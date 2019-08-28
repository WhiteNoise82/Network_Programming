using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpListener03_NetworkStream
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 7);
            tcpListener.Start();
            byte[] Buffer = new byte[1024];
            int TotalByteCount = 0, ReadByteCount = 0;

            Console.WriteLine("서버");

            TcpClient tcpClientl = tcpListener.AcceptTcpClient();
            NetworkStream ns = tcpClientl.GetStream();

            while (true)
            {
                ReadByteCount = ns.Read(Buffer, 0, Buffer.Length);
                if (ReadByteCount == 0)
                {
                    break;
                }

                TotalByteCount += ReadByteCount;
                ns.Write(Buffer, 0, ReadByteCount);
                Console.Write(Encoding.ASCII.GetString(Buffer));
            }

            ns.Close();
            tcpClientl.Close();
            tcpListener.Stop();
        }
    }
}
