--Part I – Queries for SoftUni Database

--Problem 1.	Find Names of All Employees by First Name
SELECT [FirstName]
      ,[LastName]
  FROM [Employees]
 WHERE [FirstName] LIKE 'Sa%'

--Problem 1.0.
SELECT [FirstName]
      ,[LastName]
  FROM [Employees]
 WHERE SUBSTRING([FirstName], 1, 2) = 'Sa'

--Problem 2.	Find Names of All employees by Last Name
SELECT [FirstName]
      ,[LastName] 
  FROM [Employees]
 WHERE [LastName] LIKE'%EI%'
 
--Problem 2.0.
SELECT [FirstName]
      ,[LastName] 
  FROM [Employees]
 WHERE CHARINDEX('EI', [LastName]) <> 0 -- => case-insensitive

--Problem 2.1.
SELECT [FirstName]
      ,[LastName] 
  FROM [Employees]
 WHERE PATINDEX('%ei%', [LastName]) <> 0 -- => case-insensitive

--Problem 3.	Find First Names of All Employees
SELECT [FirstName]
  FROM [Employees]
 WHERE [DepartmentID] IN (3,10)
   AND DATEPART(year,[HireDate]) BETWEEN 1995 AND 2005

--Problem 3.0.
SELECT [FirstName]
  FROM [Employees]
 WHERE [DepartmentID] IN (3,10)
   AND YEAR([HireDate]) BETWEEN 1995 AND 2005

--Problem 4.	Find All Employees Except Engineers
SELECT [FirstName]
	  ,[LastName]
  FROM [Employees]
 WHERE PATINDEX('%engineer%', [JobTitle]) = 0

--Problem 4.0.
SELECT [FirstName]
	  ,[LastName]
  FROM [Employees]
 WHERE [JobTitle] NOT LIKE '%engineer%'

--Problem 5.	Find Towns with Name Length
  SELECT [Name]
    FROM [Towns]
   WHERE LEN([Name]) IN (5,6)
ORDER BY [Name]

--Problem 5.0.
  SELECT [Name]
    FROM [Towns]
   WHERE LEN([Name]) BETWEEN 5 AND 6
ORDER BY [Name]

--Problem 6.	Find Towns Starting With
  SELECT [TownID]
        ,[Name]
    FROM [Towns]
   WHERE [Name] LIKE '[mkbe]%'
ORDER BY [Name]

--Problem 6.0.
  SELECT [TownID]
        ,[Name]
    FROM [Towns]
   WHERE LEFT([Name],1) IN ('m','k','b','e')
ORDER BY [Name]

--Problem 7.	 Find Towns Not Starting With
  SELECT [TownID]
        ,[Name]
    FROM [Towns]
   WHERE [Name] NOT LIKE '[rbd]%'
ORDER BY [Name]

--Problem 7.0.
  SELECT [TownID]
        ,[Name]
    FROM [Towns]
   WHERE LEFT([Name],1) NOT IN ('r','d','b')
ORDER BY [Name]

--Problem 7.1.
  SELECT [TownID]
        ,[Name]
    FROM [Towns]
   WHERE [Name] LIKE '[^rdb]%'
ORDER BY [Name]

--Problem 8.	Create View Employees Hired After 2000 Year
CREATE OR ALTER VIEW [V_EmployeesHiredAfter2000] AS 
      SELECT [FirstName]
            ,[LastName]
        FROM [Employees]
       WHERE YEAR([HireDate]) > 2000

--Problem 9.	Length of Last Name
SELECT [FirstName]
      ,[LastName]
  FROM [Employees]
 WHERE LEN([LastName]) = 5

 --Problem 10.	Rank Employees by Salary
  SELECT [EmployeeID]
        ,[FirstName]
        ,[LastName]
        ,[Salary]
        ,DENSE_RANK() OVER (PARTITION BY[Salary] ORDER BY [EmployeeID]) AS [Rank]
    FROM [Employees]
   WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

--Problem 11.	Find All Employees with Rank 2
SELECT * 
  FROM 
     (
       SELECT [EmployeeID]
             ,[FirstName]
             ,[LastName]
             ,[Salary]
             ,DENSE_RANK() OVER (PARTITION BY[Salary] ORDER BY [EmployeeID]) AS [Rank]
         FROM [Employees]
        WHERE [Salary] BETWEEN 10000 AND 50000 
     )
	  AS [Inner Select]
   WHERE [RANK] = 2
ORDER BY [Salary] DESC

--Part II – Queries for Geography Database 

--Problem 12.	Countries Holding ‘A’ 3 or More Times
  SELECT [CountryName]
        ,[IsoCode] AS [ISO Code]
    FROM [Countries]
   WHERE [CountryName] LIKE '%a%a%a%'
 ORDER BY[IsoCode]

--Problem 12.0.	Countries Holding ‘A’ 3 or More Times
 SELECT [CountryName]
       ,[IsoCode] AS [ISO Code]
   FROM [Countries]
  WHERE LEN([CountryName]) - LEN(REPLACE([CountryName], 'a','')) > 2
ORDER BY[IsoCode]

 --Problem 13.	Mix of Peak and River Names
  SELECT [PeakName]
        ,[RiverName]
        ,LOWER(CONCAT(SUBSTRING([PeakName],1,LEN([PeakName])-1),[RiverName])) AS [Mix]
    FROM [Rivers]
        ,[Peaks]
   WHERE UPPER(RIGHT([PeakName],1)) = UPPER(LEFT([RiverName],1))
ORDER BY [Mix]

--Part III – Queries for Diablo Database

--Problem 14.	Games from 2011 and 2012 year
  SELECT TOP 50
         g.[Name]
        ,CONVERT(VARCHAR(10), g.[Start],121) AS [Start]
    FROM [Games] AS g
   WHERE YEAR(g.[Start]) IN (2011,2012)
ORDER BY [Start],g.[Name]

--Problem 14.0.	Games from 2011 and 2012 year
  SELECT TOP 50
         g.[Name]
        ,FORMAT(g.[Start],'yyyy-MM-dd') AS [Start]
    FROM [Games] AS g
   WHERE YEAR(g.[Start]) IN (2011,2012)
ORDER BY [Start],g.[Name]

--Problem 14.1.	Games from 2011 and 2012 year
  SELECT TOP 50
         g.[Name]
        ,CAST(g.[Start] AS DATE) AS [Start]
    FROM [Games] AS g
   WHERE YEAR(g.[Start]) IN (2011,2012)
ORDER BY [Start],g.[Name]

--Problem 15.	User Email Providers
  SELECT [Username]
        ,REPLACE([Email],SUBSTRING([Email],1,CHARINDEX('@',[Email],1)),'') AS [Email Provider]
    FROM [Users]
ORDER BY [Email Provider],[Username]

--Problem 16.	Get Users with IPAdress Like Pattern
  SELECT [Username]
        ,[IpAddress]
    FROM [Users]
   WHERE [IpAddress] LIKE '___.1%.%.___'
ORDER BY [Username]

--Problem 17.	Show All Games with Duration and Part of the Day
  SELECT [Name]
      AS [Game]
        ,CASE 
            WHEN DATEPART(HOUR,[Start]) < 12 THEN 'Morning'
            WHEN DATEPART(HOUR,[Start]) < 18 THEN 'Afternoon'
            WHEN DATEPART(HOUR,[Start]) < 24 THEN 'Evening'
         END 
      AS [Part of the Day]
        ,CASE 
            WHEN [Duration] < 4 THEN 'Extra Short'
            WHEN [Duration] < 7 THEN 'Short'
            WHEN [Duration] > 6 THEN 'Long'
            ELSE 'Extra Long'
         END
      AS [Duration]
    FROM [Games]
ORDER BY [Game],[Duration],[Part of the Day]