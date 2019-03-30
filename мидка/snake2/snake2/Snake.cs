using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Main
{
    [Serializable]
    public class Snake : GameObjects
    {
        public Snake() { }
        public Snake(int x, int y, char sign, ConsoleColor color) : base(x, y, sign, color) { }
        char last = 'N';

        public void MoveOn()
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
        }
        public void Move(ConsoleKeyInfo keyInfo)
        {
            if (body.Count == 1 && last == 'N')
            {
                MoveOn();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    body[0].y--;
                }
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    body[0].y++;
                }
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    body[0].x--;
                }
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    body[0].x++;
                }
            }
            else
            {
                if (keyInfo.Key == ConsoleKey.UpArrow && last != 'D')
                {
                    MoveOn();
                    body[0].y--;
                    last = 'U';
                }
                if (keyInfo.Key == ConsoleKey.DownArrow && last != 'U')
                {
                    MoveOn();
                    body[0].y++;
                    last = 'D';
                }
                if (keyInfo.Key == ConsoleKey.LeftArrow && last != 'R')
                {
                    MoveOn();
                    body[0].x--;
                    last = 'L';
                }
                if (keyInfo.Key == ConsoleKey.RightArrow && last != 'L')
                {
                    MoveOn();
                    body[0].x++;
                    last = 'R';
                }
            }
        }
    }
}