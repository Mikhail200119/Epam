using System;
using System.Threading;
using PingPong;

/*Напишите "пинг-понг":
•	2 класса Ping и Pong
•	один уведомляет другого, о том, что "произошёл пинг", другой - о том, что "произошёл понг",
•	одна пара объектов "играют" между собой, другая пара - между собой и т.д.
и выводить на консоль соответсвующие сообщения, что-то вроди такого:
1.	Ping received Pong.
2.	Pong received Ping.
3.	Ping received Pong.
4.	Pong received Ping.
5.	Ping received Pong.
*/

namespace Lab_Delegates
{ 
    class Program
    {
        static void StartGame(Ping A, Pong B)
        {
            Random rand = new Random();
            int HitCounter = 1;
            int HitNumber = rand.Next(2, 4);
            for (int i = 0; i < HitNumber; i++)
            {
                Console.Write(HitCounter + ". ");
                A.OnPing();
                HitCounter++;
                Thread.Sleep(800);
                Console.Write(HitCounter + ". ");
                B.OnPong();
                HitCounter++;
                Thread.Sleep(800);
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