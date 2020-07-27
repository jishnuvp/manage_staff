CREATE PROCEDURE [dbo].[SPGetAllSeniorStaffInfo]
	@Type NVARCHAR(25)
AS
BEGIN
	BEGIN
		IF(@Type = 'Teaching')
			BEGIN
				SELECT staffs.name, staffs.code, staffs.type, staffs.phone_number, staffs.date_of_join, teaching_staff.subject
				FROM staffs
				INNER JOIN teaching_staff
				ON staffs.Id = teaching_staff.staff_id
				WHERE ('senior' = dbo.[get_senior_junior](staffs.date_of_join))
			END
		IF(@Type = 'Administrative')
			BEGIN
				SELECT staffs.name, staffs.code, staffs.type, staffs.phone_number, staffs.date_of_join, administrative_staff.role
				FROM staffs
				INNER JOIN administrative_staff
				ON staffs.Id = administrative_staff.staff_id
				WHERE ('senior' = dbo.[get_senior_junior](staffs.date_of_join))
			END
		IF(@Type = 'Support')
			BEGIN
				SELECT staffs.name, staffs.code, staffs.type, staffs.phone_number, staffs.date_of_join, support_staff.department
				FROM staffs
				INNER JOIN support_staff
				ON staffs.Id = support_staff.staff_id
				WHERE ('senior' = dbo.[get_senior_junior](staffs.date_of_join))
			END
	END
END
