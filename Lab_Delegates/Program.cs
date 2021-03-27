using System;
using System.Threading;
using PingPong;

namespace Lab_Delegates
{
    class Program
    {
        static void StartGame(Ping A, Pong B)
        {
            Random rand = new Random();
            int HitNumber = rand.Next(2, 4);
            for (int i = 0; i < HitNumber; i++)
            {
                A.OnPing();
                B.OnPong();
            }
        }

        static void Main(string[] args)
        {
            Ping A = new Ping();
            Pong B = new Pong();
            StartGame(A, B);
        }
    }

}