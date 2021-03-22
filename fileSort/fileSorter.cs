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
            path = getPath();
            files = loadFiles(path);

            foreach (string filename in files)
            {

                FileInfo finf = new FileInfo(filename);
                string extension = $"ex = '{finf.Extension}'";
                string folder = "";

                DataRow[] foundRow = Program.settings.Tables[0].Select(extension);

                foreach (DataRow dr in foundRow)
                {
                    folder = dr["folder"].ToString();
                }

                if (!Directory.Exists(Path.Combine(path, folder)))
                {
                    Directory.CreateDirectory(Path.Combine(path, folder));
                }

                File.Move(finf.FullName, Path.Combine(Path.Combine(path, folder), finf.Name));
            }

            Console.WriteLine("Succesfully sorted!");
            System.Threading.Thread.Sleep(2000);

            return;
        }

        private static string[] loadFiles(string path)
        {
            string[] files;
            if (Directory.Exists(path))
            {
                files = Directory.GetFiles(path);
                return files;
            }
            else
            {
                Console.WriteLine("Directory doesn't exists");
                return new string[] { };
            }
        }

        private static string getPath()
        {
            string path;
            Console.Clear();

            Console.Write("Type path of the folder you want to organize: ");
            path = Console.ReadLine();
            Console.Clear();

            if (Directory.Exists(path))
            {
                return path;
            }
            else
            {
                Console.WriteLine("Invalid path! Try again.");
                getPath();
            }
            return null;
        }
    }
}
