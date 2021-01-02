CREATE PROCEDURE spSearchLoans 
@loanId INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Loan]
	WHERE LoanID = @loanId;
END