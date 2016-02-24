using UnityEngine;
using System.Collections;

public class UILayer : LayerBase
{
    private static UILayer sLayer = null;
    public static UILayer Instance()
    {
        return sLayer;
    }

    public override void Awake()
    {
        base.Awake();
        sLayer = this;
    }

    private RectTransform mCavasRtTrans;

    public override string LayerName
    {
        get
        {
            return "UI";
        }
    }

    private RectTransform mRtLayerparent = null;

    public RectTransform LayerParentRect
    {
        get
        {
            if (mRtLayerparent == null)
            {
                mRtLayerparent = mLayerParent.GetComponent<RectTransform>();
            }
            return mRtLayerparent;
        }
    }
    
    //屏幕转换到UI坐标
    public Vector2 ScreenToUIPosition(Vector2 screenpos)
    {
        Vector2 pos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(LayerParentRect, screenpos, mLayerCamera, out pos);
        return pos;
    }

    //ui坐标转换为屏幕坐标
    public Vector2 UIToScreenPosition(Vector2 uipos)
    {
        return mLayerCamera.WorldToScreenPoint(LayerParentRect.TransformPoint(uipos));
    }
}
