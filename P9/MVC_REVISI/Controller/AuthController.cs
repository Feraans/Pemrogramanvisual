using System;
using HotelDafam.Models;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace HotelDafam.Controllers
{
    public class AuthController
    {
        public bool Register(User user)
        {
            using (var conn = Koneksi.GetConnection())
            {
                const string sql = "INSERT INTO users (username, password, full_name, role) VALUES (@username, @password, @fullName, @role)";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", HashPassword(user.Password));
                    cmd.Parameters.AddWithValue("@fullName", user.FullName);
                    cmd.Parameters.AddWithValue("@role", user.Role);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public User? Login(string username, string password)
        {
            using (var conn = Koneksi.GetConnection())
            {
                const string sql = "SELECT id, username, password, full_name, role FROM users WHERE username = @username";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var storedPassword = reader["password"]?.ToString() ?? string.Empty;
                            if (!string.IsNullOrEmpty(storedPassword) && VerifyPassword(password, storedPassword))
                            {
                                return new User
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Username = reader["username"]?.ToString() ?? string.Empty,
                                    FullName = reader["full_name"]?.ToString() ?? string.Empty,
                                    Role = reader["role"]?.ToString() ?? "staff"
                                };
                            }
                        }
                        return null;
                    }
                }
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            if (string.IsNullOrEmpty(storedPassword))
                return false;

            return HashPassword(inputPassword) == storedPassword;
        }
    }
}
