CREATE TABLE [dbo].[teaching_staff]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [subject] VARCHAR(25) NOT NULL, 
    CONSTRAINT [FK_teaching_staff_Tostaff] FOREIGN KEY (Id) REFERENCES staffs(Id)
)
