using System;
using System.Windows.Forms;
using HotelDafam.Controllers;
using HotelDafam.Models;

namespace HotelDafam.Views
{
    public partial class RegisterView : Form
    {
        private AuthController authController;

        public RegisterView()
        {
            InitializeComponent();
            authController = new AuthController();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password dan konfirmasi password tidak sama!");
                return;
            }

            var user = new User
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                FullName = txtFullName.Text,
                Role = "staff" // Default role
            };

            if (authController.Register(user))
            {
                MessageBox.Show("Registrasi berhasil! Silakan login.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Registrasi gagal. Username mungkin sudah digunakan.");
            }
        }
    }
}