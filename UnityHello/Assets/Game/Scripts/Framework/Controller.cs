using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Controller : IController
{
    protected IDictionary<string, Type> mCommandMap;
    protected IDictionary<IView, List<string>> mViewCmdMap;

    protected static IController mInstance;
    protected readonly object mSyncRoot = new object();
    protected static readonly object mStaticSyncRoot = new object();

    protected Controller()
    {
        InitController();
    }

    public static IController Instance
    {
        get
        {
            if (mInstance == null)
            {
                lock (mStaticSyncRoot)
                {
                    if (mInstance == null)
                    {
                        mInstance = new Controller();
                    }
                }
            }
            return mInstance;
        }
    }

    protected virtual void InitController()
    {
        mCommandMap = new Dictionary<string, Type>();
        mViewCmdMap = new Dictionary<IView, List<string>>();
    }

    public virtual void ExecuteCommand(IMessage note)
    {
        Type commandType = null;
        List<IView> views = null;
        lock (mSyncRoot)
        {
            if (mCommandMap.ContainsKey(note.Name))
            {
                commandType = mCommandMap[note.Name];
            }
            else
            {
                views = new List<IView>();
                foreach (var de in mViewCmdMap)
                {
                    if (de.Value.Contains(note.Name))
                    {
                        views.Add(de.Key);
                    }
                }
            }
        }
        if (commandType != null)
        {
            object commandInstance = Activator.CreateInstance(commandType);
            if (commandInstance is ICommand)
            {
                ((ICommand)commandInstance).Execute(note);
            }
        }
        if (views != null && views.Count > 0)
        {
            for (int i = 0; i < views.Count; ++i)
            {
                views[i].OnMessage(note);
            }
            views = null;
        }
    }

    public virtual void RegisterCommand(string commandName, Type commandType)
    {
        lock (mSyncRoot)
        {
            mCommandMap[commandName] = commandType;
        }
    }

    public virtual void RegisterViewCommand(IView view, string[] commandNames)
    {
        lock (mSyncRoot)
        {
            if (mViewCmdMap.ContainsKey(view))
            {
                List<string> list = null;
                if (mViewCmdMap.TryGetValue(view, out list))
                {
                    for (int i = 0; i < commandNames.Length; i++)
                    {
                        if (list.Contains(commandNames[i])) continue;
                        list.Add(commandNames[i]);
                    }
                }
            }
            else
            {
                mViewCmdMap.Add(view, new List<string>(commandNames));
            }
        }
    }

    public virtual bool HasCommand(string commandName)
    {
        lock (mSyncRoot)
        {
            return mCommandMap.ContainsKey(commandName);
        }
    }

    public virtual void RemoveCommand(string commandName)
    {
        lock (mSyncRoot)
        {
            if (mCommandMap.ContainsKey(commandName))
            {
                mCommandMap.Remove(commandName);
            }
        }
    }

    public virtual void RemoveViewCommand(IView view, string[] commandNames)
    {
        lock (mSyncRoot)
        {
            if (mViewCmdMap.ContainsKey(view))
            {
                List<string> list = null;
                if (mViewCmdMap.TryGetValue(view, out list))
                {
                    for (int i = 0; i < commandNames.Length; i++)
                    {
                        if (!list.Contains(commandNames[i])) continue;
                        list.Remove(commandNames[i]);
                    }
                }
            }
        }
    }
}
