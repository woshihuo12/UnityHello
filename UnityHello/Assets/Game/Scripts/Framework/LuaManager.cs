using UnityEngine;
using System.Collections;
using LuaInterface;

public class LuaManager : Manager
{
    //public static LuaManager Instance
    //{
    //    get;
    //    private set;
    //}

    private LuaState mLuaState;

    private LuaFunction mUpdateFunction = null;
    private LuaFunction mLateUpdateFunction = null;
    private LuaFunction mFixedUpdateFunction = null;

    public LuaEvent UpdateEvent { get; private set; }

    public LuaEvent LateUpdateEvent { get; private set; }
    public LuaEvent FixedUpdateEvent { get; private set; }

    private void Awake()
    {
        mLuaState = new LuaState();
        mLuaState.OpenLibs(LuaDLL.luaopen_pb);
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

    public void DoFile(string fn)
    {

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

    private void OnApplicationQuit()
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
            //Instance = null;
        }
    }

    public LuaState GetLuaState()
    {
        return mLuaState;
    }
}
