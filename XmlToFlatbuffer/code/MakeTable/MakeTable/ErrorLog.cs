using System;
using System.IO;
using System.Text;

namespace MakeTable
{
    public class ErrorLog
    {
        private static StreamWriter sw = null;

        public static void SetLogFile(string genRootPath)
        {
            string logPath = ToolUtils.GetPath(E_PathType.Result, genRootPath);
            if (!DirectoryUtils.Exists(logPath))
                throw new Exception($"路径不存在:{logPath}");

            string logFile = PathUtils.Combine(logPath, "result.log");

            if (FileUtils.Exists(logFile))
                FileUtils.Delete(logFile);

            sw = new StreamWriter(logFile, false, Encoding.UTF8);
        }

        public static void Flush()
        {
            if (null != sw)
            {
                try
                {
                    sw.Flush();
                    sw.Close();
                }
                catch(Exception e)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("[Exception]:Error Log Flush!");
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

                    throw e;
                }
                finally
                {
                    sw = null;
                }
            }
        }

        #region 输出普通日志

        public static void Print(string output)
        {
            if (null == sw)
                return;

            try
            {
                sw.WriteLine(output);
            }
            catch(Exception e)
            {
                sw.Flush();
                sw.Close();
                sw = null;

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
        }

        public static void Print(string format, string arg)
        {
            Print(string.Format(format, arg));
        }

        public static void Print(string format, string arg0, string arg1)
        {
            Print(string.Format(format, arg0, arg1));
        }

        public static void Print(string format, string arg0, string arg1, string arg2)
        {
            Print(string.Format(format, arg0, arg1, arg2));
        }

        #endregion

        #region 输出警告日志

        private static string LogType_Warning = "[Warning]";

        public static void Warning(string output)
        {
            Print(LogType_Warning + output);
        }

        public static void Warning(string format, string arg)
        {
            Print(LogType_Warning + string.Format(format, arg));
        }

        public static void Warning(string format, string arg0, string arg1)
        {
            Print(LogType_Warning + string.Format(format, arg0, arg1));
        }

        public static void Warning(string format, string arg0, string arg1, string arg2)
        {
            Print(LogType_Warning + string.Format(format, arg0, arg1, arg2));
        }

        #endregion

        #region 输出错误日志

        private static string LogType_Error = "[Error]";

        public static void Error(string output)
        {
            Print(LogType_Error + output);
        }

        public static void Error(string format, object arg)
        {
            Print(LogType_Error + string.Format(format, arg));
        }

        public static void Error(string format, object arg0, object arg1)
        {
            Print(LogType_Error + string.Format(format, arg0, arg1));
        }

        public static void Error(string format, object arg0, object arg1, object arg2)
        {
            Print(LogType_Error + string.Format(format, arg0, arg1, arg2));
        }

        public static void Error(string format, object arg0, object arg1, object arg2, object arg3)
        {
            Print(LogType_Error + string.Format(format, arg0, arg1, arg2, arg3));
        }

        public static void Error(string format, object arg0, object arg1, object arg2, object arg3, object arg4)
        {
            Print(LogType_Error + string.Format(format, arg0, arg1, arg2, arg3, arg4));
        }

        #endregion

        #region 输出异常日志

        public static void Error(Exception e, string output)
        {
            Print(MakeLog(e, output));
        }

        public static void Error(Exception e, string format, object arg)
        {
            Print(MakeLog(e, string.Format(format, arg)));
        }

        public static void Error(Exception e, string format, object arg0, object arg1)
        {
            Print(MakeLog(e, string.Format(format, arg0, arg1)));
        }

        public static void Error(Exception e, string format, object arg0, object arg1, object arg2)
        {
            Print(MakeLog(e, string.Format(format, arg0, arg1, arg2)));
        }

        public static void Error(Exception e, string format, object arg0, object arg1, object arg2, object arg3)
        {
            Print(MakeLog(e, string.Format(format, arg0, arg1, arg2, arg3)));
        }

        public static void Error(Exception e, string format, object arg0, object arg1, object arg2, object arg3, object arg4)
        {
            Print(MakeLog(e, string.Format(format, arg0, arg1, arg2, arg3, arg4)));
        }

        private static string MakeLog(Exception e, string output)
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

            return stringBuilder.ToString();
        }

        #endregion
    }
}
