using System;
using LuaInterface;

public class UnityEngine_UI_GraphicWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.UI.Graphic), typeof(UnityEngine.EventSystems.UIBehaviour));
		L.RegFunction("SetAllDirty", SetAllDirty);
		L.RegFunction("SetLayoutDirty", SetLayoutDirty);
		L.RegFunction("SetVerticesDirty", SetVerticesDirty);
		L.RegFunction("SetMaterialDirty", SetMaterialDirty);
		L.RegFunction("Rebuild", Rebuild);
		L.RegFunction("LayoutComplete", LayoutComplete);
		L.RegFunction("GraphicUpdateComplete", GraphicUpdateComplete);
		L.RegFunction("SetNativeSize", SetNativeSize);
		L.RegFunction("Raycast", Raycast);
		L.RegFunction("PixelAdjustPoint", PixelAdjustPoint);
		L.RegFunction("GetPixelAdjustedRect", GetPixelAdjustedRect);
		L.RegFunction("CrossFadeColor", CrossFadeColor);
		L.RegFunction("CrossFadeAlpha", CrossFadeAlpha);
		L.RegFunction("RegisterDirtyLayoutCallback", RegisterDirtyLayoutCallback);
		L.RegFunction("UnregisterDirtyLayoutCallback", UnregisterDirtyLayoutCallback);
		L.RegFunction("RegisterDirtyVerticesCallback", RegisterDirtyVerticesCallback);
		L.RegFunction("UnregisterDirtyVerticesCallback", UnregisterDirtyVerticesCallback);
		L.RegFunction("RegisterDirtyMaterialCallback", RegisterDirtyMaterialCallback);
		L.RegFunction("UnregisterDirtyMaterialCallback", UnregisterDirtyMaterialCallback);
		L.RegFunction("New", _CreateUnityEngine_UI_Graphic);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("defaultGraphicMaterial", get_defaultGraphicMaterial, null);
		L.RegVar("color", get_color, set_color);
		L.RegVar("raycastTarget", get_raycastTarget, set_raycastTarget);
		L.RegVar("depth", get_depth, null);
		L.RegVar("rectTransform", get_rectTransform, null);
		L.RegVar("canvas", get_canvas, null);
		L.RegVar("canvasRenderer", get_canvasRenderer, null);
		L.RegVar("defaultMaterial", get_defaultMaterial, null);
		L.RegVar("material", get_material, set_material);
		L.RegVar("materialForRendering", get_materialForRendering, null);
		L.RegVar("mainTexture", get_mainTexture, null);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_UI_Graphic(IntPtr L)
	{
		return LuaDLL.luaL_error(L, "UnityEngine.UI.Graphic class does not have a constructor function");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetAllDirty(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));

		try
		{
			obj.SetAllDirty();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLayoutDirty(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));

		try
		{
			obj.SetLayoutDirty();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetVerticesDirty(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));

		try
		{
			obj.SetVerticesDirty();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetMaterialDirty(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));

		try
		{
			obj.SetMaterialDirty();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Rebuild(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));
		UnityEngine.UI.CanvasUpdate arg0 = (UnityEngine.UI.CanvasUpdate)ToLua.CheckObject(L, 2, typeof(UnityEngine.UI.CanvasUpdate));

		try
		{
			obj.Rebuild(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LayoutComplete(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));

		try
		{
			obj.LayoutComplete();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GraphicUpdateComplete(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));

		try
		{
			obj.GraphicUpdateComplete();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetNativeSize(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));

		try
		{
			obj.SetNativeSize();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Raycast(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));
		UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
		UnityEngine.Camera arg1 = (UnityEngine.Camera)ToLua.CheckUnityObject(L, 3, typeof(UnityEngine.Camera));
		bool o;

		try
		{
			o = obj.Raycast(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PixelAdjustPoint(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));
		UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
		UnityEngine.Vector2 o;

		try
		{
			o = obj.PixelAdjustPoint(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPixelAdjustedRect(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));
		UnityEngine.Rect o;

		try
		{
			o = obj.GetPixelAdjustedRect();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CrossFadeColor(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 5);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));
		UnityEngine.Color arg0 = ToLua.ToColor(L, 2);
		float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
		bool arg2 = LuaDLL.luaL_checkboolean(L, 4);
		bool arg3 = LuaDLL.luaL_checkboolean(L, 5);

		try
		{
			obj.CrossFadeColor(arg0, arg1, arg2, arg3);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CrossFadeAlpha(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 4);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
		float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
		bool arg2 = LuaDLL.luaL_checkboolean(L, 4);

		try
		{
			obj.CrossFadeAlpha(arg0, arg1, arg2);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RegisterDirtyLayoutCallback(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));
		UnityEngine.Events.UnityAction arg0 = null;
		LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

		if (funcType2 != LuaTypes.LUA_TFUNCTION)
		{
			 arg0 = (UnityEngine.Events.UnityAction)ToLua.CheckObject(L, 2, typeof(UnityEngine.Events.UnityAction));
		}
		else
		{
			LuaFunction func = ToLua.ToLuaFunction(L, 2);
			arg0 = DelegateFactory.CreateDelegate(L, typeof(UnityEngine.Events.UnityAction), func) as UnityEngine.Events.UnityAction;
		}

		try
		{
			obj.RegisterDirtyLayoutCallback(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnregisterDirtyLayoutCallback(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));
		UnityEngine.Events.UnityAction arg0 = null;
		LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

		if (funcType2 != LuaTypes.LUA_TFUNCTION)
		{
			 arg0 = (UnityEngine.Events.UnityAction)ToLua.CheckObject(L, 2, typeof(UnityEngine.Events.UnityAction));
		}
		else
		{
			LuaFunction func = ToLua.ToLuaFunction(L, 2);
			arg0 = DelegateFactory.CreateDelegate(L, typeof(UnityEngine.Events.UnityAction), func) as UnityEngine.Events.UnityAction;
		}

		try
		{
			obj.UnregisterDirtyLayoutCallback(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RegisterDirtyVerticesCallback(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));
		UnityEngine.Events.UnityAction arg0 = null;
		LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

		if (funcType2 != LuaTypes.LUA_TFUNCTION)
		{
			 arg0 = (UnityEngine.Events.UnityAction)ToLua.CheckObject(L, 2, typeof(UnityEngine.Events.UnityAction));
		}
		else
		{
			LuaFunction func = ToLua.ToLuaFunction(L, 2);
			arg0 = DelegateFactory.CreateDelegate(L, typeof(UnityEngine.Events.UnityAction), func) as UnityEngine.Events.UnityAction;
		}

		try
		{
			obj.RegisterDirtyVerticesCallback(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnregisterDirtyVerticesCallback(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));
		UnityEngine.Events.UnityAction arg0 = null;
		LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

		if (funcType2 != LuaTypes.LUA_TFUNCTION)
		{
			 arg0 = (UnityEngine.Events.UnityAction)ToLua.CheckObject(L, 2, typeof(UnityEngine.Events.UnityAction));
		}
		else
		{
			LuaFunction func = ToLua.ToLuaFunction(L, 2);
			arg0 = DelegateFactory.CreateDelegate(L, typeof(UnityEngine.Events.UnityAction), func) as UnityEngine.Events.UnityAction;
		}

		try
		{
			obj.UnregisterDirtyVerticesCallback(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RegisterDirtyMaterialCallback(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));
		UnityEngine.Events.UnityAction arg0 = null;
		LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

		if (funcType2 != LuaTypes.LUA_TFUNCTION)
		{
			 arg0 = (UnityEngine.Events.UnityAction)ToLua.CheckObject(L, 2, typeof(UnityEngine.Events.UnityAction));
		}
		else
		{
			LuaFunction func = ToLua.ToLuaFunction(L, 2);
			arg0 = DelegateFactory.CreateDelegate(L, typeof(UnityEngine.Events.UnityAction), func) as UnityEngine.Events.UnityAction;
		}

		try
		{
			obj.RegisterDirtyMaterialCallback(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnregisterDirtyMaterialCallback(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Graphic));
		UnityEngine.Events.UnityAction arg0 = null;
		LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

		if (funcType2 != LuaTypes.LUA_TFUNCTION)
		{
			 arg0 = (UnityEngine.Events.UnityAction)ToLua.CheckObject(L, 2, typeof(UnityEngine.Events.UnityAction));
		}
		else
		{
			LuaFunction func = ToLua.ToLuaFunction(L, 2);
			arg0 = DelegateFactory.CreateDelegate(L, typeof(UnityEngine.Events.UnityAction), func) as UnityEngine.Events.UnityAction;
		}

		try
		{
			obj.UnregisterDirtyMaterialCallback(arg0);
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
	static int get_defaultGraphicMaterial(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.UI.Graphic.defaultGraphicMaterial);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_color(IntPtr L)
	{
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.ToObject(L, 1);
		UnityEngine.Color ret;

		try
		{
			ret = obj.color;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index color on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_raycastTarget(IntPtr L)
	{
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.raycastTarget;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index raycastTarget on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_depth(IntPtr L)
	{
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.depth;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index depth on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rectTransform(IntPtr L)
	{
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.ToObject(L, 1);
		UnityEngine.RectTransform ret = null;

		try
		{
			ret = obj.rectTransform;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index rectTransform on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_canvas(IntPtr L)
	{
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.ToObject(L, 1);
		UnityEngine.Canvas ret = null;

		try
		{
			ret = obj.canvas;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index canvas on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_canvasRenderer(IntPtr L)
	{
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.ToObject(L, 1);
		UnityEngine.CanvasRenderer ret = null;

		try
		{
			ret = obj.canvasRenderer;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index canvasRenderer on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_defaultMaterial(IntPtr L)
	{
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.ToObject(L, 1);
		UnityEngine.Material ret = null;

		try
		{
			ret = obj.defaultMaterial;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index defaultMaterial on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_material(IntPtr L)
	{
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.ToObject(L, 1);
		UnityEngine.Material ret = null;

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
	static int get_materialForRendering(IntPtr L)
	{
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.ToObject(L, 1);
		UnityEngine.Material ret = null;

		try
		{
			ret = obj.materialForRendering;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index materialForRendering on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainTexture(IntPtr L)
	{
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.ToObject(L, 1);
		UnityEngine.Texture ret = null;

		try
		{
			ret = obj.mainTexture;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mainTexture on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_color(IntPtr L)
	{
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.ToObject(L, 1);
		UnityEngine.Color arg0 = ToLua.ToColor(L, 2);

		try
		{
			obj.color = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index color on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_raycastTarget(IntPtr L)
	{
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.raycastTarget = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index raycastTarget on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_material(IntPtr L)
	{
		UnityEngine.UI.Graphic obj = (UnityEngine.UI.Graphic)ToLua.ToObject(L, 1);
		UnityEngine.Material arg0 = (UnityEngine.Material)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Material));

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
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.UI.Graphic>(L, new LuaOut<UnityEngine.UI.Graphic>());
		return 1;
	}
}

