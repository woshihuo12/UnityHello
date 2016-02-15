using System;
using LuaInterface;

public class UnityEngine_CharacterControllerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.CharacterController), typeof(UnityEngine.Collider));
		L.RegFunction("SimpleMove", SimpleMove);
		L.RegFunction("Move", Move);
		L.RegFunction("New", _CreateUnityEngine_CharacterController);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("isGrounded", get_isGrounded, null);
		L.RegVar("velocity", get_velocity, null);
		L.RegVar("collisionFlags", get_collisionFlags, null);
		L.RegVar("radius", get_radius, set_radius);
		L.RegVar("height", get_height, set_height);
		L.RegVar("center", get_center, set_center);
		L.RegVar("slopeLimit", get_slopeLimit, set_slopeLimit);
		L.RegVar("stepOffset", get_stepOffset, set_stepOffset);
		L.RegVar("skinWidth", get_skinWidth, set_skinWidth);
		L.RegVar("detectCollisions", get_detectCollisions, set_detectCollisions);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_CharacterController(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.CharacterController obj = new UnityEngine.CharacterController();
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.CharacterController.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SimpleMove(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.CheckObject(L, 1, typeof(UnityEngine.CharacterController));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		bool o;

		try
		{
			o = obj.SimpleMove(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Move(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.CheckObject(L, 1, typeof(UnityEngine.CharacterController));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.CollisionFlags o;

		try
		{
			o = obj.Move(arg0);
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
	static int get_isGrounded(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.isGrounded;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isGrounded on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_velocity(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.velocity;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index velocity on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_collisionFlags(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		UnityEngine.CollisionFlags ret;

		try
		{
			ret = obj.collisionFlags;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index collisionFlags on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_radius(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.radius;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index radius on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_height(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.height;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index height on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_center(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.center;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index center on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_slopeLimit(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.slopeLimit;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index slopeLimit on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stepOffset(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.stepOffset;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index stepOffset on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skinWidth(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.skinWidth;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index skinWidth on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_detectCollisions(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.detectCollisions;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index detectCollisions on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_radius(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.radius = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index radius on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_height(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

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
	static int set_center(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.center = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index center on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_slopeLimit(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.slopeLimit = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index slopeLimit on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stepOffset(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.stepOffset = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index stepOffset on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skinWidth(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.skinWidth = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index skinWidth on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_detectCollisions(IntPtr L)
	{
		UnityEngine.CharacterController obj = (UnityEngine.CharacterController)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.detectCollisions = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index detectCollisions on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.CharacterController>(L, new LuaOut<UnityEngine.CharacterController>());
		return 1;
	}
}

