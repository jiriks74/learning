using System.Net.Mime;
using System.IO;
using System.Data;
using System;

namespace fileSort
{
    class Program
    {
        private static DataSet settings = new DataSet();
        private static string settingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.xml");
        static void Main(string[] args)
        {

            Console.Clear();
            Console.WriteLine("//////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////");
            Console.WriteLine("////Welcome to filesorter by jiriks74!////");
            Console.WriteLine("//////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////");
            System.Threading.Thread.Sleep(3000);
            loadSettings();

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
            string path;
            string[] files;
            Console.Clear();

            Console.WriteLine("1 sort files");
            Console.WriteLine("2 add extensions to database");
            Console.WriteLine("3 Show current database of extesnsions");
            Console.WriteLine("4 Change extensions folder");
            Console.Write("Select operation: ");

            int x;
            int.TryParse(Console.ReadLine(), out x);

            switch (x)
            {
                // Sort files
                case 1:
                    path = getPath();
                    files = loadFiles(path);
                    sortFiles(path, files);
                    return false;

                // Add extensions to database
                case 2:
                    addFilex();
                    saveSettings();
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
        private static void loadSettings()
        {
            if (File.Exists(settingsFile))
            {
                settings.ReadXml(settingsFile);
                Console.WriteLine("Settings loaded successfully");
            }
            else
            {
                Console.WriteLine("Setings file not found, creating blank one");
                settings.Tables.Add();
                settings.Tables[0].Columns.Add("ex", typeof(String));
                settings.Tables[0].Columns.Add("folder", typeof(String));
                settings.WriteXml(settingsFile);
            }
        }

        private static void saveSettings()
        {
            settings.WriteXml(settingsFile);
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
        private static void sortFiles(string path, string[] files)
        {
            Console.Clear();
            foreach (string filename in files)
            {

                FileInfo finf = new FileInfo(filename);
                string extension = $"ex = '{finf.Extension}'";
                string folder = "";

                DataRow[] foundRow = settings.Tables[0].Select(extension);

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
        private static void addFilex()
        {
            string ex;
            string folder;
            Console.Clear();

            Console.WriteLine("Adding file extension to sorting database.");
            Console.Write("File extension: ");
            ex = Console.ReadLine();
            if (ex == "" || ex == null)
            {
                Console.Clear();
                Console.WriteLine("Invalid string. Try again.");
                addFilex();
            }
            else if (!ex.StartsWith("."))
            {
                ex = "." + ex;
            }

            Console.Clear();
            Console.Write($"Adding folder name for \'{ex}\' extension: ");
            folder = Console.ReadLine();

            DataRow row = settings.Tables[0].NewRow();
            row[0] = ex;
            row[1] = folder;
            settings.Tables[0].Rows.Add(row);

            Console.Clear();
            Console.WriteLine("Succefully added to database");
            System.Threading.Thread.Sleep(2000);

            return;
        }
    }
}