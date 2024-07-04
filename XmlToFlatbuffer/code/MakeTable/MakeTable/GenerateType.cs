using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace MakeTable
{
    public class GenerateType
    {
        #region 成员变量

        /// <summary>
        /// 已生成的表列信息
        /// </summary>
        private List<TableColumnInfo> tableColumnInfoList = new List<TableColumnInfo>();

        /// <summary>
        /// 当前解析的表列信息;
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

        public bool MakeType(string xmlPath, string genPath)
        {
            if (CommonData._is_gen_spriteatlas_only)
                return true;

            Log.Print("---------------------------------------------------------------------------------------");
            Log.Print("开始生成表结构文件...");

            if(FileUtils.Exists(xmlPath))
            {
                // 加载已有的配置表设计文件
                this.LoadDesignFile(xmlPath, genPath);

                //处理文件;
                return this.CreateTableDesign(xmlPath, genPath);
            }
            else
            {
                // 判断表格源文件是否存在
                if(!DirectoryUtils.Exists(xmlPath))
                {
                    Log.Error("无法找到配表路径! {0}", xmlPath);
                    ErrorLog.Error("无法找到配表路径! {0}", xmlPath);
                    return false;
                }

                // 分支文件名
                string branchFile;

                // 遍历文件;
                DirectoryInfo TheFolder = new DirectoryInfo(xmlPath);
                DirectoryInfo[] drectories = TheFolder.GetDirectories();
                foreach (FileInfo fileInfo in TheFolder.GetFiles("*.xml"))//遍历文件夹下所有文件
                {
                    if (!fileInfo.Name.ToLower().EndsWith(Const.g_XMLFileExtensionName))
                        continue;

                    var result = ToolUtils.CheckTableFullName(fileInfo.FullName, true);
                    if (result != E_TableNameErrorType.Success)
                        continue;

                    // 加载已有的表结构文件
                    this.LoadDesignFile(fileInfo.FullName, genPath);

                    // 创建表结构文件
                    if (!this.CreateTableDesign(fileInfo.FullName, genPath))
                        Log.Print("MakeType fail for file {0}", fileInfo.FullName);

                    // 递归合并分支的表格
                    if(CommonData._is_recursive_flatbuffer && null != drectories && drectories.Length > 0)
                    {
                        // 如果结构文件没有缓存, 那么重新加载刚生成的结构文件
                        if (this.tableColumnInfoList.Count <= 0)
                            this.LoadDesignFile(fileInfo.FullName, genPath);

                        for (int i = 0; i < drectories.Length; i++)
                        {
                            branchFile = PathUtils.Combine(PathUtils.GetFullPath(drectories[i].FullName), fileInfo.Name);
                            if(FileUtils.Exists(branchFile))
                            {
                                // 创建表结构文件
                                if (!this.CreateTableDesign(branchFile, genPath))
                                    Log.Print("MakeType fail for file {0}", fileInfo.FullName);
                            }
                        }
                    }
                }

                System.Threading.Thread.Sleep(200);

                // 合并表格(主要合并AB_开头的表格);
                this.MergeTableDesign_AB(genPath);

                // 合并表格(主要合并后缀为"_b"的表格);
                //this.MergeTableDesign_B(genPath);
            }

            return true;
        }

        #endregion

        #region 私有接口

        /// <summary>
        /// 处理表结构,识别列名以及数据类型
        /// </summary>
        /// <param name="xmlPath">XML文件路径</param>
        private bool CreateTableDesign(string xmlFile, string savePath)
        {
            this.tableColumnDic.Clear();

            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(xmlFile);
                XmlNodeList xmlNodeList = xmldoc.DocumentElement.ChildNodes;
                if (null == xmlNodeList || xmlNodeList.Count <= 0)
                {
                    Log.Warning("The table {0} have nothing.", xmlFile);
                    return true;
                }

                // 部分XML格式没统一,外面又加了一层<Group>的节点,故这里判断一下
                if (null != xmldoc.DocumentElement.FirstChild
                    && xmldoc.DocumentElement.FirstChild.ChildNodes.Count > 0
                    && xmldoc.DocumentElement.FirstChild.Name != Const.g_XmlParseElementName)
                    xmlNodeList = xmldoc.DocumentElement.FirstChild.ChildNodes;

                if (null == xmlNodeList || xmlNodeList.Count <= 0)
                {
                    Log.Warning("The table {0} have nothing.", xmlFile);
                    return false;
                }

                string columnName;
                string columnValue;

                Dictionary<string, string> ReplaceNameDic = ToolUtils.GetReplaceNameDic();

                // 获得列名;
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
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

                    XmlAttributeCollection xmlAttributeCollection = xmlNodeList[i].Attributes;
                    for (int j = 0; j < xmlAttributeCollection.Count; j++)
                    {
                        columnName = xmlAttributeCollection[j].Name;
                        if (string.IsNullOrEmpty(columnName))
                            continue;

                        if (!tableColumnDic.ContainsKey(columnName))
                            tableColumnDic.Add(columnName, new TableColumnInfo(columnName, E_ColumnType.Single_Int));

                        if (columnName.Contains("-"))
                            tableColumnDic[columnName].SetAliasName(columnName.Replace("-", "_"));
                        else if(ReplaceNameDic.ContainsKey(columnName))
                            tableColumnDic[columnName].SetAliasName(ReplaceNameDic[columnName]);

                        // [i, j]对应的数据
                        columnValue = xmlAttributeCollection[j].Value.Trim();
                        if (string.IsNullOrEmpty(columnValue))
                            continue;

                        bool is_datatype_change = false;

                        // 如果为para列,那么固定为string类型
                        if(columnName.ToLower().StartsWith(Const.g_ColumnNamePara)
                            /*|| columnName.ToLower().StartsWith(Const.g_ColumnName_Name)
                            || columnName.ToLower().StartsWith(Const.g_ColumnName_Description)*/)
                        {
                            tableColumnDic[columnName].SetDataType(E_ColumnType.Fix_String);

                            is_datatype_change = true;
                        }
                        else if (regexInt.IsMatch(columnValue))  // 匹配整数
                        {// 默认为整数,无需处理

                        }
                        else if (regexFloat.IsMatch(columnValue)) // 匹配浮点数;
                        {// 浮点数类型
                            if (E_ColumnType.Single_Float > tableColumnDic[columnName].dataType)
                            {
                                tableColumnDic[columnName].SetDataType(E_ColumnType.Single_Float);

                                is_datatype_change = true;
                            }
                        }
                        else  // 其他类型
                        {
                            //int lineCount = Regex.Matches(columnValue, Const.g_VerticalLineSeparator).Count;
                            //int semicolonCount = Regex.Matches(columnValue, Const.g_SemicolonSeparator).Count;

                            int lineCount = columnValue.IndexOf(Const.g_VerticalLineSeparator);
                            int semicolonCount = columnValue.IndexOf(Const.g_SemicolonSeparator);

                            if (lineCount >= 0 && semicolonCount >= 0)
                            {// 数组嵌套结构体数据
                                if(tableColumnDic[columnName].dataType != E_ColumnType.Fix_String)
                                {
                                    string mainSeparator = string.Empty;
                                    string childSeparator = string.Empty;

                                    E_ColumnType curColumnType = E_ColumnType.Unknow;

                                    var columnInfo = this.tableColumnInfoList.Find(o => o.name == columnName);
                                    if (null != columnInfo)
                                        curColumnType = columnInfo.dataType;

                                    int errorNo = 0;
                                    // 获得列的数据类型
                                    columnType = this.GetTableColumnType(columnValue, curColumnType, out mainSeparator, out childSeparator, out errorNo);

                                    switch(errorNo)
                                    {
                                        case 1:
                                            {
                                                string id = xmlAttributeCollection["id"].Value.Trim();
                                                //ErrorLog.Error("config error => data type {0} have repeat keys, file : {1}, row id : {2}, column : {3}, current value : {4}, if you get data by {0}, maybe you get error data, you should get right data by Array_String. if you get data by Array_String, you can ignore this error message.",
                                                //    columnInfo.dataType.ToString(), xmlFile, id, columnName, columnValue);

                                                Log.Error("config error => data type {0} have repeat keys, file : {1}, row id : {2}, column : {3}, current value : {4}, if you get data by {0}, maybe you get error data, you should get right data by Array_String. if you get data by Array_String, you can ignore this error message.",
                                                    columnInfo.dataType.ToString(), xmlFile, id, columnName, columnValue);

                                                break;
                                            }
                                        default:
                                            break;
                                    }

                                    // 检查table类型的合法性
                                    if (tableColumnDic[columnName].CheckTableValid(mainSeparator, childSeparator))
                                    {
                                        // 避免被改回去,所以加一个大小比对
                                        if (columnType > tableColumnDic[columnName].dataType)
                                        {
                                            if (columnType == E_ColumnType.Dictionary_SI
                                                && tableColumnDic[columnName].dataType == E_ColumnType.Dictionary_IS)
                                                columnType = E_ColumnType.Dictionary_SS;

                                            tableColumnDic[columnName].SetDataType(columnType);
                                            tableColumnDic[columnName].SetComment(this.GetItemColumnCount(columnValue));
                                            tableColumnDic[columnName].SetSeparator(columnValue);

                                            is_datatype_change = true;
                                        }

                                        tableColumnDic[columnName].UpdateArrayLength(columnValue);
                                    }
                                }
                            }
                            else if (lineCount >= 0 || semicolonCount >= 0)
                            {// 为数组, 需进一步判断数组元数据的类型
                                if (tableColumnDic[columnName].dataType < E_ColumnType.Array_Table)
                                {
                                    tableColumnDic[columnName].SetSeparator(columnValue);
                                    string separator = tableColumnDic[columnName].array_separator;
                                    E_ColumnType dataType = this.GetArrayType(columnValue, separator);
                                    if (dataType > tableColumnDic[columnName].dataType)
                                    {
                                        tableColumnDic[columnName].SetDataType(dataType);

                                        is_datatype_change = true;
                                    }

                                    tableColumnDic[columnName].UpdateArrayLength(columnValue);
                                }
                            }
                            else
                            {// 字符串类型
                                if (E_ColumnType.Single_String > tableColumnDic[columnName].dataType)
                                {
                                    tableColumnDic[columnName].SetDataType(E_ColumnType.Single_String);

                                    is_datatype_change = true;
                                }
                            }
                        }

                        // 如果类型有变化,那么检查下数据的正确性
                        if(is_datatype_change)
                            this.CheckColumnValueValid(columnName, xmlFile, xmlAttributeCollection["id"].Value.Trim(), columnValue);

                        // 检查表中是否含有ID, 并且必须为小写
                        if(!tableColumnDic.ContainsKey(Const.g_Id))
                        {
                            ErrorLog.Error("配表缺少'id'字段, 并且'id'必须都为小写字母, file:{0}", xmlFile);

                            Log.Error("配表缺少'id'字段, 并且'id'必须都为小写字母, , file:{0}", xmlFile);
                        }
                    }
                }

                this.CheckAndUpdateColumnInfo();
            }
            catch(Exception e)
            {
                Log.Error("parse xml {0} error,  error message : {1}", xmlFile, e.Message);
                ErrorLog.Error("parse xml {0} error,  error message : {1}", xmlFile, e.Message);

                return false;
            }

            return this.SaveFile(xmlFile, savePath);
        }

        /// <summary>
        /// 合并表格
        /// </summary>
        /// <returns></returns>
        private bool MergeTableDesign_AB(string genPath)
        {
            string designPath = ToolUtils.GetPath(E_PathType.Design, genPath);
            // 遍历文件;
            DirectoryInfo TheFolder = new DirectoryInfo(designPath);
            foreach (FileInfo fileInfo in TheFolder.GetFiles("*.txt"))//遍历文件夹下所有文件
            {
                if (!fileInfo.Name.StartsWith(Const.g_ABFileName))
                    continue;

                List<TableColumnInfo> abColumnInfoList = this.GetDesignInfo(fileInfo.FullName);

                string noABFileName = fileInfo.FullName.Replace(Const.g_ABFileName, "");
                List<TableColumnInfo> noABColumnInfoList = this.GetDesignInfo(noABFileName);

                if(null != abColumnInfoList && null != noABColumnInfoList  && null != noABFileName)
                {
                    for(int i = 0; i < abColumnInfoList.Count; i++)
                    {
                        var index = noABColumnInfoList.FindIndex(o => o.name == abColumnInfoList[i].name);
                        if(index < 0)
                        {
                            noABColumnInfoList.Add(abColumnInfoList[i]);
                        }
                        else
                        {
                            if (abColumnInfoList[i].dataType > noABColumnInfoList[index].dataType)
                                noABColumnInfoList[index].dataType = abColumnInfoList[i].dataType;
                        }
                    }

                    this.SaveMergeFile(noABFileName, genPath, noABColumnInfoList);
                    this.SaveMergeFile(fileInfo.FullName, genPath, noABColumnInfoList);
                }
            }

            return true;
        }

        /// <summary>
        /// 合并表格
        /// </summary>
        /// <returns></returns>
        private bool MergeTableDesign_B(string genPath)
        {
            string designPath = ToolUtils.GetPath(E_PathType.Design, genPath);
            // 遍历文件;
            DirectoryInfo TheFolder = new DirectoryInfo(designPath);
            foreach (FileInfo fileInfo in TheFolder.GetFiles("*.txt"))//遍历文件夹下所有文件
            {
                if (!fileInfo.Name.EndsWith(Const.g_BFileName + ".txt"))
                    continue;

                List<TableColumnInfo> abColumnInfoList = this.GetDesignInfo(fileInfo.FullName);

                string noABFileName = fileInfo.FullName.Replace(Const.g_BFileName + ".txt", ".txt");
                List<TableColumnInfo> noABColumnInfoList = this.GetDesignInfo(noABFileName);

                if (null != abColumnInfoList && null != noABColumnInfoList && null != noABFileName)
                {
                    for (int i = 0; i < abColumnInfoList.Count; i++)
                    {
                        var index = noABColumnInfoList.FindIndex(o => o.name == abColumnInfoList[i].name);
                        if (index < 0)
                        {
                            noABColumnInfoList.Add(abColumnInfoList[i]);
                        }
                        else
                        {
                            if (abColumnInfoList[i].dataType > noABColumnInfoList[index].dataType)
                                noABColumnInfoList[index].dataType = abColumnInfoList[i].dataType;
                        }
                    }

                    this.SaveMergeFile(noABFileName, genPath, noABColumnInfoList);
                    this.SaveMergeFile(fileInfo.FullName, genPath, noABColumnInfoList);
                }
            }

            return true;
        }

        /// <summary>
        /// 获得列类型
        /// </summary>
        /// <param name="columnValue">列的值</param>
        /// <param name="curColumnType">当前列的类型</param>
        /// <param name="mainSeparator">主分隔符</param>
        /// <param name="childSeparator">子分隔符</param>
        /// <param name="errNo">错误号:0-正常;1-Key重复</param>
        /// <returns></returns>
        private E_ColumnType GetTableColumnType(string columnValue, E_ColumnType curColumnType, out string mainSeparator, out string childSeparator, out int errNo)
        {
            errNo = 0;
            mainSeparator = string.Empty;
            childSeparator = string.Empty;

            int lineCount = columnValue.IndexOf(Const.g_VerticalLineSeparator);
            int semicolonCount = columnValue.IndexOf(Const.g_SemicolonSeparator);

            if (lineCount <= 0 || semicolonCount <= 0)
                return E_ColumnType.Unknow;

            mainSeparator = Const.g_VerticalLineSeparator;
            childSeparator = Const.g_SemicolonSeparator;

            if (lineCount < semicolonCount)
            {
                mainSeparator = Const.g_SemicolonSeparator;
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
                    {
                        if(this.IsDictionary(curColumnType))
                            errNo = 1;
                        
                        return E_ColumnType.Array_Table;
                    }
                        

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
        /// 判断是否为Key-Value类型
        /// </summary>
        /// <returns></returns>
        private bool IsArrayTable(E_ColumnType dataType_)
        {
            return dataType_ == E_ColumnType.Array_Table;
        }

        /// <summary>
        /// 判断是否为Key-Value类型
        /// </summary>
        /// <returns></returns>
        private bool IsDictionary(E_ColumnType dataType_)
        {
            return dataType_ == E_ColumnType.Dictionary_II
                || dataType_ == E_ColumnType.Dictionary_IS
                || dataType_ == E_ColumnType.Dictionary_SI
                || dataType_ == E_ColumnType.Dictionary_SS;
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
                                if(this.tableColumnInfoList[i].dataType == E_ColumnType.Single_String && this.tableColumnInfoList[i].dataType == E_ColumnType.Fix_String)
                                {
                                    // 属于正常情况
                                }
                                else
                                {
                                    Log.Error("The data type of column {0} is error, old type : {1}, new type : {2}, need to use {2}.", columnName,
                                    this.tableColumnInfoList[i].dataType.ToString(), this.tableColumnDic[columnName].dataType.ToString());
                                }
                            }
                            else
                            {
                                Log.Warning("The data type of column {0} is different, old type : {1}, new type : {2}, currently using {1}.", columnName,
                                this.tableColumnInfoList[i].dataType.ToString(), this.tableColumnDic[columnName].dataType.ToString());
                            }
                        }
                    }

                    this.tableColumnDic[columnName] = this.tableColumnInfoList[i];
                }
            }
        }

        /// <summary>
        /// 保存文件结构
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <param name="savePath"></param>
        /// <returns></returns>
        private bool SaveFile(string xmlPath, string savePath)
        {
            if(this.tableColumnInfoList.Count <= 0 && this.tableColumnDic.Count <= 0)
            {
                Log.Warning("The table {0} have nothing.", xmlPath);
                return true;
            }

            List<TableColumnInfo> columnList = new List<TableColumnInfo>();
            columnList.AddRange(this.tableColumnInfoList);

            foreach (var item in tableColumnDic)
            {
                var find = columnList.Find(o => o.name == item.Value.name);
                if (null == find)
                    columnList.Add(item.Value);
            }

            // 如果表格没有配置ID, 那么返回
            int index = columnList.FindIndex(o => o.name == Const.g_Id);
            if (index < 0)
            {
                return false;
            }
            else
            {
                // 将ID放在第一列
                if(index != 0)
                {
                    var tmpColumnInfo = columnList[index];
                    columnList.RemoveAt(index);
                    columnList.Insert(0, tmpColumnInfo);
                }
            }

            string fileName = PathUtils.GetFileNameWithoutExtension(xmlPath) + Const.g_TextFileExtensionName;
            string saveFile = PathUtils.Combine(ToolUtils.GetPath(E_PathType.Design, savePath), fileName);

            Log.Print("create table design => {0}", saveFile);

            try
            {
                using (FileStream fileStream = new FileStream(saveFile, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        foreach (var item in columnList)
                            writer.WriteLine(item.GetString());

                        writer.Flush();
                        writer.Close();
                        writer.Dispose();
                    }

                    fileStream.Close();
                    fileStream.Dispose();
                }
            }
            catch(Exception e)
            {
                Log.Error("保存文件失败! error:{0}, file:{1}, in function SaveFile.", e.Message, saveFile);
                ErrorLog.Error("保存文件失败! error:{0}, file:{1}, in function SaveFile.", e.Message, saveFile);
            }

            return true;
        }

        /// <summary>
        /// 保存合并的文件结构
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <param name="savePath"></param>
        /// <returns></returns>
        private bool SaveMergeFile(string xmlPath, string savePath, List<TableColumnInfo> tableColumnInfos)
        {
            string fileName = PathUtils.GetFileNameWithoutExtension(xmlPath) + Const.g_TextFileExtensionName;
            string saveFile = PathUtils.Combine(ToolUtils.GetPath(E_PathType.Design, savePath), fileName);

            Log.Print("merge table design => {0}", saveFile);

            try
            {
                using (FileStream fileStream = new FileStream(saveFile, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        foreach (var item in tableColumnInfos)
                            writer.WriteLine(item.GetString());

                        writer.Flush();
                        writer.Close();
                        writer.Dispose();
                    }

                    fileStream.Close();
                    fileStream.Dispose();
                }
            }
            catch(Exception e)
            {
                Log.Error("创建文件失败! error:{0}, file:{1}, in function SaveMergeFile.", e.Message, saveFile);
                ErrorLog.Error("创建文件失败! error:{0}, file:{1}, in function SaveMergeFile.", e.Message, saveFile);
            }

            return true;
        }

        /// <summary>
        /// 获得数组类型
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        private E_ColumnType GetArrayType(string data, string separator)
        {
            E_ColumnType dataType = E_ColumnType.Single_Int;
            string[] array = data.Split(separator);
            if (null == array || array.Length <= 0)
                return dataType;

            for (int m = 0; m < array.Length; m++)
            {
                if (regexInt.IsMatch(array[m])) // 整数类型
                {

                }
                else if (regexFloat.IsMatch(array[m]))    // 浮点类型;
                {
                    if(E_ColumnType.Single_Float > dataType)
                        dataType = E_ColumnType.Single_Float;
                }
                else  // 字符串类型
                {
                    if (E_ColumnType.Single_String > dataType)
                        dataType = E_ColumnType.Single_String;
                }
            }

            E_ColumnType targetType = E_ColumnType.Array_String;
            switch (dataType)
            {
                case E_ColumnType.Single_Int:
                    {
                        targetType = E_ColumnType.Array_Int;
                        break;
                    }
                case E_ColumnType.Single_Float:
                    {
                        targetType = E_ColumnType.Array_Float;
                        break;
                    }
                case E_ColumnType.Single_String:
                    {
                        targetType = E_ColumnType.Array_String;
                        break;
                    }
                default:
                    break;
            }

            return targetType;
        }

        /// <summary>
        /// 获得原子数据的列数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private int GetItemColumnCount(string data)
        {
            int lineIndex = data.IndexOf(Const.g_CharVerticalLineSeparator);
            int semicolonIndex = data.IndexOf(Const.g_CharSemicolonSeparator);

            if (lineIndex > semicolonIndex)
            {
                string[] arrayLine = data.Split(Const.g_CharVerticalLineSeparator);
                if (arrayLine.Length > 0)
                {
                    string[] arrayItem = arrayLine[0].Split(Const.g_CharSemicolonSeparator);
                    return arrayItem.Length;
                }
            }
            else
            {
                string[] arrayLine = data.Split(Const.g_CharSemicolonSeparator);
                if (arrayLine.Length > 0)
                {
                    string[] arrayItem = arrayLine[0].Split(Const.g_CharVerticalLineSeparator);
                    return arrayItem.Length;
                }
            }

            return -1;
        }

        /// <summary>
        /// 加载表格结构文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool LoadDesignFile(string xmlPath, string genPath)
        {
            string fileName = PathUtils.GetFileNameWithoutExtension(xmlPath) + Const.g_TextFileExtensionName;
            string designFile = PathUtils.Combine(ToolUtils.GetPath(E_PathType.Design, genPath), fileName);

            // 清理数据;
            this.tableColumnInfoList.Clear();

            if (FileUtils.Exists(designFile))
            {// 文件存在,那么加载原有的设计文件
                try
                {
                    using (FileStream fileStream = new FileStream(designFile, FileMode.Open))
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
                                        this.tableColumnInfoList.Add(columnInfo);
                                    else
                                    {
                                        Log.Print("数据类型格式配置错误,请检查文件: {0}", designFile);
                                        ErrorLog.Print("数据类型格式配置错误,请检查文件: {0}", designFile);
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
                    Log.Error("打开文件失败! error:{0}, file:{1}, in function LoadDesignFile.", e.Message, designFile);
                    ErrorLog.Error("打开文件失败! error:{0}, file:{1}, in function LoadDesignFile.", e.Message, designFile);
                }
            }

            // 解析XML中配置的数据类型,并且覆盖掉原有的数据类型
            return this.ParseDataType(xmlPath, genPath);
        }

        /// <summary>
        /// 解析数据类型
        /// </summary>
        /// <param name="xmlFile">XML文件</param>
        /// <param name="savePath">保存路径</param>
        /// <returns></returns>
        private bool ParseDataType(string xmlFile, string savePath)
        {
            this.tableColumnDic.Clear();

            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(xmlFile);
                
                XmlNodeList xmlNodeList = xmldoc.DocumentElement.ChildNodes;
                if (null == xmlNodeList || xmlNodeList.Count <= 0)
                {
                    Log.Warning("The table {0} have nothing.", xmlFile);
                    return false;
                }

                // 部分XML格式没统一,外面又加了一层<Group>的节点,故这里判断一下
                if (null != xmldoc.DocumentElement.FirstChild
                    && xmldoc.DocumentElement.FirstChild.ChildNodes.Count > 0
                    && xmldoc.DocumentElement.FirstChild.Name != Const.g_XmlParseElementName)
                    xmlNodeList = xmldoc.DocumentElement.FirstChild.ChildNodes;

                if (null == xmlNodeList || xmlNodeList.Count <= 0)
                {
                    Log.Warning("The table {0} have nothing.", xmlFile);
                    return false;
                }

                string columnName;
                string columnValue;

                Dictionary<string, string> ReplaceNameDic = ToolUtils.GetReplaceNameDic();

                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    // 空行跳过
                    if (null == xmlNodeList[i] || null == xmlNodeList[i].Attributes)
                        continue;

                    // 没有ID属性,那么跳过
                    if (!ToolUtils.IsContainAttributeId(xmlNodeList[i].Attributes))
                    {
                        // 提示没有配置ID
                        ErrorLog.Error("存在没有配置id的行,每一行必须要配置id! file:{0}", xmlFile);
                        Log.Error("存在没有配置id的行,每一行必须要配置id! file:{0}", xmlFile);

                        continue;
                    }

                    // 获得ID的值
                    string strIdValue = xmlNodeList[i].Attributes["id"].Value;
                    // 获取ID的数据类型
                    E_ColumnType columnType = ToolUtils.GetDataType(strIdValue);
                    // 获取ID数据类型成功后,那么获取其他列的数据类型
                    if (columnType != E_ColumnType.Unknow)
                    {
                        XmlAttributeCollection xmlAttributeCollection = xmlNodeList[i].Attributes;
                        for (int j = 0; j < xmlAttributeCollection.Count; j++)
                        {
                            // 列名
                            columnName = xmlAttributeCollection[j].Name;
                            if (string.IsNullOrEmpty(columnName))
                                continue;

                            // [i, j]对应的数据
                            columnValue = xmlAttributeCollection[j].Value.Trim();
                            if (string.IsNullOrEmpty(columnValue))
                            {
                                // 提示没有配置数据类型
                                ErrorLog.Error("数据类型没有配置! column:{0}, file:{1}", columnName, xmlFile);
                                Log.Error("数据类型没有配置! column:{0}, file:{1}", columnName, xmlFile);
                            }

                            // 获得数据类型
                            columnType = ToolUtils.GetDataType(columnValue);
                            // 如果没有配置数据类型或者配置错误,那么默认为字符串类型
                            if (columnType == E_ColumnType.Unknow)
                            {
                                if(!string.IsNullOrEmpty(columnValue))
                                {
                                    // 提示数据类型配置错误
                                    ErrorLog.Error("配置的数据类型不合法! column:{0}, type:{1}, file:{2}", columnName, columnValue, xmlFile);
                                    Log.Error("配置的数据类型不合法! column:{0}, type:{1}, file:{2}", columnName, columnValue, xmlFile);
                                }

                                continue;
                            }

                            // 添加列
                            if (!tableColumnDic.ContainsKey(columnName))
                                tableColumnDic.Add(columnName, new TableColumnInfo(columnName, columnType));

                            if (columnName.Contains("-"))// 中划线改为下划线
                                tableColumnDic[columnName].SetAliasName(columnName.Replace("-", "_"));
                            else if (ReplaceNameDic.ContainsKey(columnName))    // 代码关键字改名
                                tableColumnDic[columnName].SetAliasName(ReplaceNameDic[columnName]);

                            // 如果是Dictionary类型,那么需要指定分隔符
                            if(this.IsDictionary(columnType))
                            {
                                string tmpColumnValue;
                                for (int m = i + 1; m < xmlNodeList.Count; m++)
                                {
                                    // 空行跳过
                                    if (null == xmlNodeList[m] || null == xmlNodeList[m].Attributes || null == xmlNodeList[m].Attributes[columnName])
                                        continue;

                                    tmpColumnValue = xmlNodeList[m].Attributes[columnName].Value;
                                    var result = tableColumnDic[columnName].SetDictionarySeparator(tmpColumnValue);
                                    switch(result)
                                    {
                                        case E_ErrorType.DataTypeMismatch:
                                            {
                                                ErrorLog.Error("数据类型不匹配! column:{0}, value:{1}, type:{2}, file:{3}", columnName, tmpColumnValue, columnValue, xmlFile);
                                                Log.Error("数据类型不匹配! column:{0}, value:{1}, type:{2}, file:{3}", columnName, tmpColumnValue, columnValue, xmlFile);

                                                break;
                                            }
                                        default:
                                            break;
                                    }
                                }
                            }
                            else if(this.IsArrayTable(columnType))
                            {
                                if(columnValue.Contains(Const.g_VerticalLineSeparator))
                                    tableColumnDic[columnName].SetArraySeparator(Const.g_VerticalLineSeparator);
                                else if(columnValue.Contains(Const.g_SemicolonSeparator))
                                    tableColumnDic[columnName].SetArraySeparator(Const.g_SemicolonSeparator);
                            }
                            else
                            {
                                // 其他数据类型检查
                                switch(columnType)
                                {
                                    case E_ColumnType.Single_Int:
                                        {
                                            string tmpColumnValue;
                                            for (int m = i + 1; m < xmlNodeList.Count; m++)
                                            {
                                                // 空行跳过
                                                if (null == xmlNodeList[m] 
                                                    || null == xmlNodeList[m].Attributes 
                                                    || null == xmlNodeList[m].Attributes[columnName])
                                                    continue;

                                                tmpColumnValue = xmlNodeList[m].Attributes[columnName].Value.Trim();
                                                if (string.IsNullOrEmpty(tmpColumnValue))
                                                    continue;

                                                if(!regexInt.IsMatch(tmpColumnValue))
                                                {
                                                    ErrorLog.Error("数据类型不匹配! column:{0}, value:{1}, type:{2}, file:{3}", columnName, tmpColumnValue, columnValue, xmlFile);
                                                    Log.Error("数据类型不匹配! column:{0}, value:{1}, type:{2}, file:{3}", columnName, tmpColumnValue, columnValue, xmlFile);
                                                }
                                            }
                                            
                                            break;
                                        }
                                    case E_ColumnType.Array_Int:
                                        {
                                            string tmpColumnValue;
                                            for (int m = i + 1; m < xmlNodeList.Count; m++)
                                            {
                                                // 空行跳过
                                                if (null == xmlNodeList[m] 
                                                    || null == xmlNodeList[m].Attributes
                                                    || null == xmlNodeList[m].Attributes[columnName])
                                                    continue;

                                                tmpColumnValue = xmlNodeList[m].Attributes[columnName].Value.Trim();
                                                if (string.IsNullOrEmpty(tmpColumnValue))
                                                    continue;

                                                string[] array = tmpColumnValue.Split(Const.g_split_chars);
                                                for(int n = 0; n < array.Length; n++)
                                                {
                                                    if (!regexInt.IsMatch(array[n]))
                                                    {
                                                        ErrorLog.Error("数据类型不匹配! column:{0}, value:{1}, type:{2}, file:{3}", columnName, tmpColumnValue, columnValue, xmlFile);
                                                        Log.Error("数据类型不匹配! column:{0}, value:{1}, type:{2}, file:{3}", columnName, tmpColumnValue, columnValue, xmlFile);
                                                    }
                                                }
                                            }

                                            break;
                                        }
                                    case E_ColumnType.Single_Float:
                                        {
                                            string tmpColumnValue;
                                            for (int m = i + 1; m < xmlNodeList.Count; m++)
                                            {
                                                // 空行跳过
                                                if (null == xmlNodeList[m] 
                                                    || null == xmlNodeList[m].Attributes
                                                    || null == xmlNodeList[m].Attributes[columnName])
                                                    continue;

                                                tmpColumnValue = xmlNodeList[m].Attributes[columnName].Value.Trim();
                                                if (string.IsNullOrEmpty(tmpColumnValue))
                                                    continue;

                                                if (!regexFloat.IsMatch(tmpColumnValue))
                                                {
                                                    ErrorLog.Error("数据类型不匹配! column:{0}, value:{1}, type:{2}, file:{3}", columnName, tmpColumnValue, columnValue, xmlFile);
                                                    Log.Error("数据类型不匹配! column:{0}, value:{1}, type:{2}, file:{3}", columnName, tmpColumnValue, columnValue, xmlFile);
                                                }
                                            }

                                            break;
                                        }
                                    case E_ColumnType.Array_Float:
                                        {
                                            string tmpColumnValue;
                                            for (int m = i + 1; m < xmlNodeList.Count; m++)
                                            {
                                                // 空行跳过
                                                if (null == xmlNodeList[m] 
                                                    || null == xmlNodeList[m].Attributes
                                                    || null == xmlNodeList[m].Attributes[columnName])
                                                    continue;

                                                tmpColumnValue = xmlNodeList[m].Attributes[columnName].Value.Trim();
                                                if (string.IsNullOrEmpty(tmpColumnValue))
                                                    continue;

                                                string[] array = tmpColumnValue.Split(Const.g_split_chars);
                                                for (int n = 0; n < array.Length; n++)
                                                {
                                                    if (!regexInt.IsMatch(array[n]) && !regexFloat.IsMatch(array[n]))
                                                    {
                                                        ErrorLog.Error("数据类型不匹配! column:{0}, value:{1}, type:{2}, file:{3}", columnName, tmpColumnValue, columnValue, xmlFile);
                                                        Log.Error("数据类型不匹配! column:{0}, value:{1}, type:{2}, file:{3}", columnName, tmpColumnValue, columnValue, xmlFile);
                                                    }
                                                }
                                            }

                                            break;
                                        }
                                    default:
                                        break;
                                }
                            }
                        }

                        // 检查表中是否含有ID, 并且必须为小写
                        if (tableColumnDic.Count > 0 && !tableColumnDic.ContainsKey(Const.g_Id))
                        {
                            ErrorLog.Error("表格必须配置名为'id'的列,且'id'要小写, file:{0}", xmlFile);
                            Log.Error("表格必须配置名为'id'的列,且'id'要小写, file:{0}", xmlFile);
                        }

                        break;
                    }
                }

                // 将存档的数据类型修改为XML中配置的数据类型
                if(tableColumnDic.Count > 0 && this.tableColumnInfoList.Count > 0)
                {
                    for (int i = 0; i < this.tableColumnInfoList.Count; i++)
                    {
                        columnName = this.tableColumnInfoList[i].name;
                        if (!string.IsNullOrEmpty(columnName)
                            && this.tableColumnDic.ContainsKey(columnName))
                        {
                            if (this.tableColumnDic[columnName].dataType != this.tableColumnInfoList[i].dataType
                                || this.tableColumnDic[columnName].array_separator != this.tableColumnInfoList[i].array_separator)
                            {
                                this.tableColumnInfoList[i] = this.tableColumnDic[columnName];
                                //this.tableColumnDic.Remove(columnName);
                            }
                        }
                    }
                }
                else if(tableColumnDic.Count > 0 && this.tableColumnInfoList.Count <= 0)
                {
                    this.tableColumnInfoList.AddRange(tableColumnDic.Values);

                    // 如果表格没有配置ID, 那么返回
                    int index = this.tableColumnInfoList.FindIndex(o => o.name == Const.g_Id);
                    if (index > 0)
                    {// 将ID放在第一列
                        var tmpColumnInfo = this.tableColumnInfoList[index];
                        this.tableColumnInfoList.RemoveAt(index);
                        this.tableColumnInfoList.Insert(0, tmpColumnInfo);
                    }

                    // 数据重复,清空缓存数据
                    tableColumnDic.Clear();
                }
            }
            catch (Exception e)
            {
                Log.Error("解析文件失败! file:{0}, error:{1}", xmlFile, e.Message);
                ErrorLog.Error("解析文件失败! file:{0}, error:{1}", xmlFile, e.Message);

                return false;
            }

            if(tableColumnDic.Count <= 0)
            {
                //Log.Print("没有配置数据类型, file:{0}", xmlFile);
                return true;
            }
            else
            {
                Log.Print("保存策划配置的数据类型, file:{0}", xmlFile);
                return this.SaveFile(xmlFile, savePath);
            }
        }

        /// <summary>
        /// 加载表格结构文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private List<TableColumnInfo> GetDesignInfo(string designFile)
        {
            if (!FileUtils.Exists(designFile))
            {
                Log.Error("file ({0}) is not find.", designFile);
                return null;
            }

            List<TableColumnInfo> columnInfoList = new List<TableColumnInfo>();

            try
            {
                using (FileStream fileStream = new FileStream(designFile, FileMode.Open))
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
                                {
                                    columnInfoList.Add(columnInfo);
                                }
                                else
                                {
                                    Log.Print("数据类型格式配置错误,请检查文件: {0}", designFile);
                                    ErrorLog.Print("数据类型格式配置错误,请检查文件: {0}", designFile);
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
                Log.Error("打开文件失败! error:{0}, file:{1}, in function GetDesignInfo.", e.Message, designFile);
                ErrorLog.Error("打开文件失败! error:{0}, file:{1}, in function GetDesignInfo.", e.Message, designFile);
            }

            return columnInfoList;
        }

        private void CheckColumnValueValid(string columnName, string fileName, string id, string columnValue)
        {
            if (!this.tableColumnDic.ContainsKey(columnName))
                return;

            if (this.tableColumnInfoList.Count <= 0)
                return;

            var columnInfo = this.tableColumnInfoList.Find(o => o.name == columnName);
            if (null == columnInfo)
                return;

            // 如果配置类型比匹配类型相同或者要大,那么返回不提示
            if (columnInfo.dataType >= this.tableColumnDic[columnName].dataType)
                return;

            // 如果为字符串或者字符串数组类型,那么返回不提示
            if (columnInfo.dataType == E_ColumnType.Single_String
                || columnInfo.dataType == E_ColumnType.Array_String
                || columnInfo.dataType == E_ColumnType.Array_Table)
                return;

            // 如果是整型数组,那么检查数据是否为整型
            if(columnInfo.dataType == E_ColumnType.Array_Int && !string.IsNullOrEmpty(columnValue))
            {
                int tmp = 0;
                bool valid = true;
                var array = columnValue.Split(Const.g_split_chars);
                for(int i = 0; i < array.Length; i++)
                {
                    if (!int.TryParse(array[i], out tmp))
                    {
                        valid = false;
                        break;
                    }
                }

                if (valid) return;
            }

            // 如果是整型数组,那么检查数据是否为整型
            if (columnInfo.dataType == E_ColumnType.Array_Float && !string.IsNullOrEmpty(columnValue))
            {
                float tmp = 0;
                bool valid = true;
                var array = columnValue.Split(Const.g_split_chars);
                for (int i = 0; i < array.Length; i++)
                {
                    if (!float.TryParse(array[i], out tmp))
                    {
                        valid = false;
                        break;
                    }
                }

                if (valid) return;
            }

            if (this.IsDictionary(columnInfo.dataType) && this.tableColumnDic[columnName].dataType == E_ColumnType.Fix_String)
            {
                //ErrorLog.Error("config error => maybe have repeat keys for Dictionary data type, please check data, if you still use Dictionary, you can ignore this error message, but you should use Array_String to get right data.");

                Log.Error("config error => 请检查Dictionary类型数据可能存在重复的Key值, 如果依然使用Dictionary类型, 那么应该使用Array_String类型的变量来获取数据，否则可能获取到错误的数据!");
            }
            else
            {
                ErrorLog.Error("config error => 数据配置错误! 数据类型必须为 {0}, 文件:{1}, 行:{2}, 列:{3}, 当前值: {4}",
                columnInfo.dataType.ToString(), PathUtils.GetFileName(fileName), id, columnName, columnValue);

                Log.Error("config error => 数据配置错误! 数据类型必须为 {0}, 文件:{1}, 行:{2}, 列:{3}, 当前值: {4}",
                    columnInfo.dataType.ToString(), PathUtils.GetFileName(fileName), id, columnName, columnValue);
            }
        }

        #endregion
    }
}
