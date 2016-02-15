using System;
using LuaInterface;

public class UnityEngine_AnimationWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Animation), typeof(UnityEngine.Behaviour));
		L.RegFunction("Stop", Stop);
		L.RegFunction("Rewind", Rewind);
		L.RegFunction("Sample", Sample);
		L.RegFunction("IsPlaying", IsPlaying);
		L.RegFunction("get_Item", get_Item);
		L.RegFunction("Play", Play);
		L.RegFunction("CrossFade", CrossFade);
		L.RegFunction("Blend", Blend);
		L.RegFunction("CrossFadeQueued", CrossFadeQueued);
		L.RegFunction("PlayQueued", PlayQueued);
		L.RegFunction("AddClip", AddClip);
		L.RegFunction("RemoveClip", RemoveClip);
		L.RegFunction("GetClipCount", GetClipCount);
		L.RegFunction("SyncLayer", SyncLayer);
		L.RegFunction("GetEnumerator", GetEnumerator);
		L.RegFunction("GetClip", GetClip);
		L.RegFunction("New", _CreateUnityEngine_Animation);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("clip", get_clip, set_clip);
		L.RegVar("playAutomatically", get_playAutomatically, set_playAutomatically);
		L.RegVar("wrapMode", get_wrapMode, set_wrapMode);
		L.RegVar("isPlaying", get_isPlaying, null);
		L.RegVar("animatePhysics", get_animatePhysics, set_animatePhysics);
		L.RegVar("cullingType", get_cullingType, set_cullingType);
		L.RegVar("localBounds", get_localBounds, set_localBounds);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Animation(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.Animation obj = new UnityEngine.Animation();
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Animation.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Stop(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);

			try
			{
				obj.Stop();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);

			try
			{
				obj.Stop(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Animation.Stop");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Rewind(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);

			try
			{
				obj.Rewind();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);

			try
			{
				obj.Rewind(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Animation.Rewind");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Sample(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.CheckObject(L, 1, typeof(UnityEngine.Animation));

		try
		{
			obj.Sample();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsPlaying(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.CheckObject(L, 1, typeof(UnityEngine.Animation));
		string arg0 = ToLua.CheckString(L, 2);
		bool o;

		try
		{
			o = obj.IsPlaying(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Item(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.CheckObject(L, 1, typeof(UnityEngine.Animation));
		string arg0 = ToLua.CheckString(L, 2);
		UnityEngine.AnimationState o = null;

		try
		{
			o = obj[arg0];
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Play(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			bool o;

			try
			{
				o = obj.Play();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			bool o;

			try
			{
				o = obj.Play(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(UnityEngine.PlayMode)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			UnityEngine.PlayMode arg0 = (UnityEngine.PlayMode)ToLua.ToObject(L, 2);
			bool o;

			try
			{
				o = obj.Play(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string), typeof(UnityEngine.PlayMode)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.PlayMode arg1 = (UnityEngine.PlayMode)ToLua.ToObject(L, 3);
			bool o;

			try
			{
				o = obj.Play(arg0, arg1);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Animation.Play");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CrossFade(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);

			try
			{
				obj.CrossFade(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string), typeof(float)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);

			try
			{
				obj.CrossFade(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string), typeof(float), typeof(UnityEngine.PlayMode)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			UnityEngine.PlayMode arg2 = (UnityEngine.PlayMode)ToLua.ToObject(L, 4);

			try
			{
				obj.CrossFade(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Animation.CrossFade");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Blend(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);

			try
			{
				obj.Blend(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string), typeof(float)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);

			try
			{
				obj.Blend(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string), typeof(float), typeof(float)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);

			try
			{
				obj.Blend(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Animation.Blend");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CrossFadeQueued(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.AnimationState o = null;

			try
			{
				o = obj.CrossFadeQueued(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string), typeof(float)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			UnityEngine.AnimationState o = null;

			try
			{
				o = obj.CrossFadeQueued(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string), typeof(float), typeof(UnityEngine.QueueMode)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			UnityEngine.QueueMode arg2 = (UnityEngine.QueueMode)ToLua.ToObject(L, 4);
			UnityEngine.AnimationState o = null;

			try
			{
				o = obj.CrossFadeQueued(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string), typeof(float), typeof(UnityEngine.QueueMode), typeof(UnityEngine.PlayMode)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			UnityEngine.QueueMode arg2 = (UnityEngine.QueueMode)ToLua.ToObject(L, 4);
			UnityEngine.PlayMode arg3 = (UnityEngine.PlayMode)ToLua.ToObject(L, 5);
			UnityEngine.AnimationState o = null;

			try
			{
				o = obj.CrossFadeQueued(arg0, arg1, arg2, arg3);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Animation.CrossFadeQueued");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayQueued(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.AnimationState o = null;

			try
			{
				o = obj.PlayQueued(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string), typeof(UnityEngine.QueueMode)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.QueueMode arg1 = (UnityEngine.QueueMode)ToLua.ToObject(L, 3);
			UnityEngine.AnimationState o = null;

			try
			{
				o = obj.PlayQueued(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string), typeof(UnityEngine.QueueMode), typeof(UnityEngine.PlayMode)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.QueueMode arg1 = (UnityEngine.QueueMode)ToLua.ToObject(L, 3);
			UnityEngine.PlayMode arg2 = (UnityEngine.PlayMode)ToLua.ToObject(L, 4);
			UnityEngine.AnimationState o = null;

			try
			{
				o = obj.PlayQueued(arg0, arg1, arg2);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Animation.PlayQueued");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddClip(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(UnityEngine.AnimationClip), typeof(string)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip arg0 = (UnityEngine.AnimationClip)ToLua.ToObject(L, 2);
			string arg1 = ToLua.ToString(L, 3);

			try
			{
				obj.AddClip(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(UnityEngine.AnimationClip), typeof(string), typeof(int), typeof(int)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip arg0 = (UnityEngine.AnimationClip)ToLua.ToObject(L, 2);
			string arg1 = ToLua.ToString(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 5);

			try
			{
				obj.AddClip(arg0, arg1, arg2, arg3);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 6 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(UnityEngine.AnimationClip), typeof(string), typeof(int), typeof(int), typeof(bool)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip arg0 = (UnityEngine.AnimationClip)ToLua.ToObject(L, 2);
			string arg1 = ToLua.ToString(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 5);
			bool arg4 = LuaDLL.lua_toboolean(L, 6);

			try
			{
				obj.AddClip(arg0, arg1, arg2, arg3, arg4);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Animation.AddClip");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveClip(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(string)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);

			try
			{
				obj.RemoveClip(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Animation), typeof(UnityEngine.AnimationClip)))
		{
			UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip arg0 = (UnityEngine.AnimationClip)ToLua.ToObject(L, 2);

			try
			{
				obj.RemoveClip(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Animation.RemoveClip");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClipCount(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.CheckObject(L, 1, typeof(UnityEngine.Animation));
		int o;

		try
		{
			o = obj.GetClipCount();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushinteger(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SyncLayer(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.CheckObject(L, 1, typeof(UnityEngine.Animation));
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.SyncLayer(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEnumerator(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.CheckObject(L, 1, typeof(UnityEngine.Animation));
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
	static int GetClip(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.CheckObject(L, 1, typeof(UnityEngine.Animation));
		string arg0 = ToLua.CheckString(L, 2);
		UnityEngine.AnimationClip o = null;

		try
		{
			o = obj.GetClip(arg0);
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
	static int get_clip(IntPtr L)
	{
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
		UnityEngine.AnimationClip ret = null;

		try
		{
			ret = obj.clip;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index clip on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_playAutomatically(IntPtr L)
	{
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.playAutomatically;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index playAutomatically on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_wrapMode(IntPtr L)
	{
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
		UnityEngine.WrapMode ret;

		try
		{
			ret = obj.wrapMode;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index wrapMode on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPlaying(IntPtr L)
	{
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.isPlaying;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isPlaying on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animatePhysics(IntPtr L)
	{
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.animatePhysics;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index animatePhysics on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cullingType(IntPtr L)
	{
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
		UnityEngine.AnimationCullingType ret;

		try
		{
			ret = obj.cullingType;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index cullingType on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localBounds(IntPtr L)
	{
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
		UnityEngine.Bounds ret;

		try
		{
			ret = obj.localBounds;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index localBounds on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_clip(IntPtr L)
	{
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
		UnityEngine.AnimationClip arg0 = (UnityEngine.AnimationClip)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.AnimationClip));

		try
		{
			obj.clip = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index clip on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_playAutomatically(IntPtr L)
	{
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.playAutomatically = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index playAutomatically on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_wrapMode(IntPtr L)
	{
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
		UnityEngine.WrapMode arg0 = (UnityEngine.WrapMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.WrapMode));

		try
		{
			obj.wrapMode = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index wrapMode on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_animatePhysics(IntPtr L)
	{
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.animatePhysics = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index animatePhysics on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cullingType(IntPtr L)
	{
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
		UnityEngine.AnimationCullingType arg0 = (UnityEngine.AnimationCullingType)ToLua.CheckObject(L, 2, typeof(UnityEngine.AnimationCullingType));

		try
		{
			obj.cullingType = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index cullingType on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localBounds(IntPtr L)
	{
		UnityEngine.Animation obj = (UnityEngine.Animation)ToLua.ToObject(L, 1);
		UnityEngine.Bounds arg0 = ToLua.ToBounds(L, 2);

		try
		{
			obj.localBounds = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index localBounds on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.Animation>(L, new LuaOut<UnityEngine.Animation>());
		return 1;
	}
}

