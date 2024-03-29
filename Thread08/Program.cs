﻿using System;
using System.Threading;

/// <summary>
/// Abort 메소드 사용 예제
/// </summary>

namespace Thread08
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(ThreadProc1));
            th.Start();
            Console.WriteLine("Main 스레드 {0}", Thread.CurrentThread.GetHashCode());
            Console.WriteLine("Main 종료");
        }

        private static void ThreadProc1()
        {
            Console.WriteLine("ThreadProc1 스레드 {0}", Thread.CurrentThread.GetHashCode());
            Thread th = new Thread(new ThreadStart(ThreadProc2));
            th.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} ", i * 10);
                Thread.Sleep(200);

                if (i==3)
                {
                    Console.WriteLine("ThreadProc1 종료");
                    Thread.CurrentThread.Abort();
                }
            }
        }

        private static void ThreadProc2()
        {
            Console.WriteLine("ThreadProc2 스레드 {0}", Thread.CurrentThread.GetHashCode());

            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0}  ", i);
                Thread.Sleep(200);
            }
        }
    }
}
