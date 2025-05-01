using System.Windows.Forms;
using System.Drawing;

namespace HotelApp
{
    partial class MainForm
    {
        private TextBox txtNama, txtAlamat, txtNoHP;
        private DateTimePicker dtCheckin, dtCheckout;
        private ComboBox cmbPembayaran;
        private NumericUpDown numTarif, numMalam, numTotal;
        private Button btnSimpan;

        private void InitializeComponent()
        {
            this.Text = "Form Pendataan Tamu Hotel Dafam";
            this.Size = new Size(500, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblNama = new Label() { Text = "Nama", Top = 20, Left = 20 };
            txtNama = new TextBox() { Top = 40, Left = 20, Width = 400 };

            Label lblAlamat = new Label() { Text = "Alamat", Top = 80, Left = 20 };
            txtAlamat = new TextBox() { Top = 100, Left = 20, Width = 400 };

            Label lblNoHP = new Label() { Text = "No HP", Top = 140, Left = 20 };
            txtNoHP = new TextBox() { Top = 160, Left = 20, Width = 400 };

            Label lblCheckin = new Label() { Text = "Tanggal Check-in", Top = 200, Left = 20 };
            dtCheckin = new DateTimePicker() { Top = 220, Left = 20, Width = 200 };
            dtCheckin.ValueChanged += InputChanged;

            Label lblCheckout = new Label() { Text = "Tanggal Check-out", Top = 260, Left = 20 };
            dtCheckout = new DateTimePicker() { Top = 280, Left = 20, Width = 200 };
            dtCheckout.ValueChanged += InputChanged;

            Label lblPembayaran = new Label() { Text = "Metode Pembayaran", Top = 320, Left = 20 };
            cmbPembayaran = new ComboBox() { Top = 340, Left = 20, Width = 200 };
            cmbPembayaran.Items.AddRange(new string[] { "Online", "Offline" });
            cmbPembayaran.DropDownStyle = ComboBoxStyle.DropDownList;

            Label lblTarif = new Label() { Text = "Tarif per Malam (Rp)", Top = 380, Left = 20 };
            numTarif = new NumericUpDown() { Top = 400, Left = 20, Width = 200, Maximum = 10000000, Value = 500000 };
            numTarif.ValueChanged += InputChanged;

            Label lblMalam = new Label() { Text = "Jumlah Malam", Top = 440, Left = 20 };
            numMalam = new NumericUpDown() { Top = 460, Left = 20, Width = 200, ReadOnly = true };

            Label lblTotal = new Label() { Text = "Total Bayar (Rp)", Top = 500, Left = 20 };
            numTotal = new NumericUpDown() { Top = 520, Left = 20, Width = 200, Maximum = 100000000, ReadOnly = true };

            btnSimpan = new Button() { Text = "Simpan", Top = 560, Left = 20, Width = 100 };
            btnSimpan.Click += btnSimpan_Click;

            this.Controls.AddRange(new Control[] {
                lblNama, txtNama,
                lblAlamat, txtAlamat,
                lblNoHP, txtNoHP,
                lblCheckin, dtCheckin,
                lblCheckout, dtCheckout,
                lblPembayaran, cmbPembayaran,
                lblTarif, numTarif,
                lblMalam, numMalam,
                lblTotal, numTotal,
                btnSimpan
            });
        }
    }
}
