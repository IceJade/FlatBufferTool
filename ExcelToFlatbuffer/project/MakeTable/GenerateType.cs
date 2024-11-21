using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MakeTable
{
    public class GenerateType : GenerateBase
    {
        #region 成员变量

        /// <summary>
        /// 已有的表列信息
        /// </summary>
        private List<TableColumnInfo> tableColumnInfoList = new List<TableColumnInfo>();

        /// <summary>
        /// 表列信息;
        /// </summary>
        private Dictionary<string, TableColumnInfo> tableColumnDic = new Dictionary<string, TableColumnInfo>();

        /// <summary>
        /// 正则表达式匹配数字
        /// </summary>
        private readonly Regex regexInt = new Regex(@"^-?\d+$");

        /// <summary>
        /// 正则表达式匹配浮点类型
        /// </summary>
        private readonly Regex regexFloat = new Regex(@"^-?(\d+)?(\.\d+)$");

        #endregion

        #region 公共接口

        public bool MakeType(string excelPath, string genPath)
        {
            Log.Print("---------------------------------------------------------------------------------------");
            Log.Print("开始生成表结构文件...");

            if(File.Exists(excelPath))
            {
                //处理文件;
                this.CreateTableDesign(excelPath, genPath);
            }
            else
            {
                // 判断表格源文件是否存在
                if(!Directory.Exists(excelPath))
                {
                    Log.Error("Can not find table path, {0}", excelPath);
                    ErrorLog.Error("Can not find table path, {0}", excelPath);
                    return false;
                }

                // 遍历文件;
                DirectoryInfo TheFolder = new DirectoryInfo(excelPath);
                foreach (FileInfo fileInfo in TheFolder.GetFiles("*.xlsm"))//遍历文件夹下所有文件
                {
                    if (!fileInfo.Name.ToLower().EndsWith(Const.g_ExcelFileExtensionName))
                        continue;

                    if (fileInfo.Name.ToLower().StartsWith(Const.g_TmpFileName))
                        continue;

                    // 创建表结构文件
                    this.CreateTableDesign(fileInfo.FullName, genPath);
                }

                System.Threading.Thread.Sleep(200);
            }

            return true;
        }

        #endregion

        #region 私有接口

        /// <summary>
        /// 处理表结构,识别列名以及数据类型
        /// </summary>
        /// <param name="excelFile">Excel文件路径</param>
        private bool CreateTableDesign(string excelFile, string genPath)
        {
            this.tableColumnDic.Clear();

            try
            {
                if (!excelFile.EndsWith(".xlsm"))
                {
                    Log.Error("The file is not excel, {0}", excelFile);
                    return false;
                }

                FileStream fs = new FileStream(excelFile, FileMode.Open, FileAccess.Read);
                XSSFWorkbook workbook = new XSSFWorkbook(fs);
                var sheets = workbook.GetEnumerator();

                string sheetName = "";
                string tableName = "";
                while (sheets.MoveNext())
                {
                    ISheet sheet = sheets.Current;
                    sheetName = sheet.SheetName;

                    // 不符合规则的Sheet页跳过
                    tableName = ToolUtils.GetTableName(sheetName);
                    if(string.IsNullOrEmpty(tableName))
                        continue;

                    if (sheet.LastRowNum < 3)
                    {
                        Log.Error($"Excel文件格式错误,至少需要三行,且前三行为表结构定义!{excelFile}");
                        return false;
                    }

                    // 取第二行(字段名称)
                    IRow columnNameRow = sheet.GetRow(1);
                    // 取第三行(字段类型)
                    IRow dataTypeRow = sheet.GetRow(2);
                    // 取第四行(客户端/服务器端使用的字段)
                    IRow tagTypeRow = sheet.GetRow(3);

                    if (dataTypeRow.LastCellNum != columnNameRow.LastCellNum)
                    {
                        Log.Error($"Excel文件格式错误, 第二行和第三行列数不一致!{excelFile}");
                        return false;
                    }

                    // 遍历Cell(从第2列开始遍历,第1列为说明)
                    for (int j = columnNameRow.FirstCellNum + 1; j < columnNameRow.LastCellNum; ++j)
                    {
                        if(Config.Instance.IsOpen("IsClientOrServerUsedFlagEnable"))
                        {
                            ICell tagTypeCell = tagTypeRow.GetCell(j);
                            // 字段检查(客户端用还是服务器用)
                            if (null != tagTypeCell && IsSkipColumn(tagTypeCell.StringCellValue.Trim()))
                                continue;
                        }

                        ICell columnNameCell = columnNameRow.GetCell(j);
                        if (columnNameCell == null)
                        {
                            Log.Error($"字段名没有配置! 行号:2, 列:{j}, 文件:{excelFile}");
                            return false;
                        }

                        if (columnNameCell.CellType != CellType.String)
                            break;

                        ICell dataTypeCell = dataTypeRow.GetCell(j);
                        if (dataTypeCell == null)
                        {
                            Log.Error($"数据类型没有配置! 行号:3, 列:{j}, 文件:{excelFile}");
                            return false;
                        }

                        if (dataTypeCell.CellType != CellType.String)
                        {
                            Log.Error("The cell type is not string, row index:{0}, column index:{1}, file:{2}", 3, j, excelFile);
                            return false;
                        }

                        string columnName = columnNameCell.StringCellValue;
                        if (string.IsNullOrEmpty(columnName))
                        {
                            Log.Error("The cell value is null or empty, row index:{0}, column index:{1}, file:{2}", 2, j, excelFile);
                            return false;
                        }

                        string dataType = dataTypeCell.StringCellValue;
                        if (string.IsNullOrEmpty(dataType))
                        {
                            Log.Error("The cell value is null or empty, row index:{0}, column index:{1}, file:{2}", 2, j, excelFile);
                            return false;
                        }

                        this.tableColumnDic.Add(columnName, new TableColumnInfo(columnName, dataType, j));
                    }

                    // 加载已有的表结构文件
                    this.LoadDesignFile(tableName, genPath);

                    // 检查并刷新表结构文件
                    this.CheckAndUpdateColumnInfo();

                    // 保存表结构文件
                    this.SaveFile(tableName, genPath);
                }
            }
            catch(Exception e)
            {
                Log.Error($"文件 {excelFile} 被占用, 请关闭后再执行!");
                ErrorLog.Error($"文件 {excelFile} 被占用, 请关闭后再执行!");
            }

            return true;
        }

        /// <summary>
        /// 获得列类型
        /// </summary>
        /// <param name="columnValue"></param>
        /// <returns></returns>
        private E_ColumnType GetTableColumnType(string columnValue, out string mainSeparator, out string childSeparator)
        {
            mainSeparator = string.Empty;
            childSeparator = string.Empty;

            int lineCount = columnValue.IndexOf(Const.g_VerticalLineSeparator);
            int semicolonCount = columnValue.IndexOf(Const.g_CommaSeparator);

            if (lineCount <= 0 || semicolonCount <= 0)
                return E_ColumnType.Unknow;

            mainSeparator = Const.g_VerticalLineSeparator;
            childSeparator = Const.g_CommaSeparator;

            if (lineCount < semicolonCount)
            {
                mainSeparator = Const.g_CommaSeparator;
                childSeparator = Const.g_VerticalLineSeparator;
            }

            string[] array = columnValue.Split(mainSeparator);
            if(null != array && array.Length > 0)
            {
                int i = 0;

                int key;
                int value;

                int keyType = 0;         // 0-int; 1-string;
                int valueType = 0;      // 0-int; 1-string;

                List<string> keys = new List<string>();

                for (i = 0; i < array.Length; i++)
                {
                    string[] subArray = array[i].Split(childSeparator);
                    if (null == subArray)
                        continue;

                    if (subArray.Length != 2)
                        return E_ColumnType.Array_Table;

                    // Key重复,那么为Table类型;
                    if(keys.Contains(subArray[0]))
                        return E_ColumnType.Array_Table;

                    keys.Add(subArray[0]);

                    if (!int.TryParse(subArray[0], out key))
                        keyType = 1;

                    if (!int.TryParse(subArray[1], out value))
                        valueType = 1;
                }

                // 说明为Dictionary类型
                if (i >= array.Length)
                {// 进一步判断Dictionary的key和value类型
                    if (keyType == 0 && valueType == 0)
                        return E_ColumnType.Dictionary_II;

                    if (keyType == 0 && valueType == 1)
                        return E_ColumnType.Dictionary_IS;

                    if (keyType == 1 && valueType == 0)
                        return E_ColumnType.Dictionary_SI;

                    if (keyType == 1 && valueType == 1)
                        return E_ColumnType.Dictionary_SS;
                }
            }

            return E_ColumnType.Array_Table;
        }

        /// <summary>
        /// 检查并更新列信息
        /// </summary>
        private void CheckAndUpdateColumnInfo()
        {
            string columnName = string.Empty;
            for(int i = 0; i < this.tableColumnInfoList.Count; i++)
            {
                columnName = this.tableColumnInfoList[i].name;
                if (!string.IsNullOrEmpty(columnName) 
                    && this.tableColumnDic.ContainsKey(columnName))
                {
                    if(this.tableColumnDic[columnName].dataType != this.tableColumnInfoList[i].dataType)
                    {
                        if (columnName.ToLower().StartsWith(Const.g_ColumnNamePara))
                        {
                            Log.Print("If the column name contains 'para', then it's data type to be fixed string.");
                            this.tableColumnInfoList[i].SetDataType(E_ColumnType.Fix_String);
                        }
                        else
                        {
                            if (this.tableColumnInfoList[i].dataType < this.tableColumnDic[columnName].dataType)
                            {
                                Log.Error("The data type of column {0} is error, old type : {1}, new type : {2}, need to use {2}.", columnName,
                                    this.tableColumnInfoList[i].dataType.ToString(), this.tableColumnDic[columnName].dataType.ToString());
                            }
                            else
                            {
                                Log.Warning("The data type of column {0} is different, old type : {1}, new type : {2}, currently using {1}.", columnName,
                                this.tableColumnInfoList[i].dataType.ToString(), this.tableColumnDic[columnName].dataType.ToString());
                            }
                        }
                    }

                    // 更新列索引
                    if (this.tableColumnDic[columnName].columnIndex != this.tableColumnInfoList[i].columnIndex)
                        this.tableColumnInfoList[i].columnIndex = this.tableColumnDic[columnName].columnIndex;

                    this.tableColumnDic[columnName] = this.tableColumnInfoList[i];
                }
            }
        }

        /// <summary>
        /// 保存文件结构
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="savePath"></param>
        /// <returns></returns>
        private bool SaveFile(string tableName, string savePath)
        {
            if(this.tableColumnInfoList.Count <= 0 && this.tableColumnDic.Count <= 0)
            {
                Log.Warning("The file {0} have nothing.", tableName);
                return true;
            }

            string fileName = tableName + Const.g_TextFileExtensionName;
            string saveFile = Path.Combine(ToolUtils.GetPath(E_PathType.Design, savePath), fileName);

            Log.Print("create table design => {0}", saveFile);

            using (FileStream fileStream = new FileStream(saveFile, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    List<TableColumnInfo> columnList = new List<TableColumnInfo>();
                    columnList.AddRange(this.tableColumnInfoList);

                    foreach (var item in tableColumnDic)
                    {
                        var find = columnList.Find(o => o.name == item.Value.name);
                        if (null == find)
                            columnList.Add(item.Value);
                    }

                    foreach (var item in columnList)
                        writer.WriteLine(item.GetString());

                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                }

                fileStream.Close();
                fileStream.Dispose();
            }

            return true;
        }

        /// <summary>
        /// 加载表格结构文件
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        private bool LoadDesignFile(string tableName, string genPath)
        {
            string fileName = tableName + Const.g_TextFileExtensionName;
            string designFile = Path.Combine(ToolUtils.GetPath(E_PathType.Design, genPath), fileName);

            // 清理数据;
            this.tableColumnInfoList.Clear();

            if (!File.Exists(designFile))
                return false;

            using (FileStream fileStream = new FileStream(designFile, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                            this.tableColumnInfoList.Add(TableColumnInfo.Create(line));
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
        /// 加载表格结构文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private List<TableColumnInfo> GetDesignInfo(string designFile)
        {
            if (!File.Exists(designFile))
            {
                Log.Error("file ({0}) is not find.", designFile);
                return null;
            }

            List<TableColumnInfo> columnInfoList = new List<TableColumnInfo>();
            using (FileStream fileStream = new FileStream(designFile, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                            columnInfoList.Add(TableColumnInfo.Create(line));
                    }

                    reader.Close();
                    reader.Dispose();
                }

                fileStream.Close();
                fileStream.Dispose();
            }

            return columnInfoList;
        }

        #endregion
    }
}
