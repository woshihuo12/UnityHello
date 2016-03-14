﻿using System;
using LuaInterface;

public class UnityEngine_RigidbodyWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Component));
		L.RegFunction("SetDensity", SetDensity);
		L.RegFunction("AddForce", AddForce);
		L.RegFunction("AddRelativeForce", AddRelativeForce);
		L.RegFunction("AddTorque", AddTorque);
		L.RegFunction("AddRelativeTorque", AddRelativeTorque);
		L.RegFunction("AddForceAtPosition", AddForceAtPosition);
		L.RegFunction("AddExplosionForce", AddExplosionForce);
		L.RegFunction("ClosestPointOnBounds", ClosestPointOnBounds);
		L.RegFunction("GetRelativePointVelocity", GetRelativePointVelocity);
		L.RegFunction("GetPointVelocity", GetPointVelocity);
		L.RegFunction("MovePosition", MovePosition);
		L.RegFunction("MoveRotation", MoveRotation);
		L.RegFunction("Sleep", Sleep);
		L.RegFunction("IsSleeping", IsSleeping);
		L.RegFunction("WakeUp", WakeUp);
		L.RegFunction("ResetCenterOfMass", ResetCenterOfMass);
		L.RegFunction("ResetInertiaTensor", ResetInertiaTensor);
		L.RegFunction("SweepTest", SweepTest);
		L.RegFunction("SweepTestAll", SweepTestAll);
		L.RegFunction("New", _CreateUnityEngine_Rigidbody);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("velocity", get_velocity, set_velocity);
		L.RegVar("angularVelocity", get_angularVelocity, set_angularVelocity);
		L.RegVar("drag", get_drag, set_drag);
		L.RegVar("angularDrag", get_angularDrag, set_angularDrag);
		L.RegVar("mass", get_mass, set_mass);
		L.RegVar("useGravity", get_useGravity, set_useGravity);
		L.RegVar("maxDepenetrationVelocity", get_maxDepenetrationVelocity, set_maxDepenetrationVelocity);
		L.RegVar("isKinematic", get_isKinematic, set_isKinematic);
		L.RegVar("freezeRotation", get_freezeRotation, set_freezeRotation);
		L.RegVar("constraints", get_constraints, set_constraints);
		L.RegVar("collisionDetectionMode", get_collisionDetectionMode, set_collisionDetectionMode);
		L.RegVar("centerOfMass", get_centerOfMass, set_centerOfMass);
		L.RegVar("worldCenterOfMass", get_worldCenterOfMass, null);
		L.RegVar("inertiaTensorRotation", get_inertiaTensorRotation, set_inertiaTensorRotation);
		L.RegVar("inertiaTensor", get_inertiaTensor, set_inertiaTensor);
		L.RegVar("detectCollisions", get_detectCollisions, set_detectCollisions);
		L.RegVar("useConeFriction", get_useConeFriction, set_useConeFriction);
		L.RegVar("position", get_position, set_position);
		L.RegVar("rotation", get_rotation, set_rotation);
		L.RegVar("interpolation", get_interpolation, set_interpolation);
		L.RegVar("solverIterationCount", get_solverIterationCount, set_solverIterationCount);
		L.RegVar("sleepThreshold", get_sleepThreshold, set_sleepThreshold);
		L.RegVar("maxAngularVelocity", get_maxAngularVelocity, set_maxAngularVelocity);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Rigidbody(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.Rigidbody obj = new UnityEngine.Rigidbody();
			ToLua.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Rigidbody.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetDensity(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.SetDensity(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddForce(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
				obj.AddForce(arg0);
				return 0;
			}
			else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(UnityEngine.ForceMode)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
				UnityEngine.ForceMode arg1 = (UnityEngine.ForceMode)ToLua.ToObject(L, 3);
				obj.AddForce(arg0, arg1);
				return 0;
			}
			else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(float), typeof(float)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				obj.AddForce(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(float), typeof(float), typeof(UnityEngine.ForceMode)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				UnityEngine.ForceMode arg3 = (UnityEngine.ForceMode)ToLua.ToObject(L, 5);
				obj.AddForce(arg0, arg1, arg2, arg3);
				return 0;
			}
			else
			{
				return LuaDLL.tolua_error(L, "invalid arguments to method: UnityEngine.Rigidbody.AddForce");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddRelativeForce(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
				obj.AddRelativeForce(arg0);
				return 0;
			}
			else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(UnityEngine.ForceMode)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
				UnityEngine.ForceMode arg1 = (UnityEngine.ForceMode)ToLua.ToObject(L, 3);
				obj.AddRelativeForce(arg0, arg1);
				return 0;
			}
			else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(float), typeof(float)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				obj.AddRelativeForce(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(float), typeof(float), typeof(UnityEngine.ForceMode)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				UnityEngine.ForceMode arg3 = (UnityEngine.ForceMode)ToLua.ToObject(L, 5);
				obj.AddRelativeForce(arg0, arg1, arg2, arg3);
				return 0;
			}
			else
			{
				return LuaDLL.tolua_error(L, "invalid arguments to method: UnityEngine.Rigidbody.AddRelativeForce");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddTorque(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
				obj.AddTorque(arg0);
				return 0;
			}
			else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(UnityEngine.ForceMode)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
				UnityEngine.ForceMode arg1 = (UnityEngine.ForceMode)ToLua.ToObject(L, 3);
				obj.AddTorque(arg0, arg1);
				return 0;
			}
			else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(float), typeof(float)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				obj.AddTorque(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(float), typeof(float), typeof(UnityEngine.ForceMode)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				UnityEngine.ForceMode arg3 = (UnityEngine.ForceMode)ToLua.ToObject(L, 5);
				obj.AddTorque(arg0, arg1, arg2, arg3);
				return 0;
			}
			else
			{
				return LuaDLL.tolua_error(L, "invalid arguments to method: UnityEngine.Rigidbody.AddTorque");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddRelativeTorque(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
				obj.AddRelativeTorque(arg0);
				return 0;
			}
			else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(UnityEngine.ForceMode)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
				UnityEngine.ForceMode arg1 = (UnityEngine.ForceMode)ToLua.ToObject(L, 3);
				obj.AddRelativeTorque(arg0, arg1);
				return 0;
			}
			else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(float), typeof(float)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				obj.AddRelativeTorque(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(float), typeof(float), typeof(UnityEngine.ForceMode)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				UnityEngine.ForceMode arg3 = (UnityEngine.ForceMode)ToLua.ToObject(L, 5);
				obj.AddRelativeTorque(arg0, arg1, arg2, arg3);
				return 0;
			}
			else
			{
				return LuaDLL.tolua_error(L, "invalid arguments to method: UnityEngine.Rigidbody.AddRelativeTorque");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddForceAtPosition(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(UnityEngine.Vector3)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
				UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
				obj.AddForceAtPosition(arg0, arg1);
				return 0;
			}
			else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(UnityEngine.Vector3), typeof(UnityEngine.ForceMode)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
				UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
				UnityEngine.ForceMode arg2 = (UnityEngine.ForceMode)ToLua.ToObject(L, 4);
				obj.AddForceAtPosition(arg0, arg1, arg2);
				return 0;
			}
			else
			{
				return LuaDLL.tolua_error(L, "invalid arguments to method: UnityEngine.Rigidbody.AddForceAtPosition");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddExplosionForce(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(UnityEngine.Vector3), typeof(float)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
				UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				obj.AddExplosionForce(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(UnityEngine.Vector3), typeof(float), typeof(float)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
				UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				float arg3 = (float)LuaDLL.lua_tonumber(L, 5);
				obj.AddExplosionForce(arg0, arg1, arg2, arg3);
				return 0;
			}
			else if (count == 6 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(UnityEngine.Vector3), typeof(float), typeof(float), typeof(UnityEngine.ForceMode)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
				UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				float arg3 = (float)LuaDLL.lua_tonumber(L, 5);
				UnityEngine.ForceMode arg4 = (UnityEngine.ForceMode)ToLua.ToObject(L, 6);
				obj.AddExplosionForce(arg0, arg1, arg2, arg3, arg4);
				return 0;
			}
			else
			{
				return LuaDLL.tolua_error(L, "invalid arguments to method: UnityEngine.Rigidbody.AddExplosionForce");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClosestPointOnBounds(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o = obj.ClosestPointOnBounds(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRelativePointVelocity(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o = obj.GetRelativePointVelocity(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPointVelocity(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o = obj.GetPointVelocity(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MovePosition(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.MovePosition(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MoveRotation(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
			UnityEngine.Quaternion arg0 = ToLua.ToQuaternion(L, 2);
			obj.MoveRotation(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Sleep(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
			obj.Sleep();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsSleeping(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
			bool o = obj.IsSleeping();
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WakeUp(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
			obj.WakeUp();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetCenterOfMass(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
			obj.ResetCenterOfMass();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetInertiaTensor(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
			obj.ResetInertiaTensor();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SweepTest(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(LuaInterface.LuaOut<UnityEngine.RaycastHit>)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
				UnityEngine.RaycastHit arg1;
				bool o = obj.SweepTest(arg0, out arg1);
				LuaDLL.lua_pushboolean(L, o);
				ToLua.Push(L, arg1);
				return 2;
			}
			else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(LuaInterface.LuaOut<UnityEngine.RaycastHit>), typeof(float)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
				UnityEngine.RaycastHit arg1;
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				bool o = obj.SweepTest(arg0, out arg1, arg2);
				LuaDLL.lua_pushboolean(L, o);
				ToLua.Push(L, arg1);
				return 2;
			}
			else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(LuaInterface.LuaOut<UnityEngine.RaycastHit>), typeof(float), typeof(UnityEngine.QueryTriggerInteraction)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
				UnityEngine.RaycastHit arg1;
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				UnityEngine.QueryTriggerInteraction arg3 = (UnityEngine.QueryTriggerInteraction)ToLua.ToObject(L, 5);
				bool o = obj.SweepTest(arg0, out arg1, arg2, arg3);
				LuaDLL.lua_pushboolean(L, o);
				ToLua.Push(L, arg1);
				return 2;
			}
			else
			{
				return LuaDLL.tolua_error(L, "invalid arguments to method: UnityEngine.Rigidbody.SweepTest");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SweepTestAll(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
				UnityEngine.RaycastHit[] o = obj.SweepTestAll(arg0);
				ToLua.Push(L, o);
				return 1;
			}
			else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(float)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
				UnityEngine.RaycastHit[] o = obj.SweepTestAll(arg0, arg1);
				ToLua.Push(L, o);
				return 1;
			}
			else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(float), typeof(UnityEngine.QueryTriggerInteraction)))
			{
				UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
				UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
				float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
				UnityEngine.QueryTriggerInteraction arg2 = (UnityEngine.QueryTriggerInteraction)ToLua.ToObject(L, 4);
				UnityEngine.RaycastHit[] o = obj.SweepTestAll(arg0, arg1, arg2);
				ToLua.Push(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.tolua_error(L, "invalid arguments to method: UnityEngine.Rigidbody.SweepTestAll");
			}
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
	static int get_velocity(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
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
	static int get_angularVelocity(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.Vector3 ret = obj.angularVelocity;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index angularVelocity on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_drag(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			float ret = obj.drag;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index drag on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_angularDrag(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			float ret = obj.angularDrag;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index angularDrag on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mass(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			float ret = obj.mass;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index mass on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useGravity(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			bool ret = obj.useGravity;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index useGravity on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxDepenetrationVelocity(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			float ret = obj.maxDepenetrationVelocity;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index maxDepenetrationVelocity on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isKinematic(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			bool ret = obj.isKinematic;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index isKinematic on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_freezeRotation(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			bool ret = obj.freezeRotation;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index freezeRotation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_constraints(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.RigidbodyConstraints ret = obj.constraints;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index constraints on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_collisionDetectionMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.CollisionDetectionMode ret = obj.collisionDetectionMode;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index collisionDetectionMode on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_centerOfMass(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.Vector3 ret = obj.centerOfMass;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index centerOfMass on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_worldCenterOfMass(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.Vector3 ret = obj.worldCenterOfMass;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index worldCenterOfMass on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_inertiaTensorRotation(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.Quaternion ret = obj.inertiaTensorRotation;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index inertiaTensorRotation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_inertiaTensor(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.Vector3 ret = obj.inertiaTensor;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index inertiaTensor on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_detectCollisions(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			bool ret = obj.detectCollisions;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index detectCollisions on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useConeFriction(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			bool ret = obj.useConeFriction;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index useConeFriction on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_position(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.Vector3 ret = obj.position;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index position on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotation(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.Quaternion ret = obj.rotation;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index rotation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_interpolation(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.RigidbodyInterpolation ret = obj.interpolation;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index interpolation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_solverIterationCount(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			int ret = obj.solverIterationCount;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index solverIterationCount on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sleepThreshold(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			float ret = obj.sleepThreshold;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sleepThreshold on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxAngularVelocity(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			float ret = obj.maxAngularVelocity;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index maxAngularVelocity on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_velocity(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.velocity = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index velocity on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_angularVelocity(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.angularVelocity = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index angularVelocity on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_drag(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.drag = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index drag on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_angularDrag(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.angularDrag = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index angularDrag on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mass(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.mass = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index mass on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useGravity(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.useGravity = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index useGravity on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxDepenetrationVelocity(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.maxDepenetrationVelocity = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index maxDepenetrationVelocity on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isKinematic(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.isKinematic = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index isKinematic on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_freezeRotation(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.freezeRotation = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index freezeRotation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_constraints(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.RigidbodyConstraints arg0 = (UnityEngine.RigidbodyConstraints)ToLua.CheckObject(L, 2, typeof(UnityEngine.RigidbodyConstraints));
			obj.constraints = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index constraints on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_collisionDetectionMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.CollisionDetectionMode arg0 = (UnityEngine.CollisionDetectionMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.CollisionDetectionMode));
			obj.collisionDetectionMode = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index collisionDetectionMode on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_centerOfMass(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.centerOfMass = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index centerOfMass on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_inertiaTensorRotation(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.Quaternion arg0 = ToLua.ToQuaternion(L, 2);
			obj.inertiaTensorRotation = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index inertiaTensorRotation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_inertiaTensor(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.inertiaTensor = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index inertiaTensor on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_detectCollisions(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.detectCollisions = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index detectCollisions on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useConeFriction(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.useConeFriction = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index useConeFriction on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_position(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.position = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index position on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rotation(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.Quaternion arg0 = ToLua.ToQuaternion(L, 2);
			obj.rotation = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index rotation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_interpolation(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			UnityEngine.RigidbodyInterpolation arg0 = (UnityEngine.RigidbodyInterpolation)ToLua.CheckObject(L, 2, typeof(UnityEngine.RigidbodyInterpolation));
			obj.interpolation = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index interpolation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_solverIterationCount(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.solverIterationCount = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index solverIterationCount on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sleepThreshold(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.sleepThreshold = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sleepThreshold on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxAngularVelocity(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.maxAngularVelocity = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index maxAngularVelocity on a nil value" : e.Message);
		}
	}
}

