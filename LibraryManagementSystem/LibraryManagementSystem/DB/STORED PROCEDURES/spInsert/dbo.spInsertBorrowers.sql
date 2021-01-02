CREATE PROCEDURE spInsertBorrowers
@BID INT,
@name NVARCHAR(50),
@contact NCHAR(10),
@address NVARCHAR(50),
@email NVARCHAR(50)

AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.Borrower([BID],[Name],[Contact],[Address],[Email])
	VALUES (@BID,@name,@contact,@address,@email);
END