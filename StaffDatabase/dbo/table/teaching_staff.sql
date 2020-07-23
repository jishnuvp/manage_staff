CREATE TABLE [dbo].[teaching_staff]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [subject] NVARCHAR(25) NOT NULL, 
    [staff_id] INT NOT NULL, 
    CONSTRAINT [FK_teaching_staff_Tostaffs] FOREIGN KEY ([staff_id]) REFERENCES staffs(Id) 
)
