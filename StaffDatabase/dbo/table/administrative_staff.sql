CREATE TABLE [dbo].[administrative_staff]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [role] NVARCHAR(25) NOT NULL, 
    [staff_id] INT NOT NULL, 
    [created_at] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP, 
    [updated_at] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP, 
    CONSTRAINT [FK_administrative_staff_Tostaff] FOREIGN KEY ([staff_id]) REFERENCES staffs(Id) ON DELETE CASCADE
)
