
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

go

create procedure eliminarEspecialidadXM
	@idMedico int,
	@idEspecialidad int
as
begin 
	delete Especialidades_X_Medico where IdMedico = @idMedico and IdEspecialidad = @idEspecialidad
end

GO

CREATE PROCEDURE AgregarExM
	@idE int,
	@idM int
AS
BEGIN 
	INSERT INTO Especialidades_X_Medico(IdMedico, IdEspecialidad)
	VALUES (@idM,@idE)
END