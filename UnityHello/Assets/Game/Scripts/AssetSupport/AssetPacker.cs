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

    public Sprite GetSprite(string objName)
    {
        Object obj = GetAsset(objName);
        if (obj == null)
        {
            return Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 4, 4), new Vector2(0.5f, 0.5f));
        }
        return obj as Sprite;
    }

    public Texture2D GetTexture(string objName)
    {
        Object obj = GetAsset(objName);
        if (obj == null)
        {
            return Texture2D.whiteTexture;
        }
        return obj as Texture2D;
    }
}
