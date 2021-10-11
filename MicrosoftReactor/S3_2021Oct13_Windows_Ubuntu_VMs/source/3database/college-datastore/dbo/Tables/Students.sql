CREATE TABLE [dbo].[Students]
(
	[StudentId] [uniqueidentifier] NOT NULL DEFAULT newid(),
	[Name] [varchar](100) NULL,
	[RollNumber] [varchar](100) NULL,
	[ProfessorId] [uniqueidentifier] NOT NULL,
	[Fees] [numeric](18, 2) NULL, 
    CONSTRAINT [PK_Students] PRIMARY KEY ([StudentId]), 
    CONSTRAINT [FK_Students_Professors] FOREIGN KEY ([ProfessorId]) REFERENCES [Professors]([ProfessorId])
)
