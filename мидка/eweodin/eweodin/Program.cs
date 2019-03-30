using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(1, 1);
            Thread t = new Thread(moving);
            void moving()
            {
                while (true)
                {
                    if (p.x >= 20)
                    {
                        p.x = 1;
                        p.y += 1;
                    }
                    else
                    {
                        p.x += 1;
                    }

                    p.drawPoint(p.y);
                }
            }

            t.Start();
            ConsoleKeyInfo btn = Console.ReadKey();
            if (btn.Key == ConsoleKey.Spacebar)
            {
                t.Suspend();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Your program is stopped on " + p.x + " " + p.y + " position");
            }
            //Console.WriteLine(Console.BufferWidth);

            Console.ReadKey();
        }

    }
}
