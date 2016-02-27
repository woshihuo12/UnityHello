using UnityEngine;
using System.Collections;
using LuaInterface;

public class LuaManager : Manager
{
    private LuaState mLuaState;

    private LuaFunction mUpdateFunction = null;
    private LuaFunction mLateUpdateFunction = null;
    private LuaFunction mFixedUpdateFunction = null;

    public LuaEvent UpdateEvent { get; private set; }

    public LuaEvent LateUpdateEvent { get; private set; }
    public LuaEvent FixedUpdateEvent { get; private set; }

    private void InitLuaLibrary()
    {
        mLuaState.OpenLibs(LuaDLL.luaopen_pb);
    }

    private void InitLuaPath()
    {
        if (GameSetting.DebugMode)
        {
            mLuaState.AddSearchPath(Application.dataPath + "/" + "Lua");
        }
        else
        {
            mLuaState.AddSearchPath(Tools.DataPath + "lua");
        }
    }

    private void Awake()
    {
        mLuaState = new LuaState();
        InitLuaLibrary();


        LuaBinder.Bind(mLuaState);
        LuaCoroutine.Register(mLuaState, this);
    }

    private LuaEvent GetEvent(string name)
    {
        LuaTable table = mLuaState.GetTable(name);
        LuaEvent e = new LuaEvent(table);
        table.Dispose();
        table = null;
        return e;
    }

    public void InitStart()
    {
        LuaFileUtils.Instance.AddSearchPath("Lua");

        mLuaState.Start();
        mLuaState.DoFile("Main.lua");

        mUpdateFunction = mLuaState.GetFunction("Update");
        mLateUpdateFunction = mLuaState.GetFunction("LateUpdate");
        mFixedUpdateFunction = mLuaState.GetFunction("FixedUpdate");

        LuaFunction main = mLuaState.GetFunction("Main");
        main.Call();
        main.Dispose();
        main = null;

        UpdateEvent = GetEvent("UpdateBeat");
        LateUpdateEvent = GetEvent("LateUpdateBeat");
        FixedUpdateEvent = GetEvent("FixedUpdateBeat");
    }

    public object[] CallFunction(string funcName, params object[] args)
    {
        LuaFunction func = mLuaState.GetFunction(funcName);
        if (func != null)
        {
            return func.Call(args);
        }
        return null;
    }

    private void Update()
    {
        if (mUpdateFunction != null)
        {
            mUpdateFunction.BeginPCall(TracePCall.Ignore);
            mUpdateFunction.Push(Time.deltaTime);
            mUpdateFunction.Push(Time.unscaledDeltaTime);
            mUpdateFunction.PCall();
            mUpdateFunction.EndPCall();
        }

        mLuaState.Collect();

#if UNITY_EDITOR
        mLuaState.CheckTop();
#endif
    }

    private void LateUpdate()
    {
        if (mLateUpdateFunction != null)
        {
            mLateUpdateFunction.BeginPCall(TracePCall.Ignore);
            mLateUpdateFunction.PCall();
            mLateUpdateFunction.EndPCall();
        }
    }

    private void FixedUpdate()
    {
        if (mFixedUpdateFunction != null)
        {
            mFixedUpdateFunction.BeginPCall(TracePCall.Ignore);
            mFixedUpdateFunction.Push(Time.fixedDeltaTime);
            mFixedUpdateFunction.PCall();
            mFixedUpdateFunction.EndPCall();
        }
    }

    public object[] DoFile(string filename)
    {
        return mLuaState.DoFile(filename);
    }

    public void LuaGC()
    {
        mLuaState.LuaGC(LuaGCOptions.LUA_GCCOLLECT);
    }

    private void SafeRelease(ref LuaFunction luaRef)
    {
        if (luaRef != null)
        {
            luaRef.Dispose();
            luaRef = null;
        }
    }

    private void SafeRelease(ref LuaEvent luaEvent)
    {
        if (luaEvent != null)
        {
            luaEvent.Dispose();
            luaEvent = null;
        }
    }

    public LuaState GetLuaState()
    {
        return mLuaState;
    }

    public void Close()
    {
        if (mLuaState != null)
        {
            SafeRelease(ref mUpdateFunction);
            SafeRelease(ref mLateUpdateFunction);
            SafeRelease(ref mFixedUpdateFunction);

            if (UpdateEvent != null)
            {
                UpdateEvent.Dispose();
                UpdateEvent = null;
            }

            if (LateUpdateEvent != null)
            {
                LateUpdateEvent.Dispose();
                LateUpdateEvent = null;
            }

            if (FixedUpdateEvent != null)
            {
                FixedUpdateEvent.Dispose();
                FixedUpdateEvent = null;
            }

            mLuaState.Dispose();
            mLuaState = null;
        }
    }
}
