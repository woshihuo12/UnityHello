using UnityEngine;
using System.Collections;

public class Singleton<T> : BaseObject
    where T : Singleton<T>, new()
{
    private static T sInstance = null;
    public static T Instance()
    {
        if (sInstance == null)
        {
            sInstance = new T();
        }
        return sInstance;
    }
}
