using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Point
    {
        public int x;
        public int y;

        public Point(int a, int b)
        {
            x = a;
            y = b;

        }
        public void drawPoint(int z)
        {
            if (z % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(250);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(500);
            }
            Console.SetCursorPosition(x, y);
            Console.WriteLine('-');
        }
    }
}