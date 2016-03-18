using System;
using LuaInterface;

public class LuaHelperWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaHelper), typeof(System.Object));
		L.RegFunction("GetResManager", GetResManager);
		L.RegFunction("ChangeChildLayer", ChangeChildLayer);
		L.RegFunction("AddChildToTarget", AddChildToTarget);
		L.RegFunction("New", _CreateLuaHelper);
		L.RegFunction("__tostring", Lua_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLuaHelper(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			LuaHelper obj = new LuaHelper();
			ToLua.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: LuaHelper.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetResManager(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			ResourceManager o = LuaHelper.GetResManager();
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ChangeChildLayer(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.Transform));
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 2);
			LuaHelper.ChangeChildLayer(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddChildToTarget(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.Transform));
			UnityEngine.Transform arg1 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Transform));
			LuaHelper.AddChildToTarget(arg0, arg1);
			return 0;
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
}

