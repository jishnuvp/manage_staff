CREATE PROCEDURE [dbo].[SPDeleteStaff]
	@Id int
AS
BEGIN
DECLARE @Counter INT = 0	
	SET @Counter = ( SELECT COUNT(*) FROM Staffs WHERE Id = @Id)
	IF(@Counter > 0)
		BEGIN
			DELETE FROM Staffs WHERE Id = @Id
			RETURN @Counter
		END
	IF(@Counter = 0)
		BEGIN
			RETURN @Counter
		END
END
