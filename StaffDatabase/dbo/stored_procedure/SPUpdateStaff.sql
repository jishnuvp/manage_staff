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
			SET @Id = (SELECT Id FROM Staffs WHERE Code = @Code)
			UPDATE Staffs 
			SET Name = @Name, Type = @Type, PhoneNumber = @PhoneNumber, DateOfJoin = @DateOfJoin, UpdatedAt = GETDATE()
			WHERE id = @Id
			IF(@Type = 'Teaching')
				BEGIN
					UPDATE TeachingStaff
					SET Subject = @Subject, UpdatedAt = GETDATE()
					WHERE StaffId = @Id
				END
			IF(@Type = 'Administrative')
				BEGIN
					UPDATE AdministrativeStaff
					SET Role = @Role, UpdatedAt = GETDATE()
					WHERE StaffId = @Id
				END
			IF(@Type = 'Support')
				BEGIN
					UPDATE SupportStaff
					SET Department = @Department, UpdatedAt = GETDATE()
					WHERE StaffId = @Id
				END
		END
END
