using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelDafam
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtNama, txtAlamat, txtNoHP, txtJumlahTamu, txtNoKamar;
        private DateTimePicker dtpCheckIn, dtpCheckOut;
        private Button btnSimpan, btnUpdate, btnHapus, btnReset, btnLaporan;
        private DataGridView dataGridView1;
        public Panel panelMain;
        private Label lblJudul;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ---------- INISIALISASI KONTROL ----------
            // TextBox
            this.txtNama       = new TextBox();
            this.txtAlamat     = new TextBox();
            this.txtNoHP       = new TextBox();
            this.txtJumlahTamu = new TextBox();
            this.txtNoKamar    = new TextBox();

            // DateTimePicker
            this.dtpCheckIn  = new DateTimePicker();
            this.dtpCheckOut = new DateTimePicker();

            // Buttons
            this.btnSimpan   = new Button();
            this.btnUpdate   = new Button();
            this.btnHapus    = new Button();
            this.btnReset    = new Button();
            this.btnLaporan  = new Button();   // << tombol laporan baru

            // DataGridView
            this.dataGridView1 = new DataGridView();

            // Panel
            this.panelMain = new Panel();

            // Label Judul
            this.lblJudul = new Label();
            this.lblJudul.Text = "HOTEL DAFAM";
            this.lblJudul.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblJudul.AutoSize = true;
            this.lblJudul.ForeColor = Color.DarkBlue;
            this.lblJudul.Location = new Point(30, 30);

            // Panel utama
            this.panelMain.Size = new Size(600, 300);
            this.panelMain.Location = new Point((700 - panelMain.Width) / 2, 60);
            this.panelMain.Anchor = AnchorStyles.Top;

            // ---------- LABEL DAN INPUT ----------
            Label lblNama = new Label() { Text = "Nama Tamu",         Location = new Point(20, 10),   AutoSize = true };
            txtNama.Location = new Point(20, 30); txtNama.Size = new Size(250, 22);

            Label lblAlamat = new Label() { Text = "Alamat",            Location = new Point(20, 60),   AutoSize = true };
            txtAlamat.Location = new Point(20, 80); txtAlamat.Size = new Size(250, 45); txtAlamat.Multiline = true;

            Label lblNoHP = new Label() { Text = "No. HP",           Location = new Point(20, 130),  AutoSize = true };
            txtNoHP.Location = new Point(20, 150); txtNoHP.Size = new Size(250, 22);

            Label lblCheckIn = new Label() { Text = "Tanggal Check-in", Location = new Point(300, 10),  AutoSize = true };
            dtpCheckIn.Location = new Point(300, 30); dtpCheckIn.Size = new Size(250, 22);

            Label lblCheckOut = new Label() { Text = "Tanggal Check-out",Location = new Point(300, 60),  AutoSize = true };
            dtpCheckOut.Location = new Point(300, 80); dtpCheckOut.Size = new Size(250, 22);

            Label lblJumlah = new Label() { Text = "Jumlah Tamu",      Location = new Point(300, 110), AutoSize = true };
            txtJumlahTamu.Location = new Point(300, 130); txtJumlahTamu.Size = new Size(250, 22);

            Label lblKamar = new Label() { Text = "Nomor Kamar",      Location = new Point(300, 160), AutoSize = true };
            txtNoKamar.Location = new Point(300, 180); txtNoKamar.Size = new Size(250, 22);

            // ---------- TOMBOL ----------
            btnSimpan.Text = "Simpan";  btnSimpan.Location = new Point(20, 220);
            btnSimpan.Click += new EventHandler(this.btnSimpan_Click);

            btnUpdate.Text = "Update";  btnUpdate.Location = new Point(120, 220);
            btnUpdate.Click += new EventHandler(this.btnUpdate_Click);

            btnHapus.Text  = "Hapus";   btnHapus.Location  = new Point(220, 220);
            btnHapus.Click  += new EventHandler(this.btnHapus_Click);

            btnReset.Text  = "Reset";   btnReset.Location  = new Point(320, 220);
            btnReset.Click  += new EventHandler(this.btnReset_Click);

            btnLaporan.Text = "Laporan"; btnLaporan.Location = new Point(420, 220); // tombol laporan
            btnLaporan.Click += new EventHandler(this.btnLaporan_Click);

            // ---------- DATAGRIDVIEW ----------
            dataGridView1.Location = new Point(20, 380);
            dataGridView1.Size = new Size(640, 150);
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            dataGridView1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // ---------- TAMBAHKAN KONTROL KE PANEL ----------
            panelMain.Controls.AddRange(new Control[] {
                lblNama, txtNama,
                lblAlamat, txtAlamat,
                lblNoHP, txtNoHP,
                lblCheckIn, dtpCheckIn,
                lblCheckOut, dtpCheckOut,
                lblJumlah, txtJumlahTamu,
                lblKamar,  txtNoKamar,
                btnSimpan, btnUpdate, btnHapus, btnReset, btnLaporan  // btnLaporan ditambahkan di sini
            });

            // ---------- PENGATURAN FORM ----------
            this.ClientSize = new Size(700, 600);
            this.Text = "Pendataan Tamu Hotel Dafam";

            this.Controls.Add(lblJudul);
            this.Controls.Add(panelMain);
            this.Controls.Add(dataGridView1);

            this.Load += new EventHandler(this.Form1_Load);
            this.Resize += new EventHandler(this.Form1_Resize);
        }
    }
}
