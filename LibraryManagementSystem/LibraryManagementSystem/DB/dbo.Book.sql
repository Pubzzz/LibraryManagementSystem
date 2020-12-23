CREATE TABLE [dbo].[Book] (
    [ISBN]         BIGINT     NOT NULL,
    [Title]        NCHAR (30) NOT NULL,
    [Author]       NCHAR (60) NOT NULL,
    [No.of.copies] NCHAR (10) NULL,
    [Subject]      NCHAR (10) NULL
);

