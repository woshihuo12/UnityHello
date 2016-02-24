using System;
using LuaInterface;

public class UnityEngine_UI_TextWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.UI.Text), typeof(UnityEngine.UI.MaskableGraphic));
		L.RegFunction("FontTextureChanged", FontTextureChanged);
		L.RegFunction("GetGenerationSettings", GetGenerationSettings);
		L.RegFunction("GetTextAnchorPivot", GetTextAnchorPivot);
		L.RegFunction("CalculateLayoutInputHorizontal", CalculateLayoutInputHorizontal);
		L.RegFunction("CalculateLayoutInputVertical", CalculateLayoutInputVertical);
		L.RegFunction("New", _CreateUnityEngine_UI_Text);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("cachedTextGenerator", get_cachedTextGenerator, null);
		L.RegVar("cachedTextGeneratorForLayout", get_cachedTextGeneratorForLayout, null);
		L.RegVar("mainTexture", get_mainTexture, null);
		L.RegVar("font", get_font, set_font);
		L.RegVar("text", get_text, set_text);
		L.RegVar("supportRichText", get_supportRichText, set_supportRichText);
		L.RegVar("resizeTextForBestFit", get_resizeTextForBestFit, set_resizeTextForBestFit);
		L.RegVar("resizeTextMinSize", get_resizeTextMinSize, set_resizeTextMinSize);
		L.RegVar("resizeTextMaxSize", get_resizeTextMaxSize, set_resizeTextMaxSize);
		L.RegVar("alignment", get_alignment, set_alignment);
		L.RegVar("alignByGeometry", get_alignByGeometry, set_alignByGeometry);
		L.RegVar("fontSize", get_fontSize, set_fontSize);
		L.RegVar("horizontalOverflow", get_horizontalOverflow, set_horizontalOverflow);
		L.RegVar("verticalOverflow", get_verticalOverflow, set_verticalOverflow);
		L.RegVar("lineSpacing", get_lineSpacing, set_lineSpacing);
		L.RegVar("fontStyle", get_fontStyle, set_fontStyle);
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
	static int _CreateUnityEngine_UI_Text(IntPtr L)
	{
		return LuaDLL.luaL_error(L, "UnityEngine.UI.Text class does not have a constructor function");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FontTextureChanged(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Text));

		try
		{
			obj.FontTextureChanged();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetGenerationSettings(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Text));
		UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
		UnityEngine.TextGenerationSettings o;

		try
		{
			o = obj.GetGenerationSettings(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTextAnchorPivot(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.TextAnchor arg0 = (UnityEngine.TextAnchor)ToLua.CheckObject(L, 1, typeof(UnityEngine.TextAnchor));
		UnityEngine.Vector2 o;

		try
		{
			o = UnityEngine.UI.Text.GetTextAnchorPivot(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CalculateLayoutInputHorizontal(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Text));

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
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Text));

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
	static int get_cachedTextGenerator(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		UnityEngine.TextGenerator ret = null;

		try
		{
			ret = obj.cachedTextGenerator;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index cachedTextGenerator on a nil value" : e.Message);
		}

		ToLua.PushObject(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cachedTextGeneratorForLayout(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		UnityEngine.TextGenerator ret = null;

		try
		{
			ret = obj.cachedTextGeneratorForLayout;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index cachedTextGeneratorForLayout on a nil value" : e.Message);
		}

		ToLua.PushObject(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainTexture(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
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
	static int get_font(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		UnityEngine.Font ret = null;

		try
		{
			ret = obj.font;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index font on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_text(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		string ret = null;

		try
		{
			ret = obj.text;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index text on a nil value" : e.Message);
		}

		LuaDLL.lua_pushstring(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportRichText(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.supportRichText;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index supportRichText on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_resizeTextForBestFit(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.resizeTextForBestFit;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index resizeTextForBestFit on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_resizeTextMinSize(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.resizeTextMinSize;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index resizeTextMinSize on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_resizeTextMaxSize(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.resizeTextMaxSize;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index resizeTextMaxSize on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_alignment(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		UnityEngine.TextAnchor ret;

		try
		{
			ret = obj.alignment;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index alignment on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_alignByGeometry(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.alignByGeometry;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index alignByGeometry on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fontSize(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.fontSize;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index fontSize on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_horizontalOverflow(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		UnityEngine.HorizontalWrapMode ret;

		try
		{
			ret = obj.horizontalOverflow;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index horizontalOverflow on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_verticalOverflow(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		UnityEngine.VerticalWrapMode ret;

		try
		{
			ret = obj.verticalOverflow;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index verticalOverflow on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lineSpacing(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.lineSpacing;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index lineSpacing on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fontStyle(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		UnityEngine.FontStyle ret;

		try
		{
			ret = obj.fontStyle;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index fontStyle on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelsPerUnit(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
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
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
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
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
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
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
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
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
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
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
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
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
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
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
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
	static int set_font(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		UnityEngine.Font arg0 = (UnityEngine.Font)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Font));

		try
		{
			obj.font = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index font on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_text(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		string arg0 = ToLua.CheckString(L, 2);

		try
		{
			obj.text = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index text on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_supportRichText(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.supportRichText = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index supportRichText on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_resizeTextForBestFit(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.resizeTextForBestFit = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index resizeTextForBestFit on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_resizeTextMinSize(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.resizeTextMinSize = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index resizeTextMinSize on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_resizeTextMaxSize(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.resizeTextMaxSize = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index resizeTextMaxSize on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_alignment(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		UnityEngine.TextAnchor arg0 = (UnityEngine.TextAnchor)ToLua.CheckObject(L, 2, typeof(UnityEngine.TextAnchor));

		try
		{
			obj.alignment = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index alignment on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_alignByGeometry(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.alignByGeometry = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index alignByGeometry on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fontSize(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.fontSize = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index fontSize on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_horizontalOverflow(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		UnityEngine.HorizontalWrapMode arg0 = (UnityEngine.HorizontalWrapMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.HorizontalWrapMode));

		try
		{
			obj.horizontalOverflow = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index horizontalOverflow on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_verticalOverflow(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		UnityEngine.VerticalWrapMode arg0 = (UnityEngine.VerticalWrapMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.VerticalWrapMode));

		try
		{
			obj.verticalOverflow = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index verticalOverflow on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lineSpacing(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.lineSpacing = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index lineSpacing on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fontStyle(IntPtr L)
	{
		UnityEngine.UI.Text obj = (UnityEngine.UI.Text)ToLua.ToObject(L, 1);
		UnityEngine.FontStyle arg0 = (UnityEngine.FontStyle)ToLua.CheckObject(L, 2, typeof(UnityEngine.FontStyle));

		try
		{
			obj.fontStyle = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index fontStyle on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.UI.Text>(L, new LuaOut<UnityEngine.UI.Text>());
		return 1;
	}
}

