using System;
using System.Threading;

/// <summary>
/// 다른 class의 메소드를 Thread로 실행할때
/// </summary>
/// 

namespace Thread02
{
    class Test
    {
        public void Print()
        {
            Console.WriteLine("Test!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test(); // class가 다르기 때문에 객체 먼저 생성
            Thread th = new Thread(new ThreadStart(test.Print)); // 스레드 객체 생성과 동시에 델리게이트를 통해 메소드 연결
            th.Start();
        }
    }
}
