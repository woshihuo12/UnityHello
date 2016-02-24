using System;
using LuaInterface;

public class UILayerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UILayer), typeof(LayerBase));
		L.RegFunction("Instance", Instance);
		L.RegFunction("Awake", Awake);
		L.RegFunction("ScreenToUIPosition", ScreenToUIPosition);
		L.RegFunction("UIToScreenPosition", UIToScreenPosition);
		L.RegFunction("New", _CreateUILayer);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("LayerName", get_LayerName, null);
		L.RegVar("LayerParentRect", get_LayerParentRect, null);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUILayer(IntPtr L)
	{
		return LuaDLL.luaL_error(L, "UILayer class does not have a constructor function");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Instance(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 0);
		UILayer o = null;

		try
		{
			o = UILayer.Instance();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Awake(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UILayer obj = (UILayer)ToLua.CheckObject(L, 1, typeof(UILayer));

		try
		{
			obj.Awake();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ScreenToUIPosition(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UILayer obj = (UILayer)ToLua.CheckObject(L, 1, typeof(UILayer));
		UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
		UnityEngine.Vector2 o;

		try
		{
			o = obj.ScreenToUIPosition(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UIToScreenPosition(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UILayer obj = (UILayer)ToLua.CheckObject(L, 1, typeof(UILayer));
		UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
		UnityEngine.Vector2 o;

		try
		{
			o = obj.UIToScreenPosition(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
		UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
		bool o;

		try
		{
			o = arg0 == arg1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
		return 1;
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
	static int get_LayerName(IntPtr L)
	{
		UILayer obj = (UILayer)ToLua.ToObject(L, 1);
		string ret = null;

		try
		{
			ret = obj.LayerName;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index LayerName on a nil value" : e.Message);
		}

		LuaDLL.lua_pushstring(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LayerParentRect(IntPtr L)
	{
		UILayer obj = (UILayer)ToLua.ToObject(L, 1);
		UnityEngine.RectTransform ret = null;

		try
		{
			ret = obj.LayerParentRect;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index LayerParentRect on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UILayer>(L, new LuaOut<UILayer>());
		return 1;
	}
}

