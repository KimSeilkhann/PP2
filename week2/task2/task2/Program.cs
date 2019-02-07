using System;
using System.IO;
namespace task2
{
    class MainClass
    {
        public static bool Pr(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)     //функция для проверки на прайм
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../input.txt");      //считываем стринг через файл 
            String b = sr.ReadToEnd();
            String[] s = b.Split();         //делим стринг в массив 
            sr.Close();
            string ans = "";            
            foreach (String a in s)
            {
                int c = int.Parse(a);       //проегаемся по массиву, каждый элемент парсим в инт и проверяем на прайм
                if (Pr(c) == true) ans += a + " ";  //если число прайм добавляем в стринг ответ
            }
            StreamWriter sw = new StreamWriter("../../output.txt");     //через файл айтпут выводим ответ
            sw.WriteLine(ans);
            sw.Close();

        }
    }
}
