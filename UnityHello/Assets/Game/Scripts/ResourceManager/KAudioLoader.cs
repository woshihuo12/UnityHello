using UnityEngine;

namespace KEngine
{
    public class AudioLoader : AbstractResourceLoader
    {
        private AudioClip ResultAudioClip
        {
            get { return ResultObject as AudioClip; }
        }

        private AssetFileLoader AssetFileBridge;

        public override float Progress
        {
            get { return AssetFileBridge.Progress; }
        }

        public static AudioLoader Load(string url, System.Action<bool, AudioClip> callback = null)
        {
            LoaderDelgate newCallback = null;
            if (callback != null)
            {
                newCallback = (isOk, obj) => callback(isOk, obj as AudioClip);
            }
            return AutoNew<AudioLoader>(url, newCallback);
        }

        protected override void Init(string url, params object[] args)
        {
            base.Init(url, args);

            AssetFileBridge = AssetFileLoader.Load(url, (bool isOk, UnityEngine.Object obj) => { OnFinish(obj); });
        }

        protected override void DoDispose()
        {
            base.DoDispose();

            AssetFileBridge.Release(IsBeenReleaseNow);
        }
    }

}