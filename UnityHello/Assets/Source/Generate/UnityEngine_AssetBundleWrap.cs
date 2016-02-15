using System;
using LuaInterface;

public class UnityEngine_AssetBundleWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.AssetBundle), typeof(UnityEngine.Object));
		L.RegFunction("LoadFromFileAsync", LoadFromFileAsync);
		L.RegFunction("LoadFromFile", LoadFromFile);
		L.RegFunction("LoadFromMemoryAsync", LoadFromMemoryAsync);
		L.RegFunction("LoadFromMemory", LoadFromMemory);
		L.RegFunction("Contains", Contains);
		L.RegFunction("LoadAsset", LoadAsset);
		L.RegFunction("LoadAssetAsync", LoadAssetAsync);
		L.RegFunction("LoadAssetWithSubAssets", LoadAssetWithSubAssets);
		L.RegFunction("LoadAssetWithSubAssetsAsync", LoadAssetWithSubAssetsAsync);
		L.RegFunction("LoadAllAssets", LoadAllAssets);
		L.RegFunction("LoadAllAssetsAsync", LoadAllAssetsAsync);
		L.RegFunction("Unload", Unload);
		L.RegFunction("GetAllAssetNames", GetAllAssetNames);
		L.RegFunction("GetAllScenePaths", GetAllScenePaths);
		L.RegFunction("New", _CreateUnityEngine_AssetBundle);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("mainAsset", get_mainAsset, null);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_AssetBundle(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.AssetBundle obj = new UnityEngine.AssetBundle();
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AssetBundle.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadFromFileAsync(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(string)))
		{
			string arg0 = ToLua.ToString(L, 1);
			UnityEngine.AssetBundleCreateRequest o = null;

			try
			{
				o = UnityEngine.AssetBundle.LoadFromFileAsync(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(string), typeof(uint)))
		{
			string arg0 = ToLua.ToString(L, 1);
			uint arg1 = (uint)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.AssetBundleCreateRequest o = null;

			try
			{
				o = UnityEngine.AssetBundle.LoadFromFileAsync(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadFromFileAsync");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadFromFile(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(string)))
		{
			string arg0 = ToLua.ToString(L, 1);
			UnityEngine.AssetBundle o = null;

			try
			{
				o = UnityEngine.AssetBundle.LoadFromFile(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(string), typeof(uint)))
		{
			string arg0 = ToLua.ToString(L, 1);
			uint arg1 = (uint)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.AssetBundle o = null;

			try
			{
				o = UnityEngine.AssetBundle.LoadFromFile(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadFromFile");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadFromMemoryAsync(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(byte[])))
		{
			byte[] arg0 = ToLua.CheckByteBuffer(L, 1);
			UnityEngine.AssetBundleCreateRequest o = null;

			try
			{
				o = UnityEngine.AssetBundle.LoadFromMemoryAsync(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(byte[]), typeof(uint)))
		{
			byte[] arg0 = ToLua.CheckByteBuffer(L, 1);
			uint arg1 = (uint)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.AssetBundleCreateRequest o = null;

			try
			{
				o = UnityEngine.AssetBundle.LoadFromMemoryAsync(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadFromMemoryAsync");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadFromMemory(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(byte[])))
		{
			byte[] arg0 = ToLua.CheckByteBuffer(L, 1);
			UnityEngine.AssetBundle o = null;

			try
			{
				o = UnityEngine.AssetBundle.LoadFromMemory(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(byte[]), typeof(uint)))
		{
			byte[] arg0 = ToLua.CheckByteBuffer(L, 1);
			uint arg1 = (uint)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.AssetBundle o = null;

			try
			{
				o = UnityEngine.AssetBundle.LoadFromMemory(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadFromMemory");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Contains(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
		string arg0 = ToLua.CheckString(L, 2);
		bool o;

		try
		{
			o = obj.Contains(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAsset(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AssetBundle), typeof(string)))
		{
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.Object o = null;

			try
			{
				o = obj.LoadAsset(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AssetBundle), typeof(string), typeof(System.Type)))
		{
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			System.Type arg1 = (System.Type)ToLua.ToObject(L, 3);
			UnityEngine.Object o = null;

			try
			{
				o = obj.LoadAsset(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadAsset");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAssetAsync(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AssetBundle), typeof(string)))
		{
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.AssetBundleRequest o = null;

			try
			{
				o = obj.LoadAssetAsync(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AssetBundle), typeof(string), typeof(System.Type)))
		{
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			System.Type arg1 = (System.Type)ToLua.ToObject(L, 3);
			UnityEngine.AssetBundleRequest o = null;

			try
			{
				o = obj.LoadAssetAsync(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadAssetAsync");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAssetWithSubAssets(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AssetBundle), typeof(string)))
		{
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.Object[] o = null;

			try
			{
				o = obj.LoadAssetWithSubAssets(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AssetBundle), typeof(string), typeof(System.Type)))
		{
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			System.Type arg1 = (System.Type)ToLua.ToObject(L, 3);
			UnityEngine.Object[] o = null;

			try
			{
				o = obj.LoadAssetWithSubAssets(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadAssetWithSubAssets");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAssetWithSubAssetsAsync(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AssetBundle), typeof(string)))
		{
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.AssetBundleRequest o = null;

			try
			{
				o = obj.LoadAssetWithSubAssetsAsync(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AssetBundle), typeof(string), typeof(System.Type)))
		{
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			System.Type arg1 = (System.Type)ToLua.ToObject(L, 3);
			UnityEngine.AssetBundleRequest o = null;

			try
			{
				o = obj.LoadAssetWithSubAssetsAsync(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadAssetWithSubAssetsAsync");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAllAssets(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AssetBundle)))
		{
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.ToObject(L, 1);
			UnityEngine.Object[] o = null;

			try
			{
				o = obj.LoadAllAssets();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AssetBundle), typeof(System.Type)))
		{
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.ToObject(L, 1);
			System.Type arg0 = (System.Type)ToLua.ToObject(L, 2);
			UnityEngine.Object[] o = null;

			try
			{
				o = obj.LoadAllAssets(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadAllAssets");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAllAssetsAsync(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AssetBundle)))
		{
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.ToObject(L, 1);
			UnityEngine.AssetBundleRequest o = null;

			try
			{
				o = obj.LoadAllAssetsAsync();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AssetBundle), typeof(System.Type)))
		{
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.ToObject(L, 1);
			System.Type arg0 = (System.Type)ToLua.ToObject(L, 2);
			UnityEngine.AssetBundleRequest o = null;

			try
			{
				o = obj.LoadAllAssetsAsync(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadAllAssetsAsync");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Unload(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.Unload(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAllAssetNames(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
		string[] o = null;

		try
		{
			o = obj.GetAllAssetNames();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAllScenePaths(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
		string[] o = null;

		try
		{
			o = obj.GetAllScenePaths();
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
	static int get_mainAsset(IntPtr L)
	{
		UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.ToObject(L, 1);
		UnityEngine.Object ret = null;

		try
		{
			ret = obj.mainAsset;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mainAsset on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.AssetBundle>(L, new LuaOut<UnityEngine.AssetBundle>());
		return 1;
	}
}

