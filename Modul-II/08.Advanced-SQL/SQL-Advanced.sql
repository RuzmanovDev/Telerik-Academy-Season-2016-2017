/* 1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
Use a nested SELECT statement.*/

SELECT FirstName + ' ' + LastName AS [Name]
FROM Employees
WHERE Salary =
	(SELECT MIN(Salary) FROM Employees)

/* 2. Write a SQL query to find the names and salaries of the employees 
that have a salary that is up to 10% higher than the minimal salary for the company. */

SELECT FirstName + ' ' + LastName AS [Name], Salary
FROM Employees
WHERE Salary < (SELECT MIN(Salary) * 1.1 FROM Employees)

/* 3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
Use a nested SELECT statement. */

SELECT FirstName + ' ' + LastName AS [Full name],
	Salary,
	d.Name AS [Departement Name]
FROM Employees e
JOIN Departments d
 on d.DepartmentID = e.DepartmentID
	WHERE Salary = (SELECT MIN(Salary) 
					FROM Employees
					WHERE DepartmentID = e.DepartmentID )
ORDER BY Salary

/* 4. Write a SQL query to find the average salary in the department #1. */

SELECT AVG(e.Salary) AS [Average Salary]
FROM Employees e, Departments d
WHERE d.DepartmentID = '1'

/* 5. Write a SQL query to find the average salary in the "Sales" department. */

SELECT AVG(e.Salary) as [Average Salary]
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

/* 6. Write a SQL query to find the number of employees in the "Sales" department. */

SELECT COUNT(*) AS [Employees in Sales Departement]
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID 
	AND d.Name = 'Sales'

/* 7. Write a SQL query to find the number of all employees that have manager. */

SELECT COUNT(*) AS [Employees with Manager]
FROM Employees e
WHERE e.ManagerID IS NOT NULL

/* 8. Write a SQL query to find the number of all employees that have no manager. */

SELECT COUNT(*) AS [Employees without Manager]
FROM Employees e
WHERE e.ManagerID is NULL

/* 9. Write a SQL query to find all departments and the average salary for each of them. */

SELECT AVG(Salary) AS [AverageSalary], d.Name
FROM Employees e
JOIN Departments d
	on e.DepartmentID = d.DepartmentID
GROUP BY d.Name
ORDER BY [AverageSalary]

/* 10. Write a SQL query to find the count of all employees in each department and for each town. */

SELECT COUNT(e.FirstName), d.Name as [Departement Name], t.Name AS [Town Name]
FROM Employees e
	JOIN Departments d
	ON d.DepartmentID = e.DepartmentID
	JOIN Addresses a 
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON a.AddressID = t.TownID
GROUP BY t.Name, d.Name

/* 11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name. */

SELECT em.FirstName, em.LastName
FROM Employees em, Employees e
WHERE e.ManagerID = em.EmployeeID
GROUP BY em.FirstName, em.LastName
HAVING COUNT(*) = 5

/* 12. Write a SQL query to find all employees along with their managers. 
For employees that do not have manager display the value "(no manager)". */

SELECT e.FirstName, e.LastName, ISNULL(m.FirstName + ' ' + m.LastName, ('(no manager)')) AS [Manager Name]
FROM Employees e
LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

/* 13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.*/

SELECT e.FirstName, e.LastName
FROM Employees e
WHERE LEN(e.LastName) = 5

/* 14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
Search in Google to find how to format dates in SQL Server. */

SELECT CONVERT(varchar(10),GETDATE(),114) AS [Hour:Minutes:Seconds:Milliseconds];

/* 15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
Define the primary key column as identity to facilitate inserting records.
Define unique constraint to avoid repeating usernames.
Define a check constraint to ensure the password is at least 5 characters long. */

CREATE TABLE Users(
	Id int IDENTITY,
	UserName nvarchar(20) NOT NULL UNIQUE,
	Password nvarchar(30) NOT NULL CHECK(LEN(Password)>4),
	FullName nvarchar(40),
	LastLogin date,

	CONSTRAINT Pk_Id PRIMARY KEY(Id),
)

/* 16 Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
Test if the view works correctly. */

CREATE VIEW [Visitors for today] AS 
SELECT UserName
FROM Users
WHERE CONVERT(date, LastLogin) = CONVERT(DATE, GETDATE())

/* 17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
Define primary key and identity column. */

CREATE TABLE Groups(
	GroupId int IDENTITY,
	Name nvarchar(40) NOT NULL UNIQUE,

	CONSTRAINT PK_GroupId PRIMARY KEY(GroupId)
)

/* 18.  Write a SQL statement to add a column GroupID to the table Users.
Fill some data in this new column and as well in the `Groups table.
Write a SQL statement to add a foreign key constraint between tables Users and Groups tables. */

ALTER TABLE Users
ADD GroupId int

ALTER TABLE Users
ADD CONSTRAINT GroupId
FOREIGN KEY (GroupId)
REFERENCES Groups(GroupId)

/* 19. Write SQL statements to insert several records in the Users and Groups tables. */

INSERT INTO Groups
VALUES ('JS APPS')

INSERT INTO Groups
VALUES ('C Sharp')

INSERT INTO Users
VALUES ('Goshko', '123333', 'Petar Ivanov', '2016-08-10', 1)

/* 20. Write SQL statements to update some of the records in the Users and Groups tables. */

UPDATE Users
SET UserName = 'Petkan'
WHERE UserName = 'Pesho'

UPDATE Groups
SET Name = 'DB'
WHERE Name = 'JS APPS'

/* 21. Write SQL statements to delete some of the records from the Users and Groups tables. */

DELETE FROM Users
WHERE Id = 1

DELETE FROM Groups
WHERE GroupID = 1

/* 22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.
Combine the first and last names as a full name.
For username use the first letter of the first name + the last name (in lowercase).
Use the same for the password, and NULL for last login time. */

INSERT INTO Users(UserName,Password,LastLogin)
SELECT DISTINCT
	LEFT(LOWER(FirstName),1) + '.' + LOWER(LastName),
	LEFT(LOWER(FirstName),1) + LOWER(LastName),
	NULL
FROM Employees


/* 23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010. */

UPDATE Users
SET PASSWORD = NULL
WHERE LastLogin < '2010-03-10'

/* 24. Write a SQL statement that deletes all users without passwords (NULL password). */

DELETE FROM Users
WHERE Password = NULL

/* 25.Write a SQL query to display the average employee salary by department and job title. */

SELECT d.name AS [Departement Name] , e.JobTitle, AVG(e.Salary) AS [Average salary]
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

/* 26. Write a SQL query to display the minimal employee salary
 by department and job title along with the name of some of the employees that take it. */

 SELECT e.FirstName, MIN(e.Salary) AS [Min salary], d.Name AS [Departement name], e.JobTitle as [Job title]
 FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name,e.JobTitle, e.FirstName

/* 27. Write a SQL query to display the town where maximal number of employees work. */

SELECT t.Name AS [Town Name], COUNT(e.FirstName) AS [Emlopees Count]
FROM Employees e
	JOIN Addresses a 
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY  COUNT(e.FirstName) DESC

/* 28. Write a SQL query to display the number of managers from each town. */

SELECT COUNT(DISTINCT e.ManagerID) AS [Managers count], t.Name AS [Town name]
FROM Employees e
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON t.TownID = a.TownID
WHERE e.ManagerID IS NOT NULL
GROUP BY  t.Name
ORDER BY [Managers count] DESC

/* 29.Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
Don't forget to define identity, primary key and appropriate foreign key.
Issue few SQL statements to insert, update and delete of some data in the table.
Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
For each change keep the old record data, the new record data and the command (insert / update / delete). */

CREATE TABLE WorkHours(
	EmloyeeId int IDENTITY,
	[Date] date ,
	Task nvarchar(30),
	[Hours] date,
	Comments nvarchar(60),

	CONSTRAINT PK_EmployeeId PRIMARY KEY(EmloyeeId) 
)

CREATE TABLE WorkHoursLog(
 Id int IDENTITY,
	[Date] date ,
	Task nvarchar(30),
	[Hours] date,
	Comments nvarchar(60),
	Command nvarchar(10),

 CONSTRAINT PK_WorkingHoursLogID PRIMARY KEY(Id)
)

GO 
CREATE TRIGGER dbo.OnChange
ON dbo.WorkHours
after UPDATE, INSERT, DELETE
AS
BEGIN
	DECLARE @command nvarchar(10);

	IF EXISTS(SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
	BEGIN
		SET @command = 'UPDATE'; 
		INSERT INTO WorkHoursLog SELECT [Date], [Task], [Hours], [Comments],@command
		FROM inserted
	END

	IF EXISTS (Select * FROM inserted) AND NOT EXISTS(Select * FROM deleted)
	BEGIN
		SET @command = 'INSERT';
	 INSERT INTO WorkHoursLog SELECT [Date], [Task], [Hours], [Comments],@command
		FROM inserted
	END

	IF EXISTS(SELECT * FROM deleted) AND NOT EXISTS(SELECT * FROM inserted)
	BEGIN 
		INSERT INTO WorkHoursLog SELECT [Date], [Task], [Hours], [Comments],@command
		FROM deleted
	END
END

/* 30. Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables.
At the end rollback the transaction. */

BEGIN TRAN
	ALTER TABLE Departments
	DROP CONSTRAINT FK_Departments_Employees

	ALTER TABLE EmployeesProjects
	DROP CONSTRAINT FK_EmployeesProjects_Employees

	DELETE FROM Employees
	SELECT d.Name
	FROM Employees e
		JOIN Departments d
			ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	GROUP BY d.Name
ROLLBACK TRAN

/* 31. Start a database transaction and drop the table EmployeesProjects.
Now how you could restore back the lost table data? */
BEGIN TRAN
	DROP TABLE EmployeesProjects
ROlLBACK TRAN

/* 32. Find how to use temporary tables in SQL Server.
Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table. */

BEGIN TRAN
SELECT *  INTO  #TempEmployeesProjects
FROM EmployeesProjects

DROP TABLE EmployeesProjects

SELECT * INTO EmployeesPRojects
FROM #TempEmployeesProjects

ROLLBACK TRAN