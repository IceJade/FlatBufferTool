using System;
using System.Collections.Generic;
using System.IO;

namespace MakeTable
{
    /// <summary>
    /// 生成基类
    /// </summary>
    public class GenerateBase
    {
        public bool IsGenerateCode()
        {
            return Config.Instance.IsOpen("IsGenerateCode", true);
        }

        public bool IsGenerateJson()
        {
            return Config.Instance.IsOpen("IsGenerateJson", true);
        }

        public bool IsGenerateClientData()
        {
            return Config.Instance.IsOpen("GenerateDataType", true);
        }

        public bool IsSkipColumn(string columnName)
        {
            if(string.IsNullOrEmpty(columnName))
                return false;

            if (IsGenerateClientData())
            {
                return columnName == "S" || columnName == "s";
            }
            else
            {
                return columnName == "C" || columnName == "c";
            }
        }
    }
}
