CREATE TABLE [dbo].[Order] (
    [Id]         UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [UserId]     UNIQUEIDENTIFIER NOT NULL,
    [Status]     NVARCHAR (10)    NOT NULL,
    [OrderDate]  DATE             NOT NULL,
    [TotalPrice] DECIMAL (10, 2)  NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);
