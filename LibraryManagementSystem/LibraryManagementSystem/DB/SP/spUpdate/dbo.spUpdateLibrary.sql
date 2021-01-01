CREATE PROCEDURE spUpdateLibrary
@libraryId INT,
@name NVARCHAR(50),
@type NCHAR(12),
@administrator NVARCHAR(50),
@contact NCHAR(10),
@address NVARCHAR(50)

AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[Library] 
	SET 
	[LibID] = @libraryId, 
	[Name] = @name, 
	[Type] = @type, 
	[Administrator] = @administrator,
	[Contact]=@contact,
	[Address]=@address

	WHERE [LibId] = @libraryId;
END