GO
PRINT 'BEGIN SEEDING [Identity].AspNetRoles'

DECLARE @src TABLE 
(
	Id int
	,[Name] nvarchar(256)
	,NormalizedName nvarchar(256)
	,ConcurrencyStamp nvarchar
)

INSERT INTO @src (Id,[Name],NormalizedName,ConcurrencyStamp)
VALUES
(1,'SysAdmin','SysAdmin',NULL)
,(2,'ClientAdmin','ClientAdmin',NULL)
,(3,'ClientUser','ClientUser',NULL)

DECLARE @MergeActions TABLE (ActionTaken NVARCHAR(10))
DECLARE @Inserted INT,@Updated INT,@Deleted INT

SET NOCOUNT ON

SET IDENTITY_INSERT [Identity].[AspNetRoles] ON 

MERGE INTO [Identity].[AspNetRoles] t
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

SET IDENTITY_INSERT [Identity].[AspNetRoles] OFF

SET @Inserted = (SELECT COUNT(1) FROM @MergeActions WHERE ActionTaken = 'INSERT')
SET @Updated = (SELECT COUNT(1) FROM @MergeActions WHERE ActionTaken = 'UPDATE')
SET @Deleted = (SELECT COUNT(1) FROM @MergeActions WHERE ActionTaken = 'DELETE')

PRINT 
	CONVERT(NVARCHAR(15),@Inserted) + ' rows inserted' + CHAR(13)+CHAR(10)
	+ CONVERT(NVARCHAR(15),@Updated) + ' rows updated' + CHAR(13)+CHAR(10)
	+ CONVERT(NVARCHAR(15),@Deleted) + ' rows deleted'


PRINT 'END SEEDING [Identity].AspNetRoles'
GO
