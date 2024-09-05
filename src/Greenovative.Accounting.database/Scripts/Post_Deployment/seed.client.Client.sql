GO
PRINT 'BEGIN SEEDING [Client].[Client]'


-- Seeding script for [Client].[Client]
DECLARE @MergeActions TABLE (ActionTaken NVARCHAR(10));
DECLARE @Inserted INT,@Updated INT,@Deleted INT;

WITH SeedData AS (
    SELECT NEWID() AS [Id], 
           N'Greenovative Demo Client1 Fname' AS [ClientFName], 
           NULL AS [ClientMName], 
           N'Greenovative Demo Client1 Lname' AS [ClientLName], 
           NULL AS [AddressId], 
           NULL AS [ContactId], 
           1 AS [IsActive], 
           N'Admin' AS [CreatedBy], 
           GETDATE() AS [CreatedOn], 
           N'Admin' AS [ModifiedBy], 
           GETDATE() AS [ModifiedOn]
    UNION ALL
    SELECT NEWID() AS [Id], 
           N'Greenovative Demo Client2 Fname' AS [ClientFName], 
           NULL AS [ClientMName], 
           N'Greenovative Demo Client2 Lname' AS [ClientLName], 
           NULL AS [AddressId], 
           NULL AS [ContactId], 
           1 AS [IsActive], 
           N'Admin' AS [CreatedBy], 
           GETDATE() AS [CreatedOn], 
           N'Admin' AS [ModifiedBy], 
           GETDATE() AS [ModifiedOn]
    
)
MERGE [Client].[Client] AS target
USING SeedData AS source
ON target.[Id] = source.[Id]
WHEN MATCHED THEN
    UPDATE SET 
        target.[ClientFName] = source.[ClientFName],
        target.[ClientMName] = source.[ClientMName],
        target.[ClientLName] = source.[ClientLName],
        target.[AddressId] = source.[AddressId],
        target.[ContactId] = source.[ContactId],
        target.[IsActive] = source.[IsActive],
        target.[CreatedBy] = source.[CreatedBy],
        target.[CreatedOn] = source.[CreatedOn],
        target.[ModifiedBy] = source.[ModifiedBy],
        target.[ModifiedOn] = source.[ModifiedOn]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([Id], [ClientFName], [ClientMName], [ClientLName], [AddressId], [ContactId], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn])
    VALUES (source.[Id], source.[ClientFName], source.[ClientMName], source.[ClientLName], source.[AddressId], source.[ContactId], source.[IsActive], source.[CreatedBy], GETDATE(), source.[ModifiedBy], GETDATE())

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


PRINT 'END SEEDING [Client].[Client]'
GO

