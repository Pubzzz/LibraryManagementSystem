﻿CREATE PROCEDURE [dbo].[spDeleteLoans]
@loanId NCHAR
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.Loan
	WHERE LoanID = @loanId;
END