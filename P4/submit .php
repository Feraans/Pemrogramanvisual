<?php
$host = "localhost";
$user = "root";
$pass = "";
$dbname = "buahdb";

$conn = new mysqli($host, $user, $pass, $dbname);
if ($conn->connect_error) {
  die("Koneksi gagal: " . $conn->connect_error);
}

$diameter = $_POST['diameter'] ?? null;
$weight   = $_POST['weight'] ?? null;
$red      = $_POST['red'] ?? null;
$green    = $_POST['green'] ?? null;
$blue     = $_POST['blue'] ?? null;
$hasil    = (rand(0,1) == 1) ? "Benar" : "Salah";

// Pastikan data lengkap
if ($diameter && $weight && $red && $green && $blue) {
    $stmt = $conn->prepare("INSERT INTO prediksi_buah (diameter, weight, red, green, blue) VALUES (?, ?, ?, ?, ?)");
    $stmt->bind_param($diameter, $weight, $red, $green, $blue);
    
    if ($stmt->execute()) {
        echo "<h2>Data berhasil disimpan!</h2>";
        echo "<p>Hasil Prediksi: <strong>$hasil</strong></p>";
        echo "<a href='index.html'>Kembali</a>";
    } else {
        echo "Gagal menyimpan data: " . $stmt->error;
    }

    $stmt->close();
} else {
    echo "Data tidak lengkap.";
}

$conn->close();
?>
