
using FlatBuffers;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace MakeTable
{
    class TableIndexID
    {
        public string _id;
        public ushort _index;
        public E_ColumnType _dataType;

        public TableIndexID(string id, ushort index, E_ColumnType dataType)
        {
            this._id = id;
            this._index = index;
            this._dataType = dataType;
        }
    }

    /// <summary>
    /// 生成二进制文件 
    /// </summary>
    class GenerateBinary
    {
        /// <summary>
        /// 表列信息
        /// </summary>
        private List<TableColumnInfo> TableColumnInfoList = new List<TableColumnInfo>();

        /// <summary>
        /// 表ID与索引信息
        /// </summary>
        private List<TableIndexID> TableIndexIdList = new List<TableIndexID>();

        #region 公共接口

        /// <summary>
        /// 生成二进制文件
        /// </summary>
        /// <param name="excelPath"></param>
        /// <param name="genPath"></param>
        /// <returns></returns>
        public bool MakeBinary(string excelPath, string genPath)
        {
            Log.Print("---------------------------------------------------------------------------------------");
            Log.Print("开始生成FlatBuffer二进制数据文件...");

            if (File.Exists(excelPath))
            {
                // 生成二进制文件
                this.CreateDataFile(excelPath, genPath);

                // 创建ID和行数的索引文件;
                this.CreateIndexIdDicFile(excelPath, genPath);
            }
            else
            {
                // 遍历文件夹;
                DirectoryInfo TheFolder = new DirectoryInfo(excelPath);
                DirectoryInfo[] directoryInfos = TheFolder.GetDirectories();
                foreach (FileInfo fileInfo in TheFolder.GetFiles("*.xlsm"))//遍历文件夹下所有文件
                {
                    if (!fileInfo.Name.ToLower().EndsWith(Const.g_ExcelFileExtensionName))
                        continue;

                    if (fileInfo.Name.ToLower().StartsWith(Const.g_TmpFileName))
                        continue;

                    if (!this.CreateDataFile(fileInfo.FullName, genPath))
                    {
                        Log.Print("生成二进制失败, {0}", fileInfo.FullName);
                    }
                }
            }

            return true;
        }

        #endregion

        #region 私有接口

        /// <summary>
        /// 创建数据文件
        /// </summary>
        /// <param name="excelFile"></param>
        /// <param name="genPath"></param>
        private bool CreateDataFile(string excelFile, string genPath)
        {
            string fileName = Path.GetFileNameWithoutExtension(excelFile);

            string binPath = ToolUtils.GetPath(E_PathType.Binary, genPath);
            if (!Directory.Exists(binPath))
                Directory.CreateDirectory(binPath);

            try
            {
                FileStream fs = new FileStream(excelFile, FileMode.Open, FileAccess.Read);
                XSSFWorkbook workbook = new XSSFWorkbook(fs);
                var sheets = workbook.GetEnumerator();

                string designFile = "";
                string sheetName = "";
                string tableName = "";
                while (sheets.MoveNext())
                {
                    ISheet sheet = sheets.Current;
                    sheetName = sheet.SheetName;

                    // 不符合规则的Sheet页跳过
                    tableName = ToolUtils.GetTableName(sheetName);
                    if (string.IsNullOrEmpty(tableName))
                        continue;

                    designFile = Path.Combine(ToolUtils.GetPath(E_PathType.Design, genPath), tableName + Const.g_TextFileExtensionName);
                    this.LoadDesignFile(designFile);

                    // 初始化内存长度
                    FlatBufferBuilder fbBuilder = new FlatBufferBuilder((sheet.LastRowNum - 3) * 512);
                    // 临时数组,包含注释行
                    Offset<int>[] tmpOffsets = new Offset<int>[sheet.LastRowNum - 2];

                    ushort index = 0;
                    int rowIndex = 0;
                    string columnName = string.Empty;
                    string columnValue = string.Empty;

                    // 列数量
                    int columnCount = this.TableColumnInfoList.Count;

                    // 列值;
                    ArrayList columnValueList = new ArrayList(columnCount);

                    this.TableIndexIdList.Clear();

                    // 获得列名;
                    for (int i = 4; i <= sheet.LastRowNum; i++)
                    {
                        IRow datarow = sheet.GetRow(i);
                        if (null == datarow)
                            continue;

                        // 清理行数据
                        columnValueList.Clear();

                        for (int j = 0; j < columnCount; j++)
                        {
                            columnValue = string.Empty;

                            // 对应的列索引
                            int columnIndex = this.TableColumnInfoList[j].columnIndex;

                            if (columnIndex > datarow.LastCellNum)
                            {
                                //Log.Error("column index is error, column:{0}, row:{1}, file:{2}", i + 1, j + 1, excelFile);
                                //ErrorLog.Error("column index is error, column:{0}, row:{1}, file:{2}", i + 1, j + 1, excelFile);
                            }
                            else
                            {
                                ICell cell = datarow.GetCell(columnIndex);
                                columnValue = this.GetColumnValue(cell);

                                // 检查行数是否超过ushort的最大值
                                if (index >= ushort.MaxValue)
                                {
                                    Log.Error("Row counts of {0} is over max limit, max:{1}", fileName, ushort.MaxValue);
                                    ErrorLog.Error("config error => Row counts of {0} is over max limit, max:{1}", excelFile, ushort.MaxValue);
                                }

                                // 字段名称
                                columnName = this.TableColumnInfoList[j].name;

                                // ID列索引记录
                                if (columnName.ToLower() == Const.g_Id && index <= ushort.MaxValue)
                                {
                                    if (string.IsNullOrEmpty(columnValue))
                                        break;

                                    // 检查ID是否重复
                                    var find = this.TableIndexIdList.Find(o => o._id == columnValue);
                                    if (null != find)
                                    {
                                        Log.Error($"ID({columnValue})配置重复!文件:{excelFile}");
                                        ErrorLog.Error($"ID({columnValue})配置重复!文件:{excelFile}");
                                    }

                                    // 检查ID是否超过int的最大值
                                    if (!string.IsNullOrEmpty(columnValue.Trim()))
                                    {
                                        // 如果ID数据以"#"开头代表为注释行,直接跳过
                                        if (columnValue.Trim().StartsWith("#"))
                                            break;

                                        long longValue = 0;
                                        if (long.TryParse(columnValue, out longValue))
                                        {
                                            if (longValue >= int.MaxValue)
                                            {
                                                Log.Error("The value of id must be less than int.MaxValue[{0}], table:{1}, id:{2}", int.MaxValue, excelFile, columnValue);
                                                Log.Error("config error => The value of id must be less than int.MaxValue[{0}], table:{1}, id:{2}", int.MaxValue, excelFile, columnValue);
                                            }
                                        }
                                        //else
                                        //{
                                        //    Log.Warning("The id is not integer, table:{0}, id:{1}", excelFile, columnValue);
                                        //}
                                    }
                                    else
                                    {
                                        Log.Error("The value of id must be not empty or space, table:{0}, id:{1}", excelFile, columnValue);
                                        Log.Error("config error => The value of id must be not empty or space, table:{0}, id:{1}", excelFile, columnValue);

                                        break;
                                    }

                                    if (!string.IsNullOrEmpty(columnValue))
                                        this.TableIndexIdList.Add(new TableIndexID(columnValue, index, this.TableColumnInfoList[j].dataType));

                                    index++;
                                }
                            }

                            // 获取列数据
                            this.AddColumnArrayList(ref columnValueList, fbBuilder, columnValue, this.TableColumnInfoList[j]);
                        }

                        if (columnValueList.Count > 0)
                        {
                            // 开始行;
                            fbBuilder.StartTable(columnCount);

                            // 将列数据添加到flatbuffer
                            this.AddDataRowToFlatBuffer(fbBuilder, columnValueList);

                            // 结束行
                            tmpOffsets[rowIndex] = new Offset<int>(fbBuilder.EndTable());

                            rowIndex++;
                        }
                    }

                    // 修改成实际的行数;
                    Offset<int>[] offsets = new Offset<int>[rowIndex];
                    for (int i = 0; i < offsets.Length; i++)
                        offsets[i] = tmpOffsets[i];

                    this.CreateFlatBuffer(fbBuilder, offsets);

                    string binFile = Path.Combine(binPath, tableName + Const.g_BytesFileExtensionName);
                    Log.Print("create binary => {0}", binFile);

                    byte[] buffers = fbBuilder.SizedByteArray();

                    FileStream fileWrite = new FileStream(binFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fileWrite.Write(buffers, 0, buffers.Length);
                    fileWrite.Flush();
                    fileWrite.Close();
                    fileWrite.Dispose();

                    // 创建ID和行数的索引文件;
                    this.CreateIndexIdDicFile(tableName, genPath);
                }
            }
            catch(Exception e)
            {
                Log.Error($"文件 {excelFile} 被占用, 请关闭后再执行!");
            }

            return true;
        }

        /// <summary>
        /// 获得Cell数据
        /// </summary>
        /// <returns></returns>
        private string GetColumnValue(ICell cell)
        {
            string columnValue = string.Empty;

            if (null != cell)
            {
                switch (cell.CellType)
                {
                    case CellType.Unknown:
                        {
                            break;
                        }
                    case CellType.Numeric:  // 数值型
                        {
                            columnValue = cell.NumericCellValue.ToString();
                            break;
                        }
                    case CellType.String:   // 字符串型
                        {
                            columnValue = cell.StringCellValue.Trim();
                            break;
                        }
                    case CellType.Formula:  // 公式型
                        {
                            break;
                        }
                    case CellType.Blank:    // 空值
                        {
                            break;
                        }
                    case CellType.Boolean:  // 布尔型
                        {
                            columnValue = cell.BooleanCellValue.ToString();
                            break;
                        }
                    case CellType.Error:
                        {
                            break;
                        }
                    default:
                        break;
                }
            }

            return columnValue;
        }

        /// <summary>
        /// 创建表格ID与索引对应关系文件
        /// </summary>
        /// <param name="genPath"></param>
        /// <returns></returns>
        private bool CreateIndexIdDicFile(string excelFile, string genPath, string subPath = "")
        {
            if (this.TableIndexIdList.Count <= 0)
            {
                Log.Warning("The file {0} have nothing.", excelFile);
                return true;
            }

            string fileName = Path.GetFileNameWithoutExtension(excelFile);

            string idsPath = ToolUtils.GetPath(E_PathType.Ids, genPath);
            if(!string.IsNullOrEmpty(subPath))
                idsPath = Path.Combine(idsPath, subPath);

            if (!Directory.Exists(idsPath))
                Directory.CreateDirectory(idsPath);

            string idsFile = Path.Combine(idsPath, string.Format(Const.g_TableIdsFileName, fileName));

            Log.Print("create table index file => {0}", idsFile);

            // 如果文件存在, 那么先删除
            if (File.Exists(idsFile))
                File.Delete(idsFile);

            using (FileStream fileStream = new FileStream(idsFile, FileMode.CreateNew, FileAccess.Write))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    binaryWriter.Write(new char[] { 'I', 'D', 'S', ':' });

                    int offset = 5;
                    byte[] buffer = null;

                    // 表行数;
                    binaryWriter.Write(TableIndexIdList.Count);
                    offset += 4;
                    
                    for (int i = 0; i < TableIndexIdList.Count; i++)
                    {
                        switch (TableIndexIdList[i]._dataType)
                        {
                            case E_ColumnType.Single_String:
                            case E_ColumnType.Fix_String:
                                {
                                    int utf8StringLen = Encoding.UTF8.GetByteCount(TableIndexIdList[i]._id);
                                    buffer = new byte[utf8StringLen];
                                    Encoding.UTF8.GetBytes(TableIndexIdList[i]._id, 0, TableIndexIdList[i]._id.Length, buffer, 0);

                                    int length = TableIndexIdList[i]._id.Length;
                                    binaryWriter.Write(utf8StringLen);
                                    offset += 4;

                                    binaryWriter.Write(buffer);
                                    offset += buffer.Length;

                                    break;
                                }
                            case E_ColumnType.Single_Int:
                                {
                                    int id = int.Parse(TableIndexIdList[i]._id);
                                    binaryWriter.Write(id);
                                    offset += 4;

                                    break;
                                }
                            default:
                                break;
                        }

                        binaryWriter.Write(TableIndexIdList[i]._index);
                        offset += 2;
                    }

                    binaryWriter.Flush();
                    binaryWriter.Close();
                    binaryWriter.Dispose();
                }

                fileStream.Close();
                fileStream.Dispose();
            }

            return true;
        }

        /// <summary>
        /// 加载表格结构文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool LoadDesignFile(string file)
        {
            if (!File.Exists(file))
                return false;

            // 清理数据;
            this.TableColumnInfoList.Clear();

            using (FileStream fileStream = new FileStream(file, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                            this.TableColumnInfoList.Add(TableColumnInfo.Create(line));
                    }

                    reader.Close();
                    reader.Dispose();
                }

                fileStream.Close();
                fileStream.Dispose();
            }

            return true;
        }

        /// <summary>
        /// 将值添加到列表
        /// </summary>
        private void AddColumnArrayList(ref ArrayList arrayList, FlatBufferBuilder fbBuilder, string columnValue, TableColumnInfo tableColumnInfo)
        {
            switch (tableColumnInfo.dataType)
            {
                case E_ColumnType.Single_Int:
                    {
                        int value = 0;

                        if(!string.IsNullOrEmpty(columnValue))
                            int.TryParse(columnValue, out value);

                        arrayList.Add(value);

                        break;
                    }
                case E_ColumnType.Single_Byte:
                    {
                        byte value = 0;

                        if (!string.IsNullOrEmpty(columnValue))
                            byte.TryParse(columnValue, out value);

                        arrayList.Add(value);

                        break;
                    }
                case E_ColumnType.Single_Short:
                    {
                        short value = 0;

                        if (!string.IsNullOrEmpty(columnValue))
                            short.TryParse(columnValue, out value);

                        arrayList.Add(value);

                        break;
                    }
                case E_ColumnType.Single_Long:
                    {
                        long value = 0;

                        if (!string.IsNullOrEmpty(columnValue))
                            long.TryParse(columnValue, out value);

                        arrayList.Add(value);

                        break;
                    }
                case E_ColumnType.Single_Bool:
                    {
                        bool value = false;

                        if(!string.IsNullOrEmpty(columnValue))
                        {
                            if(!bool.TryParse(columnValue, out value))
                                value = (columnValue != "0");
                        }

                        arrayList.Add(value);

                        break;
                    }
                case E_ColumnType.Single_Float:
                    {
                        float value = 0;
                        float.TryParse(columnValue, out value);
                        arrayList.Add(value);

                        break;
                    }
                case E_ColumnType.Single_String:
                case E_ColumnType.Fix_String:
                    {
                        StringOffset stringOffset = fbBuilder.CreateString(columnValue);
                        arrayList.Add(stringOffset);

                        break;
                    }
                case E_ColumnType.Single_Table:
                    {
                        break;
                    }
                case E_ColumnType.Array_Int:
                    {
                        if (!string.IsNullOrEmpty(columnValue))
                        {
                            string[] array = columnValue.Split(Const.g_VerticalLineSeparator);
                            if(null == array || array.Length <= 1)
                                array = columnValue.Split(Const.g_CommaSeparator);

                            int[] data = new int[array.Length];

                            for (int k = 0; k < array.Length; k++)
                                int.TryParse(array[k], out data[k]);

                            VectorOffset vectorOffset = this.CreateVectorOffset_Int(fbBuilder, data);
                            arrayList.Add(vectorOffset);
                        }
                        else
                        {
                            VectorOffset vectorOffset = this.CreateVectorOffset_Int(fbBuilder, null);
                            arrayList.Add(vectorOffset);
                        }

                        break;
                    }
                case E_ColumnType.Array_Byte:
                    {
                        if (!string.IsNullOrEmpty(columnValue))
                        {
                            string[] array = columnValue.Split(Const.g_VerticalLineSeparator);
                            if (null == array || array.Length <= 1)
                                array = columnValue.Split(Const.g_CommaSeparator);

                            byte[] data = new byte[array.Length];

                            for (int k = 0; k < array.Length; k++)
                                byte.TryParse(array[k], out data[k]);

                            VectorOffset vectorOffset = this.CreateVectorOffset_Byte(fbBuilder, data);
                            arrayList.Add(vectorOffset);
                        }
                        else
                        {
                            VectorOffset vectorOffset = this.CreateVectorOffset_Byte(fbBuilder, null);
                            arrayList.Add(vectorOffset);
                        }

                        break;
                    }
                case E_ColumnType.Array_Short:
                    {
                        if (!string.IsNullOrEmpty(columnValue))
                        {
                            string[] array = columnValue.Split(Const.g_VerticalLineSeparator);
                            if (null == array || array.Length <= 1)
                                array = columnValue.Split(Const.g_CommaSeparator);

                            short[] data = new short[array.Length];

                            for (int k = 0; k < array.Length; k++)
                                short.TryParse(array[k], out data[k]);

                            VectorOffset vectorOffset = this.CreateVectorOffset_Short(fbBuilder, data);
                            arrayList.Add(vectorOffset);
                        }
                        else
                        {
                            VectorOffset vectorOffset = this.CreateVectorOffset_Short(fbBuilder, null);
                            arrayList.Add(vectorOffset);
                        }

                        break;
                    }
                case E_ColumnType.Array_bool:
                    {
                        if (!string.IsNullOrEmpty(columnValue))
                        {
                            string[] array = columnValue.Split(Const.g_VerticalLineSeparator);
                            if (null == array || array.Length <= 1)
                                array = columnValue.Split(Const.g_CommaSeparator);

                            bool[] data = new bool[array.Length];

                            for (int k = 0; k < array.Length; k++)
                                bool.TryParse(array[k], out data[k]);

                            VectorOffset vectorOffset = this.CreateVectorOffset_Bool(fbBuilder, data);
                            arrayList.Add(vectorOffset);
                        }
                        else
                        {
                            VectorOffset vectorOffset = this.CreateVectorOffset_Bool(fbBuilder, null);
                            arrayList.Add(vectorOffset);
                        }

                        break;
                    }
                case E_ColumnType.Array_Float:
                    {
                        if(!string.IsNullOrEmpty(columnValue))
                        {
                            string[] array = columnValue.Split(Const.g_VerticalLineSeparator);
                            if (null == array || array.Length <= 1)
                                array = columnValue.Split(Const.g_CommaSeparator);

                            float[] data = new float[array.Length];

                            for (int k = 0; k < array.Length; k++)
                                float.TryParse(array[k], out data[k]);

                            VectorOffset vectorOffset = this.CreateVectorOffset_Float(fbBuilder, data);
                            arrayList.Add(vectorOffset);
                        }
                        else
                        {
                            VectorOffset vectorOffset = this.CreateVectorOffset_Float(fbBuilder, null);
                            arrayList.Add(vectorOffset);
                        }

                        break;
                    }
                case E_ColumnType.Array_String:
                    {
                        if (!string.IsNullOrEmpty(columnValue))
                        {
                            string[] array = columnValue.Split(Const.g_VerticalLineSeparator);
                            if (null == array || array.Length <= 1)
                                array = columnValue.Split(Const.g_CommaSeparator);

                            VectorOffset vectorOffset = this.CreateVectorOffset_String(fbBuilder, array);
                            arrayList.Add(vectorOffset);
                        }
                        else
                        {
                            VectorOffset vectorOffset = this.CreateVectorOffset_String(fbBuilder, data: null);
                            arrayList.Add(vectorOffset);
                        }

                        break;
                    }
                case E_ColumnType.Array_Table:
                case E_ColumnType.Dictionary_II:
                case E_ColumnType.Dictionary_IS:
                case E_ColumnType.Dictionary_SI:
                case E_ColumnType.Dictionary_SS:
                    {
                        if (!string.IsNullOrEmpty(columnValue))
                        {
                            string[] array = columnValue.Split(tableColumnInfo.array_separator);
                            VectorOffset vectorOffset = this.CreateVectorOffset_String(fbBuilder, array);
                            arrayList.Add(vectorOffset);
                        }
                        else
                        {
                            VectorOffset vectorOffset = this.CreateVectorOffset_String(fbBuilder, data: null);
                            arrayList.Add(vectorOffset);
                        }

                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// 将数据添加到缓存
        /// </summary>
        /// <param name="fbBuilder"></param>
        /// <param name="tableColumnInfo"></param>
        /// <param name="columnValue"></param>
        private void AddDataRowToFlatBuffer(FlatBufferBuilder fbBuilder, ArrayList arrayList)
        {
            for(int i = arrayList.Count - 1; i >= 0; i--)
            {
                bool isBool = arrayList[i] is bool;
                bool isByte = arrayList[i] is byte;
                bool isShort = arrayList[i] is short;
                bool isInt = arrayList[i] is int;
                bool isLong = arrayList[i] is long;
                bool isFloat = arrayList[i] is float;
                bool isStringOffset = arrayList[i] is StringOffset;
                bool isVectorOffset = arrayList[i] is VectorOffset;

                if(isInt)
                    fbBuilder.AddInt(i, (int)arrayList[i], 0);
                else if (isByte)
                    fbBuilder.AddByte(i, (byte)arrayList[i], 0);
                else if (isShort)
                    fbBuilder.AddShort(i, (short)arrayList[i], 0);
                else if (isLong)
                    fbBuilder.AddLong(i, (long)arrayList[i], 0);
                else if (isBool)
                    fbBuilder.AddBool(i, (bool)arrayList[i], false);
                else if (isFloat)
                    fbBuilder.AddFloat(i, (float)arrayList[i], 0.0f);
                else if (isStringOffset)
                    fbBuilder.AddOffset(i, ((StringOffset)arrayList[i]).Value, 0);
                else if (isVectorOffset)
                    fbBuilder.AddOffset(i, ((VectorOffset)arrayList[i]).Value, 0);
            }
        }

        /// <summary>
        /// 创建缓存
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="data"></param>
        private void CreateFlatBuffer(FlatBufferBuilder builder, Offset<int>[] data)
        {
            VectorOffset dataOffset = CreateDataVector(builder, data);

            builder.StartTable(1);
            builder.AddOffset(0, dataOffset.Value, 0);
            builder.Finish(builder.EndTable());
        }

        /// <summary>
        /// 创建表数据
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public VectorOffset CreateDataVector(FlatBufferBuilder builder, Offset<int>[] data) 
        { 
            builder.StartVector(4, data.Length, 4); 
            for (int i = data.Length - 1; i >= 0; i--) 
                builder.AddOffset(data[i].Value); 
            
            return builder.EndVector(); 
        }

        /// <summary>
        /// 创建整数类型的数组
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private VectorOffset CreateVectorOffset_Int(FlatBufferBuilder builder, int[] data) 
        { 
            if(null == data || data.Length <= 0)
            {
                builder.StartVector(4, 0, 4);
            }
            else
            {
                builder.StartVector(4, data.Length, 4);
                for (int i = data.Length - 1; i >= 0; i--)
                    builder.AddInt(data[i]);
            }
            
            return builder.EndVector();
        }

        /// <summary>
        /// 创建byte类型的数组
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private VectorOffset CreateVectorOffset_Byte(FlatBufferBuilder builder, byte[] data)
        {
            if (null == data || data.Length <= 0)
            {
                builder.StartVector(4, 0, 4);
            }
            else
            {
                builder.StartVector(4, data.Length, 4);
                for (int i = data.Length - 1; i >= 0; i--)
                    builder.AddByte(data[i]);
            }

            return builder.EndVector();
        }

        /// <summary>
        /// 创建short类型的数组
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private VectorOffset CreateVectorOffset_Short(FlatBufferBuilder builder, short[] data)
        {
            if (null == data || data.Length <= 0)
            {
                builder.StartVector(4, 0, 4);
            }
            else
            {
                builder.StartVector(4, data.Length, 4);
                for (int i = data.Length - 1; i >= 0; i--)
                    builder.AddShort(data[i]);
            }

            return builder.EndVector();
        }

        /// <summary>
        /// 创建short类型的数组
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private VectorOffset CreateVectorOffset_Bool(FlatBufferBuilder builder, bool[] data)
        {
            if (null == data || data.Length <= 0)
            {
                builder.StartVector(4, 0, 4);
            }
            else
            {
                builder.StartVector(4, data.Length, 4);
                for (int i = data.Length - 1; i >= 0; i--)
                    builder.AddBool(data[i]);
            }

            return builder.EndVector();
        }

        /// <summary>
        /// 创建short类型的数组
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private VectorOffset CreateVectorOffset_Float(FlatBufferBuilder builder, float[] data)
        {
            if(null == data || data.Length <= 0)
            {
                builder.StartVector(4, 0, 4);
            }
            else
            {
                builder.StartVector(4, data.Length, 4);

                for (int i = data.Length - 1; i >= 0; i--)
                    builder.AddFloat(data[i]);
            }

            return builder.EndVector();
        }

        /// <summary>
        /// 创建字符串数组
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private VectorOffset CreateVectorOffset_String(FlatBufferBuilder builder, string[] array)
        {
            if(null == array || array.Length <= 0)
            {
                return CreateVectorOffset_String(builder, data: null);
            }
            else
            {
                StringOffset[] data = new StringOffset[array.Length];

                for (int i = 0; i < array.Length; i++)
                {
                    var stringOffset = builder.CreateString(array[i]);
                    data[i] = stringOffset;
                }

                return CreateVectorOffset_String(builder, data);
            }
        }

        /// <summary>
        /// 创建字符串数组
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private VectorOffset CreateVectorOffset_String(FlatBufferBuilder builder, StringOffset[] data) 
        { 
            if(null == data || data.Length <= 0)
            {
                builder.StartVector(4, 0, 4);
            }
            else
            {
                builder.StartVector(4, data.Length, 4);
                for (int i = data.Length - 1; i >= 0; i--)
                    builder.AddOffset(data[i].Value);
            }
            
            return builder.EndVector();
        }

        #endregion
    }
}
