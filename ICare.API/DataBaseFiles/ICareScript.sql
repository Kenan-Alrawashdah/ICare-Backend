USE [ICare-Database13]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[PatientId] [int] NOT NULL,
	[DrugId] [int] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  Table [dbo].[Drug]    Script Date: 11/27/2021 7:15:25 PM ******/
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
	[PicturePath] [nvarchar](250) NULL,
 CONSTRAINT [PK_Drug] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DrugCategory]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  Table [dbo].[DrugDoseTime]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[HourSalary] [float] NOT NULL,
	[MonthlyWorkingHours] [int] NOT NULL,
	[PricePerHour] [float] NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HealthReport]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  Table [dbo].[Location]    Script Date: 11/27/2021 7:15:25 PM ******/
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
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 11/27/2021 7:15:25 PM ******/
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
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDrugs]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  Table [dbo].[Patient]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  Table [dbo].[PatientDrugs]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  Table [dbo].[Payment]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[Bank_Id] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [int] NULL,
	[Expirydate] [varchar](50) NULL,
	[cvcCode] [int] NULL,
	[CardName] [varchar](250) NULL,
	[Balance] [decimal](18, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[Bank_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  Table [dbo].[StatusOrderEnum]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  Table [dbo].[SubscribeType]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscribeType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[Type] [nvarchar](150) NOT NULL,
	[SubscribePrice] [float] NOT NULL,
	[SubscribeDescription] [nvarchar](1000) NOT NULL,
	[Days] [int] NOT NULL,
 CONSTRAINT [PK_SubscribeType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscription]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  Table [dbo].[UserLogins]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  Table [dbo].[UserTokens]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  Table [dbo].[Water]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  Table [dbo].[Work]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[AddOrUpdateProfilePicture]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[AuthLogin]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AuthLogin]
@Email varchar(50)
as 
select  u.FirstName as "FirstName", u.Email as "Email" , u.Id as "Id",RoleId as "RoleId"
from [User] as u
where u.Email = @Email 
GO
/****** Object:  StoredProcedure [dbo].[CartDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[CartGetAll]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[CartInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CartInsert] 
    @CreatedOn datetime2(7),
    @PatientId int,
    @DrugId int
AS 

	INSERT INTO [dbo].[Cart] ([CreatedOn], [PatientId], [DrugId])
	SELECT @CreatedOn, @PatientId, @DrugId
	
GO
/****** Object:  StoredProcedure [dbo].[CartSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[CartUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[ChangeUserPassword]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[CheckEmailExist]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteDrugDoseTime]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DeliveryDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DeliveryGetAll]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DeliveryInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DeliverySelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DeliveryUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DrugCategoryDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DrugCategoryGetAll]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DrugCategoryInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DrugCategorySelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DrugCategoryUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DrugDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DrugDoseTimeDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DrugDoseTimeGetAll]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DrugDoseTimeInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DrugDoseTimeSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DrugDoseTimeUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DrugGetAll]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DrugInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DrugInsert] 
    @DrugCategoryId int,
    @Name nvarchar(150),
    @Price float,
    @PicturePath nvarchar(250) = NULL
AS 

	INSERT INTO [dbo].[Drug] ([CreatedOn], [DrugCategoryId], [Name], [Price], [PicturePath])
	SELECT GetDate(), @DrugCategoryId, @Name, @Price, @PicturePath
GO
/****** Object:  StoredProcedure [dbo].[DrugSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[DrugSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [DrugCategoryId], [Name], [Price], [PicturePath] 
	FROM   [dbo].[Drug] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[DrugUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[DrugUpdate] 
    @Id int,
    @CreatedOn datetime2(7),
    @DrugCategoryId int,
    @Name nvarchar(150),
    @Price float,
    @PicturePath nvarchar(250) = NULL
AS 

	UPDATE [dbo].[Drug]
	SET    [CreatedOn] = @CreatedOn, [DrugCategoryId] = @DrugCategoryId, [Name] = @Name, [Price] = @Price, [PicturePath] = @PicturePath
	WHERE  [Id] = @Id
	
GO
/****** Object:  StoredProcedure [dbo].[EmployeeDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[EmployeeInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[EmployeeSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[EmployeesGetAll]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[EmployeeUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[EndWork]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetAllEmployees]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllEmployees]
as begin 
select * from Employee
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllUserLogins]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllUserLogins]
as begin 
select * from UserLogins
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetAllUserTokens]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllUserTokens]
as begin 
select * from UserTokens
end
GO
/****** Object:  StoredProcedure [dbo].[GetBySearch]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetBySearch]
@search nvarchar(max)=null
AS
BEGIN
SELECT d.Name,d.Price,d.PicturePath
FROM dbo.Drug d
where
d.Name LIKE CASE WHEN @search is not null then '%'+@search+'%' else d.Name end
END

GO
/****** Object:  StoredProcedure [dbo].[GetDrugDoseTimeByPatientDrugId]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetDrugsOnTime]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[GetDrugsOnTime]
 as
DECLARE @hour  int
SET @hour = datepart(hour, getdate())
DECLARE @mi  int
SET @mi = datepart(mi, getdate())

 select pd.DrugName as NameDrug , u.Email as Email
 from DrugDoseTime ddt
 inner join PatientDrugs pd on pd.Id = ddt.PatientDrugId
 inner join Patient p on p.Id = pd.PatientId
 inner join [dbo].[User] u on u.Id = p.UserId
 where ddt.time = concat(@hour,':',@mi,':00')
GO
/****** Object:  StoredProcedure [dbo].[GetMyDrugs]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetMyDrugs]
@pathientId int 
as 
begin 
select[Id], [DrugName] , [EndDate] from [PatientDrugs]
where [PatientId] = @pathientId


end
GO
/****** Object:  StoredProcedure [dbo].[GetPaitentByUserId]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetPasswordByEmail]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetPatientDrugById]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetRoleIdByName]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetRoleyNameById]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetSartWork]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetUserByEmail]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetUserIdByEmial]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetUserLocations]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetWaterByUserId]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[HealthReportDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[HealthReportGetAll]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[HealthReportInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[HealthReportSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[HealthReportTypesDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[HealthReportTypesGetAll]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[HealthReportTypesInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[HealthReportTypesSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[HealthReportTypesUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[HealthReportUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[InsertPDFData]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[LocationDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[LocationInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
	@Street varchar(250)
AS 

	INSERT INTO [dbo].[Location] (AddressName,CreatedOn,UserId ,PhoneNumber,City,ZipCode,Details,Street )
	values( @AddressName,GETDATE(),@UserId,@PhoneNumber,@City,@ZipCode,@Details,@Street)
	
GO
/****** Object:  StoredProcedure [dbo].[LocationSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LocationSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [AddressName], [UserId], [PhoneNumber], [City], [ZipCode], [Details], [Street] 
	FROM   [dbo].[Location] 
	WHERE  [Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[LocationUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
    @Street varchar(250)
AS 

	UPDATE [dbo].[Location]
	SET     [AddressName] = @AddressName,  [PhoneNumber] = @PhoneNumber, [City] = @City, [ZipCode] = @ZipCode, [Details] = @Details, [Street] = @Street
	WHERE  [Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[NotificationDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[NotificationGetAll]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[NotificationInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[OrderDrugsDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[OrderDrugsGetAll]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[OrderDrugsInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OrderDrugsInsert] 
    @CreatedOn datetime2(7),
    @Quantity int,
    @DrugsId int,
    @OrderId int
AS 

	INSERT INTO [dbo].[OrderDrugs] ([CreatedOn], [Quantity], [DrugsId], [OrderId])
	SELECT @CreatedOn, @Quantity, @DrugsId, @OrderId
	
GO
/****** Object:  StoredProcedure [dbo].[OrderDrugsSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[OrderDrugsUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[OrderGetAll]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[OrderInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OrderInsert] 
    @CreatedOn datetime2(7),
    @TotalPrice float,
    @StatusId int,
    @DeliveryId int = NULL,
    @PatientId int
AS 

	INSERT INTO [dbo].[Order] ([CreatedOn], [TotalPrice], [StatusId], [DeliveryId], [PatientId])
	SELECT @CreatedOn, @TotalPrice, @StatusId, @DeliveryId, @PatientId
	
GO
/****** Object:  StoredProcedure [dbo].[OrderSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[OrderUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[PatientDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[PatientDrugsDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[PatientDrugsGetAll]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[PatientDrugsInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[PatientDrugsSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[PatientDrugsUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[PatientGetAll]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[PatientInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[PatientSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[PatientUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[RolesDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[RolesInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[RolesSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[RolesUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[StartWork]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[StatusOrderEnumDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[StatusOrderEnumInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[StatusOrderEnumSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[StatusOrderEnumUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SubscribeTypeDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SubscribeTypeInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SubscribeTypeSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE PROC [dbo].[SubscribeTypeSelect] 
    @Id int
AS 

	SELECT [Id], [CreatedOn], [Type], [SubscribePrice], [SubscribeDescription], [Days] 
	FROM   [dbo].[SubscribeType] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

GO
/****** Object:  StoredProcedure [dbo].[SubscribeTypeUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SubscriptionDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SubscriptionInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SubscriptionPayment]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SubscriptionSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SubscriptionTypeGetAll]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SubscriptionUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserLoginsDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserLoginsGetAll]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserLoginsInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserLoginsSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserLoginsUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UsersGetAll]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserTokensDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserTokensInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserTokensSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserTokensUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UserUpdate] 
    @Id int,
    @Email nvarchar(150),
    @PhoneNumber nvarchar(15),
    @FirstName nvarchar(50),
    @LastName nvarchar(50)
AS 

	UPDATE [dbo].[User]
	SET     [Email] = @Email,  [PhoneNumber] = @PhoneNumber, [FirstName] = @FirstName, [LastName] = @LastName
	WHERE  [Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[WaterDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[WaterInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
	values( GETDATE(), @PatientId, @Every, @From, @To)
	
GO
/****** Object:  StoredProcedure [dbo].[WaterUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
	SET     [Every] = @Every, [From] = @From, [To] = @To
	WHERE  [Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[WorkDelete]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[WorkInsert]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[WorkSelect]    Script Date: 11/27/2021 7:15:25 PM ******/
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
/****** Object:  StoredProcedure [dbo].[WorkUpdate]    Script Date: 11/27/2021 7:15:25 PM ******/
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
