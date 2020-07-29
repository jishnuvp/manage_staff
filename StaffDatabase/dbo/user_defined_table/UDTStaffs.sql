CREATE TYPE [dbo].[UDTStaffs] AS TABLE
(
	[Name] NVARCHAR(30) NOT NULL, 
    [Code] NVARCHAR(10) NOT NULL UNIQUE, 
    [Type] NVARCHAR(25) NOT NULL, 
    [PhoneNumber] VARCHAR(15) NOT NULL, 
    [DateOfJoin] DATETIME NOT NULL,
    [Subject] NVARCHAR(25) NULL, 
    [Role] NVARCHAR(25) NULL, 
    [Department] NVARCHAR(25) NULL
)
