using System;
using System.Windows.Forms;

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
            MessageBox.Show("Data berhasil disimpan:\n" +
                $"Nama: {txtNama.Text}\n" +
                $"Alamat: {txtAlamat.Text}\n" +
                $"No HP: {txtNoHP.Text}\n" +
                $"Check-in: {dtCheckin.Value.ToShortDateString()}\n" +
                $"Check-out: {dtCheckout.Value.ToShortDateString()}\n" +
                $"Metode Pembayaran: {cmbPembayaran.SelectedItem}\n" +
                $"Total Bayar: Rp {numTotal.Value}");
        }
    }
}
