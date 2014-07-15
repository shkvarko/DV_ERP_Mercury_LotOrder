USE [ERP_Mercury]
GO

/****** Object:  Table [dbo].[T_LotState]   ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_LotState](
	[LotState_Guid] [dbo].[D_GUID] NOT NULL,
	[LotState_Name] [dbo].[D_NAME] NOT NULL,
	[LotState_Description] [dbo].[D_DESCRIPTION] NULL,
	[LotState_OrderNum] [dbo].[D_ID] NOT NULL,
	[LotState_IsActive] [dbo].[D_ISACTIVE] NOT NULL,
	[Record_Updated] [dbo].[D_DATETIME] NOT NULL,
	[Record_UserUdpated] [dbo].[D_NAMESHORT] NOT NULL,
	[LotState_IsRequire] [dbo].[D_YESNO] NULL,
 CONSTRAINT [PK_T_LotState] PRIMARY KEY CLUSTERED 
(
	[LotState_Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [INDX_T_LotState_LotSateName]    Script Date: 04.06.2013 16:44:26 ******/
CREATE UNIQUE NONCLUSTERED INDEX [INDX_T_LotState_LotSateName] ON [dbo].[T_LotState]
(
	[LotState_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[T_Lot](
	[Lot_Guid] [dbo].[D_GUID] NOT NULL,
	[Lot_Id] [dbo].[D_ID] NOT NULL,
	[KLP_Guid] [dbo].[D_GUID] NULL,
	[Lot_Num] [dbo].[D_NAMESHORT] NOT NULL,
	[Lot_DocNum] [dbo].[D_NAMESHORT] NOT NULL,
	[Lot_Date] [dbo].[D_DATE] NOT NULL,
	[Lot_DocDate] [dbo].[D_DATE] NOT NULL,
	[Stock_Guid] [dbo].[D_GUID] NOT NULL,
	[Vendor_Guid] [dbo].[D_GUID] NOT NULL,
	[Currency_Guid] [dbo].[D_GUID] NOT NULL,
	[LotState_Guid] [dbo].[D_GUID] NOT NULL,
	[Lot_CurrencyRate] [dbo].[D_MONEY] NOT NULL,
	-- себестоимость в валюте прихода
	[Lot_AllPrice] [dbo].[D_MONEY] NOT NULL,
	-- себестоимость в ОВУ
	[Lot_CurrencyAllPrice] [dbo].[D_MONEY] NOT NULL,
	-- сумма возврата в ОВУ
	[Lot_RetCurrencyAllPrice] [dbo].[D_MONEY] NOT NULL,
	[Lot_Description] [dbo].[D_DESCRIPTION] NULL,
	[Lot_IsActive] [dbo].[D_ISACTIVE] NOT NULL,
	[Record_Updated] [dbo].[D_DATETIME] NOT NULL,
	[Record_UserUdpated] [dbo].[D_NAMESHORT] NOT NULL,
	
	
 CONSTRAINT [PK_T_Lot] PRIMARY KEY CLUSTERED 
(
	[Lot_Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[T_Lot]  WITH CHECK ADD  CONSTRAINT [FK_T_Lot_T_Currency] FOREIGN KEY([Currency_Guid])
REFERENCES [dbo].[T_Currency] ([Currency_Guid])
GO

ALTER TABLE [dbo].[T_Lot] CHECK CONSTRAINT [FK_T_Lot_T_Currency]
GO

ALTER TABLE [dbo].[T_Lot]  WITH CHECK ADD  CONSTRAINT [FK_T_Lot_T_LotState] FOREIGN KEY([LotState_Guid])
REFERENCES [dbo].[T_LotState] ([LotState_Guid])
GO

ALTER TABLE [dbo].[T_Lot] CHECK CONSTRAINT [FK_T_Lot_T_LotState]
GO

ALTER TABLE [dbo].[T_Lot]  WITH CHECK ADD  CONSTRAINT [FK_T_Lot_T_Vendor] FOREIGN KEY([Vendor_Guid])
REFERENCES [dbo].[T_Vendor] ([Vendor_Guid])
GO

ALTER TABLE [dbo].[T_Lot] CHECK CONSTRAINT [FK_T_Lot_T_Vendor]
GO

ALTER TABLE [dbo].[T_Lot]  WITH CHECK ADD  CONSTRAINT [FK_T_Lot_T_Stock] FOREIGN KEY([Stock_Guid])
REFERENCES [dbo].[T_Stock] ([Stock_Guid])
GO

ALTER TABLE [dbo].[T_Lot] CHECK CONSTRAINT [FK_T_Lot_T_Stock]
GO


ALTER TABLE [dbo].[T_Lot]  WITH CHECK ADD  CONSTRAINT [FK_T_Lot_T_KLP] FOREIGN KEY([KLP_Guid])
REFERENCES [dbo].[T_KLP] ([KLP_Guid])
GO

ALTER TABLE [dbo].[T_Lot] CHECK CONSTRAINT [FK_T_Lot_T_KLP]
GO


SET ANSI_PADDING ON

GO

CREATE NONCLUSTERED INDEX [INDX_T_Lot_LotNum] ON [dbo].[T_Lot]
(
	[Lot_Num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]

GO

CREATE NONCLUSTERED INDEX [INDX_T_Lot_LotDocNum] ON [dbo].[T_Lot]
(
	[Lot_DocNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]

GO

CREATE NONCLUSTERED INDEX [INDX_T_Lot_LotDate] ON [dbo].[T_Lot]
(
	[Lot_Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]

GO

CREATE NONCLUSTERED INDEX [INDX_T_Lot_LotDocDate] ON [dbo].[T_Lot]
(
	[Lot_DocDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]

GO

CREATE NONCLUSTERED INDEX [INDX_T_Lot_LotIsActive] ON [dbo].[T_Lot]
(
	[Lot_IsActive] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]

GO

CREATE NONCLUSTERED INDEX [INDX_T_Lot_LotId] ON [dbo].[T_Lot]
(
	[Lot_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]

GO

/****** Object:  Table [dbo].[T_LotItems]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[T_LotItems](
	[LotItems_Guid] [dbo].[D_GUID] NOT NULL,
	[LotItems_Id] [dbo].[D_ID] NOT NULL,
	[Lot_Guid] [dbo].[D_GUID] NOT NULL,
	[KLPItems_Guid] [dbo].[D_GUID] NULL,

	[Parts_Guid] [dbo].[D_GUID] NOT NULL,
	[Measure_Guid] [dbo].[D_GUID] NOT NULL,

	[LotItems_Quantity] [dbo].[D_QUANTITY] NOT NULL,
	[LotItems_RetQuantity] [dbo].[D_QUANTITY] NOT NULL,
	[LotItems_LeavQuantity]  AS ([LotItems_Quantity] - [LotItems_RetQuantity]) PERSISTED,

	[LotItems_Price] [dbo].[D_MONEY] NOT NULL,
	[LotItems_CurrencyPrice] [dbo].[D_MONEY] NOT NULL,

	[LotItems_AllPrice]  AS ([LotItems_Quantity]*[LotItems_Price]) PERSISTED,
	[LotItems_CurrencyAllPrice]  AS ([LotItems_Quantity]*[LotItems_CurrencyPrice]) PERSISTED,
	
	[LotItems_ExpDate] [dbo].[D_DATE] NULL,
	[CountryProduction_Guid] [dbo].[D_GUID] NULL,
 CONSTRAINT [PK_T_LotItems] PRIMARY KEY CLUSTERED 
(
	[LotItems_Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[T_LotItems]  WITH CHECK ADD  CONSTRAINT [FK_T_LotItems_T_Lot] FOREIGN KEY([Lot_Guid])
REFERENCES [dbo].[T_Lot] ([Lot_Guid])
GO

ALTER TABLE [dbo].[T_LotItems] CHECK CONSTRAINT [FK_T_LotItems_T_Lot]
GO

ALTER TABLE [dbo].[T_LotItems]  WITH CHECK ADD  CONSTRAINT [FK_T_LotItems_T_Measure] FOREIGN KEY([Measure_Guid])
REFERENCES [dbo].[T_Measure] ([Measure_Guid])
GO

ALTER TABLE [dbo].[T_LotItems] CHECK CONSTRAINT [FK_T_LotItems_T_Measure]
GO

ALTER TABLE [dbo].[T_LotItems]  WITH CHECK ADD  CONSTRAINT [FK_T_LotItems_T_Parts] FOREIGN KEY([Parts_Guid])
REFERENCES [dbo].[T_Parts] ([Parts_Guid])
GO

ALTER TABLE [dbo].[T_LotItems] CHECK CONSTRAINT [FK_T_LotItems_T_Parts]
GO

ALTER TABLE [dbo].[T_LotItems]  WITH CHECK ADD  CONSTRAINT [FK_T_LotItems_T_KLPItems] FOREIGN KEY([KLPItems_Guid])
REFERENCES [dbo].[T_KLPItems] ([KLPItems_Guid])
GO

ALTER TABLE [dbo].[T_LotItems] CHECK CONSTRAINT [FK_T_LotItems_T_KLPItems]
GO

ALTER TABLE [dbo].[T_LotItems]  WITH CHECK ADD  CONSTRAINT [FK_T_LotItems_T_Country] FOREIGN KEY([CountryProduction_Guid])
REFERENCES [dbo].[T_Country] ([Country_Guid])
GO

ALTER TABLE [dbo].[T_LotItems] CHECK CONSTRAINT [FK_T_LotItems_T_Country]
GO


CREATE NONCLUSTERED INDEX [INDX_T_LotItems_LotItemdId] ON [dbo].[T_LotItems]
(
	[LotItems_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]

GO



CREATE NONCLUSTERED INDEX [INDX_T_LotItems_LotItemsExpDate] ON [dbo].[T_LotItems]
(
	[LotItems_ExpDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_LotStateHistory](
	[LotStateHistory_Guid] [dbo].[D_GUID] NOT NULL,
	[Lot_Guid] [dbo].[D_GUID] NOT NULL,
	[LotState_Date] [dbo].[D_DATETIME] NOT NULL,
	[LotState_Guid] [dbo].[D_GUID] NOT NULL,
	[Record_Updated] [dbo].[D_DATETIME] NOT NULL,
	[Record_UserUdpated] [dbo].[D_NAMESHORT] NOT NULL,
 CONSTRAINT [PK_T_LotStateHistory] PRIMARY KEY CLUSTERED 
(
	[LotStateHistory_Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[T_LotStateHistory]  WITH CHECK ADD  CONSTRAINT [FK_T_LotStateHistory_T_Lot] FOREIGN KEY([Lot_Guid])
REFERENCES [dbo].[T_Lot] ([Lot_Guid])
GO

ALTER TABLE [dbo].[T_LotStateHistory] CHECK CONSTRAINT [FK_T_LotStateHistory_T_Lot]
GO

ALTER TABLE [dbo].[T_LotStateHistory]  WITH CHECK ADD  CONSTRAINT [FK_T_LotStateHistory_T_LotState] FOREIGN KEY([LotState_Guid])
REFERENCES [dbo].[T_LotState] ([LotState_Guid])
GO

ALTER TABLE [dbo].[T_LotStateHistory] CHECK CONSTRAINT [FK_T_LotStateHistory_T_LotState]
GO


CREATE NONCLUSTERED INDEX [INDX_T_LotStateHistory_LotStateDate] ON [dbo].[T_LotStateHistory]
(
	[LotState_Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[LotStateHistoryView]
AS
SELECT     dbo.T_LotStateHistory.LotStateHistory_Guid, dbo.T_LotStateHistory.Lot_Guid, dbo.T_LotStateHistory.LotState_Date, dbo.T_LotStateHistory.LotState_Guid, 
                      dbo.T_LotStateHistory.Record_Updated, dbo.T_LotStateHistory.Record_UserUdpated, dbo.T_LotState.LotState_Name, dbo.T_LotState.LotState_OrderNum, 
                      dbo.T_LotState.LotState_IsActive
FROM         dbo.T_LotStateHistory INNER JOIN
                      dbo.T_LotState ON dbo.T_LotStateHistory.LotState_Guid = dbo.T_LotState.LotState_Guid AND dbo.T_LotStateHistory.LotState_Guid = dbo.T_LotState.LotState_Guid

GO
GRANT SELECT ON [dbo].[LotStateHistoryView] TO [public]
GO

/****** Object:  View [dbo].[LotView]    Script Date: 04.06.2013 21:00:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[LotView]
AS
SELECT     dbo.T_Lot.Lot_Guid, dbo.T_Lot.Lot_Id, dbo.T_Lot.KLP_Guid, dbo.T_Lot.Lot_Num, dbo.T_Lot.Lot_DocNum, dbo.T_Lot.Lot_Date, dbo.T_Lot.Lot_DocDate, 
                      dbo.T_Lot.Stock_Guid, dbo.T_Lot.Vendor_Guid, dbo.T_Lot.Currency_Guid, dbo.T_Lot.LotState_Guid, dbo.T_Lot.Lot_CurrencyRate, dbo.T_Lot.Lot_AllPrice, 
                      dbo.T_Lot.Lot_CurrencyAllPrice, dbo.T_Lot.Lot_RetCurrencyAllPrice, dbo.T_Lot.Lot_Description, dbo.T_Lot.Lot_IsActive, dbo.T_LotState.LotState_Name, 
                      dbo.T_LotState.LotState_Description, dbo.T_LotState.LotState_OrderNum, dbo.T_LotState.LotState_IsActive, dbo.T_LotState.LotState_IsRequire, 
                      dbo.T_Currency.Currency_Abbr, dbo.T_Currency.Currency_Code, dbo.T_Currency.Currency_ShortName, dbo.T_Currency.Currency_IsMain, dbo.T_Vendor.Vendor_Id, 
                      dbo.T_Vendor.Vendor_Name, dbo.T_Vendor.Vendor_Description, dbo.T_Vendor.Vendor_IsActive, dbo.T_Vendor.VendorType_Guid, dbo.T_VendorType.VendorType_Id, 
                      dbo.T_VendorType.VendorType_Name, dbo.T_VendorType.VendorType_Description, dbo.T_VendorType.VendorType_IsActive, dbo.T_Stock.Stock_Id, 
                      dbo.T_Stock.Warehouse_Guid, dbo.T_Stock.WarehouseType_Guid, dbo.T_Stock.Company_Guid, dbo.T_Stock.Stock_Name, dbo.T_Stock.Stock_IsActive, 
                      dbo.T_Stock.Stock_IsTrade, dbo.T_Stock.Stock_InTransfer, dbo.T_WarehouseType.WareHouseType_Name, dbo.T_WarehouseType.WarehouseType_IsActive, 
                      dbo.T_Company.Company_Id, dbo.T_Company.CompanyType_Guid, dbo.T_Company.Company_Acronym, dbo.T_Company.Company_OKPO, 
                      dbo.T_Company.Company_OKULP, dbo.T_Company.Company_UNN, dbo.T_Company.Company_IsActive, dbo.T_Company.Company_Name, 
                      dbo.T_Company.Company_Description, dbo.T_CompanyType.CompanyType_name, dbo.T_CompanyType.CompanyType_Description, 
                      dbo.T_CompanyType.CompanyType_IsActive, dbo.T_Company.CustomerStateType_Guid, dbo.T_CustomerStateType.CustomerStateType_Name, 
                      dbo.T_CustomerStateType.CustomerStateType_ShortName, dbo.T_CustomerStateType.CustomerStateType_IsActive
FROM         dbo.T_Lot INNER JOIN
                      dbo.T_LotState ON dbo.T_Lot.LotState_Guid = dbo.T_LotState.LotState_Guid INNER JOIN
                      dbo.T_Currency ON dbo.T_Lot.Currency_Guid = dbo.T_Currency.Currency_Guid INNER JOIN
                      dbo.T_Vendor ON dbo.T_Lot.Vendor_Guid = dbo.T_Vendor.Vendor_Guid INNER JOIN
                      dbo.T_VendorType ON dbo.T_Vendor.VendorType_Guid = dbo.T_VendorType.VendorType_Guid INNER JOIN
                      dbo.T_Stock ON dbo.T_Lot.Stock_Guid = dbo.T_Stock.Stock_Guid INNER JOIN
                      dbo.T_WarehouseType ON dbo.T_Stock.WarehouseType_Guid = dbo.T_WarehouseType.WareHouseType_Guid INNER JOIN
                      dbo.T_Company ON dbo.T_Stock.Company_Guid = dbo.T_Company.Company_Guid INNER JOIN
                      dbo.T_CompanyType ON dbo.T_Company.CompanyType_Guid = dbo.T_CompanyType.CompanyType_Guid INNER JOIN
                      dbo.T_CustomerStateType ON dbo.T_Company.CustomerStateType_Guid = dbo.T_CustomerStateType.CustomerStateType_Guid

GO
GRANT SELECT ON [dbo].[LotView] TO [public]
GO


/****** Object:  View [dbo].[LotItemsView]    Script Date: 04.06.2013 21:08:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[LotItemsView]
AS
SELECT     dbo.T_LotItems.LotItems_Guid, dbo.T_LotItems.LotItems_Id, dbo.T_LotItems.Lot_Guid, dbo.T_LotItems.KLPItems_Guid, dbo.T_LotItems.Parts_Guid, 
                      dbo.T_LotItems.Measure_Guid, dbo.T_LotItems.LotItems_Quantity, dbo.T_LotItems.LotItems_RetQuantity, dbo.T_LotItems.LotItems_LeavQuantity, 
                      dbo.T_LotItems.LotItems_Price, dbo.T_LotItems.LotItems_CurrencyPrice, dbo.T_LotItems.LotItems_AllPrice, dbo.T_LotItems.LotItems_CurrencyAllPrice, 
                      dbo.T_LotItems.LotItems_ExpDate, dbo.T_LotItems.CountryProduction_Guid, dbo.T_Country.Country_ISOCode, dbo.T_Country.Country_Name, 
                      dbo.T_Country.Country_Code, dbo.T_Country.Country_Id, dbo.T_Measure.Measure_Id, dbo.T_Measure.Measure_Code, dbo.T_Measure.Measure_Name, 
                      dbo.T_Measure.Measure_ShortName, dbo.T_KLPItems.KLP_Guid, dbo.T_Parts.Parts_Id, dbo.T_Parts.Parts_OriginalName, dbo.T_Parts.Parts_Name, 
                      dbo.T_Parts.Parts_ShortName, dbo.T_Parts.Parts_Article, dbo.T_Parts.Parts_IsActive
FROM         dbo.T_LotItems LEFT OUTER JOIN
                      dbo.T_KLPItems ON dbo.T_LotItems.KLPItems_Guid = dbo.T_KLPItems.KLPItems_Guid INNER JOIN
                      dbo.T_Measure ON dbo.T_LotItems.Measure_Guid = dbo.T_Measure.Measure_Guid INNER JOIN
                      dbo.T_Country ON dbo.T_LotItems.CountryProduction_Guid = dbo.T_Country.Country_Guid INNER JOIN
                      dbo.T_Parts ON dbo.T_LotItems.Parts_Guid = dbo.T_Parts.Parts_Guid

GO
GRANT SELECT ON [dbo].[LotItemsView] TO [public]
GO

/****** Object:  View [dbo].[LotStateView]    Script Date: 04.06.2013 21:11:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[LotStateView]
AS
SELECT     LotState_Guid, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire
FROM         dbo.T_LotState

GO
GRANT SELECT ON [dbo].[LotStateView] TO [public]
GO

/****** Object:  StoredProcedure [dbo].[usp_GetLotState]    Script Date: 04.06.2013 21:20:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Возвращает список записей из ( dbo.LotStateView )
--
-- Входные параметры:
--		@Lot_Guid - УИ прихода
--
-- Выходные параметры:
--
-- Результат:
--    0 - успешное завершение
--    <>0 - ошибка запроса информации из базы данных

CREATE PROCEDURE [dbo].[usp_GetLotState] 
	@Lot_Guid D_GUID = NULL,
	
  @ERROR_NUM int output,
  @ERROR_MES nvarchar(4000) output
AS

BEGIN

  SET @ERROR_NUM = 0;
  SET @ERROR_MES = NULL;

  BEGIN TRY

    IF( @Lot_Guid IS NULL )
			BEGIN
				SELECT LotState_Guid, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire
				FROM [dbo].[LotStateView]
				ORDER BY LotState_OrderNum;
			END
		ELSE	
			BEGIN
				DECLARE @CurrentLotState_Guid D_GUID = NULL;
				DECLARE @LotState_OrderNum int;
				
				SELECT @CurrentLotState_Guid = LotState_Guid 
				FROM dbo.T_Lot WHERE Lot_Guid = @Lot_Guid;
				
				IF( @CurrentLotState_Guid IS NULL )
					BEGIN
						SELECT @LotState_OrderNum = MIN( LotState_OrderNum ) FROM dbo.T_LotState WHERE LotState_IsRequire = 1;
						IF( @LotState_OrderNum IS NULL )
							SELECT @LotState_OrderNum = MIN( LotState_OrderNum ) FROM dbo.T_LotState;
						
						IF( @LotState_OrderNum IS NOT NULL )
							SELECT LotState_Guid, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire
							FROM [dbo].[LotStateView]
							WHERE LotState_OrderNum = @LotState_OrderNum;
					END
				ELSE	
					BEGIN
						DECLARE @CurrentLotState_OrderNum int;
						SELECT Top 1 @CurrentLotState_OrderNum = LotState_OrderNum FROM dbo.T_LotState
						WHERE LotState_Guid = @CurrentLotState_Guid;

						SELECT @LotState_OrderNum = MIN( LotState_OrderNum ) FROM dbo.T_LotState 
						WHERE LotState_IsRequire = 1 
							AND LotState_OrderNum > @CurrentLotState_OrderNum;
							
						IF( @LotState_OrderNum IS NOT NULL )
							SELECT LotState_Guid, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire
							FROM [dbo].[LotStateView]
							WHERE LotState_OrderNum BETWEEN @CurrentLotState_OrderNum AND @LotState_OrderNum
							ORDER BY 	LotState_OrderNum;
						ELSE
							SELECT LotState_Guid, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire
							FROM [dbo].[LotStateView]
							WHERE LotState_OrderNum = @CurrentLotState_OrderNum;
						
					END
			END
	END TRY
	BEGIN CATCH
		SET @ERROR_NUM = ERROR_NUMBER();
		SET @ERROR_MES = ERROR_MESSAGE();
		RETURN @ERROR_NUM;
	END CATCH;

  IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
  RETURN @ERROR_NUM;
END


GO
GRANT EXECUTE ON [dbo].[usp_GetLotState] TO [public]
GO


/****** Object:  StoredProcedure [dbo].[usp_DeleteLotState]    Script Date: 04.06.2013 21:20:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- Удаление элемента из таблицы dbo.T_LotState
--
-- Входящие параметры:
--		@LotState_Guid - уникальный идентификатор записи
--
-- Результат:
--    0 - успешное завершение
--    <>0 - ошибка

CREATE PROCEDURE [dbo].[usp_DeleteLotState] 
	@LotState_Guid D_GUID,

  @ERROR_NUM int output,
  @ERROR_MES nvarchar(4000) output

AS

BEGIN

  SET @ERROR_NUM = 0;
  SET @ERROR_MES = '';

	BEGIN TRY

    -- Проверяем наличие записи с заданным именем
    IF EXISTS ( SELECT LotState_Guid FROM dbo.T_Lot	WHERE LotState_Guid = @LotState_Guid )
      BEGIN
        SET @ERROR_NUM = 1;
        SET @ERROR_MES = 'В приходных документах существует ссылка на указанное состояние.' + Char(13) + 
          'Удалить запись нельзя.';
        RETURN @ERROR_NUM;
      END

   DELETE FROM dbo.T_LotState WHERE LotState_Guid = @LotState_Guid;

	END TRY
	BEGIN CATCH
		SET @ERROR_NUM = ERROR_NUMBER();
		SET @ERROR_MES = ERROR_MESSAGE();

		RETURN @ERROR_NUM;
	END CATCH;

	IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
	RETURN @ERROR_NUM;
END


GO
GRANT EXECUTE ON [dbo].[usp_DeleteLotState] TO [public]
GO

/****** Object:  StoredProcedure [dbo].[usp_AddLotState]    Script Date: 04.06.2013 21:20:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- Добавляет новую запись в таблицу dbo.T_LotState
--
-- Входящие параметры:
--	@LotState_Name				- наименование
--	@LotState_Description - описание
--	@LotState_OrderNum		- номер состояния в очереди
--	@LotState_IsActive		- признак активности записи
--	@LotState_IsRequire		- признак обязательного прохождения состояния
--
--
-- Выходные параметры:
--  @LotState_Guid - уникальный идентификатор записи
--  @ERROR_NUM - номер ошибки
--  @ERROR_MES - текст ошибки
--
-- Результат:
--    0 - Успешное завершение
--    <>0 - ошибка

CREATE PROCEDURE [dbo].[usp_AddLotState] 
	@LotState_Name D_NAME,
	@LotState_Description D_DESCRIPTION = NULL,
	@LotState_OrderNum D_ID,
	@LotState_IsActive D_ISACTIVE = 1,
	@LotState_IsRequire D_YESNO = 1,

  @LotState_Guid D_GUID output,
  @ERROR_NUM int output,
  @ERROR_MES nvarchar(4000) output

AS

BEGIN

	BEGIN TRY

    SET @ERROR_NUM = 0;
    SET @ERROR_MES = '';
    SET @LotState_Guid = NULL;

    -- Проверяем наличие записи с заданным именем
    IF EXISTS ( SELECT * FROM dbo.T_LotState	WHERE LotState_Name = @LotState_Name )
      BEGIN
        SET @ERROR_NUM = 1;
        SET @ERROR_MES = 'В базе данных уже присутствует состояние прихода с указанным наименованием.' + Char(13) + 
          'состояние: ' + Char(9) + @LotState_Name;
        RETURN @ERROR_NUM;
      END

    DECLARE @NewID D_GUID;
    SET @NewID = NEWID ( );	
    
    INSERT INTO dbo.T_LotState( LotState_Guid, LotState_Name, LotState_Description, 
			LotState_OrderNum, LotState_IsActive, LotState_IsRequire,
			Record_Updated, Record_UserUdpated )
    VALUES( @NewID, @LotState_Name, @LotState_Description, 
			@LotState_OrderNum, @LotState_IsActive, @LotState_IsRequire,
			sysutcdatetime(), ( Host_Name() + ': ' + SUSER_SNAME() ) );
    
    SET @LotState_Guid = @NewID;

	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = ERROR_MESSAGE();
		RETURN @ERROR_NUM;
	END CATCH;

	IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
	RETURN @ERROR_NUM;
END


GO
GRANT EXECUTE ON [dbo].[usp_AddLotState] TO [public]
GO

/****** Object:  StoredProcedure [dbo].[usp_EditLotState]    Script Date: 04.06.2013 21:20:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- Редактирует запись в таблице dbo.T_LotState
--
-- Входящие параметры:
--  @LotState_Guid				- уникальный идентификатор записи
--		@LotState_Name				- наименование
--		@LotState_Description - описание
--		@LotState_OrderNum		- номер состояния в очереди
--		@LotState_IsActive		- признак активности записи
--		@LotState_IsRequire		- признак обязательного прохождения состояния
--
--
-- Выходные параметры:
--  @ERROR_NUM - номер ошибки
--  @ERROR_MES - текст ошибки
--
-- Результат:
--    0 - Успешное завершение
--    <>0 - ошибка

CREATE PROCEDURE [dbo].[usp_EditLotState] 
  @LotState_Guid D_GUID,
	@LotState_Name D_NAME,
	@LotState_Description D_DESCRIPTION = NULL,
	@LotState_OrderNum D_ID,
	@LotState_IsActive D_ISACTIVE,
	@LotState_IsRequire D_YESNO = 1,

  @ERROR_NUM int output,
  @ERROR_MES nvarchar(4000) output

AS

BEGIN

	BEGIN TRY

    SET @ERROR_NUM = 0;
    SET @ERROR_MES = NULL;

    -- Проверяем наличие записи с заданным именем
    IF EXISTS ( SELECT * FROM dbo.T_LotState	WHERE LotState_Name = @LotState_Name AND LotState_Guid <> @LotState_Guid )
      BEGIN
        SET @ERROR_NUM = 1;
        SET @ERROR_MES = 'В базе данных уже присутствует состояние прихода с указанным наименованием.' + Char(13) + 
          'состояние: ' + Char(9) + @LotState_Name;
        RETURN @ERROR_NUM;
      END

    UPDATE dbo.T_LotState SET LotState_Name = @LotState_Name, LotState_Description = @LotState_Description, 
			LotState_IsActive = @LotState_IsActive, LotState_OrderNum = @LotState_OrderNum, 
			LotState_IsRequire = @LotState_IsRequire
		WHERE LotState_Guid = @LotState_Guid; 
			
	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = ERROR_MESSAGE();
		RETURN @ERROR_NUM;
	END CATCH;

	IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
	RETURN @ERROR_NUM;
END


GO
GRANT EXECUTE ON [dbo].[usp_EditLotState] TO [public]
GO


/****** Object:  StoredProcedure [dbo].[usp_GetLotStateHistory]    Script Date: 04.06.2013 21:46:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- Возвращает журнал состояний прихода
--
-- Входные параметры:
--		@Lot_Guid	- УИ прихода
--
-- Выходные параметры:
--
-- Результат:
--    0 - успешное завершение
--    <>0 - ошибка запроса информации из базы данных

CREATE PROCEDURE [dbo].[usp_GetLotStateHistory] 
	@Lot_Guid	D_GUID,
	
  @ERROR_NUM			int output,
  @ERROR_MES			nvarchar(4000) output
AS

BEGIN

  SET @ERROR_NUM = 0;
  SET @ERROR_MES = '';

  BEGIN TRY
  
		SELECT LotStateHistory_Guid, Lot_Guid, LotState_Date, LotState_Guid, 
			Record_Updated, Record_UserUdpated, LotState_Name, LotState_OrderNum
		FROM dbo.LotStateHistoryView
		WHERE Lot_Guid = @Lot_Guid
		ORDER BY Record_Updated 
	END TRY
	BEGIN CATCH
		SET @ERROR_NUM = ERROR_NUMBER();
		SET @ERROR_MES = ERROR_MESSAGE();
		RETURN @ERROR_NUM;
	END CATCH;

  IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
  RETURN @ERROR_NUM;
END

GO
GRANT EXECUTE ON [dbo].[usp_GetLotStateHistory] TO [public]
GO

CREATE TYPE [dbo].[udt_LotItems] AS TABLE(
	[LotItems_Guid] [uniqueidentifier] NULL,
	[LotItems_Id] [int] NOT NULL,
	[Lot_Guid] [uniqueidentifier] NULL,
	[KLPItems_Guid] [uniqueidentifier] NULL,
	[Parts_Guid] [uniqueidentifier] NOT NULL,
	[Measure_Guid] [uniqueidentifier] NOT NULL,
	[LotItems_Quantity] [float] NOT NULL,
	[LotItems_RetQuantity] [float] NOT NULL,
	[LotItems_Price] [money] NOT NULL,
	[LotItems_CurrencyPrice] [money] NOT NULL,
	[LotItems_ExpDate] [date] NULL,
	[CountryProduction_Guid] [uniqueidentifier] NULL
)
GO

GRANT CONTROL ON TYPE::[dbo].[udt_LotItems] TO [public]
GO
use [ERP_Mercury]
GO
GRANT REFERENCES ON TYPE::[dbo].[udt_LotItems] TO [public]
GO
use [ERP_Mercury]
GO
GRANT TAKE OWNERSHIP ON TYPE::[dbo].[udt_LotItems] TO [public]
GO
use [ERP_Mercury]
GO
GRANT VIEW DEFINITION ON TYPE::[dbo].[udt_LotItems] TO [public]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Добавляет в базу данных InterBase информацию о приходе
--
-- Параметры:
-- [in] @Lot_Guid									- УИ прихода
-- [in] @IBLINKEDSERVERNAME				- Linked Server
--
-- [out]  @Lot_Id										- УИ прихода в InterBase
-- [out]  @ERROR_NUM									- номер ошибки
-- [out]  @ERROR_MES									- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--			<>0 - ошибка
--
-- Возвращает:
--
CREATE PROCEDURE [dbo].[usp_AddLotToIB]
  @IBLINKEDSERVERNAME dbo.D_NAME = NULL,
  @Lot_Guid						D_GUID,

  @Lot_Id							D_ID output,
  @ERROR_NUM					int output,
  @ERROR_MES					nvarchar(4000) output
AS

BEGIN
	DECLARE @StartProcessSuppl D_DATETIME;
	SET @StartProcessSuppl = GetDate();

  BEGIN TRY
    SET @ERROR_NUM = 0;
    SET @ERROR_MES = '';
    SET @Lot_Id = 0;
    
 	  IF( @IBLINKEDSERVERNAME IS NULL ) SELECT @IBLINKEDSERVERNAME = dbo.GetIBLinkedServerName();

    DECLARE @strIBSQLText nvarchar( 250 );
    
 	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = '[usp_AddToIB]: ' + ERROR_MESSAGE();

		RETURN @ERROR_NUM;
	END CATCH;

  IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Приход успешно сохранён в IB';

	RETURN @ERROR_NUM;

END

GO
GRANT EXECUTE ON [dbo].[usp_AddLotToIB] TO [public]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Добавляет в базу данных информацию о приходе
--
-- Параметры:
-- [in] @tLotItems										- приложение к приходу
-- [in] @Lot_Num											- номер партии
-- [in] @Lot_Date										- дата прихода
-- [in] @Lot_Num											- номер приходной накладной
-- [in] @Lot_DocDate									- дата приходной накладной
-- [in] @Vendor_Guid									- УИ поставщика
-- [in] @Currency_Guid								- УИ валюты прихода
-- [in] @Stock_Guid									- УИ склада
-- [in] @Lot_Description							- примечание
-- [in] @Lotr_IsActive								- признак "приход активен"
-- [in] @LotState_Guid								- УИ состояния прихода
-- [in] @Lot_CurrencyRate						- курс пересчёта валюты прихода в ОВУ
--
-- [out]  @Lot_Guid									- УИ прихода
-- [out]  @Lot_Id										- УИ прихода в InterBase
-- [out]  @Lot_AllPrice							- себестоимость в валюте прихода
-- [out]  @Lot_CurrencyAllPrice			- себестоимость в ОВУ
-- [out]  @Lot_RetCurrencyAllPrice		- сумма возврата по накладной по себестоимости в ОВУ
-- [out]  @ERROR_NUM									- номер ошибки
-- [out]  @ERROR_MES									- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--			<>0 - ошибка
--
-- Возвращает:
--

CREATE PROCEDURE [dbo].[usp_AddLot]
	@KLP_Guid									D_GUID = NULL,
	@Lot_Num									D_NAMESHORT,
	@Lot_DocNum								D_NAMESHORT,
	@Lot_Date									D_DATE,
	@Lot_DocDate							D_DATE,
	@Vendor_Guid							D_GUID,
	@Stock_Guid								D_GUID,
	@Currency_Guid						D_GUID,
	@Lot_Description					D_DESCRIPTION = NULL,
	@Lot_IsActive							D_ISACTIVE = 1, 
	@LotState_Guid						D_GUID,
	@Lot_CurrencyRate					D_MONEY,

	@tLotItems								dbo.udt_LotItems  READONLY,

  @Lot_Guid									D_GUID output,
  @Lot_Id										D_ID output,
	@Lot_AllPrice							D_MONEY output,
	@Lot_CurrencyAllPrice			D_MONEY output,
	@Lot_RetCurrencyAllPrice	D_MONEY output,

  @ERROR_NUM								int output,
  @ERROR_MES								nvarchar(4000) output
AS


BEGIN

  BEGIN TRY
    SET @ERROR_NUM = 0;
    SET @ERROR_MES = '';
    SET @Lot_Guid = NULL;
    SET @Lot_Id = 0;
    SET @Lot_AllPrice = 0;
    SET @Lot_CurrencyAllPrice = 0;
    SET @Lot_RetCurrencyAllPrice = 0;
    
    -- Проверяем наличие поставщика с указанным идентификатором
    IF NOT EXISTS ( SELECT Vendor_Guid FROM dbo.T_Vendor WHERE Vendor_Guid = @Vendor_Guid )
      BEGIN
        SET @ERROR_NUM = 1;
        SET @ERROR_MES = 'В базе данных не найден поставщик с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Vendor_Guid  );
        RETURN @ERROR_NUM;
      END
    
    -- Проверяем наличие валюты с указанным идентификатором
    IF NOT EXISTS ( SELECT Currency_Guid FROM dbo.T_Currency WHERE Currency_Guid = @Currency_Guid )
      BEGIN
        SET @ERROR_NUM = 2;
        SET @ERROR_MES = 'В базе данных не найдена валюта с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Currency_Guid  );
        RETURN @ERROR_NUM;
      END

    -- Проверяем наличие записи о состоянии прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT LotState_Guid FROM dbo.T_LotState WHERE LotState_Guid = @LotState_Guid )
      BEGIN
        SET @ERROR_NUM = 3;
        SET @ERROR_MES = 'В базе данных не найдена запись о состоянии прихода с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @LotState_Guid  );
        RETURN @ERROR_NUM;
      END

    -- Проверяем наличие записи о складе прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT Stock_Guid FROM dbo.T_Stock WHERE Stock_Guid = @Stock_Guid )
      BEGIN
        SET @ERROR_NUM = 4;
        SET @ERROR_MES = 'В базе данных не найдена запись о складе с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Stock_Guid  );
        RETURN @ERROR_NUM;
      END

		-- Регистрируем шапку прихода
    DECLARE @NewID D_GUID;
    SET @NewID = NEWID( );	

    BEGIN TRANSACTION UpdateData;

		INSERT INTO T_Lot( Lot_Guid, Lot_Id, KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date, Lot_DocDate, 
			Stock_Guid, Vendor_Guid, Currency_Guid, LotState_Guid, 
			Lot_CurrencyRate, Lot_AllPrice, Lot_CurrencyAllPrice, Lot_RetCurrencyAllPrice, 
			Lot_Description, Lot_IsActive, Record_Updated, Record_UserUdpated )
		VALUES( @NewID, @Lot_Id, @KLP_Guid, @Lot_Num, @Lot_DocNum, @Lot_Date, @Lot_DocDate, 
			@Stock_Guid, @Vendor_Guid, @Currency_Guid, @LotState_Guid, 
			@Lot_CurrencyRate, @Lot_AllPrice, @Lot_CurrencyAllPrice, @Lot_RetCurrencyAllPrice, @Lot_Description, @Lot_IsActive,
			sysutcdatetime(), ( Host_Name() + ': ' + SUSER_SNAME() ) );
		
		-- Приложение к приходу
		INSERT INTO T_LotItems( LotItems_Guid, LotItems_Id, Lot_Guid,	KLPItems_Guid,	Parts_Guid,	Measure_Guid,
			LotItems_Quantity,	LotItems_RetQuantity,	LotItems_Price,	LotItems_CurrencyPrice,	LotItems_ExpDate,	CountryProduction_Guid  )
		SELECT LotItems_Guid, 0, @NewID,	KLPItems_Guid,	Parts_Guid,	Measure_Guid,
			LotItems_Quantity,	LotItems_RetQuantity,	LotItems_Price,	LotItems_CurrencyPrice,	LotItems_ExpDate,	CountryProduction_Guid
		FROM @tLotItems;
		
    SELECT  @Lot_AllPrice = SUM( [LotItems_Quantity] * [LotItems_Price] ), 
			@Lot_CurrencyAllPrice = SUM( [LotItems_Quantity] * [LotItems_CurrencyPrice] ),
			@Lot_RetCurrencyAllPrice = SUM( [LotItems_RetQuantity] * [LotItems_CurrencyPrice])
    FROM T_LotItems 
    WHERE Lot_Guid = @NewID;
    
		UPDATE T_Lot SET Lot_AllPrice = @Lot_AllPrice, Lot_CurrencyAllPrice = @Lot_CurrencyAllPrice, 
		 Lot_RetCurrencyAllPrice = @Lot_RetCurrencyAllPrice
		WHERE Lot_Guid = @NewID;

		INSERT INTO dbo.T_LotStateHistory( LotStateHistory_Guid, Lot_Guid, LotState_Date, LotState_Guid, Record_Updated, Record_UserUdpated )
		VALUES( NEWID(), @NewID, sysutcdatetime(), @LotState_Guid, sysutcdatetime(), ( Host_Name() + ': ' + SUSER_SNAME() ) );	
		
		SET @Lot_Guid = @NewID;

		IF( @ERROR_NUM = 0 )
			BEGIN
				-- теперь приход необходимо "разместить" в InterBase
				EXEC dbo.usp_AddLotToIB @Lot_Guid = @Lot_Guid, @Lot_Id = @Lot_Id out, 
					@ERROR_NUM = @ERROR_NUM out, @ERROR_MES = @ERROR_MES out;
			END
		
		IF( @ERROR_NUM = 0 )	
			BEGIN
				UPDATE dbo.T_Lot SET Lot_Id = @Lot_Id
				WHERE Lot_Guid = @Lot_Guid;
				
				COMMIT TRANSACTION UpdateData;
			END 
		ELSE	
			ROLLBACK TRANSACTION UpdateData;

		   
 	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = 'Ошибка добавления в базу данных информации о приходе. ' + ERROR_MESSAGE();
    
		RETURN @ERROR_NUM;
	END CATCH;

	IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
	RETURN @ERROR_NUM;
END

GO
GRANT EXECUTE ON [dbo].[usp_AddLot] TO [public]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Редактирует в базе данных информацию о приходе
--
-- Параметры:
-- [in] @Lot_Guid									- УИ прихода
-- [in] @tLotItems										- приложение к приходу
-- [in] @Lot_Num											- номер партии
-- [in] @Lot_Date										- дата прихода
-- [in] @Lot_Num											- номер приходной накладной
-- [in] @Lot_DocDate									- дата приходной накладной
-- [in] @Vendor_Guid									- УИ поставщика
-- [in] @Currency_Guid								- УИ валюты прихода
-- [in] @Stock_Guid									- УИ склада
-- [in] @Lot_Description							- примечание
-- [in] @Lotr_IsActive								- признак "приход активен"
-- [in] @LotState_Guid								- УИ состояния прихода
-- [in] @Lot_CurrencyRate						- курс пересчёта валюты прихода в ОВУ
--
-- [out]  @Lot_AllPrice							- себестоимость в валюте прихода
-- [out]  @Lot_CurrencyAllPrice			- себестоимость в ОВУ
-- [out]  @Lot_RetCurrencyAllPrice		- сумма возврата по накладной по себестоимости в ОВУ
-- [out]  @ERROR_NUM									- номер ошибки
-- [out]  @ERROR_MES									- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--			<>0 - ошибка
--
-- Возвращает:
--

CREATE PROCEDURE [dbo].[usp_EditLot]
	@Lot_Guid									D_GUID,
	@KLP_Guid									D_GUID = NULL,
	@Lot_Num									D_NAMESHORT,
	@Lot_DocNum								D_NAMESHORT,
	@Lot_Date									D_DATE,
	@Lot_DocDate							D_DATE,
	@Vendor_Guid							D_GUID,
	@Stock_Guid								D_GUID,
	@Currency_Guid						D_GUID,
	@Lot_Description					D_DESCRIPTION = NULL,
	@Lot_IsActive							D_ISACTIVE = 1, 
	@LotState_Guid						D_GUID,
	@Lot_CurrencyRate					D_MONEY,

	@tLotItems								dbo.udt_LotItems  READONLY,

	@Lot_AllPrice							D_MONEY output,
	@Lot_CurrencyAllPrice			D_MONEY output,
	@Lot_RetCurrencyAllPrice	D_MONEY output,

  @ERROR_NUM								int output,
  @ERROR_MES								nvarchar(4000) output
AS

BEGIN

  BEGIN TRY
    SET @ERROR_NUM = 0;
    SET @ERROR_MES = '';

    SET @Lot_AllPrice = 0;
    SET @Lot_CurrencyAllPrice = 0;
    SET @Lot_RetCurrencyAllPrice = 0;
    
    -- Проверяем наличие прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT Lot_Guid FROM dbo.T_Lot WHERE Lot_Guid = @Lot_Guid )
      BEGIN
        SET @ERROR_NUM = 1;
        SET @ERROR_MES = 'В базе данных не найден приход с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Lot_Guid  );
        RETURN @ERROR_NUM;
      END

    -- Проверяем наличие поставщика с указанным идентификатором
    IF NOT EXISTS ( SELECT Vendor_Guid FROM dbo.T_Vendor WHERE Vendor_Guid = @Vendor_Guid )
      BEGIN
        SET @ERROR_NUM = 2;
        SET @ERROR_MES = 'В базе данных не найден поставщик с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Vendor_Guid  );
        RETURN @ERROR_NUM;
      END
    
    -- Проверяем наличие валюты с указанным идентификатором
    IF NOT EXISTS ( SELECT Currency_Guid FROM dbo.T_Currency WHERE Currency_Guid = @Currency_Guid )
      BEGIN
        SET @ERROR_NUM = 3;
        SET @ERROR_MES = 'В базе данных не найдена валюта с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Currency_Guid  );
        RETURN @ERROR_NUM;
      END

    -- Проверяем наличие записи о состоянии прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT LotState_Guid FROM dbo.T_LotState WHERE LotState_Guid = @LotState_Guid )
      BEGIN
        SET @ERROR_NUM = 4;
        SET @ERROR_MES = 'В базе данных не найдена запись о состоянии прихода с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @LotState_Guid  );
        RETURN @ERROR_NUM;
      END

    -- Проверяем наличие записи о складе прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT Stock_Guid FROM dbo.T_Stock WHERE Stock_Guid = @Stock_Guid )
      BEGIN
        SET @ERROR_NUM = 5;
        SET @ERROR_MES = 'В базе данных не найдена запись о складе с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Stock_Guid  );
        RETURN @ERROR_NUM;
      END

    BEGIN TRANSACTION UpdateData;

		-- Вносим правки в шапку прихода
		--
		DECLARE @CurrentLotState_Guid D_GUID;
		SELECT @CurrentLotState_Guid = LotState_Guid FROM dbo.T_Lot WHERE Lot_Guid = @Lot_Guid;		
		
		UPDATE dbo.T_Lot SET KLP_Guid = @KLP_Guid, Lot_Num = @Lot_Num, Lot_DocNum = @Lot_DocNum, Lot_Date = @Lot_Date, 
			Lot_DocDate = @Lot_DocDate, Stock_Guid = @Stock_Guid, Vendor_Guid = @Vendor_Guid, Currency_Guid = @Currency_Guid, 
			Lot_CurrencyRate = @Lot_CurrencyRate,  Lot_Description = @Lot_Description, Lot_IsActive = @Lot_IsActive
		WHERE Lot_Guid = @Lot_Guid;	

		IF( @CurrentLotState_Guid <> @LotState_Guid )
			INSERT INTO dbo.T_LotStateHistory( LotStateHistory_Guid, Lot_Guid, LotState_Date, LotState_Guid, Record_Updated, Record_UserUdpated )
			VALUES( NEWID(), @Lot_Guid, sysutcdatetime(), @LotState_Guid, sysutcdatetime(), ( Host_Name() + ': ' + SUSER_SNAME() ) );	

		-- Теперь шапка в InterBase
    DECLARE @SQLString nvarchar( 2048);
    DECLARE @ParmDefinition nvarchar(500);

    DECLARE @VENDOR_ID D_ID;
    DECLARE @CURRENCY_CODE nvarchar(3);
    DECLARE @LOTORDER_CURRENCYRATE float;

		-- запрашиваем данные, необходимые для создания заказа на стороне IB
		SELECT @VENDOR_ID = Vendor_Id FROM dbo.T_Vendor WHERE Vendor_Guid = @Vendor_Guid;
		SELECT @CURRENCY_CODE = Currency_Abbr FROM dbo.T_Currency WHERE Currency_Guid = @Currency_Guid;

		--DECLARE @strLOTORDER_STOCKDATE varchar( 24 );
		--IF( @Lot_StockDate IS NULL ) SET @strLOTORDER_STOCKDATE = 'NULL'
		--ELSE 
		--	BEGIN
		--		SET @strLOTORDER_STOCKDATE = convert( varchar( 10), @LotOrder_StockDate, 104);
		--		SET @strLOTORDER_STOCKDATE = '''''' + @strLOTORDER_STOCKDATE + '''''';
		--	END	
		
		--DECLARE @strLOTORDER_DATE varchar( 24 );
		--IF( @LotOrder_Date IS NULL ) SET @strLOTORDER_DATE = 'NULL'
		--ELSE 
		--	BEGIN
		--		SET @strLOTORDER_DATE = convert( varchar( 10), @LotOrder_Date, 104);
		--		SET @strLOTORDER_DATE = '''''' + @strLOTORDER_DATE + '''''';
		--	END	
		
		--IF( @LotOrder_ShipDate IS NULL ) SET @LotOrder_ShipDate = @LotOrder_Date;
		--DECLARE @strLOTORDER_SHIPDATE varchar( 24 );
		--IF( @LotOrder_ShipDate IS NULL ) SET @strLOTORDER_SHIPDATE = 'NULL'
		--ELSE 
		--	BEGIN
		--		SET @strLOTORDER_SHIPDATE = convert( varchar( 10), @LotOrder_ShipDate, 104);
		--		SET @strLOTORDER_SHIPDATE = '''''' + @strLOTORDER_SHIPDATE + '''''';
		--	END	

  --  DECLARE @uuidEUR D_GUID;
  --  DECLARE @strEUR D_CURRENCYCODE = 'EUR';
  --  SELECT @uuidEUR = Currency_Guid FROM dbo.T_Currency WHERE Currency_Abbr = @strEUR;

		--SELECT @LOTORDER_CURRENCYRATE = dbo.GetCurrencyRateInOut( @Currency_Guid, @uuidEUR, @LotOrder_Date );	
		--IF( @CURRENCY_CODE = 'RUB' ) SET @CURRENCY_CODE = 'RUR';		
		
		--DECLARE @LotOrder_Id D_ID;	
		--DECLARE @SrcLotOrder_Id D_ID;	
		--DECLARE @DocType_Id D_ID = 0;
		
		--SELECT @LotOrder_Id = LotOrder_Id, @SrcLotOrder_Id = SrcLotOrder_Id FROM T_LotOrder WHERE LotOrder_Guid = @LotOrder_Guid;

		--IF( ( @SrcLotOrder_Id IS NOT NULL ) AND ( @SrcLotOrder_Id <> 0 ) )
		--	SET @DocType_Id = 1; -- Поставка		

  --  SET @ParmDefinition = N'@error_numbersql int output, @error_textsql nvarchar(480) output'; 
    
  --  DECLARE @IBLINKEDSERVERNAME dbo.D_NAME;
  --  SELECT @IBLINKEDSERVERNAME = dbo.GetIBLinkedServerName();

  --  -- Редактирует запись в таблице T_LOTORDER в InterBase
			
  --  SET @SQLString = 'select @error_numbersql = ERROR_NUMBER, @error_textsql = ERROR_TEXT from openquery( ' + 
		--	@IBLINKEDSERVERNAME + ', ''select ERROR_NUMBER, ERROR_TEXT from SP_EDITLOTORDER_FROMSQL( ' + cast( @DocType_Id as nvarchar( 20))  + ', ' +
		--		cast( @LotOrder_Id as nvarchar( 20))  + ', ' + 
		--		cast( @VENDOR_ID as nvarchar( 20))  + ', ' + @strLOTORDER_DATE + ', ' + @strLOTORDER_SHIPDATE + ', ''''' + @LotOrder_Num + ''''', ' + @strLOTORDER_STOCKDATE + 
		--			', ''''' + @CURRENCY_CODE + ''''', ' + cast( @LOTORDER_CURRENCYRATE as nvarchar( 56)) + ')'')'; 

		--PRINT @SQLString;
  --  EXECUTE sp_executesql @SQLString, @ParmDefinition, 
		--	@error_numbersql = @ERROR_NUM output, @error_textsql = @ERROR_MES output;

  --  IF( ( @ERROR_NUM <> 0 ) OR ( @LotOrder_Id IS NULL ) OR ( @LotOrder_Id = 0 ) ) -- ошибка при сохранении заказа в IB
  --    BEGIN
  --      RETURN @ERROR_NUM;
	 --   END

		---- Приложение к заказу
		--DECLARE @LotOrderItems_Guid [uniqueidentifier];
		--DECLARE @LotOrder_Guid2 [uniqueidentifier];
		--DECLARE @Parts_Guid [uniqueidentifier];
		--DECLARE @Measure_Guid [uniqueidentifier];
		--DECLARE @LotOrderItems_OrderQuantity [float];
		--DECLARE @LotOrderItems_Quantity [float];
		--DECLARE @LotOrderItems_VendorPrice [money];
		--DECLARE @LotOrderItems_DiscountPercent [money];
		--DECLARE @LotOrderItems_DiscountVendorPrice [money];
		--DECLARE @LotOrderItems_PriceForCalcCostPrice [money];
		--DECLARE @LotOrderItems_ConfirmQuantity [money];
		--DECLARE @LotOrderItems_ExpDate [date];
		--DECLARE @LotOrderItems_CustomTarifPercent [money];
		--DECLARE @CountryProduction_Guid [uniqueidentifier];

		--DECLARE @LOTORDERITMS_ID int;
		--DECLARE @IN_LOTORDERITMS_ID int;
  --  DECLARE @PARTS_ID int;
  --  DECLARE @MEASURE_ID int;
		--DECLARE @COUNTRY_ID int;
  --  DECLARE @LOTORDERITMS_QUANTITY int;
  --  DECLARE @LOTORDERITMS_CUSTOMTARIFPERCENT float;

  --  DECLARE @PRICE_EXW float;
  --  DECLARE @PRICE_INVOICE float;
  --  DECLARE @PRICE_FORCALCCOSTPRICE float;

  --  DECLARE @ACTIONTYPE_ID int;
  --  SET @ParmDefinition = N'@LOTORDERITMS_IDsql int output, @error_numbersql int output, @error_textsql nvarchar(480) output'; 
    

	 -- DECLARE crLotOrderItems CURSOR
	 -- FOR SELECT LotOrderItems_Guid, LotOrder_Guid, Parts_Guid, Measure_Guid, LotOrderItems_OrderQuantity, LotOrderItems_Quantity, 
		--	LotOrderItems_VendorPrice, LotOrderItems_DiscountPercent, LotOrderItems_DiscountVendorPrice, LotOrderItems_ConfirmQuantity,
		--	LotOrderItems_ExpDate, LotOrderItems_CustomTarifPercent, CountryProduction_Guid, LotOrderItems_PriceForCalcCostPrice
	 -- FROM @tLotOrderItems;
	 -- OPEN crLotOrderItems;
	 -- FETCH NEXT FROM crLotOrderItems INTO @LotOrderItems_Guid, @LotOrder_Guid2, @Parts_Guid, @Measure_Guid, @LotOrderItems_OrderQuantity, 
		--	@LotOrderItems_Quantity, @LotOrderItems_VendorPrice, @LotOrderItems_DiscountPercent, @LotOrderItems_DiscountVendorPrice, 
		--	@LotOrderItems_ConfirmQuantity, @LotOrderItems_ExpDate, @LotOrderItems_CustomTarifPercent, @CountryProduction_Guid, 
		--	@LotOrderItems_PriceForCalcCostPrice;
	 -- WHILE ( @@fetch_status = 0)
		--  BEGIN

		--		SET @PARTS_ID = NULL;
		--		SET @MEASURE_ID = NULL;
		--		SET @COUNTRY_ID = NULL;
		--		SET @IN_LOTORDERITMS_ID = NULL;
		--		SET @LOTORDERITMS_ID = NULL;
		--		SET @LOTORDERITMS_QUANTITY = 0;
		--		SET @PRICE_EXW = 0;
		--		SET @PRICE_INVOICE = 0;
		--		SET @PRICE_FORCALCCOSTPRICE = 0;
				
		--		SELECT @PARTS_ID = Parts_Id FROM T_Parts WHERE Parts_Guid = @Parts_Guid; 
		--		SELECT @MEASURE_ID = Measure_Id FROM T_Measure WHERE Measure_Guid = @Measure_Guid;
		--		SELECT @COUNTRY_ID = Country_Id FROM T_Country WHERE Country_Guid = @CountryProduction_Guid;

		--		IF( @DocType_Id = 1 ) -- Поставка	
		--			SET @LOTORDERITMS_QUANTITY = @LotOrderItems_ConfirmQuantity;
		--		ELSE IF( @DocType_Id = 0 ) -- Заказ
		--			SET @LOTORDERITMS_QUANTITY = @LotOrderItems_OrderQuantity;

		--		SET @PRICE_EXW = @LotOrderItems_VendorPrice;
		--		SET @PRICE_FORCALCCOSTPRICE = @LotOrderItems_PriceForCalcCostPrice;
		--		SET @PRICE_INVOICE = @LotOrderItems_DiscountVendorPrice;

		--		SET @LOTORDERITMS_CUSTOMTARIFPERCENT = @LotOrderItems_CustomTarifPercent;

  --      IF NOT EXISTS ( SELECT LotOrderItems_Guid FROM dbo.T_LotOrderItems  WHERE LotOrderItems_Guid = @LotOrderItems_Guid )
  --        BEGIN
		--				SET @IN_LOTORDERITMS_ID = 0;
		--				SET @ACTIONTYPE_ID = 0;

		--				SET @SQLString = 'select @LOTORDERITMS_IDsql = LOTORDERITMS_ID, @error_numbersql = ERROR_NUMBER, @error_textsql = ERROR_TEXT from openquery( ' + 
		--					@IBLINKEDSERVERNAME + ', ''select LOTORDERITMS_ID, ERROR_NUMBER, ERROR_TEXT from SP_EDITLOTORDERITMS_FROMSQL( '  + cast( @DocType_Id as nvarchar( 20))  + ', ' +
		--					cast( @IN_LOTORDERITMS_ID as nvarchar( 20)) + ', ' +  
		--					cast( @LotOrder_Id as nvarchar( 20)) + ', ' + cast( @PARTS_ID as nvarchar( 20)) + ', ' + cast( @MEASURE_ID as nvarchar( 20)) + ', ' + 
		--					cast( @LOTORDERITMS_QUANTITY as nvarchar( 56)) + ', ' + 
		--					cast( @PRICE_EXW as nvarchar( 56)) + ', ' + cast( @PRICE_INVOICE as nvarchar( 56)) + ', ' + cast( @PRICE_FORCALCCOSTPRICE as nvarchar( 56)) + ', ' + 
		--					cast( @LOTORDERITMS_CUSTOMTARIFPERCENT as nvarchar( 56)) + ', ' + cast( @COUNTRY_ID as nvarchar( 20)) + ', ' +  
		--					cast( @ACTIONTYPE_ID as nvarchar( 20)) + ')'')';

		--				execute sp_executesql @SQLString, @ParmDefinition, 
		--					@LOTORDERITMS_IDsql = @LOTORDERITMS_ID output, @error_numbersql = @ERROR_NUM output, @error_textsql = @ERROR_MES output;

		--				IF( ( @ERROR_NUM = 0 ) AND ( @LOTORDERITMS_ID IS NOT NULL )	AND ( @LOTORDERITMS_ID <> 0 ) )	
		--					INSERT INTO T_LotOrderItems( LotOrderItems_Guid, LotOrderItems_Id,	LotOrder_Guid,	Parts_Guid,	Measure_Guid,
		--						LotOrderItems_OrderQuantity,	LotOrderItems_Quantity,	LotOrderItems_ConfirmQuantity,
		--						LotOrderItems_VendorPrice,	LotOrderItems_DiscountPercent,	LotOrderItems_DiscountVendorPrice, LotOrderItems_ExpDate, 
		--						LotOrderItems_CustomTarifPercent, CountryProduction_Guid, LotOrderItems_PriceForCalcCostPrice )
		--					VALUES( @LotOrderItems_Guid, @LOTORDERITMS_ID, @LotOrder_Guid2, @Parts_Guid,	@Measure_Guid,
		--						@LotOrderItems_OrderQuantity,	@LotOrderItems_Quantity,	@LotOrderItems_ConfirmQuantity,
		--						@LotOrderItems_VendorPrice,	@LotOrderItems_DiscountPercent,	@LotOrderItems_DiscountVendorPrice, @LotOrderItems_ExpDate, 
		--						@LotOrderItems_CustomTarifPercent, @CountryProduction_Guid, @LotOrderItems_PriceForCalcCostPrice );	
		--				ELSE
		--					BEGIN
		--						SET @ERROR_MES = @ERROR_MES + ' код товара: ' + cast( @PARTS_ID as nvarchar( 20)) + ' ' + @SQLString;
		--						BREAK;
		--					END
								
  --        END  
  --      ELSE  
  --        BEGIN
		--				SET @ACTIONTYPE_ID = 1;
		--				SELECT @IN_LOTORDERITMS_ID = LotOrderItems_Id FROM dbo.T_LotOrderItems  WHERE LotOrderItems_Guid = @LotOrderItems_Guid;
						
		--				SET @SQLString = 'select @LOTORDERITMS_IDsql = LOTORDERITMS_ID, @error_numbersql = ERROR_NUMBER, @error_textsql = ERROR_TEXT from openquery( ' + 
		--					@IBLINKEDSERVERNAME + ', ''select LOTORDERITMS_ID, ERROR_NUMBER, ERROR_TEXT from SP_EDITLOTORDERITMS_FROMSQL( '  + cast( @DocType_Id as nvarchar( 20))  + ', ' + 
		--					cast( @IN_LOTORDERITMS_ID as nvarchar( 20))  + ', ' + 
		--					cast( @LotOrder_Id as nvarchar( 20)) + ', ' + cast( @PARTS_ID as nvarchar( 20)) + ', ' + cast( @MEASURE_ID as nvarchar( 20)) + ', ' + 
		--					cast( @LOTORDERITMS_QUANTITY as nvarchar( 56)) + ', ' + 
		--					cast( @PRICE_EXW as nvarchar( 56)) + ', ' + cast( @PRICE_INVOICE as nvarchar( 56)) + ', ' + cast( @PRICE_FORCALCCOSTPRICE as nvarchar( 56)) + ', ' + 
		--					cast( @LOTORDERITMS_CUSTOMTARIFPERCENT as nvarchar( 56)) + ', ' + cast( @COUNTRY_ID as nvarchar( 20)) + ', ' +  
		--					cast( @ACTIONTYPE_ID as nvarchar( 20)) + ')'')';

		--				execute sp_executesql @SQLString, @ParmDefinition, 
		--					@LOTORDERITMS_IDsql = @LOTORDERITMS_ID output, @error_numbersql = @ERROR_NUM output, @error_textsql = @ERROR_MES output;

		--				IF( ( @ERROR_NUM = 0 ) AND ( @LOTORDERITMS_ID IS NOT NULL )	AND ( @LOTORDERITMS_ID <> 0 ) AND ( @IN_LOTORDERITMS_ID = @LOTORDERITMS_ID ) )	
		--					UPDATE T_LotOrderItems SET Parts_Guid = @Parts_Guid, Measure_Guid = @Measure_Guid, LotOrderItems_OrderQuantity = @LotOrderItems_OrderQuantity, 
		--						LotOrderItems_Quantity = @LotOrderItems_Quantity, LotOrderItems_ConfirmQuantity = @LotOrderItems_ConfirmQuantity, 
		--						LotOrderItems_VendorPrice = @LotOrderItems_VendorPrice, LotOrderItems_DiscountPercent = @LotOrderItems_DiscountPercent,
		--						LotOrderItems_DiscountVendorPrice = @LotOrderItems_DiscountVendorPrice, LotOrderItems_ExpDate = @LotOrderItems_ExpDate, 
		--						LotOrderItems_CustomTarifPercent = @LotOrderItems_CustomTarifPercent, CountryProduction_Guid = @CountryProduction_Guid, 
		--						LotOrderItems_PriceForCalcCostPrice = @LotOrderItems_PriceForCalcCostPrice
		--					WHERE LotOrderItems_Guid = @LotOrderItems_Guid;
		--				ELSE
		--					BREAK;
  --        END  
          
		--	  FETCH NEXT FROM crLotOrderItems INTO @LotOrderItems_Guid, @LotOrder_Guid2, @Parts_Guid, @Measure_Guid, @LotOrderItems_OrderQuantity, 
		--			@LotOrderItems_Quantity, @LotOrderItems_VendorPrice, @LotOrderItems_DiscountPercent, @LotOrderItems_DiscountVendorPrice, 
		--			@LotOrderItems_ConfirmQuantity, @LotOrderItems_ExpDate, @LotOrderItems_CustomTarifPercent, @CountryProduction_Guid, 
		--			@LotOrderItems_PriceForCalcCostPrice;
		--  END -- while
  	
	 -- CLOSE crLotOrderItems;
	 -- DEALLOCATE crLotOrderItems;
	  
	 -- IF( @ERROR_NUM = 0 )
		--	BEGIN
		--		-- изменения в шапке заказа и в приложении к заказу прошли хорошо
		--		-- теперь необходимо удалить из приложения те позиции, которые были удалены
		--		DECLARE crLotOrderItemsDeleted CURSOR
		--		FOR SELECT LotOrderItems_Id FROM T_LotOrderItems WHERE LotOrder_Guid = @LotOrder_Guid AND LotOrderItems_Guid NOT IN ( SELECT LotOrderItems_Guid FROM @tLotOrderItems )
		--		OPEN crLotOrderItemsDeleted;
		--		FETCH NEXT FROM crLotOrderItemsDeleted INTO @IN_LOTORDERITMS_ID;
		--		WHILE ( @@fetch_status = 0)
		--			BEGIN
						
		--				SET @ACTIONTYPE_ID = 2;
						
		--				SET @SQLString = 'select @LOTORDERITMS_IDsql = LOTORDERITMS_ID, @error_numbersql = ERROR_NUMBER, @error_textsql = ERROR_TEXT from openquery( ' + 
		--					@IBLINKEDSERVERNAME + ', ''select LOTORDERITMS_ID, ERROR_NUMBER, ERROR_TEXT from SP_EDITLOTORDERITMS_FROMSQL( '  + cast( @DocType_Id as nvarchar( 20))  + ', ' + 
		--					cast( @IN_LOTORDERITMS_ID as nvarchar( 20))  + ', ' + 
		--					cast( @LotOrder_Id as nvarchar( 20)) + ', 0, 0, 0, 0, 0, 0, 0, 0, ' + cast( @ACTIONTYPE_ID as nvarchar( 20)) + ')'')';

		--				execute sp_executesql @SQLString, @ParmDefinition, 
		--					@LOTORDERITMS_IDsql = @LOTORDERITMS_ID output, @error_numbersql = @ERROR_NUM output, @error_textsql = @ERROR_MES output;
							
		--				IF( @ERROR_NUM <> 0 )	BREAK;
						
		--				FETCH NEXT FROM crLotOrderItemsDeleted INTO @IN_LOTORDERITMS_ID;
		--			END -- while
		  	
		--		CLOSE crLotOrderItemsDeleted;
		--		DEALLOCATE crLotOrderItemsDeleted;
				
		--		IF( @ERROR_NUM = 0 )
		--			BEGIN
		--				DELETE FROM dbo.T_LotOrderItems WHERE LotOrder_Guid = @LotOrder_Guid AND LotOrderItems_Guid NOT IN ( SELECT LotOrderItems_Guid FROM @tLotOrderItems );

		--				-- пересчёт сумм в шапке заказа
						
		--				IF( @DocType_Id = 0 )
		--					BEGIN
		--						SET @ParmDefinition = N'@error_numbersql int output, @error_textsql nvarchar(480) output'; 
		--						SET @SQLString = 'select  @error_numbersql = ERROR_NUMBER, @error_textsql = ERROR_TEXT from openquery( ' + @IBLINKEDSERVERNAME + 
		--							', ''select ERROR_NUMBER, ERROR_TEXT from SP_RECALCLOTORDER_FROMSQL( ' + 
		--						cast( @LotOrder_Id as nvarchar( 20)) + ')'')';
		--					END
		--				ELSE IF( @DocType_Id = 1 )	
		--					BEGIN
		--						SET @ParmDefinition = N'@error_numbersql int output, @error_textsql nvarchar(480) output'; 
		--						SET @SQLString = 'select  @error_numbersql = ERROR_NUMBER, @error_textsql = ERROR_TEXT from openquery( ' + @IBLINKEDSERVERNAME + 
		--							', ''select ERROR_NUMBER, ERROR_TEXT from SP_RECALCLOT_FROMSQL( ' + 
		--						cast( @LotOrder_Id as nvarchar( 20)) + ')'')';
		--					END
						

		--				execute sp_executesql @SQLString, @ParmDefinition, @error_numbersql = @ERROR_NUM output, @error_textsql = @ERROR_MES output;
						
		--				IF( @ERROR_NUM = 0 )
		--					BEGIN

		--						SELECT  @LotOrder_AllPriceEXW = SUM( [LotOrderItems_Quantity] * [LotOrderItems_VendorPrice] ), 
		--							@LotOrder_AllPriceInvoice = SUM( [LotOrderItems_Quantity] * [LotOrderItems_DiscountVendorPrice] ),
		--							@LotOrder_AllPriceForCalcCostPrice = SUM( [LotOrderItems_Quantity] * [LotOrderItems_PriceForCalcCostPrice])
		--						FROM T_LotOrderItems 
		--						WHERE LotOrder_Guid = @LotOrder_Guid;
    
		--						UPDATE T_LotOrder SET LotOrder_AllPrice = @LotOrder_AllPriceEXW,  LotOrder_AllDiscount = ( @LotOrder_AllPriceEXW - @LotOrder_AllPriceInvoice )
		--						WHERE LotOrder_Guid = @LotOrder_Guid;

		--					END

		--			END
				
		--	END

		
 	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = 'Ошибка редактирования в базе данных информации о приходе. ' + ERROR_MESSAGE();
	END CATCH;

		IF( @ERROR_NUM = 0 )	
			BEGIN
				SET @ERROR_MES = 'Успешное завершение операции.';
				COMMIT TRANSACTION UpdateData;
			END 
		ELSE	
			ROLLBACK TRANSACTION UpdateData;

	RETURN @ERROR_NUM;
END

GO
GRANT EXECUTE ON [dbo].[usp_EditLotOrder] TO [public]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Удаляет в базе данных InterBase информацию о приходе
--
-- Параметры:
--
-- [in] @Lot_Guid									- УИ прихода
-- [in] @IBLINKEDSERVERNAME				- Linked Server
--
-- [out]  @ERROR_NUM								- номер ошибки
-- [out]  @ERROR_MES								- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--			<>0 - ошибка
--
-- Возвращает:
--
CREATE PROCEDURE [dbo].[usp_DeleteLotFromIB]
	@Lot_Guid				D_GUID,
  @IBLINKEDSERVERNAME dbo.D_NAME = NULL,

  @ERROR_NUM int output,
  @ERROR_MES nvarchar(4000) output
AS

BEGIN
  BEGIN TRY
    SET @ERROR_NUM = 0;
    SET @ERROR_MES = '';
    IF( @IBLINKEDSERVERNAME IS NULL ) SELECT @IBLINKEDSERVERNAME = dbo.GetIBLinkedServerName();

		DECLARE @Lot_Id int;
		SELECT @Lot_Id = Lot_Id FROM dbo.T_Lot WHERE Lot_Guid = @Lot_Guid;
		
    DECLARE @SQLString nvarchar( 2048 );
    DECLARE @ParmDefinition nvarchar( 500 );
    
    IF( ( @Lot_Id IS NOT NULL ) AND ( @Lot_Id <> 0 ) )
			BEGIN

				SET @ParmDefinition = N'@error_numbersql int output, @error_textsql nvarchar(480) output'; 
				SET @SQLString = 'select  @error_numbersql = ERROR_NUMBER, @error_textsql = ERROR_TEXT from openquery( ' + @IBLINKEDSERVERNAME + 
					', ''select ERROR_NUMBER, ERROR_TEXT from SP_DELETELOT_FROMSQL( ' + 
				cast( @Lot_Id as nvarchar( 20)) + ')'')';

				execute sp_executesql @SQLString, @ParmDefinition, @error_numbersql = @ERROR_NUM output, @error_textsql = @ERROR_MES output;
				
			END
		
 	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = '[usp_DeleteLotFromIB]: ' + ERROR_MESSAGE();

		RETURN @ERROR_NUM;
	END CATCH;

  IF( @ERROR_NUM = 0 )
			SET @ERROR_MES = '[usp_DeleteLotFromIB] Успешное завершение операции.' + nChar(13) + nChar(10) + 
			  'Завершено удаление прихода в InterBase.' + nChar(13) + nChar(10) + 
				'УИ в IB: ' + CONVERT( nvarchar(8), @Lot_Id );

	RETURN @ERROR_NUM;

END

GO
GRANT EXECUTE ON [dbo].[usp_DeleteLotFromIB] TO [public]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Удаление элемента из таблицы dbo.T_Lot
--
-- Параметры:
--
-- [in] @Lot_Guid									- УИ прихода
-- [in] @IBLINKEDSERVERNAME				- Linked Server
--
-- [out]  @ERROR_NUM								- номер ошибки
-- [out]  @ERROR_MES								- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--			<>0 - ошибка

CREATE PROCEDURE [dbo].[usp_DeleteLot] 
	@Lot_Guid		D_GUID,

  @ERROR_NUM	int output,
  @ERROR_MES	nvarchar(4000) output

AS

BEGIN

  SET @ERROR_NUM = 0;
  SET @ERROR_MES = '';

	BEGIN TRANSACTION UpdateData;
	BEGIN TRY

		-- попробуем удалить заказ в InterBase
		EXEC usp_DeleteLotFromIB @Lot_Guid = @Lot_Guid,  
			@ERROR_NUM = @ERROR_NUM output, @ERROR_MES = @ERROR_MES output;

		IF( @ERROR_NUM = 0 )
			BEGIN
			 DELETE FROM dbo.T_LotItems WHERE Lot_Guid = @Lot_Guid;
			 DELETE FROM dbo.T_LotStateHistory WHERE Lot_Guid = @Lot_Guid;
			 DELETE FROM dbo.T_Lot WHERE Lot_Guid = @Lot_Guid;

				IF( @ERROR_NUM = 0 ) COMMIT TRANSACTION UpdateData
				 ELSE ROLLBACK TRANSACTION UpdateData;
			END

		END TRY
		BEGIN CATCH

			ROLLBACK TRANSACTION UpdateData;
			SET @ERROR_NUM = ERROR_NUMBER();
			SET @ERROR_MES = @ERROR_MES + nChar(13) + nChar(10) +  '[usp_DeleteLot] Текст ошибки: ' + ERROR_MESSAGE();

		END CATCH;

	IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
	RETURN @ERROR_NUM;
END

GO
GRANT EXECUTE ON [dbo].[usp_DeleteLot] TO [public]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Возвращает список записей из ( dbo.LotView )
--
-- Входные параметры:
--		@Lot_Guid				- УИ прихода
--		@BeginDate			- дата начала периода поиска
--		@EndDate				- дата окончания периода поиска
--
-- Выходные параметры:
--		@ERROR_NUM			- номер ошибки
--		@ERROR_MES			- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--    <>0 - ошибка запроса информации из базы данных

CREATE PROCEDURE [dbo].[usp_GetLot] 
	@Lot_Guid				D_GUID = NULL,
	@BeginDate			D_DATE = NULL,
	@EndDate				D_DATE = NULL,
	
  @ERROR_NUM			int output,
  @ERROR_MES			nvarchar(4000) output
AS

BEGIN

  SET @ERROR_NUM = 0;
  SET @ERROR_MES = NULL;

  BEGIN TRY

    IF( @Lot_Guid IS NULL )
			BEGIN
				IF( @BeginDate IS NULL ) SET @BeginDate = ( SELECT dbo.TrimTime( GetDate() ) );
				IF( @EndDate IS NULL ) SET @EndDate = @BeginDate;
				-- поиск по дате документа
				WITH Lot AS
				(
					SELECT Lot_Guid, Lot_Id, KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date, Lot_DocDate, Stock_Guid, Vendor_Guid, Currency_Guid, 
						LotState_Guid, Lot_CurrencyRate, Lot_AllPrice, Lot_CurrencyAllPrice, Lot_RetCurrencyAllPrice, Lot_Description, 
						Lot_IsActive, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, 
						Currency_Abbr, Currency_Code, Currency_ShortName, Currency_IsMain, 
						Vendor_Id, Vendor_Name, Vendor_Description, Vendor_IsActive, VendorType_Guid, 
						VendorType_Id, VendorType_Name, VendorType_Description, VendorType_IsActive, 
						Stock_Id, Warehouse_Guid, WarehouseType_Guid, Company_Guid, Stock_Name, Stock_IsActive, 
						Stock_IsTrade, Stock_InTransfer, WareHouseType_Name, WarehouseType_IsActive, 
						Company_Id, CompanyType_Guid, Company_Acronym, Company_OKPO, Company_OKULP, 
						Company_UNN, Company_IsActive, Company_Name, Company_Description, CompanyType_name, CompanyType_Description, CompanyType_IsActive, 
						CustomerStateType_Guid, CustomerStateType_Name, CustomerStateType_ShortName, CustomerStateType_IsActive
					FROM [dbo].[LotView]
					WHERE Lot_DocDate BETWEEN @BeginDate AND @EndDate
				)
				SELECT Lot.Lot_Guid, Lot_Id, Lot.KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date, Lot_DocDate, Lot.Stock_Guid, Vendor_Guid, Currency_Guid, 
						LotState_Guid, Lot_CurrencyRate, Lot_AllPrice, Lot_CurrencyAllPrice, Lot_RetCurrencyAllPrice, Lot_Description, 
						Lot_IsActive, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, 
						Currency_Abbr, Currency_Code, Currency_ShortName, Currency_IsMain, 
						Vendor_Id, Vendor_Name, Vendor_Description, Vendor_IsActive, VendorType_Guid, 
						VendorType_Id, VendorType_Name, VendorType_Description, VendorType_IsActive, 
						Stock_Id, Warehouse_Guid, WarehouseType_Guid, Company_Guid, Stock_Name, Stock_IsActive, 
						Stock_IsTrade, Stock_InTransfer, WareHouseType_Name, WarehouseType_IsActive, 
						Company_Id, CompanyType_Guid, Company_Acronym, Company_OKPO, Company_OKULP, 
						Company_UNN, Company_IsActive, Company_Name, Company_Description, CompanyType_name, CompanyType_Description, CompanyType_IsActive, 
						CustomerStateType_Guid, CustomerStateType_Name, CustomerStateType_ShortName, CustomerStateType_IsActive, 
						LotItems.Quantity, LotItems.RetQuantity, LotItems.LeavQuantity, 
						KLP.KLP_Date, KLP.KLP_Num
				FROM Lot 
				CROSS APPLY ( SELECT SUM( LotItems_Quantity ) AS Quantity, SUM( LotItems_RetQuantity ) AS RetQuantity, SUM( LotItems_LeavQuantity ) AS LeavQuantity
						FROM [dbo].[T_LotItems]   
						WHERE Lot_Guid = Lot.Lot_Guid ) LotItems LEFT OUTER JOIN [dbo].[T_KLP] AS KLP ON Lot.KLP_Guid = KLP.KLP_Guid
				ORDER BY Lot_Date;

			END
		ELSE	
			BEGIN
				SELECT Lot_Guid, Lot_Id, [dbo].[LotView].KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date, Lot_DocDate, [dbo].[LotView].Stock_Guid, Vendor_Guid, Currency_Guid, 
							LotState_Guid, Lot_CurrencyRate, Lot_AllPrice, Lot_CurrencyAllPrice, Lot_RetCurrencyAllPrice, Lot_Description, 
							Lot_IsActive, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, 
							Currency_Abbr, Currency_Code, Currency_ShortName, Currency_IsMain, 
							Vendor_Id, Vendor_Name, Vendor_Description, Vendor_IsActive, VendorType_Guid, 
							VendorType_Id, VendorType_Name, VendorType_Description, VendorType_IsActive, 
							Stock_Id, Warehouse_Guid, WarehouseType_Guid, Company_Guid, Stock_Name, Stock_IsActive, 
							Stock_IsTrade, Stock_InTransfer, WareHouseType_Name, WarehouseType_IsActive, 
							Company_Id, CompanyType_Guid, Company_Acronym, Company_OKPO, Company_OKULP, 
							Company_UNN, Company_IsActive, Company_Name, Company_Description, CompanyType_name, CompanyType_Description, CompanyType_IsActive, 
							CustomerStateType_Guid, CustomerStateType_Name, CustomerStateType_ShortName, CustomerStateType_IsActive,
							LotItems.Quantity, LotItems.RetQuantity, LotItems.LeavQuantity,
							KLP.KLP_Date, KLP.KLP_Num
				FROM [dbo].[LotView]
				CROSS APPLY ( SELECT SUM( LotItems_Quantity ) AS Quantity, SUM( LotItems_RetQuantity ) AS RetQuantity, SUM( LotItems_LeavQuantity ) AS LeavQuantity
						FROM [dbo].[T_LotItems]   
						WHERE Lot_Guid = [dbo].[LotView].Lot_Guid ) LotItems INNER JOIN [dbo].[T_KLP] AS KLP ON [dbo].[LotView].KLP_Guid = KLP.KLP_Guid
				WHERE [dbo].[LotView].KLP_Guid IS NOT NULL
					AND [dbo].[LotView].KLP_Guid = @Lot_Guid
				ORDER BY Lot_Date;
			END
	END TRY
	BEGIN CATCH
		SET @ERROR_NUM = ERROR_NUMBER();
		SET @ERROR_MES = ERROR_MESSAGE();
	END CATCH;

  IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
  RETURN @ERROR_NUM;
END

GO
GRANT EXECUTE ON [dbo].[usp_GetLot] TO [public]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Возвращает список записей из ( dbo.LotItemsView )
--
-- Входные параметры:
--		@Lot_Guid				- УИ прихода
--
-- Выходные параметры:
--		@ERROR_NUM			- номер ошибки
--		@ERROR_MES			- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--    <>0 - ошибка запроса информации из базы данных

CREATE PROCEDURE [dbo].[usp_GetLotItems] 
	@Lot_Guid				D_GUID,
	
  @ERROR_NUM			int output,
  @ERROR_MES			nvarchar(4000) output
AS

BEGIN

  SET @ERROR_NUM = 0;
  SET @ERROR_MES = '';

  BEGIN TRY
  
		SELECT LotItems_Guid, LotItems_Id, Lot_Guid, KLPItems_Guid, Parts_Guid, Measure_Guid, LotItems_Quantity, LotItems_RetQuantity, LotItems_LeavQuantity, 
			LotItems_Price, LotItems_CurrencyPrice, LotItems_AllPrice, LotItems_CurrencyAllPrice, LotItems_ExpDate, CountryProduction_Guid, 
			Country_ISOCode, Country_Name, Country_Code, Country_Id, Measure_Id, Measure_Code, Measure_Name, Measure_ShortName, 
			KLP_Guid, Parts_Id, Parts_OriginalName, Parts_Name, Parts_ShortName, Parts_Article, Parts_IsActive
		FROM dbo.LotItemsView
		WHERE Lot_Guid = @Lot_Guid
		ORDER BY Parts_Name
	END TRY
	BEGIN CATCH
		SET @ERROR_NUM = ERROR_NUMBER();
		SET @ERROR_MES = ERROR_MESSAGE();
	END CATCH;

  IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
  RETURN @ERROR_NUM;
END

GO
GRANT EXECUTE ON [dbo].[usp_GetLotItems] TO [public]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Редактирует в базе данных информацию о состоянии прихода
--
-- Параметры:
-- [in] @Lot_Guid					- УИ заказа
-- [in] @LotState_Guid			- УИ состояния прихода
--
-- [out]  @Lot_Id					- УИ прихода в InterBase
-- [out]  @ERROR_NUM				- номер ошибки
-- [out]  @ERROR_MES				- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--		<>0 - ошибка
--
-- Возвращает:
--

CREATE PROCEDURE [dbo].[usp_ChangeLotState]
  @Lot_Guid				D_GUID,
	@LotState_Guid	D_GUID,
	
	@Lot_Id					D_ID out,
  @ERROR_NUM			int output,
  @ERROR_MES			nvarchar(4000) output
AS

BEGIN

  BEGIN TRY
    SET @ERROR_NUM = 0;
    SET @ERROR_MES = '';

    -- Проверяем наличие прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT Lot_Guid FROM dbo.T_Lot WHERE Lot_Guid = @Lot_Guid )
      BEGIN
        SET @ERROR_NUM = 1;
        SET @ERROR_MES = 'В базе данных не найден приход с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Lot_Guid  );
        RETURN @ERROR_NUM;
      END

    -- Проверяем наличие записи о состоянии прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT LotState_Guid FROM dbo.T_LotState WHERE LotState_Guid = @LotState_Guid )
      BEGIN
        SET @ERROR_NUM = 2;
        SET @ERROR_MES = 'В базе данных не найдена запись о состоянии прихода с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @LotState_Guid  );
        RETURN @ERROR_NUM;
      END

		DECLARE @CurrentLotState_Guid D_GUID = NULL;
		
		SELECT @CurrentLotState_Guid = LotState_Guid, @Lot_Id = Lot_Id 
		FROM dbo.T_Lot WHERE Lot_Guid = @Lot_Guid;
		
		IF( @CurrentLotState_Guid = @LotState_Guid )
			BEGIN
				SET @ERROR_NUM = 0;
				SET @ERROR_MES = 'Успешное завершение операции.';
				
				RETURN @ERROR_NUM;
			END

		DECLARE @LotStateLot_Guid D_GUID = NULL;
		SELECT @LotStateLot_Guid = dbo.GetLotOrderStateLOT();
		

    BEGIN TRANSACTION UpdateData;
    
			UPDATE dbo.T_Lot SET LotState_Guid = @LotState_Guid WHERE Lot_Guid = @Lot_Guid;
			SET @ERROR_NUM = 0;
			SET @ERROR_MES = 'Состояние прихода успешно оизменено.';
		
 	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = 'Ошибка редактирования состояния прихода. ' + ERROR_MESSAGE();
	END CATCH;

	IF( @ERROR_NUM = 0 )	
		BEGIN
			SET @ERROR_MES = 'Успешное завершение операции.';
			COMMIT TRANSACTION UpdateData;
		END 
	ELSE	
		ROLLBACK TRANSACTION UpdateData;

	RETURN @ERROR_NUM;
END

GO
GRANT EXECUTE ON [dbo].[usp_ChangeLotState] TO [public]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Возвращает список записей из ( dbo.KLPItemsView ) как источник данных для документа "Приход на склад"
--
-- Входные параметры:
--		@KLP_Guid	- УИ КЛП
--
-- Выходные параметры:
--
-- Результат:
--    0 - успешное завершение
--    <>0 - ошибка запроса информации из базы данных

CREATE PROCEDURE [dbo].[usp_GetSrcForLotItems] 
	@KLP_Guid	D_GUID,
	
  @ERROR_NUM			int output,
  @ERROR_MES			nvarchar(4000) output
AS

BEGIN

  SET @ERROR_NUM = 0;
  SET @ERROR_MES = '';

  BEGIN TRY
  
		SELECT KLPItems_Guid, KLPItems_Id, KLP_Guid, Parts_Guid, Measure_Guid, LotOrderItems_Guid, KLPItems_Quantity, KLPItems_FactQuantity, 
			KLPItems_DiscountVendorPrice, KLPItems_CurrencyPrice, KLPItems_AllDiscountVendorPrice, KLPItems_FactAllDiscountVendorPrice, 
			KLPItems_AllCurrencyPrice, KLPItems_FactAllCurrencyPrice, 
			Parts_Id, Parts_OriginalName, Parts_Name, Parts_ShortName, Parts_Article, Parts_PackQuantity, Parts_BoxQuantity, 
			Parts_Weight, Parts_IsActive, Parts_PlasticContainerWeight, Parts_PaperContainerWeight, Parts_AlcoholicContentPercent, 
			Parts_VendorPrice, Parts_NotValid, Parts_ActualNotValid, Parts_Certificate, Parts_CodeTNVD, 
			Parts_Reference, Parts_PackQuantityForCalc, Parts_CustomTariff, 
			Measure_Id, Measure_Name, Measure_ShortName, 
			CountryProduction_Guid, Country_Id, Country_Name, PartsOwner_Guid
		FROM [dbo].[KLPItemsView]
		WHERE [KLP_Guid] = @KLP_Guid
		ORDER BY Parts_Name
	END TRY
	BEGIN CATCH
		SET @ERROR_NUM = ERROR_NUMBER();
		SET @ERROR_MES = ERROR_MESSAGE();
		RETURN @ERROR_NUM;
	END CATCH;

  IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
  RETURN @ERROR_NUM;
END

GO
GRANT EXECUTE ON [dbo].[usp_GetSrcForLotItems] TO [public]
GO

/****** Object:  StoredProcedure [dbo].[usp_GetLot]    Script Date: 11.06.2013 14:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Возвращает список записей из ( dbo.LotView )
--
-- Входные параметры:
--		@KLP_Guid				- УИ КЛП
--		@BeginDate			- дата начала периода поиска
--		@EndDate				- дата окончания периода поиска
--
-- Выходные параметры:
--		@ERROR_NUM			- номер ошибки
--		@ERROR_MES			- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--    <>0 - ошибка запроса информации из базы данных

ALTER PROCEDURE [dbo].[usp_GetLot] 
	@KLP_Guid				D_GUID = NULL,
	@BeginDate			D_DATE = NULL,
	@EndDate				D_DATE = NULL,
	
  @ERROR_NUM			int output,
  @ERROR_MES			nvarchar(4000) output
AS

BEGIN

  SET @ERROR_NUM = 0;
  SET @ERROR_MES = NULL;

  BEGIN TRY

    IF( @KLP_Guid IS NULL )
			BEGIN
				IF( @BeginDate IS NULL ) SET @BeginDate = ( SELECT dbo.TrimTime( GetDate() ) );
				IF( @EndDate IS NULL ) SET @EndDate = @BeginDate;
				-- поиск по дате документа
				WITH Lot AS
				(
					SELECT Lot_Guid, Lot_Id, KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date, Lot_DocDate, Stock_Guid, Vendor_Guid, Currency_Guid, 
						LotState_Guid, Lot_CurrencyRate, Lot_AllPrice, Lot_CurrencyAllPrice, Lot_RetCurrencyAllPrice, Lot_Description, 
						Lot_IsActive, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, 
						Currency_Abbr, Currency_Code, Currency_ShortName, Currency_IsMain, 
						Vendor_Id, Vendor_Name, Vendor_Description, Vendor_IsActive, VendorType_Guid, 
						VendorType_Id, VendorType_Name, VendorType_Description, VendorType_IsActive, 
						Stock_Id, Warehouse_Guid, WarehouseType_Guid, Company_Guid, Stock_Name, Stock_IsActive, 
						Stock_IsTrade, Stock_InTransfer, WareHouseType_Name, WarehouseType_IsActive, 
						Company_Id, CompanyType_Guid, Company_Acronym, Company_OKPO, Company_OKULP, 
						Company_UNN, Company_IsActive, Company_Name, Company_Description, CompanyType_name, CompanyType_Description, CompanyType_IsActive, 
						CustomerStateType_Guid, CustomerStateType_Name, CustomerStateType_ShortName, CustomerStateType_IsActive
					FROM [dbo].[LotView]
					WHERE Lot_DocDate BETWEEN @BeginDate AND @EndDate
				)
				SELECT Lot.Lot_Guid, Lot_Id, KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date, Lot_DocDate, Stock_Guid, Vendor_Guid, Currency_Guid, 
						LotState_Guid, Lot_CurrencyRate, Lot_AllPrice, Lot_CurrencyAllPrice, Lot_RetCurrencyAllPrice, Lot_Description, 
						Lot_IsActive, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, 
						Currency_Abbr, Currency_Code, Currency_ShortName, Currency_IsMain, 
						Vendor_Id, Vendor_Name, Vendor_Description, Vendor_IsActive, VendorType_Guid, 
						VendorType_Id, VendorType_Name, VendorType_Description, VendorType_IsActive, 
						Stock_Id, Warehouse_Guid, WarehouseType_Guid, Company_Guid, Stock_Name, Stock_IsActive, 
						Stock_IsTrade, Stock_InTransfer, WareHouseType_Name, WarehouseType_IsActive, 
						Company_Id, CompanyType_Guid, Company_Acronym, Company_OKPO, Company_OKULP, 
						Company_UNN, Company_IsActive, Company_Name, Company_Description, CompanyType_name, CompanyType_Description, CompanyType_IsActive, 
						CustomerStateType_Guid, CustomerStateType_Name, CustomerStateType_ShortName, CustomerStateType_IsActive, 
						LotItems.Quantity, LotItems.RetQuantity, LotItems.LeavQuantity
				FROM Lot 
				CROSS APPLY ( SELECT SUM( LotItems_Quantity ) AS Quantity, SUM( LotItems_RetQuantity ) AS RetQuantity, SUM( LotItems_LeavQuantity ) AS LeavQuantity
						FROM [dbo].[T_LotItems]   
						WHERE Lot_Guid = Lot.Lot_Guid ) LotItems
				ORDER BY Lot_Date;

			END
		ELSE	
			BEGIN
				SELECT Lot_Guid, Lot_Id, KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date, Lot_DocDate, Stock_Guid, Vendor_Guid, Currency_Guid, 
							LotState_Guid, Lot_CurrencyRate, Lot_AllPrice, Lot_CurrencyAllPrice, Lot_RetCurrencyAllPrice, Lot_Description, 
							Lot_IsActive, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, 
							Currency_Abbr, Currency_Code, Currency_ShortName, Currency_IsMain, 
							Vendor_Id, Vendor_Name, Vendor_Description, Vendor_IsActive, VendorType_Guid, 
							VendorType_Id, VendorType_Name, VendorType_Description, VendorType_IsActive, 
							Stock_Id, Warehouse_Guid, WarehouseType_Guid, Company_Guid, Stock_Name, Stock_IsActive, 
							Stock_IsTrade, Stock_InTransfer, WareHouseType_Name, WarehouseType_IsActive, 
							Company_Id, CompanyType_Guid, Company_Acronym, Company_OKPO, Company_OKULP, 
							Company_UNN, Company_IsActive, Company_Name, Company_Description, CompanyType_name, CompanyType_Description, CompanyType_IsActive, 
							CustomerStateType_Guid, CustomerStateType_Name, CustomerStateType_ShortName, CustomerStateType_IsActive,
							LotItems.Quantity, LotItems.RetQuantity, LotItems.LeavQuantity
				FROM [dbo].[LotView]
				CROSS APPLY ( SELECT SUM( LotItems_Quantity ) AS Quantity, SUM( LotItems_RetQuantity ) AS RetQuantity, SUM( LotItems_LeavQuantity ) AS LeavQuantity
						FROM [dbo].[T_LotItems]   
						WHERE Lot_Guid = [dbo].[LotView].Lot_Guid ) LotItems
				WHERE KLP_Guid IS NOT NULL
					AND KLP_Guid = @KLP_Guid
				ORDER BY Lot_Date;
			END
	END TRY
	BEGIN CATCH
		SET @ERROR_NUM = ERROR_NUMBER();
		SET @ERROR_MES = ERROR_MESSAGE();
	END CATCH;

  IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
  RETURN @ERROR_NUM;
END
GO

/****** Object:  View [dbo].[KLPItemsView]    Script Date: 12.06.2013 11:03:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[KLPItemsView]
AS
SELECT     dbo.T_KLPItems.KLPItems_Guid, dbo.T_KLPItems.KLPItems_Id, dbo.T_KLPItems.KLP_Guid, dbo.T_KLPItems.Parts_Guid, dbo.T_KLPItems.Measure_Guid, 
                      dbo.T_KLPItems.LotOrderItems_Guid, dbo.T_KLPItems.KLPItems_Quantity, dbo.T_KLPItems.KLPItems_FactQuantity, dbo.T_KLPItems.KLPItems_DiscountVendorPrice, 
                      dbo.T_KLPItems.KLPItems_CurrencyPrice, dbo.T_KLPItems.KLPItems_AllDiscountVendorPrice, dbo.T_KLPItems.KLPItems_FactAllDiscountVendorPrice, 
                      dbo.T_KLPItems.KLPItems_AllCurrencyPrice, dbo.T_KLPItems.KLPItems_FactAllCurrencyPrice, dbo.T_Parts.Parts_Guid AS Expr1, dbo.T_Parts.Parts_Id, 
                      dbo.T_Parts.Parts_OriginalName, dbo.T_Parts.Parts_Name, dbo.T_Parts.Parts_ShortName, dbo.T_Parts.Parts_Article, dbo.T_Parts.Parts_PackQuantity, 
                      dbo.T_Parts.Parts_BoxQuantity, dbo.T_Parts.Parts_Weight, dbo.T_Parts.Parts_IsActive, dbo.T_Parts.Parts_PlasticContainerWeight, 
                      dbo.T_Parts.Parts_PaperContainerWeight, dbo.T_Parts.Parts_AlcoholicContentPercent, dbo.T_Parts.Parts_VendorPrice, dbo.T_Parts.Parts_NotValid, 
                      dbo.T_Parts.Parts_ActualNotValid, dbo.T_Parts.Parts_Certificate, dbo.T_Parts.Parts_CodeTNVD, dbo.T_Parts.Parts_Reference, 
                      dbo.T_Parts.Parts_PackQuantityForCalc, dbo.T_Parts.Parts_CustomTariff, dbo.T_Measure.Measure_Id, dbo.T_Measure.Measure_Name, 
                      dbo.T_Measure.Measure_ShortName, dbo.T_KLPItems.KLPItems_CustomTarifPercent, dbo.T_KLPItems.CountryProduction_Guid, dbo.T_Country.Country_Id, 
                      dbo.T_Country.Country_Name, dbo.GetOwnerGuidForParts(dbo.T_KLPItems.Parts_Guid) AS PartsOwner_Guid, dbo.T_LotOrderItems.LotOrderItems_ExpDate
FROM         dbo.T_KLPItems INNER JOIN
                      dbo.T_Parts ON dbo.T_KLPItems.Parts_Guid = dbo.T_Parts.Parts_Guid INNER JOIN
                      dbo.T_Measure ON dbo.T_KLPItems.Measure_Guid = dbo.T_Measure.Measure_Guid INNER JOIN
                      dbo.T_Country ON dbo.T_KLPItems.CountryProduction_Guid = dbo.T_Country.Country_Guid LEFT OUTER JOIN
                      dbo.T_LotOrderItems ON dbo.T_KLPItems.LotOrderItems_Guid = dbo.T_LotOrderItems.LotOrderItems_Guid

GO

/****** Object:  StoredProcedure [dbo].[usp_GetKLPItems]    Script Date: 12.06.2013 11:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Возвращает список записей из ( dbo.KLPItemsView )
--
-- Входные параметры:
--	@KLP_Guid	- УИ КЛП
--
-- Выходные параметры:
--
-- Результат:
--    0 - успешное завершение
--    <>0 - ошибка запроса информации из базы данных

ALTER PROCEDURE [dbo].[usp_GetKLPItems] 
	@KLP_Guid	D_GUID,
	
  @ERROR_NUM			int output,
  @ERROR_MES			nvarchar(4000) output
AS

BEGIN

  SET @ERROR_NUM = 0;
  SET @ERROR_MES = '';

  BEGIN TRY
  
		SELECT KLPItems_Guid, KLPItems_Id, Parts_Guid, Measure_Guid, LotOrderItems_Guid, KLPItems_Quantity, 
			KLPItems_FactQuantity, KLPItems_DiscountVendorPrice, KLPItems_CurrencyPrice, KLPItems_AllDiscountVendorPrice, 
			KLPItems_FactAllDiscountVendorPrice, KLPItems_AllCurrencyPrice, KLPItems_FactAllCurrencyPrice, 
			Parts_Id, Parts_OriginalName, Parts_Name, Parts_ShortName, Parts_Article, Parts_PackQuantity, 
			Parts_BoxQuantity, Parts_Weight, Parts_IsActive, Parts_PlasticContainerWeight, Parts_PaperContainerWeight, 
			Parts_AlcoholicContentPercent, Parts_VendorPrice, Parts_NotValid, Parts_ActualNotValid, Parts_Certificate, 
			Parts_CodeTNVD, Parts_Reference, Parts_PackQuantityForCalc, Parts_CustomTariff, 
			Measure_Id, Measure_Name, Measure_ShortName, KLPItems_CustomTarifPercent, CountryProduction_Guid, Country_Name, Country_Id, 
			cast( dbo.GetBarcodeForParts( Parts_Guid ) as nvarchar( 13 ) ) AS PartsBarcode, 
			PartsOwner_Guid, LotOrderItems_ExpDate
		FROM dbo.KLPItemsView
		WHERE KLP_Guid = @KLP_Guid
		ORDER BY Parts_Name
	END TRY
	BEGIN CATCH
		SET @ERROR_NUM = ERROR_NUMBER();
		SET @ERROR_MES = ERROR_MESSAGE();
		RETURN @ERROR_NUM;
	END CATCH;

  IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
  RETURN @ERROR_NUM;
END

GO

	INSERT INTO [dbo].[T_LotState](LotState_Guid, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, Record_Updated, Record_UserUdpated, LotState_IsRequire )
	VALUES( NEWID(), 'Создан', NULL, 0, 1, Getdate(), 'Admin', 1 )

	INSERT INTO [dbo].[T_LotState](LotState_Guid, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, Record_Updated, Record_UserUdpated, LotState_IsRequire )
	VALUES( NEWID(), 'Поставлен на приход', NULL, 1, 1, Getdate(), 'Admin', 1 )

	GO


DECLARE @doc xml;

SET @doc = '<ImportDataInOrderSettings> 
  <ColumnItem TOOLS_ID="70" TOOLS_NAME="STARTROW" TOOLS_USERNAME="Начальная строка" TOOLS_DESCRIPTION="№ строки, с которой начинается импорт данных" TOOLS_VALUE="2" TOOLSTYPE_ID="10" />
  <ColumnItem TOOLS_ID="71" TOOLS_NAME="PARTS_ID" TOOLS_USERNAME="Код товара" TOOLS_DESCRIPTION="№ столбца с кодом товара" TOOLS_VALUE="1" TOOLSTYPE_ID="10" />
  <ColumnItem TOOLS_ID="72" TOOLS_NAME="QUANTITY" TOOLS_USERNAME="Количество" TOOLS_DESCRIPTION="№ столбца с количеством товара" TOOLS_VALUE="2" TOOLSTYPE_ID="10" />
  <ColumnItem TOOLS_ID="73" TOOLS_NAME="EXPDATE" TOOLS_USERNAME="Срок годности" TOOLS_DESCRIPTION="№ столбца с информацией о сроке годности" TOOLS_VALUE="3" TOOLSTYPE_ID="10" />
</ImportDataInOrderSettings>';

INSERT INTO [dbo].[T_Settings]( Settings_Guid, Settings_Name, Settings_XML, Record_Updated, Record_UserUdpated )
VALUES( NEWID(), 'SettingsForImportDataInLotByPartsId', @doc, GetDate(), 'Admin' );

/****** Object:  StoredProcedure [dbo].[usp_GetImportDataInLotOrderByPartsIdSettings]    Script Date: 18.06.2013 9:49:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Возвращает список записей из ( dbo.T_Settings )
--
-- Входные параметры:
--
-- Выходные параметры:
--
-- Результат:
--    0 - успешное завершение
--    <>0 - ошибка запроса информации из базы данных

CREATE PROCEDURE [dbo].[usp_GetSettingsForImportDataInLot] 
  @ERROR_NUM int output,
  @ERROR_MES nvarchar(4000) output
AS

BEGIN

  SET @ERROR_NUM = 0;
  SET @ERROR_MES = NULL;

  BEGIN TRY

    SELECT Top 1 Settings_Guid, Settings_Name, Settings_XML
    FROM dbo.T_Settings
    WHERE Settings_Name = 'SettingsForImportDataInLotByPartsId';

	END TRY
	BEGIN CATCH
		SET @ERROR_NUM = ERROR_NUMBER();
		SET @ERROR_MES = ERROR_MESSAGE();
		RETURN @ERROR_NUM;
	END CATCH;

  IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
  RETURN @ERROR_NUM;
END

GO
GRANT EXECUTE ON [dbo].[usp_GetSettingsForImportDataInLot] TO [public]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
	

CREATE FUNCTION [dbo].[GetLotStateLOT]()
RETURNS D_GUID
WITH EXECUTE AS caller
AS
BEGIN
  
DECLARE @LotState_Guid D_GUID = NULL;

-- необходимо реализовать константу, как настройку в T_Settings
DECLARE	@LotStateId D_ID = 1;
SELECT @LotState_Guid = LotState_Guid FROM dbo.T_LotState WHERE LotState_OrderNum = @LotStateId;

RETURN @LotState_Guid
end

GO
GRANT EXECUTE ON [dbo].[GetLotStateLOT] TO [public]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Регистрация в InterBase прихода на склад

-- Параметры:
-- [in] @Lot_Guid									- УИ прихода
-- [in] @IBLINKEDSERVERNAME				- Linked Server к InterBase
--
-- [out]  @Lot_Id									- УИ прихода в InterBase
-- [out]  @ERROR_NUM							- номер ошибки
-- [out]  @ERROR_MES							- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--			<>0 - ошибка
--
-- Возвращает:
--

ALTER PROCEDURE [dbo].[usp_AddLotToIB]
  @IBLINKEDSERVERNAME	dbo.D_NAME = NULL,
  @Lot_Guid						D_GUID,

  @Lot_Id							D_ID output,
  @ERROR_NUM					int output,
  @ERROR_MES					nvarchar(4000) output
AS

BEGIN
	DECLARE @StartProcessSuppl D_DATETIME;
	SET @StartProcessSuppl = GetDate();

  BEGIN TRY
    SET @ERROR_NUM = 0;
    SET @ERROR_MES = '';
    SET @Lot_Id = 0;
    
 	  IF( @IBLINKEDSERVERNAME IS NULL ) SELECT @IBLINKEDSERVERNAME = dbo.GetIBLinkedServerName();

    DECLARE @VENDOR_ID D_ID;
    DECLARE @STOCK_ID int;
    DECLARE @LOT_DOCDATE D_DATE;
    DECLARE @LOT_DATE D_DATE;
    DECLARE @LOT_SHIPDATE D_DATE;
    DECLARE @LOT_STOCKDATE D_DATE;
    DECLARE @LOT_ACCEPTDATE D_DATE;
    DECLARE @LOT_SRCCODE int = 0;
    DECLARE @LOT_SRCID int = 0;
    DECLARE @LOT_NUM D_NAMESHORT;
    DECLARE @LOT_DOCNUM D_NAMESHORT;
    DECLARE @LOT_WAYBILLNUM D_NAMESHORT;
    DECLARE @CURRENCY_CODE D_NAMESHORT;
    DECLARE @LOT_CURRENCYRATE D_MONEY;
    DECLARE @LOT_ALLPRICE D_MONEY = 0;
    DECLARE @LOT_CURRENCYALLPRICE D_MONEY = 0;
    DECLARE @LOT_VENDORMARKUP D_MONEY = 0;
    DECLARE @LOT_CURRENCYALLVENDORPRICE D_MONEY = 0;
    DECLARE @LOT_EURRATE D_MONEY = 0;

		-- запрашиваем данные, необходимые для создания прихода на стороне IB
		DECLARE @Vendor_Guid					D_GUID;
		DECLARE @Currency_Guid				D_GUID;
		DECLARE @Stock_Guid						D_GUID;
		DECLARE @KLP_Guid						D_GUID;

		SELECT @Vendor_Guid = [Vendor_Guid], @Stock_Guid = [Stock_Guid], @KLP_Guid = [KLP_Guid], 
		 @LOT_DOCDATE = [Lot_DocDate], @LOT_DATE = [Lot_Date], @LOT_NUM = Substring( [Lot_Num], 1, 16),  
		 @LOT_DOCNUM = Substring( [Lot_DocNum], 1, 16 ),  @LOT_CURRENCYRATE = [Lot_CurrencyRate], @LOT_WAYBILLNUM = Substring( [Lot_DocNum], 1, 16 ), 
		 @LOT_ALLPRICE = [Lot_AllPrice], @LOT_CURRENCYALLPRICE = [Lot_CurrencyAllPrice], @LOT_CURRENCYALLVENDORPRICE = [Lot_AllPrice], 
		 @Currency_Guid = Currency_Guid
		FROM dbo.T_Lot
		WHERE Lot_Guid = @Lot_Guid;

    SET @LOT_SHIPDATE = @LOT_DOCDATE;
    SET @LOT_STOCKDATE = @LOT_DOCDATE;
    SET @LOT_ACCEPTDATE = @LOT_DOCDATE;
		SET @LOT_NUM = '''''' + @LOT_NUM + '''''';
		SET @LOT_DOCNUM = '''''' + @LOT_DOCNUM + '''''';
		SET @LOT_WAYBILLNUM = '''''' + @LOT_WAYBILLNUM + '''''';

		IF( @KLP_Guid IS NULL ) SET @LOT_SRCCODE = 0
			ELSE 
				BEGIN
					SET @LOT_SRCCODE = 2;
					SELECT @LOT_SRCID = [KLP_Id] FROM [dbo].[T_KLP] WHERE [KLP_Guid] = @KLP_Guid;
				END
		SELECT @STOCK_ID = [Stock_Id] FROM [dbo].[T_Stock] WHERE [Stock_Guid] = @Stock_Guid;
		SELECT @VENDOR_ID = Vendor_Id FROM dbo.T_Vendor WHERE Vendor_Guid = @Vendor_Guid;
		SELECT @CURRENCY_CODE = Currency_Abbr FROM dbo.T_Currency WHERE Currency_Guid = @Currency_Guid;

		DECLARE @strLOT_DOCDATE varchar( 24 );
		DECLARE @strLOT_DATE varchar( 24 );
		DECLARE @strLOT_SHIPDATE varchar( 24 );
		DECLARE @strLOT_STOCKDATE varchar( 24 );
		DECLARE @strLOT_ACCEPTDATE varchar( 24 );

		IF( @LOT_DOCDATE IS NULL ) SET @strLOT_DOCDATE = 'NULL'
		ELSE 
			BEGIN
				SET @strLOT_DOCDATE = convert( varchar( 10), @LOT_DOCDATE, 104);
				SET @strLOT_DOCDATE = '''''' + @strLOT_DOCDATE + '''''';
			END	
		
		IF( @LOT_DATE IS NULL ) SET @strLOT_DATE = 'NULL'
		ELSE 
			BEGIN
				SET @strLOT_DATE = convert( varchar( 10), @LOT_DATE, 104);
				SET @strLOT_DATE = '''''' + @strLOT_DATE + '''''';
			END	

		IF( @LOT_SHIPDATE IS NULL ) SET @strLOT_SHIPDATE = 'NULL'
		ELSE 
			BEGIN
				SET @strLOT_SHIPDATE = convert( varchar( 10), @LOT_SHIPDATE, 104);
				SET @strLOT_SHIPDATE = '''''' + @strLOT_SHIPDATE + '''''';
			END	
		
		IF( @LOT_STOCKDATE IS NULL ) SET @strLOT_STOCKDATE = 'NULL'
		ELSE 
			BEGIN
				SET @strLOT_STOCKDATE = convert( varchar( 10), @LOT_STOCKDATE, 104);
				SET @strLOT_STOCKDATE = '''''' + @strLOT_STOCKDATE + '''''';
			END	
		
		IF( @LOT_ACCEPTDATE IS NULL ) SET @strLOT_ACCEPTDATE = 'NULL'
		ELSE 
			BEGIN
				SET @strLOT_ACCEPTDATE = convert( varchar( 10), @LOT_ACCEPTDATE, 104);
				SET @strLOT_ACCEPTDATE = '''''' + @strLOT_ACCEPTDATE + '''''';
			END	

    DECLARE @uuidEUR D_GUID;
    DECLARE @strEUR D_CURRENCYCODE = 'EUR';
    SELECT @uuidEUR = Currency_Guid FROM dbo.T_Currency WHERE Currency_Abbr = @strEUR;

		SELECT @LOT_EURRATE = dbo.GetCurrencyRateInOut( @Currency_Guid, @uuidEUR, @LOT_DOCDATE );	
		IF( @LOT_EURRATE IS NULL ) SET @LOT_EURRATE = @LOT_CURRENCYALLPRICE;

		IF( @CURRENCY_CODE = 'RUB' ) SET @CURRENCY_CODE = 'RUR';			
		SET @CURRENCY_CODE = '''''' + @CURRENCY_CODE + '''''';
		

    DECLARE @SQLString nvarchar( 3048);
    DECLARE @ParmDefinition nvarchar(500);
    DECLARE @SQLStringForDiscount nvarchar( 3048);
    DECLARE @ParmDefinitionForDiscount nvarchar(500);
    DECLARE @RETURNVALUE int;
		
    SET @ParmDefinition = N'@lot_idsql int output, @error_numbersql int output, @error_textsql nvarchar(480) output'; 

    -- Добавляем запись в таблицу T_LOTORDER в InterBase
    SET @SQLString = 'select @lot_idsql = lot_id, @error_numbersql = ERROR_NUMBER, @error_textsql = ERROR_TEXT from openquery( ' + 
			@IBLINKEDSERVERNAME + ', ''select lot_id, ERROR_NUMBER, ERROR_TEXT from SP_ADDLOT_FROMSQL( ' + 
			cast( @VENDOR_ID as nvarchar( 20))  + ', ' + cast( @STOCK_ID as nvarchar( 20))  + ', ' +
			@strLOT_DOCDATE + ', ' + cast( @LOT_SRCCODE as nvarchar(10))  + ', ' + cast( @LOT_SRCID as nvarchar( 20))  + ', ' + 
			@LOT_NUM + ', ' + @LOT_DOCNUM + ', ' + @LOT_WAYBILLNUM + ', ' + 
			cast( @LOT_ALLPRICE as nvarchar( 56)) + ', ' + @CURRENCY_CODE + ', ' + 
			cast( @LOT_CURRENCYRATE as nvarchar( 56)) + ', ' + cast( @LOT_CURRENCYALLPRICE as nvarchar( 56)) + ', ' + 
			cast( @LOT_VENDORMARKUP as nvarchar( 56)) + ', ' + cast( @LOT_CURRENCYALLVENDORPRICE as nvarchar( 56)) + ', ' + 
			cast( @LOT_EURRATE as nvarchar( 56)) + ')'')'; 

		PRINT '@SQLString';
		PRINT @SQLString;

    EXECUTE sp_executesql @SQLString, @ParmDefinition, 
			@lot_idsql = @Lot_Id output, @error_numbersql = @ERROR_NUM output, @error_textsql = @ERROR_MES output;

		PRINT 'выполнена процедура SP_ADDLOT_FROMSQL';
		PRINT GetDate();

    IF( ( @ERROR_NUM <> 0 ) OR ( @Lot_Id IS NULL ) OR ( @Lot_Id = 0 ) ) -- ошибка при сохранении заголовка прихода в IB
	    RETURN @ERROR_NUM;
		
		PRINT @Lot_Id;
		
		-- заголовок прихода сохранён, сохраняется приложение к приходу
		DECLARE @LotItems_Guid D_GUID;
		DECLARE @LOTITMS_ID int;
    DECLARE @PARTS_ID int;
    DECLARE @MEASURE_ID int;
		DECLARE @COUNTRY_ID int;
    DECLARE @LOTITMS_QUANTITY int;
    DECLARE @LOTITMS_PRICE float;
    DECLARE @LOTITMS_CURRENCYPRICE float;
		DECLARE @LOTITMS_VENDORMARKUP float;
		DECLARE @LOTITMS_EXPDATE D_DATE;
		DECLARE @strLOTITMS_EXPDATE varchar( 24 );

    CREATE TABLE #LotItems( LotItems_Guid uniqueidentifier, PARTS_ID int, MEASURE_ID int, LOTITMS_QUANTITY int, 
			LOTITMS_PRICE float, LOTITMS_CURRENCYPRICE float, LOTITMS_VENDORMARKUP float, COUNTRY_ID int, LOTITMS_EXPDATE smalldatetime );
    INSERT INTO #LotItems( LotItems_Guid, PARTS_ID, MEASURE_ID, LOTITMS_QUANTITY, 
			LOTITMS_PRICE, LOTITMS_CURRENCYPRICE, LOTITMS_VENDORMARKUP, COUNTRY_ID, LOTITMS_EXPDATE )
    SELECT LotItems_Guid, Parts_Id, Measure_Id, LotItems_Quantity, 
			[LotItems_Price], [LotItems_CurrencyPrice], 0, [Country_Id], [LotItems_ExpDate]
    FROM dbo.LotItemsView WHERE Lot_Guid = @Lot_Guid;
		
    SET @ParmDefinition = N'@LOTITMS_IDsql int output, @error_numbersql int output, @error_textsql nvarchar(480) output'; 

		-- каждая позиция сохраняется в IB
    DECLARE crLotItms CURSOR 
    FOR SELECT LotItems_Guid, PARTS_ID, MEASURE_ID, LOTITMS_QUANTITY, 
			LOTITMS_PRICE, LOTITMS_CURRENCYPRICE, LOTITMS_VENDORMARKUP, COUNTRY_ID, LOTITMS_EXPDATE 
    FROM #LotItems;
    OPEN crLotItms;
    FETCH NEXT FROM crLotItms INTO @LotItems_Guid, @PARTS_ID, @MEASURE_ID, @LOTITMS_QUANTITY, 
			@LOTITMS_PRICE, @LOTITMS_CURRENCYPRICE, @LOTITMS_VENDORMARKUP, @COUNTRY_ID, @LOTITMS_EXPDATE; 
    WHILE @@FETCH_STATUS = 0
      BEGIN
				BEGIN TRY
					
					IF( @LOTITMS_EXPDATE IS NULL ) SET @strLOTITMS_EXPDATE = 'NULL'
					ELSE 
						BEGIN
							SET @strLOTITMS_EXPDATE = convert( varchar( 10), @LOTITMS_EXPDATE, 104);
							SET @strLOTITMS_EXPDATE = '''''' + @strLOTITMS_EXPDATE + '''''';
						END	

					SET @SQLString = 'select @LOTITMS_IDsql = LOTITMS_ID, @error_numbersql = ERROR_NUMBER, @error_textsql = ERROR_TEXT from openquery( ' + 
						@IBLINKEDSERVERNAME + ', ''select LOTITMS_ID, ERROR_NUMBER, ERROR_TEXT from SP_ADDLOTITMS_FROMSQL( ' + 
						cast( @LOT_ID as nvarchar( 20 ) ) + ', ' + cast( @PARTS_ID as nvarchar( 20)) + ', ' + cast( @MEASURE_ID as nvarchar( 20)) + ', ' + 
						cast( @LOTITMS_QUANTITY as nvarchar( 56)) + ', ' + cast( @LOTITMS_PRICE as nvarchar( 56)) + ', ' + 
						cast( @LOTITMS_CURRENCYPRICE as nvarchar( 56)) + ', ' + cast( @LOTITMS_VENDORMARKUP as nvarchar( 56)) + ', ' + 
						cast( @COUNTRY_ID as nvarchar( 20 ) ) + ', ' + @strLOTITMS_EXPDATE +  ')'')';

					execute sp_executesql @SQLString, @ParmDefinition, 
						@LOTITMS_IDsql = @LOTITMS_ID output, @error_numbersql = @ERROR_NUM output, @error_textsql = @ERROR_MES output;
						
					IF( ( @ERROR_NUM = 0 ) AND ( @LOTITMS_ID IS NOT NULL )	AND ( @LOTITMS_ID <> 0 ) ) 
						UPDATE dbo.T_LotItems SET LotItems_Id = @LOTITMS_ID WHERE LotItems_Guid = @LotItems_Guid;
					
				END TRY
				BEGIN CATCH
					SET @ERROR_NUM = ERROR_NUMBER();
					SET @ERROR_MES = '[usp_AddLoToIB] Текст ошибки: ' + ERROR_MESSAGE();
				END CATCH;
       FETCH NEXT FROM crLotItms INTO @LotItems_Guid, @PARTS_ID, @MEASURE_ID, @LOTITMS_QUANTITY, 
			@LOTITMS_PRICE, @LOTITMS_CURRENCYPRICE, @LOTITMS_VENDORMARKUP, @COUNTRY_ID, @LOTITMS_EXPDATE; 
      END 
    
    CLOSE crLotItms;
    DEALLOCATE crLotItms;
    
    DROP TABLE #LotItems;
    
		PRINT 'выполнена процедура SP_ADDLOTITMS_FROMSQL';
		PRINT GetDate();
    
    IF( @ERROR_NUM = 0 )
			BEGIN
				-- шапка и приложение к приходу сохранились без ошибок
				-- теперь необходимо сформировать остаток и накладную на ответственное хранение в IB
				SET @ParmDefinition = N'@error_numbersql int output, @error_textsql nvarchar(480) output'; 
				SET @SQLString = 'select  @error_numbersql = ERROR_NUMBER, @error_textsql = ERROR_TEXT from openquery( ' + @IBLINKEDSERVERNAME + 
					', ''select ERROR_NUMBER, ERROR_TEXT from SP_CREATEINSTOCK_FROMLOT( ' + 
				cast( @Lot_Id as nvarchar( 20)) + ')'')';

				execute sp_executesql @SQLString, @ParmDefinition, @error_numbersql = @ERROR_NUM output, @error_textsql = @ERROR_MES output;

				PRINT 'выполнена процедура SP_CREATEINSTOCK_FROMLOT';
				PRINT GetDate();

				IF( @ERROR_NUM = 0 )
					UPDATE [dbo].[T_Lot] SET [Lot_Id] = @Lot_Id WHERE [Lot_Guid] = @Lot_Guid;
				ELSE
					UPDATE dbo.T_LotItems SET LotItems_Id = 0 WHERE [Lot_Guid] = @Lot_Guid;

			END
		ELSE	
			BEGIN
				UPDATE dbo.T_LotItems SET LotItems_Id = 0 WHERE [Lot_Guid] = @Lot_Guid;
			END


 	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = '[usp_AddLotToIB]: ' + ERROR_MESSAGE();

		RETURN @ERROR_NUM;
	END CATCH;

  IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Приход успешно сохранён в IB';

	RETURN @ERROR_NUM;

END

GO

/****** Object:  StoredProcedure [dbo].[usp_AddLot]    Script Date: 21.06.2013 13:28:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Добавляет в базу данных информацию о приходе
--
-- Параметры:
-- [in] @tLotItems										- приложение к приходу
-- [in] @Lot_Num											- номер партии
-- [in] @Lot_Date										- дата прихода
-- [in] @Lot_Num											- номер приходной накладной
-- [in] @Lot_DocDate									- дата приходной накладной
-- [in] @Vendor_Guid									- УИ поставщика
-- [in] @Currency_Guid								- УИ валюты прихода
-- [in] @Stock_Guid									- УИ склада
-- [in] @Lot_Description							- примечание
-- [in] @Lotr_IsActive								- признак "приход активен"
-- [in] @LotState_Guid								- УИ состояния прихода
-- [in] @Lot_CurrencyRate						- курс пересчёта валюты прихода в ОВУ
--
-- [out]  @Lot_Guid									- УИ прихода
-- [out]  @Lot_Id										- УИ прихода в InterBase
-- [out]  @Lot_AllPrice							- себестоимость в валюте прихода
-- [out]  @Lot_CurrencyAllPrice			- себестоимость в ОВУ
-- [out]  @Lot_RetCurrencyAllPrice		- сумма возврата по накладной по себестоимости в ОВУ
-- [out]  @ERROR_NUM									- номер ошибки
-- [out]  @ERROR_MES									- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--			<>0 - ошибка
--
-- Возвращает:
--

ALTER PROCEDURE [dbo].[usp_AddLot]
	@KLP_Guid									D_GUID = NULL,
	@Lot_Num									D_NAMESHORT,
	@Lot_DocNum								D_NAMESHORT,
	@Lot_Date									D_DATE,
	@Lot_DocDate							D_DATE,
	@Vendor_Guid							D_GUID,
	@Stock_Guid								D_GUID,
	@Currency_Guid						D_GUID,
	@Lot_Description					D_DESCRIPTION = NULL,
	@Lot_IsActive							D_ISACTIVE = 1, 
	@LotState_Guid						D_GUID,
	@Lot_CurrencyRate					D_MONEY,

	@tLotItems								dbo.udt_LotItems  READONLY,

  @Lot_Guid									D_GUID output,
  @Lot_Id										D_ID output,
	@Lot_AllPrice							D_MONEY output,
	@Lot_CurrencyAllPrice			D_MONEY output,
	@Lot_RetCurrencyAllPrice	D_MONEY output,

  @ERROR_NUM								int output,
  @ERROR_MES								nvarchar(4000) output
AS


BEGIN

  BEGIN TRY
    SET @ERROR_NUM = 0;
    SET @ERROR_MES = '';
    SET @Lot_Guid = NULL;
    SET @Lot_Id = 0;
    SET @Lot_AllPrice = 0;
    SET @Lot_CurrencyAllPrice = 0;
    SET @Lot_RetCurrencyAllPrice = 0;
    
    -- Проверяем наличие поставщика с указанным идентификатором
    IF NOT EXISTS ( SELECT Vendor_Guid FROM dbo.T_Vendor WHERE Vendor_Guid = @Vendor_Guid )
      BEGIN
        SET @ERROR_NUM = 1;
        SET @ERROR_MES = 'В базе данных не найден поставщик с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Vendor_Guid  );
        RETURN @ERROR_NUM;
      END
    
    -- Проверяем наличие валюты с указанным идентификатором
    IF NOT EXISTS ( SELECT Currency_Guid FROM dbo.T_Currency WHERE Currency_Guid = @Currency_Guid )
      BEGIN
        SET @ERROR_NUM = 2;
        SET @ERROR_MES = 'В базе данных не найдена валюта с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Currency_Guid  );
        RETURN @ERROR_NUM;
      END

    -- Проверяем наличие записи о состоянии прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT LotState_Guid FROM dbo.T_LotState WHERE LotState_Guid = @LotState_Guid )
      BEGIN
        SET @ERROR_NUM = 3;
        SET @ERROR_MES = 'В базе данных не найдена запись о состоянии прихода с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @LotState_Guid  );
        RETURN @ERROR_NUM;
      END

    -- Проверяем наличие записи о складе прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT Stock_Guid FROM dbo.T_Stock WHERE Stock_Guid = @Stock_Guid )
      BEGIN
        SET @ERROR_NUM = 4;
        SET @ERROR_MES = 'В базе данных не найдена запись о складе с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Stock_Guid  );
        RETURN @ERROR_NUM;
      END

		-- Регистрируем шапку прихода
    DECLARE @NewID D_GUID;
    SET @NewID = NEWID( );	

    BEGIN TRANSACTION UpdateData;

		INSERT INTO T_Lot( Lot_Guid, Lot_Id, KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date, Lot_DocDate, 
			Stock_Guid, Vendor_Guid, Currency_Guid, LotState_Guid, 
			Lot_CurrencyRate, Lot_AllPrice, Lot_CurrencyAllPrice, Lot_RetCurrencyAllPrice, 
			Lot_Description, Lot_IsActive, Record_Updated, Record_UserUdpated )
		VALUES( @NewID, @Lot_Id, @KLP_Guid, @Lot_Num, @Lot_DocNum, @Lot_Date, @Lot_DocDate, 
			@Stock_Guid, @Vendor_Guid, @Currency_Guid, @LotState_Guid, 
			@Lot_CurrencyRate, @Lot_AllPrice, @Lot_CurrencyAllPrice, @Lot_RetCurrencyAllPrice, @Lot_Description, @Lot_IsActive,
			sysutcdatetime(), ( Host_Name() + ': ' + SUSER_SNAME() ) );
		
		-- Приложение к приходу
		INSERT INTO T_LotItems( LotItems_Guid, LotItems_Id, Lot_Guid,	KLPItems_Guid,	Parts_Guid,	Measure_Guid,
			LotItems_Quantity,	LotItems_RetQuantity,	LotItems_Price,	LotItems_CurrencyPrice,	LotItems_ExpDate,	CountryProduction_Guid  )
		SELECT LotItems_Guid, 0, @NewID,	KLPItems_Guid,	Parts_Guid,	Measure_Guid,
			LotItems_Quantity,	LotItems_RetQuantity,	LotItems_Price,	LotItems_CurrencyPrice,	LotItems_ExpDate,	CountryProduction_Guid
		FROM @tLotItems;
		
    SELECT  @Lot_AllPrice = SUM( [LotItems_Quantity] * [LotItems_Price] ), 
			@Lot_CurrencyAllPrice = SUM( [LotItems_Quantity] * [LotItems_CurrencyPrice] ),
			@Lot_RetCurrencyAllPrice = SUM( [LotItems_RetQuantity] * [LotItems_CurrencyPrice])
    FROM T_LotItems 
    WHERE Lot_Guid = @NewID;
    
		UPDATE T_Lot SET Lot_AllPrice = @Lot_AllPrice, Lot_CurrencyAllPrice = @Lot_CurrencyAllPrice, 
		 Lot_RetCurrencyAllPrice = @Lot_RetCurrencyAllPrice
		WHERE Lot_Guid = @NewID;

		INSERT INTO dbo.T_LotStateHistory( LotStateHistory_Guid, Lot_Guid, LotState_Date, LotState_Guid, Record_Updated, Record_UserUdpated )
		VALUES( NEWID(), @NewID, sysutcdatetime(), @LotState_Guid, sysutcdatetime(), ( Host_Name() + ': ' + SUSER_SNAME() ) );	
		
		SET @Lot_Guid = @NewID;

		IF( @ERROR_NUM = 0 )	
			BEGIN
				UPDATE dbo.T_Lot SET Lot_Id = @Lot_Id
				WHERE Lot_Guid = @Lot_Guid;
				
				COMMIT TRANSACTION UpdateData;
			END 
		ELSE	
			ROLLBACK TRANSACTION UpdateData;

		   
 	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = 'Ошибка добавления в базу данных информации о приходе. ' + ERROR_MESSAGE();
    
		RETURN @ERROR_NUM;
	END CATCH;

	IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
	RETURN @ERROR_NUM;
END

GO

/****** Object:  StoredProcedure [dbo].[usp_ChangeLotState]    Script Date: 21.06.2013 13:29:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Редактирует в базе данных информацию о состоянии прихода
--
-- Параметры:
-- [in] @Lot_Guid					- УИ заказа
-- [in] @LotState_Guid			- УИ состояния прихода
--
-- [out]  @Lot_Id					- УИ прихода в InterBase
-- [out]  @ERROR_NUM				- номер ошибки
-- [out]  @ERROR_MES				- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--		<>0 - ошибка
--
-- Возвращает:
--

ALTER PROCEDURE [dbo].[usp_ChangeLotState]
  @Lot_Guid				D_GUID,
	@LotState_Guid	D_GUID,
	
	@Lot_Id					D_ID out,
  @ERROR_NUM			int output,
  @ERROR_MES			nvarchar(4000) output
AS

BEGIN

  BEGIN TRY
    SET @ERROR_NUM = 0;
    SET @ERROR_MES = '';

    -- Проверяем наличие прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT Lot_Guid FROM dbo.T_Lot WHERE Lot_Guid = @Lot_Guid )
      BEGIN
        SET @ERROR_NUM = 1;
        SET @ERROR_MES = 'В базе данных не найден приход с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Lot_Guid  );
        RETURN @ERROR_NUM;
      END

    -- Проверяем наличие записи о состоянии прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT LotState_Guid FROM dbo.T_LotState WHERE LotState_Guid = @LotState_Guid )
      BEGIN
        SET @ERROR_NUM = 2;
        SET @ERROR_MES = 'В базе данных не найдена запись о состоянии прихода с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @LotState_Guid  );
        RETURN @ERROR_NUM;
      END

		DECLARE @CurrentLotState_Guid D_GUID = NULL;
		
		SELECT @CurrentLotState_Guid = LotState_Guid, @Lot_Id = Lot_Id 
		FROM dbo.T_Lot WHERE Lot_Guid = @Lot_Guid;
		
		IF( @CurrentLotState_Guid = @LotState_Guid )
			BEGIN
				SET @ERROR_NUM = 0;
				SET @ERROR_MES = 'Успешное завершение операции.';
				
				RETURN @ERROR_NUM;
			END

		DECLARE @LotStateLot_Guid D_GUID = NULL;
		SELECT @LotStateLot_Guid = dbo.GetLotStateLOT();
		

    BEGIN TRANSACTION UpdateData;
    
			IF( ( @LotStateLot_Guid IS NOT NULL ) AND ( @LotStateLot_Guid = @LotState_Guid ) )
				BEGIN
					-- постановка на приход
					EXEC dbo.usp_AddLotToIB @Lot_Guid = @Lot_Guid, @Lot_Id = @Lot_Id out, 
						@ERROR_NUM = @ERROR_NUM out, @ERROR_MES = @ERROR_MES out;

					IF( @ERROR_NUM = 0 )	
						UPDATE dbo.T_Lot SET LotState_Guid = @LotStateLot_Guid	WHERE Lot_Guid = @Lot_Guid;
				END
			ELSE
				BEGIN
					UPDATE dbo.T_Lot SET LotState_Guid = @LotState_Guid WHERE Lot_Guid = @Lot_Guid;
					SET @ERROR_NUM = 0;
					SET @ERROR_MES = 'Состояние прихода успешно оизменено.';
				END	
		
 	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = 'Ошибка редактирования состояния прихода. ' + ERROR_MESSAGE();
	END CATCH;

	IF( @ERROR_NUM = 0 )	
		BEGIN
			SET @ERROR_MES = 'Успешное завершение операции.';
			COMMIT TRANSACTION UpdateData;
		END 
	ELSE	
		ROLLBACK TRANSACTION UpdateData;

	RETURN @ERROR_NUM;
END

GO

/****** Object:  StoredProcedure [dbo].[usp_GetEarningInfoFromIB]    Script Date: 21.06.2013 16:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Корректировка себестоимости в КЛП на основании данных из Interbase 
--
-- Входные параметры
--
--		@KLP_Guid						- УИ КЛП
--		@IBLINKEDSERVERNAME	- имя LinkedServer
--
-- Выходные параметры
--
--		@ERROR_NUM					- код ошбики
--		@ERROR_MES					- сообщение об ошибке
--
CREATE PROCEDURE [dbo].[usp_CorrectCostPriceInKLP] 
	@KLP_Guid				D_GUID,
  @IBLINKEDSERVERNAME	D_NAME = NULL,
  
  @ERROR_NUM					int output,
  @ERROR_MES					nvarchar(4000) output
  
AS
-- процедура предназначена для выборки данных из справочника цен в InterBase
BEGIN
	SET NOCOUNT ON;
	
  SET @ERROR_NUM = 0;
  SET @ERROR_MES = '';

  IF( @IBLINKEDSERVERNAME IS NULL ) SELECT @IBLINKEDSERVERNAME = dbo.GetIBLinkedServerName();
  
	declare @sql_text nvarchar( 1000);
	
	BEGIN TRY

    DECLARE @KLP_IDsql int;
    DECLARE @KLP_CostIsCalcsql int;

		SELECT @KLP_IDsql = KLP_Id, @KLP_CostIsCalcsql = [KLP_CostIsCalc] FROM T_KLP WHERE KLP_Guid = @KLP_Guid;

		if( @KLP_IDsql IS NULL )
			BEGIN
				SET @ERROR_NUM = 1;
				SET @ERROR_MES = 'В базе данных не найден КЛП с указанным идентификатором: ' + CAST( @KLP_Guid as nvarchar(36) );
			END

	  IF( @IBLINKEDSERVERNAME IS NULL ) SELECT @IBLINKEDSERVERNAME = dbo.GetIBLinkedServerName();
	  
    DECLARE @SQLString nvarchar( 2048 );
    DECLARE @ParmDefinition nvarchar( 500 );
		DECLARE @KLP_ID int;
		DECLARE @KLP_DONEPRICE int;

    SET @ParmDefinition = N' @KLP_ID_OUT_Ib int output, @KLP_DONEPRICE_Ib int output'; 				

		SET @SQLString = 'SELECT @KLP_ID_OUT_Ib = KLP_ID, @KLP_DONEPRICE_Ib = KLP_DONEPRICE FROM OPENQUERY( ' + 
			@IBLINKEDSERVERNAME + ', ''SELECT KLP_ID, KLP_DONEPRICE FROM T_KLP WHERE KLP_ID = ' + cast( @KLP_IDsql as nvarchar(20)) + ''' )'; 
		
		PRINT @SQLString;

    EXECUTE sp_executesql @SQLString, @ParmDefinition, @KLP_ID_OUT_Ib = @KLP_ID output, @KLP_DONEPRICE_Ib = @KLP_DONEPRICE output;  

		if( @KLP_ID IS NULL )
			BEGIN
				SET @ERROR_NUM = 2;
				SET @ERROR_MES = 'В базе данных InterBase не найден КЛП с указанным идентификатором: ' + CAST( @KLP_IDsql as nvarchar(36) );
				
				RETURN @ERROR_NUM;
			END

		IF( ( @KLP_DONEPRICE = 1 ) AND ( @KLP_CostIsCalcsql = 0 ) )
			BEGIN
				-- в InterBase себестоимость проставлена, а в SQLServer нет
				CREATE TABLE #KLPItems( KLPITMS_ID int,  PARTS_ID INT,  KLPITMS_REALQTY INT,  KLPITMS_CURRENCYPRICE money );

				SELECT @SQLString = dbo.GetTextQueryForSelectFromInterbase( null, null, 
					' SELECT  KLPITMS_ID, PARTS_ID, KLPITMS_REALQTY, KLPITMS_CURRENCYPRICE	FROM T_KLPITMS WHERE KLP_ID =  ' +  cast( @KLP_ID as nvarchar(20)) );
					SET @SQLString = ' INSERT INTO #KLPItems( KLPITMS_ID,  PARTS_ID, KLPITMS_REALQTY, KLPITMS_CURRENCYPRICE ) ' + @SQLString;  

				PRINT @SQLString;

				execute sp_executesql @SQLString;

				SELECT * FROM #KLPItems;

				BEGIN TRY
					BEGIN TRANSACTION UpdateData;

					DECLARE @KLPITMS_ID int;
					DECLARE @KLPITMS_CURRENCYPRICE money;

					DECLARE crSynch_1 CURSOR FOR SELECT KLPITMS_ID, KLPITMS_CURRENCYPRICE FROM #KLPItems;
					OPEN crSynch_1;
					FETCH next FROM crSynch_1 INTO @KLPITMS_ID, @KLPITMS_CURRENCYPRICE;
					WHILE @@fetch_status = 0
						BEGIN
							
							UPDATE [dbo].[T_KLPItems] SET [KLPItems_CurrencyPrice] = @KLPITMS_CURRENCYPRICE
							WHERE [KLP_Guid] = @KLP_Guid AND [KLPItems_Id] = @KLPITMS_ID;

							FETCH next FROM crSynch_1 INTO @KLPITMS_ID, @KLPITMS_CURRENCYPRICE;
						END
					CLOSE crSynch_1;
					DEALLOCATE crSynch_1;

					UPDATE [dbo].[T_KLP] SET [KLP_CostIsCalc] = 1 WHERE [KLP_Guid] = @KLP_Guid;

					COMMIT TRANSACTION UpdateData;
				END TRY
				BEGIN CATCH
					ROLLBACK TRANSACTION UpdateData;

					SET @ERROR_NUM = ERROR_NUMBER();
					SET @ERROR_MES = ERROR_MESSAGE();

					RETURN @ERROR_NUM;
				END CATCH;

				DROP TABLE #KLPItems;
			END

 	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = ERROR_MESSAGE();

		RETURN @ERROR_NUM;
	END CATCH;

	RETURN @ERROR_NUM;

END

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Корректировка себестоимости в КЛП на основании данных из Interbase за указанный период
--
-- Входные параметры
--
--		@Begin_Date	- Начало периода
--		@End_Date	- Окончание периода
--		@IBLINKEDSERVERNAME	- имя LinkedServer
--
-- Выходные параметры
--
--		@ERROR_NUM					- код ошбики
--		@ERROR_MES					- сообщение об ошибке
--
CREATE PROCEDURE [dbo].[usp_CorrectCostPriceInKLPForDatePeriod] 
  @Begin_Date					D_DATE = NULL,
	@End_Date						D_DATE = NULL,
  @IBLINKEDSERVERNAME	D_NAME = NULL,
	  
  @ERROR_NUM					int output,
  @ERROR_MES					nvarchar(4000) output
  
AS

BEGIN
	SET NOCOUNT ON;
	
  SET @ERROR_NUM = 0;
  SET @ERROR_MES = '';
	IF ( @Begin_Date IS NULL ) SET @Begin_Date = ( SELECT dbo.GetBeginYear( GETDATE() ) );
	IF ( @Begin_Date IS NULL ) SET @End_Date = ( SELECT GETDATE() );

  IF( @IBLINKEDSERVERNAME IS NULL ) SELECT @IBLINKEDSERVERNAME = dbo.GetIBLinkedServerName();
  
	DECLARE	@KLP_Guid	D_GUID;
	
	BEGIN TRY


  DECLARE crSynch CURSOR FOR SELECT KLP_Guid 
		FROM dbo.T_KLP  WHERE [KLP_Date] BETWEEN @Begin_Date AND @End_Date AND [KLP_CostIsCalc] = 0;
  OPEN crSynch;
  FETCH next FROM crSynch INTO @KLP_Guid;
  WHILE @@fetch_status = 0
	  BEGIN
		
	    EXEC dbo.usp_CorrectCostPriceInKLP @KLP_Guid = @KLP_Guid, @ERROR_NUM = @ERROR_NUM output, @ERROR_MES = @ERROR_MES output;

			PRINT @ERROR_NUM;

		  FETCH next FROM crSynch INTO @KLP_Guid;
	  END
  CLOSE crSynch;
  DEALLOCATE crSynch;

 	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = ERROR_MESSAGE();

		CLOSE crSynch;
		DEALLOCATE crSynch;

		RETURN @ERROR_NUM;
	END CATCH;

	
	IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
	
	RETURN @ERROR_NUM;

END

GO

ALTER TABLE T_Lot ADD StoreWaybill_DocNum D_NAMESHORT NULL
GO

ALTER TABLE T_Lot ADD StoreWaybill_DocDate D_DATE NULL
GO

/****** Object:  View [dbo].[LotView]    Script Date: 21.06.2013 17:51:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[LotView]
AS
SELECT     dbo.T_Lot.Lot_Guid, dbo.T_Lot.Lot_Id, dbo.T_Lot.KLP_Guid, dbo.T_Lot.Lot_Num, dbo.T_Lot.Lot_DocNum, dbo.T_Lot.Lot_Date, dbo.T_Lot.Lot_DocDate, 
                      dbo.T_Lot.Stock_Guid, dbo.T_Lot.Vendor_Guid, dbo.T_Lot.Currency_Guid, dbo.T_Lot.LotState_Guid, dbo.T_Lot.Lot_CurrencyRate, dbo.T_Lot.Lot_AllPrice, 
                      dbo.T_Lot.Lot_CurrencyAllPrice, dbo.T_Lot.Lot_RetCurrencyAllPrice, dbo.T_Lot.Lot_Description, dbo.T_Lot.Lot_IsActive, dbo.T_LotState.LotState_Name, 
                      dbo.T_LotState.LotState_Description, dbo.T_LotState.LotState_OrderNum, dbo.T_LotState.LotState_IsActive, dbo.T_LotState.LotState_IsRequire, 
                      dbo.T_Currency.Currency_Abbr, dbo.T_Currency.Currency_Code, dbo.T_Currency.Currency_ShortName, dbo.T_Currency.Currency_IsMain, dbo.T_Vendor.Vendor_Id, 
                      dbo.T_Vendor.Vendor_Name, dbo.T_Vendor.Vendor_Description, dbo.T_Vendor.Vendor_IsActive, dbo.T_Vendor.VendorType_Guid, dbo.T_VendorType.VendorType_Id, 
                      dbo.T_VendorType.VendorType_Name, dbo.T_VendorType.VendorType_Description, dbo.T_VendorType.VendorType_IsActive, dbo.T_Stock.Stock_Id, 
                      dbo.T_Stock.Warehouse_Guid, dbo.T_Stock.WarehouseType_Guid, dbo.T_Stock.Company_Guid, dbo.T_Stock.Stock_Name, dbo.T_Stock.Stock_IsActive, 
                      dbo.T_Stock.Stock_IsTrade, dbo.T_Stock.Stock_InTransfer, dbo.T_WarehouseType.WareHouseType_Name, dbo.T_WarehouseType.WarehouseType_IsActive, 
                      dbo.T_Company.Company_Id, dbo.T_Company.CompanyType_Guid, dbo.T_Company.Company_Acronym, dbo.T_Company.Company_OKPO, 
                      dbo.T_Company.Company_OKULP, dbo.T_Company.Company_UNN, dbo.T_Company.Company_IsActive, dbo.T_Company.Company_Name, 
                      dbo.T_Company.Company_Description, dbo.T_CompanyType.CompanyType_name, dbo.T_CompanyType.CompanyType_Description, 
                      dbo.T_CompanyType.CompanyType_IsActive, dbo.T_Company.CustomerStateType_Guid, dbo.T_CustomerStateType.CustomerStateType_Name, 
                      dbo.T_CustomerStateType.CustomerStateType_ShortName, dbo.T_CustomerStateType.CustomerStateType_IsActive,
											dbo.T_Lot.StoreWaybill_DocNum, dbo.T_Lot.StoreWaybill_DocDate
FROM         dbo.T_Lot INNER JOIN
                      dbo.T_LotState ON dbo.T_Lot.LotState_Guid = dbo.T_LotState.LotState_Guid INNER JOIN
                      dbo.T_Currency ON dbo.T_Lot.Currency_Guid = dbo.T_Currency.Currency_Guid INNER JOIN
                      dbo.T_Vendor ON dbo.T_Lot.Vendor_Guid = dbo.T_Vendor.Vendor_Guid INNER JOIN
                      dbo.T_VendorType ON dbo.T_Vendor.VendorType_Guid = dbo.T_VendorType.VendorType_Guid INNER JOIN
                      dbo.T_Stock ON dbo.T_Lot.Stock_Guid = dbo.T_Stock.Stock_Guid INNER JOIN
                      dbo.T_WarehouseType ON dbo.T_Stock.WarehouseType_Guid = dbo.T_WarehouseType.WareHouseType_Guid INNER JOIN
                      dbo.T_Company ON dbo.T_Stock.Company_Guid = dbo.T_Company.Company_Guid INNER JOIN
                      dbo.T_CompanyType ON dbo.T_Company.CompanyType_Guid = dbo.T_CompanyType.CompanyType_Guid INNER JOIN
                      dbo.T_CustomerStateType ON dbo.T_Company.CustomerStateType_Guid = dbo.T_CustomerStateType.CustomerStateType_Guid


GO

/****** Object:  StoredProcedure [dbo].[usp_AddLot]    Script Date: 21.06.2013 17:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Добавляет в базу данных информацию о приходе
--
-- Параметры:
-- [in] @tLotItems										- приложение к приходу
-- [in] @Lot_Num											- номер партии
-- [in] @Lot_Date										- дата прихода
-- [in] @Lot_Num											- номер приходной накладной
-- [in] @Lot_DocDate									- дата приходной накладной
-- [in] @Vendor_Guid									- УИ поставщика
-- [in] @Currency_Guid								- УИ валюты прихода
-- [in] @Stock_Guid									- УИ склада
-- [in] @Lot_Description							- примечание
-- [in] @Lotr_IsActive								- признак "приход активен"
-- [in] @LotState_Guid								- УИ состояния прихода
-- [in] @Lot_CurrencyRate						- курс пересчёта валюты прихода в ОВУ
-- [in] 	@StoreWaybill_DocNum				- № накладной на ответ. хранение
-- [in] 	@StoreWaybill_DocDate				- дата накладной на ответ. хранение
--
-- [out]  @Lot_Guid									- УИ прихода
-- [out]  @Lot_Id										- УИ прихода в InterBase
-- [out]  @Lot_AllPrice							- себестоимость в валюте прихода
-- [out]  @Lot_CurrencyAllPrice			- себестоимость в ОВУ
-- [out]  @Lot_RetCurrencyAllPrice		- сумма возврата по накладной по себестоимости в ОВУ
-- [out]  @ERROR_NUM									- номер ошибки
-- [out]  @ERROR_MES									- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--			<>0 - ошибка
--
-- Возвращает:
--

ALTER PROCEDURE [dbo].[usp_AddLot]
	@KLP_Guid									D_GUID = NULL,
	@Lot_Num									D_NAMESHORT,
	@Lot_DocNum								D_NAMESHORT,
	@Lot_Date									D_DATE,
	@Lot_DocDate							D_DATE,
	@Vendor_Guid							D_GUID,
	@Stock_Guid								D_GUID,
	@Currency_Guid						D_GUID,
	@Lot_Description					D_DESCRIPTION = NULL,
	@Lot_IsActive							D_ISACTIVE = 1, 
	@LotState_Guid						D_GUID,
	@Lot_CurrencyRate					D_MONEY,
	@StoreWaybill_DocNum			D_NAMESHORT = NULL,
	@StoreWaybill_DocDate			D_DATE = NULL,

	@tLotItems								dbo.udt_LotItems  READONLY,

  @Lot_Guid									D_GUID output,
  @Lot_Id										D_ID output,
	@Lot_AllPrice							D_MONEY output,
	@Lot_CurrencyAllPrice			D_MONEY output,
	@Lot_RetCurrencyAllPrice	D_MONEY output,

  @ERROR_NUM								int output,
  @ERROR_MES								nvarchar(4000) output
AS


BEGIN

  BEGIN TRY
    SET @ERROR_NUM = 0;
    SET @ERROR_MES = '';
    SET @Lot_Guid = NULL;
    SET @Lot_Id = 0;
    SET @Lot_AllPrice = 0;
    SET @Lot_CurrencyAllPrice = 0;
    SET @Lot_RetCurrencyAllPrice = 0;
    
    -- Проверяем наличие поставщика с указанным идентификатором
    IF NOT EXISTS ( SELECT Vendor_Guid FROM dbo.T_Vendor WHERE Vendor_Guid = @Vendor_Guid )
      BEGIN
        SET @ERROR_NUM = 1;
        SET @ERROR_MES = 'В базе данных не найден поставщик с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Vendor_Guid  );
        RETURN @ERROR_NUM;
      END
    
    -- Проверяем наличие валюты с указанным идентификатором
    IF NOT EXISTS ( SELECT Currency_Guid FROM dbo.T_Currency WHERE Currency_Guid = @Currency_Guid )
      BEGIN
        SET @ERROR_NUM = 2;
        SET @ERROR_MES = 'В базе данных не найдена валюта с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Currency_Guid  );
        RETURN @ERROR_NUM;
      END

    -- Проверяем наличие записи о состоянии прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT LotState_Guid FROM dbo.T_LotState WHERE LotState_Guid = @LotState_Guid )
      BEGIN
        SET @ERROR_NUM = 3;
        SET @ERROR_MES = 'В базе данных не найдена запись о состоянии прихода с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @LotState_Guid  );
        RETURN @ERROR_NUM;
      END

    -- Проверяем наличие записи о складе прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT Stock_Guid FROM dbo.T_Stock WHERE Stock_Guid = @Stock_Guid )
      BEGIN
        SET @ERROR_NUM = 4;
        SET @ERROR_MES = 'В базе данных не найдена запись о складе с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Stock_Guid  );
        RETURN @ERROR_NUM;
      END

		-- Регистрируем шапку прихода
    DECLARE @NewID D_GUID;
    SET @NewID = NEWID( );	

    BEGIN TRANSACTION UpdateData;

		INSERT INTO T_Lot( Lot_Guid, Lot_Id, KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date, Lot_DocDate, 
			Stock_Guid, Vendor_Guid, Currency_Guid, LotState_Guid, 
			Lot_CurrencyRate, Lot_AllPrice, Lot_CurrencyAllPrice, Lot_RetCurrencyAllPrice, 
			Lot_Description, Lot_IsActive, StoreWaybill_DocNum, StoreWaybill_DocDate, Record_Updated, Record_UserUdpated )
		VALUES( @NewID, @Lot_Id, @KLP_Guid, @Lot_Num, @Lot_DocNum, @Lot_Date, @Lot_DocDate, 
			@Stock_Guid, @Vendor_Guid, @Currency_Guid, @LotState_Guid, 
			@Lot_CurrencyRate, @Lot_AllPrice, @Lot_CurrencyAllPrice, @Lot_RetCurrencyAllPrice, @Lot_Description, @Lot_IsActive,
			@StoreWaybill_DocNum, @StoreWaybill_DocDate,
			sysutcdatetime(), ( Host_Name() + ': ' + SUSER_SNAME() ) );
		
		-- Приложение к приходу
		INSERT INTO T_LotItems( LotItems_Guid, LotItems_Id, Lot_Guid,	KLPItems_Guid,	Parts_Guid,	Measure_Guid,
			LotItems_Quantity,	LotItems_RetQuantity,	LotItems_Price,	LotItems_CurrencyPrice,	LotItems_ExpDate,	CountryProduction_Guid  )
		SELECT LotItems_Guid, 0, @NewID,	KLPItems_Guid,	Parts_Guid,	Measure_Guid,
			LotItems_Quantity,	LotItems_RetQuantity,	LotItems_Price,	LotItems_CurrencyPrice,	LotItems_ExpDate,	CountryProduction_Guid
		FROM @tLotItems;
		
    SELECT  @Lot_AllPrice = SUM( [LotItems_Quantity] * [LotItems_Price] ), 
			@Lot_CurrencyAllPrice = SUM( [LotItems_Quantity] * [LotItems_CurrencyPrice] ),
			@Lot_RetCurrencyAllPrice = SUM( [LotItems_RetQuantity] * [LotItems_CurrencyPrice])
    FROM T_LotItems 
    WHERE Lot_Guid = @NewID;
    
		UPDATE T_Lot SET Lot_AllPrice = @Lot_AllPrice, Lot_CurrencyAllPrice = @Lot_CurrencyAllPrice, 
		 Lot_RetCurrencyAllPrice = @Lot_RetCurrencyAllPrice
		WHERE Lot_Guid = @NewID;

		INSERT INTO dbo.T_LotStateHistory( LotStateHistory_Guid, Lot_Guid, LotState_Date, LotState_Guid, Record_Updated, Record_UserUdpated )
		VALUES( NEWID(), @NewID, sysutcdatetime(), @LotState_Guid, sysutcdatetime(), ( Host_Name() + ': ' + SUSER_SNAME() ) );	
		
		SET @Lot_Guid = @NewID;

		IF( @ERROR_NUM = 0 )	
			BEGIN
				UPDATE dbo.T_Lot SET Lot_Id = @Lot_Id
				WHERE Lot_Guid = @Lot_Guid;
				
				COMMIT TRANSACTION UpdateData;
			END 
		ELSE	
			ROLLBACK TRANSACTION UpdateData;

		   
 	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = 'Ошибка добавления в базу данных информации о приходе. ' + ERROR_MESSAGE();
    
		RETURN @ERROR_NUM;
	END CATCH;

	IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
	RETURN @ERROR_NUM;
END

GO

/****** Object:  StoredProcedure [dbo].[usp_EditLot]    Script Date: 21.06.2013 18:10:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Редактирует в базе данных информацию о приходе
--
-- Параметры:
-- [in] @Lot_Guid									- УИ прихода
-- [in] @tLotItems										- приложение к приходу
-- [in] @Lot_Num											- номер партии
-- [in] @Lot_Date										- дата прихода
-- [in] @Lot_Num											- номер приходной накладной
-- [in] @Lot_DocDate									- дата приходной накладной
-- [in] @Vendor_Guid									- УИ поставщика
-- [in] @Currency_Guid								- УИ валюты прихода
-- [in] @Stock_Guid									- УИ склада
-- [in] @Lot_Description							- примечание
-- [in] @Lotr_IsActive								- признак "приход активен"
-- [in] @LotState_Guid								- УИ состояния прихода
-- [in] @Lot_CurrencyRate						- курс пересчёта валюты прихода в ОВУ
-- [in] 	@StoreWaybill_DocNum				- № накладной на ответ. хранение
-- [in] 	@StoreWaybill_DocDate				- дата накладной на ответ. хранение
--
-- [out]  @Lot_AllPrice							- себестоимость в валюте прихода
-- [out]  @Lot_CurrencyAllPrice			- себестоимость в ОВУ
-- [out]  @Lot_RetCurrencyAllPrice		- сумма возврата по накладной по себестоимости в ОВУ
-- [out]  @ERROR_NUM									- номер ошибки
-- [out]  @ERROR_MES									- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--			<>0 - ошибка
--
-- Возвращает:
--

ALTER PROCEDURE [dbo].[usp_EditLot]
	@Lot_Guid									D_GUID,
	@KLP_Guid									D_GUID = NULL,
	@Lot_Num									D_NAMESHORT,
	@Lot_DocNum								D_NAMESHORT,
	@Lot_Date									D_DATE,
	@Lot_DocDate							D_DATE,
	@Vendor_Guid							D_GUID,
	@Stock_Guid								D_GUID,
	@Currency_Guid						D_GUID,
	@Lot_Description					D_DESCRIPTION = NULL,
	@Lot_IsActive							D_ISACTIVE = 1, 
	@LotState_Guid						D_GUID,
	@Lot_CurrencyRate					D_MONEY,
	@StoreWaybill_DocNum			D_NAMESHORT = NULL,
	@StoreWaybill_DocDate			D_DATE = NULL,

	@tLotItems								dbo.udt_LotItems  READONLY,

	@Lot_AllPrice							D_MONEY output,
	@Lot_CurrencyAllPrice			D_MONEY output,
	@Lot_RetCurrencyAllPrice	D_MONEY output,

  @ERROR_NUM								int output,
  @ERROR_MES								nvarchar(4000) output
AS

BEGIN

  BEGIN TRY
    SET @ERROR_NUM = 0;
    SET @ERROR_MES = '';

    SET @Lot_AllPrice = 0;
    SET @Lot_CurrencyAllPrice = 0;
    SET @Lot_RetCurrencyAllPrice = 0;
    
    -- Проверяем наличие прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT Lot_Guid FROM dbo.T_Lot WHERE Lot_Guid = @Lot_Guid )
      BEGIN
        SET @ERROR_NUM = 1;
        SET @ERROR_MES = 'В базе данных не найден приход с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Lot_Guid  );
        RETURN @ERROR_NUM;
      END

    -- Проверяем наличие поставщика с указанным идентификатором
    IF NOT EXISTS ( SELECT Vendor_Guid FROM dbo.T_Vendor WHERE Vendor_Guid = @Vendor_Guid )
      BEGIN
        SET @ERROR_NUM = 2;
        SET @ERROR_MES = 'В базе данных не найден поставщик с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Vendor_Guid  );
        RETURN @ERROR_NUM;
      END
    
    -- Проверяем наличие валюты с указанным идентификатором
    IF NOT EXISTS ( SELECT Currency_Guid FROM dbo.T_Currency WHERE Currency_Guid = @Currency_Guid )
      BEGIN
        SET @ERROR_NUM = 3;
        SET @ERROR_MES = 'В базе данных не найдена валюта с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Currency_Guid  );
        RETURN @ERROR_NUM;
      END

    -- Проверяем наличие записи о состоянии прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT LotState_Guid FROM dbo.T_LotState WHERE LotState_Guid = @LotState_Guid )
      BEGIN
        SET @ERROR_NUM = 4;
        SET @ERROR_MES = 'В базе данных не найдена запись о состоянии прихода с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @LotState_Guid  );
        RETURN @ERROR_NUM;
      END

    -- Проверяем наличие записи о складе прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT Stock_Guid FROM dbo.T_Stock WHERE Stock_Guid = @Stock_Guid )
      BEGIN
        SET @ERROR_NUM = 5;
        SET @ERROR_MES = 'В базе данных не найдена запись о складе с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Stock_Guid  );
        RETURN @ERROR_NUM;
      END

    BEGIN TRANSACTION UpdateData;

		-- Вносим правки в шапку прихода
		--
		DECLARE @CurrentLotState_Guid D_GUID;
		SELECT @CurrentLotState_Guid = LotState_Guid FROM dbo.T_Lot WHERE Lot_Guid = @Lot_Guid;		
		
		UPDATE dbo.T_Lot SET KLP_Guid = @KLP_Guid, Lot_Num = @Lot_Num, Lot_DocNum = @Lot_DocNum, Lot_Date = @Lot_Date, 
			Lot_DocDate = @Lot_DocDate, Stock_Guid = @Stock_Guid, Vendor_Guid = @Vendor_Guid, Currency_Guid = @Currency_Guid, 
			Lot_CurrencyRate = @Lot_CurrencyRate,  Lot_Description = @Lot_Description, Lot_IsActive = @Lot_IsActive, 
			StoreWaybill_DocNum = @StoreWaybill_DocNum, StoreWaybill_DocDate = @StoreWaybill_DocDate
		WHERE Lot_Guid = @Lot_Guid;	

 	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = 'Ошибка редактирования в базе данных информации о приходе. ' + ERROR_MESSAGE();
	END CATCH;

		IF( @ERROR_NUM = 0 )	
			BEGIN
				SET @ERROR_MES = 'Успешное завершение операции.';
				COMMIT TRANSACTION UpdateData;
			END 
		ELSE	
			ROLLBACK TRANSACTION UpdateData;

	RETURN @ERROR_NUM;
END

GO

/****** Object:  StoredProcedure [dbo].[usp_ChangeLotState]    Script Date: 21.06.2013 18:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Редактирует в базе данных информацию о состоянии прихода
--
-- Параметры:
-- [in] @Lot_Guid					- УИ заказа
-- [in] @LotState_Guid			- УИ состояния прихода
--
-- [out]  @Lot_Id					- УИ прихода в InterBase
-- [out]  @ERROR_NUM				- номер ошибки
-- [out]  @ERROR_MES				- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--		<>0 - ошибка
--
-- Возвращает:
--

ALTER PROCEDURE [dbo].[usp_ChangeLotState]
  @Lot_Guid				D_GUID,
	@LotState_Guid	D_GUID,
	
	@Lot_Id					D_ID out,
  @ERROR_NUM			int output,
  @ERROR_MES			nvarchar(4000) output
AS

BEGIN

  BEGIN TRY
    SET @ERROR_NUM = 0;
    SET @ERROR_MES = '';

    -- Проверяем наличие прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT Lot_Guid FROM dbo.T_Lot WHERE Lot_Guid = @Lot_Guid )
      BEGIN
        SET @ERROR_NUM = 1;
        SET @ERROR_MES = 'В базе данных не найден приход с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @Lot_Guid  );
        RETURN @ERROR_NUM;
      END

    -- Проверяем наличие записи о состоянии прихода с указанным идентификатором
    IF NOT EXISTS ( SELECT LotState_Guid FROM dbo.T_LotState WHERE LotState_Guid = @LotState_Guid )
      BEGIN
        SET @ERROR_NUM = 2;
        SET @ERROR_MES = 'В базе данных не найдена запись о состоянии прихода с указанным идетнификатором.' + Char(13) + 
          'УИ: ' + Char(9) + CONVERT( nvarchar(36), @LotState_Guid  );
        RETURN @ERROR_NUM;
      END

		DECLARE @CurrentLotState_Guid D_GUID = NULL;
		
		SELECT @CurrentLotState_Guid = LotState_Guid, @Lot_Id = Lot_Id 
		FROM dbo.T_Lot WHERE Lot_Guid = @Lot_Guid;
		
		IF( @CurrentLotState_Guid = @LotState_Guid )
			BEGIN
				SET @ERROR_NUM = 0;
				SET @ERROR_MES = 'Успешное завершение операции.';
				
				RETURN @ERROR_NUM;
			END

		DECLARE @LotStateLot_Guid D_GUID = NULL;
		SELECT @LotStateLot_Guid = dbo.GetLotStateLOT();
		

    BEGIN TRANSACTION UpdateData;
    
			IF( ( @LotStateLot_Guid IS NOT NULL ) AND ( @LotStateLot_Guid = @LotState_Guid ) )
				BEGIN
					-- постановка на приход
					EXEC dbo.usp_AddLotToIB @Lot_Guid = @Lot_Guid, @Lot_Id = @Lot_Id out, 
						@ERROR_NUM = @ERROR_NUM out, @ERROR_MES = @ERROR_MES out;

					IF( @ERROR_NUM = 0 )	
						UPDATE dbo.T_Lot SET LotState_Guid = @LotStateLot_Guid	WHERE Lot_Guid = @Lot_Guid;
				END
			ELSE
				BEGIN
					UPDATE dbo.T_Lot SET LotState_Guid = @LotState_Guid WHERE Lot_Guid = @Lot_Guid;
					SET @ERROR_NUM = 0;
					SET @ERROR_MES = 'Состояние прихода успешно оизменено.';
				END	

			INSERT INTO dbo.T_LotStateHistory( LotStateHistory_Guid, Lot_Guid, LotState_Date, LotState_Guid, Record_Updated, Record_UserUdpated )
			VALUES( NEWID(), @Lot_Guid, sysutcdatetime(), @LotState_Guid, sysutcdatetime(), ( Host_Name() + ': ' + SUSER_SNAME() ) );	
		
 	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = 'Ошибка редактирования состояния прихода. ' + ERROR_MESSAGE();
	END CATCH;

	IF( @ERROR_NUM = 0 )	
		BEGIN
			SET @ERROR_MES = 'Успешное завершение операции.';
			COMMIT TRANSACTION UpdateData;
		END 
	ELSE	
		ROLLBACK TRANSACTION UpdateData;

	RETURN @ERROR_NUM;
END

GO

/****** Object:  StoredProcedure [dbo].[usp_GetLot]    Script Date: 24.06.2013 9:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Возвращает список записей из ( dbo.LotView )
--
-- Входные параметры:
--		@KLP_Guid				- УИ КЛП
--		@BeginDate			- дата начала периода поиска
--		@EndDate				- дата окончания периода поиска
--
-- Выходные параметры:
--		@ERROR_NUM			- номер ошибки
--		@ERROR_MES			- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--    <>0 - ошибка запроса информации из базы данных

ALTER PROCEDURE [dbo].[usp_GetLot] 
	@KLP_Guid				D_GUID = NULL,
	@BeginDate			D_DATE = NULL,
	@EndDate				D_DATE = NULL,
	
  @ERROR_NUM			int output,
  @ERROR_MES			nvarchar(4000) output
AS

BEGIN

  SET @ERROR_NUM = 0;
  SET @ERROR_MES = NULL;

  BEGIN TRY

    IF( @KLP_Guid IS NULL )
			BEGIN
				IF( @BeginDate IS NULL ) SET @BeginDate = ( SELECT dbo.TrimTime( GetDate() ) );
				IF( @EndDate IS NULL ) SET @EndDate = @BeginDate;
				-- поиск по дате документа
				WITH Lot AS
				(
					SELECT Lot_Guid, Lot_Id, KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date, Lot_DocDate, Stock_Guid, Vendor_Guid, Currency_Guid, 
						LotState_Guid, Lot_CurrencyRate, Lot_AllPrice, Lot_CurrencyAllPrice, Lot_RetCurrencyAllPrice, Lot_Description, 
						Lot_IsActive, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, 
						Currency_Abbr, Currency_Code, Currency_ShortName, Currency_IsMain, 
						Vendor_Id, Vendor_Name, Vendor_Description, Vendor_IsActive, VendorType_Guid, 
						VendorType_Id, VendorType_Name, VendorType_Description, VendorType_IsActive, 
						Stock_Id, Warehouse_Guid, WarehouseType_Guid, Company_Guid, Stock_Name, Stock_IsActive, 
						Stock_IsTrade, Stock_InTransfer, WareHouseType_Name, WarehouseType_IsActive, 
						Company_Id, CompanyType_Guid, Company_Acronym, Company_OKPO, Company_OKULP, 
						Company_UNN, Company_IsActive, Company_Name, Company_Description, CompanyType_name, CompanyType_Description, CompanyType_IsActive, 
						CustomerStateType_Guid, CustomerStateType_Name, CustomerStateType_ShortName, CustomerStateType_IsActive, 
						StoreWaybill_DocNum, StoreWaybill_DocDate
					FROM [dbo].[LotView]
					WHERE Lot_DocDate BETWEEN @BeginDate AND @EndDate
				)
				SELECT Lot.Lot_Guid, Lot_Id, Lot.KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date, Lot_DocDate, Lot.Stock_Guid, Vendor_Guid, Currency_Guid, 
						LotState_Guid, Lot_CurrencyRate, Lot_AllPrice, Lot_CurrencyAllPrice, Lot_RetCurrencyAllPrice, Lot_Description, 
						Lot_IsActive, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, 
						Currency_Abbr, Currency_Code, Currency_ShortName, Currency_IsMain, 
						Vendor_Id, Vendor_Name, Vendor_Description, Vendor_IsActive, VendorType_Guid, 
						VendorType_Id, VendorType_Name, VendorType_Description, VendorType_IsActive, 
						Stock_Id, Warehouse_Guid, WarehouseType_Guid, Company_Guid, Stock_Name, Stock_IsActive, 
						Stock_IsTrade, Stock_InTransfer, WareHouseType_Name, WarehouseType_IsActive, 
						Company_Id, CompanyType_Guid, Company_Acronym, Company_OKPO, Company_OKULP, 
						Company_UNN, Company_IsActive, Company_Name, Company_Description, CompanyType_name, CompanyType_Description, CompanyType_IsActive, 
						CustomerStateType_Guid, CustomerStateType_Name, CustomerStateType_ShortName, CustomerStateType_IsActive, 
						LotItems.Quantity, LotItems.RetQuantity, LotItems.LeavQuantity, 
						KLP.KLP_Date, KLP.KLP_Num, Lot.StoreWaybill_DocNum, Lot.StoreWaybill_DocDate
				FROM Lot 
				CROSS APPLY ( SELECT SUM( LotItems_Quantity ) AS Quantity, SUM( LotItems_RetQuantity ) AS RetQuantity, SUM( LotItems_LeavQuantity ) AS LeavQuantity
						FROM [dbo].[T_LotItems]   
						WHERE Lot_Guid = Lot.Lot_Guid ) LotItems LEFT OUTER JOIN [dbo].[T_KLP] AS KLP ON Lot.KLP_Guid = KLP.KLP_Guid
				ORDER BY Lot_Date;

			END
		ELSE	
			BEGIN
				SELECT Lot_Guid, Lot_Id, [dbo].[LotView].KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date, Lot_DocDate, [dbo].[LotView].Stock_Guid, Vendor_Guid, Currency_Guid, 
							LotState_Guid, Lot_CurrencyRate, Lot_AllPrice, Lot_CurrencyAllPrice, Lot_RetCurrencyAllPrice, Lot_Description, 
							Lot_IsActive, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, 
							Currency_Abbr, Currency_Code, Currency_ShortName, Currency_IsMain, 
							Vendor_Id, Vendor_Name, Vendor_Description, Vendor_IsActive, VendorType_Guid, 
							VendorType_Id, VendorType_Name, VendorType_Description, VendorType_IsActive, 
							Stock_Id, Warehouse_Guid, WarehouseType_Guid, Company_Guid, Stock_Name, Stock_IsActive, 
							Stock_IsTrade, Stock_InTransfer, WareHouseType_Name, WarehouseType_IsActive, 
							Company_Id, CompanyType_Guid, Company_Acronym, Company_OKPO, Company_OKULP, 
							Company_UNN, Company_IsActive, Company_Name, Company_Description, CompanyType_name, CompanyType_Description, CompanyType_IsActive, 
							CustomerStateType_Guid, CustomerStateType_Name, CustomerStateType_ShortName, CustomerStateType_IsActive,
							LotItems.Quantity, LotItems.RetQuantity, LotItems.LeavQuantity,
							KLP.KLP_Date, KLP.KLP_Num,  [dbo].[LotView].StoreWaybill_DocNum,  [dbo].[LotView].StoreWaybill_DocDate
				FROM [dbo].[LotView]
				CROSS APPLY ( SELECT SUM( LotItems_Quantity ) AS Quantity, SUM( LotItems_RetQuantity ) AS RetQuantity, SUM( LotItems_LeavQuantity ) AS LeavQuantity
						FROM [dbo].[T_LotItems]   
						WHERE Lot_Guid = [dbo].[LotView].Lot_Guid ) LotItems INNER JOIN [dbo].[T_KLP] AS KLP ON [dbo].[LotView].KLP_Guid = KLP.KLP_Guid
				WHERE [dbo].[LotView].KLP_Guid IS NOT NULL
					AND [dbo].[LotView].KLP_Guid = @KLP_Guid
				ORDER BY Lot_Date;
			END
	END TRY
	BEGIN CATCH
		SET @ERROR_NUM = ERROR_NUMBER();
		SET @ERROR_MES = ERROR_MESSAGE();
	END CATCH;

  IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
  RETURN @ERROR_NUM;
END

GO


	ALTER TABLE [dbo].[T_LotState] ADD LotState_IsCanEditDocument D_YESNO NULL 
	GO
	
	UPDATE [dbo].[T_LotState] SET LotState_IsCanEditDocument = 1
	GO

	UPDATE [dbo].[T_LotState] SET LotState_IsCanEditDocument = 0  WHERE LotState_OrderNum = 1
	GO

	
/****** Object:  View [dbo].[LotStateView]    Script Date: 24.06.2013 16:07:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[LotStateView]
AS
SELECT     LotState_Guid, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, LotState_IsCanEditDocument
FROM         dbo.T_LotState


GO

/****** Object:  StoredProcedure [dbo].[usp_GetLotState]    Script Date: 24.06.2013 16:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Возвращает список записей из ( dbo.LotStateView )
--
-- Входные параметры:
--		@Lot_Guid - УИ прихода
--
-- Выходные параметры:
--
-- Результат:
--    0 - успешное завершение
--    <>0 - ошибка запроса информации из базы данных

ALTER PROCEDURE [dbo].[usp_GetLotState] 
	@Lot_Guid D_GUID = NULL,
	
  @ERROR_NUM int output,
  @ERROR_MES nvarchar(4000) output
AS

BEGIN

  SET @ERROR_NUM = 0;
  SET @ERROR_MES = NULL;

  BEGIN TRY

    IF( @Lot_Guid IS NULL )
			BEGIN
				SELECT LotState_Guid, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, LotState_IsCanEditDocument
				FROM [dbo].[LotStateView]
				ORDER BY LotState_OrderNum;
			END
		ELSE	
			BEGIN
				DECLARE @CurrentLotState_Guid D_GUID = NULL;
				DECLARE @LotState_OrderNum int;
				
				SELECT @CurrentLotState_Guid = LotState_Guid 
				FROM dbo.T_Lot WHERE Lot_Guid = @Lot_Guid;
				
				IF( @CurrentLotState_Guid IS NULL )
					BEGIN
						SELECT @LotState_OrderNum = MIN( LotState_OrderNum ) FROM dbo.T_LotState WHERE LotState_IsRequire = 1;
						IF( @LotState_OrderNum IS NULL )
							SELECT @LotState_OrderNum = MIN( LotState_OrderNum ) FROM dbo.T_LotState;
						
						IF( @LotState_OrderNum IS NOT NULL )
							SELECT LotState_Guid, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, LotState_IsCanEditDocument
							FROM [dbo].[LotStateView]
							WHERE LotState_OrderNum = @LotState_OrderNum;
					END
				ELSE	
					BEGIN
						DECLARE @CurrentLotState_OrderNum int;
						SELECT Top 1 @CurrentLotState_OrderNum = LotState_OrderNum FROM dbo.T_LotState
						WHERE LotState_Guid = @CurrentLotState_Guid;

						SELECT @LotState_OrderNum = MIN( LotState_OrderNum ) FROM dbo.T_LotState 
						WHERE LotState_IsRequire = 1 
							AND LotState_OrderNum > @CurrentLotState_OrderNum;
							
						IF( @LotState_OrderNum IS NOT NULL )
							SELECT LotState_Guid, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, LotState_IsCanEditDocument
							FROM [dbo].[LotStateView]
							WHERE LotState_OrderNum BETWEEN @CurrentLotState_OrderNum AND @LotState_OrderNum
							ORDER BY 	LotState_OrderNum;
						ELSE
							SELECT LotState_Guid, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, LotState_IsCanEditDocument
							FROM [dbo].[LotStateView]
							WHERE LotState_OrderNum = @CurrentLotState_OrderNum;
						
					END
			END
	END TRY
	BEGIN CATCH
		SET @ERROR_NUM = ERROR_NUMBER();
		SET @ERROR_MES = ERROR_MESSAGE();
		RETURN @ERROR_NUM;
	END CATCH;

  IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
  RETURN @ERROR_NUM;
END

GO


/****** Object:  StoredProcedure [dbo].[usp_AddLotState]    Script Date: 24.06.2013 16:06:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Добавляет новую запись в таблицу dbo.T_LotState
--
-- Входящие параметры:
--	@LotState_Name				- наименование
--	@LotState_Description - описание
--	@LotState_OrderNum		- номер состояния в очереди
--	@LotState_IsActive		- признак активности записи
--	@LotState_IsRequire		- признак обязательного прохождения состояния
--@LotState_IsCanEditDocument - признак того, можно ли релактировать документ в данном состоянии
--
-- Выходные параметры:
--  @LotState_Guid - уникальный идентификатор записи
--  @ERROR_NUM - номер ошибки
--  @ERROR_MES - текст ошибки
--
-- Результат:
--    0 - Успешное завершение
--    <>0 - ошибка

ALTER PROCEDURE [dbo].[usp_AddLotState] 
	@LotState_Name D_NAME,
	@LotState_Description D_DESCRIPTION = NULL,
	@LotState_OrderNum D_ID,
	@LotState_IsActive D_ISACTIVE = 1,
	@LotState_IsRequire D_YESNO = 1,
	@LotState_IsCanEditDocument D_YESNO = 1,

  @LotState_Guid D_GUID output,
  @ERROR_NUM int output,
  @ERROR_MES nvarchar(4000) output

AS

BEGIN

	BEGIN TRY

    SET @ERROR_NUM = 0;
    SET @ERROR_MES = '';
    SET @LotState_Guid = NULL;

    -- Проверяем наличие записи с заданным именем
    IF EXISTS ( SELECT * FROM dbo.T_LotState	WHERE LotState_Name = @LotState_Name )
      BEGIN
        SET @ERROR_NUM = 1;
        SET @ERROR_MES = 'В базе данных уже присутствует состояние прихода с указанным наименованием.' + Char(13) + 
          'состояние: ' + Char(9) + @LotState_Name;
        RETURN @ERROR_NUM;
      END

    DECLARE @NewID D_GUID;
    SET @NewID = NEWID ( );	
    
    INSERT INTO dbo.T_LotState( LotState_Guid, LotState_Name, LotState_Description, 
			LotState_OrderNum, LotState_IsActive, LotState_IsRequire, LotState_IsCanEditDocument, 
			Record_Updated, Record_UserUdpated )
    VALUES( @NewID, @LotState_Name, @LotState_Description, 
			@LotState_OrderNum, @LotState_IsActive, @LotState_IsRequire, @LotState_IsCanEditDocument,
			sysutcdatetime(), ( Host_Name() + ': ' + SUSER_SNAME() ) );
    
    SET @LotState_Guid = @NewID;

	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = ERROR_MESSAGE();
		RETURN @ERROR_NUM;
	END CATCH;

	IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
	RETURN @ERROR_NUM;
END

GO

/****** Object:  StoredProcedure [dbo].[usp_EditLotState]    Script Date: 24.06.2013 16:15:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Редактирует запись в таблице dbo.T_LotState
--
-- Входящие параметры:
--  @LotState_Guid				- уникальный идентификатор записи
--		@LotState_Name				- наименование
--		@LotState_Description - описание
--		@LotState_OrderNum		- номер состояния в очереди
--		@LotState_IsActive		- признак активности записи
--		@LotState_IsRequire		- признак обязательного прохождения состояния
--		@LotState_IsCanEditDocument - признак того, можно ли релактировать документ в данном состоянии
--
-- Выходные параметры:
--  @ERROR_NUM - номер ошибки
--  @ERROR_MES - текст ошибки
--
-- Результат:
--    0 - Успешное завершение
--    <>0 - ошибка

ALTER PROCEDURE [dbo].[usp_EditLotState] 
  @LotState_Guid D_GUID,
	@LotState_Name D_NAME,
	@LotState_Description D_DESCRIPTION = NULL,
	@LotState_OrderNum D_ID,
	@LotState_IsActive D_ISACTIVE,
	@LotState_IsRequire D_YESNO = 1,
	@LotState_IsCanEditDocument D_YESNO,

  @ERROR_NUM int output,
  @ERROR_MES nvarchar(4000) output

AS

BEGIN

	BEGIN TRY

    SET @ERROR_NUM = 0;
    SET @ERROR_MES = NULL;

    -- Проверяем наличие записи с заданным именем
    IF EXISTS ( SELECT * FROM dbo.T_LotState	WHERE LotState_Name = @LotState_Name AND LotState_Guid <> @LotState_Guid )
      BEGIN
        SET @ERROR_NUM = 1;
        SET @ERROR_MES = 'В базе данных уже присутствует состояние прихода с указанным наименованием.' + Char(13) + 
          'состояние: ' + Char(9) + @LotState_Name;
        RETURN @ERROR_NUM;
      END

    UPDATE dbo.T_LotState SET LotState_Name = @LotState_Name, LotState_Description = @LotState_Description, 
			LotState_IsActive = @LotState_IsActive, LotState_OrderNum = @LotState_OrderNum, 
			LotState_IsRequire = @LotState_IsRequire, LotState_IsCanEditDocument = @LotState_IsCanEditDocument
		WHERE LotState_Guid = @LotState_Guid; 
			
	END TRY
	BEGIN CATCH
    SET @ERROR_NUM = ERROR_NUMBER();
    SET @ERROR_MES = ERROR_MESSAGE();
		RETURN @ERROR_NUM;
	END CATCH;

	IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
	RETURN @ERROR_NUM;
END

GO


/****** Object:  View [dbo].[LotView]    Script Date: 24.06.2013 16:34:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER VIEW [dbo].[LotView]
AS
SELECT     dbo.T_Lot.Lot_Guid, dbo.T_Lot.Lot_Id, dbo.T_Lot.KLP_Guid, dbo.T_Lot.Lot_Num, dbo.T_Lot.Lot_DocNum, dbo.T_Lot.Lot_Date, dbo.T_Lot.Lot_DocDate, 
                      dbo.T_Lot.Stock_Guid, dbo.T_Lot.Vendor_Guid, dbo.T_Lot.Currency_Guid, dbo.T_Lot.LotState_Guid, dbo.T_Lot.Lot_CurrencyRate, dbo.T_Lot.Lot_AllPrice, 
                      dbo.T_Lot.Lot_CurrencyAllPrice, dbo.T_Lot.Lot_RetCurrencyAllPrice, dbo.T_Lot.Lot_Description, dbo.T_Lot.Lot_IsActive, dbo.T_LotState.LotState_Name, 
                      dbo.T_LotState.LotState_Description, dbo.T_LotState.LotState_OrderNum, dbo.T_LotState.LotState_IsActive, dbo.T_LotState.LotState_IsRequire, 
                      dbo.T_Currency.Currency_Abbr, dbo.T_Currency.Currency_Code, dbo.T_Currency.Currency_ShortName, dbo.T_Currency.Currency_IsMain, dbo.T_Vendor.Vendor_Id, 
                      dbo.T_Vendor.Vendor_Name, dbo.T_Vendor.Vendor_Description, dbo.T_Vendor.Vendor_IsActive, dbo.T_Vendor.VendorType_Guid, dbo.T_VendorType.VendorType_Id, 
                      dbo.T_VendorType.VendorType_Name, dbo.T_VendorType.VendorType_Description, dbo.T_VendorType.VendorType_IsActive, dbo.T_Stock.Stock_Id, 
                      dbo.T_Stock.Warehouse_Guid, dbo.T_Stock.WarehouseType_Guid, dbo.T_Stock.Company_Guid, dbo.T_Stock.Stock_Name, dbo.T_Stock.Stock_IsActive, 
                      dbo.T_Stock.Stock_IsTrade, dbo.T_Stock.Stock_InTransfer, dbo.T_WarehouseType.WareHouseType_Name, dbo.T_WarehouseType.WarehouseType_IsActive, 
                      dbo.T_Company.Company_Id, dbo.T_Company.CompanyType_Guid, dbo.T_Company.Company_Acronym, dbo.T_Company.Company_OKPO, 
                      dbo.T_Company.Company_OKULP, dbo.T_Company.Company_UNN, dbo.T_Company.Company_IsActive, dbo.T_Company.Company_Name, 
                      dbo.T_Company.Company_Description, dbo.T_CompanyType.CompanyType_name, dbo.T_CompanyType.CompanyType_Description, 
                      dbo.T_CompanyType.CompanyType_IsActive, dbo.T_Company.CustomerStateType_Guid, dbo.T_CustomerStateType.CustomerStateType_Name, 
                      dbo.T_CustomerStateType.CustomerStateType_ShortName, dbo.T_CustomerStateType.CustomerStateType_IsActive,
											dbo.T_Lot.StoreWaybill_DocNum, dbo.T_Lot.StoreWaybill_DocDate, dbo.T_LotState.LotState_IsCanEditDocument
FROM         dbo.T_Lot INNER JOIN
                      dbo.T_LotState ON dbo.T_Lot.LotState_Guid = dbo.T_LotState.LotState_Guid INNER JOIN
                      dbo.T_Currency ON dbo.T_Lot.Currency_Guid = dbo.T_Currency.Currency_Guid INNER JOIN
                      dbo.T_Vendor ON dbo.T_Lot.Vendor_Guid = dbo.T_Vendor.Vendor_Guid INNER JOIN
                      dbo.T_VendorType ON dbo.T_Vendor.VendorType_Guid = dbo.T_VendorType.VendorType_Guid INNER JOIN
                      dbo.T_Stock ON dbo.T_Lot.Stock_Guid = dbo.T_Stock.Stock_Guid INNER JOIN
                      dbo.T_WarehouseType ON dbo.T_Stock.WarehouseType_Guid = dbo.T_WarehouseType.WareHouseType_Guid INNER JOIN
                      dbo.T_Company ON dbo.T_Stock.Company_Guid = dbo.T_Company.Company_Guid INNER JOIN
                      dbo.T_CompanyType ON dbo.T_Company.CompanyType_Guid = dbo.T_CompanyType.CompanyType_Guid INNER JOIN
                      dbo.T_CustomerStateType ON dbo.T_Company.CustomerStateType_Guid = dbo.T_CustomerStateType.CustomerStateType_Guid



GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Возвращает список записей из ( dbo.LotView )
--
-- Входные параметры:
--		@KLP_Guid				- УИ КЛП
--		@BeginDate			- дата начала периода поиска
--		@EndDate				- дата окончания периода поиска
--
-- Выходные параметры:
--		@ERROR_NUM			- номер ошибки
--		@ERROR_MES			- текст ошибки
--
-- Результат:
--    0 - успешное завершение
--    <>0 - ошибка запроса информации из базы данных

ALTER PROCEDURE [dbo].[usp_GetLot] 
	@KLP_Guid				D_GUID = NULL,
	@BeginDate			D_DATE = NULL,
	@EndDate				D_DATE = NULL,
	
  @ERROR_NUM			int output,
  @ERROR_MES			nvarchar(4000) output
AS

BEGIN

  SET @ERROR_NUM = 0;
  SET @ERROR_MES = NULL;

  BEGIN TRY

    IF( @KLP_Guid IS NULL )
			BEGIN
				IF( @BeginDate IS NULL ) SET @BeginDate = ( SELECT dbo.TrimTime( GetDate() ) );
				IF( @EndDate IS NULL ) SET @EndDate = @BeginDate;
				-- поиск по дате документа
				WITH Lot AS
				(
					SELECT Lot_Guid, Lot_Id, KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date, Lot_DocDate, Stock_Guid, Vendor_Guid, Currency_Guid, 
						LotState_Guid, Lot_CurrencyRate, Lot_AllPrice, Lot_CurrencyAllPrice, Lot_RetCurrencyAllPrice, Lot_Description, 
						Lot_IsActive, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, 
						Currency_Abbr, Currency_Code, Currency_ShortName, Currency_IsMain, 
						Vendor_Id, Vendor_Name, Vendor_Description, Vendor_IsActive, VendorType_Guid, 
						VendorType_Id, VendorType_Name, VendorType_Description, VendorType_IsActive, 
						Stock_Id, Warehouse_Guid, WarehouseType_Guid, Company_Guid, Stock_Name, Stock_IsActive, 
						Stock_IsTrade, Stock_InTransfer, WareHouseType_Name, WarehouseType_IsActive, 
						Company_Id, CompanyType_Guid, Company_Acronym, Company_OKPO, Company_OKULP, 
						Company_UNN, Company_IsActive, Company_Name, Company_Description, CompanyType_name, CompanyType_Description, CompanyType_IsActive, 
						CustomerStateType_Guid, CustomerStateType_Name, CustomerStateType_ShortName, CustomerStateType_IsActive, 
						StoreWaybill_DocNum, StoreWaybill_DocDate, LotState_IsCanEditDocument
					FROM [dbo].[LotView]
					WHERE Lot_DocDate BETWEEN @BeginDate AND @EndDate
				)
				SELECT Lot.Lot_Guid, Lot_Id, Lot.KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date, Lot_DocDate, Lot.Stock_Guid, Vendor_Guid, Currency_Guid, 
						LotState_Guid, Lot_CurrencyRate, Lot_AllPrice, Lot_CurrencyAllPrice, Lot_RetCurrencyAllPrice, Lot_Description, 
						Lot_IsActive, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, 
						Currency_Abbr, Currency_Code, Currency_ShortName, Currency_IsMain, 
						Vendor_Id, Vendor_Name, Vendor_Description, Vendor_IsActive, VendorType_Guid, 
						VendorType_Id, VendorType_Name, VendorType_Description, VendorType_IsActive, 
						Stock_Id, Warehouse_Guid, WarehouseType_Guid, Company_Guid, Stock_Name, Stock_IsActive, 
						Stock_IsTrade, Stock_InTransfer, WareHouseType_Name, WarehouseType_IsActive, 
						Company_Id, CompanyType_Guid, Company_Acronym, Company_OKPO, Company_OKULP, 
						Company_UNN, Company_IsActive, Company_Name, Company_Description, CompanyType_name, CompanyType_Description, CompanyType_IsActive, 
						CustomerStateType_Guid, CustomerStateType_Name, CustomerStateType_ShortName, CustomerStateType_IsActive, 
						LotItems.Quantity, LotItems.RetQuantity, LotItems.LeavQuantity, 
						KLP.KLP_Date, KLP.KLP_Num, Lot.StoreWaybill_DocNum, Lot.StoreWaybill_DocDate, Lot.LotState_IsCanEditDocument
				FROM Lot 
				CROSS APPLY ( SELECT SUM( LotItems_Quantity ) AS Quantity, SUM( LotItems_RetQuantity ) AS RetQuantity, SUM( LotItems_LeavQuantity ) AS LeavQuantity
						FROM [dbo].[T_LotItems]   
						WHERE Lot_Guid = Lot.Lot_Guid ) LotItems LEFT OUTER JOIN [dbo].[T_KLP] AS KLP ON Lot.KLP_Guid = KLP.KLP_Guid
				ORDER BY Lot_Date;

			END
		ELSE	
			BEGIN
				SELECT Lot_Guid, Lot_Id, [dbo].[LotView].KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date, Lot_DocDate, [dbo].[LotView].Stock_Guid, Vendor_Guid, Currency_Guid, 
							LotState_Guid, Lot_CurrencyRate, Lot_AllPrice, Lot_CurrencyAllPrice, Lot_RetCurrencyAllPrice, Lot_Description, 
							Lot_IsActive, LotState_Name, LotState_Description, LotState_OrderNum, LotState_IsActive, LotState_IsRequire, 
							Currency_Abbr, Currency_Code, Currency_ShortName, Currency_IsMain, 
							Vendor_Id, Vendor_Name, Vendor_Description, Vendor_IsActive, VendorType_Guid, 
							VendorType_Id, VendorType_Name, VendorType_Description, VendorType_IsActive, 
							Stock_Id, Warehouse_Guid, WarehouseType_Guid, Company_Guid, Stock_Name, Stock_IsActive, 
							Stock_IsTrade, Stock_InTransfer, WareHouseType_Name, WarehouseType_IsActive, 
							Company_Id, CompanyType_Guid, Company_Acronym, Company_OKPO, Company_OKULP, 
							Company_UNN, Company_IsActive, Company_Name, Company_Description, CompanyType_name, CompanyType_Description, CompanyType_IsActive, 
							CustomerStateType_Guid, CustomerStateType_Name, CustomerStateType_ShortName, CustomerStateType_IsActive,
							LotItems.Quantity, LotItems.RetQuantity, LotItems.LeavQuantity,
							KLP.KLP_Date, KLP.KLP_Num,  [dbo].[LotView].StoreWaybill_DocNum, [dbo].[LotView].StoreWaybill_DocDate, [dbo].[LotView].LotState_IsCanEditDocument
				FROM [dbo].[LotView]
				CROSS APPLY ( SELECT SUM( LotItems_Quantity ) AS Quantity, SUM( LotItems_RetQuantity ) AS RetQuantity, SUM( LotItems_LeavQuantity ) AS LeavQuantity
						FROM [dbo].[T_LotItems]   
						WHERE Lot_Guid = [dbo].[LotView].Lot_Guid ) LotItems INNER JOIN [dbo].[T_KLP] AS KLP ON [dbo].[LotView].KLP_Guid = KLP.KLP_Guid
				WHERE [dbo].[LotView].KLP_Guid IS NOT NULL
					AND [dbo].[LotView].KLP_Guid = @KLP_Guid
				ORDER BY Lot_Date;
			END
	END TRY
	BEGIN CATCH
		SET @ERROR_NUM = ERROR_NUMBER();
		SET @ERROR_MES = ERROR_MESSAGE();
	END CATCH;

  IF( @ERROR_NUM = 0 )
		SET @ERROR_MES = 'Успешное завершение операции.';
		
  RETURN @ERROR_NUM;
END

GO
