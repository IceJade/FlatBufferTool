﻿using System;
using System.Text;
using System.Text.RegularExpressions;

namespace MakeTable
{
    class TableColumnInfo
    {
        #region 公有变量

        /// <summary>
        /// 列名
        /// </summary>
        public string name;

        /// <summary>
        /// 列的别名(有些列名不符合变量命名规范,故换成别名)
        /// </summary>
        public string alias_name;

        /// <summary>
        /// 列类型
        /// </summary>
        public E_ColumnType dataType = E_ColumnType.Single_Int;

        /// <summary>
        /// 数组长度
        /// </summary>
        public int length = 0;

        /// <summary>
        /// 数组分隔符
        /// </summary>
        public string array_separator = string.Empty;

        /// <summary>
        /// 数组中的数据元分隔符
        /// </summary>
        public string item_separator = string.Empty;

        /// <summary>
        /// 注解
        /// </summary>
        public string comment = string.Empty;

        #endregion

        #region 私有变量

        /// <summary>
        /// 列细分的数据数量
        /// </summary>
        private int item_count = 0;

        #endregion

        #region 公共接口

        public TableColumnInfo()
        {

        }

        public TableColumnInfo(string name_, E_ColumnType dataType_)
        {
            this.name = name_;
            this.dataType = dataType_;
        }

        /// <summary>
        /// 设置别名
        /// </summary>
        /// <param name="alies_"></param>
        public void SetAliasName(string alies_)
        {
            this.alias_name = alies_;
        }

        /// <summary>
        /// 获得列名
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            if (!string.IsNullOrEmpty(this.alias_name))
                return this.alias_name;

            return this.name;
        }

        /// <summary>
        /// 设置数据类型
        /// </summary>
        /// <param name="dataType_"></param>
        public void SetDataType(E_ColumnType dataType_)
        {
            // 如果之前判断是数组类型, 后面判断是dictionary类型, 那么需要检查之前的数组数量为2才能兼容, 否则固定为字符串类型
            if(this.IsArray(this.dataType) 
                && this.IsDictionary(dataType_) 
                && this.length != 2)
            {
                this.SetDataType(E_ColumnType.Fix_String);
                return;
            }

            this.dataType = dataType_;

            if(dataType_ == E_ColumnType.Fix_String)
                this.ClearComment();
        }

        /// <summary>
        /// 设置数组分隔符
        /// </summary>
        /// <param name="separator"></param>
        public void SetArraySeparator(string separator)
        {
            this.array_separator = separator;
        }

        /// <summary>
        /// 判断是否为数组类型
        /// </summary>
        /// <returns></returns>
        private bool IsArray(E_ColumnType dataType_)
        {
            return dataType_ == E_ColumnType.Array_Int
                || dataType_ == E_ColumnType.Array_Short
                || dataType_ == E_ColumnType.Array_bool
                || dataType_ == E_ColumnType.Array_Float
                || dataType_ == E_ColumnType.Array_String;
        }

        /// <summary>
        /// 判断是否为Key-Value类型
        /// </summary>
        /// <returns></returns>
        private bool IsDictionary(E_ColumnType dataType_)
        {
            return dataType_ == E_ColumnType.Dictionary_II
                || dataType_ == E_ColumnType.Dictionary_IS
                || dataType_ == E_ColumnType.Dictionary_SI
                || dataType_ == E_ColumnType.Dictionary_SS;
        }

        /// <summary>
        /// 设置注解
        /// </summary>
        /// <param name="count"></param>
        public void SetComment(int count)
        {
            if (count > this.item_count)
            {
                comment = string.Empty;

                for (int i = 0; i < count; i++)
                {
                    if (i <= 0)
                    {
                        comment = name + "_1";
                    }
                    else
                    {
                        comment += Const.comment_separator + name + "_" + (i + 1).ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 清除注解
        /// </summary>
        /// <param name="count"></param>
        public void ClearComment()
        {
            this.item_count = 0;
            this.comment = string.Empty;
        }

        /// <summary>
        /// 检查Table类型是否合法
        /// </summary>
        /// <param name="mainSeparator">主分隔符</param>
        /// <param name="childSeparator">自分隔符</param>
        /// <returns></returns>
        public bool CheckTableValid(string mainSeparator, string childSeparator)
        {
            // 如果发现分隔符变化,那么固定为字符串类型
            if (!string.IsNullOrEmpty(this.array_separator) 
                && !string.IsNullOrEmpty(this.item_separator) 
                && (this.array_separator != mainSeparator 
                || this.item_separator != childSeparator))
            {
                this.SetDataType(E_ColumnType.Fix_String);

                return false;
            }

            // 如果前面是数组,后面判断是Table类型,那么之前的数组分隔符必须为子分隔符,否则固定位字符串类型
            if (!string.IsNullOrEmpty(this.array_separator)
                && string.IsNullOrEmpty(this.item_separator)
                && this.array_separator != childSeparator)
            {
                this.SetDataType(E_ColumnType.Fix_String);

                return false;
            }

            return true;
        }

        /// <summary>
        /// 设置分隔符
        /// </summary>
        /// <param name="data"></param>
        public void SetSeparator(string data)
        {
            //int lineCount = Regex.Matches(data, Const.g_VerticalLineSeparator).Count;
            //int semicolonCount = Regex.Matches(data, Const.g_SemicolonSeparator).Count;

            int lineCount = data.IndexOf(Const.g_VerticalLineSeparator);
            int semicolonCount = data.IndexOf(Const.g_SemicolonSeparator);

            if (lineCount > 0 && semicolonCount > 0)
            {
                if(lineCount > semicolonCount)
                {
                    // 如果发现分隔符变化,那么固定为字符串类型
                    if(!string.IsNullOrEmpty(this.array_separator) 
                        && !string.IsNullOrEmpty(this.item_separator) 
                        && (this.array_separator != Const.g_VerticalLineSeparator 
                        || this.item_separator != Const.g_SemicolonSeparator))
                    {
                        this.SetDataType(E_ColumnType.Fix_String);

                        return;
                    }

                    this.array_separator = Const.g_VerticalLineSeparator;
                    this.item_separator = Const.g_SemicolonSeparator;
                }
                else
                {
                    // 如果发现分隔符变化,那么固定为字符串类型
                    if (!string.IsNullOrEmpty(this.array_separator)
                        && !string.IsNullOrEmpty(this.item_separator)
                        && (this.array_separator != Const.g_SemicolonSeparator
                        || this.item_separator != Const.g_VerticalLineSeparator))
                    {
                        this.SetDataType(E_ColumnType.Fix_String);

                        return;
                    }

                    this.array_separator = Const.g_SemicolonSeparator;
                    this.item_separator = Const.g_VerticalLineSeparator;
                }
            }
            else if(lineCount > 0)
            {
                if(this.dataType < E_ColumnType.Array_Table)
                    this.array_separator = Const.g_VerticalLineSeparator;
            }   
            else if(semicolonCount > 0)
            {
                if (this.dataType < E_ColumnType.Array_Table)
                    this.array_separator = Const.g_SemicolonSeparator;
            }
        }

        /// <summary>
        /// 设置字段类型数据的分隔符
        /// </summary>
        /// <param name="data"></param>
        public E_ErrorType SetDictionarySeparator(string data)
        {
            E_ErrorType result = E_ErrorType.Success;

            int lineCount = data.IndexOf(Const.g_VerticalLineSeparator);
            int semicolonCount = data.IndexOf(Const.g_SemicolonSeparator);

            if (lineCount > 0 && semicolonCount > 0)
            {
                if (lineCount > semicolonCount)
                {
                    this.array_separator = Const.g_VerticalLineSeparator;
                    this.item_separator = Const.g_SemicolonSeparator;
                }
                else
                {
                    this.array_separator = Const.g_SemicolonSeparator;
                    this.item_separator = Const.g_VerticalLineSeparator;
                }
            }
            else if (lineCount > 0 && semicolonCount <= 0)
            {
                if (this.array_separator == Const.g_VerticalLineSeparator)
                    result = E_ErrorType.DataTypeMismatch;

                this.array_separator = Const.g_SemicolonSeparator;
            }
            else if (semicolonCount > 0 && lineCount <= 0)
            {
                if (this.array_separator == Const.g_SemicolonSeparator)
                    result = E_ErrorType.DataTypeMismatch;

                this.array_separator = Const.g_VerticalLineSeparator;
            }

            return result;
        }

        /// <summary>
        /// 刷新数组长度
        /// </summary>
        /// <param name="data"></param>
        public void UpdateArrayLength(string data)
        {
            if (string.IsNullOrEmpty(data))
                return;

            if (string.IsNullOrEmpty(this.array_separator))
                return;

            if (!data.Contains(this.array_separator))
                return;

            string[] array = data.Split(this.array_separator);
            int len = array.Length;

            /*
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == this.array_separator[0])
                    len++;
            }
            */

            if (len > 0 && this.length < len)
                this.length = len;
        }

        /// <summary>
        /// 解包
        /// </summary>
        /// <returns></returns>
        public static TableColumnInfo Create(string data)
        {
            if (!data.Contains(Const.tab_separator))
                return null;

            string[] array = data.Split(Const.tab_separator);
            if (null == array || array.Length < 7)
            {
                Log.Print("数据类型格式配置错误,请检查: {0}", data);
                ErrorLog.Print("数据类型格式配置错误,请检查: {0}", data);
                return null;
            }

            TableColumnInfo tableColumnInfo = new TableColumnInfo();
            tableColumnInfo.name = array[0];
            tableColumnInfo.alias_name = array[1];
            tableColumnInfo.dataType = (E_ColumnType)Enum.Parse(typeof(E_ColumnType), array[2], true);
            tableColumnInfo.length = int.Parse(array[3]);
            tableColumnInfo.array_separator = array[4];
            tableColumnInfo.item_separator = array[5];
            tableColumnInfo.comment = array[6];

            return tableColumnInfo;
        }

        /// <summary>
        /// 获得FBS字符串
        /// </summary>
        /// <returns></returns>
        public string GetFBS()
        {
            string variableName = string.IsNullOrEmpty(this.alias_name) ? this.name : this.alias_name;
            return string.Format("  {0}:{1};", variableName, this.GetFBSType());
        }

        /// <summary>
        /// 获得字符串;
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.name);
            stringBuilder.Append(Const.tab_separator);
            stringBuilder.Append(this.alias_name);
            stringBuilder.Append(Const.tab_separator);
            stringBuilder.Append(this.dataType);
            stringBuilder.Append(Const.tab_separator);
            stringBuilder.Append(this.length);
            stringBuilder.Append(Const.tab_separator);
            stringBuilder.Append(this.array_separator);
            stringBuilder.Append(Const.tab_separator);
            stringBuilder.Append(this.item_separator);
            stringBuilder.Append(Const.tab_separator);
            stringBuilder.Append(this.comment);

           return  stringBuilder.ToString();
        }

        #endregion

        #region 私有接口

        /// <summary>
        /// 获得FBS类型
        /// </summary>
        /// <returns></returns>
        private string GetFBSType()
        {
            string type = "int";
            switch (dataType)
            {
                case E_ColumnType.Single_Int:
                    {
                        break;
                    }
                case E_ColumnType.Single_Short:
                    {
                        type = "short";
                        break;
                    }
                case E_ColumnType.Single_Bool:
                    {
                        type = "bool";
                        break;
                    }
                case E_ColumnType.Single_Float:
                    {
                        type = "float";
                        break;
                    }
                case E_ColumnType.Single_String:
                case E_ColumnType.Fix_String:
                    {
                        type = "string";
                        break;
                    }
                case E_ColumnType.Single_Table:
                    {
                        type = "string";
                        break;
                    }
                case E_ColumnType.Array_Int:
                    {
                        type = "[int]";
                        break;
                    }
                case E_ColumnType.Array_Short:
                    {
                        type = "[short]";
                        break;
                    }
                case E_ColumnType.Array_bool:
                    {
                        type = "[bool]";
                        break;
                    }
                case E_ColumnType.Array_Float:
                    {
                        type = "[float]";
                        break;
                    }
                case E_ColumnType.Array_String:
                case E_ColumnType.Array_Table:
                case E_ColumnType.Dictionary_II:
                case E_ColumnType.Dictionary_IS:
                case E_ColumnType.Dictionary_SI:
                case E_ColumnType.Dictionary_SS:
                    {
                        type = "[string]";
                        break;
                    }
                default:
                    break;
            }

            return type;
        }

        #endregion
    }
}
