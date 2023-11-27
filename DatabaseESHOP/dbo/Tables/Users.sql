CREATE TABLE [dbo].[Users] (
    [Id]        UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [LastName]  NVARCHAR (50)    NOT NULL,
    [FirstName] NVARCHAR (50)    NOT NULL,
    [Email]     NVARCHAR (384)   NOT NULL,
    [Password]  NVARCHAR (60)    NOT NULL,
    [Status]    NVARCHAR (10)    NOT NULL,
    [Address]   NVARCHAR (255)   NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

