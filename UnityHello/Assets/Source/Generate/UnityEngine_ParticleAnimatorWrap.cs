using System;
using LuaInterface;

public class UnityEngine_ParticleAnimatorWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.ParticleAnimator), typeof(UnityEngine.Component));
		L.RegFunction("New", _CreateUnityEngine_ParticleAnimator);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("doesAnimateColor", get_doesAnimateColor, set_doesAnimateColor);
		L.RegVar("worldRotationAxis", get_worldRotationAxis, set_worldRotationAxis);
		L.RegVar("localRotationAxis", get_localRotationAxis, set_localRotationAxis);
		L.RegVar("sizeGrow", get_sizeGrow, set_sizeGrow);
		L.RegVar("rndForce", get_rndForce, set_rndForce);
		L.RegVar("force", get_force, set_force);
		L.RegVar("damping", get_damping, set_damping);
		L.RegVar("autodestruct", get_autodestruct, set_autodestruct);
		L.RegVar("colorAnimation", get_colorAnimation, set_colorAnimation);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_ParticleAnimator(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.ParticleAnimator obj = new UnityEngine.ParticleAnimator();
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.ParticleAnimator.New");
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
	static int get_doesAnimateColor(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.doesAnimateColor;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index doesAnimateColor on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_worldRotationAxis(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.worldRotationAxis;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index worldRotationAxis on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localRotationAxis(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.localRotationAxis;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index localRotationAxis on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sizeGrow(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.sizeGrow;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sizeGrow on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rndForce(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.rndForce;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index rndForce on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_force(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.force;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index force on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_damping(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.damping;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index damping on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autodestruct(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.autodestruct;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index autodestruct on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_colorAnimation(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		UnityEngine.Color[] ret = null;

		try
		{
			ret = obj.colorAnimation;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index colorAnimation on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_doesAnimateColor(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.doesAnimateColor = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index doesAnimateColor on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_worldRotationAxis(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.worldRotationAxis = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index worldRotationAxis on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localRotationAxis(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.localRotationAxis = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index localRotationAxis on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sizeGrow(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.sizeGrow = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sizeGrow on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rndForce(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.rndForce = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index rndForce on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_force(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.force = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index force on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_damping(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.damping = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index damping on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autodestruct(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.autodestruct = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index autodestruct on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_colorAnimation(IntPtr L)
	{
		UnityEngine.ParticleAnimator obj = (UnityEngine.ParticleAnimator)ToLua.ToObject(L, 1);
		UnityEngine.Color[] arg0 = ToLua.CheckObjectArray<UnityEngine.Color>(L, 2);

		try
		{
			obj.colorAnimation = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index colorAnimation on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.ParticleAnimator>(L, new LuaOut<UnityEngine.ParticleAnimator>());
		return 1;
	}
}

