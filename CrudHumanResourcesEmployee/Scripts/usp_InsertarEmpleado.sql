USE [AdventureWorks2019]
GO

/****** Object:  StoredProcedure [HumanResources].[usp_InsertarEmpleado]    Script Date: 21/11/2021 18:17:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Carlos Sanchez
-- Create date: 2021-11-20
-- Description:	Procedimiento que registra un nuevo empleado
-- =============================================
CREATE PROCEDURE [HumanResources].[usp_InsertarEmpleado]
	@BusinessEntityId int,
	@NationalIdNumber nvarchar(15),
	@LoginId nvarchar(256),
	@JobTitle nvarchar(50),
	@BirthDate date,
	@MaritalStatus nchar(1),
	@Gender nchar(1),
	@HireDate date,
	@VacationHours smallint,
	@SickLeaveHours smallint
AS
BEGIN
DECLARE @result int;

	SET NOCOUNT ON;
	INSERT INTO [HumanResources].[Employee] (
		[BusinessEntityID],
		[NationalIDNumber],
		[LoginID],
		[JobTitle],
		[BirthDate],
		[MaritalStatus],
		[Gender],
		[HireDate],
		[VacationHours],
		[SickLeaveHours]
	) VALUES (
		@BusinessEntityId,
		@NationalIdNumber,
		@LoginId,
		@JobTitle,
		@BirthDate,
		@MaritalStatus,
		@Gender,
		@HireDate,
		@VacationHours,
		@SickLeaveHours
	);

	SET  @result = @@ROWCOUNT;
	SELECT @result AS Resultado;

END
GO


