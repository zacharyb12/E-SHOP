CREATE TABLE [dbo].[FavoriteItem] (
    [Id]        UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [UserId]    UNIQUEIDENTIFIER NOT NULL,
    [ProductId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_FavoriteItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FavoriteItem_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_FavoriteItem_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

