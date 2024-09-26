GO
PRINT 'BEGIN SEEDING [identity].AspNetRoles'

DECLARE @src TABLE 
(
	Id uniqueidentifier
	,[Name] nvarchar(256)
	,NormalizedName nvarchar(256)
	,ConcurrencyStamp nvarchar
)

INSERT INTO @src (Id,[Name],NormalizedName,ConcurrencyStamp)
VALUES
(NEWID(),'SysAdmin','SysAdmin',NULL)
,(NEWID(),'ClientAdmin','ClientAdmin',NULL)
,(NEWID(),'ClientUser','ClientUser',NULL)

DECLARE @MergeActions TABLE (ActionTaken NVARCHAR(10))
DECLARE @Inserted INT,@Updated INT,@Deleted INT

SET NOCOUNT ON

MERGE INTO [identity].[AspNetRoles] t
USING @src s
ON s.Id = t.Id

WHEN MATCHED THEN 
	UPDATE SET 
		t.[Name] = s.[Name]
		,t.NormalizedName = s.NormalizedName
		,t.ConcurrencyStamp = s.ConcurrencyStamp
		

WHEN NOT MATCHED THEN
	INSERT (Id,[Name],NormalizedName,ConcurrencyStamp)
	VALUES (s.Id,s.[Name],s.NormalizedName,s.ConcurrencyStamp)

WHEN NOT MATCHED BY SOURCE THEN
	DELETE 

OUTPUT $action INTO @MergeActions
;


SET @Inserted = (SELECT COUNT(1) FROM @MergeActions WHERE ActionTaken = 'INSERT')
SET @Updated = (SELECT COUNT(1) FROM @MergeActions WHERE ActionTaken = 'UPDATE')
SET @Deleted = (SELECT COUNT(1) FROM @MergeActions WHERE ActionTaken = 'DELETE')

PRINT 
	CONVERT(NVARCHAR(15),@Inserted) + ' rows inserted' + CHAR(13)+CHAR(10)
	+ CONVERT(NVARCHAR(15),@Updated) + ' rows updated' + CHAR(13)+CHAR(10)
	+ CONVERT(NVARCHAR(15),@Deleted) + ' rows deleted'


PRINT 'END SEEDING [identity].AspNetRoles'
GO
