using System;
using LuaInterface;

public class LayerBaseWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LayerBase), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("Awake", Awake);
		L.RegFunction("ShowLayer", ShowLayer);
		L.RegFunction("HideLayer", HideLayer);
		L.RegFunction("WorldToScreenPoint", WorldToScreenPoint);
		L.RegFunction("LocalToWorldUIPosition", LocalToWorldUIPosition);
		L.RegFunction("New", _CreateLayerBase);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("mLayerParent", get_mLayerParent, set_mLayerParent);
		L.RegVar("mLayerCamera", get_mLayerCamera, set_mLayerCamera);
		L.RegVar("LayerName", get_LayerName, null);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLayerBase(IntPtr L)
	{
		return LuaDLL.luaL_error(L, "LayerBase class does not have a constructor function");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Awake(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		LayerBase obj = (LayerBase)ToLua.CheckObject(L, 1, typeof(LayerBase));

		try
		{
			obj.Awake();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ShowLayer(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		LayerBase obj = (LayerBase)ToLua.CheckObject(L, 1, typeof(LayerBase));

		try
		{
			obj.ShowLayer();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HideLayer(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		LayerBase obj = (LayerBase)ToLua.CheckObject(L, 1, typeof(LayerBase));

		try
		{
			obj.HideLayer();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WorldToScreenPoint(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		LayerBase obj = (LayerBase)ToLua.CheckObject(L, 1, typeof(LayerBase));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.Vector3 o;

		try
		{
			o = obj.WorldToScreenPoint(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LocalToWorldUIPosition(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		LayerBase obj = (LayerBase)ToLua.CheckObject(L, 1, typeof(LayerBase));
		UnityEngine.RectTransform arg0 = (UnityEngine.RectTransform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.RectTransform));
		UnityEngine.RectTransform arg1 = (UnityEngine.RectTransform)ToLua.CheckUnityObject(L, 3, typeof(UnityEngine.RectTransform));
		UnityEngine.Vector3 o;

		try
		{
			o = obj.LocalToWorldUIPosition(arg0, arg1);
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
	static int get_mLayerParent(IntPtr L)
	{
		LayerBase obj = (LayerBase)ToLua.ToObject(L, 1);
		UnityEngine.Transform ret = null;

		try
		{
			ret = obj.mLayerParent;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mLayerParent on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mLayerCamera(IntPtr L)
	{
		LayerBase obj = (LayerBase)ToLua.ToObject(L, 1);
		UnityEngine.Camera ret = null;

		try
		{
			ret = obj.mLayerCamera;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mLayerCamera on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LayerName(IntPtr L)
	{
		LayerBase obj = (LayerBase)ToLua.ToObject(L, 1);
		string ret = null;

		try
		{
			ret = obj.LayerName;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index LayerName on a nil value" : e.Message);
		}

		LuaDLL.lua_pushstring(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mLayerParent(IntPtr L)
	{
		LayerBase obj = (LayerBase)ToLua.ToObject(L, 1);
		UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Transform));

		try
		{
			obj.mLayerParent = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mLayerParent on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mLayerCamera(IntPtr L)
	{
		LayerBase obj = (LayerBase)ToLua.ToObject(L, 1);
		UnityEngine.Camera arg0 = (UnityEngine.Camera)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Camera));

		try
		{
			obj.mLayerCamera = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mLayerCamera on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<LayerBase>(L, new LuaOut<LayerBase>());
		return 1;
	}
}

