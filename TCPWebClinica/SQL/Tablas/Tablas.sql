--CREATE DATABASE TCPClinica_DB
--GO
USE TCPClinica_DB
GO
--Rol
CREATE TABLE [dbo].[Rol](
	[Id] [int] not null primary key identity(1,1),
	[Descripcion] [nvarchar](20) not null
	)

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
	[IdRol] [int] NOT NULL FOREIGN KEY REFERENCES Rol(id),
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
--Medico

Create Table[dbo].[Medico]
(
  [Id] [int] not null primary key identity(1,1),
  [Nombre] nvarchar(100) NOT NULL,
  [Apellido] nvarchar (100) NOT NULL,
  [Email] nvarchar(100) NOT NULL,
  [CreatedDate] [datetime] NOT NULL,
  [Deleted] [bit] NOT NULL,
  [DeleteDate] [datetime] NULL
   
)
--Paciente

--Create Table[dbo].[Paciente]
--(
--  [Id] [int] not null primary key identity(1,1),
--  [HC] int NOT NULL,
--  [Nombre] nvarchar (100) NOT NULL,
--  [Apellido] nvarchar (100) NOT NULL,
--  [Documento] int NOT NULL,
--  [FechaNacimiento] datetime NOT NULL,
--  [Celular] nvarchar (100) NOT NULL,
--  [Email] nvarchar (100) NULL,
--  [Sexo] bit NOT NULL,
--  [IdObraSocial] int NOT NULL foreign key references ObraSocial(Id),
--  [CreatedDate] [datetime] NOT NULL,
--  [Deleted] [bit] NOT NULL,
--  [DeleteDate] [datetime] NULL
   
--)
CREATE TABLE [dbo].[Pacientes](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Apellido] [varchar](50) NOT NULL,
    [Nombre] [varchar](50) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[DNI] [varchar] (15),
	[Email] [varchar](100) NULL,
	[Telefono] [varchar](20) NOT NULL,
	[Sexo] [char] NOT NULL,
	[IdObrasocial] [int] NULL FOREIGN KEY REFERENCES ObraSocial(id),
	[CreatedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteDate] [datetime] NULL
)
--CREATE TABLE [dbo].[EstadoTurno](
--	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
--	[Estado] [varchar](50) NOT NULL,
--	[CreatedDate] [datetime] NOT NULL,
--	[Deleted] [bit] NOT NULL,
--	[DeleteDate] [datetime] NULL
--)
create table [dbo].[Medicos](
	[Id] [int] NOT NULL FOREIGN KEY REFERENCES Usuarios(Id) PRIMARY KEY,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](100) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteDate] [datetime] NULL
)
create table [dbo].[Especialidades_X_Medico](
	[IdMedico] [int] not null foreign key references Medicos(id),
	[IdEspecialidad] [int] not null foreign key references Especialidad(id),
	primary key (IdMedico, IdEspecialidad)
)
--Estado de Turno
Create Table[dbo].[EstadoTurno]
(
  [Id] int Identity(1,1) Primary Key,
  [Codigo] Nvarchar(50) NOT NULL,
  [Descripcion] Nvarchar(100) NOT NULL,
  [CreatedDate] [datetime] NOT NULL,
  [Deleted] [bit] NOT NULL,
  [DeleteDate] [datetime] NULL,
   
)
create table [dbo].[Turnos](
	[Id] [int] not null primary key identity(1,1),
	[IdPaciente] [int] not null foreign key references Pacientes(id),
	[IdMedico] [int] not null foreign key references Medicos(id),
	[IdEspecialidad] [int] not null foreign key references Especialidad(id), 
	[Observaciones] [varchar](500) null,
	[FechaTurno] [datetime] not null,
	[IdEstadoTurno] [int] not null foreign key references EstadoTurno(id),
	[IdObraSocial] [int] null foreign key references ObraSocial(id)
)
go



--HorarioDeTrabajo

Create Table[dbo].[HorarioDeTrabajo]
(
  [Id] [int] not null primary key identity(1,1),
  [HorarioEntrada] DateTime NOT NULL,
  [HorarioSalida] DateTime NOT NULL,
  [CreatedDate] [datetime] NOT NULL,
  [Deleted] [bit] NOT NULL,
  [DeleteDate] [datetime] NULL
   
)










