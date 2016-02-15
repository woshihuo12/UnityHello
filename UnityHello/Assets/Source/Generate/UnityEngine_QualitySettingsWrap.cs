using System;
using LuaInterface;

public class UnityEngine_QualitySettingsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.QualitySettings), typeof(UnityEngine.Object));
		L.RegFunction("GetQualityLevel", GetQualityLevel);
		L.RegFunction("SetQualityLevel", SetQualityLevel);
		L.RegFunction("IncreaseLevel", IncreaseLevel);
		L.RegFunction("DecreaseLevel", DecreaseLevel);
		L.RegFunction("New", _CreateUnityEngine_QualitySettings);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("names", get_names, null);
		L.RegVar("pixelLightCount", get_pixelLightCount, set_pixelLightCount);
		L.RegVar("shadowProjection", get_shadowProjection, set_shadowProjection);
		L.RegVar("shadowCascades", get_shadowCascades, set_shadowCascades);
		L.RegVar("shadowDistance", get_shadowDistance, set_shadowDistance);
		L.RegVar("shadowNearPlaneOffset", get_shadowNearPlaneOffset, set_shadowNearPlaneOffset);
		L.RegVar("shadowCascade2Split", get_shadowCascade2Split, set_shadowCascade2Split);
		L.RegVar("shadowCascade4Split", get_shadowCascade4Split, set_shadowCascade4Split);
		L.RegVar("masterTextureLimit", get_masterTextureLimit, set_masterTextureLimit);
		L.RegVar("anisotropicFiltering", get_anisotropicFiltering, set_anisotropicFiltering);
		L.RegVar("lodBias", get_lodBias, set_lodBias);
		L.RegVar("maximumLODLevel", get_maximumLODLevel, set_maximumLODLevel);
		L.RegVar("particleRaycastBudget", get_particleRaycastBudget, set_particleRaycastBudget);
		L.RegVar("softVegetation", get_softVegetation, set_softVegetation);
		L.RegVar("realtimeReflectionProbes", get_realtimeReflectionProbes, set_realtimeReflectionProbes);
		L.RegVar("billboardsFaceCameraPosition", get_billboardsFaceCameraPosition, set_billboardsFaceCameraPosition);
		L.RegVar("maxQueuedFrames", get_maxQueuedFrames, set_maxQueuedFrames);
		L.RegVar("vSyncCount", get_vSyncCount, set_vSyncCount);
		L.RegVar("antiAliasing", get_antiAliasing, set_antiAliasing);
		L.RegVar("desiredColorSpace", get_desiredColorSpace, null);
		L.RegVar("activeColorSpace", get_activeColorSpace, null);
		L.RegVar("blendWeights", get_blendWeights, set_blendWeights);
		L.RegVar("asyncUploadTimeSlice", get_asyncUploadTimeSlice, set_asyncUploadTimeSlice);
		L.RegVar("asyncUploadBufferSize", get_asyncUploadBufferSize, set_asyncUploadBufferSize);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_QualitySettings(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.QualitySettings obj = new UnityEngine.QualitySettings();
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.QualitySettings.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetQualityLevel(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 0);
		int o;

		try
		{
			o = UnityEngine.QualitySettings.GetQualityLevel();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushinteger(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetQualityLevel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(int)))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);

			try
			{
				UnityEngine.QualitySettings.SetQualityLevel(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(int), typeof(bool)))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			bool arg1 = LuaDLL.lua_toboolean(L, 2);

			try
			{
				UnityEngine.QualitySettings.SetQualityLevel(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.QualitySettings.SetQualityLevel");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IncreaseLevel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			try
			{
				UnityEngine.QualitySettings.IncreaseLevel();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 1 && ToLua.CheckTypes(L, 1, typeof(bool)))
		{
			bool arg0 = LuaDLL.lua_toboolean(L, 1);

			try
			{
				UnityEngine.QualitySettings.IncreaseLevel(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.QualitySettings.IncreaseLevel");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DecreaseLevel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			try
			{
				UnityEngine.QualitySettings.DecreaseLevel();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 1 && ToLua.CheckTypes(L, 1, typeof(bool)))
		{
			bool arg0 = LuaDLL.lua_toboolean(L, 1);

			try
			{
				UnityEngine.QualitySettings.DecreaseLevel(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.QualitySettings.DecreaseLevel");
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
	static int get_names(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.QualitySettings.names);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelLightCount(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.pixelLightCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowProjection(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.QualitySettings.shadowProjection);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowCascades(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.shadowCascades);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowDistance(IntPtr L)
	{
		LuaDLL.lua_pushnumber(L, UnityEngine.QualitySettings.shadowDistance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowNearPlaneOffset(IntPtr L)
	{
		LuaDLL.lua_pushnumber(L, UnityEngine.QualitySettings.shadowNearPlaneOffset);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowCascade2Split(IntPtr L)
	{
		LuaDLL.lua_pushnumber(L, UnityEngine.QualitySettings.shadowCascade2Split);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowCascade4Split(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.QualitySettings.shadowCascade4Split);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_masterTextureLimit(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.masterTextureLimit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_anisotropicFiltering(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.QualitySettings.anisotropicFiltering);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lodBias(IntPtr L)
	{
		LuaDLL.lua_pushnumber(L, UnityEngine.QualitySettings.lodBias);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maximumLODLevel(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.maximumLODLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_particleRaycastBudget(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.particleRaycastBudget);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_softVegetation(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.QualitySettings.softVegetation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_realtimeReflectionProbes(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.QualitySettings.realtimeReflectionProbes);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_billboardsFaceCameraPosition(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.QualitySettings.billboardsFaceCameraPosition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxQueuedFrames(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.maxQueuedFrames);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_vSyncCount(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.vSyncCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_antiAliasing(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.antiAliasing);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_desiredColorSpace(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.QualitySettings.desiredColorSpace);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_activeColorSpace(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.QualitySettings.activeColorSpace);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_blendWeights(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.QualitySettings.blendWeights);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_asyncUploadTimeSlice(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.asyncUploadTimeSlice);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_asyncUploadBufferSize(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.asyncUploadBufferSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pixelLightCount(IntPtr L)
	{
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		UnityEngine.QualitySettings.pixelLightCount = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowProjection(IntPtr L)
	{
		UnityEngine.ShadowProjection arg0 = (UnityEngine.ShadowProjection)ToLua.CheckObject(L, 2, typeof(UnityEngine.ShadowProjection));
		UnityEngine.QualitySettings.shadowProjection = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowCascades(IntPtr L)
	{
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		UnityEngine.QualitySettings.shadowCascades = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowDistance(IntPtr L)
	{
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
		UnityEngine.QualitySettings.shadowDistance = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowNearPlaneOffset(IntPtr L)
	{
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
		UnityEngine.QualitySettings.shadowNearPlaneOffset = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowCascade2Split(IntPtr L)
	{
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
		UnityEngine.QualitySettings.shadowCascade2Split = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowCascade4Split(IntPtr L)
	{
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.QualitySettings.shadowCascade4Split = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_masterTextureLimit(IntPtr L)
	{
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		UnityEngine.QualitySettings.masterTextureLimit = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_anisotropicFiltering(IntPtr L)
	{
		UnityEngine.AnisotropicFiltering arg0 = (UnityEngine.AnisotropicFiltering)ToLua.CheckObject(L, 2, typeof(UnityEngine.AnisotropicFiltering));
		UnityEngine.QualitySettings.anisotropicFiltering = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lodBias(IntPtr L)
	{
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
		UnityEngine.QualitySettings.lodBias = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maximumLODLevel(IntPtr L)
	{
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		UnityEngine.QualitySettings.maximumLODLevel = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_particleRaycastBudget(IntPtr L)
	{
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		UnityEngine.QualitySettings.particleRaycastBudget = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_softVegetation(IntPtr L)
	{
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
		UnityEngine.QualitySettings.softVegetation = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_realtimeReflectionProbes(IntPtr L)
	{
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
		UnityEngine.QualitySettings.realtimeReflectionProbes = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_billboardsFaceCameraPosition(IntPtr L)
	{
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
		UnityEngine.QualitySettings.billboardsFaceCameraPosition = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxQueuedFrames(IntPtr L)
	{
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		UnityEngine.QualitySettings.maxQueuedFrames = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_vSyncCount(IntPtr L)
	{
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		UnityEngine.QualitySettings.vSyncCount = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_antiAliasing(IntPtr L)
	{
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		UnityEngine.QualitySettings.antiAliasing = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_blendWeights(IntPtr L)
	{
		UnityEngine.BlendWeights arg0 = (UnityEngine.BlendWeights)ToLua.CheckObject(L, 2, typeof(UnityEngine.BlendWeights));
		UnityEngine.QualitySettings.blendWeights = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_asyncUploadTimeSlice(IntPtr L)
	{
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		UnityEngine.QualitySettings.asyncUploadTimeSlice = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_asyncUploadBufferSize(IntPtr L)
	{
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		UnityEngine.QualitySettings.asyncUploadBufferSize = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.QualitySettings>(L, new LuaOut<UnityEngine.QualitySettings>());
		return 1;
	}
}

