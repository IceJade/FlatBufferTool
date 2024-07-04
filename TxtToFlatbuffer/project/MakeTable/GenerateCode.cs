﻿
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace MakeTable
{
    /// <summary>
    /// 生成解析代码文件
    /// </summary>
    class GenerateCode
    {
        /// <summary>
        /// 表列信息
        /// </summary>
        private List<TableColumnInfo> TableColumnInfoList = new List<TableColumnInfo>();

        #region 公有接口

        /// <summary>
        /// 生成代码文件
        /// </summary>
        /// <param name="fbsPath"></param>
        /// <param name="codePath"></param>
        /// <returns></returns>
        public bool MakeCode(string flatcFile, string tablePath, string genPath)
        {
            Log.Print("---------------------------------------------------------------------------------------");
            Log.Print("开始生成FlatBuffer解析代码文件...");

            string fileName = string.Empty;
            string designFile = string.Empty;

            // CSharp脚本生成路径
            string csGenPath = Path.Combine(ToolUtils.GetPath(E_PathType.CSharp, genPath), Const.g_FlatbufferFolder);

            if (File.Exists(tablePath))
            {
                fileName = Path.GetFileNameWithoutExtension(tablePath);
                string fbsFileName = Const.g_DataTableAliasName + fileName + Const.g_FBSFileExtensionName;
                string fbsFile = Path.Combine(ToolUtils.GetPath(E_PathType.FBS, genPath), fbsFileName);
                designFile = Path.Combine(ToolUtils.GetPath(E_PathType.Design, genPath), fileName + Const.g_TextFileExtensionName);

                // 生成C#代码
                this.CreateFlatbufferCodeFile_CSharp(flatcFile, fbsFile, csGenPath);

                // 生成Lua代码
                this.CreateFlatbufferCodeFile_Lua(flatcFile, fbsFile, ToolUtils.GetPath(E_PathType.Lua, genPath));

                // 生成框架代码
                this.CreateTableParseCode_CSharp(designFile, genPath, fileName);
            }
            else
            {
                // 遍历文件夹;
                string fbsPath = Path.Combine(ToolUtils.GetPath(E_PathType.FBS, genPath));
                DirectoryInfo TheFolder = new DirectoryInfo(fbsPath);
                foreach (FileInfo fileInfo in TheFolder.GetFiles("*.fbs"))//遍历文件夹下所有文件
                {
                    // 生成C#代码
                    this.CreateFlatbufferCodeFile_CSharp(flatcFile, fileInfo.FullName, csGenPath);

                    // 生成Lua代码
                    this.CreateFlatbufferCodeFile_Lua(flatcFile, fileInfo.FullName, ToolUtils.GetPath(E_PathType.Lua, genPath));
                    
                    fileName = Path.GetFileNameWithoutExtension(fileInfo.FullName);
                    fileName = fileName.Replace(Const.g_DataTableAliasName, "");
                    designFile = Path.Combine(ToolUtils.GetPath(E_PathType.Design, genPath), fileName + Const.g_TextFileExtensionName);

                    // 生成框架代码
                    this.CreateTableParseCode_CSharp(designFile, genPath, fileName);
                }
            }

            return true;
        }

        #endregion

        #region 私有接口

        /// <summary>
        /// 创建C#代码文件
        /// </summary>
        /// <param name="flatcFile"></param>
        /// <param name="fbsFile"></param>
        /// <param name="codePath"></param>
        /// <returns></returns>
        private bool CreateFlatbufferCodeFile_CSharp(string flatcFile, string fbsFile, string genPath)
        {
            if (!Directory.Exists(genPath))
                Directory.CreateDirectory(genPath);

            string fileName = Path.GetFileNameWithoutExtension(fbsFile);
            Log.Print("create csharp => {0}", Path.Combine(genPath, fileName + ".cs"));

            using (Process p = new Process())
            {
                string args = string.Format("--csharp --gen-onefile -o {0} {1}", genPath, fbsFile);
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
                p.WaitForExit();//等待程序执行完退出进程
                p.Close();
            }

            return true;
        }

        /// <summary>
        /// 创建Lua代码文件
        /// </summary>
        /// <param name="flatcFile"></param>
        /// <param name="fbsFile"></param>
        /// <param name="codePath"></param>
        /// <returns></returns>
        private bool CreateFlatbufferCodeFile_Lua(string flatcFile, string fbsFile, string genPath)
        {
            string fileName = Path.GetFileNameWithoutExtension(fbsFile);
            Log.Print("create lua    => {0}", Path.Combine(genPath, fileName + ".lua"));

            using (Process p = new Process())
            {
                string args = string.Format("--lua --gen-onefile -o {0} {1}", genPath, fbsFile);
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
                p.WaitForExit();//等待程序执行完退出进程
                p.Close();
            }

            return true;
        }

        /// <summary>
        /// 生成表格管理器代码
        /// </summary>
        /// <returns></returns>
        private bool CreateTableParseCode_CSharp(string designFile, string genPath, string tableFileName)
        {
            string partialModelFileName = Const.g_IntegerPartialModelFileName;

            // 加载表格设计文件
            this.LoadDesignFile(designFile);

            var columnInfo = TableColumnInfoList.Find(o => o.name.ToLower() == Const.g_Id);
            if (null != columnInfo && columnInfo.dataType == E_ColumnType.Single_String)
                partialModelFileName = Const.g_StringPartialModelFileName;

            string modelFile = Path.Combine(ToolUtils.GetPath(E_PathType.Model, genPath), partialModelFileName);
            byte[] buffers = File.ReadAllBytes(modelFile);
            string modelContent = Encoding.UTF8.GetString(buffers);

            // 替换表名;
            string saveContent = modelContent.Replace("#tablename#", tableFileName);
            // 类名大写
            saveContent = saveContent.Replace("#up_tablename#", ToolUtils.UpFirstChar(tableFileName));

            // 生成switch-case代码;
            saveContent = this.GenerateCaseCode(saveContent);

            // 生成类属性代码;
            saveContent = this.GeneratePropertyCode(saveContent);

            // 生成LuaTable
            saveContent = this.GenerateLuaTableCode(saveContent);

            // 生成LuaValue
            saveContent = this.GenerateLuaValueCode(saveContent);

            // 生成HasKey接口
            saveContent = this.GenerateHasKeyCode(saveContent);

            // 获得要写入文件的字节buffer;
            byte[] code = Encoding.UTF8.GetBytes(saveContent);

            // 获得保存的文件名;
            string codeFileName = string.Format(Const.g_TableCodeFileName, ToolUtils.UpFirstChar(tableFileName));
            string codeTablePath = Path.Combine(ToolUtils.GetPath(E_PathType.CSharp, genPath), Const.g_TableGenarateFolder);
            string codeFile = Path.Combine(codeTablePath, codeFileName);

            if (!Directory.Exists(codeTablePath))
                Directory.CreateDirectory(codeTablePath);

            if (File.Exists(codeFile))
                File.Delete(codeFile);

            Log.Print("create class => {0}", codeFile);

            // 创建并写入文件;
            FileStream fileWrite = new FileStream(codeFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fileWrite.Write(code, 0, code.Length);
            fileWrite.Flush();
            fileWrite.Close();
            fileWrite.Dispose();

            return true;
        }

        /// <summary>
        /// 生成case代码
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string GenerateCaseCode(string content)
        {
            string boolCase = string.Empty;
            string shortCase = string.Empty;
            string intCase = string.Empty;
            string floatCase = string.Empty;
            string stringCase = string.Empty;
            string boolArrayCase = string.Empty;
            string shortArrayCase = string.Empty;
            string intArrayCase = string.Empty;
            string floatArrayCase = string.Empty;
            string stringArrayCase = string.Empty;
            string stringArrayIndexCase = string.Empty;
            string stringArrayLengthCase = string.Empty;
            string dictionaryIICase = string.Empty;
            string dictionaryISCase = string.Empty;
            string dictionarySICase = string.Empty;
            string dictionarySSCase = string.Empty;

            TableColumnInfo columnInfo;
            for (int i = 0; i < this.TableColumnInfoList.Count; i++)
            {
                columnInfo = this.TableColumnInfoList[i];
                switch (columnInfo.dataType)
                {
                    case E_ColumnType.Single_Bool:
                        {
                            boolCase += this.GetCaseCodeLine(columnInfo.name);

                            break;
                        }
                    case E_ColumnType.Single_Short:
                        {
                            shortCase += this.GetCaseCodeLine(columnInfo.name);

                            break;
                        }
                    case E_ColumnType.Single_Int:
                        {
                            intCase += this.GetCaseCodeLine(columnInfo.name);
                            floatCase += this.GetCaseCodeLine(columnInfo.name);
                            stringCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.String);

                            break;
                        }
                    case E_ColumnType.Single_Float:
                        {
                            floatCase += this.GetCaseCodeLine(columnInfo.name);
                            stringCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.String);

                            break;
                        }
                    case E_ColumnType.Single_String:
                    case E_ColumnType.Fix_String:
                        {
                            stringCase += this.GetCaseCodeLine(columnInfo.name);

                            break;
                        }
                    case E_ColumnType.Single_Table:
                        {
                            break;
                        }
                    case E_ColumnType.Array_bool:
                        {
                            boolArrayCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.CommonArray);

                            break;
                        }
                    case E_ColumnType.Array_Short:
                        {
                            shortArrayCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.CommonArray);

                            break;
                        }
                    case E_ColumnType.Array_Int:
                        {
                            intArrayCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.CommonArray);

                            break;
                        }
                    case E_ColumnType.Array_Float:
                        {
                            floatArrayCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.CommonArray);

                            break;
                        }
                    case E_ColumnType.Array_String:
                    case E_ColumnType.Array_Table:
                        {
                            stringArrayCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.StringArray);
                            stringArrayIndexCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.StringArrayIndex);
                            stringArrayLengthCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.StringArrayLength);

                            break;
                        }
                    case E_ColumnType.Dictionary_II:
                        {
                            stringArrayCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.StringArray);
                            stringArrayIndexCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.StringArrayIndex);
                            stringArrayLengthCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.StringArrayLength);
                            dictionaryIICase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.Dictionary_II);

                            break;
                        }
                    case E_ColumnType.Dictionary_IS:
                        {
                            stringArrayCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.StringArray);
                            stringArrayIndexCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.StringArrayIndex);
                            stringArrayLengthCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.StringArrayLength);
                            dictionaryISCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.Dictionary_IS);

                            break;
                        }
                    case E_ColumnType.Dictionary_SI:
                        {
                            stringArrayCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.StringArray);
                            stringArrayIndexCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.StringArrayIndex);
                            stringArrayLengthCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.StringArrayLength);
                            dictionarySICase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.Dictionary_SI);

                            break;
                        }
                    case E_ColumnType.Dictionary_SS:
                        {
                            stringArrayCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.StringArray);
                            stringArrayIndexCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.StringArrayIndex);
                            stringArrayLengthCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.StringArrayLength);
                            dictionarySSCase += this.GetCaseCodeLine(columnInfo.name, E_ModelType.Dictionary_SS);

                            break;
                        }
                    default:
                        break;
                }
            }

            string genContent = content;
            genContent = genContent.Replace("#case_bool#", boolCase);
            genContent = genContent.Replace("#case_short#", shortCase);
            genContent = genContent.Replace("#case_int#", intCase);
            genContent = genContent.Replace("#case_float#", floatCase);
            genContent = genContent.Replace("#case_string#", stringCase);
            genContent = genContent.Replace("#case_bool_array#", boolArrayCase);
            genContent = genContent.Replace("#case_short_array#", shortArrayCase);
            genContent = genContent.Replace("#case_int_array#", intArrayCase);
            genContent = genContent.Replace("#case_float_array#", floatArrayCase);
            genContent = genContent.Replace("#case_string_array#", stringArrayCase);
            genContent = genContent.Replace("#case_string_array_index#", stringArrayIndexCase);
            genContent = genContent.Replace("#case_string_array_length#", stringArrayLengthCase);
            genContent = genContent.Replace("#case_dictionary_ii#", dictionaryIICase);
            genContent = genContent.Replace("#case_dictionary_is#", dictionaryISCase);
            genContent = genContent.Replace("#case_dictionary_si#", dictionarySICase);
            genContent = genContent.Replace("#case_dictionary_ss#", dictionarySSCase);

            return genContent;
        }

        /// <summary>
        /// 生成属性代码
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string GeneratePropertyCode(string content)
        {
            if (!content.Contains("#property_list#"))
                return content;

            string properts = string.Empty;

            TableColumnInfo columnInfo;
            for (int i = 0; i < this.TableColumnInfoList.Count; i++)
            {
                columnInfo = this.TableColumnInfoList[i];
                switch (columnInfo.dataType)
                {
                    case E_ColumnType.Single_Int:
                        {
                            properts += this.GetPropertsCodeLine(columnInfo.name);

                            break;
                        }
                    case E_ColumnType.Single_Short:
                        {
                            properts += this.GetPropertsCodeLine(columnInfo.name, E_ModelType.Short);
                            break;
                        }
                    case E_ColumnType.Single_Bool:
                        {
                            properts += this.GetPropertsCodeLine(columnInfo.name, E_ModelType.Bool);
                            break;
                        }
                    case E_ColumnType.Single_Float:
                        {
                            properts += this.GetPropertsCodeLine(columnInfo.name, E_ModelType.Float);

                            break;
                        }
                    case E_ColumnType.Single_String:
                    case E_ColumnType.Fix_String:
                        {
                            properts += this.GetPropertsCodeLine(columnInfo.name, E_ModelType.String);

                            break;
                        }
                    case E_ColumnType.Single_Table:
                        {
                            break;
                        }
                    case E_ColumnType.Array_Int:
                        {
                            properts += this.GetPropertsCodeLine(columnInfo.name, E_ModelType.CommonArray);

                            break;
                        }
                    case E_ColumnType.Array_Short:
                        {
                            properts += this.GetPropertsCodeLine(columnInfo.name, E_ModelType.ShortArray);

                            break;
                        }
                    case E_ColumnType.Array_bool:
                        {
                            properts += this.GetPropertsCodeLine(columnInfo.name, E_ModelType.BoolArray);

                            break;
                        }
                    case E_ColumnType.Array_Float:
                        {
                            properts += this.GetPropertsCodeLine(columnInfo.name, E_ModelType.FloatArray);

                            break;
                        }
                    case E_ColumnType.Array_String:
                        {
                            properts += this.GetPropertsCodeLine(columnInfo.name, E_ModelType.StringArray);
                            //stringArrayIndexProperts += this.GetPropertsCodeLine(columnInfo.name, E_ModelType.StringArrayIndex);
                            //stringArrayLengthProperts += this.GetPropertsCodeLine(columnInfo.name, E_ModelType.StringArrayLength);

                            break;
                        }
                    case E_ColumnType.Array_Table:
                        {
                            properts += this.GetPropertsCodeLine(columnInfo.name, E_ModelType.TableArray);

                            break;
                        }
                    case E_ColumnType.Dictionary_II:
                        {
                            properts += this.GetPropertsCodeLine(columnInfo.name, E_ModelType.Dictionary_II);
                            properts += this.GetDictionaryCodeLine(columnInfo, E_ModelType.Dictionary_II);

                            break;
                        }
                    case E_ColumnType.Dictionary_IS:
                        {
                            properts += this.GetPropertsCodeLine(columnInfo.name, E_ModelType.Dictionary_IS);
                            properts += this.GetDictionaryCodeLine(columnInfo, E_ModelType.Dictionary_IS);

                            break;
                        }
                    case E_ColumnType.Dictionary_SI:
                        {
                            properts += this.GetPropertsCodeLine(columnInfo.name, E_ModelType.Dictionary_SI);
                            properts += this.GetDictionaryCodeLine(columnInfo, E_ModelType.Dictionary_SI);

                            break;
                        }
                    case E_ColumnType.Dictionary_SS:
                        {
                            properts += this.GetPropertsCodeLine(columnInfo.name, E_ModelType.Dictionary_SS);
                            properts += this.GetDictionaryCodeLine(columnInfo, E_ModelType.Dictionary_SS);

                            break;
                        }
                    default:
                        break;
                }
            }

            string genContent = content;
            genContent = genContent.Replace("#property_list#", properts);
            //genContent = genContent.Replace("#Properts_string_array_index#", stringArrayIndexProperts);
            //genContent = genContent.Replace("#Properts_string_array_length#", stringArrayLengthProperts);

            return genContent;
        }

        /// <summary>
        /// 生成属性代码
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string GenerateLuaTableCode(string content)
        {
            if (!content.Contains("#property_luatable#"))
                return content;

            string properts = string.Empty;

            TableColumnInfo columnInfo;
            for (int i = 0; i < this.TableColumnInfoList.Count; i++)
            {
                columnInfo = this.TableColumnInfoList[i];
                switch (columnInfo.dataType)
                {
                    case E_ColumnType.Single_Int:
                    case E_ColumnType.Single_Short:
                    case E_ColumnType.Single_Bool:
                    case E_ColumnType.Single_Float:
                    case E_ColumnType.Single_String:
                    case E_ColumnType.Fix_String:
                    case E_ColumnType.Single_Table:
                        {
                            properts += this.GetLuaTableCodeLine(columnInfo.name);
                            break;
                        }
                    case E_ColumnType.Array_Int:
                    case E_ColumnType.Array_Short:
                    case E_ColumnType.Array_bool:
                    case E_ColumnType.Array_Float:
                    case E_ColumnType.Array_String:
                    case E_ColumnType.Array_Table:
                    case E_ColumnType.Dictionary_II:
                    case E_ColumnType.Dictionary_IS:
                    case E_ColumnType.Dictionary_SI:
                    case E_ColumnType.Dictionary_SS:
                        {
                            properts += this.GetLuaTableCodeLine(columnInfo.name, E_ModelType.CommonArray);
                            break;
                        }
                    default:
                        break;
                }
            }

            string genContent = content;
            genContent = genContent.Replace("#property_luatable#", properts);

            return genContent;
        }

        /// <summary>
        /// 生成Lua返回值的代码
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string GenerateLuaValueCode(string content)
        {
            if (!content.Contains("#property_luavalue#"))
                return content;

            string properts = string.Empty;

            TableColumnInfo columnInfo;
            for (int i = 0; i < this.TableColumnInfoList.Count; i++)
            {
                columnInfo = this.TableColumnInfoList[i];
                switch (columnInfo.dataType)
                {
                    case E_ColumnType.Single_Int:
                    case E_ColumnType.Single_Short:
                    case E_ColumnType.Single_Bool:
                    case E_ColumnType.Single_Float:
                    case E_ColumnType.Single_String:
                    case E_ColumnType.Fix_String:
                    case E_ColumnType.Single_Table:
                        {
                            properts += string.Format("                case \"{0}\": [[ luaValue.SetValue(this.{1}); break; ]]\n", columnInfo.name, ToolUtils.GetRealName(columnInfo.name));
                            break;
                        }
                    case E_ColumnType.Array_Int:
                    case E_ColumnType.Array_Short:
                    case E_ColumnType.Array_bool:
                    case E_ColumnType.Array_Float:
                    case E_ColumnType.Array_String:
                    case E_ColumnType.Array_Table:
                        {
                            properts += string.Format("                case \"{0}\": [[ luaValue.SetValue(this.{1}Array); break; ]]\n", columnInfo.name, ToolUtils.GetRealName(columnInfo.name));
                            break;
                        }
                    case E_ColumnType.Dictionary_II:
                    case E_ColumnType.Dictionary_IS:
                    case E_ColumnType.Dictionary_SI:
                    case E_ColumnType.Dictionary_SS:
                        {
                            properts += string.Format("                case \"{0}\": [[ luaValue.SetValue(this.{1}Dic); break; ]]\n", columnInfo.name, ToolUtils.GetRealName(columnInfo.name));
                            break;
                        }
                    default:
                        break;
                }
            }

            properts = properts.Replace("[[", "{");
            properts = properts.Replace("]]", "}");

            string genContent = content;
            genContent = genContent.Replace("#property_luavalue#", properts);

            return genContent;
        }

        /// <summary>
        /// 生成HasKey代码行
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string GenerateHasKeyCode(string content)
        {
            if (!content.Contains("#property_haskey#"))
                return content;

            string properts = string.Empty;

            TableColumnInfo columnInfo;
            for (int i = 0; i < this.TableColumnInfoList.Count; i++)
            {
                columnInfo = this.TableColumnInfoList[i];
                switch (columnInfo.dataType)
                {
                    case E_ColumnType.Single_Int:
                    case E_ColumnType.Single_Short:
                    case E_ColumnType.Single_Bool:
                    case E_ColumnType.Single_Float:
                        {
                            properts += string.Format("                case \"{0}\": [[ result = !this.IsEmpty(_datarow.{1}); break; ]]\n", columnInfo.name, ToolUtils.GetRealName(columnInfo.name));
                            break;
                        }
                    case E_ColumnType.Single_String:
                    case E_ColumnType.Fix_String:
                    case E_ColumnType.Single_Table:
                        {
                            properts += string.Format("                case \"{0}\": [[ result = !this.IsEmpty(this.{1}); break; ]]\n", columnInfo.name, ToolUtils.GetRealName(columnInfo.name));
                            break;
                        }
                    case E_ColumnType.Array_Int:
                    case E_ColumnType.Array_Short:
                    case E_ColumnType.Array_bool:
                    case E_ColumnType.Array_Float:
                    case E_ColumnType.Array_String:
                    case E_ColumnType.Array_Table:
                    case E_ColumnType.Dictionary_II:
                    case E_ColumnType.Dictionary_IS:
                    case E_ColumnType.Dictionary_SI:
                    case E_ColumnType.Dictionary_SS:
                        {
                            properts += string.Format("                case \"{0}\": [[ result = _datarow.{1}Length > 0; break; ]]\n", columnInfo.name, ToolUtils.GetRealName(columnInfo.name));
                            break;
                        }
                    default:
                        break;
                }
            }

            properts = properts.Replace("[[", "{");
            properts = properts.Replace("]]", "}");

            string genContent = content;
            genContent = genContent.Replace("#property_haskey#", properts);

            return genContent;
        }

        /// <summary>
        /// 获得Case代码行
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isCommon"></param>
        /// <returns></returns>
        private string GetCaseCodeLine(string name, E_ModelType e_ModelType = E_ModelType.Common)
        {
            string result = string.Empty;
            string realName = ToolUtils.GetRealName(name);

            switch (e_ModelType)
            {
                case E_ModelType.Common:
                    {
                        result = "                case \"" + name + "\": { result = datarow." + realName + "; break; }\n";
                        break;
                    }
                case E_ModelType.String:
                    {
                        result = "                case \"" + name + "\": { result = datarow." + realName + ".ToString(); break; }\n";
                        break;
                    }
                case E_ModelType.CommonArray:
                    {
                        result = "                case \"" + name + "\": { result = datarow." + realName + "Array; break; }\n";
                        break;
                    }
                case E_ModelType.StringArray:
                    {
                        result = "                case \"" + name + "\": { result = datarow." + realName + "Array; break; }\n";
                        break;
                    }
                case E_ModelType.StringArrayIndex:
                    {
                        result = "                case \"" + name + "\": { result = datarow." + realName + "Array[index]; break; }\n";
                        break;
                    }
                case E_ModelType.StringArrayLength:
                    {
                        result = "                case \"" + name + "\": { result = datarow." + realName + "ArrayLength; break; }\n";
                        break;
                    }
                case E_ModelType.Dictionary_II:
                case E_ModelType.Dictionary_IS:
                case E_ModelType.Dictionary_SI:
                case E_ModelType.Dictionary_SS:
                    {
                        result = "                case \"" + name + "\": { result = datarow." + realName + "Dic; break; }\n";
                        break;
                    }
                default:
                    break;
            }

            return result;
        }

        private string GetPropertsCodeLine(string name, E_ModelType e_ModelType = E_ModelType.Common)
        {
            string result = string.Empty;
            string realName = ToolUtils.GetRealName(name);

            switch (e_ModelType)
            {
                case E_ModelType.Common:
                    {
                        result += string.Format("        public int {0} [[ get [[ return _datarow.{0}; ]] ]]\n\n", realName);
                        break;
                    }
                case E_ModelType.Bool:
                    {
                        result += string.Format("        public bool {0} [[ get [[ return _datarow.{0}; ]] ]]\n\n", realName);
                        break;
                    }
                case E_ModelType.Short:
                    {
                        result += string.Format("        public short {0} [[ get [[ return _datarow.{0}; ]] ]]\n\n", realName);
                        break;
                    }
                case E_ModelType.Float:
                    {
                        result += string.Format("        public float {0} [[ get [[ return _datarow.{0}; ]] ]]\n\n", realName);
                        break;
                    }
                case E_ModelType.String:
                    {
                        result += string.Format("        private string _{0} = null;\n", realName);
                        result += string.Format("        public string {0} [[ get [[ if (null == _{0}) _{0} = _datarow.{0}; return _{0}; ]] ]]\n\n", realName);

                        break;
                    }
                case E_ModelType.CommonArray:
                    {
                        result += string.Format("        private int[] _{0}Array = null;\n", realName);
                        result += string.Format("        public int[] {0}Array [[ get [[ if (null == _{1}Array) _{2}Array = _datarow.Get{3}Array(); return _{4}Array; ]] ]]\n", realName, realName, realName, realName, realName);
                        result += string.Format("        public int {0}ArrayLength [[ get [[ if (null == this.{0}Array) return 0; return this.{0}Array.Length; ]] ]]\n\n", realName);

                        break;
                    }
                case E_ModelType.ShortArray:
                    {
                        result += string.Format("        private short[] _{0}Array = null;\n", realName);
                        result += string.Format("        public short[] {0}Array [[ get [[ if (null == _{1}Array) _{2}Array = _datarow.Get{3}Array(); return _{4}Array; ]] ]]\n", realName, realName, realName, realName, realName);
                        result += string.Format("        public short {0}ArrayLength [[ get [[ if (null == this.{0}Array) return 0; return this.{0}Array.Length; ]] ]]\n\n", realName);

                        break;
                    }
                case E_ModelType.BoolArray:
                    {
                        result += string.Format("        private bool[] _{0}Array = null;\n", realName);
                        result += string.Format("        public bool[] {0}Array [[ get [[ if (null == _{1}Array) _{2}Array = _datarow.Get{3}Array(); return _{4}Array; ]] ]]\n", realName, realName, realName, realName, realName);
                        result += string.Format("        public bool {0}ArrayLength [[ get [[ if (null == this.{0}Array) return 0; return this.{0}Array.Length; ]] ]]\n\n", realName);

                        break;
                    }
                case E_ModelType.FloatArray:
                    {
                        result += string.Format("        private float[] _{0}Array = null;\n", realName);
                        result += string.Format("        public float[] {0}Array [[ get [[ if (null == _{1}Array) _{2}Array = _datarow.Get{3}Array(); return _{4}Array; ]] ]]\n", realName, realName, realName, realName, realName);
                        result += string.Format("        public int {0}ArrayLength [[ get [[ if (null == this.{0}Array) return 0; return this.{0}Array.Length; ]] ]]\n", realName);
                        result += "\n";

                        break;
                    }
                case E_ModelType.StringArray:
                    {
                        result += this.GetStringArrayCode(realName);

                        break;
                    }
                case E_ModelType.TableArray:
                    {
                        result += this.GetStringArrayCode(realName);

                        break;
                    }
                case E_ModelType.Dictionary_II:
                    {
                        result += this.GetStringArrayCode(realName);

                        break;
                    }
                case E_ModelType.Dictionary_IS:
                    {
                        result += this.GetStringArrayCode(realName);

                        break;
                    }
                case E_ModelType.Dictionary_SI:
                    {
                        result += this.GetStringArrayCode(realName);

                        break;
                    }
                case E_ModelType.Dictionary_SS:
                    {
                        result += this.GetStringArrayCode(realName);

                        break;
                    }
                default:
                    break;
            }

            result = result.Replace("[[", "{");
            result = result.Replace("]]", "}");

            return result;
        }

        private string GetLuaTableCodeLine(string name, E_ModelType e_ModelType = E_ModelType.Common)
        {
            string result = string.Empty;
            string realName = ToolUtils.GetRealName(name);

            switch (e_ModelType)
            {
                case E_ModelType.Common:
                    {
                        result += string.Format("                if(this.HasKey(\"{0}\")) _LuaDataRow.Set(\"{0}\", this.{1});\n", name, realName);
                        break;
                    }
                case E_ModelType.CommonArray:
                    {
                        result += string.Format("                if(this.HasKey(\"{0}\")) _LuaDataRow.Set(\"{0}\", this.{1}Array);\n", name, realName);
                        break;
                    }
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// 生成Dictionary代码
        /// </summary>
        /// <param name="columnInfo"></param>
        /// <param name="e_ModelType"></param>
        /// <returns></returns>
        private string GetDictionaryCodeLine(TableColumnInfo columnInfo, E_ModelType e_ModelType = E_ModelType.Dictionary_II)
        {
            string result = "";

            string realName = ToolUtils.GetRealName(columnInfo.name);

            switch (e_ModelType)
            {
                case E_ModelType.Dictionary_II:
                    {
                        result = string.Format("        private Dictionary<int, int> _{0}Dic = null;\n", realName);
                        result += string.Format("        public Dictionary<int, int> {0}Dic [[ get [[ if(null == _{0}Dic) " +
                            "[[ _{0}Dic = new Dictionary<int, int>(); if({0}ArrayLength > 0) [[ for(int i = 0; i < {0}ArrayLength; i++) [[ string[] array = {0}Array[i].Split('{1}'); " +
                            "if(array.Length > 1) [[ int key = array[0].ToInt(); if (!_{0}Dic.ContainsKey(key)) _{0}Dic.Add(array[0].ToInt(), array[1].ToInt()); ]] ]] ]] ]] return _{0}Dic; ]] ]]\n", 
                            realName, columnInfo.item_separator);
                        result += "\n";

                        break;
                    }
                case E_ModelType.Dictionary_IS:
                    {
                        result = string.Format("        private Dictionary<int, string> _{0}Dic = null;\n", realName);
                        result += string.Format("        public Dictionary<int, string> {0}Dic [[ get [[ if(null == _{0}Dic) " +
                            "[[ _{0}Dic = new Dictionary<int, string>(); if({0}ArrayLength > 0) [[ for(int i = 0; i < {0}ArrayLength; i++) [[ string[] array = {0}Array[i].Split('{1}'); " +
                            "if(array.Length > 1) [[ int key = array[0].ToInt(); if (!_{0}Dic.ContainsKey(key)) _{0}Dic.Add(array[0].ToInt(), array[1]); ]] ]] ]] ]] return _{0}Dic; ]] ]]\n",
                            realName, columnInfo.item_separator);
                        result += "\n";

                        break;
                    }
                case E_ModelType.Dictionary_SI:
                    {
                        result = string.Format("        private Dictionary<string, int> _{0}Dic = null;\n", realName);
                        result += string.Format("        public Dictionary<string, int> {0}Dic [[ get [[ if(null == _{0}Dic) " +
                            "[[ _{0}Dic = new Dictionary<string, int>(); if({0}ArrayLength > 0) [[ for(int i = 0; i < {0}ArrayLength; i++) [[ string[] array = {0}Array[i].Split('{1}'); " +
                            "if(array.Length > 1) [[ string key = array[0]; if (!_{0}Dic.ContainsKey(key)) _{0}Dic.Add(array[0], array[1].ToInt()); ]] ]] ]] ]] return _{0}Dic; ]] ]]\n",
                            realName, columnInfo.item_separator);
                        result += "\n";

                        break;
                    }
                case E_ModelType.Dictionary_SS:
                    {
                        result = string.Format("        private Dictionary<string, string> _{0}Dic = null;\n", realName);
                        result += string.Format("        public Dictionary<string, string> {0}Dic [[ get [[ if(null == _{0}Dic) " +
                            "[[ _{0}Dic = new Dictionary<string, string>(); if({0}ArrayLength > 0) [[ for(int i = 0; i < {0}ArrayLength; i++) [[ string[] array = {0}Array[i].Split('{1}'); " +
                            "if(array.Length > 1) [[ string key = array[0]; if (!_{0}Dic.ContainsKey(key)) _{0}Dic.Add(array[0], array[1]); ]] ]] ]] ]] return _{0}Dic; ]] ]]\n",
                            realName, columnInfo.item_separator);
                        result += "\n";

                        break;
                    }
                default:
                    break;
            }

            result = result.Replace("[[", "{");
            result = result.Replace("]]", "}");

            return result;
        }

        /// <summary>
        /// 获得字符串数组代码
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        private string GetStringArrayCode(string columnName)
        {
            string result = string.Format("        private string[] _{0}Array = null;\n", columnName);
            result += string.Format("        public string[] {0}Array [[ get [[ if(null == _{0}Array) [[ if (_datarow.{0}Length > 0) " +
                "[[ _{0}Array = new string[_datarow.{0}Length]; for (int i = 0; i < _datarow.{0}Length; i++) " +
                "[[ _{0}Array[i] = _datarow.{0}(i); ]] ]] ]] return _{0}Array; ]] ]]\n", columnName);
            result += string.Format("        public int {0}ArrayLength [[ get [[ if (null == this.{0}Array) return 0; return this.{0}Array.Length; ]] ]]\n", columnName);
            result += "\n";

            return result;
        }

        /// <summary>
        /// 加载表格结构文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool LoadDesignFile(string file)
        {
            if (!File.Exists(file))
                return false;

            // 清理数据;
            this.TableColumnInfoList.Clear();

            using (FileStream fileStream = new FileStream(file, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                            this.TableColumnInfoList.Add(TableColumnInfo.Create(line));
                    }

                    reader.Close();
                    reader.Dispose();
                }

                fileStream.Close();
                fileStream.Dispose();
            }

            return true;
        }

        #endregion
    }
}
