CREATE TABLE [dbo].[BorrowerBackup] (
    [BID]     INT           NOT NULL,
    [Name]    NVARCHAR (50) NOT NULL,
    [Contact] NCHAR (10)    NULL,
    [Address] NVARCHAR (50) NULL,
    [Email]   NVARCHAR (50) NULL,
    CONSTRAINT [PK_BorrowerBackup] PRIMARY KEY CLUSTERED ([BID] ASC)
);

