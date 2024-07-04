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

	public sealed class Heroes_campTable : BaseTable
    {
        private Table_heroes_camp table = default(Table_heroes_camp);

        private Dictionary<int, Heroes_campDataRow> data_row = new Dictionary<int, Heroes_campDataRow>(128);
        
        public static string g_TableFileName = "heroes_camp";

        #region Data Method

        public override bool GetBoolValue(int id, string column, bool defaultValue = false)
        {
            bool result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_heroes_camp.GetBoolValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_heroes_camp.GetShortValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "against": { result = datarow.Against; break; }
                case "order": { result = datarow.Order; break; }
                case "restraint_des": { result = datarow.RestraintDes; break; }

                default: { GameFramework.Log.Error("Table_heroes_camp.GetIntValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "against": { result = datarow.Against; break; }
                case "order": { result = datarow.Order; break; }
                case "restraint_des": { result = datarow.RestraintDes; break; }

                default: { GameFramework.Log.Error("Table_heroes_camp.GetFloatValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "name": { result = datarow.Name; break; }
                case "des": { result = datarow.Des; break; }
                case "kind_icon1": { result = datarow.KindIcon1; break; }
                case "kind_icon2": { result = datarow.KindIcon2; break; }
                case "kind_icon3": { result = datarow.KindIcon3; break; }
                case "icon": { result = datarow.Icon; break; }
                case "camp_scene": { result = datarow.CampScene; break; }
                case "result_icon": { result = datarow.ResultIcon; break; }
                case "against": { result = datarow.Against.ToString(); break; }
                case "big_icon": { result = datarow.BigIcon; break; }
                case "kind_icon4": { result = datarow.KindIcon4; break; }
                case "camp_icon": { result = datarow.CampIcon; break; }
                case "normal_icon": { result = datarow.NormalIcon; break; }
                case "list_icon": { result = datarow.ListIcon; break; }
                case "order": { result = datarow.Order.ToString(); break; }
                case "icon_color": { result = datarow.IconColor; break; }
                case "restraint_des": { result = datarow.RestraintDes.ToString(); break; }

                default: { GameFramework.Log.Error("Table_heroes_camp.GetStringValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_heroes_camp.GetBoolArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_heroes_camp.GetShortArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_heroes_camp.GetIntArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_heroes_camp.GetFloatArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "effect": { result = datarow.EffectArray; break; }

                default: { GameFramework.Log.Error("Table_heroes_camp.GetStringArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override string GetStringArrayItem(int id, string column, int index, string defaultValue = "")
        {
            string result = defaultValue;

            int length = this.GetStringArrayLength(id, column);
            if (index < 0 || index >= length)
            {
                GameFramework.Log.Error("Table_heroes_camp.GetStringArrayItem => index out of array length({0}), [id:{1}, column:{2}, index:{3}]", length, id, column, index);
                return result;
            }
            
            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {
                case "effect": { result = datarow.EffectArray[index]; break; }

                default: { GameFramework.Log.Error("Table_heroes_camp.GetStringArrayItem => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "effect": { result = datarow.EffectArrayLength; break; }

                default: { GameFramework.Log.Error("Table_heroes_camp.GetStringArrayLength => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "effect": { result = datarow.EffectDic; break; }

                default: { GameFramework.Log.Error("Table_heroes_camp.GetDictionaryII => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_heroes_camp.GetDictionaryIS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_heroes_camp.GetDictionarySI => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_heroes_camp.GetDictionarySS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
            Table_heroes_camp table = this.GetTable();
            if (null == table.ByteBuffer)
                return 0;

            return table.DataLength; 
        }
        
        /// <summary>
        /// 获得行数据
        /// </summary>
        /// <param name="id">字段ID的值</param>
        /// <returns>行数据</returns>
        public Heroes_campDataRow GetDataRow(int id)
        {
            if (data_row.ContainsKey(id))
                return data_row[id];

            Table_heroes_camp table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            if (data_row.Count >= table.DataLength)
                return null;
            
            if (null != row_index && row_index.ContainsKey(id))
            {
                DRheroes_camp? data = table.Data(row_index[id]);
                if (data.HasValue && data.Value.Id == id)
                {
                    Heroes_campDataRow datarow = new Heroes_campDataRow(data.Value, row_index[id]);
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
                DRheroes_camp? data = table.Data(i);
                if (data.HasValue)
                {
                    Heroes_campDataRow datarow = new Heroes_campDataRow(data.Value, i);
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
        public Heroes_campDataRow GetDataRowByIndex(int index)
        {
            Table_heroes_camp table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;

            if (index < 0 || index >= table.DataLength)
                return null;

            DRheroes_camp? data = table.Data(index);
            if (data.HasValue)
            {
                if (!data_row.ContainsKey(data.Value.Id))
                {
                    Heroes_campDataRow datarow = new Heroes_campDataRow(data.Value, index);
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
        public Dictionary<int, Heroes_campDataRow> GetAllData()
        {
            Table_heroes_camp table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            int dataCount = table.DataLength;
            if (data_row.Count < dataCount)
            {
                for (int i = 0; i < table.DataLength; i++)
                {
                    DRheroes_camp? data = table.Data(i);
                    if (data.HasValue && !data_row.ContainsKey(data.Value.Id))
                    {
                        Heroes_campDataRow datarow = new Heroes_campDataRow(data.Value, i);
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
            table = Table_heroes_camp.GetRootAsTable_heroes_camp(byteBuffer);
            
            this.load_state = E_LoadState.Loaded;
        }

        public override void ResetTable()
        {
            base.ResetTable();

            this.data_row.Clear();
        }
        
        private Table_heroes_camp GetTable()
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
            return "heroes_camp.bytes";
        }

        protected override string GetIndexFileName()
        {
            return "heroes_camp_ids";
        }
        
        #endregion Framework Method
    }

    #endregion Table

    #region DataRow

    public class Heroes_campBaseDataRow : BaseDataRow
    {
        protected DRheroes_camp _datarow;

        public Heroes_campBaseDataRow(DRheroes_camp datarow, int index) : base(index)
        {
            this._datarow = datarow;
        }
        
        public override CSLuaTable GetLuaTable()
        {
            base.GetLuaTable();

            if (_LuaDataRow.Length <= 0)
            {
                if(this.HasKey("id")) _LuaDataRow.Set("id", this.Id);
                if(this.HasKey("name")) _LuaDataRow.Set("name", this.Name);
                if(this.HasKey("des")) _LuaDataRow.Set("des", this.Des);
                if(this.HasKey("kind_icon1")) _LuaDataRow.Set("kind_icon1", this.KindIcon1);
                if(this.HasKey("kind_icon2")) _LuaDataRow.Set("kind_icon2", this.KindIcon2);
                if(this.HasKey("kind_icon3")) _LuaDataRow.Set("kind_icon3", this.KindIcon3);
                if(this.HasKey("icon")) _LuaDataRow.Set("icon", this.Icon);
                if(this.HasKey("camp_scene")) _LuaDataRow.Set("camp_scene", this.CampScene);
                if(this.HasKey("result_icon")) _LuaDataRow.Set("result_icon", this.ResultIcon);
                if(this.HasKey("against")) _LuaDataRow.Set("against", this.Against);
                if(this.HasKey("big_icon")) _LuaDataRow.Set("big_icon", this.BigIcon);
                if(this.HasKey("kind_icon4")) _LuaDataRow.Set("kind_icon4", this.KindIcon4);
                if(this.HasKey("camp_icon")) _LuaDataRow.Set("camp_icon", this.CampIcon);
                if(this.HasKey("normal_icon")) _LuaDataRow.Set("normal_icon", this.NormalIcon);
                if(this.HasKey("list_icon")) _LuaDataRow.Set("list_icon", this.ListIcon);
                if(this.HasKey("order")) _LuaDataRow.Set("order", this.Order);
                if(this.HasKey("icon_color")) _LuaDataRow.Set("icon_color", this.IconColor);
                if(this.HasKey("restraint_des")) _LuaDataRow.Set("restraint_des", this.RestraintDes);
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
                case "name": { luaValue.SetValue(this.Name); break; }
                case "des": { luaValue.SetValue(this.Des); break; }
                case "kind_icon1": { luaValue.SetValue(this.KindIcon1); break; }
                case "kind_icon2": { luaValue.SetValue(this.KindIcon2); break; }
                case "kind_icon3": { luaValue.SetValue(this.KindIcon3); break; }
                case "icon": { luaValue.SetValue(this.Icon); break; }
                case "camp_scene": { luaValue.SetValue(this.CampScene); break; }
                case "result_icon": { luaValue.SetValue(this.ResultIcon); break; }
                case "against": { luaValue.SetValue(this.Against); break; }
                case "big_icon": { luaValue.SetValue(this.BigIcon); break; }
                case "kind_icon4": { luaValue.SetValue(this.KindIcon4); break; }
                case "camp_icon": { luaValue.SetValue(this.CampIcon); break; }
                case "normal_icon": { luaValue.SetValue(this.NormalIcon); break; }
                case "list_icon": { luaValue.SetValue(this.ListIcon); break; }
                case "order": { luaValue.SetValue(this.Order); break; }
                case "icon_color": { luaValue.SetValue(this.IconColor); break; }
                case "restraint_des": { luaValue.SetValue(this.RestraintDes); break; }
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
                case "name": { result = !this.IsEmpty(this.Name); break; }
                case "des": { result = !this.IsEmpty(this.Des); break; }
                case "kind_icon1": { result = !this.IsEmpty(this.KindIcon1); break; }
                case "kind_icon2": { result = !this.IsEmpty(this.KindIcon2); break; }
                case "kind_icon3": { result = !this.IsEmpty(this.KindIcon3); break; }
                case "icon": { result = !this.IsEmpty(this.Icon); break; }
                case "camp_scene": { result = !this.IsEmpty(this.CampScene); break; }
                case "result_icon": { result = !this.IsEmpty(this.ResultIcon); break; }
                case "against": { result = !this.IsEmpty(_datarow.Against); break; }
                case "big_icon": { result = !this.IsEmpty(this.BigIcon); break; }
                case "kind_icon4": { result = !this.IsEmpty(this.KindIcon4); break; }
                case "camp_icon": { result = !this.IsEmpty(this.CampIcon); break; }
                case "normal_icon": { result = !this.IsEmpty(this.NormalIcon); break; }
                case "list_icon": { result = !this.IsEmpty(this.ListIcon); break; }
                case "order": { result = !this.IsEmpty(_datarow.Order); break; }
                case "icon_color": { result = !this.IsEmpty(this.IconColor); break; }
                case "restraint_des": { result = !this.IsEmpty(_datarow.RestraintDes); break; }
                case "effect": { result = _datarow.EffectLength > 0; break; }

                default:
                    break;
            }

            return result;
        }
        
        public int Id { get { return this.GetTableInt(_datarow.Id); } }

        private string _Name = null;
        public string Name { get { if (null == _Name) _Name = _datarow.Name; return _Name; } }

        private string _Des = null;
        public string Des { get { if (null == _Des) _Des = _datarow.Des; return _Des; } }

        private string _KindIcon1 = null;
        public string KindIcon1 { get { if (null == _KindIcon1) _KindIcon1 = _datarow.KindIcon1; return _KindIcon1; } }

        private string _KindIcon2 = null;
        public string KindIcon2 { get { if (null == _KindIcon2) _KindIcon2 = _datarow.KindIcon2; return _KindIcon2; } }

        private string _KindIcon3 = null;
        public string KindIcon3 { get { if (null == _KindIcon3) _KindIcon3 = _datarow.KindIcon3; return _KindIcon3; } }

        private string _Icon = null;
        public string Icon { get { if (null == _Icon) _Icon = _datarow.Icon; return _Icon; } }

        private string _CampScene = null;
        public string CampScene { get { if (null == _CampScene) _CampScene = _datarow.CampScene; return _CampScene; } }

        private string _ResultIcon = null;
        public string ResultIcon { get { if (null == _ResultIcon) _ResultIcon = _datarow.ResultIcon; return _ResultIcon; } }

        public int Against { get { return this.GetTableInt(_datarow.Against); } }

        private string _BigIcon = null;
        public string BigIcon { get { if (null == _BigIcon) _BigIcon = _datarow.BigIcon; return _BigIcon; } }

        private string _KindIcon4 = null;
        public string KindIcon4 { get { if (null == _KindIcon4) _KindIcon4 = _datarow.KindIcon4; return _KindIcon4; } }

        private string _CampIcon = null;
        public string CampIcon { get { if (null == _CampIcon) _CampIcon = _datarow.CampIcon; return _CampIcon; } }

        private string _NormalIcon = null;
        public string NormalIcon { get { if (null == _NormalIcon) _NormalIcon = _datarow.NormalIcon; return _NormalIcon; } }

        private string _ListIcon = null;
        public string ListIcon { get { if (null == _ListIcon) _ListIcon = _datarow.ListIcon; return _ListIcon; } }

        public int Order { get { return this.GetTableInt(_datarow.Order); } }

        private string _IconColor = null;
        public string IconColor { get { if (null == _IconColor) _IconColor = _datarow.IconColor; return _IconColor; } }

        public int RestraintDes { get { return this.GetTableInt(_datarow.RestraintDes); } }

        private string[] _EffectArray = null;
        public string[] EffectArray { get { if(null == _EffectArray) { if (_datarow.EffectLength > 0) { _EffectArray = new string[_datarow.EffectLength]; for (int i = 0; i < _datarow.EffectLength; i++) { _EffectArray[i] = _datarow.Effect(i); } } } return _EffectArray; } }
        public int EffectArrayLength { get { if (null == this.EffectArray) return 0; return this.EffectArray.Length; } }

        private Dictionary<int, int> _EffectDic = null;
        public Dictionary<int, int> EffectDic { get { if(null == _EffectDic) { _EffectDic = new Dictionary<int, int>(); if(EffectArrayLength > 0) { for(int i = 0; i < EffectArrayLength; i++) { string[] array = EffectArray[i].Split(split_chars); if(array.Length > 1) { int key = array[0].ToInt(); if (!_EffectDic.ContainsKey(key)) _EffectDic.Add(array[0].ToInt(), array[1].ToInt()); } } } } return _EffectDic; } }


    }

    #endregion DataRow
}