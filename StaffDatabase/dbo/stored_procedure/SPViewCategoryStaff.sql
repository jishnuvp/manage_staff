
CREATE PROCEDURE [dbo].[SPViewCategoryStaff]
	@Type nvarchar(25)
AS
BEGIN
	IF(@Type = 'Teaching')
		BEGIN
			SELECT Staffs.Name, Staffs.Code, Staffs.Type, Staffs.PhoneNumber, Staffs.DateOfJoin, TeachingStaff.Subject
			FROM Staffs
			INNER JOIN TeachingStaff
			ON Staffs.Id = TeachingStaff.StaffId
		END
	IF(@Type = 'Administrative')
		BEGIN
			SELECT Staffs.Name, Staffs.Code, Staffs.Type, Staffs.PhoneNumber, Staffs.DateOfJoin, AdministrativeStaff.Role
			FROM Staffs
			INNER JOIN AdministrativeStaff
			ON Staffs.Id = AdministrativeStaff.StaffId
		END
	IF(@Type = 'Support')
		BEGIN
			SELECT Staffs.Name, Staffs.Code, Staffs.Type, Staffs.PhoneNumber, Staffs.DateOfJoin, SupportStaff.Department
			FROM Staffs
			INNER JOIN SupportStaff
			ON Staffs.Id = SupportStaff.StaffId
		END
END
