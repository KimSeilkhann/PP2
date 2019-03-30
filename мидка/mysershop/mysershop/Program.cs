using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace mysershop
{
    // Дина я не успела дописать эту задачу 
    [Serializable]
    public class Book
    {

        public static string name = "ekuv";
        public static List<string> names = new List<string>();
        public static int amount = 6;
        public static int price = 7;
        public Book()
        {

        }

        //public Book(string name, int amount, int price)
        //{
        //    this.name = name;
        //    this.amount = amount; 
        //    this.price = price;
        //}
        public static void Vyvod()
        {
            Console.WriteLine(name + " " + amount + " " + price);
        }
        public static void Va(string a)
        {
            names.Add(a);
        }

        public static void ShopSer(Book shopp)
        {
            FileStream fs = new FileStream("save.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Book));
            xs.Serialize(fs, shopp);
            fs.Close();
        }
        public Book Des()
        {
            FileStream fs = new FileStream("save.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Book));
            Book S = xs.Deserialize(fs) as Book;
            return S;
        }
        public static void Showall()
        {

                        for(int i=0; i<names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
    class Program
    {
        public static void Vvod()
        {
            Book sh = new Book();
            string a, b, c;
           a = Console.ReadLine();
            b = Console.ReadLine();
           c =  Console.ReadLine();
            Book.name = a;
            Book.Va(a);
            Book.ShopSer(sh);
        }
        static void Main(string[] args)
        {

            Book shop = new Book();
            int x = 0, y = 0;
            Console.WriteLine("showall");
            Console.WriteLine("add new");
            Console.SetCursorPosition(x,y);
            int curs = 0;
            ConsoleKeyInfo cf = new ConsoleKeyInfo();
            while (true)
            {
                cf = Console.ReadKey();
               
                if(cf.Key == ConsoleKey.Enter)
                {
                    if (curs == 0)
                        Book.Showall();
                    if (curs == 1)
                        Vvod();
                    break;
                   
                }
                if (cf.Key == ConsoleKey.DownArrow)
                {
                    curs++;
                    y++;
                    if (y >1) {
                     y = 0;
                        curs = 0;
                    }
                }
                if (cf.Key == ConsoleKey.UpArrow)
                {
                    curs--;
                    y--;
                    if (y < 0)
                    {
                        y = 1;
                        curs = 1;
                    }

                }
                Console.SetCursorPosition(x, y);

            }
            //Console.Clear();
            //Shop shop2 = shop.Des();
            //Console.WriteLine(shop2.name + " " + shop2.s);

        }
    }

}
