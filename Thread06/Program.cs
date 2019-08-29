using System;
using System.Threading;

/// <summary>
/// IsBackground 속성을 이용하여 포그라운드 스레드의 테스트
/// </summary>

namespace Thread06
{
    class Program
    {
        static void Func()
        {
            int i = 0;
            while (true)
            {
                Console.Write("{0}  ", i++);
                Thread.Sleep(300);
            }
        }

        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(Func));
            th.IsBackground = true;
            th.Start();
            Console.WriteLine("메인 종료");
        }
    }
}
