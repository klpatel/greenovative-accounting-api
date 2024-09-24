CREATE TABLE [identity].[AspNetUserRoles] (
    [UserId]   uniqueidentifier NOT NULL,
    [RoleId]   uniqueidentifier NOT NULL,
    [ClientId] uniqueidentifier      NULL,
    [StoreId]  INT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [identity].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [identity].[AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_Client] FOREIGN KEY ([ClientId]) REFERENCES [Client].[Client] ([Id]),
    CONSTRAINT [FK_AspNetUserRoles_Store] FOREIGN KEY ([StoreId]) REFERENCES [Client].[Store] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId]
    ON [identity].[AspNetUserRoles]([RoleId] ASC);

