-- When an employee is added to the payment table, display the total sum of all salaries
DROP TRIGGER add_employee
CREATE TRIGGER add_employee
ON Employee_pay_tbl
AFTER INSERT
	AS 
		BEGIN
		DECLARE @sum int
		SELECT @sum=SUM(salary) FROM Employee_pay_tbl WHERE Salary IS NOT NULL
			PRINT 'sum salaries: '+ CAST(@sum as varchar(10))
		END

INSERT INTO Employee_pay_tbl(EmpID,Position)
VALUES(123987456,6)--sum salaries: 55500
--1
CREATE TRIGGER timeUpDateEpmPay
ON Employee_pay_tbl
AFTER UPDATE
	AS
		BEGIN
			PRINT CONVERT(time(0), GETDATE())
		END

UPDATE Employee_pay_tbl
SET Bonus=Bonus+100
WHERE Salary<10000
--10:32:48
--(1 row affected)
--2
-- Write a trigger that activates upon updating the salary field
-- in the employee_pay_tbl table:
-- The trigger will check if the change was made to the salary field,
-- if so, it will perform a rollback
-- and print an appropriate message.
DROP TRIGGER trg_UpdateSalary
CREATE TRIGGER trg_UpdateSalary
ON employee_pay_tbl
AFTER UPDATE
AS
BEGIN
    -- Check if the Salary field was changed
	IF UPDATE(Salary)
    BEGIN
        -- If Salary was changed, rollback and print message
        RAISERROR('Updating the Salary field is not allowed!', 16, 1);
        ROLLBACK TRANSACTION;  -- Cancels the update
    END
    ELSE
    BEGIN
        PRINT 'The update was executed but there was no change in the Salary field';
    END
END;
	UPDATE Employee_pay_tbl
	SET Salary=15000
	WHERE Bonus<1000
--Output	
--Msg 50000, Level 16, State 1, Procedure trg_UpdateSalary, Line 15 [Batch Start Line 61]
--Updating the Salary field is not allowed!
--Msg 3609, Level 16, State 1, Line 62
--The transaction ended in the trigger. The batch has been aborted

--3
drop TRIGGER insertNewRental
CREATE TRIGGER insertNewRental
ON Rentals_tbl
AFTER INSERT
	AS
		BEGIN
		DECLARE @CAR INT,@price int
		SELECT @CAR= CarID
		FROM inserted
		
		select @price= PricePerMonth
		from Cars_tbl
		where @CAR= CarID
		if(@price<4500)
			begin
			RAISERROR('It is not possible to execute this rental', 16, 1);
            ROLLBACK TRANSACTION; 
			end
		END
INSERT INTO Rentals_tbl
VALUES(4, 104, GETDATE(), DATEADD(D, 2, GETDATE()), 500)
--Output
--Msg 50000, Level 16, State 1, Procedure insertNewRental, Line 15 [Batch Start Line 81]
--It is not possible to execute this rental
--Msg 3609, Level 16, State 1, Line 82
--The transaction ended in the trigger. The batch has been aborted.

--4

CREATE TRIGGER updatePriceCar
ON Cars_tbl
AFTER UPDATE
	AS
		BEGIN
			IF UPDATE (PricePerMonth)
			BEGIN
			DECLARE @oldPrice int, @newPrice int
			SELECT @oldPrice=PricePerMonth FROM deleted
			SELECT @newPrice=PricePerMonth FROM inserted
			IF(@oldPrice>@newPrice)
			BEGIN
				RAISERROR('The car price is lower than its previous price, the update cannot be performed', 16, 1);
                ROLLBACK TRANSACTION;
			END
			ELSE
				PRINT 'Car price updated successfully'
			END
		END

UPDATE Cars_tbl
SET PricePerMonth=4100
WHERE CarID=100
--5
DROP TRIGGER updatePriceCar
--6
CREATE TRIGGER addBonusToEmp
ON Customer_tbl
AFTER INSERT
	AS
		BEGIN
		DECLARE @ENP INT
		SELECT @ENP=EmpID
		FROM Customer_tbl
		WHERE CustID=(SELECT CustID FROM inserted)
		UPDATE Employee_pay_tbl
		SET Bonus=Bonus*1.5
		WHERE @ENP=EmpID
		END
INSERT INTO Customer_tbl
VALUES('CHAIM','LEVI','bnei brak',03-6214587,03-6142587,987654321)
	SELECT *
	FROM Customer_tbl
--7
CREATE TRIGGER printCountDeleted
ON Rentals_tbl
AFTER DELETE
	AS
		BEGIN
		DECLARE @COUNT INT
		SELECT @COUNT=COUNT(*)
		FROM deleted
		PRINT CAST(@COUNT as varchar(10))+' ' +'rentals deleted'
		END
		DELETE FROM Rentals_tbl
		WHERE RentalNum=4
--Output
--1 rentals deleted
--(1 row affected) 

--8
DROP TRIGGER printCountDeleted2
CREATE TRIGGER printCountDeleted2
ON Rentals_tbl
AFTER DELETE
	AS
		BEGIN
		
		DECLARE @COUNT INT
		SELECT @COUNT=COUNT(*)
		FROM deleted
		IF(@COUNT>=3)
			BEGIN
			IF EXISTS(
			SELECT 1
			FROM deleted
			WHERE ToDate>=GETDATE()
			)
			BEGIN
				RAISERROR('Cannot perform the deletion of these rentals', 16, 1);
                ROLLBACK TRANSACTION;
			END
			END
		ELSE
		  PRINT CAST(@COUNT as varchar(10))+' ' +'rentals deleted'
		END
--9
CREATE TRIGGER deleteAllOfEmp
ON Employee_pay_tbl
AFTER DELETE
	AS
		BEGIN
		DELETE FROM Employee_pay_tbl
		WHERE EmpID IN(SELECT EmpID FROM deleted) AND HireDate NOT IN(SELECT HireDate FROM deleted)
		END
--10
CREATE TRIGGER checkCust
ON Rentals_tbl
INSTEAD OF DELETE
	AS
		BEGIN
			DECLARE @CUST INT
			SELECT @CUST=CustID
			FROM deleted
			IF EXISTS(
			SELECT 1
			FROM Rentals_tbl
			WHERE @CUST=CustID
			)
			BEGIN
			DELETE FROM Rentals_tbl
			WHERE CustID=@CUST
			END

		END