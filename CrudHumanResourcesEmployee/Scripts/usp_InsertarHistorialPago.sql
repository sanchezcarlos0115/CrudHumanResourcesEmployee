USE [AdventureWorks2019]
GO

/****** Object:  StoredProcedure [HumanResources].[usp_InsertarHistorialPago]    Script Date: 22/11/2021 17:01:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Carlos Sanchez
-- Create date: 2021-11-22
-- Description:	Procedimiento que registra un nuevo historial pago
-- =============================================
CREATE PROCEDURE [HumanResources].[usp_InsertarHistorialPago]
	@BusinessEntityId int,
	@RateChangeDate datetime,
	@Rate money,
	@PayFrequency tinyint
AS
BEGIN
DECLARE @result int;

	SET NOCOUNT ON;
	INSERT INTO [HumanResources].[EmployeePayHistory] (
	[BusinessEntityID],
	[RateChangeDate],
	[Rate],
	[PayFrequency],
	[ModifiedDate]
	) VALUES (
		@BusinessEntityId,
		@RateChangeDate,
		@Rate,
		@PayFrequency,
		GETDATE()
	);

	SET  @result = @@ROWCOUNT;
	SELECT @result AS Resultado;

END
GO


