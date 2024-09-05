CREATE TABLE [Identity].[AspNetUserRoles] (
    [UserId]   INT NOT NULL,
    [RoleId]   INT NOT NULL,
    [ClientId] NVARCHAR (50)      NULL,
    [StoreId]  INT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Identity].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_Client] FOREIGN KEY ([ClientId]) REFERENCES [Client].[Client] ([Id]),
    CONSTRAINT [FK_AspNetUserRoles_Store] FOREIGN KEY ([StoreId]) REFERENCES [Client].[Store] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId]
    ON [Identity].[AspNetUserRoles]([RoleId] ASC);

