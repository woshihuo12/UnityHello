using UnityEngine;
using System.Collections;
using System.Text;

public class Message : IMessage
{
    public Message(string name)
        : this(name, null, null)
    {
    }

    public Message(string name, object body)
        : this(name, body, null)
    {
    }

    public Message(string name, object body, string type)
    {
        mName = name;
        mBody = body;
        mType = type;
    }

    public virtual string Name
    {
        get { return mName; }
    }

    public virtual object Body
    {
        get
        {
            return mBody;
        }
        set
        {
            mBody = value;
        }
    }

    public virtual string Type
    {
        get
        {
            return mType;
        }
        set
        {
            mType = value;
        }
    }

    public override string ToString()
    {
        mSb.Remove(0, mSb.Length).Append("Notification Name: ")
            .Append(Name)
            .Append("\nBody:")
            .Append((Body == null) ? "null" : Body.ToString())
            .Append("\nType:")
            .Append((Type == null) ? "null" : Type);
        return mSb.ToString();
    }

    private StringBuilder mSb = new StringBuilder(42);

    private string mName;
    private string mType;
    private object mBody;
}
