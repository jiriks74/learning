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

            Console.WriteLine("1: Sort files");
            Console.WriteLine("2: Add extensions to database");
            Console.WriteLine("3: Show current database of extesnsions");
            Console.WriteLine("4: Change extensions folder");
            Console.WriteLine("999: Quit")
            Console.Write("Select operation: ");

            int x;
            int.TryParse(Console.ReadLine(), out x);

            switch (x)
            {
                // Sort files
                case 1:
                    fileSorter.sortFiles();
                    return false;

                // Add extensions to database
                case 2:
                    xmlEdit.addFilex();
                    return false;

                // Show current database of extensions
                case 3:
                    Console.WriteLine("todo");
                    System.Threading.Thread.Sleep(2000);
                    return false;

                // Change extensions folder
                case 4:
                    Console.WriteLine("todo");
                    System.Threading.Thread.Sleep(2000);
                    return false;

                // Quit
                case 999:
                    Environment.Exit(0);
                    return true;

                // Default - wrong value
                default:
                    Console.WriteLine($"There is no operation for {x}. Try again.");
                    System.Threading.Thread.Sleep(3000);
                    return false;
            }
        }
    }
}