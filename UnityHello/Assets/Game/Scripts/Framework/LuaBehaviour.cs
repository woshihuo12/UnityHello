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

    private bool mUsingUpdate = false;
    public bool UsingUpdate
    {
        get
        {
            return mUsingUpdate;
        }
        set
        {
            mUsingUpdate = value;
        }
    }

    private bool mUsingFixedUpdate = false;
    public bool UsingFixedUpdate
    {
        get
        {
            return mUsingFixedUpdate;
        }
        set
        {
            mUsingFixedUpdate = value;
        }
    }

    private bool mUsingLateUpdate = false;
    public bool UsingLateUpdate
    {
        get
        {
            return mUsingLateUpdate;
        }
        set
        {
            mUsingLateUpdate = value;
        }
    }

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

    private LuaFunction mFixedUpdateFunc = null;
    private LuaFunction mUpdateFunc = null;
    private LuaFunction mLateUpdateFunc = null;
    private LuaFunction mOnEnableFunc = null;
    private LuaFunction mOnDisableFunc = null;

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

    private void Awake()
    {
        mLuaState = SimpleLuaClient.GetMainState();
        if (mLuaState == null) return;

        mLuaTable = mLuaState.GetTable(name);

        if (mLuaTable == null)
        {
            Debug.LogWarning("mLuaTable is null:" + name);
            return;
        }

        mLuaTable["gameObject"] = gameObject;
        mLuaTable["transform"] = transform;
        mLuaTable["this"] = this;

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
    }

    private void Update()
    {
        if (UsingUpdate)
        {
            if (!CheckValid()) return;

            if (mUpdateFunc == null)
            {
                mUpdateFunc = mLuaTable.GetLuaFunction("Update") as LuaFunction;
            }
            if (mUpdateFunc != null)
            {
                mUpdateFunc.BeginPCall();
                mUpdateFunc.Push(Time.deltaTime);
                mUpdateFunc.Push(Time.unscaledDeltaTime);
                mUpdateFunc.PCall();
                mUpdateFunc.EndPCall();
            }
        }
    }

    private void FixedUpdate()
    {
        if (UsingFixedUpdate)
        {
            if (!CheckValid()) return;
            if (mFixedUpdateFunc == null)
            {
                mFixedUpdateFunc = mLuaTable.GetLuaFunction("FixedUpdate") as LuaFunction;
            }
            if (mFixedUpdateFunc != null)
            {
                mFixedUpdateFunc.BeginPCall();
                mFixedUpdateFunc.Push(Time.fixedDeltaTime);
                mFixedUpdateFunc.PCall();
                mFixedUpdateFunc.EndPCall();
            }
        }
    }

    private void LateUpdate()
    {
        if (UsingLateUpdate)
        {
            if (!CheckValid()) return;
            if (mLateUpdateFunc == null)
            {
                mLateUpdateFunc = mLuaTable.GetLuaFunction("LateUpdate") as LuaFunction;
            }
            if (mLateUpdateFunc != null)
            {
                mLateUpdateFunc.BeginPCall();
                mLateUpdateFunc.PCall();
                mLateUpdateFunc.EndPCall();
            }
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
                    luafunc.Call(go);
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
