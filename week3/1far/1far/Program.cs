using System;
using System.IO;
using System.Text;
namespace far
{
    class Zhorik        //create class
    {
        public int curs = 0;        //var-s of class
        public int L, R;
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
        public void AtynAuystyru()         //method to rename file or directory
        {
            Console.Clear();
            Console.WriteLine("Please, write new name ");
            string name = Console.ReadLine();
            if(currentFs is FileInfo)
            {
                string begin = path + '/' + currentFs.Name;
                string ext= Path.GetExtension(currentFs.Name); 
                string end = path + '/' + name + ext;
                File.Move(@begin, @end); 
            }
            else
            {
                DirectoryInfo d = new DirectoryInfo(currentFs.FullName);
                string begin = d.FullName;
                string end = d.Parent.FullName + '/' + name;
                Directory.Move(@begin, @end);
            }
        }
        public void Oshiru()        //method to delete file or directory
        {

            if (currentFs is DirectoryInfo) 
            {
                currentFs.Delete();
            }
            else File.Delete(currentFs.FullName);
        }
        public void SizeCnt()       // method to count size 
        {
            directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            size = fs.Length;
            if (isHidden == false)
                for (int i = 0; i < fs.Length; i++)
                    if (fs[i].Name[0] == '.')
                        size--;

        }
        public void Color(FileSystemInfo fs, int ind)       //method to paint console, files, dir etc
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
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
        public void Show()      // method to show
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;    
            Console.Clear();
            directory = new DirectoryInfo(path);                //read the directory 
            FileSystemInfo[] fs = directory.GetFileSystemInfos(); // array of files and directories from our parent directory
            for (int i = 0, t = 0; i < fs.Length; i++)      // iterate through files and dir-s
            {
                if (isHidden == false && fs[i].Name[0] == '.')      // t - numeraciya kajdogo file or dir
                {
                    continue;                                   // if it is hidden file , continue
                }
                if (t >= L && t <= R)       // L R ogranicheniya vyvoda papok na konsoli 
                {
                    Color(fs[i], t);
                    Console.WriteLine(t + 1 + ". " + fs[i].Name);
                }
                t++;
            }
        }

        public void Ustige()        //method to go up 
        {
            curs--;
            if (curs < 0)
            {
                curs = size - 1;
                R = curs;
                L = Math.Max(0, R - 9);
            }
            else if(curs + 1 == L)
            {
                L--;
                if (R - L + 1 >10) R--;
           
            }
        }
        public void Astyga()    //method to go down
        {
            curs++;
            if (curs == size)
            {
                curs = 0;
                L = 0;
                R = Math.Min(size - 1, 9);
            }
            else if(curs-1==R)
            {
                R++;
                if(R-L+1>10)
                L++;
            }
        }
        public void OpenFile()      //method to open file txt
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            string txt = File.ReadAllText(currentFs.FullName);
            Console.WriteLine(txt);
            Console.ReadKey();
        }
     
        public void Nachalo()       // osnovnaya func. 
        { 
            L = 0; R = Math.Min(9, size);       //zadaem ogranicheniya L R dlya konsoli
            SizeCnt();
            Show();
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            while (consoleKey.Key != ConsoleKey.Escape)
            {

                SizeCnt();
                Show();
                consoleKey = Console.ReadKey();     //proveryaem kakuyu button nazhali i dalwe zapuskaem nuzhnuyu func.
                if(consoleKey.Key == ConsoleKey.UpArrow)
                {
                    Ustige();
                }
                if (consoleKey.Key == ConsoleKey.DownArrow)
                {
                    Astyga();
                }
                if (consoleKey.Key == ConsoleKey.RightArrow)   //proverka dlya hidden files     
                {
                    isHidden= false;
                    curs = 0;
                }
                if (consoleKey.Key == ConsoleKey.LeftArrow)
                {
                    curs = 0;
                    isHidden = true;
                }
                if(consoleKey.Key == ConsoleKey.Enter)  //otkrytie file or dir 
                {
                    if(currentFs is DirectoryInfo)
                    {
                        curs = 0;
                        path = currentFs.FullName;
                        directory = new DirectoryInfo(path);
                        FileSystemInfo[] fs = directory.GetFileSystemInfos();
                        L = 0;
                        R = fs.Length - 1;
                    }
                    if (currentFs is FileInfo)
                    {
                        OpenFile();
                    }
                }

                if(consoleKey.Key == ConsoleKey.D)
                {
                    Oshiru();               //udalenie
                }
                if(consoleKey.Key == ConsoleKey.R)
                {
                    AtynAuystyru();     //rename file or dir
                }

                if (consoleKey.Key == ConsoleKey.Backspace)     //nazad 
                {
                    curs = 0;                    
                    path = directory.Parent.FullName;       //menyaem path, dir i syst.info na tot chto byl ran'we
                    directory = new DirectoryInfo(path);
                    FileSystemInfo[] fs = directory.GetFileSystemInfos();
                    L = 0;                  //zadaem novye ogranicheniya
                    R = fs.Length - 1;
                }

            }
        }

    }
    class MainClass { 

    public static void Main(string[] args)
        {
            //string curdir = Console.ReadLine();
            Zhorik zhora = new Zhorik("/Users/kymbatseilkhan/Desktop/ENG"); // init the class 
         
            zhora.Nachalo();        // call the main function
        }
    }
}
