using UnityEngine;
using System.Collections;

public class StartUpCommand : ControllerCommand
{
    //IEnumerator AddLua()
    //{
    //    yield return new WaitForSeconds(5f);

    //    LuaManager luaMgr = AppFacade.Instance.AddManager<LuaManager>("LuaManager");
    //    if (luaMgr != null)
    //    {
    //        luaMgr.InitStart();
    //    }

    //    Debug.Log("hello world.");
    //}

    public override void Execute(IMessage message)
    {
        GameObject gameMgr = GameObject.Find("GameManager");
        if (gameMgr != null)
        {
            gameMgr.AddComponent<AppView>();
        }


        //resMgr.Initialize("StandaloneWindows", () => { Debug.Log("ResourceManager loaded."); });
        AppFacade.Instance.AddManager<LuaManager>();
        AppFacade.Instance.AddManager<ResourceManager>();
        AppFacade.Instance.AddManager<ThreadManager>();
        AppFacade.Instance.AddManager<SimpleTimerManager>();

        //Globals.Instance.StartCoroutine(AddLua());

    }
}
