using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : Manager
{
    public static string AssetBundlePath = GameSetting.TransAssetPath + "/AssetBundles/";

    public Dictionary<string, uint> AssetBundlesCrcPairs = new Dictionary<string, uint>();

}
