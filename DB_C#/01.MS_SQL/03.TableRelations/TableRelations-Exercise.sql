CREATE DATABASE [TableRelations-Exercise]
GO

USE [TableRelations-Exercise]

GO

--Problem 1.	One-To-One Relationship
CREATE TABLE [Passports](
	[PassportID] INT PRIMARY KEY,
	[PassportNumber] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE [Persons](
	[PersonID] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[Salary] DECIMAL(9,2) NOT NULL,
	[PassportID] INT FOREIGN KEY REFERENCES [Passports](PassportID) NOT NULL UNIQUE
)

INSERT INTO [Passports]([PassportID],[PassportNumber])
	VALUES
			(101,'N34FG21B'),
			(102,'K65LO4R7'),
			(103,'ZE657QP2')

INSERT INTO [Persons]([FirstName],[Salary],[PassportID])
	VALUES
			('Roberto',43300.00,102),
			('Tom',56100.00,103),
			('Yana',60200.00,101)

--Problem 2.	One-To-Many Relationship
	CREATE TABLE [Manufacturers](
	[ManufacturerID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[EstablishedOn] DATE
)

CREATE TABLE [Models](
	[ModelID] INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(50) NOT NULL,
	[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID]) NOT NULL
)

INSERT INTO [Manufacturers]([Name],[EstablishedOn])
	VALUES
			('BMW','07/03/1916'),
			('Tesla','01/01/2003'),
			('Lada','01/05/1966')

INSERT INTO [Models]([Name],[ManufacturerID])
	VALUES
			('X1',1),
			('i6',1),
			('Model S',2),
			('Model X',2),
			('Model 3',2),
			('Nova',3)

--Problem 3.	Many-To-Many Relationship
CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Exams](
	[ExamID] INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [StudentsExams](
	[StudentID] INT FOREIGN	KEY REFERENCES [Students]([StudentID]),
	[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]),
	PRIMARY KEY ([StudentID], [ExamID])
)

INSERT INTO [Students]([Name])
	VALUES
			('Mila'),
			('Toni'),
			('Ron')

INSERT INTO [Exams]([Name])
	VALUES
			('SpringMVC'),
			('Neo4j'),
			('Oracle 11g')

INSERT INTO [StudentsExams]([StudentID],[ExamID])
	VALUES
			(1,101),
			(1,102),
			(2,101),
			(3,103),
			(2,102),
			(2,103)

--Problem 4.	Self-Referencing 
CREATE TABLE [Teachers](
	[TeacherID] INT PRIMARY KEY IDENTITY (101,1),
	[Name] VARCHAR(50) NOT NULL,
	[ManagerID] INT FOREIGN KEY REFERENCES [Teachers](TeacherID)
)

INSERT INTO [Teachers]([Name],[ManagerID])
	VALUES
			('John', NULL),
			('Maya', 106),
			('Silvia', 106),
			('Ted', 105),
			('Mark', 101),
			('Greta', 101)

--Problem 5.	Online Store Database
CREATE DATABASE [OnlineStore]
GO
USE [OnlineStore]
GO

CREATE TABLE [Cities](
	[CityID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Customers](
	[CustomerID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Birthday] DATE,
	[CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID]) NOT NULL
)

CREATE TABLE [Orders](
	[OrderID] INT PRIMARY KEY IDENTITY,
	[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID]) NOT NULL
)

CREATE TABLE [ItemTypes](
	[ItemTypeID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Items](
	[ItemID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID]) NOT NULL
)

CREATE TABLE [OrderItems](
	[OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID]),
	[ItemID] INT FOREIGN KEY REFERENCES [Items]([ItemID]),
	PRIMARY KEY ([OrderID], [ItemID])
)

--Problem 6.	University Database
CREATE DATABASE [University]
GO
USE [University]
GO

CREATE TABLE [Majors](
	[MajorID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[StudentNumber] INT NOT NULL UNIQUE,
	[StudentName] VARCHAR(50) NOT NULL,
	[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID]) NOT NULL
)

CREATE TABLE [Payments](
	[PaymentID] INT PRIMARY KEY IDENTITY,
	[PaymentDate] DATETIME2 NOT NULL,
	[PaymentAmount] DECIMAL(9,2) NOT NULL,
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL
)

CREATE TABLE [Subjects](
	[SubjectID] INT PRIMARY KEY IDENTITY,
	[SubjectName] VARCHAR(50) NOT NULL
)

CREATE TABLE [Agenda](
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
	[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]),
	PRIMARY KEY ([StudentID],[SubjectID])
)

--Problem 9.	Peaks in Rila
  SELECT m.MountainRange, p.PeakName, p.Elevation 
    FROM Mountains AS m
    JOIN Peaks AS p ON p.MountainId = m.Id
   WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC

--Problem 9.0.	Peaks in Rila
  SELECT m.MountainRange, p.PeakName, p.Elevation 
    FROM Mountains AS m
    JOIN Peaks AS p ON p.MountainId = m.Id
     AND m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC
