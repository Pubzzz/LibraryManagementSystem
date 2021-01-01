CREATE PROCEDURE spInsertBooks
@ISBN INT,
@title NVARCHAR(50),
@author  NVARCHAR(50),
@copies INT,
@subject  NVARCHAR(50)
AS
BEGIN
   
	INSERT INTO dbo.Book([ISBN],[Title], [Author], [Noofcopies], [Subject])
	VALUES (@ISBN, @title, @author, @copies,@subject)

END