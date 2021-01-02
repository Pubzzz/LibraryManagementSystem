CREATE PROCEDURE spInsertPayments
@loanId INT,
@borrowerID INT,
@payment INT,
@date DATE

AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.Payment([LoanID],[BorrowerID],[Payment],[Date])
	VALUES (@LoanId,@BorrowerID,@payment,@date)
END