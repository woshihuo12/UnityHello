using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Base : MonoBehaviour
{
    private AppFacade mFacade;
    private ResourceManager mResMgr;
    private LuaManager mLuaMgr;
    private SimpleTimerManager mTimerManager;
    private ThreadManager mThreadManager;
    private GameManager mGameManager;

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

    protected AppFacade GameFacade
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
                mResMgr = GameFacade.GetManager<ResourceManager>();
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
                mLuaMgr = GameFacade.GetManager<LuaManager>();
            }
            return mLuaMgr;
        }
    }

    protected SimpleTimerManager TimeManager
    {
        get
        {
            if (mTimerManager == null)
            {
                mTimerManager = GameFacade.GetManager<SimpleTimerManager>();
            }
            return mTimerManager;
        }
    }

    protected ThreadManager ThreadMgr
    {
        get
        {
            if (mThreadManager == null)
            {
                mThreadManager = GameFacade.GetManager<ThreadManager>();
            }
            return mThreadManager;
        }
    }

    protected GameManager GameMgr
    {
        get
        {
            if (mGameManager == null)
            {
                mGameManager = GameFacade.GetManager<GameManager>();
            }
            return mGameManager;
        }
    }
}
