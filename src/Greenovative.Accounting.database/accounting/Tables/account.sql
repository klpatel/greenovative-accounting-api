CREATE TABLE [Accounting].[Account](
	[Id]					[nvarchar](50) NOT NULL,
	[AccountNo]				[varchar](20) NULL,
	[ClientId]				[nvarchar](50) NULL,
	[AccountName]			[varchar](50) NULL,
	[AccountTypeId]			[tinyint] NULL,
	[AccountCategoryId]		[tinyint] NULL,
	[Description]			[nvarchar](250) NULL,
	[OpeningBalance]		[decimal](18, 2) NULL,
	[DebitCredit]			[varchar](10) NULL,
	[LedgerAccount]			[tinyint] NULL,
	[CreatedBy]				[varchar](50) NULL,
	[CreatedDate]			[datetime] NULL,
	[ModifiedBy]			[varchar](50) NULL,
	[ModifiedDate]			[datetime] NULL,
	CONSTRAINT [PK_OperationData] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Voucher_AccountType] FOREIGN KEY ([AccountTypeId]) REFERENCES [Accounting].[AccountType] ([Id]),
	CONSTRAINT [FK_Voucher_AccountCategory] FOREIGN KEY ([AccountCategoryId]) REFERENCES [Accounting].[AccountCategory] ([Id]),
); 


