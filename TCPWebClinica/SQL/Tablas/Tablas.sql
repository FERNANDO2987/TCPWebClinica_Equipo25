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

go

--Caso para insertar
INSERT INTO Especialidad(Nombre,CreatedDate,Deleted,DeleteDate) VALUES ('Pediatria','2024-06-05',0,null);