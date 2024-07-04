using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace MakeTable
{
    // 资源加载模式
    public enum E_ResLoadMode
    {
        AssetBundle = 0,
        SpriteAtlas
    }

    /// <summary>
    /// 文件类型
    /// </summary>
    public enum E_FileType
    {
        Binary = 0, // 二进制数据文件
        Ids,        // 索引文件
        CSharp,     // C#解析代码
        FB_CSharp   // Flatbuffer解析代码
    }

    public class SpriteAtlasProcess : Process<SpriteAtlasProcess>
    {
        private bool initSucess = false;

        private string tablesPath = string.Empty;
        private string rootPath = string.Empty;
        private string atlasPath = string.Empty;
        private string dataPath = string.Empty;
        private string scriptsPath = string.Empty;
        private string[] spritesPaths = null;

        private string atlasFileName = "atlas.xml";
        private string spritesFileName = "sprites.xml";

        private string[] genAtlasFiles = { "atlas.bytes", "atlas_ids.bytes", "AtlasTable.cs", "DTatlas.cs" };
        private string[] genSpritesFiles = { "sprites.bytes", "sprites_ids.bytes", "SpritesTable.cs", "DTsprites.cs" };

        private string assetPath = "Assets";

        private Dictionary<string, string> atlasCaches = new Dictionary<string, string>();
        private Dictionary<string, SpriteInfo> spritesCaches = new Dictionary<string, SpriteInfo>();

        public override void Init(object param)
        {
            this.tablesPath = this.GetGenXmlPath();
        }

        public override void Start()
        {
            Log.Print("start SpriteAtlasProcess...");

            if (!this.IsOpen())
                return;

            if (!this.IsValid())
                return;

            this.initSucess = true;

            this.GenerateAtlasXml();

            this.GenerateSpritesXml();
        }

        public override void End()
        {
            Log.Print("End SpriteAtlasProcess...");

            if (!this.initSucess)
                return;

            if (!this.IsOpen())
                return;

            this.CopyFiles();
        }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(this.GetRootPath()))
                return false;

            if (string.IsNullOrEmpty(this.GetAtlasPath()))
                return false;

            var spritesPaths = this.GetSpritesPath();
            if (null == spritesPaths || spritesPaths.Length <= 0)
                return false;

            return true;
        }

        protected override string GetProcessName()
        {
            return "SpriteAtlasProcess";
        }

        #region 图集XML

        private void GenerateAtlasXml()
        {
            Log.Print("start to create or refresh atlas.xml...");

            atlasCaches.Clear();

            string atlasPath = this.GetAtlasPath();
            if(!DirectoryUtils.Exists(atlasPath))
            {
                Log.Error("can not find path {0}", atlasPath);
                return;
            }

            this.RecurseAtlasDirectory(atlasPath);

            string xmlFile = this.GetAtlasXmlFile();
            if(FileUtils.Exists(xmlFile))
                this.RefreshAtlasXmlFile(xmlFile);
            else
                this.CreateAtlasXmlFile(xmlFile);

            Log.Print("create or refresh atlas.xml end...");
        }

        /// <summary>
        /// 递归遍历图集目录
        /// </summary>
        /// <param name="directory"></param>
        private void RecurseAtlasDirectory(string directory)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            DirectoryInfo[] subDirectoryInfos = directoryInfo.GetDirectories();
            if (null == subDirectoryInfos && subDirectoryInfos.Length <= 0)
                return;

            for (int i = 0; i < subDirectoryInfos.Length; i++)
            {
                string bundleName = this.GetBunldleName(subDirectoryInfos[i].FullName);

                if (!string.IsNullOrEmpty(bundleName)
                    && !string.IsNullOrEmpty(subDirectoryInfos[i].Name)
                    && !atlasCaches.ContainsKey(subDirectoryInfos[i].Name))
                {
                    var atlasFileName = subDirectoryInfos[i].FullName + Const.g_SpriteAtlasFileName;
                    if(FileUtils.Exists(atlasFileName))
                        atlasCaches.Add(subDirectoryInfos[i].Name.Trim(), bundleName);
                }

                var childDirectoryInfos = subDirectoryInfos[i].GetDirectories();
                if (null != childDirectoryInfos && childDirectoryInfos.Length > 0)
                    this.RecurseAtlasDirectory(subDirectoryInfos[i].FullName);
            }
        }

        private void RefreshAtlasXmlFile(string xmlFile)
        {
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(xmlFile);
            }
            catch (Exception e)
            {
                Log.Error("load xml throw exception, error:{0}, xml:{1}", e.Message, xmlFile);
                ErrorLog.Error("load xml throw exception, error:{0}, xml:{1}", e.Message, xmlFile);

                return;
            }

            XmlNodeList xmlNodeList = xmlDoc.DocumentElement.ChildNodes;
            if (null == xmlNodeList || xmlNodeList.Count <= 0)
            {
                Log.Warning("The table {0} have nothing.", xmlFile);
                return;
            }

            // 刷新已有图集;
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                if (null == xmlNodeList[i] || null == xmlNodeList[i].Attributes)
                    continue;

                string atlasName = xmlNodeList[i].Attributes["id"].Value;
                // 过滤数据类型配置行
                E_ColumnType columnType = ToolUtils.GetDataType(atlasName);
                if (columnType != E_ColumnType.Unknow)
                    continue;

                string bundleName = xmlNodeList[i].Attributes["BundleName"].Value;

                if (this.atlasCaches.ContainsKey(atlasName))
                {
                    if(this.atlasCaches[atlasName] != bundleName)
                        xmlNodeList[i].Attributes["BundleName"].Value = this.atlasCaches[atlasName];

                    this.atlasCaches.Remove(atlasName);
                }
            }

            // 新增图集
            if(this.atlasCaches.Count > 0)
            {
                foreach (var per in atlasCaches)
                {
                    XmlElement item = xmlDoc.CreateElement("ItemSpec");
                    item.SetAttribute("id", per.Key);
                    item.SetAttribute("BundleName", per.Value);
                    xmlDoc.DocumentElement.AppendChild(item);
                }
            }

            try
            {
                xmlDoc.Save(xmlFile);
            }
            catch (Exception e)
            {
                Log.Error("save xml throw exception, error:{0}, xml:{1}", e.Message, xmlFile);
                ErrorLog.Error("save xml throw exception, error:{0}, xml:{1}", e.Message, xmlFile);
            }
        }

        private void CreateAtlasXmlFile(string xmlFile)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //创建类型声明节点
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "no");
            xmlDoc.AppendChild(node);
            //创建根节点  
            XmlElement root = xmlDoc.CreateElement("Root");
            xmlDoc.AppendChild(root);

            foreach (var per in atlasCaches)
            {
                XmlElement item = xmlDoc.CreateElement("ItemSpec");
                item.SetAttribute("id", per.Key);
                item.SetAttribute("BundleName", per.Value);
                root.AppendChild(item);
            }

            try
            {
                xmlDoc.Save(xmlFile);
            }
            catch (Exception e)
            {
                Log.Error("save xml throw exception, error:{0}, xml:{1}", e.Message, xmlFile);
                ErrorLog.Error("save xml throw exception, error:{0}, xml:{1}", e.Message, xmlFile);
            }
        }

        private string GetBunldleName(string path)
        {
            int index = path.IndexOf("Assets");
            if (index >= 0)
                return path.Substring(index).Trim().ToLowerInvariant().Replace("\\","/");

            return string.Empty;
        }

        private string GetAtlasXmlFile()
        {
            return PathUtils.Combine(this.tablesPath, this.atlasFileName);
        }

        #endregion

        #region 纹理XML

        private void GenerateSpritesXml()
        {
            Log.Print("start to create or refresh sprites.xml...");

            spritesCaches.Clear();

            var spritePaths = this.GetSpritesPath();
            if (null == spritePaths || spritePaths.Length <= 0)
                return;

            for (int i = 0; i < spritePaths.Length; i++)
            {
                if (!DirectoryUtils.Exists(spritePaths[i]))
                    continue;

                this.RecurseSpritesDirectory(spritePaths[i]);
            }

            string xmlFile = this.GetSpritesXmlFile();
            if (FileUtils.Exists(xmlFile))
                this.RefreshSpritesXmlFile(xmlFile);
            else
                this.CreateSpritesXmlFile(xmlFile);

            Log.Print("create or refresh sprites.xml end...");
        }

        /// <summary>
        /// 递归遍历纹理目录
        /// </summary>
        /// <param name="directory"></param>
        private void RecurseSpritesDirectory(string path)
        {
            // 以下划线开头的文件夹不生成到纹理配置里
            if (path.StartsWith("_"))
                return;

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            DirectoryInfo[] subDirectoryInfos = directoryInfo.GetDirectories();
            for (int i = 0; i < subDirectoryInfos.Length; i++)
            {
                var fileInfos = subDirectoryInfos[i].GetFiles("*.png");
                foreach (var item in fileInfos)
                {
                    string spriteName = PathUtils.GetFileNameWithoutExtension(item.Name);
                    // 以下划线开头的图片不生成到纹理配置里
                    if (spriteName.StartsWith("_"))
                        continue;

                    if (!spritesCaches.ContainsKey(spriteName))
                        spritesCaches.Add(spriteName.Trim(), new SpriteInfo(item.FullName.Trim(), subDirectoryInfos[i].Name.Trim()));
                    else
                        Log.Warning("repeat sprite, {0}", this.GetAssetPath(item.FullName));
                }

                var childDirectoryInfos = subDirectoryInfos[i].GetDirectories();
                if (null != childDirectoryInfos && childDirectoryInfos.Length > 0)
                    RecurseSpritesDirectory(subDirectoryInfos[i].FullName);
            }
        }

        private void RefreshSpritesXmlFile(string xmlFile)
        {
            XmlDocument xmlDoc = new XmlDocument();
            
            try
            {
                xmlDoc.Load(xmlFile);
            }
            catch (Exception e)
            {
                Log.Error("load xml throw exception, error:{0}, xml:{1}", e.Message, xmlFile);
                ErrorLog.Error("load xml throw exception, error:{0}, xml:{1}", e.Message, xmlFile);

                return;
            }

            XmlNodeList xmlNodeList = xmlDoc.DocumentElement.ChildNodes;
            if (null == xmlNodeList || xmlNodeList.Count <= 0)
            {
                Log.Warning("The table {0} have nothing.", xmlFile);
                return;
            }

            // 刷新已有图集;
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                if (null == xmlNodeList[i] || null == xmlNodeList[i].Attributes)
                    continue;

                string spriteName = xmlNodeList[i].Attributes["id"].Value;
                // 过滤数据类型配置行
                E_ColumnType columnType = ToolUtils.GetDataType(spriteName);
                if (columnType != E_ColumnType.Unknow)
                    continue;

                int loadType = Convert.ToInt32(xmlNodeList[i].Attributes["LoadType"].Value);
                string loadName = xmlNodeList[i].Attributes["AtlasOrBundleName"].Value;

                if (this.spritesCaches.ContainsKey(spriteName))
                {
                    E_ResLoadMode e_ResLoadMode = this.spritesCaches[spriteName].GetResLoadMode();
                    string resLoadName = this.spritesCaches[spriteName].GetResLoadName();

                    if (loadType != (int)e_ResLoadMode)
                        xmlNodeList[i].Attributes["LoadType"].Value = string.Format("{0}", (int)e_ResLoadMode);

                    if (loadName != resLoadName)
                        xmlNodeList[i].Attributes["AtlasOrBundleName"].Value = resLoadName;

                    this.spritesCaches.Remove(spriteName);
                }
            }

            // 新增图集
            if (this.spritesCaches.Count > 0)
            {
                foreach (var per in spritesCaches)
                {
                    E_ResLoadMode e_ResLoadMode = per.Value.GetResLoadMode();
                    string resLoadName = per.Value.GetResLoadName();
                    if (string.IsNullOrEmpty(resLoadName))
                        continue;

                    XmlElement item = xmlDoc.CreateElement("ItemSpec");
                    item.SetAttribute("id", per.Key);
                    item.SetAttribute("LoadType", string.Format("{0}", (int)e_ResLoadMode));
                    item.SetAttribute("AtlasOrBundleName", resLoadName);
                    xmlDoc.DocumentElement.AppendChild(item);
                }
            }

            try
            {
                xmlDoc.Save(xmlFile);
            }
            catch (Exception e)
            {
                Log.Error("save xml throw exception, error:{0}, xml:{1}", e.Message, xmlFile);
                ErrorLog.Error("save xml throw exception, error:{0}, xml:{1}", e.Message, xmlFile);
            }
        }

        private void CreateSpritesXmlFile(string xmlFile)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //创建类型声明节点
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "no");
            xmlDoc.AppendChild(node);
            //创建根节点  
            XmlElement root = xmlDoc.CreateElement("Root");
            xmlDoc.AppendChild(root);

            foreach (var per in spritesCaches)
            {
                E_ResLoadMode e_ResLoadMode = per.Value.GetResLoadMode();

                string resLoadName = per.Value.GetResLoadName();
                if (string.IsNullOrEmpty(resLoadName))
                    continue;

                XmlElement item = xmlDoc.CreateElement("ItemSpec");
                item.SetAttribute("id", per.Key);
                item.SetAttribute("LoadType", string.Format("{0}", (int)e_ResLoadMode));
                item.SetAttribute("AtlasOrBundleName", resLoadName);
                //item.SetAttribute("AtlasName", per.Value.GetAtlasName());
                //item.SetAttribute("BundleName", per.Value.GetResLoadName());
                root.AppendChild(item);
            }

            try
            {
                xmlDoc.Save(xmlFile);
            }
            catch (Exception e)
            {
                Log.Error("save xml throw exception, error:{0}, xml:{1}", e.Message, xmlFile);
                ErrorLog.Error("save xml throw exception, error:{0}, xml:{1}", e.Message, xmlFile);
            }
        }

        private string GetSpritesXmlFile()
        {
            return PathUtils.Combine(this.tablesPath, this.spritesFileName);
        }

        #endregion

        #region 结束处理

        /// <summary>
        /// 移动生成的文件
        /// </summary>
        private void CopyFiles()
        {
            string fileFullName;

            // 处理图集文件
            for (int i = 0; i < this.genAtlasFiles.Length; i++)
            {
                E_FileType e_FileType = (E_FileType)i;
                fileFullName = PathUtils.Combine(this.GetSourceFilePath(e_FileType), this.genAtlasFiles[i]);
                if (FileUtils.Exists(fileFullName))
                    CopyFile(fileFullName, e_FileType);
            }

            // 处理纹理文件
            for (int i = 0; i < this.genSpritesFiles.Length; i++)
            {
                E_FileType e_FileType = (E_FileType)i;
                fileFullName = PathUtils.Combine(this.GetSourceFilePath(e_FileType), this.genSpritesFiles[i]);
                if (FileUtils.Exists(fileFullName))
                    CopyFile(fileFullName, e_FileType);
            }
        }

        /// <summary>
        /// 获得源文件的目录
        /// </summary>
        /// <param name="e_FileType">文件类型</param>
        /// <returns></returns>
        private string GetSourceFilePath(E_FileType e_FileType)
        {
            string filePath = string.Empty;

            switch (e_FileType)
            {
                case E_FileType.Binary:
                    {
                        filePath = ToolUtils.GetPath(E_PathType.Binary, CommonData._gen_root_path);
                        break;
                    }
                case E_FileType.Ids:
                    {
                        filePath = ToolUtils.GetPath(E_PathType.Ids, CommonData._gen_root_path);
                        break;
                    }
                case E_FileType.CSharp:
                    {
                        filePath = PathUtils.Combine(ToolUtils.GetPath(E_PathType.CSharp, CommonData._gen_root_path), "genarate");
                        break;
                    }
                case E_FileType.FB_CSharp:
                    {
                        filePath = PathUtils.Combine(ToolUtils.GetPath(E_PathType.CSharp, CommonData._gen_root_path), "flatbuffer");
                        break;
                    }
                default:
                    break;
            }

            return filePath;
        }

        private void CopyFile(string fileFullName, E_FileType e_FileType)
        {
            if (string.IsNullOrEmpty(fileFullName) 
                || !FileUtils.Exists(fileFullName))
                return;

            string desFile = string.Empty;

            string fileName = PathUtils.GetFileName(fileFullName);

            switch(e_FileType)
            {
                case E_FileType.Binary:
                    {
                        desFile = PathUtils.Combine(this.GetConfigDataPath(), fileName);
                        break;
                    }
                case E_FileType.Ids:
                    {
                        desFile = PathUtils.Combine(this.GetConfigDataPath(), "ids", fileName);
                        break;
                    }
                case E_FileType.CSharp:
                    {
                        desFile = PathUtils.Combine(this.GetConfigScriptsPath(), "genarate", fileName);
                        break;
                    }
                case E_FileType.FB_CSharp:
                    {
                        desFile = PathUtils.Combine(this.GetConfigScriptsPath(), "flatbuffer", fileName);
                        break;
                    }
                default:
                    break;
            }

            if (!string.IsNullOrEmpty(desFile))
            {
                FileUtils.Copy(fileFullName, desFile, true);

                Log.Print("copy file => {0} -> {1}", fileFullName, desFile);
            }
        }

        #endregion

        #region 私有函数

        private string GetAssetPath(string file)
        {
            if(!file.StartsWith(assetPath))
                return file.Substring(file.IndexOf(assetPath));

            return file;
        }

        public string GetAtlasPath()
        {
            if (string.IsNullOrEmpty(this.tablesPath))
                return null;

            string rootPath = this.GetRootPath();
            if (string.IsNullOrEmpty(rootPath))
                return null;

            if (string.IsNullOrEmpty(atlasPath))
                atlasPath = PathUtils.Combine(rootPath, Config.Instance.GetString("atlas_path"));

            return atlasPath;
        }

        private string[] GetSpritesPath()
        {
            if (string.IsNullOrEmpty(this.tablesPath))
                return null;

            string rootPath = this.GetRootPath();
            if (string.IsNullOrEmpty(rootPath))
                return null;

            if (null == this.spritesPaths)
            {
                string[] paths = Config.Instance.GetStringArray("sprite_path", ';');
                if (null != paths && paths.Length > 0)
                {
                    this.spritesPaths = new string[paths.Length];

                    for (int i = 0; i < paths.Length; i++)
                        this.spritesPaths[i] = PathUtils.Combine(rootPath, paths[i]).Replace("\\", "/");
                }
            }

            return this.spritesPaths;
        }

        private string GetConfigDataPath()
        {
            if (string.IsNullOrEmpty(this.tablesPath))
                return null;

            string rootPath = this.GetRootPath();
            if (string.IsNullOrEmpty(rootPath))
                return null;

            if (string.IsNullOrEmpty(dataPath))
                dataPath = PathUtils.Combine(rootPath, Config.Instance.GetString("project_config_data_path"));

            return dataPath;
        }

        private string GetConfigScriptsPath()
        {
            if (string.IsNullOrEmpty(this.tablesPath))
                return null;

            string rootPath = this.GetRootPath();
            if (string.IsNullOrEmpty(rootPath))
                return null;

            if (string.IsNullOrEmpty(scriptsPath))
                scriptsPath = PathUtils.Combine(rootPath, Config.Instance.GetString("project_config_scripts_path"));

            return scriptsPath;
        }

        public string GetGenXmlPath()
        {
            string rootPath = this.GetRootPath();
            if (string.IsNullOrEmpty(rootPath))
                return null;
            
            string genXmlPath = PathUtils.Combine(rootPath, Config.Instance.GetString("project_gen_xml_path"));

            try
            {
                if (!DirectoryUtils.Exists(genXmlPath))
                    DirectoryUtils.CreateDirectory(genXmlPath);
            }
            catch (Exception e)
            {
                Log.Error("创建目录失败! error:{0}, path:{1}, in function GetGenXmlPath.", e.Message, genXmlPath);
                ErrorLog.Error("创建目录失败! error:{0}, path:{1}, in function GetGenXmlPath.", e.Message, genXmlPath);
            }

            return genXmlPath;
        }

        public string GetGenFlatbufferPath()
        {
            string rootPath = this.GetRootPath();
            if (string.IsNullOrEmpty(rootPath))
                return null;

            string genPath = PathUtils.Combine(rootPath, Config.Instance.GetString("project_gen_flatbuffer_path"));
            try
            {
                if (!DirectoryUtils.Exists(genPath))
                    DirectoryUtils.CreateDirectory(genPath);
            }
            catch (Exception e)
            {
                Log.Error("创建目录失败! error:{0}, path:{1}, in function GetGenFlatbufferPath.", e.Message, genPath);
                ErrorLog.Error("创建目录失败! error:{0}, path:{1}, in function GetGenFlatbufferPath.", e.Message, genPath);
            }

            return genPath;
        }

        private string GetRootPath()
        {
            if(string.IsNullOrEmpty(rootPath))
                rootPath = ToolUtils.GetAssetsPath();

            return this.rootPath;
        }

        #endregion
    }

    public class SpriteInfo
    {
        private string spriteFile;
        private string parentFolder;

        private string bundleFlag = "assetBundleName:";

        public SpriteInfo(string _spriteFile, string _parentFolder)
        {
            this.spriteFile = _spriteFile;
            this.parentFolder = _parentFolder;
        }

        public E_ResLoadMode GetResLoadMode()
        {
            string tmpPath = this.spriteFile.Replace("\\", "/");
            if (tmpPath.Contains(Config.Instance.GetString("atlas_mode")))
                return E_ResLoadMode.SpriteAtlas;

            return E_ResLoadMode.AssetBundle;
        }

        public string GetAtlasName()
        {
            return this.parentFolder;
        }

        public string GetBundleName()
        {
            string resLoadName = string.Empty;

            string metaFile = this.spriteFile + ".meta";
            if (!FileUtils.Exists(metaFile))
                return resLoadName;

            try
            {
                using (FileStream fileStream = new FileStream(metaFile, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string line;
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();

                            if (!line.Contains(this.bundleFlag))
                                continue;

                            resLoadName = line.Substring(line.IndexOf(this.bundleFlag) + this.bundleFlag.Length).Trim();
                            break;
                        }

                        reader.Close();
                        reader.Dispose();
                    }

                    fileStream.Close();
                    fileStream.Dispose();
                }
            }
            catch (Exception e)
            {
                Log.Error("打开文件异常! error:{0},file:{1}", e.Message, metaFile);
            }

            return resLoadName;
        }

        public string GetResLoadName()
        {
            string resLoadName = string.Empty;

            string metaFile = this.spriteFile + ".meta";
            if (!FileUtils.Exists(metaFile))
                return resLoadName;

            switch (this.GetResLoadMode())
            {
                case E_ResLoadMode.SpriteAtlas:
                    {
                        resLoadName = this.GetAtlasName();

                        break;
                    }
                case E_ResLoadMode.AssetBundle:
                    {
                        resLoadName = this.GetBundleName();

                        break;
                    }
                default:
                    break;
            }

            return resLoadName;
        }
    }
}