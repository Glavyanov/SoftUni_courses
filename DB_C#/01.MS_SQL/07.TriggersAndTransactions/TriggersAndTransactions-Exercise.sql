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