﻿
namespace MakeTable
{
    /// <summary>
    /// 指令类型
    /// </summary>
    public enum E_CommandType
    {
        None = 0,
        CMD_ParseTable,                   // 解析XML生成表结构文件
        CMD_FlatBuffer,                   // 批量生成FlatBuffer文件(不包含源目录下的子目录)
        CMD_Recursive_FlatBuffer,         // 批量递归生成FlatBuffer文件(包括源目录下的子目录)
        CMD_BuffersToJson,                // 将flatbuffers数据转换成json数据
        CMD_GenerateDataOnly,             // 批量生成Flatbuffer数据不生成解析代码
        CMD_GenSpriteAtlasConfig,         // 生成图集配置文件及Flatbuffer数据
        CMD_GenerateSingleDataOnly,       // 指定某个XML文件生成单条Flatbuffer数据
        CMD_OutsideVersion,               // 外网正式版本(只生成数据,其他不处理)
    }

    /// <summary>
    /// 文件路径类型
    /// </summary>
    public enum E_PathType
    {
        FBS = 0,
        CSharp,
        Lua,
        Design,
        Binary,
        Json,           // json文件路径
        Model,       // 模板文件
        Log,
        Ids,
        Result          // 生成的结果文件
    }

    /// <summary>
    /// 表列数据类型
    /// 0-int
    /// 1-short
    /// 2-bool
    /// 3-float
    /// 4-string
    /// 5- table
    /// 6-[int]
    /// 7-[short]
    /// 8-[bool]
    /// 9-[string]
    /// 10-[table]
    /// </summary>
    public enum E_ColumnType
    {
        Unknow = -1,
        Single_Int = 0,
        Single_Short,
        Single_Bool,
        Single_Float,
        Single_String,
        Single_Table,
        Array_Int,
        Array_Short,
        Array_bool,
        Array_Float,
        Array_String,
        Array_Table,
        Dictionary_II,
        Dictionary_IS,
        Dictionary_SI,
        Dictionary_SS,
        Fix_String          // 固定为String类型
    }

    /// <summary>
    /// 模板类型
    /// </summary>
    public enum E_ModelType
    {
        Common = 0,
        Float,
        String,
        Table,
        Dictionary_II,
        Dictionary_IS,
        Dictionary_SI,
        Dictionary_SS,
        CommonArray,
        FloatArray,
        StringArray,
        StringArrayIndex,
        StringArrayLength,
        TableArray
    }

    public enum E_CaseType
    {
        case_int = 0,
        case_int_array,
        case_float,
        case_float_array,
        case_string,
        case_string_array,
        case_string_array_index,
        case_string_array_length,
        case_check_table
    }

    public enum E_ErrorType
    {
        Success = 0,            // 成功
        DataTypeMismatch,       // 数据类型不匹配
    }

    public enum E_TableNameErrorType
    {
        Success = 0,            // 成功
        EmptyOrNull,            // 空字符串
        Has_Unvalid_Character,  // 含有非法字符
        Has_Upper_Letters       // 含有大写字母
    }
}
