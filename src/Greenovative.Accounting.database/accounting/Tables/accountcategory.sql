CREATE TABLE [Accounting].[AccountCategory](
	[Id] [tinyint] NOT NULL ,
	[AccountTypeId] [tinyint] NULL,
	[Category] [nvarchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	CONSTRAINT [PK_AccountCategory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AccountCategory_AccountType] FOREIGN KEY ([AccountTypeId]) REFERENCES [Accounting].[AccountType] ([Id])
);