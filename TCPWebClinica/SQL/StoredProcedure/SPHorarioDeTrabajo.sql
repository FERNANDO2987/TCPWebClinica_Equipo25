USE [TCPClinica_DB]
GO
/****** Object:  StoredProcedure [dbo].[AgregarEspecialidad]    Script Date: 12/06/2024 22:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: 12/06/2024
-- Description:	Agrega el Horario de Trabajo
-- =============================================

CREATE PROCEDURE [dbo].[AgregarHorarioDeTrabajo]
(
@Id INT,
@HorarioEntrada DateTime,
@HorarioSalida DateTime

)

AS BEGIN 
 	 
	if (EXISTS (SELECT * FROM [dbo].[HorarioDeTrabajo] WHERE Id = @Id ))
	UPDATE [dbo].[HorarioDeTrabajo] SET  HorarioEntrada = @HorarioEntrada,
	                                     HorarioSalida = @HorarioSalida
									 WHERE Id = @Id 

		else
			BEGIN

INSERT INTO [dbo].[HorarioDeTrabajo]

VALUES(@HorarioEntrada,@HorarioSalida,GETDATE(),0,NULL)

			SELECT SCOPE_IDENTITY()
		END

END
GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: 12/06/2024
-- Description:	Elimina Horario de trabajo por Id
-- =============================================

CREATE PROCEDURE [dbo].[EliminarHorarioDeTrabajo]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    --  variable para el resultado
    DECLARE @Result BIT;

    -- Verificar si el registro existe
    IF EXISTS (SELECT 1 FROM [dbo].[HorarioDeTrabajo] WHERE [Id] = @Id)
    BEGIN
        -- Actualizar solo el registro con el Id proporcionado
        UPDATE [dbo].[HorarioDeTrabajo]
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
-- Create date: 12/06/2024
-- Description:	Obtiene todos los Horarios de Trabajo
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerHorarioDeTrabajo]
AS
BEGIN	
	select * from [dbo].[HorarioDeTrabajo]  
	where Deleted = 0
  
END
--================================FIN===================================
GO

CREATE PROCEDURE ListarHorarios_x_Medico
	@id int
AS
BEGIN
	SELECT * FROM HorarioDeTrabajo WHERE IdMedico = @id and Deleted = 0
END