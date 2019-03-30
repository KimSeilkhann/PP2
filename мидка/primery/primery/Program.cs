using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread2
{
    class Program
    {
        static int x = 0, y = 0, x1 = 1, y1 = 0, x2 = 0, y2 = 1, x3 = 1, y3 = 1;

        static int Direction = 1;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            MoveStar();
        }

        public static void MoveStar()
        {
            while (true)
            {
                if (Direction == 1)
                {
                    x++;
                    x1++;
                    x2++;
                    x3++;
                    if (x1 == Console.WindowWidth - 1)
                    {
                        Direction = 2;
                    }
                }
                if (Direction == 2)
                {
                    y++;
                    y1++;
                    y2++;
                    y3++;
                    if (y == Console.WindowHeight)
                    {
                        Direction = 3;
                    }
                }
                if (Direction == 3)
                {
                    x--;
                    x1--;
                    x2--;
                    x3--;
                    if (x == 0)
                    {
                        Direction = 4;
                    }
                }
                if (Direction == 4)
                {
                    y--;
                    y1--;
                    y2--;
                    y3--;
                    if (y == 0)
                    {
                        Direction = 1;
                    }
                }
                Console.Clear();
                Draw(x, y);
                Draw1(x, y);
                Draw2(x, y);
                Draw3(x, y);
                Thread.Sleep(10);
            }
        }
        public static void Draw(int x, int y)
        {

            Console.SetCursorPosition(x, y);
            Console.Write("*");
        }
        public static void Draw1(int x, int y)
        {
            Console.SetCursorPosition(x1, y1);
            Console.Write("*");
        }
        public static void Draw2(int x, int y)
        {
            Console.SetCursorPosition(x2, y2);
            Console.Write("*");
        }
        public static void Draw3(int x, int y)
        {
            Console.SetCursorPosition(x3, y3);
            Console.Write("*");
        }
    }
}
