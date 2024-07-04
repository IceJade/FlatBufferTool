using System;

namespace MakeTable
{
    class Program
    {
        static void Main(string[] args)
        {
            E_CommandType commandType = GetCommandType(args);
            if (commandType == E_CommandType.None)
                return;

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

                        // 设置Log;
                        Log.SetLogFile(genRootPath);

                        // 设置错误日志;
                        ErrorLog.SetLogFile(genRootPath);

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

        static void Run(string[] args)
        {
            // flatc文件路径
            string flatc = args[1];

            // 表文件路径;
            string excelPath = args[2];

            // 生成根路径;
            string genRootPath = args[3];

            // 设置Log;
            Log.SetLogFile(genRootPath);

            // 设置错误日志;
            ErrorLog.SetLogFile(genRootPath);

            GenerateType generateType = new GenerateType();
            if (!generateType.MakeType(excelPath, genRootPath))
                return;

            GenerateFBS generateFBS = new GenerateFBS();
            if (!generateFBS.MakeFBS(excelPath, genRootPath))
                return;

            GenerateCode generateCode = new GenerateCode();
            if (!generateCode.MakeCode(flatc, excelPath, genRootPath))
                return;

            GenerateBinary generateBinary = new GenerateBinary();
            if (!generateBinary.MakeBinary(excelPath, genRootPath))
                return;

            GenerateJson generateJson = new GenerateJson();
            if (!generateJson.MakeJson(flatc, excelPath, genRootPath))
                return;

            GenerateManager generateManager = new GenerateManager();
            if (!generateManager.MakeCode(genRootPath))
                return;

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
                default:
                    break;
            }

            return commandType;
        }
    }
}
