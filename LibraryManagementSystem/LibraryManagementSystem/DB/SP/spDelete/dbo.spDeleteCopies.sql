CREATE PROCEDURE [dbo].[spDeleteCopies]
@copyId NCHAR
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.Copy
	WHERE CopyID = @copyId;
END