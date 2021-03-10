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
    class Ellipse
    {
        private double D1;

        private double D2;

        public double D1_DataChecking
        {
            get
            {
                if (D1 <= 0)
                {
                    return -1;
                }
                return D1;
            }
            set
            {
                D1 = value;
                if (D1 <= 0)
                {
                    Console.WriteLine("Первая диагональ задана некорректно");
                }
            }
        }

        public double D2_DataChecking
        {
            get
            {
                if (D2 <= 0)
                {
                    return -1;
                }
                return D2;
            }
            set
            {
                D2 = value;
                if (D2 <= 0)
                {
                    Console.WriteLine("Вторая диагональ задана некорректно");
                }
            }
        }


        public Ellipse(double D1, double D2)
        {
            D1_DataChecking = D1;
            D2_DataChecking = D2;
        }

        public double S_Ellipse()
        {
            return Math.PI * D1 * D2 / 4;
        }

        public double P_Ellipse()
        {
            return 4 * (Math.PI * D1 * D2 + Math.Pow(D1 - D2, 2)) / (D1 + D2);
        }
    }

    class Program
    {
        static int Main(string[] args)
        {
            double D1, D2;
            string PathIn = "Inlet.in";
            string PathOut = "Outlet.out";
            string StringFile;
            string[] buff;
            Ellipse ellipse;

            using (var file = new StreamReader(Path.GetFullPath(PathIn)))
            {
                StringFile = file.ReadToEnd();
                file.Close();
            }
            buff = StringFile.Split(' ');
            try
            {
                D1 = double.Parse(buff[0]);
                D2 = double.Parse(buff[1]);
            }
            catch
            {
                Console.WriteLine("Ошибка считывания данных!");
                return 0;
            }
            ellipse = new Ellipse(D1, D2);
            using (var file = new StreamWriter(Path.GetFullPath(PathOut), false))
            {
                if (ellipse.D1_DataChecking != -1 && ellipse.D2_DataChecking != -1)
                {
                    Console.WriteLine("Площадь эллипса: " + ellipse.S_Ellipse());
                    Console.WriteLine("Периметр эллипса: " + ellipse.P_Ellipse());
                    file.WriteLine("Площадь эллипса: " + ellipse.S_Ellipse());
                    file.WriteLine("Периметр эллипса: " + ellipse.P_Ellipse());
                }
                file.Close();
            }
            return 0;
        }
    }
}