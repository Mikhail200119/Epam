using System;

namespace Lab_Class_Vectors
{
    public class Vector
    {
        //private int x1 = 0, y1 = 0, z1 = 0;
        private int x, y, z;
        public Vector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }
        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }
        public void PrintVector()
        {
            Console.WriteLine($"x: {x}; y: {y}; z: {z}.");
        }
    }

    class Program
    { 
        static void Main(string[] args)
        {
            int x, y, z;
            Console.WriteLine("Vector A\n");
            Console.Write("x: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y: ");
            y = Convert.ToInt32(Console.ReadLine());
            Console.Write("z: ");
            z = Convert.ToInt32(Console.ReadLine());
            Vector A = new Vector(x, y, z);
            Console.WriteLine("Vector B\n");
            Console.Write("x: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y: ");
            y = Convert.ToInt32(Console.ReadLine());
            Console.Write("z: ");
            z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Vector B = new Vector(x, y, z);
            Vector C = A + B;
            Vector D = A - B;
            Vector E = A * B;
            C.PrintVector();
            D.PrintVector();
            E.PrintVector();
        }
    }
}