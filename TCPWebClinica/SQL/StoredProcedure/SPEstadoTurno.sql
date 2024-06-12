USE [TCPClinica_DB]
GO
/****** Object:  StoredProcedure [dbo].[AgregarEstadoTurno]    Script Date: 11/06/2024 20:55:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: 11/06/2024
-- Description:	Agrega el Estado del Turno
-- =============================================
CREATE PROCEDURE [dbo].[AgregarEstadoTurno]
(
    @Id INT,
    @Codigo nvarchar(50),
    @Descripcion nvarchar(100)
 
)
AS
BEGIN
    IF (EXISTS (SELECT * FROM [dbo].[EstadoTurno] WHERE Id = @Id))
        UPDATE [dbo].[EstadoTurno]
        SET Codigo = @Codigo,
            Descripcion = @Descripcion
         
        WHERE Id = @Id;
    ELSE
        BEGIN
            INSERT INTO EstadoTurno(Codigo, Descripcion,CreatedDate, Deleted, DeleteDate)
            VALUES(@Codigo, @Descripcion, GETDATE(), 0, NULL);
            
            SELECT SCOPE_IDENTITY();
        END
END

go

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: 11/06/2024
-- Description:	Elimina el Estado del Turno por Id
-- =============================================

CREATE PROCEDURE [dbo].[EliminarEstadoTurno]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Declarar variable para el resultado
    DECLARE @Result BIT;

    -- Verificar si el registro existe
    IF EXISTS (SELECT 1 FROM [dbo].[EstadoTurno] WHERE [Id] = @Id)
    BEGIN
        -- Actualizar solo el registro con el Id proporcionado
        UPDATE [dbo].[EstadoTurno]
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
-- Create date: 11/06/2024
-- Description:	Obtiene todos los Estados de Turno
-- =============================================

CREATE PROCEDURE [dbo].[ObtenerEstadosTurno]
AS
BEGIN	
	select * from [dbo].[EstadoTurno] 
	Where Deleted = 0

  
END