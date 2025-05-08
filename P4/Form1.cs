using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HotelDafam
{
    public partial class Form1 : Form
    {
        int selectedId = 0;

        public Form1()
        {
            InitializeComponent();

            // Atur background image saat inisialisasi form
            try
            {
                this.BackgroundImage = Image.FromFile("background.jpg"); // pastikan path-nya benar
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat gambar background: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void TampilkanData()
        {
            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM tamu", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtJumlahTamu.Text, out int jumlahTamu))
            {
                MessageBox.Show("Jumlah tamu harus berupa angka.");
                return;
            }

            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                string query = "INSERT INTO tamu (nama, alamat, no_hp, tgl_checkin, tgl_checkout, jumlah_tamu, no_kamar) " +
                               "VALUES (@nama, @alamat, @no_hp, @tgl_in, @tgl_out, @jumlah, @kamar)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                cmd.Parameters.AddWithValue("@no_hp", txtNoHP.Text);
                cmd.Parameters.AddWithValue("@tgl_in", dtpCheckIn.Value.Date);
                cmd.Parameters.AddWithValue("@tgl_out", dtpCheckOut.Value.Date);
                cmd.Parameters.AddWithValue("@jumlah", jumlahTamu);
                cmd.Parameters.AddWithValue("@kamar", txtNoKamar.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data berhasil disimpan!");
                TampilkanData();
                ResetForm();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu.");
                return;
            }

            if (!int.TryParse(txtJumlahTamu.Text, out int jumlahTamu))
            {
                MessageBox.Show("Jumlah tamu harus berupa angka.");
                return;
            }

            using (MySqlConnection conn = Koneksi.GetConnection())
            {
                string query = "UPDATE tamu SET nama=@nama, alamat=@alamat, no_hp=@no_hp, tgl_checkin=@tgl_in, " +
                               "tgl_checkout=@tgl_out, jumlah_tamu=@jumlah, no_kamar=@kamar WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", selectedId);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                cmd.Parameters.AddWithValue("@no_hp", txtNoHP.Text);
                cmd.Parameters.AddWithValue("@tgl_in", dtpCheckIn.Value.Date);
                cmd.Parameters.AddWithValue("@tgl_out", dtpCheckOut.Value.Date);
                cmd.Parameters.AddWithValue("@jumlah", jumlahTamu);
                cmd.Parameters.AddWithValue("@kamar", txtNoKamar.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data berhasil diupdate!");
                TampilkanData();
                ResetForm();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu.");
                return;
            }

            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    string query = "DELETE FROM tamu WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", selectedId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Data berhasil dihapus!");
                    TampilkanData();
                    ResetForm();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                try
                {
                    selectedId = Convert.ToInt32(row.Cells["id"].Value);
                    txtNama.Text = row.Cells["nama"].Value.ToString();
                    txtAlamat.Text = row.Cells["alamat"].Value.ToString();
                    txtNoHP.Text = row.Cells["no_hp"].Value.ToString();
                    dtpCheckIn.Value = Convert.ToDateTime(row.Cells["tgl_checkin"].Value);
                    dtpCheckOut.Value = Convert.ToDateTime(row.Cells["tgl_checkout"].Value);
                    txtJumlahTamu.Text = row.Cells["jumlah_tamu"].Value.ToString();
                    txtNoKamar.Text = row.Cells["no_kamar"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal membaca data: " + ex.Message);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtNama.Clear();
            txtAlamat.Clear();
            txtNoHP.Clear();
            txtJumlahTamu.Clear();
            txtNoKamar.Clear();
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now;
            selectedId = 0;
        }
    }
}
