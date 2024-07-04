﻿// <auto-generated>
//  automatically generated by table tool, do not modify
// </auto-generated>
using System;
using System.Collections.Generic;
using UnityGameFramework.Runtime;

namespace LF
{
	public class TableManager : Singleton<TableManager>
    {
        private Dictionary<string, byte[]> dataTableAssets = new Dictionary<string, byte[]>(100);
        public Dictionary<string, byte[]> DataTableAssets { get { return dataTableAssets; } }

        private Dictionary<string, BaseTable> dataTables = new Dictionary<string, BaseTable>(100);

        private Dictionary<Type, string> nameCache = new Dictionary<Type, string>(200);

        private bool[] default_bool = new bool[0];
        private short[] default_short = new short[0];
        private int[] default_int = new int[0];
        private float[] default_float = new float[0];
        private string[] default_string = new string[0];

        #region Data Method

        public bool GetBool(string tableName, string id, string column, bool defaultValue = false)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return defaultValue;

            return dataTable.GetBoolValue(id, column, defaultValue);
        }

        public bool[] GetBoolArray(string tableName, string id, string column)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return default_bool;

            var result = dataTable.GetBoolArray(id, column);
            if (null == result)
                return default_bool;

            return result;
        }
        
        public short GetShort(string tableName, string id, string column, short defaultValue = 0)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return defaultValue;

            return dataTable.GetShortValue(id, column, defaultValue);
        }

        public short[] GetShortArray(string tableName, string id, string column)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return default_short;

            var result = dataTable.GetShortArray(id, column);
            if (null == result)
                return default_short;

            return result;
        }
        
        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public int GetInt(string tableName, string id, string column, int defaultValue = 0)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return defaultValue;

            return dataTable.GetIntValue(id, column, defaultValue);
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public int[] GetIntArray(string tableName, string id, string column) 
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return default_int;

            var result = dataTable.GetIntArray(id, column);
            if (null == result)
                return default_int;

            return result;
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public float GetFloat(string tableName, string id, string column, float defaultValue = 0.0f) 
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return defaultValue;

            return dataTable.GetFloatValue(id, column, defaultValue);
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public float[] GetFloatArray(string tableName, string id, string column) 
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return default_float;

            var result = dataTable.GetFloatArray(id, column);
            if (null == result)
                return default_float;

            return result;
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public string GetString(string tableName, string id, string column, string defaultValue = "") 
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return defaultValue;

            return dataTable.GetStringValue(id, column, defaultValue);
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public int GetStringArrayLength(string tableName, string id, string column) 
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return 0;

            return dataTable.GetStringArrayLength(id, column);
        }
        
        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public string[] GetStringArray(string tableName, string id, string column) 
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return default_string;

            var result = dataTable.GetStringArray(id, column);
            if (null == result)
                return default_string;

            return result;
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public string GetStringArrayItem(string tableName, string id, string column, int index, string defaultValue = "") 
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return defaultValue;

            return dataTable.GetStringArrayItem(id, column, index, defaultValue);
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public int GetInt(string tableName, int id, string column, int defaultValue = 0)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return defaultValue;

            return dataTable.GetIntValue(id, column, defaultValue);
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public int[] GetIntArray(string tableName, int id, string column)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return default_int;

            var result = dataTable.GetIntArray(id, column);
            if (null == result)
                return default_int;

            return result;
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public float GetFloat(string tableName, int id, string column, float defaultValue = 0.0f)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return defaultValue;

            return dataTable.GetFloatValue(id, column, defaultValue);
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public float[] GetFloatArray(string tableName, int id, string column)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return default_float;

            var result = dataTable.GetFloatArray(id, column);
            if (null == result)
                return default_float;

            return result;
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public string GetString(string tableName, int id, string column, string defaultValue = "")
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return defaultValue;

            return dataTable.GetStringValue(id, column, defaultValue);
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public int GetStringArrayLength(string tableName, int id, string column)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return 0;

            return dataTable.GetStringArrayLength(id, column);
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public string[] GetStringArray(string tableName, int id, string column)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return default_string;

            var result = dataTable.GetStringArray(id, column);
            if (null == result)
                return default_string;

            return result;
        }
        
        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public string GetStringArrayItem(string tableName, int id, string column, int index, string defaultValue = "")
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return defaultValue;

            return dataTable.GetStringArrayItem(id, column, index, defaultValue);
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public Dictionary<int, int> GetDictionaryII(string tableName, int id, string column)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return null;

            return dataTable.GetDictionaryII(id, column);
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public Dictionary<int, string> GetDictionaryIS(string tableName, int id, string column)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return null;

            return dataTable.GetDictionaryIS(id, column);
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public Dictionary<string, int> GetDictionarySI(string tableName, int id, string column)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return null;

            return dataTable.GetDictionarySI(id, column);
        }

        //[Obsolete("This function is not recommended, you can call GetDataRow<T>")]
        public Dictionary<string, string> GetDictionarySS(string tableName, int id, string column)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return null;

            return dataTable.GetDictionarySS(id, column);
        }
        
        #endregion Data Method
        
        #region Table Method

        /// <summary>
        /// 获得表
        /// </summary>
        /// <typeparam name="T">继承自BaseTable的表类型</typeparam>
        /// <returns>表对象</returns>
        public T GetTable<T>() where T : BaseTable, new()
        {
            Type type = typeof(T);
            
            string tableName;
            if (!nameCache.TryGetValue(type, out tableName))
            {
                string typeName = type.Name;
                int index = typeName.LastIndexOf("Table");
                if (index <= 0)
                {
                    GameFramework.Log.Error("The T must inherit from BaseTable");
                    return null;
                }

                tableName = typeName.Substring(0, index);

                if (!this.IsValidTable(tableName))
                    tableName = this.LowerFirstChar(tableName);

                if (!this.IsValidTable(tableName))
                {
                    GameFramework.Log.Error("Can not find {0}, please check.", typeName);
                    return null;
                }

                if (!nameCache.ContainsKey(type))
                    nameCache.Add(type, tableName);
            }
            
#if UNITY_EDITOR
            GameEntry.CheckTableLoad(tableName);
#endif

            if (!this.dataTables.ContainsKey(tableName))
                this.dataTables.Add(tableName, new T());

            return (T)this.dataTables[tableName];
        }
        
        /// <summary>
        /// 按行遍历表格
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="callback"></param>
        public void dumpTable(string tableName, System.Func<BaseDataRow, bool> callback)
        {
            var table = this.GetTable(tableName);
            if (null == table)
                return;

            table.VisitTable(callback);
        }

        /// <summary>
        /// Lua侧获得所有表数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public CSLuaTable[] GetAllDataRows(string tableName)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return null;

            return dataTable.GetAllLuaData();
        }
        
        /// <summary>
        /// 获得表数据的条数
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <returns></returns>
        public int GetDataCount(string tableName)
        {
            BaseTable dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return 0;

            return dataTable.GetDataCount();
        }
        
        #endregion Table Method

        #region DataRow Method

        /// <summary>
        /// 判断表的数据行是否存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool HasDataRow<T>(int id) where T : BaseDataRow
        {
            Type type = typeof(T);
            
            string tableName;
            if(!nameCache.TryGetValue(type, out tableName))
            {
                string typeName = type.Name;
                int index = typeName.LastIndexOf("DataRow");
                if (index <= 0)
                {
                    GameFramework.Log.Error("The T must inherit from BaseDataRow");
                    return false;
                }

                tableName = typeName.Substring(0, index);

                if (!this.IsValidTable(tableName))
                    tableName = this.LowerFirstChar(tableName);

                if (!this.IsValidTable(tableName))
                {
                    GameFramework.Log.Error("Can not find {0}, please check.", typeName);
                    return false;
                }
                
                if(!nameCache.ContainsKey(type))
                    nameCache.Add(type, tableName);
            }

            BaseTable table = this.GetTable(tableName);
            if (null != table)
                return table.HasDataRow(id);

            return false;
        }

        /// <summary>
        /// 判断表的数据行是否存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool HasDataRow<T>(string id) where T : BaseDataRow
        {
            Type type = typeof(T);
            
            string tableName;
            if(!nameCache.TryGetValue(type, out tableName))
            {
                string typeName = type.Name;

                int index = typeName.LastIndexOf("DataRow");
                if (index <= 0)
                {
                    GameFramework.Log.Error("The T must inherit from BaseDataRow");
                    return false;
                }

                tableName = typeName.Substring(0, index);

                if (!this.IsValidTable(tableName))
                    tableName = this.LowerFirstChar(tableName);

                if (!this.IsValidTable(tableName))
                {
                    GameFramework.Log.Error("Can not find {0}, please check.", typeName);
                    return false;
                }
                
                if(!nameCache.ContainsKey(type))
                    nameCache.Add(type, tableName);
            }
            
            BaseTable table = this.GetTable(tableName);
            if (null != table)
                return table.HasDataRow(id);

            return false;
        }
        
        /// <summary>
        /// 获得表的数据行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetDataRow<T>(int id) where T : BaseDataRow
        {
            Type type = typeof(T);
            
            string tableName;
            if(!nameCache.TryGetValue(type, out tableName))
            {
                string typeName = type.Name;
                int index = typeName.LastIndexOf("DataRow");
                if (index <= 0)
                {
                    GameFramework.Log.Error("The T must inherit from BaseDataRow");
                    return null;
                }

                tableName = typeName.Substring(0, index);

                if (!this.IsValidTable(tableName))
                    tableName = this.LowerFirstChar(tableName);

                if (!this.IsValidTable(tableName))
                {
                    GameFramework.Log.Error("Can not find {0}, please check.", typeName);
                    return null;
                }
                
                if(!nameCache.ContainsKey(type))
                    nameCache.Add(type, tableName);
            }
            
            BaseTable table = this.GetTable(tableName);
            if (null != table)
                return (T)table.GetTableRow(id);

            return null;
        }

        /// <summary>
        /// 获得表的数据行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetDataRow<T>(string id) where T : BaseDataRow
        {
            Type type = typeof(T);
            
            string tableName;
            if(!nameCache.TryGetValue(type, out tableName))
            {
                string typeName = typeof(T).Name;
                int index = typeName.LastIndexOf("DataRow");
                if (index <= 0)
                {
                    GameFramework.Log.Error("The T must inherit from BaseDataRow");
                    return null;
                }

                tableName = typeName.Substring(0, index);

                if (!this.IsValidTable(tableName))
                    tableName = this.LowerFirstChar(tableName);

                if (!this.IsValidTable(tableName))
                {
                    GameFramework.Log.Error("Can not find {0}, please check.", typeName);
                    return null;
                }
                
                if(!nameCache.ContainsKey(type))
                    nameCache.Add(type, tableName);
            }
            
            BaseTable table = this.GetTable(tableName);
            if (null != table)
                return (T)table.GetTableRow(id);

            return null;
        }

        /// <summary>
        /// 根据行号获得表的数据行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index">行号,从0开始</param>
        /// <returns></returns>
        public T GetDataRowByIndex<T>(int index) where T : BaseDataRow
        {
            Type type = typeof(T);

            string tableName;
            if (!nameCache.TryGetValue(type, out tableName))
            {
                string typeName = typeof(T).Name;
                int tmpIndex = typeName.LastIndexOf("DataRow");
                if (tmpIndex <= 0)
                {
                    GameFramework.Log.Error("The T must inherit from BaseDataRow");
                    return null;
                }

                tableName = typeName.Substring(0, tmpIndex);

                if (!this.IsValidTable(tableName))
                    tableName = this.LowerFirstChar(tableName);

                if (!this.IsValidTable(tableName))
                {
                    GameFramework.Log.Error("Can not find {0}, please check.", typeName);
                    return null;
                }

                if (!nameCache.ContainsKey(type))
                    nameCache.Add(type, tableName);
            }

            BaseTable table = this.GetTable(tableName);
            if (null != table)
                return (T)table.GetTableRowByIndex(index);

            return null;
        }
        
        /// <summary>
        /// Lua侧获得行数据(为了兼容Lua老接口而设计,会使行数据产生两份内存,不建议使用)
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="id">行ID</param>
        /// <returns></returns>
        public CSLuaTable GetDataRow(string tableName, int id)
        {
            var dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return null;

            var dataRow = dataTable.GetTableRow(id);
            if (null == dataRow)
                return null;

            return dataRow.GetLuaTable();
        }

        /// <summary>
        /// Lua侧获得行数据(为了兼容Lua老接口而设计,会使行数据产生两份内存,不建议使用)
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="id">行ID</param>
        /// <returns></returns>
        public CSLuaTable GetDataRow(string tableName, string id)
        {
            var dataTable = this.GetTable(tableName);
            if (null == dataTable)
                return null;

            var dataRow = dataTable.GetTableRow(id);
            if (null == dataRow)
                return null;

            return dataRow.GetLuaTable();
        }

        /// <summary>
        /// 根据Id获得数据行(Lua侧获取行数据建议使用此接口)
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="id"></param>
        public BaseDataRow GetDataRowById(string tableName, int id)
        {
            var table = this.GetTable(tableName);
            if (null == table)
                return null;

            return table.GetTableRow(id);
        }

        /// <summary>
        /// 根据Id获得数据行(Lua侧获取行数据建议使用此接口)
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="id"></param>
        public BaseDataRow GetDataRowById(string tableName, string id)
        {
            var table = this.GetTable(tableName);
            if (null == table)
                return null;

            return table.GetTableRow(id);
        }

        /// <summary>
        /// 根据行号获得数据行(Lua侧获取行数据建议使用此接口)
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="index"></param>
        public BaseDataRow GetDataRowByIndex(string tableName, int index)
        {
            var table = this.GetTable(tableName);
            if (null == table)
                return null;

            return table.GetTableRowByIndex(index);
        }

        #endregion DataRow Method

        #region Framework Method
        
        /// <summary>
        /// 重置所有表
        /// </summary>
        public void ResetAllTable()
        {
            foreach(var table in this.dataTables)
            {
                if (null != table.Value)
                    table.Value.ResetTable();
            }
        }
        
        /// <summary>
        /// 根据表名获得表对象
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>表对象</returns>
        private BaseTable GetTable(string tableName)
        {
#if UNITY_EDITOR
            GameEntry.CheckTableLoad(tableName);
#endif

            BaseTable table = null;
            if (this.dataTables.TryGetValue(tableName, out table) && null != table)
                return table;
            
            if (!this.IsValidTable(tableName))
            {
                GameFramework.Log.Error("Can not find the table {0}", tableName);
                return null;
            }
            
            if (!this.dataTables.ContainsKey(tableName))
            {
                string tableType = string.Format("LF.{0}Table", this.UpperFirstChar(tableName));
                table = (BaseTable)Activator.CreateInstance(Type.GetType(tableType));

                this.dataTables.Add(tableName, table);
            }
            
            return this.dataTables[tableName];
        }

        /// <summary>
        /// 将字符串的首字母大写
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns></returns>
        private string UpperFirstChar(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            if (input.Length <= 1)
                return input.ToUpperInvariant();
            else
                return input.Substring(0, 1).ToUpperInvariant() + input.Substring(1);
        }

        /// <summary>
        /// 将字符串的首字母大写
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns></returns>
        private string LowerFirstChar(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            if (input.Length <= 1)
                return input.ToUpperInvariant();
            else
                return input.Substring(0, 1).ToLowerInvariant() + input.Substring(1);
        }

        /// <summary>
        /// 判断表名是否合法
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>true-合法, false-不合法</returns>
        public bool IsValidTable(string tableName)
        {
            bool isValid = false;

            switch (tableName)
            {
                case "building": { isValid = true; break; }
                case "duoyuyan": { isValid = true; break; }
                case "goods": { isValid = true; break; }
                case "heroes": { isValid = true; break; }
                case "heroes_camp": { isValid = true; break; }
                case "heroes_levelup": { isValid = true; break; }
                case "heroes_quality": { isValid = true; break; }
                case "mail": { isValid = true; break; }
                case "movie": { isValid = true; break; }
                case "pve": { isValid = true; break; }
                case "quest": { isValid = true; break; }
                case "science": { isValid = true; break; }
                case "score": { isValid = true; break; }
                case "skill": { isValid = true; break; }
                case "sound": { isValid = true; break; }
                case "vip": { isValid = true; break; }

                default:{ isValid = ConfigManager.Instance.IsValidTable(tableName); break; }
            }

            return isValid;
        }
        
        #endregion Framework Method
    }
}