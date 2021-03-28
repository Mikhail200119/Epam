using System;

namespace Lab_Delegates_1
{
    class Program
    {
        public static void action(Func<int> func, char ch1, char ch2)
        {
            Console.WriteLine("Completed first...");
        }

        public static void action_2(Func<int> func, char ch1, char ch2)
        {
            Console.WriteLine("Completed second...");
        }

        public static int func()
        {
            return 1;
        }

        static void Main(string[] args)
        {
            Func<int> F = func;
            Action<Func<int>, char, char> Delegate = action;
            Delegate += action_2;
            Delegate(F, 'f', 'f');
        }
    }
}
