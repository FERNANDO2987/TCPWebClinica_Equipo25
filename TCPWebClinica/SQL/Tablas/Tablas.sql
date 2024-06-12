--CREATE DATABASE TCPClinica_DB
--GO
USE TCPClinica_DB
GO

Create Table[dbo].[Especialidad]
(
  [Id] int Identity(1,1) Primary Key,
  [Nombre] Nvarchar(100) NOT NULL,
  [CreatedDate] [datetime] NOT NULL,
  [Deleted] [bit] NOT NULL,
  [DeleteDate] [datetime] NULL,
   
)
CREATE TABLE[dbo].[ObraSocial](
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Nombre] NVARCHAR(100) NOT NULL,
	[Descripcion] NVARCHAR(200) NOT NULL,
	[Direccion] NVARCHAR(100) NOT NULL,
	[Telefono] NVARCHAR(100) NOT NULL,
	[Email] NVARCHAR(100) NOT NULL,
	[Website] NVARCHAR(100) NULL,
	[Activo] BIT NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteDate] [datetime] NULL
)
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[NombreUsuario] [varchar](50) NOT NULL UNIQUE,
	[Password] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Rol] [char](1) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteDate] [datetime] NULL
	)
	CREATE TABLE [dbo].[Administrador](
	[Id] [int] NOT NULL FOREIGN KEY REFERENCES Usuarios(Id) PRIMARY KEY,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](100) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteDate] [datetime] NULL
	)
CREATE TABLE [dbo].[Recepcionista](
	[Id] [int] NOT NULL FOREIGN KEY REFERENCES Usuarios(Id) PRIMARY KEY,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](100) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteDate] [datetime] NULL
	)
CREATE TABLE [dbo].[EstadoTurno](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Estado] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteDate] [datetime] NULL
)
go

--Estado de Turno
Create Table[dbo].[EstadoTurno]
(
  [Id] int Identity(1,1) Primary Key,
  [Codigo] Nvarchar(50) NOT NULL,
  [Nombre] Nvarchar(100) NOT NULL,
  [CreatedDate] [datetime] NOT NULL,
  [Deleted] [bit] NOT NULL,
  [DeleteDate] [datetime] NULL,
   
)




