USE TCPClinica_DB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--***********AGREGAR RECEPCIONISTA************--

CREATE PROCEDURE [dbo].[AgregarRecepcionista]
    @Id INT,
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Email VARCHAR(100)
AS
BEGIN
    INSERT INTO [dbo].[Recepcionista] (Id, Nombre, Apellido, Email, CreatedDate, Deleted,DeleteDate)
    VALUES (@Id, @Nombre, @Apellido, @Email, GETDATE(), 0 , null)
END
go
--***********ELIMINAR RECEPCIONISTA************--
CREATE PROCEDURE [dbo].[EliminarRecepcionista]
    @Id INT
AS
BEGIN
    UPDATE [dbo].[Recepcionista]
    SET Deleted = 1, DeleteDate = GETDATE()
    WHERE Id = @Id and Deleted = 0
END
go
--************MODIFICAR RECEPCIONISTA***********--
CREATE PROCEDURE [dbo].[ModificarRecepcionista]
    @Id INT,
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Email VARCHAR(100)
AS
BEGIN
    UPDATE [dbo].[Recepcionista]
    SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email
    WHERE Id = @Id and Deleted = 0
END
go
--***********LEER RECEPCIONISTA************--
CREATE PROCEDURE [dbo].[LeerRecepcionista]
AS
BEGIN
    SELECT Id, Nombre, Apellido, Email
    FROM [dbo].[Recepcionista]
	WHERE Deleted = 0
END