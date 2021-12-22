CREATE TABLE [dbo].[bestellingtrui] (
    [bestellingid] INT NOT NULL,
    [truitjeid]    INT NOT NULL,
    [aantal]       INT NULL,
    PRIMARY KEY CLUSTERED ([bestellingid] ASC, [truitjeid] ASC),
    FOREIGN KEY ([bestellingid]) REFERENCES [dbo].[bestelling] ([id]),
    FOREIGN KEY ([truitjeid]) REFERENCES [dbo].[truitje] ([id])
);