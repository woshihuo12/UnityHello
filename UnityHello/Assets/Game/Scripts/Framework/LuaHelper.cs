using UnityEngine;
using System.Collections;

public class LuaHelper
{
    /// <summary>
    /// 资源管理器
    /// </summary>
    public static ResourceManager GetResManager()
    {
        return AppFacade.Instance.GetManager<ResourceManager>();
    }

    public static void ChangeChildLayer(Transform t, int layer)
    {
        t.gameObject.layer = layer;
        for (int i = 0; i < t.childCount; ++i)
        {
            Transform child = t.GetChild(i);
            child.gameObject.layer = layer;
            ChangeChildLayer(child, layer);
        }
    }

    public static void AddChildToTarget(Transform target, Transform child)
    {
        child.SetParent(target, false);
        child.localScale = Vector3.one;
        child.localPosition = Vector3.zero;
        child.localRotation = Quaternion.identity;

        ChangeChildLayer(child, target.gameObject.layer);
    }
}
