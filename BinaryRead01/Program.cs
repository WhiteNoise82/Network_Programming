using System;
using System.IO;
using System.Net.Sockets;

namespace BinaryRead01
{
    class Program
    {
        static void Main(string[] args)
        {
            bool YesNo;
            int Val1;
            float PI;
            string Message;

            TcpClient tcpClient = new TcpClient("localhost", 3000);
            NetworkStream ns = tcpClient.GetStream();
            using (BinaryReader br = new BinaryReader(ns))
            {
                YesNo = br.ReadBoolean();
                Val1 = br.ReadInt32();
                PI = br.ReadSingle();
                Message = br.ReadString();
            }
            ns.Close();
            tcpClient.Close();

            Console.WriteLine(YesNo);
            Console.WriteLine(Val1);
            Console.WriteLine(PI);
            Console.WriteLine(Message);
        }
    }
}
