using System;
using System.IO;
namespace task1
{
    class MainClass
    {
        public static void Kek()                //создаем функцию 
        {
            StreamReader sr = new StreamReader("../../input.txt");      //считываем стринг через инпут файл
            string s = sr.ReadToEnd();
            string[] a = s.Split();
            int l = a.Length;
            for (int i = 0; i < l / 2; i++)     //проверяем стринг на палиндром и выводим ответ
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
            Kek();      //вызываем нашу функцию 
        }
    }
}
