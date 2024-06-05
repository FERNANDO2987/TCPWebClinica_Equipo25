USE TCPClinica_DB
GO
/****** Object:  StoredProcedure [dbo].[ObtenerEspecialidad]    Script Date: 04/06/2024 21:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ObtenerEspecialidad]
AS
BEGIN	
	select * from [dbo].[Especialidad]  
	where Deleted = 0
  
END