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

	public sealed class VipTable : BaseTable
    {
        private Table_vip table = default(Table_vip);

        private Dictionary<int, VipDataRow> data_row = new Dictionary<int, VipDataRow>(128);
        
        public static string g_TableFileName = "vip";

        #region Data Method

        public override bool GetBoolValue(int id, string column, bool defaultValue = false)
        {
            bool result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_vip.GetBoolValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_vip.GetShortValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "point": { result = datarow.Point; break; }
                case "reward2": { result = datarow.Reward2; break; }

                default: { GameFramework.Log.Error("Table_vip.GetIntValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "point": { result = datarow.Point; break; }
                case "reward2": { result = datarow.Reward2; break; }

                default: { GameFramework.Log.Error("Table_vip.GetFloatValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "point": { result = datarow.Point.ToString(); break; }
                case "icon": { result = datarow.Icon; break; }
                case "reward2": { result = datarow.Reward2.ToString(); break; }

                default: { GameFramework.Log.Error("Table_vip.GetStringValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_vip.GetBoolArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_vip.GetShortArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "display": { result = datarow.DisplayArray; break; }

                default: { GameFramework.Log.Error("Table_vip.GetIntArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_vip.GetFloatArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "reward1": { result = datarow.Reward1Array; break; }
                case "effect": { result = datarow.EffectArray; break; }

                default: { GameFramework.Log.Error("Table_vip.GetStringArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override string GetStringArrayItem(int id, string column, int index, string defaultValue = "")
        {
            string result = defaultValue;

            int length = this.GetStringArrayLength(id, column);
            if (index < 0 || index >= length)
            {
                GameFramework.Log.Error("Table_vip.GetStringArrayItem => index out of array length({0}), [id:{1}, column:{2}, index:{3}]", length, id, column, index);
                return result;
            }
            
            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {
                case "reward1": { result = datarow.Reward1Array[index]; break; }
                case "effect": { result = datarow.EffectArray[index]; break; }

                default: { GameFramework.Log.Error("Table_vip.GetStringArrayItem => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "reward1": { result = datarow.Reward1ArrayLength; break; }
                case "effect": { result = datarow.EffectArrayLength; break; }

                default: { GameFramework.Log.Error("Table_vip.GetStringArrayLength => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "reward1": { result = datarow.Reward1Dic; break; }

                default: { GameFramework.Log.Error("Table_vip.GetDictionaryII => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "effect": { result = datarow.EffectDic; break; }

                default: { GameFramework.Log.Error("Table_vip.GetDictionaryIS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_vip.GetDictionarySI => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_vip.GetDictionarySS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
            Table_vip table = this.GetTable();
            if (null == table.ByteBuffer)
                return 0;

            return table.DataLength; 
        }
        
        /// <summary>
        /// 获得行数据
        /// </summary>
        /// <param name="id">字段ID的值</param>
        /// <returns>行数据</returns>
        public VipDataRow GetDataRow(int id)
        {
            if (data_row.ContainsKey(id))
                return data_row[id];

            Table_vip table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            if (data_row.Count >= table.DataLength)
                return null;
            
            if (null != row_index && row_index.ContainsKey(id))
            {
                DRvip? data = table.Data(row_index[id]);
                if (data.HasValue && data.Value.Id == id)
                {
                    VipDataRow datarow = new VipDataRow(data.Value, row_index[id]);
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
                DRvip? data = table.Data(i);
                if (data.HasValue)
                {
                    VipDataRow datarow = new VipDataRow(data.Value, i);
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
        public VipDataRow GetDataRowByIndex(int index)
        {
            Table_vip table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;

            if (index < 0 || index >= table.DataLength)
                return null;

            DRvip? data = table.Data(index);
            if (data.HasValue)
            {
                if (!data_row.ContainsKey(data.Value.Id))
                {
                    VipDataRow datarow = new VipDataRow(data.Value, index);
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
        public Dictionary<int, VipDataRow> GetAllData()
        {
            Table_vip table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            int dataCount = table.DataLength;
            if (data_row.Count < dataCount)
            {
                for (int i = 0; i < table.DataLength; i++)
                {
                    DRvip? data = table.Data(i);
                    if (data.HasValue && !data_row.ContainsKey(data.Value.Id))
                    {
                        VipDataRow datarow = new VipDataRow(data.Value, i);
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
            table = Table_vip.GetRootAsTable_vip(byteBuffer);
            
            this.load_state = E_LoadState.Loaded;
        }

        public override void ResetTable()
        {
            base.ResetTable();

            this.data_row.Clear();
        }
        
        private Table_vip GetTable()
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
            return "vip.bytes";
        }

        protected override string GetIndexFileName()
        {
            return "vip_ids";
        }
        
        #endregion Framework Method
    }

    #endregion Table

    #region DataRow

    public class VipBaseDataRow : BaseDataRow
    {
        protected DRvip _datarow;

        public VipBaseDataRow(DRvip datarow, int index) : base(index)
        {
            this._datarow = datarow;
        }
        
        public override CSLuaTable GetLuaTable()
        {
            base.GetLuaTable();

            if (_LuaDataRow.Length <= 0)
            {
                if(this.HasKey("id")) _LuaDataRow.Set("id", this.Id);
                if(this.HasKey("point")) _LuaDataRow.Set("point", this.Point);
                if(this.HasKey("icon")) _LuaDataRow.Set("icon", this.Icon);
                if(this.HasKey("reward1")) _LuaDataRow.Set("reward1", this.Reward1Array);
                if(this.HasKey("reward2")) _LuaDataRow.Set("reward2", this.Reward2);
                if(this.HasKey("display")) _LuaDataRow.Set("display", this.DisplayArray);
                if(this.HasKey("effect")) _LuaDataRow.Set("effect", this.EffectArray);

            }

            return _LuaDataRow;
        }

        protected override LuaValue GetLuaValue(string rowId)
        {
            LuaValue luaValue = new LuaValue();
            switch (rowId)
            {
                case "id": { luaValue.SetValue(this.Id); break; }
                case "point": { luaValue.SetValue(this.Point); break; }
                case "icon": { luaValue.SetValue(this.Icon); break; }
                case "reward1": { luaValue.SetValue(this.Reward1Dic); break; }
                case "reward2": { luaValue.SetValue(this.Reward2); break; }
                case "display": { luaValue.SetValue(this.DisplayArray); break; }
                case "effect": { luaValue.SetValue(this.EffectDic); break; }

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
                case "point": { result = !this.IsEmpty(_datarow.Point); break; }
                case "icon": { result = !this.IsEmpty(this.Icon); break; }
                case "reward1": { result = _datarow.Reward1Length > 0; break; }
                case "reward2": { result = !this.IsEmpty(_datarow.Reward2); break; }
                case "display": { result = _datarow.DisplayLength > 0; break; }
                case "effect": { result = _datarow.EffectLength > 0; break; }

                default:
                    break;
            }

            return result;
        }
        
        public int Id { get { return this.GetTableInt(_datarow.Id); } }

        public int Point { get { return this.GetTableInt(_datarow.Point); } }

        private string _Icon = null;
        public string Icon { get { if (null == _Icon) _Icon = _datarow.Icon; return _Icon; } }

        private string[] _Reward1Array = null;
        public string[] Reward1Array { get { if(null == _Reward1Array) { if (_datarow.Reward1Length > 0) { _Reward1Array = new string[_datarow.Reward1Length]; for (int i = 0; i < _datarow.Reward1Length; i++) { _Reward1Array[i] = _datarow.Reward1(i); } } } return _Reward1Array; } }
        public int Reward1ArrayLength { get { if (null == this.Reward1Array) return 0; return this.Reward1Array.Length; } }

        private Dictionary<int, int> _Reward1Dic = null;
        public Dictionary<int, int> Reward1Dic { get { if(null == _Reward1Dic) { _Reward1Dic = new Dictionary<int, int>(); if(Reward1ArrayLength > 0) { for(int i = 0; i < Reward1ArrayLength; i++) { string[] array = Reward1Array[i].Split(split_chars); if(array.Length > 1) { int key = array[0].ToInt(); if (!_Reward1Dic.ContainsKey(key)) _Reward1Dic.Add(array[0].ToInt(), array[1].ToInt()); } } } } return _Reward1Dic; } }

        public int Reward2 { get { return this.GetTableInt(_datarow.Reward2); } }

        private int[] _DisplayArray = null;
        public int[] DisplayArray { get { if (null == _DisplayArray) _DisplayArray = _datarow.GetDisplayArray(); return _DisplayArray; } }
        public int DisplayArrayLength { get { if (null == this.DisplayArray) return 0; return this.DisplayArray.Length; } }

        private string[] _EffectArray = null;
        public string[] EffectArray { get { if(null == _EffectArray) { if (_datarow.EffectLength > 0) { _EffectArray = new string[_datarow.EffectLength]; for (int i = 0; i < _datarow.EffectLength; i++) { _EffectArray[i] = _datarow.Effect(i); } } } return _EffectArray; } }
        public int EffectArrayLength { get { if (null == this.EffectArray) return 0; return this.EffectArray.Length; } }

        private Dictionary<int, string> _EffectDic = null;
        public Dictionary<int, string> EffectDic { get { if(null == _EffectDic) { _EffectDic = new Dictionary<int, string>(); if(EffectArrayLength > 0) { for(int i = 0; i < EffectArrayLength; i++) { string[] array = EffectArray[i].Split(split_chars); if(array.Length > 1) { int key = array[0].ToInt(); if (!_EffectDic.ContainsKey(key)) _EffectDic.Add(array[0].ToInt(), array[1]); } } } } return _EffectDic; } }


    }

    #endregion DataRow
}