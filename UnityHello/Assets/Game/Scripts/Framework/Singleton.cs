using System;

public class Singleton<T> where T : Singleton<T>, new()
{
    private static T s_instance;

    public static T instance
    {
        get
        {
            if (s_instance == null)
            {
                CreateInstance();
            }
            return s_instance;
        }
    }

    protected Singleton()
    {
    }

    public static void CreateInstance()
    {
        if (s_instance == null)
        {
            s_instance = new T();
            s_instance.Init();
        }
    }

    public static void DestroyInstance()
    {
        if (s_instance != null)
        {
            s_instance.UnInit();
            s_instance = null;
        }
    }

    public static T GetInstance()
    {
        if (s_instance == null)
        {
            CreateInstance();
        }
        return s_instance;
    }

    public static bool HasInstance()
    {
        return s_instance != null;
    }

    public virtual void Init()
    {
    }

    public virtual void UnInit()
    {
    }
}