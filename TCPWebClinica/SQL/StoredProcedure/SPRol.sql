USE TCPClinica_DB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Palacios Fernando
-- Create date: 09/06/2024
-- Description:	Obtener Rol por Id
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerRolPorId]
@Id INT
AS
BEGIN	
	select * from [dbo].[Rol]  
	where Id = @Id and Deleted = 0

  
END

go

-- =============================================
-- Author:		Palacios Fernando
-- Create date: 09/06/2024
-- Description:	Obtener Rol por Id
-- =============================================

