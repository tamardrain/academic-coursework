-- Functions
--1
-- Create functions that receive a car ID and return:
-- The average KM for this car.
-- How many times it was rented.
DROP FUNCTION getAvgKm

CREATE FUNCTION getAvgKm(@carId smallint)
RETURNS float
	AS
		BEGIN
			DECLARE @avg float
			SELECT @avg=AVG(KM)
			FROM Rentals_tbl
			WHERE CarID=@carId
			RETURN @avg
		END
PRINT dbo.getAvgKm(100)

CREATE FUNCTION getCountRentals(@car smallint)
RETURNS smallint
AS
	BEGIN
	DECLARE @count smallint
	SELECT @count=COUNT(*)
	FROM Rentals_tbl
	WHERE CarID=@car
	RETURN @count
	
	END
	PRINT dbo.getCountRentals(100)

--2
SELECT CarID,dbo.getCountRentals(CarID) AS numOfRentals
FROM Cars_tbl
WHERE dbo.getAvgKm(CarID)<3000
--3
-- Create a function that receives a customer ID and returns the number of rentals they performed.
CREATE FUNCTION getCountRentalsOtCust(@cust smallint)
RETURNS smallint
	AS
		BEGIN
		DECLARE @counter smallint
		SELECT @counter=COUNT(*)
		FROM Rentals_tbl
		WHERE CustID=@cust
		RETURN @counter
		END
PRINT dbo.getCountRentalsOtCust(6)
--4
SELECT CustName,dbo.getCountRentalsOtCust(CustID) AS numOfRentals
FROM Customer_tbl
--5
DROP FUNCTION printDate
CREATE FUNCTION printDate(@date DATE)
RETURNS varchar(15)
	AS
		BEGIN
		DECLARE @str varchar(15)
		SET @str=  CAST(YEAR(@date) AS varchar(10))+'//'+CAST(MONTH(@date) AS varchar(10))+'//'+CAST(DAY(@date) AS varchar(10))
		RETURN @str
		END

--6
PRINT dbo.printDate(GETDATE())--2025//11//5
--7
DROP FUNCTION getCustDetails
CREATE FUNCTION getCustDetails(@cust smallint)
RETURNS TABLE
	AS
		RETURN
		(
		SELECT C.CustName,dbo.printDate(CAST(r.FromDate AS DATE)) AS rentalDate,r.RentalNum
		FROM Customer_tbl c join Rentals_tbl r
		ON C.CustID=r.CustID
		WHERE @cust=C.CustID AND @cust=R.CustID
		)
SELECT * FROM dbo.getCustDetails(4)
--8
DROP FUNCTION printUserName
CREATE FUNCTION printUserName(@first varchar(15),@last varchar(15))
RETURNS varchar(15)	
	AS
		BEGIN
		DECLARE @userName varchar(15)
		SET @userName=SUBSTRING(@first,1,1)+@last
		RETURN @userName
		END

SELECT dbo.printUserName(LastName,FirstName) as userName
FROM Employee_tbl
WHERE EmpID=036974101
--CChaim
--9
CREATE FUNCTION getPosition(@position smallint)
RETURNS varchar(10)
		AS
			BEGIN
			DECLARE @string varchar(10)
			SET @string = IIF(@position < 5, 'LOW', 'HIGH')
			RETURN @string ;
			END
SELECT dbo.getPosition(Position) as pos
FROM Employee_pay_tbl
--10. Write a function that receives a discount percentage and returns the car ID, price before discount, and price after discount.

CREATE FUNCTION getSaleTable(@sale float)
RETURNS @getSaleTable TABLE( CarID smallint, PricePerMonth smallint, salePrice smallint)
	AS
		BEGIN
		INSERT INTO @getSaleTable
		SELECT CarID,PricePerMonth,PricePerMonth -(PricePerMonth*@sale) AS salePrice
		FROM Cars_tbl
		RETURN
		END

--11. Use the above function and display the list of cars whose price will increase by more than 200 NIS.
SELECT *  
FROM getSaleTable(0.1)
WHERE (PricePerMonth -salePrice)>200

select*
from Cars_tbl