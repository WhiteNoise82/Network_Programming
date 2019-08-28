using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpClient02_NetworkStream
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("192.168.0.11", 7);
            if (tcpClient.Connected)
            {
                Console.WriteLine("서버 연결 성공");
                NetworkStream ns = tcpClient.GetStream();
                string Message = "Hello World!";
                byte[] SendByteMessage = Encoding.ASCII.GetBytes(Message);
                ns.Write(SendByteMessage, 0, SendByteMessage.Length);

                byte[] ReceiveByteMessage = new byte[32];
                ns.Read(ReceiveByteMessage, 0, 32);
                string ReceiveMessage = Encoding.ASCII.GetString(ReceiveByteMessage);
                Console.WriteLine(ReceiveMessage);
                ns.Close();
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
