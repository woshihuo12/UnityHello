using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

public class NetworkManager : Manager
{
    private LuaState mLuaState = null;
    private LuaTable mLuaTable = null;

    private SocketClient mSocketClient;
    static Queue<KeyValuePair<int, ByteBuffer>> sEvents = new Queue<KeyValuePair<int, ByteBuffer>>();

    private SocketClient SocketClient
    {
        get
        {
            if (mSocketClient == null)
            {
                mSocketClient = new SocketClient();
            }
            return mSocketClient;
        }
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        SocketClient.OnRegister();
    }

    public void SetLuaTable(LuaTable tb)
    {
        mLuaState = SimpleLuaClient.GetMainState();
        if (mLuaState == null) return;

        if (tb == null)
        {
            mLuaTable = mLuaState.GetTable("NetworkManager");
        }
        else
        {
            mLuaTable = tb;
        }

        if (mLuaTable == null)
        {
            Debug.LogWarning("NetworkManager is null:");
            return;
        }
    }

    private bool CheckValid()
    {
        if (mLuaState == null) return false;
        if (mLuaTable == null) return false;
        return true;
    }

    public void SendConnect()
    {
        SocketClient.SendConnect();
    }

    public void SendMessage(ByteBuffer buffer)
    {
        Debug.Log(buffer.ToBytes());
        SocketClient.SendMessage(buffer);
    }

    public static void AddEvent(int _event, ByteBuffer data)
    {
        sEvents.Enqueue(new KeyValuePair<int, ByteBuffer>(_event, data));
    }

    /// <summary>
    /// 交给Command，这里不想关心发给谁。
    /// </summary>
    private void Update()
    {
        if (sEvents.Count > 0)
        {
            while (sEvents.Count > 0)
            {
                KeyValuePair<int, ByteBuffer> _event = sEvents.Dequeue();
                GameFacade.SendMessageCommand(NotiConst.DISPATCH_MESSAGE, _event);
            }
        }
    }

    private void OnDestroy()
    {
        OnUnLoad();
        SocketClient.OnRemove();
        Debug.Log("~NetworkManager was destroy");

        if (mLuaTable != null)
        {
            mLuaTable.Dispose();
            mLuaTable = null;
        }
    }

    public void OnInit()
    {
        if (!CheckValid()) return;
        LuaFunction OnInitFunc = mLuaTable.GetLuaFunction("on_init") as LuaFunction;
        if (OnInitFunc != null)
        {
            OnInitFunc.BeginPCall();
            OnInitFunc.PCall();
            OnInitFunc.EndPCall();

            OnInitFunc.Dispose();
            OnInitFunc = null;
        }
    }

    public void OnUnLoad()
    {
        if (!CheckValid()) return;
        LuaFunction OnUnLoadFunc = mLuaTable.GetLuaFunction("on_unload") as LuaFunction;
        if (OnUnLoadFunc != null)
        {
            OnUnLoadFunc.BeginPCall();
            OnUnLoadFunc.PCall();
            OnUnLoadFunc.EndPCall();

            OnUnLoadFunc.Dispose();
            OnUnLoadFunc = null;
        }
    }
}
