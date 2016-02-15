using System;
using LuaInterface;

public class UnityEngine_ParticleRendererWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.ParticleRenderer), typeof(UnityEngine.Renderer));
		L.RegFunction("New", _CreateUnityEngine_ParticleRenderer);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("particleRenderMode", get_particleRenderMode, set_particleRenderMode);
		L.RegVar("lengthScale", get_lengthScale, set_lengthScale);
		L.RegVar("velocityScale", get_velocityScale, set_velocityScale);
		L.RegVar("cameraVelocityScale", get_cameraVelocityScale, set_cameraVelocityScale);
		L.RegVar("maxParticleSize", get_maxParticleSize, set_maxParticleSize);
		L.RegVar("uvAnimationXTile", get_uvAnimationXTile, set_uvAnimationXTile);
		L.RegVar("uvAnimationYTile", get_uvAnimationYTile, set_uvAnimationYTile);
		L.RegVar("uvAnimationCycles", get_uvAnimationCycles, set_uvAnimationCycles);
		L.RegVar("maxPartileSize", get_maxPartileSize, set_maxPartileSize);
		L.RegVar("uvTiles", get_uvTiles, set_uvTiles);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_ParticleRenderer(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.ParticleRenderer obj = new UnityEngine.ParticleRenderer();
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.ParticleRenderer.New");
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
	static int get_particleRenderMode(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		UnityEngine.ParticleRenderMode ret;

		try
		{
			ret = obj.particleRenderMode;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index particleRenderMode on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lengthScale(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.lengthScale;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index lengthScale on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_velocityScale(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.velocityScale;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index velocityScale on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cameraVelocityScale(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.cameraVelocityScale;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index cameraVelocityScale on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxParticleSize(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.maxParticleSize;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index maxParticleSize on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uvAnimationXTile(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.uvAnimationXTile;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index uvAnimationXTile on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uvAnimationYTile(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.uvAnimationYTile;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index uvAnimationYTile on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uvAnimationCycles(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.uvAnimationCycles;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index uvAnimationCycles on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxPartileSize(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.maxPartileSize;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index maxPartileSize on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uvTiles(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		UnityEngine.Rect[] ret = null;

		try
		{
			ret = obj.uvTiles;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index uvTiles on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_particleRenderMode(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		UnityEngine.ParticleRenderMode arg0 = (UnityEngine.ParticleRenderMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.ParticleRenderMode));

		try
		{
			obj.particleRenderMode = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index particleRenderMode on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lengthScale(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.lengthScale = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index lengthScale on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_velocityScale(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.velocityScale = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index velocityScale on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cameraVelocityScale(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.cameraVelocityScale = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index cameraVelocityScale on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxParticleSize(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.maxParticleSize = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index maxParticleSize on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uvAnimationXTile(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.uvAnimationXTile = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index uvAnimationXTile on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uvAnimationYTile(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.uvAnimationYTile = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index uvAnimationYTile on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uvAnimationCycles(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.uvAnimationCycles = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index uvAnimationCycles on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxPartileSize(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.maxPartileSize = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index maxPartileSize on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uvTiles(IntPtr L)
	{
		UnityEngine.ParticleRenderer obj = (UnityEngine.ParticleRenderer)ToLua.ToObject(L, 1);
		UnityEngine.Rect[] arg0 = ToLua.CheckObjectArray<UnityEngine.Rect>(L, 2);

		try
		{
			obj.uvTiles = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index uvTiles on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.ParticleRenderer>(L, new LuaOut<UnityEngine.ParticleRenderer>());
		return 1;
	}
}

