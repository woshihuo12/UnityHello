using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;

public class GameManager : Manager
{
    protected static bool mInitialize = false;

    private List<string> mDownloadFiles = new List<string>();

    private StringBuilder mSb = new StringBuilder(42);
    void Awake()
    {
        Init();
    }

    void Init()
    {
        //释放资源
        CheckExtractResource();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = GameSetting.GameFrameRate;
    }

    /// <summary>
    /// 释放资源
    /// </summary>
    public void CheckExtractResource()
    {
        bool isExists = Directory.Exists(Tools.DataPath)
            && Directory.Exists(Tools.DataPath + "lua/")
            && File.Exists(Tools.DataPath + "files.txt");

        if (isExists || GameSetting.DevelopMode)
        {
            StartCoroutine(OnUpdateResource());
            return;   //文件已经解压过了，自己可添加检查文件列表逻辑
        }
        StartCoroutine(OnExtractResource());    //启动释放协成 
    }

    IEnumerator OnExtractResource()
    {
        string dataPath = Tools.DataPath; //数据目录
        string resPath = Tools.AppContentPath(); //游戏包资源目录

        if (Directory.Exists(dataPath)) Directory.Delete(dataPath, true);
        Directory.CreateDirectory(dataPath);

        string infile = resPath + "files.txt";
        string outfile = dataPath + "files.txt";
        if (File.Exists(outfile)) File.Delete(outfile);

        string message = "正在解包文件:>files.txt";
        Debug.Log(infile);
        Debug.Log(outfile);

        if (Application.platform == RuntimePlatform.Android)
        {
            WWW www = new WWW(infile);
            yield return www;

            if (www.isDone)
            {
                File.WriteAllBytes(outfile, www.bytes);
            }
            yield return null;
        }
        else
        {
            File.Copy(infile, outfile, true);
        }

        yield return new WaitForEndOfFrame();

        //释放所有文件到数据目录
        string[] files = File.ReadAllLines(outfile);
        foreach (string file in files)
        {
            string[] fs = file.Split('|');
            infile = resPath + fs[0];
            outfile = dataPath + fs[0];

            message = "正在解包文件:>" + fs[0];
            Debug.Log("正在解包文件:>" + infile);

            GameFacade.SendMessageCommand(NotiConst.UPDATE_MESSAGE, message);

            string dir = Path.GetDirectoryName(outfile);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (Application.platform == RuntimePlatform.Android)
            {
                WWW www = new WWW(infile);
                yield return www;
                if (www.isDone)
                {
                    File.WriteAllBytes(outfile, www.bytes);
                }
                yield return null;
            }
            else
            {
                if (File.Exists(outfile))
                {
                    File.Delete(outfile);
                }
                File.Copy(infile, outfile, true);
            }
            yield return new WaitForEndOfFrame();
        }

        message = "解包完成!!!";
        GameFacade.SendMessageCommand(NotiConst.UPDATE_MESSAGE, message);
        yield return new WaitForSeconds(0.1f);

        message = string.Empty;
        //释放完成，开始启动更新资源
        StartCoroutine(OnUpdateResource());
    }

    private void OnUpdateFailed(string file)
    {
        string message = "更新失败!>" + file;
        GameFacade.SendMessageCommand(NotiConst.UPDATE_MESSAGE, message);
    }

    /// <summary>
    /// 是否下载完成
    /// </summary>
    bool IsDownOK(string file)
    {
        return mDownloadFiles.Contains(file);
    }

    /// <summary>
    /// 线程下载
    /// </summary>
    void BeginDownload(string url, string file)
    {     //线程下载
        object[] param = new object[2] { url, file };

        ThreadEvent ev = new ThreadEvent();
        ev.mKey = NotiConst.UPDATE_DOWNLOAD;
        ev.mParams.AddRange(param);
        ThreadMgr.AddEvent(ev, OnThreadCompleted);   //线程下载
    }

    /// <summary>
    /// 线程完成
    /// </summary>
    /// <param name="data"></param>
    void OnThreadCompleted(NotiData data)
    {
        switch (data.mEvName)
        {
            case NotiConst.UPDATE_EXTRACT:  //解压一个完成
                //
                break;
            case NotiConst.UPDATE_DOWNLOAD: //下载一个完成
                mDownloadFiles.Add(data.mEvParam.ToString());
                break;
        }
    }

    /// <summary>
    /// 启动更新下载，这里只是个思路演示，此处可启动线程下载更新
    /// </summary>
    IEnumerator OnUpdateResource()
    {
        if (!GameSetting.UpdateMode)
        {
            OnResourceInited();
            yield break;
        }

        string dataPath = Tools.DataPath;
        string url = GameSetting.WebUrl;
        string message = string.Empty;

        string random = DateTime.Now.ToString("yyyymmddhhmmss");

        string listUrl = url + "files.txt?v=" + random;
        Debug.LogWarning("LoadUpdate---->>>" + listUrl);

        WWW www = new WWW(listUrl);
        yield return www;

        if (www.error != null)
        {
            OnUpdateFailed(string.Empty);
            yield break;
        }

        if (!Directory.Exists(dataPath))
        {
            Directory.CreateDirectory(dataPath);
        }

        File.WriteAllBytes(dataPath + "files.txt", www.bytes);

        string filesText = www.text;
        string[] files = filesText.Split('\n');

        for (int i = 0; i < files.Length; i++)
        {
            if (string.IsNullOrEmpty(files[i])) continue;
            string[] keyValue = files[i].Split('|');
            string f = keyValue[0];
            string localFile = (dataPath + f).Trim();
            string path = Path.GetDirectoryName(localFile);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileUrl = mSb.Remove(0, mSb.Length)
                    .Append(url)
                    .Append(f)
                    .Append("?v=")
                    .Append(random).ToString();
            bool canUpdate = !File.Exists(localFile);
            if (!canUpdate)
            {
                string remoteMd5 = keyValue[1].Trim();
                string localMd5 = Tools.md5file(localFile);
                canUpdate = !remoteMd5.Equals(localMd5);
                if (canUpdate) File.Delete(localFile);
            }
            //本地缺少文件
            if (canUpdate)
            {
                Debug.Log(fileUrl);
                message = mSb.Remove(0, mSb.Length).Append("downloading>>")
                    .Append(fileUrl).ToString();
                GameFacade.SendMessageCommand(NotiConst.UPDATE_MESSAGE, message);
                /*
                www = new WWW(fileUrl); yield return www;
                if (www.error != null) {
                    OnUpdateFailed(path);   //
                    yield break;
                }
                File.WriteAllBytes(localfile, www.bytes);
                 */
                //这里都是资源文件，用线程下载
                BeginDownload(fileUrl, localFile);
                while (!(IsDownOK(localFile)))
                {
                    yield return new WaitForEndOfFrame();
                }
            }
        }
        yield return new WaitForEndOfFrame();

        message = "更新完成!!";
        GameFacade.SendMessageCommand(NotiConst.UPDATE_MESSAGE, message);
        OnResourceInited();
    }

    /// <summary>
    /// 资源初始化结束
    /// </summary>
    public void OnResourceInited()
    {
#if ASYNC_MODE
        if (GameSetting.DevelopMode)
        {
            OnInitialize();
        }
        else
        {
            ResManager.Initialize(Tools.GetOS(), delegate()
            {
                Debug.Log("Initialize OK!!!");
                OnInitialize();
            });
        }
#else
        ResManager.Initialize();
        OnInitialize();
#endif
    }

    void OnInitialize()
    {
        LuaMgr.InitStart();
        //LuaManager.DoFile("Logic/Game");         //加载游戏
        //LuaManager.DoFile("Logic/Network");      //加载网络
        NetManager.OnInit();                     //初始化网络
        //Util.CallMethod("Game", "OnInitOK");     //初始化完成
        mInitialize = true;
    }

    /// <summary>
    /// 析构函数
    /// </summary>
    void OnDestroy()
    {
        if (LuaMgr != null)
        {
            LuaMgr.Close();
        }
        Debug.Log("~GameManager was destroyed");
    }
}
