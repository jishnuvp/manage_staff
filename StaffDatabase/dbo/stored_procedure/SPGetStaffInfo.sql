CREATE PROCEDURE [dbo].[SPGetStaffInfo]
	@Code nvarchar(10)
AS
BEGIN
	--DECLARE @Id int, @Type nvarchar(25)	
	--SET @Type =  (SELECT type FROM Staffs WHERE code = @Code)
	--SET @Id = (SELECT Id FROM Staffs WHERE code = @Code)

	SELECT p. name, p.code, p.type, p.phone_number, p.DateOfJoin, t.subject, a.role, s.department  
	FROM Staffs AS p  
	LEFT JOIN TeachingStaff AS t  
	ON p.Id = t.staff_id  
	LEFT JOIN AdministrativeStaff AS a  
	ON p.Id = a.staff_id  
	LEFT JOIN SupportStaff AS s  
	ON p.Id = s.staff_id  
	WHERE p.code = @Code

	--IF(@Type = 'Teaching')
	--	BEGIN
	--		SELECT Staffs.name, Staffs.code, Staffs.type, Staffs.phone_number, Staffs.DateOfJoin, TeachingStaff.subject
	--		FROM Staffs
	--		INNER JOIN TeachingStaff
	--		ON Staffs.Id = TeachingStaff.staff_id
	--		WHERE Staffs.Id = @Id
	--	END
	--IF(@Type = 'Administrative')
	--	BEGIN
	--		SELECT Staffs.name, Staffs.code, Staffs.type, Staffs.phone_number, Staffs.DateOfJoin, AdministrativeStaff.role
	--		FROM Staffs
	--		INNER JOIN AdministrativeStaff
	--		ON Staffs.Id = AdministrativeStaff.staff_id
	--		WHERE Staffs.Id = @Id
	--	END
	--IF(@Type = 'Support')
	--		BEGIN
	--			SELECT Staffs.name, Staffs.code, Staffs.type, Staffs.phone_number, Staffs.DateOfJoin, SupportStaff.department
	--			FROM Staffs
	--			INNER JOIN SupportStaff
	--			ON Staffs.Id = SupportStaff.staff_id
	--			WHERE Staffs.Id = @Id
	--		END
END
