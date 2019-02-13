using System;
using System.IO;
namespace task4
{
    class MainClass
    {
  
   
        public static void CreateFile()     //method to create new file
        {
            string path1 = "/Users/kymbatseilkhan/Desktop/primerchik";  //first path to folder where we will create the file
            string fileName = "MyNewFile.txt";          // name of the file
            path1 = System.IO.Path.Combine(path1, fileName);   // create a file on the first folder     
            System.IO.File.WriteAllText(path1, "Zhora top");    //write something in a file
            string path2 = "/Users/kymbatseilkhan/Desktop/ponchik";     // second path 
            string newwFile = System.IO.Path.Combine(path2, fileName);  //create second file to the second folder
            System.IO.File.Copy(path1, newwFile, true);     //copy first file to the second file
            DeleFile(path1);        //call the method to delete first file
        }
        public static void DeleFile(string path)
        {
            if (File.Exists(path)){     //if file exists then delete it 
                File.Delete(path);
            }
        }
        public static void Main(string[] args)
        { 
        CreateFile();       //call the method
           


        }
    }
}
