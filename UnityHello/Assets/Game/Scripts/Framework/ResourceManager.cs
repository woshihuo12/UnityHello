using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

public class AssetBundleInfo
{
    public AssetBundle mAssetBundle;
    public int mReferencedCount;

    public AssetBundleInfo(AssetBundle ab)
    {
        mAssetBundle = ab;
        mReferencedCount = 1;
    }
}

public class ResourceManager : Manager
{
    class LoadAssetRequest
    {
        public Type mAssetType;
        public string[] mAssetNames;
        public LuaFunction mLuaFunc;
        public Action<UnityEngine.Object[]> mSharpFunc;
    }

    public static string AssetBundlePath = GameSetting.TransAssetPath + "/AssetBundles/";

    //public Dictionary<string, uint> AssetBundlesCrcPairs = new Dictionary<string, uint>();

    private AssetBundleManifest mAssetBundleManifest = null;

    private Dictionary<string, string[]> mDependencies = new Dictionary<string, string[]>();
    private Dictionary<string, AssetBundleInfo> mLoadedAssetBundles = new Dictionary<string, AssetBundleInfo>();
    private Dictionary<string, List<LoadAssetRequest>> mLoadRequests = new Dictionary<string, List<LoadAssetRequest>>();

    // Load AssetBundleManifest.
    public void Initialize(string manifestName, Action initOK)
    {
        LoadAsset<AssetBundleManifest>(manifestName, new string[] { "AssetBundleManifest" },
            delegate(UnityEngine.Object[] objs)
            {
                if (objs.Length > 0)
                {
                    mAssetBundleManifest = objs[0] as AssetBundleManifest;
                }
                if (initOK != null)
                {
                    initOK();
                }
            });
    }

    public void LoadPrefab(string abName, string assetName, Action<UnityEngine.Object[]> func)
    {
        LoadAsset<GameObject>(abName, new string[] { assetName }, func);
    }

    public void LoadPrefab(string abName, string[] assetNames, Action<UnityEngine.Object[]> func)
    {
        LoadAsset<GameObject>(abName, assetNames, func);
    }

    public void LoadPrefab(string abName, string[] assetNames, LuaFunction func)
    {
        LoadAsset<GameObject>(abName, assetNames, null, func);
    }

    private string GetRealAssetPath(string abName)
    {
        abName = abName.ToLower();
        if (!abName.EndsWith(GameConst.ExtName))
        {
            abName += GameConst.ExtName;
        }
        if (abName.Contains("/"))
        {
            return abName;
        }

        if (mAssetBundleManifest == null) return null;

        string[] paths = mAssetBundleManifest.GetAllAssetBundles();
        for (int i = 0; i < paths.Length; i++)
        {
            if (paths[i].Equals(abName))
            {
                return paths[i];
            }
        }
        Debug.LogError("GetRealAssetPath Error:>>" + abName);
        return null;
    }

    /// <summary>
    /// 载入素材
    /// </summary>
    private void LoadAsset<T>(string abName, string[] assetNames, Action<UnityEngine.Object[]> action = null,
        LuaFunction func = null) where T : UnityEngine.Object
    {
        //abName = GetRealAssetPath(abName);

        LoadAssetRequest request = new LoadAssetRequest();
        request.mAssetType = typeof(T);
        request.mAssetNames = assetNames;
        request.mLuaFunc = func;
        request.mSharpFunc = action;

        List<LoadAssetRequest> requests = null;
        if (!mLoadRequests.TryGetValue(abName, out requests))
        {
            requests = new List<LoadAssetRequest>();
            requests.Add(request);
            mLoadRequests.Add(abName, requests);
            StartCoroutine(DoLoadAsset<T>(abName));
        }
        else
        {
            requests.Add(request);
        }
    }

    private AssetBundleInfo GetLoadedAssetBundle(string abName)
    {
        AssetBundleInfo ret = null;

        mLoadedAssetBundles.TryGetValue(abName, out ret);
        if (ret == null) return null;

        // No dependencies are recorded, only the bundle itself is required.
        string[] dependencies = null;
        if (!mDependencies.TryGetValue(abName, out dependencies))
        {
            return ret;
        }

        // Make sure all dependencies are loaded
        foreach (string dependency in dependencies)
        {
            AssetBundleInfo dependentBundle;
            mLoadedAssetBundles.TryGetValue(dependency, out dependentBundle);
            if (dependentBundle == null) return null;
        }
        return ret;
    }

    private string GetAssetBundlePath(string bdName)
    {
        string platformFolder = "StandaloneWindows/";
        if (Application.platform == RuntimePlatform.Android)
        {
            platformFolder = "Android/";
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            platformFolder = "iOS/";
        }
        return AssetBundlePath + platformFolder + bdName;
    }

    private IEnumerator DoLoadAssetBundle(string abName, Type type)
    {
        string url = GetAssetBundlePath(abName);

        WWW download = null;
        if (type == typeof(AssetBundleManifest))
        {
            download = new WWW(url);
        }
        else
        {
            string[] dependencies = mAssetBundleManifest.GetAllDependencies(abName);
            if (dependencies.Length > 0)
            {
                mDependencies.Add(abName, dependencies);

                for (int i = 0; i < dependencies.Length; ++i)
                {
                    string depName = dependencies[i];
                    AssetBundleInfo bundleInfo = null;
                    if (mLoadedAssetBundles.TryGetValue(depName, out bundleInfo))
                    {
                        ++bundleInfo.mReferencedCount;
                    }
                    else if (!mLoadRequests.ContainsKey(depName))
                    {
                        yield return StartCoroutine(DoLoadAssetBundle(depName, type));
                    }
                }
            }

            download = WWW.LoadFromCacheOrDownload(url, mAssetBundleManifest.GetAssetBundleHash(abName), 0);
        }
        yield return download;

        AssetBundle assetObj = download.assetBundle;
        if (assetObj != null)
        {
            mLoadedAssetBundles.Add(abName, new AssetBundleInfo(assetObj));
        }
    }

    private IEnumerator DoLoadAsset<T>(string abName) where T : UnityEngine.Object
    {
        AssetBundleInfo bundleInfo = GetLoadedAssetBundle(abName);
        if (bundleInfo == null)
        {
            yield return StartCoroutine(DoLoadAssetBundle(abName, typeof(T)));

            bundleInfo = GetLoadedAssetBundle(abName);
            if (bundleInfo == null)
            {
                mLoadRequests.Remove(abName);
                Debug.LogError("OnLoadAsset----->>>" + abName);
                yield break;
            }
        }

        List<LoadAssetRequest> list = null;
        if (!mLoadRequests.TryGetValue(abName, out list))
        {
            mLoadRequests.Remove(abName);
            yield break;
        }

        for (int i = 0; i < list.Count; ++i)
        {
            string[] assetNames = list[i].mAssetNames;
            List<UnityEngine.Object> result = new List<UnityEngine.Object>();

            AssetBundle ab = bundleInfo.mAssetBundle;
            for (int j = 0; j < assetNames.Length; ++j)
            {
                string assetPath = assetNames[j];
                AssetBundleRequest request = ab.LoadAssetAsync(assetPath, list[i].mAssetType);
                yield return request;
                result.Add(request.asset);
            }

            if (list[i].mSharpFunc != null)
            {
                list[i].mSharpFunc(result.ToArray());
                list[i].mSharpFunc = null;
            }

            if (list[i].mLuaFunc != null)
            {
                list[i].mLuaFunc.Call((object)result.ToArray());
                list[i].mLuaFunc.Dispose();
                list[i].mLuaFunc = null;
            }
            ++bundleInfo.mReferencedCount;
        }

        mLoadRequests.Remove(abName);
    }

    public void UnloadAssetBundle(string abName)
    {
        abName = GetRealAssetPath(abName);
        Debug.Log(mLoadedAssetBundles.Count + " assetbundle(s) in memroy before unloading " + abName);
        UnloadAssetBundleInternal(abName);
        UnloadDependencies(abName);
        Debug.Log(mLoadedAssetBundles.Count + " assetbundle(s) in memory after unloading " + abName);
    }

    private void UnloadDependencies(string abName)
    {
        string[] dependencies = null;
        if (!mDependencies.TryGetValue(abName, out dependencies)) return;

        // Loop dependencies.
        foreach (string dependency in dependencies)
        {
            UnloadAssetBundleInternal(dependency);
        }
        mDependencies.Remove(abName);
    }

    private void UnloadAssetBundleInternal(string abName)
    {
        AssetBundleInfo bundle = GetLoadedAssetBundle(abName);
        if (bundle == null) return;

        if (--bundle.mReferencedCount == 0)
        {
            bundle.mAssetBundle.Unload(false);
            mLoadedAssetBundles.Remove(abName);
            Debug.Log(abName + " has been unloaded successfully");
        }
    }
}
