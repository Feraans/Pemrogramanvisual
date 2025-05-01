using System;
using System.Data.SQLite;

namespace HotelApp
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Data Source=hotel.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static void ExecuteCommand(string query, Action<SQLiteCommand> setParameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(query, conn))
            {
                setParameters(cmd);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
