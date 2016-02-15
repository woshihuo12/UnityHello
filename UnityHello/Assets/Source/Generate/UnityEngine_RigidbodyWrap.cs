using System;
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
		L.RegVar("out", get_out, null);
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
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.SetDensity(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddForce(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

			try
			{
				obj.AddForce(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(UnityEngine.ForceMode)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.ForceMode arg1 = (UnityEngine.ForceMode)ToLua.ToObject(L, 3);

			try
			{
				obj.AddForce(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(float), typeof(float)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);

			try
			{
				obj.AddForce(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(float), typeof(float), typeof(UnityEngine.ForceMode)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
			UnityEngine.ForceMode arg3 = (UnityEngine.ForceMode)ToLua.ToObject(L, 5);

			try
			{
				obj.AddForce(arg0, arg1, arg2, arg3);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Rigidbody.AddForce");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddRelativeForce(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

			try
			{
				obj.AddRelativeForce(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(UnityEngine.ForceMode)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.ForceMode arg1 = (UnityEngine.ForceMode)ToLua.ToObject(L, 3);

			try
			{
				obj.AddRelativeForce(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(float), typeof(float)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);

			try
			{
				obj.AddRelativeForce(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(float), typeof(float), typeof(UnityEngine.ForceMode)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
			UnityEngine.ForceMode arg3 = (UnityEngine.ForceMode)ToLua.ToObject(L, 5);

			try
			{
				obj.AddRelativeForce(arg0, arg1, arg2, arg3);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Rigidbody.AddRelativeForce");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddTorque(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

			try
			{
				obj.AddTorque(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(UnityEngine.ForceMode)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.ForceMode arg1 = (UnityEngine.ForceMode)ToLua.ToObject(L, 3);

			try
			{
				obj.AddTorque(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(float), typeof(float)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);

			try
			{
				obj.AddTorque(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(float), typeof(float), typeof(UnityEngine.ForceMode)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
			UnityEngine.ForceMode arg3 = (UnityEngine.ForceMode)ToLua.ToObject(L, 5);

			try
			{
				obj.AddTorque(arg0, arg1, arg2, arg3);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Rigidbody.AddTorque");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddRelativeTorque(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

			try
			{
				obj.AddRelativeTorque(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(UnityEngine.ForceMode)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.ForceMode arg1 = (UnityEngine.ForceMode)ToLua.ToObject(L, 3);

			try
			{
				obj.AddRelativeTorque(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(float), typeof(float)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);

			try
			{
				obj.AddRelativeTorque(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(float), typeof(float), typeof(UnityEngine.ForceMode)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
			UnityEngine.ForceMode arg3 = (UnityEngine.ForceMode)ToLua.ToObject(L, 5);

			try
			{
				obj.AddRelativeTorque(arg0, arg1, arg2, arg3);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Rigidbody.AddRelativeTorque");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddForceAtPosition(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);

			try
			{
				obj.AddForceAtPosition(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(UnityEngine.Vector3), typeof(UnityEngine.ForceMode)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
			UnityEngine.ForceMode arg2 = (UnityEngine.ForceMode)ToLua.ToObject(L, 4);

			try
			{
				obj.AddForceAtPosition(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Rigidbody.AddForceAtPosition");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddExplosionForce(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(UnityEngine.Vector3), typeof(float)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);

			try
			{
				obj.AddExplosionForce(arg0, arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else if (count == 5 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(float), typeof(UnityEngine.Vector3), typeof(float), typeof(float)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
			float arg3 = (float)LuaDLL.lua_tonumber(L, 5);

			try
			{
				obj.AddExplosionForce(arg0, arg1, arg2, arg3);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

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

			try
			{
				obj.AddExplosionForce(arg0, arg1, arg2, arg3, arg4);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Rigidbody.AddExplosionForce");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClosestPointOnBounds(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.Vector3 o;

		try
		{
			o = obj.ClosestPointOnBounds(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRelativePointVelocity(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.Vector3 o;

		try
		{
			o = obj.GetRelativePointVelocity(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPointVelocity(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
		UnityEngine.Vector3 o;

		try
		{
			o = obj.GetPointVelocity(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		ToLua.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MovePosition(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.MovePosition(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MoveRotation(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 2);
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
		UnityEngine.Quaternion arg0 = ToLua.ToQuaternion(L, 2);

		try
		{
			obj.MoveRotation(arg0);
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Sleep(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));

		try
		{
			obj.Sleep();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsSleeping(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));
		bool o;

		try
		{
			o = obj.IsSleeping();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		LuaDLL.lua_pushboolean(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WakeUp(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));

		try
		{
			obj.WakeUp();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetCenterOfMass(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));

		try
		{
			obj.ResetCenterOfMass();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetInertiaTensor(IntPtr L)
	{
		ToLua.CheckArgsCount(L, 1);
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.CheckObject(L, 1, typeof(UnityEngine.Rigidbody));

		try
		{
			obj.ResetInertiaTensor();
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SweepTest(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(LuaInterface.LuaOut<UnityEngine.RaycastHit>)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.RaycastHit arg1;
			bool o;

			try
			{
				o = obj.SweepTest(arg0, out arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

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
			bool o;

			try
			{
				o = obj.SweepTest(arg0, out arg1, arg2);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

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
			bool o;

			try
			{
				o = obj.SweepTest(arg0, out arg1, arg2, arg3);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			LuaDLL.lua_pushboolean(L, o);
			ToLua.Push(L, arg1);
			return 2;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Rigidbody.SweepTest");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SweepTestAll(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.RaycastHit[] o = null;

			try
			{
				o = obj.SweepTestAll(arg0);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 3 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(float)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			UnityEngine.RaycastHit[] o = null;

			try
			{
				o = obj.SweepTestAll(arg0, arg1);
			}
			catch(Exception e)
			{
				return LuaDLL.toluaL_exception(L, e);
			}

			ToLua.Push(L, o);
			return 1;
		}
		else if (count == 4 && ToLua.CheckTypes(L, 1, typeof(UnityEngine.Rigidbody), typeof(UnityEngine.Vector3), typeof(float), typeof(UnityEngine.QueryTriggerInteraction)))
		{
			UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			UnityEngine.QueryTriggerInteraction arg2 = (UnityEngine.QueryTriggerInteraction)ToLua.ToObject(L, 4);
			UnityEngine.RaycastHit[] o = null;

			try
			{
				o = obj.SweepTestAll(arg0, arg1, arg2);
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
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.Rigidbody.SweepTestAll");
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
	static int get_velocity(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
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
	static int get_angularVelocity(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.angularVelocity;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index angularVelocity on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_drag(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.drag;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index drag on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_angularDrag(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.angularDrag;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index angularDrag on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mass(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.mass;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mass on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useGravity(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.useGravity;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index useGravity on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxDepenetrationVelocity(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.maxDepenetrationVelocity;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index maxDepenetrationVelocity on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isKinematic(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.isKinematic;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isKinematic on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_freezeRotation(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.freezeRotation;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index freezeRotation on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_constraints(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.RigidbodyConstraints ret;

		try
		{
			ret = obj.constraints;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index constraints on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_collisionDetectionMode(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.CollisionDetectionMode ret;

		try
		{
			ret = obj.collisionDetectionMode;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index collisionDetectionMode on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_centerOfMass(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.centerOfMass;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index centerOfMass on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_worldCenterOfMass(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.worldCenterOfMass;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index worldCenterOfMass on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_inertiaTensorRotation(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.Quaternion ret;

		try
		{
			ret = obj.inertiaTensorRotation;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index inertiaTensorRotation on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_inertiaTensor(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.inertiaTensor;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index inertiaTensor on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_detectCollisions(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.detectCollisions;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index detectCollisions on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useConeFriction(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		bool ret;

		try
		{
			ret = obj.useConeFriction;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index useConeFriction on a nil value" : e.Message);
		}

		LuaDLL.lua_pushboolean(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_position(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 ret;

		try
		{
			ret = obj.position;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index position on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotation(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.Quaternion ret;

		try
		{
			ret = obj.rotation;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index rotation on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_interpolation(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.RigidbodyInterpolation ret;

		try
		{
			ret = obj.interpolation;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index interpolation on a nil value" : e.Message);
		}

		ToLua.Push(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_solverIterationCount(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		int ret;

		try
		{
			ret = obj.solverIterationCount;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index solverIterationCount on a nil value" : e.Message);
		}

		LuaDLL.lua_pushinteger(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sleepThreshold(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.sleepThreshold;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sleepThreshold on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxAngularVelocity(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		float ret;

		try
		{
			ret = obj.maxAngularVelocity;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index maxAngularVelocity on a nil value" : e.Message);
		}

		LuaDLL.lua_pushnumber(L, ret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_velocity(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.velocity = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index velocity on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_angularVelocity(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.angularVelocity = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index angularVelocity on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_drag(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.drag = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index drag on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_angularDrag(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.angularDrag = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index angularDrag on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mass(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.mass = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index mass on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useGravity(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.useGravity = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index useGravity on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxDepenetrationVelocity(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.maxDepenetrationVelocity = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index maxDepenetrationVelocity on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isKinematic(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.isKinematic = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index isKinematic on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_freezeRotation(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.freezeRotation = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index freezeRotation on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_constraints(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.RigidbodyConstraints arg0 = (UnityEngine.RigidbodyConstraints)ToLua.CheckObject(L, 2, typeof(UnityEngine.RigidbodyConstraints));

		try
		{
			obj.constraints = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index constraints on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_collisionDetectionMode(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.CollisionDetectionMode arg0 = (UnityEngine.CollisionDetectionMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.CollisionDetectionMode));

		try
		{
			obj.collisionDetectionMode = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index collisionDetectionMode on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_centerOfMass(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.centerOfMass = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index centerOfMass on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_inertiaTensorRotation(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.Quaternion arg0 = ToLua.ToQuaternion(L, 2);

		try
		{
			obj.inertiaTensorRotation = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index inertiaTensorRotation on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_inertiaTensor(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.inertiaTensor = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index inertiaTensor on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_detectCollisions(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.detectCollisions = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index detectCollisions on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useConeFriction(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		bool arg0 = LuaDLL.luaL_checkboolean(L, 2);

		try
		{
			obj.useConeFriction = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index useConeFriction on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_position(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);

		try
		{
			obj.position = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index position on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rotation(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.Quaternion arg0 = ToLua.ToQuaternion(L, 2);

		try
		{
			obj.rotation = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index rotation on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_interpolation(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		UnityEngine.RigidbodyInterpolation arg0 = (UnityEngine.RigidbodyInterpolation)ToLua.CheckObject(L, 2, typeof(UnityEngine.RigidbodyInterpolation));

		try
		{
			obj.interpolation = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index interpolation on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_solverIterationCount(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.solverIterationCount = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index solverIterationCount on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sleepThreshold(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.sleepThreshold = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index sleepThreshold on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxAngularVelocity(IntPtr L)
	{
		UnityEngine.Rigidbody obj = (UnityEngine.Rigidbody)ToLua.ToObject(L, 1);
		float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);

		try
		{
			obj.maxAngularVelocity = arg0;
		}
		catch(Exception e)
		{
			return LuaDLL.luaL_error(L, obj == null ? "attempt to index maxAngularVelocity on a nil value" : e.Message);
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_out(IntPtr L)
	{
		ToLua.PushOut<UnityEngine.Rigidbody>(L, new LuaOut<UnityEngine.Rigidbody>());
		return 1;
	}
}

