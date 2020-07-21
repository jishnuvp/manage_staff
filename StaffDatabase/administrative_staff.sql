CREATE TABLE [dbo].[administrative_staff]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [role] VARCHAR(25) NOT NULL, 
    CONSTRAINT [FK_administrative_staff_Tostaff] FOREIGN KEY (Id) REFERENCES staffs(Id)
)
