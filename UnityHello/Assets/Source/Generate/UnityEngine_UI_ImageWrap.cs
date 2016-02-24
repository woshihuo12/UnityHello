using System;
using LuaInterface;

public class UnityEngine_UI_ImageWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.UI.Image), typeof(UnityEngine.UI.MaskableGraphic));
		L.RegFunction("OnBeforeSerialize", OnBeforeSerialize);
		L.RegFunction("OnAfterDeserialize", OnAfterDeserialize);
		L.RegFunction("SetNativeSize", SetNativeSize);
		L.RegFunction("CalculateLayoutInputHorizontal", CalculateLayoutInputHorizontal);
		L.RegFunction("CalculateLayoutInputVertical", CalculateLayoutInputVertical);
		L.RegFunction("IsRaycastLocationValid", IsRaycastLocationValid);
		L.RegFunction("New", _CreateUnityEngine_UI_Image);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("sprite", get_sprite, set_sprite);
		L.RegVar("overrideSprite", get_overrideSprite, set_overrideSprite);
		L.RegVar("type", get_type, set_type);
		L.RegVar("preserveAspect", get_preserveAspect, set_preserveAspect);
		L.RegVar("fillCenter", get_fillCenter, set_fillCenter);
		L.RegVar("fillMethod", get_fillMethod, set_fillMethod);
		L.RegVar("fillAmount", get_fillAmount, set_fillAmount);
		L.RegVar("fillClockwise", get_fillClockwise, set_fillClockwise);
		L.RegVar("fillOrigin", get_fillOrigin, set_fillOrigin);
		L.RegVar("eventAlphaThreshold", get_eventAlphaThreshold, set_eventAlphaThreshold);
		L.RegVar("mainTexture", get_mainTexture, null);
		L.RegVar("hasBorder", get_hasBorder, null);
		L.RegVar("pixelsPerUnit", get_pixelsPerUnit, null);
		L.RegVar("minWidth", get_minWidth, null);
		L.RegVar("preferredWidth", get_preferredWidth, null);
		L.RegVar("flexibleWidth", get_flexibleWidth, null);
		L.RegVar("minHeight", get_minHeight, null);
		L.RegVar("preferredHeight", get_preferredHeight, null);
		L.RegVar("flexibleHeight", get_flexibleHeight, null);
		L.RegVar("layoutPriority", get_layoutPriority, null);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_UI_Image(IntPtr L)
	{
		return LuaDLL.luaL_error(L, "UnityEngine.UI.Image class does not have a constructor function");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnBeforeSerialize(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Image));

		try
		{
			obj.OnBeforeSerialize();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnAfterDeserialize(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Image));

		try
		{
			obj.OnAfterDeserialize();
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
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Image));

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
	static int CalculateLayoutInputHorizontal(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Image));

		try
		{
			obj.CalculateLayoutInputHorizontal();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CalculateLayoutInputVertical(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Image));

		try
		{
			obj.CalculateLayoutInputVertical();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsRaycastLocationValid(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Image));
		UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
		UnityEngine.Camera arg1 = (UnityEngine.Camera)ToLua.CheckUnityObject(L, 3, typeof(UnityEngine.Camera));
		bool o;

		try
		{
			o = obj.IsRaycastLocationValid(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
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
	static int get_sprite(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		UnityEngine.Sprite ret = null;

		try
		{
			ret = obj.sprite;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sprite on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_overrideSprite(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		UnityEngine.Sprite ret = null;

		try
		{
			ret = obj.overrideSprite;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index overrideSprite on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_type(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		UnityEngine.UI.Image.Type ret;

		try
		{
			ret = obj.type;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index type on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_preserveAspect(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.preserveAspect;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index preserveAspect on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fillCenter(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.fillCenter;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index fillCenter on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fillMethod(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		UnityEngine.UI.Image.FillMethod ret;

		try
		{
			ret = obj.fillMethod;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index fillMethod on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fillAmount(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.fillAmount;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index fillAmount on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fillClockwise(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.fillClockwise;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index fillClockwise on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fillOrigin(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.fillOrigin;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index fillOrigin on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_eventAlphaThreshold(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.eventAlphaThreshold;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index eventAlphaThreshold on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainTexture(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
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
	static int get_hasBorder(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.hasBorder;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index hasBorder on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelsPerUnit(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.pixelsPerUnit;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index pixelsPerUnit on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_minWidth(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.minWidth;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index minWidth on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_preferredWidth(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.preferredWidth;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index preferredWidth on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flexibleWidth(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.flexibleWidth;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index flexibleWidth on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_minHeight(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.minHeight;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index minHeight on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_preferredHeight(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.preferredHeight;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index preferredHeight on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flexibleHeight(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.flexibleHeight;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index flexibleHeight on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_layoutPriority(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.layoutPriority;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index layoutPriority on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sprite(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		UnityEngine.Sprite arg0 = (UnityEngine.Sprite)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Sprite));

		try
		{
			obj.sprite = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sprite on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_overrideSprite(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		UnityEngine.Sprite arg0 = (UnityEngine.Sprite)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Sprite));

		try
		{
			obj.overrideSprite = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index overrideSprite on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_type(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		UnityEngine.UI.Image.Type arg0 = (UnityEngine.UI.Image.Type)ToLua.CheckObject(L, 2, typeof(UnityEngine.UI.Image.Type));

		try
		{
			obj.type = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index type on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_preserveAspect(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.preserveAspect = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index preserveAspect on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fillCenter(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.fillCenter = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index fillCenter on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fillMethod(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		UnityEngine.UI.Image.FillMethod arg0 = (UnityEngine.UI.Image.FillMethod)ToLua.CheckObject(L, 2, typeof(UnityEngine.UI.Image.FillMethod));

		try
		{
			obj.fillMethod = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index fillMethod on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fillAmount(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.fillAmount = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index fillAmount on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fillClockwise(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.fillClockwise = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index fillClockwise on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fillOrigin(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.fillOrigin = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index fillOrigin on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_eventAlphaThreshold(IntPtr L)
	{
		UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.eventAlphaThreshold = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index eventAlphaThreshold on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.UI.Image>(L, new LuaOut<UnityEngine.UI.Image>());
		return 1;
	}
}

