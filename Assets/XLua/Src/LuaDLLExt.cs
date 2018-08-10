
using System;
using System.Runtime.InteropServices;

using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;

namespace XLua.LuaDLL
{
	public partial class Lua
	{
		
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaopen_socket_core(System.IntPtr L);

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		internal static int cs_luaopen_socket_core(RealStatePtr L)
		{
			return luaopen_socket_core(L);
		}
		
	}
}

namespace XLua
{
	public static class LuaDLLExt
	{
		public static void AddLib(LuaEnv env)
		{
			env.AddBuildin("socket.core", LuaDLL.Lua.cs_luaopen_socket_core);
			
			env.AddBuildin("socket", LuaDLL.Lua.cs_luaopen_socket_core);
			
		}
	}
}

