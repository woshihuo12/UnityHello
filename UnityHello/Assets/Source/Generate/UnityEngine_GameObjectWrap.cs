using System;
using LuaInterface;

public class UnityEngine_GameObjectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.GameObject), typeof(UnityEngine.Object));
		L.RegFunction("CreatePrimitive", CreatePrimitive);
		L.RegFunction("GetComponent", GetComponent);
		L.RegFunction("GetComponentInChildren", GetComponentInChildren);
		L.RegFunction("GetComponentInParent", GetComponentInParent);
		L.RegFunction("GetComponents", GetComponents);
		L.RegFunction("GetComponentsInChildren", GetComponentsInChildren);
		L.RegFunction("GetComponentsInParent", GetComponentsInParent);
		L.RegFunction("SetActive", SetActive);
		L.RegFunction("CompareTag", CompareTag);
		L.RegFunction("FindGameObjectWithTag", FindGameObjectWithTag);
		L.RegFunction("FindWithTag", FindWithTag);
		L.RegFunction("FindGameObjectsWithTag", FindGameObjectsWithTag);
		L.RegFunction("SendMessageUpwards", SendMessageUpwards);
		L.RegFunction("SendMessage", SendMessage);
		L.RegFunction("BroadcastMessage", BroadcastMessage);
		L.RegFunction("AddComponent", AddComponent);
		L.RegFunction("Find", Find);
		L.RegFunction("New", _CreateUnityEngine_GameObject);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("transform", get_transform, null);
		L.RegVar("layer", get_layer, set_layer);
		L.RegVar("activeSelf", get_activeSelf, null);
		L.RegVar("activeInHierarchy", get_activeInHierarchy, null);
		L.RegVar("isStatic", get_isStatic, set_isStatic);
		L.RegVar("tag", get_tag, set_tag);
		L.RegVar("scene", get_scene, null);
		L.RegVar("gameObject", get_gameObject, null);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_GameObject(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.GameObject obj = new UnityEngine.GameObject();
			ToLua.Push(L, obj);
			return 1;
		}
		else if (count == 1 && ToLua.CheckTypes(L, 1, typeof(string)))
		{
			string arg0 = ToLua.CheckString(L, 1);
			UnityEngine.GameObject obj = new UnityEngine.GameObject(arg0);
			ToLua.Push(L, obj);
			return 1;
		}
		else if (ToLua.CheckTypes(L, 1, typeof(string)) && ToLua.CheckParamsType(L, typeof(System.Type), 2, count - 1))
		{
			string arg0 = ToLua.CheckString(L, 1);
			System.Type[] arg1 = ToLua.CheckParamsObject<System.Type>(L, 2, count - 1);
			UnityEngine.GameObject obj = new UnityEngine.GameObject(arg0, arg1);
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.GameObject.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreatePrimitive(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.PrimitiveType arg0 = (UnityEngine.PrimitiveType)ToLua.CheckObject(L, 1, typeof(UnityEngine.PrimitiveType));
		UnityEngine.GameObject o = null;

		try
		{
			o = UnityEngine.GameObject.CreatePrimitive(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(System.Type)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.GameObject.GetComponent");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInChildren(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(System.Type)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(System.Type), typeof(bool)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.GameObject.GetComponentInChildren");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInParent(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
	static int GetComponents(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(System.Type)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(System.Type), typeof(System.Collections.Generic.List<UnityEngine.Component>)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.GameObject.GetComponents");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentsInChildren(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(System.Type)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(System.Type), typeof(bool)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.GameObject.GetComponentsInChildren");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentsInParent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(System.Type)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(System.Type), typeof(bool)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.GameObject.GetComponentsInParent");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetActive(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.SetActive(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CompareTag(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
	static int FindGameObjectWithTag(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		string arg0 = ToLua.CheckString(L, 1);
		UnityEngine.GameObject o = null;

		try
		{
			o = UnityEngine.GameObject.FindGameObjectWithTag(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindWithTag(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		string arg0 = ToLua.CheckString(L, 1);
		UnityEngine.GameObject o = null;

		try
		{
			o = UnityEngine.GameObject.FindWithTag(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindGameObjectsWithTag(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		string arg0 = ToLua.CheckString(L, 1);
		UnityEngine.GameObject[] o = null;

		try
		{
			o = UnityEngine.GameObject.FindGameObjectsWithTag(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessageUpwards(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string), typeof(UnityEngine.SendMessageOptions)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string), typeof(object)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string), typeof(object), typeof(UnityEngine.SendMessageOptions)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.GameObject.SendMessageUpwards");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessage(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string), typeof(UnityEngine.SendMessageOptions)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string), typeof(object)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string), typeof(object), typeof(UnityEngine.SendMessageOptions)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.GameObject.SendMessage");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BroadcastMessage(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string), typeof(UnityEngine.SendMessageOptions)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string), typeof(object)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string), typeof(object), typeof(UnityEngine.SendMessageOptions)))
		{
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.GameObject.BroadcastMessage");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddComponent(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
		System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
		UnityEngine.Component o = null;

		try
		{
			o = obj.AddComponent(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Find(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		string arg0 = ToLua.CheckString(L, 1);
		UnityEngine.GameObject o = null;

		try
		{
			o = UnityEngine.GameObject.Find(arg0);
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
	static int get_transform(IntPtr L)
	{
		UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
	static int get_layer(IntPtr L)
	{
		UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.layer;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index layer on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_activeSelf(IntPtr L)
	{
		UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.activeSelf;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index activeSelf on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_activeInHierarchy(IntPtr L)
	{
		UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.activeInHierarchy;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index activeInHierarchy on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isStatic(IntPtr L)
	{
		UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.isStatic;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isStatic on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tag(IntPtr L)
	{
		UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
	static int get_scene(IntPtr L)
	{
		UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
		UnityEngine.SceneManagement.Scene ret;

		try
		{
			ret = obj.scene;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index scene on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gameObject(IntPtr L)
	{
		UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
	static int set_layer(IntPtr L)
	{
		UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.layer = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index layer on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isStatic(IntPtr L)
	{
		UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.isStatic = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isStatic on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tag(IntPtr L)
	{
		UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
		ToLua.PushOut<UnityEngine.GameObject>(L, new LuaOut<UnityEngine.GameObject>());
		return 1;
	}
}

