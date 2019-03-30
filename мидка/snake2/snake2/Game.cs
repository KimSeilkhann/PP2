using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Game
    {
        List<GameObjects> g_objects;
        public bool isAlive;
        public Snake snake;
        public Food food;
        public Wall wall;
        public Interface menu = new Interface();

        public Game() { }

        public Game(Snake snake, Food food, Wall wall)
        {
            isAlive = true;
            g_objects = new List<GameObjects>();
            this.snake = snake;
            this.wall = wall;
            this.food = food;
            g_objects.Add(snake);
            g_objects.Add(food);
            g_objects.Add(wall);
            while (food.IsCollisionWithObject(snake) && food.IsCollisionWithObject(wall))
                food.Generate();
            wall.Level(wall.index);
        }

        public Game(int i = 0)
        {
            isAlive = true;
            g_objects = new List<GameObjects>();
            snake = new Snake(30, 13, 'o', ConsoleColor.White);
            food = new Food(2, 2, '@', ConsoleColor.DarkRed);
            wall = new Wall('#', ConsoleColor.Green);
            g_objects.Add(snake);
            g_objects.Add(food);
            g_objects.Add(wall);
            while (food.IsCollisionWithObject(snake) && food.IsCollisionWithObject(wall))
                food.Generate();
            wall.index = i;
            wall.Level(wall.index);


        }

        public void Draw()
        {
            Console.Clear();
            foreach (GameObjects g in g_objects)
                g.Draw();
        }

        public void Start()
        {
            while (isAlive)
            {
                Draw();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(20, 21);
                Console.WriteLine("Current Level: {0}   |   Score: {1}", wall.index + 1, snake.body.Count);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(10, 25);
                Console.WriteLine("{0}(C)  |  {1}(N)  |  {2}(L)  |   {3}(Q)", menu.menu[0], menu.menu[1], menu.menu[2], menu.menu[3]);
                Console.SetCursorPosition(30, 27);
                Console.WriteLine("Mady by Akhmetov Alik");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    g_objects[0].SnakeSerialize((Snake)g_objects[0]);
                    g_objects[1].FoodSerialize((Food)g_objects[1]);
                    g_objects[2].WallSerialize((Wall)g_objects[2]);
                    break;
                }
                if (snake.IsCollisionWithObject(food))
                {
                    snake.body.Add(new Point(0, 0));
                    while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                        food.Generate();
                    if (snake.body.Count % 5 == 0)
                        wall.NextLevel();

                }
                if (snake.IsCollisionWithSnake())
                {
                    isAlive = false;
                }
                if (snake.IsCollisionWithObject(wall))
                    isAlive = false;
                snake.Move(keyInfo);


            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(34, 15);
            Console.WriteLine("GAME IS OVER");
            Console.SetCursorPosition(34, 16);
            Console.WriteLine("____________");
            Console.SetCursorPosition(34, 17);
            Console.WriteLine("Your score " + snake.body.Count);
            menu.ShowMenu(isAlive);
        }

    }
}