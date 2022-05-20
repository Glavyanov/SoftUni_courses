--Problem 1.	Create Database
CREATE DATABASE[Minions]

USE [Minions]

--Problem 2.	Create Tables
CREATE TABLE [Minions](
	 [Id] INT  PRIMARY KEY NOT NULL,
	 [Name] NVARCHAR(50) NOT NULL,
	 [Age] INT,
);

CREATE TABLE [Towns](
	 [Id] INT  PRIMARY KEY NOT NULL,
	 [Name] NVARCHAR(50) NOT NULL,
);

--Problem 3.	Alter Minions Table
ALTER TABLE [Minions] 
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns](Id);

--Problem 4.	Insert Records in Both Tables
INSERT INTO [Towns]([Id], [Name]) VALUES 
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId]) VALUES 
(1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Steward',NULL,2)

--Problem 5.	Truncate Table Minions
TRUNCATE TABLE [Minions];

--Problem 6.	Drop All Tables
DROP TABLE [MInions],[Towns];

--Problem 7.	Create Table People
CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture])<=20000000),
	[Height] DECIMAL(4,2),
	[Weight] DECIMAL(5,2),
	[Gender] CHAR(1) NOT NULL,
    CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX)
);

INSERT INTO [People]([Name],[Picture],[Height],[Weight],[Gender],[Birthdate],[Biography]) VALUES
(N'Александър',CAST('0xBDC5C000000000000000000000000000' As varbinary(MAX)),1.8,8.3,'m','02.02.1990',N'Някаква биография'),
(N'Александра',CAST('0xBDC5C000000000000000000000000000' As varbinary(MAX)),1.8,80.3,'f','01.01.1984',N'Някаква биография'),
(N'Борис',CAST('0xBDC5C000000000000000000000000000' As varbinary(MAX)),1.8,80.3,'m','01.01.1983',N'Някаква биография'),
(N'Борислава',CAST('0xBDC5C000000000000000000000000000' As varbinary(MAX)),1.8,80.3,'f','01.01.1982',N'Някаква биография'),
(N'Георги',CAST('0xBDC5C000000000000000000000000000' As varbinary(MAX)),1.8,80.3,'m','01.01.1981',N'Някаква биография')

--Problem 8.	Create Table Users
CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture])<=900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT
);

INSERT INTO [Users]([Username],[Password],[ProfilePicture],[LastLoginTime],[IsDeleted]) VALUES 
('User1','1',NULL,'01.01.2009',0),
('User2','2',NULL,'01.01.2019',0),
('User3','3',NULL,'01.01.2015',1),
('User4','4',NULL,'01.01.2008',0),
('User5','5',NULL,'01.01.2021',1)

--Problem 9.	Change Primary Key
ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC07AA8EC090]

ALTER TABLE [USers]
ADD CONSTRAINT [PK_UsersComposite_IdAndUsername] PRIMARY KEY ([Id],[Username])

--Problem 10.	Add Check Constraint
ALTER TABLE [Users]
ADD CONSTRAINT [PasswordLength] CHECK (LEN([Password])>4)

--Problem 11.	Set Default Value of a Field
   ALTER TABLE [Users] 
ADD CONSTRAINT [DF_LastLoginTime]
       DEFAULT CURRENT_TIMEZONE() FOR [LastLoginTime];

--Problem 14.	Car Rental Database
CREATE DATABASE [CarRental];

USE [CarRental];

CREATE TABLE [Categories](
	 [Id] INT PRIMARY KEY IDENTITY
    ,[CategoryName] VARCHAR(200) NOT NULL UNIQUE
	,[DailyRate] DECIMAL(9,2)
	,[WeeklyRate]DECIMAL(9,2)
	,[MonthlyRate] DECIMAL(9,2)
	,[WeekendRate]DECIMAL(9,2)
);

CREATE TABLE [Cars](
	 [Id] INT PRIMARY KEY IDENTITY
	,[PlateNumber] NVARCHAR(50)
	,[Manufacturer] NVARCHAR(200) NOT NULL
	,[Model] NVARCHAR(200) NOT NULL
	,[CarYear] INT
	,[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id])
	,[Doors] SMALLINT
	,[Picture] VARBINARY(MAX)
	,CHECK (DATALENGTH([Picture])<=20000000)
	,[Condition] VARCHAR(200)
	,[Available] BIT
);

CREATE TABLE [Employees](
	 [Id] INT PRIMARY KEY IDENTITY
	,[FirstName] VARCHAR(50) NOT NULL
	,[LastName] VARCHAR(50) NOT NULL
	,[Title] VARCHAR(50)
	,[Notes] VARCHAR(255)
);

CREATE TABLE [Customers](
	 [Id] INT PRIMARY KEY IDENTITY
	,[DriverLicenceNumber] INT NOT NULL
	,[FullName] VARCHAR(255) NOT NULL
	,[Address] VARCHAR(255) NOT NULL
	,[City] VARCHAR(50) NOT NULL
	,[ZIPCode] INT NOT NULL
	,[Notes] VARCHAR(255)
);

CREATE TABLE [RentalOrders](
	 [Id] INT PRIMARY KEY IDENTITY
	,[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id])
	,[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id])
	,[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id])
	,[TankLevel] INT 
	,[KilometrageStart] INT NOT NULL
	,[KilometrageEnd] INT NOT NULL
	,[TotalKilometrage] INT NOT NULL
	,[StartDate] DATE NOT NULL
	,[EndDate] DATE NOT NULL
	,[TotalDays] INT NOT NULL
	,[RateApplied] DECIMAL (9,2) NOT NULL
	,[TaxRate] DECIMAL (9,2) NOT NULL
	,[OrderStatus] VARCHAR(50) NOT NULL
	,[Notes] VARCHAR(255)
);

INSERT INTO [Categories]([CategoryName],[DailyRate],[WeeklyRate],[MonthlyRate],[WeekendRate])
	VALUES
		('A',10.00,68.80,277.55,35.00),
		('B',20.00,108.80,477.55,65.00),
		('B1',25.00,138.80,577.55,95.00),
		('C',40.00,322.80,1200.55,120.00),
		('D1',40.00,322.80,1200.55,120.00)

INSERT INTO [Cars]([PlateNumber],[Manufacturer],[Model],[CarYear],[CategoryId],[Doors],[Picture],[Condition],[Available])
	VALUES
		('A 2323 AB','MAN','350',2010,5,3,NULL,'GOOD',1),
		('B 1818 CB','VW','Caddy',2020,3,5,NULL,'GOOD',1),
		('C 1313 KX','KIA','Optima',2018,2,4,NULL,'GOOD',1),
		('CA 2121 KM','DAF','400',2017,4,2,NULL,'GOOD',1),
		('E 3312 MH','BMW','320',2021,2,5,NULL,'GOOD',1) 

INSERT INTO [Employees]([FirstName],[LastName],[Title], [Notes])
	VALUES
		('John1','Doe1','driver','N/A'),
		('John2','Doe2','driver','N/A'),
		('John3','Doe3','driver','N/A'),
		('John4','Doe4','driver','N/A'),
		('John5','Doe5','manager','N/A')

INSERT INTO [Customers]([DriverLicenceNumber],[FullName],[Address],[City],[ZIPCode],[Notes])
	VALUES (28252,'Jane1 Doe1','Sofia','Sofia',1303,NULL),
	       (28253,'Jane2 Doe2','Sofia','Sofia',1303,NULL),
	       (28254,'Jane3 Doe3','Sofia','Sofia',1303,NULL),
	       (28255,'Jane4 Doe4','Sofia','Sofia',1303,NULL),
	       (28256,'Jane5 Doe5','Sofia','Sofia',1303,NULL)

INSERT INTO [RentalOrders](
           [EmployeeId]
		   ,[CustomerId]
		   ,[CarId]
		   ,[TankLevel]
		   ,[KilometrageStart]
		   ,[KilometrageEnd]
		   ,[TotalKilometrage]
		   ,[StartDate]
		   ,[EndDate]
		   ,[TotalDays]
		   ,[RateApplied]
		   ,[TaxRate]
		   ,[OrderStatus]
		   ,[Notes]
)
	VALUES 
		(1,1,1,NULL,100,200,100,'1998-01-01','1998-01-03',3,2.33,253.42,'Received',NULL),
		(2,2,2,NULL,100,200,100,'1998-01-01','1998-01-03',3,2.33,453.42,'In Progress',NULL),
		(3,3,3,NULL,100,200,100,'1998-01-01','1998-01-03',3,2.33,553.42,'Not Started',NULL),
		(4,4,4,NULL,100,200,100,'1998-01-01','1998-01-03',3,2.33,253.42,'Received',NULL),
		(5,5,5,NULL,100,200,100,'1998-01-01','1998-01-03',3,2.33,353.42,'Received',NULL)