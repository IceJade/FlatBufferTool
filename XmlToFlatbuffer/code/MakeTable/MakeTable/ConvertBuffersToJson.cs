using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MakeTable
{
    /// <summary>
    /// 将Flatbuffers数据转换成json数据
    /// </summary>
    class ConvertBuffersToJson
    {
        public void Run(string[] args)
        {
            if (args.Length < 5)
            {
                Console.WriteLine("args error, the count of args must be 5.");
                return;
            }

            string flatcFile = args[1];
            if(!FileUtils.Exists(flatcFile))
            {
                Console.WriteLine("The file flatc is not exist, file : {0}", flatcFile);
                return;
            }

            string fbsPath = args[2];
            if (!DirectoryUtils.Exists(fbsPath))
            {
                Console.WriteLine("fbs path is not exist, path : {0}", fbsPath);
                return;
            }

            string binPath = args[3];
            if (!DirectoryUtils.Exists(binPath))
            {
                Console.WriteLine("binary data path is not exist, path : {0}", binPath);
                return;
            }

            string genPath = args[4];

            this.Run(flatcFile, fbsPath, binPath, genPath);
        }

        public void Run(string flatcFile, string fbsPath, string binPath, string genPath)
        {
            // 遍历文件夹
            DirectoryInfo TheFolder = new DirectoryInfo(binPath);
            foreach (FileInfo fileInfo in TheFolder.GetFiles("*.bytes"))//遍历文件夹下所有文件
            {
                // fbs文件
                string fbsFile = PathUtils.Combine(fbsPath, Const.g_DataTableAliasName + fileInfo.Name.Replace(".bytes", ".fbs"));
                if (!FileUtils.Exists(fbsFile))
                    continue;

                // 生成json文件
                this.CreateJson(flatcFile, fbsFile, fileInfo.FullName, genPath);
            }
        }

        /// <summary>
        /// 创建json文件
        /// </summary>
        /// <param name="flatcFile"></param>
        /// <param name="xmlFile"></param>
        /// <returns></returns>
        private bool CreateJson(string flatcFile, string fbsFile, string binFile, string genPath)
        {
            string fileName = PathUtils.GetFileNameWithoutExtension(fbsFile).Replace(Const.g_DataTableAliasName, "");

            try
            {
                if (!DirectoryUtils.Exists(genPath))
                    DirectoryUtils.CreateDirectory(genPath);
            }
            catch (Exception e)
            {
                Log.Error("创建根目录失败! error:{0}, path:{1}, in function CreateJson.", e.Message, genPath);
                ErrorLog.Error("创建根目录失败! error:{0}, path:{1}, in function CreateJson.", e.Message, genPath);
            }

            string jsonFile = PathUtils.Combine(genPath, fileName + Const.g_JsonFileExtensionName);
            Console.WriteLine("create json => {0}", jsonFile);

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
                //p.WaitForExit(2000);//等待程序执行完退出进程
                p.WaitForExit();//等待程序执行完退出进程
                p.Close();
            }

            return true;
        }
    }
}
