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

        LuaManager luaMgr = AppFacade.Instance.AddManager<LuaManager>("LuaManager");
        if (luaMgr != null)
        {
            luaMgr.InitStart();
        }
        AppFacade.Instance.AddManager<ResourceManager>("ResourceManager");

        Debug.Log("hello world.");
    }
}
