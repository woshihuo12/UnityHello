using UnityEngine;
using System.Collections;

public class BaseObject
{
    public bool IsInit { get; protected set; }

    public bool IsDestroy { get; protected set; }

    public BaseObject()
    {
        IsInit = false;
    }

    protected virtual void Init()
    {

    }

    public void Create()
    {
        if (!IsInit)
        {
            IsInit = true;
            Init();
        }
        IsDestroy = false;
        OnCreate();
    }

    protected virtual void OnCreate()
    {

    }

    public virtual void Destroy()
    {
        IsDestroy = true;
    }
}
