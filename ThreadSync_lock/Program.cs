using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// 다수의 스레드가 하나의 맴버변수를 사용하는 경우
/// </summary>
/// 

namespace ThreadSync_lock01
{
    class Test
    {
        //static int Count; // 공유할 자원

        //public void ThreadProc()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Count++;
        //        Console.WriteLine("Thread ID: {0}  result: {1}",
        //            Thread.CurrentThread.GetHashCode(), Count);
        //    }
        //}

        /// <summary>
        /// lock를 사용한 공유자원 보호 방법
        /// </summary>
        /// 스레드간 공유할 자원을 다른 한 스레드에의해 침범 당하지 않도록
        /// 오브젝트 객체를 생성하고 공유할 자원이 사용되는 코드를 lock로 묶는다.
        /// 

        static object obj = new object();
        static int Count; // 공유할 자원

        public void ThreadProc()
        {
            lock (obj)
            {
                for (int i = 0; i < 10; i++)
                {
                    Count++;
                    Console.WriteLine("Thread ID: {0}  result: {1}",
                        Thread.CurrentThread.GetHashCode(), Count);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /// lock을 사용하지 않은 결과는 th1이 실행되는 틈틈히 th2가 실행되어 결과가 예상과 다름
            /// lock을 사용한 결과는 th1이 실행되는 동안 th2가 공유자원에 접근할 수 없어 th1의 실행이 완료된 후 th2가 수행됨.

            Test test = new Test();
            Thread th1 = new Thread(new ThreadStart(test.ThreadProc));
            Thread th2 = new Thread(new ThreadStart(test.ThreadProc));
            th1.Start();
            th2.Start();
        }
    }
}
