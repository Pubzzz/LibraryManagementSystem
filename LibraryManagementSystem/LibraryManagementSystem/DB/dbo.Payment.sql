CREATE TABLE [dbo].[Payment] (
    [LoanID]     INT  NOT NULL,
    [BorrowerID] INT  NOT NULL,
    [Payment]    INT  NOT NULL,
    [Date]       DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([LoanID] ASC)
);

