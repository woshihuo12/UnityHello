using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerCommand : ICommand
{
    public virtual void Execute(IMessage message)
    {
    }
}

public class Facade
{
    protected IController mController;
    private static GameObject mGameManager;
    private static Dictionary<string, object> mManagers = new Dictionary<string, object>();

    GameObject AppGameManager
    {
        get
        {
            if (mGameManager == null)
            {
                mGameManager = GameObject.Find("GameManager");
            }
            return mGameManager;
        }
    }

    public Facade()
    {
        InitFramework();
    }

    protected virtual void InitFramework()
    {
        if (mController != null) return;
        //mController = 
    }
}
