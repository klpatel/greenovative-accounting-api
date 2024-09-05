CREATE TABLE [Client].[BusinessType] (
    [Id]               TINYINT       IDENTITY (1, 1) NOT NULL,
    [BusinessTypeName] VARCHAR (50)  NULL,
    [Description]      VARCHAR (MAX) NULL,
    CONSTRAINT [PK_BusinessType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

