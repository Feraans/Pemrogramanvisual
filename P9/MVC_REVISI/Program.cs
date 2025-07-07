using System;
using System.Windows.Forms;
using HotelDafam.Views;
using HotelDafam.Models;

namespace HotelDafam
{
    static class Program
    {
        public static User? CurrentUser { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            bool bypassLogin = false; // Set ke false untuk production

            if (bypassLogin)
            {
                // Mode development - langsung ke MainView dengan user dummy
                CurrentUser = new User 
                { 
                    Id = 1,
                    Username = "admin",
                    FullName = "Administrator",
                    Role = "admin"
                };
                
                ShowMainViewAndRunApplication();
            }
            else
            {
                // Mode production - tampilkan login terlebih dahulu
                using (var loginView = new LoginView())
                {
                    if (loginView.ShowDialog() == DialogResult.OK && CurrentUser != null)
                    {
                        ShowMainViewAndRunApplication();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }

        private static void ShowMainViewAndRunApplication()
        {
            if (CurrentUser == null)
            {
                MessageBox.Show("User tidak valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            var mainView = new MainView(CurrentUser);
            mainView.FormClosed += (s, args) => Application.Exit();
            Application.Run(mainView);
        }

        public static void SetCurrentUser(User? user)
        {
            CurrentUser = user;
        }
    }
}