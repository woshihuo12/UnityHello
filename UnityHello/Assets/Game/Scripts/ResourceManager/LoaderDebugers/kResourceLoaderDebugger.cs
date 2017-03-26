using UnityEngine;
using System.Collections;
using System;

namespace KEngine
{
    /// <summary>
    /// 只在编辑器下出现，分别对应一个Loader~生成一个GameObject对象，为了方便调试！
    /// </summary>
    public class KResourceLoaderDebugger : MonoBehaviour
    {
        public AbstractResourceLoader TheLoader;
        public int RefCount;
        public float FinishUsedTime; // 参考，完成所需时间
        public static bool IsApplicationQuit = false;

        const string bigType = "ResourceLoaderDebuger";

        public static KResourceLoaderDebugger Create(string type, string url, AbstractResourceLoader loader)
        {
            if (IsApplicationQuit) return null;

            Func<string> getName = () => string.Format("{0}-{1}-{2}", type, url, loader.Desc);
            var newHelpGameObject = new GameObject(getName());
            KDebuggerObjectTool.SetParent(bigType, type, newHelpGameObject);
            var newHelp = newHelpGameObject.AddComponent<KResourceLoaderDebugger>();
            newHelp.TheLoader = loader;

            loader.SetDescEvent += (newDesc) =>
            {
                if (loader.RefCount > 0)
                    newHelpGameObject.name = getName();
            };

            loader.DisposeEvent += () =>
            {
                if (!IsApplicationQuit)
                    KDebuggerObjectTool.RemoveFromParent(bigType, type, newHelpGameObject);
            };

            return newHelp;
        }

        private void Update()
        {
            RefCount = TheLoader.RefCount;
            FinishUsedTime = TheLoader.FinishUsedTime;
        }

        private void OnApplicationQuit()
        {
            IsApplicationQuit = true;
        }
    }
}