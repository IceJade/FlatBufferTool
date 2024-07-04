using UnityEngine;
using UnityEditor;
using System.IO;
using System.Diagnostics;
using System;
using System.Text;
using DataTableEditor;
using System.Collections.Generic;
using LF;

public class TableTools
{
    static Process proc = new Process();

    #region 生成Flatbuffer表配置数据_策划

    [MenuItem("Tools/FlatBuffer/打开Xml配置文件目录_策划", false, 1)]
    private static void OpenXmlPath()
    {
        string rootPath = GetDataTablePath();
        if (string.IsNullOrEmpty(rootPath))
            return;

        InternalOpenFolder(Path.Combine(rootPath, "XML"));
    }

    [MenuItem("Tools/FlatBuffer/生成Flatbuffer表配置数据(只生成数据不生成代码)_策划", false, 2)]
    static void GenerateFlatbufferTableData()
    {
        string tableToolPath = GetTableToolPath();
        if (string.IsNullOrEmpty(tableToolPath))
            return;

#if UNITY_EDITOR_WIN
        proc.StartInfo.WorkingDirectory = tableToolPath;
        proc.StartInfo.FileName = "gen_flatbuffer_data_win.bat";
        proc.Start();
        proc.WaitForExit();
#elif UNITY_EDITOR_OSX
        string shell = Path.Combine(tableToolPath,"gen_flatbuffer_data_mac.sh");
        CommandTool.ProcessCommand("sh", $"{shell}");
#else
        UnityEngine.Debug.LogError("This command only supports Windows and Mac system  currently");
#endif
    }

    [MenuItem("Tools/FlatBuffer/生成Flatbuffer表配置数据和代码(数据和代码都生成)_策划", false, 3)]
    static void GenerateFlatbufferTableDataAndCode()
    {
        string tableToolPath = GetTableToolPath();
        if (string.IsNullOrEmpty(tableToolPath))
            return;

#if UNITY_EDITOR_WIN
        proc.StartInfo.WorkingDirectory = tableToolPath;
        proc.StartInfo.FileName = "生成表格和代码.bat";
        proc.Start();
        proc.WaitForExit();
#elif UNITY_EDITOR_OSX
        string shell = Path.Combine(tableToolPath,"gen_flatbuffer_mac.sh");
        CommandTool.ProcessCommand("sh", $"{shell}");
#else
        UnityEngine.Debug.LogError("This command only supports Windows and Mac system  currently");
#endif
    }

    [MenuItem("Tools/FlatBuffer/打开数据类型配置目录_策划", false, 4)]
    private static void OpenDataDesignPath()
    {
        string tableToolPath = GetTableToolPath();
        if (string.IsNullOrEmpty(tableToolPath))
            return;

        string bytesPath = Path.Combine(tableToolPath, "gen", "design");

        InternalOpenFolder(bytesPath);
    }

    [MenuItem("Tools/FlatBuffer/打开Flatbuffer转换成Json的目录_策划", false, 5)]
    private static void OpenConvertPath()
    {
        string tableToolPath = GetTableToolPath();
        if (string.IsNullOrEmpty(tableToolPath))
            return;

        string bytesPath = Path.Combine(tableToolPath, "gen", "bytes");

        InternalOpenFolder(bytesPath);
    }

    [MenuItem("Tools/FlatBuffer/Flatbuffer转换成Json数据_策划", false, 6)]
    static void ConvertFlatbufferToJson()
    {
        string tableToolPath = GetTableToolPath();
        if (string.IsNullOrEmpty(tableToolPath))
            return;

        proc.StartInfo.WorkingDirectory = tableToolPath;

#if UNITY_EDITOR_WIN
        proc.StartInfo.FileName = "二进制数据导出成Json数据.bat";
        proc.Start();
        proc.WaitForExit();
#elif UNITY_EDITOR_OSX
        proc.StartInfo.FileName = "二进制数据导出成Json数据.sh";
        proc.Start();
        proc.WaitForExit();
#else
        UnityEngine.Debug.LogError("This command only supports Windows and Mac system  currently");
#endif

        // 转换完成后自动打开目录
        string outPath = Path.Combine(tableToolPath, "gen", "output");
        InternalOpenFolder(outPath);
    }

    [MenuItem("Tools/FlatBuffer/表格配置说明文档", false, 7)]
    static void OpenTableConfigDocument()
    {
        string assetPath = Application.streamingAssetsPath;
        int index = assetPath.IndexOf("project");
        string rootPath = assetPath.Substring(0, index);
        string documentFile = Path.Combine(rootPath, "documents", "表格模块配置说明.pdf");

        InternalOpenFolder(documentFile);
    }

    [MenuItem("Tools/FlatBuffer/策划配置技术说明文档", false, 8)]
    static void OpenTechnicalDocument()
    {
        string assetPath = Application.streamingAssetsPath;
        int index = assetPath.IndexOf("project");
        string rootPath = assetPath.Substring(0, index);
        string documentFile = Path.Combine(rootPath, "documents", "表格模块使用说明.pdf");

        InternalOpenFolder(documentFile);
    }

    #endregion

    #region 生成Flatbuffer表配置数据_程序

    [MenuItem("Tools/FlatBuffer/打开配置文件目录_程序", false, 21)]
    private static void OpenExcelPath()
    {
        string assetPath = Application.streamingAssetsPath;
        int index = assetPath.IndexOf("project");
        string rootPath = assetPath.Substring(0, index);
        string configPath = Path.Combine(rootPath, "tools", "MakeConfig", "config");

        InternalOpenFolder(configPath);
    }

    [MenuItem("Tools/FlatBuffer/生成Flatbuffer表配置数据和代码_程序", false, 22)]
    public static void GenerateFlatbufferConfigData()
    {
        string assetPath = Application.streamingAssetsPath;
        int index = assetPath.IndexOf("project");
        string rootPath = assetPath.Substring(0, index);
        string tableToolPath = Path.Combine(rootPath, "tools", "MakeConfig");

        // 检查文件是否可打开
        //if(!TryOpenFiles(Path.Combine(tableToolPath, "excel"), "*.xlsm"))
        //    return;

#if UNITY_EDITOR_WIN
        proc.StartInfo.WorkingDirectory = tableToolPath;
        proc.StartInfo.FileName = "生成配置和代码.bat";
        proc.Start();
        proc.WaitForExit();
#elif UNITY_EDITOR_OSX
        string shell = Path.Combine(tableToolPath,"gen_flatbuffer_mac.sh");
        CommandTool.ProcessCommand("sh", $"{shell}");
#else
        UnityEngine.Debug.LogError("This command only supports Windows and Mac system  currently");
#endif
    }

    [MenuItem("Tools/FlatBuffer/打开Flatbuffer转换成Json的目录_程序", false, 24)]
    private static void OpenConvertPathForCoder()
    {
        string assetPath = Application.streamingAssetsPath;
        int index = assetPath.IndexOf("project");
        string rootPath = assetPath.Substring(0, index);
        string bytesPath = Path.Combine(rootPath, "tools", "MakeConfig", "gen", "bytes");

        InternalOpenFolder(bytesPath);
    }

    [MenuItem("Tools/FlatBuffer/Flatbuffer转换成Json数据_程序", false, 25)]
    static void ConvertFlatbufferToJsonForCoder()
    {
        string assetPath = Application.streamingAssetsPath;
        int index = assetPath.IndexOf("project");
        string rootPath = assetPath.Substring(0, index);
        string tableToolPath = Path.Combine(rootPath, "tools", "MakeConfig");

        proc.StartInfo.WorkingDirectory = tableToolPath;

#if UNITY_EDITOR_WIN
        proc.StartInfo.FileName = "二进制数据导出成Json数据.bat";
        proc.Start();
        proc.WaitForExit();
#elif UNITY_EDITOR_OSX
        proc.StartInfo.FileName = "二进制数据导出成Json数据.sh";
        proc.Start();
        proc.WaitForExit();
#else
        UnityEngine.Debug.LogError("This command only supports Windows and Mac system  currently");
#endif

        // 转换完成后自动打开目录
        string outPath = Path.Combine(rootPath, "tools", "MakeConfig", "gen", "output");
        InternalOpenFolder(outPath);
    }

    [MenuItem("Tools/FlatBuffer/本地配置技术说明文档", false, 26)]
    static void OpenTechnicalDocumentForCoder()
    {
        string assetPath = Application.streamingAssetsPath;
        int index = assetPath.IndexOf("project");
        string rootPath = assetPath.Substring(0, index);
        string documentFile = Path.Combine(rootPath, "documents", "本地表配置使用说明_V1.2.pdf");

        InternalOpenFolder(documentFile);
    }

    /// <summary>
    /// 打开文件夹
    /// </summary>
    /// <param name="folder"></param>
    static void InternalOpenFolder(string folder)
    {
        folder = string.Format("\"{0}\"", folder);
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsEditor:
                Process.Start("Explorer.exe", folder.Replace('/', '\\'));
                break;
            case RuntimePlatform.OSXEditor:
                Process.Start("open", folder);
                break;
            default:
                throw new Exception(string.Format("Not support open folder on '{0}' platform.", Application.platform.ToString()));
        }
    }

    static bool TryOpenFiles(string path, string filter)
    {
        // 遍历文件;
        DirectoryInfo TheFolder = new DirectoryInfo(path);
        foreach (FileInfo fileInfo in TheFolder.GetFiles(filter))//遍历文件夹下所有文件
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read);
            }
            catch(Exception e)
            {
                string message = string.Format("请关闭文件后重试!!!\n{0}", fileInfo.FullName);
                EditorUtility.DisplayDialog("友情提示", message, "OK");
                //UnityEngine.Debug.LogErrorFormat(">>>>>>请关闭文件后再重试!!!{0}", fileInfo.FullName);
                return false;
            }
            finally
            {
                if (null != fs)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
        }

        return true;
    }

    /// <summary>
    /// 执行生成配置的指令
    /// </summary>
    private static void ExecuteMakeConfigCommand()
    {
        string assetPath = Application.streamingAssetsPath;
        int index = assetPath.IndexOf("project");
        // 根目录
        string rootPath = assetPath.Substring(0, index);

        // 工具目录
        string toolsPath = Path.Combine(rootPath, "tools", "MakeConfig");

        // 工程代码
        string shelterPath = Path.Combine(rootPath, "project", "Assets", "Shelter");

        // 数据目录
        string DestTableFolder = Path.Combine(shelterPath, "Config");
        string DestTableIdsFolder = Path.Combine(shelterPath, "Config", "ids");
        // 代码目录
        string DestScriptFolder = Path.Combine(shelterPath, "Scripts", "Config");
        string DestFlatbufferFolder = Path.Combine(shelterPath, "Scripts", "Config", "flatbuffer");
        string DestGenCodeFolder = Path.Combine(shelterPath, "Scripts", "Config", "genarate");

        // 源数据目录
        string SrcTableFolder = Path.Combine(toolsPath, "excel");

        // 临时目录
        string TempFBSFolder = Path.Combine(toolsPath, "gen", "fbs");
        string TempBinTableFolder = Path.Combine(toolsPath, "gen", "data", "binary");
        string TempJsonTableFolder = Path.Combine(toolsPath, "gen", "data", "json");
        string TempIdsTableFolder = Path.Combine(toolsPath, "gen", "data", "ids");
        string TempCSharpFolder = Path.Combine(toolsPath, "gen", "code", "csharp");
        string TempLuaFolder = Path.Combine(toolsPath, "gen", "code", "lua");

        // 清理临时目录文件
        DeletePathFiles(TempFBSFolder);
        DeletePathFiles(TempBinTableFolder);
        DeletePathFiles(TempJsonTableFolder);
        DeletePathFiles(TempIdsTableFolder);
        DeletePathFiles(TempCSharpFolder);
        DeletePathFiles(TempLuaFolder);

        // 创建目录
        CreatePath(TempFBSFolder);
        CreatePath(TempBinTableFolder);
        CreatePath(TempJsonTableFolder);
        CreatePath(TempIdsTableFolder);
        CreatePath(TempCSharpFolder);
        CreatePath(TempLuaFolder);

        string toolFile = Path.Combine(toolsPath, "tool", "mac", "MakeTable.dll");
        string arguments = string.Format("-f {0}/tool/mac/flatc {1} {0}/gen", toolsPath, SrcTableFolder);

#if UNITY_EDITOR_WIN
        toolFile = Path.Combine(toolsPath, "tool", "win", "MakeTable");
        arguments = string.Format("-f {0}/tool/win/flatc {1} {0}/gen", toolsPath, SrcTableFolder);
#elif UNITY_EDITOR_OSX

#else
        UnityEngine.Debug.LogError("This command only supports Windows and Mac system  currently");
        return;
#endif

        Process process = System.Diagnostics.Process.Start(toolFile, arguments);
        process.WaitForExit();

        CopyPathFiles(TempBinTableFolder, DestTableFolder);
        CopyPathFiles(TempIdsTableFolder, DestTableIdsFolder);
        CopyPathFiles(TempCSharpFolder, DestScriptFolder);

        EditorUtility.DisplayDialog("提示", "处理完毕!!!", "OK");
    }

    static void DeletePathFiles(string path)
    {
        if (string.IsNullOrEmpty(path))
            return;

        string[] files = Directory.GetFiles(path);
        if (null == files || files.Length <= 0)
            return;

        foreach (var file in files)
            File.Delete(file);
    }

    static void CreatePath(string path)
    {
        if (string.IsNullOrEmpty(path))
            return;

        if (Directory.Exists(path))
            return;

        Directory.CreateDirectory(path);
    }

    /// <summary>
    /// 拷贝路径下的所有文件
    /// </summary>
    /// <param name="srcPath"></param>
    /// <param name="desPath"></param>
    static void CopyPathFiles(string srcPath, string desPath)
    {
        if (string.IsNullOrEmpty(srcPath))
            return;

        if (!Directory.Exists(srcPath))
            return;

        if (!Directory.Exists(desPath))
            Directory.CreateDirectory(desPath);

        string desFile;
        DirectoryInfo directoryInfo = new DirectoryInfo(srcPath);
        //遍历文件夹下所有文件
        foreach (FileInfo fileInfo in directoryInfo.GetFiles())
        {
            desFile = Path.Combine(desPath, fileInfo.Name);
            File.Copy(fileInfo.FullName, desFile, true);
        }

        DirectoryInfo[] directories = directoryInfo.GetDirectories();
        if (null == directories || directories.Length <= 0)
            return;

        foreach(var path in directories)
            CopyPathFiles(path.FullName, Path.Combine(desPath, path.Name));
    }

    #endregion

    #region 批量设置本地配置表AssetBundle

    public static string g_BundleName = "assets/shelter/config";
    public static string g_BunldeVariantNamne = "bundle";

    [MenuItem("Tools/FlatBuffer/设置Flatbuffer表配置的Bundle_程序", false, 23)]
    static void SetFlatbufferConfigBundle()
    {
        string assetPath = Application.streamingAssetsPath;
        int index = assetPath.IndexOf("StreamingAssets");
        string rootPath = assetPath.Substring(0, index);

        SetBundle(Path.Combine(rootPath, "Shelter", "Config"));
        SetBundle(Path.Combine(rootPath, "Shelter", "Config", "ids"));

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    static void SetBundle(string path)
    {
        DirectoryInfo directory = new DirectoryInfo(path);
        foreach (FileInfo fileInfo in directory.GetFiles("*.bytes"))
            SetBundleName(fileInfo.FullName);
    }

    /// <summary>
    /// //设置assetbundle名字
    /// </summary>
    /// <param name="path"></param>
    static void SetBundleName(string file)
    {
        int index = file.IndexOf("Assets");
        var importer = AssetImporter.GetAtPath(file.Substring(index));
        if (null == importer)
            return;

        if (importer.assetBundleName != g_BundleName)
            importer.assetBundleName = g_BundleName;

        if (importer.assetBundleVariant != g_BunldeVariantNamne)
            importer.assetBundleVariant = g_BunldeVariantNamne;
    }

    #endregion

    #region 生成资源配置文件

    [MenuItem("Tools/FlatBuffer/生成纹理资源配置", false, 41)]
    static void GenerateAtlasAndTextureConfigData()
    {
        string tableToolPath = GetTableToolPath();
        if (string.IsNullOrEmpty(tableToolPath))
            return;

#if UNITY_EDITOR_WIN
        proc.StartInfo.WorkingDirectory = tableToolPath;
        proc.StartInfo.FileName = "gen_flatbuffer_spriteatlas_win.bat";
        proc.Start();
        proc.WaitForExit();
#elif UNITY_EDITOR_OSX
        string shell = Path.Combine(tableToolPath,"gen_flatbuffer_spriteatlas_mac.sh");
        CommandTool.ProcessCommand("sh", $"{shell}");
#else
        UnityEngine.Debug.LogError("This command only supports Windows and Mac system  currently");
#endif
    }

    #endregion

    #region 配置同步 git => svn

    private static string key_svn_path = "svn_table_path";

    [MenuItem("Tools/配置本地同步/同步配置至SVN", false, 41)]
    static void SyncTableDesignToSVN()
    {
        string svn_table_path = string.Empty;

        if(!PlayerPrefs.HasKey(key_svn_path))
        {
            var path = EditorUtility.OpenFolderPanel("选择SVN同步目录", "", "");
            if (string.IsNullOrEmpty(path))
                return;

            if(!Directory.Exists(path))
            {
                EditorUtility.DisplayDialog("提示", string.Format("路径不存在:{0}", path), "OK");
                return;
            }

            PlayerPrefs.SetString(key_svn_path, path);
            PlayerPrefs.Save();

            svn_table_path = path;
        }
        else
        {
            var path = PlayerPrefs.GetString(key_svn_path);

            if (!Directory.Exists(path))
            {
                EditorUtility.DisplayDialog("提示", string.Format("路径不存在:{0}", path), "OK");
                return;
            }

            svn_table_path = path;
        }

        var versionFile = Path.Combine(Application.dataPath, "DataTable", "VERSION.txt");
        if(!File.Exists(versionFile))
        {
            EditorUtility.DisplayDialog("提示", "版本文件不存在:project/Assets/DataTable/VERSION.txt, 请检查!", "OK");
            return;
        }

        // 获得版本号
        var version = GetVersionNo(versionFile);
        if(string.IsNullOrEmpty(version))
        {
            EditorUtility.DisplayDialog("提示", "获取版本号错误,请检查文件:project/Assets/DataTable/VERSION.txt", "OK");
            return;
        }

        var message = string.Format("是否同步{0}的配表工具?", version);
        if (EditorUtility.DisplayDialog("同步确认", message, "是", "否"))
        {
            var git_design_path = Path.Combine(Application.dataPath, "DataTable/.Tool/MakeTable/gen/design");
            if(!Directory.Exists(git_design_path))
            {
                EditorUtility.DisplayDialog("提示", "Git工程里配置文件的数据类型文件路径不存在,请检查!", "OK");
                return;
            }

            var svn_design_path = Path.Combine(svn_table_path, version, "MakeTable/gen/design");
            if(Directory.Exists(svn_design_path))
            {
                CopyFiles(git_design_path, svn_design_path);

                if(EditorUtility.DisplayDialog("提示", "同步完成!\n是否打开SVN目标文件夹?", "是", "否"))
                {
                    InternalOpenFolder(svn_design_path);
                }
            }
            else
            {
                var git_table_root = Path.Combine(Application.dataPath, "DataTable/.Tool/MakeTable");
                if (!Directory.Exists(git_table_root))
                {
                    EditorUtility.DisplayDialog("提示", "Git工程里配置文件的数据类型文件路径不存在,请检查!", "OK");
                    return;
                }

                var svn_table_root = Path.Combine(svn_table_path, version, "MakeTable");

                CopyFiles(git_table_root, svn_table_root);

                if (EditorUtility.DisplayDialog("提示", "同步完成!\n是否打开SVN目标文件夹?", "是", "否"))
                {
                    InternalOpenFolder(Path.Combine(svn_table_path, version));
                }
            }
        }
    }

    [MenuItem("Tools/配置本地同步/打开SVN配置路径", false, 41)]
    static void OpenSVNTableDesignPath()
    {
        string svn_table_path = string.Empty;

        if (!PlayerPrefs.HasKey(key_svn_path))
        {
            EditorUtility.DisplayDialog("提示", "没有设置SVN配置路径!", "OK");
            return;
        }

        var path = PlayerPrefs.GetString(key_svn_path);

        if (!Directory.Exists(path))
        {
            EditorUtility.DisplayDialog("提示", string.Format("路径不存在:{0}", path), "OK");
            return;
        }

        InternalOpenFolder(path);
    }

    [MenuItem("Tools/配置本地同步/清除SVN配置路径", false, 41)]
    static void CleanSVNTableDesignPath()
    {
        PlayerPrefs.DeleteKey(key_svn_path);
        PlayerPrefs.Save();

        EditorUtility.DisplayDialog("提示", "清除成功!", "OK");
    }

    private static string version_start = "app_";
    private static string GetVersionNo(string versionFile)
    {
        string version = string.Empty;

        using (FileStream fileStream = new FileStream(versionFile, FileMode.Open))
        {
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string content = reader.ReadToEnd();
                if (!content.StartsWith(version_start))
                    return version;

                int end_index = content.IndexOf("=");
                int start_index = version_start.Length;
                version = content.Substring(start_index, end_index - start_index);

                reader.Close();
                reader.Dispose();
            }

            fileStream.Close();
            fileStream.Dispose();
        }

        return version;
    }

    private static void CopyFiles(string srcPath, string desPath)
    {
        if (!Directory.Exists(desPath))
            Directory.CreateDirectory(desPath);

        DirectoryInfo direction = new DirectoryInfo(srcPath);
        var fileInfo = direction.GetFiles();
        if (null == fileInfo)
            return;

        for(int i = 0; i < fileInfo.Length; i++)
        {
            var fileName = Path.GetFileName(fileInfo[i].FullName);
            File.Copy(fileInfo[i].FullName, Path.Combine(desPath, fileName), true);
        }

        DirectoryInfo[] sub_directs = direction.GetDirectories();
        if (null == sub_directs || sub_directs.Length <= 0)
            return;

        for (int i = 0; i < sub_directs.Length; i++)
        {
            var fileName = Path.GetFileName(sub_directs[i].FullName);
            if (fileName.Contains("project") || fileName.Contains("log"))
                continue;

            CopyFiles(sub_directs[i].FullName, Path.Combine(desPath, fileName));
        }
    }

    #endregion

    #region 右键菜单配表操作指令

    [MenuItem("Assets/配表工具/XML生成Flatbuffer数据(单选)", false, 1)]
    private static void GenerateFlatbufferDataForSelectTable()
    {
        var guids = Selection.assetGUIDs;
        if (guids == null || guids.Length != 1)
        {
            EditorUtility.DisplayDialog("提示", "请选中一个Assets/DataTable/XML目录下的xml文件!", "OK");
            return;
        }

        var xmlFile = AssetDatabase.GUIDToAssetPath(guids[0]);
        if (string.IsNullOrEmpty(xmlFile) || !xmlFile.Contains(".xml"))
        {
            EditorUtility.DisplayDialog("提示", "请选中一个Assets/DataTable/XML目录下的xml文件来生成数据!", "OK");
            return;
        }

        string tableToolPath = GetTableToolPath();
        if (string.IsNullOrEmpty(tableToolPath))
            return;

        // 表工具
        string tableToolExe = Path.Combine(tableToolPath, "tool", "win", "MakeTable.exe");
        // flatc工具
        string flatcExeFile = Path.Combine(tableToolPath, "tool", "win", "flatc.exe");
        // 源文件全路径
        string xmlFullPath = Application.dataPath + xmlFile.Replace("Assets", "");
        // 生成的目录
        string genPath = Path.Combine(tableToolPath, "gen");

        if (!File.Exists(tableToolExe))
        {
            string msg = string.Format("文件不存在!{0}", tableToolExe);
            EditorUtility.DisplayDialog("提示", msg, "OK");
            return;
        }

        if (!File.Exists(flatcExeFile))
        {
            string msg = string.Format("文件不存在!{0}", flatcExeFile);
            EditorUtility.DisplayDialog("提示", msg, "OK");
            return;
        }

        if (!File.Exists(xmlFullPath))
        {
            string msg = string.Format("文件不存在!{0}", xmlFullPath);
            EditorUtility.DisplayDialog("提示", msg, "OK");
            return;
        }

        if (!Directory.Exists(genPath))
        {
            string msg = string.Format("目录不存在!{0}", genPath);
            EditorUtility.DisplayDialog("提示", msg, "OK");
            return;
        }

        // 参数
        string args = string.Format("{0} {1} {2} {3}", "-sd", flatcExeFile, xmlFullPath, genPath);

        proc.StartInfo.WorkingDirectory = tableToolPath;
        proc.StartInfo.FileName = tableToolExe;
        proc.StartInfo.Arguments = args;
        proc.Start();
        proc.WaitForExit();
    }

    #region 将UI添加到配表并生成Flatbuffer数据

    [MenuItem("Assets/配表工具/将prefab添加到UI配表中并生成Flatbuffer数据(可多选)", false, 21)]
    private static void MakeUIToFlatbufferData()
    {
        var guids = Selection.assetGUIDs;
        if (guids == null)
        {
            EditorUtility.DisplayDialog("提示", "请选中ui prefab文件!", "OK");
            return;
        }

        // 清理UI配表
        var table = TableManager.Instance.GetTable<UiTable>();
        if (null != table)
            table.ResetTable();

        bool change = false;

        for (int i = 0; i < guids.Length; i++)
        {
            var assetFile = AssetDatabase.GUIDToAssetPath(guids[i]);
            if (string.IsNullOrEmpty(assetFile) || !assetFile.EndsWith(".prefab") || !assetFile.Contains("Prefabs"))
            {
                EditorUtility.DisplayDialog("提示", "请选中一个ui prefab文件来生成数据!", "OK");
                return;
            }

            var fileName = Path.GetFileNameWithoutExtension(assetFile);
            var result = AddUIToTable(fileName, assetFile);

            if (result && !change)
                change = true;
        }

        if(change)
        {
            // 刷新本地资源
            AssetDatabase.Refresh();

            // 生成FlatBuffer数据
            TableTools.GenerateFlatbufferConfigData();
            
            EditorUtility.DisplayDialog("提示", "处理完毕!", "确定");
        }
    }

    [MenuItem("Assets/配表工具/编辑选中的prefab在UI表中的配置(可多选)", false, 22)]
    private static void EditUIConfig()
    {
        var guids = Selection.assetGUIDs;
        if (guids == null)
        {
            EditorUtility.DisplayDialog("提示", "请选中ui prefab文件!", "OK");
            return;
        }

        var assetFile = AssetDatabase.GUIDToAssetPath(guids[0]);
        if (string.IsNullOrEmpty(assetFile) || !assetFile.EndsWith(".prefab") || !assetFile.Contains("Prefabs"))
        {
            EditorUtility.DisplayDialog("提示", "请选中ui prefab文件来编辑数据!", "OK");
            return;
        }

        List<string> assetFiles = new List<string>();
        for (int i = 0; i < guids.Length; i++)
            assetFiles.Add(AssetDatabase.GUIDToAssetPath(guids[i]));

        LauncherEditorWindow.LoadSelectedConfig(assetFiles, E_LoadType.SelectedUIs);
    }

    [MenuItem("Assets/配表工具/检查UI配表中是否已配置此prefab(单选)", false, 23)]
    private static void IsExistThisUI()
    {
        var guids = Selection.assetGUIDs;
        if (guids == null || guids.Length != 1)
        {
            EditorUtility.DisplayDialog("提示", "请选中一个ui prefab文件!", "OK");
            return;
        }

        var assetFile = AssetDatabase.GUIDToAssetPath(guids[0]);
        if (string.IsNullOrEmpty(assetFile) || !assetFile.EndsWith(".prefab") || !assetFile.Contains("Prefabs"))
        {
            EditorUtility.DisplayDialog("提示", "请选中一个ui prefab文件来检查!", "OK");
            return;
        }

        var table = TableManager.Instance.GetTable<LF.UiTable>();
        if (null != table)
            table.ResetTable();

        var fileName = Path.GetFileNameWithoutExtension(assetFile);
        if(table.HasDataRow(fileName))
        {
            EditorUtility.DisplayDialog("提示", "文件已配置!", "OK");
            return;
        }

        var datas = table.GetAllData();
        if(null != datas && datas.Count > 0)
        {
            var target = assetFile.ToLowerInvariant();

            foreach (var per in datas)
            {
                var path = per.Value.AssetName.ToLowerInvariant();
                if (path.Contains(target) || target.Contains(path))
                {
                    EditorUtility.DisplayDialog("提示", "文件已配置!", "OK");
                    return;
                }
            }
        }

        EditorUtility.DisplayDialog("提示", "文件没有配置!", "OK");
    }

    /// <summary>
    /// 添加UI到配表中
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="prefabFile"></param>
    private static bool AddUIToTable(string fileName, string prefabFile)
    {
        // 先查表,查到后返回
        var datarow = TableManager.Instance.GetDataRow<LF.UiDataRow>(fileName);
        if (null != datarow)
        {
            EditorUtility.DisplayDialog("提示", string.Format("UI配表已经存在{0}", fileName), "确定");
            return false;
        }

        bool isWrapEnd = false;
        using (StreamReader sr = new StreamReader(GetUIFile()))
        {
            var content = sr.ReadToEnd();
            if (content.EndsWith("\n") || content.EndsWith("\r\n"))
                isWrapEnd = true;
        }

        // 获得数据行
        var dataLine = GetUIDataLine(fileName, prefabFile);

        // 没查到,那么添加数据
        using (StreamWriter sw = new StreamWriter(GetUIFile(), true, Encoding.UTF8))
        {
            if(!isWrapEnd)
                sw.WriteLine();

            sw.Write(dataLine);
            sw.Flush();
        }

        return true;
    }

    private static string uiFile = "";
    public static string GetUIFile()
    {
        if (!string.IsNullOrEmpty(uiFile))
            return uiFile;

        string assetPath = Application.streamingAssetsPath;
        int index = assetPath.IndexOf("project");
        string rootPath = assetPath.Substring(0, index);
        uiFile = Path.Combine(rootPath, "tools", "MakeConfig", "config", "ui.txt");

        return uiFile;
    }

    public static string GetUIDataLine(string fileName, string filePath)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("");
        stringBuilder.Append("\t");
        stringBuilder.Append(fileName);
        stringBuilder.Append("\t");
        stringBuilder.Append(filePath);
        stringBuilder.Append("\t");
        stringBuilder.Append("Default");
        stringBuilder.Append("\t");
        stringBuilder.Append("99");
        stringBuilder.Append("\t");
        stringBuilder.Append("FALSE");
        stringBuilder.Append("\t");
        stringBuilder.Append("FALSE");
        stringBuilder.Append("\t");
        stringBuilder.Append("FALSE");
        stringBuilder.Append("\t");
        stringBuilder.Append("FALSE");
        stringBuilder.Append("\t");
        stringBuilder.Append("FALSE");
        stringBuilder.Append("\t");
        stringBuilder.Append("FALSE");

        return stringBuilder.ToString();
    }

    #endregion

    #region 将Effect添加到配表并生成Flatbuffer数据

    [MenuItem("Assets/配表工具/将prefab添加到Effect配表中并生成Flatbuffer数据(可多选)", false, 41)]
    private static void MakeEffectToFlatbufferData()
    {
        var guids = Selection.assetGUIDs;
        if (guids == null)
        {
            EditorUtility.DisplayDialog("提示", "请选中effect prefab文件!", "OK");
            return;
        }

        // 清理Effect配表
        var table = TableManager.Instance.GetTable<EffectTable>();
        if (null != table)
            table.ResetTable();

        bool change = false;

        for (int i = 0; i < guids.Length; i++)
        {
            var assetFile = AssetDatabase.GUIDToAssetPath(guids[i]);
            if (string.IsNullOrEmpty(assetFile) || !assetFile.EndsWith(".prefab") || !assetFile.Contains("Effects"))
            {
                EditorUtility.DisplayDialog("提示", "请选中effect prefab文件来生成数据!", "OK");
                return;
            }

            var fileName = Path.GetFileNameWithoutExtension(assetFile);
            var result = AddEffectToTable(fileName, assetFile, true);

            if (result && !change)
                change = true;
        }

        if(change)
        {
            // 刷新本地资源
            AssetDatabase.Refresh();

            // 生成FlatBuffer数据
            GenerateFlatbufferConfigData();

            EditorUtility.DisplayDialog("提示", "处理完毕!", "确定");
        }
    }

    [MenuItem("Assets/配表工具/编辑选中的prefab在Effect表中的配置(可多选)", false, 42)]
    private static void EditEffectConfig()
    {
        var guids = Selection.assetGUIDs;
        if (guids == null)
        {
            EditorUtility.DisplayDialog("提示", "请选中effect prefab文件!", "OK");
            return;
        }

        var assetFile = AssetDatabase.GUIDToAssetPath(guids[0]);
        if (string.IsNullOrEmpty(assetFile) || !assetFile.EndsWith(".prefab") || !assetFile.Contains("Effects"))
        {
            EditorUtility.DisplayDialog("提示", "请选中effect prefab文件来编辑数据!", "OK");
            return;
        }

        List<string> assetFiles = new List<string>();
        for (int i = 0; i < guids.Length; i++)
            assetFiles.Add(AssetDatabase.GUIDToAssetPath(guids[i]));

        LauncherEditorWindow.LoadSelectedConfig(assetFiles, E_LoadType.SelectedEffects);
    }

    [MenuItem("Assets/配表工具/检查Effect配表中是否已配置此prefab(单选)", false, 43)]
    private static void IsExistThisEffect()
    {
        var guids = Selection.assetGUIDs;
        if (guids == null || guids.Length != 1)
        {
            EditorUtility.DisplayDialog("提示", "请选中一个effect prefab文件!", "OK");
            return;
        }

        var assetFile = AssetDatabase.GUIDToAssetPath(guids[0]);
        if (string.IsNullOrEmpty(assetFile) || !assetFile.EndsWith(".prefab") || !assetFile.Contains("Effects"))
        {
            EditorUtility.DisplayDialog("提示", "请选中effect prefab文件来检查!", "OK");
            return;
        }

        var table = TableManager.Instance.GetTable<LF.EffectTable>();
        if (null != table)
            table.ResetTable();

        var fileName = Path.GetFileNameWithoutExtension(assetFile);
        if (table.HasDataRow(fileName))
        {
            EditorUtility.DisplayDialog("提示", "文件已配置!", "OK");
            return;
        }

        var datas = table.GetAllData();
        if (null != datas && datas.Count > 0)
        {
            var target = assetFile.ToLowerInvariant();

            foreach (var per in datas)
            {
                var path = per.Value.AssetName.ToLowerInvariant();
                if (path.Contains(target) || target.Contains(path))
                {
                    EditorUtility.DisplayDialog("提示", "文件已配置!", "OK");
                    return;
                }
            }
        }

        EditorUtility.DisplayDialog("提示", "文件没有配置!", "OK");
    }

    /// <summary>
    /// 添加UI到配表中
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="prefabFile"></param>
    public static bool AddEffectToTable(string fileName, string prefabFile, bool showTips = false)
    {
        // 先查表,查到后返回
        var datarow = TableManager.Instance.GetDataRow<LF.EffectDataRow>(fileName);
        if (null != datarow)
        {
            if(showTips)
                EditorUtility.DisplayDialog("提示", string.Format("Effect配表已经存在{0}", fileName), "确定");

            return false;
        }

        bool isWrapEnd = false;
        using (StreamReader sr = new StreamReader(GetEffectFile()))
        {
            var content = sr.ReadToEnd();
            if (content.EndsWith("\n") || content.EndsWith("\r\n"))
                isWrapEnd = true;
        }

        // 获得数据行
        var dataLine = GetEffectDataLine(fileName, prefabFile);

        // 没查到,那么添加数据
        using (StreamWriter sw = new StreamWriter(GetEffectFile(), true, Encoding.UTF8))
        {
            if(!isWrapEnd)
                sw.WriteLine();

            sw.Write(dataLine);
            sw.Flush();
        }

        return true;
    }

    private static string effectFile = "";
    public static string GetEffectFile()
    {
        if (!string.IsNullOrEmpty(effectFile))
            return effectFile;

        string assetPath = Application.streamingAssetsPath;
        int index = assetPath.IndexOf("project");
        string rootPath = assetPath.Substring(0, index);
        effectFile = Path.Combine(rootPath, "tools", "MakeConfig", "config", "effect.txt");

        return effectFile;
    }

    public static string GetEffectDataLine(string fileName, string filePath)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("");
        stringBuilder.Append("\t");
        stringBuilder.Append(fileName);
        stringBuilder.Append("\t");
        stringBuilder.Append(filePath);
        stringBuilder.Append("\t");
        stringBuilder.Append("0");
        stringBuilder.Append("\t");
        stringBuilder.Append("0");
        stringBuilder.Append("\t");
        stringBuilder.Append("0");

        return stringBuilder.ToString();
    }

    #endregion

    #endregion

    /// <summary>
    /// 获得DataTable路径
    /// </summary>
    /// <returns></returns>
    static string GetDataTablePath()
    {
        string assetPath = Application.streamingAssetsPath;
        int index = assetPath.IndexOf("StreamingAssets");
        string rootPath = assetPath.Substring(0, index);
        string dataTablePath = Path.Combine(rootPath, "DataTable");
        if (Directory.Exists(dataTablePath))
        {
            return dataTablePath;
        }
        else
        {
            string message = string.Format("路径不存在:{0}\r\n请检查是否关联了配置文件子模块!", dataTablePath);
            EditorUtility.DisplayDialog("提示", message, "OK");

            return null;
        }
    }

    static string GetTableToolPath()
    {
        string rootPath = GetDataTablePath();
        if (string.IsNullOrEmpty(rootPath))
            return null;

        string tableToolPath = Path.Combine(rootPath, ".Tool", "MakeTable");
        if (Directory.Exists(tableToolPath))
        {
            return tableToolPath;
        }
        else
        {
            string message = string.Format("路径不存在:{0}\r\n请检查是否关联了配置文件子模块!", tableToolPath);
            EditorUtility.DisplayDialog("提示", message, "OK");

            return null;
        }
    }
}