USE [master]
GO
/****** Object:  Database [app_db]    Script Date: 01/12/2020 21:03:10 ******/
CREATE DATABASE [app_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'app_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\app_db.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'app_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\app_db_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [app_db] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [app_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [app_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [app_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [app_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [app_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [app_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [app_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [app_db] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [app_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [app_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [app_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [app_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [app_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [app_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [app_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [app_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [app_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [app_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [app_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [app_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [app_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [app_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [app_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [app_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [app_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [app_db] SET  MULTI_USER 
GO
ALTER DATABASE [app_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [app_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [app_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [app_db] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [app_db]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 01/12/2020 21:03:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actor](
	[ActorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Actor] PRIMARY KEY CLUSTERED 
(
	[ActorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 01/12/2020 21:03:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[ContryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[ContryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Director]    Script Date: 01/12/2020 21:03:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Director](
	[DirectorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Director] PRIMARY KEY CLUSTERED 
(
	[DirectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gender]    Script Date: 01/12/2020 21:03:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[GenderId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Movie]    Script Date: 01/12/2020 21:03:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[GenderId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[ActorId] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](1024) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Post]    Script Date: 01/12/2020 21:03:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostId] [int] NULL,
	[UserId] [int] NULL,
	[Date] [datetime] NULL,
	[Description] [nchar](10) NULL,
	[Image] [nchar](10) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Actor] ON 

INSERT [dbo].[Actor] ([ActorId], [Name], [LastName], [CountryId], [Date]) VALUES (1, N'Cristian', N'Lopez', 1, NULL)
INSERT [dbo].[Actor] ([ActorId], [Name], [LastName], [CountryId], [Date]) VALUES (2, N'Julian', N'Bedoya', 2, NULL)
INSERT [dbo].[Actor] ([ActorId], [Name], [LastName], [CountryId], [Date]) VALUES (4, N'dd', N'dd', 1, NULL)
INSERT [dbo].[Actor] ([ActorId], [Name], [LastName], [CountryId], [Date]) VALUES (14, N'prueba ', N'grabacion', 0, NULL)
SET IDENTITY_INSERT [dbo].[Actor] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([ContryId], [Name], [Date]) VALUES (1, N'Colombia', NULL)
INSERT [dbo].[Country] ([ContryId], [Name], [Date]) VALUES (2, N'Estados Unidos', NULL)
INSERT [dbo].[Country] ([ContryId], [Name], [Date]) VALUES (10, N'pais grabacion', NULL)
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([GenderId], [Name], [Date]) VALUES (1, N'Terror', NULL)
INSERT [dbo].[Gender] ([GenderId], [Name], [Date]) VALUES (2, N'Suspenso', NULL)
INSERT [dbo].[Gender] ([GenderId], [Name], [Date]) VALUES (9, N'genero grabacion', NULL)
SET IDENTITY_INSERT [dbo].[Gender] OFF
SET IDENTITY_INSERT [dbo].[Movie] ON 

INSERT [dbo].[Movie] ([MovieId], [GenderId], [CountryId], [ActorId], [Title], [Description], [Date]) VALUES (4, 1, 1, 2, N'prueba', N'dssdasd', NULL)
INSERT [dbo].[Movie] ([MovieId], [GenderId], [CountryId], [ActorId], [Title], [Description], [Date]) VALUES (18, 9, 10, 14, N'Pelicula grabacion', N'Prueba grabacion video', NULL)
SET IDENTITY_INSERT [dbo].[Movie] OFF
INSERT [dbo].[Post] ([PostId], [UserId], [Date], [Description], [Image]) VALUES (2, 2, NULL, N'dsdsd     ', N'sdsad     ')
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Actor] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actor] ([ActorId])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_Actor]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([ContryId])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_Country]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([GenderId])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_Gender]
GO
USE [master]
GO
ALTER DATABASE [app_db] SET  READ_WRITE 
GO
