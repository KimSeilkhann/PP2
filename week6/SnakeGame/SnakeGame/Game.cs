using System;
using System.Collections.Generic;
using System.Threading;
namespace SnakeGame
{
    public class Game
    {
        List<GameObject> g_objects;
        public bool isAlive;
        public Snake snake;
        public Food food;
        public Wall wall;
       // public Dictionary<TKey, TValue>;

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
            //Console.SetCursorPosition(1, 100);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Hello! Please, write your username");

            string username = Console.ReadLine();
            Thread thread = new Thread(MoveSnake);
            thread.Start();
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.Clear();
            while (isAlive && keyInfo.Key != ConsoleKey.Escape)
            {
                keyInfo = Console.ReadKey();
                snake.CheckDirection(keyInfo);
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("GAME OVER!!!");
        }
        public void MoveSnake()
        {
            int x = 500;
            while (isAlive)
            {
                snake.Move();
                if (snake.IsCollisionWithObject(food))
                {
                    snake.body.Add(new Point(0, 0));
                    while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                        food.Generate();

                    if (snake.body.Count % 3 == 0)
                        wall.NextLevel();
                    x /= 2;

                }
                if (snake.IsCollisionWithObject(wall))
                {
                    isAlive = false;
                }
                Draw();
             
                    Thread.Sleep(x);
            
            }
        }
        public void Draw()
        {
            Console.Clear();
            foreach (GameObject g in g_objects)
                g.Draw();
        }
    }
}