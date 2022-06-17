                               /*******************************************
                                ** Part I – Queries for SoftUni Database **
                                *******************************************/
--Problem 1.	Employees with Salary Above 35000
CREATE PROC [usp_GetEmployeesSalaryAbove35000]
AS
BEGIN
    SELECT [FirstName] AS [First Name]
          ,[LastName] AS [Last Name]
      FROM [Employees]
     WHERE [Salary] > 35000
END

GO
EXEC [usp_GetEmployeesSalaryAbove35000]

GO
--Problem 2.	Employees with Salary Above Number
CREATE PROC [usp_GetEmployeesSalaryAboveNumber](@salaryAbove DECIMAL(18,4))
AS
BEGIN
    SELECT [FirstName] AS [First Name]
          ,[LastName] AS [Last Name]
      FROM [Employees]
     WHERE [Salary] >= @salaryAbove
END

GO

EXEC [dbo].[usp_GetEmployeesSalaryAboveNumber] 48100

GO

--Problem 3.	Town Names Starting With
CREATE PROC [usp_GetTownsStartingWith] @pattern VARCHAR(50)
AS
BEGIN
	SELECT [Name]
	  FROM [Towns]
	 WHERE [Name] LIKE CONCAT(@pattern,'%')
END

GO

EXEC [dbo].[usp_GetTownsStartingWith] 'b'

GO

--Problem 4.	Employees from Town
CREATE PROC [usp_GetEmployeesFromTown] @townName VARCHAR(50)
AS
BEGIN
    SELECT [FirstName]
          ,[LastName] 
      FROM [Employees] AS e
      JOIN [Addresses] AS a ON e.[AddressID] = a.AddressID
      JOIN [Towns] AS t ON a.[TownID] = t.[TownID]
     WHERE t.[Name] = @townName
END

GO

EXEC [dbo].[usp_GetEmployeesFromTown] 'Sofia'
EXEC [dbo].[usp_GetEmployeesFromTown] 'Seattle'

GO

--Problem 5.	Salary Level Function
CREATE FUNCTION [ufn_GetSalaryLevel](@salary DECIMAL(18,4))
RETURNS VARCHAR(8)
AS
BEGIN 
    RETURN  
        CASE    
            WHEN  @salary < 30000  THEN 'Low'
            WHEN  @salary > 50000  THEN 'High'  
            ELSE 'Average'  
        END;
END
/*CREATE FUNCTION [ufn_GetSalaryLevel](@salary DECIMAL(18,4))
RETURNS VARCHAR(8)
AS
BEGIN
    DECLARE @salaryLevel VARCHAR(8)
 
    IF @salary < 30000
    BEGIN
        SET @salaryLevel = 'Low'
    END
    ELSE IF @salary BETWEEN 30000 AND 50000
    BEGIN
        SET @salaryLevel = 'Average'
    END
    ELSE IF @salary > 50000
    BEGIN
        SET @salaryLevel = 'High'
    END
 
    RETURN @salaryLevel
END*/
GO

SELECT [Salary]
      ,[dbo].[ufn_GetSalaryLevel]([Salary])
    AS [Salary Level]
  FROM [Employees]

GO

--Problem 6.	Employees by Salary Level
CREATE PROC [usp_EmployeesBySalaryLevel](@levelOfSalary VARCHAR(8))
AS
BEGIN
    SELECT [FirstName] AS [First Name]
         , [LastName] AS [Last Name]
      FROM [Employees]
     WHERE [dbo].[ufn_GetSalaryLevel]([Salary]) = @levelOfSalary
END

GO

EXEC [dbo].[usp_EmployeesBySalaryLevel] 'High'

GO

--Problem 7.	Define Function
CREATE FUNCTION [ufn_IsWordComprised](@setOfLetters VARCHAR(100), @word VARCHAR(100))
RETURNS BIT
AS
BEGIN
    DECLARE @currentSymbol VARCHAR
    DECLARE @index INT = 1
    DECLARE @result BIT = 1

    WHILE(@index <= LEN(@word))
    BEGIN
        SET @currentSymbol = SUBSTRING(@word,@index,1);
        IF(CHARINDEX(@currentSymbol,@setOfLetters) < 1)
        BEGIN
            SET @result = 0;
            BREAK;
        END
        SET @index +=1;
    END
    RETURN @result
END

GO

SELECT [dbo].[ufn_IsWordComprised]('oistmiahf','Sofia') AS [Result]
SELECT [dbo].[ufn_IsWordComprised]('oistmiahf','halves') AS [Result]
SELECT [dbo].[ufn_IsWordComprised]('bobr','Rob') AS [Result]
SELECT [dbo].[ufn_IsWordComprised]('pppp','Guy') AS [Result]

GO

--Problem 8.	Define Function
CREATE PROC [usp_DeleteEmployeesFromDepartment](@departmentId INT)
AS
BEGIN 
	
	--Set NULL to ManagerId for Employees whose ManagerID is equal on EmployeeID to delete
    UPDATE [Employees]
    SET [ManagerID] = NULL  
    WHERE [ManagerID] IN ( SELECT [EmployeeID] 
                             FROM [Employees] 
                            WHERE [DepartmentID] = @departmentId
                         )
 --ALTER COLUMN [ManagerID] to nullable on Departments table and set to NULL [v]
     ALTER TABLE [Departments]
    ALTER COLUMN [ManagerID] INT
	
    UPDATE [Departments]
       SET [ManagerID] = NULL  
     WHERE [ManagerID] IN ( SELECT [EmployeeID] 
                              FROM [Employees] 
                             WHERE [DepartmentID] = @departmentId
                          )
--Delete from EmployeeProjects
DELETE FROM [EmployeesProjects]
      WHERE [EmployeeID] IN (
                                SELECT [EmployeeID]
                                  FROM [Employees]
                                 WHERE [DepartmentID] = @departmentId
                            )
--Delete from Employees
DELETE FROM [Employees]
      WHERE [DepartmentID] = @departmentId
--Delete from Departments
DELETE FROM [Departments]
      WHERE [DepartmentID] = @departmentId

    SELECT COUNT(*) 
     FROM [Employees] 
    WHERE [DepartmentID] = @departmentId
END

GO

/*EXEC [dbo].[usp_DeleteEmployeesFromDepartment] */

                                                /*****************************************
                                                 ** Part II – Queries for Bank Database **
                                                 *****************************************/
USE [Bank]

GO

--Problem 9.	Find Full Name
CREATE PROC [usp_GetHoldersFullName]
AS
BEGIN
    SELECT CONCAT([FirstName],' ',[LastName]) AS [Full Name]
    FROM [AccountHolders]
END

GO

EXEC [dbo].[usp_GetHoldersFullName]

GO

--Problem 10.	People with Balance Higher Than
CREATE PROC [usp_GetHoldersWithBalanceHigherThan] @greaterThan DECIMAL(18,4)
AS
BEGIN
SELECT [FirstName] AS [First Name]
     , [LastName] AS [Last Name]
  FROM [AccountHolders]
 WHERE [Id] IN (SELECT [ID] 
                 FROM (
                              SELECT ac.[Id] AS [ID]
                                   , SUM([Balance]) AS [SumBalance]
                                FROM [AccountHolders] AS ac
                                JOIN [Accounts] AS a ON ac.[Id] = a.[AccountHolderId]
							GROUP BY ac.[Id]
                      ) AS [GroupByID]
                WHERE [SumBalance] > @greaterThan 
                )
ORDER BY [First Name],[Last Name]
END

GO

EXEC [dbo].[usp_GetHoldersWithBalanceHigherThan] 6000000

GO