using System;
using System.Collections.Generic;
using System.IO;

namespace MakeTable
{
    /// <summary>
    /// 生成FBS文件
    /// </summary>
    public class GenerateFBS
    {
        /// <summary>
        /// 表列信息
        /// </summary>
        private List<TableColumnInfo> TableColumnInfoList = new List<TableColumnInfo>();

        #region 公共接口

        /// <summary>
        /// 生成FBS文件
        /// </summary>
        /// <param name="tablePath"></param>
        /// <param name="generatePath"></param>
        /// <returns></returns>
        public bool MakeFBS(string tablePath, string genPath)
        {
            if (string.IsNullOrEmpty(tablePath))
                return false;

            if (string.IsNullOrEmpty(genPath))
                return false;

            Log.Print("---------------------------------------------------------------------------------------");
            Log.Print("开始生成FBS文件...");

            if(File.Exists(tablePath))
            {
                string fileName = Path.GetFileNameWithoutExtension(tablePath);
                string designFile = Path.Combine(ToolUtils.GetPath(E_PathType.Design, genPath), fileName + Const.g_TextFileExtensionName);

                if (!this.LoadDesignFile(designFile))
                    return false;

                if (!this.CreateBFSFile(designFile, genPath))
                    return false;
            }
            else
            {
                // 遍历文件;
                string designPath = ToolUtils.GetPath(E_PathType.Design, genPath);
                DirectoryInfo TheFolder = new DirectoryInfo(designPath);
                foreach (FileInfo fileInfo in TheFolder.GetFiles("*.txt"))//遍历文件夹下所有文件
                {
                    if (!this.LoadDesignFile(fileInfo.FullName))
                        return false;

                    if (!this.CreateBFSFile(fileInfo.FullName, genPath))
                        return false;
                }
            }

            return true;
        }

        #endregion

        #region 私有接口

        /// <summary>
        /// 加载表格结构文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool LoadDesignFile(string designFile)
        {
            if (!File.Exists(designFile))
                return false;

            // 清理数据;
            this.TableColumnInfoList.Clear();

            using (FileStream fileStream = new FileStream(designFile, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line;
                    while(!reader.EndOfStream)
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

        /// <summary>
        /// 创建FBS文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="savePath"></param>
        /// <returns></returns>
        private bool CreateBFSFile(string designFile, string savePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(designFile);
            string tableFileName = Const.g_TableAliasName + fileName;
            string dataRowFileName = Const.g_DataRowAliasName + fileName;
            string dataTableFileName = Const.g_DataTableAliasName + fileName + Const.g_FBSFileExtensionName;
            string saveFile = Path.Combine(ToolUtils.GetPath(E_PathType.FBS, savePath), dataTableFileName);

            if (File.Exists(saveFile))
                File.Delete(saveFile);

            Log.Print("create fbs => {0}", saveFile);

            // 如果文件存在, 那么先删除
            if (File.Exists(saveFile))
                File.Delete(saveFile);

            string configNameSpace = Config.Instance.GetString("NameSpace", "Game.Table");
            string nameSpace = $"namespace {configNameSpace};";

            using (FileStream fileStream = new FileStream(saveFile, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    // 写入文件头;
                    writer.WriteLine(nameSpace);
                    writer.WriteLine();

                    // 写入表名;
                    writer.WriteLine(string.Format("table {0}", dataRowFileName));
                    writer.WriteLine("{");

                    foreach (var item in TableColumnInfoList)
                        writer.WriteLine(item.GetFBS());

                    writer.WriteLine("}");
                    writer.WriteLine();
                    writer.WriteLine(string.Format("table {0}", tableFileName));
                    writer.WriteLine("{");
                    writer.WriteLine(string.Format("  data:[{0}];", dataRowFileName));
                    writer.WriteLine("}");
                    writer.WriteLine();
                    writer.WriteLine(string.Format("root_type {0};", tableFileName));

                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                }

                fileStream.Close();
                fileStream.Dispose();
            }

            return true;
        }

        #endregion
    }
}
