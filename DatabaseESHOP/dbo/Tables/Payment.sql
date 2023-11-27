CREATE TABLE [dbo].[Payment] (
    [Id]                UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [OrderId]           UNIQUEIDENTIFIER NOT NULL,
    [UserId]            UNIQUEIDENTIFIER NOT NULL,
    [Amount]            DECIMAL (10, 2)  NOT NULL,
    [PaymentDate]       DATE             NOT NULL,
    [PaymentValidation] NVARCHAR (10)    NOT NULL,
    CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Payment_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_Payment_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);