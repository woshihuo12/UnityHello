using UnityEngine;
using System.Collections;

public class GameSetting
{
    // 开发模式
    public static bool DevelopMode = true;
    public static bool UpdateMode = false;

    public const string WebUrl = "http://localhost:6688/";      //测试更新地址

    public const string AppName = "UnityHello";               //应用程序名称

    public const int GameFrameRate = 30;
    //AB素材扩展名
    public const string ABExtName = ".u3d";

    public static bool LuaByteMode = false;                     //Lua字节码模式-默认关闭 
    public static bool LuaBundleMode = false;                    //Lua代码AssetBundle模式

    public static int SocketPort = 0;                           //Socket服务器端口
    public static string SocketAddress = string.Empty;          //Socket服务器地址

    public static bool EnableLuaDebug = false;

    // 美术库用到
    public const string ResourcesBuildDir = "BundleResources";

    /// <summary>
    /// 编辑状态的资源目录存放, Unity 5中采用自动对BundleResources整体打包，把编辑器部分移出
    /// </summary>
    public const string ResourcesEditDir = "BundleEditing";

    public const string ProductRelPath = "Product";
    public const string StreamingBundlesFolderName = "Bundles";
    public const string AssetBundleBuildRelPath = "Product/Bundles";
}
