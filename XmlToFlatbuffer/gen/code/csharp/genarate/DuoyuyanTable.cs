﻿// <auto-generated>
//  automatically generated by table tool, do not modify
// </auto-generated>
using System.IO;
using FlatBuffers;
using LF.Table;
using System.Collections.Generic;

namespace LF
{
    #region Table

	public sealed class DuoyuyanTable : BaseTable
    {
        private Table_duoyuyan table = default(Table_duoyuyan);

        private Dictionary<int, DuoyuyanDataRow> data_row = new Dictionary<int, DuoyuyanDataRow>(128);
        
        public static string g_TableFileName = "duoyuyan";

        #region Data Method

        public override bool GetBoolValue(int id, string column, bool defaultValue = false)
        {
            bool result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_duoyuyan.GetBoolValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override short GetShortValue(int id, string column, short defaultValue = 0)
        {
            short result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_duoyuyan.GetShortValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override int GetIntValue(int id, string column, int defaultValue = 0)
        {
            int result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {
                case "id": { result = datarow.Id; break; }
                case "lock": { result = datarow.LockAlies; break; }

                default: { GameFramework.Log.Error("Table_duoyuyan.GetIntValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override float GetFloatValue(int id, string column, float defaultValue = 0.0f)
        {
            float result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {
                case "id": { result = datarow.Id; break; }
                case "lock": { result = datarow.LockAlies; break; }

                default: { GameFramework.Log.Error("Table_duoyuyan.GetFloatValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }

        public override string GetStringValue(int id, string column, string defaultValue = "")
        {
            string result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {
                case "id": { result = datarow.Id.ToString(); break; }
                case "language": { result = datarow.Language; break; }
                case "lock": { result = datarow.LockAlies.ToString(); break; }

                default: { GameFramework.Log.Error("Table_duoyuyan.GetStringValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override bool[] GetBoolArray(int id, string column)
        {
            bool[] result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_duoyuyan.GetBoolArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override short[] GetShortArray(int id, string column)
        {
            short[] result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_duoyuyan.GetShortArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override int[] GetIntArray(int id, string column)
        {
            int[] result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_duoyuyan.GetIntArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override float[] GetFloatArray(int id, string column)
        {
            float[] result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;
                
            switch (column)
            {

                default: { GameFramework.Log.Error("Table_duoyuyan.GetFloatArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }

        public override string[] GetStringArray(int id, string column)
        {
            string[] result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_duoyuyan.GetStringArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override string GetStringArrayItem(int id, string column, int index, string defaultValue = "")
        {
            string result = defaultValue;

            int length = this.GetStringArrayLength(id, column);
            if (index < 0 || index >= length)
            {
                GameFramework.Log.Error("Table_duoyuyan.GetStringArrayItem => index out of array length({0}), [id:{1}, column:{2}, index:{3}]", length, id, column, index);
                return result;
            }
            
            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_duoyuyan.GetStringArrayItem => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override int GetStringArrayLength(int id, string column)
        {
            int result = 0;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_duoyuyan.GetStringArrayLength => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override Dictionary<int, int> GetDictionaryII(int id, string column) 
        {
            Dictionary<int, int> result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_duoyuyan.GetDictionaryII => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }

        public override Dictionary<int, string> GetDictionaryIS(int id, string column) 
        {
            Dictionary<int, string> result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_duoyuyan.GetDictionaryIS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }

        public override Dictionary<string, int> GetDictionarySI(int id, string column) 
        {
            Dictionary<string, int> result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_duoyuyan.GetDictionarySI => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }

        public override Dictionary<string, string> GetDictionarySS(int id, string column) 
        {
            Dictionary<string, string> result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_duoyuyan.GetDictionarySS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }

        #endregion Data Method

        #region DataRow Method
        
        /// <summary>
        /// 获得数据行的数量
        /// </summary>
        /// <returns></returns>
        public override int GetDataCount() 
        {
            Table_duoyuyan table = this.GetTable();
            if (null == table.ByteBuffer)
                return 0;

            return table.DataLength; 
        }
        
        /// <summary>
        /// 获得行数据
        /// </summary>
        /// <param name="id">字段ID的值</param>
        /// <returns>行数据</returns>
        public DuoyuyanDataRow GetDataRow(int id)
        {
            if (data_row.ContainsKey(id))
                return data_row[id];

            Table_duoyuyan table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            if (data_row.Count >= table.DataLength)
                return null;
            
            if (null != row_index && row_index.ContainsKey(id))
            {
                DRduoyuyan? data = table.Data(row_index[id]);
                if (data.HasValue && data.Value.Id == id)
                {
                    DuoyuyanDataRow datarow = new DuoyuyanDataRow(data.Value, row_index[id]);
                    if(!data_row.ContainsKey(datarow.Id))
                        data_row.Add(datarow.Id, datarow);

                    return datarow;
                }
            }

            if (current_row_index >= table.DataLength)
                return null;

            int start = current_row_index;
            for (int i = start; i < table.DataLength; i++)
            {
                DRduoyuyan? data = table.Data(i);
                if (data.HasValue)
                {
                    DuoyuyanDataRow datarow = new DuoyuyanDataRow(data.Value, i);
                    if(!data_row.ContainsKey(datarow.Id))
                        data_row.Add(datarow.Id, datarow);

                    current_row_index = i;
                    
                    if (datarow.Id == id)
                        return datarow;
                }
            }

            return null;
        }

        /// <summary>
        /// 通过索引获取行数据
        /// </summary>
        /// <param name="index">索引,即行号,从0开始</param>
        /// <returns></returns>
        public DuoyuyanDataRow GetDataRowByIndex(int index)
        {
            Table_duoyuyan table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;

            if (index < 0 || index >= table.DataLength)
                return null;

            DRduoyuyan? data = table.Data(index);
            if (data.HasValue)
            {
                if (!data_row.ContainsKey(data.Value.Id))
                {
                    DuoyuyanDataRow datarow = new DuoyuyanDataRow(data.Value, index);
                    data_row.Add(datarow.Id, datarow);
                }

                return data_row[data.Value.Id];
            }

            return null;
        }
        
        /// <summary>
        /// 获得所有行数据
        /// </summary>
        /// <returns>所有行数据</returns>
        public Dictionary<int, DuoyuyanDataRow> GetAllData()
        {
            Table_duoyuyan table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            int dataCount = table.DataLength;
            if (data_row.Count < dataCount)
            {
                for (int i = 0; i < table.DataLength; i++)
                {
                    DRduoyuyan? data = table.Data(i);
                    if (data.HasValue && !data_row.ContainsKey(data.Value.Id))
                    {
                        DuoyuyanDataRow datarow = new DuoyuyanDataRow(data.Value, i);
                        data_row.Add(data.Value.Id, datarow);
                    }
                }
            }

            return data_row;
        }
        
        /// <summary>
        /// 按行遍历表格
        /// </summary>
        /// <param name="callback"></param>
        public override void VisitTable(System.Func<BaseDataRow, bool> callback)
        {
            if (null == callback)
                return;

            this.GetAllData();

            var iterator = data_row.GetEnumerator();
            try
            {
                bool _stop = false;
                while (iterator.MoveNext() && _stop == false)
                {
                    _stop = callback(iterator.Current.Value);
                }
            }
            finally
            {
                iterator.Dispose();
            }
        }
        
        public override BaseDataRow GetTableRow(int id) 
        { 
            return this.GetDataRow(id); 
        }

        public override BaseDataRow GetTableRow(string id)
        {
            int rowId = 0;
            if(int.TryParse(id, out rowId))
                return this.GetDataRow(rowId);

            return null;
        }

        public override BaseDataRow GetTableRowByIndex(int index)
        {
            return this.GetDataRowByIndex(index);
        }

        #endregion DataRow Method
        
        #region Framework Method

        protected override void InitTable(ByteBuffer byteBuffer)
        {
            table = Table_duoyuyan.GetRootAsTable_duoyuyan(byteBuffer);
            
            this.load_state = E_LoadState.Loaded;
        }

        public override void ResetTable()
        {
            base.ResetTable();

            this.data_row.Clear();
        }
        
        private Table_duoyuyan GetTable()
        {
            LoadTable();

            return table;
        }
        
        protected override string GetTableFileName()
        {
            return g_TableFileName;
        }

        protected override string GetDataFileName()
        {
            return "duoyuyan.bytes";
        }

        protected override string GetIndexFileName()
        {
            return "duoyuyan_ids";
        }
        
        #endregion Framework Method
    }

    #endregion Table

    #region DataRow

    public class DuoyuyanBaseDataRow : BaseDataRow
    {
        protected DRduoyuyan _datarow;

        public DuoyuyanBaseDataRow(DRduoyuyan datarow, int index) : base(index)
        {
            this._datarow = datarow;
        }
        
        public override CSLuaTable GetLuaTable()
        {
            base.GetLuaTable();

            if (_LuaDataRow.Length <= 0)
            {
                if(this.HasKey("id")) _LuaDataRow.Set("id", this.Id);
                if(this.HasKey("language")) _LuaDataRow.Set("language", this.Language);
                if(this.HasKey("lock")) _LuaDataRow.Set("lock", this.LockAlies);

            }

            return _LuaDataRow;
        }

        protected override LuaValue GetLuaValue(string rowId)
        {
            LuaValue luaValue = new LuaValue();
            switch (rowId)
            {
                case "id": { luaValue.SetValue(this.Id); break; }
                case "language": { luaValue.SetValue(this.Language); break; }
                case "lock": { luaValue.SetValue(this.LockAlies); break; }

                default:
                    break;
            }

            return luaValue;
        }
        
        public override bool HasKey(string column)
        {
            bool result = false;

            switch (column)
            {
                case "id": { result = !this.IsEmpty(_datarow.Id); break; }
                case "language": { result = !this.IsEmpty(this.Language); break; }
                case "lock": { result = !this.IsEmpty(_datarow.LockAlies); break; }

                default:
                    break;
            }

            return result;
        }
        
        public int Id { get { return this.GetTableInt(_datarow.Id); } }

        private string _Language = null;
        public string Language { get { if (null == _Language) _Language = _datarow.Language; return _Language; } }

        public int LockAlies { get { return this.GetTableInt(_datarow.LockAlies); } }


    }

    #endregion DataRow
}