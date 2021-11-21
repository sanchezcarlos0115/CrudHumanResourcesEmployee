USE [AdventureWorks2019]
GO

/****** Object:  StoredProcedure [HumanResources].[uspObtenerEmpleadosFull]    Script Date: 21/11/2021 18:18:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Carlos Sanchez
-- Create date: 2021-11-20
-- Description:	Obtiene todos los empleados registrados
--				en la tabla Employee
-- =============================================
CREATE PROCEDURE [HumanResources].[uspObtenerEmpleadosFull] 	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT  p.BusinessEntityID
      ,(ISNULL(p.Title,'') +' '+ p.LastName +' '+ ISNULL(p.MiddleName,'') +' '+p.FirstName) as NameDescription
      ,NationalIDNumber
      ,LoginID
      ,JobTitle
      ,BirthDate
      ,MaritalStatus
      ,Gender
      ,HireDate
      ,VacationHours
      ,SickLeaveHours
	  FROM [HumanResources].[Employee] e
	  inner join [Person].[Person] p on e.BusinessEntityID = p.BusinessEntityID 
	  where e.CurrentFlag = '1'
	   order by p.LastName,p.FirstName;
END
   
   
GO


