using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);

            string path = root;

            for(int i = 0; i < sub_path.Length; i++)
            {
                path = Path.Combine(path, sub_path[i]);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
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

        public static string GetTableName(string sheetName)
        {
            if (string.IsNullOrEmpty(sheetName))
                return null;

            if (sheetName.StartsWith("#"))
                return sheetName.Substring(1);

            if (sheetName.Contains("_"))
                return sheetName.Substring(sheetName.IndexOf("_") + 1);

            return null;
        }

        /// <summary>
        /// 获得当前系统时间
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentTime()
        {
            // 获取当前系统时间
            DateTime currentTime = DateTime.Now;

            // 将日期时间格式化为年月日时分秒格式 (yyyy-MM-dd HH:mm:ss)
            return currentTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
