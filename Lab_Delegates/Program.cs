using System;
using System.Threading;

namespace Lab_Delegates
{
    public delegate void Delegate();

    class Ping
    {
        private static int Counter = 1;

        public static void PrintPing()
        {
            Console.Write($"{Counter}. Pong received Ping\n");
            Counter += 2;
            Thread.Sleep(360);
        }
    }

    class Pong
    {
        private static int Counter = 2;

        public static void PrintPong()
        {
            Console.Write($"{Counter}. Ping received Pong\n");
            Counter += 2;
            Thread.Sleep(360);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Delegate del;
            Random random = new Random();
            del = new Delegate(Ping.PrintPing);
            del += Pong.PrintPong;
            int i = 0;
            while (i < 3)
            {
                del();
                i++;
            }
        }
    }
}