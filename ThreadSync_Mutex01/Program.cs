using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSync_Mutex01
{
    class Test
    {
        static Mutex mut = new Mutex();
        static int Count;

        public static void ThreadProc()
        {
            mut.WaitOne();

            for (int i = 0; i < 5; i++)
            {
                Count++;
                Console.WriteLine("Thread ID: {0}  Count: {1}", Thread.CurrentThread.GetHashCode(), Count);
            }

            mut.ReleaseMutex();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadStart(Test.ThreadProc));
            Thread th2 = new Thread(new ThreadStart(Test.ThreadProc));
            th1.Start();
            th2.Start();
        }
    }
}
