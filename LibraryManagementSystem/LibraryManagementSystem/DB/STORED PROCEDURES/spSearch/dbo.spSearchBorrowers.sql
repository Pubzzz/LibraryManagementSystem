CREATE PROCEDURE spSearchBorrowers 
@bid INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Borrower]
	WHERE BID = @bid;
END