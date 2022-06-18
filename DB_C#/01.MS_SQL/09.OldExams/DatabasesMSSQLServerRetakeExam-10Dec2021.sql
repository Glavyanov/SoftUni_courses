CREATE DATABASE Airport

GO

USE Airport

--1.
CREATE TABLE Passengers (
	Id INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) UNIQUE NOT NULL,
	LastName VARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT NOT NULL,
	CHECK(Age BETWEEN 21 AND 62),
	Rating FLOAT,
	CHECK(Rating BETWEEN 0.0 AND 10.0)
)

CREATE tABLE AircraftTypes (
	Id INT PRIMARY KEY IDENTITY,
	TypeName VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft(
	Id INT PRIMARY KEY IDENTITY,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR NOT NULL,
	TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL
)


CREATE TABLE PilotsAircraft (
    AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
    PilotId INT FOREIGN KEY REFERENCES Pilots(Id) NOT NULL,
	PRIMARY KEY(AircraftId, PilotId)
)

CREATE TABLE Airports (
	Id INT PRIMARY KEY IDENTITY,
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE FlightDestinations (
	Id INT PRIMARY KEY IDENTITY,
	AirportId INT FOREIGN KEY REFERENCES Airports(Id) NOT NULL,
	[Start] DATETIME NOT NULL,
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	TicketPrice DECIMAL(18,2) NOT NULL DEFAULT(15)
)

--2 Insert
INSERT INTO Passengers(FullName, Email)
SELECT CONCAT(FirstName,' ',LastName)
	 , CONCAT(FirstName,LastName,'@gmail.com')
FROM Pilots
WHERE Id BETWEEN 5 AND 15

--3 Update
UPDATE Aircraft
SET Condition = 'A'
WHERE Condition IN('C','B')	AND (FlightHours IS NULL OR FlightHours <= 100) AND [Year] >= 2013

--4 DELETE
SELECT FullName
FROM Passengers
WHERE LEN(FullName) < 11 
SELECT * FROM Passengers

DELETE FROM Passengers
WHERE LEN(FullName) < 11 

/*Section 3. Querying (40 pts)
You need to start with a fresh dataset, so recreate your DB and import the sample data again (01. DDL_Dataset.sql).
*/
--5	Aircraft
  SELECT Manufacturer
       , Model
       , FlightHours
       , Condition
    FROM Aircraft
ORDER BY FlightHours DESC

--6.	Pilots and Aircraft
  SELECT p.FirstName
	   , p.LastName
	   , a.Manufacturer
	   , a.Model
	   , a.FlightHours
    FROM Pilots AS p
    JOIN PilotsAircraft AS pa ON pa.PilotId = p.Id
    JOIN Aircraft AS a on a.Id = pa.AircraftId
   WHERE a.FlightHours IS NOT NULL AND a.FlightHours <= 304
ORDER BY a.FlightHours DESC, p.FirstName

--7
SELECT TOP 20 fd.Id AS DestinationId
            , fd.[Start]
			, p.FullName
			, a.AirportName
			, fd.TicketPrice
         FROM FlightDestinations AS fd
         JOIN Passengers AS p ON p.Id = fd.PassengerId
         JOIN Airports  AS a ON a.Id = fd.AirportId
        WHERE DAY([Start]) % 2 = 0
     ORDER BY fd.TicketPrice DESC, a.AirportName

--8
   SELECT fd.AircraftId
        , a.Manufacturer
        , a.FlightHours
        , COUNT(fd.AircraftId) AS FlightDestinationsCount
        , ROUND (AVG(fd.TicketPrice), 2) AS AvgPrice
     FROM Aircraft AS a
     JOIN FlightDestinations AS fd ON a.Id = fd.AircraftId
GROUP BY  a.Manufacturer, a.FlightHours , fd.AircraftId
   HAVING COUNT(fd.AircraftId) >= 2
 ORDER BY FlightDestinationsCount DESC, fd.AircraftId

--9
  SELECT p.FullName
       , COUNT(fd.AircraftId) AS CountOfAircraft
       , SUM(fd.TicketPrice) AS TotalPayed
    FROM Passengers AS p
    JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
   WHERE p.FullName LIKE '_[a]%' 
GROUP BY p.FullName
  HAVING COUNT(fd.AircraftId) > 1
ORDER BY p.FullName

--10
  SELECT a.AirportName
       , fd.[Start] AS DayTime
       , fd.TicketPrice
       , p.FullName
       , acr.Manufacturer
       , acr.Model
    FROM Airports AS a
    JOIN FlightDestinations AS fd ON a.Id = fd.AirportId
    JOIN Passengers AS p ON p.Id = fd.PassengerId
    JOIN Aircraft AS acr ON fd.AircraftId = acr.Id
   WHERE (CONVERT(VARCHAR(5),[Start],108) BETWEEN '06:00' AND '20:00') AND fd.TicketPrice > 2500
ORDER BY acr.Model

GO
--11
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50)) 
RETURNS INT 
AS
BEGIN
 RETURN ( 
			SELECT COUNT(*)	
			FROM FlightDestinations
			WHERE PassengerId IN(SELECT TOP 1 Id
				                       FROM Passengers
				                      WHERE Email = @email
                                )
        )
END

GO

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')

GO
--12
CREATE PROC usp_SearchByAirportName @airportName VARCHAR(70)
AS
BEGIN
  SELECT a.AirportName
      , p.FullName
	  , CASE 
			WHEN fd.TicketPrice < 401 THEN 'Low'
			WHEN fd.TicketPrice < 1501 THEN 'Medium'
			ELSE 'High'
		END AS LevelOfTickerPrice
	  , acr.Manufacturer
	  , acr.Condition
	  , acrt.TypeName
  FROM Passengers AS p
  JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
  JOIN Aircraft AS acr ON fd.AircraftId = acr.Id
  JOIN AircraftTypes AS acrt ON acr.TypeId = acrt.Id
  JOIN Airports AS a ON a.Id = fd.AirportId
  WHERE a.AirportName = @airportName
  ORDER BY acr.Manufacturer,p.FullName
END

GO

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'