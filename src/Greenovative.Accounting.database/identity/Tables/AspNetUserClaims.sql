﻿CREATE TABLE [identity].[AspNetUserClaims] (
    [Id]         uniqueidentifier NOT NULL,
    [UserId]     uniqueidentifier            NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [identity].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId]
    ON [identity].[AspNetUserClaims]([UserId] ASC);

