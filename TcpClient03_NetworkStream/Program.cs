using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpClient03_NetworkStream
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("localhost", 7);
            NetworkStream ns = tcpClient.GetStream();
            Console.WriteLine("클라이언트");
            byte[] Buffer = new byte[1024];
            byte[] SendMessage = Encoding.ASCII.GetBytes("Hello World!");
            ns.Write(SendMessage, 0, SendMessage.Length);
            int TotalCount = 0, Readcount = 0;

            while (TotalCount < SendMessage.Length)
            {
                Readcount = ns.Read(Buffer, 0, Buffer.Length);
                TotalCount += Readcount;

                string RecvMessage = Encoding.ASCII.GetString(Buffer);
                Console.Write(RecvMessage);
            }

            Console.WriteLine("받은 문자열 바이트 수 : {0}", TotalCount);
            ns.Close();
            tcpClient.Close();
        }
    }
}
