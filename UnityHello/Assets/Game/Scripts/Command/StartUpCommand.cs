using UnityEngine;
using System.Collections;

public class StartUpCommand : ControllerCommand
{
    IEnumerator AddLua()
    {
        yield return new WaitForSeconds(5f);

        LuaManager luaMgr = AppFacade.Instance.AddManager<LuaManager>("LuaManager");
        if (luaMgr != null)
        {
            luaMgr.InitStart();
        }

        Debug.Log("hello world.");
    }

    public override void Execute(IMessage message)
    {
        GameObject gameMgr = GameObject.Find("GameManager");
        if (gameMgr != null)
        {
            AppView appView = gameMgr.AddComponent<AppView>();
        }

        ResourceManager resMgr = AppFacade.Instance.AddManager<ResourceManager>("ResourceManager");
        resMgr.Initialize("StandaloneWindows", () => { Debug.Log("ResourceManager loaded."); });


        Globals.Instance.StartCoroutine(AddLua());
        
    }
}
