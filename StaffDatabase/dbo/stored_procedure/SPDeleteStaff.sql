CREATE PROCEDURE [dbo].[SPDeleteStaff]
	@Code nvarchar(10)
AS
BEGIN
DECLARE @Counter INT = 0	
	SET @Counter = ( SELECT COUNT(*) FROM Staffs WHERE Code = @Code)
	IF(@Counter > 0)
		BEGIN
			DELETE FROM Staffs WHERE Code = @Code
			RETURN @Counter
		END
	IF(@Counter = 0)
		BEGIN
			RETURN @Counter
		END
END
