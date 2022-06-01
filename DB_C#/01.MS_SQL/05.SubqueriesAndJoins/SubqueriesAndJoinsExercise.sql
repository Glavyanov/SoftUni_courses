--Part I – Queries for SoftUni Database

--Problem 1.	Employee Address
  SELECT TOP 5
         e.[EmployeeID] AS [EmployeeId] 
        ,e.[JobTitle]
        ,e.[AddressID] AS [AddressId]
        ,a.[AddressText]
    FROM [Employees] AS e
    JOIN [Addresses] AS a ON e.AddressID = a.AddressID
ORDER BY [AddressId]

--Problem 2.	Addresses with Towns
  SELECT TOP 50
         e.[FirstName]
        ,e.[LastName]
        ,t.[Name] AS [Town]
        ,a.[AddressText]
    FROM [Employees] AS e
    JOIN [Addresses] AS a ON e.[AddressID] = a.[AddressID]
    JOIN [Towns] AS t ON a.[TownID] = t.[TownID]
ORDER BY e.[FirstName],e.[LastName]

--Problem 3.	Sales Employee
  SELECT e.[EmployeeID]
        ,e.[FirstName]
        ,e.[LastName]
        ,d.[Name] AS [DepartmentName]
    FROM [Employees] AS e
    JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID] AND d.[Name] = 'Sales'
ORDER BY e.[EmployeeID]

--Problem 3.0.	Sales Employee
  SELECT e.[EmployeeID]
        ,e.[FirstName]
        ,e.[LastName]
        ,d.[Name] AS [DepartmentName]
    FROM [Employees] AS e
    JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID] 
   WHERE d.[Name] IN ('Sales')
ORDER BY e.[EmployeeID]
