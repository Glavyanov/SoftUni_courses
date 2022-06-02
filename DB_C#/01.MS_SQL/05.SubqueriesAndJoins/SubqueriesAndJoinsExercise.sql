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

--Problem 4.   Employee Departments
  SELECT TOP 5
         e.[EmployeeID]
        ,e.[FirstName]
        ,e.[Salary]
        ,d.[Name] AS [DepartmentName]
    FROM [Employees] AS e
    JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
ORDER BY d.[DepartmentID]

--Problem 5.	Employees Without Project
   SELECT TOP 3
          e.[EmployeeID]
         ,e.[FirstName]
     FROM [Employees] AS e
LEFT JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
    WHERE ep.[EmployeeID] IS NULL
 ORDER BY e.[EmployeeID]

--Problem 6.   Employees Hired After
  SELECT e.[FirstName]
        ,e.[LastName]
        ,e.[HireDate]
        ,d.[Name] AS [DepartmentName]
    FROM [Employees] AS e
    JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
   WHERE e.[HireDate] > '1999-01-01' AND d.[Name] IN ('Sales','Finance')
ORDER BY e.[HireDate]

--Problem 7.  	Employees with Project
  SELECT TOP 5 
         e.[EmployeeID]
        ,e.[FirstName]
        ,p.[Name] AS [ProjectName]
    FROM [Employees] AS e
    JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
    JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
   WHERE p.[StartDate] > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.[EmployeeID]

--Problem 8.  	Employee 24
SELECT TOP 5 
       e.[EmployeeID]
      ,e.[FirstName]
      ,CASE
           WHEN YEAR(p.[StartDate]) < 2005 THEN p.[Name]
           ELSE NULL
       END AS [ProjectName]
  FROM [Employees] AS e
  JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
  JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID] AND e.[EmployeeID] = 24

--Problem 9.	Employee Manager
  SELECT e.[EmployeeID] 
        ,e.[FirstName]
        ,e.[ManagerID]
        ,m.[FirstName] AS [ManagerName]
    FROM [Employees] AS e
    JOIN [Employees] AS m ON e.[ManagerID] = m.[EmployeeID]
   WHERE e.[ManagerID] IN (3,7)
ORDER BY e.[EmployeeID]