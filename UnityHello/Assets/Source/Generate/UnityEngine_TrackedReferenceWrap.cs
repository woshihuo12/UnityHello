using System;
using LuaInterface;

public class UnityEngine_TrackedReferenceWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.TrackedReference), typeof(System.Object));
		L.RegFunction("Equals", Equals);
		L.RegFunction("GetHashCode", GetHashCode);
		L.RegFunction("New", _CreateUnityEngine_TrackedReference);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_TrackedReference(IntPtr L)
	{
		return LuaDLL.luaL_error(L, "UnityEngine.TrackedReference class does not have a constructor function");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.TrackedReference obj = (UnityEngine.TrackedReference)ToLua.CheckObject(L, 1, typeof(UnityEngine.TrackedReference));
		object arg0 = ToLua.ToVarObject(L, 2);
		bool o;

		try
		{
			o = obj != null ? obj.Equals(arg0) : arg0 == null;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.TrackedReference obj = (UnityEngine.TrackedReference)ToLua.CheckObject(L, 1, typeof(UnityEngine.TrackedReference));
		int o;

		try
		{
			o = obj.GetHashCode();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushinteger(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.TrackedReference arg0 = (UnityEngine.TrackedReference)ToLua.ToObject(L, 1);
		UnityEngine.TrackedReference arg1 = (UnityEngine.TrackedReference)ToLua.ToObject(L, 2);
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
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.TrackedReference>(L, new LuaOut<UnityEngine.TrackedReference>());
		return 1;
	}
}

