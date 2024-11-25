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

	public sealed class ScoreTable : BaseTable
    {
        private Table_score table = default(Table_score);

        private Dictionary<int, ScoreDataRow> data_row = new Dictionary<int, ScoreDataRow>(128);
        
        public static string g_TableFileName = "score";

        #region Data Method

        public override bool GetBoolValue(int id, string column, bool defaultValue = false)
        {
            bool result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { GameFramework.Log.Error("Table_score.GetBoolValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_score.GetShortValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "type": { result = datarow.Type; break; }
                case "points": { result = datarow.Points; break; }
                case "season_type": { result = datarow.SeasonType; break; }

                default: { GameFramework.Log.Error("Table_score.GetIntValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "type": { result = datarow.Type; break; }
                case "points": { result = datarow.Points; break; }
                case "season_type": { result = datarow.SeasonType; break; }

                default: { GameFramework.Log.Error("Table_score.GetFloatValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "type": { result = datarow.Type.ToString(); break; }
                case "name": { result = datarow.Name; break; }
                case "points": { result = datarow.Points.ToString(); break; }
                case "season_type": { result = datarow.SeasonType.ToString(); break; }

                default: { GameFramework.Log.Error("Table_score.GetStringValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_score.GetBoolArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_score.GetShortArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "group": { result = datarow.GroupArray; break; }
                case "tips": { result = datarow.TipsArray; break; }

                default: { GameFramework.Log.Error("Table_score.GetIntArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_score.GetFloatArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "value": { result = datarow.ValueArray; break; }

                default: { GameFramework.Log.Error("Table_score.GetStringArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override string GetStringArrayItem(int id, string column, int index, string defaultValue = "")
        {
            string result = defaultValue;

            int length = this.GetStringArrayLength(id, column);
            if (index < 0 || index >= length)
            {
                GameFramework.Log.Error("Table_score.GetStringArrayItem => index out of array length({0}), [id:{1}, column:{2}, index:{3}]", length, id, column, index);
                return result;
            }
            
            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {
                case "value": { result = datarow.ValueArray[index]; break; }

                default: { GameFramework.Log.Error("Table_score.GetStringArrayItem => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "value": { result = datarow.ValueArrayLength; break; }

                default: { GameFramework.Log.Error("Table_score.GetStringArrayLength => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_score.GetDictionaryII => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_score.GetDictionaryIS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_score.GetDictionarySI => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { GameFramework.Log.Error("Table_score.GetDictionarySS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
            Table_score table = this.GetTable();
            if (null == table.ByteBuffer)
                return 0;

            return table.DataLength; 
        }
        
        /// <summary>
        /// 获得行数据
        /// </summary>
        /// <param name="id">字段ID的值</param>
        /// <returns>行数据</returns>
        public ScoreDataRow GetDataRow(int id)
        {
            if (data_row.ContainsKey(id))
                return data_row[id];

            Table_score table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            if (data_row.Count >= table.DataLength)
                return null;
            
            if (null != row_index && row_index.ContainsKey(id))
            {
                DRscore? data = table.Data(row_index[id]);
                if (data.HasValue && data.Value.Id == id)
                {
                    ScoreDataRow datarow = new ScoreDataRow(data.Value, row_index[id]);
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
                DRscore? data = table.Data(i);
                if (data.HasValue)
                {
                    ScoreDataRow datarow = new ScoreDataRow(data.Value, i);
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
        public ScoreDataRow GetDataRowByIndex(int index)
        {
            Table_score table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;

            if (index < 0 || index >= table.DataLength)
                return null;

            DRscore? data = table.Data(index);
            if (data.HasValue)
            {
                if (!data_row.ContainsKey(data.Value.Id))
                {
                    ScoreDataRow datarow = new ScoreDataRow(data.Value, index);
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
        public Dictionary<int, ScoreDataRow> GetAllData()
        {
            Table_score table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            int dataCount = table.DataLength;
            if (data_row.Count < dataCount)
            {
                for (int i = 0; i < table.DataLength; i++)
                {
                    DRscore? data = table.Data(i);
                    if (data.HasValue && !data_row.ContainsKey(data.Value.Id))
                    {
                        ScoreDataRow datarow = new ScoreDataRow(data.Value, i);
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
            table = Table_score.GetRootAsTable_score(byteBuffer);
            
            this.load_state = E_LoadState.Loaded;
        }

        public override void ResetTable()
        {
            base.ResetTable();

            this.data_row.Clear();
        }
        
        private Table_score GetTable()
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
            return "score.bytes";
        }

        protected override string GetIndexFileName()
        {
            return "score_ids";
        }
        
        #endregion Framework Method
    }

    #endregion Table

    #region DataRow

    public class ScoreBaseDataRow : BaseDataRow
    {
        protected DRscore _datarow;

        public ScoreBaseDataRow(DRscore datarow, int index) : base(index)
        {
            this._datarow = datarow;
        }
        
        public override CSLuaTable GetLuaTable()
        {
            base.GetLuaTable();

            if (_LuaDataRow.Length <= 0)
            {
                if(this.HasKey("id")) _LuaDataRow.Set("id", this.Id);
                if(this.HasKey("type")) _LuaDataRow.Set("type", this.Type);
                if(this.HasKey("name")) _LuaDataRow.Set("name", this.Name);
                if(this.HasKey("points")) _LuaDataRow.Set("points", this.Points);
                if(this.HasKey("season_type")) _LuaDataRow.Set("season_type", this.SeasonType);
                if(this.HasKey("value")) _LuaDataRow.Set("value", this.ValueArray);
                if(this.HasKey("group")) _LuaDataRow.Set("group", this.GroupArray);
                if(this.HasKey("tips")) _LuaDataRow.Set("tips", this.TipsArray);

            }

            return _LuaDataRow;
        }

        protected override LuaValue GetLuaValue(string rowId)
        {
            LuaValue luaValue = new LuaValue();
            switch (rowId)
            {
                case "id": { luaValue.SetValue(this.Id); break; }
                case "type": { luaValue.SetValue(this.Type); break; }
                case "name": { luaValue.SetValue(this.Name); break; }
                case "points": { luaValue.SetValue(this.Points); break; }
                case "season_type": { luaValue.SetValue(this.SeasonType); break; }
                case "value": { luaValue.SetValue(this.ValueArray); break; }
                case "group": { luaValue.SetValue(this.GroupArray); break; }
                case "tips": { luaValue.SetValue(this.TipsArray); break; }

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
                case "type": { result = !this.IsEmpty(_datarow.Type); break; }
                case "name": { result = !this.IsEmpty(this.Name); break; }
                case "points": { result = !this.IsEmpty(_datarow.Points); break; }
                case "season_type": { result = !this.IsEmpty(_datarow.SeasonType); break; }
                case "value": { result = _datarow.ValueLength > 0; break; }
                case "group": { result = _datarow.GroupLength > 0; break; }
                case "tips": { result = _datarow.TipsLength > 0; break; }

                default:
                    break;
            }

            return result;
        }
        
        public int Id { get { return this.GetTableInt(_datarow.Id); } }

        public int Type { get { return this.GetTableInt(_datarow.Type); } }

        private string _Name = null;
        public string Name { get { if (null == _Name) _Name = _datarow.Name; return _Name; } }

        public int Points { get { return this.GetTableInt(_datarow.Points); } }

        public int SeasonType { get { return this.GetTableInt(_datarow.SeasonType); } }

        private string[] _ValueArray = null;
        public string[] ValueArray { get { if(null == _ValueArray) { if (_datarow.ValueLength > 0) { _ValueArray = new string[_datarow.ValueLength]; for (int i = 0; i < _datarow.ValueLength; i++) { _ValueArray[i] = _datarow.Value(i); } } } return _ValueArray; } }
        public int ValueArrayLength { get { if (null == this.ValueArray) return 0; return this.ValueArray.Length; } }

        private int[] _GroupArray = null;
        public int[] GroupArray { get { if (null == _GroupArray) _GroupArray = _datarow.GetGroupArray(); return _GroupArray; } }
        public int GroupArrayLength { get { if (null == this.GroupArray) return 0; return this.GroupArray.Length; } }

        private int[] _TipsArray = null;
        public int[] TipsArray { get { if (null == _TipsArray) _TipsArray = _datarow.GetTipsArray(); return _TipsArray; } }
        public int TipsArrayLength { get { if (null == this.TipsArray) return 0; return this.TipsArray.Length; } }


    }

    #endregion DataRow
}