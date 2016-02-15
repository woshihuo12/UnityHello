using System;
using LuaInterface;

public class UnityEngine_SkinnedMeshRendererWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.SkinnedMeshRenderer), typeof(UnityEngine.Renderer));
		L.RegFunction("BakeMesh", BakeMesh);
		L.RegFunction("GetBlendShapeWeight", GetBlendShapeWeight);
		L.RegFunction("SetBlendShapeWeight", SetBlendShapeWeight);
		L.RegFunction("New", _CreateUnityEngine_SkinnedMeshRenderer);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("bones", get_bones, set_bones);
		L.RegVar("rootBone", get_rootBone, set_rootBone);
		L.RegVar("quality", get_quality, set_quality);
		L.RegVar("sharedMesh", get_sharedMesh, set_sharedMesh);
		L.RegVar("updateWhenOffscreen", get_updateWhenOffscreen, set_updateWhenOffscreen);
		L.RegVar("localBounds", get_localBounds, set_localBounds);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_SkinnedMeshRenderer(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.SkinnedMeshRenderer obj = new UnityEngine.SkinnedMeshRenderer();
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.SkinnedMeshRenderer.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BakeMesh(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.SkinnedMeshRenderer obj = (UnityEngine.SkinnedMeshRenderer)ToLua.CheckObject(L, 1, typeof(UnityEngine.SkinnedMeshRenderer));
		UnityEngine.Mesh arg0 = (UnityEngine.Mesh)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Mesh));

		try
		{
			obj.BakeMesh(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBlendShapeWeight(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.SkinnedMeshRenderer obj = (UnityEngine.SkinnedMeshRenderer)ToLua.CheckObject(L, 1, typeof(UnityEngine.SkinnedMeshRenderer));
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		float o;

		try
		{
			o = obj.GetBlendShapeWeight(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushnumber(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetBlendShapeWeight(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.SkinnedMeshRenderer obj = (UnityEngine.SkinnedMeshRenderer)ToLua.CheckObject(L, 1, typeof(UnityEngine.SkinnedMeshRenderer));
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);

		try
		{
			obj.SetBlendShapeWeight(arg0, arg1);
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
	static int get_bones(IntPtr L)
	{
		UnityEngine.SkinnedMeshRenderer obj = (UnityEngine.SkinnedMeshRenderer)ToLua.ToObject(L, 1);
		UnityEngine.Transform[] ret = null;

		try
		{
			ret = obj.bones;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index bones on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rootBone(IntPtr L)
	{
		UnityEngine.SkinnedMeshRenderer obj = (UnityEngine.SkinnedMeshRenderer)ToLua.ToObject(L, 1);
		UnityEngine.Transform ret = null;

		try
		{
			ret = obj.rootBone;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index rootBone on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_quality(IntPtr L)
	{
		UnityEngine.SkinnedMeshRenderer obj = (UnityEngine.SkinnedMeshRenderer)ToLua.ToObject(L, 1);
		UnityEngine.SkinQuality ret;

		try
		{
			ret = obj.quality;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index quality on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sharedMesh(IntPtr L)
	{
		UnityEngine.SkinnedMeshRenderer obj = (UnityEngine.SkinnedMeshRenderer)ToLua.ToObject(L, 1);
		UnityEngine.Mesh ret = null;

		try
		{
			ret = obj.sharedMesh;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sharedMesh on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_updateWhenOffscreen(IntPtr L)
	{
		UnityEngine.SkinnedMeshRenderer obj = (UnityEngine.SkinnedMeshRenderer)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.updateWhenOffscreen;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index updateWhenOffscreen on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localBounds(IntPtr L)
	{
		UnityEngine.SkinnedMeshRenderer obj = (UnityEngine.SkinnedMeshRenderer)ToLua.ToObject(L, 1);
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
	static int set_bones(IntPtr L)
	{
		UnityEngine.SkinnedMeshRenderer obj = (UnityEngine.SkinnedMeshRenderer)ToLua.ToObject(L, 1);
		UnityEngine.Transform[] arg0 = ToLua.CheckObjectArray<UnityEngine.Transform>(L, 2);

		try
		{
			obj.bones = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index bones on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rootBone(IntPtr L)
	{
		UnityEngine.SkinnedMeshRenderer obj = (UnityEngine.SkinnedMeshRenderer)ToLua.ToObject(L, 1);
		UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Transform));

		try
		{
			obj.rootBone = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index rootBone on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_quality(IntPtr L)
	{
		UnityEngine.SkinnedMeshRenderer obj = (UnityEngine.SkinnedMeshRenderer)ToLua.ToObject(L, 1);
		UnityEngine.SkinQuality arg0 = (UnityEngine.SkinQuality)ToLua.CheckObject(L, 2, typeof(UnityEngine.SkinQuality));

		try
		{
			obj.quality = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index quality on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sharedMesh(IntPtr L)
	{
		UnityEngine.SkinnedMeshRenderer obj = (UnityEngine.SkinnedMeshRenderer)ToLua.ToObject(L, 1);
		UnityEngine.Mesh arg0 = (UnityEngine.Mesh)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Mesh));

		try
		{
			obj.sharedMesh = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sharedMesh on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_updateWhenOffscreen(IntPtr L)
	{
		UnityEngine.SkinnedMeshRenderer obj = (UnityEngine.SkinnedMeshRenderer)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.updateWhenOffscreen = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index updateWhenOffscreen on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localBounds(IntPtr L)
	{
		UnityEngine.SkinnedMeshRenderer obj = (UnityEngine.SkinnedMeshRenderer)ToLua.ToObject(L, 1);
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
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.SkinnedMeshRenderer>(L, new LuaOut<UnityEngine.SkinnedMeshRenderer>());
		return 1;
	}
}

