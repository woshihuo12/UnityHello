using UnityEngine;
using System.Collections;
using System;

namespace KEngine
{
    /// <summary>
    /// 加载模式，同步或异步
    /// </summary>
    public enum LoaderMode
    {
        Async,
        Sync,
    }
    public class AssetBundleLoader : AbstractResourceLoader
    {
        public delegate void CAssetBundleLoaderDelegate(bool isOk, AssetBundle ab);

        public static Action<string> NewAssetBundleLoaderEvent;
        public static Action<AssetBundleLoader> AssetBundlerLoaderErrorEvent;

        private KWWWLoader _wwwLoader;
        private KAssetBundleParser BundleParser;
        //private bool UnloadAllAssets; // Dispose时赋值
        public AssetBundle Bundle
        {
            get { return ResultObject as AssetBundle; }
        }

        private string RelativeResourceUrl;
        /// <summary>
        /// AssetBundle加载方式
        /// </summary>
        private LoaderMode _loaderMode;

        /// <summary>
        /// AssetBundle读取原字节目录
        /// </summary>
        //private KResourceInAppPathType _inAppPathType;
        public static AssetBundleLoader Load(string url, CAssetBundleLoaderDelegate callback = null,
            LoaderMode loaderMode = LoaderMode.Async)
        {
            LoaderDelgate newCallback = null;
            if (callback != null)
            {
                newCallback = (isOk, obj) => callback(isOk, obj as AssetBundle);
            }
            var newLoader = AutoNew<AssetBundleLoader>(url, newCallback, false, loaderMode);
            return newLoader;
        }

#if UNITY_5
        private static bool _hasPreloadAssetBundleManifest = false;
        private static AssetBundle _mainAssetBundle;
        private static AssetBundleManifest _assetBundleManifest;

        /// <summary>
        /// Unity5下，使用manifest进行AssetBundle的加载
        /// </summary>
        static void PreLoadManifest()
        {
            if (_hasPreloadAssetBundleManifest)
            {
                return;
            }
            _hasPreloadAssetBundleManifest = true;
            //var mainAssetBundlePath = string.Format("{0}/{1}/{1}", KResourceModule.BundlesDirName,KResourceModule.BuildPlatformName);
            HotBytesLoader bytesLoader = HotBytesLoader.Load(KResourceManager.BuildPlatformName, LoaderMode.Sync);//string.Format("{0}/{1}", KResourceModule.BundlesDirName, KResourceModule.BuildPlatformName), LoaderMode.Sync);
            _mainAssetBundle = AssetBundle.LoadFromMemory(bytesLoader.Bytes);//KResourceModule.LoadSyncFromStreamingAssets(mainAssetBundlePath));
            _assetBundleManifest = _mainAssetBundle.LoadAsset("AssetBundleManifest") as AssetBundleManifest;
            Debuger.Assert(_mainAssetBundle);
            Debuger.Assert(_assetBundleManifest);
        }
#endif

        protected override void Init(string url, params object[] args)
        {
#if UNITY_5
            PreLoadManifest();
#endif
            base.Init(url);
            _loaderMode = (LoaderMode)args[0];
            if (NewAssetBundleLoaderEvent != null)
                NewAssetBundleLoaderEvent(url);
            RelativeResourceUrl = url;
            KResourceManager.LogRequest("AssetBundle", RelativeResourceUrl);
            var resMgr = AppFacade.Instance.GetManager<KResourceManager>();
            if (resMgr != null)
            {
                resMgr.StartCoroutine(LoadAssetBundle(url));
            }
        }

#if UNITY_5
        /// <summary>
        /// 依赖的AssetBundleLoader
        /// </summary>
        private AssetBundleLoader[] _depLoaders;
#endif

        private IEnumerator LoadAssetBundle(string relativeUrl)
        {
#if UNITY_5
            // Unity 5下，自动进行依赖加载
            var abPath = relativeUrl.ToLower();
            var deps = _assetBundleManifest.GetAllDependencies(abPath);
            _depLoaders = new AssetBundleLoader[deps.Length];
            for (var d = 0; d < deps.Length; d++)
            {
                var dep = deps[d];
                _depLoaders[d] = AssetBundleLoader.Load(dep, null, _loaderMode);
            }
            for (var l = 0; l < _depLoaders.Length; l++)
            {
                var loader = _depLoaders[l];
                while (!loader.IsCompleted)
                {
                    yield return null;
                }
            }
#endif

#if UNITY_5
            // Unity 5 AssetBundle自动转小写
            relativeUrl = relativeUrl.ToLower();
#endif
            var bytesLoader = HotBytesLoader.Load(relativeUrl, _loaderMode);
            while (!bytesLoader.IsCompleted)
            {
                yield return null;
            }
            if (!bytesLoader.IsSuccess)
            {
                if (AssetBundlerLoaderErrorEvent != null)
                {
                    AssetBundlerLoaderErrorEvent(this);
                }
                Log.Error("[AssetBundleLoader]Error Load Bytes AssetBundle: {0}", relativeUrl);
                OnFinish(null);
                yield break;
            }

            byte[] bundleBytes = bytesLoader.Bytes;
            Progress = 1 / 2f;
            bytesLoader.Release(); // 字节用完就释放

            BundleParser = new KAssetBundleParser(RelativeResourceUrl, bundleBytes);
            while (!BundleParser.IsFinished)
            {
                if (IsReadyDisposed) // 中途释放
                {
                    OnFinish(null);
                    yield break;
                }
                Progress = BundleParser.Progress / 2f + 1 / 2f; // 最多50%， 要算上WWWLoader的嘛
                yield return null;
            }

            Progress = 1f;
            var assetBundle = BundleParser.Bundle;
            if (assetBundle == null)
                Log.Error("WWW.assetBundle is NULL: {0}", RelativeResourceUrl);

            OnFinish(assetBundle);

            //Array.Clear(cloneBytes, 0, cloneBytes.Length);  // 手工释放内存

            //GC.Collect(0);// 手工释放内存
        }
    }
}