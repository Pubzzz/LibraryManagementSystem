CREATE PROCEDURE spUpdateAuthors
@authorId INT,
@name NVARCHAR(50),
@contact NCHAR(10),
@email NVARCHAR(50)

AS
BEGIN
	SET NOCOUNT ON;
	UPDATE dbo.Author 
	SET
	[AuthorID] = @authorId,
	[Name] = @name,
	[Contact] = @contact,
	[Email] = @email
	WHERE [AuthorID] = @authorId
END