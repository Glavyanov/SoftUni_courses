--Part I – Queries for Gringotts Database

--Problem 1. Records’ Count
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