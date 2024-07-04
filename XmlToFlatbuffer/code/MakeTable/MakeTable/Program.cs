using System;
using System.IO;
using System.Text;

namespace MakeTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args);

            try
            {
                // 程序正在执行中,那么退出
                if (IsAppRunning(args))
                    return;

                InitLog(args);

                Init();

                E_CommandType commandType = GetCommandType(args);
                if (commandType == E_CommandType.None)
                    return;

                switch (commandType)
                {
                    case E_CommandType.CMD_ParseTable:              // 解析数据表生成表结构文件
                        {
                            if (args.Length < 3)
                            {
                                Log.Print("传递参数错误...");
                                return;
                            }

                            // 表文件路径;
                            string tablePath = args[1];
                            string genRootPath = args[2];

                            GenerateType generateType = new GenerateType();
                            generateType.MakeType(tablePath, genRootPath);

                            Log.Print("表结构文件生成完毕...");

                            break;
                        }
                    case E_CommandType.CMD_FlatBuffer:              // 生成FlatBuffer文件(不包含源目录下的子目录)
                        {
                            Run(args);

                            break;
                        }
                    case E_CommandType.CMD_Recursive_FlatBuffer:    // 递归生成FlatBuffer文件(包括源目录下的子目录)
                        {
                            Run(args, true);

                            break;
                        }
                    case E_CommandType.CMD_BuffersToJson:           // 将flatbuffer数据转换成json数据
                        {
                            ConvertBuffersToJson convertBuffersToJson = new ConvertBuffersToJson();
                            convertBuffersToJson.Run(args);

                            break;
                        }
                    case E_CommandType.CMD_GenerateDataOnly:        // 只生成Flatbuffer数据,不生成代码
                        {
                            Run(args, false, true);

                            break;
                        }
                    case E_CommandType.CMD_OutsideVersion:          // 外网包处理(只生成bytes文件)
                        {
                            Run(args, false, true, false);

                            break;
                        }
                    case E_CommandType.CMD_GenerateSingleDataOnly:  // 只生成单条Flatbuffer数据
                        {
                            CommonData._is_gen_single_flatbuffer = true;

                            Run(args, false, true);

                            break;
                        }
                    case E_CommandType.CMD_GenSpriteAtlasConfig:    // 只生成UI资源配置的数据
                        {
                            CommonData._is_startup_preprocess = true;
                            CommonData._is_gen_spriteatlas_only = true;

                            Run(args);

                            break;
                        }
                    default:
                        break;
                }
            }
            catch(Exception e)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("[Exception]:");
                stringBuilder.Append("Program.Main()");
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

                string logRootPath = args[args.Length - 1];
                string logPath = ToolUtils.GetPath(E_PathType.Result, logRootPath);
                string _log_file = PathUtils.Combine(logPath, "exception.log");

                if (FileUtils.Exists(_log_file))
                    FileUtils.Delete(_log_file);

                var sw = new StreamWriter(_log_file, false, Encoding.UTF8);
                if (null != sw)
                {
                    sw.Write(stringBuilder.ToString());
                    sw.Flush();
                    sw.Close();
                    sw = null;
                }

                throw;
            }
            finally
            {
                Log.Flush();
                ErrorLog.Flush();
            }

            // 如果是生成单条数据,那么不关闭控制台程序,可查看错误信息
            if (CommonData._is_gen_single_flatbuffer)
                Console.ReadKey();
        }

        /// <summary>
        /// 处理表格
        /// </summary>
        /// <param name="args">参数</param>
        /// <param name="is_recursive_flatbuffer">是否递归源数据的子目录</param>
        /// <param name="is_gen_data_only">只生成数据不生成代码</param>
        /// <param name="is_gen_json_data">是否生成json数据</param>
        static void Run(string[] args, bool is_recursive_flatbuffer = false, bool is_gen_data_only = false, bool is_gen_json_data = true)
        {
            CommonData._is_recursive_flatbuffer = is_recursive_flatbuffer;

            // flatc文件路径
            string flatc = args[1];

            // 表文件路径;
            string tablePath = args[2];

            // 生成根路径;
            string genRootPath = args[3];

            if (CommonData._is_gen_spriteatlas_only)
            {
                tablePath = SpriteAtlasProcess.Instance.GetGenXmlPath();
                genRootPath = SpriteAtlasProcess.Instance.GetGenFlatbufferPath();
            }

            // 备份生成数据的根目录
            CommonData._gen_root_path = genRootPath;

            // 如果是生成单个表数据,那么检查源文件是否存在
            if (CommonData._is_gen_single_flatbuffer && !FileUtils.Exists(tablePath))
            {
                Log.Error("The file is not exist, {0}", tablePath);
                return;
            }

            // 开始预处理;
            ProcessManager.Instance.Startup(args);

            GenerateType generateType = new GenerateType();
            if (!generateType.MakeType(tablePath, genRootPath))
                return;

            GenerateFBS generateFBS = new GenerateFBS();
            if (!generateFBS.MakeFBS(tablePath, genRootPath))
                return;

            if(!is_gen_data_only)
            {
                GenerateCode generateCode = new GenerateCode();
                if (!generateCode.MakeCode(flatc, tablePath, genRootPath))
                    return;
            }

            GenerateBinary generateBinary = new GenerateBinary();
            if (!generateBinary.MakeBinary(tablePath, genRootPath))
                return;

            if(is_gen_json_data)
            {
                GenerateJson generateJson = new GenerateJson();
                if (!generateJson.MakeJson(flatc, tablePath, genRootPath))
                    return;
            }

            if (!is_gen_data_only)
            {
                GenerateManager generateManager = new GenerateManager();
                if (!generateManager.MakeCode(genRootPath))
                    return;
            }

            if(CommonData._is_gen_single_flatbuffer)
            {// 拷贝单个文件
                Log.Print("---------------------------------------------------------------------------------------");
                Log.Print("拷贝文件...");

                string fileName = PathUtils.GetFileNameWithoutExtension(tablePath);

                string srcDataFile = PathUtils.Combine(ToolUtils.GetPath(E_PathType.Binary, genRootPath), fileName + Const.g_BytesFileExtensionName);
                string desDataFile = PathUtils.Combine(ToolUtils.GetDataTablePath(), "Tables", fileName + Const.g_BytesFileExtensionName);
                if(FileUtils.Exists(srcDataFile))
                {
                    FileUtils.Copy(srcDataFile, desDataFile, true);
                    Log.Print("copy file => {0}", desDataFile);
                }
                else
                {
                    Log.Print("The file is not exist, {0}", srcDataFile);
                }

                string srcIdsFile = PathUtils.Combine(ToolUtils.GetPath(E_PathType.Ids, genRootPath), fileName + Const.g_IdsBytesFileExtensionName);
                string desIdsFile = PathUtils.Combine(ToolUtils.GetDataTablePath(), "Tables", "ids", fileName + Const.g_IdsBytesFileExtensionName);
                if (FileUtils.Exists(srcIdsFile))
                {
                    FileUtils.Copy(srcIdsFile, desIdsFile, true);
                    Log.Print("copy file => {0}", desIdsFile);
                }
                else
                {
                    Log.Print("The file is not exist, {0}", srcIdsFile);
                }
            }

            // 结束预处理;
            ProcessManager.Instance.EndProcess();

            // 处理成功标记
            SuccessLog.Print("success");

            Log.Print("============表格处理完毕============");
        }

        /// <summary>
        /// 判断应用程序是否在运行中
        /// </summary>
        /// <returns></returns>
        static bool IsAppRunning(string[] args)
        {
            // 外网版本检查进程是否正在运行中
            string para = args[0];
            if (para.Trim() != "-ov")
                return false;

            string logRootPath = args[args.Length - 1];

            var curProcess = System.Diagnostics.Process.GetCurrentProcess();
            int appRunningCount = System.Diagnostics.Process.GetProcessesByName(curProcess.ProcessName).Length;
            if (appRunningCount > 1)
            {
                Console.WriteLine("配表工具正在执行中...");

                try
                {
                    string logPath = ToolUtils.GetPath(E_PathType.Result, logRootPath);
                    if (DirectoryUtils.Exists(logPath))
                    {
                        string _log_file = PathUtils.Combine(logPath, "warning.log");

                        if (FileUtils.Exists(_log_file))
                            FileUtils.Delete(_log_file);

                        var sw = new StreamWriter(_log_file, false, Encoding.UTF8);
                        if (null != sw)
                        {
                            sw.Write("This application is running!");
                            sw.Flush();
                            sw.Close();
                            sw = null;
                        }
                    }
                }
                catch (Exception e)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("[Exception]:");
                    stringBuilder.Append("Check this app is running or not!");
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
                    throw new Exception("此进程正在执行!重复执行会造成逻辑混乱!");
                }
            }

            return false;
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        static void Init()
        {
            // 读取本地配置
            Config.Instance.Init();

            CommonData._is_startup_preprocess = false;
            CommonData._is_gen_spriteatlas_only = false;
            CommonData._is_gen_single_flatbuffer = false;
        }

        /// <summary>
        /// 初始化Log模块
        /// </summary>
        static void InitLog(string[] args)
        {
            if (null == args || args.Length <= 0)
                return;

            int argsLength = args.Length;
            string logRootPath = args[argsLength - 1];

            // 设置Log;
            Log.SetLogFile(logRootPath);

            // 设置错误日志;
            ErrorLog.SetLogFile(logRootPath);

            // 设置成功日志;
            SuccessLog.SetLogFile(logRootPath);

            StringBuilder argsBuilder = new StringBuilder();
            for(int i = 0; i < args.Length; i++)
            {
                argsBuilder.Append(args[i]);
                argsBuilder.Append(" ");
            }

            Log.Print("---------------------------------------------------------------------------------------");
            Log.Print("参数列表: {0}", argsBuilder.ToString());
        }

        static E_CommandType GetCommandType(string[] args)
        {
            E_CommandType commandType = E_CommandType.None;

            switch (args[0])
            {
                case "-p":
                    {
                        commandType = E_CommandType.CMD_ParseTable;
                        break;
                    }
                case "-f":
                    {
                        commandType = E_CommandType.CMD_FlatBuffer;
                        break;
                    }
                case "-rf":
                    {
                        commandType = E_CommandType.CMD_Recursive_FlatBuffer;
                        break;
                    }
                case "-json":
                    {
                        commandType = E_CommandType.CMD_BuffersToJson;
                        break;
                    }
                case "-d":
                    {
                        commandType = E_CommandType.CMD_GenerateDataOnly;
                        break;
                    }
                case "-sa":
                    {
                        commandType = E_CommandType.CMD_GenSpriteAtlasConfig;
                        break;
                    }
                case "-sd":
                    {
                        commandType = E_CommandType.CMD_GenerateSingleDataOnly;
                        break;
                    }
                case "-ov":
                    {
                        commandType = E_CommandType.CMD_OutsideVersion;
                        break;
                    }
                default:
                    break;
            }

            return commandType;
        }
    }
}
