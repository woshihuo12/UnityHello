using UnityEngine;
using System.Collections;
using LuaInterface;

public class LuaBehaviour : View
{
    protected LuaTable mLuaTable;

    public bool UsingUpdate { get; set; }
    public bool UsingFixedUpdate { get; set; }
    public bool UsingLateUpdate { get; set; }

    protected bool mIsLuaReady = false;

    protected void Start()
    {
        CallMethod("Start");
    }

    protected void Update()
    {
        if (UsingUpdate)
        {
            CallMethod("Update");
        }
    }

    protected void FixedUpdate()
    {
        if (UsingFixedUpdate)
        {
            CallMethod("FixedUpdate");
        }
    }

    protected void LateUpdate()
    {
        if (UsingLateUpdate)
        {
            CallMethod("LateUpdate");
        }
    }

    protected void OnDestroy()
    {
        CallMethod("OnDestroy");
        if (mLuaTable != null)
        {
            mLuaTable.Dispose();
            mLuaTable = null;
        }
    }

    //设置执行的table对象
    protected void SetBehaviour(LuaTable myTable)
    {
        mLuaTable = myTable;

        mLuaTable["this"] = this;
        mLuaTable["transform"] = transform;
        mLuaTable["gameObject"] = gameObject;

        CallMethod("Awake");

        mIsLuaReady = true;
    }

    //获取绑定的lua脚本
    public LuaTable GetChunk()
    {
        return mLuaTable;
    }

    //设置lua脚本可直接使用变量
    public void SetEnv(string key, object val, bool isGlobal = false)
    {
        if (isGlobal)
        {
            LuaState curState = LuaMgr.GetLuaState();
            curState[key] = val;
        }
        else
        {
            if (mLuaTable != null)
            {
                mLuaTable[key] = val;
            }
        }
    }

    public object CallMethod(string function)
    {
        return CallMethod(function, null);
    }

    public object CallMethod(string function, params object[] args)
    {
        if (mLuaTable == null
            || mLuaTable[function] == null
            || !(mLuaTable[function] is LuaFunction))
        {
            return null;
        }

        LuaFunction func = (LuaFunction)mLuaTable[function];
        if (func == null) return null;
        try
        {
            if (args != null)
            {
                return func.Call(args);
            }
            else
            {
                func.BeginPCall(TracePCall.Ignore);
                func.PCall();
                object ret = func.CheckObject(typeof(GameObject));
                func.EndPCall();
                return ret;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(FormatException(e), gameObject);
        }
        return null;
    }
    public static string FormatException(System.Exception e)
    {
        string source = (string.IsNullOrEmpty(e.Source)) ? "<no source>" : e.Source.Substring(0, e.Source.Length - 2);
        return string.Format("{0}\nLua (at {1})", e.Message, source);
    }
}
