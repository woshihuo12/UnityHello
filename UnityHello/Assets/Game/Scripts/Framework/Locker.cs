using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Locker<T>
{
    private List<T> mLockKeys = new List<T>();

    public void Lock(T key)
    {
        if (!mLockKeys.Contains(key))
        {
            mLockKeys.Add(key);
        }
    }

    public void UnLock(T key)
    {
        if (mLockKeys.Contains(key))
        {
            mLockKeys.Remove(key);
        }
    }

    public bool IsLock(T key)
    {
        return mLockKeys.Contains(key);
    }

    public bool HasLock()
    {
        return mLockKeys.Count > 0;
    }
}

public class SimpleLocker
{
    private bool mLocked = false;

    public void Lock()
    {
        mLocked = true;
    }

    public void UnLock()
    {
        mLocked = false;
    }

    public bool IsLock()
    {
        return mLocked;
    }
}
