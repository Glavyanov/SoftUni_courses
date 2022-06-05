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

--Problem 10. Employee Summary
  SELECT TOP 50
        e.[EmployeeID]
        ,CONCAT(e.[FirstName],' ',e.[LastName]) AS [EmployeeName]
        ,CONCAT(m.[FirstName],' ' ,m.[LastName]) AS [ManagerName]
        ,d.[Name] AS [DepartmentName]
    FROM [Employees] AS e
    JOIN [Employees] AS m ON e.[ManagerID] = m.[EmployeeID]
    JOIN [Departments] AS d ON e.[DepartmentID] = d.DepartmentID
ORDER BY e.[EmployeeID]

--Problem 11. Min Average Salary
SELECT 
  MIN(avQ.[av]) AS [MinAverageSalary]
FROM (
       SELECT AVG([Salary]) AS av
         FROM [Employees]
     GROUP BY [DepartmentID]
     ) 
  AS [avQ]

--Part II – Queries for Geography Database

--Problem 12. Highest Peaks in Bulgaria
  SELECT c.[CountryCode]
        ,m.[MountainRange]
        ,p.[PeakName]
        ,p.[Elevation]
    FROM [Countries] AS c
    JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
    JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
    JOIN [Peaks] AS p ON m.Id = p.MountainId
WHERE c.[CountryCode] = 'BG' AND p.[Elevation] > 2835
ORDER BY p.[Elevation] DESC

---Problem 13. Count Mountain Ranges
  SELECT mc.[CountryCode]
        ,COUNT(m.[MountainRange]) AS [MountainRange]
    FROM [Mountains] AS m
    JOIN [MountainsCountries] AS mc ON m.[Id] = mc.[MountainId]
   WHERE mc.[CountryCode] IN ('US','BG','RU')
GROUP BY mc.[CountryCode]

--Problem 14. Countries with Rivers
   SELECT TOP 5
          c.[CountryName]
         ,r.[RiverName]
     FROM [Countries] AS c
LEFT JOIN [CountriesRivers] AS cr ON cr.[CountryCode] = c.[CountryCode]
LEFT JOIN [Rivers] AS r ON cr.[RiverId] = r.[Id]
    WHERE c.[ContinentCode] = 'AF'
 ORDER BY c.[CountryName]

--Problem 15. Continents and Currencies
  SELECT [MaxCurrency].[ContinentCode]
        ,[MaxCurrency].[CurrencyCode]
        ,[MaxCurrency].[CurrencyUsage] 
    FROM (
			SELECT * 
				  ,DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY [CurrencyUsage] DESC) AS [CurrRanking]
              FROM (
                         SELECT c.[ContinentCode],
                                ctr.[CurrencyCode],
                                COUNT(ctr.[CurrencyCode]) AS [CurrencyUsage]
                           FROM [Continents] AS c
                      LEFT JOIN [Countries] AS ctr ON c.[ContinentCode] = ctr.[ContinentCode]
                       GROUP BY c.[ContinentCode], ctr.[CurrencyCode] 
                   ) 
                AS [CurrencyGreaterThenOne]
             WHERE [CurrencyUsage] > 1
		 ) 
      AS [MaxCurrency]
   WHERE [CurrRanking] = 1
ORDER BY [MaxCurrency].[ContinentCode]

--Problem 16. Countries Without Any Mountains
   SELECT COUNT(*) AS [Count]
     FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
    WHERE mc.[MountainId] IS NULL

--Problem 17. Highest Peak and Longest River by Country
   SELECT TOP 5
          [CountryName]
         ,MAX(p.[Elevation]) AS [HighestPeakElevation]
         ,MAX(r.[Length]) AS [LongestRiverLength]
     FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN [Mountains] AS m ON mc.[MountainId] = m.Id
LEFT JOIN [Peaks] AS p ON m.[Id] = p.[MountainId]
LEFT JOIN [CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r ON cr.[RiverId] = r.[Id]
 GROUP BY c.[CountryName]
 ORDER BY [HighestPeakElevation] DESC,[LongestRiverLength] DESC, [CountryName]

--Problem 18. Highest Peak Name and Elevation by Country
  SELECT TOP 5
         [CountryName] AS [Country]
        ,CASE
             WHEN [PeakName] IS NULL THEN '(no highest peak)'
             ELSE [PeakName]
         END AS [Highest Peak Name]
        ,CASE
             WHEN [Highest Peak Elevation] IS NULL THEN 0
             ELSE [Highest Peak Elevation]
         END AS [Highest Peak Elevation]
        ,CASE
             WHEN [MountainRange] IS NULL THEN '(no mountain)'
             ELSE [MountainRange]
         END AS [Mountain]
    FROM (
            SELECT *
                  ,DENSE_RANK() OVER (PARTITION BY [CountryName] ORDER BY [Highest Peak Elevation] DESC) AS [RankElev]
              FROM (
                           SELECT c.[CountryName]
                                 ,p.[PeakName]
                                 ,p.[Elevation] AS [Highest Peak Elevation]
                                 ,m.[MountainRange]
                             FROM [Countries] AS c
                        LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
                        LEFT JOIN [Mountains] AS m ON mc.[MountainId] =  m.[Id]
                        LEFT JOIN [Peaks] AS p ON m.[Id] = p.[MountainId]
                    ) 
                 AS [AllInfo]
         ) 
      AS [CurrentRank]
   WHERE [RankElev] = 1
ORDER BY [CountryName],[Highest Peak Name]