﻿using Ryujinx.HLE.HOS.Services.Ldn.Types;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace LanPlayServer.Network.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0xAC, CharSet = CharSet.Ansi, Pack = 1)]
    struct CreateAccessPointRequest
    {
        public SecurityConfig SecurityConfig;
        public UserConfig UserConfig;
        public NetworkConfig NetworkConfig;

        // PrivateIp is included for external proxies for the case where a client attempts to join from
        // their own LAN. UPnP forwarding can fail when connecting devices on the same network over the public IP,
        // so if their public IP is identical, the internal address should be sent instead.

        // The fields below are 0 if not hosting a p2p proxy.

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
        public byte[] PrivateIp; 
        public AddressFamily AddressFamily;
        public ushort ExternalProxyPort;
        public ushort InternalProxyPort;

        // Advertise data is appended separately. (remaining data in the buffer)
    }
}
