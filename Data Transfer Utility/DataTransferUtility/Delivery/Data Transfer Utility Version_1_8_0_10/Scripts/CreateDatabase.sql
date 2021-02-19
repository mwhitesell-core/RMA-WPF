USE [MASTER]

IF NOT EXISTS(SELECT * FROM sys.sysdatabases WHERE NAME = '%DatabaseName%')
BEGIN
   CREATE DATABASE [%DatabaseName%]
    CONTAINMENT = NONE
    ON  PRIMARY 
   ( NAME = N'%DatabaseName%', FILENAME = N'%SQLServerLocation%\%DatabaseName%.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
    LOG ON 
   ( NAME = N'%DatabaseName%_log', FILENAME = N'%SQLServerLocation%\%DatabaseName%_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )

   IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
   BEGIN
      EXEC [%DatabaseName%].[dbo].[sp_fulltext_database] @action = 'enable'
   END

   ALTER DATABASE [%DatabaseName%] SET ANSI_NULL_DEFAULT OFF 

   ALTER DATABASE [%DatabaseName%] SET ANSI_NULLS OFF 

   ALTER DATABASE [%DatabaseName%] SET ANSI_PADDING OFF 

   ALTER DATABASE [%DatabaseName%] SET ANSI_WARNINGS OFF 

   ALTER DATABASE [%DatabaseName%] SET ARITHABORT OFF 

   ALTER DATABASE [%DatabaseName%] SET AUTO_CLOSE OFF 

   ALTER DATABASE [%DatabaseName%] SET AUTO_CREATE_STATISTICS ON 

   ALTER DATABASE [%DatabaseName%] SET AUTO_SHRINK OFF 

   ALTER DATABASE [%DatabaseName%] SET AUTO_UPDATE_STATISTICS ON 

   ALTER DATABASE [%DatabaseName%] SET CURSOR_CLOSE_ON_COMMIT OFF 

   ALTER DATABASE [%DatabaseName%] SET CURSOR_DEFAULT  GLOBAL 

   ALTER DATABASE [%DatabaseName%] SET CONCAT_NULL_YIELDS_NULL OFF 

   ALTER DATABASE [%DatabaseName%] SET NUMERIC_ROUNDABORT OFF 

   ALTER DATABASE [%DatabaseName%] SET QUOTED_IDENTIFIER OFF 

   ALTER DATABASE [%DatabaseName%] SET RECURSIVE_TRIGGERS OFF 

   ALTER DATABASE [%DatabaseName%] SET  DISABLE_BROKER 

   ALTER DATABASE [%DatabaseName%] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 

   ALTER DATABASE [%DatabaseName%] SET DATE_CORRELATION_OPTIMIZATION OFF 

   ALTER DATABASE [%DatabaseName%] SET TRUSTWORTHY OFF 

   ALTER DATABASE [%DatabaseName%] SET ALLOW_SNAPSHOT_ISOLATION OFF 

   ALTER DATABASE [%DatabaseName%] SET PARAMETERIZATION SIMPLE 

   ALTER DATABASE [%DatabaseName%] SET READ_COMMITTED_SNAPSHOT OFF 

   ALTER DATABASE [%DatabaseName%] SET HONOR_BROKER_PRIORITY OFF 

   ALTER DATABASE [%DatabaseName%] SET RECOVERY FULL 

   ALTER DATABASE [%DatabaseName%] SET  MULTI_USER 

   ALTER DATABASE [%DatabaseName%] SET PAGE_VERIFY CHECKSUM  

   ALTER DATABASE [%DatabaseName%] SET DB_CHAINING OFF 

   ALTER DATABASE [%DatabaseName%] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 

   ALTER DATABASE [%DatabaseName%] SET TARGET_RECOVERY_TIME = 60 SECONDS 

   ALTER DATABASE [%DatabaseName%] SET  READ_WRITE 
END

IF NOT EXISTS(SELECT * FROM sys.sysdatabases WHERE NAME = '%DatabaseName%_BACKUP')
BEGIN
   CREATE DATABASE [%DatabaseName%_BACKUP]
    CONTAINMENT = NONE
    ON  PRIMARY 
   ( NAME = N'%DatabaseName%_BACKUP', FILENAME = N'%SQLServerLocation%\%DatabaseName%_BACKUP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
    LOG ON 
   ( NAME = N'%DatabaseName%_BACKUP_log', FILENAME = N'%SQLServerLocation%\%DatabaseName%_BACKUP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )

   IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
   BEGIN
      EXEC [%DatabaseName%_BACKUP].[dbo].[sp_fulltext_database] @action = 'enable'
   END

   ALTER DATABASE [%DatabaseName%_BACKUP] SET ANSI_NULL_DEFAULT OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET ANSI_NULLS OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET ANSI_PADDING OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET ANSI_WARNINGS OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET ARITHABORT OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET AUTO_CLOSE OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET AUTO_CREATE_STATISTICS ON 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET AUTO_SHRINK OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET AUTO_UPDATE_STATISTICS ON 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET CURSOR_CLOSE_ON_COMMIT OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET CURSOR_DEFAULT  GLOBAL 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET CONCAT_NULL_YIELDS_NULL OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET NUMERIC_ROUNDABORT OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET QUOTED_IDENTIFIER OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET RECURSIVE_TRIGGERS OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET  DISABLE_BROKER 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET DATE_CORRELATION_OPTIMIZATION OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET TRUSTWORTHY OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET ALLOW_SNAPSHOT_ISOLATION OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET PARAMETERIZATION SIMPLE 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET READ_COMMITTED_SNAPSHOT OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET HONOR_BROKER_PRIORITY OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET RECOVERY FULL 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET  MULTI_USER 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET PAGE_VERIFY CHECKSUM  

   ALTER DATABASE [%DatabaseName%_BACKUP] SET DB_CHAINING OFF 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET TARGET_RECOVERY_TIME = 60 SECONDS 

   ALTER DATABASE [%DatabaseName%_BACKUP] SET  READ_WRITE 
END