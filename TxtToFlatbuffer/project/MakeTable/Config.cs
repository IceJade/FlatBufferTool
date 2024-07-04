using System;
using System.Collections.Generic;
using System.IO;

namespace MakeTable
{
    public class Config : Singleton<Config>
    {
        private bool isInitSuccess = false;
        private string configFile = string.Empty;

        private Dictionary<string, string> configs = new Dictionary<string, string>();

        public void Init()
        {
            // 已经初始化,那么返回
            if (isInitSuccess)
                return;

            configFile = this.GetConfigFile();
            if (string.IsNullOrEmpty(configFile) || !File.Exists(configFile))
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
                Log.Error("Read config throw exception,error:{0},file:{1}", e.Message, configFile);
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

        private string GetConfigFile()
        {
            return Path.Combine(ToolUtils.GetToolPath(), "tool", "config", "config.txt");
        }
    }
}
