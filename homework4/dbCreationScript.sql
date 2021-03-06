USE [master]
GO
/****** Object:  Database [homework4]    Script Date: 04.03.2020 22:35:43 ******/
CREATE DATABASE [homework4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'homework4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\homework4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'homework4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\homework4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [homework4] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [homework4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [homework4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [homework4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [homework4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [homework4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [homework4] SET ARITHABORT OFF 
GO
ALTER DATABASE [homework4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [homework4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [homework4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [homework4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [homework4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [homework4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [homework4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [homework4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [homework4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [homework4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [homework4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [homework4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [homework4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [homework4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [homework4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [homework4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [homework4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [homework4] SET RECOVERY FULL 
GO
ALTER DATABASE [homework4] SET  MULTI_USER 
GO
ALTER DATABASE [homework4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [homework4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [homework4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [homework4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [homework4] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'homework4', N'ON'
GO
ALTER DATABASE [homework4] SET QUERY_STORE = OFF
GO
USE [homework4]
GO
/****** Object:  Table [dbo].[EmployeeProjectPosition]    Script Date: 04.03.2020 22:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeProjectPosition](
	[id] [int] NOT NULL,
	[project_id] [int] NULL,
	[employee_id] [int] NULL,
	[position_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 04.03.2020 22:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[id] [int] NOT NULL,
	[FirstName] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 04.03.2020 22:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[id] [int] NOT NULL,
	[Name] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 04.03.2020 22:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[id] [int] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[CreationDate] [datetime] NULL,
	[isOpen] [bit] NOT NULL,
	[EndDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 04.03.2020 22:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[id] [int] NOT NULL,
	[Status] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status_Task_Info]    Script Date: 04.03.2020 22:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status_Task_Info](
	[id] [int] NOT NULL,
	[Status_id] [int] NULL,
	[StatusDate] [datetime] NULL,
	[Supervisor_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 04.03.2020 22:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[id] [int] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[DeadlineDate] [datetime] NULL,
	[EPP_id] [int] NULL,
	[Status_Info_id] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[EmployeeProjectPosition] ([id], [project_id], [employee_id], [position_id]) VALUES (1, 1, 4, 2)
INSERT [dbo].[EmployeeProjectPosition] ([id], [project_id], [employee_id], [position_id]) VALUES (2, 2, 4, 6)
INSERT [dbo].[EmployeeProjectPosition] ([id], [project_id], [employee_id], [position_id]) VALUES (3, 1, 7, 1)
INSERT [dbo].[EmployeeProjectPosition] ([id], [project_id], [employee_id], [position_id]) VALUES (4, 2, 8, 5)
INSERT [dbo].[Employees] ([id], [FirstName], [LastName]) VALUES (4, N'Vsevolod', N'Slavinsyi')
INSERT [dbo].[Employees] ([id], [FirstName], [LastName]) VALUES (5, N'Alex', N'Kozin')
INSERT [dbo].[Employees] ([id], [FirstName], [LastName]) VALUES (6, N'Sveta', N' Mul')
INSERT [dbo].[Employees] ([id], [FirstName], [LastName]) VALUES (7, N'Bogdan', N'Lysov')
INSERT [dbo].[Employees] ([id], [FirstName], [LastName]) VALUES (8, N'Dmytro', N'Ignatov')
INSERT [dbo].[Employees] ([id], [FirstName], [LastName]) VALUES (9, N'Petro', N'Dragin')
INSERT [dbo].[Positions] ([id], [Name]) VALUES (1, N'HR')
INSERT [dbo].[Positions] ([id], [Name]) VALUES (2, N'Junior Programmer')
INSERT [dbo].[Positions] ([id], [Name]) VALUES (3, N'Middle Programmer')
INSERT [dbo].[Positions] ([id], [Name]) VALUES (4, N'Senior Programmer')
INSERT [dbo].[Positions] ([id], [Name]) VALUES (5, N'PM')
INSERT [dbo].[Positions] ([id], [Name]) VALUES (6, N'Analyst')
INSERT [dbo].[Positions] ([id], [Name]) VALUES (7, N'Lab Head')
INSERT [dbo].[Projects] ([id], [Name], [CreationDate], [isOpen], [EndDate]) VALUES (1, N'Proj1', CAST(N'2014-05-04T00:00:00.000' AS DateTime), 1, CAST(N'2019-01-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Projects] ([id], [Name], [CreationDate], [isOpen], [EndDate]) VALUES (2, N'Proj2', CAST(N'2020-11-15T00:00:00.000' AS DateTime), 0, CAST(N'2020-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Projects] ([id], [Name], [CreationDate], [isOpen], [EndDate]) VALUES (3, N'Proj3', CAST(N'2018-07-20T00:00:00.000' AS DateTime), 0, CAST(N'2022-07-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Projects] ([id], [Name], [CreationDate], [isOpen], [EndDate]) VALUES (4, N'Proj4', CAST(N'2014-05-01T00:00:00.000' AS DateTime), 1, CAST(N'2015-01-08T00:00:00.000' AS DateTime))
INSERT [dbo].[Projects] ([id], [Name], [CreationDate], [isOpen], [EndDate]) VALUES (5, N'Proj5', CAST(N'2017-06-13T00:00:00.000' AS DateTime), 0, CAST(N'2025-02-24T00:00:00.000' AS DateTime))
INSERT [dbo].[Projects] ([id], [Name], [CreationDate], [isOpen], [EndDate]) VALUES (6, N'Proj6', CAST(N'2017-11-18T00:00:00.000' AS DateTime), 1, CAST(N'2019-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Projects] ([id], [Name], [CreationDate], [isOpen], [EndDate]) VALUES (7, N'Proj7', CAST(N'2011-12-12T00:00:00.000' AS DateTime), 0, CAST(N'2020-11-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Projects] ([id], [Name], [CreationDate], [isOpen], [EndDate]) VALUES (8, NULL, NULL, 0, NULL)
INSERT [dbo].[Status] ([id], [Status]) VALUES (1, N'Open')
INSERT [dbo].[Status] ([id], [Status]) VALUES (2, N'Done')
INSERT [dbo].[Status] ([id], [Status]) VALUES (3, N'In process')
INSERT [dbo].[Status] ([id], [Status]) VALUES (4, N'Closed')
INSERT [dbo].[Status_Task_Info] ([id], [Status_id], [StatusDate], [Supervisor_id]) VALUES (1, 1, CAST(N'2020-02-28T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Status_Task_Info] ([id], [Status_id], [StatusDate], [Supervisor_id]) VALUES (2, 2, CAST(N'2020-03-23T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Status_Task_Info] ([id], [Status_id], [StatusDate], [Supervisor_id]) VALUES (3, 4, CAST(N'2020-01-22T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Status_Task_Info] ([id], [Status_id], [StatusDate], [Supervisor_id]) VALUES (4, 4, CAST(N'2020-02-07T00:00:00.000' AS DateTime), 6)
INSERT [dbo].[Tasks] ([id], [Name], [Description], [DeadlineDate], [EPP_id], [Status_Info_id]) VALUES (1, N'DAL creation', N'A lot of information', CAST(N'2020-04-11T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Tasks] ([id], [Name], [Description], [DeadlineDate], [EPP_id], [Status_Info_id]) VALUES (2, N'BLL creation', N'Another information', CAST(N'2020-04-19T00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[Tasks] ([id], [Name], [Description], [DeadlineDate], [EPP_id], [Status_Info_id]) VALUES (3, N'DB analyse', N'lallala', CAST(N'2018-03-06T00:00:00.000' AS DateTime), 2, 3)
INSERT [dbo].[Tasks] ([id], [Name], [Description], [DeadlineDate], [EPP_id], [Status_Info_id]) VALUES (4, N'Find people for project', N'llalalalalala', CAST(N'2011-03-06T00:00:00.000' AS DateTime), 3, 4)
USE [master]
GO
ALTER DATABASE [homework4] SET  READ_WRITE 
GO
