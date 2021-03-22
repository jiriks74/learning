using System.IO;
using System;
using System.Data.SQLite;

namespace databaseLearn
{
    class Program
    {
        public static SQLiteConnectionStringBuilder conString = new SQLiteConnectionStringBuilder();
        public static SQLiteConnection con;
        public static System.Data.DataTable table = new System.Data.DataTable();
        static void Main(string[] args)
        {
            conString.DataSource = "./database.db";
            string comstring = "SELECT * FROM drinks;";

            using (con = new SQLiteConnection(conString.ConnectionString))
            using (SQLiteCommand command = new SQLiteCommand(comstring, con))
            using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command))
            {
                dataAdapter.Fill(table);
            }

            
            foreach (System.Data.DataRow row in table.Rows)
            {
                string name = row["name"].ToString();
                Console.WriteLine(name);
            }
            System.Threading.Thread.Sleep(10000);
        }
    }
}