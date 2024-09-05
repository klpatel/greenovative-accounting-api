/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO
PRINT 'BEGIN POST-DEPLOYMENT'

:r seed.identity.AspNetRoles.sql

:r seed.accounting.VoucherTypes.sql

:r seed.sccounting.AccountType.sql

:r seed.sccounting.AccountCategory.sql

:r seed.sccounting.LedgerAccount.sql


PRINT 'END POST-DEPLOYMENT'
GO
