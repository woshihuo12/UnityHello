using KEngine;
using UnityEngine;

namespace KEngine
{
    /// <summary>
    /// 静态对象加载，通常用于全局唯一的GameObject，
    /// 跟其它TextureLoader不一样的是,它会拷一份
    /// 原加载对象(AssetFileBridge)会被删除，节省内存
    /// </summary>
    public class StaticAssetLoader : AbstractResourceLoader
    {
        public UnityEngine.Object TheAsset // Copy
        {
            get { return (UnityEngine.Object)ResultObject; }
        }

        private AssetFileLoader _assetFileLoader;

        public override float Progress
        {
            get { return _assetFileLoader.Progress; }
        }

        public static StaticAssetLoader Load(string url, AssetFileLoader.AssetFileBridgeDelegate callback = null, LoaderMode loaderMode = LoaderMode.Async)
        {
            LoaderDelgate newCallback = null;
            if (callback != null)
            {
                newCallback = (isOk, obj) => callback(isOk, obj as UnityEngine.Object);
            }

            return AutoNew<StaticAssetLoader>(url, newCallback, false, loaderMode);
        }

        protected override void Init(string path, params object[] args)
        {
            var loaderMode = (LoaderMode)args[0];

            base.Init(path, args);
            if (string.IsNullOrEmpty(path))
                Log.Error("StaticAssetLoader 空资源路径!");

            _assetFileLoader = AssetFileLoader.Load(path, (_isOk, _obj) =>
            {
                OnFinish(_obj);

                if (Application.isEditor)
                    if (TheAsset != null)
                        KResoourceLoadedAssetDebugger.Create("StaticAsset", path, TheAsset);
            }, loaderMode);
        }

        protected override void OnFinish(object resultObj)
        {
            // 拷一份
            var copyAsset = Object.Instantiate(resultObj as UnityEngine.Object);

            base.OnFinish(copyAsset);
        }

        protected override void DoDispose()
        {
            base.DoDispose();
            _assetFileLoader.Release(IsBeenReleaseNow);
            GameObject.Destroy(TheAsset);
        }
    }

}
