USE [IntvDB]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 04.05.2021 16:43:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [int] NOT NULL,
	[Name] [nvarchar](2500) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](19, 4) NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 04.05.2021 16:43:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[OrderId] [int] NOT NULL,
	[ItemId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 04.05.2021 16:43:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[RegionId] [int] NULL,
	[Sum] [decimal](19, 4) NULL,
	[CreatedTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 04.05.2021 16:43:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [int] NOT NULL,
	[Name] [nvarchar](2000) NOT NULL,
	[ParentId] [int] NOT NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04.05.2021 16:43:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [int] NOT NULL,
	[Login] [nvarchar](500) NOT NULL,
	[Password] [nvarchar](1500) NOT NULL,
	[FirstName] [nvarchar](500) NOT NULL,
	[LastName] [nvarchar](500) NOT NULL,
	[Role] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (1, 1, N'Ноутбук', N'Қазақша', CAST(15000.0000 AS Decimal(19, 4)), 10)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (3, 1, N'Мышка', N'Description', CAST(5999.0000 AS Decimal(19, 4)), 10)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (4, 1, N'Клавиатура', N'Description', CAST(3999.0000 AS Decimal(19, 4)), 10)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (5, 1, N'Монитор', N'Description', CAST(150000.0000 AS Decimal(19, 4)), 10)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (6, 1, N'Смартфон', N'Description', CAST(150000.0000 AS Decimal(19, 4)), 10)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (7, 1, N'Камера', N'Description', CAST(50000.0000 AS Decimal(19, 4)), 10)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (8, 1, N'Холодильник', N'Description', CAST(250000.0000 AS Decimal(19, 4)), 10)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (9, 1, N'Наушник', N'Description', CAST(4999.0000 AS Decimal(19, 4)), 10)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (10, 1, N'Стиральная машина', N'Description', CAST(199999.0000 AS Decimal(19, 4)), 10)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (11, 1, N'Телевизор', N'Description', CAST(250000.0000 AS Decimal(19, 4)), 10)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (12, 1, N'Пылесос', N'Description', CAST(50000.0000 AS Decimal(19, 4)), 10)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (13, 1, N'Штор', N'Description', CAST(49999.0000 AS Decimal(19, 4)), 10)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (14, 1, N'Посудомоечная машина', N'Description', CAST(1666659.0000 AS Decimal(19, 4)), 10)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (16, 1, N'Велосипед', N'Description', CAST(30000.0000 AS Decimal(19, 4)), 10)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (17, 1, N'Самакат', N'Description', CAST(80000.0000 AS Decimal(19, 4)), 10)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (18, 1, N'Скутер', N'Description', CAST(170000.0000 AS Decimal(19, 4)), 10)
SET IDENTITY_INSERT [dbo].[Items] OFF
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (2, 5)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (2, 6)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (2, 8)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (15, NULL)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (15, 16)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (15, 7)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (16, 8)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (18, 7)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (18, 18)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (19, 3)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (19, 9)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (19, 10)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (20, 11)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (20, 13)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (21, 1)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (21, 4)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (21, 16)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (22, 7)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (23, 13)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (26, 3)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (24, 5)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (25, 9)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (25, 17)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (27, 13)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (25, 18)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (25, 5)
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [Status], [UserId], [RegionId], [Sum], [CreatedTime]) VALUES (2, 1, 5, 7, CAST(550000.0000 AS Decimal(19, 4)), CAST(N'2021-05-01T13:06:00.023' AS DateTime))
INSERT [dbo].[Orders] ([Id], [Status], [UserId], [RegionId], [Sum], [CreatedTime]) VALUES (15, 1, 6, 8, CAST(80000.0000 AS Decimal(19, 4)), CAST(N'2021-05-03T17:40:58.810' AS DateTime))
INSERT [dbo].[Orders] ([Id], [Status], [UserId], [RegionId], [Sum], [CreatedTime]) VALUES (16, 1, 5, 10, CAST(250000.0000 AS Decimal(19, 4)), CAST(N'2021-05-03T17:47:34.307' AS DateTime))
INSERT [dbo].[Orders] ([Id], [Status], [UserId], [RegionId], [Sum], [CreatedTime]) VALUES (18, 1, 2, 9, CAST(220000.0000 AS Decimal(19, 4)), CAST(N'2021-05-03T19:11:11.220' AS DateTime))
INSERT [dbo].[Orders] ([Id], [Status], [UserId], [RegionId], [Sum], [CreatedTime]) VALUES (19, 1, 5, 7, CAST(210997.0000 AS Decimal(19, 4)), CAST(N'2021-05-03T19:24:03.907' AS DateTime))
INSERT [dbo].[Orders] ([Id], [Status], [UserId], [RegionId], [Sum], [CreatedTime]) VALUES (20, 1, 6, 8, CAST(299999.0000 AS Decimal(19, 4)), CAST(N'2021-05-03T19:24:17.097' AS DateTime))
INSERT [dbo].[Orders] ([Id], [Status], [UserId], [RegionId], [Sum], [CreatedTime]) VALUES (21, 1, 2, 12, CAST(48999.0000 AS Decimal(19, 4)), CAST(N'2021-05-03T19:24:52.333' AS DateTime))
INSERT [dbo].[Orders] ([Id], [Status], [UserId], [RegionId], [Sum], [CreatedTime]) VALUES (22, 1, 5, 8, CAST(50000.0000 AS Decimal(19, 4)), CAST(N'2021-05-03T19:25:03.410' AS DateTime))
INSERT [dbo].[Orders] ([Id], [Status], [UserId], [RegionId], [Sum], [CreatedTime]) VALUES (23, 1, 6, 12, CAST(49999.0000 AS Decimal(19, 4)), CAST(N'2021-05-03T19:25:44.020' AS DateTime))
INSERT [dbo].[Orders] ([Id], [Status], [UserId], [RegionId], [Sum], [CreatedTime]) VALUES (24, 1, 5, 9, CAST(150000.0000 AS Decimal(19, 4)), CAST(N'2021-05-03T19:25:57.797' AS DateTime))
INSERT [dbo].[Orders] ([Id], [Status], [UserId], [RegionId], [Sum], [CreatedTime]) VALUES (25, 1, 2, 7, CAST(404999.0000 AS Decimal(19, 4)), CAST(N'2021-05-03T19:26:21.910' AS DateTime))
INSERT [dbo].[Orders] ([Id], [Status], [UserId], [RegionId], [Sum], [CreatedTime]) VALUES (26, 1, 2, 10, CAST(5999.0000 AS Decimal(19, 4)), CAST(N'2021-05-04T13:14:04.720' AS DateTime))
INSERT [dbo].[Orders] ([Id], [Status], [UserId], [RegionId], [Sum], [CreatedTime]) VALUES (27, 1, 2, 10, CAST(49999.0000 AS Decimal(19, 4)), CAST(N'2021-05-04T14:51:20.303' AS DateTime))
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Regions] ON 

INSERT [dbo].[Regions] ([Id], [Status], [Name], [ParentId]) VALUES (1, 1, N'Қазақстан', 0)
INSERT [dbo].[Regions] ([Id], [Status], [Name], [ParentId]) VALUES (2, 1, N'Узбекистан', 0)
INSERT [dbo].[Regions] ([Id], [Status], [Name], [ParentId]) VALUES (3, 1, N'Китай', 0)
INSERT [dbo].[Regions] ([Id], [Status], [Name], [ParentId]) VALUES (4, 1, N'обл. Алматы', 1)
INSERT [dbo].[Regions] ([Id], [Status], [Name], [ParentId]) VALUES (5, 1, N'обл. Жамбыл ', 1)
INSERT [dbo].[Regions] ([Id], [Status], [Name], [ParentId]) VALUES (6, 1, N'обл. Туркистан ', 1)
INSERT [dbo].[Regions] ([Id], [Status], [Name], [ParentId]) VALUES (7, 1, N'г. Алматы', 4)
INSERT [dbo].[Regions] ([Id], [Status], [Name], [ParentId]) VALUES (8, 1, N'г. Туркистан', 6)
INSERT [dbo].[Regions] ([Id], [Status], [Name], [ParentId]) VALUES (9, 1, N'г. Ташкент', 2)
INSERT [dbo].[Regions] ([Id], [Status], [Name], [ParentId]) VALUES (10, 1, N'г Қаскелен', 4)
INSERT [dbo].[Regions] ([Id], [Status], [Name], [ParentId]) VALUES (12, 1, N'Атырау', 1)
SET IDENTITY_INSERT [dbo].[Regions] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Status], [Login], [Password], [FirstName], [LastName], [Role]) VALUES (1, 1, N'admin@gmail.com', N'e10adc3949ba59abbe56e057f20f883e', N'Admin', N'Admin', 4)
INSERT [dbo].[Users] ([Id], [Status], [Login], [Password], [FirstName], [LastName], [Role]) VALUES (2, 1, N'customer1@mail.ru', N'96e79218965eb72c92a549dd5a330112', N'Customes', N'Customer1', 2)
INSERT [dbo].[Users] ([Id], [Status], [Login], [Password], [FirstName], [LastName], [Role]) VALUES (5, 1, N'customer2@mail.ru', N'e3ceb5881a0a1fdaad01296d7554868d', N'Customer', N'Customer2', 2)
INSERT [dbo].[Users] ([Id], [Status], [Login], [Password], [FirstName], [LastName], [Role]) VALUES (6, 1, N'customer3@mail.ru', N'1a100d2c0dab19c4430e7d73762b3423', N'Customer', N'Customer3', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF_Items_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF_Items_Count]  DEFAULT ((0)) FOR [Count]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[Regions] ADD  CONSTRAINT [DF_Regions_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Items]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Regions] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Regions]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
/****** Object:  StoredProcedure [dbo].[GetRegionFullAreaName]    Script Date: 04.05.2021 16:43:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRegionFullAreaName] 
 @Id INT
AS

BEGIN
	WITH RegionAndPs(Id,Name,rTo,depth) AS
	(
	select 
	Id,Name,ParentId,0
	from regions where Id = @Id

	UNION ALL 

	select 
	regions.Id,regions.Name,regions.ParentId,RegionAndPs.depth-1
	from regions 
		JOIN RegionAndPs ON regions.Id = RegionAndPs.rTo
	) 

	select  top 1
	STUFF((SELECT ', ' + Name  FROM RegionAndPs  ORDER BY depth FOR XML PATH('')),1,1,'') as Name,RegionAndPs.Id, RegionAndPs.rTo as ParentId from RegionAndPs
END;
GO
/****** Object:  StoredProcedure [dbo].[GetRegionWithParents]    Script Date: 04.05.2021 16:43:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetRegionWithParents]
	-- Add the parameters for the stored procedure here
	@Id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	WITH RegionAndPs(Id,Name,ParentId,depth) AS
	(
	select 
	Id,Name,ParentId,0
	from regions where Id = 10

	UNION ALL 

	select 
	regions.Id,regions.Name,regions.ParentId,RegionAndPs.depth-1
	from regions 
		JOIN RegionAndPs ON regions.Id = RegionAndPs.ParentId
	) 
	SELECT * FROM RegionAndPs  ORDER BY  depth desc
END
GO
