GO
PRINT 'BEGIN SEEDING [Accounting].[AccountCategory]'

-- Seeding script for [Accounting].[AccountCategory]
DECLARE @MergeActions TABLE (ActionTaken NVARCHAR(10));
DECLARE @Inserted INT,@Updated INT,@Deleted INT;

WITH SeedData AS (
    SELECT 1 AS [Id], 1 AS [AccountTypeId], N'Bank Account' AS [Category], N'Bank Account' AS [Description], N'Admin' AS [CreatedBy], GETDATE() AS [CreatedDate], N'Admin' AS [ModifiedBy], GETDATE() AS [ModifiedDate]
    UNION ALL
    SELECT 2, 1, N'Accounts Receivable', N'Accounts Receivable', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 3, 1, N'Petty Cash', N'Petty Cash', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 4, 1, N'Inventory', N'Inventory', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 5, 1, N'Property, Plant, and Equipment', N'Property, Plant, and Equipment', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 6, 2, N'Collected Sales Tax', N'Collected Sales Tax', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 7, 2, N'Accounts Payable', N'Accounts Payable', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 8, 2, N'Income Tax', N'Income Tax', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 9, 2, N'Payroll Tax', N'Payroll Tax', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 10, 3, N'Earned Interest', N'Earned Interest', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 11, 3, N'Product Sales', N'Product Sales', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 12, 3, N'Inclome', N'Inclome', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 13, 4, N'Cost of Goods Sold', N'Cost of Goods Sold', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 14, 4, N'Insurance Expenses', N'Insurance Expenses', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 15, 4, N'Vehicle Expenses', N'Vehicle Expenses', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 16, 4, N'Payroll Expenses or salary accounts', N'Payroll Expenses or salary accounts', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 18, 4, N'Rent', N'Rent', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 19, 4, N'Office Expenses', N'Office Expenses', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 20, 5, N'Retained Earnings', N'Retained Earnings', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 21, 5, N'Owner’s Equity', N'Owner’s Equity', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 22, 5, N'Common Stock', N'Common Stock', N'Admin', GETDATE(), N'Admin', GETDATE()
)
MERGE [Accounting].[AccountCategory] AS target
USING SeedData AS source
ON target.[Id] = source.[Id]
WHEN MATCHED THEN
    UPDATE SET 
        target.[AccountTypeId] = source.[AccountTypeId],
        target.[Category] = source.[Category],
        target.[Description] = source.[Description],
        target.[CreatedBy] = source.[CreatedBy],
        target.[CreatedDate] = source.[CreatedDate],
        target.[ModifiedBy] = source.[ModifiedBy],
        target.[ModifiedDate] = source.[ModifiedDate]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
    VALUES (source.[Id], source.[AccountTypeId], source.[Category], source.[Description], source.[CreatedBy], GETDATE(), source.[ModifiedBy], GETDATE())

WHEN NOT MATCHED BY SOURCE THEN
	DELETE 

OUTPUT $action INTO @MergeActions;

SET @Inserted = (SELECT COUNT(1) FROM @MergeActions WHERE ActionTaken = 'INSERT')
SET @Updated = (SELECT COUNT(1) FROM @MergeActions WHERE ActionTaken = 'UPDATE')
SET @Deleted = (SELECT COUNT(1) FROM @MergeActions WHERE ActionTaken = 'DELETE')

PRINT 
	CONVERT(NVARCHAR(15),@Inserted) + ' rows inserted' + CHAR(13)+CHAR(10)
	+ CONVERT(NVARCHAR(15),@Updated) + ' rows updated' + CHAR(13)+CHAR(10)
	+ CONVERT(NVARCHAR(15),@Deleted) + ' rows deleted'


PRINT 'END SEEDING [Accounting].[AccountCategory]'
GO

