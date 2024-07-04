
using UnityEngine;

public abstract class Singleton<T> where T : class, new()
{
    private static T sInstance = null;
    private static bool sApplicationIsQuitting = false;
    private static readonly object sysob = new object();

    ~Singleton()
    {
        sApplicationIsQuitting = true;
    }

    public static T Instance
    {
        get
        {
            if (sApplicationIsQuitting)
            {
                Debug.LogError("获取单例 error! 程序已经退出了");
                return null;
            }

            if (sInstance == null)
            {
                lock (sysob)
                {
                    if (sInstance == null)
                    {
                        sInstance = new T();
                    }
                }
            }
            return sInstance;
        }
    }
}

