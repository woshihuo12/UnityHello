using System;
using LuaInterface;

public class UnityEngine_AudioSourceWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.AudioSource), typeof(UnityEngine.Behaviour));
		L.RegFunction("Play", Play);
		L.RegFunction("PlayDelayed", PlayDelayed);
		L.RegFunction("PlayScheduled", PlayScheduled);
		L.RegFunction("SetScheduledStartTime", SetScheduledStartTime);
		L.RegFunction("SetScheduledEndTime", SetScheduledEndTime);
		L.RegFunction("Stop", Stop);
		L.RegFunction("Pause", Pause);
		L.RegFunction("UnPause", UnPause);
		L.RegFunction("PlayOneShot", PlayOneShot);
		L.RegFunction("PlayClipAtPoint", PlayClipAtPoint);
		L.RegFunction("SetCustomCurve", SetCustomCurve);
		L.RegFunction("GetCustomCurve", GetCustomCurve);
		L.RegFunction("GetOutputData", GetOutputData);
		L.RegFunction("GetSpectrumData", GetSpectrumData);
		L.RegFunction("SetSpatializerFloat", SetSpatializerFloat);
		L.RegFunction("GetSpatializerFloat", GetSpatializerFloat);
		L.RegFunction("New", _CreateUnityEngine_AudioSource);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("volume", get_volume, set_volume);
		L.RegVar("pitch", get_pitch, set_pitch);
		L.RegVar("time", get_time, set_time);
		L.RegVar("timeSamples", get_timeSamples, set_timeSamples);
		L.RegVar("clip", get_clip, set_clip);
		L.RegVar("outputAudioMixerGroup", get_outputAudioMixerGroup, set_outputAudioMixerGroup);
		L.RegVar("isPlaying", get_isPlaying, null);
		L.RegVar("loop", get_loop, set_loop);
		L.RegVar("ignoreListenerVolume", get_ignoreListenerVolume, set_ignoreListenerVolume);
		L.RegVar("playOnAwake", get_playOnAwake, set_playOnAwake);
		L.RegVar("ignoreListenerPause", get_ignoreListenerPause, set_ignoreListenerPause);
		L.RegVar("velocityUpdateMode", get_velocityUpdateMode, set_velocityUpdateMode);
		L.RegVar("panStereo", get_panStereo, set_panStereo);
		L.RegVar("spatialBlend", get_spatialBlend, set_spatialBlend);
		L.RegVar("spatialize", get_spatialize, set_spatialize);
		L.RegVar("reverbZoneMix", get_reverbZoneMix, set_reverbZoneMix);
		L.RegVar("bypassEffects", get_bypassEffects, set_bypassEffects);
		L.RegVar("bypassListenerEffects", get_bypassListenerEffects, set_bypassListenerEffects);
		L.RegVar("bypassReverbZones", get_bypassReverbZones, set_bypassReverbZones);
		L.RegVar("dopplerLevel", get_dopplerLevel, set_dopplerLevel);
		L.RegVar("spread", get_spread, set_spread);
		L.RegVar("priority", get_priority, set_priority);
		L.RegVar("mute", get_mute, set_mute);
		L.RegVar("minDistance", get_minDistance, set_minDistance);
		L.RegVar("maxDistance", get_maxDistance, set_maxDistance);
		L.RegVar("rolloffMode", get_rolloffMode, set_rolloffMode);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_AudioSource(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.AudioSource obj = new UnityEngine.AudioSource();
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AudioSource.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Play(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AudioSource)))
		{
			UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);

			try
			{
				obj.Play();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AudioSource), typeof(ulong)))
		{
			UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
			ulong arg0 = (ulong)LuaDLL.lua_tonumber(L, 2);

			try
			{
				obj.Play(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AudioSource.Play");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayDelayed(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.CheckObject(L, 1, typeof(UnityEngine.AudioSource));
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.PlayDelayed(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayScheduled(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.CheckObject(L, 1, typeof(UnityEngine.AudioSource));
		double arg0 = (double)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.PlayScheduled(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetScheduledStartTime(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.CheckObject(L, 1, typeof(UnityEngine.AudioSource));
		double arg0 = (double)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.SetScheduledStartTime(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetScheduledEndTime(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.CheckObject(L, 1, typeof(UnityEngine.AudioSource));
		double arg0 = (double)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.SetScheduledEndTime(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Stop(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.CheckObject(L, 1, typeof(UnityEngine.AudioSource));

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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Pause(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.CheckObject(L, 1, typeof(UnityEngine.AudioSource));

		try
		{
			obj.Pause();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnPause(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.CheckObject(L, 1, typeof(UnityEngine.AudioSource));

		try
		{
			obj.UnPause();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayOneShot(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AudioSource), typeof(UnityEngine.AudioClip)))
		{
			UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
			UnityEngine.AudioClip arg0 = (UnityEngine.AudioClip)ToLua.ToObject(L, 2);

			try
			{
				obj.PlayOneShot(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AudioSource), typeof(UnityEngine.AudioClip), typeof(float)))
		{
			UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
			UnityEngine.AudioClip arg0 = (UnityEngine.AudioClip)ToLua.ToObject(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);

			try
			{
				obj.PlayOneShot(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AudioSource.PlayOneShot");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayClipAtPoint(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AudioClip), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.AudioClip arg0 = (UnityEngine.AudioClip)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 2);

			try
			{
				UnityEngine.AudioSource.PlayClipAtPoint(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.AudioClip), typeof(UnityEngine.Vector3), typeof(float)))
		{
			UnityEngine.AudioClip arg0 = (UnityEngine.AudioClip)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);

			try
			{
				UnityEngine.AudioSource.PlayClipAtPoint(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.AudioSource.PlayClipAtPoint");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetCustomCurve(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.CheckObject(L, 1, typeof(UnityEngine.AudioSource));
		UnityEngine.AudioSourceCurveType arg0 = (UnityEngine.AudioSourceCurveType)ToLua.CheckObject(L, 2, typeof(UnityEngine.AudioSourceCurveType));
		UnityEngine.AnimationCurve arg1 = (UnityEngine.AnimationCurve)ToLua.CheckObject(L, 3, typeof(UnityEngine.AnimationCurve));

		try
		{
			obj.SetCustomCurve(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetCustomCurve(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.CheckObject(L, 1, typeof(UnityEngine.AudioSource));
		UnityEngine.AudioSourceCurveType arg0 = (UnityEngine.AudioSourceCurveType)ToLua.CheckObject(L, 2, typeof(UnityEngine.AudioSourceCurveType));
		UnityEngine.AnimationCurve o = null;

		try
		{
			o = obj.GetCustomCurve(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetOutputData(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.CheckObject(L, 1, typeof(UnityEngine.AudioSource));
		float[] arg0 = ToLua.CheckNumberArray<float>(L, 2);
		int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);

		try
		{
			obj.GetOutputData(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSpectrumData(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 4);
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.CheckObject(L, 1, typeof(UnityEngine.AudioSource));
		float[] arg0 = ToLua.CheckNumberArray<float>(L, 2);
		int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
		UnityEngine.FFTWindow arg2 = (UnityEngine.FFTWindow)ToLua.CheckObject(L, 4, typeof(UnityEngine.FFTWindow));

		try
		{
			obj.GetSpectrumData(arg0, arg1, arg2);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetSpatializerFloat(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.CheckObject(L, 1, typeof(UnityEngine.AudioSource));
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
		bool o;

		try
		{
			o = obj.SetSpatializerFloat(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSpatializerFloat(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.CheckObject(L, 1, typeof(UnityEngine.AudioSource));
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		float arg1;
		bool o;

		try
		{
			o = obj.GetSpatializerFloat(arg0, out arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
		LuaDLL.lua_pushnumber(L, arg1);
		return 2;
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
	static int get_volume(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.volume;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index volume on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pitch(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.pitch;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index pitch on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_time(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.time;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index time on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_timeSamples(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.timeSamples;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index timeSamples on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_clip(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		UnityEngine.AudioClip ret = null;

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
	static int get_outputAudioMixerGroup(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		UnityEngine.Audio.AudioMixerGroup ret = null;

		try
		{
			ret = obj.outputAudioMixerGroup;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index outputAudioMixerGroup on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPlaying(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
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
	static int get_loop(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.loop;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index loop on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ignoreListenerVolume(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.ignoreListenerVolume;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index ignoreListenerVolume on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_playOnAwake(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.playOnAwake;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index playOnAwake on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ignoreListenerPause(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.ignoreListenerPause;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index ignoreListenerPause on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_velocityUpdateMode(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		UnityEngine.AudioVelocityUpdateMode ret;

		try
		{
			ret = obj.velocityUpdateMode;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index velocityUpdateMode on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_panStereo(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.panStereo;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index panStereo on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spatialBlend(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.spatialBlend;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index spatialBlend on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spatialize(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.spatialize;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index spatialize on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_reverbZoneMix(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.reverbZoneMix;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index reverbZoneMix on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bypassEffects(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.bypassEffects;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index bypassEffects on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bypassListenerEffects(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.bypassListenerEffects;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index bypassListenerEffects on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bypassReverbZones(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.bypassReverbZones;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index bypassReverbZones on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dopplerLevel(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.dopplerLevel;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index dopplerLevel on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spread(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.spread;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index spread on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_priority(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.priority;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index priority on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mute(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.mute;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mute on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_minDistance(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.minDistance;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index minDistance on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxDistance(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.maxDistance;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index maxDistance on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rolloffMode(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		UnityEngine.AudioRolloffMode ret;

		try
		{
			ret = obj.rolloffMode;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index rolloffMode on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_volume(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.volume = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index volume on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pitch(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.pitch = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index pitch on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_time(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.time = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index time on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_timeSamples(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.timeSamples = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index timeSamples on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_clip(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		UnityEngine.AudioClip arg0 = (UnityEngine.AudioClip)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.AudioClip));

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
	static int set_outputAudioMixerGroup(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		UnityEngine.Audio.AudioMixerGroup arg0 = (UnityEngine.Audio.AudioMixerGroup)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Audio.AudioMixerGroup));

		try
		{
			obj.outputAudioMixerGroup = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index outputAudioMixerGroup on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_loop(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.loop = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index loop on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ignoreListenerVolume(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.ignoreListenerVolume = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index ignoreListenerVolume on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_playOnAwake(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.playOnAwake = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index playOnAwake on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ignoreListenerPause(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.ignoreListenerPause = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index ignoreListenerPause on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_velocityUpdateMode(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		UnityEngine.AudioVelocityUpdateMode arg0 = (UnityEngine.AudioVelocityUpdateMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.AudioVelocityUpdateMode));

		try
		{
			obj.velocityUpdateMode = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index velocityUpdateMode on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_panStereo(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.panStereo = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index panStereo on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spatialBlend(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.spatialBlend = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index spatialBlend on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spatialize(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.spatialize = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index spatialize on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_reverbZoneMix(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.reverbZoneMix = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index reverbZoneMix on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bypassEffects(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.bypassEffects = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index bypassEffects on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bypassListenerEffects(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.bypassListenerEffects = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index bypassListenerEffects on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bypassReverbZones(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.bypassReverbZones = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index bypassReverbZones on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dopplerLevel(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.dopplerLevel = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index dopplerLevel on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spread(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.spread = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index spread on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_priority(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.priority = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index priority on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mute(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.mute = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mute on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_minDistance(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.minDistance = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index minDistance on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxDistance(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.maxDistance = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index maxDistance on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rolloffMode(IntPtr L)
	{
		UnityEngine.AudioSource obj = (UnityEngine.AudioSource)ToLua.ToObject(L, 1);
		UnityEngine.AudioRolloffMode arg0 = (UnityEngine.AudioRolloffMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.AudioRolloffMode));

		try
		{
			obj.rolloffMode = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index rolloffMode on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.AudioSource>(L, new LuaOut<UnityEngine.AudioSource>());
		return 1;
	}
}

