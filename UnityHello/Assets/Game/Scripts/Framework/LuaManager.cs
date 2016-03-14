using UnityEngine;
using System.Collections;
using LuaInterface;
using System.IO;

public class LuaManager : Manager
{

    private void InitLuaLibrary()
    {
    }

    private void InitLuaPath()
    {
        //if (GameSetting.DebugMode)
        //{
        //    mLuaState.AddSearchPath(Application.dataPath + "/" + "Lua");
        //}
        //else
        //{
        //    mLuaState.AddSearchPath(Tools.DataPath + "lua");
        //}
    }

    private void Awake()
    {
        //mLuaState = new LuaState();
        //InitLuaLibrary();


        //LuaBinder.Bind(mLuaState);
        //LuaCoroutine.Register(mLuaState, this);
    }

    private void AddBundle(string bundleName)
    {
        string url = Tools.DataPath + bundleName;
        if (File.Exists(url))
        {
            AssetBundle bundle = AssetBundle.LoadFromFile(url);
            if (bundle != null)
            {
                bundleName = bundleName.Replace("Lua/", "");
                bundleName = bundleName.Replace(".unity3d", "");
                LuaFileUtils.Instance.AddSearchBundle(bundleName.ToLower(), bundle);
            }
        }
    }

    /// <summary>
    /// 初始化LuaBundle
    /// </summary>
    void InitLuaBundle()
    {
        LuaFileUtils.Instance.beZip = GameSetting.LuaBundleMode;
        if (LuaFileUtils.Instance.beZip)
        {
            AddBundle("Lua/Lua.unity3d");
            AddBundle("Lua/Lua_math.unity3d");
            AddBundle("Lua/Lua_system.unity3d");
            AddBundle("Lua/Lua_u3d.unity3d");
            AddBundle("Lua/Lua_Misc.unity3d");
            AddBundle("Lua/lua_lscripts.unity3d");
            AddBundle("Lua/lua_socket.unity3d");
            AddBundle("Lua/Lua_protobuf.unity3d");
        }
    }

    public void InitStart()
    {
        InitLuaPath();
        InitLuaBundle();
    }

    public object[] CallFunction(string funcName, params object[] args)
    {
        //LuaFunction func = mLuaState.GetFunction(funcName);
        //if (func != null)
        //{
        //    return func.Call(args);
        //}
        return null;
    }

    public void Close()
    {
    }
}
