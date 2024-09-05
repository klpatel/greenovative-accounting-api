CREATE TABLE [Client].[Store] (
    [Id]                 INT                IDENTITY (1, 1) NOT NULL,
    [ClientId]           NVARCHAR (50)      NULL,
    [StoreNumber]        VARCHAR (50)       NULL,
    [StoreName]          VARCHAR (50)       NULL,
    [RegisteredName]     VARCHAR (50)       NULL,
    [TINNo]              VARCHAR (50)       NULL,
    [BusinessTypeId]     TINYINT            NULL,
    [BusinessCategoryId] TINYINT            NULL,
    [ContactId]          NVARCHAR (50)      NULL,
    [AddressId]          NVARCHAR (50)      NULL,
    [IsActive]           BIT                NULL,
    [CreatedBy]          VARCHAR (50)       NULL,
    [CreatedOn]          DATETIMEOFFSET (7) NULL,
    [ModifiedBy]         VARCHAR (50)       NULL,
    [ModifiedOn]         DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Store_Address] FOREIGN KEY ([AddressId]) REFERENCES [Client].[Address] ([Id]),
    CONSTRAINT [FK_Store_Client] FOREIGN KEY ([ClientId]) REFERENCES [Client].[Client] ([Id]),
    CONSTRAINT [FK_Store_Contact] FOREIGN KEY ([ContactId]) REFERENCES [Client].[Contact] ([Id]),
    CONSTRAINT [FK_Store_Store] FOREIGN KEY ([Id]) REFERENCES [Client].[Store] ([Id])
);

