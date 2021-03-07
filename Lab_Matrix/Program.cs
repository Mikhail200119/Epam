using System;
using System.IO;

/*(Вариант 9) Текстовый файл Inlet.in содержит целочисленные
       значения элементов массива A[0..N-1, 0..M-1].
       Осуществить циклический сдвиг элементов в строках
       прямоугольной матрицы на k элементов вправо,
       k может быть больше количества элементов в строке.
       Результат решения задачи внести в файл Outlet.out.*/

/*Файлы Inlet.in и Output.out находятся в каталоге проекта в папке \bin\Debug\netcoreapp3.1*/

namespace Lab_Mateix
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0, M = 0, i = 0, j = 0, k;
            int counter = 0, t = 0, number = 0, f = 0, buff = 0, Cache = 0;
            int[,] Matrix = new int[50, 50];
            int[] AuxiliaryArray = new int[50];
            string FileString, str;
            char[] splt = { ' ', '\n' };
            string[] FileMatrix;
            string[] BuffMatrix;
            string PathIn = "Inlet.in";
            string PathOut = "Outlet.out";
            string path = Path.GetFullPath(PathIn);
            using (var file = new StreamReader(path))
            {
                str = file.ReadToEnd();
                file.Close();
            }
            using (var file = new StreamReader(PathIn))
            {
                while (!file.EndOfStream)
                {
                    FileString = file.ReadLine();
                    FileMatrix = FileString.Split(' ');
                    for (j = 0; j < FileMatrix.Length; j++)
                    {
                        Matrix[i, j] = int.Parse(FileMatrix[j]);
                    }
                    i++;
                }
                BuffMatrix = str.Split(splt);
                file.Close();
            }
            N = i;
            M = j;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < M; j++)
                {
                    Console.Write(Matrix[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
            Console.Write("\nK: ");
            k = Convert.ToInt32(Console.ReadLine());
            while (k > N * M * 2)
            {
                k /= 2;
            }
            buff = k;
            k = Math.Abs(M * N - k);
            if (buff > M * N)
            {
                buff = Math.Abs(M * N - k);
                Cache = buff;
                buff = k;
                k = Cache;
            }
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < M; j++)
                {
                    number++;
                    if (number >= k + 1)
                    {
                        AuxiliaryArray[f] = Matrix[i, j];
                        f++;
                    }
                }
            }
            f = 0;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < M; j++)
                {
                    if (counter < buff)
                    {
                        counter++;
                        Matrix[i, j] = AuxiliaryArray[f];
                        f++;
                    }
                    else
                    {
                        Matrix[i, j] = int.Parse(BuffMatrix[t]);
                        t++;
                    }
                }
            }
            Console.WriteLine("\n");
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < M; j++)
                {
                    Console.Write(Matrix[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
            using (var file = new StreamWriter(PathOut, false))
            {
                for (i = 0; i < N; i++)
                {
                    for (j = 0; j < M; j++)
                    {
                        file.Write(Matrix[i, j] + "\t");
                    }
                    file.WriteLine();
                }
                file.Close();
            }
        }
    }
}