using System;
using System.Data;
using HotelDafam.Models;
using MySql.Data.MySqlClient;

namespace HotelDafam.Controllers
{
    public class TamuController
    {
        public DataTable GetAllTamu()
        {
            using var conn = Koneksi.GetConnection();
            const string sql = "SELECT * FROM tamu";
            using var da = new MySqlDataAdapter(sql, conn);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void AddTamu(Tamu tamu)
        {
            const string sql = @"INSERT INTO tamu
                (nama, alamat, no_hp, tgl_checkin, tgl_checkout, jumlah_tamu, no_kamar)
                VALUES (@nama,@alamat,@no_hp,@tgl_in,@tgl_out,@jumlah,@kamar)";

            using var conn = Koneksi.GetConnection();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nama", tamu.Nama);
            cmd.Parameters.AddWithValue("@alamat", tamu.Alamat);
            cmd.Parameters.AddWithValue("@no_hp", tamu.NoHp);
            cmd.Parameters.AddWithValue("@tgl_in", tamu.TglCheckIn.Date);
            cmd.Parameters.AddWithValue("@tgl_out", tamu.TglCheckOut.Date);
            cmd.Parameters.AddWithValue("@jumlah", tamu.JumlahTamu);
            cmd.Parameters.AddWithValue("@kamar", tamu.NoKamar);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void UpdateTamu(Tamu tamu)
        {
            const string sql = @"UPDATE tamu SET
                nama=@nama, alamat=@alamat, no_hp=@no_hp,
                tgl_checkin=@tgl_in, tgl_checkout=@tgl_out,
                jumlah_tamu=@jumlah, no_kamar=@kamar
                WHERE id=@id";

            using var conn = Koneksi.GetConnection();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", tamu.Id);
            cmd.Parameters.AddWithValue("@nama", tamu.Nama);
            cmd.Parameters.AddWithValue("@alamat", tamu.Alamat);
            cmd.Parameters.AddWithValue("@no_hp", tamu.NoHp);
            cmd.Parameters.AddWithValue("@tgl_in", tamu.TglCheckIn.Date);
            cmd.Parameters.AddWithValue("@tgl_out", tamu.TglCheckOut.Date);
            cmd.Parameters.AddWithValue("@jumlah", tamu.JumlahTamu);
            cmd.Parameters.AddWithValue("@kamar", tamu.NoKamar);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void DeleteTamu(int id)
        {
            using var conn = Koneksi.GetConnection();
            const string sql = "DELETE FROM tamu WHERE id=@id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}