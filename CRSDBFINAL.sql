USE [master]
GO
/****** Object:  Database [ComplainManagementDB]    Script Date: 10/20/2015 12:40:15 PM ******/
CREATE DATABASE [ComplainManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ComplainManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ComplainManagementDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ComplainManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ComplainManagementDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ComplainManagementDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ComplainManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ComplainManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ComplainManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ComplainManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ComplainManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ComplainManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ComplainManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ComplainManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [ComplainManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ComplainManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ComplainManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ComplainManagementDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ComplainManagementDB]
GO
/****** Object:  Table [dbo].[AssistantDetails]    Script Date: 10/20/2015 12:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssistantDetails](
	[AssistantID] [varchar](50) NOT NULL,
	[AsstName] [varchar](50) NULL,
	[ContactNo] [varchar](50) NULL,
	[AsstType] [varchar](50) NULL,
	[SolvingReq] [int] NULL,
	[PendingReq] [int] NULL,
 CONSTRAINT [PK_AssistantDetails] PRIMARY KEY CLUSTERED 
(
	[AssistantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Complain]    Script Date: 10/20/2015 12:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Complain](
	[ComplainID] [varchar](50) NOT NULL,
	[PersonName] [varchar](50) NULL,
	[HostelNo] [int] NULL,
	[RoomNo] [int] NULL,
	[Category] [varchar](50) NULL,
	[Subject] [varchar](50) NULL,
	[Summary] [varchar](2000) NULL,
	[Priority] [varchar](50) NULL,
	[DateOfComplain] [date] NULL,
	[Status] [varchar](50) NULL,
	[ContactNo] [varchar](50) NULL,
	[AssistantName] [varchar](50) NULL,
	[Remarks] [varchar](200) NULL,
	[AssistantContact] [int] NULL,
 CONSTRAINT [PK_Complain] PRIMARY KEY CLUSTERED 
(
	[ComplainID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 10/20/2015 12:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserAccount](
	[UserID] [varchar](50) NOT NULL,
	[UserType] [varchar](50) NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[ContactNo] [varchar](50) NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[AssistantDetails] ([AssistantID], [AsstName], [ContactNo], [AsstType], [SolvingReq], [PendingReq]) VALUES (N'10473', N'Babull', N'2353647', N'Cleaner', NULL, NULL)
INSERT [dbo].[AssistantDetails] ([AssistantID], [AsstName], [ContactNo], [AsstType], [SolvingReq], [PendingReq]) VALUES (N'85056', N'Babul', N'223456', N'Plumber', NULL, NULL)
INSERT [dbo].[AssistantDetails] ([AssistantID], [AsstName], [ContactNo], [AsstType], [SolvingReq], [PendingReq]) VALUES (N'85108', N'Magfur ur rahman', N'456756', N'Electrician', NULL, NULL)
INSERT [dbo].[AssistantDetails] ([AssistantID], [AsstName], [ContactNo], [AsstType], [SolvingReq], [PendingReq]) VALUES (N'C1', N'Nur Alam', N'0169459494', N'Cleaner', 2, 0)
INSERT [dbo].[AssistantDetails] ([AssistantID], [AsstName], [ContactNo], [AsstType], [SolvingReq], [PendingReq]) VALUES (N'ca', N'Mamun', N'223456', N'Carpenter', NULL, NULL)
INSERT [dbo].[AssistantDetails] ([AssistantID], [AsstName], [ContactNo], [AsstType], [SolvingReq], [PendingReq]) VALUES (N'car1', N'Mamun', N'334', N'Carpenter', NULL, NULL)
INSERT [dbo].[AssistantDetails] ([AssistantID], [AsstName], [ContactNo], [AsstType], [SolvingReq], [PendingReq]) VALUES (N'D12', N'Farid hossain', N'014534354676', N'Electrician', 3, 1)
INSERT [dbo].[AssistantDetails] ([AssistantID], [AsstName], [ContactNo], [AsstType], [SolvingReq], [PendingReq]) VALUES (N'E1', N'Jahid', N'0159388339', N'Electrician', 3, 1)
INSERT [dbo].[AssistantDetails] ([AssistantID], [AsstName], [ContactNo], [AsstType], [SolvingReq], [PendingReq]) VALUES (N'F1', N'Dulal', N'0188989999', N'Carpenter', 1, 2)
INSERT [dbo].[AssistantDetails] ([AssistantID], [AsstName], [ContactNo], [AsstType], [SolvingReq], [PendingReq]) VALUES (N'hyj45', N'rgtmmmm', N'dsfg899', N' Electrical', NULL, NULL)
INSERT [dbo].[AssistantDetails] ([AssistantID], [AsstName], [ContactNo], [AsstType], [SolvingReq], [PendingReq]) VALUES (N'P1', N'Farukh', N'0197364872', N'Plumber', 1, 2)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'15625', N'Dalim', 5, 301, N'Carpenter', N'Fan', N'rtgrjy', N'High', CAST(0x923A0B00 AS Date), N'New', N'3454647', NULL, N'10/20/2015 ( Complain Registered By Mr.Alamin)', NULL)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'23077', N'Arif', 2, 345, N'Electrical', N'fgf', N'dfgbfh', N'High', CAST(0x903A0B00 AS Date), N'Pending', N'345547', N'Farid hossain', N'10/20/2015:(Rono)rghj', NULL)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'38333', N'Babul', 5, 201, N'Electrical', N'Fan', N'Fan is not working', N'High', CAST(0x913A0B00 AS Date), N'Pending', N'097867664', N'Farid hossain', N'10/19/2015:(Rono)6h8hi6', NULL)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'42112', N'Minhaz', 3, 126, N'Electrical', N'Fan', N'yhtui8ui', N'High', CAST(0x8E3A0B00 AS Date), N'Closed', N'4356768', N'Farid', N'10/18/2015:(Rono)dfcfgdgh', NULL)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'44254', N'Mushfiqul', 1, 458, N'Plumbing', N'Fan', N'erghyh', N'High', CAST(0x8F3A0B00 AS Date), N'New', N'2356', NULL, N'(10/17/2015 10:11:37 AM)Complain Registerd By :Alamin', NULL)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'508', N'Mehedi', 1, 101, N'Electrical', N'bed', N'wrtrtyy', N'High', CAST(0x903A0B00 AS Date), N'New', N'45475789', NULL, N'(10/18/2015 8:58:43 PM)Complain Registerd By : Alamin(10/20/2015) By : Mr.(Rono) : Good Job', NULL)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'51118', N'Sayed', 5, 34, N'Electrical', N'erf', N'ertyh', N'High', CAST(0x8F3A0B00 AS Date), N'Solved', N'246', N'Farid', N'10/18/2015:(Rono)dfcfgdgh', NULL)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'52137', N'Mr.Raihan', 3, 234, N'Plumbing', N'Tep', N'4rtrytujk', N'High', CAST(0x8E3A0B00 AS Date), N'New', N'234567', NULL, NULL, NULL)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'54848', N'Sohel', 4, 239, N'Electrical', N'Besin', N'er gr th', N'High', CAST(0x8F3A0B00 AS Date), N'Solved', N'5657', N'Farid', N'10/18/2015:(  )erfryu', NULL)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'62634', N'sabbir', 4, 234, N'Carpenter', N'bed', N'dfsdghj', N'High', CAST(0x8F3A0B00 AS Date), N'New', N'676', NULL, N'(10/17/2015 10:41:29 AM)Complain Registerd By : Alamin', NULL)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'65846', N'Hamim', 5, 987, N'Plumbing', N'Tep', N'fgth', N'High', CAST(0x913A0B00 AS Date), N'New', N'e5t5y435647', NULL, N'10/19/2015 ( Complain Registered By Mr.Alamin)', NULL)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'78087', N'Ismail', 2, 11, N'Electrical', N'erty', N'sdfg', N'High', CAST(0x913A0B00 AS Date), N'New', N'23456', NULL, NULL, NULL)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'79061', N'Nahihan', 4, 457, N'Electrical', N'Toilet', N'wfrretvgt', N'High', CAST(0x8F3A0B00 AS Date), N'New', N'3456', NULL, N'(10/17/2015 10:43:34 AM)Complain Registerd By : Alamin', NULL)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'86829', N'Mizan', 2, 34, N'Cleaning', N'weqr', N'efwt', N'High', CAST(0x913A0B00 AS Date), N'New', N'qetey', NULL, N'10/19/2015 ( Complain Registered By Mr.Alamin)', NULL)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'88547', N'Shamal', 2, 111, N'Furniture', N'Table', N'bhnukhjk', N'Low', CAST(0x8F3A0B00 AS Date), N'New', N'24567', NULL, NULL, NULL)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'89679', N'Meskat', 5, 233, N'Plumbing', N'trfg', N'dghdh', N'Low', CAST(0x913A0B00 AS Date), N'New', N'478769', NULL, NULL, NULL)
INSERT [dbo].[Complain] ([ComplainID], [PersonName], [HostelNo], [RoomNo], [Category], [Subject], [Summary], [Priority], [DateOfComplain], [Status], [ContactNo], [AssistantName], [Remarks], [AssistantContact]) VALUES (N'97495', N'Mizan456', 2, 238, N'Cleaning', N'fan', N'fgvfhg', N'High', CAST(0x923A0B00 AS Date), N'New', N'467788', NULL, N'10/20/2015 ( Complain Registered By Mr.Alamin)', NULL)
INSERT [dbo].[UserAccount] ([UserID], [UserType], [UserName], [Password], [Email], [ContactNo]) VALUES (N'101', N'Hostel Manager', N'Rono', N'R1234', N'r@gmail.com', N'')
INSERT [dbo].[UserAccount] ([UserID], [UserType], [UserName], [Password], [Email], [ContactNo]) VALUES (N'102', N'Receptionist', N'Alamin', N'A1234', N'4567', N'a@yahoo.com')
INSERT [dbo].[UserAccount] ([UserID], [UserType], [UserName], [Password], [Email], [ContactNo]) VALUES (N'104', N'Receptionist', N'Munna', N'M1234', NULL, NULL)
INSERT [dbo].[UserAccount] ([UserID], [UserType], [UserName], [Password], [Email], [ContactNo]) VALUES (N'108', N'Hostel Manager', N'Sakib', N'S1234', N's@mail.com', N'45456')
INSERT [dbo].[UserAccount] ([UserID], [UserType], [UserName], [Password], [Email], [ContactNo]) VALUES (N'109', N'Hostel Manager', N'Mizan', N'm12345', N'm@gmail.com', N'01824567876')
INSERT [dbo].[UserAccount] ([UserID], [UserType], [UserName], [Password], [Email], [ContactNo]) VALUES (N'110', N'Hostel Manager', N'Hasib', N'h1234', N'h@yahoo.com', N'467788')
INSERT [dbo].[UserAccount] ([UserID], [UserType], [UserName], [Password], [Email], [ContactNo]) VALUES (N'111', N'Receptionist', N'Masud', N'm12345', N'm@gmail.com', N'4566')
INSERT [dbo].[UserAccount] ([UserID], [UserType], [UserName], [Password], [Email], [ContactNo]) VALUES (N'114', N'Receptionist', N'arafat', N'asdf', N'435634', N'a@mail.com')
INSERT [dbo].[UserAccount] ([UserID], [UserType], [UserName], [Password], [Email], [ContactNo]) VALUES (N'115', N'Receptionist', N'Tamim', N'475678', N't@gmail.com', N'456')
INSERT [dbo].[UserAccount] ([UserID], [UserType], [UserName], [Password], [Email], [ContactNo]) VALUES (N'116', N'Receptionist', N'werty', N'67899', N'W@erty', N'345678')
INSERT [dbo].[UserAccount] ([UserID], [UserType], [UserName], [Password], [Email], [ContactNo]) VALUES (N'117', N'Hostel Manager', N'Yousuf', N'y1234', N'y@yahoo.com', N'01719881135')
INSERT [dbo].[UserAccount] ([UserID], [UserType], [UserName], [Password], [Email], [ContactNo]) VALUES (N'118', N'Receptionist', N'Fahim', N'wert34567', N'f@gmail.com', N'01345678')
INSERT [dbo].[UserAccount] ([UserID], [UserType], [UserName], [Password], [Email], [ContactNo]) VALUES (N'119', N'Receptionist', N'adf', N'34536', N'sfg@', N'3456000')
INSERT [dbo].[UserAccount] ([UserID], [UserType], [UserName], [Password], [Email], [ContactNo]) VALUES (N'120', N'Hostel Manager', N'wtey', N'090', N'm@', N'3567')
INSERT [dbo].[UserAccount] ([UserID], [UserType], [UserName], [Password], [Email], [ContactNo]) VALUES (N'121', N'Receptionist', N'Rasel', N'346467', N'r@mail.com', N'45674')
USE [master]
GO
ALTER DATABASE [ComplainManagementDB] SET  READ_WRITE 
GO
