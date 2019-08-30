using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/// <summary>
/// 다수의 스레드가 하나의 객체를 사용하는 경우
/// </summary>
/// 

namespace ThreadSync_lock02
{
    class ThisLock
    {
        public void IncreaseCount(ref int count)
        {
            count++;
        }
    }

    class Test
    {
        ThisLock lockObject = new ThisLock();
        int Count = 0;

        public void ThreadProc()
        {
            lock (lockObject) // <-- object형으로 처리해도 결과는 동일
            {
                for (int i = 0; i < 3; i++)
                {
                    lockObject.IncreaseCount(ref Count);
                    Console.WriteLine("Thread ID:{0}  Count:{1}", Thread.CurrentThread.GetHashCode(), Count);
                }
            }
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
                threads[i].Start();
            }

            for (int i = 0; i < 3; i++)
            {
                threads[i].Start();
            }

        }
    }
}
