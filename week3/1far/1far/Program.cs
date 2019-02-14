using System;
using System.IO;
namespace far
{
    class Zhorik
    {
        public int curs = 0;
        public bool isHidden;
        public string path;
        public int size;
        DirectoryInfo directory = null;
        FileSystemInfo currentFs = null;
        public Zhorik(string path)
        {
            this.path = path;
            curs = 0;
            directory = new DirectoryInfo(path);
            size = directory.GetFileSystemInfos().Length;
            isHidden = true;
        }
        public void SizeCnt()
        {
            directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            size = fs.Length;
            if (isHidden == false)
                for (int i = 0; i < fs.Length; i++)
                    if (fs[i].Name[0] == '.')
                        size--;

        }
        public void Color(FileSystemInfo fs, int ind)
        {
            if (curs == ind)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                currentFs = fs;
            }
            else if (fs is DirectoryInfo)
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void Show()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            for (int i = 0, t = 0; i < fs.Length; i++)
            {
                if (isHidden == false && fs[i].Name[0] == '.')
                {
                    continue;
                }
                Color(fs[i], t);
                Console.WriteLine(fs[i].Name);
                t++;
            }
        }
        public void Ustige()
        {
            curs--;
            if (curs < 0)
                curs = size - 1;
        }
        public void Astyga()
        {
            curs++;
            if (curs == size)
                curs = 0;
        }
        public void Nachalo()
        { 
        ConsoleKeyInfo consoleKey = Console.ReadKey();
            while(consoleKey.Key != ConsoleKey.Escape)
            {
                SizeCnt();
                Show();
                consoleKey = Console.ReadKey();
                if(consoleKey.Key == ConsoleKey.UpArrow)
                {
                    Ustige();
                }
                if (consoleKey.Key == ConsoleKey.DownArrow)
                {
                    Astyga();
                }
                if (consoleKey.Key == ConsoleKey.RightArrow)
                {
                    isHidden= false;
                    curs = 0;
                }
                if (consoleKey.Key == ConsoleKey.LeftArrow)
                {
                    curs = 0;
                    isHidden = true;
                }
                if(consoleKey.Key == ConsoleKey.Enter)
                {
                    if(currentFs is DirectoryInfo)
                    {
                        curs = 0;
                        path = currentFs.FullName;
                    }
                  
                }
                if (consoleKey.Key == ConsoleKey.Backspace)
                {
                    curs = 0;
                    path = directory.Parent.FullName;
                }

            }
        }

    }
    class MainClass { 

    public static void Main(string[] args)
        {
            //string curdir = Console.ReadLine();
            Zhorik zhora = new Zhorik("/Users/kymbatseilkhan/Desktop/<3");
            zhora.Nachalo();
        }
    }
}
