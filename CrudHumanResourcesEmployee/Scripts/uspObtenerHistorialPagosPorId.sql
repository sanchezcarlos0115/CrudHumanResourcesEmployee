USE [AdventureWorks2019]
GO

/****** Object:  StoredProcedure [HumanResources].[uspObtenerHistorialPagosPorId]    Script Date: 22/11/2021 17:03:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Carlos Sanchez
-- Create date: 2021-11-22
-- Description:	Obtiene el historial de pago por BusinessEntityID,RateChangeDate 
--				en la tabla EmployeePayHistory
-- =============================================
CREATE PROCEDURE [HumanResources].[uspObtenerHistorialPagosPorId]
@BusinessEntityId int,
@RateChangeDate datetime

AS
BEGIN	
	SET NOCOUNT ON;
	SELECT
	[BusinessEntityID],
	[RateChangeDate],
	[Rate],
	[PayFrequency],
	[ModifiedDate]
FROM
	[HumanResources].[EmployeePayHistory]
WHERE
	[BusinessEntityID] = @BusinessEntityId
	AND [RateChangeDate] = @RateChangeDate

END
   
   
GO


