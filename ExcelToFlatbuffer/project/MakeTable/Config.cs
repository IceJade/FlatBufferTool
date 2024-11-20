using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MakeTable
{
    public class Config : Singleton<Config>
    {
        private bool isInitSuccess = false;
        private string configFile = string.Empty;

        private Dictionary<string, string> configs = new Dictionary<string, string>();

        public void Init(string[] args)
        {
            configFile = this.GetConfigFile(args);
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
                Log.Error("打开文件异常! error:{0},file:{1},in function Config::Init", e.Message, configFile);
                ErrorLog.Error("打开文件异常! error:{0},file:{1},in function Config::Init", e.Message, configFile);
            }

            isInitSuccess = true;
        }

        public bool IsOpen(string key, bool defaultValue = false)
        {
            if (!isInitSuccess)
                return defaultValue;

            if (!configs.ContainsKey(key))
                return defaultValue;

            return configs[key] == "1" || configs[key].ToLowerInvariant() == "true";
        }

        public string GetString(string key, string defaultValue = "")
        {
            if (!isInitSuccess)
                return defaultValue;

            if (!configs.ContainsKey(key))
                return defaultValue;

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

        private string GetConfigFile(string[] args)
        {
            if (null == args || args.Length < 2 || string.IsNullOrEmpty(args[1]))
            {
                Log.Error("启动进程的参数错误, 没有检测到flatc的路径！");
                ErrorLog.Error("启动进程的参数错误, 没有检测到flatc的路径！");
                return null;
            }

            int length = args.Length;
            string genPath = args[length - 1];
            if(string.IsNullOrEmpty(genPath) || !Directory.Exists(genPath))
            {
                Log.Error("启动进程的参数错误, 生成路径不正确！");
                ErrorLog.Error("启动进程的参数错误, 生成路径不正确！");
                return null;
            }

            return Path.Combine(genPath, "config", "config.txt");
        }
    }
}
