CREATE PROCEDURE [dbo].[SPGetAllSeniorStaffInfo]
	@Type NVARCHAR(25)
AS
BEGIN
	BEGIN
		--IF(@Type = 'Teaching')
		--	BEGIN
		--		SELECT Staffs.Name, Staffs.Code, Staffs.Type, Staffs.PhoneNumber, Staffs.DateOfJoin, TeachingStaff.Subject
		--		FROM Staffs
		--		INNER JOIN TeachingStaff
		--		ON Staffs.Id = TeachingStaff.StaffId
		--		WHERE ('senior' = dbo.[get_senior_junior](Staffs.DateOfJoin))
		--	END
		--IF(@Type = 'Administrative')
		--	BEGIN
		--		SELECT Staffs.Name, Staffs.Code, Staffs.Type, Staffs.PhoneNumber, Staffs.DateOfJoin, AdministrativeStaff.Role
		--		FROM Staffs
		--		INNER JOIN AdministrativeStaff
		--		ON Staffs.Id = AdministrativeStaff.StaffId
		--		WHERE ('senior' = dbo.[get_senior_junior](Staffs.DateOfJoin))
		--	END
		--IF(@Type = 'Support')
		--	BEGIN
		--		SELECT Staffs.Name, Staffs.Code, Staffs.Type, Staffs.PhoneNumber, Staffs.DateOfJoin, SupportStaff.Department
		--		FROM Staffs
		--		INNER JOIN SupportStaff
		--		ON Staffs.Id = SupportStaff.StaffId
		--		WHERE ('senior' = dbo.[get_senior_junior](Staffs.DateOfJoin))
		--	END

		SELECT p. Name, p.Code, p.Type, p.PhoneNumber, p.DateOfJoin, t.Subject, a.Role, s.Department  
			FROM Staffs AS p  
			LEFT JOIN TeachingStaff AS t  
			ON p.Id = t.StaffId  
			LEFT JOIN AdministrativeStaff AS a  
			ON p.Id = a.StaffId  
			LEFT JOIN SupportStaff AS s  
			ON p.Id = s.StaffId  
			WHERE ('senior' = dbo.[get_senior_junior](p.DateOfJoin)) AND Type = @Type
	END
END
