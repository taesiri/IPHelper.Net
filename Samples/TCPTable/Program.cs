using System;
using IPHelper;

namespace TCPTable
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintData();
            Console.ReadLine();
        }

        private static void PrintData()
        {
            var returnData = Functions.GetExtendedTcpTable(true,Win32Funcs.TcpTableType.OwnerPidAll);

            Console.WriteLine("+================================================================================+");

            Console.Write("| ");
            Console.Write(String.Format("{0,-8}{1,-18}{2,-10}{3,-18}{4,-10}{5,-15}", "PID", "Local Address", "Port",
                                        "Remote Address", "Port", "State"));
            Console.WriteLine("|");

            Console.WriteLine("+================================================================================+");
            foreach (var data in returnData)
            {
                Console.Write("| ");
                Console.Write(String.Format("{0,-8}{1,-18}{2,-10}{3,-18}{4,-10}{5,-15}", data.ProcessId,
                                                data.LocalEndPoint.Address,
                                                data.LocalEndPoint.Port,
                                                data.RemoteEndPoint.Address,
                                                data.RemoteEndPoint.Port, 
                                                data.State));
                Console.WriteLine("|");
            }
            Console.WriteLine("+================================================================================+");

        }
    }
}