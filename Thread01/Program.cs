using System;
using System.Threading;

/// <summary>
/// 같은 class안의 함수를 Thread로 실행할 때
/// </summary>
/// 

namespace Thread01
{
    class Program
    {
        static void threadFunction() // 일반적인 스레드 함수
        {
            Console.WriteLine("스레드에서 호출");
        }

        static void ParameterizedFunction(object obj) // 매개변수를 포함하는 스레드 함수
        {
            for (int i = 0; i < (int)obj; i++)
            {
                Console.WriteLine("Parameterized 스레드에서 호출: {0}", i);
            }
        }

        static void Main(string[] args)
        {
            //일반적인 스레드함수의 실행
            Thread th = new Thread(new ThreadStart(threadFunction));
            ////위 코드의 풀어쓴 표현
            //ThreadStart thStart = new ThreadStart(threadFunction);
            //Thread th = new Thread(thStart);
            th.Start();

            ////매개변수를 포함하는 스레드함수의 실행
            //int i = 5;
            //Thread th2 = new Thread(new ParameterizedThreadStart(ParameterizedFunction));
            //th2.Start(i);
        }
    }
}
