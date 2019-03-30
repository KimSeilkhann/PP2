using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.SetWindowSize(80, 30);
           //Console.SetBufferSize(80, 30);
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Title = "My snake";
            Console.Clear();
            Interface menu = new Interface();
            menu.ShowMenu();
            Console.ReadKey();
        }
    }
}