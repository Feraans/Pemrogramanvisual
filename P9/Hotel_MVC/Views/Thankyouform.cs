using System;
using System.Windows.Forms;

namespace HotelDafamApp
{
    public partial class ThankYouForm : Form
    {
        public ThankYouForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}