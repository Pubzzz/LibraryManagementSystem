CREATE TABLE [dbo].[Loan] (
    [LoanID] NCHAR (10) NOT NULL,
    [CopyID] INT NOT NULL,
    [BID]    NCHAR (10) NOT NULL,
    [LDate]  DATE       NULL,
    [RDate]  DATE       NULL, 
    CONSTRAINT [PK_Loan] PRIMARY KEY ([LoanID]),
    CONSTRAINT [FK_Loan] FOREIGN KEY([CopyID])
    REFERENCES [dbo].[Copy] ([CopyID])
);

