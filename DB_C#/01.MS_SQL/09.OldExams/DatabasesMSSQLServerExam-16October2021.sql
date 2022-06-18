                            /***********************************************
                             ** Database Basics MS SQL Exam – 16 Oct 2021 **
                            ************************************************/
--Section 1. DDL (30 pts)
CREATE DATABASE CigarShop

GO

USE CigarShop

GO

CREATE TABLE Sizes (
	Id INT PRIMARY KEY IDENTITY,
	[Length] INT NOT NULL,
	CHECK([Length] BETWEEN 10 AND 25),
	RingRange DECIMAL(3,2) NOT NULL,
	CHECK(RingRange BETWEEN 1.5 AND 7.5)

)

CREATE TABLE Tastes(
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands(
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) NOT NULL UNIQUE,
	BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars(
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
	TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
	SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
	PriceForSingleCigar DECIMAL(20,2) NOT NULL,
    ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(30) NOT NULL,
	ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE ClientsCigars(
	ClientId INT FOREIGN KEY REFERENCES Clients(Id),
	CigarId INT FOREIGN KEY REFERENCES Cigars(Id),
	PRIMARY KEY (ClientId, CigarId)
)

GO

--2.	Insert
INSERT INTO Cigars(CigarName,BrandId,TastId,SizeId,PriceForSingleCigar,ImageURL)
	VALUES
	('COHIBA ROBUSTO',9,1,5,15.50,'cohiba-robusto-stick_18.jpg'),
	('COHIBA SIGLO I',9,1,10,410.00,'cohiba-siglo-i-stick_12.jpg'),
	('HOYO DE MONTERREY LE HOYO DU MAIRE',14,5,11,7.50,'hoyo-du-maire-stick_17.jpg'),
	('HOYO DE MONTERREY LE HOYO DE SAN JUAN',14,4,15,32.00,'hoyo-de-san-juan-stick_20.jpg'),
	('TRINIDAD COLONIALES',2,3,8,85.21,'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town,Country,Streat,ZIP)
	VALUES
	('Sofia','Bulgaria','18 Bul. Vasil levski','1000'),
	('Athens','Greece','4342 McDonald Avenue','10435'),
	('Zagreb','Croatia','4333 Lauren Drive','10000')


--3.	Update
UPDATE Cigars
SET PriceForSingleCigar *= 1.2
WHERE TastId = 1

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--4.	Delete
ALTER TABLE Clients
ALTER COLUMN AddressId INT

UPDATE Clients
 SET AddressId = NULL
 WHERE AddressId IN(
                    SELECT Id
                      FROM Addresses
                     WHERE Country LIKE 'C%'
                    )

DELETE FROM Addresses
WHERE Country LIKE 'C%'

--ALTER TABLE Clients
--ADD CONSTRAINT FK_Clients_Addresses FOREIGN KEY (AddressId) REFERENCES Addresses(Id) 

--ALTER TABLE Clients
--DROP CONSTRAINT FK_Clients_Addresses

/* Section 3. Querying (40 pts)
[v]  You need to start with a fresh dataset, so recreate your DB and import the sample data again (01-DDL-Data-Seeder.sql).*/

--5.	Cigars by Price
  SELECT CigarName
       , PriceForSingleCigar
       , ImageURL
    FROM Cigars
ORDER BY PriceForSingleCigar, CigarName DESC

--6.	Cigars by Taste
  SELECT c.Id
       , c.CigarName
       , c.PriceForSingleCigar
       , t.TasteType
       , t.TasteStrength
    FROM Cigars AS c
    JOIN Tastes AS t ON c.TastId = t.Id
WHERE t.TasteType IN ('Woody','Earthy')
ORDER BY PriceForSingleCigar DESC

--7.	Clients without Cigars
SELECT c.Id
, CONCAT(FirstName,' ',LastName) AS ClientName
, c.Email
FROM Clients AS c
LEFT JOIN [ClientsCigars] AS cc ON c.Id = cc.ClientId
WHERE cc.ClientId IS NULL
ORDER BY ClientName

--8.	First 5 Cigars
 SELECT TOP 5 
        c.CigarName
       , c.PriceForSingleCigar
       , c.ImageURL
    FROM Cigars AS c
    JOIN Sizes AS s ON c.SizeId = s.Id
   WHERE (s.[Length] >= 12 AND c.CigarName LIKE '%ci%') OR (s.[Length] >= 12 AND c.PriceForSingleCigar > 50 AND s.RingRange > 2.55)
ORDER BY c.CigarName, c.PriceForSingleCigar DESC

--9.	Clients with ZIP Codes
 SELECT FullName
      , Country
      , ZIP
      , CONCAT ('$',MAX(PriceForSingleCigar))AS CigarPrice
   FROM (
			SELECT 
			CONCAT(FirstName, ' ', LastName ) AS FullName 
			,a.Country
			,a.ZIP
			,cg.PriceForSingleCigar
			FROM Clients AS c
			JOIN Addresses AS a ON a.Id = c.AddressId
			JOIN ClientsCigars AS clcg ON clcg.ClientId = c.Id
			JOIN Cigars AS cg ON cg.Id = clcg.CigarId
			WHERE ZIP NOT LIKE '%[^0-9]%'
		 ) AS InnerQuery
GROUP BY FullName, Country, ZIP
ORDER BY FullName 

--10.	Cigars by Size
SELECT LastName
    , AVG(CiagrLength) AS CiagrLength
    , CEILING(AVG(CiagrRingRange)) AS CiagrRingRange
  FROM (
		SELECT c.LastName,s.[Length] AS CiagrLength ,s.RingRange AS CiagrRingRange,CONCAT (c.FirstName,c.LastName) AS FullName
		FROM Clients AS c
		JOIN ClientsCigars AS clcg ON c.Id = clcg.ClientId
		JOIN Cigars AS cg ON cg.Id = clcg.CigarId
		JOIN Sizes AS s ON s.Id = cg.SizeId
		) AS InnerQuery
	GROUP BY LastName
	ORDER BY CiagrLength DESC

GO
--11.  Client with Cigars
CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30)) 
RETURNS INT
AS
BEGIN
 RETURN (
			SELECT COUNT(*)
			FROM ClientsCigars
			WHERE ClientId IN (SELECT TOP  1 Id 
									 FROM Clients 
									WHERE FirstName = @name
							   )
        )
END

GO

SELECT dbo.udf_ClientWithCigars('Betty')
SELECT dbo.udf_ClientWithCigars('Rachel')
SELECT dbo.udf_ClientWithCigars('Joan')
SELECT dbo.udf_ClientWithCigars('Jean')
SELECT dbo.udf_ClientWithCigars('Irene')
SELECT dbo.udf_ClientWithCigars('Robin')

GO
--12	Search for Cigar with Specific Taste

CREATE PROC usp_SearchByTaste @taste VARCHAR(20)
AS
BEGIN
  SELECT c.CigarName
       , CONCAT( '$', c.PriceForSingleCigar )AS Price
       , t.TasteType
       , b.BrandName
       , CONCAT (s.[Length],' ', 'cm' )AS CigarLength
       , CONCAT (s.RingRange,' ', 'cm' )AS CigarRingRange
    FROM Cigars AS c
    JOIN Tastes AS t ON c.TastId = t.Id
    JOIN Brands AS b ON c.BrandId = b.Id
    JOIN Sizes AS s ON s.Id = c.SizeId
   WHERE t.TasteType = @taste
ORDER BY CigarLength,CigarRingRange DESC
END

GO

EXEC usp_SearchByTaste 'Woody'
