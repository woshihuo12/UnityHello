using UnityEngine;
using System.Collections;

public abstract class LayerBase : MonoBehaviour
{
    public Transform mLayerParent;
    public Camera mLayerCamera;

    public abstract string LayerName { get; }

    public virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public virtual void ShowLayer()
    {
        mLayerParent.gameObject.SetActive(true);
    }

    public virtual void HideLayer()
    {
        mLayerParent.gameObject.SetActive(false);
    }

    public Vector3 WorldToScreenPoint(Vector3 position)
    {
        return mLayerCamera.WorldToScreenPoint(position);
    }

    public Vector3 LocalToWorldUIPosition(RectTransform localRtTrans, RectTransform worldRtTrans)
    {
        Vector3 p = localRtTrans.position - worldRtTrans.position;
        p = UILayer.Instance().WorldToScreenPoint(p);
        p = UILayer.Instance().ScreenToUIPosition(p);
        return p;
    }
}
