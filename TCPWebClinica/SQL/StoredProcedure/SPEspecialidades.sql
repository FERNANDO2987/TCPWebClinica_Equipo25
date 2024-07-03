USE TCPClinica_DB
GO
/****** Object:  StoredProcedure [dbo].[ObtenerEspecialidad]    Script Date: 04/06/2024 21:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: Obtiene las Especilidades
-- Description:	Obtiene todas las Especilidades que tengan delete 0
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerEspecialidad]
AS
BEGIN	
	select * from [dbo].[Especialidad]  
	where Deleted = 0
  
END
--================================FIN===================================
GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: Crear Especilidad
-- Description:	Crea la especilidad y la actualiza
-- =============================================
CREATE PROCEDURE [dbo].[AgregarEspecilidad]
(
@Id INT,
@Nombre NVARCHAR(100)

)

AS BEGIN 
 	 
	if (EXISTS (SELECT * FROM [dbo].[Especialidad] WHERE Id = @Id ))
	UPDATE [dbo].[Especialidad] SET  Nombre = @Nombre WHERE Id = @Id 

		else
			BEGIN

INSERT INTO [dbo].[Especialidad]

VALUES(@Nombre,GETDATE(),0,NULL)

			SELECT SCOPE_IDENTITY()
		END

END

--================================FIN===================================
GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: Eliminar Especilidad
-- Description:	Elimina la Especilidad por Id
-- =============================================

CREATE PROCEDURE [dbo].[EliminarEspecialidad]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    --  variable para el resultado
    DECLARE @Result BIT;

    -- Verificar si el registro existe
    IF EXISTS (SELECT 1 FROM [dbo].[Especialidad] WHERE [Id] = @Id)
    BEGIN
        -- Actualizar solo el registro con el Id proporcionado
        UPDATE [dbo].[Especialidad]
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

