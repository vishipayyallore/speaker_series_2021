
/****** Object:  Table [dbo].[Professors]    Script Date: 6/20/2019 10:00:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Professors](
	[ProfessorId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NULL,
	[Doj] [datetime] NULL,
	[Teaches] [varchar](100) NULL,
	[Salary] [numeric](18, 2) NULL,
	[IsPhd] [bit] NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Professors] ADD  CONSTRAINT [DF_Professors_ProfessorId]  DEFAULT (newid()) FOR [ProfessorId]
GO


