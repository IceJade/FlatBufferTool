using System;
using System.Collections.Generic;
using System.Text;

namespace MakeTable
{
    public class Const
    {
        #region 分隔符

        /// <summary>
        /// 竖线分隔符
        /// </summary>
        public readonly static string g_VerticalLineSeparator = "|";

        /// <summary>
        /// 分号分隔符
        /// </summary>
        public readonly static string g_SemicolonSeparator = ";";

        /// <summary>
        /// 竖线分隔符
        /// </summary>
        public readonly static char g_CharVerticalLineSeparator = '|';

        /// <summary>
        /// 分号分隔符
        /// </summary>
        public readonly static char g_CharSemicolonSeparator = ';';

        /// <summary>
        /// 注解分隔符
        /// </summary>
        public readonly static string comment_separator = "#";

        /// <summary>
        /// Tab分隔符
        /// </summary>
        public readonly static string tab_separator = "\t";

        /// <summary>
        /// 路径分隔符
        /// </summary>
        public readonly static char[] path_separator = new char[2] { '/', '\\' };

        #endregion

        #region 文件相关

        /// <summary>
        /// XML文件扩展名
        /// </summary>
        public readonly static string g_XMLFileExtensionName = ".xml";

        /// <summary>
        /// 文本文件扩展名
        /// </summary>
        public readonly static string g_TextFileExtensionName = ".txt";

        /// <summary>
        /// FBS文件扩展名
        /// </summary>
        public readonly static string g_FBSFileExtensionName = ".fbs";

        /// <summary>
        /// 二进制文件扩展名
        /// </summary>
        public readonly static string g_BytesFileExtensionName = ".bytes";

        /// <summary>
        /// IDS二进制文件扩展名
        /// </summary>
        public readonly static string g_IdsBytesFileExtensionName = "_ids.bytes";

        /// <summary>
        /// Json文件扩展名
        /// </summary>
        public readonly static string g_JsonFileExtensionName = ".json";

        /// <summary>
        /// 图集文件扩展名
        /// </summary>
        public readonly static string g_SpriteAtlasFileName = ".spriteatlas";

        /// <summary>
        /// FBS文件扩展名
        /// </summary>
        public readonly static string g_DataRowAliasName = "DR";

        /// <summary>
        /// 表 文件扩展名
        /// </summary>
        public readonly static string g_DataTableAliasName = "DT";

        /// <summary>
        /// 表文件扩展名
        /// </summary>
        public readonly static string g_TableAliasName = "Table_";

        /// <summary>
        /// Log文件前缀
        /// </summary>
        public readonly static string g_LogFileName = "Log_";

        /// <summary>
        /// AB文件前缀
        /// </summary>
        public readonly static string g_ABFileName = "AB_";

        /// <summary>
        /// _b文件后缀
        /// </summary>
        public readonly static string g_BFileName = "_b";

        /// <summary>
        /// FBS AB文件前缀
        /// </summary>
        public readonly static string g_FBS_ABFileName = "DTAB_";

        /// <summary>
        /// FBS B文件后缀
        /// </summary>
        public readonly static string g_FBS_BFileName = "_b.fbs";

        /// <summary>
        /// Log文件扩展名
        /// </summary>
        public readonly static string g_LogExtensionFileName = ".log";

        /// <summary>
        /// Lua脚本生成文件夹
        /// </summary>
        public readonly static string g_LuaFolder = "lua";

        /// <summary>
        /// CSharp脚本生成文件夹
        /// </summary>
        public readonly static string g_CSharpFolder = "csharp";

        /// <summary>
        /// flatbuffer生成的脚本文件夹
        /// </summary>
        public readonly static string g_FlatbufferFolder = "flatbuffer";

        /// <summary>
        /// 解析代码生成的脚本文件夹
        /// </summary>
        public readonly static string g_TableGenarateFolder = "genarate";

        /// <summary>
        /// 解析代码生成的脚本文件夹
        /// </summary>
        public readonly static string g_TableExtendFolder = "extend";

        /// <summary>
        /// 表格管理器模板文件名
        /// </summary>
        public readonly static string g_ManagerModelFileName = "TableManager.model";

        /// <summary>
        /// 表格管理器扩展模板文件名
        /// </summary>
        public readonly static string g_ManagerExtendModelFileName = "TableManager.extend.model";

        /// <summary>
        /// 表格扩展模板文件名
        /// </summary>
        public readonly static string g_TableExtendModelFileName = "Table.extend.model";

        /// <summary>
        /// 模板文件名(ID为整形)
        /// </summary>
        public readonly static string g_IntegerPartialModelFileName = "Table.integerid.model";

        /// <summary>
        /// 模板文件名(ID为字符串)
        /// </summary>
        public readonly static string g_StringPartialModelFileName = "Table.stringid.model";

        /// <summary>
        /// 模板文件名(ID为整型)
        /// </summary>
        public readonly static string g_IntegerPartialConfigModelFileName = "Config.integerid.model";

        /// <summary>
        /// 模板文件名(ID为字符串)
        /// </summary>
        public readonly static string g_StringPartialConfigModelFileName = "Config.stringid.model";

        /// <summary>
        /// 生成的表格解析代码文件名
        /// </summary>
        public readonly static string g_TableCodeFileName = "{0}Table.cs";

        /// <summary>
        /// 生成的表格扩展代码文件名
        /// </summary>
        public readonly static string g_TableExtendCodeFileName = "{0}DataRow.cs";

        /// <summary>
        /// 生成表格ID与Index对应关系表
        /// </summary>
        public readonly static string g_TableIdsFileName = "{0}_ids.bytes";

        /// <summary>
        /// 生成表格存储与偏移对应关系表
        /// </summary>
        public readonly static string g_TableOffsetFileName = "table_offset.bytes";

        #endregion

        #region 生成代码的常量定义

        /// <summary>
        /// ID
        /// </summary>
        public readonly static string g_Id = "id";

        /// <summary>
        /// 通用Case代码模板
        /// </summary>
        public readonly static string g_CommonCaseTemplate = "                case \"{0}\": { result = datarow.{1}; break; }\n";

        /// <summary>
        /// 转换成字符串Case模板
        /// </summary>
        public readonly static string g_ToStringCaseTemplate = "                case \"{0}\": { result = datarow.{1}.ToString(); break; }\n";

        /// <summary>
        /// 转换成数组Case模板
        /// </summary>
        public readonly static string g_CommonCaseArrayTemplate = "                case \"{0}\": { result = datarow.Get{1}Array(); break; }\n";

        /// <summary>
        /// 转换成字符串Case模板
        /// </summary>
        public readonly static string g_StringCaseArrayTemplate = "                case \"{0}\": { result = datarow.{1}(index); break; }\n";

        #endregion

        #region 其他常量

        /// <summary>
        /// 解析XML的元素名称
        /// </summary>
        public readonly static string g_XmlParseElementName = "ItemSpec";

        public readonly static string g_ColumnNamePara = "para";
        public readonly static string g_ColumnName_Name = "name";
        public readonly static string g_ColumnName_Description = "description";

        /// <summary>
        /// 数组分隔符
        /// </summary>
        public readonly static char[] g_split_chars = new char[] { '|', ';' };

        #endregion
    }
}
