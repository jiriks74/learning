using System;
using System.IO;
using System.Data;

namespace fileSort
{
    public class xmlEdit
    {
        private static void saveSettings()
        {
            Program.settings.WriteXml(Program.settingsFile);
        }

        public static void loadSettings()
        {
            if (File.Exists(Program.settingsFile))
            {
                Program.settings.ReadXml(Program.settingsFile);
                Console.WriteLine("Settings loaded successfully");
            }
            else
            {
                Console.WriteLine("Setings file not found, creating blank one");
                Program.settings.Tables.Add();
                Program.settings.Tables[0].Columns.Add("ex", typeof(String));
                Program.settings.Tables[0].Columns.Add("folder", typeof(String));
                Program.settings.WriteXml(Program.settingsFile);
            }
        }
        public static void addFilex()
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

            DataRow row = Program.settings.Tables[0].NewRow();
            row[0] = ex;
            row[1] = folder;
            Program.settings.Tables[0].Rows.Add(row);

            Console.Clear();
            Console.WriteLine("Succefully added to database");
            System.Threading.Thread.Sleep(2000);

            saveSettings();

            return;
        }
    }
}
