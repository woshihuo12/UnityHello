using System;
using LuaInterface;

public class UnityEngine_UI_MaskableGraphicWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.UI.MaskableGraphic), typeof(UnityEngine.UI.Graphic));
		L.RegFunction("GetModifiedMaterial", GetModifiedMaterial);
		L.RegFunction("Cull", Cull);
		L.RegFunction("SetClipRect", SetClipRect);
		L.RegFunction("RecalculateClipping", RecalculateClipping);
		L.RegFunction("RecalculateMasking", RecalculateMasking);
		L.RegFunction("New", _CreateUnityEngine_UI_MaskableGraphic);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("onCullStateChanged", get_onCullStateChanged, set_onCullStateChanged);
		L.RegVar("maskable", get_maskable, set_maskable);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_UI_MaskableGraphic(IntPtr L)
	{
		return LuaDLL.luaL_error(L, "UnityEngine.UI.MaskableGraphic class does not have a constructor function");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetModifiedMaterial(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.MaskableGraphic));
		UnityEngine.Material arg0 = (UnityEngine.Material)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Material));
		UnityEngine.Material o = null;

		try
		{
			o = obj.GetModifiedMaterial(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Cull(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.MaskableGraphic));
		UnityEngine.Rect arg0 = (UnityEngine.Rect)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rect));
		bool arg1 = LuaDLL.luaL_checkboolean(L, 3);

		try
		{
			obj.Cull(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetClipRect(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.MaskableGraphic));
		UnityEngine.Rect arg0 = (UnityEngine.Rect)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rect));
		bool arg1 = LuaDLL.luaL_checkboolean(L, 3);

		try
		{
			obj.SetClipRect(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RecalculateClipping(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.MaskableGraphic));

		try
		{
			obj.RecalculateClipping();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RecalculateMasking(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.MaskableGraphic));

		try
		{
			obj.RecalculateMasking();
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
	static int get_onCullStateChanged(IntPtr L)
	{
		UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)ToLua.ToObject(L, 1);
		UnityEngine.UI.MaskableGraphic.CullStateChangedEvent ret = null;

		try
		{
			ret = obj.onCullStateChanged;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index onCullStateChanged on a nil value" : e.Message);
		}

		ToLua.PushObject(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maskable(IntPtr L)
	{
		UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.maskable;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index maskable on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onCullStateChanged(IntPtr L)
	{
		UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)ToLua.ToObject(L, 1);
		UnityEngine.UI.MaskableGraphic.CullStateChangedEvent arg0 = (UnityEngine.UI.MaskableGraphic.CullStateChangedEvent)ToLua.CheckObject(L, 2, typeof(UnityEngine.UI.MaskableGraphic.CullStateChangedEvent));

		try
		{
			obj.onCullStateChanged = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index onCullStateChanged on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maskable(IntPtr L)
	{
		UnityEngine.UI.MaskableGraphic obj = (UnityEngine.UI.MaskableGraphic)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.maskable = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index maskable on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.UI.MaskableGraphic>(L, new LuaOut<UnityEngine.UI.MaskableGraphic>());
		return 1;
	}
}

