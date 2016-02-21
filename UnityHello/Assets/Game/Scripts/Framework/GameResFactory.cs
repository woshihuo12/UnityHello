using UnityEngine;
using System.Collections.Generic;
using LuaInterface;
public class GameResFactory : View
{
    private static GameResFactory sInstance = null;
    public static GameResFactory Instance()
    {
        if (sInstance == null)
        {
            sInstance = new GameResFactory();
        }
        return sInstance;
    }

    private List<GameObject> mUIEffectsList = new List<GameObject>();
    private List<GameObject> mUIList = new List<GameObject>();
    //private Dictionary<string, GameObjectCache> mResCaches = new Dictionary<string, GameObjectCache>();

    public void GetUIPrefab(string name, Transform parent, LuaFunction luaCallBack)
    {
        ResManager.LoadPrefab(name, name, delegate(UnityEngine.Object[] objs)
        {
            if (objs.Length == 0) return;
            GameObject prefab = objs[0] as GameObject;
            if (prefab == null)
            {
                return;
            }
            GameObject go = Instantiate(prefab) as GameObject;
            go.name = name;
            go.layer = LayerMask.NameToLayer("Default");
            go.transform.SetParent(parent, false);
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            go.AddComponent<LuaBehaviour>();

            if (luaCallBack != null)
            {
                luaCallBack.BeginPCall();
                luaCallBack.Push(go);
                luaCallBack.PCall();
                luaCallBack.EndPCall();
            }
            Debug.LogWarning("CreatePanel::>> " + name + " " + prefab);
            mUIList.Add(go);
        });
    }

    public void DestroyUIPrefab(GameObject go)
    {
        DestroyObject(go);
        mUIList.Remove(go);
    }

    protected void GetEffectObj(string effname, System.Action<GameObject> callBack)
    {
        ResManager.LoadPrefab(effname, effname, delegate(UnityEngine.Object[] objs)
        {
            GameObject gameobj = null;

            if (objs.Length == 0) return;
            GameObject prefab = objs[0] as GameObject;
            if (prefab == null)
            {
                return;
            }
            GameObject go = Instantiate(prefab) as GameObject;
            if (callBack != null)
            {
                callBack(go);
            }
        });
    }

    //获取UI特效
    public void GetUIEffect(string effname, LuaFunction luaCallBack)
    {
        GetEffectObj(effname, (Obj) =>
        {
            if (Obj != null)
            {
                mUIList.Add(Obj);
            }
            if (luaCallBack != null)
            {
                luaCallBack.BeginPCall();
                luaCallBack.Push(Obj);
                luaCallBack.PCall();
                luaCallBack.EndPCall();
            }
        });
    }

    public void DestroyUIEffect(GameObject obj)
    {
        DestroyObject(obj);
        mUIEffectsList.Remove(obj);
    }

    public void DestroyAllUIEffect()
    {

        for (int i = 0; i < mUIEffectsList.Count; i++)
        {
            DestroyObject(mUIEffectsList[i]);
        }
        mUIEffectsList.Clear();
    }
}
