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