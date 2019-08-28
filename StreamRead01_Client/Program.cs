using System;
using System.IO;
using System.Net.Sockets;

namespace StreamRead01_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] Buffer = new char[100];
            TcpClient tcpClient = new TcpClient("localhost", 3000);
            NetworkStream ns = tcpClient.GetStream();
            using (StreamReader sr = new StreamReader(ns))
            {
                string str = sr.ReadLine();
                Console.WriteLine(str);
                str = sr.ReadLine();
                Console.WriteLine(str);
                str = sr.ReadLine();
                Console.WriteLine(str);
                str = sr.ReadLine();
                Console.WriteLine(str);
            }

            ns.Close();
            tcpClient.Close();
        }
    }
}
