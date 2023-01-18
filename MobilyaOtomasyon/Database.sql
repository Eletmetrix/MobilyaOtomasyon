CREATE TABLE [dbo].[Musteri]
(
    [MusteriId] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Ad] NVARCHAR(50) NOT NULL,
    [Soyad] NVARCHAR(50) NOT NULL,
    [TelefonNum] CHAR(11) NOT NULL
);

CREATE TABLE [dbo].[Urun]
(
    [UrunId] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [MusteriId] INT NOT NULL FOREIGN KEY REFERENCES Musteri(MusteriId),
    [UrunAdi] NVARCHAR(50) NOT NULL,
    [TeslimEdildi] BIT NOT NULL DEFAULT 0,
    [GirisTarihi] DATE NOT NULL DEFAULT GETDATE(),
    [TeslimTarihi] DATE NULL,
    [Adres] NVARCHAR(100) NOT NULL
);

CREATE TABLE [dbo].[Ebatlar]
(
    [EbatId] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [UrunId] INT NOT NULL FOREIGN KEY REFERENCES Urun(UrunId),
    [EbatIsim] NVARCHAR(20) NOT NULL,
    [EbatDeger] NVARCHAR(6) NOT NULL,
    [EbatTur] BIT NOT NULL DEFAULT 0,
);