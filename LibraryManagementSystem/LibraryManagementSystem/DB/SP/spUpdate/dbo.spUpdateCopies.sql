﻿CREATE PROCEDURE spUpdateCopies
@copyId INT,
@Availability NCHAR(12),
@pPrice INT,
@sPrice INT,
@isbn INT

AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[Copy]
	SET 
	[ISBN] =  @ISBN, 
	[Availability] = @Availability, 
	[Pprice] = @pPrice, 
	[Sprice] = @sPrice
	WHERE CopyID = @copyId;
END