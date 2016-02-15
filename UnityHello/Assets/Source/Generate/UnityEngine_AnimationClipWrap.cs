using System;
using LuaInterface;

public class UnityEngine_AnimationClipWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.AnimationClip), typeof(UnityEngine.Object));
		L.RegFunction("SampleAnimation", SampleAnimation);
		L.RegFunction("SetCurve", SetCurve);
		L.RegFunction("EnsureQuaternionContinuity", EnsureQuaternionContinuity);
		L.RegFunction("ClearCurves", ClearCurves);
		L.RegFunction("AddEvent", AddEvent);
		L.RegFunction("New", _CreateUnityEngine_AnimationClip);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("length", get_length, null);
		L.RegVar("frameRate", get_frameRate, set_frameRate);
		L.RegVar("wrapMode", get_wrapMode, set_wrapMode);
		L.RegVar("localBounds", get_localBounds, set_localBounds);
		L.RegVar("legacy", get_legacy, set_legacy);
		L.RegVar("humanMotion", get_humanMotion, null);
		L.RegVar("events", get_events, set_events);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_AnimationClip(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.AnimationClip obj = new UnityEngine.AnimationClip();
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AnimationClip.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SampleAnimation(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.CheckObject(L, 1, typeof(UnityEngine.AnimationClip));
		UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.GameObject));
		float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);

		try
		{
			obj.SampleAnimation(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetCurve(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 5);
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.CheckObject(L, 1, typeof(UnityEngine.AnimationClip));
		string arg0 = ToLua.CheckString(L, 2);
		System.Type arg1 = (System.Type)ToLua.CheckObject(L, 3, typeof(System.Type));
		string arg2 = ToLua.CheckString(L, 4);
		UnityEngine.AnimationCurve arg3 = (UnityEngine.AnimationCurve)ToLua.CheckObject(L, 5, typeof(UnityEngine.AnimationCurve));

		try
		{
			obj.SetCurve(arg0, arg1, arg2, arg3);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EnsureQuaternionContinuity(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.CheckObject(L, 1, typeof(UnityEngine.AnimationClip));

		try
		{
			obj.EnsureQuaternionContinuity();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearCurves(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.CheckObject(L, 1, typeof(UnityEngine.AnimationClip));

		try
		{
			obj.ClearCurves();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddEvent(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.CheckObject(L, 1, typeof(UnityEngine.AnimationClip));
		UnityEngine.AnimationEvent arg0 = (UnityEngine.AnimationEvent)ToLua.CheckObject(L, 2, typeof(UnityEngine.AnimationEvent));

		try
		{
			obj.AddEvent(arg0);
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
	static int get_length(IntPtr L)
	{
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.length;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index length on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_frameRate(IntPtr L)
	{
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.frameRate;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index frameRate on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_wrapMode(IntPtr L)
	{
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.ToObject(L, 1);
		UnityEngine.WrapMode ret;

		try
		{
			ret = obj.wrapMode;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index wrapMode on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localBounds(IntPtr L)
	{
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.ToObject(L, 1);
		UnityEngine.Bounds ret;

		try
		{
			ret = obj.localBounds;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index localBounds on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_legacy(IntPtr L)
	{
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.legacy;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index legacy on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_humanMotion(IntPtr L)
	{
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.humanMotion;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index humanMotion on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_events(IntPtr L)
	{
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.ToObject(L, 1);
		UnityEngine.AnimationEvent[] ret = null;

		try
		{
			ret = obj.events;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index events on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_frameRate(IntPtr L)
	{
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.frameRate = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index frameRate on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_wrapMode(IntPtr L)
	{
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.ToObject(L, 1);
		UnityEngine.WrapMode arg0 = (UnityEngine.WrapMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.WrapMode));

		try
		{
			obj.wrapMode = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index wrapMode on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localBounds(IntPtr L)
	{
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.ToObject(L, 1);
		UnityEngine.Bounds arg0 = ToLua.ToBounds(L, 2);

		try
		{
			obj.localBounds = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index localBounds on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_legacy(IntPtr L)
	{
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.legacy = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index legacy on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_events(IntPtr L)
	{
		UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.ToObject(L, 1);
		UnityEngine.AnimationEvent[] arg0 = ToLua.CheckObjectArray<UnityEngine.AnimationEvent>(L, 2);

		try
		{
			obj.events = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index events on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.AnimationClip>(L, new LuaOut<UnityEngine.AnimationClip>());
		return 1;
	}
}

