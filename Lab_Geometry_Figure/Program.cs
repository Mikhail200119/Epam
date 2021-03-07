using System;
using System.IO;

/*Задание.
• Разработать класс геометрической фигуры по варианту, заданной на плоскости линейными размерами
(например, сторонами a,b,c в случае треугольника).
• Предусмотреть возможность проверки существования фигуры, реализовать функции подсчета его 
площади и периметра.
• В качестве UI-интерфейса использовать консольное приложение с интерфейсом командной строки, 
WinForms или WPF-приложение.

                                    Вариант 9: Эллипс*/

/*Файлы Inlet.in и Output.out находятся в каталоге проекта в папке \bin\Debug\netcoreapp3.1*/

namespace Lab_Geometry_Figure
{

                /*Разработать класс геометрической фигуры по варианту, заданной на плоскости линейными размерами
                (например, сторонами a,b,c в случае треугольника).
                • Предусмотреть возможность проверки существования фигуры, реализовать функции подсчета его
                площади и периметра.
                • В качестве UI-интерфейса использовать консольное приложение с интерфейсом командной строки,
                WinForms или WPF-приложение.
                Вариан 9: Эллипс*/

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
            string PathIn = "Inlet.in";
            string PathOut = "Outlet.in";
            string StringFile;
            string[] buff;
            Ellipse ellipse = new Ellipse();

            using (var file = new StreamReader(Path.GetFullPath(PathIn)))
            {
                StringFile = file.ReadToEnd();
            }

            buff = StringFile.Split(' ');
            ellipse.D1 = Convert.ToDouble(buff[0]);
            ellipse.D2 = Convert.ToDouble(buff[1]);
            Console.WriteLine("Первый диаметр: " + ellipse.D1);
            Console.WriteLine("Второй диаметр: " + ellipse.D2);
            if (ellipse.D1 <= 0 || ellipse.D2 <= 0)
            {
                Console.WriteLine("Данные введены некорректно!");
                return 0;
            }

            Console.WriteLine("Площадь эллипса: " + S_Ellipse(ellipse.D1, ellipse.D2));
            Console.WriteLine("Периметр эллипса: " + P_Ellipse(ellipse.D1, ellipse.D2));

            using (var file = new StreamWriter(Path.GetFullPath(PathOut), false))
            {
                file.WriteLine("Площадь эллипса: " + S_Ellipse(ellipse.D1, ellipse.D2));
                file.WriteLine("Периметр эллипса: " + P_Ellipse(ellipse.D1, ellipse.D2));
            }
            return 0;
        }
    }
}