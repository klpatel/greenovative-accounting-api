/****** Object:  Database [Db_Greenovative_dev]    Script Date: 9/3/2024 2:54:14 PM ******/
CREATE DATABASE [Db_Greenovative_dev]  (EDITION = 'GeneralPurpose', SERVICE_OBJECTIVE = 'GP_S_Gen5_2', MAXSIZE = 32 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS, LEDGER = OFF;
GO
ALTER DATABASE [Db_Greenovative_dev] SET COMPATIBILITY_LEVEL = 160
GO
ALTER DATABASE [Db_Greenovative_dev] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Db_Greenovative_dev] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Db_Greenovative_dev] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Db_Greenovative_dev] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Db_Greenovative_dev] SET ARITHABORT OFF 
GO
ALTER DATABASE [Db_Greenovative_dev] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Db_Greenovative_dev] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Db_Greenovative_dev] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Db_Greenovative_dev] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Db_Greenovative_dev] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Db_Greenovative_dev] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Db_Greenovative_dev] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Db_Greenovative_dev] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Db_Greenovative_dev] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [Db_Greenovative_dev] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Db_Greenovative_dev] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Db_Greenovative_dev] SET  MULTI_USER 
GO
ALTER DATABASE [Db_Greenovative_dev] SET ENCRYPTION ON
GO
ALTER DATABASE [Db_Greenovative_dev] SET QUERY_STORE = ON
GO
ALTER DATABASE [Db_Greenovative_dev] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Schema [Accounting]    Script Date: 9/3/2024 2:54:14 PM ******/
CREATE SCHEMA [Accounting]
GO
/****** Object:  Schema [Inventory]    Script Date: 9/3/2024 2:54:14 PM ******/
CREATE SCHEMA [Inventory]
GO
/****** Object:  Table [Accounting].[Account]    Script Date: 9/3/2024 2:54:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accounting].[Account](
	[Id] [nvarchar](50) NOT NULL,
	[AccountNo] [varchar](20) NULL,
	[ClientId] [nvarchar](50) NULL,
	[AccountName] [varchar](50) NULL,
	[AccountTypeId] [tinyint] NULL,
	[AccountCategoryId] [tinyint] NULL,
	[Description] [nvarchar](250) NULL,
	[OpeningBalance] [decimal](18, 2) NULL,
	[DebitCredit] [varchar](10) NULL,
	[LedgerAccount] [tinyint] NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Accounting].[AccountCategory]    Script Date: 9/3/2024 2:54:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accounting].[AccountCategory](
	[Id] [tinyint] NOT NULL,
	[AccountTypeId] [tinyint] NULL,
	[Category] [nvarchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Accounting].[AccountType]    Script Date: 9/3/2024 2:54:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accounting].[AccountType](
	[Id] [int] NOT NULL,
	[AccountType] [varchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Accounting].[LedgerAccount]    Script Date: 9/3/2024 2:54:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accounting].[LedgerAccount](
	[Id] [int] NOT NULL,
	[Type] [varchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Accounting].[Voucher]    Script Date: 9/3/2024 2:54:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accounting].[Voucher](
	[Id] [nvarchar](50) NOT NULL,
	[VoucherNo] [nvarchar](50) NULL,
	[ClientId] [nvarchar](50) NULL,
	[CreditDebit] [char](10) NULL,
	[CreditAmount] [decimal](18, 2) NULL,
	[DebitAmount] [decimal](18, 2) NULL,
	[VoucherType] [tinyint] NULL,
	[DebitAccountId] [nvarchar](50) NULL,
	[CreditAccountId] [nvarchar](50) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Accounting].[VoucherType]    Script Date: 9/3/2024 2:54:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accounting].[VoucherType](
	[Id] [tinyint] NOT NULL,
	[VoucherType] [nvarchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 1, N'Bank Account', N'Bank Account', N'Admin', CAST(N'2024-09-03T18:26:04.280' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:04.280' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, 1, N'Accounts Receivable', N'Accounts Receivable', N'Admin', CAST(N'2024-09-03T18:26:04.417' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:04.417' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, 1, N'Petty Cash', N'Petty Cash', N'Admin', CAST(N'2024-09-03T18:26:04.520' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:04.520' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, 1, N'Inventory', N'Inventory', N'Admin', CAST(N'2024-09-03T18:26:04.620' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:04.620' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, 1, N'Property, Plant, and Equipment', N'Property, Plant, and Equipment', N'Admin', CAST(N'2024-09-03T18:26:04.710' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:04.710' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (6, 2, N'Collected Sales Tax', N'Collected Sales Tax', N'Admin', CAST(N'2024-09-03T18:26:04.807' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:04.807' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (7, 2, N'Accounts Payable', N'Accounts Payable', N'Admin', CAST(N'2024-09-03T18:26:04.910' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:04.910' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (8, 2, N'Income Tax', N'Income Tax', N'Admin', CAST(N'2024-09-03T18:26:05.010' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:05.010' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (9, 2, N'Payroll Tax', N'Payroll Tax', N'Admin', CAST(N'2024-09-03T18:26:05.113' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:05.113' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (10, 3, N'Earned Interest', N'Earned Interest', N'Admin', CAST(N'2024-09-03T18:26:05.217' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:05.217' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (11, 3, N'Product Sales', N'Product Sales', N'Admin', CAST(N'2024-09-03T18:26:05.317' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:05.317' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (12, 3, N'Inclome', N'Inclome', N'Admin', CAST(N'2024-09-03T18:26:05.403' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:05.403' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (13, 4, N'Cost of Goods Sold', N'Cost of Goods Sold', N'Admin', CAST(N'2024-09-03T18:26:05.510' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:05.510' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (14, 4, N'Insurance Expenses', N'Insurance Expenses', N'Admin', CAST(N'2024-09-03T18:26:05.607' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:05.607' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (15, 4, N'Vehicle Expenses', N'Vehicle Expenses', N'Admin', CAST(N'2024-09-03T18:26:05.727' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:05.727' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (16, 4, N'Payroll Expenses or salary accounts', N'Payroll Expenses or salary accounts', N'Admin', CAST(N'2024-09-03T18:26:05.810' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:05.810' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (18, 4, N'Rent', N'Rent', N'Admin', CAST(N'2024-09-03T18:26:05.910' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:05.910' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (19, 4, N'Office Expenses', N'Office Expenses', N'Admin', CAST(N'2024-09-03T18:26:06.017' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:06.017' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (20, 5, N'Retained Earnings', N'Retained Earnings', N'Admin', CAST(N'2024-09-03T18:26:06.113' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:06.113' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (21, 5, N'Owner’s Equity', N'Owner’s Equity', N'Admin', CAST(N'2024-09-03T18:26:06.230' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:06.230' AS DateTime))
INSERT [Accounting].[AccountCategory] ([Id], [AccountTypeId], [Category], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (22, 5, N'Common Stock', N'Common Stock', N'Admin', CAST(N'2024-09-03T18:26:06.333' AS DateTime), N'Admin', CAST(N'2024-09-03T18:26:06.333' AS DateTime))
GO
INSERT [Accounting].[AccountType] ([Id], [AccountType], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Assets', N'Assets', N'Admin', CAST(N'2024-09-03T18:08:46.453' AS DateTime), N'Admin', CAST(N'2024-09-03T18:08:46.453' AS DateTime))
INSERT [Accounting].[AccountType] ([Id], [AccountType], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'Liabilities', N'Liabilities', N'Admin', CAST(N'2024-09-03T18:08:46.563' AS DateTime), N'Admin', CAST(N'2024-09-03T18:08:46.563' AS DateTime))
INSERT [Accounting].[AccountType] ([Id], [AccountType], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'Income', N'Income/Revenue', N'Admin', CAST(N'2024-09-03T18:08:46.663' AS DateTime), N'Admin', CAST(N'2024-09-03T18:08:46.663' AS DateTime))
INSERT [Accounting].[AccountType] ([Id], [AccountType], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Expenses', N'Expenses', N'Admin', CAST(N'2024-09-03T18:08:46.757' AS DateTime), N'Admin', CAST(N'2024-09-03T18:08:46.757' AS DateTime))
INSERT [Accounting].[AccountType] ([Id], [AccountType], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Equity', N'Equity', N'Admin', CAST(N'2024-09-03T18:08:46.883' AS DateTime), N'Admin', CAST(N'2024-09-03T18:08:46.883' AS DateTime))
GO
INSERT [Accounting].[LedgerAccount] ([Id], [Type], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'General', N'General Ledger', N'Admin', CAST(N'2024-09-03T18:01:51.073' AS DateTime), N'Admin', CAST(N'2024-09-03T18:01:51.073' AS DateTime))
INSERT [Accounting].[LedgerAccount] ([Id], [Type], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'Sales', N'Sales Ledger', N'Admin', CAST(N'2024-09-03T18:01:51.150' AS DateTime), N'Admin', CAST(N'2024-09-03T18:01:51.150' AS DateTime))
INSERT [Accounting].[LedgerAccount] ([Id], [Type], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'Purchase', N'Purchase Ledger', N'Admin', CAST(N'2024-09-03T18:01:51.243' AS DateTime), N'Admin', CAST(N'2024-09-03T18:01:51.243' AS DateTime))
INSERT [Accounting].[LedgerAccount] ([Id], [Type], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'BalanceSheet', N'BalanceSheet Ledger', N'Admin', CAST(N'2024-09-03T18:01:51.343' AS DateTime), N'Admin', CAST(N'2024-09-03T18:01:51.343' AS DateTime))
INSERT [Accounting].[LedgerAccount] ([Id], [Type], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'ProfitAndLoss', N'ProfitAndLoss Ledger', N'Admin', CAST(N'2024-09-03T18:01:51.447' AS DateTime), N'Admin', CAST(N'2024-09-03T18:01:51.447' AS DateTime))
GO
INSERT [Accounting].[VoucherType] ([Id], [VoucherType], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Accounting].[VoucherType] ([Id], [VoucherType], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Cash', N'Cash Paid or Received', N'Admin', CAST(N'2024-09-03T17:56:39.957' AS DateTime), N'Admin', CAST(N'2024-09-03T17:56:39.957' AS DateTime))
INSERT [Accounting].[VoucherType] ([Id], [VoucherType], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'Payment', N'Credit Payment', N'Admin', CAST(N'2024-09-03T17:56:40.117' AS DateTime), N'Admin', CAST(N'2024-09-03T17:56:40.117' AS DateTime))
INSERT [Accounting].[VoucherType] ([Id], [VoucherType], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'Receipt', N'Credit Receipt', N'Admin', CAST(N'2024-09-03T17:56:40.203' AS DateTime), N'Admin', CAST(N'2024-09-03T17:56:40.203' AS DateTime))
INSERT [Accounting].[VoucherType] ([Id], [VoucherType], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Contra', N'Bank to Bank', N'Admin', CAST(N'2024-09-03T17:56:40.300' AS DateTime), N'Admin', CAST(N'2024-09-03T17:56:40.300' AS DateTime))
INSERT [Accounting].[VoucherType] ([Id], [VoucherType], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'Journal', N'Adjustments', N'Admin', CAST(N'2024-09-03T17:56:40.420' AS DateTime), N'Admin', CAST(N'2024-09-03T17:56:40.420' AS DateTime))
INSERT [Accounting].[VoucherType] ([Id], [VoucherType], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (6, N'Sales', N'Credit Sales', N'Admin', CAST(N'2024-09-03T17:56:40.500' AS DateTime), N'Admin', CAST(N'2024-09-03T17:56:40.500' AS DateTime))
INSERT [Accounting].[VoucherType] ([Id], [VoucherType], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (7, N'Purchase', N'Credit Purchase', N'Admin', CAST(N'2024-09-03T17:56:40.580' AS DateTime), N'Admin', CAST(N'2024-09-03T17:56:40.580' AS DateTime))
GO
ALTER DATABASE [Db_Greenovative_dev] SET  READ_WRITE 
GO
