using System;

namespace Lab_1
{
    class Program
    {
        static double Summ(double x, int k)
        {
            double summ = 0;
            for (double n = 1; n <= k; n++)
            {
                summ += Math.Pow((-1), (n + 1)) * (Math.Pow(x, 2 * n + 1) / (4 * Math.Pow(n, 2) - 1));
            }
            return summ;
        }
        static void Main(string[] args)
        {
            double x;
            int k;
            Console.Write("x: ");
            x = double.Parse(Console.ReadLine());
            Console.Write("k: ");
            k = int.Parse(Console.ReadLine());
            Console.WriteLine(Summ(x, k));
        }
    }
}
