using System;
using System.Diagnostics;
using System.IO;

namespace MakeTable
{
    public class GenerateJson
    {
        /// <summary>
        /// 生成json文件
        /// </summary>
        /// <param name="flatc"></param>
        /// <param name="tablePath"></param>
        /// <returns></returns>
        public bool MakeJson(string flatc, string tablePath, string genPath)
        {
            Log.Print("---------------------------------------------------------------------------------------");
            Log.Print("开始生成Json数据文件...");

            if (FileUtils.Exists(tablePath))
            {
                string fileName = PathUtils.GetFileNameWithoutExtension(tablePath);
                string fbsFileName = Const.g_DataTableAliasName + fileName + Const.g_FBSFileExtensionName;
                string fbsFile = PathUtils.Combine(ToolUtils.GetPath(E_PathType.FBS, genPath), fbsFileName);

                this.CreateJson(flatc, fbsFile, genPath);
            }
            else
            {
                // 遍历文件夹
                string fbsPath = ToolUtils.GetPath(E_PathType.FBS, genPath);
                DirectoryInfo TheFolder = new DirectoryInfo(fbsPath);
                foreach (FileInfo fileInfo in TheFolder.GetFiles("*.fbs"))//遍历文件夹下所有文件
                {
                    if (ToolUtils.IsIgnoreTable(fileInfo.Name))
                        continue;

                    // 生成json文件
                    this.CreateJson(flatc, fileInfo.FullName, genPath);

                    // 递归分支的表格
                    if (CommonData._is_recursive_flatbuffer)
                        this.CreateBranchJson(flatc, fileInfo.FullName, genPath);
                }
            }

            return true;
        }

        /// <summary>
        /// 创建json文件
        /// </summary>
        /// <param name="flatcFile"></param>
        /// <param name="xmlFile"></param>
        /// <returns></returns>
        private bool CreateJson(string flatcFile, string fbsFile, string genPath)
        {
            string fileName = PathUtils.GetFileNameWithoutExtension(fbsFile).Replace(Const.g_DataTableAliasName, "");

            string binPath = ToolUtils.GetPath(E_PathType.Binary, genPath);

            try
            {
                if (!DirectoryUtils.Exists(binPath))
                    DirectoryUtils.CreateDirectory(binPath);
            }
            catch (Exception e)
            {
                Log.Error("创建Bin目录失败! error:{0}, path:{1}, in function CreateJson.", e.Message, binPath);
                ErrorLog.Error("创建Bin目录失败! error:{0}, path:{1}, in function CreateJson.", e.Message, binPath);
            }

            string binFile = PathUtils.Combine(binPath, fileName + Const.g_BytesFileExtensionName);

            string jsonPath = ToolUtils.GetPath(E_PathType.Json, genPath);

            try
            {
                if (!DirectoryUtils.Exists(jsonPath))
                    DirectoryUtils.CreateDirectory(jsonPath);
            }
            catch (Exception e)
            {
                Log.Error("创建Json目录失败! error:{0}, path:{1}, in function CreateJson.", e.Message, jsonPath);
                ErrorLog.Error("创建Json目录失败! error:{0}, path:{1}, in function CreateJson.", e.Message, jsonPath);
            }

            string jsonFile = PathUtils.Combine(jsonPath, fileName + Const.g_JsonFileExtensionName);

            Log.Print("create json => {0}", jsonFile);

            // 如果文件存在, 那么先删除
            if (FileUtils.Exists(jsonFile))
                FileUtils.Delete(jsonFile);

            try
            {
                using (Process p = new Process())
                {
                    string args = string.Format("--raw-binary -t -o {0} {1} -- {2}", jsonPath, fbsFile, binFile);
                    p.StartInfo.FileName = flatcFile;
                    p.StartInfo.Arguments = args;
                    p.StartInfo.UseShellExecute = false;                //是否使用操作系统shell启动
                    p.StartInfo.RedirectStandardInput = true;       //接受来自调用程序的输入信息
                    p.StartInfo.RedirectStandardOutput = true;    //由调用程序获取输出信息
                    p.StartInfo.RedirectStandardError = true;       //重定向标准错误输出
                    p.StartInfo.CreateNoWindow = true;              //不显示程序窗口
                    p.Start();//启动程序

                    //向cmd窗口写入命令
                    //p.StandardInput.WriteLine(cmd);
                    //p.StandardInput.AutoFlush = true;

                    //获取cmd窗口的输出信息
                    //string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit(2000);//等待程序执行完退出进程
                    p.Close();
                }
            }
            catch(Exception e)
            {
                Log.Error("Process execute Exception! error:{0}, fbs:{1}, bin:{2}, in function CreateJson.", e.Message, fbsFile, binFile);
                ErrorLog.Error("Process execute Exception! error:{0}, fbs:{1}, bin:{2}, in function CreateJson.", e.Message, fbsFile, binFile);
            }

            return true;
        }

        /// <summary>
        /// 创建子分支的json文件
        /// </summary>
        /// <param name="flatcFile"></param>
        /// <param name="fbsFile"></param>
        /// <param name="genPath"></param>
        /// <returns></returns>
        private bool CreateBranchJson(string flatcFile, string fbsFile, string genPath)
        {
            string fileName = PathUtils.GetFileNameWithoutExtension(fbsFile).Replace(Const.g_DataTableAliasName, "");

            string binPath = ToolUtils.GetPath(E_PathType.Binary, genPath);
            string jsonPath = ToolUtils.GetPath(E_PathType.Json, genPath);

            // 分支下的二进制flatbuffer文件
            string branchBinFile = "";
            // 分支路径
            string branchPath = "";
            // 分支保存路径
            string branchSavePath = "";
            // 路径分段
            string[] separatorPath = null;

            DirectoryInfo TheFolder = new DirectoryInfo(binPath);
            DirectoryInfo[] directoryInfos = TheFolder.GetDirectories();
            for (int i = 0; i < directoryInfos.Length; i++)
            {
                if (string.IsNullOrEmpty(directoryInfos[i].FullName))
                    continue;
                
                branchPath = PathUtils.GetFullPath(directoryInfos[i].FullName);
                branchBinFile = PathUtils.Combine(branchPath, fileName + Const.g_BytesFileExtensionName);

                if (FileUtils.Exists(branchBinFile))
                {
                    separatorPath = branchPath.Split(Const.path_separator);

                    // 分支文件保存路径
                    if (null != separatorPath && separatorPath.Length > 0)
                        branchSavePath = PathUtils.Combine(jsonPath, separatorPath[separatorPath.Length - 1]);

                    this.CreateBranchJson(flatcFile, fbsFile, branchSavePath, branchBinFile);
                }
            }

            return true;
        }

        /// <summary>
        /// 创建子分支的json文件
        /// </summary>
        /// <param name="flatcFile"></param>
        /// <param name="fbsFile"></param>
        /// <param name="genPath"></param>
        /// <returns></returns>
        private bool CreateBranchJson(string flatcFile, string fbsFile, string genPath, string binFile)
        {
            if (!FileUtils.Exists(binFile))
                return false;

            try
            {
                if (!DirectoryUtils.Exists(genPath))
                    DirectoryUtils.CreateDirectory(genPath);
            }
            catch (Exception e)
            {
                Log.Error("创建目录失败! error:{0}, path:{1}, in function CreateBranchJson.", e.Message, genPath);
                ErrorLog.Error("创建目录失败! error:{0}, path:{1}, in function CreateBranchJson.", e.Message, genPath);
            }

            string fileName = PathUtils.GetFileNameWithoutExtension(binFile);
            string jsonFile = PathUtils.Combine(genPath, fileName + Const.g_JsonFileExtensionName);

            if (FileUtils.Exists(jsonFile))
                FileUtils.Delete(jsonFile);

            Log.Print("create json => {0}", jsonFile);

            try
            {
                using (Process p = new Process())
                {
                    string args = string.Format("--raw-binary -t -o {0} {1} -- {2}", genPath, fbsFile, binFile);
                    p.StartInfo.FileName = flatcFile;
                    p.StartInfo.Arguments = args;
                    p.StartInfo.UseShellExecute = false;                //是否使用操作系统shell启动
                    p.StartInfo.RedirectStandardInput = true;       //接受来自调用程序的输入信息
                    p.StartInfo.RedirectStandardOutput = true;    //由调用程序获取输出信息
                    p.StartInfo.RedirectStandardError = true;       //重定向标准错误输出
                    p.StartInfo.CreateNoWindow = true;              //不显示程序窗口
                    p.Start();//启动程序

                    //向cmd窗口写入命令
                    //p.StandardInput.WriteLine(cmd);
                    //p.StandardInput.AutoFlush = true;

                    //获取cmd窗口的输出信息
                    //string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit(2000);//等待程序执行完退出进程
                    p.Close();
                }
            }
            catch(Exception e)
            {
                Log.Error("Process execute Exception! error:{0}, fbs:{1}, bin:{2}, in function CreateBranchJson.", e.Message, fbsFile, binFile);
                ErrorLog.Error("Process execute Exception! error:{0}, fbs:{1}, bin:{2}, in function CreateBranchJson.", e.Message, fbsFile, binFile);
            }

            return true;
        }
    }
}
