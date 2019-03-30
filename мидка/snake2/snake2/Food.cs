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
    public class Food:GameObjects
    {
        public Food(int x, int y, char sign, ConsoleColor color) : base(x, y, sign, color) { }

        public Food()
        {
            
        }
        public void Generate()
        {
            Random random = new Random();
            int x = random.Next(1, 70);
            int y = random.Next(1, 20);
            body[0].x = x;
            body[0].y = y;
        }
    }
}