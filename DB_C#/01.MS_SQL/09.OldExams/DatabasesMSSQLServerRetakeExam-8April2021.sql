CREATE DATABASE [Service]

GO

USE [Service]

GO

CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL UNIQUE,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME2,
	Age INT,
	CHECK(Age BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME2,
	Age INT,
	CHECK(Age BETWEEN 18 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)


CREATE TABLE [Status] (
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL,
)


CREATE TABLE Reports (
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME2 NOT NULL,
	CloseDate DATETIME2,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--2
INSERT INTO Employees(FirstName, LastName, Birthdate, DepartmentId)
VALUES
	('Marlo','O''Malley', '1958-9-21', 1),
	('Niki','Stanaghan', '1969-11-26', 4),
	('Ayrton','Senna', '1960-03-21', 9),
	('Ronnie','Peterson', '1944-02-14', 9),
	('Giovanna','Amati', '1959-07-20', 5)

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES
	(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
	(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
	(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
	(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

--3
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--4
DELETE FROM Reports
WHERE StatusId = 4

--5
SELECT [Description] 
, FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY CONVERT(DATETIME2, OpenDate, 103) ASC

--6
SELECT r.[Description]
, c.[Name] AS CategoryName
FROM Categories AS c
JOIN Reports AS r ON c.Id = r.CategoryId
ORDER BY r.[Description], CategoryName

--7
SELECT TOP 5 CategoryName
           , COUNT(*) AS ReportsNumber
        FROM (
                 SELECT  c.[Name] AS CategoryName
                       , r.StatusId
                    FROM Categories AS c
                    JOIN Reports AS r ON c.Id = r.CategoryId
             ) AS GroupingByName
      GROUP BY CategoryName
      ORDER BY ReportsNumber DESC, CategoryName

--8
  SELECT u.Username
       , c.[Name] AS CategoryName
    FROM  Users AS u
    JOIN Reports AS r ON u.Id = r.UserId
    JOIN Categories AS c ON c.Id = r.CategoryId
   WHERE CONCAT(DATEPART(MONTH,r.OpenDate),DATEPART(DAY,r.OpenDate)) = CONCAT(DATEPART(MONTH,u.Birthdate),DATEPART(DAY,u.Birthdate))
ORDER BY u.Username, CategoryName

--9
  SELECT FullName
       , COUNT(UserId)  AS UsersCount
    FROM (
		  SELECT r.UserId AS UserId
			   , CONCAT(e.FirstName, ' ', e.LastName) AS FullName
			FROM Employees AS e 
			LEFT JOIN Reports AS r ON r.EmployeeId = e.Id
			LEFT JOIN Users AS u ON u.Id = r.UserId
         ) AS GroupingByName
GROUP BY FullName
ORDER BY UsersCount DESC, FullName

--10
SELECT 
		CASE 
			WHEN CONCAT(e.FirstName,' ', e.LastName) = '' THEN 'None'
			ELSE CONCAT(e.FirstName,' ', e.LastName)
		END AS Employee
	 , ISNULL(d.[Name], 'None')  AS Department
	 , ISNULL(c.[Name], 'None') AS Category
	 , ISNULL(r.[Description], 'None') AS [Description]
	 , ISNULL(CONVERT(VARCHAR, r.OpenDate, 104), 'None')  AS OpenDate
	 , ISNULL(s.[Label], 'None') AS [Status]
	 , ISNULL(u.[Name], 'None') AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
JOIN [Status] AS s ON s.Id = r.StatusId
JOIN Categories AS c ON r.CategoryId = c.Id
JOIN Users AS u ON r.UserId = u.Id
ORDER BY e.FirstName DESC, e.LastName DESC, Department ASC , Category ASC , r.[Description] ASC , CONVERT(DATETIME2, OpenDate, 103) ASC , [Status] ASC , [User] ASC

--11
GO

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN 
	DECLARE @result INT
	IF(@StartDate IS NULL OR  @EndDate IS NULL)
	BEGIN
		SET @result = 0
	END
	ELSE
	BEGIN 
		SET @result = DATEDIFF(HOUR, @StartDate, @EndDate)
	END
	RETURN @result
END

GO

SELECT [dbo].udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

GO

--12
CREATE PROC usp_AssignEmployeeToReport @EmployeeId INT, @ReportId INT
AS
BEGIN
    DECLARE @checkReportDepart INT = ( SELECT TOP 1 c.DepartmentId
                                               FROM Reports AS r
                                               JOIN Categories AS c ON r.CategoryId = c.Id
                                              WHERE r.Id = @ReportId --
                                       )

    DECLARE @checkEmployeeDepart INT = ( SELECT TOP 1 DepartmentId
                                               FROM  Employees
                                              WHERE Id =  @EmployeeId
                                       )							  
    IF(@checkEmployeeDepart <> @checkReportDepart)
    THROW 50001,'Employee doesn''t belong to the appropriate department!', 1
    ELSE
    BEGIN 
    UPDATE Reports
       SET EmployeeId = @EmployeeId
     WHERE Id = @ReportId
    END
END

GO

EXEC usp_AssignEmployeeToReport 30, 1
EXEC usp_AssignEmployeeToReport 17, 2