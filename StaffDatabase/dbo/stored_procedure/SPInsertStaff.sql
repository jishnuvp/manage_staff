CREATE PROCEDURE [dbo].[SPInsertStaff]
	@Name varchar(30),
	@Code varchar(10),
	@Type varchar(25),
	@PhoneNumber varchar(15),
	@DateOfJoin datetime,
	@Subject varchar(25) = NULL,
	@Department varchar(25) = NULL,
	@Role varchar(25) = NULL
AS
BEGIN

	INSERT INTO staffs(name, code, type, phone_number, date_of_join)
		VALUES(@Name, @Code, @Type, @PhoneNumber, @DateOfJoin)

	SET @Code = SCOPE_IDENTITY();

	IF @Type = 'Teaching'
		BEGIN
			INSERT INTO teaching_staff(subject, staff_code)
			VALUES(@Subject, @Code)
		END
	IF @Type = 'Administrative'
		BEGIN
			INSERT INTO administrative_staff(role, staff_code)
			VALUES(@Role, @Code)
		END
	IF @Type = 'Support'
		BEGIN
			INSERT INTO support_staff(department, staff_code)
			VALUES(@Department, @Code)
		END
END