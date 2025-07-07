using System;

namespace HotelDafam.Models
{
    public class Tamu
    {
        public int Id { get; set; }
        public string Nama { get; set; } = string.Empty;
        public string Alamat { get; set; } = string.Empty;
        public string NoHp { get; set; } = string.Empty;
        public DateTime TglCheckIn { get; set; }
        public DateTime TglCheckOut { get; set; }
        public int JumlahTamu { get; set; }
        public string NoKamar { get; set; } = string.Empty;
    }
}