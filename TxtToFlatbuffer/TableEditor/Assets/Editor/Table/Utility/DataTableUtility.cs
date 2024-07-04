using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text;

namespace DataTableEditor
{
    public partial class Utility
    {
        public class DataTableUtility
        {
            public static Vector2 GetMiddlePosition(float windowWidth, float windowHeight)
            {
                return new Vector2(Screen.currentResolution.width / 2 - windowWidth / 2,
                    Screen.currentResolution.height / 2 - windowHeight / 2);
            }

            public static Vector2 GetMiddlePosition(Vector2 windowSize)
            {
                return new Vector2(Screen.currentResolution.width / 2 - windowSize.x / 2,
                    Screen.currentResolution.height / 2 - windowSize.y / 2);
            }

            //模板
            public static List<DataTableRowData> DataTableTemplate = new List<DataTableRowData>
            {
                new DataTableRowData()
                {
                    Data = new List<string>()
                    {
                        "#", "配置", "", ""
                    }
                },
                new DataTableRowData()
                {
                    Data = new List<string>()
                    {
                        "#", "ID", "", ""
                    }
                },
                new DataTableRowData()
                {
                    Data = new List<string>()
                    {
                        "#", "int", "", ""
                    }
                },
                new DataTableRowData()
                {
                    Data = new List<string>()
                    {
                        "", "0", "", ""
                    }
                },
            };

            /// <summary>
            /// 新建表格
            /// </summary>
            /// <returns>新建表格文件路径</returns>
            public static string NewDataTableFile(Encoding encoding)
            {
                string path = EditorUtility.SaveFilePanel("保存文件", "", "template.txt", "txt");

                if (string.IsNullOrEmpty(path) == false)
                    SaveDataTableFile(path, DataTableTemplate, encoding);

                return path;
            }

            /// <summary>
            /// 保存表格文件
            /// </summary>
            /// <param name="path">保存文件路径</param>
            /// <param name="data">数据信息</param>
            /// <returns>保存是否成功</returns>
            public static bool SaveDataTableFile(string path, List<DataTableRowData> datas, Encoding encoding, E_LoadType loadType = E_LoadType.Whole)
            {
                switch(loadType)
                {
                    case E_LoadType.Whole:
                        {
                            using (StreamWriter sw = new StreamWriter(path, false, encoding))
                            {
                                for (int i = 0; i < datas.Count; i++)
                                {
                                    for (int j = 0; j < datas[i].Data.Count; j++)
                                    {
                                        sw.Write(datas[i].Data[j]);

                                        if (j < datas[i].Data.Count - 1)
                                            sw.Write("\t");
                                    }

                                    if (i < datas.Count - 1)
                                        sw.WriteLine();
                                }
                            }

                            break;
                        }
                    case E_LoadType.End:
                        {
                            if(datas.Count > g_default_read_end_line_count + g_table_comments_line_count)
                            {
                                bool isWrapEnd = false;
                                using (StreamReader sr = new StreamReader(path))
                                {
                                    var content = sr.ReadToEnd();
                                    if (content.EndsWith("\n") || content.EndsWith("\r\n"))
                                        isWrapEnd = true;
                                }

                                using (StreamWriter sw = new StreamWriter(path, true, encoding))
                                {
                                    if (!isWrapEnd)
                                        sw.WriteLine();

                                    for (int i = g_table_comments_line_count + g_default_read_end_line_count; i < datas.Count; i++)
                                    {
                                        for (int j = 0; j < datas[i].Data.Count; j++)
                                        {
                                            sw.Write(datas[i].Data[j]);

                                            if (j < datas[i].Data.Count - 1)
                                                sw.Write("\t");
                                        }

                                        if (i < datas.Count - 1)
                                            sw.WriteLine();
                                    }
                                }
                            }

                            break;
                        }
                    case E_LoadType.SelectedUIs:
                        {
                            ReplaceTableLineData(TableTools.GetUIFile(), datas);
                            break;
                        }
                    case E_LoadType.SelectedEffects:
                        {
                            ReplaceTableLineData(TableTools.GetEffectFile(), datas);
                            break;
                        }
                    default:
                        break;
                }

                AssetDatabase.Refresh();

                return true;
            }

            /// <summary>
            /// 替换数据行
            /// </summary>
            /// <param name="configFile"></param>
            /// <param name="data"></param>
            private static void ReplaceTableLineData(string configFile, List<DataTableRowData> datas)
            {
                if (string.IsNullOrEmpty(configFile))
                    return;

                if (null == datas || datas.Count < 4 || datas[3].Data.Count < 3)
                    return;

                List<string> lines = new List<string>();

                using(StreamReader sr = new StreamReader(configFile, Encoding.UTF8))
                {
                    while(!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] splited = line.Split('\t');
                        if (null != splited && splited.Length > 2)
                        {
                            var assetFile = splited[2].ToLowerInvariant();

                            bool need_replace = false;
                            for(int i = 3; i < datas.Count; i++)
                            {
                                var lowKey = datas[i].Data[2].ToLowerInvariant();

                                if (assetFile.Contains(lowKey) || lowKey.Contains(assetFile))
                                {
                                    StringBuilder tempBuilder = new StringBuilder();
                                    int count = datas[i].Data.Count;
                                    for (int j = 0; j < count; j++)
                                    {
                                        tempBuilder.Append(datas[i].Data[j]);

                                        if (j < count - 1)
                                            tempBuilder.Append("\t");
                                    }

                                    lines.Add(tempBuilder.ToString());

                                    need_replace = true;

                                    break;
                                }
                            }

                            if(!need_replace)
                                lines.Add(line);
                        }
                    }
                }

                using (StreamWriter sw = new StreamWriter(configFile, false, Encoding.UTF8))
                {
                    for (int i = 0; i < lines.Count; i++)
                    {
                        sw.Write(lines[i]);

                        if (i < lines.Count - 1)
                            sw.WriteLine();
                    }
                }
            }

            // 配表注释行数
            public static int g_table_comments_line_count = 3;
            // 默认读取末尾三行
            public static int g_default_read_end_line_count = 3;

            /// <summary>
            /// 加载数据表文件
            /// </summary>
            /// <param name="path">表格文件路径</param>
            /// <returns>保存的信息数据</returns>
            public static List<DataTableRowData> LoadDataTableFile(string path, List<string> keys, Encoding encoding, E_LoadType loadType = E_LoadType.Whole)
            {
                if (File.Exists(path) == false)
                {
                    EditorUtility.DisplayDialog("提示", "文件路径不存在", "确定");
                    return null;
                }

                List<DataTableRowData> data = new List<DataTableRowData>();

                int index = 0;
                using (StreamReader sr = new StreamReader(path, encoding))
                {
                    while (sr.EndOfStream == false)
                    {
                        string line = sr.ReadLine();
                        string[] splited = line.Split('\t');
                        if (null != splited && splited.Length > 1)
                        {
                            if(loadType == E_LoadType.SelectedUIs 
                                || loadType == E_LoadType.SelectedEffects)
                            {
                                if(index < 3)
                                {
                                    DataTableRowData row = new DataTableRowData();

                                    for (int i = 0; i < splited.Length; i++)
                                        row.Data.Add(splited[i]);

                                    data.Add(row);
                                }
                                else
                                {
                                    if (null == keys)
                                        break;

                                    var assetFile = splited[2].ToLowerInvariant();

                                    for(int i = 0; i < keys.Count; i++)
                                    {
                                        var lowKey = keys[i].ToLowerInvariant();

                                        if (assetFile.Contains(lowKey) || lowKey.Contains(assetFile))
                                        {
                                            DataTableRowData row = new DataTableRowData();

                                            for (int j = 0; j < splited.Length; j++)
                                                row.Data.Add(splited[j]);

                                            data.Add(row);

                                            break;
                                        }
                                    }
                                }

                                index++;
                            }
                            else
                            {
                                DataTableRowData row = new DataTableRowData();

                                for (int i = 0; i < splited.Length; i++)
                                    row.Data.Add(splited[i]);

                                data.Add(row);
                            }
                        }
                    }
                }

                switch(loadType)
                {
                    case E_LoadType.End:
                        {
                            if(data.Count > g_default_read_end_line_count)
                                data.RemoveRange(g_table_comments_line_count, data.Count - g_default_read_end_line_count - g_table_comments_line_count);

                            break;
                        }
                    default:
                        break;
                }

                return data;
            }
        }
    }
}
