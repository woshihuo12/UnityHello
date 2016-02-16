using UnityEngine;
using System.Collections;

public class AppFacade : Facade
{
    private static AppFacade _instance;

    public AppFacade()
        : base()
    {
    }

    public static AppFacade Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AppFacade();
            }
            return _instance;
        }
    }

    protected override void InitFramework()
    {
        base.InitFramework();
        RegisterCommand(NotiConst.START_UP, typeof(StartUpCommand));
    }

    public void StartUp()
    {
        SendMessageCommand(NotiConst.START_UP);
        RemoveMultiCommand(NotiConst.START_UP);
    }
}
