using UnityEngine;
using System.Collections;

public class StartUpCommand : ControllerCommand
{
    public override void Execute(IMessage message)
    {
        GameObject gameMgr = GameObject.Find("GameManager");
        if (gameMgr != null)
        {
            gameMgr.AddComponent<AppView>();
        }

        AppFacade.Instance.AddManager<LuaManager>();
        AppFacade.Instance.AddManager<ResourceManager>();
        AppFacade.Instance.AddManager<ThreadManager>();
        AppFacade.Instance.AddManager<SimpleTimerManager>();
        AppFacade.Instance.AddManager<GameManager>();


        Debug.Log(Application.dataPath);
        Debug.Log(Application.streamingAssetsPath);
    }
}
