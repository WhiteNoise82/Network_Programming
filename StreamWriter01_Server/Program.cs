using System.IO;
using System.Net.Sockets;

namespace StreamWriter01_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(3000);
            tcpListener.Start();
            TcpClient tcpClient = tcpListener.AcceptTcpClient();

            bool YesNo = false;
            int Val1 = 12;
            float PI = 3.14f;
            string Message = "Hello World!";

            NetworkStream ns = tcpClient.GetStream();
            using (StreamWriter sw = new StreamWriter(ns))
            {
                sw.AutoFlush = true; //sw 안을 비우기 위한 코드
                sw.WriteLine(YesNo);
                sw.WriteLine(Val1);
                sw.WriteLine(PI);
                sw.WriteLine(Message);
            }
            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();
        }
    }
}
