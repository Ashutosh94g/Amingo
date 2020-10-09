-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: amingodb
-- ------------------------------------------------------
-- Server version	8.0.20

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `genders`
--

DROP TABLE IF EXISTS `genders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `genders` (
  `login_reg_id` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `gender` char(1) NOT NULL COMMENT 'I am a: w- woman, m- man, o- other',
  `sexual_orientation_sid` tinyint NOT NULL,
  `preference` char(1) NOT NULL COMMENT 'Show me: w- women, m- men, e- everyone',
  PRIMARY KEY (`login_reg_id`),
  KEY `fk_genders_sexual_orientations1_idx` (`sexual_orientation_sid`),
  CONSTRAINT `fk_genders_login_reg1` FOREIGN KEY (`login_reg_id`) REFERENCES `login_reg` (`id`),
  CONSTRAINT `fk_genders_sexual_orientations1` FOREIGN KEY (`sexual_orientation_sid`) REFERENCES `sexual_orientations` (`sid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='this table will contain only gender, sexual orientation and preference info';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genders`
--

LOCK TABLES `genders` WRITE;
/*!40000 ALTER TABLE `genders` DISABLE KEYS */;
/*!40000 ALTER TABLE `genders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hobbies`
--

DROP TABLE IF EXISTS `hobbies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hobbies` (
  `hid` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `hobbies` varchar(20) NOT NULL,
  PRIMARY KEY (`hid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hobbies`
--

LOCK TABLES `hobbies` WRITE;
/*!40000 ALTER TABLE `hobbies` DISABLE KEYS */;
/*!40000 ALTER TABLE `hobbies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `login_reg`
--

DROP TABLE IF EXISTS `login_reg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `login_reg` (
  `id` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `firstName` varchar(15) NOT NULL,
  `middleName` varchar(15) DEFAULT NULL,
  `lastName` varchar(15) DEFAULT NULL,
  `username` varchar(25) NOT NULL,
  `pass` varchar(25) NOT NULL,
  `dob` date NOT NULL,
  `createdTimestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login_reg`
--

LOCK TABLES `login_reg` WRITE;
/*!40000 ALTER TABLE `login_reg` DISABLE KEYS */;
INSERT INTO `login_reg` VALUES (1,'',NULL,NULL,'admin','12345','0000-00-00','2020-10-09 16:42:12'),(2,'',NULL,NULL,'admin','12345','0000-00-00','2020-10-09 16:42:12'),(3,'Testname',NULL,NULL,'testuser','123','2000-12-12','2020-10-09 16:43:36'),(4,'gegrg',NULL,NULL,'ff','ff','2000-12-12','2020-10-09 16:44:38');
/*!40000 ALTER TABLE `login_reg` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sexual_orientations`
--

DROP TABLE IF EXISTS `sexual_orientations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sexual_orientations` (
  `sid` tinyint NOT NULL AUTO_INCREMENT,
  `sexualOrientation` varchar(10) NOT NULL,
  PRIMARY KEY (`sid`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sexual_orientations`
--

LOCK TABLES `sexual_orientations` WRITE;
/*!40000 ALTER TABLE `sexual_orientations` DISABLE KEYS */;
INSERT INTO `sexual_orientations` VALUES (1,'Straight'),(2,'Gay'),(3,'Lesbian'),(4,'Bisexual'),(5,'Asexyal'),(6,'Demisexual'),(7,'Pansexual'),(8,'Queer');
/*!40000 ALTER TABLE `sexual_orientations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_profile`
--

DROP TABLE IF EXISTS `user_profile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_profile` (
  `login_reg_id` tinyint unsigned NOT NULL,
  `hobbies_hid` tinyint unsigned NOT NULL,
  `tempColumn` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`login_reg_id`),
  KEY `fk_user_profile_hobbies1_idx` (`hobbies_hid`),
  KEY `fk_user_profile_login_reg1_idx` (`login_reg_id`),
  CONSTRAINT `fk_user_profile_hobbies1` FOREIGN KEY (`hobbies_hid`) REFERENCES `hobbies` (`hid`),
  CONSTRAINT `fk_user_profile_login_reg1` FOREIGN KEY (`login_reg_id`) REFERENCES `login_reg` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_profile`
--

LOCK TABLES `user_profile` WRITE;
/*!40000 ALTER TABLE `user_profile` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_profile` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-10-09 22:45:08
