using System;
using LuaInterface;

public class UIRootWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIRoot), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("Instance", Instance);
		L.RegFunction("ShowNormalRoot", ShowNormalRoot);
		L.RegFunction("HideNormalRoot", HideNormalRoot);
		L.RegFunction("ShowFixedRoot", ShowFixedRoot);
		L.RegFunction("HideFixedRoot", HideFixedRoot);
		L.RegFunction("ShowPopupRoot", ShowPopupRoot);
		L.RegFunction("HidePopupRoot", HidePopupRoot);
		L.RegFunction("WorldToScreenPoint", WorldToScreenPoint);
		L.RegFunction("LocalToWorldUIPosition", LocalToWorldUIPosition);
		L.RegFunction("ScreenToUIPosition", ScreenToUIPosition);
		L.RegFunction("UIToScreenPosition", UIToScreenPosition);
		L.RegFunction("New", _CreateUIRoot);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("mUICamera", get_mUICamera, set_mUICamera);
		L.RegVar("mNormalRootRt", get_mNormalRootRt, set_mNormalRootRt);
		L.RegVar("mFixedRootRt", get_mFixedRootRt, set_mFixedRootRt);
		L.RegVar("mPopupRootRt", get_mPopupRootRt, set_mPopupRootRt);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUIRoot(IntPtr L)
	{
		return LuaDLL.tolua_error(L, "UIRoot class does not have a constructor function");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Instance(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			UIRoot o = UIRoot.Instance();
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ShowNormalRoot(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIRoot obj = (UIRoot)ToLua.CheckObject(L, 1, typeof(UIRoot));
			obj.ShowNormalRoot();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HideNormalRoot(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIRoot obj = (UIRoot)ToLua.CheckObject(L, 1, typeof(UIRoot));
			obj.HideNormalRoot();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ShowFixedRoot(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIRoot obj = (UIRoot)ToLua.CheckObject(L, 1, typeof(UIRoot));
			obj.ShowFixedRoot();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HideFixedRoot(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIRoot obj = (UIRoot)ToLua.CheckObject(L, 1, typeof(UIRoot));
			obj.HideFixedRoot();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ShowPopupRoot(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIRoot obj = (UIRoot)ToLua.CheckObject(L, 1, typeof(UIRoot));
			obj.ShowPopupRoot();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HidePopupRoot(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIRoot obj = (UIRoot)ToLua.CheckObject(L, 1, typeof(UIRoot));
			obj.HidePopupRoot();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WorldToScreenPoint(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIRoot obj = (UIRoot)ToLua.CheckObject(L, 1, typeof(UIRoot));
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o = obj.WorldToScreenPoint(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LocalToWorldUIPosition(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UIRoot obj = (UIRoot)ToLua.CheckObject(L, 1, typeof(UIRoot));
			UnityEngine.RectTransform arg0 = (UnityEngine.RectTransform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.RectTransform));
			UnityEngine.RectTransform arg1 = (UnityEngine.RectTransform)ToLua.CheckUnityObject(L, 3, typeof(UnityEngine.RectTransform));
			UnityEngine.Vector3 o = obj.LocalToWorldUIPosition(arg0, arg1);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ScreenToUIPosition(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIRoot obj = (UIRoot)ToLua.CheckObject(L, 1, typeof(UIRoot));
			UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
			UnityEngine.Vector2 o = obj.ScreenToUIPosition(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UIToScreenPosition(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIRoot obj = (UIRoot)ToLua.CheckObject(L, 1, typeof(UIRoot));
			UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
			UnityEngine.Vector2 o = obj.UIToScreenPosition(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		object obj = ToLua.ToObject(L, 1);

		if (obj != null)
		{
			LuaDLL.lua_pushstring(L, obj.ToString());
		}
		else
		{
			LuaDLL.lua_pushnil(L);
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mUICamera(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIRoot obj = (UIRoot)o;
			UnityEngine.Camera ret = obj.mUICamera;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index mUICamera on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mNormalRootRt(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIRoot obj = (UIRoot)o;
			UnityEngine.RectTransform ret = obj.mNormalRootRt;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index mNormalRootRt on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mFixedRootRt(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIRoot obj = (UIRoot)o;
			UnityEngine.RectTransform ret = obj.mFixedRootRt;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index mFixedRootRt on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mPopupRootRt(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIRoot obj = (UIRoot)o;
			UnityEngine.RectTransform ret = obj.mPopupRootRt;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index mPopupRootRt on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mUICamera(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIRoot obj = (UIRoot)o;
			UnityEngine.Camera arg0 = (UnityEngine.Camera)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Camera));
			obj.mUICamera = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index mUICamera on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mNormalRootRt(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIRoot obj = (UIRoot)o;
			UnityEngine.RectTransform arg0 = (UnityEngine.RectTransform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.RectTransform));
			obj.mNormalRootRt = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index mNormalRootRt on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mFixedRootRt(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIRoot obj = (UIRoot)o;
			UnityEngine.RectTransform arg0 = (UnityEngine.RectTransform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.RectTransform));
			obj.mFixedRootRt = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index mFixedRootRt on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mPopupRootRt(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIRoot obj = (UIRoot)o;
			UnityEngine.RectTransform arg0 = (UnityEngine.RectTransform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.RectTransform));
			obj.mPopupRootRt = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index mPopupRootRt on a nil value" : e.Message);
		}
	}
}

