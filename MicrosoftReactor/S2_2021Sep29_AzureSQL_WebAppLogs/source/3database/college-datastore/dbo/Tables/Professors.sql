CREATE TABLE [dbo].[Professors]
(
	[ProfessorId] [uniqueidentifier] NOT NULL DEFAULT newid(),
	[Name] [varchar](100) NULL,
	[Doj] [datetime] NULL,
	[Teaches] [varchar](100) NULL,
	[Salary] [numeric](18, 2) NULL,
	[IsPhd] [bit] NULL DEFAULT 0, 
    [Rating] [numeric](5, 2) NULL DEFAULT 2.5, 
    CONSTRAINT [PK_Professors] PRIMARY KEY ([ProfessorId]),
)
