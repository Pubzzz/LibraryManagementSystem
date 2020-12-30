CREATE TABLE [dbo].[Overdue] (
    [LoanID]     INT           NOT NULL,
    [BorrowerID] NVARCHAR (50) NULL,
    [NoOfDays]   INT           NULL,
    [PaymentDue] INT           NULL,
    PRIMARY KEY CLUSTERED ([LoanID] ASC)
);

