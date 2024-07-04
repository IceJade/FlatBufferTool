using System.Collections.Generic;

namespace LF
{
    public class CSLuaTable
    {
        private Dictionary<string, object> datas = new Dictionary<string, object>(16);

        static public string[] EmptyStringArray = new string[0];
        static public int[] EmptyIntArray = new int[0];
        
        public int Length { get { return null != datas ? datas.Count : 0; } }

        public void Set(string key, object value)
        {
            if (datas.ContainsKey(key))
                datas[key] = value;
            else
                datas.Add(key, value);
        }

        public object Get(string key)
        {
            if (datas.ContainsKey(key))
                return datas[key];

            return null;
        }

        public bool HasKey(string key)
        {
            if (datas.ContainsKey(key))
                return true;

            return false;
        }

        public int GetInt(string key, int defaultValue = 0)
        {
            if (!HasKey(key))
                return defaultValue;

            if (datas[key] is int)
                return (int)datas[key];

            int ret;
            if (!int.TryParse(datas[key].ToString(), out ret))
            {
                GameFramework.Log.Error("CSLuaTable::GetInt => data type is not match, or not find [id:{0}, column:{1}]", this.GetInt("id"), key);
                return defaultValue;
            }

            return ret;
        }

        public float GetFloat(string key, float defaultValue = 0.0f)
        {
            if (!HasKey(key))
                return defaultValue;

            if (datas[key] is float)
                return (float)datas[key];

            float ret;
            if (!float.TryParse((string)datas[key], out ret))
            {
                GameFramework.Log.Error("CSLuaTable::GetFloat => data type is not match, or not find [id:{0}, column:{1}]", this.GetInt("id"), key);
                return defaultValue;
            }

            return ret;
        }

        public string GetString(string key, string defaultValue = "")
        {
            object ret;
            if (datas.TryGetValue(key, out ret))
            {
                if (ret is string)
                    return (string)ret;
                else if (ret is int)
                    return ((int)ret).ToString();
                else if (ret is float)
                    return ((float)ret).ToString();
                else
                    return ret.ToString();
            }
            //else
            //{
            //    GameFramework.Log.Error("CSLuaTable::GetString => data type is not match, or not find [id:{0}, column:{1}]", this.GetInt("id"), key);
            //}

            return defaultValue;
        }

        public object this[string key]
        {
            get
            {
                if(datas.ContainsKey(key))
                    return datas[key];

                return null;
            }
            set
            {
                if (datas.ContainsKey(key))
                    datas[key] = value;
                else
                    datas.Add(key, value);
            }
        }

        /// <summary>
        /// 键值是否为空(在表中为空字符串的值,包括int、float、string及其数组类型)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsEmpty(string key)
        {
            bool result = false;

            object ret;
            if (datas.TryGetValue(key, out ret))
            {
                if (ret is string)
                    result = string.IsNullOrEmpty((string)ret);
                else if (ret is int)
                    result = ((int)ret).IsTEmpty();
                else if (ret is float)
                    result = ((float)ret).IsTEmpty();
                else
                    result = (ret == null);
            }

            return result;
        }
    }
}