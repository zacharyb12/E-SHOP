CREATE TABLE [dbo].[Product] (
    [Id]            UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]          NVARCHAR (100)   NOT NULL,
    [Price]         DECIMAL (10, 2)  NOT NULL,
    [ImagePath]     NVARCHAR (255)   NOT NULL,
    [Description]   NVARCHAR (MAX)   NOT NULL,
    [StockQuantity] INT              NOT NULL,
    [Rating]        INT              NOT NULL,
    [CategoryId]    UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id])
);