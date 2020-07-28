CREATE PROCEDURE [dbo].[SPInsertStaff]
	@Name nvarchar(30),
	@Code nvarchar(10),
	@Type nvarchar(25),
	@PhoneNumber varchar(15),
	@DateOfJoin datetime,
	@Subject nvarchar(25) = NULL,
	@Department nvarchar(25) = NULL,
	@Role nvarchar(25) = NULL,
	@StaffId int = NULL
AS
BEGIN
	DECLARE @Counter INT	
	SET @Counter = ( SELECT COUNT(*) FROM Staffs WHERE Code = @Code)
	IF (@Counter = 0)
		BEGIN
			INSERT INTO Staffs(Name, Code, Type, PhoneNumber, DateOfJoin)
				VALUES(@Name, @Code, @Type, @PhoneNumber, @DateOfJoin)

			SET @StaffId = SCOPE_IDENTITY();

			IF (@Type = 'Teaching')
				BEGIN
					INSERT INTO TeachingStaff(Subject, StaffId)
					VALUES(@Subject, @StaffId)
				END
			IF (@Type = 'Administrative')
				BEGIN
					INSERT INTO AdministrativeStaff(Role, StaffId)
					VALUES(@Role, @StaffId)
				END
			IF (@Type = 'Support')
				BEGIN
					INSERT INTO SupportStaff(Department, StaffId)
					VALUES(@Department, @StaffId)
				END
			RETURN @Counter
		END
	ELSE
		BEGIN
			RETURN @Counter
		END
END