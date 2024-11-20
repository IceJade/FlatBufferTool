﻿// <auto-generated>
//  automatically generated by table tool, do not modify
// </auto-generated>
using System.IO;
using FlatBuffers;
using Chanto.Table;
using System.Collections.Generic;
using UnityEngine;

namespace Chanto.Table
{
    #region Table
    
	public sealed class UiTable : StringIdConfig
    {
        private Table_ui table = default(Table_ui);

        private Dictionary<string, UiDataRow> data_row = new Dictionary<string, UiDataRow>(128);
        
        public static string g_TableFileName = "ui";

        #region Data Method

        public override bool GetBoolValue(string id, string column, bool defaultValue = false)
        {
            bool result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {
                case "IsPauseCoveredUI": { result = datarow.IsPauseCoveredUI; break; }
                case "IsMultipleInstance": { result = datarow.IsMultipleInstance; break; }
                case "IsLocked": { result = datarow.IsLocked; break; }
                case "IsRefreshOnReopenning": { result = datarow.IsRefreshOnReopenning; break; }
                case "IsFullScreen": { result = datarow.IsFullScreen; break; }
                case "IsCaptureSceneScreenshot": { result = datarow.IsCaptureSceneScreenshot; break; }

                default: { Debug.LogErrorFormat("Table_ui.GetBoolValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Debug.LogErrorFormat("Table_ui.GetShortValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "Priority": { result = datarow.Priority; break; }

                default: { Debug.LogErrorFormat("Table_ui.GetIntValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "Priority": { result = datarow.Priority; break; }

                default: { Debug.LogErrorFormat("Table_ui.GetFloatValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "AssetName": { result = datarow.AssetName; break; }
                case "UIGroupName": { result = datarow.UIGroupName; break; }
                case "Priority": { result = datarow.Priority.ToString(); break; }

                default: { Debug.LogError($"Table_ui.GetStringValue => data type is not match, or not find [id:{id}, column:{column}]"); break; }
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

                default: { Debug.LogErrorFormat("Table_ui.GetBoolArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Debug.LogErrorFormat("Table_ui.GetShortArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Debug.LogErrorFormat("Table_ui.GetIntArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Debug.LogErrorFormat("Table_ui.GetFloatArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Debug.LogErrorFormat("Table_ui.GetStringArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override string GetStringArrayItem(string id, string column, int index, string defaultValue = "")
        {
            string result = defaultValue;

            int length = this.GetStringArrayLength(id, column);
            if (index < 0 || index >= length)
            {
                Debug.LogErrorFormat("Table_ui.GetStringArrayItem => index out of array length({0}), [id:{1}, column:{2}, index:{3}]", length, id, column, index);
                return result;
            }
            
            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Debug.LogErrorFormat("Table_ui.GetStringArrayItem => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Debug.LogErrorFormat("Table_ui.GetStringArrayLength => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Debug.LogErrorFormat("Table_ui.GetDictionaryII => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Debug.LogErrorFormat("Table_ui.GetDictionaryIS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Debug.LogErrorFormat("Table_ui.GetDictionarySI => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Debug.LogErrorFormat("Table_ui.GetDictionarySS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
            Table_ui table = this.GetTable();
            if (null == table.ByteBuffer)
                return 0;

            return table.DataLength; 
        }
        
        /// <summary>
        /// 获得行数据
        /// </summary>
        /// <param name="id">字段ID的值</param>
        /// <returns>行数据</returns>
        public UiDataRow GetDataRow(string id)
        {
            if (data_row.ContainsKey(id))
                return data_row[id];

            Table_ui table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            if (data_row.Count >= table.DataLength)
                return null;
            
            int hashcode = id.GetHashCode();
            if (null != row_index && row_index.ContainsKey(hashcode))
            {
                DRui? data = table.Data(row_index[hashcode]);
                if (data.HasValue && data.Value.Id == id)
                {
                    UiDataRow datarow = new UiDataRow(data.Value, row_index[hashcode]);
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
                DRui? data = table.Data(i);
                if (data.HasValue)
                {
                    UiDataRow datarow = new UiDataRow(data.Value, i);
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
        public UiDataRow GetDataRowByIndex(int index)
        {
            Table_ui table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;

            if (index < 0 || index >= table.DataLength)
                return null;

            DRui? data = table.Data(index);
            if (data.HasValue)
            {
                if (!data_row.ContainsKey(data.Value.Id))
                {
                    UiDataRow datarow = new UiDataRow(data.Value, index);
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
        public Dictionary<string, UiDataRow> GetAllData()
        {
            this.LoadTable();

            Table_ui table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            int dataCount = table.DataLength;
            if (data_row.Count < dataCount)
            {
                for (int i = 0; i < table.DataLength; i++)
                {
                    DRui? data = table.Data(i);
                    if (data.HasValue && !data_row.ContainsKey(data.Value.Id))
                    {
                        UiDataRow datarow = new UiDataRow(data.Value, i);
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
            table = Table_ui.GetRootAsTable_ui(byteBuffer);
            
            this.load_state = E_LoadState.Loaded;
        }

        public override void ResetTable()
        {
            base.ResetTable();

            this.data_row.Clear();
        }
        
        private Table_ui GetTable()
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
            return "ui.bytes";
        }

        protected override string GetIndexFileName()
        {
            return "ui_ids";
        }
        
        #endregion Framework Method
    }

    #endregion Table

    #region DataRow

    public sealed class UiDataRow : BaseDataRow
    {
        private DRui _datarow;

        public UiDataRow(DRui datarow, int index) : base(index)
        {
            this._datarow = datarow;
        }

        protected override LuaValue GetLuaValue(string rowId)
        {
            LuaValue luaValue = new LuaValue();
            switch (rowId)
            {
                case "id": { luaValue.SetValue(this.Id); break; }
                case "AssetName": { luaValue.SetValue(this.AssetName); break; }
                case "UIGroupName": { luaValue.SetValue(this.UIGroupName); break; }
                case "Priority": { luaValue.SetValue(this.Priority); break; }
                case "IsPauseCoveredUI": { luaValue.SetValue(this.IsPauseCoveredUI); break; }
                case "IsMultipleInstance": { luaValue.SetValue(this.IsMultipleInstance); break; }
                case "IsLocked": { luaValue.SetValue(this.IsLocked); break; }
                case "IsRefreshOnReopenning": { luaValue.SetValue(this.IsRefreshOnReopenning); break; }
                case "IsFullScreen": { luaValue.SetValue(this.IsFullScreen); break; }
                case "IsCaptureSceneScreenshot": { luaValue.SetValue(this.IsCaptureSceneScreenshot); break; }

                default:
                    break;
            }

            return luaValue;
        }

        private string _Id = null;
        public string Id { get { if (null == _Id) _Id = _datarow.Id; return _Id; } }

        private string _AssetName = null;
        public string AssetName { get { if (null == _AssetName) _AssetName = _datarow.AssetName; return _AssetName; } }

        private string _UIGroupName = null;
        public string UIGroupName { get { if (null == _UIGroupName) _UIGroupName = _datarow.UIGroupName; return _UIGroupName; } }

        public int Priority { get { return _datarow.Priority; } }

        public bool IsPauseCoveredUI { get { return _datarow.IsPauseCoveredUI; } }

        public bool IsMultipleInstance { get { return _datarow.IsMultipleInstance; } }

        public bool IsLocked { get { return _datarow.IsLocked; } }

        public bool IsRefreshOnReopenning { get { return _datarow.IsRefreshOnReopenning; } }

        public bool IsFullScreen { get { return _datarow.IsFullScreen; } }

        public bool IsCaptureSceneScreenshot { get { return _datarow.IsCaptureSceneScreenshot; } }


    }

    #endregion DataRow
}