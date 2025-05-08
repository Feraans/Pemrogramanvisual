using MySql.Data.MySqlClient;

namespace HotelDafam
{
    public class Koneksi
    {
        private static string connStr = "server=localhost;user=root;database=hotel_dafam;password=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connStr);
        }
    }
}