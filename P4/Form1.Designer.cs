using System.Windows.Forms;

namespace HotelDafam
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtNama, txtAlamat, txtNoHP, txtJumlahTamu, txtNoKamar;
        private DateTimePicker dtpCheckIn, dtpCheckOut;
        private Button btnSimpan, btnUpdate, btnHapus, btnReset;
        private DataGridView dataGridView1;

        private void InitializeComponent()
        {
            // Inisialisasi kontrol input
            txtNama = new TextBox();
            txtAlamat = new TextBox();
            txtNoHP = new TextBox();
            txtJumlahTamu = new TextBox();
            txtNoKamar = new TextBox();
            dtpCheckIn = new DateTimePicker();
            dtpCheckOut = new DateTimePicker();
            btnSimpan = new Button();
            btnUpdate = new Button();
            btnHapus = new Button();
            btnReset = new Button();
            dataGridView1 = new DataGridView();

            // Label Judul
            Label lblJudul = new Label()
            {
                Text = "HOTEL DAFAM",
                Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                ForeColor = System.Drawing.Color.DarkBlue,
                Location = new System.Drawing.Point(230, 10)
            };

            // Label dan posisi kontrol lainnya
            Label lblNama = new Label() { Text = "Nama Tamu", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            txtNama.Location = new System.Drawing.Point(20, 80);
            txtNama.Size = new System.Drawing.Size(250, 22);

            Label lblAlamat = new Label() { Text = "Alamat", Location = new System.Drawing.Point(20, 110), AutoSize = true };
            txtAlamat.Location = new System.Drawing.Point(20, 130);
            txtAlamat.Size = new System.Drawing.Size(250, 45);
            txtAlamat.Multiline = true;

            Label lblNoHP = new Label() { Text = "No. HP", Location = new System.Drawing.Point(20, 180), AutoSize = true };
            txtNoHP.Location = new System.Drawing.Point(20, 200);
            txtNoHP.Size = new System.Drawing.Size(250, 22);

            Label lblCheckIn = new Label() { Text = "Tanggal Check-in", Location = new System.Drawing.Point(300, 60), AutoSize = true };
            dtpCheckIn.Location = new System.Drawing.Point(300, 80);
            dtpCheckIn.Size = new System.Drawing.Size(250, 22);

            Label lblCheckOut = new Label() { Text = "Tanggal Check-out", Location = new System.Drawing.Point(300, 110), AutoSize = true };
            dtpCheckOut.Location = new System.Drawing.Point(300, 130);
            dtpCheckOut.Size = new System.Drawing.Size(250, 22);

            Label lblJumlah = new Label() { Text = "Jumlah Tamu", Location = new System.Drawing.Point(300, 160), AutoSize = true };
            txtJumlahTamu.Location = new System.Drawing.Point(300, 180);
            txtJumlahTamu.Size = new System.Drawing.Size(250, 22);

            Label lblKamar = new Label() { Text = "Nomor Kamar", Location = new System.Drawing.Point(300, 210), AutoSize = true };
            txtNoKamar.Location = new System.Drawing.Point(300, 230);
            txtNoKamar.Size = new System.Drawing.Size(250, 22);

            // Tombol
            btnSimpan.Text = "Simpan";
            btnSimpan.Location = new System.Drawing.Point(20, 270);
            btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);

            btnUpdate.Text = "Update";
            btnUpdate.Location = new System.Drawing.Point(120, 270);
            btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            btnHapus.Text = "Hapus";
            btnHapus.Location = new System.Drawing.Point(220, 270);
            btnHapus.Click += new System.EventHandler(this.btnHapus_Click);

            btnReset.Text = "Reset";
            btnReset.Location = new System.Drawing.Point(320, 270);
            btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // DataGridView
            dataGridView1.Location = new System.Drawing.Point(20, 310);
            dataGridView1.Size = new System.Drawing.Size(600, 200);
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            // Tambahkan semua kontrol ke form
            this.ClientSize = new System.Drawing.Size(650, 540);
            this.Controls.AddRange(new Control[] {
                lblJudul,
                lblNama, txtNama,
                lblAlamat, txtAlamat,
                lblNoHP, txtNoHP,
                lblCheckIn, dtpCheckIn,
                lblCheckOut, dtpCheckOut,
                lblJumlah, txtJumlahTamu,
                lblKamar, txtNoKamar,
                btnSimpan, btnUpdate, btnHapus, btnReset,
                dataGridView1 });

            this.Text = "Pendataan Tamu Hotel Dafam";
            this.Load += new System.EventHandler(this.Form1_Load);
        }
    }
}