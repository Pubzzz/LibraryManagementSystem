CREATE PROCEDURE spInsertLoans 
@loanId INT,
@copyId INT,
@BID INT,
@LDate DATE,
@RDate DATE
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.Loan([LoanID],[CopyID],[BID],[LDate],[RDate])
	VALUES(@loanId,@copyId,@BID,@LDate,@RDate)
END