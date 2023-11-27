CREATE TABLE [dbo].[ProductReview] (
    [Id]         UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [ProductId]  UNIQUEIDENTIFIER NOT NULL,
    [UserId]     UNIQUEIDENTIFIER NOT NULL,
    [Rating]     INT              NOT NULL,
    [ReviewText] NVARCHAR (MAX)   NOT NULL,
    [ReviewDate] DATE             NOT NULL,
    CONSTRAINT [PK_ProductReview] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductReview_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_ProductReview_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);