/* =========================================================
   WorldSkills China - Test Database
   SQL Server
   ========================================================= */

IF DB_ID('Session2') IS NULL
BEGIN
    CREATE DATABASE Session2;
END
GO

USE Session2;
GO

-- =========================================================
-- 1. 删除旧表
-- =========================================================

IF OBJECT_ID('dbo.ItemAttractions', 'U') IS NOT NULL
    DROP TABLE dbo.ItemAttractions;

IF OBJECT_ID('dbo.ItemAmenities', 'U') IS NOT NULL
    DROP TABLE dbo.ItemAmenities;

IF OBJECT_ID('dbo.Attractions', 'U') IS NOT NULL
    DROP TABLE dbo.Attractions;

IF OBJECT_ID('dbo.Items', 'U') IS NOT NULL
    DROP TABLE dbo.Items;

IF OBJECT_ID('dbo.Amenities', 'U') IS NOT NULL
    DROP TABLE dbo.Amenities;

IF OBJECT_ID('dbo.Areas', 'U') IS NOT NULL
    DROP TABLE dbo.Areas;

IF OBJECT_ID('dbo.ItemTypes', 'U') IS NOT NULL
    DROP TABLE dbo.ItemTypes;

IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
    DROP TABLE dbo.Users;

IF OBJECT_ID('dbo.UserTypes', 'U') IS NOT NULL
    DROP TABLE dbo.UserTypes;


-- =========================================================
-- 2. UserTypes
-- =========================================================

CREATE TABLE dbo.UserTypes
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Name NVARCHAR(50) NOT NULL
);


-- =========================================================
-- 3. Users
-- =========================================================

CREATE TABLE dbo.Users
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    UserTypeID INT NOT NULL,

    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    FullName NVARCHAR(100),
    Gender NVARCHAR(10),
    BirthDate DATE,
    FamilyCount INT,

    CONSTRAINT FK_Users_UserTypes
        FOREIGN KEY (UserTypeID)
        REFERENCES dbo.UserTypes(ID)
);


-- =========================================================
-- 4. ItemTypes
-- =========================================================

CREATE TABLE dbo.ItemTypes
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Name NVARCHAR(50) NOT NULL
);


-- =========================================================
-- 5. Areas
-- =========================================================

CREATE TABLE dbo.Areas
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Name NVARCHAR(100) NOT NULL
);


-- =========================================================
-- 6. Amenities
-- =========================================================

CREATE TABLE dbo.Amenities
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Name NVARCHAR(100) NOT NULL,
    IconName NVARCHAR(100)
);


-- =========================================================
-- 7. Attractions
-- =========================================================

CREATE TABLE dbo.Attractions
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    AreaID INT NOT NULL,

    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255),

    CONSTRAINT FK_Attractions_Areas
        FOREIGN KEY (AreaID)
        REFERENCES dbo.Areas(ID)
);


-- =========================================================
-- 8. Items
-- =========================================================

CREATE TABLE dbo.Items
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    UserID INT NOT NULL,
    ItemTypeID INT NOT NULL,
    AreaID INT NOT NULL,

    Title NVARCHAR(200) NOT NULL,

    Capacity INT,
    NumberOfBeds INT,
    NumberOfBedrooms INT,
    NumberOfBathrooms INT,

    ExactAddress NVARCHAR(255),
    ApproximateAddress NVARCHAR(255),

    Description NVARCHAR(MAX),
    HostRules NVARCHAR(MAX),

    MinimumNights INT,
    MaximumNights INT,

    CONSTRAINT FK_Items_Users
        FOREIGN KEY (UserID)
        REFERENCES dbo.Users(ID),

    CONSTRAINT FK_Items_ItemTypes
        FOREIGN KEY (ItemTypeID)
        REFERENCES dbo.ItemTypes(ID),

    CONSTRAINT FK_Items_Areas
        FOREIGN KEY (AreaID)
        REFERENCES dbo.Areas(ID)
);


-- =========================================================
-- 9. ItemAmenities
-- =========================================================

CREATE TABLE dbo.ItemAmenities
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    ItemID INT NOT NULL,
    AmenityID INT NOT NULL,

    CONSTRAINT FK_ItemAmenities_Items
        FOREIGN KEY (ItemID)
        REFERENCES dbo.Items(ID),

    CONSTRAINT FK_ItemAmenities_Amenities
        FOREIGN KEY (AmenityID)
        REFERENCES dbo.Amenities(ID)
);


-- =========================================================
-- 10. ItemAttractions
-- =========================================================

CREATE TABLE dbo.ItemAttractions
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    GUID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    ItemID INT NOT NULL,
    AttractionID INT NOT NULL,

    Distance DECIMAL(10,2),
    DurationOnFoot INT,
    DurationByCar INT,

    CONSTRAINT FK_ItemAttractions_Items
        FOREIGN KEY (ItemID)
        REFERENCES dbo.Items(ID),

    CONSTRAINT FK_ItemAttractions_Attractions
        FOREIGN KEY (AttractionID)
        REFERENCES dbo.Attractions(ID)
);


-- =========================================================
-- 11. UserTypes 测试数据
-- =========================================================

INSERT INTO dbo.UserTypes
    (Name)
VALUES
    (N'Guest'),
    (N'Host'),
    (N'Administrator');


-- =========================================================
-- 12. Users 测试数据
-- =========================================================

INSERT INTO dbo.Users
    (UserTypeID, Username, Password, FullName, Gender, BirthDate, FamilyCount)
VALUES
    (1, N'zhangsan', N'123456', N'张三', N'Male', '2002-05-10', 3),
    (1, N'lisi', N'123456', N'李四', N'Male', '2001-08-15', 2),
    (2, N'wangwu', N'123456', N'王五', N'Male', '1995-03-20', 4),
    (2, N'zhaoliu', N'123456', N'赵六', N'Female', '1997-11-08', 2),
    (3, N'admin', N'admin123', N'管理员', N'Male', '1990-01-01', 1);


-- =========================================================
-- 13. ItemTypes 测试数据
-- =========================================================

INSERT INTO dbo.ItemTypes
    (Name)
VALUES
    (N'Apartment'),
    (N'House'),
    (N'Hotel'),
    (N'Guesthouse'),
    (N'Villa');


-- =========================================================
-- 14. Areas 测试数据
-- =========================================================

INSERT INTO dbo.Areas
    (Name)
VALUES
    (N'Beijing'),
    (N'Shanghai'),
    (N'Guangzhou'),
    (N'Shenzhen'),
    (N'Hangzhou');


-- =========================================================
-- 15. Amenities 测试数据
-- =========================================================

INSERT INTO dbo.Amenities
    (Name, IconName)
VALUES
    (N'WiFi', N'wifi'),
    (N'Air Conditioning', N'air_conditioner'),
    (N'TV', N'tv'),
    (N'Kitchen', N'kitchen'),
    (N'Washing Machine', N'washing_machine'),
    (N'Parking', N'parking'),
    (N'Swimming Pool', N'swimming_pool'),
    (N'Heating', N'heating'),
    (N'Breakfast', N'breakfast'),
    (N'Elevator', N'elevator');


-- =========================================================
-- 16. Attractions 测试数据
-- =========================================================

INSERT INTO dbo.Attractions
    (AreaID, Name, Address)
VALUES
    (1, N'The Palace Museum', N'Beijing Dongcheng District'),
    (1, N'Tiananmen Square', N'Beijing Dongcheng District'),
    (1, N'The Great Wall', N'Beijing Huairou District'),

    (2, N'The Bund', N'Shanghai Huangpu District'),
    (2, N'Oriental Pearl Tower', N'Shanghai Pudong District'),
    (2, N'Yu Garden', N'Shanghai Huangpu District'),

    (3, N'Canton Tower', N'Guangzhou Haizhu District'),
    (3, N'Chimelong Paradise', N'Guangzhou Panyu District'),

    (4, N'Window of the World', N'Shenzhen Nanshan District'),
    (4, N'Splendid China', N'Shenzhen Nanshan District'),

    (5, N'West Lake', N'Hangzhou Xihu District'),
    (5, N'Lingyin Temple', N'Hangzhou Xihu District');


-- =========================================================
-- 17. Items 测试数据
-- =========================================================

INSERT INTO dbo.Items
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
    1,
    N'Cozy Apartment Near Tiananmen',
    4,
    2,
    2,
    1,
    N'北京市东城区某街道88号',
    N'Near Tiananmen Square',
    N'Comfortable apartment suitable for families and tourists.',
    N'No smoking. Keep quiet after 10 PM.',
    1,
    30
),

(
    3,
    2,
    1,
    N'Beijing Traditional Courtyard House',
    6,
    3,
    3,
    2,
    N'北京市东城区某胡同18号',
    N'Near the Forbidden City',
    N'Traditional Beijing courtyard house with modern facilities.',
    N'No parties. No pets.',
    2,
    60
),

(
    4,
    3,
    2,
    N'Shanghai City Center Hotel',
    2,
    1,
    1,
    1,
    N'上海市黄浦区某路168号',
    N'Near The Bund',
    N'Modern hotel room in the center of Shanghai.',
    N'No smoking.',
    1,
    20
),

(
    4,
    1,
    2,
    N'Luxury Apartment Near The Bund',
    4,
    2,
    2,
    2,
    N'上海市黄浦区某路66号',
    N'Near The Bund',
    N'Luxury apartment with excellent city views.',
    N'No parties. No smoking.',
    1,
    30
),

(
    3,
    5,
    5,
    N'Hangzhou West Lake Villa',
    8,
    4,
    4,
    3,
    N'杭州市西湖区某路99号',
    N'Near West Lake',
    N'Large villa suitable for families and groups.',
    N'Keep the property clean.',
    2,
    90
),

(
    4,
    4,
    4,
    N'Shenzhen Comfortable Guesthouse',
    3,
    2,
    1,
    1,
    N'深圳市南山区某路28号',
    N'Near Window of the World',
    N'Affordable guesthouse for short trips.',
    N'No smoking. No parties.',
    1,
    15
);


-- =========================================================
-- 18. ItemAmenities 测试数据
-- =========================================================

-- Item 1
INSERT INTO dbo.ItemAmenities
    (ItemID, AmenityID)
VALUES
    (1, 1), -- WiFi
    (1, 2), -- Air Conditioning
    (1, 3), -- TV
    (1, 4), -- Kitchen
    (1, 5), -- Washing Machine
    (1, 10); -- Elevator


-- Item 2
INSERT INTO dbo.ItemAmenities
    (ItemID, AmenityID)
VALUES
    (2, 1),
    (2, 2),
    (2, 3),
    (2, 4),
    (2, 6);


-- Item 3
INSERT INTO dbo.ItemAmenities
    (ItemID, AmenityID)
VALUES
    (3, 1),
    (3, 2),
    (3, 3),
    (3, 9),
    (3, 10);


-- Item 4
INSERT INTO dbo.ItemAmenities
    (ItemID, AmenityID)
VALUES
    (4, 1),
    (4, 2),
    (4, 3),
    (4, 4),
    (4, 5),
    (4, 6),
    (4, 10);


-- Item 5
INSERT INTO dbo.ItemAmenities
    (ItemID, AmenityID)
VALUES
    (5, 1),
    (5, 2),
    (5, 3),
    (5, 4),
    (5, 5),
    (5, 6),
    (5, 7);


-- Item 6
INSERT INTO dbo.ItemAmenities
    (ItemID, AmenityID)
VALUES
    (6, 1),
    (6, 2),
    (6, 3),
    (6, 6);


-- =========================================================
-- 19. ItemAttractions 测试数据
-- =========================================================

-- Beijing Item 1
INSERT INTO dbo.ItemAttractions
    (ItemID, AttractionID, Distance, DurationOnFoot, DurationByCar)
VALUES
    (1, 1, 1.20, 15, 5),
    (1, 2, 0.80, 10, 4),
    (1, 3, 65.00, 900, 80);


-- Beijing Item 2
INSERT INTO dbo.ItemAttractions
    (ItemID, AttractionID, Distance, DurationOnFoot, DurationByCar)
VALUES
    (2, 1, 1.50, 20, 6),
    (2, 2, 1.00, 13, 5),
    (2, 3, 70.00, 950, 85);


-- Shanghai Item 3
INSERT INTO dbo.ItemAttractions
    (ItemID, AttractionID, Distance, DurationOnFoot, DurationByCar)
VALUES
    (3, 4, 0.50, 7, 3),
    (3, 5, 1.20, 15, 5),
    (3, 6, 2.00, 25, 8);


-- Shanghai Item 4
INSERT INTO dbo.ItemAttractions
    (ItemID, AttractionID, Distance, DurationOnFoot, DurationByCar)
VALUES
    (4, 4, 0.30, 4, 2),
    (4, 5, 1.00, 12, 5),
    (4, 6, 1.80, 22, 7);


-- Hangzhou Item 5
INSERT INTO dbo.ItemAttractions
    (ItemID, AttractionID, Distance, DurationOnFoot, DurationByCar)
VALUES
    (5, 11, 1.00, 13, 5),
    (5, 12, 3.50, 45, 12);


-- Shenzhen Item 6
INSERT INTO dbo.ItemAttractions
    (ItemID, AttractionID, Distance, DurationOnFoot, DurationByCar)
VALUES
    (6, 9, 0.80, 10, 4),
    (6, 10, 2.00, 25, 8);


