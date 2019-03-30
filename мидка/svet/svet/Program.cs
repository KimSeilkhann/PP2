using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Thread1Repeat
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Draw(ConsoleColor.Red, ConsoleColor.White, ConsoleColor.White);
                Thread.Sleep(1000);
                Draw(ConsoleColor.White, ConsoleColor.Yellow, ConsoleColor.White);
                Thread.Sleep(1000);
                Draw(ConsoleColor.White, ConsoleColor.White, ConsoleColor.Green);
                Thread.Sleep(1000);
            }
        }

        public static void Draw(ConsoleColor color, ConsoleColor color1, ConsoleColor color2)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.ForegroundColor = color;
                    Console.Write("*");

                }

            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(j, i + 5);
                    Console.ForegroundColor = color1;
                    Console.Write("*");

                }

            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(j, i + 10);
                    Console.ForegroundColor = color2;
                    Console.Write("*");

                }

            }
        }
    }
}