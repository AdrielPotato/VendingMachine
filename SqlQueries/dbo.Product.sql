CREATE TABLE [dbo].[Product] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [ProductCode]    VARCHAR (48)    NOT NULL UNIQUE,
    [Name]           VARCHAR (240)   NOT NULL,
    [Price]          DECIMAL (10, 2) NOT NULL,
    [QtyStock]       INT             NOT NULL,
    [CategoryTypeId] INT             NOT NULL,
    [IsDeleted]      BIT             DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_CategoryType] FOREIGN KEY ([CategoryTypeId]) REFERENCES [dbo].[CategoryType] ([Id])
);

