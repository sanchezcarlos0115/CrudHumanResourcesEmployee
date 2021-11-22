USE [AdventureWorks2019]
GO

/****** Object:  StoredProcedure [HumanResources].[usp_ActualizarHistorialPago]    Script Date: 22/11/2021 17:02:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Carlos Sanchez
-- Create date: 2021-11-21
-- Description:	Procedimiento que actualiza un historial de pago del empleado
-- =============================================
CREATE PROCEDURE [HumanResources].[usp_ActualizarHistorialPago]
	@BusinessEntityId int,
	@RateChangeDate datetime,
	@Rate money,
	@PayFrequency tinyint
AS
BEGIN
DECLARE @result int;	
  SET NOCOUNT ON;

   UPDATE [HumanResources].[EmployeePayHistory] SET
	[Rate] = @Rate,
	[PayFrequency] = @PayFrequency,
	[ModifiedDate] = GETDATE()
WHERE
	[BusinessEntityID] = @BusinessEntityId
	AND [RateChangeDate] = @RateChangeDate

SET  @result = @@ROWCOUNT;
SELECT @result AS Resultado;

END
GO


