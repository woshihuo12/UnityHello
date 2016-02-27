using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using System.Diagnostics;
using System.Net;

public class ThreadEvent
{
    public string mKey;
    public List<object> mParams = new List<object>();
}

public class NotiData
{
    public string mEvName;
    public object mEvParam;

    public NotiData(string name, object param)
    {
        mEvName = name;
        mEvParam = param;
    }
}

public class ThreadManager : Manager
{
    private Thread mThread;

    private Action<NotiData> mFunc;
    private Stopwatch mStopwatch = new Stopwatch();
    private string mCurDownFile = string.Empty;

    private static readonly object mLockObj = new object();
    private static Queue<ThreadEvent> mEvents = new Queue<ThreadEvent>();

    private Action<NotiData> mSyncEvent;

    void Awake()
    {
        mSyncEvent = OnSyncEvent;
        mThread = new Thread(OnUpdate);
    }

    void Start()
    {
        mThread.Start();
    }

    /// <summary>
    /// 添加到事件队列
    /// </summary>
    public void AddEvent(ThreadEvent ev, Action<NotiData> func)
    {
        lock (mLockObj)
        {
            mFunc = func;
            mEvents.Enqueue(ev);
        }
    }

    private void OnSyncEvent(NotiData data)
    {
        if (mFunc != null) mFunc(data);  //回调逻辑层
        GameFacade.SendMessageCommand(data.mEvName, data.mEvParam); //通知View层
    }

    private void OnUpdate()
    {
        while (true)
        {
            lock (mLockObj)
            {
                if (mEvents.Count > 0)
                {
                    ThreadEvent e = mEvents.Dequeue();
                    try
                    {
                        switch (e.mKey)
                        {
                            case NotiConst.UPDATE_EXTRACT:
                                {     //解压文件
                                    OnExtractFile(e.mParams);
                                }
                                break;
                            case NotiConst.UPDATE_DOWNLOAD:
                                {    //下载文件
                                    OnDownloadFile(e.mParams);
                                }
                                break;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        UnityEngine.Debug.LogError(ex.Message);
                    }
                }
            }
            Thread.Sleep(1);
        }
    }

    /// <summary>
    /// 下载文件
    /// </summary>
    private void OnDownloadFile(List<object> evParams)
    {
        string url = evParams[0].ToString();
        mCurDownFile = evParams[1].ToString();

        using (WebClient client = new WebClient())
        {
            mStopwatch.Start();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            client.DownloadFileAsync(new System.Uri(url), mCurDownFile);
        }
    }

    private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        //UnityEngine.Debug.Log(e.ProgressPercentage);
        /*
        UnityEngine.Debug.Log(string.Format("{0} MB's / {1} MB's",
            (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
            (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00")));
        */
        //float value = (float)e.ProgressPercentage / 100f;
        string value = string.Format("{0} kb/s", (e.BytesReceived / 1024d / mStopwatch.Elapsed.TotalSeconds).ToString("0.00"));
        NotiData data = new NotiData(NotiConst.UPDATE_PROGRESS, value);
        if (mSyncEvent != null) mSyncEvent(data);

        if (e.ProgressPercentage == 100 && e.BytesReceived == e.TotalBytesToReceive)
        {
            mStopwatch.Reset();

            data = new NotiData(NotiConst.UPDATE_DOWNLOAD, mCurDownFile);
            if (mSyncEvent != null) mSyncEvent(data);
        }
    }

    /// <summary>
    /// 调用方法
    /// </summary>
    void OnExtractFile(List<object> evParams)
    {
        Debugger.LogWarning("Thread evParams: >>" + evParams.Count);
        ///------------------通知更新面板解压完成--------------------
        NotiData data = new NotiData(NotiConst.UPDATE_DOWNLOAD, null);
        if (mSyncEvent != null) mSyncEvent(data);
    }

    /// <summary>
    /// 应用程序退出
    /// </summary>
    void OnDestroy()
    {
        mThread.Abort();
    }
}
