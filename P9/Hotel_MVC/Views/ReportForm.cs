using HotelDafam; 
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HotelDafamApp
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                string query = "SELECT * FROM tamu WHERE tgl_checkin BETWEEN @tgl1 AND @tgl2";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tgl1", dtpMulai.Value.Date);
                cmd.Parameters.AddWithValue("@tgl2", dtpSelesai.Value.Date);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
