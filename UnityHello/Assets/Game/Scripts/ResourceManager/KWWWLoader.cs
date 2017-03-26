using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace KEngine
{
    /// <summary>
    /// Load www, A wrapper of WWW.
    /// </summary>
    public class KWWWLoader : AbstractResourceLoader
    {
        // 前几项用于监控器
        private static IEnumerator CachedWWWLoaderMonitorCoroutine; // 专门监控WWW的协程
        private const int MAX_WWW_COUNT = 15; // 同时进行的最大Www加载个数，超过的排队等待
        private static int WWWLoadingCount = 0; // 有多少个WWW正在运作, 有上限的

        private static readonly Stack<KWWWLoader> WWWLoadersStack = new Stack<KWWWLoader>();
        // WWWLoader的加载是后进先出! 有一个协程全局自我管理. 后来涌入的优先加载！

        public static event Action<string> WWWFinishCallback;

        public float BeginLoadTime;
        public float FinishLoadTime;
        public WWW Www;
        public int Size
        {
            get { return Www.size; }
        }

        public float LoadSpeed
        {
            get
            {
                if (!IsCompleted)
                    return 0;
                return Size / (FinishLoadTime - BeginLoadTime);
            }
        }

        /// <summary>
        /// Use this to directly load WWW by Callback or Coroutine, pass a full URL.
        /// A wrapper of Unity's WWW class.
        /// </summary>
        public static KWWWLoader Load(string url, LoaderDelgate callback = null)
        {
            var wwwLoader = AutoNew<KWWWLoader>(url, callback);
            return wwwLoader;
        }

        protected override void Init(string url, params object[] args)
        {
            base.Init(url, args);

            WWWLoadersStack.Push(this); // 不执行开始加载，由www监控器协程控制
            if (CachedWWWLoaderMonitorCoroutine == null)
            {
                //CachedWWWLoaderMonitorCoroutine = WWWLoaderMonitorCoroutine();
                //KResourceModule.Instance.StartCoroutine(CachedWWWLoaderMonitorCoroutine);
            }
        }
    }
}