using System;
using System.IO;

namespace MakeTable
{
    public class ErrorLog
    {
        private static StreamWriter sw = null;

        public static void SetLogFile(string genRootPath)
        {
            string logFile = Path.Combine(ToolUtils.GetPath(E_PathType.Result, genRootPath), "result.log");

            if (File.Exists(logFile))
                File.Delete(logFile);

            sw = new StreamWriter(logFile);
        }

        public static void Flush()
        {
            if (null != sw)
            {
                sw.Flush();
                sw.Close();
            }
        }

        #region 输出普通日志

        public static void Print(string output)
        {
            if (null == sw)
                return;

            sw.WriteLine(output);
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
    }
}
