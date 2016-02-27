using UnityEngine;
using System.Collections;

public class GameSetting
{
    public static bool DebugMode = true;

    public const string AppName = "UnityHello";               //应用程序名称

    public static string AssetPath
    {
        get
        {
            return Application.streamingAssetsPath;
        }
    }

    public static string TransAssetPath
    {
        get
        {
            string protocl = "file://";
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                protocl = "file:///";
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                protocl = "";
            }
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                protocl = "";
            }
            return protocl + AssetPath;
        }
    }
}
