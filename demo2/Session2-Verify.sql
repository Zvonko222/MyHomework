/* Run after Session2-MsSQL.sql. All result sets should report zero problems. */
USE [Session2];
GO
SET NOCOUNT ON;

SELECT N'TableCounts' AS CheckName,
       (SELECT COUNT(*) FROM dbo.Store) AS Stores,
       (SELECT COUNT(*) FROM dbo.StoreImages) AS StoreImages,
       (SELECT COUNT(*) FROM dbo.Role) AS Roles,
       (SELECT COUNT(*) FROM dbo.Staff) AS Staff,
       (SELECT COUNT(*) FROM dbo.ArrangementStation) AS Stations,
       (SELECT COUNT(*) FROM dbo.FlowerCategory) AS Categories,
       (SELECT COUNT(*) FROM dbo.Flower) AS Flowers,
       (SELECT COUNT(*) FROM dbo.OpenStation) AS OpenStations,
       (SELECT COUNT(*) FROM dbo.OrderFlowers) AS OrderLines;

SELECT N'InvalidActiveStationCount' AS CheckName, COUNT(*) AS ProblemCount
FROM dbo.OpenStation os
JOIN dbo.ArrangementStation s ON s.Id = os.StationId
WHERE os.IsCheckout = 0
  AND (s.IsEnable = 0 OR os.NumberOfPeople > s.MaximumPeople);

SELECT N'OrderTotalMismatchCount' AS CheckName, COUNT(*) AS ProblemCount
FROM
(
    SELECT os.Id,
           os.TotalAmount,
           SUM(f.Price * ofl.Number) AS CalculatedAmount
    FROM dbo.OpenStation os
    JOIN dbo.OrderFlowers ofl ON ofl.OpenStationId = os.Id
    JOIN dbo.Flower f ON f.Id = ofl.FlowerId
    GROUP BY os.Id, os.TotalAmount
) x
WHERE x.TotalAmount <> x.CalculatedAmount;

SELECT N'ExpectedImagePaths' AS CheckName, Src AS RelativePath
FROM dbo.StoreImages
UNION ALL
SELECT N'ExpectedImagePaths', Cover FROM dbo.Flower
UNION ALL
SELECT N'ExpectedImagePaths', COALESCE(Photo, N'Images/Staff/default.png') FROM dbo.Staff;
GO
