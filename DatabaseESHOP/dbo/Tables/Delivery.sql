CREATE TABLE [dbo].[Delivery] (
    [Id]           UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [UserId]       UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [OrderId]      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Status]       NVARCHAR (10)    NOT NULL,
    [DeliveryDate] DATE             NOT NULL,
    CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Delivery_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_Delivery_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);