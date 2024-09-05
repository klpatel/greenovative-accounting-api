CREATE TABLE [Client].[Client] (
    [Id]          NVARCHAR (50)     NOT NULL,
    [ClientFName] VARCHAR (50)       NULL,
    [ClientMName] VARCHAR (50)       NULL,
    [ClientLName] VARCHAR (50)       NULL,
    [AddressId]   NVARCHAR (50)      NULL,
    [ContactId]   NVARCHAR (50)      NULL,
    [IsActive]    NCHAR (10)         NULL,
    [CreatedBy]   VARCHAR (50)       NULL,
    [CreatedOn]   DATETIMEOFFSET (7) NULL,
    [ModifiedBy]  VARCHAR (50)       NULL,
    [ModifiedOn]  DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Client_Address] FOREIGN KEY ([AddressId]) REFERENCES [Client].[Address] ([Id]),
    CONSTRAINT [FK_Client_Contact] FOREIGN KEY ([ContactId]) REFERENCES [Client].[Contact] ([Id])
);

