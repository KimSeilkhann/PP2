using System;
using System.IO;
namespace task3
{
    class MainClass
    {
        public static void Probely(int lvl)             //method to separate space by level of lines 
        {
            for(int i=0; i<lvl; i++)
            {
                Console.Write("    ");
            }
        }
        public static void Direc(DirectoryInfo dir, int lvl)        //method to output name of each file and directory 
        {
            foreach (FileInfo f in dir.GetFiles())      //take files from the directory and show
            {
                Probely(lvl);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.WriteLine(f.Name);
            }
            foreach(DirectoryInfo d in dir.GetDirectories())  //take directories from the directory and show
            {
                Probely(lvl);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(d.Name);
                Direc(d, lvl+1);        //by recursion call the method Direc to show another files and directories 
            }
        }

        public static void Main(string[] args)
        {
            string path = Console.ReadLine();   // we can read string path from the console, but i take as example my own path
            DirectoryInfo dirr = new DirectoryInfo(path);    // take information about our directory from the string path
            Direc(dirr, 0);     //call the method Direc, dir - inf. about directory , 0 - first line level
      }
    }
}
