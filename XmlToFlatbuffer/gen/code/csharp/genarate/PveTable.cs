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

	public sealed class PveTable : BaseTable
    {
        private Table_pve table = default(Table_pve);

        private Dictionary<int, PveDataRow> data_row = new Dictionary<int, PveDataRow>(128);
        
        public static string g_TableFileName = "pve";

        #region Data Method

        public override bool GetBoolValue(int id, string column, bool defaultValue = false)
        {
            bool result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_pve.GetBoolValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_pve.GetShortValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "area": { result = datarow.Area; break; }
                case "level": { result = datarow.Level; break; }
                case "army_show": { result = datarow.ArmyShow; break; }
                case "route_point_id": { result = datarow.RoutePointId; break; }
                case "explore_max": { result = datarow.ExploreMax; break; }

                default: { Log.Error("Table_pve.GetIntValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "area": { result = datarow.Area; break; }
                case "level": { result = datarow.Level; break; }
                case "army_show": { result = datarow.ArmyShow; break; }
                case "route_point_id": { result = datarow.RoutePointId; break; }
                case "explore_max": { result = datarow.ExploreMax; break; }

                default: { Log.Error("Table_pve.GetFloatValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "area": { result = datarow.Area.ToString(); break; }
                case "level": { result = datarow.Level.ToString(); break; }
                case "battle_ground": { result = datarow.BattleGround; break; }
                case "army_show": { result = datarow.ArmyShow.ToString(); break; }
                case "route_point_id": { result = datarow.RoutePointId.ToString(); break; }
                case "explore_max": { result = datarow.ExploreMax.ToString(); break; }

                default: { Log.Error("Table_pve.GetStringValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_pve.GetBoolArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_pve.GetShortArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "reward_show": { result = datarow.RewardShowArray; break; }

                default: { Log.Error("Table_pve.GetIntArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_pve.GetFloatArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_pve.GetStringArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override string GetStringArrayItem(int id, string column, int index, string defaultValue = "")
        {
            string result = defaultValue;

            int length = this.GetStringArrayLength(id, column);
            if (index < 0 || index >= length)
            {
                Log.Error("Table_pve.GetStringArrayItem => index out of array length({0}), [id:{1}, column:{2}, index:{3}]", length, id, column, index);
                return result;
            }
            
            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_pve.GetStringArrayItem => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_pve.GetStringArrayLength => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_pve.GetDictionaryII => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_pve.GetDictionaryIS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_pve.GetDictionarySI => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_pve.GetDictionarySS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
            Table_pve table = this.GetTable();
            if (null == table.ByteBuffer)
                return 0;

            return table.DataLength; 
        }
        
        /// <summary>
        /// 获得行数据
        /// </summary>
        /// <param name="id">字段ID的值</param>
        /// <returns>行数据</returns>
        public PveDataRow GetDataRow(int id)
        {
            if (data_row.ContainsKey(id))
                return data_row[id];

            Table_pve table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            if (data_row.Count >= table.DataLength)
                return null;
            
            if (null != row_index && row_index.ContainsKey(id))
            {
                DRpve? data = table.Data(row_index[id]);
                if (data.HasValue && data.Value.Id == id)
                {
                    PveDataRow datarow = new PveDataRow(data.Value, row_index[id]);
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
                DRpve? data = table.Data(i);
                if (data.HasValue)
                {
                    PveDataRow datarow = new PveDataRow(data.Value, i);
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
        public PveDataRow GetDataRowByIndex(int index)
        {
            Table_pve table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;

            if (index < 0 || index >= table.DataLength)
                return null;

            DRpve? data = table.Data(index);
            if (data.HasValue)
            {
                if (!data_row.ContainsKey(data.Value.Id))
                {
                    PveDataRow datarow = new PveDataRow(data.Value, index);
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
        public Dictionary<int, PveDataRow> GetAllData()
        {
            Table_pve table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            int dataCount = table.DataLength;
            if (data_row.Count < dataCount)
            {
                for (int i = 0; i < table.DataLength; i++)
                {
                    DRpve? data = table.Data(i);
                    if (data.HasValue && !data_row.ContainsKey(data.Value.Id))
                    {
                        PveDataRow datarow = new PveDataRow(data.Value, i);
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
            table = Table_pve.GetRootAsTable_pve(byteBuffer);
            
            this.load_state = E_LoadState.Loaded;
        }

        public override void ResetTable()
        {
            base.ResetTable();

            this.data_row.Clear();
        }
        
        private Table_pve GetTable()
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
            return "pve.bytes";
        }

        protected override string GetIndexFileName()
        {
            return "pve_ids";
        }
        
        #endregion Framework Method
    }

    #endregion Table

    #region DataRow

    public class PveBaseDataRow : BaseDataRow
    {
        protected DRpve _datarow;

        public PveBaseDataRow(DRpve datarow, int index) : base(index)
        {
            this._datarow = datarow;
        }
        
        public override CSLuaTable GetLuaTable()
        {
            base.GetLuaTable();

            if (_LuaDataRow.Length <= 0)
            {
                if(this.HasKey("id")) _LuaDataRow.Set("id", this.Id);
                if(this.HasKey("area")) _LuaDataRow.Set("area", this.Area);
                if(this.HasKey("level")) _LuaDataRow.Set("level", this.Level);
                if(this.HasKey("reward_show")) _LuaDataRow.Set("reward_show", this.RewardShowArray);
                if(this.HasKey("battle_ground")) _LuaDataRow.Set("battle_ground", this.BattleGround);
                if(this.HasKey("army_show")) _LuaDataRow.Set("army_show", this.ArmyShow);
                if(this.HasKey("route_point_id")) _LuaDataRow.Set("route_point_id", this.RoutePointId);
                if(this.HasKey("explore_max")) _LuaDataRow.Set("explore_max", this.ExploreMax);

            }

            return _LuaDataRow;
        }

        protected override LuaValue GetLuaValue(string rowId)
        {
            LuaValue luaValue = new LuaValue();
            switch (rowId)
            {
                case "id": { luaValue.SetValue(this.Id); break; }
                case "area": { luaValue.SetValue(this.Area); break; }
                case "level": { luaValue.SetValue(this.Level); break; }
                case "reward_show": { luaValue.SetValue(this.RewardShowArray); break; }
                case "battle_ground": { luaValue.SetValue(this.BattleGround); break; }
                case "army_show": { luaValue.SetValue(this.ArmyShow); break; }
                case "route_point_id": { luaValue.SetValue(this.RoutePointId); break; }
                case "explore_max": { luaValue.SetValue(this.ExploreMax); break; }

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
                case "area": { result = !this.IsEmpty(_datarow.Area); break; }
                case "level": { result = !this.IsEmpty(_datarow.Level); break; }
                case "reward_show": { result = _datarow.RewardShowLength > 0; break; }
                case "battle_ground": { result = !this.IsEmpty(this.BattleGround); break; }
                case "army_show": { result = !this.IsEmpty(_datarow.ArmyShow); break; }
                case "route_point_id": { result = !this.IsEmpty(_datarow.RoutePointId); break; }
                case "explore_max": { result = !this.IsEmpty(_datarow.ExploreMax); break; }

                default:
                    break;
            }

            return result;
        }
        
        public int Id { get { return this.GetTableInt(_datarow.Id); } }

        public int Area { get { return this.GetTableInt(_datarow.Area); } }

        public int Level { get { return this.GetTableInt(_datarow.Level); } }

        private int[] _RewardShowArray = null;
        public int[] RewardShowArray { get { if (null == _RewardShowArray) _RewardShowArray = _datarow.GetRewardShowArray(); return _RewardShowArray; } }
        public int RewardShowArrayLength { get { if (null == this.RewardShowArray) return 0; return this.RewardShowArray.Length; } }

        private string _BattleGround = null;
        public string BattleGround { get { if (null == _BattleGround) _BattleGround = _datarow.BattleGround; return _BattleGround; } }

        public int ArmyShow { get { return this.GetTableInt(_datarow.ArmyShow); } }

        public int RoutePointId { get { return this.GetTableInt(_datarow.RoutePointId); } }

        public int ExploreMax { get { return this.GetTableInt(_datarow.ExploreMax); } }


    }

    #endregion DataRow
}