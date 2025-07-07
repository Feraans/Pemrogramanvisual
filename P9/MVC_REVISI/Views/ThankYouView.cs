using System;
using System.Windows.Forms;

namespace HotelDafam.Views
{
    public partial class ThankYouView : Form
    {
        public ThankYouView()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}