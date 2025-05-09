CREATE DATABASE IF NOT EXISTS hotel_dafam;
USE hotel_dafam;

CREATE TABLE IF NOT EXISTS tamu (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nama VARCHAR(100) NOT NULL,
    alamat TEXT NOT NULL,
    no_hp VARCHAR(20) NOT NULL,
    tgl_checkin DATE NOT NULL,
    tgl_checkout DATE NOT NULL,
    jumlah_tamu INT NOT NULL,
    no_kamar VARCHAR(10) NOT NULL
);
