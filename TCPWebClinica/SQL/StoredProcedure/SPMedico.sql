USE [TCPClinica_DB]
GO
/****** Object:  StoredProcedure [dbo].[AgregarMedico]    Script Date: 13/06/2024 21:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: 13/06/2024
-- Description:	Agrega el Medico
-- =============================================

CREATE PROCEDURE [dbo].[AgregarMedico]
(
    @Id INT,
    @Nombre nvarchar(100),
    @Apellido nvarchar(100),
    @Email nvarchar(100)

)
AS
BEGIN
    IF (EXISTS (SELECT * FROM [dbo].[Medicos] WHERE Id = @Id))
        UPDATE [dbo].[Medico]
        SET Nombre = @Nombre,
            Apellido = @Apellido,
            Email = @Email
       
        WHERE Id = @Id;
    ELSE
        BEGIN
            INSERT INTO Medicos(Nombre, Apellido, Email, CreatedDate, Deleted, DeleteDate)
            VALUES(@Nombre, @Apellido, @Email, GETDATE(), 0, NULL);
            
            SELECT SCOPE_IDENTITY();
        END
END


GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: 13/06/2024
-- Description:	Elimina el  Medico
-- =============================================

CREATE PROCEDURE [dbo].[EliminarMedico]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Declarar variable para el resultado
    DECLARE @Result BIT;

    -- Verificar si el registro existe
    IF EXISTS (SELECT 1 FROM [dbo].[Medicos] WHERE [Id] = @Id)
    BEGIN
        -- Actualizar solo el registro con el Id proporcionado
        UPDATE [dbo].[Medicos]
        SET [Deleted] = 1,
            [DeleteDate] = GETDATE()
        WHERE [Id] = @Id;

        -- Establece el resultado en verdadero indicando éxito
        SET @Result = 1;
    END
    ELSE
    BEGIN
       -- Establecer el resultado en falso indicando falla
        SET @Result = 0;
    END

    -- Devuelve el resultado
    SELECT CAST(@Result AS BIT) AS 'Result';
END;
GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: 13/06/2024
-- Description: Obtiene los Medicos
-- =============================================

CREATE PROCEDURE [dbo].[ObtenerMedico]
AS
BEGIN	
	select * from [dbo].[Medicos] 
	Where Deleted = 0

  
END
