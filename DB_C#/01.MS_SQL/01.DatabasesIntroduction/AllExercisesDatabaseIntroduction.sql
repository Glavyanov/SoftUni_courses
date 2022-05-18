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
	[Gender] CHAR NOT NULL,
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX)
);

INSERT INTO [People]([Name],[Picture],[Height],[Weight],[Gender],[Birthdate],[Biography]) VALUES
(N'Александър',CAST('0xBDC5C000000000000000000000000000' As varbinary(MAX)),1.8,8.3,'m','02.02.1990',N'Някаква биография'),
(N'Александра',CAST('0xBDC5C000000000000000000000000000' As varbinary(MAX)),1.8,80.3,'f','01.01.1984',N'Някаква биография'),
(N'Борис',CAST('0xBDC5C000000000000000000000000000' As varbinary(MAX)),1.8,80.3,'m','01.01.1983',N'Някаква биография'),
(N'Борислава',CAST('0xBDC5C000000000000000000000000000' As varbinary(MAX)),1.8,80.3,'f','01.01.1982',N'Някаква биография'),
(N'Георги',CAST('0xBDC5C000000000000000000000000000' As varbinary(MAX)),1.8,80.3,'m','01.01.1981',N'Някаква биография')
