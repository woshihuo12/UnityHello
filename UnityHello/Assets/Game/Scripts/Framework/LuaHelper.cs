using UnityEngine;
using System.Collections;
using LuaInterface;

public sealed class LuaHelper
{
    /// <summary>
    /// 网络管理器
    /// </summary>
    public static NetworkManager GetNetManager()
    {
        return AppFacade.Instance.GetManager<NetworkManager>();
    }
}
