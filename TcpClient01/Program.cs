using System;
using System.Net;
using System.Net.Sockets;

namespace TcpClient01
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("192.168.0.11", 7);
            if (tcpClient.Connected)
            {
                Console.WriteLine("서버 연결 성공");
            }
            else
            {
                Console.WriteLine("서버 연결 실패");
            }
            tcpClient.Close();
            Console.ReadKey();
        }
    }
}
