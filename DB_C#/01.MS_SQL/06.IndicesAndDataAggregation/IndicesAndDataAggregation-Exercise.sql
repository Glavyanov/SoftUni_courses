                                     /*********************************************
                                      ** Part I � Queries for Gringotts Database **
                                      *********************************************/

--Part I � Queries for Gringotts Database

--Problem 1. Records� Count
SELECT COUNT([Id]) AS [Count]
  FROM [WizzardDeposits]

--Problem 2. Longest Magic Wand
SELECT MAX([MagicWandSize]) AS [LongestMagicWand]
  FROM [WizzardDeposits]

--Problem 3. Longest Magic Wand Per Deposit Groups
  SELECT [DepositGroup]
       , MAX([MagicWandSize]) AS [LongestMagicWand]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--Problem 4. Smallest Deposit Group Per Magic Wand Size
  SELECT TOP 2 [DepositGroup]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]
ORDER BY AVG([MagicWandSize])

--Problem 5. Deposits Sum
  SELECT [DepositGroup] 
       , SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--Problem 6. Deposits Sum for Ollivander Family
  SELECT [DepositGroup] 
       , SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] LIKE 'Ollivander%'
GROUP BY [DepositGroup]

--Problem 7. Deposits Filter
  SELECT [DepositGroup] 
       , SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] LIKE 'Ollivander%'
GROUP BY [DepositGroup]
  HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC

--Problem 8. Deposit Charge
  SELECT [DepositGroup]
       , [MagicWandCreator]
        , MIN([DepositCharge]) AS [MinDepositCharge]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup],[MagicWandCreator]
ORDER BY [MagicWandCreator],[DepositGroup]

--Problem 9. Age Groups
SELECT [AgeGroup]
      ,COUNT(*) AS [WizardCount]
       FROM 
           ( SELECT 
                  CASE
                     WHEN [Age] < 11 THEN '[0-10]'
                     WHEN [Age] < 21 THEN '[11-20]'
                     WHEN [Age] < 31 THEN '[21-30]'
                     WHEN [Age] < 41 THEN '[31-40]'
                     WHEN [Age] < 51 THEN '[41-50]'
                     WHEN [Age] < 61 THEN '[51-60]'
                     WHEN [Age] > 60 THEN '[61+]'
                  END AS [AgeGroup]
              FROM [WizzardDeposits] 
            ) AS [FilterAge]
GROUP BY [AgeGroup]

--Problem 10. First Letter
 SELECT [FirstLetter]
   FROM (
         SELECT LEFT([FirstName],1) AS [FirstLetter]
           FROM [WizzardDeposits] 
          WHERE [DepositGroup] = 'Troll Chest' 
        ) AS [Uniqueness]
GROUP BY [FirstLetter]
ORDER BY [FirstLetter]

--Problem 11. Average Interest
  SELECT [DepositGroup]
       , [IsDepositExpired]
       , AVG([DepositInterest]) AS [AverageInterest]
    FROM [WizzardDeposits]
   WHERE [DepositStartDate] > '1985-01-01'
GROUP BY [DepositGroup],[IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired]

--Problem 12. Rich Wizard, Poor Wizard
SELECT SUM([Diff]) AS [SumDifference]
  FROM (
         SELECT [DepositAmount]  - LEAD([DepositAmount]) OVER (ORDER BY [Id]) AS [Diff]
           FROM [WizzardDeposits]
       ) AS [InnerDiff]

                                            /********************************************
                                             ** Part II � Queries for SoftUni Database **
                                             ********************************************/
GO
 
USE [SoftUni]
 
GO
--Problem 13. Departments Total Salaries
  SELECT [DepartmentID]
       , SUM([Salary]) AS [TotalSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
