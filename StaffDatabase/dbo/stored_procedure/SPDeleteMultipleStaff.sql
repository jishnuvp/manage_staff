﻿CREATE PROCEDURE [dbo].[SPDeleteMultipleStaff]
	@IdList UDTIntIdList READONLY
AS
	BEGIN
		DELETE FROM Staffs WHERE Id IN (SELECT Id FROM @IdList)
	END
