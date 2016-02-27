using UnityEngine;
using System.Collections;

public class Tools
{
    public static object[] CallMethod(string module, string func, params object[] args)
    {
        LuaManager luaMgr = AppFacade.Instance.GetManager<LuaManager>();
        if (luaMgr == null) return null;
        return luaMgr.CallFunction(module + "." + func, args);
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
            if (GameSetting.DebugMode)
            {
                return Application.dataPath + "/" + GameConst.AssetDir + "/";
            }
            if (Application.platform == RuntimePlatform.OSXEditor)
            {
                int i = Application.dataPath.LastIndexOf('/');
                return Application.dataPath.Substring(0, i + 1) + game + "/";
            }
            return "c:/" + game + "/";
        }
    }
}
