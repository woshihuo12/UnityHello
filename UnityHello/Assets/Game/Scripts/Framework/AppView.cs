using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AppView : View
{
    private string message;

    List<string> MessageList
    {
        get
        {
            return new List<string>()
            { 
                NotiConst.UPDATE_MESSAGE,
                NotiConst.UPDATE_EXTRACT,
                NotiConst.UPDATE_DOWNLOAD,
                NotiConst.UPDATE_PROGRESS,
            };
        }
    }

    private void Awake()
    {
        RemoveMessage(this, MessageList);
        RegisterMessage(this, MessageList);
    }

    public override void OnMessage(IMessage message)
    {
        string name = message.Name;
        //object body = message.Body;
        switch (name)
        {
            case NotiConst.UPDATE_MESSAGE:      //更新消息
                break;
            case NotiConst.UPDATE_EXTRACT:      //更新解压
                break;
            case NotiConst.UPDATE_DOWNLOAD:     //更新下载
                break;
            case NotiConst.UPDATE_PROGRESS:     //更新下载进度
                break;
        }
    }
}
