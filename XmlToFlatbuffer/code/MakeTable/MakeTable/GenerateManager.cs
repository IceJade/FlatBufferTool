using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MakeTable
{
    public class GenerateManager
    {
        /// <summary>
        /// 表列信息
        /// </summary>
        private List<TableColumnInfo> TableColumnInfoList = new List<TableColumnInfo>();

        /// <summary>
        /// 不合法的配表名称
        /// </summary>
        private List<string> invalidTables = null;

        /// <summary>
        /// 生成主管理器代码
        /// </summary>
        /// <param name="genPath"></param>
        /// <returns></returns>
        public bool MakeCode(string genPath)
        {
            if (CommonData._is_gen_spriteatlas_only)
                return true;

            Log.Print("---------------------------------------------------------------------------------------");
            Log.Print("开始创建表格管理器代码文件...");

            if (!DirectoryUtils.Exists(genPath))
                return false;

            if (!this.CreateMainManager(genPath))
                return false;

            //if (!this.CreateExtendManager(genPath))
            //    return false;

            return true;
        }

        /// <summary>
        /// 创建表格主管理器代码文件
        /// </summary>
        /// <param name="genPath"></param>
        private bool CreateMainManager(string genPath)
        {
            string modelFile = PathUtils.Combine(ToolUtils.GetPath(E_PathType.Model, genPath), Const.g_ManagerModelFileName);
            if (!FileUtils.Exists(modelFile))
                return false;

            // 获得模板文件内容;
            byte[] buffers = FileUtils.ReadAllBytes(modelFile);
            string modelContent = Encoding.UTF8.GetString(buffers);

            StringBuilder allTable = new StringBuilder();

            string fileName = string.Empty;
            string designPath = ToolUtils.GetPath(E_PathType.Design, genPath);
            DirectoryInfo TheFolder = new DirectoryInfo(designPath);
            FileInfo[] fileInfos = TheFolder.GetFiles("*.txt");
            List<FileInfo> fileInfoList = new List<FileInfo>(fileInfos);
            // 进行排序, 按字母排序, 主要兼容linux系统;
            fileInfoList.Sort((a, b) =>
            {
                if (a.Name == b.Name)
                {
                    return 0;
                }
                else if (a.Name.Contains(b.Name))
                {
                    return 1;
                }
                else if (b.Name.Contains(a.Name))
                {
                    return -1;
                }
                else
                {
                    return a.Name.CompareTo(b.Name);
                }
            });

            // 添加外部附加表
            var invalidTables = Config.Instance.GetStringArray("InvalidTables");

            foreach (FileInfo fileInfo in fileInfoList)//遍历文件夹下所有文件
            {
                //this.LoadDesignFile(fileInfo.FullName);
                if (fileInfo.Name.StartsWith(Const.g_ABFileName))
                    continue;

                // 文件名
                fileName = fileInfo.Name.Replace(fileInfo.Extension, "");

                // 如果为_b文件, 那么跳过
                if (fileName.EndsWith(Const.g_BFileName))
                    continue;

                // 不合法的配表跳过
                if (this.IsInvalidTable(fileName))
                    continue;

                allTable.Append(this.GetCaseCodeLine(fileName, E_CaseType.case_check_table));
            }

            // 添加外部附加表
            var extenalTables = Config.Instance.GetStringArray("ExtenalTables");
            if (null != extenalTables && extenalTables.Length > 0)
            {
                string allTableNames = allTable.ToString();

                for (int i = 0; i < extenalTables.Length; i++)
                {
                    string tableName = extenalTables[i].Trim();
                    if (!string.IsNullOrEmpty(tableName) && !allTableNames.Contains(tableName))
                        allTable.Append(this.GetCaseCodeLine(tableName, E_CaseType.case_check_table));
                }
            }

            string saveContent = modelContent;
            saveContent = saveContent.Replace("#case_table#", allTable.ToString());

            // 获得要写入文件的字节buffer;
            byte[] code = Encoding.UTF8.GetBytes(saveContent);
            //byte[] code = new UTF8Encoding(true).GetBytes(saveContent);

            // 获得保存的文件名;
            string codeFile = PathUtils.Combine(ToolUtils.GetPath(E_PathType.CSharp, genPath), "TableManager.cs");

            if (FileUtils.Exists(codeFile))
                FileUtils.Delete(codeFile);

            Log.Print("create manager code file => {0}", codeFile);

            try
            {
                // 创建并写入文件;
                using (FileStream fileWrite = new FileStream(codeFile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    fileWrite.Write(code, 0, code.Length);
                    fileWrite.Flush();
                    fileWrite.Close();
                    fileWrite.Dispose();
                }
            }
            catch (Exception e)
            {
                Log.Error("打开或者创建文件失败, error:{0}, file:{1}, in function CreateMainManager.", e.Message, codeFile);
                ErrorLog.Error("打开或者创建文件失败, error:{0}, file:{1}, in function CreateMainManager.", e.Message, codeFile);
            }

            return true;
        }

        /// <summary>
        /// 获得Case代码行
        /// </summary>
        /// <param name="name"></param>
        /// <param name="e_CaseType"></param>
        /// <returns></returns>
        private string GetCaseCodeLine(string name, E_CaseType e_CaseType = E_CaseType.case_int)
        {
            string result = string.Empty;

            switch (e_CaseType)
            {
                case E_CaseType.case_int:
                    {
                        result = "                case \"" + name + "\": { result = this.GetIntValueFromTable_" + name + "(id, column); break; }\n";
                        break;
                    }
                case E_CaseType.case_int_array:
                    {
                        result = "                case \"" + name + "\": { result = this.GetIntArrayFromTable_" + name + "(id, column); break; }\n";
                        break;
                    }
                case E_CaseType.case_float:
                    {
                        result = "                case \"" + name + "\": { result = this.GetFloatValueFromTable_" + name + "(id, column); break; }\n";
                        break;
                    }
                case E_CaseType.case_float_array:
                    {
                        result = "                case \"" + name + "\": { result = this.GetFloatArrayFromTable_" + name + "(id, column); break; }\n";
                        break;
                    }
                case E_CaseType.case_string:
                    {
                        result = "                case \"" + name + "\": { result = this.GetStringValueFromTable_" + name + "(id, column); break; }\n";
                        break;
                    }
                case E_CaseType.case_string_array:
                    {
                        result = "                case \"" + name + "\": { result = this.GetStringArrayFromTable_" + name + "(id, column); break; }\n";
                        break;
                    }
                case E_CaseType.case_string_array_index:
                    {
                        result = "                case \"" + name + "\": { result = this.GetStringArrayFromTable_" + name + "(id, column, index); break; }\n";
                        break;
                    }
                case E_CaseType.case_string_array_length:
                    {
                        result = "                case \"" + name + "\": { result = this.GetStringArrayLengthFromTable_" + name + "(id, column); break; }\n";
                        break;
                    }
                case E_CaseType.case_check_table:
                    {
                        result = "                case \"" + name + "\": { isValid = true; break; }\n";
                        break;
                    }
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// 加载数据类型文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool LoadDesignFile(string file)
        {
            if (!FileUtils.Exists(file))
                return false;

            // 清理数据;
            this.TableColumnInfoList.Clear();

            try
            {
                using (FileStream fileStream = new FileStream(file, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string line;
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            if (!string.IsNullOrEmpty(line))
                            {
                                var columnInfo = TableColumnInfo.Create(line);
                                if (null != columnInfo)
                                    this.TableColumnInfoList.Add(columnInfo);
                                else
                                {
                                    Log.Print("数据类型格式配置错误,请检查文件: {0}", file);
                                    ErrorLog.Print("数据类型格式配置错误,请检查文件: {0}", file);
                                }
                            }
                        }

                        reader.Close();
                        reader.Dispose();
                    }

                    fileStream.Close();
                    fileStream.Dispose();
                }
            }
            catch(Exception e)
            {
                Log.Error("加载文件失败! error:{0}, file:{1}, in function LoadDesignFile.", e.Message, file);
                ErrorLog.Error("加载文件失败! error:{0}, file:{1}, in function LoadDesignFile.", e.Message, file);
            }

            return true;
        }

        /// <summary>
        /// 是否为不合法的配表
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns>true:不合法 false:合法</returns>
        private bool IsInvalidTable(string tableName)
        {
            if (null == invalidTables)
                invalidTables = Config.Instance.GetStringList("InvalidTables", ';');

            if (null != invalidTables && invalidTables.Count > 0)
                return invalidTables.Contains(tableName);

            return false;
        }
    }
}
