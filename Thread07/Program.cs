using System;
using System.Threading;

/// <summary>
/// Join 메소드 사용 예제
/// </summary>

namespace Thread07
{
    class Program
    {
        static void Func1()
        {
            for (int i = 0; i < 30; i++)
            {
                Console.Write("{0}  ", i);
                Thread.Sleep(200);
            }
        }

        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(Func1));
            th.Start();
            //th.Join();
            // Join이 된 스레드가 끝날때까지 추가로 스레드를 만들지 않는다.
            Console.WriteLine("Main 종료");

        }
    }
}
