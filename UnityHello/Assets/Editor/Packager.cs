using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;


public class Packager
{
    public static string mPlatform = string.Empty;

    static List<string> mPaths = new List<string>();
    static List<string> mFiles = new List<string>();
    static List<AssetBundleBuild> mABBMaps = new List<AssetBundleBuild>();

    /// <summary>
    /// 数据目录
    /// </summary>
    static string AppDataPath
    {
        get { return Application.dataPath.ToLower(); }
    }

    ///-----------------------------------------------------------
    static string[] mFileExts = { ".txt", ".xml", ".lua", ".assetbundle", ".json" };
    static bool CanCopy(string ext)
    {   //能不能复制
        foreach (string e in mFileExts)
        {
            if (ext.Equals(e)) return true;
        }
        return false;
    }

    [MenuItem("打包游戏资源/iPhone", false, 100)]
    public static void BuildiPhoneResource()
    {
        if (EditorApplication.isCompiling)
        {
            EditorUtility.DisplayDialog("警告", "请等待编辑器完成编译再执行此功能", "确定");
            return;
        }

        BuildTarget target;
#if UNITY_5
        target = BuildTarget.iOS;
#else
        target = BuildTarget.iPhone;
#endif
        BuildAssetResource(target);
    }

    [MenuItem("打包游戏资源/Android", false, 101)]
    public static void BuildAndroidResource()
    {
        if (EditorApplication.isCompiling)
        {
            EditorUtility.DisplayDialog("警告", "请等待编辑器完成编译再执行此功能", "确定");
            return;
        }

        BuildAssetResource(BuildTarget.Android);
    }

    [MenuItem("打包游戏资源/Windows", false, 102)]
    public static void BuildWindowsResource()
    {
        if (EditorApplication.isCompiling)
        {
            EditorUtility.DisplayDialog("警告", "请等待编辑器完成编译再执行此功能", "确定");
            return;
        }

        BuildAssetResource(BuildTarget.StandaloneWindows);
    }

    private static string GetOS()
    {
#if UNITY_STANDALONE
        return "Win";
#elif UNITY_ANDROID
        return "Android";
#elif UNITY_IPHONE
        return "iOS";
#endif
    }

    private static string GetOSStreamAssetPath()
    {
        return Application.streamingAssetsPath + "/" + GetOS();
    }

    private static void BuildFileIndex()
    {
        ///----------------------创建文件列表-----------------------
        string osStreamPath = GetOSStreamAssetPath();
        string newFilePath = osStreamPath + "/files.txt";
        if (File.Exists(newFilePath)) File.Delete(newFilePath);

        mPaths.Clear();
        mFiles.Clear();
        Recursive(osStreamPath);

        FileStream fs = new FileStream(newFilePath, FileMode.CreateNew);
        StreamWriter sw = new StreamWriter(fs);
        for (int i = 0; i < mFiles.Count; i++)
        {
            string file = mFiles[i];
            //string ext = Path.GetExtension(file);
            if (file.EndsWith(".meta") || file.Contains(".DS_Store")) continue;

            string md5 = Tools.md5file(file);
            string value = file.Replace(osStreamPath, string.Empty);
            sw.WriteLine(value + "|" + md5);
        }
        sw.Close();
        fs.Close();
    }

    /// <summary>
    /// 生成绑定素材
    /// </summary>
    public static void BuildAssetResource(BuildTarget target)
    {
        string streamPath = GetOSStreamAssetPath();

        if (Directory.Exists(streamPath))
        {
            Directory.Delete(streamPath, true);
        }
        Directory.CreateDirectory(streamPath);
        AssetDatabase.Refresh();

        mABBMaps.Clear();

        if (GameSetting.LuaBundleMode)
        {
            HandleLuaBundle();

            //HandleExampleBundle();

            BuildAssetBundleOptions options = BuildAssetBundleOptions.DeterministicAssetBundle |
                                      BuildAssetBundleOptions.UncompressedAssetBundle;
            BuildPipeline.BuildAssetBundles(streamPath, mABBMaps.ToArray(), options, target);
        }
        else
        {
            HandleLuaFile();
        }

        BuildFileIndex();

        string tmpLuaDir = GetTmpLuaDir();
        if (Directory.Exists(tmpLuaDir)) Directory.Delete(tmpLuaDir, true);
        AssetDatabase.Refresh();
    }

    /// <summary>
    /// 处理框架实例包
    /// </summary>
    static void HandleExampleBundle()
    {
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
        AddBuildMap("ui_notice" + GameSetting.ExtName, "*.prefab", "Assets/Game/UIPrefab");
    }

    public static void EncodeLuaFile(string srcFile, string outFile)
    {
        if (!srcFile.ToLower().EndsWith(".lua"))
        {
            File.Copy(srcFile, outFile, true);
            return;
        }

        bool isWin = true;
        string luaexe = string.Empty;
        string args = string.Empty;
        string exedir = string.Empty;
        string currDir = Directory.GetCurrentDirectory();
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            isWin = true;
            luaexe = "luajit.exe";
            args = "-b " + srcFile + " " + outFile;
            exedir = AppDataPath.Replace("assets", "") + "/LuaEncoder/luajit/";
        }
        else if (Application.platform == RuntimePlatform.OSXEditor)
        {
            isWin = false;
            luaexe = "./luac";
            args = "-o " + outFile + " " + srcFile;
            exedir = AppDataPath.Replace("assets", "") + "/LuaEncoder/luavm/";
        }

        Directory.SetCurrentDirectory(exedir);
        ProcessStartInfo info = new ProcessStartInfo();
        info.FileName = luaexe;
        info.Arguments = args;
        info.WindowStyle = ProcessWindowStyle.Hidden;
        info.ErrorDialog = true;
        info.UseShellExecute = isWin;
        UnityEngine.Debug.Log(info.FileName + " " + info.Arguments);

        Process pro = Process.Start(info);
        pro.WaitForExit();
        Directory.SetCurrentDirectory(currDir);
    }

    private static string GetTmpLuaDir()
    {
        return Application.dataPath + "/TmpLua/";
    }

    /// <summary>
    /// 处理Lua代码包
    /// </summary>
    private static void HandleLuaBundle()
    {
        string srcDir = Application.dataPath + "/Lua/";
        string srcDir2 = Application.dataPath + "/ToLua/Lua/";
        string destDir = GetTmpLuaDir();
        if (Directory.Exists(destDir)) Directory.Delete(destDir, true);
        Directory.CreateDirectory(destDir);

        string[] srcDirs = { srcDir, srcDir2 };

        for (int i = 0; i < srcDirs.Length; i++)
        {
            string sourceDir = srcDirs[i];
            if (!Directory.Exists(sourceDir))
            {
                return;
            }

            string[] files = Directory.GetFiles(sourceDir, "*.lua", SearchOption.AllDirectories);
            int len = sourceDir.Length;

            if (sourceDir[len - 1] == '/' || sourceDir[len - 1] == '\\')
            {
                --len;
            }

            int n = 0;

            for (int j = 0; j < files.Length; j++)
            {
                string str = files[j].Remove(0, len);
                string dest = destDir + str + ".bytes";
                string dir = Path.GetDirectoryName(dest);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                if (GameSetting.LuaByteMode)
                {
                    EncodeLuaFile(files[j], dest);
                }
                else
                {
                    File.Copy(files[j], dest, true);
                }

                UpdateProgress(n++, files.Length, dest);
            }
        }

        string[] dirs = Directory.GetDirectories(destDir, "*", SearchOption.AllDirectories);
        for (int i = 0; i < dirs.Length; i++)
        {
            string name = dirs[i].Replace(destDir, string.Empty);
            name = name.Replace('\\', '_').Replace('/', '_');
            name = "lua/lua_" + name.ToLower() + GameSetting.ExtName;

            string path = "Assets" + dirs[i].Replace(Application.dataPath, "");
            AddBuildMap(name, "*.bytes", path);
        }
        AddBuildMap("lua/lua" + GameSetting.ExtName, "*.bytes", "Assets/TmpLua");

        ////-------------------------------处理非Lua文件----------------------------------
        //string luaPath = AppDataPath + "/StreamingAssets/lua/";
        //for (int i = 0; i < srcDirs.Length; i++)
        //{
        //    mPaths.Clear();
        //    mFiles.Clear();

        //    string luaDataPath = srcDirs[i].ToLower();
        //    Recursive(luaDataPath);
        //    foreach (string f in mFiles)
        //    {
        //        if (f.EndsWith(".meta") || f.EndsWith(".lua")) continue;
        //        string newfile = f.Replace(luaDataPath, "");
        //        string path = Path.GetDirectoryName(luaPath + newfile);
        //        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        //        string destfile = path + "/" + Path.GetFileName(f);
        //        File.Copy(f, destfile, true);
        //    }
        //}

        EditorUtility.ClearProgressBar();
        AssetDatabase.Refresh();
    }

    static void AddBuildMap(string bundleName, string pattern, string path)
    {
        string[] files = Directory.GetFiles(path, pattern);
        if (files.Length == 0) return;

        for (int i = 0; i < files.Length; i++)
        {
            files[i] = files[i].Replace('\\', '/');
        }
        AssetBundleBuild build = new AssetBundleBuild();
        build.assetBundleName = bundleName;
        build.assetNames = files;
        mABBMaps.Add(build);
    }

    /// <summary>
    /// 遍历目录及其子目录
    /// </summary>
    static void Recursive(string path)
    {
        string[] names = Directory.GetFiles(path);
        string[] dirs = Directory.GetDirectories(path);
        foreach (string filename in names)
        {
            string ext = Path.GetExtension(filename);
            if (ext.Equals(".meta")) continue;
            mFiles.Add(filename.Replace('\\', '/'));
        }
        foreach (string dir in dirs)
        {
            mPaths.Add(dir.Replace('\\', '/'));
            Recursive(dir);
        }
    }

    /// <summary>
    /// 处理Lua文件
    /// </summary>
    private static void HandleLuaFile()
    {
        string resPath = Application.streamingAssetsPath;
        string luaPath = resPath + "/" + GetOS() + "/lua/";

        //----------复制Lua文件----------------
        if (!Directory.Exists(luaPath))
        {
            Directory.CreateDirectory(luaPath);
        }

        string srcDir = Application.dataPath + "/Lua/";
        string srcDir2 = Application.dataPath + "/ToLua/Lua/";

        string[] srcDirs = { srcDir, srcDir2 };

        for (int i = 0; i < srcDirs.Length; i++)
        {
            mPaths.Clear();
            mFiles.Clear();
            string luaDataPath = srcDirs[i].ToLower();
            Recursive(luaDataPath);
            int n = 0;
            foreach (string f in mFiles)
            {
                if (f.EndsWith(".meta")) continue;
                if (f.EndsWith(".bat")) continue;
                string newfile = f.Replace(luaDataPath, "");
                string newpath = luaPath + newfile;
                string path = Path.GetDirectoryName(newpath);
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                if (File.Exists(newpath))
                {
                    File.Delete(newpath);
                }
                if (GameSetting.LuaByteMode)
                {
                    EncodeLuaFile(f, newpath);
                }
                else
                {
                    File.Copy(f, newpath, true);
                }
                UpdateProgress(n++, mFiles.Count, newpath);
            }
        }
        EditorUtility.ClearProgressBar();
        AssetDatabase.Refresh();
    }

    static void UpdateProgress(int progress, int progressMax, string desc)
    {
        string title = "Processing...[" + progress + " - " + progressMax + "]";
        float value = (float)progress / (float)progressMax;
        EditorUtility.DisplayProgressBar(title, desc, value);
    }

    [MenuItem("打包游戏资源/Build Protobuf-lua-gen File", false, 150)]
    public static void BuildProtobufFile()
    {
        string dir = AppDataPath + "/Lua/3rd/pblua";
        mPaths.Clear();
        mFiles.Clear();
        Recursive(dir);

        string protoc = "d:/protobuf-2.4.1/src/protoc.exe";
        string protoc_gen_dir = "\"d:/protoc-gen-lua/plugin/protoc-gen-lua.bat\"";

        foreach (string f in mFiles)
        {
            string name = Path.GetFileName(f);
            string ext = Path.GetExtension(f);
            if (!ext.Equals(".proto")) continue;

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = protoc;
            info.Arguments = " --lua_out=./ --plugin=protoc-gen-lua=" + protoc_gen_dir + " " + name;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            info.UseShellExecute = true;
            info.WorkingDirectory = dir;
            info.ErrorDialog = true;
            UnityEngine.Debug.Log(info.FileName + " " + info.Arguments);

            Process pro = Process.Start(info);
            pro.WaitForExit();
        }

        AssetDatabase.Refresh();
    }
}
