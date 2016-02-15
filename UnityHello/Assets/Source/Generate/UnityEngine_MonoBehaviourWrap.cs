using System;
using LuaInterface;

public class UnityEngine_MonoBehaviourWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.MonoBehaviour), typeof(UnityEngine.Behaviour));
		L.RegFunction("Invoke", Invoke);
		L.RegFunction("InvokeRepeating", InvokeRepeating);
		L.RegFunction("CancelInvoke", CancelInvoke);
		L.RegFunction("IsInvoking", IsInvoking);
		L.RegFunction("StartCoroutine", StartCoroutine);
		L.RegFunction("StartCoroutine_Auto", StartCoroutine_Auto);
		L.RegFunction("StopCoroutine", StopCoroutine);
		L.RegFunction("StopAllCoroutines", StopAllCoroutines);
		L.RegFunction("print", print);
		L.RegFunction("New", _CreateUnityEngine_MonoBehaviour);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("useGUILayout", get_useGUILayout, set_useGUILayout);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_MonoBehaviour(IntPtr L)
	{
		return LuaDLL.luaL_error(L, "UnityEngine.MonoBehaviour class does not have a constructor function");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Invoke(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.MonoBehaviour obj = (UnityEngine.MonoBehaviour)ToLua.CheckObject(L, 1, typeof(UnityEngine.MonoBehaviour));
		string arg0 = ToLua.CheckString(L, 2);
		float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);

		try
		{
			obj.Invoke(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InvokeRepeating(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 4);
		UnityEngine.MonoBehaviour obj = (UnityEngine.MonoBehaviour)ToLua.CheckObject(L, 1, typeof(UnityEngine.MonoBehaviour));
		string arg0 = ToLua.CheckString(L, 2);
		float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
		float arg2 = (float)LuaDLL.luaL_checknumber(L, 4);

		try
		{
			obj.InvokeRepeating(arg0, arg1, arg2);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CancelInvoke(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.MonoBehaviour)))
		{
			UnityEngine.MonoBehaviour obj = (UnityEngine.MonoBehaviour)ToLua.ToObject(L, 1);

			try
			{
				obj.CancelInvoke();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.MonoBehaviour), typeof(string)))
		{
			UnityEngine.MonoBehaviour obj = (UnityEngine.MonoBehaviour)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);

			try
			{
				obj.CancelInvoke(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.MonoBehaviour.CancelInvoke");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsInvoking(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.MonoBehaviour)))
		{
			UnityEngine.MonoBehaviour obj = (UnityEngine.MonoBehaviour)ToLua.ToObject(L, 1);
			bool o;

			try
			{
				o = obj.IsInvoking();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.MonoBehaviour), typeof(string)))
		{
			UnityEngine.MonoBehaviour obj = (UnityEngine.MonoBehaviour)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			bool o;

			try
			{
				o = obj.IsInvoking(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.MonoBehaviour.IsInvoking");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartCoroutine(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.MonoBehaviour), typeof(string)))
		{
			UnityEngine.MonoBehaviour obj = (UnityEngine.MonoBehaviour)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.Coroutine o = null;

			try
			{
				o = obj.StartCoroutine(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.MonoBehaviour), typeof(System.Collections.IEnumerator)))
		{
			UnityEngine.MonoBehaviour obj = (UnityEngine.MonoBehaviour)ToLua.ToObject(L, 1);
			System.Collections.IEnumerator arg0 = (System.Collections.IEnumerator)ToLua.ToObject(L, 2);
			UnityEngine.Coroutine o = null;

			try
			{
				o = obj.StartCoroutine(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.MonoBehaviour), typeof(string), typeof(object)))
		{
			UnityEngine.MonoBehaviour obj = (UnityEngine.MonoBehaviour)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			object arg1 = ToLua.ToVarObject(L, 3);
			UnityEngine.Coroutine o = null;

			try
			{
				o = obj.StartCoroutine(arg0, arg1);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.MonoBehaviour.StartCoroutine");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartCoroutine_Auto(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.MonoBehaviour obj = (UnityEngine.MonoBehaviour)ToLua.CheckObject(L, 1, typeof(UnityEngine.MonoBehaviour));
		System.Collections.IEnumerator arg0 = (System.Collections.IEnumerator)ToLua.CheckObject(L, 2, typeof(System.Collections.IEnumerator));
		UnityEngine.Coroutine o = null;

		try
		{
			o = obj.StartCoroutine_Auto(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopCoroutine(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.MonoBehaviour), typeof(UnityEngine.Coroutine)))
		{
			UnityEngine.MonoBehaviour obj = (UnityEngine.MonoBehaviour)ToLua.ToObject(L, 1);
			UnityEngine.Coroutine arg0 = (UnityEngine.Coroutine)ToLua.ToObject(L, 2);

			try
			{
				obj.StopCoroutine(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.MonoBehaviour), typeof(System.Collections.IEnumerator)))
		{
			UnityEngine.MonoBehaviour obj = (UnityEngine.MonoBehaviour)ToLua.ToObject(L, 1);
			System.Collections.IEnumerator arg0 = (System.Collections.IEnumerator)ToLua.ToObject(L, 2);

			try
			{
				obj.StopCoroutine(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.MonoBehaviour), typeof(string)))
		{
			UnityEngine.MonoBehaviour obj = (UnityEngine.MonoBehaviour)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);

			try
			{
				obj.StopCoroutine(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.MonoBehaviour.StopCoroutine");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopAllCoroutines(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.MonoBehaviour obj = (UnityEngine.MonoBehaviour)ToLua.CheckObject(L, 1, typeof(UnityEngine.MonoBehaviour));

		try
		{
			obj.StopAllCoroutines();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int print(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		object arg0 = ToLua.ToVarObject(L, 1);

		try
		{
			UnityEngine.MonoBehaviour.print(arg0);
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
	static int get_useGUILayout(IntPtr L)
	{
		UnityEngine.MonoBehaviour obj = (UnityEngine.MonoBehaviour)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.useGUILayout;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index useGUILayout on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useGUILayout(IntPtr L)
	{
		UnityEngine.MonoBehaviour obj = (UnityEngine.MonoBehaviour)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.useGUILayout = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index useGUILayout on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.MonoBehaviour>(L, new LuaOut<UnityEngine.MonoBehaviour>());
		return 1;
	}
}

