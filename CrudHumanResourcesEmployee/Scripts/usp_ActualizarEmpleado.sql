USE [AdventureWorks2019]
GO

/****** Object:  StoredProcedure [HumanResources].[usp_ActualizarEmpleado]    Script Date: 21/11/2021 18:15:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Carlos Sanchez
-- Create date: 2021-11-21
-- Description:	Procedimiento que actualiza un empleado
-- =============================================
CREATE PROCEDURE [HumanResources].[usp_ActualizarEmpleado]
	@BusinessEntityId int,
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

   UPDATE [HumanResources].[Employee] SET
	[JobTitle] = @JobTitle,
	[BirthDate] = @BirthDate,
	[MaritalStatus] = @MaritalStatus,
	[Gender] = @Gender,
	[HireDate] = @HireDate,
	[VacationHours] = @VacationHours,
	[SickLeaveHours] = @SickLeaveHours,
	[ModifiedDate] = GETDATE()
WHERE
	[BusinessEntityID] = @BusinessEntityId;

SET  @result = @@ROWCOUNT;
SELECT @result AS Resultado;

END
GO


