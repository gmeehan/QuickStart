USE [master]
GO

/****** Object:  Database [QuickStart_DB]    Script Date: 11/09/2012 11:56:50 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'QuickStart_DB')
DROP DATABASE [QuickStart_DB]
GO

USE [master]
GO

/****** Object:  Database [QuickStart_DB]    Script Date: 11/09/2012 11:56:50 ******/

CREATE DATABASE [QuickStart_DB] ON  PRIMARY 
( NAME = N'QuickStart_DB', FILENAME = N'E:\Websites\QuickStart\QSR Database\QuickStart_DB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuickStart_DB_log', FILENAME = N'E:\Websites\QuickStart\QSR Database\QuickStart_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [QuickStart_DB] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuickStart_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [QuickStart_DB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [QuickStart_DB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [QuickStart_DB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [QuickStart_DB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [QuickStart_DB] SET ARITHABORT OFF 
GO

ALTER DATABASE [QuickStart_DB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [QuickStart_DB] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [QuickStart_DB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [QuickStart_DB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [QuickStart_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [QuickStart_DB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [QuickStart_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [QuickStart_DB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [QuickStart_DB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [QuickStart_DB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [QuickStart_DB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [QuickStart_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [QuickStart_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [QuickStart_DB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [QuickStart_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [QuickStart_DB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [QuickStart_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [QuickStart_DB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [QuickStart_DB] SET  READ_WRITE 
GO

ALTER DATABASE [QuickStart_DB] SET RECOVERY FULL 
GO

ALTER DATABASE [QuickStart_DB] SET  MULTI_USER 
GO

ALTER DATABASE [QuickStart_DB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [QuickStart_DB] SET DB_CHAINING OFF 
GO


USE [QuickStart_DB]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/09/2012 11:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](30) NULL,
	[Password] [varchar](30) NULL,
	[Salutation] [varchar](30) NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](30) NULL,
	[Address1] [varchar](30) NULL,
	[Address2] [varchar](30) NULL,
	[City] [varchar](30) NULL,
	[StateProvinceID] [int] NULL,
	[ZipPostalCode] [varchar](9) NULL,
	[Email] [varchar](30) NULL,
	[IsReceiveNewsletters] [bit] NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Salutation], [FirstName], [LastName], [Address1], [Address2], [City], [StateProvinceID], [ZipPostalCode], [Email], [IsReceiveNewsletters], [Created], [Modified]) VALUES (1, N'gmeehan', N'gmeehan', N'Mr.', N'Graham', N'Meehan', N'123 Test Street', NULL, N'London', 9, N'N6E 2N9', N'graham_meehan@hotmail.com', 0, CAST(0x0000A0F801156A47 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Table [dbo].[StatesProvinces]    Script Date: 11/09/2012 11:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StatesProvinces](
	[StateProvinceID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NULL,
	[Country] [varchar](20) NULL,
	[CurrencyCode] [varchar](3) NULL,
	[TaxRatePercentage] [float] NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_StatesProvinces] PRIMARY KEY CLUSTERED 
(
	[StateProvinceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[StatesProvinces] ON
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (1, N'Alberta', N'Canada', N'CAD', 5, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (2, N'British Colombia', N'Canada', N'CAD', 12, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (3, N'Manitoba', N'Canada', N'CAD', 12, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (4, N'New Brunswick', N'Canada', N'CAD', 13, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (5, N'Newfoundland and Labrador', N'Canada', N'CAD', 13, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (6, N'Northwest Territories', N'Canada', N'CAD', 5, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (7, N'Nova Scotia', N'Canada', N'CAD', 15, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (8, N'Nunavut', N'Canada', N'CAD', 5, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (9, N'Ontario', N'Canada', N'CAD', 13, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (10, N'Prince Edward Island', N'Canada', N'CAD', 15, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (11, N'Quebec', N'Canada', N'CAD', 14.5, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (12, N'Saskatchewan', N'Canada', N'CAD', 10, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (13, N'Yukon', N'Canada', N'CAD', 5, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (14, N'Alabama', N'United States', N'USD', 4, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (15, N'Alaska', N'United States', N'USD', 0, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (16, N'American Samoa', N'United States', N'USD', 0, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (17, N'Arizona', N'United States', N'USD', 7.3, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (18, N'Arkansas', N'United States', N'USD', 6, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (19, N'California', N'United States', N'USD', 7.25, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (20, N'Colorado', N'United States', N'USD', 2.9, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (21, N'Conneticut', N'United States', N'USD', 6.35, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (22, N'Delaware', N'United States', N'USD', 0, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (23, N'District of Columbia', N'United States', N'USD', 6, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (24, N'Federated States of Micronesia', N'United States', N'USD', 5, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (25, N'Florida', N'United States', N'USD', 6, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (26, N'Georgia', N'United States', N'USD', 4, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (27, N'Guam Gu', N'United States', N'USD', 4, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (28, N'Hawaii', N'United States', N'USD', 4, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (29, N'Idaho', N'United States', N'USD', 6, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (30, N'Illinois', N'United States', N'USD', 6.25, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (31, N'Indiana', N'United States', N'USD', 7, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (32, N'Iowa', N'United States', N'USD', 6, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (33, N'Kansas', N'United States', N'USD', 6.3, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (34, N'Kentucky', N'United States', N'USD', 6, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (35, N'Louisiana', N'United States', N'USD', 4, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (36, N'Maine', N'United States', N'USD', 5, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (37, N'Marshall Islands', N'United States', N'USD', 4, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (38, N'Maryland', N'United States', N'USD', 6, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (39, N'Massachusetts', N'United States', N'USD', 6.25, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (40, N'Michigan', N'United States', N'USD', 6, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (41, N'Minnesota', N'United States', N'USD', 6.875, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (42, N'Mississippi', N'United States', N'USD', 7, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (43, N'Missouri', N'United States', N'USD', 4.225, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (44, N'Montana', N'United States', N'USD', 0, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (45, N'Nebraska', N'United States', N'USD', 5.5, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (46, N'Nevada', N'United States', N'USD', 6.85, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (47, N'New Hampshire', N'United States', N'USD', 0, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (48, N'New Jersey', N'United States', N'USD', 7, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (49, N'New Mexico', N'United States', N'USD', 5.125, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (50, N'New York', N'United States', N'USD', 4, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (51, N'North Carolina', N'United States', N'USD', 4.75, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (52, N'North Dakota', N'United States', N'USD', 5, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (53, N'Northern Mariana Islands', N'United States', N'USD', 5, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (54, N'Ohio', N'United States', N'USD', 5.5, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (55, N'Oklahoma', N'United States', N'USD', 4.5, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (56, N'Oregon', N'United States', N'USD', 0, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (57, N'Palau', N'United States', N'USD', 4, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (58, N'Pennsylvania', N'United States', N'USD', 6, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (59, N'Puerto Rico', N'United States', N'USD', 5.5, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (60, N'Rhode Island', N'United States', N'USD', 7, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (61, N'South Carolina', N'United States', N'USD', 6, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (62, N'South Dakota', N'United States', N'USD', 4, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (63, N'Tennessee', N'United States', N'USD', 7, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (64, N'Texas', N'United States', N'USD', 6.25, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (65, N'Utah', N'United States', N'USD', 5.95, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (66, N'Vermont', N'United States', N'USD', 6, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (67, N'Virgin Islands', N'United States', N'USD', 0, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (68, N'Virginia', N'United States', N'USD', 5, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (69, N'Washington', N'United States', N'USD', 6.5, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (70, N'West Virginia', N'United States', N'USD', 6, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (71, N'Wisconsin', N'United States', N'USD', 5, NULL)
INSERT [dbo].[StatesProvinces] ([StateProvinceID], [Name], [Country], [CurrencyCode], [TaxRatePercentage], [Modified]) VALUES (72, N'Wyoming', N'United States', N'USD', 4, NULL)
SET IDENTITY_INSERT [dbo].[StatesProvinces] OFF
/****** Object:  Table [dbo].[Products]    Script Date: 11/09/2012 11:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[ProductCode] [varchar](10) NOT NULL,
	[Name] [varchar](50) NULL,
	[Brand] [varchar](50) NULL,
	[Description] [varchar](200) NULL,
	[CategoryID] [int] NOT NULL,
	[MSRP] [float] NOT NULL,
	[isFreeShipping] [bit] NOT NULL,
	[isTaxFree] [bit] NOT NULL,
	[QuantityInStock] [int] NOT NULL,
	[IsQuantityUnlimited] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_Products_1] PRIMARY KEY CLUSTERED 
(
	[ProductCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'0QEN0BL4OH', N'40" Plasma Television', N'Toshiba', N'Large TV, Great Value', 23, 599.99, 1, 0, 6, 0, CAST(0x0000A102013676A6 AS DateTime), CAST(0x0000A10300DD7168 AS DateTime), 1)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'4Q8UMWUV3B', N'Solid Steel Refridgerator', N'General Electric', NULL, 7, 299.99, 0, 0, 3, 0, CAST(0x0000A0F300DD4DAD AS DateTime), CAST(0x0000A10300CE77FE AS DateTime), 1)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'51PBBCMUQF', N'3D Blueray Player', N'Samsung', NULL, 0, 499.99, 0, 0, 0, 0, CAST(0x0000A0F300DD2AA5 AS DateTime), NULL, 1)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'8XGWBVIZ5K', N'IPod Nano', N'Apple', NULL, 27, 899.99, 0, 0, 0, 0, CAST(0x0000A0F300DD2683 AS DateTime), NULL, 1)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'DIF0G5NJWL', N'IPod Touch', N'Apple', NULL, 27, 699.99, 0, 0, 0, 0, CAST(0x0000A0F300DD56A1 AS DateTime), NULL, 1)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'FAULJR8RBI', N'Xbox 360 Console 250GB', N'Microsoft', NULL, 12, 99.99, 0, 0, 0, 0, CAST(0x0000A0F300DD60A1 AS DateTime), NULL, 1)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'G34ASD3455', N'50" LCD Television', N'Panasonic', N'Large, Glare-Resistant Screen', 23, 899.99, 0, 0, 4, 0, CAST(0x0000A10400B54192 AS DateTime), CAST(0x0000A10400B55E8A AS DateTime), 1)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'GDSFG23423', N'44" 3D LCD Television', N'Panasonic', N'The best 3D viewing experience!', 23, 649.99, 0, 0, 6, 0, CAST(0x0000A10400B5EBE2 AS DateTime), NULL, 1)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'GSADF324GF', N'MyTestProduct', N'MyTestBrand', N'This is for testing AddProduct', 7, 299.99, 1, 0, 6, 0, CAST(0x0000A10300DCA471 AS DateTime), CAST(0x0000A10300DCBC7E AS DateTime), 0)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'H6RF27H46H', N'Playstation 3', N'Sony', NULL, 13, 199.99, 0, 0, 0, 0, CAST(0x0000A0F300DCDFDD AS DateTime), NULL, 1)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'HF234JHAWE', N'60" LCD Television', N'Sharp', N'The largest, clearest screen!', 23, 1099.99, 0, 0, 6, 0, CAST(0x0000A10400B64483 AS DateTime), NULL, 1)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'I7HTIILG3X', N'Compact Digital Camera', N'Nikon', NULL, 16, 199.99, 0, 0, 0, 0, CAST(0x0000A0F300DD529A AS DateTime), NULL, 1)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'IVVXPUY5IP', N'3D Camcorder', N'Nikon', NULL, 18, 999.99, 0, 0, 0, 0, CAST(0x0000A0F300DD2EE9 AS DateTime), NULL, 1)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'MKNSDPYHFV', N'17" Gaming Laptop', N'Alienware', NULL, 0, 299.99, 0, 0, 0, 0, CAST(0x0000A0F300DD6A90 AS DateTime), NULL, 1)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'QWN1MDYDKP', N'Blue Gaming Mouse', N'NextTech', NULL, 0, 499.99, 0, 0, 0, 0, CAST(0x0000A0F300DD4303 AS DateTime), NULL, 1)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'U68J39BVNF', N'44" LCD Television', N'Sharp', NULL, 23, 599.99, 0, 0, 0, 0, CAST(0x0000A0F300DD64C5 AS DateTime), NULL, 1)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'UVP9TQMFGC', N'8" Digital Frame', N'Nikon', NULL, 19, 799.99, 0, 0, 0, 0, CAST(0x0000A0F300DD2287 AS DateTime), NULL, 1)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified], [isActive]) VALUES (N'XBL5MU5CM1', N'10" Digital Frame', N'Nikon', NULL, 19, 899.99, 0, 0, 0, 0, CAST(0x0000A0F300DD48A9 AS DateTime), NULL, 1)
/****** Object:  Table [dbo].[ProductDeliveryTypes]    Script Date: 11/09/2012 11:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDeliveryTypes](
	[ProductDeliveryTypeID] [int] IDENTITY(1,1) NOT NULL,
	[DeliveryTypeID] [int] NULL,
	[ProductCode] varchar(10) NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_ProductDelivery] PRIMARY KEY CLUSTERED 
(
	[ProductDeliveryTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/09/2012 11:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Subtotal] [float] NULL,
	[Taxes] [float] NULL,
	[DeliveryCost] [float] NULL,
	[DeliveryTypeID] [int] NULL,
	[GrandTotal] [float] NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 11/09/2012 11:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderItems](
	[OrderItemID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[ProductCode] [varchar](10) NULL,
	[Quantity] [int] NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[OrderItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LangLabels]    Script Date: 11/09/2012 11:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LangLabels](
	[LangLabelCode] [varchar](30) NOT NULL,
	[Value] [varchar](100) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_LangLabels] PRIMARY KEY CLUSTERED 
(
	[LangLabelCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DeliveryType]    Script Date: 11/09/2012 11:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DeliveryType](
	[DeliveryTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NULL,
	[Description] [varchar](50) NULL,
	[Cost] [float] NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_DeliveryType] PRIMARY KEY CLUSTERED 
(
	[DeliveryTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[DeliveryType] ON
INSERT [dbo].[DeliveryType] ([DeliveryTypeID], [Name], [Description], [Cost], [Created], [Modified]) VALUES (1, N'General Mail', N'Purchasel is sent through standard mail system.', 15, CAST(0x0000A0F200EC6321 AS DateTime), NULL)
INSERT [dbo].[DeliveryType] ([DeliveryTypeID], [Name], [Description], [Cost], [Created], [Modified]) VALUES (2, N'Express Mail', N'Purchase is sent through express delivery', 30, CAST(0x0000A0F200EC6321 AS DateTime), NULL)
INSERT [dbo].[DeliveryType] ([DeliveryTypeID], [Name], [Description], [Cost], [Created], [Modified]) VALUES (3, N'Electronic', N'Purchase is sent via e-mail', 0, CAST(0x0000A0F200EC6321 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[DeliveryType] OFF
/****** Object:  Table [dbo].[Configurations]    Script Date: 11/09/2012 11:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Configurations](
	[ConfigurationCode] [varchar](20) NOT NULL,
	[Description] [varchar](200) NULL,
	[Value] [varchar](100) NULL,
	[IsYesNoValue] [bit] NULL,
	[YesNoValue] [bit] NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_Configurations] PRIMARY KEY CLUSTERED 
(
	[ConfigurationCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/09/2012 11:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NULL,
	[Description] [varchar](200) NULL,
	[ParentCategoryID] [int] NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (1, N'Appliances', N'Household appliances', 0, CAST(0x0000A0F200E3B431 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (2, N'Gaming', N'Console, PC and Handheld gaming', 0, CAST(0x0000A0F200E3B431 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (3, N'Cameras & Camcorders', N'Cameras, camcorders and accessories', 0, CAST(0x0000A0F200E404BF AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (4, N'Music and Movies', N'CD Albums, DVDs and more', 0, CAST(0x0000A0F200E4783E AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (5, N'TV & Home Theatre', N'TV, home theatre and accessories', 0, CAST(0x0000A0F200E4D6A1 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (6, N'MP3 Players and Headphones', N'MP3 Players, IPods, heaphones and accessories', 0, CAST(0x0000A0F200E4E84B AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (7, N'Refridgerators', NULL, 1, CAST(0x0000A0F200E65287 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (8, N'Dishwashers', NULL, 1, CAST(0x0000A0F200E66C1A AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (9, N'Microwaves', NULL, 1, CAST(0x0000A0F200E6AE9F AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (10, N'Blenders', NULL, 1, CAST(0x0000A0F200E6D0D5 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (11, N'Stoves', NULL, 1, CAST(0x0000A0F200E6F367 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (12, N'Xbox 360', NULL, 2, CAST(0x0000A0F200E74FD1 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (13, N'Playstation 3', NULL, 2, CAST(0x0000A0F200E77CC5 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (14, N'Nintendo Wii', NULL, 2, CAST(0x0000A0F200E7E546 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (15, N'Playstation PSP', NULL, 2, CAST(0x0000A0F200E80E32 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (16, N'Digital Cameras', NULL, 3, CAST(0x0000A0F200E82730 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (17, N'Film Cameras', NULL, 3, CAST(0x0000A0F200E86015 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (18, N'Camcorders', NULL, 3, CAST(0x0000A0F200E87F31 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (19, N'Digital Picture Frames', NULL, 3, CAST(0x0000A0F200E899C4 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (20, N'Music', NULL, 4, CAST(0x0000A0F200E92A03 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (21, N'Movies', NULL, 4, CAST(0x0000A0F200E9D329 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (22, N'TV Shows', NULL, 4, CAST(0x0000A0F200E9F1E3 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (23, N'TVs', NULL, 5, CAST(0x0000A0F200EA321F AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (24, N'Audio', NULL, 5, CAST(0x0000A0F200EA4DE0 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (25, N'Wall Mounts and Stands', NULL, 5, CAST(0x0000A0F200EA86A8 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (26, N'MP3 Players', NULL, 6, CAST(0x0000A0F200EAE696 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (27, N'IPods', NULL, 6, CAST(0x0000A0F200EB0516 AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Description], [ParentCategoryID], [Created], [Modified], [IsActive]) VALUES (28, N'IPod Accessories', NULL, 6, CAST(0x0000A0F200EB171F AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
/****** Object:  Table [dbo].[AuditTypes]    Script Date: 11/09/2012 11:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AuditTypes](
	[AuditTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_AuditTypes] PRIMARY KEY CLUSTERED 
(
	[AuditTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Audits]    Script Date: 11/09/2012 11:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Audits](
	[AuditID] [int] IDENTITY(1,1) NOT NULL,
	[AuditTypeID] [int] NULL,
	[UserID] [int] NULL,
	[AdminID] [int] NULL,
	[Notes] [varchar](200) NULL,
	[Created] [datetime] NULL,
 CONSTRAINT [PK_Audits] PRIMARY KEY CLUSTERED 
(
	[AuditID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Administrators]    Script Date: 11/09/2012 11:57:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Administrators](
	[AdministratorID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](30) NULL,
	[Password] [varchar](30) NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](30) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Administrators] PRIMARY KEY CLUSTERED 
(
	[AdministratorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Administrators] ON
INSERT [dbo].[Administrators] ([AdministratorID], [Username], [Password], [FirstName], [LastName], [IsActive]) VALUES (2, N'admin', N'admin', N'Graham', N'Meehan', 1)
SET IDENTITY_INSERT [dbo].[Administrators] OFF
/****** Object:  Default [DF_Audits_Created]    Script Date: 11/09/2012 11:57:37 ******/
ALTER TABLE [dbo].[Audits] ADD  CONSTRAINT [DF_Audits_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_Categories_Created]    Script Date: 11/09/2012 11:57:37 ******/
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_Categories_IsActive]    Script Date: 11/09/2012 11:57:37 ******/
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_DeliveryType_Created]    Script Date: 11/09/2012 11:57:37 ******/
ALTER TABLE [dbo].[DeliveryType] ADD  CONSTRAINT [DF_DeliveryType_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_OrderItems_Created]    Script Date: 11/09/2012 11:57:37 ******/
ALTER TABLE [dbo].[OrderItems] ADD  CONSTRAINT [DF_OrderItems_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_Orders_Created]    Script Date: 11/09/2012 11:57:37 ******/
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_ProductDeliveryTypes_Created]    Script Date: 11/09/2012 11:57:37 ******/
ALTER TABLE [dbo].[ProductDeliveryTypes] ADD  CONSTRAINT [DF_ProductDeliveryTypes_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_Products_CategoryID]    Script Date: 11/09/2012 11:57:37 ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_CategoryID]  DEFAULT ((0)) FOR [CategoryID]
GO
/****** Object:  Default [DF_Products_MSRP]    Script Date: 11/09/2012 11:57:37 ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_MSRP]  DEFAULT ((0.00)) FOR [MSRP]
GO
/****** Object:  Default [DF_Products_isFreeShipping]    Script Date: 11/09/2012 11:57:37 ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_isFreeShipping]  DEFAULT ((0)) FOR [isFreeShipping]
GO
/****** Object:  Default [DF_Products_isTaxFree]    Script Date: 11/09/2012 11:57:37 ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_isTaxFree]  DEFAULT ((0)) FOR [isTaxFree]
GO
/****** Object:  Default [DF_Products_QuantityInStock]    Script Date: 11/09/2012 11:57:37 ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_QuantityInStock]  DEFAULT ((0)) FOR [QuantityInStock]
GO
/****** Object:  Default [DF_Products_IsQuantityUnlimited]    Script Date: 11/09/2012 11:57:37 ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_IsQuantityUnlimited]  DEFAULT ((0)) FOR [IsQuantityUnlimited]
GO
/****** Object:  Default [DF_Products_Created]    Script Date: 11/09/2012 11:57:37 ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_Products_isActive]    Script Date: 11/09/2012 11:57:37 ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_isActive]  DEFAULT ((1)) FOR [isActive]
GO
/****** Object:  Default [DF_Users_Created]    Script Date: 11/09/2012 11:57:37 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Created]  DEFAULT (getdate()) FOR [Created]
GO
