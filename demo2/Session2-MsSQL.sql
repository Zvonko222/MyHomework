/*
    Session2 - Microsoft SQL Server database bootstrap
    Bloom Garden mobile application / Web API exercise

    Reconstruction note:
    The official companion SQL file was not present with the supplied test PDF.
    This script reconstructs the eight tables and field names shown in the printed
    ERD, then adds clearly identified demonstration data needed by Session 2.

    Target: SQL Server 2016 or later
    Safety: creates the Session2 database when absent; never drops a database/table.
*/

USE [master];
GO

IF DB_ID(N'Session2') IS NULL
BEGIN
    CREATE DATABASE [Session2];
END;
GO

USE [Session2];
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

/* ---------- Schema (field names follow the ERD in the test paper) ---------- */

IF OBJECT_ID(N'dbo.Store', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Store
    (
        Id          INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Store PRIMARY KEY,
        Name        NVARCHAR(100) NOT NULL,
        Location    NVARCHAR(200) NOT NULL,
        IsEnable    BIT NOT NULL CONSTRAINT DF_Store_IsEnable DEFAULT (1)
    );
END;
GO

IF OBJECT_ID(N'dbo.Role', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Role
    (
        Id          INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Role PRIMARY KEY,
        Name        NVARCHAR(50) NOT NULL CONSTRAINT UQ_Role_Name UNIQUE
    );
END;
GO

IF OBJECT_ID(N'dbo.FlowerCategory', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.FlowerCategory
    (
        Id          INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_FlowerCategory PRIMARY KEY,
        Name        NVARCHAR(50) NOT NULL CONSTRAINT UQ_FlowerCategory_Name UNIQUE
    );
END;
GO

IF OBJECT_ID(N'dbo.StoreImages', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.StoreImages
    (
        Id          INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_StoreImages PRIMARY KEY,
        StoreId     INT NOT NULL,
        Src         NVARCHAR(260) NOT NULL,
        CONSTRAINT FK_StoreImages_Store
            FOREIGN KEY (StoreId) REFERENCES dbo.Store(Id)
    );
END;
GO

IF OBJECT_ID(N'dbo.Staff', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Staff
    (
        StaffId     VARCHAR(20) NOT NULL CONSTRAINT PK_Staff PRIMARY KEY,
        FirstName   NVARCHAR(50) NOT NULL,
        LastName    NVARCHAR(50) NOT NULL,
        [Password]  NVARCHAR(255) NOT NULL,
        RoleId      INT NOT NULL,
        StoreId     INT NOT NULL,
        Photo       NVARCHAR(260) NULL,
        CONSTRAINT FK_Staff_Role
            FOREIGN KEY (RoleId) REFERENCES dbo.Role(Id),
        CONSTRAINT FK_Staff_Store
            FOREIGN KEY (StoreId) REFERENCES dbo.Store(Id)
    );
END;
GO

IF OBJECT_ID(N'dbo.ArrangementStation', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ArrangementStation
    (
        Id              INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ArrangementStation PRIMARY KEY,
        StoreId         INT NOT NULL,
        MaximumPeople   INT NOT NULL,
        IsEnable        BIT NOT NULL CONSTRAINT DF_ArrangementStation_IsEnable DEFAULT (1),
        CONSTRAINT FK_ArrangementStation_Store
            FOREIGN KEY (StoreId) REFERENCES dbo.Store(Id),
        CONSTRAINT CK_ArrangementStation_MaximumPeople
            CHECK (MaximumPeople > 0)
    );
END;
GO

IF OBJECT_ID(N'dbo.Flower', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Flower
    (
        Id                  INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Flower PRIMARY KEY,
        Name                NVARCHAR(100) NOT NULL,
        CategoryId          INT NOT NULL,
        Price               DECIMAL(10,2) NOT NULL,
        InventoryNumber     INT NOT NULL,
        IsAvailable         BIT NOT NULL CONSTRAINT DF_Flower_IsAvailable DEFAULT (1),
        Cover               NVARCHAR(260) NOT NULL,
        CONSTRAINT FK_Flower_FlowerCategory
            FOREIGN KEY (CategoryId) REFERENCES dbo.FlowerCategory(Id),
        CONSTRAINT CK_Flower_Price CHECK (Price >= 0),
        CONSTRAINT CK_Flower_InventoryNumber CHECK (InventoryNumber >= 0)
    );
END;
GO

IF OBJECT_ID(N'dbo.OpenStation', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.OpenStation
    (
        Id              INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_OpenStation PRIMARY KEY,
        StationId       INT NOT NULL,
        NumberOfPeople  INT NOT NULL,
        HasVase         BIT NOT NULL CONSTRAINT DF_OpenStation_HasVase DEFAULT (0),
        OpenTime        DATETIME2(0) NOT NULL,
        IsCheckout      BIT NOT NULL CONSTRAINT DF_OpenStation_IsCheckout DEFAULT (0),
        CheckOutTime    DATETIME2(0) NULL,
        TotalAmount     DECIMAL(12,2) NOT NULL CONSTRAINT DF_OpenStation_TotalAmount DEFAULT (0),
        CONSTRAINT FK_OpenStation_ArrangementStation
            FOREIGN KEY (StationId) REFERENCES dbo.ArrangementStation(Id),
        CONSTRAINT CK_OpenStation_NumberOfPeople CHECK (NumberOfPeople > 0),
        CONSTRAINT CK_OpenStation_TotalAmount CHECK (TotalAmount >= 0),
        CONSTRAINT CK_OpenStation_CheckoutState CHECK
        (
            (IsCheckout = 0 AND CheckOutTime IS NULL)
            OR
            (IsCheckout = 1 AND CheckOutTime IS NOT NULL AND CheckOutTime >= OpenTime)
        )
    );
END;
GO

IF OBJECT_ID(N'dbo.OrderFlowers', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.OrderFlowers
    (
        Id              INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_OrderFlowers PRIMARY KEY,
        OpenStationId   INT NOT NULL,
        FlowerId        INT NOT NULL,
        Number          INT NOT NULL,
        OrderTime       DATETIME2(0) NOT NULL,
        CONSTRAINT FK_OrderFlowers_OpenStation
            FOREIGN KEY (OpenStationId) REFERENCES dbo.OpenStation(Id),
        CONSTRAINT FK_OrderFlowers_Flower
            FOREIGN KEY (FlowerId) REFERENCES dbo.Flower(Id),
        CONSTRAINT CK_OrderFlowers_Number CHECK (Number > 0)
    );
END;
GO

IF NOT EXISTS
(
    SELECT 1 FROM sys.indexes
    WHERE object_id = OBJECT_ID(N'dbo.OpenStation')
      AND name = N'UX_OpenStation_OneActivePerStation'
)
BEGIN
    CREATE UNIQUE INDEX UX_OpenStation_OneActivePerStation
        ON dbo.OpenStation(StationId)
        WHERE IsCheckout = 0;
END;
GO

IF NOT EXISTS
(
    SELECT 1 FROM sys.indexes
    WHERE object_id = OBJECT_ID(N'dbo.OrderFlowers')
      AND name = N'IX_OrderFlowers_OpenStationId'
)
BEGIN
    CREATE INDEX IX_OrderFlowers_OpenStationId
        ON dbo.OrderFlowers(OpenStationId, OrderTime);
END;
GO

/* ---------- Demonstration data (reconstructed; not official source data) ---------- */

BEGIN TRANSACTION;

IF NOT EXISTS (SELECT 1 FROM dbo.Store WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT dbo.Store ON;
    INSERT dbo.Store (Id, Name, Location, IsEnable)
    VALUES
        (1, N'Bloom Garden - Central Store', N'18 Garden Avenue, Central District', 1),
        (2, N'Bloom Garden - Riverside Store', N'88 Riverside Road', 1);
    SET IDENTITY_INSERT dbo.Store OFF;
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Role WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT dbo.Role ON;
    INSERT dbo.Role (Id, Name)
    VALUES (1, N'Store Manager'), (2, N'Florist');
    SET IDENTITY_INSERT dbo.Role OFF;
END;

IF NOT EXISTS (SELECT 1 FROM dbo.FlowerCategory WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT dbo.FlowerCategory ON;
    INSERT dbo.FlowerCategory (Id, Name)
    VALUES (1, N'Rose'), (2, N'Lily'), (3, N'Tulip');
    SET IDENTITY_INSERT dbo.FlowerCategory OFF;
END;

IF NOT EXISTS (SELECT 1 FROM dbo.StoreImages WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT dbo.StoreImages ON;
    INSERT dbo.StoreImages (Id, StoreId, Src)
    VALUES
        (1, 1, N'Images/Store/store-01.jpg'),
        (2, 1, N'Images/Store/store-02.jpg'),
        (3, 1, N'Images/Store/store-03.jpg');
    SET IDENTITY_INSERT dbo.StoreImages OFF;
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Staff WHERE StaffId = 'S000001')
BEGIN
    INSERT dbo.Staff (StaffId, FirstName, LastName, [Password], RoleId, StoreId, Photo)
    VALUES
        ('S000001', N'Mei', N'Lin', N'123456', 1, 1, NULL),
        ('S000002', N'Alex', N'Chen', N'123456', 2, 1, N'Images/Staff/default.png');
END;

IF NOT EXISTS (SELECT 1 FROM dbo.ArrangementStation WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT dbo.ArrangementStation ON;
    INSERT dbo.ArrangementStation (Id, StoreId, MaximumPeople, IsEnable)
    VALUES
        (1, 1, 5, 1),
        (2, 1, 5, 1),
        (3, 1, 4, 1),
        (4, 1, 6, 1),
        (5, 1, 4, 1),
        (6, 1, 5, 0);
    SET IDENTITY_INSERT dbo.ArrangementStation OFF;
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Flower WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT dbo.Flower ON;
    INSERT dbo.Flower
        (Id, Name, CategoryId, Price, InventoryNumber, IsAvailable, Cover)
    VALUES
        (1, N'Red Rose',      1, 28.00, 12, 1, N'Images/Flowers/red-rose.png'),
        (2, N'Pink Rose',     1, 34.00,  8, 1, N'Images/Flowers/pink-rose.png'),
        (3, N'White Lily',    2, 40.00,  0, 1, N'Images/Flowers/white-lily.png'),
        (4, N'Pink Lily',     2, 46.00,  9, 1, N'Images/Flowers/pink-lily.png'),
        (5, N'Yellow Tulip',  3, 32.00, 20, 1, N'Images/Flowers/yellow-tulip.png'),
        (6, N'Purple Tulip',  3, 35.00,  6, 0, N'Images/Flowers/purple-tulip.png');
    SET IDENTITY_INSERT dbo.Flower OFF;
END;

IF NOT EXISTS (SELECT 1 FROM dbo.OpenStation WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT dbo.OpenStation ON;
    INSERT dbo.OpenStation
        (Id, StationId, NumberOfPeople, HasVase, OpenTime, IsCheckout, CheckOutTime, TotalAmount)
    VALUES
        (1, 1, 3, 1, '2026-09-21T10:10:00', 0, NULL,                  96.00),
        (2, 3, 2, 0, '2026-09-21T11:20:00', 0, NULL,                  68.00),
        (3, 2, 4, 1, '2026-09-21T09:00:00', 1, '2026-09-21T12:00:00', 120.00);
    SET IDENTITY_INSERT dbo.OpenStation OFF;
END;

IF NOT EXISTS (SELECT 1 FROM dbo.OrderFlowers WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT dbo.OrderFlowers ON;
    INSERT dbo.OrderFlowers (Id, OpenStationId, FlowerId, Number, OrderTime)
    VALUES
        (1, 1, 1, 2, '2026-09-21T10:15:00'),
        (2, 1, 3, 1, '2026-09-21T10:16:00'),
        (3, 2, 2, 2, '2026-09-21T11:25:00'),
        (4, 3, 1, 2, '2026-09-21T09:10:00'),
        (5, 3, 5, 2, '2026-09-21T09:12:00');
    SET IDENTITY_INSERT dbo.OrderFlowers OFF;
END;

COMMIT TRANSACTION;
GO

PRINT N'Session2 database schema and demonstration data are ready.';
PRINT N'Demo login: S000001 / 123456';
GO
