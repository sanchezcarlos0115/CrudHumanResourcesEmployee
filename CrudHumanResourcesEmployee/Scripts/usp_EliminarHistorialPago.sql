USE [AdventureWorks2019]
GO

/****** Object:  StoredProcedure [HumanResources].[usp_EliminarHistorialPago]    Script Date: 22/11/2021 17:02:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Carlos Sanchez
-- Create date: 2021-11-22
-- Description:	Elimina un historial de pago
-- =============================================
CREATE PROCEDURE [HumanResources].[usp_EliminarHistorialPago]
	@BusinessEntityId int,
	@RateChangeDate datetime
AS
BEGIN
	DECLARE @result int;
	SET NOCOUNT ON;

   DELETE FROM [HumanResources].[EmployeePayHistory]
   WHERE [BusinessEntityID] = @BusinessEntityId
	AND [RateChangeDate] = @RateChangeDate

	SET  @result = @@ROWCOUNT;
	SELECT @result AS Resultado;
END
GO


