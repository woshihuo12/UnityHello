using System.Collections;
using System.IO;
using UnityEngine;

#if UNITY_5

namespace KEngine
{
    public class SceneLoader : AbstractResourceLoader
    {
        private AssetFileLoader _assetFileBridge;
        private LoaderMode _mode;
        private string _url;
        private string _sceneName;

        public override float Progress
        {
            get { return _assetFileBridge.Progress; }
        }

        public string SceneName
        {
            get { return _sceneName; }
        }

        public static SceneLoader Load(string url, System.Action<bool> callback = null,
            LoaderMode mode = LoaderMode.Async)
        {
            LoaderDelgate newCallback = null;
            if (callback != null)
            {
                newCallback = (isOk, obj) => callback(isOk);
            }
            return AutoNew<SceneLoader>(url, newCallback, false, mode);
        }

        protected override void Init(string url, params object[] args)
        {
            base.Init(url, args);

            _mode = (LoaderMode)args[0];
            _url = url;
            _sceneName = Path.GetFileNameWithoutExtension(_url);
            AppFacade.Instance.GetManager<KResourceManager>().StartCoroutine(Start());
        }

        IEnumerator Start()
        {
            _assetFileBridge = AssetFileLoader.Load(_url, (bool isOk, UnityEngine.Object obj) => { },
                _mode);

            while (!_assetFileBridge.IsCompleted)
            {
                yield return null;
            }
            if (_assetFileBridge.IsError)
            {
                Log.Error("[SceneLoader]Load SceneLoader Failed(Error) when Finished: {0}", _url);
                _assetFileBridge.Release();
                OnFinish(null);
                yield break;
            }

            // load scene
            Debuger.Assert(_assetFileBridge.Asset);

            if (_mode == LoaderMode.Sync)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName,
                     UnityEngine.SceneManagement.LoadSceneMode.Additive);
            }
            else
            {
                var op = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_sceneName, UnityEngine.SceneManagement.LoadSceneMode.Additive);
                while (!op.isDone)
                {
                    yield return null;
                }
            }

            if (Application.isEditor)
            {
                AppFacade.Instance.GetManager<KResourceManager>().StartCoroutine(EditorLoadSceneBugFix(null));
            }

            OnFinish(_assetFileBridge);
        }


        /// <summary>
        ///     编辑器模式下，场景加载完毕，刷新所有material的shader确保显示正确， unity b.u.g
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        private static IEnumerator EditorLoadSceneBugFix(AsyncOperation op)
        {
            if (op != null)
            {
                while (!op.isDone)
                    yield return null;
            }
            yield return null; // one more frame

            RefreshAllMaterialsShaders();
        }

        /// <summary>
        /// 编辑器模式下，对全部GameObject刷新一下Material
        /// </summary>
        private static void RefreshAllMaterialsShaders()
        {
            foreach (var renderer in GameObject.FindObjectsOfType<Renderer>())
            {
                AssetFileLoader.RefreshMaterialsShaders(renderer);
            }
        }


        protected override void DoDispose()
        {
            base.DoDispose();
            _assetFileBridge.Release(IsBeenReleaseNow);
            UnityEngine.SceneManagement.SceneManager.UnloadScene(_sceneName);
        }
    }
}
#endif