CREATE TABLE [dbo].[Book] (
    [ISBN]         BIGINT     NOT NULL,
    [Title]        NCHAR (30) NOT NULL,
    [AuthorID]      INT NOT NULL,
    [No.of.copies] NCHAR (10) NULL,
    [Subject]      NCHAR (10) NULL, 
    CONSTRAINT [PK_Book] PRIMARY KEY ([ISBN]),
    CONSTRAINT [FK_Book] FOREIGN KEY([AuthorID])
    REFERENCES [dbo].[Author] ([AuthorID])
);


