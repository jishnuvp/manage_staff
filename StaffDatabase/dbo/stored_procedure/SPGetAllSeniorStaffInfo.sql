CREATE PROCEDURE [dbo].[SPGetAllSeniorStaffInfo]
	@Type NVARCHAR(25)
AS
BEGIN
	BEGIN

		SELECT p.Id, p.Name, p.Code, p.Type, p.PhoneNumber, p.DateOfJoin, t.Subject, a.Role, s.Department  
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
