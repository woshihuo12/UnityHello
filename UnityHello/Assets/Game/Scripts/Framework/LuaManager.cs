using UnityEngine;
using System.Collections;
using LuaInterface;
using System.IO;
using System.Text;
using KEngine;

public class SimpleLuaResLoader : LuaFileUtils
{
    public SimpleLuaResLoader()
    {
        instance = this;
        if (EngineConfig.instance.IsDebugMode)
        {
            if (EngineConfig.instance.IsLuaBundleMode)
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
        if (EngineConfig.instance.IsDevelopMode)
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
            path = StringBuilderCache.GetStringAndRelease(StringBuilderCache.Acquire().Append(dir).Append("/").Append(KResourceManager.BuildPlatformName)
                 .Append("/Lua/").Append(fileName));
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
        base.LoadLuaFiles();
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
        if (EngineConfig.instance.IsEnableLuaDebug)
        {
            OpenZbsDebugger();
        }

        luaState.Start();
        StartLooper();
    }

    public void OnLuaFilesLoaded()
    {
        StartMain();
    }
}

public class LuaManager : Manager
{
    private SimpleLuaClient mSimpleLuaClient;

    private void InitLuaPath()
    {
        if (EngineConfig.instance.IsDevelopMode)
        {
            if (!EngineConfig.instance.IsLuaBundleMode)
            {
                SimpleLuaClient.GetMainState().AddSearchPath(LuaConst.luaDir);
                SimpleLuaClient.GetMainState().AddSearchPath(LuaConst.toluaDir);
            }
        }
    }

    private void Awake()
    {
        mSimpleLuaClient = gameObject.AddComponent<SimpleLuaClient>();
        InitLuaLoaderSearchPath();
    }

    private void AddBundle(string bundleName)
    {
        string url = KResourceManager.BundlesPathWithoutFileProtocol + "/lua/" + bundleName;
        if (File.Exists(url))
        {
            AssetBundle bundle = AssetBundle.LoadFromFile(url);
            if (bundle != null)
            {
                bundleName = bundleName.Replace("lua/", "");
                bundleName = bundleName.Replace(EngineConfig.instance.ABExtName, "");
                LuaFileUtils.Instance.AddSearchBundle(bundleName.ToLower(), bundle);
            }
        }
    }

    /// <summary>
    /// 初始化LuaBundle
    /// </summary>
    void InitLuaBundle()
    {
        if (EngineConfig.instance.IsLuaBundleMode)
        {
            AddBundle("toluascripts/system/reflection.u3d");
            AddBundle("toluascripts/cjson.u3d");
            AddBundle("toluascripts/lpeg.u3d");
            AddBundle("toluascripts/misc.u3d");
            AddBundle("toluascripts/protobuf.u3d");
            AddBundle("toluascripts/socket.u3d");
            AddBundle("toluascripts/system.u3d");
            AddBundle("toluascripts/unityengine.u3d");
            ////////////////////////////////////
            AddBundle("luascripts/ai/bt.u3d");
            AddBundle("luascripts/globalization/zh.u3d");
            AddBundle("luascripts/common.u3d");
            AddBundle("luascripts/components.u3d");
            AddBundle("luascripts/core.u3d");
            AddBundle("luascripts/data_infos.u3d");
            AddBundle("luascripts/entities.u3d");
            AddBundle("luascripts/eventsystem.u3d");
            AddBundle("luascripts/framework.u3d");
            AddBundle("luascripts/manager.u3d");
            AddBundle("luascripts/protol.u3d");
            AddBundle("luascripts/settings.u3d");
            AddBundle("luascripts/subsystems.u3d");
            AddBundle("luascripts/uiscripts.u3d");
            ///////////////////////////////////////
            AddBundle("toluascripts.u3d");
            AddBundle("luascripts.u3d");
        }
    }

    public void InitLuaLoaderSearchPath()
    {
        InitLuaPath();
        InitLuaBundle();
    }

    public void InitStart()
    {
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
