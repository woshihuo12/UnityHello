using System;
using LuaInterface;

public class UnityEngine_RendererWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Renderer), typeof(UnityEngine.Component));
		L.RegFunction("SetPropertyBlock", SetPropertyBlock);
		L.RegFunction("GetPropertyBlock", GetPropertyBlock);
		L.RegFunction("GetClosestReflectionProbes", GetClosestReflectionProbes);
		L.RegFunction("New", _CreateUnityEngine_Renderer);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("isPartOfStaticBatch", get_isPartOfStaticBatch, null);
		L.RegVar("worldToLocalMatrix", get_worldToLocalMatrix, null);
		L.RegVar("localToWorldMatrix", get_localToWorldMatrix, null);
		L.RegVar("enabled", get_enabled, set_enabled);
		L.RegVar("shadowCastingMode", get_shadowCastingMode, set_shadowCastingMode);
		L.RegVar("receiveShadows", get_receiveShadows, set_receiveShadows);
		L.RegVar("material", get_material, set_material);
		L.RegVar("sharedMaterial", get_sharedMaterial, set_sharedMaterial);
		L.RegVar("materials", get_materials, set_materials);
		L.RegVar("sharedMaterials", get_sharedMaterials, set_sharedMaterials);
		L.RegVar("bounds", get_bounds, null);
		L.RegVar("lightmapIndex", get_lightmapIndex, set_lightmapIndex);
		L.RegVar("realtimeLightmapIndex", get_realtimeLightmapIndex, set_realtimeLightmapIndex);
		L.RegVar("lightmapScaleOffset", get_lightmapScaleOffset, set_lightmapScaleOffset);
		L.RegVar("realtimeLightmapScaleOffset", get_realtimeLightmapScaleOffset, set_realtimeLightmapScaleOffset);
		L.RegVar("isVisible", get_isVisible, null);
		L.RegVar("useLightProbes", get_useLightProbes, set_useLightProbes);
		L.RegVar("probeAnchor", get_probeAnchor, set_probeAnchor);
		L.RegVar("reflectionProbeUsage", get_reflectionProbeUsage, set_reflectionProbeUsage);
		L.RegVar("sortingLayerName", get_sortingLayerName, set_sortingLayerName);
		L.RegVar("sortingLayerID", get_sortingLayerID, set_sortingLayerID);
		L.RegVar("sortingOrder", get_sortingOrder, set_sortingOrder);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Renderer(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.Renderer obj = new UnityEngine.Renderer();
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Renderer.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPropertyBlock(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.CheckObject(L, 1, typeof(UnityEngine.Renderer));
		UnityEngine.MaterialPropertyBlock arg0 = (UnityEngine.MaterialPropertyBlock)ToLua.CheckObject(L, 2, typeof(UnityEngine.MaterialPropertyBlock));

		try
		{
			obj.SetPropertyBlock(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPropertyBlock(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.CheckObject(L, 1, typeof(UnityEngine.Renderer));
		UnityEngine.MaterialPropertyBlock arg0 = (UnityEngine.MaterialPropertyBlock)ToLua.CheckObject(L, 2, typeof(UnityEngine.MaterialPropertyBlock));

		try
		{
			obj.GetPropertyBlock(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClosestReflectionProbes(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.CheckObject(L, 1, typeof(UnityEngine.Renderer));
		System.Collections.Generic.List<UnityEngine.Rendering.ReflectionProbeBlendInfo> arg0 = (System.Collections.Generic.List<UnityEngine.Rendering.ReflectionProbeBlendInfo>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Rendering.ReflectionProbeBlendInfo>));

		try
		{
			obj.GetClosestReflectionProbes(arg0);
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
	static int get_isPartOfStaticBatch(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.isPartOfStaticBatch;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isPartOfStaticBatch on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_worldToLocalMatrix(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Matrix4x4 ret;

		try
		{
			ret = obj.worldToLocalMatrix;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index worldToLocalMatrix on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localToWorldMatrix(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Matrix4x4 ret;

		try
		{
			ret = obj.localToWorldMatrix;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index localToWorldMatrix on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enabled(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.enabled;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index enabled on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowCastingMode(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Rendering.ShadowCastingMode ret;

		try
		{
			ret = obj.shadowCastingMode;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index shadowCastingMode on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_receiveShadows(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.receiveShadows;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index receiveShadows on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_material(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
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
	static int get_sharedMaterial(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Material ret = null;

		try
		{
			ret = obj.sharedMaterial;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sharedMaterial on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_materials(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Material[] ret = null;

		try
		{
			ret = obj.materials;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index materials on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sharedMaterials(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Material[] ret = null;

		try
		{
			ret = obj.sharedMaterials;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sharedMaterials on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bounds(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Bounds ret;

		try
		{
			ret = obj.bounds;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index bounds on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lightmapIndex(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.lightmapIndex;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index lightmapIndex on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_realtimeLightmapIndex(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.realtimeLightmapIndex;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index realtimeLightmapIndex on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lightmapScaleOffset(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Vector4 ret;

		try
		{
			ret = obj.lightmapScaleOffset;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index lightmapScaleOffset on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_realtimeLightmapScaleOffset(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Vector4 ret;

		try
		{
			ret = obj.realtimeLightmapScaleOffset;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index realtimeLightmapScaleOffset on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isVisible(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.isVisible;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isVisible on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useLightProbes(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.useLightProbes;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index useLightProbes on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_probeAnchor(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Transform ret = null;

		try
		{
			ret = obj.probeAnchor;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index probeAnchor on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_reflectionProbeUsage(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Rendering.ReflectionProbeUsage ret;

		try
		{
			ret = obj.reflectionProbeUsage;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index reflectionProbeUsage on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sortingLayerName(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		string ret = null;

		try
		{
			ret = obj.sortingLayerName;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sortingLayerName on a nil value" : e.Message);
		}

		LuaDLL.lua_pushstring(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sortingLayerID(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.sortingLayerID;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sortingLayerID on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sortingOrder(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.sortingOrder;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sortingOrder on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enabled(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.enabled = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index enabled on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowCastingMode(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Rendering.ShadowCastingMode arg0 = (UnityEngine.Rendering.ShadowCastingMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rendering.ShadowCastingMode));

		try
		{
			obj.shadowCastingMode = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index shadowCastingMode on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_receiveShadows(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.receiveShadows = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index receiveShadows on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_material(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
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
	static int set_sharedMaterial(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Material arg0 = (UnityEngine.Material)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Material));

		try
		{
			obj.sharedMaterial = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sharedMaterial on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_materials(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Material[] arg0 = ToLua.CheckObjectArray<UnityEngine.Material>(L, 2);

		try
		{
			obj.materials = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index materials on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sharedMaterials(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Material[] arg0 = ToLua.CheckObjectArray<UnityEngine.Material>(L, 2);

		try
		{
			obj.sharedMaterials = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sharedMaterials on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lightmapIndex(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.lightmapIndex = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index lightmapIndex on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_realtimeLightmapIndex(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.realtimeLightmapIndex = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index realtimeLightmapIndex on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lightmapScaleOffset(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Vector4 arg0 = ToLua.ToVector4(L, 2);

		try
		{
			obj.lightmapScaleOffset = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index lightmapScaleOffset on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_realtimeLightmapScaleOffset(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Vector4 arg0 = ToLua.ToVector4(L, 2);

		try
		{
			obj.realtimeLightmapScaleOffset = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index realtimeLightmapScaleOffset on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useLightProbes(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.useLightProbes = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index useLightProbes on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_probeAnchor(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Transform));

		try
		{
			obj.probeAnchor = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index probeAnchor on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_reflectionProbeUsage(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		UnityEngine.Rendering.ReflectionProbeUsage arg0 = (UnityEngine.Rendering.ReflectionProbeUsage)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rendering.ReflectionProbeUsage));

		try
		{
			obj.reflectionProbeUsage = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index reflectionProbeUsage on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sortingLayerName(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		string arg0 = ToLua.CheckString(L, 2);

		try
		{
			obj.sortingLayerName = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sortingLayerName on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sortingLayerID(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.sortingLayerID = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sortingLayerID on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sortingOrder(IntPtr L)
	{
		UnityEngine.Renderer obj = (UnityEngine.Renderer)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.sortingOrder = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sortingOrder on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.Renderer>(L, new LuaOut<UnityEngine.Renderer>());
		return 1;
	}
}

