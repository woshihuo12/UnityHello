using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using System.Text;

public class LuaBehaviour : MonoBehaviour
{
    private LuaState mLuaState = null;
    private Dictionary<string, LuaFunction> mButtonCallbacks = new Dictionary<string, LuaFunction>();

    private StringBuilder mSb = new StringBuilder(42);

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

    protected bool mUsingOnEnable = false;
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

    protected bool mUsingOnDisable = false;
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
    private LuaFunction mOnClickFunc = null;

    private void SafeRelease(ref LuaFunction luaRef)
    {
        if (luaRef != null)
        {
            luaRef.Dispose();
            luaRef = null;
        }
    }

    private string GetFuncName(string funcName)
    {
        return mSb.Remove(0, mSb.Length).Append(gameObject.name).Append(".").Append(funcName).ToString();
    }

    protected void Awake()
    {
        mLuaState = SimpleLuaClient.GetMainState();
        if (mLuaState == null) return;
        LuaFunction awakeFunc = mLuaState.GetFunction(GetFuncName("Awake"));
        if (awakeFunc != null)
        {
            awakeFunc.BeginPCall();
            awakeFunc.Push(gameObject);
            awakeFunc.PCall();
            awakeFunc.EndPCall();

            awakeFunc.Dispose();
            awakeFunc = null;
        }
    }

    protected void Start()
    {
        if (mLuaState == null) return;
        LuaFunction startFunc = mLuaState.GetFunction(GetFuncName("Start"));
        if (startFunc != null)
        {
            startFunc.BeginPCall();
            startFunc.PCall();
            startFunc.EndPCall();

            startFunc.Dispose();
            startFunc = null;
        }
    }

    protected void Update()
    {
        if (UsingUpdate)
        {
            if (mLuaState == null) return;

            if (mUpdateFunc == null)
            {
                mUpdateFunc = SimpleLuaClient.GetMainState().GetFunction(GetFuncName("Update"));
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

    protected void FixedUpdate()
    {
        if (UsingFixedUpdate)
        {
            if (mLuaState == null) return;
            if (mFixedUpdateFunc == null)
            {
                mFixedUpdateFunc = SimpleLuaClient.GetMainState().GetFunction(GetFuncName("FixedUpdate"));
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

    protected void LateUpdate()
    {
        if (UsingLateUpdate)
        {
            if (mLuaState == null) return;
            if (mLateUpdateFunc == null)
            {
                mLateUpdateFunc = SimpleLuaClient.GetMainState().GetFunction(GetFuncName("LateUpdate"));
            }
            if (mLateUpdateFunc != null)
            {
                mLateUpdateFunc.BeginPCall();
                mLateUpdateFunc.PCall();
                mLateUpdateFunc.EndPCall();
            }
        }
    }

    protected void OnEnable()
    {
        if (UsingOnEnable)
        {
            if (mLuaState == null) return;

            if (mOnEnableFunc == null)
            {
                mOnEnableFunc = SimpleLuaClient.GetMainState().GetFunction(GetFuncName("OnEnable"));
            }
            if (mOnEnableFunc != null)
            {
                mOnEnableFunc.BeginPCall();
                mOnEnableFunc.PCall();
                mOnEnableFunc.EndPCall();
            }
        }
    }

    protected void OnDisable()
    {
        if (UsingOnDisable)
        {
            if (mLuaState == null) return;

            if (mOnDisableFunc == null)
            {
                mOnDisableFunc = SimpleLuaClient.GetMainState().GetFunction(GetFuncName("OnDisable"));
            }
            if (mOnDisableFunc != null)
            {
                mOnDisableFunc.BeginPCall();
                mOnDisableFunc.PCall();
                mOnDisableFunc.EndPCall();
            }
        }
    }

    protected void OnClickEvent(GameObject go)
    {
        if (mLuaState == null) return;
        if (mOnClickFunc == null)
        {
            mOnClickFunc = mLuaState.GetFunction(GetFuncName("OnClick"));
        }
        if (mOnClickFunc != null)
        {
            mOnClickFunc.BeginPCall();
            mOnClickFunc.Push(go);
            mOnClickFunc.PCall();
            mOnClickFunc.EndPCall();
        }
    }

    public void AddClick(GameObject go, LuaFunction luafunc)
    {
        if (mLuaState == null) return;
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
        if (mLuaState == null) return;
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
        if (mLuaState == null) return;
        foreach (var de in mButtonCallbacks)
        {
            if (de.Value != null)
            {
                de.Value.Dispose();
            }
        }
        mButtonCallbacks.Clear();
    }

    protected void OnDestroy()
    {
        if (mLuaState == null) return;
        ClearClick();
        LuaFunction destroyFunc = mLuaState.GetFunction(GetFuncName("OnDestroy"));
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
        SafeRelease(ref mOnClickFunc);
    }
}
