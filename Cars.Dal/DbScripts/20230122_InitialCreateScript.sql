USE [master]
GO
/****** Object:  Database [CarDb]    Script Date: 22.01.2023 23:16:52 ******/
CREATE DATABASE [CarDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CarDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CarDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CarDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarDb] SET RECOVERY FULL 
GO
ALTER DATABASE [CarDb] SET  MULTI_USER 
GO
ALTER DATABASE [CarDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CarDb', N'ON'
GO
ALTER DATABASE [CarDb] SET QUERY_STORE = OFF
GO
USE [CarDb]
GO
/****** Object:  User [IIS APPPOOL\CarAPI]    Script Date: 22.01.2023 23:16:52 ******/
CREATE USER [IIS APPPOOL\CarAPI] FOR LOGIN [IIS APPPOOL\CarAPI] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\Car]    Script Date: 22.01.2023 23:16:52 ******/
CREATE USER [IIS APPPOOL\Car] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [IIS APPPOOL\CarAPI]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [IIS APPPOOL\CarAPI]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\Car]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 22.01.2023 23:16:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Models]    Script Date: 22.01.2023 23:16:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Models](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[StartDate] [smallint] NOT NULL,
	[EndDate] [smallint] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Models] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Spesifications]    Script Date: 22.01.2023 23:16:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spesifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Spesifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransmissionTypes]    Script Date: 22.01.2023 23:16:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransmissionTypes](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_TransmissionTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Versions]    Script Date: 22.01.2023 23:16:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Versions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModelId] [int] NOT NULL,
	[TransmissionTypeId] [smallint] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Versions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VersionSpesifications]    Script Date: 22.01.2023 23:16:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VersionSpesifications](
	[VersionId] [int] NOT NULL,
	[SpesificationId] [int] NOT NULL,
 CONSTRAINT [PK_VersionSpesifications] PRIMARY KEY CLUSTERED 
(
	[VersionId] ASC,
	[SpesificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 
GO
INSERT [dbo].[Brands] ([Id], [Name], [IsActive], [IsDeleted]) VALUES (1, N'SEAT', 1, 0)
GO
INSERT [dbo].[Brands] ([Id], [Name], [IsActive], [IsDeleted]) VALUES (2, N'SKODA', 1, 0)
GO
INSERT [dbo].[Brands] ([Id], [Name], [IsActive], [IsDeleted]) VALUES (4, N'BMW', 1, 0)
GO
INSERT [dbo].[Brands] ([Id], [Name], [IsActive], [IsDeleted]) VALUES (6, N'AUDI', 1, 0)
GO
INSERT [dbo].[Brands] ([Id], [Name], [IsActive], [IsDeleted]) VALUES (7, N'MERCEDES', 1, 0)
GO
INSERT [dbo].[Brands] ([Id], [Name], [IsActive], [IsDeleted]) VALUES (8, N'RANGE ROVER', 1, 0)
GO
INSERT [dbo].[Brands] ([Id], [Name], [IsActive], [IsDeleted]) VALUES (9, N'RENAULT', 1, 0)
GO
INSERT [dbo].[Brands] ([Id], [Name], [IsActive], [IsDeleted]) VALUES (10, N'BUICK', 1, 0)
GO
INSERT [dbo].[Brands] ([Id], [Name], [IsActive], [IsDeleted]) VALUES (11, N'FIAT', 1, 0)
GO
INSERT [dbo].[Brands] ([Id], [Name], [IsActive], [IsDeleted]) VALUES (12, N'HONDA', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Models] ON 
GO
INSERT [dbo].[Models] ([Id], [BrandId], [Code], [Name], [StartDate], [EndDate], [IsActive], [IsDeleted]) VALUES (1, 1, N'LEON', N'LEON', 0, 0, 1, 0)
GO
INSERT [dbo].[Models] ([Id], [BrandId], [Code], [Name], [StartDate], [EndDate], [IsActive], [IsDeleted]) VALUES (2, 1, N'IBIZA', N'İBİZA', 0, 0, 1, 0)
GO
INSERT [dbo].[Models] ([Id], [BrandId], [Code], [Name], [StartDate], [EndDate], [IsActive], [IsDeleted]) VALUES (3, 1, N'CORDOBA', N'CORDOBA', 0, 0, 1, 0)
GO
INSERT [dbo].[Models] ([Id], [BrandId], [Code], [Name], [StartDate], [EndDate], [IsActive], [IsDeleted]) VALUES (4, 1, N'ALTEA', N'ALTEA', 0, 0, 1, 0)
GO
INSERT [dbo].[Models] ([Id], [BrandId], [Code], [Name], [StartDate], [EndDate], [IsActive], [IsDeleted]) VALUES (1002, 2, N'FABIA', N'FABİA', 0, 0, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Models] OFF
GO
SET IDENTITY_INSERT [dbo].[TransmissionTypes] ON 
GO
INSERT [dbo].[TransmissionTypes] ([Id], [Name], [IsActive], [IsDeleted]) VALUES (1, N'Otomatik', 1, 0)
GO
INSERT [dbo].[TransmissionTypes] ([Id], [Name], [IsActive], [IsDeleted]) VALUES (2, N'Yarı Otomatik', 1, 0)
GO
INSERT [dbo].[TransmissionTypes] ([Id], [Name], [IsActive], [IsDeleted]) VALUES (3, N'Manuel', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[TransmissionTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Versions] ON 
GO
INSERT [dbo].[Versions] ([Id], [ModelId], [TransmissionTypeId], [Name], [IsActive], [IsDeleted]) VALUES (1, 1, 1, N'1.6', 1, 0)
GO
INSERT [dbo].[Versions] ([Id], [ModelId], [TransmissionTypeId], [Name], [IsActive], [IsDeleted]) VALUES (2, 1, 3, N'1.6', 1, 0)
GO
INSERT [dbo].[Versions] ([Id], [ModelId], [TransmissionTypeId], [Name], [IsActive], [IsDeleted]) VALUES (3, 1, 1, N'1.6 TDI', 1, 0)
GO
INSERT [dbo].[Versions] ([Id], [ModelId], [TransmissionTypeId], [Name], [IsActive], [IsDeleted]) VALUES (4, 1, 3, N'1.6 TDI', 1, 0)
GO
INSERT [dbo].[Versions] ([Id], [ModelId], [TransmissionTypeId], [Name], [IsActive], [IsDeleted]) VALUES (5, 1, 1, N'1.4 TSI', 1, 0)
GO
INSERT [dbo].[Versions] ([Id], [ModelId], [TransmissionTypeId], [Name], [IsActive], [IsDeleted]) VALUES (6, 1, 3, N'1.4 TSI', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Versions] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Models_Code]    Script Date: 22.01.2023 23:16:52 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Models_Code] ON [dbo].[Models]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Models]  WITH CHECK ADD  CONSTRAINT [FK_Models_Brands] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
GO
ALTER TABLE [dbo].[Models] CHECK CONSTRAINT [FK_Models_Brands]
GO
ALTER TABLE [dbo].[Versions]  WITH CHECK ADD  CONSTRAINT [FK_Versions_Models] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Models] ([Id])
GO
ALTER TABLE [dbo].[Versions] CHECK CONSTRAINT [FK_Versions_Models]
GO
ALTER TABLE [dbo].[Versions]  WITH CHECK ADD  CONSTRAINT [FK_Versions_TransmissionTypes] FOREIGN KEY([TransmissionTypeId])
REFERENCES [dbo].[TransmissionTypes] ([Id])
GO
ALTER TABLE [dbo].[Versions] CHECK CONSTRAINT [FK_Versions_TransmissionTypes]
GO
ALTER TABLE [dbo].[VersionSpesifications]  WITH CHECK ADD  CONSTRAINT [FK_VersionSpesifications_Spesifications] FOREIGN KEY([SpesificationId])
REFERENCES [dbo].[Spesifications] ([Id])
GO
ALTER TABLE [dbo].[VersionSpesifications] CHECK CONSTRAINT [FK_VersionSpesifications_Spesifications]
GO
ALTER TABLE [dbo].[VersionSpesifications]  WITH CHECK ADD  CONSTRAINT [FK_VersionSpesifications_Versions] FOREIGN KEY([VersionId])
REFERENCES [dbo].[Versions] ([Id])
GO
ALTER TABLE [dbo].[VersionSpesifications] CHECK CONSTRAINT [FK_VersionSpesifications_Versions]
GO
USE [master]
GO
ALTER DATABASE [CarDb] SET  READ_WRITE 
GO
