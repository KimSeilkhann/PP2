using System;

namespace task2
{
    class Student       //создаем класс студент
    {
       
            public string name;             // объявляем переменные 
            public string id;
            public int year;

            public Student(string name, string id)      // создаем конструктор который принимает 2 переменные имя и айди
        {
            this.name = name;
            this.id = id;
        }
        public Student(int year)        //создаем конструктор который принимает переменную год
        {
            this.year = year;
        }
        public void Yearr()         // функция для инкремента года
        {
           year++;
        }
        public void Cout()      //функция для вывода перемиенных 
        {
            Console.WriteLine(name + " " + id + " " + year);
        }
    }
    class Program { 
    public static void Main(string[] args)
        {
            string a = Console.ReadLine();      //считываем стринг, разделяем на 3 стринга
            string[] s = a.Split();
            Student kakawka = new Student(s[0],s[1]); // создаем переменную студент для имени и айди
            kakawka.year = int.Parse(s[2]);     // парсим в инт третий стринг и создаем переменную студент для года 
            kakawka.Yearr();        // вызываем функцию вывода всех переменных
        }
    }
}
