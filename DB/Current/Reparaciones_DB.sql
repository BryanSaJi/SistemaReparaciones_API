USE [master]
GO
/****** Object:  Database [ReparacionesDB]    Script Date: 3/24/2024 5:29:14 PM ******/
CREATE DATABASE [ReparacionesDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ReparacionesDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS03\MSSQL\DATA\ReparacionesDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ReparacionesDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS03\MSSQL\DATA\ReparacionesDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ReparacionesDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ReparacionesDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ReparacionesDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ReparacionesDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ReparacionesDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ReparacionesDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ReparacionesDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ReparacionesDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ReparacionesDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ReparacionesDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ReparacionesDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ReparacionesDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ReparacionesDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ReparacionesDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ReparacionesDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ReparacionesDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ReparacionesDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ReparacionesDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ReparacionesDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ReparacionesDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ReparacionesDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ReparacionesDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ReparacionesDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ReparacionesDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ReparacionesDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ReparacionesDB] SET  MULTI_USER 
GO
ALTER DATABASE [ReparacionesDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ReparacionesDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ReparacionesDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ReparacionesDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ReparacionesDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ReparacionesDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ReparacionesDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [ReparacionesDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ReparacionesDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/24/2024 5:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 3/24/2024 5:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido1] [varchar](50) NULL,
	[apellido2] [varchar](50) NULL,
	[cedula] [varchar](15) NULL,
	[telefono1] [varchar](20) NULL,
	[telefono2] [varchar](20) NULL,
	[email] [varchar](100) NULL,
	[fecha_ingreso] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cola_Reparaciones]    Script Date: 3/24/2024 5:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cola_Reparaciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[local_id] [int] NULL,
	[cliente_id] [int] NULL,
	[maquina_id] [int] NULL,
	[estado_id] [int] NULL,
	[estado_taller_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 3/24/2024 5:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre_estado] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado_Taller]    Script Date: 3/24/2024 5:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado_Taller](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre_estado] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locales]    Script Date: 3/24/2024 5:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[direccion] [varchar](255) NULL,
	[telefono] [varchar](20) NULL,
	[tipo_local_id] [int] NULL,
	[usuario_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maquinas]    Script Date: 3/24/2024 5:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maquinas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipo_consola_id] [int] NULL,
	[detalle1] [varchar](100) NULL,
	[detalle2] [varchar](300) NULL,
	[serial] [varchar](50) NULL,
	[estado_fisico] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passwords]    Script Date: 3/24/2024 5:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passwords](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[password] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Repuestos]    Script Date: 3/24/2024 5:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Repuestos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipo_consola_id] [int] NULL,
	[tipo_repuesto_id] [int] NULL,
	[detalle] [varchar](300) NULL,
	[fabricante_modelo] [varchar](100) NULL,
	[taller_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 3/24/2024 5:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rol] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Local]    Script Date: 3/24/2024 5:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Local](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre_tipo] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_Consola]    Script Date: 3/24/2024 5:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos_Consola](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre_consola] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_Repuesto]    Script Date: 3/24/2024 5:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos_Repuesto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre_tipo] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 3/24/2024 5:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[cedula] [varchar](15) NULL,
	[fecha_nacimiento] [date] NULL,
	[rol_id] [int] NULL,
	[password_id] [int] NULL,
	[username] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Passwords] ON 

INSERT [dbo].[Passwords] ([id], [password]) VALUES (1, N'admin1')
SET IDENTITY_INSERT [dbo].[Passwords] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([id], [rol]) VALUES (1, N'Admin')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [cedula], [fecha_nacimiento], [rol_id], [password_id], [username]) VALUES (4, N'Bryan', N'Sanabria', N'1234567', CAST(N'2024-03-20' AS Date), 1, 1, N'brysan')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Cola_Reparaciones]  WITH CHECK ADD FOREIGN KEY([cliente_id])
REFERENCES [dbo].[Clientes] ([id])
GO
ALTER TABLE [dbo].[Cola_Reparaciones]  WITH CHECK ADD FOREIGN KEY([estado_id])
REFERENCES [dbo].[Estado] ([id])
GO
ALTER TABLE [dbo].[Cola_Reparaciones]  WITH CHECK ADD FOREIGN KEY([estado_taller_id])
REFERENCES [dbo].[Estado_Taller] ([id])
GO
ALTER TABLE [dbo].[Cola_Reparaciones]  WITH CHECK ADD FOREIGN KEY([local_id])
REFERENCES [dbo].[Locales] ([id])
GO
ALTER TABLE [dbo].[Cola_Reparaciones]  WITH CHECK ADD FOREIGN KEY([maquina_id])
REFERENCES [dbo].[Maquinas] ([id])
GO
ALTER TABLE [dbo].[Locales]  WITH CHECK ADD FOREIGN KEY([tipo_local_id])
REFERENCES [dbo].[Tipo_Local] ([id])
GO
ALTER TABLE [dbo].[Locales]  WITH CHECK ADD FOREIGN KEY([usuario_id])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Maquinas]  WITH CHECK ADD FOREIGN KEY([tipo_consola_id])
REFERENCES [dbo].[Tipos_Consola] ([id])
GO
ALTER TABLE [dbo].[Repuestos]  WITH CHECK ADD FOREIGN KEY([taller_id])
REFERENCES [dbo].[Locales] ([id])
GO
ALTER TABLE [dbo].[Repuestos]  WITH CHECK ADD FOREIGN KEY([tipo_consola_id])
REFERENCES [dbo].[Tipos_Consola] ([id])
GO
ALTER TABLE [dbo].[Repuestos]  WITH CHECK ADD FOREIGN KEY([tipo_repuesto_id])
REFERENCES [dbo].[Tipos_Repuesto] ([id])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([password_id])
REFERENCES [dbo].[Passwords] ([id])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([rol_id])
REFERENCES [dbo].[Roles] ([id])
GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 3/24/2024 5:29:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[sp_Login](@Usuario varchar(max), @Contresenia varchar(max), @Exitoso bit OUTPUT)
as begin 

	
	if (select count(*) from Usuarios where username=@Usuario and password_id=(SELECT password_id
																			 FROM Passwords
																			 WHERE password = @Contresenia)) = 1
	begin 
		set @Exitoso =1
	end
	else
	begin
		set @Exitoso =0
	end
	--set @Exitoso =0
	select @Exitoso
end
GO
USE [master]
GO
ALTER DATABASE [ReparacionesDB] SET  READ_WRITE 
GO
