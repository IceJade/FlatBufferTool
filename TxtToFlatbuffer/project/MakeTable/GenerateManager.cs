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
        /// 生成主管理器代码
        /// </summary>
        /// <param name="genPath"></param>
        /// <returns></returns>
        public bool MakeCode(string genPath)
        {
            Log.Print("---------------------------------------------------------------------------------------");
            Log.Print("开始创建表格管理器代码文件...");

            if (!Directory.Exists(genPath))
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
            string modelFile = Path.Combine(ToolUtils.GetPath(E_PathType.Model, genPath), Const.g_ManagerModelFileName);
            if (!File.Exists(modelFile))
                return false;

            // 获得模板文件内容;
            byte[] buffers = File.ReadAllBytes(modelFile);
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
                if(a.Name == b.Name)
                {
                    return 0;
                }
                else if(a.Name.Contains(b.Name))
                {
                    return 1;
                }
                else if(b.Name.Contains(a.Name))
                {
                    return -1;
                }
                else
                {
                    return a.Name.CompareTo(b.Name);
                }
            });

            foreach (FileInfo fileInfo in fileInfoList)//遍历文件夹下所有文件
            {
                // 文件名
                fileName = fileInfo.Name.Replace(fileInfo.Extension, "");

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
                    if (!allTableNames.Contains(tableName))
                        allTable.Append(this.GetCaseCodeLine(tableName, E_CaseType.case_check_table));
                }
            }

            string saveContent = modelContent;
            saveContent = saveContent.Replace("#case_table#", allTable.ToString());

            // 获得要写入文件的字节buffer;
            byte[] code = Encoding.UTF8.GetBytes(saveContent);
            //byte[] code = new UTF8Encoding(true).GetBytes(saveContent);

            // 获得保存的文件名;
            string codeFile = Path.Combine(ToolUtils.GetPath(E_PathType.CSharp, genPath), "ConfigManager.cs");

            if (File.Exists(codeFile))
                File.Delete(codeFile);

            Log.Print("create manager code file => {0}", codeFile);

            // 创建并写入文件;
            FileStream fileWrite = new FileStream(codeFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fileWrite.Write(code, 0, code.Length);
            fileWrite.Flush();
            fileWrite.Close();
            fileWrite.Dispose();

            return true;
        }

        /// <summary>
        /// 创建表格主管理器代码文件
        /// </summary>
        /// <param name="genPath"></param>
        private bool CreateExtendManager(string genPath)
        {
            string modelFile = Path.Combine(ToolUtils.GetPath(E_PathType.Model, genPath), Const.g_ManagerExtendModelFileName);
            if (!File.Exists(modelFile))
                return false;

            string tableExtendMode = this.GetTableExtendMode(genPath);

            // 获得模板文件内容;
            byte[] buffers = File.ReadAllBytes(modelFile);
            string modelContent = Encoding.UTF8.GetString(buffers);

            StringBuilder allTable = new StringBuilder();

            bool isInt = true;
            string fileName = string.Empty;
            string designPath = ToolUtils.GetPath(E_PathType.Design, genPath);
            string targetCode = string.Empty;

            DirectoryInfo TheFolder = new DirectoryInfo(designPath);
            foreach (FileInfo fileInfo in TheFolder.GetFiles("*.txt"))//遍历文件夹下所有文件
            {
                isInt = true;

                this.LoadDesignFile(fileInfo.FullName);

                var columnInfo = this.TableColumnInfoList.Find(o => o.name.ToLower() == Const.g_Id);
                if (null != columnInfo && columnInfo.dataType == E_ColumnType.Single_String)
                    isInt = false;

                fileName = fileInfo.Name.Replace(fileInfo.Extension, "");
                targetCode = tableExtendMode.Replace("#tablename#", fileName);
                targetCode = targetCode.Replace("#up_tablename#", ToolUtils.UpFirstChar(fileName));

                if(isInt)
                    targetCode = targetCode.Replace("#data_type#", "int");
                else
                    targetCode = targetCode.Replace("#data_type#", "string");

                allTable.Append(targetCode + "\n");
            }

            string saveContent = modelContent;
            saveContent = saveContent.Replace("#table_list#", allTable.ToString());

            // 获得要写入文件的字节buffer;
            byte[] code = Encoding.UTF8.GetBytes(saveContent);

            // 获得保存的文件名;
            string codeFile = Path.Combine(ToolUtils.GetPath(E_PathType.CSharp, genPath), "TableManager.Extend.cs");

            if (File.Exists(codeFile))
                File.Delete(codeFile);

            Log.Print("create extend manager => {0}", codeFile);

            // 创建并写入文件;
            FileStream fileWrite = new FileStream(codeFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fileWrite.Write(code, 0, code.Length);
            fileWrite.Flush();
            fileWrite.Close();
            fileWrite.Dispose();

            return true;
        }

        /// <summary>
        /// 创建表格主管理器代码文件
        /// </summary>
        /// <param name="genPath"></param>
        private string GetTableExtendMode(string genPath)
        {
            string modelFile = Path.Combine(ToolUtils.GetPath(E_PathType.Model, genPath), Const.g_TableExtendModelFileName);
            if (!File.Exists(modelFile))
                return string.Empty;

            // 获得模板文件内容;
            byte[] buffers = File.ReadAllBytes(modelFile);
            return Encoding.UTF8.GetString(buffers);
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
        /// 创建FBS文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="generatePath"></param>
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
    }
}
