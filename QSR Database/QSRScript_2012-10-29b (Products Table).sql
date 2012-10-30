USE [QuickStart_DB]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Products_isFreeShipping]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [DF_Products_isFreeShipping]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Products_isTaxFree]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [DF_Products_isTaxFree]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Products_IsQuantityUnlimited]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [DF_Products_IsQuantityUnlimited]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Products_Created]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [DF_Products_Created]
END

GO

USE [QuickStart_DB]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 10/29/2012 21:13:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
DROP TABLE [dbo].[Products]
GO

USE [QuickStart_DB]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/29/2012 21:12:06 ******/
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
	[CategoryID] [int] NULL,
	[MSRP] [float] NULL,
	[isFreeShipping] [bit] NULL,
	[isTaxFree] [bit] NULL,
	[QuantityInStock] [int] NULL,
	[IsQuantityUnlimited] [bit] NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_Products_1] PRIMARY KEY CLUSTERED 
(
	[ProductCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified]) VALUES (N'0QEN0BL4OH', N'40" Plasma Television', N'Toshiba', NULL, 23, NULL, 0, 0, NULL, 0, CAST(0x0000A0F300DD3DAF AS DateTime), NULL)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified]) VALUES (N'4Q8UMWUV3B', N'Solid Steel Refridgerator', N'General Electric', NULL, 7, NULL, 0, 0, NULL, 0, CAST(0x0000A0F300DD4DAD AS DateTime), NULL)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified]) VALUES (N'51PBBCMUQF', N'3D Blueray Player', N'Samsung', NULL, NULL, NULL, 0, 0, NULL, 0, CAST(0x0000A0F300DD2AA5 AS DateTime), NULL)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified]) VALUES (N'8XGWBVIZ5K', N'IPod Nano', N'Apple', NULL, 27, NULL, 0, 0, NULL, 0, CAST(0x0000A0F300DD2683 AS DateTime), NULL)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified]) VALUES (N'DIF0G5NJWL', N'IPod Touch', N'Apple', NULL, 27, NULL, 0, 0, NULL, 0, CAST(0x0000A0F300DD56A1 AS DateTime), NULL)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified]) VALUES (N'FAULJR8RBI', N'Xbox 360 Console 250GB', N'Microsoft', NULL, 12, NULL, 0, 0, NULL, 0, CAST(0x0000A0F300DD60A1 AS DateTime), NULL)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified]) VALUES (N'H6RF27H46H', N'Playstation 3', N'Sony', NULL, 13, NULL, 0, 0, NULL, 0, CAST(0x0000A0F300DCDFDD AS DateTime), NULL)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified]) VALUES (N'I7HTIILG3X', N'Compact Digital Camera', N'Nikon', NULL, 18, NULL, 0, 0, NULL, 0, CAST(0x0000A0F300DD529A AS DateTime), NULL)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified]) VALUES (N'IVVXPUY5IP', N'3D Camcorder', N'Nikon', NULL, 18, NULL, 0, 0, NULL, 0, CAST(0x0000A0F300DD2EE9 AS DateTime), NULL)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified]) VALUES (N'MKNSDPYHFV', N'17" Gaming Laptop', N'Alienware', NULL, NULL, NULL, 0, 0, NULL, 0, CAST(0x0000A0F300DD6A90 AS DateTime), NULL)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified]) VALUES (N'QWN1MDYDKP', N'Blue Gaming Mouse', N'NextTech', NULL, NULL, NULL, 0, 0, NULL, 0, CAST(0x0000A0F300DD4303 AS DateTime), NULL)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified]) VALUES (N'U68J39BVNF', N'44" LCD Television', N'Sharp', NULL, 23, NULL, 0, 0, NULL, 0, CAST(0x0000A0F300DD64C5 AS DateTime), NULL)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified]) VALUES (N'UVP9TQMFGC', N'8" Digital Frame', N'Nikon', NULL, 19, NULL, 0, 0, NULL, 0, CAST(0x0000A0F300DD2287 AS DateTime), NULL)
INSERT [dbo].[Products] ([ProductCode], [Name], [Brand], [Description], [CategoryID], [MSRP], [isFreeShipping], [isTaxFree], [QuantityInStock], [IsQuantityUnlimited], [Created], [Modified]) VALUES (N'XBL5MU5CM1', N'10" Digital Frame', N'Nikon', NULL, 19, NULL, 0, 0, NULL, 0, CAST(0x0000A0F300DD48A9 AS DateTime), NULL)
/****** Object:  Default [DF_Products_isFreeShipping]    Script Date: 10/29/2012 21:12:06 ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_isFreeShipping]  DEFAULT ((0)) FOR [isFreeShipping]
GO
/****** Object:  Default [DF_Products_isTaxFree]    Script Date: 10/29/2012 21:12:06 ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_isTaxFree]  DEFAULT ((0)) FOR [isTaxFree]
GO
/****** Object:  Default [DF_Products_IsQuantityUnlimited]    Script Date: 10/29/2012 21:12:06 ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_IsQuantityUnlimited]  DEFAULT ((0)) FOR [IsQuantityUnlimited]
GO
/****** Object:  Default [DF_Products_Created]    Script Date: 10/29/2012 21:12:06 ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Created]  DEFAULT (getdate()) FOR [Created]
GO
