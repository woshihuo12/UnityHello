using System;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    private static bool _destroyed;

    public static T instance
    {
        get
        {
            return GetInstance();
        }
    }

    public static T GetInstance()
    {
        if (_instance == null && !_destroyed)
        {
            GameObject gameObject = new GameObject(typeof(T).Name);
            _instance = gameObject.AddComponent<T>();
        }
        return _instance;
    }

    public static void DestroyInstance()
    {
        if (_instance != null)
        {
            UnityEngine.Object.Destroy(_instance.gameObject);
        }
        _destroyed = true;
        _instance = null;
    }

    public static void ClearDestroy()
    {
        DestroyInstance();
        _destroyed = false;
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = gameObject.GetComponent<T>();
        }
        UnityEngine.Object.DontDestroyOnLoad(gameObject);
        this.Init();
    }

    protected virtual void OnDestroy()
    {
        if (_instance != null)
        {
            _instance = null;
        }
    }

    public static bool HasInstance()
    {
        return _instance != null;
    }

    protected virtual void Init()
    {
    }
}
