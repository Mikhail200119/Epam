using System;
using System.Linq;

namespace net_core
{
    class Program
    {
        static double F(double x)
        {
            return Math.Acos(x) - Math.Sqrt(1 - Math.Pow(x, 3));
        }
        
        static double F1(double x)
        {
            return (9 * Math.Pow(x, 2)) / (20 * Math.Sqrt(1 - 0.3 * Math.Pow(x, 2)))
                - (1 / Math.Sqrt(1 - Math.Pow(x, 2)));
        }

        static void Main(string[] args)
        {
            double E, xn, x = 0;
            Console.Write("Введите точность: ");
            E = double.Parse(Console.ReadLine());
            Console.Write("Введите начальное приближение: ");
            xn = double.Parse(Console.ReadLine());
            while (Math.Abs(F(x)) > E)
            {
                x = xn - F(xn) / F1(xn);
                xn = x;
            }
            Console.WriteLine(x);
        }
    }
}