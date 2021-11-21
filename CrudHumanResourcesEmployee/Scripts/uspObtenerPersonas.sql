USE [AdventureWorks2019]
GO

/****** Object:  StoredProcedure [HumanResources].[uspObtenerPersonas]    Script Date: 21/11/2021 18:19:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Carlos Sanchez
-- Create date: 2021-11-20
-- Description:	Obtiene las 200 primeras personas que no estan
--				regitradas en la tabla Employee
-- =============================================
CREATE PROCEDURE [HumanResources].[uspObtenerPersonas] 	
AS
BEGIN
	
	SET NOCOUNT ON;

	 SELECT TOP (200) p.BusinessEntityID
      ,(ISNULL(p.[Title],'') +' '+ p.[LastName] +' '+ ISNULL(p.[MiddleName],'') +' '+p.[FirstName]) as NameDescription
	  FROM [Person].[Person] p where p.BusinessEntityID  NOT IN 
	  (SELECT e.[BusinessEntityID] 
	   FROM [HumanResources].[Employee] e)
	   order by p.LastName,p.FirstName;

END
GO


