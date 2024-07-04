using System;
using System.IO;
using System.Text;

namespace MakeTable
{
    public class PathUtils
    {
        #region Combine

        public static string Combine(string path1, string path2)
        {
            string path = "";

            try
            {
                path = Path.Combine(path1, path2);
            }
            catch(Exception e)
            {
                Log.Error(e, $"Path.Combine Exception! path1:{path1}, path2:{path2}");
                ErrorLog.Error(e, $"Path.Combine Exception! path1:{path1}, path2:{path2}");

                throw;
            }

            return path;
        }

        public static string Combine(string path1, string path2, string path3)
        {
            string path = "";

            try
            {
                path = Path.Combine(path1, path2, path3);
            }
            catch (Exception e)
            {
                Log.Error(e, $"Path.Combine Exception! path1:{path1}, path2:{path2}, path3:{path3}");
                ErrorLog.Error(e, $"Path.Combine Exception! path1:{path1}, path2:{path2}, path3:{path3}");

                throw;
            }

            return path;
        }
 
        public static string Combine(string path1, string path2, string path3, string path4)
        {
            string path = "";

            try
            {
                path = Path.Combine(path1, path2, path3, path4);
            }
            catch (Exception e)
            {
                Log.Error(e, $"Path.Combine Exception! path1:{path1}, path2:{path2}, path3:{path3}, path4:{path4}");
                ErrorLog.Error(e, $"Path.Combine Exception! path1:{path1}, path2:{path2}, path3:{path3}, path4:{path4}");

                throw;
            }

            return path;
        }

        public static string Combine(params string[] paths)
        {
            string path = "";

            try
            {
                path = Path.Combine(paths);
            }
            catch (Exception e)
            {
                StringBuilder stringBuilder = new StringBuilder();

                for(int i = 0; i < paths.Length; i++)
                {
                    stringBuilder.Append(paths[i]);

                    if(i < paths.Length - 1)
                        stringBuilder.Append(",");
                }
                    
                Log.Error(e, $"Path.Combine Exception! path:{stringBuilder.ToString()}");
                ErrorLog.Error(e, $"Path.Combine Exception! path:{stringBuilder.ToString()}");

                throw;
            }

            return path;
        }

        #endregion

        public static string GetFileName(string path)
        {
            string filename = "";

            if (string.IsNullOrEmpty(path))
                return filename;

            try
            {
                filename = Path.GetFileName(path);
            }
            catch(Exception e)
            {
                Log.Error(e, $"Path.GetFileName Exception! path:{path}");
                ErrorLog.Error(e, $"Path.GetFileName Exception! path:{path}");

                throw;
            }

            return filename;
        }

        public static string GetFullPath(string path)
        {
            string result = "";

            try
            {
                result = Path.GetFullPath(path);
            }
            catch(Exception e)
            {
                Log.Error(e, $"Path.GetFullPath Exception! path:{path}");
                ErrorLog.Error(e, $"Path.GetFullPath Exception! path:{path}");

                throw;
            }

            return result;
        }

        public static string GetFileNameWithoutExtension(string path)
        {
            string filename = "";

            if (string.IsNullOrEmpty(path))
                return filename;

            try
            {
                filename = Path.GetFileNameWithoutExtension(path);
            }
            catch(Exception e)
            {
                Log.Error(e, $"Path.GetFileNameWithoutExtension Exception! path:{path}");
                ErrorLog.Error(e, $"Path.GetFileNameWithoutExtension Exception! path:{path}");

                throw;
            }

            return filename;
        }
    }
}
