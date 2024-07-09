USE [TCPClinica_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerMedicosXHorariosDeTrabajoPorMedico]
(
    @MedicoId INT
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, MedicoId, DiaSemana, HoraInicio, HoraFin
    FROM MedicoHorarios
    WHERE MedicoId = @MedicoId and Deleted = 0
END

GO


CREATE PROCEDURE [dbo].[ObtenerMedicosXHorariosDeTrabajo]
AS
BEGIN	
	select * from [dbo].[MedicoHorarios]  
	where Deleted = 0
  
END

go

CREATE PROCEDURE [dbo].[AgregarHorariosYDiasDeTrabajo]
(
    @Id INT,
    @MedicoId INT,
    @DiaSemana INT,
    @HoraInicio TIME,
    @HoraFin TIME
)
AS
BEGIN
    IF (EXISTS (SELECT * FROM [dbo].[MedicoHorarios] WHERE Id = @Id))
    BEGIN
        -- Actualizar el registro existente si ya existe el ID
        UPDATE [dbo].[MedicoHorarios]
        SET MedicoId = @MedicoId,
            DiaSemana = @DiaSemana,
            HoraInicio = @HoraInicio,
            HoraFin = @HoraFin
        WHERE Id = @Id;
    END
    ELSE
    BEGIN
        -- Insertar un nuevo registro si no existe el ID
        INSERT INTO [dbo].[MedicoHorarios] (MedicoId, DiaSemana, HoraInicio, HoraFin, CreatedDate,Deleted,DeleteDate)
        VALUES (@MedicoId, @DiaSemana, @HoraInicio, @HoraFin, GETDATE(),0,NULL);

        -- Devolver el ID generado
        SELECT SCOPE_IDENTITY() AS Id;
    END
END
