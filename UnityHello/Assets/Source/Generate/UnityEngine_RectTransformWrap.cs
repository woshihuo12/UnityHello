using System;
using LuaInterface;

public class UnityEngine_RectTransformWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.RectTransform), typeof(UnityEngine.Transform));
		L.RegFunction("GetLocalCorners", GetLocalCorners);
		L.RegFunction("GetWorldCorners", GetWorldCorners);
		L.RegFunction("SetInsetAndSizeFromParentEdge", SetInsetAndSizeFromParentEdge);
		L.RegFunction("SetSizeWithCurrentAnchors", SetSizeWithCurrentAnchors);
		L.RegFunction("New", _CreateUnityEngine_RectTransform);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("rect", get_rect, null);
		L.RegVar("anchorMin", get_anchorMin, set_anchorMin);
		L.RegVar("anchorMax", get_anchorMax, set_anchorMax);
		L.RegVar("anchoredPosition3D", get_anchoredPosition3D, set_anchoredPosition3D);
		L.RegVar("anchoredPosition", get_anchoredPosition, set_anchoredPosition);
		L.RegVar("sizeDelta", get_sizeDelta, set_sizeDelta);
		L.RegVar("pivot", get_pivot, set_pivot);
		L.RegVar("offsetMin", get_offsetMin, set_offsetMin);
		L.RegVar("offsetMax", get_offsetMax, set_offsetMax);
		L.RegVar("reapplyDrivenProperties", get_reapplyDrivenProperties, set_reapplyDrivenProperties);
		L.RegFunction("ReapplyDrivenProperties", ReapplyDrivenProperties);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_RectTransform(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.RectTransform obj = new UnityEngine.RectTransform();
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.RectTransform.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLocalCorners(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.CheckObject(L, 1, typeof(UnityEngine.RectTransform));
		UnityEngine.Vector3[] arg0 = ToLua.CheckObjectArray<UnityEngine.Vector3>(L, 2);

		try
		{
			obj.GetLocalCorners(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWorldCorners(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.CheckObject(L, 1, typeof(UnityEngine.RectTransform));
		UnityEngine.Vector3[] arg0 = ToLua.CheckObjectArray<UnityEngine.Vector3>(L, 2);

		try
		{
			obj.GetWorldCorners(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetInsetAndSizeFromParentEdge(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 4);
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.CheckObject(L, 1, typeof(UnityEngine.RectTransform));
		UnityEngine.RectTransform.Edge arg0 = (UnityEngine.RectTransform.Edge)ToLua.CheckObject(L, 2, typeof(UnityEngine.RectTransform.Edge));
		float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
		float arg2 = (float)LuaDLL.luaL_checknumber(L, 4);

		try
		{
			obj.SetInsetAndSizeFromParentEdge(arg0, arg1, arg2);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetSizeWithCurrentAnchors(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.CheckObject(L, 1, typeof(UnityEngine.RectTransform));
		UnityEngine.RectTransform.Axis arg0 = (UnityEngine.RectTransform.Axis)ToLua.CheckObject(L, 2, typeof(UnityEngine.RectTransform.Axis));
		float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);

		try
		{
			obj.SetSizeWithCurrentAnchors(arg0, arg1);
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
	static int get_rect(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Rect ret;

		try
		{
			ret = obj.rect;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index rect on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_anchorMin(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 ret;

		try
		{
			ret = obj.anchorMin;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index anchorMin on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_anchorMax(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 ret;

		try
		{
			ret = obj.anchorMax;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index anchorMax on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_anchoredPosition3D(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.anchoredPosition3D;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index anchoredPosition3D on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_anchoredPosition(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 ret;

		try
		{
			ret = obj.anchoredPosition;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index anchoredPosition on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sizeDelta(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 ret;

		try
		{
			ret = obj.sizeDelta;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sizeDelta on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pivot(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 ret;

		try
		{
			ret = obj.pivot;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index pivot on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_offsetMin(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 ret;

		try
		{
			ret = obj.offsetMin;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index offsetMin on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_offsetMax(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 ret;

		try
		{
			ret = obj.offsetMax;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index offsetMax on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_reapplyDrivenProperties(IntPtr L)
	{
		ToLua.Push(L, new EventObject("UnityEngine.RectTransform.reapplyDrivenProperties"));
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_anchorMin(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);

		try
		{
			obj.anchorMin = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index anchorMin on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_anchorMax(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);

		try
		{
			obj.anchorMax = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index anchorMax on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_anchoredPosition3D(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.anchoredPosition3D = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index anchoredPosition3D on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_anchoredPosition(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);

		try
		{
			obj.anchoredPosition = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index anchoredPosition on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sizeDelta(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);

		try
		{
			obj.sizeDelta = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sizeDelta on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pivot(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);

		try
		{
			obj.pivot = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index pivot on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_offsetMin(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);

		try
		{
			obj.offsetMin = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index offsetMin on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_offsetMax(IntPtr L)
	{
		UnityEngine.RectTransform obj = (UnityEngine.RectTransform)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);

		try
		{
			obj.offsetMax = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index offsetMax on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_reapplyDrivenProperties(IntPtr L)
	{
		EventObject arg0 = null;

		if (LuaDLL.lua_isuserdata(L, 2) != 0)
		{
			arg0 = (EventObject)ToLua.ToObject(L, 2);
		}
		else
		{
			return LuaDLL.luaL_error(L, "The event 'UnityEngine.RectTransform.reapplyDrivenProperties' can only appear on the left hand side of += or -= when used outside of the type 'UnityEngine.RectTransform'");
		}

		if (arg0.op == EventOp.Add)
		{
			UnityEngine.RectTransform.ReapplyDrivenProperties ev = (UnityEngine.RectTransform.ReapplyDrivenProperties)DelegateFactory.CreateDelegate(L, typeof(UnityEngine.RectTransform.ReapplyDrivenProperties), arg0.func);
			UnityEngine.RectTransform.reapplyDrivenProperties += ev;
		}
		else if (arg0.op == EventOp.Sub)
		{
			UnityEngine.RectTransform.ReapplyDrivenProperties ev = (UnityEngine.RectTransform.ReapplyDrivenProperties)LuaMisc.GetEventHandler(null, typeof(UnityEngine.RectTransform), "reapplyDrivenProperties");
			Delegate[] ds = ev.GetInvocationList();

			for (int i = 0; i < ds.Length; i++)
			{
				ev = (UnityEngine.RectTransform.ReapplyDrivenProperties)ds[i];
				LuaDelegate ld = ev.Target as LuaDelegate;

				if (ld != null && ld.func == arg0.func)
				{
					UnityEngine.RectTransform.reapplyDrivenProperties -= ev;
					ld.func.Dispose();
					break;
				}
			}

			arg0.func.Dispose();
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.RectTransform>(L, new LuaOut<UnityEngine.RectTransform>());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReapplyDrivenProperties(IntPtr L)
	{
		LuaFunction func = ToLua.CheckLuaFunction(L, 1);
		Delegate arg1 = DelegateFactory.CreateDelegate(L, typeof(UnityEngine.RectTransform.ReapplyDrivenProperties), func);
		ToLua.Push(L, arg1);
		return 1;
	}
}

