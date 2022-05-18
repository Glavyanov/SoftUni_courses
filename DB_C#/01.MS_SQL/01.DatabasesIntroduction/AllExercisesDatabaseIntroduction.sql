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