CREATE PROCEDURE spInsertCopies
@copyId INT,
@Availability NCHAR(12),
@pPrice INT,
@sPrice INT,
@isbn INT

AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.Copy([CopyID],[Availability],[Pprice],[Sprice],[ISBN])
	VALUES (@copyId,@Availability,@pPrice,@sPrice,@isbn)
END