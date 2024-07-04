
using FlatBuffers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

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

        /// <summary>
        /// 数组分隔符
        /// </summary>
        private char[] split_chars = new char[] { '|', ';' };

        #region 公共接口

        /// <summary>
        /// 生成二进制文件
        /// </summary>
        /// <param name="tablePath"></param>
        /// <param name="binaryPath"></param>
        /// <returns></returns>
        public bool MakeBinary(string tablePath, string genPath)
        {
            Log.Print("---------------------------------------------------------------------------------------");
            Log.Print("开始生成FlatBuffer二进制数据文件...");

            if (FileUtils.Exists(tablePath))
            {
                // 生成二进制文件
                if(!this.CreateDataFile(tablePath, genPath))
                {
                    Log.Print("生成二进制失败, {0}", tablePath);
                }

                // 创建ID和行数的索引文件;
                this.CreateIndexIdDicFile(tablePath, genPath);
            }
            else
            {
                // 分支文件名
                string branchFile;
                // 分支路径
                string branchPath;
                // 分支保存路径
                string branchSavePath = "";
                // 路径分段
                string[] separatorPath = null;

                // 遍历文件夹;
                DirectoryInfo TheFolder = new DirectoryInfo(tablePath);
                DirectoryInfo[] directoryInfos = TheFolder.GetDirectories();
                foreach (FileInfo fileInfo in TheFolder.GetFiles("*.xml"))//遍历文件夹下所有文件
                {
                    if (!fileInfo.Name.ToLower().EndsWith(Const.g_XMLFileExtensionName))
                        continue;

                    if (ToolUtils.IsIgnoreTable(fileInfo.Name))
                        continue;

                    var result = ToolUtils.CheckTableFullName(fileInfo.FullName);
                    if (result != E_TableNameErrorType.Success)
                        continue;

                    if (!this.CreateDataFile(fileInfo.FullName, genPath))
                    {
                        Log.Print("生成二进制失败, {0}", fileInfo.FullName);
                    }

                    // 创建ID和行数的索引文件;
                    this.CreateIndexIdDicFile(fileInfo.FullName, genPath);

                    // 递归分支的表格
                    if (CommonData._is_recursive_flatbuffer && null != directoryInfos && directoryInfos.Length > 0)
                    {
                        for (int i = 0; i < directoryInfos.Length; i++)
                        {
                            branchPath = PathUtils.GetFullPath(directoryInfos[i].FullName);
                            branchFile = PathUtils.Combine(branchPath, fileInfo.Name);
                            if (FileUtils.Exists(branchFile))
                            {
                                separatorPath = branchPath.Split(Const.path_separator);

                                // 分支文件保存路径
                                if(null != separatorPath && separatorPath.Length > 0)
                                    branchSavePath = separatorPath[separatorPath.Length - 1];

                                // 创建flatbuffer数据
                                if (!this.CreateDataFile(branchFile, genPath, branchSavePath))
                                {
                                    Log.Print("生成二进制失败, {0}", branchFile);
                                }

                                // 创建ID和行数的索引文件;
                                this.CreateIndexIdDicFile(branchFile, genPath, branchSavePath);
                            }
                        }
                    }
                }
            }

            

            // 创建表格索引存储偏移量文件;
            //if (!this.CreateTableOffsetDicFile(genPath))
            //    return false;

            return true;
        }

        #endregion

        #region 私有接口

        /// <summary>
        /// 创建数据文件
        /// </summary>
        /// <param name="xmlFile"></param>
        /// <param name="designFile"></param>
        /// <param name="genPath"></param>
        private bool CreateDataFile(string xmlFile, string genPath, string subPath = "")
        {
            string fileName = PathUtils.GetFileNameWithoutExtension(xmlFile);

            string binPath = ToolUtils.GetPath(E_PathType.Binary, genPath);
            if(!string.IsNullOrEmpty(subPath))
                binPath = PathUtils.Combine(binPath, subPath);

            try
            {
                if (!DirectoryUtils.Exists(binPath))
                    DirectoryUtils.CreateDirectory(binPath);
            }
            catch (Exception e)
            {
                Log.Error("创建Bin目录失败! error:{0}, path:{1}, in function CreateDataFile.", e.Message, binPath);
                ErrorLog.Error("创建Bin目录失败! error:{0}, path:{1}, in function CreateDataFile.", e.Message, binPath);
            }

            string binFile = PathUtils.Combine(binPath, fileName + Const.g_BytesFileExtensionName);
            Log.Print("create binary => {0}", binFile);

            string designFile = PathUtils.Combine(ToolUtils.GetPath(E_PathType.Design, genPath), fileName + Const.g_TextFileExtensionName);
            this.LoadDesignFile(designFile);

            XmlDocument xmldoc = new XmlDocument();
            
            try
            {
                xmldoc.Load(xmlFile);
            }
            catch (Exception e)
            {
                Log.Error("加载xml文件异常! error:{0}, xml:{1}", e.Message, xmlFile);
                ErrorLog.Error("加载xml文件异常! error:{0}, xml:{1}", e.Message, xmlFile);

                return false;
            }

            XmlNodeList xmlNodeList = xmldoc.DocumentElement.ChildNodes;

            // 部分XML格式没统一,外面又加了一层<Group>的节点,故这里判断一下
            if (null != xmldoc.DocumentElement.FirstChild 
                && xmldoc.DocumentElement.FirstChild.ChildNodes.Count > 0 
                && xmldoc.DocumentElement.FirstChild.Name != Const.g_XmlParseElementName)
                xmlNodeList = xmldoc.DocumentElement.FirstChild.ChildNodes;

            int fileSize = xmldoc.InnerXml.Length;
            FlatBufferBuilder fbBuilder = new FlatBufferBuilder(fileSize);

            int dataCount = 0;
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                // 空行跳过
                if (null == xmlNodeList[i] || null == xmlNodeList[i].Attributes)
                    continue;

                // 没有ID属性,那么跳过
                if (!ToolUtils.IsContainAttributeId(xmlNodeList[i].Attributes))
                {
                    // 提示没有配置ID
                    ErrorLog.Error("存在没有配置id的行! file:{0}", xmlFile);
                    Log.Error("存在没有配置id的行! file:{0}", xmlFile);

                    continue;
                }

                // 获得ID的值
                string strIdValue = xmlNodeList[i].Attributes["id"].Value;
                // 过滤数据类型配置行
                E_ColumnType columnType = ToolUtils.GetDataType(strIdValue);
                if (columnType != E_ColumnType.Unknow)
                    continue;

                dataCount++;
            }
            
            Offset<int>[] offsets = new Offset<int>[dataCount];

            ushort index = 0;
            string columnName = string.Empty;
            string columnValue = string.Empty;

            // 列数量
            int columnCount = this.TableColumnInfoList.Count;

            // 列值;
            ArrayList columnValueList = new ArrayList(columnCount);

            this.TableIndexIdList.Clear();

            // 遍历行数据;
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                // 空行跳过
                if (null == xmlNodeList[i] || null == xmlNodeList[i].Attributes)
                    continue;

                // 没有ID属性,那么跳过
                if (!ToolUtils.IsContainAttributeId(xmlNodeList[i].Attributes))
                {
                    // 提示没有配置ID
                    ErrorLog.Error("存在没有配置id的行! file:{0}", xmlFile);
                    Log.Error("存在没有配置id的行! file:{0}", xmlFile);

                    continue;
                }

                // 获得ID的值
                string strIdValue = xmlNodeList[i].Attributes["id"].Value;
                // 过滤数据类型配置行
                E_ColumnType columnType = ToolUtils.GetDataType(strIdValue);
                if (columnType != E_ColumnType.Unknow)
                    continue;

                // 清理行数据
                columnValueList.Clear();

                for (int j = 0; j < columnCount; j++)
                {
                    columnName = this.TableColumnInfoList[j].name.Trim();
                    if (null != xmlNodeList[i].Attributes[columnName])
                    {
                        string srcColumnValue = xmlNodeList[i].Attributes[columnName].Value;
                        columnValue = xmlNodeList[i].Attributes[columnName].Value.Trim();

                        if(srcColumnValue != columnValue)
                        {
                            // 没有ID属性,那么跳过
                            if (!ToolUtils.IsContainAttributeId(xmlNodeList[i].Attributes))
                            {
                                // 提示没有配置ID
                                ErrorLog.Error("存在没有配置id的行! file:{0}", xmlFile);
                                Log.Error("存在没有配置id的行! file:{0}", xmlFile);
                            }
                            else
                            {
                                string strId = xmlNodeList[i].Attributes["id"].Value;
                                Log.Error("The value have blank space, table : {0}, id : {1}, column : {2}, value : {3}", xmlFile, strId, columnName, srcColumnValue);
                                ErrorLog.Error("config error => 配置的值含有空格, table : {0}, id : {1}, column : {2}, value : {3}", xmlFile, strId, columnName, srcColumnValue);
                            }
                        }
                    }
                    else
                        columnValue = string.Empty;

                    // 检查行数是否超过ushort的最大值
                    if (index >= ushort.MaxValue)
                    {
                        Log.Error("Row counts of {0} is over max limit, max : {1}", fileName, ushort.MaxValue);
                        ErrorLog.Error("config error => Row counts of {0} is over max limit, max : {1}", xmlFile, ushort.MaxValue);
                    }

                    if(columnName.ToLower() == Const.g_Id && index <= ushort.MaxValue)
                    {
                        // 检查ID是否重复
                        var find = this.TableIndexIdList.Find(o => o._id == columnValue);
                        if(null != find)
                        {
                            Log.Error("The id is repeat, table : {0}, id : {1}", xmlFile, columnValue);
                            ErrorLog.Error("config error => id {0} 配置重复, file : {1}", columnValue, xmlFile);
                        }

                        // 检查ID是否超过int的最大值
                        if(!string.IsNullOrEmpty(columnValue.Trim()))
                        {
                            long longValue = 0;
                            if(long.TryParse(columnValue, out longValue))
                            {
                                if(longValue >= int.MaxValue)
                                {
                                    Log.Error("The value of id must be less than int.MaxValue[{0}], table : {1}, id : {2}", int.MaxValue, xmlFile, columnValue);
                                    ErrorLog.Error("config error => The value of id must be less than int.MaxValue[{0}], table : {1}, id : {2}", int.MaxValue, xmlFile, columnValue);
                                }
                            }
                            else
                            {
                                //Log.Warning("The id is not integer, table : {0}, id : {1}", xmlFile, columnValue);
                            }
                        }
                        else
                        {
                            Log.Error("The value of id must be not empty or space, table : {0}, id : {1}", xmlFile, columnValue);
                            ErrorLog.Error("config error => The value of id must be not empty or space, table : {0}, id : {1}", xmlFile, columnValue);
                        }

                        if(!string.IsNullOrEmpty(columnValue))
                            this.TableIndexIdList.Add(new TableIndexID(columnValue, index, this.TableColumnInfoList[j].dataType));

                        
                    }

                    // 获取列数据
                    this.AddColumnArrayList(ref columnValueList, fbBuilder, columnValue, this.TableColumnInfoList[j]);
                }

                // 开始行;
                fbBuilder.StartTable(columnCount);

                // 将列数据添加到flatbuffer
                this.AddDataRowToFlatBuffer(fbBuilder, columnValueList);

                // 结束行
                offsets[index] = new Offset<int>(fbBuilder.EndTable());

                index++;
            }

            this.CreateFlatBuffer(fbBuilder, offsets);

            byte[] buffers = fbBuilder.SizedByteArray();

            // 如果文件存在, 那么先删除
            if (FileUtils.Exists(binFile))
                FileUtils.Delete(binFile);

            try
            {
                using (FileStream fileStream = new FileStream(binFile, FileMode.CreateNew, FileAccess.Write))
                {
                    fileStream.Write(buffers, 0, buffers.Length);
                    fileStream.Flush();
                    fileStream.Close();
                    fileStream.Dispose();
                }
            }
            catch (Exception e)
            {
                Log.Error("创建文件失败, error:{0}, file:{1}", e.Message, binFile);
                ErrorLog.Error("创建文件失败, error:{0}, file:{1}", e.Message, binFile);
            }

            return true;
        }

        /// <summary>
        /// 创建表格ID与索引对应关系文件
        /// </summary>
        /// <param name="genPath"></param>
        /// <returns></returns>
        private bool CreateIndexIdDicFile(string xmlFile, string genPath, string subPath = "")
        {
            if (this.TableIndexIdList.Count <= 0)
            {
                Log.Warning("The table {0} have nothing.", xmlFile);
                return true;
            }

            string fileName = PathUtils.GetFileNameWithoutExtension(xmlFile);

            string idsPath = ToolUtils.GetPath(E_PathType.Ids, genPath);
            if(!string.IsNullOrEmpty(subPath))
                idsPath = PathUtils.Combine(idsPath, subPath);

            try
            {
                if (!DirectoryUtils.Exists(idsPath))
                    DirectoryUtils.CreateDirectory(idsPath);
            }
            catch (Exception e)
            {
                Log.Error("创建索引目录失败! error:{0}, path:{1}, in function CreateIndexIdDicFile.", e.Message, idsPath);
                ErrorLog.Error("创建索引目录失败! error:{0}, path:{1}, in function CreateIndexIdDicFile.", e.Message, idsPath);
            }

            string idsFile = PathUtils.Combine(idsPath, string.Format(Const.g_TableIdsFileName, fileName));

            Log.Print("create table index file => {0}", idsFile);

            // 如果文件存在, 那么先删除
            if (FileUtils.Exists(idsFile))
                FileUtils.Delete(idsFile);

            try
            {
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
            }
            catch (Exception e)
            {
                Log.Error("创建文件失败, error:{0}, file:{1}, in function CreateIndexIdDicFile.", e.Message, idsFile);
                ErrorLog.Error("创建文件失败, error:{0}, file:{1}, in function CreateIndexIdDicFile.", e.Message, idsFile);
            }

            return true;
        }

        /// <summary>
        /// 存储表格偏移
        /// </summary>
        /// <param name="genPath"></param>
        /// <returns></returns>
        /*
        private bool CreateTableOffsetDicFile(string genPath)
        {
            string idsPath = ToolUtils.GetPath(E_PathType.Ids, genPath);
            string offsetFile = PathUtils.Combine(idsPath, Const.g_TableOffsetFileName);

            Log.Print("create table offset file => {0}", offsetFile);

            using (FileStream fileStream = new FileStream(offsetFile, FileMode.CreateNew, FileAccess.Write))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    // 文件标记;
                    binaryWriter.Write(new char[] { 'O', 'F', 'F', 'S', 'E', 'T', ':' });
                    // 数量;
                    binaryWriter.Write(this.TableOffsetDic.Count);

                    byte[] buffer = null;
                    foreach (var item in this.TableOffsetDic)
                    {
                        var utf8StringLen = Encoding.UTF8.GetByteCount(item.Key);
                        buffer = new byte[utf8StringLen];
                        Encoding.UTF8.GetBytes(item.Key, 0, item.Key.Length, buffer, 0);

                        // 存储字符串的长度
                        binaryWriter.Write(buffer.Length);
                        // 存储表名;
                        binaryWriter.Write(buffer);
                        // 表的偏移量;
                        binaryWriter.Write(item.Value);
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
        */

        /// <summary>
        /// 加载表格结构文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool LoadDesignFile(string file)
        {
            if (!FileUtils.Exists(file))
                return false;

            // 清理数据;
            this.TableColumnInfoList.Clear();

            try
            {
                using (FileStream fileStream = new FileStream(file, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string line;
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            if (!string.IsNullOrEmpty(line))
                            {
                                var columnInfo = TableColumnInfo.Create(line);
                                if (null != columnInfo)
                                    this.TableColumnInfoList.Add(columnInfo);
                                else
                                {
                                    Log.Print("数据类型格式配置错误,请检查文件: {0}", file);
                                    ErrorLog.Print("数据类型格式配置错误,请检查文件: {0}", file);
                                }
                            }
                        }

                        reader.Close();
                        reader.Dispose();
                    }

                    fileStream.Close();
                    fileStream.Dispose();
                }
            }
            catch(Exception e)
            {
                Log.Error("打开文件失败! error:{0}, file:{1}, in function GenerateBinary::LoadDesignFile.", e.Message, file);
                ErrorLog.Error("打开文件失败! error:{0}, file:{1}, in function GenerateBinary::LoadDesignFile.", e.Message, file);
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
                        int value = int.MinValue;

                        if(!string.IsNullOrEmpty(columnValue))
                            int.TryParse(columnValue, out value);

                        arrayList.Add(value);

                        break;
                    }
                case E_ColumnType.Single_Short:
                    {
                        short value = short.MinValue;

                        if (!string.IsNullOrEmpty(columnValue))
                            short.TryParse(columnValue, out value);

                        arrayList.Add(value);

                        break;
                    }
                case E_ColumnType.Single_Bool:
                    {
                        bool value = false;

                        if(!string.IsNullOrEmpty(columnValue))
                            bool.TryParse(columnValue, out value);

                        arrayList.Add(value);

                        break;
                    }
                case E_ColumnType.Single_Float:
                    {
                        float value = float.MinValue;
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
                            string[] array = columnValue.Split(Const.g_split_chars);
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
                case E_ColumnType.Array_Short:
                    {
                        if (!string.IsNullOrEmpty(columnValue))
                        {
                            string[] array = columnValue.Split(Const.g_split_chars);
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
                        break;
                    }
                case E_ColumnType.Array_Float:
                    {
                        if(!string.IsNullOrEmpty(columnValue))
                        {
                            string[] array = columnValue.Split(Const.g_split_chars);
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
                            string[] array = columnValue.Split(Const.g_split_chars);

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
                bool isInt = arrayList[i] is int;
                bool isBool = arrayList[i] is bool;
                bool isShort = arrayList[i] is short;
                bool isFloat = arrayList[i] is float;
                bool isStringOffset = arrayList[i] is StringOffset;
                bool isVectorOffset = arrayList[i] is VectorOffset;

                if(isInt)
                    fbBuilder.AddInt(i, (int)arrayList[i], 0);
                else if(isShort)
                    fbBuilder.AddShort(i, (short)arrayList[i], 0);
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
        /// 将数据添加到缓存
        /// </summary>
        /// <param name="fbBuilder"></param>
        /// <param name="tableColumnInfo"></param>
        /// <param name="columnValue"></param>
        private void AddDataRowToFlatBuffer(FlatBufferBuilder fbBuilder, int j, string columnValue)
        {
            TableColumnInfo tableColumnInfo = this.TableColumnInfoList[j];

            switch (tableColumnInfo.dataType)
            {
                case E_ColumnType.Single_Int:
                    {
                        int value = -1;
                        int.TryParse(columnValue, out value);
                        fbBuilder.AddInt(j, value, 0);

                        break;
                    }
                case E_ColumnType.Single_Short:
                    {
                        short value = 0;
                        short.TryParse(columnValue, out value);
                        fbBuilder.AddShort(j, value, 0);

                        break;
                    }
                case E_ColumnType.Single_Bool:
                    {
                        bool value = false;
                        bool.TryParse(columnValue, out value);
                        fbBuilder.AddBool(j, value, false);

                        break;
                    }
                case E_ColumnType.Single_Float:
                    {
                        float value = 0;
                        float.TryParse(columnValue, out value);
                        fbBuilder.AddFloat(j, value, 0.0f);

                        break;
                    }
                case E_ColumnType.Single_String:
                case E_ColumnType.Fix_String:
                    {
                        var stringOffset = fbBuilder.CreateString(columnValue);
                        fbBuilder.AddOffset(j, stringOffset.Value, 0);

                        break;
                    }
                case E_ColumnType.Single_Table:
                    {
                        break;
                    }
                case E_ColumnType.Array_Int:
                    {
                        if(!string.IsNullOrEmpty(columnValue))
                        {
                            string[] array = columnValue.Split(Const.g_VerticalLineSeparator);
                            if (null == array || array.Length <= 1)
                                array = columnValue.Split(Const.g_SemicolonSeparator);

                            int[] data = new int[array.Length];

                            for (int k = 0; k < array.Length; k++)
                                int.TryParse(array[k], out data[k]);

                            VectorOffset vectorOffset = this.CreateVectorOffset_Int(fbBuilder, data);
                            fbBuilder.AddOffset(j, vectorOffset.Value, 0);
                        }
                        else
                        {
                            fbBuilder.AddOffset(j, 0, 0);
                        }

                        break;
                    }
                case E_ColumnType.Array_Short:
                    {
                        string[] array = columnValue.Split(Const.g_VerticalLineSeparator);
                        if (null == array || array.Length <= 1)
                            array = columnValue.Split(Const.g_SemicolonSeparator);

                        short[] data = new short[array.Length];

                        for (int k = 0; k < array.Length; k++)
                            short.TryParse(array[k], out data[k]);

                        VectorOffset vectorOffset = this.CreateVectorOffset_Short(fbBuilder, data);
                        fbBuilder.AddOffset(j, vectorOffset.Value, 0);

                        break;
                    }
                case E_ColumnType.Array_bool:
                    {
                        break;
                    }
                case E_ColumnType.Array_Float:
                    {
                        string[] array = columnValue.Split(Const.g_VerticalLineSeparator);
                        if (null == array || array.Length <= 1)
                            array = columnValue.Split(Const.g_SemicolonSeparator);

                        float[] data = new float[array.Length];

                        for (int k = 0; k < array.Length; k++)
                            float.TryParse(array[k], out data[k]);

                        VectorOffset vectorOffset = this.CreateVectorOffset_Float(fbBuilder, data);
                        fbBuilder.AddOffset(j, vectorOffset.Value, 0);

                        break;
                    }
                case E_ColumnType.Array_String:
                case E_ColumnType.Array_Table:
                case E_ColumnType.Dictionary_II:
                case E_ColumnType.Dictionary_IS:
                case E_ColumnType.Dictionary_SI:
                case E_ColumnType.Dictionary_SS:
                    {
                        if(!string.IsNullOrEmpty(columnValue))
                        {
                            string[] array = columnValue.Split(Const.g_VerticalLineSeparator);
                            if (null == array || array.Length <= 1)
                                array = columnValue.Split(Const.g_SemicolonSeparator);

                            VectorOffset vectorOffset = this.CreateVectorOffset_String(fbBuilder, array);
                            fbBuilder.AddOffset(j, vectorOffset.Value, 0);
                        }
                        else
                        {
                            fbBuilder.AddOffset(j, 0, 0);
                        }

                        break;
                    }
                default:
                    break;
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
