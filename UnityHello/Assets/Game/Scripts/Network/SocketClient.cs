using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System;

public enum DisType
{
    Exception,
    Disconnect,
}

public class SocketClient
{
    private TcpClient mTcpClient = null;
    private NetworkStream mOutStream = null;
    private MemoryStream mMemoryStream = null;
    private BinaryReader mBinaryReader = null;

    private const int MAX_READ = 8192;
    private byte[] mByteBuffer = new byte[MAX_READ];

    public static bool mLoggedIn = false;

    public SocketClient()
    {
    }

    public void OnRegister()
    {
        mMemoryStream = new MemoryStream();
        mBinaryReader = new BinaryReader(mMemoryStream);
    }

    public void OnRemove()
    {
        Close();
        mBinaryReader.Close();
        mMemoryStream.Close();

        mBinaryReader = null;
        mMemoryStream = null;
    }

    private void ConnectServer(string host, int port)
    {
        mTcpClient = new TcpClient();
        mTcpClient.SendTimeout = 1000;
        mTcpClient.ReceiveTimeout = 1000;
        mTcpClient.NoDelay = true;
        try
        {
            mTcpClient.BeginConnect(host, port, new AsyncCallback(OnConnect), null);
        }
        catch (Exception e)
        {
            Close();
            Debug.LogError(e.Message);
        }
    }

    private void OnConnect(IAsyncResult asr)
    {
        mOutStream = mTcpClient.GetStream();
        mOutStream.BeginRead(mByteBuffer, 0, MAX_READ, new AsyncCallback(OnRead), null);
        NetworkManager.AddEvent(Protocal.Connect, new ByteBuffer());
    }

    private void WriteMessage(byte[] message)
    {
        MemoryStream ms = null;
        using (ms = new MemoryStream())
        {
            ms.Position = 0;
            BinaryWriter writer = new BinaryWriter(ms);
            ushort msglen = (ushort)message.Length;
            writer.Write(msglen);
            writer.Write(message);
            writer.Flush();
            if (mTcpClient != null && mTcpClient.Connected)
            {
                byte[] payload = ms.ToArray();
                mOutStream.BeginWrite(payload, 0, payload.Length, new AsyncCallback(OnWrite), null);
            }
            else
            {
                Debug.LogWarning("mTcpClient.connected----->>false");
            }
        }
    }

    private void OnRead(IAsyncResult asr)
    {
        int bytesRead = 0;
        try
        {
            //读取字节流到缓冲区
            lock (mTcpClient.GetStream())
            {
                bytesRead = mTcpClient.GetStream().EndRead(asr);
            }
            //包尺寸有问题，断线处理
            if (bytesRead < 1)
            {
                OnDisconnected(DisType.Disconnect, "bytesRead < 1");
                return;
            }
            //分析数据包内容，抛给逻辑层
            OnReceive(mByteBuffer, bytesRead);
            //分析完，再次监听服务器发过来的新消息
            lock (mTcpClient.GetStream())
            {
                //清空数组
                Array.Clear(mByteBuffer, 0, mByteBuffer.Length);
                mTcpClient.GetStream().BeginRead(mByteBuffer, 0, MAX_READ, new AsyncCallback(OnRead), null);
            }
        }
        catch (Exception e)
        {
            OnDisconnected(DisType.Exception, e.Message);
        }
    }

    private void OnDisconnected(DisType dis, string msg)
    {
        //关掉客户端链接
        Close();
        int protocal = dis == DisType.Exception ? Protocal.Exception : Protocal.Disconnect;
        ByteBuffer buffer = new ByteBuffer();
        buffer.WriteShort((ushort)protocal);
        NetworkManager.AddEvent(protocal, buffer);
        Debug.LogError("Connection was closed by the server:>" + msg + " Distype:>" + dis);
    }

    private void PrintBytes()
    {
        string returnStr = string.Empty;
        for (int i = 0; i < mByteBuffer.Length; i++)
        {
            returnStr += mByteBuffer[i].ToString("X2");
        }
        Debug.LogError(returnStr);
    }

    /// <summary>
    /// 向链接写入数据流
    /// </summary>
    private void OnWrite(IAsyncResult r)
    {
        try
        {
            mOutStream.EndWrite(r);
        }
        catch (Exception ex)
        {
            Debug.LogError("OnWrite--->>>" + ex.Message);
        }
    }

    /// <summary>
    /// 接收到消息
    /// </summary>
    private void OnReceive(byte[] bytes, int length)
    {
        mMemoryStream.Seek(0, SeekOrigin.End);
        mMemoryStream.Write(bytes, 0, length);
        //Reset to beginning
        mMemoryStream.Seek(0, SeekOrigin.Begin);
        while (RemainingBytes() > 2)
        {
            ushort messageLen = mBinaryReader.ReadUInt16();
            if (RemainingBytes() >= messageLen)
            {
                MemoryStream ms = new MemoryStream();
                BinaryWriter writer = new BinaryWriter(ms);
                writer.Write(mBinaryReader.ReadBytes(messageLen));
                ms.Seek(0, SeekOrigin.Begin);
                OnReceivedMessage(ms);
            }
            else
            {
                //Back up the position two bytes
                mMemoryStream.Position = mMemoryStream.Position - 2;
                break;
            }
        }
        //Create a new stream with any leftover bytes
        byte[] leftover = mBinaryReader.ReadBytes((int)RemainingBytes());
        mMemoryStream.SetLength(0);     //Clear
        mMemoryStream.Write(leftover, 0, leftover.Length);
    }

    /// <summary>
    /// 剩余的字节
    /// </summary>
    private long RemainingBytes()
    {
        return mMemoryStream.Length - mMemoryStream.Position;
    }

    /// <summary>
    /// 接收到消息
    /// </summary>
    private void OnReceivedMessage(MemoryStream ms)
    {
        BinaryReader r = new BinaryReader(ms);
        byte[] message = r.ReadBytes((int)(ms.Length - ms.Position));
        //int msglen = message.Length;
        ByteBuffer buffer = new ByteBuffer(message);
        int mainId = buffer.ReadShort();
        NetworkManager.AddEvent(mainId, buffer);
    }

    /// <summary>
    /// 会话发送
    /// </summary>
    private void SessionSend(byte[] bytes)
    {
        WriteMessage(bytes);
    }

    private void Close()
    {
        if (mTcpClient != null)
        {
            if (mTcpClient.Connected)
            {
                mTcpClient.Close();
            }
            mTcpClient = null;
        }
        mLoggedIn = false;
    }

    /// <summary>
    /// 发送连接请求
    /// </summary>
    public void SendConnect()
    {
        ConnectServer(GameSetting.SocketAddress, GameSetting.SocketPort);
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    public void SendMessage(ByteBuffer buffer)
    {
        SessionSend(buffer.ToBytes());
        buffer.Close();
    }
}
