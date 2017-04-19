using UnityEngine;
using System.Collections;

namespace KEngine
{
    public class KAtlasLoader : AbstractResourceLoader
    {
        public AssetPacker mAtlasPacker
        {
            get
            {
                return ResultObject as AssetPacker;
            }
        }

        public delegate void CAtlasLoaderDelegate(bool isOk, AssetPacker tex);

        private AssetFileLoader AssetFileBridge;

        public override float Progress
        {
            get
            {
                if (AssetFileBridge == null)
                {
                    return 0f;
                }
                return AssetFileBridge.Progress;
            }
        }

        public string Path { get; private set; }

        public static KAtlasLoader Load(string path, CAtlasLoaderDelegate callback = null)
        {
            LoaderDelgate newCallback = null;
            if (callback != null)
            {
                newCallback = (isOk, obj) => callback(isOk, obj as AssetPacker);
            }
            return AutoNew<KAtlasLoader>(path, newCallback);
        }

        protected override void Init(string url, params object[] args)
        {
            base.Init(url, args);
            Path = url;
            AssetFileBridge = AssetFileLoader.Load(Path, OnAtlasLoaded, LoaderMode.Sync);
        }

        private void OnAtlasLoaded(bool isOk, UnityEngine.Object obj)
        {
            OnFinish(obj);
        }

        protected override void DoDispose()
        {
            base.DoDispose();
            AssetFileBridge.Release(IsBeenReleaseNow); // all, Texture is singleton!
        }
    }
}