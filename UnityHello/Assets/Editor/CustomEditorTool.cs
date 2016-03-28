using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.Linq;

public class CustomEditorTool : MonoBehaviour
{
    [MenuItem("CustomEditorTool/StringTableTool")]
    private static void StringTableTool()
    {
        string dirName = Application.dataPath + "/Editor/StringTableTool";
        ProcessStartInfo info = new ProcessStartInfo();
        info.FileName = dirName + "/StringTableTool.bat";
        //info.Arguments = "";
        info.WindowStyle = ProcessWindowStyle.Hidden;
        info.UseShellExecute = true;
        info.WorkingDirectory = dirName;
        info.ErrorDialog = true;
        UnityEngine.Debug.Log(info.WorkingDirectory);
        Process pro = Process.Start(info);
        pro.WaitForExit();
    }

    /// <summary>
    /// 
    /// </summary>
    private static string mPackResFilePath = "Assets/Resources/res_asset_packer.asset";

    //private static bool CheckPackResFiles()
    //{
    //    if (Selection.activeObject == null)
    //    {
    //        return false;
    //    }
    //    return true;
    //}

    private static void PackRes(UnityEngine.Object[] assets)
    {
        if (assets == null)
        {
            return;
        }

        UnityEngine.Object assetPackerObj = AssetDatabase.LoadMainAssetAtPath(mPackResFilePath);
        AssetPacker assetPacker = null;
        if (assetPackerObj == null)
        {
            assetPacker = ScriptableObject.CreateInstance<AssetPacker>();
            assetPacker.name = "res_asset_packer";
            AssetDatabase.CreateAsset(assetPacker, mPackResFilePath);
        }
        else
        {
            assetPacker = assetPackerObj as AssetPacker;
        }

        assetPacker.mAssets = assets;
        assetPacker.hideFlags = HideFlags.NotEditable;

    }

    [MenuItem("CustomEditorTool/PackResFiles")]
    public static void PackResFiles()
    {
        string resName = "res_asset_packer.asset";
        List<UnityEngine.Object> assets = new List<UnityEngine.Object>();
        for (int i = 0; i < Selection.objects.Length; i++)
        {
            UnityEngine.Object asset = Selection.objects[i];
            Type t = asset.GetType();
            if (t == typeof(UnityEditor.DefaultAsset)
                || t == typeof(UnityEngine.GameObject)
                || t == typeof(UnityEngine.Font)
                || t == typeof(UnityEngine.Texture)
                || t == typeof(UnityEngine.Texture2D)
                || t == typeof(UnityEngine.AudioClip))
            {
                AssetImporter asIpter = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(asset));
                if (asIpter.assetBundleName.StartsWith("res_") && asIpter.assetBundleName != resName)
                {
                    UnityEngine.Debug.Log(asIpter.assetBundleName);
                    if (asIpter.assetBundleName.StartsWith("res_atlas"))
                    {
                        Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(AssetDatabase.GetAssetPath(asset)).OfType<Sprite>().ToArray();
                        assets.AddRange(sprites);
                    }
                    else if (asIpter.assetBundleName.StartsWith("res_music") || asIpter.assetBundleName.StartsWith("res_sound"))
                    {
                        assets.Add(asset);
                    }
                }
            }
        }

        if (assets.Count <= 0)
        {
            return;
        }

        PackRes(assets.ToArray());
    }




    ////////////////////////////////////////////////////


    static readonly string Error_RepeatAssetPath = "资源路径重复！该资源包有多个！\n资源包名称：";
    static readonly string Error_RepeatAssetPath_Paths = "\n多个文件路径：";
    static readonly string Tip_Title = "资源包提示";
    static readonly string Error_ErrorAssetName = "资源名称错误！必须和资源包名称保持一致！\n资源包名称：";

    //根据名字检查资源包正确性
    private static bool CheckAssetByName(string abName)
    {
        bool checkRet = true;
        UnityEngine.Debug.Log("Bundle:" + abName);
        //获取某个资源包路径字符串数组
        string[] assetPaths = AssetDatabase.GetAssetPathsFromAssetBundle(abName);
        if (assetPaths == null || assetPaths.Length <= 0) return false;
        int pathLength = assetPaths.Length;
        if (pathLength > 1)
        {
            //资源路径重复！该资源包有多个！
            string errinfo = Error_RepeatAssetPath + abName + Error_RepeatAssetPath_Paths + "\n";
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
        UnityEngine.Debug.Log("assetPath:" + assetPath);

        if (AssetDatabase.IsValidFolder(assetPath))
        {
            AssetImporter assetImporter = AssetImporter.GetAtPath(assetPath);
            assetImporter.assetBundleName = null;
            assetImporter.assetBundleVariant = null;
            return true;
        }

        //根据路径拼接出，某个资源包名称
        string assetName = assetPath.Substring(assetPath.LastIndexOf('/') + 1, assetPath.LastIndexOf('.') - assetPath.LastIndexOf('/') - 1);
        UnityEngine.Debug.Log("assetName:" + assetName);
        if (abName.StartsWith("ui"))
        {
            if (assetName != abName)
            {
                EditorUtility.DisplayDialog(Tip_Title, Error_ErrorAssetName + abName, "OK");
                checkRet = false;
            }
        }
        else if (abName.StartsWith("res"))
        {
            if (assetName != abName)
            {
                EditorUtility.DisplayDialog(Tip_Title, Error_ErrorAssetName + abName, "OK");
                checkRet = false;
            }
        }

        return checkRet;
    }


    //根据选择的资源检查正确性
    [MenuItem("CustomEditorTool/CheckAssetBySelect")]
    public static void CheckAssetBySelect()
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

            }
        }
    }
}
