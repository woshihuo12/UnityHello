using System;
using LuaInterface;

public class UnityEngine_ComponentWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Component), typeof(UnityEngine.Object));
		L.RegFunction("GetComponent", GetComponent);
		L.RegFunction("GetComponentInChildren", GetComponentInChildren);
		L.RegFunction("GetComponentsInChildren", GetComponentsInChildren);
		L.RegFunction("GetComponentInParent", GetComponentInParent);
		L.RegFunction("GetComponentsInParent", GetComponentsInParent);
		L.RegFunction("GetComponents", GetComponents);
		L.RegFunction("CompareTag", CompareTag);
		L.RegFunction("SendMessageUpwards", SendMessageUpwards);
		L.RegFunction("SendMessage", SendMessage);
		L.RegFunction("BroadcastMessage", BroadcastMessage);
		L.RegFunction("New", _CreateUnityEngine_Component);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("transform", get_transform, null);
		L.RegVar("gameObject", get_gameObject, null);
		L.RegVar("tag", get_tag, set_tag);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Component(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.Component obj = new UnityEngine.Component();
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Component.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.Component o = null;

			try
			{
				o = obj.GetComponent(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(System.Type)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			System.Type arg0 = (System.Type)ToLua.ToObject(L, 2);
			UnityEngine.Component o = null;

			try
			{
				o = obj.GetComponent(arg0);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Component.GetComponent");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInChildren(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(System.Type)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			System.Type arg0 = (System.Type)ToLua.ToObject(L, 2);
			UnityEngine.Component o = null;

			try
			{
				o = obj.GetComponentInChildren(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(System.Type), typeof(bool)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			System.Type arg0 = (System.Type)ToLua.ToObject(L, 2);
			bool arg1 = LuaDLL.lua_toboolean(L, 3);
			UnityEngine.Component o = null;

			try
			{
				o = obj.GetComponentInChildren(arg0, arg1);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Component.GetComponentInChildren");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentsInChildren(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(System.Type)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			System.Type arg0 = (System.Type)ToLua.ToObject(L, 2);
			UnityEngine.Component[] o = null;

			try
			{
				o = obj.GetComponentsInChildren(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(System.Type), typeof(bool)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			System.Type arg0 = (System.Type)ToLua.ToObject(L, 2);
			bool arg1 = LuaDLL.lua_toboolean(L, 3);
			UnityEngine.Component[] o = null;

			try
			{
				o = obj.GetComponentsInChildren(arg0, arg1);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Component.GetComponentsInChildren");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInParent(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
		System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
		UnityEngine.Component o = null;

		try
		{
			o = obj.GetComponentInParent(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentsInParent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(System.Type)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			System.Type arg0 = (System.Type)ToLua.ToObject(L, 2);
			UnityEngine.Component[] o = null;

			try
			{
				o = obj.GetComponentsInParent(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(System.Type), typeof(bool)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			System.Type arg0 = (System.Type)ToLua.ToObject(L, 2);
			bool arg1 = LuaDLL.lua_toboolean(L, 3);
			UnityEngine.Component[] o = null;

			try
			{
				o = obj.GetComponentsInParent(arg0, arg1);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Component.GetComponentsInParent");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponents(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(System.Type)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			System.Type arg0 = (System.Type)ToLua.ToObject(L, 2);
			UnityEngine.Component[] o = null;

			try
			{
				o = obj.GetComponents(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(System.Type), typeof(System.Collections.Generic.List<UnityEngine.Component>)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			System.Type arg0 = (System.Type)ToLua.ToObject(L, 2);
			System.Collections.Generic.List<UnityEngine.Component> arg1 = (System.Collections.Generic.List<UnityEngine.Component>)ToLua.ToObject(L, 3);

			try
			{
				obj.GetComponents(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Component.GetComponents");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CompareTag(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
		string arg0 = ToLua.CheckString(L, 2);
		bool o;

		try
		{
			o = obj.CompareTag(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessageUpwards(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);

			try
			{
				obj.SendMessageUpwards(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string), typeof(UnityEngine.SendMessageOptions)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.SendMessageOptions arg1 = (UnityEngine.SendMessageOptions)ToLua.ToObject(L, 3);

			try
			{
				obj.SendMessageUpwards(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string), typeof(object)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			object arg1 = ToLua.ToVarObject(L, 3);

			try
			{
				obj.SendMessageUpwards(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string), typeof(object), typeof(UnityEngine.SendMessageOptions)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			object arg1 = ToLua.ToVarObject(L, 3);
			UnityEngine.SendMessageOptions arg2 = (UnityEngine.SendMessageOptions)ToLua.ToObject(L, 4);

			try
			{
				obj.SendMessageUpwards(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Component.SendMessageUpwards");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessage(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);

			try
			{
				obj.SendMessage(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string), typeof(UnityEngine.SendMessageOptions)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.SendMessageOptions arg1 = (UnityEngine.SendMessageOptions)ToLua.ToObject(L, 3);

			try
			{
				obj.SendMessage(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string), typeof(object)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			object arg1 = ToLua.ToVarObject(L, 3);

			try
			{
				obj.SendMessage(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string), typeof(object), typeof(UnityEngine.SendMessageOptions)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			object arg1 = ToLua.ToVarObject(L, 3);
			UnityEngine.SendMessageOptions arg2 = (UnityEngine.SendMessageOptions)ToLua.ToObject(L, 4);

			try
			{
				obj.SendMessage(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Component.SendMessage");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BroadcastMessage(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);

			try
			{
				obj.BroadcastMessage(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string), typeof(UnityEngine.SendMessageOptions)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.SendMessageOptions arg1 = (UnityEngine.SendMessageOptions)ToLua.ToObject(L, 3);

			try
			{
				obj.BroadcastMessage(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string), typeof(object)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			object arg1 = ToLua.ToVarObject(L, 3);

			try
			{
				obj.BroadcastMessage(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string), typeof(object), typeof(UnityEngine.SendMessageOptions)))
		{
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			object arg1 = ToLua.ToVarObject(L, 3);
			UnityEngine.SendMessageOptions arg2 = (UnityEngine.SendMessageOptions)ToLua.ToObject(L, 4);

			try
			{
				obj.BroadcastMessage(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Component.BroadcastMessage");
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
	static int get_transform(IntPtr L)
	{
		UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
		UnityEngine.Transform ret = null;

		try
		{
			ret = obj.transform;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index transform on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gameObject(IntPtr L)
	{
		UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
		UnityEngine.GameObject ret = null;

		try
		{
			ret = obj.gameObject;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index gameObject on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tag(IntPtr L)
	{
		UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
		string ret = null;

		try
		{
			ret = obj.tag;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index tag on a nil value" : e.Message);
		}

		LuaDLL.lua_pushstring(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tag(IntPtr L)
	{
		UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
		string arg0 = ToLua.CheckString(L, 2);

		try
		{
			obj.tag = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index tag on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.Component>(L, new LuaOut<UnityEngine.Component>());
		return 1;
	}
}

