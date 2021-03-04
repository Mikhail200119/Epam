using System;
using System.IO;

namespace Lab_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            string PathIn = @"C:\Users\koval\Desktop\buff\Lab_Vectors\Inlet.in.txt";
            string PathOut = @"C:\Users\koval\Desktop\buff\Lab_Vectors\Outlet.in.txt";
            string FileArray;
            string[] ArrayString;
            int[] ArrayInt;
            int B, C, counter = 0;

            using (var file = new StreamReader(PathIn))
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

            using (var file = new StreamWriter(PathOut, false))
            {
                file.Write(counter);
            }
        }
    }
}
