using System;
using System.IO;
using System.Linq;
using System.Data;

namespace fileSort
{
    public class dal
    {
        public static DataSet settings = new DataSet();
        public static string settingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.xml");
        public static string tableName = "filex";
        private static void saveSettings()
        {
            settings.WriteXml(settingsFile); // Save the settings to settings file
        }

        public static void loadSettings()
        {
            if (File.Exists(settingsFile)) // If settings file exists
            {
                settings.ReadXml(settingsFile); // Load the settings file
                Console.WriteLine("Settings loaded successfully");
            }
            else
            {
                Console.WriteLine("Setings file not found, creating blank one");
                settings.Tables.Add(tableName); // Add table to the dataset
                settings.Tables[tableName].Columns.Add("ex", typeof(String)); // Add column for file extensions to table
                settings.Tables[tableName].Columns.Add("folder", typeof(String)); // Add column for folder names to table
                settings.WriteXml(settingsFile); // Save the new blank settings into the settings file
            }
        }
        public static void addFilex(string ex, string folder)
        {
            DataRow row = settings.Tables[tableName].NewRow(); // Create new row
            row[0] = ex; // Add the file extension to the first column
            row[1] = folder; // Add folder name to second column
            settings.Tables[tableName].Rows.Add(row); // Add the new row to table

            Console.Clear();
            Console.WriteLine("Succefully added to database");
            System.Threading.Thread.Sleep(2000);

            saveSettings(); // Save the new settings

            return;
        }
        public static string folderName(string ex)
        {

            string extension = $"ex = '{ex}'"; // Load the file extension into a format that can be searched in settings table
            string folder = ""; // Initialize folder variable for storing foldername where the file will be moved

            DataRow[] foundRow = settings.Tables[tableName].Select(extension); // Search for the extension in settings table

            foreach (DataRow dr in foundRow) // Foreach row, where the file extension 'ex' exists (should be always one)
            {
                folder = dr["folder"].ToString(); // Get the foldername and store it in 'folder'
            }
            
            return folder;
        }
    }
}
