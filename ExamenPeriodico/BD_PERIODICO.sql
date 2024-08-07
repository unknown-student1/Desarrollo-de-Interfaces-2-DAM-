-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         5.5.40 - MySQL Community Server (GPL)
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.6.0.6765
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Volcando estructura para tabla periodico.publicaciones
CREATE TABLE IF NOT EXISTS `publicaciones` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Fecha` date DEFAULT NULL,
  `Titulo` varchar(100) COLLATE utf8_spanish2_ci DEFAULT NULL,
  `Cuerpo` varchar(500) COLLATE utf8_spanish2_ci DEFAULT NULL,
  `Seccion` int(11) DEFAULT NULL,
  `Calificacion` int(11) DEFAULT NULL,
  `PalabrasClave` varchar(100) COLLATE utf8_spanish2_ci DEFAULT NULL,
  `Autor` varchar(100) COLLATE utf8_spanish2_ci DEFAULT NULL,
  KEY `Id` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

-- Volcando datos para la tabla periodico.publicaciones: ~1 rows (aproximadamente)
INSERT INTO `publicaciones` (`Id`, `Fecha`, `Titulo`, `Cuerpo`, `Seccion`, `Calificacion`, `PalabrasClave`, `Autor`) VALUES
	(1, '2024-05-21', 'Lorem Ipsum', 'Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen.', 2, 10, 'Example Lorem Ipsum', 'Pepe Juan');

-- Volcando estructura para tabla periodico.secciones
CREATE TABLE IF NOT EXISTS `secciones` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(100) COLLATE utf8_spanish2_ci DEFAULT NULL,
  KEY `Id` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

-- Volcando datos para la tabla periodico.secciones: ~5 rows (aproximadamente)
INSERT INTO `secciones` (`Id`, `Descripcion`) VALUES
	(1, 'Deportes'),
	(2, 'Sociedad'),
	(3, 'Provincia'),
	(4, 'Economía'),
	(5, 'Moda');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
