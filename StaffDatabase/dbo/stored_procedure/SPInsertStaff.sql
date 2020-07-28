CREATE PROCEDURE [dbo].[SPInsertStaff]
	@Name nvarchar(30),
	@Code nvarchar(10),
	@Type nvarchar(25),
	@PhoneNumber varchar(15),
	@DateOfJoin datetime,
	@Subject nvarchar(25) = NULL,
	@Department nvarchar(25) = NULL,
	@role nvarchar(25) = NULL,
	@staff_id int = NULL
AS
BEGIN
	DECLARE @Counter INT	
	SET @Counter = ( SELECT COUNT(*) FROM Staffs WHERE code = @Code)
	IF (@Counter = 0)
		BEGIN
			INSERT INTO Staffs(name, code, type, phone_number, date_of_join)
				VALUES(@Name, @Code, @Type, @PhoneNumber, @DateOfJoin)

			SET @staff_id = SCOPE_IDENTITY();

			IF (@Type = 'Teaching')
				BEGIN
					INSERT INTO TeachingStaff(subject, staff_id)
					VALUES(@Subject, @staff_id)
				END
			IF (@Type = 'Administrative')
				BEGIN
					INSERT INTO AdministrativeStaff(role, staff_id)
					VALUES(@role, @staff_id)
				END
			IF (@Type = 'Support')
				BEGIN
					INSERT INTO SupportStaff(department, staff_id)
					VALUES(@Department, @staff_id)
				END
			RETURN @Counter
		END
	ELSE
		BEGIN
			RETURN @Counter
		END
END