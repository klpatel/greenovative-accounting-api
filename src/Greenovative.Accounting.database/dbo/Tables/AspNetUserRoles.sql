CREATE TABLE [security].[AspNetUserRoles] (
    [UserId]   INT NOT NULL,
    [RoleId]   INT NOT NULL,
    [ClientId] INT NULL,
    [StoreId]  INT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [security].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [security].[AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_Client] FOREIGN KEY ([ClientId]) REFERENCES [client].[Client] ([Id]),
    CONSTRAINT [FK_AspNetUserRoles_Store] FOREIGN KEY ([StoreId]) REFERENCES [client].[Store] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId]
    ON [security].[AspNetUserRoles]([RoleId] ASC);

