using System;
using System.IO;
using System.Linq;

namespace fileSort
{
    public class Program
    {
        public static string path;
        
        public static void Main(string[] args)
        {

            Console.Clear(); 
            Console.WriteLine("//////////////////////////////////////////"); 
            Console.WriteLine("//////////////////////////////////////////"); 
            Console.WriteLine("////Welcome to filesorter by jiriks74!////");
            Console.WriteLine("//////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////");
            System.Threading.Thread.Sleep(3000); // Wait 3 seconds to show welcome screen

            dal.loadSettings(); // Load settings, call function from xmlEdit class

            Console.Clear();

            bool exit = false;
            // Loop so the program won't close on copletion of operation
            // Loop until exit is true
            while (exit == false){
                exit = operation();
            }
            Environment.Exit(0);
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

            string input = Console.ReadLine(); // Get input from console

            // Switch for choosing operations
            switch (input) 
            {
                // Sort files
                case "s":
                    path = getPath(); // Get path that user wants to sort
                    fileSorter.sortFiles(path); // Call function from fileSorter class to sort files
                    return false;

                // Add extensions to database
                case "a":
                    //dal.addFilex(); // Call function from xmlEdit class to add new extensions to database --old
                    string ex = null;
                    while(ex == null){
                        ex = newExt();
                        if(ex == "0") break;
                    }

                    string folder = null;
                    while(folder == null){
                        folder = newFolder();
                        if(folder == "0") break;
                    }

                    dal.addFilex(ex, folder);
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
                    return true; // Compiler thinks I need to return something even though it's unreachable code

                // Default - input
                default:
                    Console.WriteLine($"There is no operation for {input}. Try again.");
                    System.Threading.Thread.Sleep(2000); // Sleep for 2 seconds
                    return false;
            }
        }
        private static string getPath()
        {
            Console.Clear();

            Console.Write("Type path of the folder you want to organize: ");
            path = Console.ReadLine(); // Get path of the folder user want's to sort
            Console.Clear();

            if (Directory.Exists(path))
            {
                return path; // If the directory exists, return it
            }
            else
            {
                Console.WriteLine("Invalid path! Try again.");
                getPath(); // Else call getPath() function again, so user can type the path again
            }
            return null; // Unreachable code, just for compiler
        }
        public static string newExt(){
            string ex;
            Console.WriteLine("Adding file extension to sorting database. Use 'q' for quit");
            Console.Write("File extension: ");
            ex = Console.ReadLine(); // Get file extension from user input in console
            ex = String.Concat(ex.Where(c => !Char.IsWhiteSpace(c))); // Make sure, there is no 'whitespace' in the extension
            if (ex == "" || ex == null) // If there's nothing, call addFilex() again, so user can input proper extension
            {
                Console.Clear();
                Console.WriteLine("Invalid string. Try again.");
                return null;
            }
            else if (ex == "q") return "0"; // If input is q, return to quit the function
            else if (!ex.StartsWith(".")) ex = "." + ex; // If use didn't put . in the begining of the file extension, add it
            return ex;
        }

        public static string newFolder(){
            string folder;
            Console.Clear();
            Console.Write("Folder name for the extension. Type 'q' to cancel. \n Folder name: ");
            folder = Console.ReadLine();

            if (folder == "" || folder == null) // If there's nothing, call addFilex() again, so user can input proper extension
            {
                Console.Clear();
                Console.WriteLine("Invalid string. Try again.");
                return null;
            }

            if (folder == "q") return "0";
            return folder;
        }
    }
}