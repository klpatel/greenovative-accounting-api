CREATE TABLE [Client].[Address] (
    [Id]      NVARCHAR (50)     NOT NULL,
    [Addr1]   VARCHAR (50) NULL,
    [Addr2]   VARCHAR (50) NULL,
    [City]    VARCHAR (50) NULL,
    [State]   VARCHAR (50) NULL,
    [Zip]     VARCHAR (50) NULL,
    [Country] VARCHAR (50) NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id] ASC)
);

