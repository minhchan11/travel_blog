USE [master]
GO
/****** Object:  Database [Travel]    Script Date: 4/19/2017 4:31:16 PM ******/
CREATE DATABASE [Travel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Travel', FILENAME = N'C:\Users\epicodus\Travel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Travel_log', FILENAME = N'C:\Users\epicodus\Travel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Travel] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Travel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Travel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Travel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Travel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Travel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Travel] SET ARITHABORT OFF 
GO
ALTER DATABASE [Travel] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Travel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Travel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Travel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Travel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Travel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Travel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Travel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Travel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Travel] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Travel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Travel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Travel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Travel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Travel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Travel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Travel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Travel] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Travel] SET  MULTI_USER 
GO
ALTER DATABASE [Travel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Travel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Travel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Travel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Travel] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Travel] SET QUERY_STORE = OFF
GO
USE [Travel]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Travel]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 4/19/2017 4:31:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[locations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [pk_locations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[persons]    Script Date: 4/19/2017 4:31:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persons](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](255) NOT NULL,
	[thingId] [int] NOT NULL,
 CONSTRAINT [pk_people] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[things]    Script Date: 4/19/2017 4:31:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[things](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](255) NOT NULL,
	[locationId] [int] NOT NULL,
 CONSTRAINT [pk_things] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[locations] ON 

INSERT [dbo].[locations] ([id], [name]) VALUES (1, N'Paris')
INSERT [dbo].[locations] ([id], [name]) VALUES (2, N'London')
INSERT [dbo].[locations] ([id], [name]) VALUES (3, N'Berlin')
INSERT [dbo].[locations] ([id], [name]) VALUES (4, N'Beijing')
SET IDENTITY_INSERT [dbo].[locations] OFF
SET IDENTITY_INSERT [dbo].[persons] ON 

INSERT [dbo].[persons] ([id], [name], [thingId]) VALUES (3, N'John                                                                                                                                                                                                                                                           ', 1)
INSERT [dbo].[persons] ([id], [name], [thingId]) VALUES (4, N'Mary                                                                                                                                                                                                                                                           ', 2)
INSERT [dbo].[persons] ([id], [name], [thingId]) VALUES (9, N'Peter                                                                                                                                                                                                                                                          ', 4)
INSERT [dbo].[persons] ([id], [name], [thingId]) VALUES (10, N'Mai                                                                                                                                                                                                                                                            ', 5)
INSERT [dbo].[persons] ([id], [name], [thingId]) VALUES (11, N'Larry                                                                                                                                                                                                                                                          ', 1)
INSERT [dbo].[persons] ([id], [name], [thingId]) VALUES (13, N'Jim                                                                                                                                                                                                                                                            ', 2)
INSERT [dbo].[persons] ([id], [name], [thingId]) VALUES (14, N'Michelle                                                                                                                                                                                                                                                       ', 4)
INSERT [dbo].[persons] ([id], [name], [thingId]) VALUES (15, N'Yves                                                                                                                                                                                                                                                           ', 5)
SET IDENTITY_INSERT [dbo].[persons] OFF
SET IDENTITY_INSERT [dbo].[things] ON 

INSERT [dbo].[things] ([id], [name], [locationId]) VALUES (1, N'Take pics                                                                                                                                                                                                                                                      ', 1)
INSERT [dbo].[things] ([id], [name], [locationId]) VALUES (2, N'Eat food                                                                                                                                                                                                                                                       ', 2)
INSERT [dbo].[things] ([id], [name], [locationId]) VALUES (4, N'See Mountains                                                                                                                                                                                                                                                  ', 1)
INSERT [dbo].[things] ([id], [name], [locationId]) VALUES (5, N'See Beaches                                                                                                                                                                                                                                                    ', 2)
INSERT [dbo].[things] ([id], [name], [locationId]) VALUES (6, N'Meet new friends                                                                                                                                                                                                                                               ', 3)
INSERT [dbo].[things] ([id], [name], [locationId]) VALUES (7, N'Meet old friends                                                                                                                                                                                                                                               ', 3)
INSERT [dbo].[things] ([id], [name], [locationId]) VALUES (9, N'Go clubbing                                                                                                                                                                                                                                                    ', 4)
INSERT [dbo].[things] ([id], [name], [locationId]) VALUES (11, N'Go hiking                                                                                                                                                                                                                                                      ', 4)
SET IDENTITY_INSERT [dbo].[things] OFF
ALTER TABLE [dbo].[persons]  WITH CHECK ADD  CONSTRAINT [fk_people_things] FOREIGN KEY([thingId])
REFERENCES [dbo].[things] ([id])
GO
ALTER TABLE [dbo].[persons] CHECK CONSTRAINT [fk_people_things]
GO
ALTER TABLE [dbo].[things]  WITH CHECK ADD  CONSTRAINT [fk_things_locations] FOREIGN KEY([locationId])
REFERENCES [dbo].[locations] ([id])
GO
ALTER TABLE [dbo].[things] CHECK CONSTRAINT [fk_things_locations]
GO
USE [master]
GO
ALTER DATABASE [Travel] SET  READ_WRITE 
GO
