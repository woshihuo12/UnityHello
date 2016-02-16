using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Base : MonoBehaviour
{
    private AppFacade mFacade;

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

    protected AppFacade Facade
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
}
