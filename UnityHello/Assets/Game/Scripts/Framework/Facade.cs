using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

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

    public GameObject AppGameManager
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
        mController = Controller.Instance;
    }

    public virtual void RegisterCommand(string commandName, Type commandType)
    {
        mController.RegisterCommand(commandName, commandType);
    }

    public virtual void RemoveCommand(string commandName)
    {
        mController.RemoveCommand(commandName);
    }

    public virtual bool HasCommand(string commandName)
    {
        return mController.HasCommand(commandName);
    }

    public void RegisterMultiCommand(Type commandType, params string[] commandNames)
    {
        for (int i = 0, iMax = commandNames.Length; i < iMax; i++)
        {
            RegisterCommand(commandNames[i], commandType);
        }
    }

    public void RemoveMultiCommand(params string[] commandName)
    {
        for (int i = 0, iMax = commandName.Length; i < iMax; i++)
        {
            RemoveCommand(commandName[i]);
        }
    }

    public void SendMessageCommand(string message, object body = null)
    {
        mController.ExecuteCommand(new Message(message, body));
    }

    public void AddManager(string typeName, object obj)
    {
        if (!mManagers.ContainsKey(typeName))
        {
            mManagers.Add(typeName, obj);
        }
    }

    public T AddManager<T>(string typeName) where T : Component
    {
        object result = null;
        mManagers.TryGetValue(typeName, out result);
        if (result != null)
        {
            return (T)result;
        }
        Component c = AppGameManager.AddComponent<T>();
        mManagers.Add(typeName, c);
        return default(T);
    }

    public T GetManager<T>(string typeName) where T : class
    {
        if (!mManagers.ContainsKey(typeName))
        {
            return default(T);
        }
        object manager = null;
        mManagers.TryGetValue(typeName, out manager);
        return (T)manager;
    }

    public void RemoveManager(string typeName)
    {
        if (!mManagers.ContainsKey(typeName))
        {
            return;
        }
        object manager = null;
        mManagers.TryGetValue(typeName, out manager);
        Type type = manager.GetType();
        if (type.IsSubclassOf(typeof(MonoBehaviour)))
        {
            GameObject.Destroy((Component)manager);
        }
        mManagers.Remove(typeName);
    }
}
