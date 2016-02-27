using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

public class LuaBehaviour : View
{
    private Dictionary<string, LuaFunction> mButtonCallbacks = new Dictionary<string, LuaFunction>();

    public bool UsingUpdate { get; set; }
    public bool UsingFixedUpdate { get; set; }
    public bool UsingLateUpdate { get; set; }

    protected bool mIsLuaReady = false;

    protected void Awake()
    {
        Tools.CallMethod(name, "Awake", gameObject);
    }

    protected void Start()
    {
        Tools.CallMethod(name, "Start");
    }

    protected void Update()
    {
        if (UsingUpdate)
        {
            Tools.CallMethod(name, "Update");
        }
    }

    protected void FixedUpdate()
    {
        if (UsingFixedUpdate)
        {
            Tools.CallMethod(name, "FixedUpdate");
        }
    }

    protected void LateUpdate()
    {
        if (UsingLateUpdate)
        {
            Tools.CallMethod(name, "LateUpdate");
        }
    }

    protected void OnClick()
    {
        Tools.CallMethod(name, "OnClick");
    }

    protected void OnClickEvent(GameObject go)
    {
        Tools.CallMethod(name, "OnClick", go);
    }

    public void AddClick(GameObject go, LuaFunction luafunc)
    {
        if (go == null || luafunc == null) return;
        mButtonCallbacks.Add(go.name, luafunc);
        go.GetComponent<Button>().onClick.AddListener(
            delegate()
            {
                luafunc.Call(go);
            }
        );
    }

    public void RemoveClick(GameObject go)
    {
        if (go == null) return;
        LuaFunction luafunc = null;
        if (mButtonCallbacks.TryGetValue(go.name, out luafunc))
        {
            luafunc.Dispose();
            luafunc = null;
            mButtonCallbacks.Remove(go.name);
        }
    }

    public void ClearClick()
    {
        foreach (var de in mButtonCallbacks)
        {
            if (de.Value != null)
            {
                de.Value.Dispose();
            }
        }
        mButtonCallbacks.Clear();
    }

    protected void OnDestroy()
    {
        ClearClick();
        Tools.CallMethod(name, "OnDestroy");
    }
}
