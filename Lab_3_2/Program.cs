using System;

namespace Lab3_2
{
                        /*(Вариант 9) Задача 2. Напишите программу нахождения суммы, включая в нее начальные слагаемые,
                    абсолютная величина которых не превосходит заданной точности E */
    class Program
    {
        static double D(double n)
        {
            return -((Math.Pow(n, 2)) / Math.Pow((n + 1), 2));
        }

        static void Main(string[] args)
        {
            double E, n = 1, sl = 1, sum = 0;
            Console.Write("E: ");
            E = Convert.ToDouble(Console.ReadLine());
            while ((D(n) * sl) <= E)
            {
                sl = D(n) * sl;
                sum += D(n) * sl;
                n++;
            }
            Console.WriteLine(sum);
        }
    }
}
