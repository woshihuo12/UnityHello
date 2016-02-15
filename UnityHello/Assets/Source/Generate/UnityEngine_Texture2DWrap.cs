using System;
using LuaInterface;

public class UnityEngine_Texture2DWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Texture2D), typeof(UnityEngine.Texture));
		L.RegFunction("CreateExternalTexture", CreateExternalTexture);
		L.RegFunction("UpdateExternalTexture", UpdateExternalTexture);
		L.RegFunction("SetPixel", SetPixel);
		L.RegFunction("GetPixel", GetPixel);
		L.RegFunction("GetPixelBilinear", GetPixelBilinear);
		L.RegFunction("SetPixels", SetPixels);
		L.RegFunction("SetPixels32", SetPixels32);
		L.RegFunction("LoadImage", LoadImage);
		L.RegFunction("LoadRawTextureData", LoadRawTextureData);
		L.RegFunction("GetRawTextureData", GetRawTextureData);
		L.RegFunction("GetPixels", GetPixels);
		L.RegFunction("GetPixels32", GetPixels32);
		L.RegFunction("Apply", Apply);
		L.RegFunction("Resize", Resize);
		L.RegFunction("Compress", Compress);
		L.RegFunction("PackTextures", PackTextures);
		L.RegFunction("ReadPixels", ReadPixels);
		L.RegFunction("EncodeToPNG", EncodeToPNG);
		L.RegFunction("EncodeToJPG", EncodeToJPG);
		L.RegFunction("New", _CreateUnityEngine_Texture2D);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("mipmapCount", get_mipmapCount, null);
		L.RegVar("format", get_format, null);
		L.RegVar("whiteTexture", get_whiteTexture, null);
		L.RegVar("blackTexture", get_blackTexture, null);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Texture2D(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Texture2D obj = new UnityEngine.Texture2D(arg0, arg1);
			ToLua.Push(L, obj);
			return 1;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(int), typeof(int), typeof(UnityEngine.TextureFormat), typeof(bool)))
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.TextureFormat arg2 = (UnityEngine.TextureFormat)ToLua.CheckObject(L, 3, typeof(UnityEngine.TextureFormat));
			bool arg3 = LuaDLL.luaL_checkboolean(L, 4);
			UnityEngine.Texture2D obj = new UnityEngine.Texture2D(arg0, arg1, arg2, arg3);
			ToLua.Push(L, obj);
			return 1;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(int), typeof(int), typeof(UnityEngine.TextureFormat), typeof(bool), typeof(bool)))
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.TextureFormat arg2 = (UnityEngine.TextureFormat)ToLua.CheckObject(L, 3, typeof(UnityEngine.TextureFormat));
			bool arg3 = LuaDLL.luaL_checkboolean(L, 4);
			bool arg4 = LuaDLL.luaL_checkboolean(L, 5);
			UnityEngine.Texture2D obj = new UnityEngine.Texture2D(arg0, arg1, arg2, arg3, arg4);
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Texture2D.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateExternalTexture(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 6);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
		int arg1 = (int)LuaDLL.luaL_checknumber(L, 2);
		UnityEngine.TextureFormat arg2 = (UnityEngine.TextureFormat)ToLua.CheckObject(L, 3, typeof(UnityEngine.TextureFormat));
		bool arg3 = LuaDLL.luaL_checkboolean(L, 4);
		bool arg4 = LuaDLL.luaL_checkboolean(L, 5);
		System.IntPtr arg5 = (System.IntPtr)LuaDLL.lua_touserdata(L, 6);
		UnityEngine.Texture2D o = null;

		try
		{
			o = UnityEngine.Texture2D.CreateExternalTexture(arg0, arg1, arg2, arg3, arg4, arg5);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UpdateExternalTexture(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.CheckObject(L, 1, typeof(UnityEngine.Texture2D));
		System.IntPtr arg0 = (System.IntPtr)LuaDLL.lua_touserdata(L, 2);

		try
		{
			obj.UpdateExternalTexture(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPixel(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 4);
		UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.CheckObject(L, 1, typeof(UnityEngine.Texture2D));
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
		UnityEngine.Color arg2 = ToLua.ToColor(L, 4);

		try
		{
			obj.SetPixel(arg0, arg1, arg2);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPixel(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.CheckObject(L, 1, typeof(UnityEngine.Texture2D));
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
		UnityEngine.Color o;

		try
		{
			o = obj.GetPixel(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPixelBilinear(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.CheckObject(L, 1, typeof(UnityEngine.Texture2D));
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
		float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
		UnityEngine.Color o;

		try
		{
			o = obj.GetPixelBilinear(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPixels(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(UnityEngine.Color[])))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			UnityEngine.Color[] arg0 = ToLua.CheckObjectArray<UnityEngine.Color>(L, 2);

			try
			{
				obj.SetPixels(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(UnityEngine.Color[]), typeof(int)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			UnityEngine.Color[] arg0 = ToLua.CheckObjectArray<UnityEngine.Color>(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);

			try
			{
				obj.SetPixels(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 6 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(int), typeof(int), typeof(int), typeof(int), typeof(UnityEngine.Color[])))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 5);
			UnityEngine.Color[] arg4 = ToLua.CheckObjectArray<UnityEngine.Color>(L, 6);

			try
			{
				obj.SetPixels(arg0, arg1, arg2, arg3, arg4);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 7 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(int), typeof(int), typeof(int), typeof(int), typeof(UnityEngine.Color[]), typeof(int)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 5);
			UnityEngine.Color[] arg4 = ToLua.CheckObjectArray<UnityEngine.Color>(L, 6);
			int arg5 = (int)LuaDLL.lua_tonumber(L, 7);

			try
			{
				obj.SetPixels(arg0, arg1, arg2, arg3, arg4, arg5);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Texture2D.SetPixels");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPixels32(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(UnityEngine.Color32[])))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			UnityEngine.Color32[] arg0 = ToLua.CheckObjectArray<UnityEngine.Color32>(L, 2);

			try
			{
				obj.SetPixels32(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(UnityEngine.Color32[]), typeof(int)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			UnityEngine.Color32[] arg0 = ToLua.CheckObjectArray<UnityEngine.Color32>(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);

			try
			{
				obj.SetPixels32(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 6 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(int), typeof(int), typeof(int), typeof(int), typeof(UnityEngine.Color32[])))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 5);
			UnityEngine.Color32[] arg4 = ToLua.CheckObjectArray<UnityEngine.Color32>(L, 6);

			try
			{
				obj.SetPixels32(arg0, arg1, arg2, arg3, arg4);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 7 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(int), typeof(int), typeof(int), typeof(int), typeof(UnityEngine.Color32[]), typeof(int)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 5);
			UnityEngine.Color32[] arg4 = ToLua.CheckObjectArray<UnityEngine.Color32>(L, 6);
			int arg5 = (int)LuaDLL.lua_tonumber(L, 7);

			try
			{
				obj.SetPixels32(arg0, arg1, arg2, arg3, arg4, arg5);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Texture2D.SetPixels32");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadImage(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(byte[])))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			byte[] arg0 = ToLua.CheckByteBuffer(L, 2);
			bool o;

			try
			{
				o = obj.LoadImage(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(byte[]), typeof(bool)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			byte[] arg0 = ToLua.CheckByteBuffer(L, 2);
			bool arg1 = LuaDLL.lua_toboolean(L, 3);
			bool o;

			try
			{
				o = obj.LoadImage(arg0, arg1);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Texture2D.LoadImage");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadRawTextureData(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(byte[])))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			byte[] arg0 = ToLua.CheckByteBuffer(L, 2);

			try
			{
				obj.LoadRawTextureData(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(System.IntPtr), typeof(int)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			System.IntPtr arg0 = (System.IntPtr)LuaDLL.lua_touserdata(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);

			try
			{
				obj.LoadRawTextureData(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Texture2D.LoadRawTextureData");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRawTextureData(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.CheckObject(L, 1, typeof(UnityEngine.Texture2D));
		byte[] o = null;

		try
		{
			o = obj.GetRawTextureData();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPixels(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			UnityEngine.Color[] o = null;

			try
			{
				o = obj.GetPixels();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(int)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.Color[] o = null;

			try
			{
				o = obj.GetPixels(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(int), typeof(int), typeof(int), typeof(int)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 5);
			UnityEngine.Color[] o = null;

			try
			{
				o = obj.GetPixels(arg0, arg1, arg2, arg3);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 6 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 5);
			int arg4 = (int)LuaDLL.lua_tonumber(L, 6);
			UnityEngine.Color[] o = null;

			try
			{
				o = obj.GetPixels(arg0, arg1, arg2, arg3, arg4);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Texture2D.GetPixels");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPixels32(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			UnityEngine.Color32[] o = null;

			try
			{
				o = obj.GetPixels32();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(int)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.Color32[] o = null;

			try
			{
				o = obj.GetPixels32(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Texture2D.GetPixels32");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Apply(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);

			try
			{
				obj.Apply();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(bool)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			bool arg0 = LuaDLL.lua_toboolean(L, 2);

			try
			{
				obj.Apply(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(bool), typeof(bool)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			bool arg0 = LuaDLL.lua_toboolean(L, 2);
			bool arg1 = LuaDLL.lua_toboolean(L, 3);

			try
			{
				obj.Apply(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Texture2D.Apply");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Resize(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(int), typeof(int)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			bool o;

			try
			{
				o = obj.Resize(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(int), typeof(int), typeof(UnityEngine.TextureFormat), typeof(bool)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			UnityEngine.TextureFormat arg2 = (UnityEngine.TextureFormat)ToLua.ToObject(L, 4);
			bool arg3 = LuaDLL.lua_toboolean(L, 5);
			bool o;

			try
			{
				o = obj.Resize(arg0, arg1, arg2, arg3);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Texture2D.Resize");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Compress(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.CheckObject(L, 1, typeof(UnityEngine.Texture2D));
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.Compress(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PackTextures(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(UnityEngine.Texture2D[]), typeof(int)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			UnityEngine.Texture2D[] arg0 = ToLua.CheckObjectArray<UnityEngine.Texture2D>(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			UnityEngine.Rect[] o = null;

			try
			{
				o = obj.PackTextures(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(UnityEngine.Texture2D[]), typeof(int), typeof(int)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			UnityEngine.Texture2D[] arg0 = ToLua.CheckObjectArray<UnityEngine.Texture2D>(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			UnityEngine.Rect[] o = null;

			try
			{
				o = obj.PackTextures(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(UnityEngine.Texture2D[]), typeof(int), typeof(int), typeof(bool)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			UnityEngine.Texture2D[] arg0 = ToLua.CheckObjectArray<UnityEngine.Texture2D>(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			bool arg3 = LuaDLL.lua_toboolean(L, 5);
			UnityEngine.Rect[] o = null;

			try
			{
				o = obj.PackTextures(arg0, arg1, arg2, arg3);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Texture2D.PackTextures");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadPixels(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(UnityEngine.Rect), typeof(int), typeof(int)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			UnityEngine.Rect arg0 = (UnityEngine.Rect)ToLua.ToObject(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);

			try
			{
				obj.ReadPixels(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(UnityEngine.Rect), typeof(int), typeof(int), typeof(bool)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			UnityEngine.Rect arg0 = (UnityEngine.Rect)ToLua.ToObject(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			bool arg3 = LuaDLL.lua_toboolean(L, 5);

			try
			{
				obj.ReadPixels(arg0, arg1, arg2, arg3);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Texture2D.ReadPixels");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EncodeToPNG(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.CheckObject(L, 1, typeof(UnityEngine.Texture2D));
		byte[] o = null;

		try
		{
			o = obj.EncodeToPNG();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EncodeToJPG(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			byte[] o = null;

			try
			{
				o = obj.EncodeToJPG();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Texture2D), typeof(int)))
		{
			UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			byte[] o = null;

			try
			{
				o = obj.EncodeToJPG(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Texture2D.EncodeToJPG");
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
	static int get_mipmapCount(IntPtr L)
	{
		UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.mipmapCount;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mipmapCount on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_format(IntPtr L)
	{
		UnityEngine.Texture2D obj = (UnityEngine.Texture2D)ToLua.ToObject(L, 1);
		UnityEngine.TextureFormat ret;

		try
		{
			ret = obj.format;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index format on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_whiteTexture(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Texture2D.whiteTexture);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_blackTexture(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Texture2D.blackTexture);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.Texture2D>(L, new LuaOut<UnityEngine.Texture2D>());
		return 1;
	}
}

