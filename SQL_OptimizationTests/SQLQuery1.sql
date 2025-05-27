
use QueryOptimization;

--CREATE TABLE Orders (
--    OrderID INT PRIMARY KEY,
--    CustomerID INT,
--    OrderDate DATETIME,
--    TotalAmount DECIMAL(10,2)
--);


--DECLARE @i INT = 1;

--WHILE @i <= 1000000
--BEGIN
--    INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount)
--    VALUES (
--        @i, 
--        ABS(CHECKSUM(NEWID())) % 1000 + 1, 
--        DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, '2022-01-01'), 
--        CAST(RAND() * 500 AS DECIMAL(10,2))
--    );
--    SET @i = @i + 1;
--END;


--select count(*) from Orders


SET STATISTICS IO ON;
SET STATISTICS TIME ON;
SELECT * FROM Orders WHERE CustomerID = 123;
