using System.IO;
using System.Data;
using System;

namespace fileSort
{
    public class Program
    {
        
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
                    fileSorter.sortFiles(); // Call function from fileSorter class to sort files
                    return false;

                // Add extensions to database
                case "a":
                    dal.addFilex(); // Call function from xmlEdit class to add new extensions to database
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
    }
}