using System;
using System.IO;

namespace Lab_Geometry_Figure
{
    class Ellipse
    {
        public double D1;
        public double D2;
    }

    class Program
    { 

        static double S_Ellipse(double a, double b)
        {
            return Math.PI * a * b / 4;
        }

        static double P_Ellipse(double a, double b)
        {
            return 4 * (Math.PI * a * b + Math.Pow(a - b, 2)) / (a + b);
        }

        static int Main(string[] args)
        {
            string PathIn = @"C:\Users\koval\Desktop\epam\Lab_Geometry_Figure\Inlet.in";
            string PathOut = @"C:\Users\koval\Desktop\epam\Lab_Geometry_Figure\Outlet.in";
            string StringFile;
            string[] buff;
            Ellipse ellipse = new Ellipse();

            using (var file = new StreamReader(PathIn))
            {
                StringFile = file.ReadToEnd();
            }

            buff = StringFile.Split(' ');
            /*Console.Write("Введите первый диаметр эллипса: ");
            ellipse.D1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите второй диаметр эллипса: ");
            ellipse.D2 = Convert.ToDouble(Console.ReadLine());*/
            ellipse.D1 = Convert.ToDouble(buff[0]);
            ellipse.D2 = Convert.ToDouble(buff[1]);
            if (ellipse.D1 <= 0 || ellipse.D2 <= 0)
            {
                Console.WriteLine("Данные введены некорректно!");
                return 0;
            }

            using (var file = new StreamWriter(PathOut))
            {
                file.WriteLine("Площадь эллипса: " + S_Ellipse(ellipse.D1, ellipse.D2));
                file.WriteLine("Периметр эллипса: " + P_Ellipse(ellipse.D1, ellipse.D2));
            }
            return 0;
        }
    }
}