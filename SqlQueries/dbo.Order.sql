CREATE TABLE [dbo].[Order] (
    [Id]           INT             NOT NULL IDENTITY,
    [ProductId]    INT             NOT NULL,
    [ProductName]  VARCHAR (240)   NOT NULL,
    [ProductPrice] DECIMAL (10, 2) NOT NULL,
    [DateCreated]  DATETIME        NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);

