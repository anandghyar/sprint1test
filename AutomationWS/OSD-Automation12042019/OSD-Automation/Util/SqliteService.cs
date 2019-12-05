using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
namespace OSD_Automation.Util
{
    class SqliteService
    {

        public SqliteService()
        {

        }
        public string Sqlites(int rowNum)
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            string columnVal = ReadData(sqlite_conn, rowNum);
            CloseConnection(sqlite_conn);
            return columnVal;
        }

        public SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            var packageName = ConfigurationManager.AppSettings["packageUrl"];
            var localDbFilename = ConfigurationManager.AppSettings["localDbFilename"];
            string connection_string = "Data Source=" + packageName+ "\\"+localDbFilename;
           sqlite_conn = new SQLiteConnection(connection_string);

            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }

        public string ReadData(SQLiteConnection conn, int rowNum)
        {
            string myreader = "";

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            Dictionary<string, string> dict = DataPool.PopulateInCollection("SqliteQuery.csv", rowNum);
            sqlite_cmd.CommandText = dict["SqlQuery"];
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            return myreader;
        }

        static void CloseConnection(SQLiteConnection conn)
        {
            conn.Close();
        }
    }
}
