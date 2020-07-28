CREATE PROCEDURE [dbo].[SPGetAllSeniorStaffInfo]
	@Type NVARCHAR(25)
AS
BEGIN
	BEGIN
		IF(@Type = 'Teaching')
			BEGIN
				SELECT Staffs.name, Staffs.code, Staffs.type, Staffs.phone_number, Staffs.DateOfJoin, TeachingStaff.subject
				FROM Staffs
				INNER JOIN TeachingStaff
				ON Staffs.Id = TeachingStaff.staff_id
				WHERE ('senior' = dbo.[get_senior_junior](Staffs.DateOfJoin))
			END
		IF(@Type = 'Administrative')
			BEGIN
				SELECT Staffs.name, Staffs.code, Staffs.type, Staffs.phone_number, Staffs.DateOfJoin, AdministrativeStaff.role
				FROM Staffs
				INNER JOIN AdministrativeStaff
				ON Staffs.Id = AdministrativeStaff.staff_id
				WHERE ('senior' = dbo.[get_senior_junior](Staffs.DateOfJoin))
			END
		IF(@Type = 'Support')
			BEGIN
				SELECT Staffs.name, Staffs.code, Staffs.type, Staffs.phone_number, Staffs.DateOfJoin, SupportStaff.department
				FROM Staffs
				INNER JOIN SupportStaff
				ON Staffs.Id = SupportStaff.staff_id
				WHERE ('senior' = dbo.[get_senior_junior](Staffs.DateOfJoin))
			END
	END
END
