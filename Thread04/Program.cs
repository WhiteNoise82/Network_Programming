using System;
using System.Threading;

/// <summary>
/// 다른 class에 있는 메소드를 두개 이상의 객체를 만들어 스레드로 실행
/// </summary>

namespace Thread04
{
    class Test
    {
        public void Print()
        {
            Console.WriteLine("스레드 호출");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test test1 = new Test();
            Test test2 = new Test();

            Thread th1 = new Thread(new ThreadStart(test1.Print));
            Thread th2 = new Thread(new ThreadStart(test2.Print));
            th1.Start();
            th2.Start();
            Console.ReadKey();
        }
    }
}
