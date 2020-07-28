CREATE TABLE [dbo].[AdministrativeStaff]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [role] NVARCHAR(25) NOT NULL, 
    [staff_id] INT NOT NULL, 
    [created_at] DATETIME NOT NULL DEFAULT GETDATE(), 
    [updated_at] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_administrative_staff_Tostaff] FOREIGN KEY ([staff_id]) REFERENCES Staffs(Id) ON DELETE CASCADE
)
