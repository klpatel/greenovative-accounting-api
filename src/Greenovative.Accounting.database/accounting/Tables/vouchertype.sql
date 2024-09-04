CREATE TABLE [Accounting].[VoucherType](
	[Id] [tinyint] NOT NULL ,
	[VoucherType] [nvarchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	CONSTRAINT [PK_VoucherType] PRIMARY KEY CLUSTERED ([Id] ASC),

);