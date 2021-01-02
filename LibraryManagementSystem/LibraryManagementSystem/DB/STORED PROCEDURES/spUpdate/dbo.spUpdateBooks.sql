CREATE PROCEDURE spUpdateBooks
@ISBN INT,
@title NVARCHAR(50),
@author NVARCHAR(50),
@copies INT,
@subject  NVARCHAR(50)

AS
BEGIN
	SET NOCOUNT ON;
	UPDATE dbo.Book
	SET 
	[Title] = @title, 
	[Author] = @author, 
	[Noofcopies] = @copies, 
	[Subject] = @subject
	WHERE [ISBN] = @ISBN;
END