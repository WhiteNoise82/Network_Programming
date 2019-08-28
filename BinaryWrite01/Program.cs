using System.IO;
using System.Net;
using System.Net.Sockets;

namespace BinaryWrite01
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 3000);
            tcpListener.Start();

            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream ns = tcpClient.GetStream();
            using (BinaryWriter bw = new BinaryWriter(ns))
            {
                bool YesNo = false;
                int Val1 = 12;
                float PI = 3.14f;
                string Message = "Hello World!";

                bw.Write(YesNo);
                bw.Write(Val1);
                bw.Write(PI);
                bw.Write(Message);
            }
            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();
        }
    }
}
