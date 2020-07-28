CREATE PROCEDURE [dbo].[SPViewSingleStaff]
	@Code nvarchar(10),
	@Type nvarchar(25)
AS
BEGIN
	DECLARE @Id int	
	--SET @Type =  (SELECT type FROM Staffs WHERE code = @Code)
	SET @Id = (SELECT Id FROM Staffs WHERE code = @Code)
	IF(@Type = 'Teaching')
		BEGIN
			SELECT Staffs.name, Staffs.code, Staffs.type, Staffs.phone_number, Staffs.DateOfJoin, TeachingStaff.subject
			FROM Staffs
			INNER JOIN TeachingStaff
			ON Staffs.Id = TeachingStaff.staff_id
			WHERE Staffs.Id = @Id
		END
	IF(@Type = 'Administrative')
		BEGIN
			SELECT Staffs.name, Staffs.code, Staffs.type, Staffs.phone_number, Staffs.DateOfJoin, AdministrativeStaff.role
			FROM Staffs
			INNER JOIN AdministrativeStaff
			ON Staffs.Id = AdministrativeStaff.staff_id
			WHERE Staffs.Id = @Id
		END
	IF(@Type = 'Support')
			BEGIN
				SELECT Staffs.name, Staffs.code, Staffs.type, Staffs.phone_number, Staffs.DateOfJoin, SupportStaff.department
				FROM Staffs
				INNER JOIN SupportStaff
				ON Staffs.Id = SupportStaff.staff_id
				WHERE Staffs.Id = @Id
			END
END
