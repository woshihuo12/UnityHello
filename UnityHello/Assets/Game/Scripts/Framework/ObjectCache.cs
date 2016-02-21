using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class ObjectCache<T>
    where T : UnityEngine.Object
{
    private List<T> mCacheObjects = new List<T>();
    private List<T> mUsingObjects = new List<T>();

    public abstract T CreateOne();
    public abstract void DestroyOne(T one);
    protected abstract void OnGetOne(T one);
    protected abstract void OnStoreOne(T one);

    public Action<T> OnGetOneEvent;
    public Action<T> OnStoreOneEvent;

    protected void Create(uint count)
    {
        if (count > 0)
        {
            for (int i = 0; i < count; ++i)
            {
                T one = CreateOne();
                mCacheObjects.Add(one);
            }
        }
    }

    public T GetOne()
    {
        if (mCacheObjects.Count <= 0) return null;
        T one = null;
        while (true)
        {
            if (mCacheObjects.Count <= 0) break;
            one = mCacheObjects[0];
            if (one == null)
            {
                mCacheObjects.RemoveAt(0);
                continue;
            }
            OnGetOne(one);
            if (OnGetOneEvent != null)
            {
                OnGetOneEvent(one);
            }
            mCacheObjects.Remove(one);
            mUsingObjects.Add(one);
            break;
        }
        return one;
    }

    public void StoreOne(T one)
    {
        if (one == null) return;
        if (mCacheObjects.Contains(one)) return;
        OnStoreOne(one);
        if (OnStoreOneEvent != null) OnStoreOneEvent(one);
        if (mUsingObjects.Contains(one)) mUsingObjects.Remove(one);
        mCacheObjects.Add(one);
    }

    public void StoreAll()
    {
        for (int i = 0; i < mUsingObjects.Count; ++i)
        {
            StoreOne(mUsingObjects[i]);
            i--;
        }
    }

    public void Destroy()
    {
        for (int i = 0; i < mUsingObjects.Count; ++i)
        {
            if (mUsingObjects[i] == null) continue;
            DestroyOne(mUsingObjects[i]);
        }

        mUsingObjects.Clear();

        for (int i = 0; i < mCacheObjects.Count; ++i)
        {
            if (mCacheObjects[i] == null) continue;
            DestroyOne(mCacheObjects[i]);
        }
        mCacheObjects.Clear();
    }
}

public class GameObjectCache : ObjectCache<GameObject>
{
    protected GameObject mPrefab;
    protected Transform mParent;

    public static GameObjectCache CreateCache(uint count, GameObject objPrefab, Transform objParent)
    {
        GameObjectCache cache = new GameObjectCache();
        cache.mPrefab = objPrefab;
        cache.mParent = objParent;
        cache.Create(count);
        return cache;
    }

    public override GameObject CreateOne()
    {
        GameObject one = GameObject.Instantiate(mPrefab);
        one.transform.SetParent(mParent);
        one.transform.localPosition = mPrefab.transform.localPosition;
        one.transform.localEulerAngles = mPrefab.transform.localEulerAngles;
        one.transform.localScale = mPrefab.transform.localScale;
        one.gameObject.SetActive(false);
        return one;
    }

    public override void DestroyOne(GameObject one)
    {
        GameObject.Destroy(one);
    }

    protected override void OnGetOne(GameObject one)
    {
        one.gameObject.SetActive(true);
    }

    protected override void OnStoreOne(GameObject one)
    {
        one.transform.SetParent(mParent);
        one.gameObject.SetActive(false);
    }
}
