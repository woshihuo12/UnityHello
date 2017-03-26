using UnityEngine;
using System.Collections;
using System;
using KEngine;
public class StartUpCommand : ControllerCommand
{
    private IEnumerator InitFunc(Action OnLoadStep, Action loadOver)
    {
        GameObject gameMgr = GameObject.Find("GameManager");
        if (gameMgr != null)
        {
            gameMgr.AddComponent<AppView>();
        }

        //-----------------关联命令-----------------------
        AppFacade.Instance.RegisterCommand(NotiConst.DISPATCH_MESSAGE, typeof(SocketCommand));

        AppFacade.Instance.AddManager<LuaManager>();
        KResourceManager resMgr = AppFacade.Instance.AddManager<KResourceManager>();

        AppFacade.Instance.AddManager<NetworkManager>();
        AppFacade.Instance.AddManager<ThreadManager>();
        AppFacade.Instance.AddManager<SimpleTimerManager>();

        bool canNext = false;

        //resMgr.LoadAssetPacker("res_asset_packer.unity", "res_asset_packer", delegate(UnityEngine.Object[] objs)
        //{
        //    if (objs.Length == 0) return;
        //    GameResFactory.Instance().mAssetPacker = objs[0] as AssetPacker;
        canNext = true;
        //});

        while (canNext == false) yield return null;

        if (OnLoadStep != null)
        {
            OnLoadStep();
        }

        AppFacade.Instance.AddManager<GameManager>();

        if (loadOver != null)
        {
            loadOver();
        }
    }

    public override void Execute(IMessage message)
    {
        Globals.Instance.StartCoroutine(InitFunc(
            () => { Debug.Log("OnLoadStep"); },
            () =>
            {
                Debug.Log(Application.dataPath);
                Debug.Log(Application.streamingAssetsPath);
            }));
    }
}
