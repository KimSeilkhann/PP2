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
            if (direction == Direction.NONE)
            {
                if (keyInfo.Key == ConsoleKey.UpArrow)
                    direction = Direction.UP;
                if (keyInfo.Key == ConsoleKey.DownArrow)
                    direction = Direction.DOWN;
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                    direction = Direction.LEFT;
                if (keyInfo.Key == ConsoleKey.RightArrow)
                    direction = Direction.RIGHT;
            }
          
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
        public void Move(ConsoleKeyInfo keyInfo)
        {
            CheckDirection(keyInfo);
            CanUMove(keyInfo);
         
            if (ok)
            {
                for (int i = body.Count - 1; i > 0; i--)
                {
                    body[i].x = body[i - 1].x;
                    body[i].y = body[i - 1].y;
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                    body[0].y--;
                if (keyInfo.Key == ConsoleKey.DownArrow)
                    body[0].y++;
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                    body[0].x--;
                if (keyInfo.Key == ConsoleKey.RightArrow)
                    body[0].x++;
                direction = Direction.NONE;
                CheckDirection(keyInfo);
            }
          
        }
      
    }
}