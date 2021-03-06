USE [QuickStart_DB]
GO
/****** Object:  StoredProcedure [dbo].[spGetInvoiceItemsByOrderID]    Script Date: 07/30/2013 14:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
IF OBJECT_ID('[dbo].[spGetInvoiceItemsByOrderID]') IS NOT NULL
	DROP PROCEDURE [dbo].[spGetInvoiceItemsByOrderID]
GO
CREATE PROCEDURE [dbo].[spGetInvoiceItemsByOrderID]
@orderid INT
AS
BEGIN
SELECT oi.OrderItemID AS OrderItemID, o.OrderID AS OrderID, oi.ProductCode AS ProductCode, 
  p.Name AS ProductName, p.Description AS ProductDescription, p.MSRP AS MSRP, oi.Quantity AS Quantity, p.isTaxFree AS IsTaxFree,
  ((stpr.TaxRatePercentage/100)*(p.MSRP*oi.Quantity)) AS TaxAmount
FROM OrderItems oi
JOIN Orders o ON o.OrderID = oi.OrderID
JOIN Products p ON p.ProductCode = oi.ProductCode
JOIN Users u ON u.UserID = o.UserID
JOIN StatesProvinces stpr ON u.StateProvinceID = stpr.StateProvinceID
WHERE oi.OrderID = @orderid
END