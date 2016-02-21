using UnityEngine;
using System.Collections;
using UnityEditor;

public class PackResTool
{
    private static string mPackResFileName = "res_asset_packer";
    private static string mFileExt = ".asset";
    private static string mPackResFilePath = "Assets/Res/" + mPackResFileName + mFileExt;

    private static bool CheckPackResFiles()
    {
        if (Selection.activeObject == null)
        {
            return false;
        }
        return true;
    }

    private static void PackRes(UnityEngine.Object[] assets)
    {
        if (assets == null)
        {
            return;
        }

    }
}
