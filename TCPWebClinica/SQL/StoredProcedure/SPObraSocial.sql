USE TCPClinica_DB
GO
/****** Object:  StoredProcedure [dbo].[ObtenerEspecialidad]    Script Date: 04/06/2024 21:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Palacios Fernando
-- Create date: 05/06/2024
-- Description:	Agrega la Obra Social
-- =============================================
CREATE PROCEDURE [dbo].[AgregarObraSocial]
(
@Id INT,
@Nombre NVARCHAR(50),
@Descripcion NVARCHAR(100)

)

AS BEGIN 
 	 
	if (EXISTS (SELECT * FROM [dbo].[ObraSocial] WHERE Id = @Id ))
	UPDATE [dbo].[ObraSocial] SET  Nombre = @Nombre, 
	                               Descripcion =@Descripcion
								   WHERE Id = @Id 

		else
			BEGIN

INSERT INTO [dbo].[ObraSocial]

VALUES(@Nombre,@Descripcion,GETDATE(),0,NULL)

			SELECT SCOPE_IDENTITY()
		END

END

GO
-- =============================================
-- Author:	    Palacios Fernando
-- Create date: 07/06/2024
-- Description:	Obtiene todas las Obras Sociales
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerObraSocial]
AS
BEGIN	
	select * from [dbo].[ObraSocial]  
	where Deleted = 0
  
END

GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: 07/06/2024
-- Description:	Elimina Obra Social
-- =============================================

CREATE PROCEDURE [dbo].[EliminarObraSocial]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    --  variable para el resultado
    DECLARE @Result BIT;

    -- Verificar si el registro existe
    IF EXISTS (SELECT 1 FROM [dbo].[ObraSocial] WHERE [Id] = @Id)
    BEGIN
        -- Actualizar solo el registro con el Id proporcionado
        UPDATE [dbo].[ObraSocial]
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

