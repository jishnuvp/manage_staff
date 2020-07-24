﻿CREATE PROCEDURE [dbo].[SPDeleteStaff]
	@Code nvarchar(10)
AS
BEGIN
DECLARE @Counter INT = 0	
	SET @Counter = ( SELECT COUNT(*) FROM staffs WHERE code = @Code)
	IF(@Counter > 0)
		BEGIN
			DELETE FROM staffs WHERE code = @Code
			RETURN @Counter
		END
	IF(@Counter = 0)
		BEGIN
			RETURN @Counter
		END
END
