using UnityEngine;
using System.Collections;

public class StartUpCommand : ControllerCommand
{
    public override void Execute(IMessage message)
    {
        GameObject gameMgr = GameObject.Find("GameManager");
        if (gameMgr != null)
        {
            AppView appView = gameMgr.AddComponent<AppView>();
        }

        AppFacade.Instance.AddManager<LuaManager>("LuaManager");
        AppFacade.Instance.AddManager<ResourceManager>("ResourceManager");

        Debug.Log("hello world.");
    }
}
