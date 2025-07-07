namespace HotelDafam.Views
{
    partial class MainView
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtNama, txtAlamat, txtNoHP, txtJumlahTamu, txtNoKamar;
        private DateTimePicker dtpCheckIn, dtpCheckOut;
        private Button btnSimpan, btnUpdate, btnHapus, btnReset, btnLaporan;
        private DataGridView dataGridView1;
        private Panel panelMain;
        private Label lblJudul;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtNama = new TextBox();
            this.txtAlamat = new TextBox();
            this.txtNoHP = new TextBox();
            this.txtJumlahTamu = new TextBox();
            this.txtNoKamar = new TextBox();
            this.dtpCheckIn = new DateTimePicker();
            this.dtpCheckOut = new DateTimePicker();
            this.btnSimpan = new Button();
            this.btnUpdate = new Button();
            this.btnHapus = new Button();
            this.btnReset = new Button();
            this.btnLaporan = new Button();
            this.dataGridView1 = new DataGridView();
            this.panelMain = new Panel();
            this.lblJudul = new Label();
            
            // Label Judul
            this.lblJudul.Text = "HOTEL DAFAM";
            this.lblJudul.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblJudul.AutoSize = true;
            this.lblJudul.ForeColor = Color.DarkBlue;
            this.lblJudul.Location = new Point(30, 30);
            
            // Panel utama
            this.panelMain.Size = new Size(600, 300);
            this.panelMain.Location = new Point((700 - panelMain.Width) / 2, 60);
            this.panelMain.Anchor = AnchorStyles.Top;
            
            // Kontrol Input
            Label lblNama = new Label() { Text = "Nama Tamu", Location = new Point(20, 10), AutoSize = true };
            txtNama.Location = new Point(20, 30); txtNama.Size = new Size(250, 22);
            
            Label lblAlamat = new Label() { Text = "Alamat", Location = new Point(20, 60), AutoSize = true };
            txtAlamat.Location = new Point(20, 80); txtAlamat.Size = new Size(250, 45); txtAlamat.Multiline = true;
            
            Label lblNoHP = new Label() { Text = "No. HP", Location = new Point(20, 130), AutoSize = true };
            txtNoHP.Location = new Point(20, 150); txtNoHP.Size = new Size(250, 22);
            
            Label lblCheckIn = new Label() { Text = "Tanggal Check-in", Location = new Point(300, 10), AutoSize = true };
            dtpCheckIn.Location = new Point(300, 30); dtpCheckIn.Size = new Size(250, 22);
            
            Label lblCheckOut = new Label() { Text = "Tanggal Check-out", Location = new Point(300, 60), AutoSize = true };
            dtpCheckOut.Location = new Point(300, 80); dtpCheckOut.Size = new Size(250, 22);
            
            Label lblJumlah = new Label() { Text = "Jumlah Tamu", Location = new Point(300, 110), AutoSize = true };
            txtJumlahTamu.Location = new Point(300, 130); txtJumlahTamu.Size = new Size(250, 22);
            
            Label lblKamar = new Label() { Text = "Nomor Kamar", Location = new Point(300, 160), AutoSize = true };
            txtNoKamar.Location = new Point(300, 180); txtNoKamar.Size = new Size(250, 22);
            
            // Tombol
            btnSimpan.Text = "Simpan"; btnSimpan.Location = new Point(20, 220);
            btnUpdate.Text = "Update"; btnUpdate.Location = new Point(120, 220);
            btnHapus.Text = "Hapus"; btnHapus.Location = new Point(220, 220);
            btnReset.Text = "Reset"; btnReset.Location = new Point(320, 220);
            btnLaporan.Text = "Laporan"; btnLaporan.Location = new Point(420, 220);
            
            // DataGridView
            dataGridView1.Location = new Point(20, 380);
            dataGridView1.Size = new Size(640, 150);
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            // Tambahkan kontrol ke panel
            panelMain.Controls.AddRange(new Control[] {
                lblNama, txtNama,
                lblAlamat, txtAlamat,
                lblNoHP, txtNoHP,
                lblCheckIn, dtpCheckIn,
                lblCheckOut, dtpCheckOut,
                lblJumlah, txtJumlahTamu,
                lblKamar, txtNoKamar,
                btnSimpan, btnUpdate, btnHapus, btnReset, btnLaporan
            });
            
            // Form settings
            this.ClientSize = new Size(700, 600);
            this.Text = "Pendataan Tamu Hotel Dafam";
            this.Controls.Add(lblJudul);
            this.Controls.Add(panelMain);
            this.Controls.Add(dataGridView1);
            
            // Event handlers
            this.Load += new EventHandler(MainView_Load);
            btnSimpan.Click += new EventHandler(btnSimpan_Click);
            btnUpdate.Click += new EventHandler(btnUpdate_Click);
            btnHapus.Click += new EventHandler(btnHapus_Click);
            btnReset.Click += new EventHandler(btnReset_Click);
            btnLaporan.Click += new EventHandler(btnLaporan_Click);
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }
    }
}