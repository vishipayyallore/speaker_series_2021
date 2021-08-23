CREATE TABLE [dbo].[Professors]
(
	[ProfessorId] [uniqueidentifier] NOT NULL DEFAULT newid(),
	[Name] [varchar](100) NULL,
	[Doj] [datetime] NULL,
	[Teaches] [varchar](100) NULL,
	[Salary] [numeric](18, 2) NULL,
	[IsPhd] [bit] NULL, 
    CONSTRAINT [PK_Professors] PRIMARY KEY ([ProfessorId]),
)
