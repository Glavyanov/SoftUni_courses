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
	,[CategotyId] INT FOREIGN KEY REFERENCES [Categories]([Id])
	,[Doors] SMALLINT
	,[Picture] VARBINARY(MAX)
	,CHECK (DATALENGTH([Picture])<=20000000)
	,[Condition] VARCHAR(200)
	,[Available] BIT
);
