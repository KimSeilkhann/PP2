using System;
using System.Collections.Generic;
namespace SnakeGame
{
    public class GameObject
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;

        public GameObject(int x, int y, char sign, ConsoleColor color)
        {
            //body = new List<Point>();
            //Point p = new Point(x, y);
            //body.Add(p);
            body = new List<Point>
            {
                new Point(x, y)
            };

            this.sign = sign;
            this.color = color;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }

        public bool IsCollisionWithObject(GameObject obj)
        {
            // Check obj is instance of Snake 
            foreach (Point p in obj.body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            }
            return false;
        }

    }
}