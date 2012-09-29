using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using IPHelper;

namespace IPHelper
{
    public static class Functions
    {
        #region Public Methods

        public static TcpTable GetExtendedTcpTable(bool sorted)
        {
            var tcpRows = new List<TcpRow>();

            var tcpTable = IntPtr.Zero;
            var tcpTableLength = 0;

            if (Win32Funcs.GetExtendedTcpTable(tcpTable, ref tcpTableLength, sorted, Win32Funcs.AfInet,
                                               Win32Funcs.TcpTableType.OwnerPidAll, 0) != 0)
            {
                try
                {
                    tcpTable = Marshal.AllocHGlobal(tcpTableLength);
                    if (
                        Win32Funcs.GetExtendedTcpTable(tcpTable, ref tcpTableLength, true, Win32Funcs.AfInet,
                                                       Win32Funcs.TcpTableType.OwnerPidAll, 0) == 0)
                    {
                        var table =(Win32Funcs.TcpTable) Marshal.PtrToStructure(tcpTable, typeof (Win32Funcs.TcpTable));

                        var rowPtr = (IntPtr) ((long) tcpTable + Marshal.SizeOf(table.Length));
                        for (var i = 0; i < table.Length; ++i)
                        {
                            tcpRows.Add(
                                new TcpRow(
                                    (Win32Funcs.TcpRow) Marshal.PtrToStructure(rowPtr, typeof (Win32Funcs.TcpRow))));
                            rowPtr = (IntPtr) ((long) rowPtr + Marshal.SizeOf(typeof (Win32Funcs.TcpRow)));
                        }
                    }
                }
                finally
                {
                    if (tcpTable != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(tcpTable);
                    }
                }
            }

            return new TcpTable(tcpRows);
        }


        public static UdpTable GetExtendedUdpTable(bool sorted)
        {
            var udpRows = new List<UdpRow>();

            var udpTable = IntPtr.Zero;
            var udpTableLength = 0;

            if (
                Win32Funcs.GetExtendedUdpTable(udpTable, ref udpTableLength, sorted, Win32Funcs.AfInet,
                                               Win32Funcs.UdpTableType.OwnerPid, 0) != 0)
            {
                try
                {
                    udpTable = Marshal.AllocHGlobal(udpTableLength);
                    if (
                        Win32Funcs.GetExtendedUdpTable(udpTable, ref udpTableLength, true, Win32Funcs.AfInet,
                                                       Win32Funcs.UdpTableType.OwnerPid, 0) == 0)
                    {
                        var table = (Win32Funcs.UdpTable) Marshal.PtrToStructure(udpTable, typeof (Win32Funcs.UdpTable));

                        var rowPtr = (IntPtr) ((long) udpTable + Marshal.SizeOf(table.Length));
                        for (var i = 0; i < table.Length; ++i)
                        {
                            udpRows.Add(
                                new UdpRow(
                                    (Win32Funcs.UdpRow) Marshal.PtrToStructure(rowPtr, typeof (Win32Funcs.UdpRow))));
                            rowPtr = (IntPtr) ((long) rowPtr + Marshal.SizeOf(typeof (Win32Funcs.TcpRow)));
                        }
                    }
                }
                finally
                {
                    if (udpTable != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(udpTable);
                    }
                }
            }

            return new UdpTable(udpRows);
        }

        #endregion
    }
}