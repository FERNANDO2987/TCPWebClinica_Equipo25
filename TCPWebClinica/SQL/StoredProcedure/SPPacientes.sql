/****** Object:  StoredProcedure [dbo].[AgregarPaciente]    Script Date: 12/6/2024 18:14:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarPaciente]
    @Apellido VARCHAR(50), @Nombre VARCHAR(50), @FechaNacimiento DATE, @DNI VARCHAR(15), @Email VARCHAR(100), @Telefono VARCHAR(20), @Sexo CHAR, @IdObraSocial INT
AS
BEGIN
    SET NOCOUNT ON

    INSERT INTO Pacientes (Apellido, Nombre, FechaNacimiento, DNI, Email, Telefono, Sexo, IdObrasocial, CreatedDate, Deleted)
    VALUES (@Apellido, @Nombre, @FechaNacimiento, @DNI, @Email, @Telefono, @Sexo, @IdObraSocial, GETDATE(), 0)
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarPaciente]    Script Date: 12/6/2024 18:14:42 ******/

CREATE PROCEDURE [dbo].[EliminarPaciente]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON

    UPDATE Pacientes
    SET Deleted = 1, DeleteDate = GETDATE()
    WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[LeerPacientes]    Script Date: 12/6/2024 18:14:42 ******/

CREATE PROCEDURE [dbo].[LeerPacientes]
AS
BEGIN
    SET NOCOUNT ON

    SELECT Id, Apellido, Nombre, FechaNacimiento, DNI, Email, Telefono, Sexo, IdObrasocial
    FROM Pacientes
    WHERE Deleted = 0
END

GO
/****** Object:  StoredProcedure [dbo].[ModificarPaciente]    Script Date: 12/6/2024 18:14:42 ******/

CREATE PROCEDURE [dbo].[ModificarPaciente]
    @Id INT,
    @Apellido VARCHAR(50),
    @Nombre VARCHAR(50),
    @FechaNacimiento DATE,
    @DNI VARCHAR(15),
    @Email VARCHAR(100),
    @Telefono VARCHAR(20),
    @Sexo CHAR,
    @IdObraSocial INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Pacientes
    SET Apellido = @Apellido, Nombre = @Nombre, FechaNacimiento = @FechaNacimiento, DNI = @DNI, Email = @Email, Telefono = @Telefono, Sexo = @Sexo, IdObrasocial = @IdObraSocial
    WHERE Id = @Id
END