using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

public class LuaBehaviour : MonoBehaviour
{
    private LuaState mLuaState = null;
    private LuaTable mLuaTable = null;

    private Dictionary<string, LuaFunction> mButtonCallbacks = new Dictionary<string, LuaFunction>();

    private LuaFunction mFixedUpdateFunc = null;
    private LuaFunction mUpdateFunc = null;
    private LuaFunction mLateUpdateFunc = null;

    private LuaFunction mOnEnableFunc = null;
    private LuaFunction mOnDisableFunc = null;

    private bool mUsingOnEnable = false;
    public bool UsingOnEnable
    {
        get
        {
            return mUsingOnEnable;
        }
        set
        {
            mUsingOnEnable = value;
        }
    }

    private bool mUsingOnDisable = false;
    public bool UsingOnDisable
    {
        get
        {
            return mUsingOnDisable;
        }
        set
        {
            mUsingOnDisable = value;
        }
    }

    private bool mIsStarted = false;

    private void SafeRelease(ref LuaFunction func)
    {
        if (func != null)
        {
            func.Dispose();
            func = null;
        }
    }

    private void SafeRelease(ref LuaTable table)
    {
        if (table != null)
        {
            table.Dispose();
            table = null;
        }
    }

    private bool CheckValid()
    {
        if (mLuaState == null) return false;
        if (mLuaTable == null) return false;
        return true;
    }

    public void Init(LuaTable tb)
    {
        mLuaState = SimpleLuaClient.GetMainState();
        if (mLuaState == null) return;

        if (tb == null)
        {
            mLuaTable = mLuaState.GetTable(name);
        }
        else
        {
            mLuaTable = tb;
        }
        if (mLuaTable == null)
        {
            Debug.LogWarning("mLuaTable is null:" + name);
            return;
        }
        mLuaTable["gameObject"] = gameObject;
        mLuaTable["transform"] = transform;
        mLuaTable["lua_behaviour"] = this;

        LuaFunction awakeFunc = mLuaTable.GetLuaFunction("Awake") as LuaFunction;
        if (awakeFunc != null)
        {
            awakeFunc.BeginPCall();
            awakeFunc.Push(mLuaTable);
            awakeFunc.PCall();
            awakeFunc.EndPCall();

            awakeFunc.Dispose();
            awakeFunc = null;
        }

        mUpdateFunc = mLuaTable.GetLuaFunction("Update") as LuaFunction;
        mFixedUpdateFunc = mLuaTable.GetLuaFunction("FixedUpdate") as LuaFunction;
        mLateUpdateFunc = mLuaTable.GetLuaFunction("LateUpdate") as LuaFunction;
    }

    private void Start()
    {
        if (!CheckValid()) return;

        LuaFunction startFunc = mLuaTable.GetLuaFunction("Start") as LuaFunction;
        if (startFunc != null)
        {
            startFunc.BeginPCall();
            startFunc.Push(mLuaTable);
            startFunc.PCall();
            startFunc.EndPCall();

            startFunc.Dispose();
            startFunc = null;
        }

        AddUpdate();
        mIsStarted = true;
    }

    private void AddUpdate()
    {
        if (!CheckValid()) return;

        LuaLooper luaLooper = SimpleLuaClient.Instance.GetLooper();
        if (luaLooper == null) return;

        if (mUpdateFunc != null)
        {
            luaLooper.UpdateEvent.Add(mUpdateFunc, mLuaTable);
        }

        if (mLateUpdateFunc != null)
        {
            luaLooper.LateUpdateEvent.Add(mLateUpdateFunc, mLuaTable);
        }

        if (mFixedUpdateFunc != null)
        {
            luaLooper.FixedUpdateEvent.Add(mFixedUpdateFunc, mLuaTable);
        }
    }

    private void RemoveUpdate()
    {
        if (!CheckValid()) return;

        LuaLooper luaLooper = SimpleLuaClient.Instance.GetLooper();
        if (luaLooper == null) return;

        if (mUpdateFunc != null)
        {
            luaLooper.UpdateEvent.Remove(mUpdateFunc, mLuaTable);
        }
        if (mLateUpdateFunc != null)
        {
            luaLooper.LateUpdateEvent.Remove(mLateUpdateFunc, mLuaTable);
        }
        if (mFixedUpdateFunc != null)
        {
            luaLooper.FixedUpdateEvent.Remove(mFixedUpdateFunc, mLuaTable);
        }
    }

    private void OnEnable()
    {
        if (UsingOnEnable)
        {
            if (!CheckValid()) return;

            if (mOnEnableFunc == null)
            {
                mOnEnableFunc = mLuaTable.GetLuaFunction("OnEnable") as LuaFunction;
            }
            if (mOnEnableFunc != null)
            {
                mOnEnableFunc.BeginPCall();
                mOnEnableFunc.PCall();
                mOnEnableFunc.EndPCall();
            }
        }

        if (mIsStarted)
        {
            AddUpdate();
        }
    }

    private void OnDisable()
    {
        if (UsingOnDisable)
        {
            if (!CheckValid()) return;

            if (mOnDisableFunc == null)
            {
                mOnDisableFunc = mLuaTable.GetLuaFunction("OnDisable") as LuaFunction;
            }
            if (mOnDisableFunc != null)
            {
                mOnDisableFunc.BeginPCall();
                mOnDisableFunc.PCall();
                mOnDisableFunc.EndPCall();
            }
        }

        RemoveUpdate();
    }

    public void AddClick(GameObject go, LuaFunction luafunc)
    {
        if (!CheckValid()) return;
        if (go == null || luafunc == null) return;
        if (!mButtonCallbacks.ContainsKey(go.name))
        {
            mButtonCallbacks.Add(go.name, luafunc);
            go.GetComponent<Button>().onClick.AddListener(
                delegate()
                {
                    luafunc.BeginPCall();
                    luafunc.Push(go);
                    luafunc.PCall();
                    luafunc.EndPCall();
                }
            );
        }
    }

    public void RemoveClick(GameObject go)
    {
        if (!CheckValid()) return;
        if (go == null) return;
        LuaFunction luafunc = null;
        if (mButtonCallbacks.TryGetValue(go.name, out luafunc))
        {
            luafunc.Dispose();
            luafunc = null;
            mButtonCallbacks.Remove(go.name);
        }
    }

    public void ClearClick()
    {
        foreach (var de in mButtonCallbacks)
        {
            if (de.Value != null)
            {
                de.Value.Dispose();
            }
        }
        mButtonCallbacks.Clear();
    }

    private void OnDestroy()
    {
        if (!CheckValid()) return;
        ClearClick();
        LuaFunction destroyFunc = mLuaTable.GetLuaFunction("OnDestroy") as LuaFunction;
        if (destroyFunc != null)
        {
            destroyFunc.BeginPCall();
            destroyFunc.PCall();
            destroyFunc.EndPCall();

            destroyFunc.Dispose();
            destroyFunc = null;
        }

        SafeRelease(ref mFixedUpdateFunc);
        SafeRelease(ref mUpdateFunc);
        SafeRelease(ref mLateUpdateFunc);
        SafeRelease(ref mOnEnableFunc);
        SafeRelease(ref mOnDisableFunc);
        SafeRelease(ref mLuaTable);
    }
}
