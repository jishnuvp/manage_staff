CREATE PROCEDURE [dbo].[SPUpdateStaff]
	@Name nvarchar(30),
	@PhoneNumber varchar(15),
	@DateOfJoin datetime,
	@Type nvarchar(25),
	@Code nvarchar(10),
	@Subject nvarchar(25)= null,
	@role nvarchar(25) = null,
	@Department nvarchar(25) = null
AS
BEGIN
	DECLARE @Id int
		BEGIN
			SET @Id = (SELECT Id FROM Staffs WHERE code = @Code)
			UPDATE Staffs 
			SET name = @Name, type = @Type, phone_number = @PhoneNumber, date_of_join = @DateOfJoin, updated_at = GETDATE()
			WHERE id = @Id
			IF(@Type = 'Teaching')
				BEGIN
					UPDATE TeachingStaff
					SET subject = @Subject, updated_at = GETDATE()
					WHERE staff_id = @Id
				END
			IF(@Type = 'Administrative')
				BEGIN
					UPDATE AdministrativeStaff
					SET role = @role, updated_at = GETDATE()
					WHERE staff_id = @Id
				END
			IF(@Type = 'Support')
				BEGIN
					UPDATE SupportStaff
					SET department = @Department, updated_at = GETDATE()
					WHERE staff_id = @Id
				END
		END
END
