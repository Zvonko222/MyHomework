USE Session1;
GO

/* 清空表，注意外键顺序 */
DELETE FROM dbo.CartItem;
DELETE FROM dbo.Cart;
DELETE FROM dbo.PurchaseOrderDetail;
DELETE FROM dbo.PurchaseOrder;
DELETE FROM dbo.Flower;
DELETE FROM dbo.FlowerCategory;
DELETE FROM dbo.Staff;
DELETE FROM dbo.Store;
DELETE FROM dbo.StaffRole;
GO

/* 重置标识列 */
DBCC CHECKIDENT ('dbo.CartItem', RESEED, 0);
DBCC CHECKIDENT ('dbo.Cart', RESEED, 0);
DBCC CHECKIDENT ('dbo.PurchaseOrderDetail', RESEED, 0);
DBCC CHECKIDENT ('dbo.PurchaseOrder', RESEED, 0);
DBCC CHECKIDENT ('dbo.Flower', RESEED, 0);
DBCC CHECKIDENT ('dbo.FlowerCategory', RESEED, 0);
DBCC CHECKIDENT ('dbo.StaffRole', RESEED, 0);
GO

/* 1. StaffRole 20条，显式指定 RoleID */
SET IDENTITY_INSERT dbo.StaffRole ON;
INSERT INTO dbo.StaffRole(RoleID, RoleName) VALUES
(1, N'Store Manager'),
(2, N'Central Greenhouse Manager'),
(3, N'Role03'), (4, N'Role04'), (5, N'Role05'),
(6, N'Role06'), (7, N'Role07'), (8, N'Role08'), (9, N'Role09'), (10, N'Role10'),
(11, N'Role11'), (12, N'Role12'), (13, N'Role13'), (14, N'Role14'), (15, N'Role15'),
(16, N'Role16'), (17, N'Role17'), (18, N'Role18'), (19, N'Role19'), (20, N'Role20');
SET IDENTITY_INSERT dbo.StaffRole OFF;
GO

/* 2. Store 20条，显式指定 StoreID */
SET IDENTITY_INSERT dbo.Store ON;
INSERT INTO dbo.Store(StoreID, StoreName, Address) VALUES
(1, N'Store01', N'Address01'),
(2, N'Store02', N'Address02'),
(3, N'Store03', N'Address03'),
(4, N'Store04', N'Address04'),
(5, N'Store05', N'Address05'),
(6, N'Store06', N'Address06'),
(7, N'Store07', N'Address07'),
(8, N'Store08', N'Address08'),
(9, N'Store09', N'Address09'),
(10, N'Store10', N'Address10'),
(11, N'Store11', N'Address11'),
(12, N'Store12', N'Address12'),
(13, N'Store13', N'Address13'),
(14, N'Store14', N'Address14'),
(15, N'Store15', N'Address15'),
(16, N'Store16', N'Address16'),
(17, N'Store17', N'Address17'),
(18, N'Store18', N'Address18'),
(19, N'Store19', N'Address19'),
(20, N'Store20', N'Address20');
SET IDENTITY_INSERT dbo.Store OFF;
GO

/* 3. Staff 20条，RoleID 引用 1..20，StoreID 引用 1..20 */
INSERT INTO dbo.Staff(StaffID, Password, FullName, RoleID, StoreID, Avatar) VALUES
(N'S000001', N'123456', N'Staff01', 1, 1, NULL),
(N'S000002', N'123456', N'Staff02', 2, 2, NULL),
(N'S000003', N'123456', N'Staff03', 3, 3, NULL),
(N'S000004', N'123456', N'Staff04', 4, 4, NULL),
(N'S000005', N'123456', N'Staff05', 5, 5, NULL),
(N'S000006', N'123456', N'Staff06', 6, 6, NULL),
(N'S000007', N'123456', N'Staff07', 7, 7, NULL),
(N'S000008', N'123456', N'Staff08', 8, 8, NULL),
(N'S000009', N'123456', N'Staff09', 9, 9, NULL),
(N'S000010', N'123456', N'Staff10', 10, 10, NULL),
(N'S000011', N'123456', N'Staff11', 11, 11, NULL),
(N'S000012', N'123456', N'Staff12', 12, 12, NULL),
(N'S000013', N'123456', N'Staff13', 13, 13, NULL),
(N'S000014', N'123456', N'Staff14', 14, 14, NULL),
(N'S000015', N'123456', N'Staff15', 15, 15, NULL),
(N'S000016', N'123456', N'Staff16', 16, 16, NULL),
(N'S000017', N'123456', N'Staff17', 17, 17, NULL),
(N'S000018', N'123456', N'Staff18', 18, 18, NULL),
(N'S000019', N'123456', N'Staff19', 19, 19, NULL),
(N'S000020', N'123456', N'Staff20', 20, 20, NULL);
GO

/* 4. FlowerCategory 20条，显式指定 CategoryID */
SET IDENTITY_INSERT dbo.FlowerCategory ON;
INSERT INTO dbo.FlowerCategory(CategoryID, CategoryName) VALUES
(1, N'Rose'), (2, N'Lily'), (3, N'Tulip'), (4, N'Category04'), (5, N'Category05'),
(6, N'Category06'), (7, N'Category07'), (8, N'Category08'), (9, N'Category09'), (10, N'Category10'),
(11, N'Category11'), (12, N'Category12'), (13, N'Category13'), (14, N'Category14'), (15, N'Category15'),
(16, N'Category16'), (17, N'Category17'), (18, N'Category18'), (19, N'Category19'), (20, N'Category20');
SET IDENTITY_INSERT dbo.FlowerCategory OFF;
GO

/* 5. Flower 20条，显式指定 FlowerID，CategoryID 引用 1..20 */
SET IDENTITY_INSERT dbo.Flower ON;
INSERT INTO dbo.Flower(FlowerID, FlowerName, Description, CategoryID, UnitPrice, CoverImage, IsAvailable, ReleaseDate) VALUES
(1, N'Flower01', N'Description01', 1, 28.00, N'default.png', 1, '2026-01-01'),
(2, N'Flower02', N'Description02', 2, 36.00, N'default.png', 1, '2026-01-02'),
(3, N'Flower03', N'Description03', 3, 25.00, N'default.png', 1, '2026-01-03'),
(4, N'Flower04', N'Description04', 4, 30.00, N'default.png', 1, '2026-01-04'),
(5, N'Flower05', N'Description05', 5, 32.00, N'default.png', 1, '2026-01-05'),
(6, N'Flower06', N'Description06', 6, 33.00, N'default.png', 1, '2026-01-06'),
(7, N'Flower07', N'Description07', 7, 34.00, N'default.png', 1, '2026-01-07'),
(8, N'Flower08', N'Description08', 8, 35.00, N'default.png', 1, '2026-01-08'),
(9, N'Flower09', N'Description09', 9, 36.00, N'default.png', 1, '2026-01-09'),
(10, N'Flower10', N'Description10', 10, 37.00, N'default.png', 1, '2026-01-10'),
(11, N'Flower11', N'Description11', 11, 38.00, N'default.png', 1, '2026-01-11'),
(12, N'Flower12', N'Description12', 12, 39.00, N'default.png', 1, '2026-01-12'),
(13, N'Flower13', N'Description13', 13, 40.00, N'default.png', 1, '2026-01-13'),
(14, N'Flower14', N'Description14', 14, 41.00, N'default.png', 1, '2026-01-14'),
(15, N'Flower15', N'Description15', 15, 42.00, N'default.png', 1, '2026-01-15'),
(16, N'Flower16', N'Description16', 16, 43.00, N'default.png', 1, '2026-01-16'),
(17, N'Flower17', N'Description17', 17, 44.00, N'default.png', 1, '2026-01-17'),
(18, N'Flower18', N'Description18', 18, 45.00, N'default.png', 1, '2026-01-18'),
(19, N'Flower19', N'Description19', 19, 46.00, N'default.png', 1, '2026-01-19'),
(20, N'Flower20', N'Description20', 20, 47.00, N'default.png', 1, '2026-01-20');
SET IDENTITY_INSERT dbo.Flower OFF;
GO

/* 6. PurchaseOrder 20条，显式指定 OrderID，StoreID 引用 1..20 */
SET IDENTITY_INSERT dbo.PurchaseOrder ON;
INSERT INTO dbo.PurchaseOrder(OrderID, OrderNo, StoreID, OrderDate, DeliveryDate, TotalAmount, Status) VALUES
(1, N'P20260001', 1, '2026-01-10', '2026-01-12', 92.00, N'Completed'),
(2, N'P20260002', 2, '2026-01-11', '2026-01-13', 128.00, N'Pending Delivery'),
(3, N'P20260003', 3, '2026-01-12', '2026-01-14', 150.00, N'Prepare'),
(4, N'P20260004', 4, '2026-01-13', '2026-01-15', 200.00, N'Completed'),
(5, N'P20260005', 5, '2026-01-14', '2026-01-16', 180.00, N'Pending Delivery'),
(6, N'P20260006', 6, '2026-01-15', '2026-01-17', 220.00, N'Prepare'),
(7, N'P20260007', 7, '2026-01-16', '2026-01-18', 240.00, N'Completed'),
(8, N'P20260008', 8, '2026-01-17', '2026-01-19', 260.00, N'Pending Delivery'),
(9, N'P20260009', 9, '2026-01-18', '2026-01-20', 280.00, N'Prepare'),
(10, N'P20260010', 10, '2026-01-19', '2026-01-21', 300.00, N'Completed'),
(11, N'P20260011', 11, '2026-01-20', '2026-01-22', 320.00, N'Pending Delivery'),
(12, N'P20260012', 12, '2026-01-21', '2026-01-23', 340.00, N'Prepare'),
(13, N'P20260013', 13, '2026-01-22', '2026-01-24', 360.00, N'Completed'),
(14, N'P20260014', 14, '2026-01-23', '2026-01-25', 380.00, N'Pending Delivery'),
(15, N'P20260015', 15, '2026-01-24', '2026-01-26', 400.00, N'Prepare'),
(16, N'P20260016', 16, '2026-01-25', '2026-01-27', 420.00, N'Completed'),
(17, N'P20260017', 17, '2026-01-26', '2026-01-28', 440.00, N'Pending Delivery'),
(18, N'P20260018', 18, '2026-01-27', '2026-01-29', 460.00, N'Prepare'),
(19, N'P20260019', 19, '2026-01-28', '2026-01-30', 480.00, N'Completed'),
(20, N'P20260020', 20, '2026-01-29', '2026-01-31', 500.00, N'Pending Delivery');
SET IDENTITY_INSERT dbo.PurchaseOrder OFF;
GO

/* 7. PurchaseOrderDetail 20条，OrderID 引用 1..20，FlowerID 引用 1..20 */
INSERT INTO dbo.PurchaseOrderDetail(OrderID, FlowerID, Quantity, UnitPrice) VALUES
(1, 1, 2, 28.00),
(2, 2, 1, 36.00),
(3, 3, 3, 25.00),
(4, 4, 2, 30.00),
(5, 5, 1, 32.00),
(6, 6, 4, 33.00),
(7, 7, 2, 34.00),
(8, 8, 3, 35.00),
(9, 9, 1, 36.00),
(10, 10, 5, 37.00),
(11, 11, 2, 38.00),
(12, 12, 1, 39.00),
(13, 13, 3, 40.00),
(14, 14, 2, 41.00),
(15, 15, 1, 42.00),
(16, 16, 4, 43.00),
(17, 17, 2, 44.00),
(18, 18, 3, 45.00),
(19, 19, 1, 46.00),
(20, 20, 5, 47.00);
GO

/* 8. Cart 20条，显式指定 CartID，StaffID 引用 S000001..S000020 */
SET IDENTITY_INSERT dbo.Cart ON;
INSERT INTO dbo.Cart(CartID, StaffID, CreatedAt) VALUES
(1, N'S000001', GETDATE()), (2, N'S000002', GETDATE()), (3, N'S000003', GETDATE()), (4, N'S000004', GETDATE()), (5, N'S000005', GETDATE()),
(6, N'S000006', GETDATE()), (7, N'S000007', GETDATE()), (8, N'S000008', GETDATE()), (9, N'S000009', GETDATE()), (10, N'S000010', GETDATE()),
(11, N'S000011', GETDATE()), (12, N'S000012', GETDATE()), (13, N'S000013', GETDATE()), (14, N'S000014', GETDATE()), (15, N'S000015', GETDATE()),
(16, N'S000016', GETDATE()), (17, N'S000017', GETDATE()), (18, N'S000018', GETDATE()), (19, N'S000019', GETDATE()), (20, N'S000020', GETDATE());
SET IDENTITY_INSERT dbo.Cart OFF;
GO

/* 9. CartItem 20条，CartID 引用 1..20，FlowerID 引用 1..20 */
INSERT INTO dbo.CartItem(CartID, FlowerID, Quantity) VALUES
(1, 1, 2),
(2, 2, 1),
(3, 3, 3),
(4, 4, 2),
(5, 5, 1),
(6, 6, 4),
(7, 7, 2),
(8, 8, 3),
(9, 9, 1),
(10, 10, 5),
(11, 11, 2),
(12, 12, 1),
(13, 13, 3),
(14, 14, 2),
(15, 15, 1),
(16, 16, 4),
(17, 17, 2),
(18, 18, 3),
(19, 19, 1),
(20, 20, 5);
GO

/* 调整标识列到当前最大值 */
DBCC CHECKIDENT ('dbo.StaffRole', RESEED);
DBCC CHECKIDENT ('dbo.Store', RESEED);
DBCC CHECKIDENT ('dbo.FlowerCategory', RESEED);
DBCC CHECKIDENT ('dbo.Flower', RESEED);
DBCC CHECKIDENT ('dbo.PurchaseOrder', RESEED);
DBCC CHECKIDENT ('dbo.Cart', RESEED);
DBCC CHECKIDENT ('dbo.CartItem', RESEED);
DBCC CHECKIDENT ('dbo.PurchaseOrderDetail', RESEED);
GO