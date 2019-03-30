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
    public class GameObjects
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;

        public GameObjects() { }
        public GameObjects(int x, int y, char sign, ConsoleColor color)
        {
            body = new List<Point> { new Point(x, y) };
            this.sign = sign;
            this.color = color;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
                Console.ForegroundColor = color;
            }
        }

        public bool IsCollisionWithSnake()
        {
            for (int i = 1; i < body.Count; i++)
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            return false;
        }

        public bool IsCollisionWithObject(GameObjects obj)
        {
            foreach (Point p in obj.body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            }
            return false;
        }

        public void SnakeSerialize(GameObjects g)
        {
            if (File.Exists("savesnake.xml"))
                File.Delete("savesnake.xml");
            FileStream fs = new FileStream("savesnake.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Snake));
            xs.Serialize(fs, g);
            fs.Close();
        }

        public GameObjects SnakeDeserialize()
        {
            FileStream fs = new FileStream("savesnake.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Snake));
            GameObjects snake = xs.Deserialize(fs) as GameObjects;
            fs.Close();
            return snake;
        }

        public void WallSerialize(GameObjects g)
        {
            if (File.Exists("savewall.xml"))
                File.Delete("savewall.xml");
            FileStream fs = new FileStream("savewall.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Wall));
            xs.Serialize(fs, g);
            fs.Close();
        }

        public GameObjects WallDeserialize()
        {
            FileStream fs = new FileStream("savewall.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Wall));
            GameObjects wall = xs.Deserialize(fs) as GameObjects;
            fs.Close();
            return wall;
        }

        public void FoodSerialize(GameObjects g)
        {
            if (File.Exists("savefood.xml"))
                File.Delete("savefood.xml");
            FileStream fs = new FileStream("savefood.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Food));
            xs.Serialize(fs, g);
            fs.Close();
        }

        public GameObjects FoodDeserialize()
        {
            FileStream fs = new FileStream("savefood.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Food));
            GameObjects food = xs.Deserialize(fs) as GameObjects;
            fs.Close();
            return food;
        }
    }
}