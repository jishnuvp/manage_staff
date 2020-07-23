CREATE TABLE [dbo].[support_staff]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [department] NVARCHAR(25) NOT NULL, 
    [staff_id] INT NOT NULL, 
    CONSTRAINT [FK_support_staff_Tostaffs] FOREIGN KEY ([staff_id]) REFERENCES staffs(Id) ON DELETE CASCADE
)
