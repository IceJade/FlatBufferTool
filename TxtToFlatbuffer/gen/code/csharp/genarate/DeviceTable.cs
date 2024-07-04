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
    
	public sealed class DeviceTable : StringIdConfig
    {
        private Table_device table = default(Table_device);

        private Dictionary<string, DeviceDataRow> data_row = new Dictionary<string, DeviceDataRow>(128);
        
        public static string g_TableFileName = "device";

        #region Data Method

        public override bool GetBoolValue(string id, string column, bool defaultValue = false)
        {
            bool result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_device.GetBoolValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "ModeType": { result = datarow.ModeType; break; }
                case "RenderLevel": { result = datarow.RenderLevel; break; }

                default: { GameFramework.Log.Error("Table_device.GetShortValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_device.GetIntValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_device.GetFloatValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "Id": { result = datarow.Id; break; }

                default: { GameFramework.Log.Error("Table_device.GetStringValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_device.GetBoolArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_device.GetShortArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_device.GetIntArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_device.GetFloatArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_device.GetStringArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override string GetStringArrayItem(string id, string column, int index, string defaultValue = "")
        {
            string result = defaultValue;

            int length = this.GetStringArrayLength(id, column);
            if (index < 0 || index >= length)
            {
                GameFramework.Log.Error("Table_device.GetStringArrayItem => index out of array length({0}), [id:{1}, column:{2}, index:{3}]", length, id, column, index);
                return result;
            }
            
            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_device.GetStringArrayItem => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_device.GetStringArrayLength => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_device.GetDictionaryII => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_device.GetDictionaryIS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_device.GetDictionarySI => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_device.GetDictionarySS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
            Table_device table = this.GetTable();
            if (null == table.ByteBuffer)
                return 0;

            return table.DataLength; 
        }
        
        /// <summary>
        /// 获得行数据
        /// </summary>
        /// <param name="id">字段ID的值</param>
        /// <returns>行数据</returns>
        public DeviceDataRow GetDataRow(string id)
        {
            if (data_row.ContainsKey(id))
                return data_row[id];

            Table_device table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            if (data_row.Count >= table.DataLength)
                return null;
            
            int hashcode = id.GetHashCode();
            if (null != row_index && row_index.ContainsKey(hashcode))
            {
                DRdevice? data = table.Data(row_index[hashcode]);
                if (data.HasValue && data.Value.Id == id)
                {
                    DeviceDataRow datarow = new DeviceDataRow(data.Value, row_index[hashcode]);
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
                DRdevice? data = table.Data(i);
                if (data.HasValue)
                {
                    DeviceDataRow datarow = new DeviceDataRow(data.Value, i);
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
        public DeviceDataRow GetDataRowByIndex(int index)
        {
            Table_device table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;

            if (index >= table.DataLength)
                return null;

            DRdevice? data = table.Data(index);
            if (data.HasValue)
            {
                if (!data_row.ContainsKey(data.Value.Id))
                {
                    DeviceDataRow datarow = new DeviceDataRow(data.Value, index);
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
        public Dictionary<string, DeviceDataRow> GetAllData()
        {
            this.LoadTable();

            Table_device table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            int dataCount = table.DataLength;
            if (data_row.Count < dataCount)
            {
                for (int i = 0; i < table.DataLength; i++)
                {
                    DRdevice? data = table.Data(i);
                    if (data.HasValue && !data_row.ContainsKey(data.Value.Id))
                    {
                        DeviceDataRow datarow = new DeviceDataRow(data.Value, i);
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

        #endregion DataRow Method
                
        #region Framework Method

        protected override void InitTable(ByteBuffer byteBuffer)
        {
            table = Table_device.GetRootAsTable_device(byteBuffer);
            
            this.load_state = E_LoadState.Loaded;
        }

        public override void ResetTable()
        {
            base.ResetTable();

            this.data_row.Clear();
        }
        
        private Table_device GetTable()
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
            return "device.bytes";
        }

        protected override string GetIndexFileName()
        {
            return "device_ids";
        }
        
        #endregion Framework Method
    }

    #endregion Table

    #region DataRow

    public sealed class DeviceDataRow : BaseDataRow
    {
        private DRdevice _datarow;

        public DeviceDataRow(DRdevice datarow, int index) : base(index)
        {
            this._datarow = datarow;
        }

        protected override LuaValue GetLuaValue(string rowId)
        {
            LuaValue luaValue = new LuaValue();
            switch (rowId)
            {
                case "Id": { luaValue.SetValue(this.Id); break; }
                case "ModeType": { luaValue.SetValue(this.ModeType); break; }
                case "RenderLevel": { luaValue.SetValue(this.RenderLevel); break; }

                default:
                    break;
            }

            return luaValue;
        }

        private string _Id = null;
        public string Id { get { if (null == _Id) _Id = _datarow.Id; return _Id; } }

        public short ModeType { get { return _datarow.ModeType; } }

        public short RenderLevel { get { return _datarow.RenderLevel; } }


    }

    #endregion DataRow
}