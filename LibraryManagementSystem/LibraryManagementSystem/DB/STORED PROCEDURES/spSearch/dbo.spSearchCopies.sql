CREATE PROCEDURE spSearchCopies 
@copyId INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Copy]
	WHERE CopyID = @copyId;
END