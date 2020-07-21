CREATE TABLE [dbo].[support_staff]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [department] VARCHAR(25) NOT NULL, 
    CONSTRAINT [FK_support_staff_Tostaffs] FOREIGN KEY (Id) REFERENCES staffs(Id)
)
