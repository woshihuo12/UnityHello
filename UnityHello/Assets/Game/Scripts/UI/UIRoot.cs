using UnityEngine;
using System.Collections;

public class UIRoot : MonoBehaviour
{
    private static UIRoot sLayer = null;
    public static UIRoot Instance()
    {
        return sLayer;
    }

    public Camera mUICamera;

    public RectTransform mNormalRootRt;
    public RectTransform mFixedRootRt;
    public RectTransform mPopupRootRt;

    private void Awake()
    {
        sLayer = this;
        DontDestroyOnLoad(gameObject);
    }

    public virtual void ShowNormalRoot()
    {
        mNormalRootRt.gameObject.SetActive(true);
    }

    public virtual void HideNormalRoot()
    {
        mNormalRootRt.gameObject.SetActive(false);
    }

    public virtual void ShowFixedRoot()
    {
        mFixedRootRt.gameObject.SetActive(true);
    }

    public virtual void HideFixedRoot()
    {
        mFixedRootRt.gameObject.SetActive(false);
    }

    public virtual void ShowPopupRoot()
    {
        mPopupRootRt.gameObject.SetActive(true);
    }

    public virtual void HidePopupRoot()
    {
        mPopupRootRt.gameObject.SetActive(false);
    }

    //世界转换到屏幕坐标
    public Vector3 WorldToScreenPoint(Vector3 position)
    {
        return mUICamera.WorldToScreenPoint(position);
    }

    //局部世界转换到屏幕坐标
    public Vector3 LocalToWorldUIPosition(RectTransform localRtTrans, RectTransform worldRtTrans)
    {
        Vector3 p = localRtTrans.position - worldRtTrans.position;
        p = UIRoot.Instance().WorldToScreenPoint(p);
        p = UIRoot.Instance().ScreenToUIPosition(p);
        return p;
    }

    //屏幕转换到UI坐标
    public Vector2 ScreenToUIPosition(Vector2 screenpos)
    {
        Vector2 pos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(mNormalRootRt, screenpos, mUICamera, out pos);
        return pos;
    }

    //ui坐标转换为屏幕坐标
    public Vector2 UIToScreenPosition(Vector2 uipos)
    {
        return mUICamera.WorldToScreenPoint(mNormalRootRt.TransformPoint(uipos));
    }
}
