using UnityEngine;

namespace KEngine
{
    public class SpriteLoader : AbstractResourceLoader
    {
        public Sprite Asset
        {
            get { return ResultObject as Sprite; }
        }

        public delegate void CSpriteLoaderDelegate(bool isOk, Sprite tex);

        private AssetFileLoader AssetFileBridge;

        public override float Progress
        {
            get { return AssetFileBridge.Progress; }
        }

        public string Path { get; private set; }

        public static SpriteLoader Load(string path, CSpriteLoaderDelegate callback = null)
        {
            LoaderDelgate newCallback = null;
            if (callback != null)
            {
                newCallback = (isOk, obj) => callback(isOk, obj as Sprite);
            }
            return AutoNew<SpriteLoader>(path, newCallback);
        }

        protected override void Init(string url, params object[] args)
        {
            base.Init(url, args);
            Path = url;
            AssetFileBridge = AssetFileLoader.Load(Path, OnAssetLoaded);
        }

        private void OnAssetLoaded(bool isOk, UnityEngine.Object obj)
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