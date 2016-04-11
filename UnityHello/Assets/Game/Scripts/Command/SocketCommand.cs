using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SocketCommand : ControllerCommand
{
    private NetworkManager mNetworkManager;
    public override void Execute(IMessage message)
    {
        object data = message.Body;
        if (data == null) return;
        KeyValuePair<int, ByteBuffer> buffer = (KeyValuePair<int, ByteBuffer>)data;
        switch (buffer.Key)
        {
            default:
                if (mNetworkManager = null)
                {
                    mNetworkManager = AppFacade.Instance.GetManager<NetworkManager>();
                }
                mNetworkManager.OnSocketData(buffer.Key, buffer.Value);
                break;
        }
    }
}
