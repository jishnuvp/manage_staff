CREATE TABLE [dbo].[teaching_staff]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [subject] VARCHAR(25) NOT NULL, 
    [staff_code] VARCHAR(10) NOT NULL, 
    CONSTRAINT [FK_teaching_staff_Tostaffs] FOREIGN KEY ([staff_code]) REFERENCES staffs(code) 
)
