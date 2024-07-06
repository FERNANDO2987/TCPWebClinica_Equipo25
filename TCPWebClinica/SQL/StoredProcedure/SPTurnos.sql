USE [TCPClinica_DB]
GO
/****** Object:  StoredProcedure  [dbo].[AgregarTurno]   Script Date: 20/06/2024 7:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Palacios Fernando
-- Create date: 20/06/2024
-- Description:	Agrega Turno
-- =============================================
CREATE PROCEDURE [dbo].[AgregarTurno]
(
	@Id INT,
	@IdPaciente int,
	@IdMedico int,
	@IdEspecialidad int,
    @Observaciones nvarchar(500),
	@FechaTurno DateTime,
	@IdEstadoTurno int,
	@IdObraSocial int
	
)
AS

BEGIN 
 
 	 
	if (EXISTS (SELECT * FROM [dbo].[Turnos] WHERE Id = @Id ))
	UPDATE [dbo].[Turnos] SET  IdPaciente = @IdPaciente,
	                           IdMedico = @IdMedico,
							   IdEspecialidad = @IdEspecialidad,
							   Observaciones = @Observaciones,
							   FechaTurno = @FechaTurno,
							   IdEstadoTurno = @IdEstadoTurno,
							   IdObraSocial = @IdObraSocial	
	                          WHERE Id = @Id

		else
			BEGIN

INSERT INTO Turnos(IdPaciente,IdMedico,IdEspecialidad,Observaciones,FechaTurno,IdEstadoTurno,IdObraSocial,CreatedDate,Deleted,DeleteDate)

VALUES(@IdPaciente,@IdMedico,@IdEspecialidad,@Observaciones,@FechaTurno,@IdEstadoTurno,@IdObraSocial,GETDATE(),0,NULL)

			SELECT SCOPE_IDENTITY()
		END
	
	
END

GO

-- =============================================
-- Author:		Palacios Fernando
-- Create date: 01/07/2024
-- Description:	Obtiene todos los turnos
-- =============================================

CREATE PROCEDURE [dbo].[ObtenerTurnos]
AS
BEGIN	
	select * from [dbo].[Turnos]  
	where Deleted = 0
  
END

GO

-- =============================================
-- Author:		Palacios Fernando
-- Create date: 01/07/2024
-- Description:	Obtiene todos los turnos con sus pacientes
-- =============================================

CREATE PROCEDURE [dbo].[ObtenerTurnosConPacientes]
AS
BEGIN
    SELECT 
        T.Id ,
        P.Nombre AS NombrePaciente,
        P.Apellido AS ApellidoPaciente,
        T.Observaciones,
        T.FechaTurno,
		E.Nombre AS Especialidad,
		M.Nombre AS Medico,
		ET.Descripcion,
		O.Nombre AS ObraSocial,
		M.Id AS IdMedico
       
    FROM 
        Turnos T 
    INNER JOIN 
             Paciente P ON T.IdPaciente = P.Id
	INNER JOIN 
	        Especialidad E ON T.IdEspecialidad = E.Id
	INNER JOIN
	        Medicos M ON T.IdMedico = M.Id
	INNER JOIN 
	        EstadoTurno ET ON T.IdEstadoTurno = ET.Id 
	INNER JOIN 
	      ObraSocial O ON T.IdObraSocial = O.Id 
	
	  WHERE 
        T.Deleted = 0
END
