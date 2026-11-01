-- Variables, Loops, Conditions
--1
DECLARE @eZugi int =1,@zugi int =2
WHILE @eZugi<100 AND @zugi<101
	BEGIN
		PRINT @eZugi
		PRINT @zugi
		SET @eZugi=@eZugi+2
		SET @zugi=@zugi+2
	END
--2
DECLARE @num int=1,@sum int=0
WHILE @num<=100 
	BEGIN
		
		SET @sum=@sum+@num
		SET @num=@num+1
		
	END
	PRINT @sum
--3
SELECT RentalNum,FromDate,ToDate,IIF(DATEDIFF(MONTH,FromDate,ToDate)>1,'Long period','Short period')
FROM Rentals_tbl
--4
-- Create variables and initialize them
DECLARE @maxId int, @custId int,@count int=0
SET @maxId = (SELECT MAX(CustID) FROM Customer_tbl)
SET @custId = (SELECT MIN(CustID) FROM Customer_tbl)

WHILE @custId<=@maxId
	BEGIN
		SET @count=@count+1
		SET @custId= (SELECT MIN(CustID) FROM Customer_tbl WHERE CustID > @custId)
	END
-- Check customer count and print
IF @count>50
	PRINT 'Many customers'
ELSE
	PRINT 'Few customers'
--5
-- Print car code and monthly price for cars with a monthly price lower than 4000 and price per KM lower than 0.8
DECLARE @car int,@price int,@max int,@priceKM FLOAT

SET @car=(SELECT MIN(CarID) FROM Cars_tbl)
SET @max=(SELECT MAX(CarID) FROM Cars_tbl)


WHILE @car<=@max
	BEGIN
	-- Check for the current car
		SELECT @price=PricePerMonth,@priceKM=PricePerKM
		FROM Cars_tbl
		WHERE @car=CarID
			IF @price<5000 AND @priceKM<1.4
				BEGIN
					PRINT CAST(@car AS VARCHAR(10)) + ' ' + CAST(@price AS VARCHAR(10))
					 
				END
		SET  @car=(SELECT MIN(CarID) FROM Cars_tbl WHERE CarID>@car)
			
	END
--6
--7
-- Create a table variable containing the columns: product id, product name, and price
-- Display the price of all products together 
DECLARE @products table
(
	id int primary key identity(1,1),
	name varchar(10) not null,
	price float
)
INSERT INTO @products(Name,price)
VALUES('Bread',8.9)
INSERT INTO @products(Name,price)
VALUES('Milk',5)
INSERT INTO @products(Name,price)
VALUES('Cucumber',12)
INSERT INTO @products(Name,price)
VALUES('Cornflakes',19.9)

SELECT price
FROM @products
--8
DECLARE @ID int, @maxCust int
SET @ID=(SELECT MIN(CustID) FROM Customer_tbl)
SET @maxCust=(SELECT MAX(CustID) FROM Customer_tbl)

-- Iterate through the customer table
WHILE @ID<=@maxCust
	BEGIN
-- For each customer, check the entire rentals table 
		IF  NOT EXISTS (SELECT * FROM Rentals_tbl WHERE CustID = @ID)
			--DELETE FROM Customer_tbl WHERE @ID=CustID
			PRINT @ID 
		SET @ID=(SELECT MIN(CustID) FROM Customer_tbl WHERE CustID>@ID)
	END
--9
-- Use a WHILE loop 
-- to add 100 NIS to employee salaries
-- Create a new table during the update with the following columns:
-- employee ID, old salary, new salary, and update date.
DECLARE @IDEmp int, @maxEmp int,@salary int
SET @IDEmp=(SELECT MIN(EmpID) FROM Employee_pay_tbl)
SET @maxEmp=(SELECT MAX(EmpID) FROM Employee_pay_tbl)

-- Iterate through the salary table
WHILE @IDEmp<=@maxEmp
	BEGIN
		SELECT @salary=Salary
		FROM Employee_pay_tbl
		WHERE EmpID=@IDEmp
		SET @salary=@salary+100
		--PRINT @salary
		SET @IDEmp=(SELECT MIN(EmpID) FROM Employee_pay_tbl WHERE EmpID>@IDEmp)
	
		-- Create the table
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'newTable')
	BEGIN
		CREATE TABLE newTable (
			EmpID int,
			oldSalary money,
			newSalary money,
			date date
		)
	END
	INSERT INTO newTable
	VALUES(@IDEmp, @salary-100,@salary,GETDATE())
END
SELECT * FROM newTable