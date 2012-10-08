using System;
using System.Net;
using IPHelper;

namespace TestField
{
    class Program
    {
        static void Main(string[] args)
        {
            //var strNetRow = new Win32Funcs.IpNetRow();
            //var ip = new IPAddress(new byte[] { 192, 168, 1, 5 });
            //strNetRow.adaptorAddr = (int) ip.Address;
            //strNetRow.adaptorIndex = 0;
            //strNetRow.adaptorPhysicalMacAddress0 = 0;
            //strNetRow.adaptorPhysicalMacAddress1 = 0;
            //strNetRow.adaptorPhysicalMacAddress2 = 1;
            //strNetRow.adaptorPhysicalMacAddress3 = 12;
            //strNetRow.adaptorPhysicalMacAddress4 = 13;
            //strNetRow.adaptorPhysicalMacAddress5 = 1;
            //strNetRow.adaptorPhysicalMacAddressLen = 8;
            //strNetRow.typeOfARPEntry = 4;
            //var net = new IPNetRow(strNetRow);
            //Console.WriteLine("IP  Address : "+ net.EntryIPAddress.ToString());
            //Console.WriteLine("Mac Address : "+ net.EntryMacAddress.ToString());
            //var returnval = Functions.CreateIpNetEntry(net);
            //Console.WriteLine(returnval);


            Functions.GetAdapterIndex("isatap.Home");
            Console.ReadKey();
        }
    }
}
