using System;
using System.IO;

namespace Lab_Vectors
{
    /*(Вариант 9) Дан линейный массив, содержащий N целых чисел.
    Определить, количество таких элементов этого массива, которые не делятся на B и не делятся на C*/

    /*Файлы Inlet.in и Output.out находятся в каталоге проекта в папке \bin\Debug\netcoreapp3.1*/

    class Program
    {
        static void Main(string[] args)
        {
            string PathIn = "Inlet.in";
            string PathOut = "Outlet.out";
            string FileArray;
            string[] ArrayString;
            int[] ArrayInt;
            int B, C, counter = 0;

            using (var file = new StreamReader(Path.GetFullPath(PathIn)))
            {
                FileArray = file.ReadToEnd();
            }

            ArrayString = FileArray.Split("\r\n");
            ArrayInt = new int[ArrayString.Length];
            for (int i = 0; i < ArrayInt.Length; i++)
            {
                ArrayInt[i] = int.Parse(ArrayString[i]);
            }
            Console.Write("Введите B: ");
            B = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите C: ");
            C = Convert.ToInt32(Console.ReadLine());
            foreach (var item in ArrayInt)
            {
                if ((item % B != 0) && (item % C != 0))
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);

            using (var file = new StreamWriter(Path.GetFullPath(PathOut), false))
            {
                file.Write(counter);
            }
        }
    }
}
