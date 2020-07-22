CREATE TABLE [dbo].[administrative_staff]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [role] VARCHAR(25) NOT NULL, 
    [staff_code] VARCHAR(10) NOT NULL, 
    CONSTRAINT [FK_administrative_staff_Tostaff] FOREIGN KEY ([staff_code]) REFERENCES staffs(code)
)
