namespace HotelDafamApp
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dtpMulai;
        private System.Windows.Forms.DateTimePicker dtpSelesai;
        private System.Windows.Forms.Button btnTampilkan;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1, label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dtpMulai = new System.Windows.Forms.DateTimePicker();
            this.dtpSelesai = new System.Windows.Forms.DateTimePicker();
            this.btnTampilkan = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // dtpMulai
            this.dtpMulai.Location = new System.Drawing.Point(130, 20);
            this.dtpMulai.Name = "dtpMulai";
            this.dtpMulai.Size = new System.Drawing.Size(250, 27);

            // dtpSelesai
            this.dtpSelesai.Location = new System.Drawing.Point(130, 60);
            this.dtpSelesai.Name = "dtpSelesai";
            this.dtpSelesai.Size = new System.Drawing.Size(250, 27);

            // label1
            this.label1.Text = "Tanggal Mulai:";
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Size = new System.Drawing.Size(110, 25);

            // label2
            this.label2.Text = "Tanggal Selesai:";
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Size = new System.Drawing.Size(120, 25);

            // btnTampilkan
            this.btnTampilkan.Text = "Tampilkan Laporan";
            this.btnTampilkan.Location = new System.Drawing.Point(130, 100);
            this.btnTampilkan.Size = new System.Drawing.Size(170, 30);
            this.btnTampilkan.Click += new System.EventHandler(this.btnTampilkan_Click);

            // dataGridView1
            this.dataGridView1.Location = new System.Drawing.Point(20, 150);
            this.dataGridView1.Size = new System.Drawing.Size(540, 250);

            // ReportForm
            this.ClientSize = new System.Drawing.Size(580, 420);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpMulai);
            this.Controls.Add(this.dtpSelesai);
            this.Controls.Add(this.btnTampilkan);
            this.Controls.Add(this.dataGridView1);
            this.Text = "Laporan Reservasi Tamu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
