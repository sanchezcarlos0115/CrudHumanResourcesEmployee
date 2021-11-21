USE [AdventureWorks2019]
GO

/****** Object:  StoredProcedure [HumanResources].[usp_EliminarEmpleadoPorId]    Script Date: 21/11/2021 18:16:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Carlos Sanchez
-- Create date: 2021-11-20
-- Description:	Elimina un empleado por Id
-- =============================================
CREATE PROCEDURE [HumanResources].[usp_EliminarEmpleadoPorId]
	@Id int
AS
BEGIN
	DECLARE @result int;
	SET NOCOUNT ON;

    update  [HumanResources].[Employee]
	set CurrentFlag = '0'
    WHERE [BusinessEntityID] = @Id;

	SET  @result = @@ROWCOUNT;
	SELECT @result AS Resultado;
END
GO


