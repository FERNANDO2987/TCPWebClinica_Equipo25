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