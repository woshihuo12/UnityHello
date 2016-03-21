#if ASYNC_MODE

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
    string mBaseDownloadingURL = string.Empty;
    private AssetBundleManifest mAssetBundleManifest = null;
    private Dictionary<string, string[]> mDependencies = new Dictionary<string, string[]>();
    private Dictionary<string, AssetBundleInfo> mLoadedAssetBundles = new Dictionary<string, AssetBundleInfo>();
    private Dictionary<string, List<LoadAssetRequest>> mLoadRequests = new Dictionary<string, List<LoadAssetRequest>>();

    class LoadAssetRequest
    {
        public Type mAssetType;
        public string[] mAssetNames;
        public LuaFunction mLuaFunc;
        public Action<UnityEngine.Object[]> mSharpFunc;
    }

    // Load AssetBundleManifest.
    public void Initialize(string manifestName, Action initOK)
    {
        mBaseDownloadingURL = Tools.GetRelativePath();
        LoadAssetBundleManifest(manifestName,
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
        LoadAsset<GameObject>(abName, new string[] { assetName }, func, null);
    }

    public void LoadPrefab(string abName, string[] assetNames, Action<UnityEngine.Object[]> func)
    {
        LoadAsset<GameObject>(abName, assetNames, func, null);
    }

    public void LoadPrefab(string abName, string[] assetNames, LuaFunction func)
    {
        LoadAsset<GameObject>(abName, assetNames, null, func);
    }

    private string GetRealAssetPath(string abName)
    {
        if (abName.Equals(Tools.GetOS()))
        {
            return abName;
        }
        abName = abName.ToLower();
        if (!abName.EndsWith(GameSetting.ExtName))
        {
            abName += GameSetting.ExtName;
        }
        if (abName.Contains("/"))
        {
            return abName;
        }

        if (mAssetBundleManifest == null) return null;

        string[] paths = mAssetBundleManifest.GetAllAssetBundles();
        for (int i = 0; i < paths.Length; i++)
        {
            int index = paths[i].LastIndexOf('/');
            string path = paths[i].Remove(0, index + 1);

            if (path.Equals(abName))
            {
                return paths[i];
            }
        }
        Debug.LogError("GetRealAssetPath Error:>>" + abName);
        return null;
    }

    private void LoadAssetBundleManifest(string manifestName, Action<UnityEngine.Object[]> action = null,
        LuaFunction func = null)
    {
        manifestName = GetRealAssetPath(manifestName);

        LoadAssetRequest request = new LoadAssetRequest();
        request.mAssetType = typeof(AssetBundleManifest);
        request.mAssetNames = new string[] { "AssetBundleManifest" };
        request.mLuaFunc = func;
        request.mSharpFunc = action;

        List<LoadAssetRequest> requests = null;
        if (!mLoadRequests.TryGetValue(manifestName, out requests))
        {
            requests = new List<LoadAssetRequest>();
            requests.Add(request);
            mLoadRequests.Add(manifestName, requests);
            StartCoroutine(DoLoadAsset<AssetBundleManifest>(manifestName));
        }
        else
        {
            requests.Add(request);
        }
    }

    /// <summary>
    /// 载入素材
    /// </summary>
    private void LoadAsset<T>(string abName, string[] assetNames, Action<UnityEngine.Object[]> action,
        LuaFunction func) where T : UnityEngine.Object
    {
        if (GameSetting.DevelopMode)
        {
            if (assetNames.Length > 0)
            {
                string prefabPath = assetNames[0];
                GameObject prefab = Resources.Load<GameObject>(prefabPath);
                if (prefab != null)
                {
                    if (action != null)
                    {
                        action(new GameObject[] { prefab });
                    }
                }
            }
        }
        else
        {
            abName = GetRealAssetPath(abName);

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

    private IEnumerator DoLoadAssetBundle(string abName, Type type)
    {
        string url = mBaseDownloadingURL + abName;

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

#else

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LuaInterface;
using UObject = UnityEngine.Object;


public class ResourceManager : Manager
{
    private string[] m_Variants = { };
    private AssetBundleManifest manifest;
    private AssetBundle shared, assetbundle;
    private Dictionary<string, AssetBundle> bundles;

    void Awake()
    {
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Initialize()
    {
        byte[] stream = null;
        string uri = string.Empty;
        bundles = new Dictionary<string, AssetBundle>();
        uri = Tools.DataPath + GameSetting.AssetDir;
        if (!File.Exists(uri)) return;
        stream = File.ReadAllBytes(uri);
        assetbundle = AssetBundle.CreateFromMemoryImmediate(stream);
        manifest = assetbundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
    }

    /// <summary>
    /// 载入素材
    /// </summary>
    public T LoadAsset<T>(string abname, string assetname) where T : UnityEngine.Object
    {
        abname = abname.ToLower();
        AssetBundle bundle = LoadAssetBundle(abname);
        return bundle.LoadAsset<T>(assetname);
    }

    public void LoadPrefab(string abName, string[] assetNames, LuaFunction func)
    {
        abName = abName.ToLower();
        List<UObject> result = new List<UObject>();
        for (int i = 0; i < assetNames.Length; i++)
        {
            UObject go = LoadAsset<UObject>(abName, assetNames[i]);
            if (go != null) result.Add(go);
        }
        if (func != null) func.Call((object)result.ToArray());
    }

    /// <summary>
    /// 载入AssetBundle
    /// </summary>
    /// <param name="abname"></param>
    /// <returns></returns>
    public AssetBundle LoadAssetBundle(string abname)
    {
        if (!abname.EndsWith(GameSetting.ExtName))
        {
            abname += GameSetting.ExtName;
        }
        AssetBundle bundle = null;
        if (!bundles.ContainsKey(abname))
        {
            byte[] stream = null;
            string uri = Tools.DataPath + abname;
            Debug.LogWarning("LoadFile::>> " + uri);
            LoadDependencies(abname);

            stream = File.ReadAllBytes(uri);
            bundle = AssetBundle.CreateFromMemoryImmediate(stream); //关联数据的素材绑定
            bundles.Add(abname, bundle);
        }
        else
        {
            bundles.TryGetValue(abname, out bundle);
        }
        return bundle;
    }

    /// <summary>
    /// 载入依赖
    /// </summary>
    /// <param name="name"></param>
    void LoadDependencies(string name)
    {
        if (manifest == null)
        {
            Debug.LogError("Please initialize AssetBundleManifest by calling AssetBundleManager.Initialize()");
            return;
        }
        // Get dependecies from the AssetBundleManifest object..
        string[] dependencies = manifest.GetAllDependencies(name);
        if (dependencies.Length == 0) return;

        for (int i = 0; i < dependencies.Length; i++)
            dependencies[i] = RemapVariantName(dependencies[i]);

        // Record and load all dependencies.
        for (int i = 0; i < dependencies.Length; i++)
        {
            LoadAssetBundle(dependencies[i]);
        }
    }

    // Remaps the asset bundle name to the best fitting asset bundle variant.
    string RemapVariantName(string assetBundleName)
    {
        string[] bundlesWithVariant = manifest.GetAllAssetBundlesWithVariant();

        // If the asset bundle doesn't have variant, simply return.
        if (System.Array.IndexOf(bundlesWithVariant, assetBundleName) < 0)
            return assetBundleName;

        string[] split = assetBundleName.Split('.');

        int bestFit = int.MaxValue;
        int bestFitIndex = -1;
        // Loop all the assetBundles with variant to find the best fit variant assetBundle.
        for (int i = 0; i < bundlesWithVariant.Length; i++)
        {
            string[] curSplit = bundlesWithVariant[i].Split('.');
            if (curSplit[0] != split[0])
                continue;

            int found = System.Array.IndexOf(m_Variants, curSplit[1]);
            if (found != -1 && found < bestFit)
            {
                bestFit = found;
                bestFitIndex = i;
            }
        }
        if (bestFitIndex != -1)
            return bundlesWithVariant[bestFitIndex];
        else
            return assetBundleName;
    }

    /// <summary>
    /// 销毁资源
    /// </summary>
    void OnDestroy()
    {
        if (shared != null) shared.Unload(true);
        if (manifest != null) manifest = null;
        Debug.Log("~ResourceManager was destroy!");
    }
}

#endif