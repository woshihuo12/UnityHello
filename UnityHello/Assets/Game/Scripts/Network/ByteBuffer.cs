using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;
using LuaInterface;

public class ByteBuffer
{
    private MemoryStream mMemoryStream = null;
    private BinaryWriter mBinaryWriter = null;
    private BinaryReader mBinaryReader = null;

    public ByteBuffer()
    {
        mMemoryStream = new MemoryStream();
        mBinaryWriter = new BinaryWriter(mMemoryStream);
    }

    public ByteBuffer(byte[] data)
    {
        if (data != null)
        {
            mMemoryStream = new MemoryStream(data);
            mBinaryReader = new BinaryReader(mMemoryStream);
        }
        else
        {
            mMemoryStream = new MemoryStream();
            mBinaryWriter = new BinaryWriter(mMemoryStream);
        }
    }

    public void Close()
    {
        if (mBinaryWriter != null)
        {
            mBinaryWriter.Close();
        }

        if (mBinaryReader != null)
        {
            mBinaryReader.Close();
        }

        mMemoryStream.Close();
        mBinaryWriter = null;
        mBinaryReader = null;
        mMemoryStream = null;
    }

    public void WriteByte(byte v)
    {
        mBinaryWriter.Write(v);
    }

    public void WriteInt(int v)
    {
        mBinaryWriter.Write(v);
    }

    public void WriteShort(ushort v)
    {
        mBinaryWriter.Write(v);
    }

    public void WriteLong(long v)
    {
        mBinaryWriter.Write(v);
    }

    public void WriteFloat(float v)
    {
        byte[] temp = BitConverter.GetBytes(v);
        Array.Reverse(temp);
        mBinaryWriter.Write(BitConverter.ToSingle(temp, 0));
    }

    public void WriteDouble(double v)
    {
        byte[] temp = BitConverter.GetBytes(v);
        Array.Reverse(temp);
        mBinaryWriter.Write(BitConverter.ToDouble(temp, 0));
    }

    public void WriteString(string v)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(v);
        mBinaryWriter.Write((ushort)bytes.Length);
        mBinaryWriter.Write(bytes);
    }

    public void WriteBytes(byte[] v)
    {
        mBinaryWriter.Write((int)v.Length);
        mBinaryWriter.Write(v);
    }

    public void WriteBuffer(LuaByteBuffer strBuffer)
    {
        WriteBytes(strBuffer.buffer);
    }

    public byte ReadByte()
    {
        return mBinaryReader.ReadByte();
    }

    public int ReadInt()
    {
        return (int)mBinaryReader.ReadInt32();
    }

    public ushort ReadShort()
    {
        return (ushort)mBinaryReader.ReadInt16();
    }

    public long ReadLong()
    {
        return (long)mBinaryReader.ReadInt64();
    }

    public float ReadFloat()
    {
        byte[] temp = BitConverter.GetBytes(mBinaryReader.ReadSingle());
        Array.Reverse(temp);
        return BitConverter.ToSingle(temp, 0);
    }

    public double ReadDouble()
    {
        byte[] temp = BitConverter.GetBytes(mBinaryReader.ReadDouble());
        Array.Reverse(temp);
        return BitConverter.ToDouble(temp, 0);
    }

    public string ReadString()
    {
        ushort len = ReadShort();
        byte[] buffer = new byte[len];
        buffer = mBinaryReader.ReadBytes(len);
        return Encoding.UTF8.GetString(buffer);
    }

    public byte[] ReadBytes()
    {
        return mBinaryReader.ReadBytes(ReadInt());
    }

    public LuaByteBuffer ReadBuffer()
    {
        return new LuaByteBuffer(ReadBytes());
    }

    public byte[] ToBytes()
    {
        mBinaryWriter.Flush();
        return mMemoryStream.ToArray();
    }

    public void Flush()
    {
        mBinaryWriter.Flush();
    }
}
