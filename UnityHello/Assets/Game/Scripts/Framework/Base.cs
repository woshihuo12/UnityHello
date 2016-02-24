using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Base : MonoBehaviour
{
    private AppFacade mFacade;
    private ResourceManager mResMgr;
    private LuaManager mLuaMgr;

    protected void RegisterMessage(IView view, List<string> messages)
    {
        if (messages == null || messages.Count == 0) return;
        Controller.Instance.RegisterViewCommand(view, messages.ToArray());
    }

    protected void RemoveMessage(IView view, List<string> messages)
    {
        if (messages == null || messages.Count == 0) return;
        Controller.Instance.RemoveViewCommand(view, messages.ToArray());
    }

    protected AppFacade Facade
    {
        get
        {
            if (mFacade == null)
            {
                mFacade = AppFacade.Instance;
            }
            return mFacade;
        }
    }

    protected ResourceManager ResManager
    {
        get
        {
            if (mResMgr == null)
            {
                mResMgr = mFacade.GetManager<ResourceManager>("ResourceManager");
            }
            return mResMgr;
        }
    }

    protected LuaManager LuaMgr
    {
        get
        {
            if (mLuaMgr == null)
            {
                mLuaMgr = mFacade.GetManager<LuaManager>("LuaManager");
            }
            return mLuaMgr;
        }
    }
}
