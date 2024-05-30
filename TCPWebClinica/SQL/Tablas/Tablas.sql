--CREATE DATABASE TCPClinica_DB
--GO
USE TCPClinica_DB
GO

Create Table[dbo].[Especialidad]
(
  Id int Identity(1,1) Primary Key,
  Nombre Nvarchar(100) not null
   
)