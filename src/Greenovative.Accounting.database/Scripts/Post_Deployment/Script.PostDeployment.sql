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

:r seed.accounting.AccountType.sql

:r seed.accounting.AccountCategory.sql

:r seed.accounting.LedgerAccount.sql

:r seed.client.Client.sql


PRINT 'END POST-DEPLOYMENT'
GO
