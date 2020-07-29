CREATE PROCEDURE [dbo].[SPStaffInsert]
	@typeSTaffs UDTStaffs readonly
AS
BEGIN
	Create Table #TempStaffs(Id int, Type varchar(25))
	DECLARE @StaffId INT, @Type NVARCHAR(25), @Temp NVARCHAR(25)

	INSERT INTO Staffs(Name, Code, Type, PhoneNumber, DateOfJoin)
	OUTPUT INSERTED.Id, INSERTED.Type INTO #TempStaffs(Id, Type)
	SELECT Name, Code, Type, PhoneNumber, DateOfJoin FROM @typeSTaffs

	INSERT INTO TeachingStaff (Subject, StaffId)
	SELECT n.Subject, s.Id
	FROM Staffs s
	INNER JOIN #TempStaffs t ON t.Id = s.Id
	INNER JOIN @typeSTaffs n ON n.Code = s.Code
	WHERE t.Type = 'Teaching'

	INSERT INTO AdministrativeStaff(Role, StaffId)
	SELECT n.Role, s.Id
	FROM Staffs s
	INNER JOIN #TempStaffs t ON t.Id = s.Id
	INNER JOIN @typeSTaffs n ON n.Code = s.Code
	WHERE t.Type = 'Administrative'

	INSERT INTO SupportStaff(Department, StaffId)
	SELECT n.Department, s.Id
	FROM Staffs s
	INNER JOIN #TempStaffs t ON t.Id = s.Id
	INNER JOIN @typeSTaffs n ON n.Code = s.Code
	WHERE t.Type = 'Support'
	
END