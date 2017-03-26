using UnityEngine;
using System.Collections;

namespace KEngine
{

    /// <summary>
    /// 对XXXLoader的结果Asset进行Debug显示
    /// </summary>
    public class KResoourceLoadedAssetDebugger : MonoBehaviour
    {
        public string MemorySize;
        public UnityEngine.Object TheObject;
        private const string bigType = "LoadedAssetDebugger";
        public string Type;
        private bool IsRemoveFromParent = false;

        public static KResoourceLoadedAssetDebugger Create(string type, string url, UnityEngine.Object theObject)
        {
            var newHelpGameObject = new GameObject(string.Format("LoadedObject-{0}-{1}", type, url));
            KDebuggerObjectTool.SetParent(bigType, type, newHelpGameObject);

            var newHelp = newHelpGameObject.AddComponent<KResoourceLoadedAssetDebugger>();
            newHelp.Type = type;
            newHelp.TheObject = theObject;
            newHelp.MemorySize = string.Format("{0:F5}KB",
#if UNITY_5_5
			UnityEngine.Profiling.Profiler.GetRuntimeMemorySize(theObject) / 1024f
#else
            UnityEngine.Profiler.GetRuntimeMemorySize(theObject) / 1024f
#endif
            );
            return newHelp;
        }

        private void Update()
        {
            if (TheObject == null && !IsRemoveFromParent)
            {
                IsRemoveFromParent = true;
                KDebuggerObjectTool.RemoveFromParent(bigType, Type, gameObject);
            }
        }

        // 可供调试删资源
        private void OnDestroy()
        {
            if (!IsRemoveFromParent)
            {
                IsRemoveFromParent = true;
                KDebuggerObjectTool.RemoveFromParent(bigType, Type, gameObject);
            }
        }
    }
}