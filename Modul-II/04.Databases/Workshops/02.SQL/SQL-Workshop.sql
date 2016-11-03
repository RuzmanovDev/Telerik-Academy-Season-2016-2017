/* 1. Create table Cities with (CityId, Name) */

CREATE TABLE Cities(
	CityId int IDENTITY,
	Name nvarchar(15),

	CONSTRAINT PK_CityId PRIMARY KEY(CityId)
)

/* 2. Insert into Cities all the Cities from Employees, Suppliers, Customers tables (RESULT: 95 row(s) affected) */

INSERT INTO Cities(name)
SELECT DISTINCT City FROM Employees WHERE City is not NULL UNION
SELECT DISTINCT City FROM Suppliers WHERE City is not NULL UNION
SELECT DISTINCT City FROM Customers WHERE City is not NULL

/* 3. Add CityId into Employees, Suppliers, Customers tables which is Foreign Key to CityId in Cities */

ALTER TABLE Employees
ADD CityId int,
FOREIGN KEY(CityId) REFERENCES Cities(CityId)

ALTER TABLE Suppliers
ADD CityId int,
FOREIGN KEY(CityId) REFERENCES Cities(CityId)

ALTER TABLE Customers
ADD CityId int,
FOREIGN KEY(CityId) REFERENCES Cities(CityId)

/* 4. Update Employees, Suppliers, Customers tables with CityId which is in the Cities table

Employees (RESULT: 9 row(s) affected)

Suppliers (RESULT: 29 row(s) affected)

Customers (RESULT: 91 row(s) affected) */


UPDATE Employees
SET CityId = c.CityId
FROM Cities c, Employees e
	WHERE c.Name = e.City


UPDATE Suppliers
SET CityId = c.CityId
FROM Cities c, Suppliers s
	WHERE c.Name = s.City

UPDATE Customers
SET CityId = c.CityId
FROM Cities c, Customers cust
	WHERE c.Name = cust.City

/* 5. Make the column Name in Cities Unique */

ALTER TABLE Cities
ADD CONSTRAINT uc_Name UNIQUE (Name)

/* 6. Now after looking at the database again we found there are 
Cities (ShipCity) in the Orders table as well :D 
(always read before start coding). Insert those cities please. (RESULT: 1 row(s) affected) */

INSERT INTO Cities(name)
SELECT ShipCity FROM Orders EXCEPT
	SELECT Name From Cities

/* 7. Add CityId column in Orders with Foreign Key to CityId in Cities */

ALTER TABLE Orders
ADD CityId int FOREIGN KEY REFERENCES Cities(CityId) 

/* 8. Now rename that column to be ShipCityId to be consistent (use stored procedure :) ) */

EXEC sp_rename 'Orders.CityId' , 'ShipCityId', 'COLUMN'

/* 9. Update ShipCityId in Orders table with values from Cities table (RESULT: 830 row(s) affected) */

UPDATE Orders
SET ShipCityId = c.CityId
FROM Cities c, Orders o
	WHERE c.Name = o.ShipCity

/* 10. Drop column ShipCity from Orders */

ALTER TABLE Orders
DROP COLUMN ShipCity

/* 11. Create table Countries with columns CountryId and Name (Unique) */

CREATE TABLE Countries(
	CountryId int IDENTITY PRIMARY KEY(CountryId),
	Name nvarchar(15) UNIQUE
)

/* 12. Add CountryId to Cities with Foreign Key to CountryId in Countries */

ALTER TABLE Cities
ADD CountryId int 
	FOREIGN KEY(CountryId)
	REFERENCES Countries(CountryId)

/* 13. Insert all the Countries from Employees, Customers, Suppliers and Orders (RESULT: 25 row(s) affected) */

INSERT INTO Countries(name)
SELECT DISTINCT Country FROM Employees WHERE Country is not NULL UNION
SELECT DISTINCT Country FROM Suppliers WHERE Country is not NULL UNION
SELECT DISTINCT Country FROM Customers WHERE Country is not NULL UNION
SELECT DISTINCT ShipCountry FROM Orders WHERE ShipCountry is not NULL

/* 14. Update CountryId in Cities table with values from Countries table */

SELECT *
FROM Employees e
	JOIN Orders o 
	ON e.