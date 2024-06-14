USE TCPClinica_DB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--***********AGREGAR ADMINISTRADOR************--

CREATE PROCEDURE [dbo].[AgregarAdministrador]
    @Id INT,
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Email VARCHAR(100)
AS
BEGIN
    INSERT INTO [dbo].[Administrador] (Id, Nombre, Apellido, Email, CreatedDate, Deleted,DeleteDate)
    VALUES (@Id, @Nombre, @Apellido, @Email, GETDATE(), 0 , null)
END
go
--***********ELIMINAR ADMINISTRADOR************--
CREATE PROCEDURE [dbo].[EliminarAdministrador]
    @Id INT
AS
BEGIN
    UPDATE [dbo].[Administrador]	
    SET Deleted = 1, DeleteDate = GETDATE()
    WHERE Id = @Id and Deleted = 0
END
go
--************MODIFICAR ADMINISTRADOR***********--
CREATE PROCEDURE [dbo].[ModificarAdministrador]
    @Id INT,
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Email VARCHAR(100)
AS
BEGIN
    UPDATE [dbo].[Administrador]
    SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email
    WHERE Id = @Id and Deleted = 0
END
go
--***********LEER ADMINISTRADOR************--
CREATE PROCEDURE [dbo].[LeerAdministrador]
AS
BEGIN
    SELECT Id, Nombre, Apellido, Email
    FROM [dbo].[Administrador]
	WHERE Deleted = 0
END