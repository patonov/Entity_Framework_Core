SELECT e.FirstName
,e.LastName
,e.HireDate
,d.Name AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE
	e.HireDate > '1999-01-01'
	AND d.Name IN ('Finance', 'Sales')
ORDER BY e.HireDate


SELECT TOP 100 
e.EmployeeID
,CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeNames
,CONCAT(m.FirstName, ' ', m.LastName) AS ManagerNames
,d.Name AS DepartmentName
FROM Employees AS e
LEFT JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

SELECT TOP 1
dt.AverageSalary AS MinAverageSalary
FROM 
(SELECT AVG(Salary) AS AverageSalary FROM Employees GROUP BY DepartmentID) AS dt
ORDER BY MinAverageSalary


