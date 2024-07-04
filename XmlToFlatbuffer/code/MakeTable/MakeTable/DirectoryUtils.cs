using System;
using System.IO;

namespace MakeTable
{
    public class DirectoryUtils
    {
        public static bool Exists(string path)
        {
            bool exist = false;

            try
            {
                exist = Directory.Exists(path);
            }
            catch(Exception e)
            {
                Log.Error(e, $"Directory.Exists Exception! path:{path}");
                ErrorLog.Error(e, $"Directory.Exists Exception! path:{path}");

                throw;
            }

            return exist;
        }

        public static DirectoryInfo CreateDirectory(string path)
        {
            DirectoryInfo directoryInfo = null;

            try
            {
                directoryInfo = Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                Log.Error(e, $"Directory.CreateDirectory Exception! path:{path}");
                ErrorLog.Error(e, $"Directory.CreateDirectory Exception! path:{path}");

                throw;
            }

            return directoryInfo;
        }
    }
}
