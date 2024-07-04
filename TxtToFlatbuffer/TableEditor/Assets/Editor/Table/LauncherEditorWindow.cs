using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using static DataTableEditor.Utility;

namespace DataTableEditor
{
    public class LauncherEditorWindow : EditorWindow
    {
        public static float ButtonHeight = 50;

        private string configPath;

        [MenuItem("Tools/FlatBuffer/程序配置编辑器", false, 27)]
        public static void OpenWindow()
        {
            LauncherEditorWindow window = GetWindowWithRect<LauncherEditorWindow>(new Rect(0, 0, 400, 220), true, "表格编辑器");
            window.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("新建", GUILayout.Height(ButtonHeight)))
                ButtonNew();

            if (GUILayout.Button("整表模式加载", GUILayout.Height(ButtonHeight)))
                ButtonLoad();

            if (GUILayout.Button("简易模式加载\n(加载末尾三行)", GUILayout.Height(ButtonHeight)))
                ButtonSingleLoad();

            if (GUILayout.Button("生成Flatbuffer配表数据和代码", GUILayout.Height(ButtonHeight)))
                GenerateFlatbufferData();
        }

        private void ButtonNew()
        {
            var m_DataTableEditingWindow = new DataTableEditingWindowInstance();
            m_DataTableEditingWindow.SetData(DataTableUtility.NewDataTableFile(Encoding.UTF8), Encoding.UTF8);
        }

        private void ButtonLoad()
        {
            var m_DataTableEditingWindow = new DataTableEditingWindowInstance();
            string filePath = EditorUtility.OpenFilePanel("加载数据表格文件", this.GetConfigPath(), "txt");
            if (!string.IsNullOrEmpty(filePath))
            {
                m_DataTableEditingWindow.SetData(filePath, Encoding.UTF8);
            }
        }

        private void ButtonSingleLoad()
        {
            var m_DataTableEditingWindow = new DataTableEditingWindowInstance();
            string filePath = EditorUtility.OpenFilePanel("加载数据表格文件", this.GetConfigPath(), "txt");
            if (!string.IsNullOrEmpty(filePath))
            {
                m_DataTableEditingWindow.SetData(filePath, Encoding.UTF8, E_LoadType.End);
            }
        }

        /// <summary>
        /// 加载选中的配置
        /// </summary>
        /// <param name="prefabFiles"></param>
        /// <param name="loadType"></param>
        public static void LoadSelectedConfig(List<string> prefabFiles, E_LoadType loadType)
        {
            if (null != prefabFiles && prefabFiles.Count > 0)
            {
                string configFile = string.Empty;
                switch(loadType)
                {
                    case E_LoadType.SelectedUIs:
                        {
                            configFile = TableTools.GetUIFile();

                            break;
                        }
                    case E_LoadType.SelectedEffects:
                        {
                            configFile = TableTools.GetEffectFile();

                            break;
                        }
                    default:
                        break;
                }

                if (string.IsNullOrEmpty(configFile))
                    return;

                var m_DataTableEditingWindow = new DataTableEditingWindowInstance();
                m_DataTableEditingWindow.SetData(configFile, prefabFiles, Encoding.UTF8, loadType);
            }
        }

        private void GenerateFlatbufferData()
        {
            TableTools.GenerateFlatbufferConfigData();
        }

        private string GetConfigPath()
        {
            if(string.IsNullOrEmpty(configPath))
            {
                string assetPath = Application.streamingAssetsPath;
                int index = assetPath.IndexOf("project");
                string rootPath = assetPath.Substring(0, index);
                configPath = Path.Combine(rootPath, "tools", "MakeConfig", "config");
            }

            return configPath;
        }
    }
}