CREATE TABLE [Client].[UserClientRole] (
    [Id]         INT                IDENTITY (1, 1) NOT NULL,
    [UserId]     INT                NULL,
    [ClientId]   INT                NULL,
    [StoreId]    INT                NULL,
    [RoleId]     INT                NULL,
    [IsActive]   BIT                NULL,
    [CreatedBy]  VARCHAR (50)       NULL,
    [CreatedOn]  DATETIMEOFFSET (7) NULL,
    [ModifiedBy] VARCHAR (50)       NULL,
    [ModifiedOn] DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_UserClientRole] PRIMARY KEY CLUSTERED ([Id] ASC)
);

