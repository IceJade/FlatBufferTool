using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace MakeTable
{
    public class ToolUtils
    {
        public static string GetPath(E_PathType pathType, string root)
        {
            string path = string.Empty;

            switch(pathType)
            {
                case E_PathType.FBS:
                    {
                        path = GetOrCreatePath(root, "fbs");
                        break;
                    }
                case E_PathType.CSharp:
                    {
                        path = GetOrCreatePath(root, "code", "csharp");
                        break;
                    }
                case E_PathType.Lua:
                    {
                        path = GetOrCreatePath(root, "code", "lua");
                        break;
                    }
                case E_PathType.Design:
                    {
                        path = GetOrCreatePath(root, "design");
                        break;
                    }
                case E_PathType.Binary:
                    {
                        path = GetOrCreatePath(root, "data", "binary");
                        break;
                    }
                case E_PathType.Json:
                    {
                        path = GetOrCreatePath(root, "data", "json");
                        break;
                    }
                case E_PathType.Model:
                    {
                        path = GetOrCreatePath(root, "model");
                        break;
                    }
                case E_PathType.Log:
                    {
                        path = GetOrCreatePath(root, "log");
                        break;
                    }
                case E_PathType.Ids:
                    {
                        path = GetOrCreatePath(root, "data", "ids");
                        break;
                    }
                case E_PathType.Result:
                    {
                        path = GetOrCreatePath(root, "result");
                        break;
                    }
                default:
                    break;
            }

            return path;
        }

        /// <summary>
        /// 获得并创建路径
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sub_path"></param>
        /// <returns></returns>
        public static string GetOrCreatePath(string root, params string[] sub_path)
        {
            try
            {
                if (!DirectoryUtils.Exists(root))
                    DirectoryUtils.CreateDirectory(root);
            }
            catch (Exception e)
            {
                Log.Error(e, $"创建根目录失败! path:{root}, in function GetOrCreatePath.");
                ErrorLog.Error(e, $"创建根目录失败! path:{root}, in function GetOrCreatePath.");

                throw;
            }

            string path = root;

            try
            {
                for (int i = 0; i < sub_path.Length; i++)
                {
                    path = PathUtils.Combine(path, sub_path[i]);

                    if (!DirectoryUtils.Exists(path))
                        DirectoryUtils.CreateDirectory(path);
                }
            }
            catch(Exception e)
            {
                Log.Error(e, $"创建目录失败! path:{path}, in function GetOrCreatePath.");
                ErrorLog.Error(e, $"创建目录失败! path:{path}, in function GetOrCreatePath.");

                throw;
            }

            return path;
        }

        private static Dictionary<string, string> ReplaceNameDic = null;
        public static Dictionary<string, string> GetReplaceNameDic()
        {
            if (null == ReplaceNameDic)
            {
                ReplaceNameDic = new Dictionary<string, string>();
                ReplaceNameDic.Add("char", "char_alies");
                ReplaceNameDic.Add("lock", "lock_alies");
                ReplaceNameDic.Add("base", "base_alies");
                ReplaceNameDic.Add("object", "object_alies");
            }

            return ReplaceNameDic;
        }

        public static string UpFirstChar(string name)
        {
            if (string.IsNullOrEmpty(name))
                return string.Empty;

            if (name.Length <= 1)
                return name.ToUpper();
            else
                return name.Substring(0,1).ToUpper() + name.Substring(1);
        }

        public static string GetRealName(string name)
        {
            string realName = name;
            var replaceNameDic = GetReplaceNameDic();
            if (replaceNameDic.ContainsKey(name))
                realName = replaceNameDic[name];

            return MakeCamel(realName);
        }

        // Convert an underscore_based_indentifier in to camelCase.
        // Also uppercases the first character if first is true.
        public static string MakeCamel(string s, bool first = true)
        {
            string result = string.Empty;

            for (int i = 0; i < s.Length; i++) 
            {
                if (i == 0 && first)
                    result += char.ToUpper(s[0]);
                else if (s[i] == '_' && i + 1 < s.Length)
                    result += char.ToUpper(s[++i]);
                else if (s[i] == '-' && i + 1 < s.Length)
                    result += char.ToUpper(s[++i]);
                else
                {
                    result += s[i];
                }
            }

            return result;
        }

        private static string dataTablePath = string.Empty;
        private static string dataTableName = ".Tool";

        public static string GetDataTablePath()
        {
            if (string.IsNullOrEmpty(dataTablePath))
            {
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                if (string.IsNullOrEmpty(currentDirectory))
                {
                    Log.Error("get AppDomain.CurrentDomain.BaseDirectory fail, please check MakeTable tool...");
                    ErrorLog.Error("get AppDomain.CurrentDomain.BaseDirectory fail, please check MakeTable tool...");
                    return string.Empty;
                }

                int index = currentDirectory.IndexOf(dataTableName);
                if (index < 0)
                {
                    Log.Error("获取工具目录失败! {0}", currentDirectory);
                    ErrorLog.Error("获取工具目录失败! {0}", currentDirectory);
                    return string.Empty;
                }

                dataTablePath = PathUtils.Combine(currentDirectory.Substring(0, index));
            }

            return dataTablePath;
        }

        private static string toolPath = string.Empty;
        private static string appName = "MakeTable";
        private static string appNameLowcase = "maketable";

        public static string GetToolPath()
        {
            if(string.IsNullOrEmpty(toolPath))
            {
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                if (string.IsNullOrEmpty(currentDirectory))
                {
                    Log.Error("get AppDomain.CurrentDomain.BaseDirectory fail, please check MakeTable tool...");
                    ErrorLog.Error("get AppDomain.CurrentDomain.BaseDirectory fail, please check MakeTable tool...");
                    return string.Empty;
                }

                bool useLowcaseAppName = false;
                int index = currentDirectory.IndexOf(appName);
                if (index < 0)
                {
                    index = currentDirectory.IndexOf(appNameLowcase);
                    if (index < 0)
                    {
                        Log.Error("get tool path fail, {0}", currentDirectory);
                        ErrorLog.Error("get tool path fail, {0}", currentDirectory);

                        return string.Empty;
                    }
                    else
                    {
                        useLowcaseAppName = true;
                    }
                }

                var folderName = useLowcaseAppName ? appNameLowcase : appName;
                toolPath = PathUtils.Combine(currentDirectory.Substring(0, index), folderName);
            }

            return toolPath;
        }

        private static string assetsPath = string.Empty;
        private static string assetsName = "Assets";
        public static string GetAssetsPath()
        {
            if (string.IsNullOrEmpty(assetsPath))
            {
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                int index = currentDirectory.LastIndexOf(assetsName);
                if (index < 0)
                    return assetsPath;

                assetsPath = PathUtils.Combine(currentDirectory.Substring(0, index), "Assets");
            }

            return assetsPath;
        }

        /// <summary>
        /// 获得数据类型
        /// </summary>
        /// <returns>数据类型</returns>
        public static E_ColumnType GetDataType(string columnValue)
        {
            E_ColumnType result = E_ColumnType.Unknow;

            if (string.IsNullOrEmpty(columnValue))
                return result;

            columnValue = columnValue.Trim().ToLower();

            foreach (E_ColumnType columnType in Enum.GetValues(typeof(E_ColumnType)))
            {
                if (columnValue == columnType.ToString().ToLower())
                    return columnType;
            }

            switch(columnValue)
            {
                case "bool":
                    {
                        result = E_ColumnType.Single_Bool;
                        break;
                    }
                case "bool[]":
                    {
                        result = E_ColumnType.Array_bool;
                        break;
                    }
                case "short":
                    {
                        result = E_ColumnType.Single_Short;
                        break;
                    }
                case "short[]":
                    {
                        result = E_ColumnType.Array_Short;
                        break;
                    }
                case "int":
                    {
                        result = E_ColumnType.Single_Int;
                        break;
                    }
                case "int[]":
                    {
                        result = E_ColumnType.Array_Int;
                        break;
                    }
                case "float":
                    {
                        result = E_ColumnType.Single_Float;
                        break;
                    }
                case "float[]":
                    {
                        result = E_ColumnType.Array_Float;
                        break;
                    }
                case "string":
                    {
                        result = E_ColumnType.Single_String;
                        break;
                    }
                case "string[]":
                    {
                        result = E_ColumnType.Array_String;
                        break;
                    }
                case "string[|]":
                    {
                        result = E_ColumnType.Array_Table;
                        break;
                    }
                case "string[;]":
                    {
                        result = E_ColumnType.Array_Table;
                        break;
                    }
                case "dictionaryii":
                case "dictionary_ii":
                case "d[int,int]":
                case "d[int, int]":
                case "dictionary<int,int>":
                case "dictionary<int, int>":
                    {
                        result = E_ColumnType.Dictionary_II;
                        break;
                    }
                case "dictionaryis":
                case "dictionary_is":
                case "d[int,string]":
                case "d[int, string]":
                case "dictionary<int,string>":
                case "dictionary<int, string>":
                    {
                        result = E_ColumnType.Dictionary_IS;
                        break;
                    }
                case "dictionarysi":
                case "dictionary_si":
                case "d[string,int]":
                case "d[string, int]":
                case "dictionary<string,int>":
                case "dictionary<string, int>":
                    {
                        result = E_ColumnType.Dictionary_SI;
                        break;
                    }
                case "dictionaryss":
                case "dictionary_ss":
                case "d[string,string]":
                case "d[string, string]":
                case "dictionary<string,string>":
                case "dictionary<string, string>":
                    {
                        result = E_ColumnType.Dictionary_SS;
                        break;
                    }
                default:
                    break;
            }

            return result;
        }

        public static List<string> resourceTables = null;

        /// <summary>
        /// 是否忽略此表的处理
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public static bool IsIgnoreTable(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                return false;

            if (!CommonData._is_gen_spriteatlas_only)
                return false;

            if (null == resourceTables)
                resourceTables = Config.Instance.GetStringList("InvalidTables", ';');

            // 获得表名
            string fileName = PathUtils.GetFileNameWithoutExtension(tableName);

            if (null != resourceTables && resourceTables.Count > 0)
                return !resourceTables.Contains(fileName);

            return true;
        }

        /// <summary>
        /// 如果是Unity工程平台
        /// </summary>
        public static bool IsUnityPlatform()
        {
            string assetsPath = GetAssetsPath();
            if (!string.IsNullOrEmpty(assetsPath) && DirectoryUtils.Exists(assetsPath))
                return true;

            return false;
        }

        /// <summary>
        /// 检查ID属性
        /// </summary>
        public static bool IsContainAttributeId(XmlAttributeCollection attributes)
        {
            if (null == attributes || attributes.Count <= 0)
                return false;

            for (int i = 0; i < attributes.Count; i++)
            {
                if (attributes[i].Name == Const.g_Id)
                    return true;
            }

            return false;
        }

        public static string regex = @"^\w+$";

        public static E_TableNameErrorType CheckTableFullName(string tableFullName, bool printErrorLog = false)
        {
            if (string.IsNullOrEmpty(tableFullName))
                return E_TableNameErrorType.EmptyOrNull;

            var tableName = PathUtils.GetFileNameWithoutExtension(tableFullName);
            return CheckTableName(tableName, printErrorLog);
        }

        /// <summary>
        /// 是否为合法的配表名称
        /// </summary>
        /// <param name="tableName">配表名称</param>
        /// <returns></returns>
        public static E_TableNameErrorType CheckTableName(string tableName, bool printErrorLog = false)
        {
            if (string.IsNullOrEmpty(tableName))
                return E_TableNameErrorType.EmptyOrNull;

            bool isMatch = Regex.IsMatch(tableName, regex);
            if (!isMatch)
            {
                if(printErrorLog)
                {
                    Log.Error("配表{0}名称错误, 配表名称只能由小写字母、数字和下划线组成!", tableName);
                    ErrorLog.Error("配表{0}名称错误, 配表名称只能由小写字母、数字和下划线组成!", tableName);
                }

                return E_TableNameErrorType.Has_Unvalid_Character;
            }

            /*
            // 精确匹配可忽略的配表
            var ignoreCheckTableNames = Config.Instance.GetStringArray("IgnoreCheckTableNames");
            if(null != ignoreCheckTableNames && ignoreCheckTableNames.Length > 0)
            {
                for(int i = 0; i < ignoreCheckTableNames.Length; i++)
                {
                    if (ignoreCheckTableNames[i] == tableName)
                        return E_TableNameErrorType.Success;
                }
            }

            // 模糊匹配可忽略的配表
            var ignoreMatchTableNames = Config.Instance.GetStringArray("IgnoreMatchTableNames");
            if (null != ignoreMatchTableNames && ignoreMatchTableNames.Length > 0)
            {
                for (int i = 0; i < ignoreMatchTableNames.Length; i++)
                {
                    if (tableName.Contains(ignoreMatchTableNames[i]))
                        return E_TableNameErrorType.Success;
                }
            }

            var array = tableName.ToCharArray();
            if(array.Length >= 2)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] >= 'A' && array[i] <= 'Z')
                    {
                        if (printErrorLog)
                        {
                            Log.Error("配表{0}名称错误,配表名称包含大写字母,需修改为小写,且单词之间可以由下划线相隔!", tableName);
                            ErrorLog.Error("配表{0}名称错误,配表名称包含大写字母,需修改为小写,且单词之间可以由下划线相隔!", tableName);
                        }  

                        return E_TableNameErrorType.Has_Upper_Letters;
                    }
                }
            }
            */

            return E_TableNameErrorType.Success;
        }
    }
}
