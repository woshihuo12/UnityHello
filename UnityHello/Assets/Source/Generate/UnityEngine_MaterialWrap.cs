using System;
using LuaInterface;

public class UnityEngine_MaterialWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Material), typeof(UnityEngine.Object));
		L.RegFunction("SetColor", SetColor);
		L.RegFunction("GetColor", GetColor);
		L.RegFunction("SetVector", SetVector);
		L.RegFunction("GetVector", GetVector);
		L.RegFunction("SetTexture", SetTexture);
		L.RegFunction("GetTexture", GetTexture);
		L.RegFunction("SetTextureOffset", SetTextureOffset);
		L.RegFunction("GetTextureOffset", GetTextureOffset);
		L.RegFunction("SetTextureScale", SetTextureScale);
		L.RegFunction("GetTextureScale", GetTextureScale);
		L.RegFunction("SetMatrix", SetMatrix);
		L.RegFunction("GetMatrix", GetMatrix);
		L.RegFunction("SetFloat", SetFloat);
		L.RegFunction("GetFloat", GetFloat);
		L.RegFunction("SetInt", SetInt);
		L.RegFunction("GetInt", GetInt);
		L.RegFunction("SetBuffer", SetBuffer);
		L.RegFunction("HasProperty", HasProperty);
		L.RegFunction("GetTag", GetTag);
		L.RegFunction("SetOverrideTag", SetOverrideTag);
		L.RegFunction("Lerp", Lerp);
		L.RegFunction("SetPass", SetPass);
		L.RegFunction("CopyPropertiesFromMaterial", CopyPropertiesFromMaterial);
		L.RegFunction("EnableKeyword", EnableKeyword);
		L.RegFunction("DisableKeyword", DisableKeyword);
		L.RegFunction("IsKeywordEnabled", IsKeywordEnabled);
		L.RegFunction("New", _CreateUnityEngine_Material);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("shader", get_shader, set_shader);
		L.RegVar("color", get_color, set_color);
		L.RegVar("mainTexture", get_mainTexture, set_mainTexture);
		L.RegVar("mainTextureOffset", get_mainTextureOffset, set_mainTextureOffset);
		L.RegVar("mainTextureScale", get_mainTextureScale, set_mainTextureScale);
		L.RegVar("passCount", get_passCount, null);
		L.RegVar("renderQueue", get_renderQueue, set_renderQueue);
		L.RegVar("shaderKeywords", get_shaderKeywords, set_shaderKeywords);
		L.RegVar("globalIlluminationFlags", get_globalIlluminationFlags, set_globalIlluminationFlags);
		L.RegVar("out", get_out, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Material(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material)))
		{
			UnityEngine.Material arg0 = (UnityEngine.Material)ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.Material));
			UnityEngine.Material obj = new UnityEngine.Material(arg0);
			ToLua.Push(L, obj);
			return 1;
		}
		else if (count == 1 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Shader)))
		{
			UnityEngine.Shader arg0 = (UnityEngine.Shader)ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.Shader));
			UnityEngine.Material obj = new UnityEngine.Material(arg0);
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Material.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetColor(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(int), typeof(UnityEngine.Color)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.Color arg1 = ToLua.ToColor(L, 3);

			try
			{
				obj.SetColor(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(string), typeof(UnityEngine.Color)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.Color arg1 = ToLua.ToColor(L, 3);

			try
			{
				obj.SetColor(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Material.SetColor");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetColor(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(int)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.Color o;

			try
			{
				o = obj.GetColor(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(string)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.Color o;

			try
			{
				o = obj.GetColor(arg0);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Material.GetColor");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetVector(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(int), typeof(UnityEngine.Vector4)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.Vector4 arg1 = ToLua.ToVector4(L, 3);

			try
			{
				obj.SetVector(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(string), typeof(UnityEngine.Vector4)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.Vector4 arg1 = ToLua.ToVector4(L, 3);

			try
			{
				obj.SetVector(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Material.SetVector");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetVector(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(int)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.Vector4 o;

			try
			{
				o = obj.GetVector(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(string)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.Vector4 o;

			try
			{
				o = obj.GetVector(arg0);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Material.GetVector");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(int), typeof(UnityEngine.Texture)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.Texture arg1 = (UnityEngine.Texture)ToLua.ToObject(L, 3);

			try
			{
				obj.SetTexture(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(string), typeof(UnityEngine.Texture)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.Texture arg1 = (UnityEngine.Texture)ToLua.ToObject(L, 3);

			try
			{
				obj.SetTexture(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Material.SetTexture");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(int)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.Texture o = null;

			try
			{
				o = obj.GetTexture(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(string)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.Texture o = null;

			try
			{
				o = obj.GetTexture(arg0);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Material.GetTexture");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTextureOffset(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.CheckObject(L, 1, typeof(UnityEngine.Material));
		string arg0 = ToLua.CheckString(L, 2);
		UnityEngine.Vector2 arg1 = ToLua.ToVector2(L, 3);

		try
		{
			obj.SetTextureOffset(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTextureOffset(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.CheckObject(L, 1, typeof(UnityEngine.Material));
		string arg0 = ToLua.CheckString(L, 2);
		UnityEngine.Vector2 o;

		try
		{
			o = obj.GetTextureOffset(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTextureScale(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.CheckObject(L, 1, typeof(UnityEngine.Material));
		string arg0 = ToLua.CheckString(L, 2);
		UnityEngine.Vector2 arg1 = ToLua.ToVector2(L, 3);

		try
		{
			obj.SetTextureScale(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTextureScale(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.CheckObject(L, 1, typeof(UnityEngine.Material));
		string arg0 = ToLua.CheckString(L, 2);
		UnityEngine.Vector2 o;

		try
		{
			o = obj.GetTextureScale(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetMatrix(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(int), typeof(UnityEngine.Matrix4x4)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.Matrix4x4 arg1 = (UnityEngine.Matrix4x4)ToLua.ToObject(L, 3);

			try
			{
				obj.SetMatrix(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(string), typeof(UnityEngine.Matrix4x4)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.Matrix4x4 arg1 = (UnityEngine.Matrix4x4)ToLua.ToObject(L, 3);

			try
			{
				obj.SetMatrix(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Material.SetMatrix");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMatrix(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(int)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.Matrix4x4 o;

			try
			{
				o = obj.GetMatrix(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushValue(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(string)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			UnityEngine.Matrix4x4 o;

			try
			{
				o = obj.GetMatrix(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Material.GetMatrix");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetFloat(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(int), typeof(float)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);

			try
			{
				obj.SetFloat(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(string), typeof(float)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);

			try
			{
				obj.SetFloat(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Material.SetFloat");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFloat(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(int)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			float o;

			try
			{
				o = obj.GetFloat(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(string)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			float o;

			try
			{
				o = obj.GetFloat(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Material.GetFloat");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetInt(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(int), typeof(int)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);

			try
			{
				obj.SetInt(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(string), typeof(int)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);

			try
			{
				obj.SetInt(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Material.SetInt");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInt(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(int)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			int o;

			try
			{
				o = obj.GetInt(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushinteger(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(string)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			int o;

			try
			{
				o = obj.GetInt(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushinteger(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Material.GetInt");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetBuffer(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.CheckObject(L, 1, typeof(UnityEngine.Material));
		string arg0 = ToLua.CheckString(L, 2);
		UnityEngine.ComputeBuffer arg1 = (UnityEngine.ComputeBuffer)ToLua.CheckObject(L, 3, typeof(UnityEngine.ComputeBuffer));

		try
		{
			obj.SetBuffer(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HasProperty(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(int)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			bool o;

			try
			{
				o = obj.HasProperty(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		else if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(string)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			bool o;

			try
			{
				o = obj.HasProperty(arg0);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Material.HasProperty");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTag(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(string), typeof(bool)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			bool arg1 = LuaDLL.lua_toboolean(L, 3);
			string o = null;

			try
			{
				o = obj.GetTag(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Material), typeof(string), typeof(bool), typeof(string)))
		{
			UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
			string arg0 = ToLua.ToString(L, 2);
			bool arg1 = LuaDLL.lua_toboolean(L, 3);
			string arg2 = ToLua.ToString(L, 4);
			string o = null;

			try
			{
				o = obj.GetTag(arg0, arg1, arg2);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Material.GetTag");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetOverrideTag(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 3);
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.CheckObject(L, 1, typeof(UnityEngine.Material));
		string arg0 = ToLua.CheckString(L, 2);
		string arg1 = ToLua.CheckString(L, 3);

		try
		{
			obj.SetOverrideTag(arg0, arg1);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lerp(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 4);
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.CheckObject(L, 1, typeof(UnityEngine.Material));
		UnityEngine.Material arg0 = (UnityEngine.Material)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Material));
		UnityEngine.Material arg1 = (UnityEngine.Material)ToLua.CheckUnityObject(L, 3, typeof(UnityEngine.Material));
		float arg2 = (float)LuaDLL.luaL_checknumber(L, 4);

		try
		{
			obj.Lerp(arg0, arg1, arg2);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPass(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.CheckObject(L, 1, typeof(UnityEngine.Material));
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
		bool o;

		try
		{
			o = obj.SetPass(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CopyPropertiesFromMaterial(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.CheckObject(L, 1, typeof(UnityEngine.Material));
		UnityEngine.Material arg0 = (UnityEngine.Material)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Material));

		try
		{
			obj.CopyPropertiesFromMaterial(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EnableKeyword(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.CheckObject(L, 1, typeof(UnityEngine.Material));
		string arg0 = ToLua.CheckString(L, 2);

		try
		{
			obj.EnableKeyword(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DisableKeyword(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.CheckObject(L, 1, typeof(UnityEngine.Material));
		string arg0 = ToLua.CheckString(L, 2);

		try
		{
			obj.DisableKeyword(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsKeywordEnabled(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.CheckObject(L, 1, typeof(UnityEngine.Material));
		string arg0 = ToLua.CheckString(L, 2);
		bool o;

		try
		{
			o = obj.IsKeywordEnabled(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
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
	static int get_shader(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		UnityEngine.Shader ret = null;

		try
		{
			ret = obj.shader;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index shader on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_color(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		UnityEngine.Color ret;

		try
		{
			ret = obj.color;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index color on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainTexture(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		UnityEngine.Texture ret = null;

		try
		{
			ret = obj.mainTexture;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mainTexture on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainTextureOffset(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 ret;

		try
		{
			ret = obj.mainTextureOffset;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mainTextureOffset on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainTextureScale(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 ret;

		try
		{
			ret = obj.mainTextureScale;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mainTextureScale on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_passCount(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.passCount;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index passCount on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_renderQueue(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.renderQueue;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index renderQueue on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shaderKeywords(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		string[] ret = null;

		try
		{
			ret = obj.shaderKeywords;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index shaderKeywords on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_globalIlluminationFlags(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		UnityEngine.MaterialGlobalIlluminationFlags ret;

		try
		{
			ret = obj.globalIlluminationFlags;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index globalIlluminationFlags on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shader(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		UnityEngine.Shader arg0 = (UnityEngine.Shader)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Shader));

		try
		{
			obj.shader = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index shader on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_color(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		UnityEngine.Color arg0 = ToLua.ToColor(L, 2);

		try
		{
			obj.color = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index color on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainTexture(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		UnityEngine.Texture arg0 = (UnityEngine.Texture)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Texture));

		try
		{
			obj.mainTexture = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mainTexture on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainTextureOffset(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);

		try
		{
			obj.mainTextureOffset = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mainTextureOffset on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainTextureScale(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);

		try
		{
			obj.mainTextureScale = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mainTextureScale on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_renderQueue(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.renderQueue = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index renderQueue on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shaderKeywords(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		string[] arg0 = ToLua.CheckStringArray(L, 2);

		try
		{
			obj.shaderKeywords = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index shaderKeywords on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_globalIlluminationFlags(IntPtr L)
	{
		UnityEngine.Material obj = (UnityEngine.Material)ToLua.ToObject(L, 1);
		UnityEngine.MaterialGlobalIlluminationFlags arg0 = (UnityEngine.MaterialGlobalIlluminationFlags)ToLua.CheckObject(L, 2, typeof(UnityEngine.MaterialGlobalIlluminationFlags));

		try
		{
			obj.globalIlluminationFlags = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index globalIlluminationFlags on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.Material>(L, new LuaOut<UnityEngine.Material>());
		return 1;
	}
}

