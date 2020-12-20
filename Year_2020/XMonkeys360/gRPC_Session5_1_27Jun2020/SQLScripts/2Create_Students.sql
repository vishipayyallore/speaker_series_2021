
/****** Object:  Table [dbo].[Students]    Script Date: 6/20/2019 10:00:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Students](
	[StudentId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NULL,
	[RollNumber] [varchar](100) NULL,
	[ProfessorId] [uniqueidentifier] NOT NULL,
	[Fees] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Students] ADD  CONSTRAINT [DF_Students_StudentId]  DEFAULT (newid()) FOR [StudentId]
GO

ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Professors_Students] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professors] ([ProfessorId])
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Professors_Students]
GO


