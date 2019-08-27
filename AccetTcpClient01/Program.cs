using System;
using System.Net;
using System.Net.Sockets;

namespace AcceptTcpClient01
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("192.168.0.11"), 7);
            tcpListener.Start();
            Console.WriteLine("대기 상태 시작");
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            Console.WriteLine("대기 상태 종료");
            tcpListener.Stop();
        }
    }
}
