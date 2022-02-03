CREATE TABLE [dbo].[CategoryType] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (240) NOT NULL,
    [SortValue] INT           NULL,
    CONSTRAINT [PK_CategoryType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

