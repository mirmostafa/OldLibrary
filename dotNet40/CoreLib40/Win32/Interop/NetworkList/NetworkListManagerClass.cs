#region File Notice
// Created at: 2013/12/24 3:43 PM
// Last Update time: 2013/12/24 4:05 PM
// Last Updated by: Mohammad Mir mostafa
#endregion

using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Library40.Win32.NetworkList;

namespace Library40.Win32.Interop.NetworkList
{
	[ComImport, ClassInterface((short)0), Guid("DCB00C01-570F-4A9B-8D69-199FDBA5723B")]
	[ComSourceInterfaces(
		"Microsoft.Windows.NetworkList.Internal.INetworkEvents\0Microsoft.Windows.NetworkList.Internal.INetworkConnectionEvents\0Microsoft.Windows.NetworkList.Internal.INetworkListManagerEvents\0"
		), TypeLibType((short)2)]
	internal class NetworkListManagerClass : INetworkListManager
	{
		#region INetworkListManager Members
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(7)]
		public virtual extern Connectivity GetConnectivity();

		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(2)]
		public virtual extern INetwork GetNetwork([In] Guid gdNetworkId);

		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(4)]
		public virtual extern INetworkConnection GetNetworkConnection([In] Guid gdNetworkConnectionId);

		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(3)]
		public virtual extern IEnumerable GetNetworkConnections();

		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1)]
		public virtual extern IEnumerable GetNetworks([In] NetworkConnectivityLevels Flags);

		[DispId(6)]
		public virtual extern bool IsConnected { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(6)] get; }

		[DispId(5)]
		public virtual extern bool IsConnectedToInternet { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(5)] get; }
		#endregion
	}
}