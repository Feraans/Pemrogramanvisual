<?php
// Konfigurasi koneksi
$host = "localhost";
$user = "root";
$pass = "";
$dbname = "hotel";

// Buat koneksi
$conn = new mysqli($host, $user, $pass, $dbname);

// Cek koneksi
if ($conn->connect_error) {
    die("Koneksi gagal: " . $conn->connect_error);
}

// Ambil data dari form
$nama       = $_POST['nama'] ?? '';
$alamat     = $_POST['alamat'] ?? '';
$no_hp      = $_POST['no_hp'] ?? '';
$checkin    = $_POST['checkin'] ?? '';
$checkout   = $_POST['checkout'] ?? '';
$pembayaran = $_POST['pembayaran'] ?? '';
$tarif      = $_POST['tarif'] ?? '';
$malam      = $_POST['malam'] ?? '';
$total      = $_POST['total'] ?? '';

// Validasi sederhana
if (
    empty($nama) || empty($alamat) || empty($no_hp) || empty($checkin) || empty($checkout) ||
    empty($pembayaran) || empty($tarif) || empty($malam) || empty($total)
) {
    die("Semua data harus diisi!");
}

// Query simpan
$sql = "INSERT INTO tamu (nama, alamat, no_hp, checkin, checkout, pembayaran, tarif, malam, total_bayar)
        VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
$stmt = $conn->prepare($sql);
$stmt->bind_param("ssssssiii", $nama, $alamat, $no_hp, $checkin, $checkout, $pembayaran, $tarif, $malam, $total);

// Eksekusi dan respon
if ($stmt->execute()) {
    echo "Data berhasil disimpan.";
} else {
    echo "Terjadi kesalahan: " . $stmt->error;
}

$stmt->close();
$conn->close();
?>
