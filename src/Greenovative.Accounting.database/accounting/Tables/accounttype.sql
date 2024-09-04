CREATE TABLE [Accounting].[AccountType](
	[Id] [tinyint] NOT NULL ,
	[AccountType] [varchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL
	CONSTRAINT [PK_AccountType] PRIMARY KEY CLUSTERED ([Id] ASC)
);