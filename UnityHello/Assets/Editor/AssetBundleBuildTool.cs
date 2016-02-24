using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEditor.SceneManagement;

public class AssetBundleBuildTool
{
    static List<Type> mMarkBundleWhiteList = new List<Type>()
    {
        typeof(UnityEditor.DefaultAsset),
        typeof(UnityEngine.GameObject),
        typeof(UnityEngine.Font),
        typeof(UnityEngine.Texture),
        typeof(UnityEngine.Texture2D),
        typeof(AssetPacker),
        typeof(UnityEngine.AudioClip),
    };

    static readonly string BuildABPathKey = "BuildAssetBundlePath";

    static readonly string Tip_Title = "资源包提示";
    static readonly string Tip_CheckSuccess = "资源包检查成功，可以正常导出！";
    static readonly string Tip_Success = "导出资源包成功！";
    static readonly string Tip_Success_NoNew = "可能是以下情况\n1.当前资源包是最新版本，无需重新打包！\n2.注意log，也有可能是生成出错!";
    static readonly string Error_NoAssets = "无可导出资源包！";
    static readonly string Error_RepeatAssetPath = "资源路径重复！该资源包有多个！\n资源包名称：";
    static readonly string Error_RepeatAssetPath_Paths = "\n多个文件路径：";
    static readonly string Error_ErrorAssetBundleName = "资源包名称错误！资源包名称不合法！\n资源包名称：";
    static readonly string Error_ErrorAssetName = "资源名称错误！必须和资源包名称保持一致！\n资源包名称：";
    //     static readonly string Error_SceneHasCamera="场景内部错误：场景中不能有摄像机! \n场景名称：";
    static readonly string Error_SceneHasMeshCollider = "场景内部错误：场景中不能有MeshCollider! \n场景名称：";
    static readonly string Error_SceneObjNameError = "场景内部错误：没有Scene对象！\n场景名称：";
    static readonly string Error_NaviObjNameError = "场景内部错误：没有Navi对象！\n场景名称：";
    static readonly string Error_MarkObjNameError = "场景内部错误：没有Mark对象！\n场景名称：";
    //static readonly string Error_StartPointObjNameError="场景内部错误：没有StartPoint对象！\n场景名称：";
    //     static readonly string Error_TerrainObjNameError="场景内部错误：没有Terrain对象！\n场景名称：";

    static readonly string Error_NoEffectInfo = "特效对象错误：没有EffectInfo组件！\n特效名称：";
    //static readonly string Error_NoUIInfo = "UI对象错误：没有UIInfo组件！\nUI名称：";

    static bool CheckMarkAssetBundle()
    {
        if (Selection.activeObject == null)
        {
            return false;
        }
        return true;
    }

    static void DoMarkAssetBundle(params UnityEngine.Object[] objs)
    {
        if (objs == null)
        {
            return;
        }
        for (int i = 0; i < objs.Length; i++)
        {
            Type tp = objs[i].GetType();
            Debug.Log(tp);
            if (mMarkBundleWhiteList.Contains(tp))
            {
                AssetImporter asIpter = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(objs[i]));
                asIpter.assetBundleName = objs[i].name;
            }
        }
        AssetDatabase.RemoveUnusedAssetBundleNames();
    }

    [MenuItem("Assets/MarkAssetBundle")]
    static void MarkAssetBundle()
    {
        DoMarkAssetBundle(Selection.objects);
        AssetDatabase.Refresh();
    }

    [MenuItem("ExportAsset/检查资源包正确性")]
    static void CheckABsDisplay()
    {
        if (CheckABs())
        {
            //遍历全部资源包，假如全部正确，提示资源包全部正确
            EditorUtility.DisplayDialog(Tip_Title, Tip_CheckSuccess, "OK");
        }
    }

    [MenuItem("ExportAsset/清空资源包")]
    public static void ClearABs()
    {
        string BuildAssetBundlePath = string.Empty;
        if (EditorPrefs.HasKey(BuildABPathKey))
        {
            BuildAssetBundlePath = EditorPrefs.GetString(BuildABPathKey);
        }
        if (string.IsNullOrEmpty(BuildAssetBundlePath))
        {
            return;
        }

        string path = BuildAssetBundlePath + "/StandAlone";
        if (Directory.Exists(path)) Directory.Delete(path, true);

        path = BuildAssetBundlePath + "/Android";
        if (Directory.Exists(path)) Directory.Delete(path, true);

        path = BuildAssetBundlePath + "/iOS";
        if (Directory.Exists(path)) Directory.Delete(path, true);
    }

    [MenuItem("ExportAsset/生成资源包/Editor")]
    public static void MenuItem_BuildABsEditor()
    {
        BuildPlatformABs("", BuildTarget.StandaloneWindows64);
        AssetDatabase.Refresh();
    }

    [MenuItem("ExportAsset/生成资源包/Android")]
    public static void MenuItem_BuildABsAndroid()
    {
        BuildPlatformABs("", BuildTarget.Android);
        AssetDatabase.Refresh();
    }

    [MenuItem("ExportAsset/生成资源包/iOS")]
    public static void MenuItem_BuildABsIOS()
    {
        BuildPlatformABs("", BuildTarget.iOS);
        AssetDatabase.Refresh();
    }

    //命令行调用函数
    public static void CMD_BuildABsEditor()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.WebPlayer);
        BuildPlatformABs(CommandLineReader.GetCustomArgument("path"), BuildTarget.WebPlayer);
        AssetDatabase.Refresh();
    }
    
    /// <summary>
    /// 检测全部资源包正确性
    /// </summary>
    private static bool CheckABs()
    {
        //获取全部资源包名字
        string[] bundleNames = AssetDatabase.GetAllAssetBundleNames();
        //获取没有用过的资源包的名字
        string[] unUsedBundleNames = AssetDatabase.GetUnusedAssetBundleNames();
        //假如没有资源或者，没有新资源，提示没有错误
        if (bundleNames == null
            || bundleNames.Length == 0
            || bundleNames.Length == unUsedBundleNames.Length)
        {
            EditorUtility.DisplayDialog(Tip_Title, Error_NoAssets, "OK");
            return false;
        }

        bool checkRet = true;

        var curActiveScene = EditorSceneManager.GetActiveScene();
        //获取当前场景路径
        string oldSceneName = curActiveScene != null ? curActiveScene.path : string.Empty;
        //保存当前场景
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        Debug.Log("currentScene:" + oldSceneName);

        //遍历全部资源包名字
        for (int i = 0; i < bundleNames.Length; i++)
        {
            if (CheckAssetByName(bundleNames[i]) == false)
            {
                return false;
            }
        }
        EditorSceneManager.OpenScene(oldSceneName);
        return checkRet;
    }

    //根据名字检查资源包正确性
    static bool CheckAssetByName(string abName)
    {
        bool checkRet = true;
        Debug.Log("Bundle:" + abName);
        //获取某个资源包路径字符串数组
        string[] assetPaths = AssetDatabase.GetAssetPathsFromAssetBundle(abName);
        if (assetPaths != null)
        {
            int pathLength = assetPaths.Length;
            if (pathLength > 0)
            {
                if (pathLength > 1)
                {
                    //资源路径重复！该资源包有多个！
                    string errinfo = Error_RepeatAssetPath + abName
                        + Error_RepeatAssetPath_Paths + "\n";
                    //遍历资源包路径长度
                    for (int j = 0; j < assetPaths.Length; j++)
                    {
                        errinfo += assetPaths[j] + "\n";
                    }
                    EditorUtility.DisplayDialog(Tip_Title, errinfo, "OK");
                    checkRet = false;
                }

                //获取某个资源包路径
                string assetPath = assetPaths[0];
                Debug.Log("assetPath:" + assetPath);
                if (AssetDatabase.IsValidFolder(assetPath))
                {
                    AssetImporter assetImporter = AssetImporter.GetAtPath(assetPath);
                    assetImporter.assetBundleName = null;
                    assetImporter.assetBundleVariant = null;
                    return true;
                }

                //根据路径拼接出，某个资源包名称
                string assetName = assetPath.Substring(assetPath.LastIndexOf('/') + 1, assetPath.LastIndexOf('.') - assetPath.LastIndexOf('/') - 1);
                Debug.Log("assetName:" + assetName);

                if (abName.StartsWith("effect"))
                {
                    if (assetName != abName)
                    {
                        EditorUtility.DisplayDialog(Tip_Title, Error_ErrorAssetName + abName, "OK");
                        checkRet = false;
                    }
                }
                else if (abName.StartsWith("ui"))
                {
                    if (assetName != abName)
                    {
                        EditorUtility.DisplayDialog(Tip_Title, Error_ErrorAssetName + abName, "OK");
                        return checkRet;
                    }
                }
                else
                {
                    EditorUtility.DisplayDialog(Tip_Title, Error_ErrorAssetBundleName + abName, "OK");
                    checkRet = false;
                }
            }
        }

        Debug.Log("==================================");

        return checkRet;
    }

    /// <summary>
    /// 设置打包路径
    /// </summary>
    private static string BuildAssetSetting(string inputPath, BuildTarget targetPlatform)
    {
        //建立打包资源路径
        string BuildAssetBundlePath = inputPath;
        if (string.IsNullOrEmpty(inputPath))
        {
            //判断资源打包关键字，并赋值
            if (EditorPrefs.HasKey(BuildABPathKey))
            {
                BuildAssetBundlePath = EditorPrefs.GetString(BuildABPathKey);
            }
            BuildAssetBundlePath = EditorUtility.OpenFolderPanel("选择生成目录", BuildAssetBundlePath, "");
            //当不为空时，设置由键确定的偏好值
            if (BuildAssetBundlePath != "")
            {
                EditorPrefs.SetString(BuildABPathKey, BuildAssetBundlePath);
            }
            else
            {
                return null;
            }
        }

        //建立资源生成路径
        string path = BuildAssetBundlePath + "/" + targetPlatform.ToString();
        //建立存放 AssetBundle 
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        return path;
    }

    /// <summary>
    /// 根据平台打包全部资源的方法
    /// </summary>
    private static void BuildPlatformABs(string inputPath, BuildTarget targetPlatform)
    {
        if (CheckABs())
        {
            ///设置打包路径
            string path = BuildAssetSetting(inputPath, targetPlatform);
            //资源打包设置
            BuildAssetBundleOptions assetBundleOptions = BuildAssetBundleOptions.None;
            //打包全部标记的资源（路径，选项，平台），取得清单中的所有assetBundle构建。
            if (!string.IsNullOrEmpty(path))
            {
                //打包所有assetbundle
                AssetBundleManifest absinfo = BuildPipeline.BuildAssetBundles(path, assetBundleOptions, targetPlatform);
                //ReturnsPackagingInfo(path, absinfo);
            }
        }
    }

    private static bool CanCheckAssetBySelect()
    {
        if (Selection.activeObject == null)
        {
            return false;
        }
        return true;
    }

    //根据选择的资源检查正确性
    [MenuItem("Assets/CheckAssetBySelect")]
    static void CheckAssetBySelect()
    {
        bool isNameRight = false;
        for (int i = 0; i < Selection.objects.Length; i++)
        {
            Type t = Selection.objects[i].GetType();
            if (t == typeof(UnityEditor.DefaultAsset)
               || t == typeof(UnityEngine.GameObject)
               || t == typeof(UnityEngine.Font)
               || t == typeof(UnityEngine.Texture)
               || t == typeof(UnityEngine.Texture2D))
            {
                AssetImporter asIpter = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(Selection.objects[i]));
                asIpter.assetBundleName = Selection.objects[i].name;
                if (CheckAssetByName(asIpter.assetBundleName))
                {
                    isNameRight = true;
                }
            }
        }
        if (isNameRight)
        {
            EditorUtility.DisplayDialog(Tip_Title, Tip_CheckSuccess, "OK");
        }
    }
}