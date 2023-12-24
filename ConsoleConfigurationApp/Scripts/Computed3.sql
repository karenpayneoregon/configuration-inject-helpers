USE [ComputedSample3]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 12/24/2023 4:21:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[UnitPrice] [numeric](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[RowTotal]  AS ([Quantity]*[UnitPrice]),
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/24/2023 4:21:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](40) NOT NULL,
	[SupplierID] [int] NULL,
	[CategoryID] [int] NULL,
	[QuantityPerUnit] [nvarchar](20) NULL,
	[UnitPrice] [money] NULL,
	[UnitsInStock] [smallint] NULL,
	[UnitsOnOrder] [smallint] NULL,
	[ReorderLevel] [smallint] NULL,
	[Discontinued] [bit] NOT NULL,
	[DiscontinuedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (1, 11, CAST(14.00 AS Numeric(18, 2)), 2)
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (2, 42, CAST(9.80 AS Numeric(18, 2)), 1)
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (3, 72, CAST(34.00 AS Numeric(18, 2)), 3)
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (4, 60, CAST(27.20 AS Numeric(18, 2)), 3)
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (5, 53, CAST(26.20 AS Numeric(18, 2)), 5)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (1, N'Chai', 1, 1, N'10 boxes x 20 bags', 18.0000, 39, 0, 10, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (2, N'Chang', 6, 1, N'24 - 12 oz bottles', 19.0000, 17, 40, 25, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (3, N'Aniseed Syrup', 1, 2, N'12 - 550 ml bottles', 10.0000, 13, 70, 25, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (4, N'Chef Anton''s Cajun Seasoning', 2, 2, N'48 - 6 oz jars', 22.0000, 53, 0, 0, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (5, N'Chef Anton''s Gumbo Mix', 2, 2, N'36 boxes', 21.3500, 0, 0, 0, 1, CAST(N'2001-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (6, N'Grandma''s Boysenberry Spread', 3, 2, N'12 - 8 oz jars', 25.0000, 120, 0, 25, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (7, N'Uncle Bob''s Organic Dried Pears', 3, 7, N'12 - 1 lb pkgs.', 30.0000, 15, 0, 10, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (8, N'Northwoods Cranberry Sauce', 3, 2, N'12 - 12 oz jars', 40.0000, 6, 0, 0, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (9, N'Mishi Kobe Niku', 4, 6, N'18 - 500 g pkgs.', 97.0000, 29, 0, 0, 1, CAST(N'2012-03-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (10, N'Ikura', 4, 8, N'12 - 200 ml jars', 31.0000, 31, 0, 0, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (11, N'Queso Cabrales', 5, 4, N'1 kg pkg.', 21.0000, 22, 30, 30, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (12, N'Queso Manche La Pastora', 5, 4, N'10 - 500 g pkgs.', 38.0000, 86, 0, 0, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (13, N'Konbu', 6, 8, N'2 kg box', 6.0000, 24, 0, 5, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (14, N'Tofu', 6, 7, N'40 - 100 g pkgs.', 23.2500, 35, 0, 0, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (15, N'Genen Shouyu', 6, 2, N'24 - 250 ml bottles', 15.5000, 39, 0, 5, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (16, N'Pavlova', 7, 3, N'32 - 500 g boxes', 17.4500, 29, 0, 10, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (17, N'Alice Mutton', 7, 6, N'20 - 1 kg tins', 39.0000, 0, 0, 0, 1, CAST(N'2004-09-16T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (18, N'Carnarvon Tigers', 7, 8, N'16 kg pkg.', 62.5000, 42, 0, 0, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (19, N'Teatime Chocolate Biscuits', 8, 3, N'10 boxes x 12 pieces', 9.2000, 25, 0, 5, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (20, N'Sir Rodney''s Marmalade', 8, 3, N'30 gift boxes', 81.0000, 40, 0, 0, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (21, N'Sir Rodney''s Scones', 8, 3, N'24 pkgs. x 4 pieces', 10.0000, 3, 40, 5, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (22, N'Gustaf''s KnÃ¤ckebrÃ¶d', 9, 5, N'24 - 500 g pkgs.', 21.0000, 104, 0, 25, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (23, N'TunnbrÃ¶d', 9, 5, N'12 - 250 g pkgs.', 9.0000, 61, 0, 25, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (24, N'GuaranÃ¡ FantÃ¡stica', 10, 1, N'12 - 355 ml cans', 4.5000, 20, 0, 0, 1, CAST(N'2015-07-07T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (25, N'NuNuCa NuÃŸ-Nougat-Creme', 11, 3, N'20 - 450 g glasses', 14.0000, 76, 0, 30, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (26, N'GumbÃ¤r GummibÃ¤rchen', 11, 3, N'100 - 250 g bags', 31.2300, 15, 0, 0, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (27, N'Schoggi Schokolade', 11, 3, N'100 - 100 g pieces', 43.9000, 49, 0, 30, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (28, N'RÃ¶ssle Sauerkraut', 12, 7, N'25 - 825 g cans', 45.6000, 26, 0, 0, 1, CAST(N'2016-06-30T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (29, N'ThÃ¼ringer Rostbratwurst', 12, 6, N'50 bags x 30 sausgs.', 123.7900, 0, 0, 0, 1, CAST(N'2003-01-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (30, N'Nord-Ost Matjeshering', 13, 8, N'10 - 200 g glasses', 25.8900, 10, 0, 15, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (31, N'rnzola Telino', 14, 4, N'12 - 100 g pkgs', 12.5000, 0, 70, 20, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (32, N'Mascarpone Fabioli', 14, 4, N'24 - 200 g pkgs.', 32.0000, 9, 40, 25, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (33, N'Geitost', 15, 4, N'500 g', 2.5000, 112, 0, 20, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (34, N'Sasquatch Ale', 16, 1, N'24 - 12 oz bottles', 14.0000, 111, 0, 15, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (35, N'Steeleye Stout', 16, 1, N'24 - 12 oz bottles', 18.0000, 20, 0, 15, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (36, N'Inlagd Sill', 17, 8, N'24 - 250 g  jars', 19.0000, 112, 0, 20, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (37, N'Gravad lax', 17, 8, N'12 - 500 g pkgs.', 26.0000, 11, 50, 25, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (38, N'CÃ´te de Blaye', 18, 1, N'12 - 75 cl bottles', 263.5000, 17, 0, 15, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (39, N'Chartreuse verte', 18, 1, N'750 cc per bottle', 18.0000, 69, 0, 5, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (40, N'Boston Crab Meat', 19, 8, N'24 - 4 oz tins', 18.4000, 123, 0, 30, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (41, N'Jack''s New England Clam Chowder', 19, 8, N'12 - 12 oz cans', 9.6500, 85, 0, 10, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (42, N'Singaporean Hokkien Fried Mee', 20, 5, N'32 - 1 kg pkgs.', 14.0000, 26, 0, 0, 1, CAST(N'1999-04-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (43, N'Ipoh Coffee', 20, 1, N'16 - 500 g tins', 46.0000, 17, 10, 25, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (44, N'Gula Malacca', 20, 2, N'20 - 2 kg bags', 19.4500, 27, 0, 15, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (45, N'Rogede sild', 21, 8, N'1k pkg.', 9.5000, 5, 70, 15, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (46, N'Spegesild', 21, 8, N'4 - 450 g glasses', 12.0000, 95, 0, 0, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (47, N'Zaanse koeken', 22, 3, N'10 - 4 oz boxes', 9.5000, 36, 0, 0, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (48, N'Chocolade', 22, 3, N'10 pkgs.', 12.7500, 15, 70, 25, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (49, N'Maxilaku', 23, 3, N'24 - 50 g pkgs.', 20.0000, 10, 60, 15, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (50, N'Valkoinen suklaa', 23, 3, N'12 - 100 g bars', 16.2500, 65, 0, 30, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (51, N'Manjimup Dried Apples', 24, 7, N'50 - 300 g pkgs.', 53.0000, 20, 0, 10, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (52, N'Filo Mix', 24, 5, N'16 - 2 kg boxes', 7.0000, 38, 0, 25, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (53, N'Perth Pasties', 24, 6, N'48 pieces', 32.8000, 0, 0, 0, 1, CAST(N'1988-09-23T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (54, N'TourtiÃ¨re', 25, 6, N'16 pies', 7.4500, 21, 0, 10, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (55, N'PÃ¢tÃ© chinois', 25, 6, N'24 boxes x 2 pies', 24.0000, 115, 0, 20, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (56, N'Gnocchi di nonna Alice', 26, 5, N'24 - 250 g pkgs.', 38.0000, 21, 10, 30, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (57, N'Ravioli Angelo', 26, 5, N'24 - 250 g pkgs.', 19.5000, 36, 0, 20, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (58, N'Escarts de Bourgne', 27, 8, N'24 pieces', 13.2500, 62, 0, 20, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (59, N'Raclette Courdavault', 28, 4, N'5 kg pkg.', 55.0000, 79, 0, 0, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (60, N'Camembert Pierrot', 28, 4, N'15 - 300 g rounds', 34.0000, 19, 0, 0, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (61, N'Sirop d''Ã©rable', 29, 2, N'24 - 500 ml bottles', 28.5000, 113, 0, 25, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (62, N'Tarte au sucre', 29, 3, N'48 pies', 49.3000, 17, 0, 0, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (63, N'Vegie-spread', 7, 2, N'15 - 625 g jars', 43.9000, 24, 0, 5, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (64, N'Wimmers gute SemmelknÃ¶del', 12, 5, N'20 bags x 4 pieces', 33.2500, 22, 80, 30, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (65, N'Louisiana Fiery Hot Pepper Sauce', 2, 2, N'32 - 8 oz bottles', 21.0500, 76, 0, 0, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (66, N'Louisiana Hot Spiced Okra', 2, 2, N'24 - 8 oz jars', 17.0000, 4, 100, 20, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (67, N'Laughing Lumberjack Lager', 16, 1, N'24 - 12 oz bottles', 14.0000, 52, 0, 10, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (68, N'Scottish Longbreads', 8, 3, N'10 boxes x 8 pieces', 12.5000, 6, 10, 15, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (69, N'Gudbrandsdalsost', 15, 4, N'10 kg pkg.', 36.0000, 26, 0, 15, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (70, N'Outback Lager', 7, 1, N'24 - 355 ml bottles', 15.0000, 15, 10, 30, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (71, N'Flotemysost', 15, 4, N'10 - 500 g pkgs.', 21.5000, 26, 0, 0, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (72, N'Mozzarella di Giovanni', 14, 4, N'24 - 200 g pkgs.', 34.8000, 14, 0, 0, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (73, N'RÃ¶d Kaviar', 17, 8, N'24 - 150 g jars', 15.0000, 101, 0, 5, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (74, N'Longlife Tofu', 4, 7, N'5 kg pkg.', 10.0000, 4, 20, 5, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (75, N'RhonbrÃ¤u Klosterbier', 12, 1, N'24 - 0.5 l bottles', 7.7500, 125, 0, 25, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (76, N'LakkalikÃ¶Ã¶ri', 23, 1, N'500 ml', 18.0000, 57, 0, 20, 0, NULL)
INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [DiscontinuedDate]) VALUES (77, N'Original Frankfurter grÃ¼ne SoÃŸe', 12, 2, N'12 boxes', 13.0000, 32, 0, 15, 0, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO
USE [master]
GO
ALTER DATABASE [ComputedSample3] SET  READ_WRITE 
GO
