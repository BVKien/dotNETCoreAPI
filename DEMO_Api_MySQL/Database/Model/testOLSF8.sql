-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: f8db
-- ------------------------------------------------------
-- Server version	8.0.34

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
-- Table structure for table `answer`
--

DROP TABLE IF EXISTS `answer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `answer` (
  `AnswerID` int NOT NULL,
  `Answer` varchar(200) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Question_QuestionID` int NOT NULL,
  PRIMARY KEY (`AnswerID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `answer`
--

LOCK TABLES `answer` WRITE;
/*!40000 ALTER TABLE `answer` DISABLE KEYS */;
INSERT INTO `answer` VALUES (1,'answer1',1),(2,'asnwer2',1),(3,'asnwer3',1),(4,'asnwer4',1),(5,'asnwer5',1);
/*!40000 ALTER TABLE `answer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ask`
--

DROP TABLE IF EXISTS `ask`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ask` (
  `AskID` int NOT NULL,
  `AskDetail` varchar(2000) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Dicuss_DicussID` int NOT NULL,
  PRIMARY KEY (`AskID`),
  KEY `fk_Ask_Dicuss1_idx` (`Dicuss_DicussID`),
  CONSTRAINT `fk_Ask_Dicuss1` FOREIGN KEY (`Dicuss_DicussID`) REFERENCES `dicuss` (`DicussID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ask`
--

LOCK TABLES `ask` WRITE;
/*!40000 ALTER TABLE `ask` DISABLE KEYS */;
INSERT INTO `ask` VALUES (1,'ask1',1),(2,'ask2',1),(3,'ask3',1),(4,'ask4',1),(5,'ask5',1);
/*!40000 ALTER TABLE `ask` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `blog`
--

DROP TABLE IF EXISTS `blog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `blog` (
  `BlogID` int NOT NULL AUTO_INCREMENT,
  `BlogTitle` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `BlogImage` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `BlogDetail` longtext,
  `PostDate` datetime DEFAULT NULL,
  `User_UserID` int NOT NULL,
  `BlogStatus` int DEFAULT NULL,
  `TimeToRead` int DEFAULT NULL,
  `BlogTopic_BlogTopicID` int NOT NULL,
  `BlogTag_BlogTagID` int NOT NULL,
  PRIMARY KEY (`BlogID`),
  KEY `fk_Blog_User1_idx` (`User_UserID`),
  KEY `fk_Blog_BlogTopic1_idx` (`BlogTopic_BlogTopicID`),
  KEY `fk_Blog_BlogTag1_idx` (`BlogTag_BlogTagID`),
  CONSTRAINT `fk_Blog_BlogTag1` FOREIGN KEY (`BlogTag_BlogTagID`) REFERENCES `blogtag` (`BlogTagID`),
  CONSTRAINT `fk_Blog_BlogTopic1` FOREIGN KEY (`BlogTopic_BlogTopicID`) REFERENCES `blogtopic` (`BlogTopicID`),
  CONSTRAINT `fk_Blog_User1` FOREIGN KEY (`User_UserID`) REFERENCES `user` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blog`
--

LOCK TABLES `blog` WRITE;
/*!40000 ALTER TABLE `blog` DISABLE KEYS */;
INSERT INTO `blog` VALUES (1,'blogtitile1','blogimage1','blogdetail1','2002-12-12 00:00:00',1,1,1,1,1),(2,'blogtitile2','blogimage2','blogdetail2','2002-12-12 00:00:00',1,1,1,1,1),(3,'blogtitile3','blogimage3','blogdetail3','2002-12-12 00:00:00',1,1,1,1,1),(4,'blogtitile4','blogimage4','blogdetail4','2002-12-12 00:00:00',1,1,1,1,1);
/*!40000 ALTER TABLE `blog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `blogcomment`
--

DROP TABLE IF EXISTS `blogcomment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `blogcomment` (
  `BlogCommentID` int NOT NULL AUTO_INCREMENT,
  `BlogID` int DEFAULT NULL,
  `UserID` int DEFAULT NULL,
  `level` int DEFAULT NULL,
  `origin_comment_id` int DEFAULT NULL,
  `reply_to_user` int DEFAULT NULL,
  `content` longtext,
  `publish` datetime DEFAULT NULL,
  PRIMARY KEY (`BlogCommentID`),
  KEY `fk_BlogComment_Blog1_idx` (`BlogID`),
  KEY `fk_BlogComment_User1_idx` (`UserID`),
  KEY `fk_BlogComment_User2_idx` (`reply_to_user`),
  CONSTRAINT `fk_BlogComment_Blog1` FOREIGN KEY (`BlogID`) REFERENCES `blog` (`BlogID`),
  CONSTRAINT `fk_BlogComment_User1` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`),
  CONSTRAINT `fk_BlogComment_User2` FOREIGN KEY (`reply_to_user`) REFERENCES `user` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blogcomment`
--

LOCK TABLES `blogcomment` WRITE;
/*!40000 ALTER TABLE `blogcomment` DISABLE KEYS */;
/*!40000 ALTER TABLE `blogcomment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `blogtag`
--

DROP TABLE IF EXISTS `blogtag`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `blogtag` (
  `BlogTagID` int NOT NULL AUTO_INCREMENT,
  `BlogTagName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`BlogTagID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blogtag`
--

LOCK TABLES `blogtag` WRITE;
/*!40000 ALTER TABLE `blogtag` DISABLE KEYS */;
INSERT INTO `blogtag` VALUES (1,'blogtag1'),(2,'blogtag2'),(3,'blogtag3'),(4,'blogtag4'),(5,'blogtag5'),(6,'blogtag6');
/*!40000 ALTER TABLE `blogtag` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `blogtopic`
--

DROP TABLE IF EXISTS `blogtopic`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `blogtopic` (
  `BlogTopicID` int NOT NULL AUTO_INCREMENT,
  `BlogTopicName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`BlogTopicID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blogtopic`
--

LOCK TABLES `blogtopic` WRITE;
/*!40000 ALTER TABLE `blogtopic` DISABLE KEYS */;
INSERT INTO `blogtopic` VALUES (1,'blogtopic1'),(2,'blogtopic2'),(3,'blogtopic3'),(4,'blogtopic4'),(5,'blogtopic5');
/*!40000 ALTER TABLE `blogtopic` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category` (
  `CategoryID` int NOT NULL,
  `Name` varchar(20) DEFAULT NULL,
  `CategoryImage` varchar(400) DEFAULT NULL,
  `Description` varchar(250) DEFAULT NULL,
  `Status` int DEFAULT NULL,
  PRIMARY KEY (`CategoryID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'ok','1','1',1);
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `course`
--

DROP TABLE IF EXISTS `course`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `course` (
  `CourseID` int NOT NULL,
  `Name` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Image` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `CourseInfo` varchar(200) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Description` varchar(200) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Status` int DEFAULT NULL,
  `User_UserID` int NOT NULL,
  `Category_CategoryID` int NOT NULL,
  `FeeStatus` int DEFAULT NULL,
  `VideoIntro` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  PRIMARY KEY (`CourseID`),
  KEY `fk_Course_User1_idx` (`User_UserID`),
  KEY `fk_Course_Category1_idx` (`Category_CategoryID`),
  CONSTRAINT `fk_Course_Category1` FOREIGN KEY (`Category_CategoryID`) REFERENCES `category` (`CategoryID`),
  CONSTRAINT `fk_Course_User1` FOREIGN KEY (`User_UserID`) REFERENCES `user` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `course`
--

LOCK TABLES `course` WRITE;
/*!40000 ALTER TABLE `course` DISABLE KEYS */;
INSERT INTO `course` VALUES (1,'ok','ok','ok','ok',1,1,1,1,'1'),(2,'hihi','hi','hi','hi',1,1,1,1,'1'),(3,'haha','ha','ha','ha',1,1,1,1,'1');
/*!40000 ALTER TABLE `course` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `courseenroll`
--

DROP TABLE IF EXISTS `courseenroll`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `courseenroll` (
  `CourseEnrollID` int NOT NULL AUTO_INCREMENT,
  `Status` int DEFAULT NULL,
  `LessonCurrent` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `EnrollDate` date DEFAULT NULL,
  `Course_CourseID` int NOT NULL,
  `User_UserID` int NOT NULL,
  PRIMARY KEY (`CourseEnrollID`),
  KEY `fk_CourseEnroll_Course1_idx` (`Course_CourseID`),
  KEY `fk_CourseEnroll_User1_idx` (`User_UserID`),
  CONSTRAINT `fk_CourseEnroll_Course1` FOREIGN KEY (`Course_CourseID`) REFERENCES `course` (`CourseID`),
  CONSTRAINT `fk_CourseEnroll_User1` FOREIGN KEY (`User_UserID`) REFERENCES `user` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `courseenroll`
--

LOCK TABLES `courseenroll` WRITE;
/*!40000 ALTER TABLE `courseenroll` DISABLE KEYS */;
/*!40000 ALTER TABLE `courseenroll` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dicuss`
--

DROP TABLE IF EXISTS `dicuss`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dicuss` (
  `DicussID` int NOT NULL,
  `LessonDetail_LessonDetailID` int NOT NULL,
  PRIMARY KEY (`DicussID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dicuss`
--

LOCK TABLES `dicuss` WRITE;
/*!40000 ALTER TABLE `dicuss` DISABLE KEYS */;
INSERT INTO `dicuss` VALUES (1,1);
/*!40000 ALTER TABLE `dicuss` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `feedback`
--

DROP TABLE IF EXISTS `feedback`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `feedback` (
  `FeedbackID` int NOT NULL,
  `Feedback` varchar(100) DEFAULT NULL,
  `User_UserID` varchar(45) NOT NULL,
  `Lesson_LessonID` varchar(45) NOT NULL,
  `Lesson_LessonID1` int NOT NULL,
  PRIMARY KEY (`FeedbackID`),
  KEY `fk_Feedback_Lesson1_idx` (`Lesson_LessonID1`),
  CONSTRAINT `fk_Feedback_Lesson1` FOREIGN KEY (`Lesson_LessonID1`) REFERENCES `lesson` (`LessonID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `feedback`
--

LOCK TABLES `feedback` WRITE;
/*!40000 ALTER TABLE `feedback` DISABLE KEYS */;
INSERT INTO `feedback` VALUES (1,'feedback1','1','1',1),(2,'feedback2','1','1',1),(3,'feedback3','1','1',1),(4,'feedback4','1','1',1),(5,'feedback5','1','1',1);
/*!40000 ALTER TABLE `feedback` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lesson`
--

DROP TABLE IF EXISTS `lesson`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lesson` (
  `LessonID` int NOT NULL,
  `Name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Course_CourseID` int NOT NULL,
  PRIMARY KEY (`LessonID`),
  KEY `fk_Lesson_Course1_idx` (`Course_CourseID`),
  CONSTRAINT `fk_Lesson_Course1` FOREIGN KEY (`Course_CourseID`) REFERENCES `course` (`CourseID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lesson`
--

LOCK TABLES `lesson` WRITE;
/*!40000 ALTER TABLE `lesson` DISABLE KEYS */;
INSERT INTO `lesson` VALUES (1,'lesson1',1),(2,'lesson2',1),(3,'lesson3',1),(4,'lesson4',1);
/*!40000 ALTER TABLE `lesson` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lessondetail`
--

DROP TABLE IF EXISTS `lessondetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lessondetail` (
  `LessonDetailID` int NOT NULL,
  `Title` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Video` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Note` varchar(200) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Time` time DEFAULT NULL,
  `Lesson_LessonID` int NOT NULL,
  `Dicuss_DicussID` int NOT NULL,
  PRIMARY KEY (`LessonDetailID`),
  KEY `fk_LessonDetail_Lesson1_idx` (`Lesson_LessonID`),
  KEY `fk_LessonDetail_Dicuss1_idx` (`Dicuss_DicussID`),
  CONSTRAINT `fk_LessonDetail_Dicuss1` FOREIGN KEY (`Dicuss_DicussID`) REFERENCES `dicuss` (`DicussID`),
  CONSTRAINT `fk_LessonDetail_Lesson1` FOREIGN KEY (`Lesson_LessonID`) REFERENCES `lesson` (`LessonID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lessondetail`
--

LOCK TABLES `lessondetail` WRITE;
/*!40000 ALTER TABLE `lessondetail` DISABLE KEYS */;
INSERT INTO `lessondetail` VALUES (1,'lessondetail1','lessondetailvideo1','notelessondetail','00:00:01',1,1),(2,'lessondetail2','lessondetailvideo2','notelessondetail2','00:00:10',1,1),(3,'lessondetail3','lessondetailvideo3','notelessondetail3','00:00:20',1,1);
/*!40000 ALTER TABLE `lessondetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `likecomment`
--

DROP TABLE IF EXISTS `likecomment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `likecomment` (
  `User_UserID` int NOT NULL,
  `BlogComment_BlogCommentID` int NOT NULL,
  KEY `fk_LikeComment_User1_idx` (`User_UserID`),
  KEY `fk_LikeComment_BlogComment1_idx` (`BlogComment_BlogCommentID`),
  CONSTRAINT `fk_LikeComment_BlogComment1` FOREIGN KEY (`BlogComment_BlogCommentID`) REFERENCES `blogcomment` (`BlogCommentID`),
  CONSTRAINT `fk_LikeComment_User1` FOREIGN KEY (`User_UserID`) REFERENCES `user` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `likecomment`
--

LOCK TABLES `likecomment` WRITE;
/*!40000 ALTER TABLE `likecomment` DISABLE KEYS */;
/*!40000 ALTER TABLE `likecomment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `question`
--

DROP TABLE IF EXISTS `question`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `question` (
  `QuestionID` int NOT NULL,
  `CorrectAnswer` varchar(2000) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Quiz_QuizID` int DEFAULT NULL,
  `Quiz_QuizID1` int NOT NULL,
  `Answer_AnswerID` int NOT NULL,
  PRIMARY KEY (`QuestionID`),
  KEY `fk_Question_Quiz1_idx` (`Quiz_QuizID1`),
  KEY `fk_Question_Answer1_idx` (`Answer_AnswerID`),
  CONSTRAINT `fk_Question_Answer1` FOREIGN KEY (`Answer_AnswerID`) REFERENCES `answer` (`AnswerID`),
  CONSTRAINT `fk_Question_Quiz1` FOREIGN KEY (`Quiz_QuizID1`) REFERENCES `quiz` (`QuizID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `question`
--

LOCK TABLES `question` WRITE;
/*!40000 ALTER TABLE `question` DISABLE KEYS */;
INSERT INTO `question` VALUES (1,'1',1,1,1),(2,'1',1,1,1),(3,'1',1,1,1),(4,'1',1,1,1);
/*!40000 ALTER TABLE `question` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `quiz`
--

DROP TABLE IF EXISTS `quiz`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `quiz` (
  `QuizID` int NOT NULL,
  `Lesson_LessonID` int NOT NULL,
  PRIMARY KEY (`QuizID`),
  KEY `fk_Quiz_Lesson1_idx` (`Lesson_LessonID`),
  CONSTRAINT `fk_Quiz_Lesson1` FOREIGN KEY (`Lesson_LessonID`) REFERENCES `lesson` (`LessonID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quiz`
--

LOCK TABLES `quiz` WRITE;
/*!40000 ALTER TABLE `quiz` DISABLE KEYS */;
INSERT INTO `quiz` VALUES (1,1);
/*!40000 ALTER TABLE `quiz` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reply`
--

DROP TABLE IF EXISTS `reply`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reply` (
  `ReplyID` int NOT NULL,
  `ReplyDetail` varchar(2000) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Ask_AskID` int NOT NULL,
  PRIMARY KEY (`ReplyID`),
  KEY `fk_Reply_Ask1_idx` (`Ask_AskID`),
  CONSTRAINT `fk_Reply_Ask1` FOREIGN KEY (`Ask_AskID`) REFERENCES `ask` (`AskID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reply`
--

LOCK TABLES `reply` WRITE;
/*!40000 ALTER TABLE `reply` DISABLE KEYS */;
INSERT INTO `reply` VALUES (1,'reply1',1),(2,'reply2',1),(3,'reply3',1),(4,'reply4',1),(5,'reply5',1);
/*!40000 ALTER TABLE `reply` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `saveblog`
--

DROP TABLE IF EXISTS `saveblog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `saveblog` (
  `User_UserID` int NOT NULL,
  `Blog_BlogID` int NOT NULL,
  `save_day` datetime DEFAULT NULL,
  KEY `fk_SaveBlog_User1_idx` (`User_UserID`),
  KEY `fk_SaveBlog_Blog1_idx` (`Blog_BlogID`),
  CONSTRAINT `fk_SaveBlog_Blog1` FOREIGN KEY (`Blog_BlogID`) REFERENCES `blog` (`BlogID`),
  CONSTRAINT `fk_SaveBlog_User1` FOREIGN KEY (`User_UserID`) REFERENCES `user` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `saveblog`
--

LOCK TABLES `saveblog` WRITE;
/*!40000 ALTER TABLE `saveblog` DISABLE KEYS */;
/*!40000 ALTER TABLE `saveblog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `savelike`
--

DROP TABLE IF EXISTS `savelike`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `savelike` (
  `Blog_BlogID` int NOT NULL,
  `User_UserID` int NOT NULL,
  KEY `fk_SaveLike_Blog1_idx` (`Blog_BlogID`),
  KEY `fk_SaveLike_User1_idx` (`User_UserID`),
  CONSTRAINT `fk_SaveLike_Blog1` FOREIGN KEY (`Blog_BlogID`) REFERENCES `blog` (`BlogID`),
  CONSTRAINT `fk_SaveLike_User1` FOREIGN KEY (`User_UserID`) REFERENCES `user` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `savelike`
--

LOCK TABLES `savelike` WRITE;
/*!40000 ALTER TABLE `savelike` DISABLE KEYS */;
/*!40000 ALTER TABLE `savelike` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `Email` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Facebook` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Github` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Password` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Phone` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `FullName` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Image` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Dob` date DEFAULT NULL,
  `Address` varchar(80) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `GmailID` varchar(80) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `FacebookID` varchar(80) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `GithubID` varchar(80) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Status` int DEFAULT NULL,
  `UserRole_RoleID` int NOT NULL,
  `CodeVerify` varchar(15) DEFAULT NULL,
  `Bio` varchar(300) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `BackgroundImage` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  PRIMARY KEY (`UserID`),
  KEY `fk_User_UserRole1_idx` (`UserRole_RoleID`),
  CONSTRAINT `fk_User_UserRole1` FOREIGN KEY (`UserRole_RoleID`) REFERENCES `userrole` (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Kien@gmail.com','fb','github','02122002','0961498125','Kienok','123','2002-12-02','HD City','123','123','123',1,1,'123','3132131313','1321321313');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userrole`
--

DROP TABLE IF EXISTS `userrole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userrole` (
  `RoleID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  PRIMARY KEY (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userrole`
--

LOCK TABLES `userrole` WRITE;
/*!40000 ALTER TABLE `userrole` DISABLE KEYS */;
INSERT INTO `userrole` VALUES (1,'boss');
/*!40000 ALTER TABLE `userrole` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-20 15:52:03
