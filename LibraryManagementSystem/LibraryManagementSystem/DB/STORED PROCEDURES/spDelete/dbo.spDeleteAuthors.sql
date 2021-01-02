CREATE PROCEDURE [dbo].[spDeleteAuthors]
@authorID INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.Author
	WHERE AuthorID = @authorId;
END