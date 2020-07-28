CREATE TABLE [dbo].[Staffs]
(
	[Id] INT NOT NULL  IDENTITY(1, 1), 
    [name] NVARCHAR(30) NOT NULL, 
    [code] NVARCHAR(10) NOT NULL UNIQUE, 
    [type] NVARCHAR(25) NOT NULL, 
    [phone_number] VARCHAR(15) NOT NULL, 
    [date_of_join] DATETIME NOT NULL, 
    [created_at] DATETIME NOT NULL DEFAULT GETDATE(), 
    [updated_at] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_staffs] PRIMARY KEY ([Id]) 
)
