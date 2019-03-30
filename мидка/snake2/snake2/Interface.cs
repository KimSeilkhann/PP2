using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Interface
    {
        public string[] menu = { "Continue", "New Game", "Load Level", "Quit" };
        public Game newgame;
        public Wall wall;
        public GameObjects g = new GameObjects();
        public Interface()
        {
            wall = new Wall('#', ConsoleColor.Green);
            wall.Level(0);
        }

        public void ShowMenu(bool isAlive = true)
        {
            wall.Draw();
            int x = 10;
            int y = 21;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.White;
            if (isAlive)
                Console.WriteLine("{0}(C)  |  {1}(N)  |  {2}(L)  |   {3}(Q)", menu[0], menu[1], menu[2], menu[3]);
            else
            {
                Console.SetCursorPosition(x + 8, y);
                Console.WriteLine("{0}(N)  |  {1}(L)  |   {2}(Q)", menu[1], menu[2], menu[3]);
            }

            Console.SetCursorPosition(x + 20, y + 5);
            Console.WriteLine("Mady by Akhmetov Alik");

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Q || keyInfo.Key == ConsoleKey.Escape)
                    Environment.Exit(0);
                if (keyInfo.Key == ConsoleKey.N)
                {
                    newgame = new Game(0);
                    newgame.Start();
                }
                if (keyInfo.Key == ConsoleKey.L)
                {
                    Console.Clear();
                    wall.Draw();
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 1; i <= 3; i++)
                    {
                        Console.SetCursorPosition(x + 25, y++);
                        Console.WriteLine("• Level {0}({1})", i, i);
                    }
                    ConsoleKeyInfo keyLevel = Console.ReadKey();
                    if (keyLevel.Key == ConsoleKey.NumPad1)
                        newgame = new Game(0);
                    else if (keyLevel.Key == ConsoleKey.NumPad2)
                        newgame = new Game(1);
                    else if (keyLevel.Key == ConsoleKey.NumPad3)
                        newgame = new Game(2);
                    else newgame = new Game(0);

                    newgame.Start();
                }
                if (keyInfo.Key == ConsoleKey.C)
                {
                    Snake snake = (Snake)g.SnakeDeserialize();
                    Wall wall2 = (Wall)g.WallDeserialize();
                    Food food = (Food)g.FoodDeserialize();

                    newgame = new Game(snake, food, wall2);
                    newgame.Start();
                }

            }

        }
    }
}