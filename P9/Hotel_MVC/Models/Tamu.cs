using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace HotelDafam.Repositories   // ganti jika namespace proyek Anda berbeda
{
    /// <summary>
    /// CRUD untuk tabel tamu.  Seluruh kode akses MySQL dipusatkan di sini.
    /// </summary>
    public static class TamuRepository
    {
        public static DataTable GetAll()
        {
            using var conn = Koneksi.GetConnection();
            const string sql = "SELECT * FROM tamu";
            using var da = new MySqlDataAdapter(sql, conn);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void Insert(string nama, string alamat, string noHp,
                                  DateTime tglIn, DateTime tglOut,
                                  int jumlah, string noKamar)
        {
            const string sql = @"INSERT INTO tamu
                (nama, alamat, no_hp, tgl_checkin, tgl_checkout, jumlah_tamu, no_kamar)
                VALUES (@nama,@alamat,@no_hp,@tgl_in,@tgl_out,@jumlah,@kamar)";

            using var conn = Koneksi.GetConnection();
            using var cmd  = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nama",   nama);
            cmd.Parameters.AddWithValue("@alamat", alamat);
            cmd.Parameters.AddWithValue("@no_hp",  noHp);
            cmd.Parameters.AddWithValue("@tgl_in", tglIn.Date);
            cmd.Parameters.AddWithValue("@tgl_out",tglOut.Date);
            cmd.Parameters.AddWithValue("@jumlah", jumlah);
            cmd.Parameters.AddWithValue("@kamar",  noKamar);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void Update(int id, string nama, string alamat, string noHp,
                                  DateTime tglIn, DateTime tglOut,
                                  int jumlah, string noKamar)
        {
            const string sql = @"UPDATE tamu SET
                nama=@nama, alamat=@alamat, no_hp=@no_hp,
                tgl_checkin=@tgl_in, tgl_checkout=@tgl_out,
                jumlah_tamu=@jumlah, no_kamar=@kamar
                WHERE id=@id";

            using var conn = Koneksi.GetConnection();
            using var cmd  = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id",     id);
            cmd.Parameters.AddWithValue("@nama",   nama);
            cmd.Parameters.AddWithValue("@alamat", alamat);
            cmd.Parameters.AddWithValue("@no_hp",  noHp);
            cmd.Parameters.AddWithValue("@tgl_in", tglIn.Date);
            cmd.Parameters.AddWithValue("@tgl_out",tglOut.Date);
            cmd.Parameters.AddWithValue("@jumlah", jumlah);
            cmd.Parameters.AddWithValue("@kamar",  noKamar);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void Delete(int id)
        {
            using var conn = Koneksi.GetConnection();
            const string sql = "DELETE FROM tamu WHERE id=@id";
            using var cmd  = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
