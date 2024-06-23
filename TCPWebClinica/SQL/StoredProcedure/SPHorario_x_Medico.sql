USE [TCPClinica_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--  AGREGAR HxM
CREATE PROCEDURE [dbo].[AgregarHorario_x_Medico]
    @IdHorario INT, @IdMedico INT
AS
BEGIN
    INSERT INTO [dbo].[Horario_x_Medico] (IdHorario, IdMedico)
    VALUES (@IdHorario, @IdMedico)
END
GO
--  ELIMINAR HxM
CREATE PROCEDURE [dbo].[EliminarHorario_x_Medico]
    @IdHorario INT, @IdMedico INT
AS
BEGIN
    DELETE FROM [dbo].[Horario_x_Medico]
    WHERE IdHorario = @IdHorario AND IdMedico = @IdMedico
END
GO
--  SELECCIONAR HxM (TODOS)

CREATE PROCEDURE [dbo].[SeleccionarHorario_x_Medico]
AS
BEGIN
    SELECT IdHorario, IdMedico FROM [dbo].[Horario_x_Medico]
END
GO
--  SELECCIONAR HxM (PARTICULAR)

CREATE PROCEDURE [dbo].[SeleccionarHorarios_x_Medico]
	@IdMedico INT
AS
BEGIN
    SELECT IdHorario, IdMedico FROM [dbo].[Horario_x_Medico]
	WHERE IdMedico = @IdMedico
END
GO


-- =============================================
-- Author:	    Palacios Fernando
-- Create date: 22/06/2024
-- Description:	Obtiene los horarios de Trabajo por Medico
-- =============================================

CREATE PROCEDURE [dbo].[ObtenerHorariosPorMedico](
@IdMedico INT
)
AS
BEGIN	
	Set NOCOUNT ON;

	Select HT.Id, HT.HorarioEntrada, HT.HorarioSalida 
	From HorarioDeTrabajo HT
	INNER JOIN Horario_x_Medico HM ON HT.Id = HM.IdHorario
	Where HM.IdMedico = @IdMedico

  
END