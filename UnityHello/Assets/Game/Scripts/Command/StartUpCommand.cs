using UnityEngine;
using System.Collections;

public class StartUpCommand : ControllerCommand
{
    public override void Execute(IMessage message)
    {
        GameObject gameMgr = GameObject.Find("Globals");
        if (gameMgr != null)
        {
            AppView appView = gameMgr.AddComponent<AppView>();
        }


    }
}
