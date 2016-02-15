using System;
using LuaInterface;

public class UnityEngine_ColliderWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Collider), typeof(UnityEngine.Component));
		L.RegFunction("ClosestPointOnBounds", ClosestPointOnBounds);
		L.RegFunction("Raycast", Raycast);
		L.RegFunction("New", _CreateUnityEngine_Collider);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("enabled", get_enabled, set_enabled);
		L.RegVar("attachedRigidbody", get_attachedRigidbody, null);
		L.RegVar("isTrigger", get_isTrigger, set_isTrigger);
		L.RegVar("contactOffset", get_contactOffset, set_contactOffset);
		L.RegVar("material", get_material, set_material);
		L.RegVar("sharedMaterial", get_sharedMaterial, set_sharedMaterial);
		L.RegVar("bounds", get_bounds, null);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Collider(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.Collider obj = new UnityEngine.Collider();
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Collider.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClosestPointOnBounds(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Collider obj = (UnityEngine.Collider)ToLua.CheckObject(L, 1, typeof(UnityEngine.Collider));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.Vector3 o;

		try
		{
			o = obj.ClosestPointOnBounds(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Raycast(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 4);
		UnityEngine.Collider obj = (UnityEngine.Collider)ToLua.CheckObject(L, 1, typeof(UnityEngine.Collider));
		UnityEngine.Ray arg0 = ToLua.ToRay(L, 2);
		UnityEngine.RaycastHit arg1;
		float arg2 = (float)LuaDLL.luaL_checknumber(L, 4);
		bool o;

		try
		{
			o = obj.Raycast(arg0, out arg1, arg2);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
		ToLua.Push(L, arg1);
		return 2;
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
	static int get_enabled(IntPtr L)
	{
		UnityEngine.Collider obj = (UnityEngine.Collider)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.enabled;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index enabled on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_attachedRigidbody(IntPtr L)
	{
		UnityEngine.Collider obj = (UnityEngine.Collider)ToLua.ToObject(L, 1);
		UnityEngine.Rigidbody ret = null;

		try
		{
			ret = obj.attachedRigidbody;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index attachedRigidbody on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isTrigger(IntPtr L)
	{
		UnityEngine.Collider obj = (UnityEngine.Collider)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.isTrigger;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isTrigger on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_contactOffset(IntPtr L)
	{
		UnityEngine.Collider obj = (UnityEngine.Collider)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.contactOffset;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index contactOffset on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_material(IntPtr L)
	{
		UnityEngine.Collider obj = (UnityEngine.Collider)ToLua.ToObject(L, 1);
		UnityEngine.PhysicMaterial ret = null;

		try
		{
			ret = obj.material;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index material on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sharedMaterial(IntPtr L)
	{
		UnityEngine.Collider obj = (UnityEngine.Collider)ToLua.ToObject(L, 1);
		UnityEngine.PhysicMaterial ret = null;

		try
		{
			ret = obj.sharedMaterial;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sharedMaterial on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bounds(IntPtr L)
	{
		UnityEngine.Collider obj = (UnityEngine.Collider)ToLua.ToObject(L, 1);
		UnityEngine.Bounds ret;

		try
		{
			ret = obj.bounds;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index bounds on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enabled(IntPtr L)
	{
		UnityEngine.Collider obj = (UnityEngine.Collider)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.enabled = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index enabled on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isTrigger(IntPtr L)
	{
		UnityEngine.Collider obj = (UnityEngine.Collider)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.isTrigger = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isTrigger on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_contactOffset(IntPtr L)
	{
		UnityEngine.Collider obj = (UnityEngine.Collider)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.contactOffset = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index contactOffset on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_material(IntPtr L)
	{
		UnityEngine.Collider obj = (UnityEngine.Collider)ToLua.ToObject(L, 1);
		UnityEngine.PhysicMaterial arg0 = (UnityEngine.PhysicMaterial)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.PhysicMaterial));

		try
		{
			obj.material = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index material on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sharedMaterial(IntPtr L)
	{
		UnityEngine.Collider obj = (UnityEngine.Collider)ToLua.ToObject(L, 1);
		UnityEngine.PhysicMaterial arg0 = (UnityEngine.PhysicMaterial)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.PhysicMaterial));

		try
		{
			obj.sharedMaterial = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sharedMaterial on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.Collider>(L, new LuaOut<UnityEngine.Collider>());
		return 1;
	}
}

