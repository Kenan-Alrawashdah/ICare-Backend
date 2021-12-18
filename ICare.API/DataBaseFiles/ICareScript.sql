USE [ICare-Database18]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[PatientId] [int] NOT NULL,
	[DrugId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drug]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drug](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[DrugCategoryId] [int] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Price] [float] NOT NULL,
	[PicturePath] [nvarchar](250) NOT NULL,
	[Brand] [varchar](150) NOT NULL,
	[AvailableQuantity] [int] NOT NULL,
	[Description] [varchar](1500) NULL,
 CONSTRAINT [PK_Drug] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DrugCategory]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrugCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[PicturePath] [nvarchar](250) NULL,
 CONSTRAINT [PK_DrugCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DrugDoseTime]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrugDoseTime](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[PatientDrugId] [int] NOT NULL,
	[Time] [time](0) NOT NULL,
 CONSTRAINT [PK_DrugDoseTime] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[DailyWorkingHours] [int] NOT NULL,
	[PricePerHour] [float] NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HealthReport]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HealthReport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[PatientId] [int] NOT NULL,
	[Type] [varchar](250) NOT NULL,
	[Value] [varchar](250) NOT NULL,
 CONSTRAINT [PK_HealthReport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[AddressName] [varchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[ZipCode] [int] NOT NULL,
	[Details] [varchar](250) NOT NULL,
	[Street] [varchar](250) NOT NULL,
	[lat] [decimal](8, 6) NOT NULL,
	[lng] [decimal](8, 6) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[Message] [nvarchar](1500) NOT NULL,
	[PatientId] [int] NOT NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[TotalPrice] [float] NOT NULL,
	[StatusId] [int] NOT NULL,
	[DeliveryId] [int] NULL,
	[PatientId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDrugs]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDrugs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[Quantity] [int] NOT NULL,
	[DrugsId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_OrderDrugs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[UserId] [int] NOT NULL,
	[Liters] [float] NULL,
	[SubscriptionValidation] [datetime2](0) NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientDrugs]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientDrugs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[PatientId] [int] NOT NULL,
	[StartDate] [datetime2](0) NOT NULL,
	[EndDate] [datetime2](0) NULL,
	[DrugName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PatientDrugs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[Bank_Id] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [int] NOT NULL,
	[Expirydate] [varchar](50) NOT NULL,
	[cvcCode] [int] NOT NULL,
	[CardName] [varchar](250) NOT NULL,
	[Balance] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK__Payment__0D43FE34E675C74C] PRIMARY KEY CLUSTERED 
(
	[Bank_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefreshToken]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefreshToken](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RefreshToken] [varchar](250) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
 CONSTRAINT [PK_RefreshToken] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusOrderEnum]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusOrderEnum](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_StatusOrderEnum] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubscribeType]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscribeType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[Price] [float] NOT NULL,
	[Days] [int] NOT NULL,
	[OnSale] [bit] NOT NULL,
	[PriceAfterSale] [float] NULL,
	[HasRibbon] [bit] NOT NULL,
	[Ribbon] [varchar](15) NULL,
	[Name] [varchar](50) NOT NULL,
	[RibbonColor] [varchar](50) NULL,
 CONSTRAINT [PK_SubscribeType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscription]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscription](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[PatientId] [int] NOT NULL,
	[SubscribeTypeId] [int] NOT NULL,
	[Expirationdate] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Testimonial]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Testimonial](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[created_at] [datetime] NULL,
	[userName] [varchar](50) NULL,
	[userSubject] [varchar](50) NULL,
	[userEmail] [varchar](50) NULL,
	[userPhone] [varchar](50) NULL,
	[userMessage] [varchar](50) NULL,
	[isProved] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[PasswordHash] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](15) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[ProfilePicturePath] [nvarchar](250) NULL,
	[EmployeeId] [int] NULL,
	[PatientId] [int] NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Water]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Water](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[PatientId] [int] NOT NULL,
	[Every] [int] NOT NULL,
	[From] [time](0) NOT NULL,
	[To] [time](0) NOT NULL,
 CONSTRAINT [PK_Water] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Work]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[StartDate] [datetime2](0) NOT NULL,
	[EndDate] [datetime2](0) NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_Work] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Drug_DrugId] FOREIGN KEY([DrugId])
REFERENCES [dbo].[Drug] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Drug_DrugId]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Patient_PatientId]
GO
ALTER TABLE [dbo].[Delivery]  WITH CHECK ADD  CONSTRAINT [FK_Delivery_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Delivery] CHECK CONSTRAINT [FK_Delivery_User_UserId]
GO
ALTER TABLE [dbo].[Drug]  WITH CHECK ADD  CONSTRAINT [FK_Drug_DrugCategory_DrugCategoryId] FOREIGN KEY([DrugCategoryId])
REFERENCES [dbo].[DrugCategory] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Drug] CHECK CONSTRAINT [FK_Drug_DrugCategory_DrugCategoryId]
GO
ALTER TABLE [dbo].[DrugDoseTime]  WITH CHECK ADD  CONSTRAINT [FK_DrugDoseTime_PatientDrugs_PatientDrugId] FOREIGN KEY([PatientDrugId])
REFERENCES [dbo].[PatientDrugs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DrugDoseTime] CHECK CONSTRAINT [FK_DrugDoseTime_PatientDrugs_PatientDrugId]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_User_UserId]
GO
ALTER TABLE [dbo].[HealthReport]  WITH CHECK ADD  CONSTRAINT [FK_HealthReport_Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HealthReport] CHECK CONSTRAINT [FK_HealthReport_Patient_PatientId]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_User]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Patient_PatientId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Delivery_DeliveryId] FOREIGN KEY([DeliveryId])
REFERENCES [dbo].[Delivery] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Delivery_DeliveryId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Location]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Patient_PatientId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_StatusOrderEnum_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[StatusOrderEnum] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_StatusOrderEnum_StatusId]
GO
ALTER TABLE [dbo].[OrderDrugs]  WITH CHECK ADD  CONSTRAINT [FK_OrderDrugs_Drug_DrugsId] FOREIGN KEY([DrugsId])
REFERENCES [dbo].[Drug] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDrugs] CHECK CONSTRAINT [FK_OrderDrugs_Drug_DrugsId]
GO
ALTER TABLE [dbo].[OrderDrugs]  WITH CHECK ADD  CONSTRAINT [FK_OrderDrugs_Order_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDrugs] CHECK CONSTRAINT [FK_OrderDrugs_Order_OrderId]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_User_UserId]
GO
ALTER TABLE [dbo].[PatientDrugs]  WITH CHECK ADD  CONSTRAINT [FK_PatientDrugs_Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PatientDrugs] CHECK CONSTRAINT [FK_PatientDrugs_Patient_PatientId]
GO
ALTER TABLE [dbo].[RefreshToken]  WITH CHECK ADD  CONSTRAINT [FK_RefreshToken_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[RefreshToken] CHECK CONSTRAINT [FK_RefreshToken_User]
GO
ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subscription] CHECK CONSTRAINT [FK_Subscription_Patient_PatientId]
GO
ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_SubscribeType_SubscribeTypeId] FOREIGN KEY([SubscribeTypeId])
REFERENCES [dbo].[SubscribeType] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subscription] CHECK CONSTRAINT [FK_Subscription_SubscribeType_SubscribeTypeId]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Roles]
GO
ALTER TABLE [dbo].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_User_UserId]
GO
ALTER TABLE [dbo].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_User_UserId]
GO
ALTER TABLE [dbo].[Water]  WITH CHECK ADD  CONSTRAINT [FK_Water_Patient] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([Id])
GO
ALTER TABLE [dbo].[Water] CHECK CONSTRAINT [FK_Water_Patient]
GO
ALTER TABLE [dbo].[Work]  WITH CHECK ADD  CONSTRAINT [FK_Work_Employee_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Work] CHECK CONSTRAINT [FK_Work_Employee_EmployeeId]
GO
/****** Object:  StoredProcedure [dbo].[AddOrMainusQuantity]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddOrMainusQuantity]
@CartId int , 
@Operation int 
as 

if(@Operation =1)
update Cart 
set Quantity = Quantity+1
where Id = @CartId
else
update Cart 
set Quantity = Quantity-1
where Id = @CartId
GO
/****** Object:  StoredProcedure [dbo].[AddOrUpdateProfilePicture]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddOrUpdateProfilePicture]
@imagePath varchar(250), 
@userId int
as 
begin 
update [User]
set ProfilePicturePath = @imagePath
where Id = @userId
end 
GO
/****** Object:  StoredProcedure [dbo].[AddQuantity]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddQuantity]
@CartId int
as 
update Cart 
set Quantity = Quantity+1
where Id = @CartId
GO
/****** Object:  StoredProcedure [dbo].[AddSubscribeTypes]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddSubscribeTypes]

AS 

	INSERT INTO [dbo].[SubscribeType] ([CreatedOn], [Price], [Days], [OnSale], [PriceAfterSale], [HasRibbon], [Ribbon], [Name], [RibbonColor])
	values(GETDATE(), 25, 30, 0, null, 0, null, 'Basic', '#4dbe3b')
	INSERT INTO [dbo].[SubscribeType] ([CreatedOn], [Price], [Days], [OnSale], [PriceAfterSale], [HasRibbon], [Ribbon], [Name], [RibbonColor])
	values(GETDATE(), 100, 120, 1, 80, 1, 'Best value', 'Pro', '#4dbe3b')
	INSERT INTO [dbo].[SubscribeType] ([CreatedOn], [Price], [Days], [OnSale], [PriceAfterSale], [HasRibbon], [Ribbon], [Name], [RibbonColor])
	values(GETDATE(), 200, 120, 1, 150, 0, null, 'Premium', '#4dbe3b')
	
GO
/****** Object:  StoredProcedure [dbo].[AddToQuantity]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddToQuantity] 
    @Id int,
	@Quantity int 
AS 

	update   [dbo].[Drug] 
	set AvailableQuantity = AvailableQuantity + @Quantity
	WHERE  ([Id] = @Id ) 

GO
/****** Object:  StoredProcedure [dbo].[AnnualCareSystemReport]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AnnualCareSystemReport]
as
begin
select u.FirstName+' '+u.LastName 'Name',TotalPrice 'OrderAmount',TotalPrice*0.05 'Profits', CAST( o.CreatedOn AS Date ) 'OrderDate'
from Patient p ,[dbo].[Order]  o , [dbo].[User] u
where p.Id = o.PatientId and u.Id=p.UserId and YEAR(o.CreatedOn) = YEAR(GETDATE())
end
GO
/****** Object:  StoredProcedure [dbo].[AuthLogin]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AuthLogin]
@Email varchar(50)
as 
select u.Id as 'Id', u.FirstName as "FirstName", u.Email as "Email" , u.Id as "Id",RoleId as "RoleId"
from [User] as u
where u.Email = @Email 
GO
/****** Object:  StoredProcedure [dbo].[CartDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CartDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[Cart]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[CartGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CartGetAll]
as 
begin 
select * from Cart
end
GO
/****** Object:  StoredProcedure [dbo].[CartInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CartInsert] 
    @CreatedOn datetime2(0),
    @PatientId int,
    @DrugId int,
    @Quantity int
AS 

	INSERT INTO [dbo].[Cart] ([CreatedOn], [PatientId], [DrugId], [Quantity])
	SELECT @CreatedOn, @PatientId, @DrugId, @Quantity
	
GO
/****** Object:  StoredProcedure [dbo].[CartSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[CartSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [PatientId], [DrugId] 
	FROM   [dbo].[Cart] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[CartUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CartUpdate] 
    @Id int,
    @CreatedOn datetime2(7),
    @PatientId int,
    @DrugId int
AS 

	UPDATE [dbo].[Cart]
	SET    [CreatedOn] = @CreatedOn, [PatientId] = @PatientId, [DrugId] = @DrugId
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[ChangeUserPassword]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[ChangeUserPassword]
@Email nvarchar(max),
@NewPasswordHash nvarchar(max)
AS
BEGIN
UPDATE dbo.[User]
SET PasswordHash =@NewPasswordHash
WHERE Email =@Email
END
GO
/****** Object:  StoredProcedure [dbo].[CheckEmailExist]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CheckEmailExist]
@Email varchar(150)
as 
begin 
select u.Id  from [User]as u 
where u.Email = @Email
end 
GO
/****** Object:  StoredProcedure [dbo].[CheckitemExistInCart]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CheckitemExistInCart]
@DrugId int , 
@PatientId int
as 
begin
select c.Id from Cart as c
where c.DrugId = @DrugId and c.PatientId = @PatientId

end
GO
/****** Object:  StoredProcedure [dbo].[CheckOrderStatus]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CheckOrderStatus]
AS
select Id from StatusOrderEnum as so where  so.Status = 'In Progress'
GO
/****** Object:  StoredProcedure [dbo].[CheckSubscribeType]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CheckSubscribeType]
as 
select COUNT(st.Id)  from [SubscribeType]as st 
GO
/****** Object:  StoredProcedure [dbo].[checkWaterOnTime]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[checkWaterOnTime]
 as
DECLARE @hour  int
SET @hour = datepart(hour, getdate())
DECLARE @mi  int
SET @mi = datepart(mi, getdate())
DECLARE @minet  int
set @minet = @hour * 60 + @mi

 select u.Email 
 from Water w 
 join Patient p on p.Id = w.PatientId
 join [dbo].[User] u on u.id = p.UserId

 where 
-- check time between
 w.[From] <= concat(@hour,':',@mi,':00') 
 and
 w.[To] >= concat(@hour,':',@mi,':00')

 and (@minet - (datepart(hour,w.[From])*60 +datepart(mi,w.[From]))) % w.Every = 0
GO
/****** Object:  StoredProcedure [dbo].[CreateStatusOrder]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CreateStatusOrder]
AS 

	INSERT INTO [dbo].[StatusOrderEnum] ([CreatedOn], [Status])
	values( GETDATE(), 'In Progress')
	INSERT INTO [dbo].[StatusOrderEnum] ([CreatedOn], [Status])
	values( GETDATE(), 'Delivered')
INSERT INTO [dbo].[StatusOrderEnum] ([CreatedOn], [Status])
	values( GETDATE(), 'Out for delivery')
INSERT INTO [dbo].[StatusOrderEnum] ([CreatedOn], [Status])
	values( GETDATE(), 'Canceled')
INSERT INTO [dbo].[StatusOrderEnum] ([CreatedOn], [Status])
	values( GETDATE(), 'Placed')

	
GO
/****** Object:  StoredProcedure [dbo].[DailyCareSystemReport]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DailyCareSystemReport]
as
begin
select u.FirstName+' '+u.LastName 'Name',TotalPrice 'OrderAmount',TotalPrice*0.05 'Profits', CAST( o.CreatedOn AS Date ) 'OrderDate'
from Patient p ,[dbo].[Order]  o , [dbo].[User] u
where p.Id = o.PatientId and u.Id=p.UserId and DAY(o.CreatedOn) = DAY(GETDATE())
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteDrugDoseTime]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteDrugDoseTime]
@PatientDrugsId int 
as 
begin 
delete from DrugDoseTime 
where PatientDrugId = @PatientDrugsId
end 
GO
/****** Object:  StoredProcedure [dbo].[DeliveryDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeliveryDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[Delivery]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[DeliveryGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeliveryGetAll]
as 
begin 
select * from Delivery
end
GO
/****** Object:  StoredProcedure [dbo].[DeliveryInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeliveryInsert] 
    @CreatedOn datetime2(7),
    @UserId int
AS 

	INSERT INTO [dbo].[Delivery] ([CreatedOn], [UserId])
	SELECT @CreatedOn, @UserId
	
GO
/****** Object:  StoredProcedure [dbo].[DeliverySelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[DeliverySelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [UserId] 
	FROM   [dbo].[Delivery] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[DeliveryUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[DeliveryUpdate] 
    @Id int,
    @CreatedOn datetime2(7),
    @UserId int
AS 

	UPDATE [dbo].[Delivery]
	SET    [CreatedOn] = @CreatedOn, [UserId] = @UserId
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[DrugCategoryDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DrugCategoryDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[DrugCategory]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[DrugCategoryGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DrugCategoryGetAll]
as 
begin 
select * from DrugCategory
end
GO
/****** Object:  StoredProcedure [dbo].[DrugCategoryInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DrugCategoryInsert] 
    @CreatedOn datetime2(7),
    @Name nvarchar(100),
    @PicturePath nvarchar(250) = NULL
AS 

	INSERT INTO [dbo].[DrugCategory] ([CreatedOn], [Name], [PicturePath])
	SELECT @CreatedOn, @Name, @PicturePath
	
GO
/****** Object:  StoredProcedure [dbo].[DrugCategorySelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[DrugCategorySelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [Name], [PicturePath] 
	FROM   [dbo].[DrugCategory] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[DrugCategoryUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DrugCategoryUpdate] 
    @Id int,
    @Name nvarchar(100),
    @PicturePath nvarchar(250) 
AS 
if(@PicturePath = '0')
	UPDATE [dbo].[DrugCategory]
	SET    [Name] = @Name
	WHERE  [Id] = @Id
else
	UPDATE [dbo].[DrugCategory]
	SET    [Name] = @Name, [PicturePath] = @PicturePath
	WHERE  [Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[DrugDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DrugDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[Drug]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[DrugDoseTimeDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DrugDoseTimeDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[DrugDoseTime]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[DrugDoseTimeGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DrugDoseTimeGetAll]
as 
begin 
select * from DrugDoseTime
end
GO
/****** Object:  StoredProcedure [dbo].[DrugDoseTimeInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DrugDoseTimeInsert] 
    @CreatedOn datetime2(7),
    @PatientDrugId int,
    @Time time(7)
AS 

	INSERT INTO [dbo].[DrugDoseTime] ([CreatedOn], [PatientDrugId], [Time])
	SELECT @CreatedOn, @PatientDrugId, @Time
	
GO
/****** Object:  StoredProcedure [dbo].[DrugDoseTimeSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[DrugDoseTimeSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [PatientDrugId], [Time] 
	FROM   [dbo].[DrugDoseTime] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[DrugDoseTimeUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[DrugDoseTimeUpdate] 
    @Id int,
    @CreatedOn datetime2(7),
    @PatientDrugId int,
    @Time time(7)
AS 

	UPDATE [dbo].[DrugDoseTime]
	SET    [CreatedOn] = @CreatedOn, [PatientDrugId] = @PatientDrugId, [Time] = @Time
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[DrugGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DrugGetAll]
as 
begin 
select * from Drug
end
GO
/****** Object:  StoredProcedure [dbo].[DrugInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DrugInsert] 
    @DrugCategoryId int,
    @Name nvarchar(150),
    @Price float,
    @PicturePath nvarchar(250),
    @Brand varchar(150),
    @AvailableQuantity int,
    @Description varchar(1500) = NULL
AS 

	INSERT INTO [dbo].[Drug] ([CreatedOn], [DrugCategoryId], [Name], [Price], [PicturePath], [Brand], [AvailableQuantity], [Description])
	SELECT GETDATE(), @DrugCategoryId, @Name, @Price, @PicturePath, @Brand, @AvailableQuantity, @Description
	
GO
/****** Object:  StoredProcedure [dbo].[DrugSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DrugSelect] 
    @Id int
AS 

	SELECT d.[Id], d.[CreatedOn], dc.Name as 'DrugCategory' , d.[Name], [Price], d.[PicturePath], [Brand], [AvailableQuantity], [Description] 
	FROM   [dbo].[Drug] as d
	inner join DrugCategory as dc on dc.Id = d.DrugCategoryId
	WHERE  (d.Id = @Id) 

GO
/****** Object:  StoredProcedure [dbo].[DrugUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DrugUpdate] 
    @Id int,
    @DrugCategoryId int,
    @Name nvarchar(150),
    @Price float,
    @PicturePath nvarchar(250),
    @Brand varchar(150),
    @AvailableQuantity int,
    @Description varchar(1500) = NULL
AS 
if(@PicturePath = null)
UPDATE [dbo].[Drug]
	SET    [DrugCategoryId] = @DrugCategoryId, [Name] = @Name, [Price] = @Price,  [Brand] = @Brand, [AvailableQuantity] = @AvailableQuantity, [Description] = @Description
	WHERE  [Id] = @Id
else
	UPDATE [dbo].[Drug]
	SET    [DrugCategoryId] = @DrugCategoryId, [Name] = @Name, [Price] = @Price, [PicturePath] = @PicturePath, [Brand] = @Brand, [AvailableQuantity] = @AvailableQuantity, [Description] = @Description
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[EmployeeDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EmployeeDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[Employee]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[EmployeeInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EmployeeInsert] 
    @CreatedOn datetime2(7),
    @HourSalary float,
    @MonthlyWorkingHours int,
    @PricePerHour float = NULL,
    @UserId int
AS 

	INSERT INTO [dbo].[Employee] ([CreatedOn], [HourSalary], [MonthlyWorkingHours], [PricePerHour], [UserId])
	SELECT @CreatedOn, @HourSalary, @MonthlyWorkingHours, @PricePerHour, @UserId
	
GO
/****** Object:  StoredProcedure [dbo].[EmployeeSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[EmployeeSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [HourSalary], [MonthlyWorkingHours], [PricePerHour], [UserId] 
	FROM   [dbo].[Employee] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[EmployeesGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EmployeesGetAll]
as 
begin 
select * from Employee
end
GO
/****** Object:  StoredProcedure [dbo].[EmployeeUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[EmployeeUpdate] 
    @Id int,
    @CreatedOn datetime2(7),
    @HourSalary float,
    @MonthlyWorkingHours int,
    @PricePerHour float = NULL,
    @UserId int
AS 

	UPDATE [dbo].[Employee]
	SET    [CreatedOn] = @CreatedOn, [HourSalary] = @HourSalary, [MonthlyWorkingHours] = @MonthlyWorkingHours, [PricePerHour] = @PricePerHour, [UserId] = @UserId
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[EndWork]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[EndWork]
 @EmployeeId int,
 @EndDate datetime2(7)
 as
 update Work set EndDate = @EndDate
 where EmployeeId = @EmployeeId and convert(varchar(10), StartDate, 120) = convert(varchar(10), GetDate(), 120)
GO
/****** Object:  StoredProcedure [dbo].[getAllEmployee]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getAllEmployee]
as 
begin
select FirstName+' '+LastName 'EmployeeName',
PhoneNumber 'EmployeePhoneNumber',
Email 'EmployeeEmail', r.Name as 'RoleName', e.PricePerHour,
e.DailyWorkingHours
from [dbo].[User] u ,Roles r, Employee e
where r.Id=u.RoleId and r.Name!='Patient' and u.Id = e.UserId
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllEmployees]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllEmployees]
as begin 
select * from Employee
end
GO
/****** Object:  StoredProcedure [dbo].[getAllOrdersForDelivery]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[getAllOrdersForDelivery]
  @DeliveryId  int 
AS 

	SELECT l.*,o.Id as 'OrderId',u.FirstName,u.LastName
	FROM   StatusOrderEnum as so 
	inner join [order] as o on o.StatusId = so.Id
	inner join Patient as p on p.Id = o.PatientId
	inner join [User] as u on u.Id = p.UserId
	inner join [Location] as l on l.Id = o.LocationId
	WHERE  o.DeliveryId = @DeliveryId
GO
/****** Object:  StoredProcedure [dbo].[GetAllRoles]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[GetAllRoles] 
 as
 select Id , Name from Roles

 
/****** Object:  Table [dbo].[Cart]    Script Date: 12/9/2021 12:23:33 PM ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GetAllSubscribeType]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetAllSubscribeType]
AS 

	SELECT * 
	FROM   [dbo].[SubscribeType]  

GO
/****** Object:  StoredProcedure [dbo].[GetAllTestimonial]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllTestimonial]
as
begin 
select * from Testimonial 
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllUserLogins]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllUserLogins]
as begin 
select * from UserLogins
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllUsers]
as 
begin

select * from [dbo].[User]

end
GO
/****** Object:  StoredProcedure [dbo].[GetAllUserTokens]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllUserTokens]
as begin 
select * from UserTokens
end
GO
/****** Object:  StoredProcedure [dbo].[getAnnualEmployeeSalaries]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getAnnualEmployeeSalaries]
as 
begin
select Sum(PricePerHour*DailyWorkingHours) 'AnnualEmployeeSalaries'
from Employee
where Year(CreatedOn) = Year(GETDATE())
end
GO
/****** Object:  StoredProcedure [dbo].[GetAvilableOrders]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetAvilableOrders]
   
AS 

	SELECT l.*,o.Id as 'OrderId'
	FROM   StatusOrderEnum as so 
	inner join [order] as o on o.StatusId = so.Id
	inner join [Location] as l on l.Id = o.LocationId
	WHERE  so.Status = 'Placed' 
GO
/****** Object:  StoredProcedure [dbo].[GetBySearch]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBySearch]
@search nvarchar(max)=null
AS
BEGIN
SELECT d.Id as 'Id', d.Name as 'DrugName',d.Price as 'DrugPrice',d.PicturePath as 'DrugPicturePath',d.Description as 'DrugDescription'
FROM dbo.Drug d
where
d.Name LIKE CASE WHEN @search is not null then '%'+@search+'%' else d.Name end
END
GO
/****** Object:  StoredProcedure [dbo].[GetByUserId]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetByUserId]
    @UserId int
AS 

	SELECT *
	FROM   Delivery as d
	WHERE  d.UserId =@UserId

GO
/****** Object:  StoredProcedure [dbo].[GetCartItems]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetCartItems] 
    @UserId int
AS 

	SELECT d.*,d.Id as 'DrugId',c.Quantity,c.Id as 'CartId'
	FROM  Cart as c 
	inner join Drug as d on d.Id =c.DrugId
	WHERE  (c.PatientId = @UserId ) 

GO
/****** Object:  StoredProcedure [dbo].[GetCategoryDrugs]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[GetCategoryDrugs] 
    @Id int
AS 

	SELECT d.[Id], d.[CreatedOn], dc.Name as 'DrugCategory' , d.[Name], [Price], d.[PicturePath], [Brand], [AvailableQuantity], [Description] 
	FROM   [dbo].[Drug] as d
	inner join DrugCategory as dc on dc.Id = d.DrugCategoryId
	WHERE  (dc.Id = @Id) 

GO
/****** Object:  StoredProcedure [dbo].[GetDeliveryByUserId]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[GetDeliveryByUserId] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [UserId] 
	FROM   [dbo].[Delivery] d
	WHERE  (d.UserId = @Id) 
GO
/****** Object:  StoredProcedure [dbo].[GetDrugDoseTime]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetDrugDoseTime]
@PatientDrugId int 
as 
select dd.Time 
from DrugDoseTime as dd 
inner join PatientDrugs as pd on pd.Id = dd.PatientDrugId
where pd.Id = @PatientDrugId
GO
/****** Object:  StoredProcedure [dbo].[GetDrugDoseTimeByPatientDrugId]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDrugDoseTimeByPatientDrugId]
@Id int
as 
begin
select [Time] from DrugDoseTime 
where PatientDrugId = @Id
end 
GO
/****** Object:  StoredProcedure [dbo].[GetDrugsOnTime]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[GetDrugsOnTime]
 as
DECLARE @hour  int
SET @hour = datepart(hour, getdate())
DECLARE @mi  int
SET @mi = datepart(mi, getdate())

 select pd.DrugName as NameDrug , u.Email as Email,p.Id
 from DrugDoseTime ddt
 inner join PatientDrugs pd on pd.Id = ddt.PatientDrugId
 inner join Patient p on p.Id = pd.PatientId
 inner join [dbo].[User] u on u.Id = p.UserId
 where ddt.time = concat(@hour,':',@mi,':00')
GO
/****** Object:  StoredProcedure [dbo].[getMonthlyEmployeeSalaries]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getMonthlyEmployeeSalaries]
as 
begin
select Sum(PricePerHour*DailyWorkingHours) 'MonthlyEmployeeSalaries'
from Employee
where Month(CreatedOn) = Month(GETDATE())
end
GO
/****** Object:  StoredProcedure [dbo].[GetMyDrugs]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetMyDrugs]
@pathientId int 
as 
begin 
select[Id], [DrugName] , [EndDate]as 'expireDate' from [PatientDrugs]
where [PatientId] = @pathientId


end
GO
/****** Object:  StoredProcedure [dbo].[getNumberOfOrdersForDelivery]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getNumberOfOrdersForDelivery]
@DeliveryId int
as
begin
select count(*) NumberOfOrders
from [dbo].[Order] o,StatusOrderEnum so,Delivery d,[dbo].[User] u,Location l
where so.Id = o.StatusId and o.DeliveryId=d.Id and d.UserId=u.Id and u.Id=l.UserId
and o.DeliveryId=1 and so.Id<>3
end
GO
/****** Object:  StoredProcedure [dbo].[GetOpenOrders]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetOpenOrders] 
   
AS 

	
	SELECT o.*,so.Status ,u.FirstName ,u.LastName
	FROM   StatusOrderEnum as so 
	inner join [order] as o on o.StatusId = so.Id
	inner join Patient as p on o.PatientId = p.Id
	inner join [User] as u on u.Id = p.UserId
	WHERE  so.Status = 'In Progress' 
GO
/****** Object:  StoredProcedure [dbo].[GetOrderAndLocation]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetOrderAndLocation]
	@Id int 
	as 
	select o.TotalPrice ,l.*,so.Status
	from [Order] as o 
	inner join [Location] as l on l.Id = o.LocationId 
	inner join [StatusOrderEnum] as so on so.Id =o.StatusId
	where o.Id = @Id; 
GO
/****** Object:  StoredProcedure [dbo].[GetOrderDrugs]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetOrderDrugs] 
	@Id int
AS 
	SELECT d.Name,od.Quantity
	FROM   [Order] as o 
	inner join OrderDrugs as od on od.OrderId = o.Id
	inner join Drug as d on d.Id = od.DrugsId
	WHERE  o.Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetOrderDrugsDetails]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[GetOrderDrugsDetails]
	@Id int
AS 
	SELECT d.Name , d.Price , d.PicturePath ,od.Quantity 
	FROM   [Order] as o 
	
	inner join OrderDrugs as od on od.OrderId = o.Id
	inner join Drug as d on d.Id = od.DrugsId
	WHERE  o.Id = @Id

GO
/****** Object:  StoredProcedure [dbo].[GetPaitentByUserId]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetPaitentByUserId]
@userId int 
as 
begin 
select p.* from [Patient] as p
where p.UserId = @userId
end
GO
/****** Object:  StoredProcedure [dbo].[GetPasswordByEmail]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetPasswordByEmail]
@Email varchar(150)
as 
select u.PasswordHash from [User] as u
where u.Email = @Email
GO
/****** Object:  StoredProcedure [dbo].[GetPatientDrugById]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetPatientDrugById]
@Id int
as 
begin
select * from PatientDrugs as pd
where pd.Id = @Id 
end 
GO
/****** Object:  StoredProcedure [dbo].[GetPatientStatsLast5Year]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetPatientStatsLast5Year]
as
begin
DECLARE @myTableVariable TABLE (Year INT, Count float(50));
Declare @y1 int;
Declare @y2 int;
Declare @y3 int;
Declare @y4 int;
Declare @y5 int;
Set @y1= YEAR(DATEADD(year, 0, GETDATE())) ; 
Set @y2= YEAR(DATEADD(year, -1, GETDATE())) ; 
Set @y3= YEAR(DATEADD(year, -2, GETDATE())) ; 
Set @y4= YEAR(DATEADD(year, -3, GETDATE())) ; 
Set @y5= YEAR(DATEADD(year, -4, GETDATE())) ; 

BEGIN
   insert into @myTableVariable values
   (@y1,(select   count(*) 'Count'
from [dbo].[User] o 
where YEAR(CreatedOn) =  YEAR(DATEADD(year, 0, GETDATE())) )),
(@y2,(select   count(*) 'Count'
from [dbo].[User] o 
where YEAR(CreatedOn) =  YEAR(DATEADD(year, -1, GETDATE())) )),
(@y3,(select   count(*) 'Count'
from [dbo].[User] o 
where YEAR(CreatedOn) =  YEAR(DATEADD(year, -2, GETDATE())) )),
(@y4,(select   count(*) 'Count'
from [dbo].[User] o 
where YEAR(CreatedOn) =  YEAR(DATEADD(year, -3, GETDATE())) )),
(@y5,(select   count(*) 'Count'
from [dbo].[User] o 
where YEAR(CreatedOn) =  YEAR(DATEADD(year, -4, GETDATE())) ));
   select * from @myTableVariable order by Year 
END;
end
GO
/****** Object:  StoredProcedure [dbo].[GetPatientWater]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetPatientWater]
    @PatientId int
AS 

	SELECT * 
	FROM   [dbo].[Water] 
	WHERE   PatientId = @PatientId

GO
/****** Object:  StoredProcedure [dbo].[GetPaymentOrders]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetPaymentOrders]
as
begin
select d.Name 'DrugName',d.Price*od.Quantity 'TotalPrice' ,od.CreatedOn 'OrderDate',od.Quantity 'Quantity'
from Drug d,OrderDrugs od
where d.Id=od.DrugsId
end
GO
/****** Object:  StoredProcedure [dbo].[GetPlacedOrders]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetPlacedOrders]
   
AS 

	SELECT l.*,o.Id as 'OrderId'
	FROM   StatusOrderEnum as so 
	inner join [order] as o on o.StatusId = so.Id
	inner join [Location] as l on l.Id = o.LocationId
	WHERE  so.Status = 'Placed' 
GO
/****** Object:  StoredProcedure [dbo].[GetRefreshTokenByUserId]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetRefreshTokenByUserId] 
    @UserId int
AS 

	SELECT RefreshToken as 'RToken'
	FROM   [dbo].[RefreshToken] 
	WHERE  UserId = @UserId 
GO
/****** Object:  StoredProcedure [dbo].[getRegisteredAnnual]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getRegisteredAnnual]
as 
begin
select count(*) 'RegisteredAnnualCount'
from [dbo].[User]
where YEAR(CreatedOn) = YEAR(GETDATE())
end
GO
/****** Object:  StoredProcedure [dbo].[getRegisteredDaily]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getRegisteredDaily]
as 
begin
select count(*) 'RegisteredDailyCount'
from [dbo].[User]
where Day(CreatedOn) = Day(GETDATE())
end
GO
/****** Object:  StoredProcedure [dbo].[getRegisteredMonthly]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getRegisteredMonthly]
as 
begin
select count(*) 'RegisteredMonthlyCount'
from [dbo].[User]
where MONTH(CreatedOn) = MONTH(GETDATE())
end
GO
/****** Object:  StoredProcedure [dbo].[GetRoleIdByName]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetRoleIdByName]
@Name varchar(50)
as 
select r.Id from Roles as r
where r.Name = @Name
GO
/****** Object:  StoredProcedure [dbo].[GetRoleyNameById]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetRoleyNameById]
@Id int
as 
select r.Name from Roles as r
where r.Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetSalesStatsLast5Year]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[GetSalesStatsLast5Year]
as
begin
DECLARE @myTableVariable TABLE (Year INT, Total float(50));
Declare @y1 int;
Declare @y2 int;
Declare @y3 int;
Declare @y4 int;
Declare @y5 int;
Set @y1= YEAR(DATEADD(year, 0, GETDATE())) ; 
Set @y2= YEAR(DATEADD(year, -1, GETDATE())) ; 
Set @y3= YEAR(DATEADD(year, -2, GETDATE())) ; 
Set @y4= YEAR(DATEADD(year, -3, GETDATE())) ; 
Set @y5= YEAR(DATEADD(year, -4, GETDATE())) ; 

BEGIN
insert into @myTableVariable values
(@y1,(select  sum(TotalPrice) 'Total'
from [dbo].[Order] o 
where YEAR(CreatedOn) =  YEAR(DATEADD(year, 0, GETDATE())) )),
(@y2,(select  sum(TotalPrice) 'Total'
from [dbo].[Order] o 
where YEAR(CreatedOn) =  YEAR(DATEADD(year, -1, GETDATE())) )),
(@y3,(select  sum(TotalPrice) 'Total'
from [dbo].[Order] o 
where YEAR(CreatedOn) =  YEAR(DATEADD(year, -2, GETDATE())) )),
(@y4,(select  sum(TotalPrice) 'Total'
from [dbo].[Order] o 
where YEAR(CreatedOn) =  YEAR(DATEADD(year, -3, GETDATE())) )),
(@y5,(select  sum(TotalPrice) 'Total'
from [dbo].[Order] o 
where YEAR(CreatedOn) =  YEAR(DATEADD(year, -4, GETDATE())) ));
   select * from @myTableVariable
END;

end
GO
/****** Object:  StoredProcedure [dbo].[GetSartWork]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetSartWork]
 @EmployeeId int
 as
 select * from Work 
 where convert(varchar(10), StartDate, 120) = convert(varchar(10), GetDate(), 120) 
 and EmployeeId = @EmployeeId
GO
/****** Object:  StoredProcedure [dbo].[GetUserByEmail]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetUserByEmail]
@Email varchar(150)
as 
select * from [User] as u 
where u.Email = @Email
GO
/****** Object:  StoredProcedure [dbo].[GetUserIdByEmial]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetUserIdByEmial]
@Email varchar(150)
as 
begin 

select id from [User]
where Email = @Email
end 
GO
/****** Object:  StoredProcedure [dbo].[GetUserLocations]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetUserLocations] 
@Id int 
as 
begin 
select * From Location 
where [UserId] = @Id
end 
GO
/****** Object:  StoredProcedure [dbo].[GetUserOrder]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[GetUserOrder] 
    @PatientId int
AS 

	SELECT o.Id,o.TotalPrice,o.CreatedOn , so.Status
	FROM   [dbo].[Order] as o
	inner join StatusOrderEnum as so on so.Id = o.StatusId
	WHERE  (PatientId = @PatientId) 
GO
/****** Object:  StoredProcedure [dbo].[GetWaterByUserId]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetWaterByUserId]
 @userId int
as 
begin 

select w.Every ,w.[From],w.[To] , w.Id  from [User]as u
inner join Patient as p on u.Id = p.UserId
inner join Water as w on p.Id = w.PatientId
where u.Id = @userId
end 
GO
/****** Object:  StoredProcedure [dbo].[HealthReportDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[HealthReportDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[HealthReport]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[HealthReportGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[HealthReportGetAll]
as 
begin 
select * from HealthReport
end
GO
/****** Object:  StoredProcedure [dbo].[HealthReportInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[HealthReportInsert] 
    @CreatedOn datetime2(7),
    @PatientId int,
    @TypeId varchar(250),
    @Value float
AS 

	INSERT INTO [dbo].[HealthReport] ([CreatedOn], [PatientId], [Type], [Value])
	SELECT @CreatedOn, @PatientId, @TypeId, @Value
	
GO
/****** Object:  StoredProcedure [dbo].[HealthReportSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[HealthReportSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [PatientId], [Type], [Value] 
	FROM   [dbo].[HealthReport] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[HealthReportTypesDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[HealthReportTypesDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[HealthReportTypes]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[HealthReportTypesGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[HealthReportTypesGetAll]
as 
begin 
select * from HealthReportTypes
end
GO
/****** Object:  StoredProcedure [dbo].[HealthReportTypesInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[HealthReportTypesInsert] 
    @CreatedOn datetime2(7),
    @Type nvarchar(150)
AS 

	INSERT INTO [dbo].[HealthReportTypes] ([CreatedOn], [Type])
	SELECT @CreatedOn, @Type
	
GO
/****** Object:  StoredProcedure [dbo].[HealthReportTypesSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[HealthReportTypesSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [Type] 
	FROM   [dbo].[HealthReportTypes] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[HealthReportTypesUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[HealthReportTypesUpdate] 
    @Id int,
    @CreatedOn datetime2(7),
    @Type nvarchar(150)
AS 

	UPDATE [dbo].[HealthReportTypes]
	SET    [CreatedOn] = @CreatedOn, [Type] = @Type
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[HealthReportUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[HealthReportUpdate] 
    @Id int,
    @CreatedOn datetime2(7),
    @PatientId int,
    @TypeId varchar(250),
    @Value float
AS 

	UPDATE [dbo].[HealthReport]
	SET    [CreatedOn] = @CreatedOn, [PatientId] = @PatientId, [Type] = @TypeId, [Value] = @Value
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[InsertPDFData]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[InsertPDFData]
@PatientId INT ,
@CreatedOn DATE,
@CheckUpName nvarchar(max)=null,
@BloodType nvarchar(max)=null,
@BloodSugarLevel nvarchar(max)=null,
@CheckUpDate nvarchar(max)=NULL
AS
BEGIN

INSERT INTO dbo.HealthReport
(
CreatedOn,
PatientId,
Type,
Value
)
VALUES
( @CreatedOn, -- CreatedOn - datetime2(0)
@PatientId, -- PatientId - int
'CheckUpName', -- Type - varchar(250)
@CheckUpName -- Value - varchar(250)
)
INSERT INTO dbo.HealthReport
(
CreatedOn,
PatientId,
Type,
Value
)
VALUES
( @CreatedOn, -- CreatedOn - datetime2(0)
@PatientId, -- PatientId - int
'BloodType', -- Type - varchar(250)
@BloodType -- Value - varchar(250)
)
INSERT INTO dbo.HealthReport
(
CreatedOn,
PatientId,
Type,
Value
)
VALUES
( @CreatedOn, -- CreatedOn - datetime2(0)
@PatientId, -- PatientId - int
'BloodSugarLevel ', -- Type - varchar(250)
@BloodSugarLevel -- Value - varchar(250)
)
INSERT INTO dbo.HealthReport
(
CreatedOn,
PatientId,
Type,
Value
)
VALUES
( @CreatedOn, -- CreatedOn - datetime2(0)
@PatientId, -- PatientId - int
'CheckUpDate', -- Type - varchar(250)
@CheckUpDate -- Value - varchar(250)
)




END

GO
/****** Object:  StoredProcedure [dbo].[LocationDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LocationDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[Location]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[LocationInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LocationInsert] 
    @AddressName varchar(50) ,
	@UserId int , 
	@PhoneNumber varchar(50), 
	@City varchar(50),
	@ZipCode int , 
	@Details varchar(250), 
	@Street varchar(250),
	@Lat Decimal(8,6),
	@Lng Decimal(8,6)
AS 
	INSERT INTO [dbo].[Location] (AddressName,CreatedOn,UserId ,PhoneNumber,City,ZipCode,Details,Street ,lat,lng)
	values( @AddressName,GETDATE(),@UserId,@PhoneNumber,@City,@ZipCode,@Details,@Street,@Lat,@Lng)
	
GO
/****** Object:  StoredProcedure [dbo].[LocationSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LocationSelect] 
    @Id int
AS 

	SELECT *
	FROM   [dbo].[Location] 
	WHERE  [Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[LocationUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LocationUpdate]
    @Id int,
    @AddressName varchar(50),
    @PhoneNumber varchar(50),
    @City varchar(50),
    @ZipCode int,
    @Details varchar(250),
    @Street varchar(250),
    @lat decimal(8, 6),
    @lng decimal(8, 6)
AS 

	UPDATE [dbo].[Location]
	SET    [AddressName] = @AddressName,  [PhoneNumber] = @PhoneNumber, [City] = @City, [ZipCode] = @ZipCode, [Details] = @Details, [Street] = @Street, [lat] = @lat, [lng] = @lng
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[MinusQuantity]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[MinusQuantity]
@CartId int
as 
update Cart 
set Quantity = Quantity-1
where Id = @CartId
GO
/****** Object:  StoredProcedure [dbo].[MonthlyCareSystemReport]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[MonthlyCareSystemReport]
as
begin
select u.FirstName+' '+u.LastName 'Name',TotalPrice 'OrderAmount',TotalPrice*0.05 'Profits', CAST( o.CreatedOn AS Date ) 'OrderDate'
from Patient p ,[dbo].[Order]  o , [dbo].[User] u
where p.Id = o.PatientId and u.Id=p.UserId and MONTH(o.CreatedOn) = MONTH(GETDATE())
end
GO
/****** Object:  StoredProcedure [dbo].[NotificationDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[NotificationDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[Notification]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[NotificationGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[NotificationGetAll]
as 
begin 
select * from [Notification]
end
GO
/****** Object:  StoredProcedure [dbo].[NotificationInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[NotificationInsert]
 @CreatedOn datetime2(7),
 @Massage varchar(1500),
 @PatientId int
 as
 insert into Notification(CreatedOn, Message, PatientId)
 values(@CreatedOn,@Massage,@PatientId)
GO
/****** Object:  StoredProcedure [dbo].[OrderDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OrderDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[Order]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[OrderDeliverd]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[OrderDeliverd]
@id int
as
begin
update [dbo].[Order]
set StatusId=3
where Id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[OrderDrugsDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OrderDrugsDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[OrderDrugs]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[OrderDrugsGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[OrderDrugsGetAll]
as 
begin 
select * from OrderDrugs
end
GO
/****** Object:  StoredProcedure [dbo].[OrderDrugsInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OrderDrugsInsert] 
    @OrderId int ,
    @CartId int
AS 
	DECLARE @DrugsId as int;
	DECLARE @Quantity as int;
	
    SELECT @DrugsId = DrugId,@Quantity = Quantity FROM Cart where Id = @CartId;
	INSERT INTO [dbo].[OrderDrugs] ([CreatedOn], [Quantity], [DrugsId], [OrderId])
	values(GETDATE(), @Quantity, @DrugsId, @OrderId)

	delete from Cart
	where Id = @CartId
	
GO
/****** Object:  StoredProcedure [dbo].[OrderDrugsSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[OrderDrugsSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [Quantity], [DrugsId], [OrderId] 
	FROM   [dbo].[OrderDrugs] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[OrderDrugsUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[OrderDrugsUpdate] 
    @Id int,
    @CreatedOn datetime2(7),
    @Quantity int,
    @DrugsId int,
    @OrderId int
AS 

	UPDATE [dbo].[OrderDrugs]
	SET    [CreatedOn] = @CreatedOn, [Quantity] = @Quantity, [DrugsId] = @DrugsId, [OrderId] = @OrderId
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[OrderGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[OrderGetAll]
as 
begin 
select * from [Order]
end
GO
/****** Object:  StoredProcedure [dbo].[OrderInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OrderInsert] 
    @TotalPrice float,
    @PatientId int,
    @LocationId int
AS 

	DECLARE @StatusId AS int 
	set @StatusId = (select Id From StatusOrderEnum as so where so.Status = 'In Progress');
	INSERT INTO [dbo].[Order] ([CreatedOn], [TotalPrice], [StatusId],  [PatientId], [LocationId])
	values(GETDATE(), @TotalPrice, @StatusId,  @PatientId, @LocationId)
	select SCOPE_IDENTITY();
	
GO
/****** Object:  StoredProcedure [dbo].[OrderSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[OrderSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [TotalPrice], [StatusId], [DeliveryId], [PatientId] 
	FROM   [dbo].[Order] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[OrderUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[OrderUpdate] 
    @Id int,
    @CreatedOn datetime2(7),
    @TotalPrice float,
    @StatusId int,
    @DeliveryId int = NULL,
    @PatientId int
AS 

	UPDATE [dbo].[Order]
	SET    [CreatedOn] = @CreatedOn, [TotalPrice] = @TotalPrice, [StatusId] = @StatusId, [DeliveryId] = @DeliveryId, [PatientId] = @PatientId
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[PatientDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PatientDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[Patient]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[PatientDrugsDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PatientDrugsDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[PatientDrugs]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[PatientDrugsGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[PatientDrugsGetAll]
as 
begin 
select * from PatientDrugs
end
GO
/****** Object:  StoredProcedure [dbo].[PatientDrugsInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PatientDrugsInsert] 
    @CreatedOn datetime2(7),
    @PatientId int,
    @StartDate datetime2(7),
    @EndDate datetime2(7) = NULL,
	@DrugName varchar(150)
AS 

	INSERT INTO [dbo].[PatientDrugs] ([DrugName],[CreatedOn], [PatientId], [StartDate], [EndDate])
	SELECT @DrugName,@CreatedOn, @PatientId,  @StartDate, @EndDate
	SELECT SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[PatientDrugsSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[PatientDrugsSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [PatientId],  [StartDate], [EndDate] 
	FROM   [dbo].[PatientDrugs] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[PatientDrugsUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PatientDrugsUpdate] 
    @Id int,
    @DrugName varchar(150),
    @EndDate datetime2(7) = NULL
AS 

	UPDATE [dbo].[PatientDrugs]
	SET    [EndDate] = @EndDate ,DrugName = @DrugName
	WHERE  [Id] = @Id
	SELECT @Id
GO
/****** Object:  StoredProcedure [dbo].[PatientGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[PatientGetAll]
as 
begin 
select * from Patient
end
GO
/****** Object:  StoredProcedure [dbo].[PatientInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PatientInsert] 
    @CreatedOn datetime2(7),
    @UserId int,
    @Liters float,
    @SubscriptionValidation datetime2(7) = NULL
AS 

	INSERT INTO [dbo].[Patient] ([CreatedOn], [UserId], [Liters], [SubscriptionValidation])
	SELECT @CreatedOn, @UserId, @Liters, @SubscriptionValidation
	update [User]
	set PatientId = SCOPE_IDENTITY()
	where Id = @UserId
GO
/****** Object:  StoredProcedure [dbo].[PatientSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[PatientSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [UserId], [Liters], [SubscriptionValidation] 
	FROM   [dbo].[Patient] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[PatientUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PatientUpdate] 
    @Id int,
    @CreatedOn datetime2(7),
    @UserId int,
    @Liters float,
    @SubscriptionValidation datetime2(7) = NULL
AS 

	UPDATE [dbo].[Patient]
	SET    [CreatedOn] = @CreatedOn, [UserId] = @UserId, [Liters] = @Liters, [SubscriptionValidation] = @SubscriptionValidation
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[RefreshTokenInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[RefreshTokenInsert] 
    @UserId int,
    @RefreshToken varchar(250)
AS 
	delete from RefreshToken
	where [UserId] = @UserId

	INSERT INTO [dbo].[RefreshToken] ([UserId], [RefreshToken], [CreatedOn])
	SELECT @UserId, @RefreshToken, GETDATE()
	
GO
/****** Object:  StoredProcedure [dbo].[RolesDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[RolesDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[Roles]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[RolesInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[RolesInsert] 
    @Name nvarchar(50)
AS 

	INSERT INTO [dbo].[Roles] ([CreatedOn], [Name])
	SELECT GETDATE(), @Name
	
GO
/****** Object:  StoredProcedure [dbo].[RolesSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[RolesSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [Name] 
	FROM   [dbo].[Roles] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[RolesUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[RolesUpdate] 
    @Id int,
    @CreatedOn datetime2(7),
    @Name nvarchar(50)
AS 

	UPDATE [dbo].[Roles]
	SET    [CreatedOn] = @CreatedOn, [Name] = @Name
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[SearchInByDatePaymentOrders]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SearchInByDatePaymentOrders]
@from datetime2,
@to datetime2
as
begin
select d.Name 'DrugName',d.Price*od.Quantity 'TotalPrice' ,od.CreatedOn 'OrderDate',od.Quantity 'Quantity'
from Drug d,OrderDrugs od
where d.Id=od.DrugsId and od.CreatedOn >@from and od.CreatedOn<@to
end
GO
/****** Object:  StoredProcedure [dbo].[SetOrderAsCanceled]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SetOrderAsCanceled]
    @Id int 
AS 
	DECLARE @StatusId AS int 
	set @StatusId = (select Id From StatusOrderEnum as so where so.Status = 'Canceled');
	UPDATE [dbo].[Order]
	SET   [StatusId] = @StatusId
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[SetOrderAsPlaced]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SetOrderAsPlaced]
    @Id int 
AS 
	DECLARE @StatusId AS int 
	set @StatusId = (select Id From StatusOrderEnum as so where so.Status = 'Placed');
	UPDATE [dbo].[Order]
	SET   [StatusId] = @StatusId
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[StartWork]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[StartWork]
 @CreatedOn datetime2(7),
 @StartDate datetime2(7),
 @EmployeeId int
 as
 insert into Work(CreatedOn,StartDate,EmployeeId)
 values(@CreatedOn,@StartDate,@EmployeeId)
GO
/****** Object:  StoredProcedure [dbo].[StatusOrderEnumDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[StatusOrderEnumDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[StatusOrderEnum]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[StatusOrderEnumInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[StatusOrderEnumInsert] 
    @CreatedOn datetime2(7),
    @Status nvarchar(MAX)
AS 

	INSERT INTO [dbo].[StatusOrderEnum] ([CreatedOn], [Status])
	SELECT @CreatedOn, @Status
	
GO
/****** Object:  StoredProcedure [dbo].[StatusOrderEnumSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[StatusOrderEnumSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [Status] 
	FROM   [dbo].[StatusOrderEnum] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[StatusOrderEnumUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[StatusOrderEnumUpdate] 
    @Id int,
    @CreatedOn datetime2(7),
    @Status nvarchar(MAX)
AS 

	UPDATE [dbo].[StatusOrderEnum]
	SET    [CreatedOn] = @CreatedOn, [Status] = @Status
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[SubscribeTypeDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SubscribeTypeDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[SubscribeType]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[SubscribeTypeInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SubscribeTypeInsert] 
    @CreatedOn datetime2(7),
    @Type nvarchar(150),
    @SubscribePrice float,
    @SubscribeDescription nvarchar(1000),
    @Days int
AS 

	INSERT INTO [dbo].[SubscribeType] ([CreatedOn], [Type], [SubscribePrice], [SubscribeDescription], [Days])
	SELECT @CreatedOn, @Type, @SubscribePrice, @SubscribeDescription, @Days
	
GO
/****** Object:  StoredProcedure [dbo].[SubscribeTypeSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SubscribeTypeSelect] 
    @Id int
AS 

	SELECT * 
	FROM   [dbo].[SubscribeType] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[SubscribeTypeUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SubscribeTypeUpdate] 
    @Id int,
    @CreatedOn datetime2(7),
    @Type nvarchar(150),
    @SubscribePrice float,
    @SubscribeDescription nvarchar(1000),
    @Days int
AS 

	UPDATE [dbo].[SubscribeType]
	SET    [CreatedOn] = @CreatedOn, [Type] = @Type, [SubscribePrice] = @SubscribePrice, [SubscribeDescription] = @SubscribeDescription, [Days] = @Days
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[SubscriptionDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SubscriptionDelete]
@PatientId int
AS



DELETE
FROM [dbo].[Subscription]
WHERE PatientId = @PatientId
GO
/****** Object:  StoredProcedure [dbo].[SubscriptionGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SubscriptionGetAll]
as
begin 
select u.FirstName+' '+u.LastName 'Name' ,u.PhoneNumber 'PhoneNumber',u.Email 'Email'
from [dbo].[User] u,Patient p ,Subscription s
where p.Id=s.PatientId and u.Id=p.UserId and s.Expirationdate< CAST( GETDATE() AS Date )
end
GO
/****** Object:  StoredProcedure [dbo].[SubscriptionInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SubscriptionInsert]
@CreatedOn datetime2(7),
@PatientId int,
@SubscribeTypeId int
AS

INSERT INTO [dbo].[Subscription] ([CreatedOn], [PatientId], [SubscribeTypeId],[Expirationdate])
SELECT @CreatedOn, @PatientId, @SubscribeTypeId,(DATEADD(day,
(SELECT Days FROM dbo.SubscribeType WHERE Id=@SubscribeTypeId),
CONVERT(date, getdate())) )
GO
/****** Object:  StoredProcedure [dbo].[SubscriptionPayment]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SubscriptionPayment]
@CardNumber INT,
@Expirydate VARCHAR(50),
@cvcCode INT,
@CardName VARCHAR(250)
AS
BEGIN
SELECT CardNumber,Expirydate,cvcCode,CardName
FROM dbo.Payment
WHERE CardNumber = @CardNumber
END
GO
/****** Object:  StoredProcedure [dbo].[SubscriptionSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SubscriptionSelect]
@PatientId int
AS
SELECT *
FROM [dbo].[Subscription]
WHERE ([Id] = @PatientId OR @PatientId IS NULL)
GO
/****** Object:  StoredProcedure [dbo].[SubscriptionTypeGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SubscriptionTypeGetAll]
as 
begin 
select * from SubscriptionType
end
GO
/****** Object:  StoredProcedure [dbo].[SubscriptionUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SubscriptionUpdate]
@PatientId int,
@SubscribeTypeId int
AS

UPDATE [dbo].[Subscription]
SET [SubscribeTypeId] = @SubscribeTypeId , Expirationdate=(DATEADD(day,
(SELECT Days FROM dbo.SubscribeType WHERE Id=@SubscribeTypeId),
(SELECT Expirationdate FROM dbo.Subscription WHERE PatientId=@PatientId)))
WHERE PatientId = @PatientId
GO
/****** Object:  StoredProcedure [dbo].[TakeOrder]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[TakeOrder]
@OrderId int,
@DeliveryId int
as
begin
	DECLARE @StatusId AS int 
	set @StatusId = (select Id From StatusOrderEnum as so where so.Status = 'Out for delivery');
	update [Order]
	set StatusId=@StatusId , DeliveryId = @DeliveryId
	where Id = @OrderId
end
GO
/****** Object:  StoredProcedure [dbo].[TestimonialInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TestimonialInsert] 
    @created_at datetime = NULL,
    @userName varchar(50) = NULL,
    @userSubject varchar(50) = NULL,
    @userEmail varchar(50) = NULL,
    @userPhone varchar(50) = NULL,
    @userMessage varchar(50) = NULL,
    @isProved bit = NULL
AS 

	INSERT INTO [dbo].[Testimonial] ([created_at], [userName], [userSubject], [userEmail], [userPhone], [userMessage], [isProved])
	SELECT @created_at, @userName, @userSubject, @userEmail, @userPhone, @userMessage, @isProved
	
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserPassword]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[UpdateUserPassword] 
    @Id int,
    @PasswordHash nvarchar(100)
   
AS 

	UPDATE [dbo].[User]
	SET     [PasswordHash] = @PasswordHash
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[UserDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UserDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[User]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[UserInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UserInsert] 
    @CreatedOn datetime2(7),
    @Email nvarchar(150),
    @PasswordHash nvarchar(100),
    @PhoneNumber nvarchar(15),
    @FirstName nvarchar(50),
    @LastName nvarchar(50),
    @ProfilePicturePath nvarchar(250) = NULL,
    @EmployeeId int = NULL,
    @PatientId int = NULL,
	@RoleId int 
AS 

	INSERT INTO [dbo].[User] ([CreatedOn], [Email], [PasswordHash], [PhoneNumber], [FirstName], [LastName], [ProfilePicturePath],  [EmployeeId], [PatientId],RoleId)
	SELECT @CreatedOn, @Email, @PasswordHash, @PhoneNumber, @FirstName, @LastName, @ProfilePicturePath,  @EmployeeId, @PatientId,@RoleId
	SELECT SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[UserLoginsDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UserLoginsDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[UserLogins]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[UserLoginsGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UserLoginsGetAll]
as 
begin 
select * from UserLogins
end
GO
/****** Object:  StoredProcedure [dbo].[UserLoginsInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UserLoginsInsert] 
    @CreatedOn datetime2(7),
    @LoginProvider nvarchar(MAX) = NULL,
    @ProviderKey nvarchar(MAX) = NULL,
    @ProviderDisplayName nvarchar(MAX) = NULL,
    @UserId int
AS 

	INSERT INTO [dbo].[UserLogins] ([CreatedOn], [LoginProvider], [ProviderKey], [ProviderDisplayName], [UserId])
	SELECT @CreatedOn, @LoginProvider, @ProviderKey, @ProviderDisplayName, @UserId
	
GO
/****** Object:  StoredProcedure [dbo].[UserLoginsSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[UserLoginsSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [LoginProvider], [ProviderKey], [ProviderDisplayName], [UserId] 
	FROM   [dbo].[UserLogins] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[UserLoginsUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[UserLoginsUpdate] 
    @Id int,
    @CreatedOn datetime2(7),
    @LoginProvider nvarchar(MAX) = NULL,
    @ProviderKey nvarchar(MAX) = NULL,
    @ProviderDisplayName nvarchar(MAX) = NULL,
    @UserId int
AS 

	UPDATE [dbo].[UserLogins]
	SET    [CreatedOn] = @CreatedOn, [LoginProvider] = @LoginProvider, [ProviderKey] = @ProviderKey, [ProviderDisplayName] = @ProviderDisplayName, [UserId] = @UserId
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[UserSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[UserSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [Email], [PasswordHash], [PhoneNumber], [FirstName], [LastName], [ProfilePicturePath],  [EmployeeId], [PatientId] 
	FROM   [dbo].[User] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[UsersGetAll]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UsersGetAll]
as 
begin 
select * from [User]
end
GO
/****** Object:  StoredProcedure [dbo].[UserTokensDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UserTokensDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[UserTokens]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[UserTokensInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UserTokensInsert] 
    @CreatedOn datetime2(7),
    @UserId int,
    @LoginProvider nvarchar(MAX) = NULL,
    @Name nvarchar(MAX) = NULL,
    @Value nvarchar(MAX) = NULL
AS 

	INSERT INTO [dbo].[UserTokens] ([CreatedOn], [UserId], [LoginProvider], [Name], [Value])
	SELECT @CreatedOn, @UserId, @LoginProvider, @Name, @Value
	
GO
/****** Object:  StoredProcedure [dbo].[UserTokensSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[UserTokensSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [UserId], [LoginProvider], [Name], [Value] 
	FROM   [dbo].[UserTokens] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[UserTokensUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[UserTokensUpdate] 
    @Id int,
    @CreatedOn datetime2(7),
    @UserId int,
    @LoginProvider nvarchar(MAX) = NULL,
    @Name nvarchar(MAX) = NULL,
    @Value nvarchar(MAX) = NULL
AS 

	UPDATE [dbo].[UserTokens]
	SET    [CreatedOn] = @CreatedOn, [UserId] = @UserId, [LoginProvider] = @LoginProvider, [Name] = @Name, [Value] = @Value
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[UserUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UserUpdate] 
    @Id int,
    @PhoneNumber nvarchar(15),
    @FirstName nvarchar(50),
    @LastName nvarchar(50)
AS 

	UPDATE [dbo].[User]
	SET       [PhoneNumber] = @PhoneNumber, [FirstName] = @FirstName, [LastName] = @LastName
	WHERE  [Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[WaterDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[WaterDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[Water]
	WHERE  [Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[WaterInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[WaterInsert] 
    @PatientId int,
    @Every int,
    @From time(0),
    @To time(0)
AS 

	INSERT INTO [dbo].[Water] ([CreatedOn], [PatientId], [Every], [From], [To])
	values(GETDATE(), @PatientId, @Every, @From, @To)
	
GO
/****** Object:  StoredProcedure [dbo].[WaterUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[WaterUpdate] 
    @Id int,
    @Every int,
    @From time(0),
    @To time(0)
AS 

	UPDATE [dbo].[Water]
	SET    [Every] = @Every, [From] = @From, [To] = @To
	WHERE  [Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[WorkDelete]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[WorkDelete] 
    @Id int
AS 

	DELETE
	FROM   [dbo].[Work]
	WHERE  [Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[WorkInsert]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[WorkInsert] 
    @CreatedOn datetime2(7),
    @StartDate datetime2(7),
    @EndDate datetime2(7) = NULL,
    @EmployeeId int
AS 

	INSERT INTO [dbo].[Work] ([CreatedOn], [StartDate], [EndDate], [EmployeeId])
	SELECT @CreatedOn, @StartDate, @EndDate, @EmployeeId
	
GO
/****** Object:  StoredProcedure [dbo].[WorkSelect]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[WorkSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [StartDate], [EndDate], [EmployeeId] 
	FROM   [dbo].[Work] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[WorkUpdate]    Script Date: 12/18/2021 8:50:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[WorkUpdate] 
    @Id int,
    @CreatedOn datetime2(7),
    @StartDate datetime2(7),
    @EndDate datetime2(7) = NULL,
    @EmployeeId int
AS 

	UPDATE [dbo].[Work]
	SET    [CreatedOn] = @CreatedOn, [StartDate] = @StartDate, [EndDate] = @EndDate, [EmployeeId] = @EmployeeId
	WHERE  [Id] = @Id
	
GO
