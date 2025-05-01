using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace HotelApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void HitungTotal()
        {
            try
            {
                DateTime checkin = dtCheckin.Value;
                DateTime checkout = dtCheckout.Value;
                decimal tarif = numTarif.Value;

                if (checkout > checkin)
                {
                    TimeSpan selisih = checkout - checkin;
                    int malam = selisih.Days;
                    decimal total = malam * tarif;

                    numMalam.Value = malam;
                    numTotal.Value = total;
                }
                else
                {
                    numMalam.Value = 0;
                    numTotal.Value = 0;
                }
            }
            catch
            {
                MessageBox.Show("Data input tidak valid.");
            }
        }

        private void InputChanged(object sender, EventArgs e)
        {
            HitungTotal();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            SimpanData(); // Simpan ke database

            // Tampilkan ringkasan data
            MessageBox.Show("Data berhasil disimpan:\n" +
                $"Nama: {txtNama.Text}\n" +
                $"Alamat: {txtAlamat.Text}\n" +
                $"No HP: {txtNoHP.Text}\n" +
                $"Check-in: {dtCheckin.Value.ToShortDateString()}\n" +
                $"Check-out: {dtCheckout.Value.ToShortDateString()}\n" +
                $"Metode Pembayaran: {cmbPembayaran.SelectedItem}\n" +
                $"Total Bayar: Rp {numTotal.Value}");
        }

        private void SimpanData()
        {
            string connStr = "Data Source=hotel.db;Version=3;";
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();

                string query = "INSERT INTO tamu (nama, alamat, no_hp, checkin, checkout, pembayaran, tarif, malam, total_bayar) " +
                               "VALUES (@nama, @alamat, @no_hp, @checkin, @checkout, @pembayaran, @tarif, @malam, @total)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                    cmd.Parameters.AddWithValue("@no_hp", txtNoHP.Text);
                    cmd.Parameters.AddWithValue("@checkin", dtCheckin.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@checkout", dtCheckout.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@pembayaran", cmbPembayaran.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@tarif", Convert.ToInt32(numTarif.Value));
                    cmd.Parameters.AddWithValue("@malam", Convert.ToInt32(numMalam.Value));
                    cmd.Parameters.AddWithValue("@total", Convert.ToInt32(numTotal.Value));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
