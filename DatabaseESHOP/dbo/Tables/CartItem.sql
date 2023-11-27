CREATE TABLE [dbo].[CartItem] (
    [Id]        UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [UserId]    UNIQUEIDENTIFIER NOT NULL,
    [ProductId] UNIQUEIDENTIFIER NOT NULL,
    [Quantity]  INT  NOT NULL,
    [ItemPrice] DECIMAL (18, 2)  NOT NULL,
    CONSTRAINT [PK_CartItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CartItem_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_CartItem_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);
