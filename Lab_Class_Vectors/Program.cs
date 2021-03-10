using System;
using System.IO;

namespace Lab_Class_Vectors
{
    public class Vector
    {
        private double x, y, z;

        private double ModuleOfVector;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            ModuleOfVector = Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2) + Math.Pow(this.z, 2));
        }

        public override string ToString()
        {
            return $"( {x} ; {y} ; {z} )";
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }
        public static double operator *(Vector v1, Vector v2)   //  Скалярное произведение векторов
        {
            return v1.x * v2.x + v2.y * v2.y + v2.z + v2.z;
        }
        public void PrintVector()
        {
            Console.WriteLine(ToString());
        }
    }

    class Program
    { 
        static void Main(string[] args)
        {
            double x, y, z;
            string[] FileString;
            Vector A, B;

            using(var file = new StreamReader(Path.GetFullPath("Inlet.in")))
            {
                FileString = file.ReadLine().Split(' ');
                x = double.Parse(FileString[0]);
                y = double.Parse(FileString[1]);
                z = double.Parse(FileString[2]);
                A = new Vector(x, y, z);
                FileString = file.ReadLine().Split(' ');
                x = double.Parse(FileString[0]);
                y = double.Parse(FileString[1]);
                z = double.Parse(FileString[2]);
                B = new Vector(x, y, z);
                file.Close();
            }
         
            Vector Sum = A + B;
            Vector Difference = A - B;
            double ScalarMultiply = A * B;
            Console.Write("Sum: ");
            Sum.PrintVector();
            Console.Write("Difference: ");
            Difference.PrintVector();
            Console.WriteLine("Scalar multiply: " + ScalarMultiply);
        }
    }
}