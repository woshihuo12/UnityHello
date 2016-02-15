using System;
using LuaInterface;

public class UnityEngine_RenderTextureWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.RenderTexture), typeof(UnityEngine.Texture));
		L.RegFunction("GetTemporary", GetTemporary);
		L.RegFunction("ReleaseTemporary", ReleaseTemporary);
		L.RegFunction("Create", Create);
		L.RegFunction("Release", Release);
		L.RegFunction("IsCreated", IsCreated);
		L.RegFunction("DiscardContents", DiscardContents);
		L.RegFunction("MarkRestoreExpected", MarkRestoreExpected);
		L.RegFunction("SetGlobalShaderProperty", SetGlobalShaderProperty);
		L.RegFunction("GetTexelOffset", GetTexelOffset);
		L.RegFunction("SupportsStencil", SupportsStencil);
		L.RegFunction("New", _CreateUnityEngine_RenderTexture);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("width", get_width, set_width);
		L.RegVar("height", get_height, set_height);
		L.RegVar("depth", get_depth, set_depth);
		L.RegVar("isPowerOfTwo", get_isPowerOfTwo, set_isPowerOfTwo);
		L.RegVar("sRGB", get_sRGB, null);
		L.RegVar("format", get_format, set_format);
		L.RegVar("useMipMap", get_useMipMap, set_useMipMap);
		L.RegVar("generateMips", get_generateMips, set_generateMips);
		L.RegVar("isCubemap", get_isCubemap, set_isCubemap);
		L.RegVar("isVolume", get_isVolume, set_isVolume);
		L.RegVar("volumeDepth", get_volumeDepth, set_volumeDepth);
		L.RegVar("antiAliasing", get_antiAliasing, set_antiAliasing);
		L.RegVar("enableRandomWrite", get_enableRandomWrite, set_enableRandomWrite);
		L.RegVar("colorBuffer", get_colorBuffer, null);
		L.RegVar("depthBuffer", get_depthBuffer, null);
		L.RegVar("active", get_active, set_active);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_RenderTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 2);
			int arg2 = (int)LuaDLL.luaL_checknumber(L, 3);
			UnityEngine.RenderTexture obj = new UnityEngine.RenderTexture(arg0, arg1, arg2);
			ToLua.Push(L, obj);
			return 1;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(UnityEngine.RenderTextureFormat)))
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 2);
			int arg2 = (int)LuaDLL.luaL_checknumber(L, 3);
			UnityEngine.RenderTextureFormat arg3 = (UnityEngine.RenderTextureFormat)ToLua.CheckObject(L, 4, typeof(UnityEngine.RenderTextureFormat));
			UnityEngine.RenderTexture obj = new UnityEngine.RenderTexture(arg0, arg1, arg2, arg3);
			ToLua.Push(L, obj);
			return 1;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(UnityEngine.RenderTextureFormat), typeof(UnityEngine.RenderTextureReadWrite)))
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 2);
			int arg2 = (int)LuaDLL.luaL_checknumber(L, 3);
			UnityEngine.RenderTextureFormat arg3 = (UnityEngine.RenderTextureFormat)ToLua.CheckObject(L, 4, typeof(UnityEngine.RenderTextureFormat));
			UnityEngine.RenderTextureReadWrite arg4 = (UnityEngine.RenderTextureReadWrite)ToLua.CheckObject(L, 5, typeof(UnityEngine.RenderTextureReadWrite));
			UnityEngine.RenderTexture obj = new UnityEngine.RenderTexture(arg0, arg1, arg2, arg3, arg4);
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.RenderTexture.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTemporary(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(int), typeof(int)))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.RenderTexture o = null;

			try
			{
				o = UnityEngine.RenderTexture.GetTemporary(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int)))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 3);
			UnityEngine.RenderTexture o = null;

			try
			{
				o = UnityEngine.RenderTexture.GetTemporary(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(UnityEngine.RenderTextureFormat)))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 3);
			UnityEngine.RenderTextureFormat arg3 = (UnityEngine.RenderTextureFormat)ToLua.ToObject(L, 4);
			UnityEngine.RenderTexture o = null;

			try
			{
				o = UnityEngine.RenderTexture.GetTemporary(arg0, arg1, arg2, arg3);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(UnityEngine.RenderTextureFormat), typeof(UnityEngine.RenderTextureReadWrite)))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 3);
			UnityEngine.RenderTextureFormat arg3 = (UnityEngine.RenderTextureFormat)ToLua.ToObject(L, 4);
			UnityEngine.RenderTextureReadWrite arg4 = (UnityEngine.RenderTextureReadWrite)ToLua.ToObject(L, 5);
			UnityEngine.RenderTexture o = null;

			try
			{
				o = UnityEngine.RenderTexture.GetTemporary(arg0, arg1, arg2, arg3, arg4);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 6 && ToLua.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(UnityEngine.RenderTextureFormat), typeof(UnityEngine.RenderTextureReadWrite), typeof(int)))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 3);
			UnityEngine.RenderTextureFormat arg3 = (UnityEngine.RenderTextureFormat)ToLua.ToObject(L, 4);
			UnityEngine.RenderTextureReadWrite arg4 = (UnityEngine.RenderTextureReadWrite)ToLua.ToObject(L, 5);
			int arg5 = (int)LuaDLL.lua_tonumber(L, 6);
			UnityEngine.RenderTexture o = null;

			try
			{
				o = UnityEngine.RenderTexture.GetTemporary(arg0, arg1, arg2, arg3, arg4, arg5);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.RenderTexture.GetTemporary");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReleaseTemporary(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.RenderTexture arg0 = (UnityEngine.RenderTexture)ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.RenderTexture));

		try
		{
			UnityEngine.RenderTexture.ReleaseTemporary(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.CheckObject(L, 1, typeof(UnityEngine.RenderTexture));
		bool o;

		try
		{
			o = obj.Create();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Release(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.CheckObject(L, 1, typeof(UnityEngine.RenderTexture));

		try
		{
			obj.Release();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsCreated(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.CheckObject(L, 1, typeof(UnityEngine.RenderTexture));
		bool o;

		try
		{
			o = obj.IsCreated();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DiscardContents(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.RenderTexture)))
		{
			UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);

			try
			{
				obj.DiscardContents();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.RenderTexture), typeof(bool), typeof(bool)))
		{
			UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
			bool arg0 = LuaDLL.lua_toboolean(L, 2);
			bool arg1 = LuaDLL.lua_toboolean(L, 3);

			try
			{
				obj.DiscardContents(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.RenderTexture.DiscardContents");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MarkRestoreExpected(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.CheckObject(L, 1, typeof(UnityEngine.RenderTexture));

		try
		{
			obj.MarkRestoreExpected();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetGlobalShaderProperty(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.CheckObject(L, 1, typeof(UnityEngine.RenderTexture));
		string arg0 = ToLua.CheckString(L, 2);

		try
		{
			obj.SetGlobalShaderProperty(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTexelOffset(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.CheckObject(L, 1, typeof(UnityEngine.RenderTexture));
		UnityEngine.Vector2 o;

		try
		{
			o = obj.GetTexelOffset();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SupportsStencil(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.RenderTexture arg0 = (UnityEngine.RenderTexture)ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.RenderTexture));
		bool o;

		try
		{
			o = UnityEngine.RenderTexture.SupportsStencil(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
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
	static int get_width(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.width;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index width on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_height(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.height;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index height on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_depth(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.depth;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index depth on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPowerOfTwo(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.isPowerOfTwo;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isPowerOfTwo on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sRGB(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.sRGB;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sRGB on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_format(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		UnityEngine.RenderTextureFormat ret;

		try
		{
			ret = obj.format;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index format on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useMipMap(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.useMipMap;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index useMipMap on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_generateMips(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.generateMips;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index generateMips on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isCubemap(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.isCubemap;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isCubemap on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isVolume(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.isVolume;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isVolume on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_volumeDepth(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.volumeDepth;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index volumeDepth on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_antiAliasing(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.antiAliasing;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index antiAliasing on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enableRandomWrite(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.enableRandomWrite;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index enableRandomWrite on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_colorBuffer(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		UnityEngine.RenderBuffer ret;

		try
		{
			ret = obj.colorBuffer;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index colorBuffer on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_depthBuffer(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		UnityEngine.RenderBuffer ret;

		try
		{
			ret = obj.depthBuffer;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index depthBuffer on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_active(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.RenderTexture.active);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_width(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.width = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index width on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_height(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.height = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index height on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_depth(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.depth = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index depth on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isPowerOfTwo(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.isPowerOfTwo = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isPowerOfTwo on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_format(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		UnityEngine.RenderTextureFormat arg0 = (UnityEngine.RenderTextureFormat)ToLua.CheckObject(L, 2, typeof(UnityEngine.RenderTextureFormat));

		try
		{
			obj.format = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index format on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useMipMap(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.useMipMap = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index useMipMap on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_generateMips(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.generateMips = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index generateMips on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isCubemap(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.isCubemap = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isCubemap on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isVolume(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.isVolume = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isVolume on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_volumeDepth(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.volumeDepth = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index volumeDepth on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_antiAliasing(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.antiAliasing = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index antiAliasing on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enableRandomWrite(IntPtr L)
	{
		UnityEngine.RenderTexture obj = (UnityEngine.RenderTexture)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.enableRandomWrite = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index enableRandomWrite on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_active(IntPtr L)
	{
		UnityEngine.RenderTexture arg0 = (UnityEngine.RenderTexture)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.RenderTexture));
		UnityEngine.RenderTexture.active = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.RenderTexture>(L, new LuaOut<UnityEngine.RenderTexture>());
		return 1;
	}
}

