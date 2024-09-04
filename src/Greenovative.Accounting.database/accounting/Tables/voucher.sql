CREATE TABLE [Accounting].[Voucher](
	[Id] [nvarchar](50) NOT NULL,
	[VoucherNo] [nvarchar](50) NULL,
	[ClientId] [nvarchar](50) NULL,
	[CreditDebit] [char](10) NULL,
	[CreditAmount] [decimal](18, 2) NULL,
	[DebitAmount] [decimal](18, 2) NULL,
	[VoucherTypeId] [tinyint] NULL,
	[DebitAccountId] [nvarchar](50) NULL,
	[CreditAccountId] [nvarchar](50) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Voucher_VoucherType] FOREIGN KEY ([VoucherTypeId]) REFERENCES [Accounting].[VoucherType] ([Id]),
	CONSTRAINT [FK_Voucher_DebitAccount] FOREIGN KEY ([DebitAccountId]) REFERENCES [Accounting].[Account] ([Id]),
	CONSTRAINT [FK_Voucher_CreditAccount] FOREIGN KEY ([CreditAccountId]) REFERENCES [Accounting].[Account] ([Id])

);