using System;
using System.IO;
using System.Data;

namespace fileSort
{
    public class xmlEdit
    {
        private static void saveSettings()
        {
            Program.settings.WriteXml(Program.settingsFile); // Save the settings to settings file
        }

        public static void loadSettings()
        {
            if (File.Exists(Program.settingsFile)) // If settings file exists
            {
                Program.settings.ReadXml(Program.settingsFile); // Load the settings file
                Console.WriteLine("Settings loaded successfully");
            }
            else
            {
                Console.WriteLine("Setings file not found, creating blank one");
                Program.settings.Tables.Add(); // Add table to the dataset
                Program.settings.Tables[0].Columns.Add("ex", typeof(String)); // Add column for file extensions to table
                Program.settings.Tables[0].Columns.Add("folder", typeof(String)); // Add column for folder names to table
                Program.settings.WriteXml(Program.settingsFile); // Save the new blank settings into the settings file
            }
        }
        public static void addFilex()
        {
            string ex; // For storing file extension
            string folder; // For storing folder name
            Console.Clear();

            Console.WriteLine("Adding file extension to sorting database. Use 'q' for quit"); 
            Console.Write("File extension: ");
            ex = Console.ReadLine(); // Get file extension from user input in console
            if (ex == "" || ex == null) // If there's nothing, call addFilex() again, so user can input proper extension
            {
                Console.Clear();
                Console.WriteLine("Invalid string. Try again.");
                addFilex();
            }
            else if(ex == "q") return; // If input is q, return to quit the function
            else if (!ex.StartsWith(".")) ex = "." + ex; // If use didn't put . in the begining of the file extension, add it

            Console.Clear();
            Console.Write($"Adding folder name for \'{ex}\' extension: ");
            folder = Console.ReadLine();

            if(folder == "q") return;

            DataRow row = Program.settings.Tables[0].NewRow(); // Create new row
            row[0] = ex; // Add the file extension to the first column
            row[1] = folder; // Add folder name to second column
            Program.settings.Tables[0].Rows.Add(row); // Add the new row to table

            Console.Clear();
            Console.WriteLine("Succefully added to database");
            System.Threading.Thread.Sleep(2000);

            saveSettings(); // Save the new settings

            return;
        }
    }
}
