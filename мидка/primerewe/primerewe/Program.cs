using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace amirla
{
    public class Amir
    {
        public string name;
        public int num;

        public Amir()
        {
        }
        public Amir(string n, int a)
        {
            name = n;
            a = num;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many obj you want to create?");
            int l = int.Parse(Console.ReadLine());
            Console.Clear();
            Amir[] amir = new Amir[l];

            for (int i = 0; i < l; i++)
            {
                Random random = new Random();
                amir[i] = new Amir
                {
                    name = Console.ReadLine(),
                    num = random.Next(1, 100)
                };
                string path = "test" + i + ".xml";

                FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                XmlSerializer xml = new XmlSerializer(typeof(Amir));

                xml.Serialize(fs, amir[i]);
                fs.Close();
            }
        }
    }
}