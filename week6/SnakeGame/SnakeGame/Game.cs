using System;
using System.Collections.Generic;
namespace SnakeGame
{
    public class Game
    {
        List<GameObject> g_objects;
        public bool isAlive;
        public Snake snake;
        public Food food;
        public Wall wall;

        public Game()
        {
            g_objects = new List<GameObject>();
            snake = new Snake(20, 10, '*', ConsoleColor.DarkBlue);
            food = new Food(0, 0, 'o', ConsoleColor.Black);
            wall = new Wall('#', ConsoleColor.Green);
            wall.LoadLevel();
            while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                food.Generate();

            g_objects.Add(snake);
            g_objects.Add(food);
            g_objects.Add(wall);

            isAlive = true;
        }

        public void Start()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine("Hello! Please, write your username");
            Console.WriteLine(Console.WindowWidth + " " + Console.WindowHeight);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.Clear();
            while (isAlive && keyInfo.Key != ConsoleKey.Escape)
            {
                Draw();
                keyInfo = Console.ReadKey();
                if (snake.IsCollisionWithObject(food))
                {
                    snake.body.Add(new Point(0, 0));
                    while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                        food.Generate();

                    if (snake.body.Count % 3 == 0)
                        wall.NextLevel();
                }
                if (snake.IsCollisionWithObject(wall))
                {
                    isAlive = false;
                }
                snake.Move(keyInfo);
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("GAME OVER!!!");
        }
        public void Draw()
        {
            Console.Clear();
            foreach (GameObject g in g_objects)
                g.Draw();
        }
    }
}