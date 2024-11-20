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

	public sealed class Heroes_qualityTable : BaseTable
    {
        private Table_heroes_quality table = default(Table_heroes_quality);

        private Dictionary<int, Heroes_qualityDataRow> data_row = new Dictionary<int, Heroes_qualityDataRow>(128);
        
        public static string g_TableFileName = "heroes_quality";

        #region Data Method

        public override bool GetBoolValue(int id, string column, bool defaultValue = false)
        {
            bool result = defaultValue;

            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_heroes_quality.GetBoolValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_heroes_quality.GetShortValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "level": { result = datarow.Level; break; }
                case "type": { result = datarow.Type; break; }
                case "level_growth": { result = datarow.LevelGrowth; break; }
                case "star": { result = datarow.Star; break; }
                case "limit_type": { result = datarow.LimitType; break; }

                default: { Log.Error("Table_heroes_quality.GetIntValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "level": { result = datarow.Level; break; }
                case "type": { result = datarow.Type; break; }
                case "level_growth": { result = datarow.LevelGrowth; break; }
                case "star": { result = datarow.Star; break; }
                case "limit_type": { result = datarow.LimitType; break; }

                default: { Log.Error("Table_heroes_quality.GetFloatValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "pic": { result = datarow.Pic; break; }
                case "level": { result = datarow.Level.ToString(); break; }
                case "type": { result = datarow.Type.ToString(); break; }
                case "name": { result = datarow.Name; break; }
                case "color": { result = datarow.Color; break; }
                case "pic2": { result = datarow.Pic2; break; }
                case "pic3": { result = datarow.Pic3; break; }
                case "pic_color": { result = datarow.PicColor; break; }
                case "pic4": { result = datarow.Pic4; break; }
                case "level_growth": { result = datarow.LevelGrowth.ToString(); break; }
                case "star": { result = datarow.Star.ToString(); break; }
                case "limit_type": { result = datarow.LimitType.ToString(); break; }

                default: { Log.Error("Table_heroes_quality.GetStringValue => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_heroes_quality.GetBoolArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_heroes_quality.GetShortArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
                case "lv_add": { result = datarow.LvAddArray; break; }
                case "consume": { result = datarow.ConsumeArray; break; }
                case "robot_consume": { result = datarow.RobotConsumeArray; break; }

                default: { Log.Error("Table_heroes_quality.GetIntArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_heroes_quality.GetFloatArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_heroes_quality.GetStringArray => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
            }

            return result;
        }
        
        public override string GetStringArrayItem(int id, string column, int index, string defaultValue = "")
        {
            string result = defaultValue;

            int length = this.GetStringArrayLength(id, column);
            if (index < 0 || index >= length)
            {
                Log.Error("Table_heroes_quality.GetStringArrayItem => index out of array length({0}), [id:{1}, column:{2}, index:{3}]", length, id, column, index);
                return result;
            }
            
            var datarow = this.GetDataRow(id);
            if (null == datarow)
                return result;

            switch (column)
            {

                default: { Log.Error("Table_heroes_quality.GetStringArrayItem => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_heroes_quality.GetStringArrayLength => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_heroes_quality.GetDictionaryII => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_heroes_quality.GetDictionaryIS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_heroes_quality.GetDictionarySI => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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

                default: { Log.Error("Table_heroes_quality.GetDictionarySS => data type is not match, or not find [id:{0}, column:{1}]", id, column); break; }
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
            Table_heroes_quality table = this.GetTable();
            if (null == table.ByteBuffer)
                return 0;

            return table.DataLength; 
        }
        
        /// <summary>
        /// 获得行数据
        /// </summary>
        /// <param name="id">字段ID的值</param>
        /// <returns>行数据</returns>
        public Heroes_qualityDataRow GetDataRow(int id)
        {
            if (data_row.ContainsKey(id))
                return data_row[id];

            Table_heroes_quality table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            if (data_row.Count >= table.DataLength)
                return null;
            
            if (null != row_index && row_index.ContainsKey(id))
            {
                DRheroes_quality? data = table.Data(row_index[id]);
                if (data.HasValue && data.Value.Id == id)
                {
                    Heroes_qualityDataRow datarow = new Heroes_qualityDataRow(data.Value, row_index[id]);
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
                DRheroes_quality? data = table.Data(i);
                if (data.HasValue)
                {
                    Heroes_qualityDataRow datarow = new Heroes_qualityDataRow(data.Value, i);
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
        public Heroes_qualityDataRow GetDataRowByIndex(int index)
        {
            Table_heroes_quality table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;

            if (index < 0 || index >= table.DataLength)
                return null;

            DRheroes_quality? data = table.Data(index);
            if (data.HasValue)
            {
                if (!data_row.ContainsKey(data.Value.Id))
                {
                    Heroes_qualityDataRow datarow = new Heroes_qualityDataRow(data.Value, index);
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
        public Dictionary<int, Heroes_qualityDataRow> GetAllData()
        {
            Table_heroes_quality table = this.GetTable();
            if (null == table.ByteBuffer)
                return null;
                
            int dataCount = table.DataLength;
            if (data_row.Count < dataCount)
            {
                for (int i = 0; i < table.DataLength; i++)
                {
                    DRheroes_quality? data = table.Data(i);
                    if (data.HasValue && !data_row.ContainsKey(data.Value.Id))
                    {
                        Heroes_qualityDataRow datarow = new Heroes_qualityDataRow(data.Value, i);
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
            table = Table_heroes_quality.GetRootAsTable_heroes_quality(byteBuffer);
            
            this.load_state = E_LoadState.Loaded;
        }

        public override void ResetTable()
        {
            base.ResetTable();

            this.data_row.Clear();
        }
        
        private Table_heroes_quality GetTable()
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
            return "heroes_quality.bytes";
        }

        protected override string GetIndexFileName()
        {
            return "heroes_quality_ids";
        }
        
        #endregion Framework Method
    }

    #endregion Table

    #region DataRow

    public class Heroes_qualityBaseDataRow : BaseDataRow
    {
        protected DRheroes_quality _datarow;

        public Heroes_qualityBaseDataRow(DRheroes_quality datarow, int index) : base(index)
        {
            this._datarow = datarow;
        }
        
        public override CSLuaTable GetLuaTable()
        {
            base.GetLuaTable();

            if (_LuaDataRow.Length <= 0)
            {
                if(this.HasKey("id")) _LuaDataRow.Set("id", this.Id);
                if(this.HasKey("pic")) _LuaDataRow.Set("pic", this.Pic);
                if(this.HasKey("level")) _LuaDataRow.Set("level", this.Level);
                if(this.HasKey("lv_add")) _LuaDataRow.Set("lv_add", this.LvAddArray);
                if(this.HasKey("type")) _LuaDataRow.Set("type", this.Type);
                if(this.HasKey("consume")) _LuaDataRow.Set("consume", this.ConsumeArray);
                if(this.HasKey("robot_consume")) _LuaDataRow.Set("robot_consume", this.RobotConsumeArray);
                if(this.HasKey("name")) _LuaDataRow.Set("name", this.Name);
                if(this.HasKey("color")) _LuaDataRow.Set("color", this.Color);
                if(this.HasKey("pic2")) _LuaDataRow.Set("pic2", this.Pic2);
                if(this.HasKey("pic3")) _LuaDataRow.Set("pic3", this.Pic3);
                if(this.HasKey("pic_color")) _LuaDataRow.Set("pic_color", this.PicColor);
                if(this.HasKey("pic4")) _LuaDataRow.Set("pic4", this.Pic4);
                if(this.HasKey("level_growth")) _LuaDataRow.Set("level_growth", this.LevelGrowth);
                if(this.HasKey("star")) _LuaDataRow.Set("star", this.Star);
                if(this.HasKey("limit_type")) _LuaDataRow.Set("limit_type", this.LimitType);

            }

            return _LuaDataRow;
        }

        protected override LuaValue GetLuaValue(string rowId)
        {
            LuaValue luaValue = new LuaValue();
            switch (rowId)
            {
                case "id": { luaValue.SetValue(this.Id); break; }
                case "pic": { luaValue.SetValue(this.Pic); break; }
                case "level": { luaValue.SetValue(this.Level); break; }
                case "lv_add": { luaValue.SetValue(this.LvAddArray); break; }
                case "type": { luaValue.SetValue(this.Type); break; }
                case "consume": { luaValue.SetValue(this.ConsumeArray); break; }
                case "robot_consume": { luaValue.SetValue(this.RobotConsumeArray); break; }
                case "name": { luaValue.SetValue(this.Name); break; }
                case "color": { luaValue.SetValue(this.Color); break; }
                case "pic2": { luaValue.SetValue(this.Pic2); break; }
                case "pic3": { luaValue.SetValue(this.Pic3); break; }
                case "pic_color": { luaValue.SetValue(this.PicColor); break; }
                case "pic4": { luaValue.SetValue(this.Pic4); break; }
                case "level_growth": { luaValue.SetValue(this.LevelGrowth); break; }
                case "star": { luaValue.SetValue(this.Star); break; }
                case "limit_type": { luaValue.SetValue(this.LimitType); break; }

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
                case "pic": { result = !this.IsEmpty(this.Pic); break; }
                case "level": { result = !this.IsEmpty(_datarow.Level); break; }
                case "lv_add": { result = _datarow.LvAddLength > 0; break; }
                case "type": { result = !this.IsEmpty(_datarow.Type); break; }
                case "consume": { result = _datarow.ConsumeLength > 0; break; }
                case "robot_consume": { result = _datarow.RobotConsumeLength > 0; break; }
                case "name": { result = !this.IsEmpty(this.Name); break; }
                case "color": { result = !this.IsEmpty(this.Color); break; }
                case "pic2": { result = !this.IsEmpty(this.Pic2); break; }
                case "pic3": { result = !this.IsEmpty(this.Pic3); break; }
                case "pic_color": { result = !this.IsEmpty(this.PicColor); break; }
                case "pic4": { result = !this.IsEmpty(this.Pic4); break; }
                case "level_growth": { result = !this.IsEmpty(_datarow.LevelGrowth); break; }
                case "star": { result = !this.IsEmpty(_datarow.Star); break; }
                case "limit_type": { result = !this.IsEmpty(_datarow.LimitType); break; }

                default:
                    break;
            }

            return result;
        }
        
        public int Id { get { return this.GetTableInt(_datarow.Id); } }

        private string _Pic = null;
        public string Pic { get { if (null == _Pic) _Pic = _datarow.Pic; return _Pic; } }

        public int Level { get { return this.GetTableInt(_datarow.Level); } }

        private int[] _LvAddArray = null;
        public int[] LvAddArray { get { if (null == _LvAddArray) _LvAddArray = _datarow.GetLvAddArray(); return _LvAddArray; } }
        public int LvAddArrayLength { get { if (null == this.LvAddArray) return 0; return this.LvAddArray.Length; } }

        public int Type { get { return this.GetTableInt(_datarow.Type); } }

        private int[] _ConsumeArray = null;
        public int[] ConsumeArray { get { if (null == _ConsumeArray) _ConsumeArray = _datarow.GetConsumeArray(); return _ConsumeArray; } }
        public int ConsumeArrayLength { get { if (null == this.ConsumeArray) return 0; return this.ConsumeArray.Length; } }

        private int[] _RobotConsumeArray = null;
        public int[] RobotConsumeArray { get { if (null == _RobotConsumeArray) _RobotConsumeArray = _datarow.GetRobotConsumeArray(); return _RobotConsumeArray; } }
        public int RobotConsumeArrayLength { get { if (null == this.RobotConsumeArray) return 0; return this.RobotConsumeArray.Length; } }

        private string _Name = null;
        public string Name { get { if (null == _Name) _Name = _datarow.Name; return _Name; } }

        private string _Color = null;
        public string Color { get { if (null == _Color) _Color = _datarow.Color; return _Color; } }

        private string _Pic2 = null;
        public string Pic2 { get { if (null == _Pic2) _Pic2 = _datarow.Pic2; return _Pic2; } }

        private string _Pic3 = null;
        public string Pic3 { get { if (null == _Pic3) _Pic3 = _datarow.Pic3; return _Pic3; } }

        private string _PicColor = null;
        public string PicColor { get { if (null == _PicColor) _PicColor = _datarow.PicColor; return _PicColor; } }

        private string _Pic4 = null;
        public string Pic4 { get { if (null == _Pic4) _Pic4 = _datarow.Pic4; return _Pic4; } }

        public int LevelGrowth { get { return this.GetTableInt(_datarow.LevelGrowth); } }

        public int Star { get { return this.GetTableInt(_datarow.Star); } }

        public int LimitType { get { return this.GetTableInt(_datarow.LimitType); } }


    }

    #endregion DataRow
}