CREATE TABLE [Accounting].[LedgerAccount](
	[Id] [int] NOT NULL PRIMARY KEY,
	[Type] [varchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO