--SELECT * from Addresses;
--SELECT * from Customers;
--SELECT * from Orders;

UPDATE Customers
SET remarks = 'Hey, Tiger!'
WHERE lastName = 'Moore1';

INSERT INTO Customers (firstName, lastName, addressID, lastOrderDate, remarks)
VALUES ('Hugo', 'Sanchez', 2, '2025-5-5', 'This can''t be correct correct?');

DELETE FROM Customers
WHERE firstName = 'Hugo';

CREATE PROCEDURE 
GetAllCustomerNames
AS 
SELECT * FROM Customers
WHERE addressID = 2;

EXEC GetAllCustomerNames;