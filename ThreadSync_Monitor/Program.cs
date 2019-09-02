using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadSync_Monitor01
{
    class Test
    {
        int Count;
        object obj = new object();
        public void IncreaseCount()
        {
            Monitor.Enter(obj);
            for (int i = 0; i < 5; i++)
            {
                Count++;
                Console.WriteLine("Thread Id: {0} Count: {1}", Thread.CurrentThread.GetHashCode(), Count);
            }
            Monitor.Exit(obj);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread th1 = new Thread(new ThreadStart(test.IncreaseCount));
            Thread th2 = new Thread(new ThreadStart(test.IncreaseCount));
            th1.Start();
            th2.Start();
        }
    }
}
