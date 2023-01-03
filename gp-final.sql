-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 03, 2023 at 04:21 PM
-- Server version: 8.0.29
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `gp-final`
--

-- --------------------------------------------------------

--
-- Table structure for table `aldigiders`
--

CREATE TABLE `aldigiders` (
  `count` int NOT NULL,
  `dersid` varchar(45) DEFAULT NULL,
  `ogrencino` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `aldigiders`
--

INSERT INTO `aldigiders` (`count`, `dersid`, `ogrencino`) VALUES
(1, '124', '1'),
(2, '124', '3'),
(3, '124', '5'),
(4, '754', '4'),
(5, '754', '1'),
(6, '754', '3'),
(7, '1003', '1'),
(8, '1003', '2'),
(9, '1003', '3'),
(10, '1003', '4'),
(11, '697', '1'),
(12, '697', '3'),
(13, '697', '5');

-- --------------------------------------------------------

--
-- Table structure for table `aldigidersa`
--

CREATE TABLE `aldigidersa` (
  `dersid` int NOT NULL,
  `ogrencino` varchar(45) NOT NULL,
  `count` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `aldigidersa`
--

INSERT INTO `aldigidersa` (`dersid`, `ogrencino`, `count`) VALUES
(124, '1', 1),
(124, '2', 2),
(124, '3', 3),
(754, '3', 4),
(697, '3', 6),
(1003, '5', 7),
(1003, '4', 8),
(1003, '2', 9),
(1003, '1', 10),
(1003, '3', 11);

-- --------------------------------------------------------

--
-- Table structure for table `bolumler`
--

CREATE TABLE `bolumler` (
  `idbolumler` varchar(45) NOT NULL,
  `bolumad` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `bolumler`
--

INSERT INTO `bolumler` (`idbolumler`, `bolumad`) VALUES
('1', 'Bilgisayar Mühendisliği'),
('2', 'Bilgisayar Programcılığı'),
('3', 'Makine Mühendisliği'),
('4', 'Gastronomi');

-- --------------------------------------------------------

--
-- Table structure for table `dersler`
--

CREATE TABLE `dersler` (
  `idders` int NOT NULL,
  `dersAdi` varchar(45) DEFAULT NULL,
  `bolumid` varchar(45) DEFAULT NULL,
  `Kredi` int DEFAULT '0',
  `krediKirilma` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `dersler`
--

INSERT INTO `dersler` (`idders`, `dersAdi`, `bolumid`, `Kredi`, `krediKirilma`) VALUES
(124, 'Biyoloji', 'a5', 2, 1),
(697, 'Mutfak', 'a1', 2, 1),
(754, 'Kimya', 'a3', 2, 0),
(879, 'Fizik', 'a4', 2, 0),
(1003, 'Php', 'a3', 3, 0);

-- --------------------------------------------------------

--
-- Table structure for table `duyurular`
--

CREATE TABLE `duyurular` (
  `id` int NOT NULL,
  `Duyuru` varchar(200) NOT NULL,
  `tarihDuyurular` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `duyurular`
--

INSERT INTO `duyurular` (`id`, `Duyuru`, `tarihDuyurular`) VALUES
(9, 'Selam', '29.12.2022'),
(12, 'Duyurudeneme', '21.12.2022');

-- --------------------------------------------------------

--
-- Table structure for table `notlar`
--

CREATE TABLE `notlar` (
  `count` int NOT NULL,
  `idogrenci` varchar(45) DEFAULT NULL,
  `dersid` int NOT NULL,
  `notl` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `notlar`
--

INSERT INTO `notlar` (`count`, `idogrenci`, `dersid`, `notl`) VALUES
(1, '1', 124, 100),
(2, '2', 124, 54),
(3, '3', 124, 80),
(4, '3', 697, 100),
(5, '3', 754, 45),
(7, '5', 1003, 3),
(8, '4', 1003, 12),
(9, '2', 1003, 24),
(10, '1', 1003, 12),
(11, '3', 1003, 100);

-- --------------------------------------------------------

--
-- Table structure for table `ogrenci`
--

CREATE TABLE `ogrenci` (
  `idogrenci` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ogrenciAd` varchar(45) DEFAULT NULL,
  `ogrenciSoy` varchar(45) DEFAULT NULL,
  `bolumid` varchar(45) DEFAULT NULL,
  `sifre` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `ogrenci`
--

INSERT INTO `ogrenci` (`idogrenci`, `ogrenciAd`, `ogrenciSoy`, `bolumid`, `sifre`) VALUES
('2', 'Asim', 'BEYAZTAŞ', '2', '123'),
('20220206522', 'Ertan', 'Felek', '2', '1234'),
('20220331300', 'Kerem', 'Mehmet', '3', '4578'),
('20220471471', 'Attil', 'hakan', '4', '8783'),
('20220485548', 'Süleyman', 'Köse', '4', '1111'),
('20230127001', 'asddsa', 'asd', '1', '7668'),
('20230465048', 'Hasan', 'Hüseyin', '4', NULL),
('3', 'Burak', 'FELEK', '3', '122'),
('5', 'Olgun', 'Salman', '1', '111');

-- --------------------------------------------------------

--
-- Table structure for table `ogretmen`
--

CREATE TABLE `ogretmen` (
  `idOgretmen` bigint NOT NULL,
  `ogretmencol` varchar(45) DEFAULT NULL,
  `ogretmenSoy` varchar(50) NOT NULL,
  `dersid` varchar(45) DEFAULT NULL,
  `bolumid` varchar(45) DEFAULT NULL,
  `Admin` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `sifre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `ogretmen`
--

INSERT INTO `ogretmen` (`idOgretmen`, `ogretmencol`, `ogretmenSoy`, `dersid`, `bolumid`, `Admin`, `sifre`) VALUES
(11, 'Tuğçe', 'Ergen', NULL, '3', '-', '123'),
(50, 'Murat', 'Sarı', NULL, NULL, 'Admin', '111'),
(124, 'Barış', 'Genç', NULL, '1', '-', '1235'),
(1234, 'Mete', 'Yiğit', NULL, '2', '-', '1234'),
(20220234618, 'Ertan', 'FELEK', NULL, '2', 'Admin', '4444'),
(20220308635, 'Yusuf', 'Akçura', NULL, '3', 'ÜYE', '3864'),
(20220445636, 'AHMET', 'ASLAN', NULL, '4', 'ÜYE', NULL),
(20230187838, 'Metehan', 'Yiğit', NULL, '1', 'Üye', '7434');

-- --------------------------------------------------------

--
-- Table structure for table `sinavlar`
--

CREATE TABLE `sinavlar` (
  `OgrenciId` varchar(45) NOT NULL,
  `SinavAdi` varchar(45) NOT NULL,
  `Sinif` varchar(45) NOT NULL,
  `Saat` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `sinavlar`
--

INSERT INTO `sinavlar` (`OgrenciId`, `SinavAdi`, `Sinif`, `Saat`) VALUES
('1', 'Veri Tabanı', '105', '15.30'),
('2', 'Programlama', '201', '10.00'),
('3', 'Elektronik', '201', '11.00'),
('4', 'Matematik', '203', '13.30'),
('4', 'Veri Tabanı', '105', '15.30'),
('1', 'Elektronik', '204', '13.05'),
('3', 'Programlama', '206', '12.00');

-- --------------------------------------------------------

--
-- Table structure for table `verdiders`
--

CREATE TABLE `verdiders` (
  `idders` varchar(45) NOT NULL,
  `ogretmenid` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `verdiders`
--

INSERT INTO `verdiders` (`idders`, `ogretmenid`) VALUES
('1003', '50'),
('124', '11'),
('697\n', '12'),
('754', '124'),
('879', '1234');

-- --------------------------------------------------------

--
-- Table structure for table `yemeklistesi`
--

CREATE TABLE `yemeklistesi` (
  `Tarih` varchar(45) NOT NULL,
  `Corba` varchar(45) DEFAULT NULL,
  `anaYemek` varchar(45) DEFAULT NULL,
  `Icecek` varchar(45) DEFAULT NULL,
  `Tatli` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `yemeklistesi`
--

INSERT INTO `yemeklistesi` (`Tarih`, `Corba`, `anaYemek`, `Icecek`, `Tatli`) VALUES
('2022-12-10', 'Ezo gelin', 'Pilav', 'Ayran', 'Kemalpaşa'),
('2022-22-12', 'Yayla', 'Makarna', 'Yok', 'Tavuk Göğsü'),
('2022-26-12', 'Düğün', 'Karnabahar', 'Ayran', 'kazandibi'),
('2022-27-12', 'Mercimek', 'Karnıyarık', 'Kola', 'Sütlaç'),
('2023-02-01', 'Tarhana', 'Karnıyarık', 'Şalgam', 'Mozaik pasta'),
('2023-03-01', 'Sebze', 'Fırında Makarna', 'Şalgam', 'Puding');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aldigiders`
--
ALTER TABLE `aldigiders`
  ADD PRIMARY KEY (`count`);

--
-- Indexes for table `aldigidersa`
--
ALTER TABLE `aldigidersa`
  ADD PRIMARY KEY (`count`);

--
-- Indexes for table `bolumler`
--
ALTER TABLE `bolumler`
  ADD PRIMARY KEY (`idbolumler`);

--
-- Indexes for table `dersler`
--
ALTER TABLE `dersler`
  ADD PRIMARY KEY (`idders`);

--
-- Indexes for table `duyurular`
--
ALTER TABLE `duyurular`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `notlar`
--
ALTER TABLE `notlar`
  ADD PRIMARY KEY (`count`);

--
-- Indexes for table `ogrenci`
--
ALTER TABLE `ogrenci`
  ADD PRIMARY KEY (`idogrenci`),
  ADD UNIQUE KEY `idogrenci_UNIQUE` (`idogrenci`),
  ADD KEY `bolumid` (`bolumid`);

--
-- Indexes for table `ogretmen`
--
ALTER TABLE `ogretmen`
  ADD PRIMARY KEY (`idOgretmen`),
  ADD UNIQUE KEY `idOgretmen_UNIQUE` (`idOgretmen`),
  ADD KEY `bolumid` (`bolumid`);

--
-- Indexes for table `verdiders`
--
ALTER TABLE `verdiders`
  ADD PRIMARY KEY (`idders`);

--
-- Indexes for table `yemeklistesi`
--
ALTER TABLE `yemeklistesi`
  ADD PRIMARY KEY (`Tarih`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `aldigiders`
--
ALTER TABLE `aldigiders`
  MODIFY `count` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `aldigidersa`
--
ALTER TABLE `aldigidersa`
  MODIFY `count` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `duyurular`
--
ALTER TABLE `duyurular`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `notlar`
--
ALTER TABLE `notlar`
  MODIFY `count` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `ogrenci`
--
ALTER TABLE `ogrenci`
  ADD CONSTRAINT `ogrenci_ibfk_1` FOREIGN KEY (`bolumid`) REFERENCES `bolumler` (`idbolumler`);

--
-- Constraints for table `ogretmen`
--
ALTER TABLE `ogretmen`
  ADD CONSTRAINT `ogretmen_ibfk_1` FOREIGN KEY (`bolumid`) REFERENCES `bolumler` (`idbolumler`),
  ADD CONSTRAINT `ogretmen_ibfk_2` FOREIGN KEY (`bolumid`) REFERENCES `bolumler` (`idbolumler`),
  ADD CONSTRAINT `ogretmen_ibfk_3` FOREIGN KEY (`bolumid`) REFERENCES `bolumler` (`idbolumler`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
