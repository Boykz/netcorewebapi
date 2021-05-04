USE [IntvDB]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 01.05.2021 16:18:37 ******/
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
/****** Object:  Table [dbo].[OrderItems]    Script Date: 01.05.2021 16:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[OrderId] [int] NOT NULL,
	[ItemId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 01.05.2021 16:18:37 ******/
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
/****** Object:  Table [dbo].[Regions]    Script Date: 01.05.2021 16:18:37 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 01.05.2021 16:18:37 ******/
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

INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (1, 1, N'Ноутбук', N'Қазақша', CAST(5654.5400 AS Decimal(19, 4)), 15000)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (3, 1, N'Мышка', N'Description', CAST(5.0400 AS Decimal(19, 4)), 5999)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (4, 1, N'Клавиатура', N'Description', CAST(5.0400 AS Decimal(19, 4)), 3999)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (5, 1, N'Монитор', N'Description', CAST(5.0400 AS Decimal(19, 4)), 150000)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (6, 1, N'Смартфон', N'Description', CAST(5.0400 AS Decimal(19, 4)), 150000)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (7, 1, N'Камера', N'Description', CAST(5.0400 AS Decimal(19, 4)), 50000)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (8, 1, N'Холодильник', N'Description', CAST(5.0400 AS Decimal(19, 4)), 250000)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (9, 1, N'Наушник', N'Description', CAST(5.0400 AS Decimal(19, 4)), 4999)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (10, 1, N'Стиральная машина', N'Description', CAST(5.0400 AS Decimal(19, 4)), 199999)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (11, 1, N'Телевизор', N'Description', CAST(5.0400 AS Decimal(19, 4)), 250000)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (12, 1, N'Пылесос', N'Description', CAST(5.0400 AS Decimal(19, 4)), 50000)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (13, 1, N'Штор', N'Description', CAST(5.0400 AS Decimal(19, 4)), 49999)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (14, 1, N'Посудомоечная машина', N'Description', CAST(5.0400 AS Decimal(19, 4)), 169999)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (15, 1, N'Машина', N'Description', CAST(5.0400 AS Decimal(19, 4)), 1666659)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (16, 1, N'Велосипед', N'Description', CAST(5.0400 AS Decimal(19, 4)), 30000)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (17, 1, N'Самакат', N'Description', CAST(5.0400 AS Decimal(19, 4)), 80000)
INSERT [dbo].[Items] ([Id], [Status], [Name], [Description], [Price], [Count]) VALUES (18, 1, N'Скутер', N'Description', CAST(5.0400 AS Decimal(19, 4)), 170000)
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (1, 1)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (1, 3)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (1, 4)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (1, 6)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (2, 10)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (2, 11)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (2, 15)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (6, 3)
INSERT [dbo].[OrderItems] ([OrderId], [ItemId]) VALUES (6, 1)
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [Status], [UserId], [RegionId], [Sum], [CreatedTime]) VALUES (1, 1, 2, 7, CAST(5.5600 AS Decimal(19, 4)), CAST(N'2021-05-01T12:01:33.833' AS DateTime))
INSERT [dbo].[Orders] ([Id], [Status], [UserId], [RegionId], [Sum], [CreatedTime]) VALUES (2, 1, 5, 7, CAST(564.0000 AS Decimal(19, 4)), CAST(N'2021-05-01T13:06:00.023' AS DateTime))
INSERT [dbo].[Orders] ([Id], [Status], [UserId], [RegionId], [Sum], [CreatedTime]) VALUES (6, 1, 5, 10, CAST(56.0000 AS Decimal(19, 4)), CAST(N'2021-05-01T13:07:38.913' AS DateTime))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
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
SET IDENTITY_INSERT [dbo].[Regions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Status], [Login], [Password], [FirstName], [LastName], [Role]) VALUES (1, 1, N'admin@gmail.com', N'123456', N'Admin', N'Admin', 4)
INSERT [dbo].[Users] ([Id], [Status], [Login], [Password], [FirstName], [LastName], [Role]) VALUES (2, 1, N'customer1@mail.ru', N'123456', N'Customes', N'Customer1', 2)
INSERT [dbo].[Users] ([Id], [Status], [Login], [Password], [FirstName], [LastName], [Role]) VALUES (5, 1, N'customer2@mail.ru', N'123456', N'Customer', N'Customer2', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
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
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Items]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
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
/****** Object:  StoredProcedure [dbo].[GetRegionFullAreaName]    Script Date: 01.05.2021 16:18:37 ******/
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

	select  distinct
	STUFF((SELECT ', ' + Name  FROM RegionAndPs  ORDER BY depth FOR XML PATH('')),1,1,'') as Name from RegionAndPs
END;
GO
/****** Object:  StoredProcedure [dbo].[GetRegionWithParents]    Script Date: 01.05.2021 16:18:37 ******/
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
