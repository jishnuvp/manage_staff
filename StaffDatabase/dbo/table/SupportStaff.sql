CREATE TABLE [dbo].[SupportStaff]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [department] NVARCHAR(25) NOT NULL, 
    [staff_id] INT NOT NULL, 
    [created_at] DATETIME NOT NULL DEFAULT GETDATE(), 
    [updated_at] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_support_staff_Tostaffs] FOREIGN KEY ([staff_id]) REFERENCES Staffs(Id) ON DELETE CASCADE
)
