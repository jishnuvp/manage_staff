CREATE PROCEDURE [dbo].[SPGetAllSeniorStaffInfo]
	@Type NVARCHAR(25)
AS
BEGIN
	BEGIN
		IF(@Type = 'Teaching')
			BEGIN
				SELECT Staffs.Name, Staffs.Code, Staffs.Type, Staffs.PhoneNumber, Staffs.DateOfJoin, TeachingStaff.Subject
				FROM Staffs
				INNER JOIN TeachingStaff
				ON Staffs.Id = TeachingStaff.StaffId
				WHERE ('senior' = dbo.[get_senior_junior](Staffs.DateOfJoin))
			END
		IF(@Type = 'Administrative')
			BEGIN
				SELECT Staffs.Name, Staffs.Code, Staffs.Type, Staffs.PhoneNumber, Staffs.DateOfJoin, AdministrativeStaff.Role
				FROM Staffs
				INNER JOIN AdministrativeStaff
				ON Staffs.Id = AdministrativeStaff.StaffId
				WHERE ('senior' = dbo.[get_senior_junior](Staffs.DateOfJoin))
			END
		IF(@Type = 'Support')
			BEGIN
				SELECT Staffs.Name, Staffs.Code, Staffs.Type, Staffs.PhoneNumber, Staffs.DateOfJoin, SupportStaff.Department
				FROM Staffs
				INNER JOIN SupportStaff
				ON Staffs.Id = SupportStaff.StaffId
				WHERE ('senior' = dbo.[get_senior_junior](Staffs.DateOfJoin))
			END
	END
END
