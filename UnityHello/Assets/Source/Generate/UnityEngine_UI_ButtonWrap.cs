using System;
using LuaInterface;

public class UnityEngine_UI_ButtonWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.UI.Button), typeof(UnityEngine.UI.Selectable));
		L.RegFunction("OnPointerClick", OnPointerClick);
		L.RegFunction("OnSubmit", OnSubmit);
		L.RegFunction("New", _CreateUnityEngine_UI_Button);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("onClick", get_onClick, set_onClick);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_UI_Button(IntPtr L)
	{
		return LuaDLL.luaL_error(L, "UnityEngine.UI.Button class does not have a constructor function");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerClick(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Button obj = (UnityEngine.UI.Button)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Button));
		UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));

		try
		{
			obj.OnPointerClick(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnSubmit(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Button obj = (UnityEngine.UI.Button)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Button));
		UnityEngine.EventSystems.BaseEventData arg0 = (UnityEngine.EventSystems.BaseEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.BaseEventData));

		try
		{
			obj.OnSubmit(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
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
	static int get_onClick(IntPtr L)
	{
		UnityEngine.UI.Button obj = (UnityEngine.UI.Button)ToLua.ToObject(L, 1);
		UnityEngine.UI.Button.ButtonClickedEvent ret = null;

		try
		{
			ret = obj.onClick;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index onClick on a nil value" : e.Message);
		}

		ToLua.PushObject(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onClick(IntPtr L)
	{
		UnityEngine.UI.Button obj = (UnityEngine.UI.Button)ToLua.ToObject(L, 1);
		UnityEngine.UI.Button.ButtonClickedEvent arg0 = (UnityEngine.UI.Button.ButtonClickedEvent)ToLua.CheckObject(L, 2, typeof(UnityEngine.UI.Button.ButtonClickedEvent));

		try
		{
			obj.onClick = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index onClick on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.UI.Button>(L, new LuaOut<UnityEngine.UI.Button>());
		return 1;
	}
}

