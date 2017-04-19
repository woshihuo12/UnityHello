using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using KEngine;
using System;
using LuaInterface;

public class UIAtlas
{
    private KAtlasLoader mAtlasLoader;

    private string mAtlasName;
    public string AtlasName
    {
        get
        {
            return "BuildByDir/ui/atlas/common1/" + mAtlasName + ".asset";
        }
    }

    public void Init(string atlasName)
    {
        mAtlasName = atlasName;
    }

    public IEnumerator GetSprite(string objName, Action<Sprite> doneHandler)
    {
        if (mAtlasLoader == null)
        {
            mAtlasLoader = KAtlasLoader.Load(AtlasName);
        }

        while (!mAtlasLoader.IsCompleted)
        {
            yield return null;
        }

        Sprite curSp = null;
        if (mAtlasLoader.mAtlasPacker != null)
        {
            curSp = mAtlasLoader.mAtlasPacker.GetSprite(objName);
        }
        if (doneHandler != null)
        {
            doneHandler(curSp);
        }
    }

    public void Destroy()
    {
        if (mAtlasLoader != null)
        {
            mAtlasLoader.Release();
        }
    }
}

public class UIAtlasMgr
{
    private static UIAtlasMgr sInstance = null;
    public static UIAtlasMgr Instance()
    {
        if (sInstance == null)
        {
            sInstance = new UIAtlasMgr();
        }
        return sInstance;
    }

    private Dictionary<string, UIAtlas> mAtlasCache = new Dictionary<string, UIAtlas>();

    public void GetSprite(string atlasName, string spriteName, LuaFunction luaCallback)
    {
        UIAtlas tmpAtlas;
        if (!mAtlasCache.TryGetValue(atlasName, out tmpAtlas) || tmpAtlas == null)
        {
            tmpAtlas = new UIAtlas();
            tmpAtlas.Init(atlasName);
            mAtlasCache[atlasName] = tmpAtlas;
        }
        AppFacade.Instance.GetManager<KResourceManager>().StartCoroutine(
            tmpAtlas.GetSprite(spriteName, (sp) =>
            {
                if (luaCallback != null)
                {
                    luaCallback.BeginPCall();
                    luaCallback.Push(sp);
                    luaCallback.PCall();
                    luaCallback.EndPCall();

                    luaCallback.Dispose();
                    luaCallback = null;
                }
            }));
    }
}