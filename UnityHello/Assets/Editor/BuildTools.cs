using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using KEngine;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace KEngine.Editor
{
    public class BuildTools
    {
        /// <summary>
        /// Unity 5新AssetBundle系统，需要为打包的AssetBundle配置名称
        /// 
        /// 直接将KEngine配置的BundleResources目录整个自动配置名称，因为这个目录本来就是整个导出
        /// </summary>
        [MenuItem("KEngine/AssetBundle/Make Names from [BundleResources]")]
        public static void MakeAssetBundleNames()
        {
            var dir = "Assets/" + EngineConfig.instance.ResourcesBuildDir + "/";

            // Check marked asset bundle whether real
            foreach (var assetGuid in AssetDatabase.FindAssets(""))
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(assetGuid);
                var assetImporter = AssetImporter.GetAtPath(assetPath);
                var bundleName = assetImporter.assetBundleName;
                if (string.IsNullOrEmpty(bundleName))
                {
                    continue;
                }
                if (!assetPath.StartsWith(dir))
                {
                    assetImporter.assetBundleName = null;
                }
            }

            var dirForDirs = dir + "BuildByDir/";
            // set BundleResources's all bundle name
            foreach (var filepath in Directory.GetFiles(dirForDirs, "*.*", SearchOption.AllDirectories))
            {
                if (filepath.EndsWith(".meta")
                    || filepath.EndsWith(".tpsheet"))
                {
                    continue;
                }
                var importer = AssetImporter.GetAtPath(filepath);
                if (importer == null)
                {
                    Log.Error("Not found: {0}", filepath);
                    continue;
                }

                var bundleName = filepath.Substring(dirForDirs.Length, filepath.Length - dirForDirs.Length - Path.GetFileName(filepath).Length - 1);
                importer.assetBundleName = bundleName + EngineConfig.instance.ABExtName;
            }

            var dirForFiles = dir + "BuildByFile/";
            // set BundleResources's all bundle name
            foreach (var filepath in Directory.GetFiles(dirForFiles, "*.*", SearchOption.AllDirectories))
            {
                if (filepath.EndsWith(".meta")) continue;

                var importer = AssetImporter.GetAtPath(filepath);
                if (importer == null)
                {
                    Log.Error("Not found: {0}", filepath);
                    continue;
                }
                var bundleName = filepath.Substring(dirForFiles.Length, filepath.Length - dirForFiles.Length);
                importer.assetBundleName = bundleName + EngineConfig.instance.ABExtName;
            }

            AssetDatabase.RemoveUnusedAssetBundleNames();
            Log.Info("Make all asset name successs!");
        }

        [MenuItem("KEngine/AssetBundle/Build All to All Platforms")]
        public static void BuildAllAssetBundlesToAllPlatforms()
        {
            var platforms = new List<BuildTarget>()
            {
                BuildTarget.iOS,
                BuildTarget.Android,
                BuildTarget.StandaloneWindows,
                BuildTarget.StandaloneOSXIntel,
            };

            // Build all support platforms asset bundle
            var currentBuildTarget = EditorUserBuildSettings.activeBuildTarget;
            platforms.Remove(currentBuildTarget);
            BuildAllAssetBundles();

            foreach (var platform in platforms)
            {
                if (EditorUserBuildSettings.SwitchActiveBuildTarget(platform))
                    BuildAllAssetBundles();
            }

            // revert platform 
            EditorUserBuildSettings.SwitchActiveBuildTarget(currentBuildTarget);
        }

        [MenuItem("KEngine/AssetBundle/Build All %&b")]
        public static void BuildAllAssetBundles()
        {
            if (EditorApplication.isPlaying)
            {
                Log.Error("Cannot build in playing mode! Please stop!");
                return;
            }
            MakeAssetBundleNames();
            var outputPath = GetExportPath(EditorUserBuildSettings.activeBuildTarget);
            Log.Info("Asset bundle start build to: {0}", outputPath);
            BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.DeterministicAssetBundle, EditorUserBuildSettings.activeBuildTarget);
        }

        /// <summary>
        /// Extra Flag ->   ex:  Android/  AndroidSD/  AndroidHD/
        /// </summary>
        /// <param name="platfrom"></param>
        /// <param name="quality"></param>
        /// <returns></returns>
        public static string GetExportPath(BuildTarget platfrom)
        {
            string basePath = Path.GetFullPath(EngineConfig.instance.AssetBundleBuildRelPath);
            if (File.Exists(basePath))
            {
                BuildTools.ShowDialog("路径配置错误: " + basePath);
                throw new System.Exception("路径配置错误");
            }
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            var platformName = KResourceManager.BuildPlatformName;
            string path = basePath + "/" + platformName + "/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static bool ShowDialog(string msg, string title = "提示", string button = "确定")
        {
            return EditorUtility.DisplayDialog(title, msg, button);
        }

        public static void ShowDialogSelection(string msg, Action yesCallback)
        {
            if (EditorUtility.DisplayDialog("确定吗", msg, "是!", "不！"))
            {
                yesCallback();
            }
        }
        public static void BuildError(string fmt, params string[] args)
        {
            fmt = "[BuildError]" + fmt;
            Debug.LogError(string.Format(fmt, args));
        }

        /// <summary>
        /// 获取完整的打包路径，并确保目录存在
        /// </summary>
        /// <param name="path"></param>
        /// <param name="buildTarget"></param>
        /// <returns></returns>
        public static string MakeSureExportPath(string path, BuildTarget buildTarget)
        {
            path = BuildTools.GetExportPath(buildTarget) + path;

            path = path.Replace("\\", "/");

            string exportDirectory = path.Substring(0, path.LastIndexOf('/'));
            if (!System.IO.Directory.Exists(exportDirectory))
                System.IO.Directory.CreateDirectory(exportDirectory);
            return path;
        }

        /// <summary>
        /// 检查如果有依赖，报出
        /// 检查prefab中存在prefab依赖，进行打散！
        /// </summary>
        /// <param name="assetPath"></param>
        public static void CheckAndLogDependencies(string assetPath)
        {
            if (string.IsNullOrEmpty(assetPath))
                return;

            // 输出依赖
            var depSb = new StringBuilder();
            var asset = AssetDatabase.LoadAssetAtPath(assetPath, typeof(UnityEngine.Object));
            var depsArray = EditorUtility.CollectDependencies(new[] { asset });
            if (depsArray != null && depsArray.Length > 0)
            {
                if (depsArray.Length == 1 && depsArray[0] == asset)
                {
                    // 自己依赖自己的忽略掉
                }
                else
                {
                    foreach (var depAsset in depsArray)
                    {
                        var depAssetPath = AssetDatabase.GetAssetPath(depAsset);
                        depSb.AppendLine(string.Format("{0} --> {1} <{2}>", depAssetPath, depAsset.name, depAsset.GetType()));
                    }
                    Log.Info("[BuildAssetBundle]Asset: {0} has dependencies: \n{1}", assetPath, depSb.ToString());
                }
            }
        }

        [MenuItem("Assets/Print Asset Dependencies", false, 100)]
        public static void MenuCheckAndLogDependencies()
        {
            var obj = Selection.activeObject;
            if (obj == null)
            {
                Debug.LogError("No selection object");
                return;
            }
            var assetPath = AssetDatabase.GetAssetPath(obj);
            BuildTools.CheckAndLogDependencies(assetPath);
        }

        [MenuItem("KEngine/AssetBundle/SymbolLinkResource", false, 90)]
        public static void SymbolLinkResource()
        {
            // Auto Link resources when play!
            if (!Directory.Exists(ResourcesSymbolLinkHelper.GetLinkPath()))
            {
                Log.Warning("Auto Link Bundle Resources Path... {0}", ResourcesSymbolLinkHelper.GetLinkPath());
                ResourcesSymbolLinkHelper.SymbolLinkResource();
            }
        }

        private static void DeleteLuaDirectoy(string parentDir)
        {
            if (!Directory.Exists(parentDir))
            {
                return;
            }

            parentDir.Replace("\\", "/");

            var subDirectorys = Directory.GetDirectories(parentDir, "*", SearchOption.AllDirectories);
            if (subDirectorys != null && subDirectorys.Length > 0)
            {
                for (int i = 0; i < subDirectorys.Length; ++i)
                {
                    if (Path.GetFileNameWithoutExtension(subDirectorys[i]).Equals("Lua", StringComparison.OrdinalIgnoreCase))
                    {
                        Directory.Delete(subDirectorys[i], true);
                    }
                }
            }
        }

        [MenuItem("KEngine/ToLua/Clear All Lua Files", false, 54)]
        private static void ClearAllLuaFiles()
        {
            var productBundlePath = KResourceManager.EditorProductFullPath + "/" + KResourceManager.BundlesDirName;
            DeleteLuaDirectoy(productBundlePath);

            productBundlePath = Application.streamingAssetsPath + "/" + KResourceManager.BundlesDirName;
            DeleteLuaDirectoy(productBundlePath);

            productBundlePath = KResourceManager.GetAppDataPath() + "/" + KResourceManager.BundlesDirName;
            DeleteLuaDirectoy(productBundlePath);

            productBundlePath = Application.dataPath + "/Resources";
            DeleteLuaDirectoy(productBundlePath);

            productBundlePath = Application.dataPath + "/" + EngineConfig.instance.ResourcesBuildDir;
            DeleteLuaDirectoy(productBundlePath);

            AssetDatabase.Refresh();
            Log.Info("Clear lua files over");
        }

        private static void CopyLuaBytesFiles(string sourceDir, string destDir, bool appendext = true, string searchPattern = "*.lua", SearchOption option = SearchOption.AllDirectories)
        {
            if (!Directory.Exists(sourceDir))
            {
                return;
            }

            string[] files = Directory.GetFiles(sourceDir, searchPattern, option);
            int len = sourceDir.Length;
            if (sourceDir[len - 1] == '/' || sourceDir[len - 1] == '\\')
            {
                --len;
            }

            for (int i = 0; i < files.Length; i++)
            {
                string str = files[i].Remove(0, len);
                string dest = destDir + "/" + str;
                if (appendext) dest += ".bytes";
                string dir = Path.GetDirectoryName(dest);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                File.Copy(files[i], dest, true);
            }
        }

        private static string CreateBundleResourceDir(string dir)
        {
            dir = Application.dataPath + "/" + EngineConfig.instance.ResourcesBuildDir + "/" + dir;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }

        [MenuItem("KEngine/ToLua/Build Lua files to BundleResources (PC)", false, 53)]
        public static void BuildLuaToResources()
        {
            ClearAllLuaFiles();
            string destDir = Application.dataPath + "/" + EngineConfig.instance.ResourcesBuildDir + "/BuildByDir/Lua/LuaScripts";
            string destDir2 = Application.dataPath + "/" + EngineConfig.instance.ResourcesBuildDir + "/BuildByDir/Lua/ToLuaScripts";
            CopyLuaBytesFiles(LuaConst.luaDir, destDir);
            CopyLuaBytesFiles(LuaConst.toluaDir, destDir2);
            AssetDatabase.Refresh();
            Log.Info("Copy lua files over");
        }
    }
}