-- You need to retrieve the ProfessorId from Professors table.
INSERT INTO [dbo].[Students] ([Name], [RollNumber], [ProfessorId],[Fees]) VALUES ('AAA', 'A101', '99C2F1E8-87A3-4103-955B-EC728CE84F2F', 2000.56)
GO
INSERT INTO [dbo].[Students] ([Name], [RollNumber], [ProfessorId],[Fees]) VALUES ('BBB', 'A102', '65CA4196-B519-493B-BF96-F881544BD9F4', 2000.56)
GO
INSERT INTO [dbo].[Students] ([Name], [RollNumber], [ProfessorId],[Fees]) VALUES ('CCC', 'A103', '5EC797EC-DA0A-43DF-B3A3-3F9A04163656', 2000.56)
GO


SELECT * FROM  [dbo].[Professors] 
SELECT * FROM  [dbo].[Students] 