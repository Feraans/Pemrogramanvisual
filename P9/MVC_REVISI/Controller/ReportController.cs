using System;
using System.Data;
using HotelDafam.Models;
using MySql.Data.MySqlClient;

namespace HotelDafam.Controllers
{
    public class ReportController
    {
        public DataTable GetReportByDateRange(DateTime startDate, DateTime endDate)
        {
            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                string query = "SELECT * FROM tamu WHERE tgl_checkin BETWEEN @tgl1 AND @tgl2";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tgl1", startDate.Date);
                cmd.Parameters.AddWithValue("@tgl2", endDate.Date);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}