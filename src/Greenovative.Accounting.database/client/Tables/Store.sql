CREATE TABLE [client].[Store] (
    [Id]                 INT                IDENTITY (1, 1) NOT NULL,
    [ClientId]           INT                NULL,
    [StoreNumber]        VARCHAR (50)       NULL,
    [StoreName]          VARCHAR (50)       NULL,
    [RegisteredName]     VARCHAR (50)       NULL,
    [TINNo]              VARCHAR (50)       NULL,
    [BusinessTypeId]     TINYINT            NULL,
    [BusinessCategoryId] TINYINT            NULL,
    [ContactId]          INT                NULL,
    [AddressId]          INT                NULL,
    [IsActive]           BIT                NULL,
    [CreatedBy]          VARCHAR (50)       NULL,
    [CreatedOn]          DATETIMEOFFSET (7) NULL,
    [ModifiedBy]         VARCHAR (50)       NULL,
    [ModifiedOn]         DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Store_Address] FOREIGN KEY ([AddressId]) REFERENCES [client].[Address] ([Id]),
    CONSTRAINT [FK_Store_Client] FOREIGN KEY ([ClientId]) REFERENCES [client].[Client] ([Id]),
    CONSTRAINT [FK_Store_Contact] FOREIGN KEY ([ContactId]) REFERENCES [client].[Contact] ([Id]),
    CONSTRAINT [FK_Store_Store] FOREIGN KEY ([Id]) REFERENCES [client].[Store] ([Id])
);

