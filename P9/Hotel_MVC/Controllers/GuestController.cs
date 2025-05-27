
using System;
using System.Windows.Forms;
using HotelDafamApp.Models;
using HotelDafamApp.Views;

namespace HotelDafamApp.Controllers
{
    public class GuestController
    {
        private Tamu model;
        private Form1 view;

        public GuestController(Form1 view)
        {
            this.view = view;
            this.model = new Tamu();
            // Tambahkan pengaturan event handler di sini
        }

        public void AddGuest(string nama, string alamat, string notelp)
        {
            model.InsertGuest(nama, alamat, notelp);
        }

        // Tambahan fungsi update/delete bisa ditambahkan di sini
    }
}
