using KEngine;
using UnityEngine;

namespace KEngine
{
    public class TextureLoader : AbstractResourceLoader
    {
        public Texture Asset
        {
            get { return ResultObject as Texture; }
        }

        public delegate void CTextureLoaderDelegate(bool isOk, Texture tex);

        private AssetFileLoader AssetFileBridge;

        public override float Progress
        {
            get { return AssetFileBridge.Progress; }
        }

        public string Path { get; private set; }

        public static TextureLoader Load(string path, CTextureLoaderDelegate callback = null)
        {
            LoaderDelgate newCallback = null;
            if (callback != null)
            {
                newCallback = (isOk, obj) => callback(isOk, obj as Texture);
            }
            return AutoNew<TextureLoader>(path, newCallback);
        }

        protected override void Init(string url, params object[] args)
        {
            base.Init(url, args);

            Path = url;
            AssetFileBridge = AssetFileLoader.Load(Path, OnAssetLoaded);
        }

        private void OnAssetLoaded(bool isOk, UnityEngine.Object obj)
        {
            if (!isOk)
            {
                Log.Error("[TextureLoader:OnAssetLoaded]Is not OK: {0}", this.Url);
            }

            OnFinish(obj);

            if (isOk)
            {
                var tex = Asset as Texture2D;

                string format = tex != null ? tex.format.ToString() : "";
                Desc = string.Format("{0}*{1}-{2}-{3}", Asset.width, Asset.height, Asset.width * Asset.height, format);
            }
        }

        protected override void DoDispose()
        {
            base.DoDispose();
            AssetFileBridge.Release(IsBeenReleaseNow); // all, Texture is singleton!
        }
    }

}
