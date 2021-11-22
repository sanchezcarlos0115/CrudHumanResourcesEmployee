USE [AdventureWorks2019]
GO

/****** Object:  StoredProcedure [HumanResources].[uspObtenerHistorialPagosFull]    Script Date: 22/11/2021 15:57:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Carlos Sanchez
-- Create date: 2021-11-22
-- Description:	Obtiene el histrorial de pagos empleados registrados
--				en la tabla EmployeePayHistory
-- =============================================
CREATE PROCEDURE [HumanResources].[uspObtenerHistorialPagosFull] 	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT
	hp.[BusinessEntityID],
	hp.[RateChangeDate],
	hp.[Rate],
	hp.[PayFrequency]
FROM
	[HumanResources].[EmployeePayHistory] hp
	order by hp.BusinessEntityID;

END
   
   
GO


