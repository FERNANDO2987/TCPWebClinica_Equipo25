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
            /****** SP [dbo].[Administrador] ******/ 
/****** Object:  StoredProcedure [dbo].[AgregarAdministrador]    Script Date: 8/6/2024 00:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarAdministrador] @Nombre varchar(50), @Apellido varchar(50), @Email varchar(100)
AS
INSERT INTO Administrador(Nombre, Apellido, Email, CreatedDate, Deleted, DeleteDate)
VALUES(@Nombre,@Apellido,@Email,GETDATE(),0,NULL)
GO
/****** Object:  StoredProcedure [dbo].[EliminarAdministrador]    Script Date: 8/6/2024 00:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarAdministrador] @Id int
AS
UPDATE Administrador
SET Deleted = 1, DeleteDate = GETDATE()
where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[LeerAdministradores]    Script Date: 8/6/2024 00:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerAdministradores]
AS 
SELECT Id, Nombre, Apellido, Email FROM Administrador
WHERE Deleted = 0
GO
/****** Object:  StoredProcedure [dbo].[ModificarAdministrador]    Script Date: 8/6/2024 00:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarAdministrador] @Id int, @Nombre varchar(50), @Apellido varchar(50), @Email varchar(100)
AS
UPDATE Administrador
SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email
where Id = @Id
GO
            /****** SP [dbo].[Recepcionista] ******/ 
/****** Object:  StoredProcedure [dbo].[AgregarRecepcionista]    Script Date: 8/6/2024 00:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarRecepcionista] @Nombre varchar(50), @Apellido varchar(50), @Email varchar(100)
AS
INSERT INTO Recepcionista(Nombre, Apellido, Email, CreatedDate, Deleted, DeleteDate)
VALUES(@Nombre,@Apellido,@Email,GETDATE(),0,NULL)
GO
/****** Object:  StoredProcedure [dbo].[EliminarRecepcionista]    Script Date: 8/6/2024 00:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarRecepcionista] @Id int
AS
UPDATE Recepcionista
SET Deleted = 1, DeleteDate = GETDATE()
where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[LeerRecepcionistas]    Script Date: 8/6/2024 00:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerRecepcionistas]
AS 
SELECT Id, Nombre, Apellido, Email FROM Recepcionista
WHERE Deleted = 0
GO
/****** Object:  StoredProcedure [dbo].[ModificarRecepcionista]    Script Date: 8/6/2024 00:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarRecepcionista] @Id int, @Nombre varchar(50), @Apellido varchar(50), @Email varchar(100)
AS
UPDATE Recepcionista
SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email
where Id = @Id
GO

            /****** SP [dbo].[EstadoTurno] ******/ 
/****** Object:  StoredProcedure [dbo].[AgregarEstadoTurno]    Script Date: 8/6/2024 00:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarEstadoTurno] @Estado varchar(50)
AS
INSERT INTO EstadoTurno(Estado, CreatedDate, Deleted, DeleteDate)
VALUES(@Estado,GETDATE(),0,NULL)
GO
/****** Object:  StoredProcedure [dbo].[EliminarEstadoTurno]    Script Date: 8/6/2024 00:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarEstadoTurno] @Id int
AS
UPDATE EstadoTurno
SET Deleted = 1, DeleteDate = GETDATE()
where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[LeerEstadoTurno]    Script Date: 8/6/2024 00:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerEstadoTurno]
AS 
SELECT Id, Estado FROM EstadoTurno
WHERE Deleted = 0
GO
/****** Object:  StoredProcedure [dbo].[ModificarEstadoTurno]    Script Date: 8/6/2024 00:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarEstadoTurno] @Id int, @Estado varchar(50)
AS
UPDATE EstadoTurno
SET Estado = @Estado
where Id = @Id
GO


