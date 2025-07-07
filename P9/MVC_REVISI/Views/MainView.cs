using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HotelDafam.Controllers;
using HotelDafam.Models;
using HotelDafam.Views;

namespace HotelDafam.Views
{
    public partial class MainView : Form
    {
        TamuController tamuController;
        int selectedId = 0;
        User currentUser;

        public MainView(User user)
        {
            InitializeComponent();
            currentUser = user;
            tamuController = new TamuController();
            
            lblJudul.Text = $"HOTEL DAFAM - Selamat datang, {user.FullName}";
            
            if (user.Role == "staff")
            {
                btnLaporan.Visible = false;
            }
            
            try
            {
                this.BackgroundImage = Image.FromFile("background.jpg");
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat gambar background: " + ex.Message);
            }
        }

        public MainView() : this(new User { 
            Id = 1,
            Username = "admin",
            FullName = "Administrator",
            Role = "admin"
        })
        {
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            TampilkanData();
            
            var menuStrip = new MenuStrip();
            var logoutToolStripMenuItem = new ToolStripMenuItem("Logout");
            
            // Fixed event handler assignment with proper nullability
            logoutToolStripMenuItem.Click += (s, args) => LogoutToolStripMenuItem_Click(s, args);
            
            menuStrip.Items.Add(logoutToolStripMenuItem);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        void LogoutToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi", 
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                var loginView = new LoginView();
                loginView.Show();
            }
        }

        void TampilkanData()
        {
            dataGridView1.DataSource = tamuController.GetAllTamu();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtJumlahTamu.Text, out int jumlahTamu))
            {
                MessageBox.Show("Jumlah tamu harus berupa angka.");
                return;
            }

            var tamu = new Tamu
            {
                Nama = txtNama.Text,
                Alamat = txtAlamat.Text,
                NoHp = txtNoHP.Text,
                TglCheckIn = dtpCheckIn.Value,
                TglCheckOut = dtpCheckOut.Value,
                JumlahTamu = jumlahTamu,
                NoKamar = txtNoKamar.Text
            };

            tamuController.AddTamu(tamu);

            var thankYouForm = new ThankYouView();
            thankYouForm.ShowDialog();

            TampilkanData();
            ResetForm();
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

            var tamu = new Tamu
            {
                Id = selectedId,
                Nama = txtNama.Text,
                Alamat = txtAlamat.Text,
                NoHp = txtNoHP.Text,
                TglCheckIn = dtpCheckIn.Value,
                TglCheckOut = dtpCheckOut.Value,
                JumlahTamu = jumlahTamu,
                NoKamar = txtNoKamar.Text
            };

            tamuController.UpdateTamu(tamu);
            MessageBox.Show("Data berhasil diupdate!");
            TampilkanData();
            ResetForm();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu.");
                return;
            }

            if (MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", 
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tamuController.DeleteTamu(selectedId);
                MessageBox.Show("Data berhasil dihapus!");
                TampilkanData();
                ResetForm();
            }
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            var reportView = new ReportView();
            reportView.ShowDialog();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["id"].Value != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["id"].Value);
                txtNama.Text = row.Cells["nama"]?.Value?.ToString() ?? string.Empty;
                txtAlamat.Text = row.Cells["alamat"]?.Value?.ToString() ?? string.Empty;
                txtNoHP.Text = row.Cells["no_hp"]?.Value?.ToString() ?? string.Empty;
                
                if (row.Cells["tgl_checkin"].Value != null)
                    dtpCheckIn.Value = Convert.ToDateTime(row.Cells["tgl_checkin"].Value);
                
                if (row.Cells["tgl_checkout"].Value != null)
                    dtpCheckOut.Value = Convert.ToDateTime(row.Cells["tgl_checkout"].Value);
                    
                txtJumlahTamu.Text = row.Cells["jumlah_tamu"]?.Value?.ToString() ?? string.Empty;
                txtNoKamar.Text = row.Cells["no_kamar"]?.Value?.ToString() ?? string.Empty;
            }
        }

        void ResetForm()
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            
            if (e.CloseReason == CloseReason.UserClosing && currentUser == null)
            {
                Application.Exit();
            }
        }
    }
}