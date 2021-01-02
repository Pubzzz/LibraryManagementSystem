CREATE PROCEDURE spInsertLibrary
@libraryId INT,
@name NVARCHAR(50),
@type NCHAR(10),
@administrator NVARCHAR(50),
@contact NCHAR(10),
@address NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.Library([LibID],[Name],[Type],[Administrator],[Contact],[Address])
	VALUES(@libraryId,@name,@type,@administrator,@contact,@address)
END