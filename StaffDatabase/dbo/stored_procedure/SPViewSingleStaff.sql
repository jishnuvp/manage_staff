CREATE PROCEDURE [dbo].[SPViewSingleStaff]
	@Code nvarchar(10),
	@Type nvarchar(25)
AS
BEGIN
	DECLARE @Id int	
	--SET @Type =  (SELECT Type FROM Staffs WHERE Code = @Code)
	SET @Id = (SELECT Id FROM Staffs WHERE Code = @Code)
	IF(@Type = 'Teaching')
		BEGIN
			SELECT Staffs.Name, Staffs.Code, Staffs.Type, Staffs.PhoneNumber, Staffs.DateOfJoin, TeachingStaff.Subject
			FROM Staffs
			INNER JOIN TeachingStaff
			ON Staffs.Id = TeachingStaff.StaffId
			WHERE Staffs.Id = @Id
		END
	IF(@Type = 'Administrative')
		BEGIN
			SELECT Staffs.Name, Staffs.Code, Staffs.Type, Staffs.PhoneNumber, Staffs.DateOfJoin, AdministrativeStaff.Role
			FROM Staffs
			INNER JOIN AdministrativeStaff
			ON Staffs.Id = AdministrativeStaff.StaffId
			WHERE Staffs.Id = @Id
		END
	IF(@Type = 'Support')
			BEGIN
				SELECT Staffs.Name, Staffs.Code, Staffs.Type, Staffs.PhoneNumber, Staffs.DateOfJoin, SupportStaff.Department
				FROM Staffs
				INNER JOIN SupportStaff
				ON Staffs.Id = SupportStaff.StaffId
				WHERE Staffs.Id = @Id
			END
END
