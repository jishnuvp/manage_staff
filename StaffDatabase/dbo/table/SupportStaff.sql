﻿CREATE TABLE [dbo].[SupportStaff]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [Department] NVARCHAR(25) NOT NULL, 
    [StaffId] INT NOT NULL, 
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UpdatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_support_staff_Tostaffs] FOREIGN KEY ([StaffId]) REFERENCES Staffs(Id) ON DELETE CASCADE
)
