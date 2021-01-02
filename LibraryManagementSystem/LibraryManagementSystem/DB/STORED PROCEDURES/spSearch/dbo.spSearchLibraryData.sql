CREATE PROCEDURE spSearchLibraryData 
@libId INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Library]
	WHERE LibID = @libId
END