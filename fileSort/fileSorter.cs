using System;
using System.IO;

namespace fileSort
{
    public class fileSorter
    {
        private static string path;
        private static string[] files;
        public static void sortFiles(string path)
        {
            Console.Clear();// Get path of the folder user wants to sort
            files = loadFiles(path); // Load all the files in the folder stored in 'path'

            foreach (string filename in files) // For each file in the folder
            {

                FileInfo finf = new FileInfo(filename); // Get info about the file
                string folder = dal.folderName(finf.Extension); // Get the asigned forlder name from dal

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
    }
}
