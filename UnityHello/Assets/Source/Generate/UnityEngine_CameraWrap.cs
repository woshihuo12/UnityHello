using System;
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
		L.RegFunction("CameraCallback", CameraCallback);
		L.RegVar("out", get_out, null);
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
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Camera), typeof(UnityEngine.RenderBuffer[]), typeof(UnityEngine.RenderBuffer)))
		{
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
			UnityEngine.RenderBuffer[] arg0 = ToLua.CheckObjectArray<UnityEngine.RenderBuffer>(L, 2);
			UnityEngine.RenderBuffer arg1 = (UnityEngine.RenderBuffer)ToLua.ToObject(L, 3);

			try
			{
				obj.SetTargetBuffers(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Camera), typeof(UnityEngine.RenderBuffer), typeof(UnityEngine.RenderBuffer)))
		{
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
			UnityEngine.RenderBuffer arg0 = (UnityEngine.RenderBuffer)ToLua.ToObject(L, 2);
			UnityEngine.RenderBuffer arg1 = (UnityEngine.RenderBuffer)ToLua.ToObject(L, 3);

			try
			{
				obj.SetTargetBuffers(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Camera.SetTargetBuffers");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetWorldToCameraMatrix(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));

		try
		{
			obj.ResetWorldToCameraMatrix();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetProjectionMatrix(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));

		try
		{
			obj.ResetProjectionMatrix();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetAspect(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));

		try
		{
			obj.ResetAspect();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetFieldOfView(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));

		try
		{
			obj.ResetFieldOfView();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetStereoViewMatrices(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Matrix4x4 arg0 = (UnityEngine.Matrix4x4)ToLua.CheckObject(L, 2, typeof(UnityEngine.Matrix4x4));
		UnityEngine.Matrix4x4 arg1 = (UnityEngine.Matrix4x4)ToLua.CheckObject(L, 3, typeof(UnityEngine.Matrix4x4));

		try
		{
			obj.SetStereoViewMatrices(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetStereoViewMatrices(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));

		try
		{
			obj.ResetStereoViewMatrices();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetStereoProjectionMatrices(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Matrix4x4 arg0 = (UnityEngine.Matrix4x4)ToLua.CheckObject(L, 2, typeof(UnityEngine.Matrix4x4));
		UnityEngine.Matrix4x4 arg1 = (UnityEngine.Matrix4x4)ToLua.CheckObject(L, 3, typeof(UnityEngine.Matrix4x4));

		try
		{
			obj.SetStereoProjectionMatrices(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetStereoProjectionMatrices(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));

		try
		{
			obj.ResetStereoProjectionMatrices();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WorldToScreenPoint(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.Vector3 o;

		try
		{
			o = obj.WorldToScreenPoint(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WorldToViewportPoint(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.Vector3 o;

		try
		{
			o = obj.WorldToViewportPoint(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ViewportToWorldPoint(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.Vector3 o;

		try
		{
			o = obj.ViewportToWorldPoint(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ScreenToWorldPoint(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.Vector3 o;

		try
		{
			o = obj.ScreenToWorldPoint(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ScreenToViewportPoint(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.Vector3 o;

		try
		{
			o = obj.ScreenToViewportPoint(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ViewportToScreenPoint(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.Vector3 o;

		try
		{
			o = obj.ViewportToScreenPoint(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ViewportPointToRay(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.Ray o;

		try
		{
			o = obj.ViewportPointToRay(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ScreenPointToRay(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.Ray o;

		try
		{
			o = obj.ScreenPointToRay(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAllCameras(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Camera[] arg0 = ToLua.CheckObjectArray<UnityEngine.Camera>(L, 1);
		int o;

		try
		{
			o = UnityEngine.Camera.GetAllCameras(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushinteger(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Render(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));

		try
		{
			obj.Render();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RenderWithShader(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Shader arg0 = (UnityEngine.Shader)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Shader));
		string arg1 = ToLua.CheckString(L, 3);

		try
		{
			obj.RenderWithShader(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetReplacementShader(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Shader arg0 = (UnityEngine.Shader)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Shader));
		string arg1 = ToLua.CheckString(L, 3);

		try
		{
			obj.SetReplacementShader(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetReplacementShader(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));

		try
		{
			obj.ResetReplacementShader();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RenderDontRestore(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));

		try
		{
			obj.RenderDontRestore();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetupCurrent(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Camera arg0 = (UnityEngine.Camera)ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.Camera));

		try
		{
			UnityEngine.Camera.SetupCurrent(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RenderToCubemap(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Camera), typeof(UnityEngine.RenderTexture)))
		{
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
			UnityEngine.RenderTexture arg0 = (UnityEngine.RenderTexture)ToLua.ToObject(L, 2);
			bool o;

			try
			{
				o = obj.RenderToCubemap(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Camera), typeof(UnityEngine.Cubemap)))
		{
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
			UnityEngine.Cubemap arg0 = (UnityEngine.Cubemap)ToLua.ToObject(L, 2);
			bool o;

			try
			{
				o = obj.RenderToCubemap(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Camera), typeof(UnityEngine.RenderTexture), typeof(int)))
		{
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
			UnityEngine.RenderTexture arg0 = (UnityEngine.RenderTexture)ToLua.ToObject(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			bool o;

			try
			{
				o = obj.RenderToCubemap(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Camera), typeof(UnityEngine.Cubemap), typeof(int)))
		{
			UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
			UnityEngine.Cubemap arg0 = (UnityEngine.Cubemap)ToLua.ToObject(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			bool o;

			try
			{
				o = obj.RenderToCubemap(arg0, arg1);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Camera.RenderToCubemap");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CopyFrom(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Camera arg0 = (UnityEngine.Camera)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Camera));

		try
		{
			obj.CopyFrom(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddCommandBuffer(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Rendering.CameraEvent arg0 = (UnityEngine.Rendering.CameraEvent)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rendering.CameraEvent));
		UnityEngine.Rendering.CommandBuffer arg1 = (UnityEngine.Rendering.CommandBuffer)ToLua.CheckObject(L, 3, typeof(UnityEngine.Rendering.CommandBuffer));

		try
		{
			obj.AddCommandBuffer(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveCommandBuffer(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Rendering.CameraEvent arg0 = (UnityEngine.Rendering.CameraEvent)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rendering.CameraEvent));
		UnityEngine.Rendering.CommandBuffer arg1 = (UnityEngine.Rendering.CommandBuffer)ToLua.CheckObject(L, 3, typeof(UnityEngine.Rendering.CommandBuffer));

		try
		{
			obj.RemoveCommandBuffer(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveCommandBuffers(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Rendering.CameraEvent arg0 = (UnityEngine.Rendering.CameraEvent)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rendering.CameraEvent));

		try
		{
			obj.RemoveCommandBuffers(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveAllCommandBuffers(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));

		try
		{
			obj.RemoveAllCommandBuffers();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetCommandBuffers(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Rendering.CameraEvent arg0 = (UnityEngine.Rendering.CameraEvent)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rendering.CameraEvent));
		UnityEngine.Rendering.CommandBuffer[] o = null;

		try
		{
			o = obj.GetCommandBuffers(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CalculateObliqueMatrix(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.CheckObject(L, 1, typeof(UnityEngine.Camera));
		UnityEngine.Vector4 arg0 = ToLua.ToVector4(L, 2);
		UnityEngine.Matrix4x4 o;

		try
		{
			o = obj.CalculateObliqueMatrix(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.PushValue(L, o);
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
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.fieldOfView;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index fieldOfView on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_nearClipPlane(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.nearClipPlane;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index nearClipPlane on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_farClipPlane(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.farClipPlane;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index farClipPlane on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_renderingPath(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.RenderingPath ret;

		try
		{
			ret = obj.renderingPath;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index renderingPath on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_actualRenderingPath(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.RenderingPath ret;

		try
		{
			ret = obj.actualRenderingPath;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index actualRenderingPath on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hdr(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.hdr;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index hdr on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_orthographicSize(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.orthographicSize;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index orthographicSize on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_orthographic(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.orthographic;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index orthographic on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_opaqueSortMode(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.Rendering.OpaqueSortMode ret;

		try
		{
			ret = obj.opaqueSortMode;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index opaqueSortMode on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_transparencySortMode(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.TransparencySortMode ret;

		try
		{
			ret = obj.transparencySortMode;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index transparencySortMode on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_depth(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.depth;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index depth on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_aspect(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.aspect;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index aspect on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cullingMask(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.cullingMask;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index cullingMask on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_eventMask(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.eventMask;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index eventMask on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_backgroundColor(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.Color ret;

		try
		{
			ret = obj.backgroundColor;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index backgroundColor on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rect(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.Rect ret;

		try
		{
			ret = obj.rect;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index rect on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelRect(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.Rect ret;

		try
		{
			ret = obj.pixelRect;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index pixelRect on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_targetTexture(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.RenderTexture ret = null;

		try
		{
			ret = obj.targetTexture;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index targetTexture on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelWidth(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.pixelWidth;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index pixelWidth on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelHeight(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.pixelHeight;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index pixelHeight on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cameraToWorldMatrix(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.Matrix4x4 ret;

		try
		{
			ret = obj.cameraToWorldMatrix;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index cameraToWorldMatrix on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_worldToCameraMatrix(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.Matrix4x4 ret;

		try
		{
			ret = obj.worldToCameraMatrix;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index worldToCameraMatrix on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_projectionMatrix(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.Matrix4x4 ret;

		try
		{
			ret = obj.projectionMatrix;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index projectionMatrix on a nil value" : e.Message);
		}

		ToLua.PushValue(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_velocity(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.velocity;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index velocity on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_clearFlags(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.CameraClearFlags ret;

		try
		{
			ret = obj.clearFlags;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index clearFlags on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stereoEnabled(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.stereoEnabled;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index stereoEnabled on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stereoSeparation(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.stereoSeparation;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index stereoSeparation on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stereoConvergence(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.stereoConvergence;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index stereoConvergence on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cameraType(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.CameraType ret;

		try
		{
			ret = obj.cameraType;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index cameraType on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stereoMirrorMode(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.stereoMirrorMode;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index stereoMirrorMode on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_targetDisplay(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.targetDisplay;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index targetDisplay on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
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
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.useOcclusionCulling;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index useOcclusionCulling on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_layerCullDistances(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float[] ret = null;

		try
		{
			ret = obj.layerCullDistances;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index layerCullDistances on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_layerCullSpherical(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.layerCullSpherical;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index layerCullSpherical on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_depthTextureMode(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.DepthTextureMode ret;

		try
		{
			ret = obj.depthTextureMode;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index depthTextureMode on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_clearStencilAfterLightingPass(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.clearStencilAfterLightingPass;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index clearStencilAfterLightingPass on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_commandBufferCount(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.commandBufferCount;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index commandBufferCount on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onPreCull(IntPtr L)
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
			arg0 = DelegateFactory.CreateDelegate(L, typeof(UnityEngine.Camera.CameraCallback), func) as UnityEngine.Camera.CameraCallback;
		}
		UnityEngine.Camera.onPreCull = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onPreRender(IntPtr L)
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
			arg0 = DelegateFactory.CreateDelegate(L, typeof(UnityEngine.Camera.CameraCallback), func) as UnityEngine.Camera.CameraCallback;
		}
		UnityEngine.Camera.onPreRender = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onPostRender(IntPtr L)
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
			arg0 = DelegateFactory.CreateDelegate(L, typeof(UnityEngine.Camera.CameraCallback), func) as UnityEngine.Camera.CameraCallback;
		}
		UnityEngine.Camera.onPostRender = arg0;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fieldOfView(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.fieldOfView = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index fieldOfView on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_nearClipPlane(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.nearClipPlane = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index nearClipPlane on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_farClipPlane(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.farClipPlane = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index farClipPlane on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_renderingPath(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.RenderingPath arg0 = (UnityEngine.RenderingPath)ToLua.CheckObject(L, 2, typeof(UnityEngine.RenderingPath));

		try
		{
			obj.renderingPath = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index renderingPath on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hdr(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.hdr = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index hdr on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_orthographicSize(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.orthographicSize = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index orthographicSize on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_orthographic(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.orthographic = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index orthographic on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_opaqueSortMode(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.Rendering.OpaqueSortMode arg0 = (UnityEngine.Rendering.OpaqueSortMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rendering.OpaqueSortMode));

		try
		{
			obj.opaqueSortMode = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index opaqueSortMode on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_transparencySortMode(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.TransparencySortMode arg0 = (UnityEngine.TransparencySortMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.TransparencySortMode));

		try
		{
			obj.transparencySortMode = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index transparencySortMode on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_depth(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.depth = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index depth on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_aspect(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.aspect = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index aspect on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cullingMask(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.cullingMask = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index cullingMask on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_eventMask(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.eventMask = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index eventMask on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_backgroundColor(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.Color arg0 = ToLua.ToColor(L, 2);

		try
		{
			obj.backgroundColor = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index backgroundColor on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rect(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.Rect arg0 = (UnityEngine.Rect)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rect));

		try
		{
			obj.rect = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index rect on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pixelRect(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.Rect arg0 = (UnityEngine.Rect)ToLua.CheckObject(L, 2, typeof(UnityEngine.Rect));

		try
		{
			obj.pixelRect = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index pixelRect on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_targetTexture(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.RenderTexture arg0 = (UnityEngine.RenderTexture)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.RenderTexture));

		try
		{
			obj.targetTexture = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index targetTexture on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_worldToCameraMatrix(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.Matrix4x4 arg0 = (UnityEngine.Matrix4x4)ToLua.CheckObject(L, 2, typeof(UnityEngine.Matrix4x4));

		try
		{
			obj.worldToCameraMatrix = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index worldToCameraMatrix on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_projectionMatrix(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.Matrix4x4 arg0 = (UnityEngine.Matrix4x4)ToLua.CheckObject(L, 2, typeof(UnityEngine.Matrix4x4));

		try
		{
			obj.projectionMatrix = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index projectionMatrix on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_clearFlags(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.CameraClearFlags arg0 = (UnityEngine.CameraClearFlags)ToLua.CheckObject(L, 2, typeof(UnityEngine.CameraClearFlags));

		try
		{
			obj.clearFlags = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index clearFlags on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stereoSeparation(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.stereoSeparation = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index stereoSeparation on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stereoConvergence(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.stereoConvergence = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index stereoConvergence on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cameraType(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.CameraType arg0 = (UnityEngine.CameraType)ToLua.CheckObject(L, 2, typeof(UnityEngine.CameraType));

		try
		{
			obj.cameraType = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index cameraType on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stereoMirrorMode(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.stereoMirrorMode = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index stereoMirrorMode on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_targetDisplay(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.targetDisplay = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index targetDisplay on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useOcclusionCulling(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.useOcclusionCulling = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index useOcclusionCulling on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_layerCullDistances(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		float[] arg0 = ToLua.CheckNumberArray<float>(L, 2);

		try
		{
			obj.layerCullDistances = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index layerCullDistances on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_layerCullSpherical(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.layerCullSpherical = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index layerCullSpherical on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_depthTextureMode(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		UnityEngine.DepthTextureMode arg0 = (UnityEngine.DepthTextureMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.DepthTextureMode));

		try
		{
			obj.depthTextureMode = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index depthTextureMode on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_clearStencilAfterLightingPass(IntPtr L)
	{
		UnityEngine.Camera obj = (UnityEngine.Camera)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.clearStencilAfterLightingPass = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index clearStencilAfterLightingPass on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.Camera>(L, new LuaOut<UnityEngine.Camera>());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CameraCallback(IntPtr L)
	{
		LuaFunction func = ToLua.CheckLuaFunction(L, 1);
		Delegate arg1 = DelegateFactory.CreateDelegate(L, typeof(UnityEngine.Camera.CameraCallback), func);
		ToLua.Push(L, arg1);
		return 1;
	}
}

