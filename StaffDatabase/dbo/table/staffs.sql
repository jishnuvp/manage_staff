﻿CREATE TABLE [dbo].[Staffs]
(
	[Id] INT NOT NULL  IDENTITY(1, 1), 
    [Name] NVARCHAR(30) NOT NULL, 
    [Code] NVARCHAR(10) NOT NULL UNIQUE, 
    [Type] NVARCHAR(25) NOT NULL, 
    [PhoneNumber] VARCHAR(15) NOT NULL, 
    [DateOfJoin] DATETIME NOT NULL, 
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UpdatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_staffs] PRIMARY KEY ([Id]) 
)
