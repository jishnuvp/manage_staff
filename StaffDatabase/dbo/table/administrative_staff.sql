CREATE TABLE [dbo].[administrative_staff]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [role] NVARCHAR(25) NOT NULL, 
    [staff_id] INT NOT NULL, 
    CONSTRAINT [FK_administrative_staff_Tostaff] FOREIGN KEY ([staff_id]) REFERENCES staffs(Id) ON DELETE CASCADE
)
