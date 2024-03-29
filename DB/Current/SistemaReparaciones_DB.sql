
USE [SistemaReparacionesDB]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 2/19/2024 4:26:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ClienteID] [int] NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Direccion] [nvarchar](255) NULL,
	[Telefono] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diagnosticos]    Script Date: 2/19/2024 4:26:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diagnosticos](
	[DiagnosticoID] [int] NOT NULL,
	[EquipoID] [int] NULL,
	[Descripcion] [nvarchar](255) NULL,
	[Fecha] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[DiagnosticoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipos]    Script Date: 2/19/2024 4:26:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipos](
	[EquipoID] [int] NOT NULL,
	[ClienteID] [int] NULL,
	[Estado] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[EquipoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExistenciasRepuestos]    Script Date: 2/19/2024 4:26:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExistenciasRepuestos](
	[RepuestoID] [int] NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Cantidad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RepuestoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Garantias]    Script Date: 2/19/2024 4:26:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Garantias](
	[GarantiaID] [int] NOT NULL,
	[EquipoID] [int] NULL,
	[Descripcion] [nvarchar](255) NULL,
	[FechaInicio] [date] NULL,
	[FechaFin] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[GarantiaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrabajosDirectos]    Script Date: 2/19/2024 4:26:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrabajosDirectos](
	[TrabajoID] [int] NOT NULL,
	[Descripcion] [nvarchar](255) NULL,
	[Costo] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[TrabajoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 2/19/2024 4:26:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioID] [int] NOT NULL,
	[NombreUsuario] [nvarchar](50) NULL,
	[Contrasenia] [nvarchar](50) NULL,
	[Tipo] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Clientes] ([ClienteID], [Nombre], [Direccion], [Telefono], [Email]) VALUES (1, N'Cliente1', N'Dirección 1', N'123456789', N'cliente1@example.com')
INSERT [dbo].[Clientes] ([ClienteID], [Nombre], [Direccion], [Telefono], [Email]) VALUES (2, N'Cliente2', N'Dirección 2', N'987654321', N'cliente2@example.com')
GO
INSERT [dbo].[Equipos] ([EquipoID], [ClienteID], [Estado], [Descripcion]) VALUES (1, 1, N'Reparado', N'Equipo reparado del cliente 1')
INSERT [dbo].[Equipos] ([EquipoID], [ClienteID], [Estado], [Descripcion]) VALUES (2, 2, N'Sin reparar', N'Equipo sin reparar del cliente 2')
GO
INSERT [dbo].[ExistenciasRepuestos] ([RepuestoID], [Nombre], [Cantidad]) VALUES (1, N'Repuesto1', 10)
INSERT [dbo].[ExistenciasRepuestos] ([RepuestoID], [Nombre], [Cantidad]) VALUES (2, N'Repuesto2', 5)
GO
INSERT [dbo].[TrabajosDirectos] ([TrabajoID], [Descripcion], [Costo]) VALUES (1, N'Trabajo directo 1', CAST(50.00 AS Decimal(10, 2)))
INSERT [dbo].[TrabajosDirectos] ([TrabajoID], [Descripcion], [Costo]) VALUES (2, N'Trabajo directo 2', CAST(75.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Usuarios] ([UsuarioID], [NombreUsuario], [Contrasenia], [Tipo]) VALUES (1, N'tecnico1', N'1234', N'Técnico')
INSERT [dbo].[Usuarios] ([UsuarioID], [NombreUsuario], [Contrasenia], [Tipo]) VALUES (2, N'tienda1', N'1234', N'Tienda')
GO
ALTER TABLE [dbo].[Diagnosticos]  WITH CHECK ADD FOREIGN KEY([EquipoID])
REFERENCES [dbo].[Equipos] ([EquipoID])
GO
ALTER TABLE [dbo].[Equipos]  WITH CHECK ADD FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Clientes] ([ClienteID])
GO
ALTER TABLE [dbo].[Garantias]  WITH CHECK ADD FOREIGN KEY([EquipoID])
REFERENCES [dbo].[Equipos] ([EquipoID])
GO
USE [master]
GO
ALTER DATABASE [SistemaReparacionesDB] SET  READ_WRITE 
GO
