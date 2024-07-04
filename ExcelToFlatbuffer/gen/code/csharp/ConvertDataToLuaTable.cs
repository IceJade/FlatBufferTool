using System.Collections;
using System.Collections.Generic;
using LF;
using XLua;

public class ConvertDataToLuaTable
{
    public static LuaTable ConvertToLuaTable(LuaValue _luaValue)
    {
        LuaTable tbl = LuaManager.Instance.LuaEnv.NewTable();
        switch (_luaValue.type)
        {
            case 4: //int array
                ArrayToLuaTable<int>(ref tbl, _luaValue);
                break;
            case 5: //float array
                ArrayToLuaTable<float>(ref tbl, _luaValue);
                break;
            case 6: //string array
                ArrayToLuaTable<string>(ref tbl, _luaValue);
                break;
            case 7: //dicII
                DicVV_ToLuaTable<int, int>(ref tbl, _luaValue);
                break;
            case 8: //dicIS
                DicVV_ToLuaTable<int, string>(ref tbl, _luaValue);
                break;
            case 9: //dicSI
                DicVV_ToLuaTable<string, int>(ref tbl, _luaValue);
                break;
            case 10: //dicSS
                DicVV_ToLuaTable<string, string>(ref tbl, _luaValue);
                break;
        }

        return tbl;
    }

    public static void ArrayToLuaTable<T>(ref LuaTable tbl, LuaValue _luaValue)
    {
        T[] arrayList = (T[]) _luaValue.objValue;
        if (arrayList == null)
            return;
        for (int i = 0; i < arrayList.Length; i++)
        {
            tbl.Set<int, T>(i+1, arrayList[i]);
        }
    }

    public static void DicVV_ToLuaTable<T1, T2>(ref LuaTable tbl, LuaValue _luaValue)
    {
        Dictionary<T1, T2> dictionary = (Dictionary<T1, T2>) _luaValue.objValue;
        foreach (var iter in dictionary)
        {
            tbl.Set<T1, T2>((iter.Key), iter.Value);
        }
    }

}
