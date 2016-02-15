using System;
using LuaInterface;

public class UnityEngine_ParticleSystemWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.ParticleSystem), typeof(UnityEngine.Component));
		L.RegFunction("SetParticles", SetParticles);
		L.RegFunction("GetParticles", GetParticles);
		L.RegFunction("Simulate", Simulate);
		L.RegFunction("Play", Play);
		L.RegFunction("Stop", Stop);
		L.RegFunction("Pause", Pause);
		L.RegFunction("Clear", Clear);
		L.RegFunction("IsAlive", IsAlive);
		L.RegFunction("Emit", Emit);
		L.RegFunction("New", _CreateUnityEngine_ParticleSystem);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("startDelay", get_startDelay, set_startDelay);
		L.RegVar("isPlaying", get_isPlaying, null);
		L.RegVar("isStopped", get_isStopped, null);
		L.RegVar("isPaused", get_isPaused, null);
		L.RegVar("loop", get_loop, set_loop);
		L.RegVar("playOnAwake", get_playOnAwake, set_playOnAwake);
		L.RegVar("time", get_time, set_time);
		L.RegVar("duration", get_duration, null);
		L.RegVar("playbackSpeed", get_playbackSpeed, set_playbackSpeed);
		L.RegVar("particleCount", get_particleCount, null);
		L.RegVar("startSpeed", get_startSpeed, set_startSpeed);
		L.RegVar("startSize", get_startSize, set_startSize);
		L.RegVar("startColor", get_startColor, set_startColor);
		L.RegVar("startRotation", get_startRotation, set_startRotation);
		L.RegVar("startRotation3D", get_startRotation3D, set_startRotation3D);
		L.RegVar("startLifetime", get_startLifetime, set_startLifetime);
		L.RegVar("gravityModifier", get_gravityModifier, set_gravityModifier);
		L.RegVar("maxParticles", get_maxParticles, set_maxParticles);
		L.RegVar("simulationSpace", get_simulationSpace, set_simulationSpace);
		L.RegVar("scalingMode", get_scalingMode, set_scalingMode);
		L.RegVar("randomSeed", get_randomSeed, set_randomSeed);
		L.RegVar("emission", get_emission, null);
		L.RegVar("shape", get_shape, null);
		L.RegVar("velocityOverLifetime", get_velocityOverLifetime, null);
		L.RegVar("limitVelocityOverLifetime", get_limitVelocityOverLifetime, null);
		L.RegVar("inheritVelocity", get_inheritVelocity, null);
		L.RegVar("forceOverLifetime", get_forceOverLifetime, null);
		L.RegVar("colorOverLifetime", get_colorOverLifetime, null);
		L.RegVar("colorBySpeed", get_colorBySpeed, null);
		L.RegVar("sizeOverLifetime", get_sizeOverLifetime, null);
		L.RegVar("sizeBySpeed", get_sizeBySpeed, null);
		L.RegVar("rotationOverLifetime", get_rotationOverLifetime, null);
		L.RegVar("rotationBySpeed", get_rotationBySpeed, null);
		L.RegVar("externalForces", get_externalForces, null);
		L.RegVar("collision", get_collision, null);
		L.RegVar("subEmitters", get_subEmitters, null);
		L.RegVar("textureSheetAnimation", get_textureSheetAnimation, null);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_ParticleSystem(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.ParticleSystem obj = new UnityEngine.ParticleSystem();
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.ParticleSystem.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetParticles(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.CheckObject(L, 1, typeof(UnityEngine.ParticleSystem));
		UnityEngine.ParticleSystem.Particle[] arg0 = ToLua.CheckObjectArray<UnityEngine.ParticleSystem.Particle>(L, 2);
		int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);

		try
		{
			obj.SetParticles(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetParticles(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.CheckObject(L, 1, typeof(UnityEngine.ParticleSystem));
		UnityEngine.ParticleSystem.Particle[] arg0 = ToLua.CheckObjectArray<UnityEngine.ParticleSystem.Particle>(L, 2);
		int o;

		try
		{
			o = obj.GetParticles(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushinteger(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Simulate(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.ParticleSystem), typeof(float)))
		{
			UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);

			try
			{
				obj.Simulate(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.ParticleSystem), typeof(float), typeof(bool)))
		{
			UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			bool arg1 = LuaDLL.lua_toboolean(L, 3);

			try
			{
				obj.Simulate(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.ParticleSystem), typeof(float), typeof(bool), typeof(bool)))
		{
			UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			bool arg1 = LuaDLL.lua_toboolean(L, 3);
			bool arg2 = LuaDLL.lua_toboolean(L, 4);

			try
			{
				obj.Simulate(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.ParticleSystem.Simulate");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Play(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.ParticleSystem)))
		{
			UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);

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
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.ParticleSystem), typeof(bool)))
		{
			UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
			bool arg0 = LuaDLL.lua_toboolean(L, 2);

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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.ParticleSystem.Play");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Stop(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.ParticleSystem)))
		{
			UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);

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
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.ParticleSystem), typeof(bool)))
		{
			UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
			bool arg0 = LuaDLL.lua_toboolean(L, 2);

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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.ParticleSystem.Stop");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Pause(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.ParticleSystem)))
		{
			UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);

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
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.ParticleSystem), typeof(bool)))
		{
			UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
			bool arg0 = LuaDLL.lua_toboolean(L, 2);

			try
			{
				obj.Pause(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.ParticleSystem.Pause");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.ParticleSystem)))
		{
			UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);

			try
			{
				obj.Clear();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.ParticleSystem), typeof(bool)))
		{
			UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
			bool arg0 = LuaDLL.lua_toboolean(L, 2);

			try
			{
				obj.Clear(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.ParticleSystem.Clear");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsAlive(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.ParticleSystem)))
		{
			UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
			bool o;

			try
			{
				o = obj.IsAlive();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.ParticleSystem), typeof(bool)))
		{
			UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
			bool arg0 = LuaDLL.lua_toboolean(L, 2);
			bool o;

			try
			{
				o = obj.IsAlive(arg0);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.ParticleSystem.IsAlive");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Emit(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.ParticleSystem), typeof(int)))
		{
			UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);

			try
			{
				obj.Emit(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.ParticleSystem), typeof(UnityEngine.ParticleSystem.EmitParams), typeof(int)))
		{
			UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
			UnityEngine.ParticleSystem.EmitParams arg0 = (UnityEngine.ParticleSystem.EmitParams)ToLua.ToObject(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);

			try
			{
				obj.Emit(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.ParticleSystem.Emit");
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
	static int get_startDelay(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.startDelay;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index startDelay on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPlaying(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
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
	static int get_isStopped(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.isStopped;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isStopped on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPaused(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.isPaused;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isPaused on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_loop(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
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
	static int get_playOnAwake(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
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
	static int get_time(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
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
	static int get_duration(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.duration;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index duration on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_playbackSpeed(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.playbackSpeed;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index playbackSpeed on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_particleCount(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.particleCount;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index particleCount on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_startSpeed(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.startSpeed;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index startSpeed on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_startSize(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.startSize;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index startSize on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_startColor(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.Color ret;

		try
		{
			ret = obj.startColor;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index startColor on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_startRotation(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.startRotation;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index startRotation on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_startRotation3D(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.startRotation3D;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index startRotation3D on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_startLifetime(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.startLifetime;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index startLifetime on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gravityModifier(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.gravityModifier;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index gravityModifier on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxParticles(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.maxParticles;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index maxParticles on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_simulationSpace(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystemSimulationSpace ret;

		try
		{
			ret = obj.simulationSpace;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index simulationSpace on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scalingMode(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystemScalingMode ret;

		try
		{
			ret = obj.scalingMode;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index scalingMode on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_randomSeed(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		uint ret;

		try
		{
			ret = obj.randomSeed;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index randomSeed on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_emission(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystem.EmissionModule ret;

		try
		{
			ret = obj.emission;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index emission on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shape(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystem.ShapeModule ret;

		try
		{
			ret = obj.shape;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index shape on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_velocityOverLifetime(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystem.VelocityOverLifetimeModule ret;

		try
		{
			ret = obj.velocityOverLifetime;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index velocityOverLifetime on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_limitVelocityOverLifetime(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule ret;

		try
		{
			ret = obj.limitVelocityOverLifetime;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index limitVelocityOverLifetime on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_inheritVelocity(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystem.InheritVelocityModule ret;

		try
		{
			ret = obj.inheritVelocity;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index inheritVelocity on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_forceOverLifetime(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystem.ForceOverLifetimeModule ret;

		try
		{
			ret = obj.forceOverLifetime;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index forceOverLifetime on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_colorOverLifetime(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystem.ColorOverLifetimeModule ret;

		try
		{
			ret = obj.colorOverLifetime;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index colorOverLifetime on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_colorBySpeed(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystem.ColorBySpeedModule ret;

		try
		{
			ret = obj.colorBySpeed;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index colorBySpeed on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sizeOverLifetime(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystem.SizeOverLifetimeModule ret;

		try
		{
			ret = obj.sizeOverLifetime;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sizeOverLifetime on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sizeBySpeed(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystem.SizeBySpeedModule ret;

		try
		{
			ret = obj.sizeBySpeed;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sizeBySpeed on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotationOverLifetime(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystem.RotationOverLifetimeModule ret;

		try
		{
			ret = obj.rotationOverLifetime;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index rotationOverLifetime on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotationBySpeed(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystem.RotationBySpeedModule ret;

		try
		{
			ret = obj.rotationBySpeed;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index rotationBySpeed on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_externalForces(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystem.ExternalForcesModule ret;

		try
		{
			ret = obj.externalForces;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index externalForces on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_collision(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystem.CollisionModule ret;

		try
		{
			ret = obj.collision;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index collision on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_subEmitters(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystem.SubEmittersModule ret;

		try
		{
			ret = obj.subEmitters;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index subEmitters on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_textureSheetAnimation(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystem.TextureSheetAnimationModule ret;

		try
		{
			ret = obj.textureSheetAnimation;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index textureSheetAnimation on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_startDelay(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.startDelay = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index startDelay on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_loop(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
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
	static int set_playOnAwake(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
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
	static int set_time(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
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
	static int set_playbackSpeed(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.playbackSpeed = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index playbackSpeed on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_startSpeed(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.startSpeed = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index startSpeed on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_startSize(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.startSize = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index startSize on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_startColor(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.Color arg0 = ToLua.ToColor(L, 2);

		try
		{
			obj.startColor = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index startColor on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_startRotation(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.startRotation = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index startRotation on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_startRotation3D(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.startRotation3D = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index startRotation3D on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_startLifetime(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.startLifetime = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index startLifetime on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_gravityModifier(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.gravityModifier = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index gravityModifier on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxParticles(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.maxParticles = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index maxParticles on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_simulationSpace(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystemSimulationSpace arg0 = (UnityEngine.ParticleSystemSimulationSpace)ToLua.CheckObject(L, 2, typeof(UnityEngine.ParticleSystemSimulationSpace));

		try
		{
			obj.simulationSpace = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index simulationSpace on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_scalingMode(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		UnityEngine.ParticleSystemScalingMode arg0 = (UnityEngine.ParticleSystemScalingMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.ParticleSystemScalingMode));

		try
		{
			obj.scalingMode = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index scalingMode on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_randomSeed(IntPtr L)
	{
		UnityEngine.ParticleSystem obj = (UnityEngine.ParticleSystem)ToLua.ToObject(L, 1);
		uint arg0 = (uint)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.randomSeed = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index randomSeed on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.ParticleSystem>(L, new LuaOut<UnityEngine.ParticleSystem>());
		return 1;
	}
}

