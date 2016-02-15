using System;
using LuaInterface;

public class UnityEngine_TransformWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Transform), typeof(UnityEngine.Component));
		L.RegFunction("SetParent", SetParent);
		L.RegFunction("Translate", Translate);
		L.RegFunction("Rotate", Rotate);
		L.RegFunction("RotateAround", RotateAround);
		L.RegFunction("LookAt", LookAt);
		L.RegFunction("TransformDirection", TransformDirection);
		L.RegFunction("InverseTransformDirection", InverseTransformDirection);
		L.RegFunction("TransformVector", TransformVector);
		L.RegFunction("InverseTransformVector", InverseTransformVector);
		L.RegFunction("TransformPoint", TransformPoint);
		L.RegFunction("InverseTransformPoint", InverseTransformPoint);
		L.RegFunction("DetachChildren", DetachChildren);
		L.RegFunction("SetAsFirstSibling", SetAsFirstSibling);
		L.RegFunction("SetAsLastSibling", SetAsLastSibling);
		L.RegFunction("SetSiblingIndex", SetSiblingIndex);
		L.RegFunction("GetSiblingIndex", GetSiblingIndex);
		L.RegFunction("Find", Find);
		L.RegFunction("IsChildOf", IsChildOf);
		L.RegFunction("FindChild", FindChild);
		L.RegFunction("GetEnumerator", GetEnumerator);
		L.RegFunction("GetChild", GetChild);
		L.RegFunction("New", _CreateUnityEngine_Transform);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("position", get_position, set_position);
		L.RegVar("localPosition", get_localPosition, set_localPosition);
		L.RegVar("eulerAngles", get_eulerAngles, set_eulerAngles);
		L.RegVar("localEulerAngles", get_localEulerAngles, set_localEulerAngles);
		L.RegVar("right", get_right, set_right);
		L.RegVar("up", get_up, set_up);
		L.RegVar("forward", get_forward, set_forward);
		L.RegVar("rotation", get_rotation, set_rotation);
		L.RegVar("localRotation", get_localRotation, set_localRotation);
		L.RegVar("localScale", get_localScale, set_localScale);
		L.RegVar("parent", get_parent, set_parent);
		L.RegVar("worldToLocalMatrix", get_worldToLocalMatrix, null);
		L.RegVar("localToWorldMatrix", get_localToWorldMatrix, null);
		L.RegVar("root", get_root, null);
		L.RegVar("childCount", get_childCount, null);
		L.RegVar("lossyScale", get_lossyScale, null);
		L.RegVar("hasChanged", get_hasChanged, set_hasChanged);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Transform(IntPtr L)
	{
		return LuaDLL.luaL_error(L, "UnityEngine.Transform class does not have a constructor function");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetParent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Transform)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.ToObject(L, 2);

			try
			{
				obj.SetParent(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Transform), typeof(bool)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.ToObject(L, 2);
			bool arg1 = LuaDLL.lua_toboolean(L, 3);

			try
			{
				obj.SetParent(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Transform.SetParent");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Translate(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

			try
			{
				obj.Translate(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Vector3), typeof(UnityEngine.Transform)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Transform arg1 = (UnityEngine.Transform)ToLua.ToObject(L, 3);

			try
			{
				obj.Translate(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Vector3), typeof(UnityEngine.Space)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Space arg1 = (UnityEngine.Space)ToLua.ToObject(L, 3);

			try
			{
				obj.Translate(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(float), typeof(float), typeof(float)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);

			try
			{
				obj.Translate(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(float), typeof(float), typeof(float), typeof(UnityEngine.Transform)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
			UnityEngine.Transform arg3 = (UnityEngine.Transform)ToLua.ToObject(L, 5);

			try
			{
				obj.Translate(arg0, arg1, arg2, arg3);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(float), typeof(float), typeof(float), typeof(UnityEngine.Space)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
			UnityEngine.Space arg3 = (UnityEngine.Space)ToLua.ToObject(L, 5);

			try
			{
				obj.Translate(arg0, arg1, arg2, arg3);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Transform.Translate");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Rotate(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

			try
			{
				obj.Rotate(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Vector3), typeof(float)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);

			try
			{
				obj.Rotate(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Vector3), typeof(UnityEngine.Space)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Space arg1 = (UnityEngine.Space)ToLua.ToObject(L, 3);

			try
			{
				obj.Rotate(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Vector3), typeof(float), typeof(UnityEngine.Space)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			UnityEngine.Space arg2 = (UnityEngine.Space)ToLua.ToObject(L, 4);

			try
			{
				obj.Rotate(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(float), typeof(float), typeof(float)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);

			try
			{
				obj.Rotate(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(float), typeof(float), typeof(float), typeof(UnityEngine.Space)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
			UnityEngine.Space arg3 = (UnityEngine.Space)ToLua.ToObject(L, 5);

			try
			{
				obj.Rotate(arg0, arg1, arg2, arg3);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Transform.Rotate");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RotateAround(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 4);
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.CheckObject(L, 1, typeof(UnityEngine.Transform));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
		float arg2 = (float)LuaDLL.luaL_checknumber(L, 4);

		try
		{
			obj.RotateAround(arg0, arg1, arg2);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LookAt(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

			try
			{
				obj.LookAt(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Transform)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.ToObject(L, 2);

			try
			{
				obj.LookAt(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Vector3), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);

			try
			{
				obj.LookAt(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Transform), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.ToObject(L, 2);
			UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);

			try
			{
				obj.LookAt(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Transform.LookAt");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TransformDirection(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o;

			try
			{
				o = obj.TransformDirection(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(float), typeof(float), typeof(float)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
			UnityEngine.Vector3 o;

			try
			{
				o = obj.TransformDirection(arg0, arg1, arg2);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Transform.TransformDirection");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InverseTransformDirection(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o;

			try
			{
				o = obj.InverseTransformDirection(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(float), typeof(float), typeof(float)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
			UnityEngine.Vector3 o;

			try
			{
				o = obj.InverseTransformDirection(arg0, arg1, arg2);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Transform.InverseTransformDirection");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TransformVector(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o;

			try
			{
				o = obj.TransformVector(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(float), typeof(float), typeof(float)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
			UnityEngine.Vector3 o;

			try
			{
				o = obj.TransformVector(arg0, arg1, arg2);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Transform.TransformVector");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InverseTransformVector(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o;

			try
			{
				o = obj.InverseTransformVector(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(float), typeof(float), typeof(float)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
			UnityEngine.Vector3 o;

			try
			{
				o = obj.InverseTransformVector(arg0, arg1, arg2);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Transform.InverseTransformVector");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TransformPoint(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o;

			try
			{
				o = obj.TransformPoint(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(float), typeof(float), typeof(float)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
			UnityEngine.Vector3 o;

			try
			{
				o = obj.TransformPoint(arg0, arg1, arg2);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Transform.TransformPoint");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InverseTransformPoint(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o;

			try
			{
				o = obj.InverseTransformPoint(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Transform), typeof(float), typeof(float), typeof(float)))
		{
			UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
			UnityEngine.Vector3 o;

			try
			{
				o = obj.InverseTransformPoint(arg0, arg1, arg2);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Transform.InverseTransformPoint");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DetachChildren(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.CheckObject(L, 1, typeof(UnityEngine.Transform));

		try
		{
			obj.DetachChildren();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetAsFirstSibling(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.CheckObject(L, 1, typeof(UnityEngine.Transform));

		try
		{
			obj.SetAsFirstSibling();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetAsLastSibling(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.CheckObject(L, 1, typeof(UnityEngine.Transform));

		try
		{
			obj.SetAsLastSibling();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetSiblingIndex(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.CheckObject(L, 1, typeof(UnityEngine.Transform));
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.SetSiblingIndex(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSiblingIndex(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.CheckObject(L, 1, typeof(UnityEngine.Transform));
		int o;

		try
		{
			o = obj.GetSiblingIndex();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushinteger(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Find(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.CheckObject(L, 1, typeof(UnityEngine.Transform));
		string arg0 = ToLua.CheckString(L, 2);
		UnityEngine.Transform o = null;

		try
		{
			o = obj.Find(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsChildOf(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.CheckObject(L, 1, typeof(UnityEngine.Transform));
		UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Transform));
		bool o;

		try
		{
			o = obj.IsChildOf(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindChild(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.CheckObject(L, 1, typeof(UnityEngine.Transform));
		string arg0 = ToLua.CheckString(L, 2);
		UnityEngine.Transform o = null;

		try
		{
			o = obj.FindChild(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEnumerator(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.CheckObject(L, 1, typeof(UnityEngine.Transform));
		System.Collections.IEnumerator o = null;

		try
		{
			o = obj.GetEnumerator();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetChild(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.CheckObject(L, 1, typeof(UnityEngine.Transform));
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		UnityEngine.Transform o = null;

		try
		{
			o = obj.GetChild(arg0);
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
	static int get_position(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.position;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index position on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localPosition(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.localPosition;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index localPosition on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_eulerAngles(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.eulerAngles;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index eulerAngles on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localEulerAngles(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.localEulerAngles;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index localEulerAngles on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_right(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.right;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index right on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_up(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.up;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index up on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_forward(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.forward;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index forward on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotation(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Quaternion ret;

		try
		{
			ret = obj.rotation;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index rotation on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localRotation(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Quaternion ret;

		try
		{
			ret = obj.localRotation;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index localRotation on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localScale(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.localScale;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index localScale on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_parent(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Transform ret = null;

		try
		{
			ret = obj.parent;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index parent on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_worldToLocalMatrix(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Matrix4x4 ret;

		try
		{
			ret = obj.worldToLocalMatrix;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index worldToLocalMatrix on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localToWorldMatrix(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Matrix4x4 ret;

		try
		{
			ret = obj.localToWorldMatrix;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index localToWorldMatrix on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_root(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Transform ret = null;

		try
		{
			ret = obj.root;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index root on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_childCount(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.childCount;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index childCount on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lossyScale(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.lossyScale;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index lossyScale on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hasChanged(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.hasChanged;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index hasChanged on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_position(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.position = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index position on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localPosition(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.localPosition = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index localPosition on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_eulerAngles(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.eulerAngles = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index eulerAngles on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localEulerAngles(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.localEulerAngles = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index localEulerAngles on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_right(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.right = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index right on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_up(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.up = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index up on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_forward(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.forward = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index forward on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rotation(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Quaternion arg0 = ToLua.ToQuaternion(L, 2);

		try
		{
			obj.rotation = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index rotation on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localRotation(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Quaternion arg0 = ToLua.ToQuaternion(L, 2);

		try
		{
			obj.localRotation = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index localRotation on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localScale(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.localScale = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index localScale on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_parent(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Transform));

		try
		{
			obj.parent = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index parent on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hasChanged(IntPtr L)
	{
		UnityEngine.Transform obj = (UnityEngine.Transform)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.hasChanged = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index hasChanged on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.Transform>(L, new LuaOut<UnityEngine.Transform>());
		return 1;
	}
}

