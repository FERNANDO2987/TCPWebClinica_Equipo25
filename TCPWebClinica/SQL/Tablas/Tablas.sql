﻿CREATE DATABASE TCPClinica_DB
GO
USE TCPClinica_DB
GO
--Rol
CREATE TABLE [dbo].[Rol](
	[Id] [int] not null primary key identity(1,1),
	[Descripcion] [nvarchar](20) not null,
	[CreatedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteDate] [datetime] NULL

	)

Create Table[dbo].[Especialidad]
(
  [Id] int Identity(1,1) Primary Key,
  [Nombre] Nvarchar(100) NOT NULL,
  [CreatedDate] [datetime] NOT NULL,
  [Deleted] [bit] NOT NULL,
  [DeleteDate] [datetime] NULL
   
)
CREATE TABLE[dbo].[ObraSocial](
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Nombre] NVARCHAR(100) NOT NULL,
	[Descripcion] NVARCHAR(200) NOT NULL,
	[Direccion] NVARCHAR(100) NOT NULL,
	[Telefono] NVARCHAR(100) NOT NULL,
	[Email] NVARCHAR(100) NOT NULL,
	[Website] NVARCHAR(100) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteDate] [datetime] NULL
)
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Nombre] [nvarchar](50) NOT NULL UNIQUE,
	[Contraseña] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[RolId] [int] NOT NULL FOREIGN KEY REFERENCES Rol(id),
	[CreatedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteDate] [datetime] NULL
	)
	CREATE TABLE [dbo].[Administrador](
	[Id] [int] NOT NULL FOREIGN KEY REFERENCES Usuario(Id) PRIMARY KEY,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](100) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteDate] [datetime] NULL
	)
CREATE TABLE [dbo].[Recepcionista](
	[Id] [int] NOT NULL FOREIGN KEY REFERENCES Usuario(Id) PRIMARY KEY,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](100) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteDate] [datetime] NULL
	)
--Paciente

CREATE TABLE [dbo].[Paciente](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[HC] [INT]NOT NULL,
    [Apellido] [nvarchar](100) NOT NULL,
    [Nombre] [nvarchar](100) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Docuemnto] [int],
	[Email] [nvarchar](100) NULL,
	[Celular] [nvarchar](100) NOT NULL,
	[Sexo] [nvarchar] NOT NULL,
	[IdObrasocial] [int] NULL FOREIGN KEY REFERENCES ObraSocial(id),
	[CreatedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteDate] [datetime] NULL
)
--Medicos
create table [dbo].[Medicos](
	[Id] [int] NOT NULL FOREIGN KEY REFERENCES Usuario(Id) PRIMARY KEY,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteDate] [datetime] NULL
)
create table [dbo].[Especialidades_X_Medico](
	[IdMedico] [int] not null foreign key references Medico(id),
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
	[IdPaciente] [int] not null foreign key references Paciente(id),
	[IdMedico] [int] not null foreign key references Medicos(id),
	[IdEspecialidad] [int] not null foreign key references Especialidad(id), 
	[Observaciones] [varchar](500) null,
	[FechaTurno] [datetime] not null,
	[IdEstadoTurno] [int] not null foreign key references EstadoTurno(id),
	[IdObraSocial] [int] null foreign key references ObraSocial(id),
	[CreatedDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteDate] [datetime] NULL
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

create table [dbo].[Horario_x_Medico](
	[IdHorario] [int] not null foreign key references HorarioDeTrabajo(id),
	[IdMedico] [int] not null foreign key references Medico(id),
	primary key(IdHorario,IdMedico)

)










