using System;
using LuaInterface;

public class GameResFactoryWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GameResFactory), typeof(System.Object));
		L.RegFunction("Instance", Instance);
		L.RegFunction("GetUIPrefab", GetUIPrefab);
		L.RegFunction("DestroyUIPrefab", DestroyUIPrefab);
		L.RegFunction("GetUIEffect", GetUIEffect);
		L.RegFunction("DestroyUIEffect", DestroyUIEffect);
		L.RegFunction("DestroyAllUIEffect", DestroyAllUIEffect);
		L.RegFunction("New", _CreateGameResFactory);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGameResFactory(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			GameResFactory obj = new GameResFactory();
			ToLua.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GameResFactory.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Instance(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 0);
		GameResFactory o = null;

		try
		{
			o = GameResFactory.Instance();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetUIPrefab(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 4);
		GameResFactory obj = (GameResFactory)ToLua.CheckObject(L, 1, typeof(GameResFactory));
		string arg0 = ToLua.CheckString(L, 2);
		UnityEngine.Transform arg1 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 3, typeof(UnityEngine.Transform));
		LuaFunction arg2 = ToLua.CheckLuaFunction(L, 4);

		try
		{
			obj.GetUIPrefab(arg0, arg1, arg2);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DestroyUIPrefab(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		GameResFactory obj = (GameResFactory)ToLua.CheckObject(L, 1, typeof(GameResFactory));
		UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.GameObject));

		try
		{
			obj.DestroyUIPrefab(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetUIEffect(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		GameResFactory obj = (GameResFactory)ToLua.CheckObject(L, 1, typeof(GameResFactory));
		string arg0 = ToLua.CheckString(L, 2);
		LuaFunction arg1 = ToLua.CheckLuaFunction(L, 3);

		try
		{
			obj.GetUIEffect(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DestroyUIEffect(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		GameResFactory obj = (GameResFactory)ToLua.CheckObject(L, 1, typeof(GameResFactory));
		UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.GameObject));

		try
		{
			obj.DestroyUIEffect(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DestroyAllUIEffect(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		GameResFactory obj = (GameResFactory)ToLua.CheckObject(L, 1, typeof(GameResFactory));

		try
		{
			obj.DestroyAllUIEffect();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
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
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<GameResFactory>(L, new LuaOut<GameResFactory>());
		return 1;
	}
}

