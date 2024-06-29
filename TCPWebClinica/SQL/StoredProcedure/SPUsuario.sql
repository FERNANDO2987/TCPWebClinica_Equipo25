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
-- Description:	Agrega Usuario
-- =============================================
CREATE PROCEDURE [dbo].[AgregarUsuario]
(
    @Id INT,
    @Nombre nvarchar(100),
    @Contraseña nvarchar(50),
    @Email nvarchar(200),
    @RolId INT
)
AS
BEGIN
    IF (EXISTS (SELECT * FROM [dbo].[Usuario] WHERE Id = @Id))
        UPDATE [dbo].[Usuario]
        SET Nombre = @Nombre,
            Contraseña = @Contraseña,
            Email = @Email,
            RolId = @RolId
        WHERE Id = @Id;
    ELSE
        BEGIN
            INSERT INTO Usuario(Nombre, Contraseña, Email, RolId, CreatedDate, Deleted, DeleteDate)
            VALUES(@Nombre, @Contraseña, @Email, @RolId, GETDATE(), 0, NULL);
            
            SELECT SCOPE_IDENTITY();
        END
END

GO

-- =============================================
-- Author:		Palacios Fernando
-- Create date: 09/06/2024
-- Description:	Obtener Usuario
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerUsuario]
AS
BEGIN	
	select * from [dbo].[Usuario] 
	Where Deleted = 0

  
END
GO

-- =============================================
-- Author:		Palacios Fernando
-- Create date: 09/06/2024
-- Description:	Eliminar Usuario
-- =============================================

CREATE PROCEDURE [dbo].[EliminarUsuario]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Declarar variable para el resultado
    DECLARE @Result BIT;

    -- Verificar si el registro existe
    IF EXISTS (SELECT 1 FROM [dbo].[Usuario] WHERE [Id] = @Id)
    BEGIN
        -- Actualizar solo el registro con el Id proporcionado
        UPDATE [dbo].[Usuario]
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

-- SP LOGIN

CREATE PROCEDURE Log_in
	@nombre nvarchar(100),
	@pass nvarchar(50)
AS
BEGIN 
	SELECT Id, Email, RolId FROM Usuario WHERE Nombre = @nombre AND Contraseña = @pass
END



