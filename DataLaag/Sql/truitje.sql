CREATE TABLE truitje(
id int NOT NULL PRIMARY KEY IDENTITY,
maat nvarchar(10),
seizoen nvarchar(10),
prijs float,
versie bit,
thuis bit,
competitie nvarchar(50),
ploeg nvarchar(100)
);