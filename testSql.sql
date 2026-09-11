/* =========================================================
   1. 创建数据库
   ========================================================= */

IF DB_ID('WorldSkillsBooking') IS NULL
BEGIN
    CREATE DATABASE WorldSkillsBooking;
END
GO

USE WorldSkillsBooking;
GO


/* =========================================================
   2. 删除旧表
   为了方便反复测试
   ========================================================= */

DROP TABLE IF EXISTS BookingDetails;
DROP TABLE IF EXISTS ItemPrices;
DROP TABLE IF EXISTS CancellationRefundFees;
DROP TABLE IF EXISTS CancellationPolicies;
DROP TABLE IF EXISTS Items;
DROP TABLE IF EXISTS ItemTypes;
DROP TABLE IF EXISTS Bookings;
DROP TABLE IF EXISTS Coupons;
DROP TABLE IF EXISTS Transactions;
DROP TABLE IF EXISTS TransactionTypes;
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS UserTypes;
DROP TABLE IF EXISTS DimDates;
GO


/* =========================================================
   3. UserTypes
   ========================================================= */

CREATE TABLE UserTypes
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Name NVARCHAR(50) NOT NULL
);
GO


/* =========================================================
   4. Users
   ========================================================= */

CREATE TABLE Users
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    UserTypeID INT NOT NULL,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100),
    Gender NVARCHAR(10),
    BirthDate DATE,
    FamilyCount INT,

    CONSTRAINT FK_Users_UserTypes
        FOREIGN KEY (UserTypeID)
        REFERENCES UserTypes(ID)
);
GO


/* =========================================================
   5. TransactionTypes
   ========================================================= */

CREATE TABLE TransactionTypes
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Name NVARCHAR(50) NOT NULL
);
GO


/* =========================================================
   6. Transactions
   ========================================================= */

CREATE TABLE Transactions
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    UserID INT,
    TransactionTypeID INT NOT NULL,

    Amount DECIMAL(18,2) NOT NULL,
    TransactionDate DATETIME2(0) NOT NULL,
    GatewayReturnID NVARCHAR(100),

    CONSTRAINT FK_Transactions_Users
        FOREIGN KEY (UserID)
        REFERENCES Users(ID),

    CONSTRAINT FK_Transactions_TransactionTypes
        FOREIGN KEY (TransactionTypeID)
        REFERENCES TransactionTypes(ID)
);
GO


/* =========================================================
   7. Coupons
   ========================================================= */

CREATE TABLE Coupons
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    CouponCode NVARCHAR(50) NOT NULL,
    DiscountPercent DECIMAL(5,2),
    MaximinDiscountAmount DECIMAL(18,2)
);
GO


/* =========================================================
   8. Bookings
   ========================================================= */

CREATE TABLE Bookings
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    UserID INT NOT NULL,
    BookingDate DATETIME2(0) NOT NULL,

    CouponID INT NULL,
    TransactionID INT NULL,

    AmountPaid DECIMAL(18,2) NOT NULL,

    CONSTRAINT FK_Bookings_Users
        FOREIGN KEY (UserID)
        REFERENCES Users(ID),

    CONSTRAINT FK_Bookings_Coupons
        FOREIGN KEY (CouponID)
        REFERENCES Coupons(ID),

    CONSTRAINT FK_Bookings_Transactions
        FOREIGN KEY (TransactionID)
        REFERENCES Transactions(ID)
);
GO


/* =========================================================
   9. ItemTypes
   ========================================================= */

CREATE TABLE ItemTypes
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Name NVARCHAR(50) NOT NULL
);
GO


/* =========================================================
   10. Items
   ========================================================= */

CREATE TABLE Items
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    UserID INT NOT NULL,
    ItemTypeID INT NOT NULL,

    AreaID INT,

    Title NVARCHAR(200) NOT NULL,
    Capacity INT,
    NumberOfBeds INT,
    NumberOfBedrooms INT,
    NumberOfBathrooms INT,

    ExactAddress NVARCHAR(500),
    ApproximateAddress NVARCHAR(500),

    Description NVARCHAR(MAX),
    HostRules NVARCHAR(MAX),

    MinimumNights INT,
    MaximumNights INT,

    CONSTRAINT FK_Items_Users
        FOREIGN KEY (UserID)
        REFERENCES Users(ID),

    CONSTRAINT FK_Items_ItemTypes
        FOREIGN KEY (ItemTypeID)
        REFERENCES ItemTypes(ID)
);
GO


/* =========================================================
   11. CancellationPolicies
   ========================================================= */

CREATE TABLE CancellationPolicies
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Name NVARCHAR(100) NOT NULL
);
GO


/* =========================================================
   12. CancellationRefundFees
   ========================================================= */

CREATE TABLE CancellationRefundFees
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    CancellationPolicyID INT NOT NULL,
    DaysLeft INT NOT NULL,
    PenaltyPercentage DECIMAL(5,2) NOT NULL,

    CONSTRAINT FK_CancellationRefundFees_Policies
        FOREIGN KEY (CancellationPolicyID)
        REFERENCES CancellationPolicies(ID)
);
GO


/* =========================================================
   13. ItemPrices
   ========================================================= */

CREATE TABLE ItemPrices
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    ItemID INT NOT NULL,
    Date DATE NOT NULL,
    Price DECIMAL(18,2) NOT NULL,

    CancellationPolicyID INT NOT NULL,

    CONSTRAINT FK_ItemPrices_Items
        FOREIGN KEY (ItemID)
        REFERENCES Items(ID),

    CONSTRAINT FK_ItemPrices_CancellationPolicies
        FOREIGN KEY (CancellationPolicyID)
        REFERENCES CancellationPolicies(ID)
);
GO


/* =========================================================
   14. BookingDetails
   ========================================================= */

CREATE TABLE BookingDetails
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    BookingID INT NOT NULL,
    ItemPriceID INT NOT NULL,

    IsRefund BIT NOT NULL DEFAULT 0,
    RefundDate DATETIME2(0) NULL,
    RefundCancellationPolicyID INT NULL,

    CONSTRAINT FK_BookingDetails_Bookings
        FOREIGN KEY (BookingID)
        REFERENCES Bookings(ID),

    CONSTRAINT FK_BookingDetails_ItemPrices
        FOREIGN KEY (ItemPriceID)
        REFERENCES ItemPrices(ID)
);
GO


/* =========================================================
   15. DimDates
   ========================================================= */

CREATE TABLE DimDates
(
    ID INT IDENTITY(1,1) PRIMARY KEY,

    [Date] DATE NOT NULL,
    [Year] INT,
    [Quarter] INT,
    [Month] INT,
    MonthName NVARCHAR(20),

    DayOfMonth INT,
    DayOfWeek INT,
    DayName NVARCHAR(20),

    IsHoliday BIT NOT NULL DEFAULT 0
);
GO


/* =========================================================
   16. 插入 UserTypes
   !!! 原脚本缺少这里
   ========================================================= */

INSERT INTO UserTypes
(
    Name
)
VALUES
(N'Guest'),
(N'Host');
GO


/* =========================================================
   17. 插入 Users
   ========================================================= */

INSERT INTO Users
(
    UserTypeID,
    Username,
    Password,
    FullName,
    Gender,
    BirthDate,
    FamilyCount
)
VALUES
(1, N'zhangsan', N'123456', N'张三', N'Male', '2002-05-10', 3),
(1, N'lisi', N'123456', N'李四', N'Female', '2001-08-20', 2),
(2, N'wangwu', N'123456', N'王五', N'Male', '1995-03-15', 4),
(2, N'zhaoliu', N'123456', N'赵六', N'Female', '1998-11-02', 2);
GO


/* =========================================================
   18. TransactionTypes
   ========================================================= */

INSERT INTO TransactionTypes
(
    Name
)
VALUES
(N'Payment'),
(N'Refund'),
(N'Deposit');
GO


/* =========================================================
   19. Transactions
   ========================================================= */

INSERT INTO Transactions
(
    UserID,
    TransactionTypeID,
    Amount,
    TransactionDate,
    GatewayReturnID
)
VALUES
(1, 1, 538.20, '2026-09-01 10:30:00', N'PAY202609010001'),
(2, 1, 719.20, '2026-09-02 14:20:00', N'PAY202609020001'),
(1, 2, 100.00, '2026-09-03 09:15:00', N'REF202609030001');
GO


/* =========================================================
   20. Coupons
   ========================================================= */

INSERT INTO Coupons
(
    CouponCode,
    DiscountPercent,
    MaximinDiscountAmount
)
VALUES
(N'WELCOME10', 10.00, 100.00),
(N'SUMMER20', 20.00, 200.00),
(N'VIP30', 30.00, 300.00);
GO


/* =========================================================
   21. ItemTypes
   ========================================================= */

INSERT INTO ItemTypes
(
    Name
)
VALUES
(N'Hotel'),
(N'Apartment'),
(N'Villa'),
(N'Guesthouse');
GO


/* =========================================================
   22. Items
   ========================================================= */

INSERT INTO Items
(
    UserID,
    ItemTypeID,
    AreaID,
    Title,
    Capacity,
    NumberOfBeds,
    NumberOfBedrooms,
    NumberOfBathrooms,
    ExactAddress,
    ApproximateAddress,
    Description,
    HostRules,
    MinimumNights,
    MaximumNights
)
VALUES
(
    3,
    1,
    1001,
    N'上海豪华酒店大床房',
    2,
    1,
    1,
    1,
    N'上海市黄浦区南京东路100号',
    N'人民广场附近',
    N'豪华大床房，提供早餐和免费WiFi',
    N'禁止吸烟，禁止携带宠物',
    1,
    30
),
(
    3,
    2,
    1002,
    N'上海市中心精品公寓',
    4,
    2,
    2,
    1,
    N'上海市静安区南京西路200号',
    N'静安寺附近',
    N'两室一厅精品公寓',
    N'保持室内卫生，禁止举办大型聚会',
    2,
    60
),
(
    4,
    3,
    1003,
    N'杭州西湖景区别墅',
    6,
    3,
    3,
    2,
    N'杭州市西湖区西湖大道300号',
    N'西湖景区附近',
    N'适合家庭旅行的独栋别墅',
    N'禁止吸烟',
    2,
    15
);
GO


/* =========================================================
   23. CancellationPolicies
   ========================================================= */

INSERT INTO CancellationPolicies
(
    Name
)
VALUES
(N'Flexible'),
(N'Moderate'),
(N'Strict');
GO


/* =========================================================
   24. CancellationRefundFees
   ========================================================= */

INSERT INTO CancellationRefundFees
(
    CancellationPolicyID,
    DaysLeft,
    PenaltyPercentage
)
VALUES
(1, 7, 0.00),
(1, 3, 10.00),
(2, 7, 20.00),
(2, 3, 50.00),
(3, 7, 50.00),
(3, 3, 100.00);
GO


/* =========================================================
   25. ItemPrices
   ========================================================= */

INSERT INTO ItemPrices
(
    ItemID,
    Date,
    Price,
    CancellationPolicyID
)
VALUES
(1, '2026-09-10', 299.00, 1),
(1, '2026-09-11', 299.00, 1),
(1, '2026-09-12', 399.00, 2),

(2, '2026-09-10', 499.00, 2),
(2, '2026-09-11', 499.00, 2),
(2, '2026-09-12', 599.00, 3),

(3, '2026-09-10', 899.00, 3),
(3, '2026-09-11', 899.00, 3);
GO


/* =========================================================
   26. Bookings
   ========================================================= */

INSERT INTO Bookings
(
    UserID,
    BookingDate,
    CouponID,
    TransactionID,
    AmountPaid
)
VALUES
(
    1,
    '2026-09-01 10:35:00',
    1,
    1,
    538.20
),
(
    2,
    '2026-09-02 14:25:00',
    2,
    2,
    798.40
);
GO


/* =========================================================
   27. BookingDetails
   ========================================================= */

INSERT INTO BookingDetails
(
    BookingID,
    ItemPriceID,
    IsRefund,
    RefundDate,
    RefundCancellationPolicyID
)
VALUES
(
    1,
    1,
    0,
    NULL,
    NULL
),
(
    1,
    2,
    0,
    NULL,
    NULL
),
(
    2,
    4,
    0,
    NULL,
    NULL
),
(
    2,
    5,
    0,
    NULL,
    NULL
);
GO


/* =========================================================
   28. DimDates
   ========================================================= */

INSERT INTO DimDates
(
    [Date],
    [Year],
    [Quarter],
    [Month],
    MonthName,
    DayOfMonth,
    DayOfWeek,
    DayName,
    IsHoliday
)
VALUES
('2026-09-10', 2026, 3, 9, N'September', 10, 4, N'Thursday', 0),
('2026-09-11', 2026, 3, 9, N'September', 11, 5, N'Friday', 0),
('2026-09-12', 2026, 3, 9, N'September', 12, 6, N'Saturday', 0),
('2026-10-01', 2026, 4, 10, N'October', 1, 4, N'Thursday', 1);
GO