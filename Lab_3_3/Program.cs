using System;

namespace Lab_3_3
{
                        /*(Вариант 9) Задача 3. Напишите программу нахождения первого члена числовой последовательности
                    {an} , который отличается от предыдущего ему члена не более, чем на E*/
    class Program
    {
        static double An(double x, double previousAn, double n)
        {
            return (3 + (Math.Pow(Math.Cos(previousAn - x), 2)) / Math.Pow(2, n));
        }

        static void Main(string[] args)
        {
            double x, n = 1, E, an, previousAn;
            Console.Write("Введите точность E: ");
            E = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите X: ");
            x = Convert.ToDouble(Console.ReadLine());
            an = x;
            do
            {
                n++;
                previousAn = an;
                an = An(x, previousAn, n);
            } while (Math.Abs(previousAn - an) >= E);
            Console.WriteLine(an);
        }
    }
}
