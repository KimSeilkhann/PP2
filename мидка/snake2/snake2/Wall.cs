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
    public class Wall : GameObjects
    {
        string[] levels = { "level1.txt", "level2.txt", "level3.txt" };
        public int index = 0;

        public Wall() { }
        public Wall(char sign, ConsoleColor color) : base(0, 0, sign, color)
        {
            body = new List<Point>();

        }

        public void Level(int index)
        {
            body = new List<Point>();
            for (int i = 0; i <= 78; i++)
            {
                body.Add(new Point(i, 0));
                body.Add(new Point(i, 20));
            }
            for (int i = 0; i <= 20; i++)
            {
                body.Add(new Point(0, i));
                body.Add(new Point(78, i));
            }

            string filename = levels[index];
            StreamReader sr = new StreamReader(filename);
            string[] rows = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    if (rows[i][j] == '#')
                        body.Add(new Point(j, i));

        }

        public void NextLevel()
        {
            index++;
            if (index > 2)
                index = 0;
            Level(index);
        }




    }
}