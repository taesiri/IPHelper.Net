using System;
using IPHelper;

namespace UDPTable
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PrintData();
            Console.ReadLine();
        }

        private static void PrintData()
        {
            UdpTable returnData = Functions.GetExtendedUdpTable(true,Win32Funcs.UdpTableType.OwnerPid);

            Console.WriteLine("+============================================+");

            Console.Write("| ");
            Console.Write(String.Format("{0,-15}{1,-18}{2,-10}", "PID", "Local Address", "Port"));
            Console.WriteLine("|");

            Console.WriteLine("+============================================+");
            foreach (UdpRow data in returnData)
            {
                if (data.LocalEndPoint != null)
                {
                    Console.Write("| ");

                    Console.Write(String.Format("{0,-15}{1,-18}{2,-10}", data.ProcessId,
                                                data.LocalEndPoint.Address,
                                                data.LocalEndPoint.Port
                                      ));


                    Console.WriteLine("|");
                }
            }
            Console.WriteLine("+============================================+");
        }
    }
}