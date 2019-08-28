using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpListener02_NetworkStream
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("192.168.0.11"), 7);
            tcpListener.Start();
            Console.WriteLine("대기상태");
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream ns = tcpClient.GetStream();
            byte[] ReceiveMessage = new byte[100];
            ns.Read(ReceiveMessage, 0, 100);
            string strMessage = Encoding.ASCII.GetString(ReceiveMessage);
            Console.WriteLine(strMessage);

            string EchoMessage = "Hi~~";
            byte[] SendMessage = Encoding.ASCII.GetBytes(EchoMessage);
            ns.Write(SendMessage, 0, SendMessage.Length);
            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();
            Console.ReadKey();
        }
    }
}
