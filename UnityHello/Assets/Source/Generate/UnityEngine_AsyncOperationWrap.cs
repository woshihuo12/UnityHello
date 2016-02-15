using System;
using LuaInterface;

public class UnityEngine_AsyncOperationWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.AsyncOperation), typeof(System.Object));
		L.RegFunction("New", _CreateUnityEngine_AsyncOperation);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("isDone", get_isDone, null);
		L.RegVar("progress", get_progress, null);
		L.RegVar("priority", get_priority, set_priority);
		L.RegVar("allowSceneActivation", get_allowSceneActivation, set_allowSceneActivation);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_AsyncOperation(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.AsyncOperation obj = new UnityEngine.AsyncOperation();
			ToLua.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AsyncOperation.New");
		}

		return 0;
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
	static int get_isDone(IntPtr L)
	{
		UnityEngine.AsyncOperation obj = (UnityEngine.AsyncOperation)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.isDone;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isDone on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_progress(IntPtr L)
	{
		UnityEngine.AsyncOperation obj = (UnityEngine.AsyncOperation)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.progress;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index progress on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_priority(IntPtr L)
	{
		UnityEngine.AsyncOperation obj = (UnityEngine.AsyncOperation)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.priority;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index priority on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_allowSceneActivation(IntPtr L)
	{
		UnityEngine.AsyncOperation obj = (UnityEngine.AsyncOperation)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.allowSceneActivation;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index allowSceneActivation on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_priority(IntPtr L)
	{
		UnityEngine.AsyncOperation obj = (UnityEngine.AsyncOperation)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.priority = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index priority on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_allowSceneActivation(IntPtr L)
	{
		UnityEngine.AsyncOperation obj = (UnityEngine.AsyncOperation)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.allowSceneActivation = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index allowSceneActivation on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.AsyncOperation>(L, new LuaOut<UnityEngine.AsyncOperation>());
		return 1;
	}
}

