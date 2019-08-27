using System;
using System.Net;

namespace Dns01
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress[] IP = Dns.GetHostAddresses("www.naver.com");
            foreach (IPAddress HostIP in IP)
            {
                Console.WriteLine("{0}", HostIP);
            }
        }
    }
}
