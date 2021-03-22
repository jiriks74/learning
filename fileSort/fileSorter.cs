using System;
using System.IO;
using System.Data;

namespace fileSort
{
    public static class fileSorter
    {
        private static string path;
        private static string[] files;
        public static void sortFiles()
        {
            Console.Clear();
            path = getPath(); // Get path of the folder user wants to sort
            files = loadFiles(path); // Load all the files in the folder stored in 'path'

            foreach (string filename in files) // For each file in the folder
            {

                FileInfo finf = new FileInfo(filename); // Get info about the file
                string extension = $"ex = '{finf.Extension}'"; // Load the file extension into a format that can be searched in settings table
                string folder = ""; // Initialize folder variable for storing foldername where the file will be moved

                DataRow[] foundRow = Program.settings.Tables[0].Select(extension); // Search for the extension in settings table

                foreach (DataRow dr in foundRow) // Foreach row, where the file extension 'ex' exists (should be always one)
                {
                    folder = dr["folder"].ToString(); // Get the foldername and store it in 'folder'
                }

                if (!Directory.Exists(Path.Combine(path, folder))) // If directory with name of 'folder' doesn't exist in the sorted directory
                {
                    Directory.CreateDirectory(Path.Combine(path, folder)); // Create directory of the name folder in the sorted directory
                }

                File.Move(finf.FullName, Path.Combine(Path.Combine(path, folder), finf.Name)); // Move the file to 'folder'
            }

            Console.WriteLine("Succesfully sorted!");
            System.Threading.Thread.Sleep(2000);

            return;
        }

        private static string[] loadFiles(string path)
        {
            string[] files;
            if (Directory.Exists(path)) // If directory user want's to sort exists
            {
                files = Directory.GetFiles(path); // Load all files in directory to 'files'
                return files;
            }
            else // Else the directory doesn't exist
            {
                Console.WriteLine("Directory doesn't exists");
                return new string[] { }; // Return empty string[]
            }
        }

        private static string getPath()
        {
            string path;
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
    }
}
