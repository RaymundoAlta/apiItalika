USE [master]
GO

/****** Object:  Database [Italika]    Script Date: 19/02/2021 01:17:58 p. m. ******/
CREATE DATABASE [Italika]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Italika', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Italika.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Italika_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Italika_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Italika] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Italika].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Italika] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Italika] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Italika] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Italika] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Italika] SET ARITHABORT OFF 
GO

ALTER DATABASE [Italika] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Italika] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Italika] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Italika] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Italika] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Italika] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Italika] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Italika] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Italika] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Italika] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Italika] SET  ENABLE_BROKER 
GO

ALTER DATABASE [Italika] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Italika] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Italika] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Italika] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Italika] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Italika] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Italika] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Italika] SET RECOVERY FULL 
GO

ALTER DATABASE [Italika] SET  MULTI_USER 
GO

ALTER DATABASE [Italika] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Italika] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Italika] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Italika] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [Italika] SET  READ_WRITE 
GO

USE [Italika]
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_Productos]    Script Date: 19/02/2021 01:17:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[sp_Insert_Productos]
	-- Add the parameters for the stored procedure here
	 @sku NVARCHAR(50)
	,@fert NVARCHAR(50)
	,@modelo NVARCHAR(50)
	,@tipo NVARCHAR(50)
	,@numeroserie NVARCHAR(50)
	,@fechar DATETIME
AS
BEGIN	
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Productos
	(
		 Sku
		,Fert
		,Modelo
		,Tipo
		,NumeroSerie
		,Fechar
	)
	VALUES
	(
		@sku
		,@fert
		,@modelo
		,@tipo
		,@numeroserie
		,@fechar

	)
END

GO
/****** Object:  Table [dbo].[Productos]    Script Date: 19/02/2021 01:17:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sku] [nvarchar](50) NOT NULL,
	[Fert] [nvarchar](50) NOT NULL,
	[Modelo] [nvarchar](50) NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
	[NumeroSerie] [nvarchar](50) NOT NULL,
	[Fechar] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
