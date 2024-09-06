GO
PRINT 'BEGIN SEEDING [Accounting].[AccountType]'

-- Seeding script for [Accounting].[AccountType]
DECLARE @MergeActions TABLE (ActionTaken NVARCHAR(10));
DECLARE @Inserted INT,@Updated INT,@Deleted INT;

WITH SeedData AS (
    SELECT 1 AS [Id], N'Assets' AS [AccountType], N'Assets' AS [Description], N'Admin' AS [CreatedBy], GETDATE() AS [CreatedDate], N'Admin' AS [ModifiedBy], GETDATE() AS [ModifiedDate]
    UNION ALL
    SELECT 2, N'Liabilities', N'Liabilities', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 3, N'Income', N'Income/Revenue', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 4, N'Expenses', N'Expenses', N'Admin', GETDATE(), N'Admin', GETDATE()
    UNION ALL
    SELECT 5, N'Equity', N'Equity', N'Admin', GETDATE(), N'Admin', GETDATE()
)
MERGE [Accounting].[AccountType] AS target
USING SeedData AS source
ON target.[Id] = source.[Id]
WHEN MATCHED THEN
    UPDATE SET 
        target.[AccountType] = source.[AccountType],
        target.[Description] = source.[Description],
        target.[CreatedBy] = source.[CreatedBy],
        target.[CreatedDate] = source.[CreatedDate],
        target.[ModifiedBy] = source.[ModifiedBy],
        target.[ModifiedDate] = source.[ModifiedDate]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([Id], [AccountType], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
    VALUES (source.[Id], source.[AccountType], source.[Description], source.[CreatedBy], GETDATE(), source.[ModifiedBy], GETDATE())

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


PRINT 'END SEEDING [Accounting].[AccountType]'
GO

