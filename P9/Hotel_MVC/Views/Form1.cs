using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HotelDafam.Repositories;   // repository CRUD
using HotelDafamApp;             // ReportForm & ThankYouForm

namespace HotelDafam
{
    public partial class Form1 : Form
    {
        int selectedId = 0;

        public Form1()
        {
            InitializeComponent();

            // set background sekali saat konstruktor
            try
            {
                this.BackgroundImage = Image.FromFile("background.jpg"); // pastikan path benar
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

        private void Form1_Resize(object sender, EventArgs e)
        {
            // panel utama tetap di tengah
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
        }

        /* ---------- LAPORAN ---------- */
        private void btnLaporan_Click(object sender, EventArgs e)
        {
            ReportForm laporan = new ReportForm();
            laporan.ShowDialog();
        }

        /* ---------- TAMPILKAN DATA ---------- */
        private void TampilkanData()
        {
            dataGridView1.DataSource = TamuRepository.GetAll();
        }

        /* ---------- SIMPAN ---------- */
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtJumlahTamu.Text, out int jumlahTamu))
            {
                MessageBox.Show("Jumlah tamu harus berupa angka.");
                return;
            }

            TamuRepository.Insert(
                txtNama.Text,
                txtAlamat.Text,
                txtNoHP.Text,
                dtpCheckIn.Value,
                dtpCheckOut.Value,
                jumlahTamu,
                txtNoKamar.Text
            );

            // tampilkan form ucapan
            ThankYouForm thankYouForm = new ThankYouForm();
            thankYouForm.ShowDialog();

            TampilkanData();
            ResetForm();
        }

        /* ---------- UPDATE ---------- */
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

            TamuRepository.Update(
                selectedId,
                txtNama.Text,
                txtAlamat.Text,
                txtNoHP.Text,
                dtpCheckIn.Value,
                dtpCheckOut.Value,
                jumlahTamu,
                txtNoKamar.Text
            );

            MessageBox.Show("Data berhasil di-update!");
            TampilkanData();
            ResetForm();
        }

        /* ---------- HAPUS ---------- */
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu.");
                return;
            }
            DialogResult result = MessageBox.Show(
                "Apakah Anda yakin ingin menghapus data ini?",
                "Konfirmasi", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                TamuRepository.Delete(selectedId);
                MessageBox.Show("Data berhasil dihapus!");
                TampilkanData();
                ResetForm();
            }
        }

        /* ---------- DATAGRID KLIK ---------- */
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                try
                {
                    selectedId         = row.Cells["id"].Value   != null ? Convert.ToInt32(row.Cells["id"].Value) : 0;
                    txtNama.Text       = row.Cells["nama"].Value?.ToString() ?? "";
                    txtAlamat.Text     = row.Cells["alamat"].Value?.ToString() ?? "";
                    txtNoHP.Text       = row.Cells["no_hp"].Value?.ToString() ?? "";
                    txtJumlahTamu.Text = row.Cells["jumlah_tamu"].Value?.ToString() ?? "";
                    txtNoKamar.Text    = row.Cells["no_kamar"].Value?.ToString() ?? "";

                    if (row.Cells["tgl_checkin"].Value  != null)
                        dtpCheckIn.Value  = Convert.ToDateTime(row.Cells["tgl_checkin"].Value);
                    if (row.Cells["tgl_checkout"].Value != null)
                        dtpCheckOut.Value = Convert.ToDateTime(row.Cells["tgl_checkout"].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal membaca data: " + ex.Message);
                }
            }
        }

        /* ---------- RESET ---------- */
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
            dtpCheckIn.Value  = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now;
            selectedId = 0;
        }
    }
}
