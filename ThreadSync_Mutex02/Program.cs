using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSync_Mutex02
{
    class ThisMutex
    {
        public void IncreaseCount(ref int count)
        {
            count++;
        }
    }

    class Test
    {
        ThisMutex mutexObject = new ThisMutex();
        Mutex mut = new Mutex();
        public int Count = 0;

        public void ThreadProc()
        {
            mut.WaitOne();

            for (int i = 0; i < 3; i++)
            {
                mutexObject.IncreaseCount(ref Count);
                Console.WriteLine("Thread ID: {0}  Count: {1}", Thread.CurrentThread.GetHashCode(), Count);
            }

            mut.ReleaseMutex();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread[] threads = new Thread[3];

            for (int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(new ThreadStart(test.ThreadProc));
            }

            for (int i = 0; i < 3; i++)
            {
                threads[i].Start();
            }
        }
    }
}
