CREATE FUNCTION [dbo].[get_senior_junior]
(
	@doj datetime
)
RETURNS NVARCHAR(10) AS
BEGIN
	DECLARE @return_value NVARCHAR(10), @current_date DATETIME = GetDate()
	SET @return_value = 'junior';
    IF ((DATEDIFF(year, @doj, @current_date)) > 3) SET @return_value = 'senior';
    RETURN @return_value
END;

