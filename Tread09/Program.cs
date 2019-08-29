using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tread09
{
    class Program
    {
        static void Func1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("스레드1 호출 {0}", i);
                Thread.Sleep(300);
            }
        }

        static void Func2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("스레드2 호출 {0}", i);
                Thread.Sleep(300);
            }
        }

        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadStart(Func1));
            Thread th2 = new Thread(new ThreadStart(Func2));
            //th1.IsBackground = true;    // 백그라운드 스레드는 모든 포그라운드 스레드가 종료 되어야 종료됨
                                        // th2 스레드가 포그라운드 스레드이므로 th2 스레드가 종료 될때까지 th1 스레드는 계속 실행
                                        // th2.IsBackground = true; 코드를 넣어주면,
                                        // Main 함수가 종료(Console.WriteLine("메인 종료"); 코드 실행 직후) th1, th2 스레드가 종료 됨.
            th1.Start();
            th2.Start();
            Console.WriteLine("메인 종료");
            th1.Abort();
        }
    }
}
