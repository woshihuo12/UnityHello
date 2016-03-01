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
}
