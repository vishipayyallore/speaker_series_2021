/****** Object:  Table [dbo].[AddressBook]    Script Date: 29-05-2020 17:59:46 ******/
ALTER TABLE [dbo].[AddressBook] DROP CONSTRAINT [DF_AddressBook_CreatedDateTime]
GO

ALTER TABLE [dbo].[AddressBook] DROP CONSTRAINT [DF_AddressBook_Id]
GO

/****** Object:  Table [dbo].[AddressBook]    Script Date: 29-05-2020 17:59:46 ******/
DROP TABLE [dbo].[AddressBook]
GO

/****** Object:  Table [dbo].[AddressBook]    Script Date: 29-05-2020 17:59:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AddressBook](
	[Id] [uniqueidentifier] NOT NULL,
	[StudentId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NULL,
	[FullAddress] [varchar](150) NULL,
	[Enrollment] [varchar](50) NULL,
	[EnrollmentStatus] [varchar](50) NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AddressBook] ADD  CONSTRAINT [DF_AddressBook_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[AddressBook] ADD  CONSTRAINT [DF_AddressBook_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO


