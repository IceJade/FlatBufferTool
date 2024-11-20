using NPOI.SS.Formula.Functions;
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

            // 程序正在执行中,那么退出
            if (IsAppRunning())
                return;

            E_CommandType commandType = GetCommandType(args);
            if (commandType == E_CommandType.None)
                return;

            // 初始化
            Init(args);

            switch (commandType)
            {
                case E_CommandType.CMD_ParseTable:      // 解析数据表生成表结构文件
                    {
                        if(args.Length < 3)
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
                case E_CommandType.CMD_FlatBuffer:
                case E_CommandType.CMD_Recursive_FlatBuffer:
                    {
                        Run(args);

                        break;
                    }
                case E_CommandType.CMD_GenerateDataOnly:
                    {
                        Run(args, true);

                        break;
                    }
                case E_CommandType.CMD_BuffersToJson:   // 将flatbuffer数据转换成json数据
                    {
                        ConvertBuffersToJson convertBuffersToJson = new ConvertBuffersToJson();
                        convertBuffersToJson.Run(args);

                        break;
                    }
                default:
                    break;
            }

            Log.Flush();
            ErrorLog.Flush();
        }

        static void Run(string[] args, bool isGenDataOnly = false)
        {
            // flatc文件路径
            string flatc = args[1];

            // 表文件路径;
            string excelPath = args[2];

            // 生成根路径;
            string genRootPath = args[3];

            GenerateType generateType = new GenerateType();
            if (!generateType.MakeType(excelPath, genRootPath))
                return;

            GenerateFBS generateFBS = new GenerateFBS();
            if (!generateFBS.MakeFBS(excelPath, genRootPath))
                return;

            if(!isGenDataOnly)
            {
                GenerateCode generateCode = new GenerateCode();
                if (!generateCode.MakeCode(flatc, excelPath, genRootPath))
                    return;
            }

            GenerateBinary generateBinary = new GenerateBinary();
            if (!generateBinary.MakeBinary(excelPath, genRootPath))
                return;

            GenerateJson generateJson = new GenerateJson();
            if (!generateJson.MakeJson(flatc, excelPath, genRootPath))
                return;

            if (!isGenDataOnly)
            {
                GenerateManager generateManager = new GenerateManager();
                if (!generateManager.MakeCode(genRootPath))
                    return;
            }

            Log.Print("============表格处理完毕============");
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
                default:
                    {
                        Console.WriteLine("不支持的命令行参数, 请确认!");
                        break;
                    }
            }

            return commandType;
        }

        /// <summary>
        /// 判断应用程序是否在运行中
        /// </summary>
        /// <returns></returns>
        static bool IsAppRunning()
        {
            var curProcess = System.Diagnostics.Process.GetCurrentProcess();
            int appRunningCount = System.Diagnostics.Process.GetProcessesByName(curProcess.ProcessName).Length;
            if (appRunningCount > 1)
            {
                Console.WriteLine("配表工具正在执行中,请等待...");
                return true;
            }

            return false;
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        static void Init(string[] args)
        {
            // 初始化Log
            InitLog(args);

            // 本地配置初始化
            Config.Instance.Init(args);
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

            StringBuilder argsBuilder = new StringBuilder();
            for (int i = 0; i < args.Length; i++)
            {
                argsBuilder.Append(args[i]);
                argsBuilder.Append(" ");
            }

            Log.Print("---------------------------------------------------------------------------------------");
            Log.Print("开始时间: {0}", ToolUtils.GetCurrentTime());
            Log.Print("参数列表: {0}", argsBuilder.ToString());
        }
    }
}
