/* =========================================================
   文件名：Session1-MsSQL.sql
   数据库：Session1
   平台：Microsoft SQL Server
   说明：根据 2026 市职业技能大赛软件应用开发项目 Session1 试题推断生成
   ========================================================= */

IF DB_ID(N'Session1') IS NULL
    CREATE DATABASE Session1;
GO

USE Session1;
GO

/* ----------------------------
   角色表
   ---------------------------- */
CREATE TABLE dbo.StaffRole (
    RoleID      INT IDENTITY(1,1) NOT NULL,
    RoleName    NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_StaffRole PRIMARY KEY (RoleID),
    CONSTRAINT UQ_StaffRole_RoleName UNIQUE (RoleName)
);
GO

INSERT INTO dbo.StaffRole(RoleName)
VALUES (N'Store Manager'), (N'Central Greenhouse Manager');
GO

/* ----------------------------
   门店表
   ---------------------------- */
CREATE TABLE dbo.Store (
    StoreID     INT IDENTITY(1,1) NOT NULL,
    StoreName   NVARCHAR(100) NOT NULL,
    Address     NVARCHAR(255) NULL,
    CONSTRAINT PK_Store PRIMARY KEY (StoreID)
);
GO

INSERT INTO dbo.Store(StoreName, Address)
VALUES 
(N'Store A', N'Address A'),
(N'Store B', N'Address B');
GO

/* ----------------------------
   员工表
   ---------------------------- */
CREATE TABLE dbo.Staff (
    StaffID     NVARCHAR(20) NOT NULL,
    Password    NVARCHAR(100) NOT NULL,
    FullName    NVARCHAR(100) NULL,
    RoleID      INT NOT NULL,
    StoreID     INT NULL,
    Avatar      NVARCHAR(255) NULL,
    CONSTRAINT PK_Staff PRIMARY KEY (StaffID),
    CONSTRAINT FK_Staff_StaffRole FOREIGN KEY (RoleID) REFERENCES dbo.StaffRole(RoleID),
    CONSTRAINT FK_Staff_Store FOREIGN KEY (StoreID) REFERENCES dbo.Store(StoreID)
);
GO

INSERT INTO dbo.Staff(StaffID, Password, FullName, RoleID, StoreID, Avatar)
VALUES
(N'S000001', N'123456', N'Store Manager A', 1, 1, NULL),
(N'S000002', N'123456', N'Central Greenhouse Manager', 2, NULL, NULL);
GO

/* ----------------------------
   花类表
   ---------------------------- */
CREATE TABLE dbo.FlowerCategory (
    CategoryID      INT IDENTITY(1,1) NOT NULL,
    CategoryName    NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_FlowerCategory PRIMARY KEY (CategoryID),
    CONSTRAINT UQ_FlowerCategory_CategoryName UNIQUE (CategoryName)
);
GO

INSERT INTO dbo.FlowerCategory(CategoryName)
VALUES (N'Rose'), (N'Lily'), (N'Tulip');
GO

/* ----------------------------
   花卉表
   ---------------------------- */
CREATE TABLE dbo.Flower (
    FlowerID        INT IDENTITY(1,1) NOT NULL,
    FlowerName      NVARCHAR(100) NOT NULL,
    Description     NVARCHAR(500) NULL,
    CategoryID      INT NOT NULL,
    UnitPrice       DECIMAL(10,2) NOT NULL,
    CoverImage      NVARCHAR(255) NULL CONSTRAINT DF_Flower_CoverImage DEFAULT N'default.png',
    IsAvailable     BIT NOT NULL CONSTRAINT DF_Flower_IsAvailable DEFAULT 1,
    ReleaseDate     DATE NOT NULL CONSTRAINT DF_Flower_ReleaseDate DEFAULT GETDATE(),
    CONSTRAINT PK_Flower PRIMARY KEY (FlowerID),
    CONSTRAINT CK_Flower_UnitPrice CHECK (UnitPrice >= 0),
    CONSTRAINT FK_Flower_FlowerCategory FOREIGN KEY (CategoryID) REFERENCES dbo.FlowerCategory(CategoryID)
);
GO

INSERT INTO dbo.Flower(FlowerName, Description, CategoryID, UnitPrice, CoverImage, IsAvailable, ReleaseDate)
VALUES
(N'Red Rose',   N'Fresh seasonal flower', 1, 28.00, N'default.png', 1, '2026-01-01'),
(N'White Lily', N'Fresh seasonal flower', 2, 36.00, N'default.png', 1, '2026-01-03'),
(N'Yellow Tulip', N'Fresh seasonal flower', 3, 25.00, N'default.png', 1, '2026-01-05');
GO

/* ----------------------------
   采购订单表
   ---------------------------- */
CREATE TABLE dbo.PurchaseOrder (
    OrderID         INT IDENTITY(1,1) NOT NULL,
    OrderNo         NVARCHAR(30) NOT NULL,
    StoreID         INT NOT NULL,
    OrderDate       DATE NOT NULL,
    DeliveryDate    DATE NULL,
    TotalAmount     DECIMAL(12,2) NOT NULL CONSTRAINT DF_PurchaseOrder_TotalAmount DEFAULT 0,
    Status          NVARCHAR(30) NOT NULL CONSTRAINT DF_PurchaseOrder_Status DEFAULT N'Prepare',
    CONSTRAINT PK_PurchaseOrder PRIMARY KEY (OrderID),
    CONSTRAINT UQ_PurchaseOrder_OrderNo UNIQUE (OrderNo),
    CONSTRAINT CK_PurchaseOrder_TotalAmount CHECK (TotalAmount >= 0),
    CONSTRAINT CK_PurchaseOrder_Status CHECK (Status IN (N'Prepare', N'Pending Delivery', N'Completed')),
    CONSTRAINT FK_PurchaseOrder_Store FOREIGN KEY (StoreID) REFERENCES dbo.Store(StoreID)
);
GO

INSERT INTO dbo.PurchaseOrder(OrderNo, StoreID, OrderDate, DeliveryDate, TotalAmount, Status)
VALUES
(N'P20260001', 1, '2026-01-10', '2026-01-12', 92.00, N'Completed'),
(N'P20260002', 2, '2026-01-11', NULL, 128.00, N'Pending Delivery');
GO

/* ----------------------------
   采购订单明细表
   ---------------------------- */
CREATE TABLE dbo.PurchaseOrderDetail (
    DetailID    INT IDENTITY(1,1) NOT NULL,
    OrderID     INT NOT NULL,
    FlowerID    INT NOT NULL,
    Quantity    INT NOT NULL,
    UnitPrice   DECIMAL(10,2) NOT NULL,
    LineTotal   AS (CONVERT(DECIMAL(12,2), Quantity * UnitPrice)) PERSISTED,
    CONSTRAINT PK_PurchaseOrderDetail PRIMARY KEY (DetailID),
    CONSTRAINT CK_PurchaseOrderDetail_Quantity CHECK (Quantity > 0),
    CONSTRAINT CK_PurchaseOrderDetail_UnitPrice CHECK (UnitPrice >= 0),
    CONSTRAINT FK_PurchaseOrderDetail_PurchaseOrder FOREIGN KEY (OrderID) REFERENCES dbo.PurchaseOrder(OrderID) ON DELETE CASCADE,
    CONSTRAINT FK_PurchaseOrderDetail_Flower FOREIGN KEY (FlowerID) REFERENCES dbo.Flower(FlowerID)
);
GO

INSERT INTO dbo.PurchaseOrderDetail(OrderID, FlowerID, Quantity, UnitPrice)
VALUES
(1, 1, 2, 28.00),
(1, 2, 1, 36.00),
(2, 1, 4, 28.00),
(2, 3, 1, 25.00);
GO

/* ----------------------------
   购物车表 / 购物车明细表
   ---------------------------- */
CREATE TABLE dbo.Cart (
    CartID      INT IDENTITY(1,1) NOT NULL,
    StaffID     NVARCHAR(20) NOT NULL,
    CreatedAt   DATETIME NOT NULL CONSTRAINT DF_Cart_CreatedAt DEFAULT GETDATE(),
    CONSTRAINT PK_Cart PRIMARY KEY (CartID),
    CONSTRAINT FK_Cart_Staff FOREIGN KEY (StaffID) REFERENCES dbo.Staff(StaffID)
);
GO

CREATE TABLE dbo.CartItem (
    CartItemID  INT IDENTITY(1,1) NOT NULL,
    CartID      INT NOT NULL,
    FlowerID    INT NOT NULL,
    Quantity    INT NOT NULL,
    CONSTRAINT PK_CartItem PRIMARY KEY (CartItemID),
    CONSTRAINT CK_CartItem_Quantity CHECK (Quantity >= 1),
    CONSTRAINT FK_CartItem_Cart FOREIGN KEY (CartID) REFERENCES dbo.Cart(CartID) ON DELETE CASCADE,
    CONSTRAINT FK_CartItem_Flower FOREIGN KEY (FlowerID) REFERENCES dbo.Flower(FlowerID)
);
GO

/* ----------------------------
   索引
   ---------------------------- */
CREATE INDEX IX_Flower_CategoryID ON dbo.Flower(CategoryID);
CREATE INDEX IX_PurchaseOrder_Store_OrderDate ON dbo.PurchaseOrder(StoreID, OrderDate);
CREATE INDEX IX_PurchaseOrder_Status ON dbo.PurchaseOrder(Status);
CREATE INDEX IX_PurchaseOrderDetail_OrderID ON dbo.PurchaseOrderDetail(OrderID);
GO