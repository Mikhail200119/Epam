using System;

namespace MK_Project
{
    class Program
    {
        static double Koren(double number, float n, double e, double x0)
        {
            double x = 0, x_buf = 1;
            while (Math.Abs(x - x_buf) > e)
            {
                x = 1 / n * ((n - 1) * x0 + number / (Math.Pow(x0, n - 1)));
                x_buf = x0;
                x0 = x;
            }
            return x;
        }

        static void Main(string[] args)
        {
            double number, e, x0;
            float n;
            Console.Write("Число: ");
            number = Convert.ToDouble(Console.ReadLine());
            Console.Write("Степень: ");
            n = Convert.ToSingle(Console.ReadLine());
            Console.Write("Точность: ");
            e = Convert.ToDouble(Console.ReadLine());
            Console.Write("x0: ");
            x0 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(Koren(number, n, e, x0));
            Console.WriteLine("Pow: " + Math.Pow(number, 1 / n));
        }
    }
}