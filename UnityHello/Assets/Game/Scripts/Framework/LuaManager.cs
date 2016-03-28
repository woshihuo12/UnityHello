using UnityEngine;
using System.Collections;
using LuaInterface;
using System.IO;
using System.Text;

public class SimpleLuaResLoader : LuaFileUtils
{
    private StringBuilder mSb = new StringBuilder(42);
    public SimpleLuaResLoader()
    {
        instance = this;
        if (GameSetting.DevelopMode)
        {
            if (GameSetting.LuaBundleMode)
            {
                beZip = true;
            }
            else
            {
                beZip = false;
            }
        }
        else
        {
            beZip = true;
        }
    }

    public override byte[] ReadFile(string fileName)
    {
        if (GameSetting.DevelopMode)
        {
            byte[] buffer = base.ReadFile(fileName);
            if (buffer == null)
            {
                buffer = ReadResourceFile(fileName);
            }
            if (buffer == null)
            {
                buffer = ReadDownLoadFile(fileName);
            }
            return buffer;
        }
        else
        {
            byte[] buffer = ReadDownLoadFile(fileName);
            if (buffer == null)
            {
                buffer = ReadResourceFile(fileName);
            }
            if (buffer == null)
            {
                buffer = base.ReadFile(fileName);
            }
            return buffer;
        }
    }

    private byte[] ReadResourceFile(string fileName)
    {
        byte[] buffer = null;
        string path = "Lua/" + fileName;
        TextAsset text = Resources.Load(path, typeof(TextAsset)) as TextAsset;

        if (text != null)
        {
            buffer = text.bytes;
            Resources.UnloadAsset(text);
        }

        return buffer;
    }

    private byte[] ReadDownLoadFile(string fileName)
    {
        string path = fileName;
        if (!Path.IsPathRooted(fileName))
        {
            string dir = Application.persistentDataPath.Replace('\\', '/');
            mSb.Remove(0, mSb.Length).Append(dir).Append("/").Append(GetOSDir())
                .Append("/Lua/").Append(fileName);
            path = mSb.ToString();
        }
        if (File.Exists(path))
        {
            return File.ReadAllBytes(path);
        }
        return null;
    }
}

public class SimpleLuaClient : LuaClient
{
    protected override LuaFileUtils InitLoader()
    {
        return new SimpleLuaResLoader();
    }

    protected override void LoadLuaFiles()
    {
    }

    protected override void OpenLibs()
    {
        base.OpenLibs();
    }

    protected override void CallMain()
    {
        base.CallMain();
    }

    protected override void StartMain()
    {
        base.StartMain();
    }

    protected override void Bind()
    {
        base.Bind();
    }

    protected override void OnLoadFinished()
    {
    }

    public void OnLuaFilesLoaded()
    {
        //OpenZbsDebugger();

        luaState.Start();
        StartLooper();
        StartMain();
    }
}

public class LuaManager : Manager
{
    private SimpleLuaClient mSimpleLuaClient;

    private void InitLuaPath()
    {
        if (GameSetting.DevelopMode)
        {
            SimpleLuaClient.GetMainState().AddSearchPath(Application.dataPath + "/ToLua/Lua");
            SimpleLuaClient.GetMainState().AddSearchPath(Application.dataPath + "/Lua");
        }
        else
        {
            SimpleLuaClient.GetMainState().AddSearchPath(Tools.DataPath + "lua");
        }
    }

    private void Awake()
    {
        mSimpleLuaClient = gameObject.AddComponent<SimpleLuaClient>();
    }

    private void AddBundle(string bundleName)
    {
        string url = Tools.DataPath + "/lua/" + bundleName;
        if (File.Exists(url))
        {
            AssetBundle bundle = AssetBundle.LoadFromFile(url);
            if (bundle != null)
            {
                bundleName = bundleName.Replace("lua/", "");
                bundleName = bundleName.Replace(".unity3d", "");
                LuaFileUtils.Instance.AddSearchBundle(bundleName.ToLower(), bundle);
            }
        }
    }

    /// <summary>
    /// 初始化LuaBundle
    /// </summary>
    void InitLuaBundle()
    {
        if (!GameSetting.DevelopMode
            && GameSetting.LuaBundleMode)
        {
            AddBundle("lua/lua.unity3d");
            AddBundle("lua/lua_math.unity3d");
            AddBundle("lua/lua_system.unity3d");
            AddBundle("lua/lua_u3d.unity3d");
            AddBundle("lua/lua_misc.unity3d");
            AddBundle("lua/lua_cjson.unity3d");
            AddBundle("lua/lua_lscripts.unity3d");
            AddBundle("lua/lua_socket.unity3d");
            AddBundle("lua/lua_protobuf.unity3d");
        }
    }

    public void InitStart()
    {
        InitLuaPath();
        InitLuaBundle();
        mSimpleLuaClient.OnLuaFilesLoaded();
    }

    public object[] CallFunction(string funcName, params object[] args)
    {
        LuaFunction func = SimpleLuaClient.GetMainState().GetFunction(funcName);
        if (func != null)
        {
            return func.Call(args);
        }
        return null;
    }

    public void Close()
    {
    }
}
