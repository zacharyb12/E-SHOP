CREATE TABLE [dbo].[OrderItem] (
    [Id]        UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [OrderId]   UNIQUEIDENTIFIER NOT NULL,
    [ProductId] UNIQUEIDENTIFIER NOT NULL,
    [Quantity]  INT              NOT NULL,
    [ItemPrice] DECIMAL (10, 2)  NOT NULL,
    CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderItem_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_OrderItem_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);