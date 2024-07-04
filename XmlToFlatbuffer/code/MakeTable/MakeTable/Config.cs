using System;
using System.Collections.Generic;
using System.IO;

namespace MakeTable
{
    class Config : Singleton<Config>
    {
        private bool isInitSuccess = false;
        private string configFile = string.Empty;

        private Dictionary<string, string> configs = new Dictionary<string, string>();

        public void Init()
        {
            configFile = this.GetConfigFile();
            if (string.IsNullOrEmpty(configFile) || !FileUtils.Exists(configFile))
                return;

            char[] split = new char[] { '=' };

            try
            {
                using (FileStream fileStream = new FileStream(configFile, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string line;
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();

                            //以#开头的行为注释行,跳过
                            if (line.StartsWith("#"))
                                continue;

                            string[] array = line.Split(split);
                            if (null != array && array.Length >= 2)
                                configs.Add(array[0].Trim(), array[1].Trim());
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
                Log.Error("打开文件异常! error:{0},file:{1},in function Config::Init", e.Message, configFile);
                ErrorLog.Error("打开文件异常! error:{0},file:{1},in function Config::Init", e.Message, configFile);
            }

            isInitSuccess = true;
        }

        public bool IsOpen(string key)
        {
            if (!isInitSuccess)
                return false;

            if (!configs.ContainsKey(key))
                return false;

            return configs[key] == "1" || configs[key].ToLowerInvariant() == "true";
        }

        public string GetString(string key)
        {
            if (!isInitSuccess)
                return null;

            if (!configs.ContainsKey(key))
                return null;

            return configs[key];
        }

        public string[] GetStringArray(string key, char split = ';')
        {
            if (!isInitSuccess)
                return null;

            if (!configs.ContainsKey(key))
                return null;

            return configs[key].Split(new char[] { split });
        }

        public List<string> GetStringList(string key, char split = ';')
        {
            if (!isInitSuccess)
                return new List<string>();

            if (!configs.ContainsKey(key))
                return new List<string>();

            string[] array = configs[key].Split(new char[] { split });
            if (null == array || array.Length <= 0)
                return new List<string>();

            List<string> result = new List<string>();
            result.AddRange(array);

            return result;
        }

        private string GetConfigFile()
        {
            return PathUtils.Combine(ToolUtils.GetToolPath(), "tool", "config", "config.txt");
        }
    }
}
