using System;
using LuaInterface;

public class UnityEngine_UI_SelectableWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.UI.Selectable), typeof(UnityEngine.EventSystems.UIBehaviour));
		L.RegFunction("IsInteractable", IsInteractable);
		L.RegFunction("FindSelectable", FindSelectable);
		L.RegFunction("FindSelectableOnLeft", FindSelectableOnLeft);
		L.RegFunction("FindSelectableOnRight", FindSelectableOnRight);
		L.RegFunction("FindSelectableOnUp", FindSelectableOnUp);
		L.RegFunction("FindSelectableOnDown", FindSelectableOnDown);
		L.RegFunction("OnMove", OnMove);
		L.RegFunction("OnPointerDown", OnPointerDown);
		L.RegFunction("OnPointerUp", OnPointerUp);
		L.RegFunction("OnPointerEnter", OnPointerEnter);
		L.RegFunction("OnPointerExit", OnPointerExit);
		L.RegFunction("OnSelect", OnSelect);
		L.RegFunction("OnDeselect", OnDeselect);
		L.RegFunction("Select", Select);
		L.RegFunction("New", _CreateUnityEngine_UI_Selectable);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("allSelectables", get_allSelectables, null);
		L.RegVar("navigation", get_navigation, set_navigation);
		L.RegVar("transition", get_transition, set_transition);
		L.RegVar("colors", get_colors, set_colors);
		L.RegVar("spriteState", get_spriteState, set_spriteState);
		L.RegVar("animationTriggers", get_animationTriggers, set_animationTriggers);
		L.RegVar("targetGraphic", get_targetGraphic, set_targetGraphic);
		L.RegVar("interactable", get_interactable, set_interactable);
		L.RegVar("image", get_image, set_image);
		L.RegVar("animator", get_animator, null);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_UI_Selectable(IntPtr L)
	{
		return LuaDLL.luaL_error(L, "UnityEngine.UI.Selectable class does not have a constructor function");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsInteractable(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Selectable));
		bool o;

		try
		{
			o = obj.IsInteractable();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindSelectable(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Selectable));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.UI.Selectable o = null;

		try
		{
			o = obj.FindSelectable(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindSelectableOnLeft(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Selectable));
		UnityEngine.UI.Selectable o = null;

		try
		{
			o = obj.FindSelectableOnLeft();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindSelectableOnRight(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Selectable));
		UnityEngine.UI.Selectable o = null;

		try
		{
			o = obj.FindSelectableOnRight();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindSelectableOnUp(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Selectable));
		UnityEngine.UI.Selectable o = null;

		try
		{
			o = obj.FindSelectableOnUp();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindSelectableOnDown(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Selectable));
		UnityEngine.UI.Selectable o = null;

		try
		{
			o = obj.FindSelectableOnDown();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnMove(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Selectable));
		UnityEngine.EventSystems.AxisEventData arg0 = (UnityEngine.EventSystems.AxisEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.AxisEventData));

		try
		{
			obj.OnMove(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerDown(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Selectable));
		UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));

		try
		{
			obj.OnPointerDown(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerUp(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Selectable));
		UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));

		try
		{
			obj.OnPointerUp(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerEnter(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Selectable));
		UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));

		try
		{
			obj.OnPointerEnter(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerExit(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Selectable));
		UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));

		try
		{
			obj.OnPointerExit(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnSelect(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Selectable));
		UnityEngine.EventSystems.BaseEventData arg0 = (UnityEngine.EventSystems.BaseEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.BaseEventData));

		try
		{
			obj.OnSelect(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDeselect(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Selectable));
		UnityEngine.EventSystems.BaseEventData arg0 = (UnityEngine.EventSystems.BaseEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.BaseEventData));

		try
		{
			obj.OnDeselect(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Select(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Selectable));

		try
		{
			obj.Select();
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
	static int get_allSelectables(IntPtr L)
	{
		ToLua.PushObject(L, UnityEngine.UI.Selectable.allSelectables);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_navigation(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		UnityEngine.UI.Navigation ret;

		try
		{
			ret = obj.navigation;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index navigation on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_transition(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		UnityEngine.UI.Selectable.Transition ret;

		try
		{
			ret = obj.transition;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index transition on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_colors(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		UnityEngine.UI.ColorBlock ret;

		try
		{
			ret = obj.colors;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index colors on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spriteState(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		UnityEngine.UI.SpriteState ret;

		try
		{
			ret = obj.spriteState;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index spriteState on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animationTriggers(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		UnityEngine.UI.AnimationTriggers ret = null;

		try
		{
			ret = obj.animationTriggers;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index animationTriggers on a nil value" : e.Message);
		}

		ToLua.PushObject(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_targetGraphic(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		UnityEngine.UI.Graphic ret = null;

		try
		{
			ret = obj.targetGraphic;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index targetGraphic on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_interactable(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.interactable;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index interactable on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_image(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		UnityEngine.UI.Image ret = null;

		try
		{
			ret = obj.image;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index image on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animator(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		UnityEngine.Animator ret = null;

		try
		{
			ret = obj.animator;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index animator on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_navigation(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		UnityEngine.UI.Navigation arg0 = (UnityEngine.UI.Navigation)ToLua.CheckObject(L, 2, typeof(UnityEngine.UI.Navigation));

		try
		{
			obj.navigation = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index navigation on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_transition(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		UnityEngine.UI.Selectable.Transition arg0 = (UnityEngine.UI.Selectable.Transition)ToLua.CheckObject(L, 2, typeof(UnityEngine.UI.Selectable.Transition));

		try
		{
			obj.transition = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index transition on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_colors(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		UnityEngine.UI.ColorBlock arg0 = (UnityEngine.UI.ColorBlock)ToLua.CheckObject(L, 2, typeof(UnityEngine.UI.ColorBlock));

		try
		{
			obj.colors = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index colors on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spriteState(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		UnityEngine.UI.SpriteState arg0 = (UnityEngine.UI.SpriteState)ToLua.CheckObject(L, 2, typeof(UnityEngine.UI.SpriteState));

		try
		{
			obj.spriteState = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index spriteState on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_animationTriggers(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		UnityEngine.UI.AnimationTriggers arg0 = (UnityEngine.UI.AnimationTriggers)ToLua.CheckObject(L, 2, typeof(UnityEngine.UI.AnimationTriggers));

		try
		{
			obj.animationTriggers = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index animationTriggers on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_targetGraphic(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		UnityEngine.UI.Graphic arg0 = (UnityEngine.UI.Graphic)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.UI.Graphic));

		try
		{
			obj.targetGraphic = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index targetGraphic on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_interactable(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.interactable = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index interactable on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_image(IntPtr L)
	{
		UnityEngine.UI.Selectable obj = (UnityEngine.UI.Selectable)ToLua.ToObject(L, 1);
		UnityEngine.UI.Image arg0 = (UnityEngine.UI.Image)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.UI.Image));

		try
		{
			obj.image = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index image on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.UI.Selectable>(L, new LuaOut<UnityEngine.UI.Selectable>());
		return 1;
	}
}

