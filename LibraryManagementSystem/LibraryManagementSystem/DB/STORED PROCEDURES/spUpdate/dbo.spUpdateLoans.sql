CREATE PROCEDURE spUpdateLoans
@loanId INT,
@copyId INT,
@BID INT,
@LDate DATE,
@RDate DATE
AS
BEGIN
	SET NOCOUNT ON;
	Update dbo.Loan
	SET 
		[CopyID]=@copyId,
		[BID]=@BID,
		[LDate]=@LDate,
		[RDate]=@RDate
	WHERE [LoanID]=@loanId
END