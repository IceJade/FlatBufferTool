﻿// <auto-generated>
//  automatically generated by table tool, do not modify
// </auto-generated>
using System.IO;
using FlatBuffers;
using Chanto.Table;
using System.Collections.Generic;

namespace Chanto.Table
{
    #region Table
    
	public sealed class SoundTable : StringIdTable
    {
        private Table_sound table = default(Table_sound);

        private Dictionary<string, SoundDataRow> data_row = new Dictionary<string, SoundDataRow>(128);
        
        public static string g_TableFileName = "sound";

        #region Data Method

        public override bool GetBoolValue(string id, string column, bool defaultValue = false)
        {
            bool result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_sound.GetBoolValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override short GetShortValue(string id, string column, short defaultValue = 0)
        {
            short result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_sound.GetShortValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override int GetIntValue(string id, string column, int defaultValue = 0)
        {
            int result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {
                case "loop": { result = datarow.Loop; break; }
                case "maxDistance": { result = datarow.MaxDistance; break; }
                case "priority": { result = datarow.Priority; break; }

                default: { Log.Error("Table_sound.GetIntValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override float GetFloatValue(string id, string column, float defaultValue = 0.0f)
        {
            float result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {
                case "loop": { result = datarow.Loop; break; }
                case "maxDistance": { result = datarow.MaxDistance; break; }
                case "priority": { result = datarow.Priority; break; }
                case "volume": { result = datarow.Volume; break; }

                default: { Log.Error("Table_sound.GetFloatValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }

        public override string GetStringValue(string id, string column, string defaultValue = "")
        {
            string result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {
                case "id": { result = datarow.Id; break; }
                case "loop": { result = datarow.Loop.ToString(); break; }
                case "maxDistance": { result = datarow.MaxDistance.ToString(); break; }
                case "priority": { result = datarow.Priority.ToString(); break; }
                case "volume": { result = datarow.Volume.ToString(); break; }

                default: { Log.Error("Table_sound.GetStringValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }

        public override bool[] GetBoolArray(string id, string column)
        {
            bool[] result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_sound.GetBoolArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override short[] GetShortArray(string id, string column)
        {
            short[] result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_sound.GetShortArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override int[] GetIntArray(string id, string column)
        {
            int[] result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_sound.GetIntArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override float[] GetFloatArray(string id, string column)
        {
            float[] result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_sound.GetFloatArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }

        public override string[] GetStringArray(string id, string column)
        {
            string[] result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_sound.GetStringArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override string GetStringArrayItem(string id, string column, int index, string defaultValue = "")
        {
            string result = defaultValue;

            int length = this.GetStringArrayLength(id, column);
            if (index < 0 || index >= length)
            {
                Log.Error("Table_sound.GetStringArrayItem => index out of array length({0}), [id:{1}, column:{2}, index:{3}]", length, id, column, index);
                return result;
            }
            
            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_sound.GetStringArrayItem => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override int GetStringArrayLength(string id, string column)
        {
            int result = 0;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_sound.GetStringArrayLength => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override Dictionary<int, int> GetDictionaryII(string id, string column) 
        {
            Dictionary<int, int> result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_sound.GetDictionaryII => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }

        public override Dictionary<int, string> GetDictionaryIS(string id, string column) 
        {
            Dictionary<int, string> result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_sound.GetDictionaryIS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }

        public override Dictionary<string, int> GetDictionarySI(string id, string column) 
        {
            Dictionary<string, int> result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_sound.GetDictionarySI => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }

        public override Dictionary<string, string> GetDictionarySS(string id, string column) 
        {
            Dictionary<string, string> result = null;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_sound.GetDictionarySS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
            Table_sound table = this.GetTable();
            if (null == table.ByteBuffer)
                return 0;

            return table.DataLength; 
        }
        
        /// <summary>
        /// 获得行数据
        /// </summary>
        /// <param name="id">字段ID的值</param>
        /// <returns>行数据</returns>
        public SoundDataRow GetDataRow(string id)
        {
            if (data_row.ContainsKey(id))
                return data_row[id];

            Table_sound table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            if (data_row.Count >= table.DataLength)
                return null;
            
            int hashcode = id.GetHashCode();
            if (null != row_index && row_index.ContainsKey(hashcode))
            {
                DRsound? data = table.Data(row_index[hashcode]);
                if (data.HasValue && data.Value.Id == id)
                {
                    SoundDataRow datarow = new SoundDataRow(data.Value, row_index[hashcode]);
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
                DRsound? data = table.Data(i);
                if (data.HasValue)
                {
                    SoundDataRow datarow = new SoundDataRow(data.Value, i);
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
        public SoundDataRow GetDataRowByIndex(int index)
        {
            Table_sound table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;

            if (index < 0 || index >= table.DataLength)
                return null;

            DRsound? data = table.Data(index);
            if (data.HasValue)
            {
                if (!data_row.ContainsKey(data.Value.Id))
                {
                    SoundDataRow datarow = new SoundDataRow(data.Value, index);
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
        public Dictionary<string, SoundDataRow> GetAllData()
        {
            this.LoadTable();

            Table_sound table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            int dataCount = table.DataLength;
            if (data_row.Count < dataCount)
            {
                for (int i = 0; i < table.DataLength; i++)
                {
                    DRsound? data = table.Data(i);
                    if (data.HasValue && !data_row.ContainsKey(data.Value.Id))
                    {
                        SoundDataRow datarow = new SoundDataRow(data.Value, i);
                        data_row.Add(data.Value.Id, datarow);
                    }
                }
            }

            return data_row;
        }

        /// <summary>
        /// Lua侧获得所有数据
        /// </summary>
        /// <returns></returns>
        public override CSLuaTable[] GetAllLuaData()
        {
            if (null != _LuaData)
                return _LuaData;

            int index = 0;
            var datas = this.GetAllData();
            foreach (var item in datas)
            {
                if (null != item.Value)
                {
                    _LuaData[index] = item.Value.GetLuaTable();
                    index++;
                }
            }

            return _LuaData;
        }

        public override BaseDataRow GetTableRow(string id) 
        { 
            return this.GetDataRow(id); 
        }

        public override BaseDataRow GetTableRowByIndex(int index)
        {
            return this.GetDataRowByIndex(index);
        }

        #endregion DataRow Method
                
        #region Framework Method

        protected override void InitTable(ByteBuffer byteBuffer)
        {
            table = Table_sound.GetRootAsTable_sound(byteBuffer);
            
            this.load_state = E_LoadState.Loaded;
        }

        public override void ResetTable()
        {
            base.ResetTable();

            this.data_row.Clear();
        }
        
        private Table_sound GetTable()
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
            return "sound.bytes";
        }

        protected override string GetIndexFileName()
        {
            return "sound_ids";
        }
        
        #endregion Framework Method
    }

    #endregion Table

    #region DataRow

    public class SoundBaseDataRow : BaseDataRow
    {
        protected DRsound _datarow;

        public SoundBaseDataRow(DRsound datarow, int index) : base(index)
        {
            this._datarow = datarow;
        }

        public override CSLuaTable GetLuaTable()
        {
            base.GetLuaTable();

            if (_LuaDataRow.Length <= 0)
            {
                if(this.HasKey("id")) _LuaDataRow.Set("id", this.Id);
                if(this.HasKey("loop")) _LuaDataRow.Set("loop", this.Loop);
                if(this.HasKey("maxDistance")) _LuaDataRow.Set("maxDistance", this.MaxDistance);
                if(this.HasKey("priority")) _LuaDataRow.Set("priority", this.Priority);
                if(this.HasKey("volume")) _LuaDataRow.Set("volume", this.Volume);

            }

            return _LuaDataRow;
        }

        protected override LuaValue GetLuaValue(string rowId)
        {
            LuaValue luaValue = new LuaValue();
            switch (rowId)
            {
                case "id": { luaValue.SetValue(this.Id); break; }
                case "loop": { luaValue.SetValue(this.Loop); break; }
                case "maxDistance": { luaValue.SetValue(this.MaxDistance); break; }
                case "priority": { luaValue.SetValue(this.Priority); break; }
                case "volume": { luaValue.SetValue(this.Volume); break; }

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
                case "id": { result = !this.IsEmpty(this.Id); break; }
                case "loop": { result = !this.IsEmpty(_datarow.Loop); break; }
                case "maxDistance": { result = !this.IsEmpty(_datarow.MaxDistance); break; }
                case "priority": { result = !this.IsEmpty(_datarow.Priority); break; }
                case "volume": { result = !this.IsEmpty(_datarow.Volume); break; }

                default:
                    break;
            }

            return result;
        }

        private string _Id = null;
        public string Id { get { if (null == _Id) _Id = _datarow.Id; return _Id; } }

        public int Loop { get { return this.GetTableInt(_datarow.Loop); } }

        public int MaxDistance { get { return this.GetTableInt(_datarow.MaxDistance); } }

        public int Priority { get { return this.GetTableInt(_datarow.Priority); } }

        public float Volume { get { return this.GetTableFloat(_datarow.Volume); } }


    }

    #endregion DataRow
}