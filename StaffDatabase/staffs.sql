CREATE TABLE [dbo].[staffs]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [name] VARCHAR(30) NOT NULL, 
    [code] VARCHAR(10) NOT NULL UNIQUE, 
    [type] VARCHAR(25) NOT NULL, 
    [phone_number] VARCHAR(15) NOT NULL, 
    [date_of_join] DATETIME NOT NULL
)
