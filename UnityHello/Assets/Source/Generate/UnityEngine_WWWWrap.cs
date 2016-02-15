using System;
using LuaInterface;

public class UnityEngine_WWWWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.WWW), typeof(System.Object));
		L.RegFunction("Dispose", Dispose);
		L.RegFunction("InitWWW", InitWWW);
		L.RegFunction("EscapeURL", EscapeURL);
		L.RegFunction("UnEscapeURL", UnEscapeURL);
		L.RegFunction("GetAudioClip", GetAudioClip);
		L.RegFunction("GetAudioClipCompressed", GetAudioClipCompressed);
		L.RegFunction("LoadImageIntoTexture", LoadImageIntoTexture);
		L.RegFunction("LoadFromCacheOrDownload", LoadFromCacheOrDownload);
		L.RegFunction("New", _CreateUnityEngine_WWW);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("responseHeaders", get_responseHeaders, null);
		L.RegVar("text", get_text, null);
		L.RegVar("bytes", get_bytes, null);
		L.RegVar("size", get_size, null);
		L.RegVar("error", get_error, null);
		L.RegVar("texture", get_texture, null);
		L.RegVar("textureNonReadable", get_textureNonReadable, null);
		L.RegVar("audioClip", get_audioClip, null);
		L.RegVar("isDone", get_isDone, null);
		L.RegVar("progress", get_progress, null);
		L.RegVar("uploadProgress", get_uploadProgress, null);
		L.RegVar("bytesDownloaded", get_bytesDownloaded, null);
		L.RegVar("url", get_url, null);
		L.RegVar("assetBundle", get_assetBundle, null);
		L.RegVar("threadPriority", get_threadPriority, set_threadPriority);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_WWW(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string arg0 = ToLua.CheckString(L, 1);
			UnityEngine.WWW obj = new UnityEngine.WWW(arg0);
			ToLua.PushObject(L, obj);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(string), typeof(byte[])))
		{
			string arg0 = ToLua.CheckString(L, 1);
			byte[] arg1 = ToLua.CheckByteBuffer(L, 2);
			UnityEngine.WWW obj = new UnityEngine.WWW(arg0, arg1);
			ToLua.PushObject(L, obj);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(string), typeof(UnityEngine.WWWForm)))
		{
			string arg0 = ToLua.CheckString(L, 1);
			UnityEngine.WWWForm arg1 = (UnityEngine.WWWForm)ToLua.CheckObject(L, 2, typeof(UnityEngine.WWWForm));
			UnityEngine.WWW obj = new UnityEngine.WWW(arg0, arg1);
			ToLua.PushObject(L, obj);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(string), typeof(byte[]), typeof(System.Collections.Generic.Dictionary<string,string>)))
		{
			string arg0 = ToLua.CheckString(L, 1);
			byte[] arg1 = ToLua.CheckByteBuffer(L, 2);
			System.Collections.Generic.Dictionary<string,string> arg2 = (System.Collections.Generic.Dictionary<string,string>)ToLua.CheckObject(L, 3, typeof(System.Collections.Generic.Dictionary<string,string>));
			UnityEngine.WWW obj = new UnityEngine.WWW(arg0, arg1, arg2);
			ToLua.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.WWW.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Dispose(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.CheckObject(L, 1, typeof(UnityEngine.WWW));

		try
		{
			obj.Dispose();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitWWW(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 4);
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.CheckObject(L, 1, typeof(UnityEngine.WWW));
		string arg0 = ToLua.CheckString(L, 2);
		byte[] arg1 = ToLua.CheckByteBuffer(L, 3);
		string[] arg2 = ToLua.CheckStringArray(L, 4);

		try
		{
			obj.InitWWW(arg0, arg1, arg2);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EscapeURL(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(string)))
		{
			string arg0 = ToLua.ToString(L, 1);
			string o = null;

			try
			{
				o = UnityEngine.WWW.EscapeURL(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(string), typeof(System.Text.Encoding)))
		{
			string arg0 = ToLua.ToString(L, 1);
			System.Text.Encoding arg1 = (System.Text.Encoding)ToLua.ToObject(L, 2);
			string o = null;

			try
			{
				o = UnityEngine.WWW.EscapeURL(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.WWW.EscapeURL");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnEscapeURL(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(string)))
		{
			string arg0 = ToLua.ToString(L, 1);
			string o = null;

			try
			{
				o = UnityEngine.WWW.UnEscapeURL(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(string), typeof(System.Text.Encoding)))
		{
			string arg0 = ToLua.ToString(L, 1);
			System.Text.Encoding arg1 = (System.Text.Encoding)ToLua.ToObject(L, 2);
			string o = null;

			try
			{
				o = UnityEngine.WWW.UnEscapeURL(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.WWW.UnEscapeURL");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAudioClip(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.WWW), typeof(bool)))
		{
			UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
			bool arg0 = LuaDLL.lua_toboolean(L, 2);
			UnityEngine.AudioClip o = null;

			try
			{
				o = obj.GetAudioClip(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.WWW), typeof(bool), typeof(bool)))
		{
			UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
			bool arg0 = LuaDLL.lua_toboolean(L, 2);
			bool arg1 = LuaDLL.lua_toboolean(L, 3);
			UnityEngine.AudioClip o = null;

			try
			{
				o = obj.GetAudioClip(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.WWW), typeof(bool), typeof(bool), typeof(UnityEngine.AudioType)))
		{
			UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
			bool arg0 = LuaDLL.lua_toboolean(L, 2);
			bool arg1 = LuaDLL.lua_toboolean(L, 3);
			UnityEngine.AudioType arg2 = (UnityEngine.AudioType)ToLua.ToObject(L, 4);
			UnityEngine.AudioClip o = null;

			try
			{
				o = obj.GetAudioClip(arg0, arg1, arg2);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.WWW.GetAudioClip");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAudioClipCompressed(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.WWW)))
		{
			UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
			UnityEngine.AudioClip o = null;

			try
			{
				o = obj.GetAudioClipCompressed();
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.WWW), typeof(bool)))
		{
			UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
			bool arg0 = LuaDLL.lua_toboolean(L, 2);
			UnityEngine.AudioClip o = null;

			try
			{
				o = obj.GetAudioClipCompressed(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.WWW), typeof(bool), typeof(UnityEngine.AudioType)))
		{
			UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
			bool arg0 = LuaDLL.lua_toboolean(L, 2);
			UnityEngine.AudioType arg1 = (UnityEngine.AudioType)ToLua.ToObject(L, 3);
			UnityEngine.AudioClip o = null;

			try
			{
				o = obj.GetAudioClipCompressed(arg0, arg1);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.WWW.GetAudioClipCompressed");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadImageIntoTexture(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.CheckObject(L, 1, typeof(UnityEngine.WWW));
		UnityEngine.Texture2D arg0 = (UnityEngine.Texture2D)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Texture2D));

		try
		{
			obj.LoadImageIntoTexture(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadFromCacheOrDownload(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(string), typeof(UnityEngine.Hash128)))
		{
			string arg0 = ToLua.ToString(L, 1);
			UnityEngine.Hash128 arg1 = (UnityEngine.Hash128)ToLua.ToObject(L, 2);
			UnityEngine.WWW o = null;

			try
			{
				o = UnityEngine.WWW.LoadFromCacheOrDownload(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(string), typeof(int)))
		{
			string arg0 = ToLua.ToString(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.WWW o = null;

			try
			{
				o = UnityEngine.WWW.LoadFromCacheOrDownload(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(string), typeof(UnityEngine.Hash128), typeof(uint)))
		{
			string arg0 = ToLua.ToString(L, 1);
			UnityEngine.Hash128 arg1 = (UnityEngine.Hash128)ToLua.ToObject(L, 2);
			uint arg2 = (uint)LuaDLL.lua_tonumber(L, 3);
			UnityEngine.WWW o = null;

			try
			{
				o = UnityEngine.WWW.LoadFromCacheOrDownload(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(string), typeof(int), typeof(uint)))
		{
			string arg0 = ToLua.ToString(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			uint arg2 = (uint)LuaDLL.lua_tonumber(L, 3);
			UnityEngine.WWW o = null;

			try
			{
				o = UnityEngine.WWW.LoadFromCacheOrDownload(arg0, arg1, arg2);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.WWW.LoadFromCacheOrDownload");
		}

		return 0;
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
	static int get_responseHeaders(IntPtr L)
	{
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
		System.Collections.Generic.Dictionary<string,string> ret = null;

		try
		{
			ret = obj.responseHeaders;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index responseHeaders on a nil value" : e.Message);
		}

		ToLua.PushObject(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_text(IntPtr L)
	{
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
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
	static int get_bytes(IntPtr L)
	{
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
		byte[] ret = null;

		try
		{
			ret = obj.bytes;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index bytes on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_size(IntPtr L)
	{
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.size;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index size on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_error(IntPtr L)
	{
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
		string ret = null;

		try
		{
			ret = obj.error;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index error on a nil value" : e.Message);
		}

		LuaDLL.lua_pushstring(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_texture(IntPtr L)
	{
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
		UnityEngine.Texture2D ret = null;

		try
		{
			ret = obj.texture;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index texture on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_textureNonReadable(IntPtr L)
	{
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
		UnityEngine.Texture2D ret = null;

		try
		{
			ret = obj.textureNonReadable;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index textureNonReadable on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_audioClip(IntPtr L)
	{
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
		UnityEngine.AudioClip ret = null;

		try
		{
			ret = obj.audioClip;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index audioClip on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isDone(IntPtr L)
	{
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.isDone;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isDone on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_progress(IntPtr L)
	{
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.progress;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index progress on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uploadProgress(IntPtr L)
	{
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.uploadProgress;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index uploadProgress on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bytesDownloaded(IntPtr L)
	{
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.bytesDownloaded;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index bytesDownloaded on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_url(IntPtr L)
	{
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
		string ret = null;

		try
		{
			ret = obj.url;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index url on a nil value" : e.Message);
		}

		LuaDLL.lua_pushstring(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_assetBundle(IntPtr L)
	{
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
		UnityEngine.AssetBundle ret = null;

		try
		{
			ret = obj.assetBundle;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index assetBundle on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_threadPriority(IntPtr L)
	{
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
		UnityEngine.ThreadPriority ret;

		try
		{
			ret = obj.threadPriority;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index threadPriority on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_threadPriority(IntPtr L)
	{
		UnityEngine.WWW obj = (UnityEngine.WWW)ToLua.ToObject(L, 1);
		UnityEngine.ThreadPriority arg0 = (UnityEngine.ThreadPriority)ToLua.CheckObject(L, 2, typeof(UnityEngine.ThreadPriority));

		try
		{
			obj.threadPriority = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index threadPriority on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.WWW>(L, new LuaOut<UnityEngine.WWW>());
		return 1;
	}
}

