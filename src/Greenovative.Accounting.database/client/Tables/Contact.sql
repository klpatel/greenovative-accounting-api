CREATE TABLE [Client].[Contact] (
    [Id]          NVARCHAR (50)     NOT NULL,
    [HomePhone]   VARCHAR (50) NULL,
    [OfficePhone] VARCHAR (50) NULL,
    [CellPhone]   VARCHAR (50) NULL,
    [Email1]      VARCHAR (50) NULL,
    [Email2]      VARCHAR (50) NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([Id] ASC)
);

