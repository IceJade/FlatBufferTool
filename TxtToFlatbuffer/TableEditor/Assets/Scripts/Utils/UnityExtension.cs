//------------------------------------------------------------
// Game Framework v3.x
// Copyright © 2013-2018 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

/// <summary>
/// Unity 扩展。
/// </summary>
public static class UnityExtension
{
    public static int ToInt(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return 0;
        }

        if (str.Equals(" "))
            return 0;

        // 我们数值中会有大量的0-9这样的数值处理，所以这简单处理一下
        if (str.Length == 1)
        {
            if (str[0] >= '0' && str[0] <= '9')
            {
                return str[0] - '0';
            }
        }

        int i = 0;
        if (int.TryParse(str, out i) == false)
        {
            Debug.LogErrorFormat("ToInt error!!!! str: {0}", str);
        }

        return i;
    }


    public static int ToInt(this object obj)
    {
        if (obj is string)
        {
            return ToInt((string)obj);
        }

        int i = 0;
        try
        {
            //int.TryParse(obj.ToString(), out i);
            //return i;
            i = Convert.ToInt32(obj);
        }
        catch (Exception e)
        {
            // FIXME: 有些obj不能直接ToInt32，必须要ToString之后再转
            // 理论来说，这属于一个调用问题，但是这里也得做一个兼容，毕竟这个接口的参数是object
            return ToInt(obj.ToString());
        }
        return i;
    }

    public static float ToFloat(this string value)
    {
        return ToSingle(value);
    }

    public static float ToFloat(this object value)
    {
        return ToSingle(value);
    }

    public static float ToSingle(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return 0;
        }

        float i = 0f;
        try
        {
            i = Convert.ToSingle(value, CultureInfo.InvariantCulture);
        }
        catch (Exception e)
        {
            Debug.LogErrorFormat("string convert to single error : ", e);
        }
        return i;
    }

    public static float ToSingle(object value)
    {
        if (value is string str)
        {
            return ToFloat(str);
        }

        float i;
        try
        {
            i = Convert.ToSingle(value, CultureInfo.InvariantCulture);
        }
        catch (Exception e)
        {
            Debug.LogErrorFormat("object convert to single error : ", e);
            i = ToSingle(value.ToString());
        }
        return i;
    }

    public static bool IsZero(this float value)
    {
        return value > -0.0000001 && value < 0.0000001;
    }
}
