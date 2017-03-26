using UnityEngine;
using System.Collections;
using LuaInterface;
using KEngine;

public class EngineConfig : Singleton<EngineConfig>
{
    private LuaTable mLuaTable = null;
    public override void Init()
    {
        var mLuaState = SimpleLuaClient.GetMainState();
        if (mLuaState == null) return;

        mLuaTable = mLuaState.GetTable("engine_config");
        if (mLuaTable == null)
        {
            Log.Info("mLuaTable is null:engine_config");
            return;
        }
    }

    public bool IsLoadAssetBundle()
    {
        if (mLuaTable == null)
        {
            return false;
        }

        var ret = mLuaTable["IsLoadAssetBundle"];
        return (bool)ret;
    }

    public bool IsEditorLoadAsset()
    {
        if (mLuaTable == null)
        {
            return false;
        }

        var ret = mLuaTable["IsEditorLoadAsset"];
        return (bool)ret;
    }
}