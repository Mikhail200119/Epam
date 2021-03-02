using System;

namespace Lab_3_1
{
                            /*(Вариант 9) Задача 1. Напишите программу нахождения суммы, включая в нее начальные слагаемые,
                        абсолютная величина которых не превосходит заданной точности E */
    class Program
    {
        static double D(double x, double n)
        {
            return ((-1) * ((2 * Math.Pow((n + 1), 2) + 1) * Math.Pow(x, 2)) / ((2 * n + 2) * (2 * Math.Pow(n, 2) + 1)));
        }

        static void Main(string[] args)
        {
            double x, E, n = 0, sum = 0, sl = 1;
            Console.Write("X: ");
            x = Convert.ToDouble(Console.ReadLine());
            Console.Write("E: ");
            E = Convert.ToDouble(Console.ReadLine());
            while ((D(x, n) * sl) <= E) 
            {
                sl = D(x, n) * sl;
                sum += D(x, n) * sl;
                n++;
            }
            Console.WriteLine(sum);
        }
    }
}
