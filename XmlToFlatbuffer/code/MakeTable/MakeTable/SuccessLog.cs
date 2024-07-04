using System;
using System.IO;
using System.Text;

namespace MakeTable
{
    public class SuccessLog
    {
        private static string _log_file = "";
        private static StreamWriter sw = null;

        public static void SetLogFile(string genRootPath)
        {
            string logPath = ToolUtils.GetPath(E_PathType.Result, genRootPath);
            if (!DirectoryUtils.Exists(logPath))
                throw new Exception($"路径不存在:{logPath}");

            _log_file = PathUtils.Combine(logPath, "success.log");

            if (FileUtils.Exists(_log_file))
                FileUtils.Delete(_log_file);
        }

        public static void Print(string output)
        {
            if (string.IsNullOrEmpty(_log_file))
                return;

            try
            {
                sw = new StreamWriter(_log_file, false, Encoding.UTF8);
                if (null == sw)
                {
                    Console.WriteLine("[ERROR]new StreamWriter fail, file:" + _log_file);
                    throw new Exception($"创建文件失败:{_log_file}");
                }

                sw.Write(output);
                sw.Flush();
                sw.Close();
            }
            catch (Exception e)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("[Exception]:");
                stringBuilder.Append(output);
                stringBuilder.AppendLine();
                stringBuilder.Append("[Message]:");
                stringBuilder.Append(e.Message);
                stringBuilder.AppendLine();
                stringBuilder.Append("[Source]:");
                stringBuilder.Append(e.Source);
                stringBuilder.AppendLine();
                stringBuilder.Append("[StackTrace]:");
                stringBuilder.Append(e.StackTrace);

                Console.WriteLine(stringBuilder.ToString());

                throw;
            }
            finally
            {
                sw = null;
            }
        }
    }
}
