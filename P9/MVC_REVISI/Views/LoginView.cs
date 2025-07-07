using System;
using System.Windows.Forms;
using HotelDafam.Controllers;
using HotelDafam.Models;
using HotelDafam;

namespace HotelDafam.Views
{
    public partial class LoginView : Form
    {
        private readonly AuthController authController;

        public LoginView()
        {
            InitializeComponent();
            authController = new AuthController();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan password harus diisi!", "Peringatan", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = authController.Login(username, password);
                
                if (user != null)
                {
                    // Set user yang login di Program
                    Program.SetCurrentUser(user);
                    
                    // Tutup form login
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username atau password salah!", "Login Gagal", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerView = new RegisterView();
            if (registerView.ShowDialog() == DialogResult.OK)
            {
                // Jika registrasi berhasil, fokuskan ke field username
                txtUsername.Focus();
            }
        }

        private void LoginView_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Jika login dibatalkan (tombol close/X ditekan)
            if (this.DialogResult != DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}