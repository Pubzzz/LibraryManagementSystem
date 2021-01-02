CREATE PROCEDURE [dbo].[spDeleteBorrowers]
@borrowerId INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.Borrower
	WHERE BID = @borrowerId;
END