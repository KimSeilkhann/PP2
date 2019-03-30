﻿using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
namespace stena
{
    class Program
    {
        public static List<Body> bb = new List<Body>();
        public static List<Body> ww = new List<Body>();
        public static bool ok = true;
        public static ConsoleKeyInfo kf = new ConsoleKeyInfo();

        public static void ReadCar()
        {
            StreamReader sr = new StreamReader("rer7txt.txt");
            string[] rows = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].Length; j++) {
                    if ((bb != null) && (rows[i][j] == '*'))
                        bb.Add(new Body(j, i));
                    if ((ww != null) && (rows[i][j] == '#'))
                        ww.Add(new Body(j, i));
                }
            }
        }

        public static void Direction(ConsoleKeyInfo kd)
        {
            if (kd.Key == ConsoleKey.LeftArrow)
                ok = false;
            if (kd.Key == ConsoleKey.RightArrow)
                ok = true;
        }
        public static void Draw()
        {
            //kf = Console.ReadKey();
            //Direction(kf);
            while (true)
            {
                Console.Clear();

                for (int i = bb.Count - 1; i > 0; i--)
                {
                    if (ok)
                    {
                        bb[i].x++;
                    }
                    if (ok == false) bb[i].x--;
                    Console.SetCursorPosition(bb[i].x, bb[i].y);
                    Console.Write('*');

                }
                for(int i=ww.Count-1; i>0; i--)
                {
                    Console.SetCursorPosition(ww[i].x, ww[i].y);
                    Console.Write('#');
                }
                Thread.Sleep(300);
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            ReadCar();

            Thread thread = new Thread(Draw);
            thread.Start();
            while (true)
            {
                kf = Console.ReadKey();
                Direction(kf);
            }
            //}
            //thread.Abort();
        }
    }
}
