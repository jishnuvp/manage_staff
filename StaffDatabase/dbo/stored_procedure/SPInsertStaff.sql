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

	INSERT INTO staffs(name, code, type, phone_number, date_of_join)
		VALUES(@Name, @Code, @Type, @PhoneNumber, @DateOfJoin)

	SET @StaffId = SCOPE_IDENTITY();

	IF @Type = 'Teaching'
		BEGIN
			INSERT INTO teaching_staff(subject, staff_id)
			VALUES(@Subject, @StaffId)
		END
	IF @Type = 'Administrative'
		BEGIN
			INSERT INTO administrative_staff(role, staff_id)
			VALUES(@Role, @StaffId)
		END
	IF @Type = 'Support'
		BEGIN
			INSERT INTO support_staff(department, staff_id)
			VALUES(@Department, @StaffId)
		END
END