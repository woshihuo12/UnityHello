﻿using System;
using LuaInterface;

public class UnityEngine_CameraWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Camera), typeof(UnityEngine.Behaviour));
		L.RegFunction("SetTargetBuffers", SetTargetBuffers);
		L.RegFunction("ResetWorldToCameraMatrix", ResetWorldToCameraMatrix);
		L.RegFunction("ResetProjectionMatrix", ResetProjectionMatrix);
		L.RegFunction("ResetAspect", ResetAspect);
		L.RegFunction("ResetFieldOfView", ResetFieldOfView);
		L.RegFunction("SetStereoViewMatrices", SetStereoViewMatrices);
		L.RegFunction("ResetStereoViewMatrices", ResetStereoViewMatrices);
		L.RegFunction("SetStereoProjectionMatrices", SetStereoProjectionMatrices);
		L.RegFunction("ResetStereoProjectionMatrices", ResetStereoProjectionMatrices);
		L.RegFunction("WorldToScreenPoint", WorldToScreenPoint);
		L.RegFunction("WorldToViewportPoint", WorldToViewportPoint);
		L.RegFunction("ViewportToWorldPoint", ViewportToWorldPoint);
		L.RegFunction("ScreenToWorldPoint", ScreenToWorldPoint);
		L.RegFunction("ScreenToViewportPoint", ScreenToViewportPoint);
		L.RegFunction("ViewportToScreenPoint", ViewportToScreenPoint);
		L.RegFunction("ViewportPointToRay", ViewportPointToRay);
		L.RegFunction("ScreenPointToRay", ScreenPointToRay);
		L.RegFunction("GetAllCameras", GetAllCameras);
		L.RegFunction("Render", Render);
		L.RegFunction("RenderWithShader", RenderWithShader);
		L.RegFunction("SetReplacementShader", SetReplacementShader);
		L.RegFunction("ResetReplacementShader", ResetReplacementShader);
		L.RegFunction("RenderDontRestore", RenderDontRestore);
		L.RegFunction("SetupCurrent", SetupCurrent);
		L.RegFunction("RenderToCubemap", RenderToCubemap);
		L.RegFunction("CopyFrom", CopyFrom);
		L.RegFunction("AddCommandBuffer", AddCommandBuffer);
		L.RegFunction("RemoveCommandBuffer", RemoveCommandBuffer);
		L.RegFunction("RemoveCommandBuffers", RemoveCommandBuffers);
		L.RegFunction("RemoveAllCommandBuffers", RemoveAllCommandBuffers);
		L.RegFunction("GetCommandBuffers", GetCommandBuffers);
		L.RegFunction("CalculateObliqueMatrix", CalculateObliqueMatrix);
		L.RegFunction("New", _CreateUnityEngine_Camera);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("onPreCull", get_onPreCull, set_onPreCull);
		L.RegVar("onPreRender", get_onPreRender, set_onPreRender);
		L.RegVar("onPostRender", get_onPostRender, set_onPostRender);
		L.RegVar("fieldOfView", get_fieldOfView, set_fieldOfView);
		L.RegVar("nearClipPlane", get_nearClipPlane, set_nearClipPlane);
		L.RegVar("farClipPlane", get_farClipPlane, set_farClipPlane);
		L.RegVar("renderingPath", get_renderingPath, set_renderingPath);
		L.RegVar("actualRenderingPath", get_actualRenderingPath, null);
		L.RegVar("hdr", get_hdr, set_hdr);
		L.RegVar("orthographicSize", get_orthographicSize, set_orthographicSize);
		L.RegVar("orthographic", get_orthographic, set_orthographic);
		L.RegVar("opaqueSortMode", get_opaqueSortMode, set_opaqueSortMode);
		L.RegVar("transparencySortMode", get_transparencySortMode, set_transparencySortMode);
		L.RegVar("depth", get_depth, set_depth);
		L.RegVar("aspect", get_aspect, set_aspect);
		L.RegVar("cullingMask", get_cullingMask, set_cullingMask);
		L.RegVar("eventMask", get_eventMask, set_eventMask);
		L.RegVar("backgroundColor", get_backgroundColor, set_backgroundColor);
		L.RegVar("rect", get_rect, set_rect);
		L.RegVar("pixelRect", get_pixelRect, set_pixelRect);
		L.RegVar("targetTexture", get_targetTexture, set_targetTexture);
		L.RegVar("pixelWidth", get_pixelWidth, null);
		L.RegVar("pixelHeight", get_pixelHeight, null);
		L.RegVar("cameraToWorldMatrix", get_cameraToWorldMatrix, null);
		L.RegVar("worldToCameraMatrix", get_worldToCameraMatrix, set_worldToCameraMatrix);
		L.RegVar("projectionMatrix", get_projectionMatrix, set_projectionMatrix);
		L.RegVar("velocity", get_velocity, null);
		L.RegVar("clearFlags", get_clearFlags, set_clearFlags);
		L.RegVar("stereoEnabled", get_stereoEnabled, null);
		L.RegVar("stereoSeparation", get_stereoSeparation, set_stereoSeparation);
		L.RegVar("stereoConvergence", get_stereoConvergence, set_stereoConvergence);
		L.RegVar("cameraType", get_cameraType, set_cameraType);
		L.RegVar("stereoMirrorMode", get_stereoMirrorMode, set_stereoMirrorMode);
		L.RegVar("targetDisplay", get_targetDisplay, set_targetDisplay);
		L.RegVar("main", get_main, null);
		L.RegVar("current", get_current, null);
		L.RegVar("allCameras", get_allCameras, null);
		L.RegVar("allCamerasCount", get_allCamerasCount, null);
		L.RegVar("useOcclusionCulling", get_useOcclusionCulling, set_useOcclusionCulling);
		L.RegVar("layerCullDistances", get_layerCullDistances, set_layerCullDistances);
		L.RegVar("layerCullSpherical", get_layerCullSpherical, set_layerCullSpherical);
		L.RegVar("depthTextureMode", get_depthTextureMode, set_depthTextureMode);
		L.RegVar("clearStencilAfterLightingPass", get_clearStencilAfterLightingPass, set_clearStencilAfterLightingPass);
		L.RegVar("commandBufferCount", get_commandBufferCount, null);
		L.RegFunction("CameraCallback", UnityEngine_Camera_CameraCallback);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Camera(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.Camera obj = new UnityEngine.Camera();
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Camera.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTargetBuffers(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Camera), typeof(UnityEngine.RenderBuffer[]), typeof(UnityEngine.RenderBuffer)))
			{
				UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
				UnityEngine.RenderBuffer[] arg0 = ToLua.CheckObjectArray<UnityEngine.RenderBuffer>(L, 2);
				UnityEngine.RenderBuffer arg1 = (UnityEngine.RenderBuffer)ToLua.ToObject(L, 3);
				obj.SetTargetBuffers(arg0, arg1);
				return 0;
			}
			else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Camera), typeof(UnityEngine.RenderBuffer), typeof(UnityEngine.RenderBuffer)))
			{
				UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
				UnityEngine.RenderBuffer arg0 = (UnityEngine.RenderBuffer)ToLua.ToObject(L, 2);
				UnityEngine.RenderBuffer arg1 = (UnityEngine.RenderBuffer)ToLua.ToObject(L, 3);
				obj.SetTargetBuffers(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.tolua_error(L, "invalid arguments to method: UnityEngine.Camera.SetTargetBuffers");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetWorldToCameraMatrix(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			obj.ResetWorldToCameraMatrix();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetProjectionMatrix(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			obj.ResetProjectionMatrix();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetAspect(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			obj.ResetAspect();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetFieldOfView(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			obj.ResetFieldOfView();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetStereoViewMatrices(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Matrix4x4 arg0 = (UnityEngine.Matrix4x4)ToLua.CheckObject(L, 2, typeof(UnityEngine.Matrix4x4));
			UnityEngine.Matrix4x4 arg1 = (UnityEngine.Matrix4x4)ToLua.CheckObject(L, 3, typeof(UnityEngine.Matrix4x4));
			obj.SetStereoViewMatrices(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetStereoViewMatrices(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			obj.ResetStereoViewMatrices();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetStereoProjectionMatrices(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Matrix4x4 arg0 = (UnityEngine.Matrix4x4)ToLua.CheckObject(L, 2, typeof(UnityEngine.Matrix4x4));
			UnityEngine.Matrix4x4 arg1 = (UnityEngine.Matrix4x4)ToLua.CheckObject(L, 3, typeof(UnityEngine.Matrix4x4));
			obj.SetStereoProjectionMatrices(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetStereoProjectionMatrices(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			obj.ResetStereoProjectionMatrices();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WorldToScreenPoint(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o = obj.WorldToScreenPoint(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WorldToViewportPoint(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o = obj.WorldToViewportPoint(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ViewportToWorldPoint(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o = obj.ViewportToWorldPoint(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ScreenToWorldPoint(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o = obj.ScreenToWorldPoint(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ScreenToViewportPoint(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o = obj.ScreenToViewportPoint(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ViewportToScreenPoint(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o = obj.ViewportToScreenPoint(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ViewportPointToRay(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Ray o = obj.ViewportPointToRay(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ScreenPointToRay(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Ray o = obj.ScreenPointToRay(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAllCameras(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Camera[] arg0 = ToLua.CheckObjectArray<UnityEngine.Camera>(L, 1);
			int o = UnityEngine.Camera.GetAllCameras(arg0);
			LuaDLL.lua_pushinteger(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Render(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			obj.Render();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RenderWithShader(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Shader arg0 = (UnityEngine.Shader)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Shader));
			string arg1 = ToLua.CheckString(L, 3);
			obj.RenderWithShader(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetReplacementShader(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Shader arg0 = (UnityEngine.Shader)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Shader));
			string arg1 = ToLua.CheckString(L, 3);
			obj.SetReplacementShader(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetReplacementShader(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			obj.ResetReplacementShader();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RenderDontRestore(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			obj.RenderDontRestore();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetupCurrent(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Camera arg0 = (UnityEngine.Camera)ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Camera.SetupCurrent(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RenderToCubemap(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Camera), typeof(UnityEngine.RenderTexture)))
			{
				UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
				UnityEngine.RenderTexture arg0 = (UnityEngine.RenderTexture)ToLua.ToObject(L, 2);
				bool o = obj.RenderToCubemap(arg0);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Camera), typeof(UnityEngine.Cubemap)))
			{
				UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
				UnityEngine.Cubemap arg0 = (UnityEngine.Cubemap)ToLua.ToObject(L, 2);
				bool o = obj.RenderToCubemap(arg0);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Camera), typeof(UnityEngine.RenderTexture), typeof(int)))
			{
				UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
				UnityEngine.RenderTexture arg0 = (UnityEngine.RenderTexture)ToLua.ToObject(L, 2);
				int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
				bool o = obj.RenderToCubemap(arg0, arg1);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Camera), typeof(UnityEngine.Cubemap), typeof(int)))
			{
				UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
				UnityEngine.Cubemap arg0 = (UnityEngine.Cubemap)ToLua.ToObject(L, 2);
				int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
				bool o = obj.RenderToCubemap(arg0, arg1);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.tolua_error(L, "invalid arguments to method: UnityEngine.Camera.RenderToCubemap");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CopyFrom(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Camera arg0 = (UnityEngine.Camera)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Camera));
			obj.CopyFrom(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddCommandBuffer(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Rendering.CameraEvent arg0 = (UnityEngine.Rendering.CameraEvent)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rendering.CameraEvent));
			UnityEngine.Rendering.CommandBuffer arg1 = (UnityEngine.Rendering.CommandBuffer)ToLua.CheckObject(L, 3, typeof(UnityEngine.Rendering.CommandBuffer));
			obj.AddCommandBuffer(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveCommandBuffer(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Rendering.CameraEvent arg0 = (UnityEngine.Rendering.CameraEvent)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rendering.CameraEvent));
			UnityEngine.Rendering.CommandBuffer arg1 = (UnityEngine.Rendering.CommandBuffer)ToLua.CheckObject(L, 3, typeof(UnityEngine.Rendering.CommandBuffer));
			obj.RemoveCommandBuffer(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveCommandBuffers(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Rendering.CameraEvent arg0 = (UnityEngine.Rendering.CameraEvent)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rendering.CameraEvent));
			obj.RemoveCommandBuffers(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveAllCommandBuffers(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			obj.RemoveAllCommandBuffers();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetCommandBuffers(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Rendering.CameraEvent arg0 = (UnityEngine.Rendering.CameraEvent)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rendering.CameraEvent));
			UnityEngine.Rendering.CommandBuffer[] o = obj.GetCommandBuffers(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CalculateObliqueMatrix(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
			UnityEngine.Vector4 arg0 = ToLua.ToVector4(L, 2);
			UnityEngine.Matrix4x4 o = obj.CalculateObliqueMatrix(arg0);
			ToLua.PushValue(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
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
	static int get_onPreCull(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Camera.onPreCull);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onPreRender(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Camera.onPreRender);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onPostRender(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Camera.onPostRender);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fieldOfView(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float ret = obj.fieldOfView;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fieldOfView on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_nearClipPlane(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float ret = obj.nearClipPlane;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index nearClipPlane on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_farClipPlane(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float ret = obj.farClipPlane;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index farClipPlane on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_renderingPath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.RenderingPath ret = obj.renderingPath;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index renderingPath on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_actualRenderingPath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.RenderingPath ret = obj.actualRenderingPath;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index actualRenderingPath on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hdr(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			bool ret = obj.hdr;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index hdr on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_orthographicSize(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float ret = obj.orthographicSize;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index orthographicSize on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_orthographic(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			bool ret = obj.orthographic;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index orthographic on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_opaqueSortMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.Rendering.OpaqueSortMode ret = obj.opaqueSortMode;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index opaqueSortMode on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_transparencySortMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.TransparencySortMode ret = obj.transparencySortMode;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index transparencySortMode on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_depth(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float ret = obj.depth;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index depth on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_aspect(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float ret = obj.aspect;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index aspect on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cullingMask(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			int ret = obj.cullingMask;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index cullingMask on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_eventMask(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			int ret = obj.eventMask;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index eventMask on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_backgroundColor(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.Color ret = obj.backgroundColor;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index backgroundColor on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rect(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.Rect ret = obj.rect;
			ToLua.PushValue(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index rect on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelRect(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.Rect ret = obj.pixelRect;
			ToLua.PushValue(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index pixelRect on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_targetTexture(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.RenderTexture ret = obj.targetTexture;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index targetTexture on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelWidth(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			int ret = obj.pixelWidth;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index pixelWidth on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelHeight(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			int ret = obj.pixelHeight;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index pixelHeight on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cameraToWorldMatrix(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.Matrix4x4 ret = obj.cameraToWorldMatrix;
			ToLua.PushValue(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index cameraToWorldMatrix on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_worldToCameraMatrix(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.Matrix4x4 ret = obj.worldToCameraMatrix;
			ToLua.PushValue(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index worldToCameraMatrix on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_projectionMatrix(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.Matrix4x4 ret = obj.projectionMatrix;
			ToLua.PushValue(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index projectionMatrix on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_velocity(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.Vector3 ret = obj.velocity;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index velocity on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_clearFlags(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.CameraClearFlags ret = obj.clearFlags;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index clearFlags on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stereoEnabled(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			bool ret = obj.stereoEnabled;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index stereoEnabled on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stereoSeparation(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float ret = obj.stereoSeparation;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index stereoSeparation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stereoConvergence(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float ret = obj.stereoConvergence;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index stereoConvergence on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cameraType(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.CameraType ret = obj.cameraType;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index cameraType on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stereoMirrorMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			bool ret = obj.stereoMirrorMode;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index stereoMirrorMode on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_targetDisplay(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			int ret = obj.targetDisplay;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index targetDisplay on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_main(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Camera.main);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_current(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Camera.current);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_allCameras(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Camera.allCameras);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_allCamerasCount(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.Camera.allCamerasCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useOcclusionCulling(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			bool ret = obj.useOcclusionCulling;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index useOcclusionCulling on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_layerCullDistances(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float[] ret = obj.layerCullDistances;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index layerCullDistances on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_layerCullSpherical(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			bool ret = obj.layerCullSpherical;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index layerCullSpherical on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_depthTextureMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.DepthTextureMode ret = obj.depthTextureMode;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index depthTextureMode on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_clearStencilAfterLightingPass(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			bool ret = obj.clearStencilAfterLightingPass;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index clearStencilAfterLightingPass on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_commandBufferCount(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			int ret = obj.commandBufferCount;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index commandBufferCount on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onPreCull(IntPtr L)
	{
		try
		{
			UnityEngine.Camera.CameraCallback arg0 = null;
			LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

			if (funcType2 != LuaTypes.LUA_TFUNCTION)
			{
				 arg0 = (UnityEngine.Camera.CameraCallback)ToLua.CheckObject(L, 2, typeof(UnityEngine.Camera.CameraCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				arg0 = DelegateFactory.CreateDelegate(typeof(UnityEngine.Camera.CameraCallback), func) as UnityEngine.Camera.CameraCallback;
			}

			UnityEngine.Camera.onPreCull = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onPreRender(IntPtr L)
	{
		try
		{
			UnityEngine.Camera.CameraCallback arg0 = null;
			LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

			if (funcType2 != LuaTypes.LUA_TFUNCTION)
			{
				 arg0 = (UnityEngine.Camera.CameraCallback)ToLua.CheckObject(L, 2, typeof(UnityEngine.Camera.CameraCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				arg0 = DelegateFactory.CreateDelegate(typeof(UnityEngine.Camera.CameraCallback), func) as UnityEngine.Camera.CameraCallback;
			}

			UnityEngine.Camera.onPreRender = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onPostRender(IntPtr L)
	{
		try
		{
			UnityEngine.Camera.CameraCallback arg0 = null;
			LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

			if (funcType2 != LuaTypes.LUA_TFUNCTION)
			{
				 arg0 = (UnityEngine.Camera.CameraCallback)ToLua.CheckObject(L, 2, typeof(UnityEngine.Camera.CameraCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				arg0 = DelegateFactory.CreateDelegate(typeof(UnityEngine.Camera.CameraCallback), func) as UnityEngine.Camera.CameraCallback;
			}

			UnityEngine.Camera.onPostRender = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fieldOfView(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.fieldOfView = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fieldOfView on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_nearClipPlane(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.nearClipPlane = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index nearClipPlane on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_farClipPlane(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.farClipPlane = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index farClipPlane on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_renderingPath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.RenderingPath arg0 = (UnityEngine.RenderingPath)ToLua.CheckObject(L, 2, typeof(UnityEngine.RenderingPath));
			obj.renderingPath = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index renderingPath on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hdr(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.hdr = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index hdr on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_orthographicSize(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.orthographicSize = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index orthographicSize on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_orthographic(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.orthographic = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index orthographic on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_opaqueSortMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.Rendering.OpaqueSortMode arg0 = (UnityEngine.Rendering.OpaqueSortMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rendering.OpaqueSortMode));
			obj.opaqueSortMode = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index opaqueSortMode on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_transparencySortMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.TransparencySortMode arg0 = (UnityEngine.TransparencySortMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.TransparencySortMode));
			obj.transparencySortMode = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index transparencySortMode on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_depth(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.depth = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index depth on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_aspect(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.aspect = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index aspect on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cullingMask(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.cullingMask = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index cullingMask on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_eventMask(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.eventMask = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index eventMask on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_backgroundColor(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.Color arg0 = ToLua.ToColor(L, 2);
			obj.backgroundColor = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index backgroundColor on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rect(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.Rect arg0 = (UnityEngine.Rect)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rect));
			obj.rect = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index rect on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pixelRect(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.Rect arg0 = (UnityEngine.Rect)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rect));
			obj.pixelRect = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index pixelRect on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_targetTexture(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.RenderTexture arg0 = (UnityEngine.RenderTexture)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.RenderTexture));
			obj.targetTexture = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index targetTexture on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_worldToCameraMatrix(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.Matrix4x4 arg0 = (UnityEngine.Matrix4x4)ToLua.CheckObject(L, 2, typeof(UnityEngine.Matrix4x4));
			obj.worldToCameraMatrix = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index worldToCameraMatrix on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_projectionMatrix(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.Matrix4x4 arg0 = (UnityEngine.Matrix4x4)ToLua.CheckObject(L, 2, typeof(UnityEngine.Matrix4x4));
			obj.projectionMatrix = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index projectionMatrix on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_clearFlags(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.CameraClearFlags arg0 = (UnityEngine.CameraClearFlags)ToLua.CheckObject(L, 2, typeof(UnityEngine.CameraClearFlags));
			obj.clearFlags = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index clearFlags on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stereoSeparation(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.stereoSeparation = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index stereoSeparation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stereoConvergence(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.stereoConvergence = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index stereoConvergence on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cameraType(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.CameraType arg0 = (UnityEngine.CameraType)ToLua.CheckObject(L, 2, typeof(UnityEngine.CameraType));
			obj.cameraType = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index cameraType on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stereoMirrorMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.stereoMirrorMode = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index stereoMirrorMode on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_targetDisplay(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.targetDisplay = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index targetDisplay on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useOcclusionCulling(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.useOcclusionCulling = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index useOcclusionCulling on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_layerCullDistances(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			float[] arg0 = ToLua.CheckNumberArray<float>(L, 2);
			obj.layerCullDistances = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index layerCullDistances on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_layerCullSpherical(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.layerCullSpherical = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index layerCullSpherical on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_depthTextureMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			UnityEngine.DepthTextureMode arg0 = (UnityEngine.DepthTextureMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.DepthTextureMode));
			obj.depthTextureMode = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index depthTextureMode on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_clearStencilAfterLightingPass(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Camera obj = (UnityEngine.Camera)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.clearStencilAfterLightingPass = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index clearStencilAfterLightingPass on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnityEngine_Camera_CameraCallback(IntPtr L)
	{
		try
		{
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			Delegate arg1 = DelegateFactory.CreateDelegate(typeof(UnityEngine.Camera.CameraCallback), func);
			ToLua.Push(L, arg1);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

