using System;
using System.IO;

namespace MakeTable
{
    public class FileUtils
    {
        public static bool Exists(string path)
        {
            bool exist = false;

            try
            {
                exist = File.Exists(path);
            }
            catch(Exception e)
            {
                Log.Error(e, $"File.Exists Exception! path:{path}");
                ErrorLog.Error(e, $"File.Exists Exception! path:{path}");

                throw;
            }

            return exist;
        }

        public static void Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception e)
            {
                Log.Error(e, $"File.Delete Exception! path:{path}");
                ErrorLog.Error(e, $"File.Delete Exception! path:{path}");

                throw;
            }
        }

        public static byte[] ReadAllBytes(string path)
        {
            byte[] buffers = null;

            try
            {
                buffers = File.ReadAllBytes(path);
            }
            catch (Exception e)
            {
                Log.Error(e, $"File.ReadAllBytes Exception! path:{path}");
                ErrorLog.Error(e, $"File.ReadAllBytes Exception! path:{path}");

                throw;
            }

            return buffers;
        }

        public static void Copy(string sourceFileName, string destFileName)
        {
            try
            {
                File.Copy(sourceFileName, destFileName);
            }
            catch (Exception e)
            {
                Log.Error(e, $"File.Copy Exception! sourceFileName:{sourceFileName}, destFileName:{destFileName}");
                ErrorLog.Error(e, $"File.Copy Exception! sourceFileName:{sourceFileName}, destFileName:{destFileName}");

                throw;
            }
        }

        public static void Copy(string sourceFileName, string destFileName, bool overwrite)
        {
            try
            {
                File.Copy(sourceFileName, destFileName, overwrite);
            }
            catch (Exception e)
            {
                Log.Error(e, $"File.Copy Exception! sourceFileName:{sourceFileName}, destFileName:{destFileName}, overwrite:{overwrite}");
                ErrorLog.Error(e, $"File.Copy Exception! sourceFileName:{sourceFileName}, destFileName:{destFileName}, overwrite:{overwrite}");

                throw;
            }
        }
    }
}
