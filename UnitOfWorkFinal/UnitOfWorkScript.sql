USE [master]
GO
/****** Object:  Database [Shop]    Script Date: 10/04/2018 16:09:05 ******/
CREATE DATABASE [Shop] ON  PRIMARY 
( NAME = N'Shop', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Shop.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Shop_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Shop_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Shop] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Shop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Shop] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Shop] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Shop] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Shop] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Shop] SET ARITHABORT OFF
GO
ALTER DATABASE [Shop] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Shop] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Shop] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Shop] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Shop] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Shop] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Shop] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Shop] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Shop] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Shop] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Shop] SET  DISABLE_BROKER
GO
ALTER DATABASE [Shop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Shop] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Shop] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Shop] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Shop] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Shop] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Shop] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Shop] SET  READ_WRITE
GO
ALTER DATABASE [Shop] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Shop] SET  MULTI_USER
GO
ALTER DATABASE [Shop] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Shop] SET DB_CHAINING OFF
GO
USE [Shop]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 10/04/2018 16:09:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[OrderDate] [datetime] NULL,
	[ShippingDate] [datetime] NULL,
	[Note] [varchar](max) NOT NULL,
	[DueDate] [datetime] NULL,
	[Status] [bit] NOT NULL,
	[OrderTarget] [bigint] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/04/2018 16:09:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[ProductShopCategoryId] [bigint] NOT NULL,
	[Description] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdminTB]    Script Date: 10/04/2018 16:09:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdminTB](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](max) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductShop]    Script Date: 10/04/2018 16:09:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductShop](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[Price] [bigint] NULL,
	[InStock] [bit] NULL,
	[OutStock] [bit] NULL,
	[Status] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[MetaOptions] [varchar](max) NULL,
	[City] [varchar](max) NULL,
	[CategoryId] [bigint] NULL,
 CONSTRAINT [PK_ProductShop] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/04/2018 16:09:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[Price] [bigint] NULL,
	[InStock] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/04/2018 16:09:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[Email] [varchar](max) NOT NULL,
	[Mobile] [varchar](max) NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[Image] [varchar](max) NOT NULL,
	[HouseNo] [varchar](max) NOT NULL,
	[FloorNo] [varchar](max) NOT NULL,
	[RegistrationDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductShopCategory]    Script Date: 10/04/2018 16:09:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductShopCategory](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[CategoryId] [bigint] NOT NULL,
 CONSTRAINT [PK_ProductShopCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 10/04/2018 16:09:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NULL,
	[OrderId] [bigint] NOT NULL,
	[Price] [bigint] NOT NULL,
	[Qty] [bigint] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_ProductShopCategory_Category]    Script Date: 10/04/2018 16:09:05 ******/
ALTER TABLE [dbo].[ProductShopCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductShopCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[ProductShopCategory] CHECK CONSTRAINT [FK_ProductShopCategory_Category]
GO
/****** Object:  ForeignKey [FK_ProductShopCategory_ProductShop]    Script Date: 10/04/2018 16:09:05 ******/
ALTER TABLE [dbo].[ProductShopCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductShopCategory_ProductShop] FOREIGN KEY([ProductId])
REFERENCES [dbo].[ProductShop] ([Id])
GO
ALTER TABLE [dbo].[ProductShopCategory] CHECK CONSTRAINT [FK_ProductShopCategory_ProductShop]
GO
/****** Object:  ForeignKey [FK_OrderDetails_Order]    Script Date: 10/04/2018 16:09:05 ******/
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Order]
GO
/****** Object:  ForeignKey [FK_OrderDetails_ProductShop]    Script Date: 10/04/2018 16:09:05 ******/
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_ProductShop] FOREIGN KEY([ProductId])
REFERENCES [dbo].[ProductShop] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_ProductShop]
GO
