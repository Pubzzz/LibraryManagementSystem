CREATE PROCEDURE spUpdateBooks
@ISBN INT,
@title NVARCHAR(50),
@authorId INT,
@copies INT,
@subject  NVARCHAR(50)

AS
BEGIN
	SET NOCOUNT ON;
	UPDATE dbo.Book
	SET 
	[Title] = @title, 
	[Author] = @authorId, 
	[Noofcopies] = @copies, 
	[Subject] = @subject
	WHERE [ISBN] = @ISBN;
END