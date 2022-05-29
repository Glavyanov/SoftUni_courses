--Problem 1.	Find Names of All Employees by First Name
SELECT [FirstName]
      ,[LastName]
  FROM [Employees]
 WHERE [FirstName] LIKE 'Sa%'

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