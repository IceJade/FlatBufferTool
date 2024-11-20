// <auto-generated>
//  automatically generated by table tool, do not modify
// </auto-generated>
using System.IO;
using FlatBuffers;
using Chanto.Table;
using System.Collections.Generic;
using System;
using XLua;
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;

namespace Chanto.Table
{
    /// <summary>
    /// 封装的数据类型,根据不同数据取不同的字段
    /// </summary>
    public struct LuaValue
    {
        public byte type;
        public bool bValue;
        public int nValue;
        public float fValue;
        public object objValue;

        public bool isEmpty()
        {
            if (type == 0x00)
                return true;
            return false;
        }

        public void SetValue(int value)
        {
            this.type = 1;
            this.nValue = value;
        }

        public void SetValue(float value)
        {
            this.type = 2;
            this.fValue = value;
        }

        public void SetValue(string value)
        {
            this.type = 3;
            this.objValue = value;
        }

        public void SetValue(int[] value)
        {
            this.type = 4;
            this.objValue = value;
        }

        public void SetValue(float[] value)
        {
            this.type = 5;
            this.objValue = value;
        }

        public void SetValue(string[] value)
        {
            this.type = 6;
            this.objValue = value;
        }

        public void SetValue(Dictionary<int, int> value)
        {
            this.type = 7;
            this.objValue = value;
        }

        public void SetValue(Dictionary<int, string> value)
        {
            this.type = 8;
            this.objValue = value;
        }

        public void SetValue(Dictionary<string, int> value)
        {
            this.type = 9;
            this.objValue = value;
        }

        public void SetValue(Dictionary<string, string> value)
        {
            this.type = 10;
            this.objValue = value;
        }

        public void SetValue(bool value)
        {
            this.type = 11;
            this.bValue = value;
        }
    }

    public class BaseDataRow
    {
        /// <summary>
        /// 行索引
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 数据转化为LuaTable
        /// </summary>
        protected CSLuaTable _LuaDataRow;

        public BaseDataRow(int index)
        {
            this.Index = index;
        }

        public virtual CSLuaTable GetLuaTable()
        {
            if (null == _LuaDataRow)
                _LuaDataRow = new CSLuaTable();

            return _LuaDataRow;
        }

        public virtual bool HasKey(string rowId)
        {
            return false;
        }

        #region 类型转换
        /*
        *  下面的接口主要用于处理默认值的情况:
        *  原因: 为数字类型(int\float)的列，如果表格里为空字符串,那么会以int.MinValue和float.MinValue来赋值(因为0和-1已经有用途了),故如果转换成字符串时需要特殊处理一下;
        *  转换说明如下:
        *  ToString:    如果int或者float值为MinValue时，返回值为空字符串""
        */

        /// <summary>
        /// 将整型转换成原来表格中的字符串
        /// </summary>
        /// <param name="value">整型数据</param>
        /// <returns></returns>
        protected string GetTableString(int value)
        {
            if (value == int.MinValue)
                return "";

            return value.ToString();
        }

        /// <summary>
        /// 将字符串类型值转换成原表格中的字符串
        /// </summary>
        /// <param name="value">浮点类型值</param>
        /// <returns></returns>
        protected string GetTableString(float value)
        {
            if (value < float.MinValue + 0.0000001)
                return "";

            return value.ToString();
        }

        /// <summary>
        /// 将表中配置的整型数据类型进行转换
        /// </summary>
        /// <param name="value">整型数据</param>
        /// <returns></returns>
        protected int GetTableInt(int value)
        {
            return value != int.MinValue ? value : 0;
        }

        /// <summary>
        /// 将表中配置的浮点数据类型进行转换
        /// </summary>
        /// <param name="value">整型数据</param>
        /// <returns></returns>
        protected float GetTableFloat(float value)
        {
            return value < float.MinValue + 0.0000001 ? 0 : value;
        }

        /// <summary>
        /// 整型数据在表中的原始数据是否为空字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected bool IsEmpty(int value)
        {
            return value == int.MinValue;
        }

        /// <summary>
        /// 浮点数据在表中的原始数据是否为空字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected bool IsEmpty(float value)
        {
            return value == float.MinValue;
        }

        /// <summary>
        /// 字符串在表中的原始数据是否为空字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected bool IsEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        protected bool IsEmpty(int[] value)
        {
            return null == value || value.Length <= 0;
        }

        protected bool IsEmpty(float[] value)
        {
            return null == value || value.Length <= 0;
        }

        protected bool IsEmpty(string[] value)
        {
            return null == value || value.Length <= 0;
        }

        protected bool IsEmpty(Dictionary<int, int> value)
        {
            return null == value || value.Count <= 0;
        }

        protected bool IsEmpty(Dictionary<int, string> value)
        {
            return null == value || value.Count <= 0;
        }

        protected bool IsEmpty(Dictionary<string, int> value)
        {
            return null == value || value.Count <= 0;
        }

        protected bool IsEmpty(Dictionary<string, string> value)
        {
            return null == value || value.Count <= 0;
        }

        #endregion 类型转换

        /// <summary>
        /// 在C#内部对数据进行处理,返回封装好的luaValue类型
        /// </summary>
        /// <returns></returns>
        protected virtual LuaValue GetLuaValue(string rowId)
        {
            return new LuaValue();
        }

        public void GetValue(string rowId)
        {
            RealStatePtr realStatePtr = LuaManager.Instance.LuaEnv.L;
            if (realStatePtr == null)
                return;
            LuaValue _luaValue = GetLuaValue(rowId);
            switch (_luaValue.type)
            {
                case 1: //int
                {
                    LuaAPI.xlua_pushinteger(realStatePtr, _luaValue.nValue);
                }
                    break;
                case 2: //float
                {
                    LuaAPI.lua_pushnumber(realStatePtr, _luaValue.fValue);
                }
                    break;
                case 3: //string
                {
                    LuaAPI.lua_pushstring(realStatePtr, (string)_luaValue.objValue);
                }
                    break;
                case 4: //int array
                case 5: //float array
                case 6: //string array
                case 7: //dicII
                case 8: //dicIS
                case 9: //dicSI
                case 10://dicSS
                {
                    LuaTable _luaTable = ConvertDataToLuaTable.ConvertToLuaTable(_luaValue);
                    ObjectTranslator translator = LuaManager.Instance.LuaEnv.translator;
                    translator.Push(realStatePtr, _luaTable);
                }
                    break;
                case 11://bool;
                    {
                        LuaAPI.lua_pushboolean(realStatePtr, _luaValue.bValue);
                    }
                    break;
                default:
                {
                    LuaAPI.lua_pushstring(realStatePtr, "");
                }
                    break;
            } 
        }

        public int GetIntValue(string rowId, int defaultValue = 0)
        {
            LuaValue _luaValue = GetLuaValue(rowId);
            if (_luaValue.isEmpty())
                return defaultValue;
            switch (_luaValue.type)
            {
                case 1:
                    return _luaValue.nValue;
                    break;
                case 2:
                    return (int) _luaValue.fValue;
                    break;
                case 3:
                    return _luaValue.objValue.ToInt();
                    break;
                default:
                    return defaultValue;
                    break;
            }
        }

    }
}