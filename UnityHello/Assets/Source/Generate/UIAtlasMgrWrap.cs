﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UIAtlasMgrWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIAtlasMgr), typeof(System.Object));
		L.RegFunction("Instance", Instance);
		L.RegFunction("GetSprite", GetSprite);
		L.RegFunction("New", _CreateUIAtlasMgr);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUIAtlasMgr(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UIAtlasMgr obj = new UIAtlasMgr();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UIAtlasMgr.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Instance(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			UIAtlasMgr o = UIAtlasMgr.Instance();
			ToLua.PushObject(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSprite(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			UIAtlasMgr obj = (UIAtlasMgr)ToLua.CheckObject(L, 1, typeof(UIAtlasMgr));
			string arg0 = ToLua.CheckString(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			LuaFunction arg2 = ToLua.CheckLuaFunction(L, 4);
			obj.GetSprite(arg0, arg1, arg2);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

