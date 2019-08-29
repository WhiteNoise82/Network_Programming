using System;
using System.Threading;

/// <summary>
/// 두개 이상의 스레드 실행 예제
/// 같은 클래스 안의 두개 이상의 스레드 실행
/// </summary>

namespace Thread03
{
    class Program
    {
        static void Func01()
        {
            Console.WriteLine("스레드01 호출");
        }

        static void Func02()
        {
            Console.WriteLine("스레드02 호출");
        }

        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadStart(Func01));
            Thread th2 = new Thread(new ThreadStart(Func02));
            th1.Start();
            th2.Start();
            Console.WriteLine("메인 종료");
            Console.ReadKey();
        }
    }
}
