SELECT FirstName AS [First Name],
	LastName AS [Last Name],
	t.[Name] AS Town,
	a.AddressText AS [Address]
FROM Employees AS e
LEFT JOIN Addresses AS a ON e.AddressID = a.AddressID
LEFT JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY [First Name], [Last Name]
