using System.IO;
using System.Data;
using System;

namespace fileSort
{
    public static class Program
    {
        public static DataSet settings = new DataSet();
        public static string settingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.xml");
        public static void Main(string[] args)
        {

            Console.Clear();
            Console.WriteLine("//////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////");
            Console.WriteLine("////Welcome to filesorter by jiriks74!////");
            Console.WriteLine("//////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////");
            System.Threading.Thread.Sleep(3000);
            xmlEdit.loadSettings();

            Console.Clear();

            bool exit = false;
            while (exit == false){
                exit = operation();
            }

            /*Console.Clear();
            loadSettings();
            addFilex();
            saveSettings();
            path = getPath();
            files = loadFiles(path);
            sortFiles(path, files);*/
        }

        private static bool operation()
        {
            Console.Clear();

            Console.WriteLine("'s': Sort files");
            Console.WriteLine("'a': Add extensions to database");
            Console.WriteLine("'d': Show current database of extesnsions");
            Console.WriteLine("'c': Change extensions folder");
            Console.WriteLine("'q': Quit");
            Console.Write("Select operation: ");

            string input = Console.ReadLine();

            switch (input)
            {
                // Sort files
                case "s":
                    fileSorter.sortFiles();
                    return false;

                // Add extensions to database
                case "a":
                    xmlEdit.addFilex();
                    return false;

                // Show current database of extensions
                case "d":
                    Console.WriteLine("todo");
                    System.Threading.Thread.Sleep(2000);
                    return false;

                // Change extensions folder
                case "c":
                    Console.WriteLine("todo");
                    System.Threading.Thread.Sleep(2000);
                    return false;

                // Quit
                case "q":
                    Environment.Exit(0);
                    return true;

                // Default - input
                default:
                    Console.WriteLine($"There is no operation for {input}. Try again.");
                    System.Threading.Thread.Sleep(3000);
                    return false;
            }
        }
    }
}