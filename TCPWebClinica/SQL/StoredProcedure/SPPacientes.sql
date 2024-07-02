USE [TCPClinica_DB]
GO
/****** Object:  StoredProcedure [dbo].[AgregarPaciente]    Script Date: 21/06/2024 20:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: 21/06/2024
-- Description:	Agrega el Paciente
-- =============================================

CREATE PROCEDURE [dbo].[AgregarPaciente]
(
	@Id INT,
	@HC INT,
	@Nombre NVARCHAR(100),
	@Apellido NVARCHAR(100),
	@Documento int,
	@FechaNaciemiento DateTime,
	@Celular NVARCHAR(100),
	@Email NVARCHAR(100),
	@Sexo NVARCHAR(100),
	@IdObraSocial INT
)
AS

BEGIN 
 
 	 
	if (EXISTS (SELECT * FROM [dbo].[Paciente] WHERE Id = @Id ))
	UPDATE [dbo].[Paciente] SET    HC = @HC,
	                               Nombre = @Nombre,
								   Apellido = @Apellido,
								   Documento = @Documento,
								   FechaNacimiento = @FechaNaciemiento,
								   Celular = @Celular,
								   Email = @Email,
								   Sexo = @Sexo,
								   IdObraSocial = @IdObraSocial
	                          WHERE Id = @Id

		else
			BEGIN

INSERT INTO Paciente(HC,Nombre,Apellido,Documento,FechaNacimiento,Celular,Email,Sexo,IdObraSocial,CreatedDate,Deleted,DeleteDate)

VALUES(@HC,@Nombre,@Apellido,@Documento,@FechaNaciemiento,@Celular,@Email,@Sexo,@IdObraSocial,GETDATE(),0,NULL)



			SELECT SCOPE_IDENTITY()
		END
	
	
END

GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: 21/06/2024
-- Description:	Obtiene los Pacientes
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerPaciente]
AS
BEGIN	
	select * from [dbo].[Paciente]  
	where Deleted = 0
  
END

GO

CREATE PROCEDURE [dbo].[EliminarPacienteYObraSocial]
    @pacienteId INT
AS
BEGIN
    BEGIN TRANSACTION;
	  
    BEGIN TRY
        -- Obtener la Obra Social
        DECLARE @obraSocialId INT;
        SELECT @obraSocialId = IdObraSocial FROM [dbo].[Paciente] WHERE Id = @pacienteId;

        -- Actualizar registro en Paciente
        UPDATE [dbo].[Paciente]
        SET
            Deleted = 1,
            DeleteDate = GETDATE()
        WHERE
            Id = @pacienteId;

        -- Actualizar registro en ObraSocial
        UPDATE [dbo].[ObraSocial]
        SET
            Deleted = 1,
            DeleteDate = GETDATE()
        WHERE
            Id = @obraSocialId;
    END TRY

    BEGIN CATCH
        SELECT
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_SEVERITY() AS ErrorSeverity,
            ERROR_STATE() AS ErrorState,
            ERROR_PROCEDURE() AS ErrorProcedure,
            ERROR_LINE() AS ErrorLine,
            ERROR_MESSAGE() AS ErrorMessage;

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
    END CATCH;

    IF @@TRANCOUNT > 0
        COMMIT TRANSACTION;

    -- Seleccionar los registros actualizados
    SELECT *
    FROM [dbo].[Paciente]
    WHERE Id = @pacienteId;

    SELECT *
    FROM [dbo].[ObraSocial]
    WHERE Id = @obraSocialId;
END;
GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: 28/06/2024
-- Description:	Busca en la tabla paciente por criterio, Nombre,Apellido,HC y Documento
-- =============================================

CREATE PROCEDURE [dbo].[BuscarPaciente]
(
  @Criterio varchar(100)
)
AS
BEGIN
	Set NOCOUNT ON;

	SELECT *
	FROM Paciente
	WHERE
	    HC LIKE '%' + @Criterio + '%' OR
		Nombre LIKE '%' + @Criterio + '%' OR
		Apellido LIKE '%' + @Criterio + '%' OR
		Documento LIKE '%' + @Criterio + '%';

END

GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: 01/07/2024
-- Description:	Obtiene los pacientes por Id
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerPacientePorId]
(
  @Id int
)
AS
BEGIN	
	select * from [dbo].[Paciente] 
	Where Id = @Id and Deleted = 0

  
END
