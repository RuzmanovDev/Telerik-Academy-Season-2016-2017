/* 4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database)*/
SELECT * 
FROM Departments

/* 5. Write a SQL query to find all department names. */
SELECT Name
FROM Departments

/* 6. Write a SQL query to find the salary of each employee. */
SELECT FirstName, LastName, Salary
FROM Employees

/* 7. Write a SQL to find the full name of each employee. */
SELECT FirstName + ' ' + LastName AS [Full name]
FROM Employees

/* 8. Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".*/
SELECT FirstName + '.' + LastName + '@telerik.com' as [Full email address] 
FROM Employees

/* 9. Write a SQL query to find all different employee salaries. */
SELECT DISTINCT Salary
FROM Employees

/* 10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“. */
SELECT *
FROM Employees
WHERE JobTitle = 'Sales Representative';

/* 11. Write a SQL query to find the names of all employees whose first name starts with "SA". */
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%'

/* 12. Write a SQL query to find the names of all employees whose last name contains "ei". */
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

/* 13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000]. */
SELECT FirstName + ' ' + LastName AS [Employee Name]
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

/* 14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600. */
SELECT FirstName + ' ' + LastName AS [Employee Name]
FROM Employees
WHERE Salary IN ('25000', '14000', '12500', '23600')

/* 15. Write a SQL query to find all employees that do not have manager. */
SELECT FirstName + ' ' + LastName AS [Employee Name]
FROM Employees
WHERE ManagerID IS Null

/* 16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary. */
SELECT FirstName + ' ' + LastName AS [Employee Name], Salary
FROM Employees
WHERE Salary > '50000'
ORDER BY Salary DESC

/* 17. Write a SQL query to find the top 5 best paid employees. */
SELECT TOP 5 *
FROM Employees
ORDER BY Salary DESC

/* 18. Write a SQL query to find all employees along with their address. Use inner join with ON clause. */
SELECT FirstName, LastName, AddressText
FROM Employees AS e
	INNER JOIN Addresses a
	ON e.AddressID = a.AddressID

/* 19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause). */
SELECT FirstName, LastName, AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

/* 20. Write a SQL query to find all employees along with their manager. */
SELECT e1.FirstName AS [Employee name], e2.FirstName AS [Manager Name]
FROM Employees e1, Employees e2
WHERE e1.ManagerID = e2.EmployeeID


/* 21. Write a SQL query to find all employees, 
along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a. */

SELECT e.FirstName AS [Employee], 
m.FirstName AS [Manager],
 a.AddressText AS [Employee Address]
FROM Employees e, Employees m, Addresses a
WHERE e.ManagerID = m.EmployeeID
	 AND e.AddressID = a.AddressID
	
/* 22. Write a SQL query to find all departments and all town names as a single list. Use UNION. */

SELECT Name FROM Departments
UNION
SELECT Name FROM Towns

/* 23. Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join. */

SELECT e.FirstName AS [Employee name] , d.FirstName AS [Manager name]
FROM Employees e
	LEFT OUTER JOIN  Employees d
	ON e.ManagerID = d.EmployeeID



/* 24. Write a SQL query to find the names of all employees from the departments 
"Sales" and "Finance" whose hire year is between 1995 and 2005. */

SELECT e.FirstName + ' ' + e.LastName as [Employee name],
		d.name as [Departement name],
		e.HireDate
FROM Employees e
	JOIN Departments d
	ON d.DepartmentID = e.DepartmentID
WHERE d.Name IN ('Sales', 'Finance') AND 
	e.HireDate BETWEEN '1995' AND '2005'
ORDER BY HireDate


