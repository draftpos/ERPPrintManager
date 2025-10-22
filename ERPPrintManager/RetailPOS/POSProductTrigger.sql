USE [RetailPOS_DB]
GO

/****** Object:  Trigger [dbo].[trg_Product_InsertUpdate]    Script Date: 17/01/2025 9:49:48 am ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[trg_Product_InsertUpdate]
ON [dbo].[Product]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;



    -- Insert or update data in the ZRA database
    MERGE [ZRA].[dbo].[Product] AS target
    USING (SELECT 
               [ProductCode] AS [itemCd],
               [ProductName] AS [itemNm],
               [Description] AS [itemStdNm],
               [orgnNatCd],
               [pkgUnitCd],
               [vatCatCd],
               [itemClsCd],
               [iplCatCd],
               [tlCatCd],
               [Barcode] AS [bcd],
               [SalesCost] AS [dftPrc],
               [AddedDate] AS [regrNm],
			   [ReorderPoint] AS [sftyQty],
			   [SalesUnit] AS [qtyUnitCd],
               [modrNm]
           FROM inserted) AS source
    ON target.[itemCd] = source.[itemCd]
    WHEN MATCHED THEN
        UPDATE SET 
            target.[itemNm] = source.[itemNm],
            target.[itemStdNm] = source.[itemStdNm],
            target.[orgnNatCd] = source.[orgnNatCd],
            target.[pkgUnitCd] = source.[pkgUnitCd],
            target.[vatCatCd] = source.[vatCatCd],
            target.[itemClsCd] = source.[itemClsCd],
            target.[iplCatCd] = source.[iplCatCd],
            target.[tlCatCd] = source.[tlCatCd],
            target.[bcd] = source.[bcd],
            target.[dftPrc] = source.[dftPrc],
			target.[sftyQty] = source.[sftyQty],
			target.[qtyUnitCd] = source.[qtyUnitCd],
            target.[modrNm] = source.[modrNm]
    WHEN NOT MATCHED THEN
        INSERT ([itemCd], [itemNm], [itemStdNm], [orgnNatCd], [pkgUnitCd], [vatCatCd], [itemClsCd], [iplCatCd], [tlCatCd], [bcd], [dftPrc], [regrNm], [modrNm],[sftyQty],[qtyUnitCd])
        VALUES (source.[itemCd], source.[itemNm], source.[itemStdNm], source.[orgnNatCd], source.[pkgUnitCd], source.[vatCatCd], source.[itemClsCd], source.[iplCatCd], source.[tlCatCd], source.[bcd], source.[dftPrc], source.[regrNm], source.[modrNm],source.[sftyQty],source.[qtyUnitCd]);
END;
GO

ALTER TABLE [dbo].[Product] ENABLE TRIGGER [trg_Product_InsertUpdate]
GO


