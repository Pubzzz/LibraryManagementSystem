CREATE PROCEDURE spSearchAuthors 
@authorId NCHAR
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Author]
	WHERE AuthorID = @authorId;
END