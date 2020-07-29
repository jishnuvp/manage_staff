CREATE PROCEDURE [dbo].[SPCheckStaffExistence]
	@Code NVARCHAR(10)
AS
	DECLARE @IsExist INT = 0
	IF EXISTS(SELECT * from Staffs WHERE Code = @Code)		
	BEGIN
		SET @IsExist = 1
		RETURN @IsExist
	END
	ELSE
	BEGIN
		RETURN @IsExist
	END