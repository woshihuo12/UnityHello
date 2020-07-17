using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.U2D;

/// <summary>
/// UI打图集工具函数
/// </summary>
public class SpriteAtlasMaker : Editor
{
    [MenuItem("Assets/MakeSpriteAtlas")]
    public static void MakeSpriteAtlas()
    {
        if (EditorApplication.isCompiling)
        {
            EditorUtility.DisplayDialog("警告", "请等待编辑器完成编译再执行此功能", "确定");
            return;
        }

        string[] objs = Selection.assetGUIDs;
        if (objs.Length != 1)
        {
            EditorUtility.DisplayDialog("警告", "请右键选中 Arts/atlasimage 文件夹下的单个文件夹进行操作", "确定");
            return;
        }

        string selectPath = AssetDatabase.GUIDToAssetPath(objs[0]);
        if (!selectPath.Contains("atlasimage/"))
        {
            EditorUtility.DisplayDialog("警告", "请右键选中 Arts/atlasimage 文件夹下的单个文件夹进行操作", "确定");
            return;
        }

        // 不是文件夹
        if (!Directory.Exists(selectPath))
        {
            EditorUtility.DisplayDialog("警告", "请右键选中 Arts/atlasimage 文件夹下的单个文件夹进行操作", "确定");
            return;
        }

        if (selectPath.EndsWith("lang"))
        {
            var subLangDirs = Directory.GetDirectories(selectPath);
            foreach (var subLange in subLangDirs)
            {
                MakeAtlas(subLange);
            }
        }
        else
        {
            MakeAtlas(selectPath);
        }
    }

    public static void MakeAtlas(string selectPath)
    {
        var destAtlasParentDir = "Assets/BundleResources/BuildByDir/UI/spriteatlas";
        if (!Directory.Exists(destAtlasParentDir))
        {
            Directory.CreateDirectory(destAtlasParentDir);
        }

        var dirInfo = new DirectoryInfo(selectPath);
        var atlasName = dirInfo.Name;

        if (atlasName == "english" || atlasName == "chinese")
        {
            atlasName = dirInfo.Parent.Name + "_" + atlasName;
        }
        
        var destAtlasDir = destAtlasParentDir + "/" + atlasName;
        if (!Directory.Exists(destAtlasDir))
        {
            Directory.CreateDirectory(destAtlasDir);
        }

        var destAtlasFileName = destAtlasDir + "/" + atlasName + ".spriteatlas";

        SpriteAtlas tmpAtlas = null;
        if (!File.Exists(destAtlasFileName))
        {
            tmpAtlas = new SpriteAtlas();

            AssetDatabase.CreateAsset(tmpAtlas, destAtlasFileName);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        else
        {
            tmpAtlas = AssetDatabase.LoadAssetAtPath<SpriteAtlas>(destAtlasFileName);
        }

        if (tmpAtlas == null)
        {
            return;
        }

        tmpAtlas.Remove(tmpAtlas.GetPackables());

        var selectDir = AssetDatabase.LoadAssetAtPath<Object>(selectPath);
        tmpAtlas.Add(new Object[] { selectDir });

        //////////////////////////////////  
        var packageSetting = tmpAtlas.GetPackingSettings();
        packageSetting.enableRotation = false;
        packageSetting.enableTightPacking = false;
        packageSetting.padding = 2;
        tmpAtlas.SetPackingSettings(packageSetting);
        //////////////////////////////////

        var texSetting = tmpAtlas.GetTextureSettings();
        texSetting.readable = false;
        texSetting.generateMipMaps = false;
        texSetting.sRGB = true;
        texSetting.filterMode = FilterMode.Bilinear;
        tmpAtlas.SetTextureSettings(texSetting);

        //////////////////////////////////
        var standaloneSettings = tmpAtlas.GetPlatformSettings("Standalone");

        standaloneSettings.maxTextureSize = 2048;
        standaloneSettings.format = TextureImporterFormat.DXT5;
        standaloneSettings.overridden = true;
        tmpAtlas.SetPlatformSettings(standaloneSettings);

        var androidSettings = tmpAtlas.GetPlatformSettings("Android");
        androidSettings.maxTextureSize = 2048;
        androidSettings.format = TextureImporterFormat.ETC2_RGBA8;
        androidSettings.overridden = true;
        tmpAtlas.SetPlatformSettings(androidSettings);

        var iosSettings = tmpAtlas.GetPlatformSettings("iPhone");
        iosSettings.maxTextureSize = 2048;
        iosSettings.format = TextureImporterFormat.ASTC_RGBA_6x6;
        iosSettings.overridden = true;
        tmpAtlas.SetPlatformSettings(iosSettings);


        /// /////////////////////////////////
        SpriteAtlasUtility.PackAllAtlases(BuildTarget.StandaloneWindows64);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
