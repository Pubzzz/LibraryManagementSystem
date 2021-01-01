CREATE PROCEDURE spUpdateBorrowers
@BID INT,
@name NVARCHAR(50),
@contact NCHAR(10),
@address NVARCHAR(50),
@email  NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	Update [dbo].[Borrower] 
	SET 
		[BID]=@BID,
		[Name]=@name,
		[Contact]=@contact,
		[Address]=@address,
		[Email]=@email
	WHERE [BID]=@BID
END