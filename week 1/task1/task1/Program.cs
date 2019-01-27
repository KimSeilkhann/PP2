using System;
using System.Collections.Generic;
namespace task1
{
    class MainClass
    {
       
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
           
            string[] s = Console.ReadLine().Split(); //считываем наш массив в виде стринга 

            List<int> b = new List<int>(); // создаем лист чтобы в дальнейшем добавлять туда наши прайм числа
            int cnt = 0; // создаем счетчик каунтер чтобы считать количество прайм чисел

            for (int i=0; i<n; i++)
            {
                int a;                  // пробегаемся по всем элементам, каждый элемпент массива  s переводим (парсим) в интеджер
                a = int.Parse(s[i]);

                int r = 1;          // это у нас переменная как бул чтобы проверять прайм ли наше число или нет

                for (int j = 2; j <= Math.Sqrt(a); j++)
                {
                    if (a % j == 0)         // пробегаемся от 2 до Sqrt(a) чтобы проверить есть ли делители числа а, если да то число не прайм 
                    {
                        r = 0;
                        break;
                    }
                }
                if (r == 1) 
                {
                    b.Add(a);
                    cnt++;
                }
            }
            Console.WriteLine(cnt);
            for(int i=0; i<b.Count; i++)
            {
                Console.Write(b[i]+ " ");
            }

        }
    }
}
