CREATE PROCEDURE [dbo].[spDeleteLibrary]
@libraryId NCHAR
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.Library
	WHERE LibID = @libraryId;
END