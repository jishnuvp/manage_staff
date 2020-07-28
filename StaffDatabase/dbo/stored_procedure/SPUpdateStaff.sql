CREATE PROCEDURE [dbo].[SPUpdateStaff]
	@Name nvarchar(30),
	@PhoneNumber varchar(15),
	@DateOfJoin datetime,
	@Type nvarchar(25),
	@Code nvarchar(10),
	@Subject nvarchar(25)= null,
	@Role nvarchar(25) = null,
	@Department nvarchar(25) = null
AS
BEGIN
	DECLARE @Id int
		BEGIN
			SET @Id = (SELECT Id FROM staffs WHERE code = @Code)
			UPDATE staffs 
			SET name = @Name, type = @Type, phone_number = @PhoneNumber, date_of_join = @DateOfJoin, updated_at = GETDATE()
			WHERE id = @Id
			IF(@Type = 'Teaching')
				BEGIN
					UPDATE teaching_staff
					SET subject = @Subject, updated_at = GETDATE()
					WHERE staff_id = @Id
				END
			IF(@Type = 'Administrative')
				BEGIN
					UPDATE administrative_staff
					SET role = @Role, updated_at = GETDATE()
					WHERE staff_id = @Id
				END
			IF(@Type = 'Support')
				BEGIN
					UPDATE support_staff
					SET department = @Department, updated_at = GETDATE()
					WHERE staff_id = @Id
				END
		END
END
