CREATE TABLE [dbo].[support_staff]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [department] VARCHAR(25) NOT NULL, 
    [staff_code] VARCHAR(10) NOT NULL, 
    CONSTRAINT [FK_support_staff_Tostaffs] FOREIGN KEY ([staff_code]) REFERENCES staffs(code)
)
