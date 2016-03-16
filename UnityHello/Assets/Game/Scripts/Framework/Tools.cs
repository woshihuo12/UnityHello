using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System;

public class Tools
{
    public static object[] CallMethod(string module, string func, params object[] args)
    {
        LuaManager luaMgr = AppFacade.Instance.GetManager<LuaManager>();
        if (luaMgr == null) return null;
        return luaMgr.CallFunction(module + "." + func, args);
    }

    public static string GetOS()
    {
#if UNITY_STANDALONE
        return "Win";
#elif UNITY_ANDROID
        return "Android";
#elif UNITY_IPHONE
        return "iOS";
#endif
    }

    /// <summary>
    /// 取得数据存放目录
    /// </summary>
    public static string DataPath
    {
        get
        {
            string game = GameSetting.AppName.ToLower();
            if (Application.isMobilePlatform)
            {
                return Application.persistentDataPath + "/" + game + "/";
            }
            if (GameSetting.DevelopMode)
            {
                return Application.streamingAssetsPath + "/" + GetOS() + "/";
            }
            if (Application.platform == RuntimePlatform.OSXEditor)
            {
                int i = Application.dataPath.LastIndexOf('/');
                return Application.dataPath.Substring(0, i + 1) + game + "/";
            }
            return "c:/" + game + "/";
        }
    }
    /// <summary>
    /// 应用程序内容路径
    /// </summary>
    public static string AppContentPath()
    {
        string path = string.Empty;
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                path = "jar:file://" + Application.dataPath + "!/assets/";
                break;
            case RuntimePlatform.IPhonePlayer:
                path = Application.dataPath + "/Raw/";
                break;
            default:
                path = Application.streamingAssetsPath + "/";
                break;
        }
        return path;
    }

    public static string GetRelativePath()
    {
        if (Application.isEditor)
        {
            //return "file://" + System.Environment.CurrentDirectory.Replace("\\", "/") + "/Assets/" + AppConst.AssetDir + "/";
            return "file://" + Application.streamingAssetsPath + "/" + GetOS() + "/";
        }
        else if (Application.isMobilePlatform
            || Application.isConsolePlatform)
        {
            return "file:///" + DataPath;
        }

        else // For standalone player.
        {
            return "file://" + Application.streamingAssetsPath + "/" + GetOS() + "/";
        }
    }

    /// <summary>
    /// 计算文件的MD5值
    /// </summary>
    public static string md5file(string file)
    {
        try
        {
            FileStream fs = new FileStream(file, FileMode.Open);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(fs);
            fs.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
        catch (Exception ex)
        {
            throw new Exception("md5file() fail, error:" + ex.Message);
        }
    }
}
