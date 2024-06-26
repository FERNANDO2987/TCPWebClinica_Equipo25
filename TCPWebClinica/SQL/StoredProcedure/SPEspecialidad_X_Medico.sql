
USE [TCPClinica_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerEspecialidadPorMedico](
@IdMedico INT
)
AS
BEGIN	
	Set NOCOUNT ON;

	Select E.Id, E.Nombre
	From Especialidad E
	INNER JOIN Especialidades_X_Medico EXM ON E.Id = EXM.IdEspecialidad
	Where EXM.IdMedico = @IdMedico

  
END