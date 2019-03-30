using System;
namespace SnakeGame
{
    public class Snake : GameObject
    {
        enum Direction
        {
            NONE,
            RIGHT,
            LEFT,
            UP,
            DOWN
        }
        Direction direction = Direction.NONE;
        public bool ok;
        
        public Snake(int x, int y, char sign, ConsoleColor color) : base(x, y, sign, color)
        {

        }
        public void CheckDirection(ConsoleKeyInfo keyInfo)
        {
          
                if (keyInfo.Key == ConsoleKey.UpArrow)
                    direction = Direction.UP;
                if (keyInfo.Key == ConsoleKey.DownArrow)
                    direction = Direction.DOWN;
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                    direction = Direction.LEFT;
                if (keyInfo.Key == ConsoleKey.RightArrow)
                    direction = Direction.RIGHT;
                CanUMove(keyInfo);

        }
        public void CanUMove(ConsoleKeyInfo keyInfo)
        { 
            if (keyInfo.Key == ConsoleKey.UpArrow && direction == Direction.DOWN)
            {
                ok = false;
                return;
            }
            if (keyInfo.Key == ConsoleKey.DownArrow && direction == Direction.UP)
            {
                ok = false;
                return;
            }
            if (keyInfo.Key == ConsoleKey.LeftArrow && direction == Direction.RIGHT)
            {
                ok = false;
                return;
            }
            if (keyInfo.Key == ConsoleKey.RightArrow && direction == Direction.LEFT)
            {
                ok = false;
                return;
            }
            ok = true;
        }
        public void Move()
        {
            if (direction == Direction.NONE)
                return;

            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            if (direction == Direction.UP)
                body[0].y--;
            if (direction == Direction.DOWN)
                body[0].y++;
            if (direction == Direction.LEFT)
                body[0].x--;
            if (direction == Direction.RIGHT)
                body[0].x++;
        }
          
        }
      
    }
