using UnityEngine;
using System.Collections;
using LuaInterface;
using KEngine;
using System;
using System.IO;

[Serializable]
internal class EngineConfigData
{
    public bool IsLoadAssetBundle;
    public bool IsEditorLoadAsset;
    public bool IsDebugMode;
    public bool IsUpdateMode;
    public bool LuaByteMode;
    public bool LuaBundleMode;
    public bool EnableLuaDebug;
    public bool IsDevelopMode;

    //测试更新地址
    public string WebUrl;
    //应用程序名称
    public string AppName;
    public string ABExtName;
    public string ResourcesBuildDir;
    public string ResourcesEditDir;

    public string ProductRelPath;
    public string StreamingBundlesFolderName;
    public string AssetBundleBuildRelPath;

    public string SocketAddress;

    public int SocketPort;
    public int GameFrameRate;
}

public class EngineConfig : Singleton<EngineConfig>
{
    private EngineConfigData mData;
    public override void Init()
    {
        using (StreamReader sr = new StreamReader(Application.dataPath + "/Resources/jdata/engineconfig.json"))
        {
            if (sr == null)
            {
                return;
            }
            string json = sr.ReadToEnd();
            if (json.Length > 0)
            {
                mData = JsonUtility.FromJson<EngineConfigData>(json);
            }
        }
    }

    public bool IsLoadAssetBundle
    {
        get
        {
            if (mData == null)
            {
                return false;
            }

            return mData.IsLoadAssetBundle;
        }
    }

    public bool IsEditorLoadAsset
    {
        get
        {
            if (mData == null)
            {
                return false;
            }

            return mData.IsEditorLoadAsset;
        }
    }

    public bool IsDebugMode
    {
        get
        {
            if (mData == null)
            {
                return false;
            }

            return mData.IsDebugMode;
        }
    }

    public bool IsUpdateMopde
    {
        get
        {
            if (mData == null)
            {
                return false;
            }

            return mData.IsUpdateMode;
        }
    }

    public bool IsLuaByteMode
    {
        get
        {
            if (mData == null)
            {
                return false;
            }

            return mData.LuaByteMode;
        }
    }

    public bool IsLuaBundleMode
    {
        get
        {
            if (mData == null)
            {
                return false;
            }

            return mData.LuaBundleMode;
        }
    }

    public bool IsDevelopMode
    {
        get
        {
            if (mData == null)
            {
                return false;
            }

            return mData.IsDevelopMode;
        }
    }

    public bool IsEnableLuaDebug
    {
        get
        {
            if (mData == null)
            {
                return false;
            }

            return mData.EnableLuaDebug;
        }
    }

    public string WebUrl
    {
        get
        {
            if (mData == null)
            {
                return string.Empty;
            }
            return mData.WebUrl;
        }
    }

    public string AppName
    {
        get
        {
            if (mData == null)
            {
                return string.Empty;
            }
            return mData.AppName;
        }
    }

    public string ABExtName
    {
        get
        {
            if (mData == null)
            {
                return string.Empty;
            }
            return mData.ABExtName;
        }
    }

    public string ResourcesBuildDir
    {
        get
        {
            if (mData == null)
            {
                return string.Empty;
            }
            return mData.ResourcesBuildDir;
        }
    }

    public string ResourcesEditDir
    {
        get
        {
            if (mData == null)
            {
                return string.Empty;
            }
            return mData.ResourcesEditDir;
        }
    }

    public string ProductRelPath
    {
        get
        {
            if (mData == null)
            {
                return string.Empty;
            }
            return mData.ProductRelPath;
        }
    }

    public string StreamingBundlesFolderName
    {
        get
        {
            if (mData == null)
            {
                return string.Empty;
            }
            return mData.StreamingBundlesFolderName;
        }
    }

    public string AssetBundleBuildRelPath
    {
        get
        {
            if (mData == null)
            {
                return string.Empty;
            }
            return mData.AssetBundleBuildRelPath;
        }
    }

    public string SocketAddress
    {
        get
        {
            if (mData == null)
            {
                return string.Empty;
            }
            return mData.SocketAddress;
        }
    }

    public int SocketPort
    {
        get
        {
            if (mData == null)
            {
                return 0;
            }
            return mData.SocketPort;
        }
    }

    public int GameFrameRate
    {
        get
        {
            if (mData == null)
            {
                return 30;
            }
            return mData.GameFrameRate;
        }
    }
}