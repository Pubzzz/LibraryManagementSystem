CREATE PROCEDURE spInsertAuthors
@authorId INT,
@name NVARCHAR(50),
@contact NCHAR(10),
@email NVARCHAR(50)

AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.Author([AuthorID],[Name],[Contact],[Email])
	VALUES (@authorId,@name,@contact,@email)
END