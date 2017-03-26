using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using KEngine;

public class Base : MonoBehaviour
{
    private AppFacade mFacade;
    private KResourceManager mResMgr;
    //private ResourceManagerOld mResMgr;
    private LuaManager mLuaMgr;
    private SimpleTimerManager mTimerManager;
    private ThreadManager mThreadManager;
    private GameManager mGameManager;
    private NetworkManager mNetworkManager;

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

    protected KResourceManager ResManager
    {
        get
        {
            if (mResMgr == null)
            {
                mResMgr = GameFacade.GetManager<KResourceManager>();
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

    protected NetworkManager NetManager
    {
        get
        {
            if (mNetworkManager == null)
            {
                mNetworkManager = GameFacade.GetManager<NetworkManager>();
            }
            return mNetworkManager;
        }
    }
}
