﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class PlayerDisplayWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(PlayerDisplay), typeof(BaseResLoader));
		L.RegFunction("PlaySound", PlaySound);
		L.RegFunction("PlayCnsAnimate", PlayCnsAnimate);
		L.RegFunction("Trigger_SuperPause", Trigger_SuperPause);
		L.RegFunction("GetMugenAnimateTime", GetMugenAnimateTime);
		L.RegFunction("ChangeState", ChangeState);
		L.RegFunction("HasAniGroup", HasAniGroup);
		L.RegFunction("PlayAni", PlayAni);
		L.RegFunction("IsCommandInputKeyOk", IsCommandInputKeyOk);
		L.RegFunction("RunCmd", RunCmd);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("SoundCount", get_SoundCount, null);
		L.RegVar("IsFlipX", get_IsFlipX, set_IsFlipX);
		L.RegVar("Attribe", get_Attribe, null);
		L.RegVar("Stateno", get_Stateno, null);
		L.RegVar("ImageCurrentFrame", get_ImageCurrentFrame, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlaySound(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			PlayerDisplay obj = (PlayerDisplay)ToLua.CheckObject<PlayerDisplay>(L, 1);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
			bool o = obj.PlaySound(arg0, arg1);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayCnsAnimate(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				PlayerDisplay obj = (PlayerDisplay)ToLua.CheckObject<PlayerDisplay>(L, 1);
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
				bool o = obj.PlayCnsAnimate(arg0);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 3)
			{
				PlayerDisplay obj = (PlayerDisplay)ToLua.CheckObject<PlayerDisplay>(L, 1);
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				bool o = obj.PlayCnsAnimate(arg0, arg1);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: PlayerDisplay.PlayCnsAnimate");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Trigger_SuperPause(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			PlayerDisplay obj = (PlayerDisplay)ToLua.CheckObject<PlayerDisplay>(L, 1);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
			obj.Trigger_SuperPause(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMugenAnimateTime(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlayerDisplay obj = (PlayerDisplay)ToLua.CheckObject<PlayerDisplay>(L, 1);
			float o = obj.GetMugenAnimateTime();
			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ChangeState(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				PlayerDisplay obj = (PlayerDisplay)ToLua.CheckObject<PlayerDisplay>(L, 1);
				Mugen.PlayerState arg0 = (Mugen.PlayerState)ToLua.CheckObject(L, 2, typeof(Mugen.PlayerState));
				bool o = obj.ChangeState(arg0);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 3)
			{
				PlayerDisplay obj = (PlayerDisplay)ToLua.CheckObject<PlayerDisplay>(L, 1);
				Mugen.PlayerState arg0 = (Mugen.PlayerState)ToLua.CheckObject(L, 2, typeof(Mugen.PlayerState));
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				bool o = obj.ChangeState(arg0, arg1);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: PlayerDisplay.ChangeState");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HasAniGroup(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PlayerDisplay obj = (PlayerDisplay)ToLua.CheckObject<PlayerDisplay>(L, 1);
			Mugen.PlayerState arg0 = (Mugen.PlayerState)ToLua.CheckObject(L, 2, typeof(Mugen.PlayerState));
			bool o = obj.HasAniGroup(arg0);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayAni(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				PlayerDisplay obj = (PlayerDisplay)ToLua.CheckObject<PlayerDisplay>(L, 1);
				Mugen.PlayerState arg0 = (Mugen.PlayerState)ToLua.CheckObject(L, 2, typeof(Mugen.PlayerState));
				bool o = obj.PlayAni(arg0);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 3)
			{
				PlayerDisplay obj = (PlayerDisplay)ToLua.CheckObject<PlayerDisplay>(L, 1);
				Mugen.PlayerState arg0 = (Mugen.PlayerState)ToLua.CheckObject(L, 2, typeof(Mugen.PlayerState));
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				bool o = obj.PlayAni(arg0, arg1);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: PlayerDisplay.PlayAni");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsCommandInputKeyOk(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PlayerDisplay obj = (PlayerDisplay)ToLua.CheckObject<PlayerDisplay>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			bool o = obj.IsCommandInputKeyOk(arg0);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RunCmd(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PlayerDisplay obj = (PlayerDisplay)ToLua.CheckObject<PlayerDisplay>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			bool o = obj.RunCmd(arg0);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
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
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SoundCount(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PlayerDisplay obj = (PlayerDisplay)o;
			int ret = obj.SoundCount;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index SoundCount on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsFlipX(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PlayerDisplay obj = (PlayerDisplay)o;
			bool ret = obj.IsFlipX;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index IsFlipX on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Attribe(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PlayerDisplay obj = (PlayerDisplay)o;
			PlayerAttribe ret = obj.Attribe;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Attribe on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Stateno(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PlayerDisplay obj = (PlayerDisplay)o;
			int ret = obj.Stateno;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Stateno on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ImageCurrentFrame(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PlayerDisplay obj = (PlayerDisplay)o;
			int ret = obj.ImageCurrentFrame;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index ImageCurrentFrame on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_IsFlipX(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PlayerDisplay obj = (PlayerDisplay)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.IsFlipX = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index IsFlipX on a nil value");
		}
	}
}

