CREATE TABLE [dbo].[AuthorBackup] (
    [AuthorID] INT           NOT NULL,
    [Name]     NVARCHAR (50) NULL,
    [Contact]  NCHAR (10)    NULL,
    [Email]    NVARCHAR (50) NULL,
    CONSTRAINT [PK_AuthorBackup] PRIMARY KEY CLUSTERED ([AuthorID] ASC)
);

