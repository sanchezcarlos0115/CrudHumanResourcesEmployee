USE [AdventureWorks2019]
GO

/****** Object:  StoredProcedure [HumanResources].[usp_ActualizarEmpleado]    Script Date: 22/11/2021 14:24:47 ******/
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

   UPDATE [HumanResources].[Employee] SET
    NationalIDNumber = @NationalIdNumber,
	LoginID = @LoginId,
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


