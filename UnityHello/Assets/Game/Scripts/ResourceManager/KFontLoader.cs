using System;
using UnityEngine;

namespace KEngine
{
    public class FontLoader : AbstractResourceLoader
    {
        private AssetFileLoader _bridge;

        public override float Progress
        {
            get { return _bridge.Progress; }
        }

        public static FontLoader Load(string path, Action<bool, Font> callback = null)
        {
            LoaderDelgate realcallback = null;
            if (callback != null)
            {
                realcallback = (isOk, obj) => callback(isOk, obj as Font);
            }

            return AutoNew<FontLoader>(path, realcallback);
        }

        protected override void Init(string url, params object[] args)
        {
            base.Init(url, args);

            _bridge = AssetFileLoader.Load(Url, (_isOk, _obj) => { OnFinish(_obj); });
        }

        protected override void DoDispose()
        {
            base.DoDispose();
            _bridge.Release(IsBeenReleaseNow);
        }
    }
}