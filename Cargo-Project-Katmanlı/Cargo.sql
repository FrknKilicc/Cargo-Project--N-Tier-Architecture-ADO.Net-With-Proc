USE [master]
GO
/****** Object:  Database [Cargo]    Script Date: 28.08.2023 20:51:46 ******/
CREATE DATABASE [Cargo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cargo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Cargo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cargo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Cargo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Cargo] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cargo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cargo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cargo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cargo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cargo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cargo] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cargo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cargo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cargo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cargo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cargo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cargo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cargo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cargo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cargo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cargo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cargo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cargo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cargo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cargo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cargo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cargo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cargo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cargo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Cargo] SET  MULTI_USER 
GO
ALTER DATABASE [Cargo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cargo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cargo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cargo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cargo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Cargo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Cargo] SET QUERY_STORE = ON
GO
ALTER DATABASE [Cargo] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Cargo]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 28.08.2023 20:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerNo] [int] IDENTITY(1,1) NOT NULL,
	[NameSurname] [varchar](50) NULL,
	[Adress] [varchar](50) NULL,
	[Phone] [char](11) NULL,
	[Mail] [varchar](50) NULL,
	[PaymentStatus] [varchar](50) NULL,
	[CustomerPW] [varchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 28.08.2023 20:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[NameSurname] [varchar](50) NULL,
	[EmployeeOccupation] [varchar](50) NULL,
	[EmployeeTitle] [varchar](50) NULL,
	[Phone] [char](11) NULL,
	[Mail] [varchar](50) NULL,
	[EmployeeWage] [money] NULL,
	[CustomerNo] [int] NULL,
	[EmployeePW] [varchar](50) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipping]    Script Date: 28.08.2023 20:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipping](
	[ShippingNo] [int] NOT NULL,
	[ShippingName] [varchar](50) NULL,
	[DeliveredLocation] [varchar](50) NULL,
	[Distance] [varchar](50) NULL,
	[TotalAmount] [money] NULL,
 CONSTRAINT [PK_Shipping] PRIMARY KEY CLUSTERED 
(
	[ShippingNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 28.08.2023 20:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[VehicleID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleName] [varchar](50) NULL,
	[VehicleCapacity] [varchar](50) NULL,
	[VehicleDriver] [varchar](50) NULL,
	[VehicleExpense] [money] NULL,
	[EmployeeID] [int] NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerNo], [NameSurname], [Adress], [Phone], [Mail], [PaymentStatus], [CustomerPW]) VALUES (1, N'furkan', N'zeytinburnu', N'5442603193 ', N'furkan@gmail.com', N'var', N'123')
INSERT [dbo].[Customers] ([CustomerNo], [NameSurname], [Adress], [Phone], [Mail], [PaymentStatus], [CustomerPW]) VALUES (3, N'anil erdem', N'üsküdar', N'5442610319 ', N'anil@gmail.com', N'var', N'123')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeID], [NameSurname], [EmployeeOccupation], [EmployeeTitle], [Phone], [Mail], [EmployeeWage], [CustomerNo], [EmployeePW]) VALUES (1, N'Furkan Kiliç', N'E-Ticaret', N'Yönetici', N'5442603193 ', N'furkan@gmail.com', 500.0000, NULL, N'123')
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Customers] FOREIGN KEY([CustomerNo])
REFERENCES [dbo].[Customers] ([CustomerNo])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Customers]
GO
ALTER TABLE [dbo].[Shipping]  WITH CHECK ADD  CONSTRAINT [FK_Shipping_Employees] FOREIGN KEY([ShippingNo])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Shipping] CHECK CONSTRAINT [FK_Shipping_Employees]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_Employees]
GO
/****** Object:  StoredProcedure [dbo].[AddCustomer]    Script Date: 28.08.2023 20:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddCustomer]
@NameSurname varchar(50),
@Adress varchar(50),
@Phone char(11),
@Mail varchar(50),
@PaymentStatus varchar(50),
@CustomerPW varchar(50)
as begin

insert into Customers (NameSurname,CustomerPW,Adress,Phone,Mail,PaymentStatus) values (@NameSurname,@CustomerPW,@Adress,@Phone,@Mail,@PaymentStatus)

end
GO
/****** Object:  StoredProcedure [dbo].[DelCustomer]    Script Date: 28.08.2023 20:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DelCustomer] 

@CustomerNo int

as begin
delete Customers where CustomerNo=@CustomerNo
end
GO
/****** Object:  StoredProcedure [dbo].[ListCustomer]    Script Date: 28.08.2023 20:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ListCustomer]

as begin
select*from Customers
end
GO
/****** Object:  StoredProcedure [dbo].[LoginEmployee]    Script Date: 28.08.2023 20:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LoginEmployee]

@Mail varchar,
@EmployeePW varchar(50)
as begin

select*from Employees where Mail = @Mail and EmployeePW=@EmployeePW

end
GO
/****** Object:  StoredProcedure [dbo].[UpCustomer]    Script Date: 28.08.2023 20:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpCustomer]
@CustomerNo int,
@NameSurname varchar(50),
@Adress varchar(50),
@Phone char(11),
@Mail varchar(50),
@PaymentStatus varchar(50),
@CustomerPW varchar(50)
as begin 

update Customers set NameSurname=@NameSurname,CustomerPW=@CustomerPW,Adress=@Adress,Phone=@Phone,Mail=@Mail,PaymentStatus=@PaymentStatus where CustomerNo = @CustomerNo
end
GO
USE [master]
GO
ALTER DATABASE [Cargo] SET  READ_WRITE 
GO
