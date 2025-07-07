using System;
using System.Data;
using System.Windows.Forms;
using HotelDafam.Controllers;

namespace HotelDafam.Views
{
    public partial class ReportView : Form
    {
        private ReportController reportController;

        public ReportView()
        {
            InitializeComponent();
            reportController = new ReportController();
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reportController.GetReportByDateRange(
                dtpMulai.Value, dtpSelesai.Value);
        }
    }
}