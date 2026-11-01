-- Procedures
--1
CREATE PROCEDURE printNumLesNum
	AS
		BEGIN
		DECLARE @num1 int=120,@num2 int=30
		PRINT @num1-@num2
		END
EXEC printNumLesNum
--2
CREATE PROCEDURE isZugi @num int
	AS
		BEGIN
		IF @num%2=0
			print 'true'
		ELSE
			print 'false'
		
		END
EXEC isZugi 11
--3
CREATE PROCEDURE getLowSalaryEmp @num int
	AS
		BEGIN
		SELECT EmpID
		FROM Employee_pay_tbl
		WHERE @num>Salary
		END
EXEC getLowSalaryEmp 20000
--4
CREATE PROCEDURE addBonus 
	AS
		BEGIN
		UPDATE Employee_pay_tbl
		SET Bonus=Bonus+250
		WHERE Salary=(
		SELECT MAX(Salary)
		FROM Employee_pay_tbl
		)
		END
EXEC addBonus
--5
-- Write a procedure that receives a number.
-- The procedure will display rental data that occurred during the previous number of days (received) prior to the current date.
-- (For example, if the number 20 is received, rentals from the last 20 days will be displayed)
DROP PROCEDURE getRentalsFromNumDays
CREATE PROCEDURE getRentalsFromNumDays @num int
	AS
		BEGIN
		SELECT *
		FROM Rentals_tbl
		WHERE (GETDATE()-@num)<=FromDate
		END
EXEC getRentalsFromNumDays 5
--6
-- Write a procedure that receives a car code as a parameter and displays a table in the following structure:
-- Model, number of times the car was rented, number of customers who ordered the car, last rental date.
-- If the value -1 is received as a parameter, records for all cars will be returned.
 DROP PROCEDURE getRentalsTable
-- CREATE PROCEDURE getRentalsTable @carid int
	--AS	
	--	BEGIN
		-- Create variables
	--	DECLARE @model varchar(12),@countRentals int,@countCust int,@lastDate date
			-- If a valid code is received, retrieve the appropriate values for the car
			--if(@carid != -1)
			--	BEGIN
			--		SET @model=(SELECT model  FROM Cars_tbl WHERE CarID=@carid)
			--		SET @countRentals=(SELECT COUNT(*) FROM Rentals_tbl WHERE CarID=@carid)
			--		SET @countCust=(SELECT COUNT(DISTINCT CustID) FROM Rentals_tbl WHERE CarID=@carid)
		--			SET @lastDate= (SELECT TOP 1 FromDate FROM Rentals_tbl ORDER BY FromDate DESC)
				-- Insert variables into a new table
		--		SELECT @model as model,@countRentals as countRentals,@countCust as countCust,@lastDate as lastDate
		--		INTO #detailsForCar
		--		END
			-- If -1 parameter is received, update the new table with values for all cars
		--	else
		--		BEGIN
		--			SELECT c.Model AS Model,COUNT(r.RentalNum) AS CountRentals,
		--				COUNT(DISTINCT r.CustID) AS CountCust,MAX(r.FromDate) AS LastDate
		--			INTO #detailsForCar
		--			FROM Cars_tbl c
		--			LEFT JOIN Rentals_tbl r ON c.CarID = r.CarID
		--			GROUP BY c.Model;
		--		END
	--	END

-- Solution without creating a table and variables 
CREATE PROCEDURE getRentalsByCarid
    @carid INT
AS
BEGIN
    SELECT  c.Model AS Model,COUNT(r.RentalNum) AS CountRentals, COUNT(DISTINCT r.CustID) AS CountCust, MAX(r.FromDate) AS LastDate   
    FROM Cars_tbl c LEFT JOIN Rentals_tbl r  
    ON c.CarID = r.CarID
    WHERE @carid = -1 OR c.CarID = @carid
    GROUP BY c.Model;
END

EXEC getRentalsByCarid 100

--7
-- Write a procedure that returns in an OUTPUT variable
-- the number of customers living in a certain city sent as a parameter to the procedure.
-- The main program will check if the amount is greater than 5, an appropriate message will be printed to the message window,
-- otherwise the order details of that customer will be displayed in the result window.
CREATE PROCEDURE getCountCustInCity @city varchar(15), @countCust int output
	AS
		BEGIN
		SELECT @countCust=COUNT(*)
		FROM Customer_tbl
		WHERE CustCity=@city
		END
DECLARE @count int
EXEC getCountCustInCity 'tel-aviv',@count output
	IF @count>5
		PRINT 'City with many customers'
	ELSE
		SELECT r.*
		FROM Rentals_tbl r join Customer_tbl c
		ON r.CustID=c.CustID
		WHERE C.CustCity='Bnei Brak'
--8
-- Write a procedure that returns in OUTPUT variables the highest and lowest salary for a specific employee.
-- The main program will check the difference between the lowest and highest salary and print a message about the difference.
CREATE PROCEDURE getMinMaxSalary @emp int,@minSalary int output,@maxSalary int output
	AS
		BEGIN
			SELECT @minSalary=MIN(Salary),@maxSalary=MAX(Salary)
			FROM Employee_pay_tbl
			WHERE EmpID=@emp
		END
DECLARE @min int,@max int
EXEC getMinMaxSalary 123456789,@min output,@max output
PRINT 'The difference between the high salary and the low salary is: ' +CAST(@max-@min as varchar(10))
--9
-- Create a procedure that receives an employee ID as a parameter and displays the following details: last name, first name, and city
-- if the letter 'i' exists in the employee's last name.
-- If the letter 'i' does not exist, print the following message to the message window:
-- Employee ID: [Employee ID] whose name is [Employee Name] does not contain the letter i.
DROP PROCEDURE getDetailsByEmp
CREATE PROCEDURE getDetailsByEmp @empId int
	as
		BEGIN
		DECLARE @firstN varchar(10),@lastN varchar(10),@city varchar(10)
			
			SELECT @firstN=FirstName,@lastN=LastName,@city=City
			FROM Employee_tbl
			WHERE @empId=EmpID
				IF  @lastN LIKE '%i%'
					SELECT @firstN AS FirstName, @lastN AS LastName, @city AS City;
				ELSE
					PRINT 'Employee ID: '+CAST(@empId as varchar(10))+' whose name is: '+@firstN+' '+@lastN+' '+' does not contain the letter i.'
		END
EXEC getDetailsByEmp 123987456
EXEC getDetailsByEmp 123456789