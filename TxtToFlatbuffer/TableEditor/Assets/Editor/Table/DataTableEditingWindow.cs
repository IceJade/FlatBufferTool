using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using static DataTableEditor.Utility;

namespace DataTableEditor
{
    public enum E_LoadType
    {
        Error = -1,
        Whole,              // 加载整表
        End,                // 只加载配表的末尾三行
        SelectedUIs,        // 只加载选定的UI数据
        SelectedEffects     // 只加载选定的特效数据
    }

    public class DataTableEditingWindowInstance
    {
        public DataTableEditingWindow Instance { get; private set; }

        public void SetData(string path, Encoding encoding, E_LoadType loadType = E_LoadType.Whole)
        {
            FileInfo fileInfo = new FileInfo(path);
            Instance = EditorWindowUtility.CreateWindow<DataTableEditingWindow>(fileInfo.Name);
            Instance.OpenWindow(path, null, encoding, loadType);
            Instance.Show();
        }

        public void SetData(string path, List<string> prefabFiles, Encoding encoding, E_LoadType loadType = E_LoadType.Whole)
        {
            FileInfo fileInfo = new FileInfo(path);
            Instance = EditorWindowUtility.CreateWindow<DataTableEditingWindow>(fileInfo.Name);
            Instance.OpenWindow(path, prefabFiles, encoding, loadType);
            Instance.Show();
        }
    }


    public class DataTableEditingWindow : EditorWindow
    {
        public List<DataTableRowData> RowDatas { get; private set; }

        private List<DataTableRowData> RowDatasTemp;
        private ReorderableList reorderableList;

        private List<int> columnWidthList = new List<int>();
        private int totalWidth = 0;

        public string FilePath { get; private set; }

        public int LightMode = 0;

        private Vector2 m_scrollViewPos;

        private Encoding m_encoding;
        private int m_codePage;
        private E_LoadType m_loadType;

        public void OpenWindow(string path, List<string> keys, Encoding encoding, E_LoadType loadType = E_LoadType.Whole)
        {
            m_encoding = encoding;
            m_loadType = loadType;
            m_codePage = encoding.CodePage;
            FilePath = path;
            RowDatas = DataTableUtility.LoadDataTableFile(FilePath, keys, m_encoding, loadType);

            if (RowDatas == null)
                return;

            columnWidthList.Clear();
            RowDatasTemp = new List<DataTableRowData>();

            for (int i = 0; i < RowDatas.Count; i++)
            {
                DataTableRowData data = new DataTableRowData();

                for (int j = 0; j < RowDatas[i].Data.Count; j++)
                {
                    data.Data.Add(RowDatas[i].Data[j]);

                    if (columnWidthList.Count < j + 1)
                    {
                        columnWidthList.Add(RowDatas[i].Data[j].Length);
                    }
                    else
                    {
                        if(RowDatas[i].Data[j].Length > columnWidthList[j])
                            columnWidthList[j] = RowDatas[i].Data[j].Length;
                    }
                }

                RowDatasTemp.Add(data);
            }

            totalWidth = 0;
            for (int i = 0; i < columnWidthList.Count; i++)
            {
                if (i == 0 && columnWidthList[i] < 20)
                    columnWidthList[i] = 20;
                else if (columnWidthList[i] < 10)
                    columnWidthList[i] = Mathf.Min(10, columnWidthList[i] + 4);
                else if (columnWidthList[i] % 2 != 0)
                    columnWidthList[i] += 1;
                
                totalWidth += columnWidthList[i];
            }
        }

        private void OnGUI()
        {
            m_scrollViewPos = GUILayout.BeginScrollView(m_scrollViewPos);
            if (RowDatas == null || RowDatas.Count == 0)
            {
                Close();
                GUILayout.EndScrollView();
                return;
            }

            CheckColumnCount();

            if (reorderableList == null)
            {
                reorderableList = new ReorderableList(RowDatas, typeof(List<DataTableRowData>), true, true, true, true);
                reorderableList.drawHeaderCallback = (Rect rect) =>
                {
                    EditorGUI.LabelField(rect, FilePath);
                    rect.x = rect.width - 210;
                    EditorGUI.LabelField(rect, "按Ctrl+S键保存或者关闭窗口时提示保存!");
                };

                reorderableList.drawElementCallback = (Rect rect, int index, bool selected, bool focused) =>
                {
                    float offset_x = 20.0f;
                    float position_x = offset_x;

                    for (int i = 0; i < RowDatas[index].Data.Count; i++)
                    {
                        //if (RowDatas[index].Data.Count > 10)
                        //{
                        //    rect.width = (this.position.width - offset_x) / 10;
                        //    rect.x = rect.width * i + offset_x;
                        //}
                        //else
                        //{
                            rect.width = (this.position.width - offset_x) * columnWidthList[i] / this.totalWidth;
                            rect.x = position_x;

                            position_x += rect.width;
                        //}
                        
                        RowDatas[index].Data[i] = EditorGUI.TextField(rect, "", RowDatas[index].Data[i], "ScriptText");
                    }
                };

                reorderableList.onAddCallback = list =>
                {
                    if (m_loadType == E_LoadType.SelectedEffects || m_loadType == E_LoadType.SelectedUIs)
                    {
                        EditorUtility.DisplayDialog("提示", "编辑选定数据时不允许添加行数据？", "确定");
                        return;
                    }

                    bool result = EditorUtility.DisplayDialog("提示", "确认添加行数据？", "确定", "取消");
                    if (result)
                    {
                        if (RowDatas.Count == 0)
                        {
                            RowDatas.Add(new DataTableRowData()
                            {
                                Data = new List<string>() {"", "", "", ""}
                            });
                        }
                        else
                        {
                            int length = RowDatas.Count;

                            DataTableRowData data = new DataTableRowData();

                            for (int i = 0; i < RowDatas[length - 1].Data.Count; i++)
                            {
                                if(i == 0)
                                {
                                    data.Data.Add("");
                                }
                                else if (i == 1)
                                {
                                    if(int.TryParse(RowDatas[length - 1].Data[i], out int id))
                                    {
                                        data.Data.Add((id + 1).ToString());
                                    }
                                    else
                                    {
                                        data.Data.Add("id");
                                    }
                                }
                                else
                                {
                                    data.Data.Add(RowDatas[length - 1].Data[i]);
                                }
                            }

                            RowDatas.Add(data);
                        }
                    }

                    Focus();
                };

                reorderableList.onRemoveCallback = list =>
                {
                    if (list.index < DataTableUtility.g_table_comments_line_count)
                    {
                        EditorUtility.DisplayDialog("提示", "前三行为配表必要的注释说明,不能删除!", "确定");
                        return;
                    }

                    if (m_loadType == E_LoadType.SelectedEffects || m_loadType == E_LoadType.SelectedUIs)
                    {
                        EditorUtility.DisplayDialog("提示", "编辑选定数据时不允许删除行数据？", "确定");
                        return;
                    }

                    switch (this.m_loadType)
                    {
                        case E_LoadType.End:
                            {
                                if (list.index < DataTableUtility.g_table_comments_line_count + DataTableUtility.g_table_comments_line_count)
                                    EditorUtility.DisplayDialog("提示", "简易加载模式不允许删除默认加载行!", "确定");
                                else
                                    RowDatas.RemoveAt(list.index);

                                break;
                            }
                        default:
                            {
                                bool result = EditorUtility.DisplayDialog("提示", "确认移除选中行？", "确定", "取消");

                                if (result)
                                    RowDatas.RemoveAt(list.index);

                                break;
                            }
                    }

                    Focus();
                };
            }

            reorderableList.DoLayoutList();

            if (RowDatas != null && RowDatas.Count > 0)
            {
                if (RowDatas[0].Data.Count > 10)
                {
                    float listItemWidth = 0f;
                    float listX = 0f;
                    listItemWidth = (position.width - 20) / 10;
                    listX = listItemWidth * (RowDatas[0].Data.Count - 1) + 20;
                    GUILayout.Label("", new GUIStyle() {fixedWidth = listX});
                }
            }

            GUILayout.EndScrollView();
            if (IsCombinationKey(EventModifiers.Control, KeyCode.S, EventType.KeyDown))
            {
                SaveDataTable();
            }
        }

        private void SaveDataTable()
        {
            if (!CheckDirty())
                return;

            RowDatasTemp = new List<DataTableRowData>();
            for (int i = 0; i < RowDatas.Count; i++)
            {
                DataTableRowData data = new DataTableRowData();

                for (int j = 0; j < RowDatas[i].Data.Count; j++)
                {
                    data.Data.Add(RowDatas[i].Data[j]);
                }

                RowDatasTemp.Add(data);
            }

            if (m_encoding == null)
            {
                m_encoding = Encoding.GetEncoding(m_codePage);
            }

            DataTableUtility.SaveDataTableFile(FilePath, RowDatas, m_encoding, m_loadType);

            bool result = EditorUtility.DisplayDialog("提示", "配置已经保存成功, 是否立即生成FlatBuffer数据?", "是", "否");
            if (result)
                TableTools.GenerateFlatbufferConfigData();
        }

        private bool IsCombinationKey(EventModifiers preKey, KeyCode postKey, EventType postKeyEvent)
        {
            if (preKey != EventModifiers.None)
            {
                bool eventDown = (Event.current.modifiers & preKey) != 0;
                if (eventDown && Event.current.rawType == postKeyEvent && Event.current.keyCode == postKey)
                {
                    Event.current.Use();
                    return true;
                }
            }
            else
            {
                if (Event.current.rawType == postKeyEvent && Event.current.keyCode == postKey)
                {
                    Event.current.Use();
                    return true;
                }
            }

            return false;
        }

        private void OnDisable()
        {
            if (!CheckDirty())
                return;

            bool result = EditorUtility.DisplayDialog("提示", "你已经对表格进行了修改，是否需要保存？", "是", "否");
            if (result)
            {
                SaveDataTable();
            }
            Focus();
        }

        /// <summary>
        /// 检查列数一致性
        /// </summary>
        private void CheckColumnCount()
        {
            if (RowDatas == null || RowDatas.Count == 0)
                return;

            int count = RowDatas[0].Data.Count;

            for (int i = 0; i < RowDatas.Count; i++)
            {
                int need = count - RowDatas[i].Data.Count;

                if (need > 0)
                    for (int j = 0; j < need; j++)
                        RowDatas[i].Data.Add("");
                else if (need < 0)
                    for (int j = 0; j < Mathf.Abs(need); j++)
                        RowDatas[i].Data.RemoveAt(RowDatas[i].Data.Count - 1);
            }
        }

        /// <summary>
        /// 检查表格是否进行更改
        /// </summary>
        /// <returns></returns>
        private bool CheckDirty()
        {
            if (RowDatasTemp == null || RowDatas == null)
            {
                return false;
            }

            if (RowDatasTemp.Count != RowDatas.Count)
                return true;

            for (int i = 0; i < RowDatas.Count; i++)
            {
                if (RowDatasTemp[i].Data.Count != RowDatas[i].Data.Count)
                    return true;

                for (int j = 0; j < RowDatas[i].Data.Count; j++)
                {
                    if (RowDatas[i].Data[j] != RowDatasTemp[i].Data[j])
                        return true;
                }
            }

            return false;
        }
    }
}