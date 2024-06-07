USE TCPClinica_DB
GO
/****** Object:  StoredProcedure [dbo].[ObtenerEspecialidad]    Script Date: 04/06/2024 21:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: Obtiene las Especilidades
-- Description:	Obtiene todas las Especilidades que tengan delete 0
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerEspecialidad]
AS
BEGIN	
	select * from [dbo].[Especialidad]  
	where Deleted = 0
  
END
--================================FIN===================================
GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: Crear Especilidad
-- Description:	Crea la especilidad y la actualiza
-- =============================================
CREATE PROCEDURE [dbo].[AgregarEspecilidad]
(
@Id INT,
@Nombre NVARCHAR(100)

)

AS BEGIN 
 	 
	if (EXISTS (SELECT * FROM [dbo].[Especialidad] WHERE Id = @Id ))
	UPDATE [dbo].[Especialidad] SET  Nombre = @Nombre WHERE Id = @Id 

		else
			BEGIN

INSERT INTO [dbo].[Especialidad]

VALUES(@Nombre,GETDATE(),0,NULL)

			SELECT SCOPE_IDENTITY()
		END

END

--================================FIN===================================
GO

-- =============================================
-- Author:	    Palacios Fernando
-- Create date: Eliminar Especilidad
-- Description:	Elimina la Especilidad por Id
-- =============================================

CREATE PROCEDURE [dbo].[EliminarEspecilidad]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    --  variable para el resultado
    DECLARE @Result BIT;

    -- Verificar si el registro existe
    IF EXISTS (SELECT 1 FROM [dbo].[Especialidad] WHERE [Id] = @Id)
    BEGIN
        -- Actualizar solo el registro con el Id proporcionado
        UPDATE [dbo].[Especialidad]
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
USE [TCPClinica_DB]
GO
/****** Object:  StoredProcedure [dbo].[AgregarObraSocial]    Script Date: 6/6/2024 16:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarObraSocial] @Nombre varchar(50), @Descripcion varchar(100)
AS
INSERT INTO ObraSocial(Nombre,Descripcion,CreatedDate,Deleted,DeleteDate)
VALUES(@Nombre,@Descripcion,GETDATE(),0,NULL)
GO
/****** Object:  StoredProcedure [dbo].[EliminarObraSocial]    Script Date: 6/6/2024 16:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarObraSocial] @Id int
AS
UPDATE ObraSocial
SET Deleted = 1, DeleteDate = GETDATE()
WHERE Id = @Id

GO
/****** Object:  StoredProcedure [dbo].[LeerObrasSociales]    Script Date: 6/6/2024 16:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerObrasSociales]
AS
SELECT Id, Nombre, Descripcion FROM ObraSocial
WHERE Deleted = 0

GO
/****** Object:  StoredProcedure [dbo].[ModificarObraSocial]    Script Date: 6/6/2024 16:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarObraSocial] @Nombre varchar(50), @Descripcion varchar(100), @Id int
AS
UPDATE ObraSocial
SET Nombre = @Nombre, Descripcion = @Descripcion
WHERE Id = @Id

GO            
            /****** SP [dbo].[Usuarios] ******/ 

/****** Object:  StoredProcedure [dbo].[AgregarUsuario]    Script Date: 7/6/2024 18:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarUsuario] @NombreUsuario varchar(50), @Password varchar(50), @Email varchar(100), @Rol char(1)
AS
INSERT INTO Usuarios( NombreUsuario, Password, Email, Rol, CreatedDate, Deleted, DeleteDate)
VALUES(@NombreUsuario, @Password, @Email, @Rol, GETDATE(), 0, NULL)
GO

/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 7/6/2024 18:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarUsuario] @Id int
AS
UPDATE Usuarios
SET Deleted = 1, DeleteDate = GETDATE()
WHERE Id = @Id 
GO
/****** Object:  StoredProcedure [dbo].[LeerUsuarios]    Script Date: 7/6/2024 18:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerUsuarios]
AS
Select Id, NombreUsuario, Password, Email, Rol FROM Usuarios
WHERE Deleted = 0
GO
/****** Object:  StoredProcedure [dbo].[ModificarUsuario]    Script Date: 7/6/2024 18:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarUsuario] @Id int, @NombreUsuario varchar(50), @Password varchar(50), @Email varchar(100), @Rol char(1)
AS
UPDATE Usuarios
SET NombreUsuario = @NombreUsuario, Password = @Password, Email = @Email, Rol = @Rol
WHERE Id = @Id
GO
