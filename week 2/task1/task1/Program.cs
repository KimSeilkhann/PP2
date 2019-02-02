using System;
using System.IO;
namespace task1
{
    class MainClass
    {
        public static void kek()
        {
            StreamReader sr = new StreamReader("../../input.txt");
            string s = sr.ReadToEnd();
            string[] a = s.Split();
            int l = a.Length;
            for(int i=0; i<l/2; i++)
            {
                if (a[i] != a[l - i - 1])
                {
                    Console.WriteLine("No");
                    return;
                }

            }

            Console.WriteLine("Yes");

        }
        public static void Main(string[] args)
        {
            kek();
        }
    }
}
