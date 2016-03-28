using UnityEngine;
using System.Collections;

public class AssetPacker : ScriptableObject
{
    public Object[] mAssets;

    public Object GetAsset(string objName)
    {
        for (int i = 0; i < mAssets.Length; ++i)
        {
            Object obj = mAssets[i];
            if (obj != null && obj.name == objName)
            {
                return obj;
            }
        }
        return null;
    }
}
