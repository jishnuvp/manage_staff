CREATE TABLE [dbo].[AdministrativeStaff]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [Role] NVARCHAR(25) NOT NULL, 
    [StaffId] INT NOT NULL, 
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UpdatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_administrative_staff_Tostaff] FOREIGN KEY ([StaffId]) REFERENCES Staffs(Id) ON DELETE CASCADE
)
