using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPMercuryLotOrder
{
    /// <summary>
    /// Класс "Заказ поставщику"
    /// </summary>
    public class CLotOrder
    {
        #region Свойства
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public System.Guid ID { get; set; }
        /// <summary>
        /// Уникальный идентификатор в IB
        /// </summary>
        public System.Int32 Ib_ID { get; set; }
        /// <summary>
        /// Уникальный идентификатор в IB
        /// </summary>
        public System.Int32 SrcIb_ID { get; set; }
        /// <summary>
        /// Номер заказа
        /// </summary>
        public System.String Number {get; set;}
        /// <summary>
        /// Дата оформления заказа
        /// </summary>
        public System.DateTime Date {get; set;}
        /// <summary>
        /// Дата отгрузки заказа поставщиком
        /// </summary>
        public System.DateTime DateShip { get; set; }
        /// <summary>
        /// Дата планируемого поступления на склад прихода
        /// </summary>
        public System.DateTime DateStockPrognostic {get; set;}
        /// <summary>
        /// Поставщик
        /// </summary>
        public ERP_Mercury.Common.CVendor Vendor {get; set;}
        /// <summary>
        /// Поставщик (наименование)
        /// </summary>
        public System.String VendorName
        {
            get
            {
                return (Vendor == null ? "" : Vendor.Name);
            }
        }
        /// <summary>
        /// Валюта заказа
        /// </summary>
        public ERP_Mercury.Common.CCurrency Currency {get; set;}
        /// <summary>
        /// Валюта заказа (сокращение)
        /// </summary>
        public System.String CurrencyCode
        {
            get
            {
                return (Currency == null ? "" : Currency.CurrencyAbbr);
            }
        }
        /// <summary>
        /// Текущее состояние заказа
        /// </summary>
        public ERP_Mercury.Common.CLotOrderState CurrentLotorderState {get; set;}
        /// <summary>
        /// Текущее состояние заказа (наименование)
        /// </summary>
        public System.String CurrentLotorderStateName
        { 
            get {
                    return ( CurrentLotorderState == null ? "" : CurrentLotorderState.Name); 
                }
        }
        /// <summary>
        /// № состояния по порядку
        /// </summary>
        public System.Int32 LotOrderStateOrderNum
        {
            get
            {
                return (CurrentLotorderState == null ? 0 : CurrentLotorderState.OrderNum);
            }
        }
        /// <summary>
        /// Примечание
        /// </summary>
        public System.String Description {get; set;}
        /// <summary>
        /// Признак "заказ активен"
        /// </summary>
        public System.Boolean IsActive {get; set;}
        /// <summary>
        /// Сумма заказа без скидки по тарифу поставщика
        /// </summary>
        public System.Double AllPriceEXW {get; set;}
        /// <summary>
        /// Сумма по инвойсу
        /// </summary>
        public System.Double AllPriceInvoice {get; set;}
        /// <summary>
        /// Сумма для расчёта себестоимости
        /// </summary>
        public System.Double AllPriceForCalcCostPrice {get; set;}
        /// <summary>
        /// Приложение к заказу
        /// </summary>
        public List<CLotOrderItems> LotOrderItemsList { get; set; }
        /// <summary>
        /// Количество в инвойсе
        /// </summary>
        public System.Double QuantityInDoc { get; set; }
        #endregion

        #region Конструктор
        public CLotOrder()
        {
            ID = System.Guid.Empty;
            Ib_ID = 0;
            SrcIb_ID = 0;
            Number = "";
            Date = System.DateTime.MinValue;
            DateStockPrognostic = System.DateTime.MinValue;
            DateShip = System.DateTime.MinValue;
            Currency = null;
            Vendor = null;
            CurrentLotorderState = null;
            Description = "";
            IsActive = false;
            AllPriceEXW = 0;
            AllPriceInvoice = 0;
            AllPriceForCalcCostPrice = 0;
            QuantityInDoc = 0;

            LotOrderItemsList = null;
        }
        #endregion

        #region Приложение к заказу
        /// <summary>
        /// Загружает в заказ приложение из БД
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        public System.Boolean Init( UniXP.Common.CProfile objProfile, ref System.String strErr )
        {
            System.Boolean bRet = false;
            System.Int32 iRes = 0;
            try
            {
                this.LotOrderItemsList = CLotOrderRepository.GetLotOrderItemsList(objProfile, null, this.ID, ref iRes, ref strErr);
                bRet = (iRes == 0);

                if (bRet == false)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show( strErr, "Внимание",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            catch (System.Exception f)
            {
                strErr += ("Не удалось получить приложение к заказу. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return bRet;
        }
        #endregion
    }

    /// <summary>
    /// Класс "Строка в приложении к заказу"
    /// </summary>
    public class CLotOrderItems
    {
        #region Свойства
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public System.Guid ID { get; set; }
        /// <summary>
        /// Уникальный идентификатор в InterBase
        /// </summary>
        public System.Int32 Ib_Id { get; set; }
        /// <summary>
        /// Товар
        /// </summary>
        public ERP_Mercury.Common.CProduct Product { get; set; }
        /// <summary>
        /// Единица измерения
        /// </summary>
        public ERP_Mercury.Common.CMeasure Measure { get; set; }
        /// <summary>
        /// заказанное количество
        /// </summary>
        public System.Double QuantityOrder { get; set; }
        /// <summary>
        /// количество подтверждённое поставщиком
        /// </summary>
        public System.Double QuantityConfirm { get; set; }
        /// <summary>
        /// количество в документе от поставщика
        /// </summary>
        public System.Double Quantity { get; set; }
        /// <summary>
        /// количество, включенное в КЛП
        /// </summary>
        public System.Double QuantityInKLP { get; set; }
        /// <summary>
        /// тариф поставщика
        /// </summary>
        public System.Double PriceVendorTarif { get; set; }
        /// <summary>
        /// размер предоставленной скидки в %
        /// </summary>
        public System.Double DiscountPercent { get; set; }
        /// <summary>
        /// тариф поставщика с учётом скидки (цена по инвойсу)
        /// </summary>
        public System.Double PriceVendorTarifWithDiscount { get; set; }
        /// <summary>
        /// Цена в ОВУ для расчёта себестоимости
        /// </summary>
        public System.Double PriceForCalcCostPrice { get; set; }
        /// <summary>
        /// (тариф поставщика х заказанное количество )
        /// </summary>
        public System.Double SumPriceVendorTarifOrder { get { return ( PriceVendorTarif * QuantityOrder ); }}
        /// <summary>
        /// (тариф поставщика х количество подтверждённое поставщиком )
        /// </summary>
        public System.Double SumPriceVendorTarifConfirm { get { return (PriceVendorTarif * QuantityConfirm); } }
        /// <summary>
        /// (тариф поставщика х количество в документе от поставщика )
        /// </summary>
        public System.Double SumPriceVendorTarif { get { return (PriceVendorTarif * Quantity); } }
        /// <summary>
        /// (тариф поставщика с учётом скидки х заказанное количество )
        /// </summary>
        public System.Double SumPriceVendorTarifOrderWithDiscount { get { return (PriceVendorTarifWithDiscount * QuantityOrder); } }
        /// <summary>
        /// (тариф поставщика с учётом скидки х количество подтверждённое поставщиком )
        /// </summary>
        public System.Double SumPriceVendorTarifConfirmWithDiscount { get { return (PriceVendorTarifWithDiscount * QuantityConfirm); } }
        /// <summary>
        /// (тариф поставщика с учётом скидки х количество в документе от поставщика )
        /// </summary>
        public System.Double SumPriceVendorTarifWithDiscount { get { return (PriceVendorTarifWithDiscount * Quantity); } }
        /// <summary>
        /// (цена в ОВУ для расчёта себестоимости х количество подтверждённое поставщиком )
        /// </summary>
        public System.Double SumPriceForCalcCostPrice { get { return (PriceVendorTarifWithDiscount * QuantityConfirm); } }
        /// <summary>
        /// Тариф в справочнике
        /// </summary>
        public System.Double PriceVendorTarifInDirectory { get; set; }
        /// <summary>
        /// Вес в справочнике
        /// </summary>
        public System.Double ProductWeightInDirectory { get; set; }
        /// <summary>
        /// Срок годности
        /// </summary>
        public System.DateTime ExpirationDare { get; set; }
        /// <summary>
        /// Таможенный тариф
        /// </summary>
        public System.Double CustomTarifPercent { get; set; }
        /// <summary>
        /// Страна производства
        /// </summary>
        public ERP_Mercury.Common.CCountry CountryProduction { get; set; }

        #endregion

        #region Конструктор
        public CLotOrderItems()
        {
            ID = System.Guid.Empty;
            Ib_Id = 0;
            Product = null;
            Measure = null;
            Quantity = 0;
            QuantityConfirm = 0;
            QuantityOrder = 0;
            QuantityInKLP = 0;
            PriceVendorTarif = 0;
            PriceVendorTarifWithDiscount = 0;
            PriceForCalcCostPrice = 0;
            DiscountPercent = 0;
            PriceVendorTarifInDirectory = 0;
            ProductWeightInDirectory = 0;
            CustomTarifPercent = 0;
            CountryProduction = null;
        }
        #endregion

        #region Преобразование приложения к заказу в таблицу
        /// <summary>
        /// Преобразует приложение к заказу в таблицу
        /// </summary>
        /// <param name="objLotOrderItemslist">приложение к заказу</param>
        /// <param name="uuidLotOrderID">уи заказа</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>таблица</returns>
        public static System.Data.DataTable ConvertListToTable(List<CLotOrderItems> objLotOrderItemslist, System.Guid uuidLotOrderID, ref System.String strErr)
        {
            if (objLotOrderItemslist == null) { return null; }
            System.Data.DataTable addedItems = new System.Data.DataTable();

            try
            {
                addedItems.Columns.Add(new System.Data.DataColumn("LotOrderItems_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotOrder_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("Parts_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("Measure_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotOrderItems_OrderQuantity", typeof(System.Data.SqlTypes.SqlDouble)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotOrderItems_Quantity", typeof(System.Data.SqlTypes.SqlDouble)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotOrderItems_VendorPrice", typeof(System.Data.SqlTypes.SqlMoney)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotOrderItems_DiscountPercent", typeof(System.Data.SqlTypes.SqlMoney)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotOrderItems_DiscountVendorPrice", typeof(System.Data.SqlTypes.SqlMoney)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotOrderItems_PriceForCalcCostPrice", typeof(System.Data.SqlTypes.SqlMoney)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotOrderItems_ConfirmQuantity", typeof(System.Data.SqlTypes.SqlDouble)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotOrderItems_ExpDate", typeof(System.Data.SqlTypes.SqlDateTime)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotOrderItems_CustomTarifPercent", typeof(System.Data.SqlTypes.SqlDouble)));
                addedItems.Columns.Add(new System.Data.DataColumn("CountryProduction_Guid", typeof(System.Data.SqlTypes.SqlGuid)));

                System.Data.DataRow newRow = null;
                foreach (CLotOrderItems objItem in objLotOrderItemslist)
                {
                    newRow = addedItems.NewRow();
                    newRow["LotOrderItems_Guid"] = objItem.ID;
                    newRow["LotOrder_Guid"] = uuidLotOrderID;
                    newRow["Parts_Guid"] = objItem.Product.ID;
                    newRow["Measure_Guid"] = objItem.Measure.ID;
                    newRow["LotOrderItems_OrderQuantity"] = objItem.QuantityOrder;
                    newRow["LotOrderItems_Quantity"] = objItem.Quantity;
                    newRow["LotOrderItems_VendorPrice"] = (System.Data.SqlTypes.SqlMoney)objItem.PriceVendorTarif;
                    newRow["LotOrderItems_DiscountPercent"] = (System.Data.SqlTypes.SqlMoney)objItem.DiscountPercent;
                    newRow["LotOrderItems_DiscountVendorPrice"] = (System.Data.SqlTypes.SqlMoney)objItem.PriceVendorTarifWithDiscount;
                    newRow["LotOrderItems_PriceForCalcCostPrice"] = (System.Data.SqlTypes.SqlMoney)objItem.PriceForCalcCostPrice;
                    newRow["LotOrderItems_ConfirmQuantity"] = objItem.QuantityConfirm;
                    newRow["LotOrderItems_CustomTarifPercent"] = (System.Data.SqlTypes.SqlMoney)objItem.CustomTarifPercent;
                    newRow["CountryProduction_Guid"] = objItem.CountryProduction.ID;
                    if (objItem.ExpirationDare != System.DateTime.MinValue)
                    {
                        newRow["LotOrderItems_ExpDate"] = (System.Data.SqlTypes.SqlDateTime)objItem.ExpirationDare;
                    }
                    addedItems.Rows.Add(newRow);
                }

                addedItems.AcceptChanges();
            }
            catch (System.Exception f)
            {
                strErr = f.Message;
            }
            finally
            {
            }

            return addedItems;
        }
        #endregion
    }
    /// <summary>
    /// Класс "История изменений"
    /// </summary>
    public class CLotOrderHistory
    {
        #region Свойства
        public struct LotOrderHistoryRecord
        {
            public System.DateTime RecordDateTimeUpdate;
            public System.String RecordUserUpdate;
            public ERP_Mercury.Common.CLotOrderState LotOrderState;

            public LotOrderHistoryRecord(System.DateTime dtRecordDateTimeUpdate, System.String strRecordUserUpdate,
                ERP_Mercury.Common.CLotOrderState objLotOrderState)
            {
                RecordDateTimeUpdate = dtRecordDateTimeUpdate;
                RecordUserUpdate = strRecordUserUpdate;
                LotOrderState = objLotOrderState;
            }
        }

        public List<LotOrderHistoryRecord> LotOrderHistoryRecordList { get; set; }

        #endregion

        #region Конструктор
        public CLotOrderHistory()
        {
            LotOrderHistoryRecordList = null;
        }
        #endregion

        #region Добавление записи в журнал
        public void AddLotOrderHistoryRecord(System.DateTime dtRecordDateTimeUpdate, System.String strRecordUserUpdate,
                ERP_Mercury.Common.CLotOrderState objLotOrderState)
        {
            System.Int32 iRecordCount = 0;
            try
            {
                if (LotOrderHistoryRecordList == null)
                {
                    LotOrderHistoryRecordList = new List<LotOrderHistoryRecord>();
                }

                iRecordCount = LotOrderHistoryRecordList.Count;
                LotOrderHistoryRecordList.Add(new LotOrderHistoryRecord(dtRecordDateTimeUpdate, strRecordUserUpdate, objLotOrderState));
            }
            catch
            {
                if( ( LotOrderHistoryRecordList != null ) && ( LotOrderHistoryRecordList.Count != 0 ) 
                    && ( LotOrderHistoryRecordList.Count > iRecordCount ) )
                {
                    LotOrderHistoryRecordList.RemoveAt( LotOrderHistoryRecordList.Count - 1 );
                }
            }
            return ;
        }
        #endregion
    }

    public class CLotOrderRepository
    {
        #region Список заказов
        /// <summary>
        /// Возвращает список заказов поставщику
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="dtBeginDate">начало периода для поиска</param>
        /// <param name="dtEndDate">окончание периода для поиска</param>
        /// <param name="uuidVendorId">уи поставщика</param>
        /// <param name="strLotOrderNum">номер заказа</param>
        /// <returns>список заказов поставщику (объекты класса CLotOrder)</returns>
        public static List<CLotOrder> GetLotOrderList(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.DateTime dtBeginDate, System.DateTime dtEndDate, System.Guid uuidVendorId, System.String strLotOrderNum, 
            ref System.String strErr)
        {
            List<CLotOrder> objList = new List<CLotOrder>();
            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            try
            {
                if (cmdSQL == null)
                {
                    DBConnection = objProfile.GetDBSource();
                    if (DBConnection == null)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                            "Не удалось получить соединение с базой данных.", "Внимание",
                            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return objList;
                    }
                    cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.Connection = DBConnection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    cmd = cmdSQL;
                    cmd.Parameters.Clear();
                }

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_GetLotOrder]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                if (uuidVendorId.CompareTo(System.Guid.Empty) != 0)
                {
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Vendor_Guid", System.Data.SqlDbType.UniqueIdentifier));
                    cmd.Parameters["@Vendor_Guid"].Value = uuidVendorId;
                }
                if (strLotOrderNum != "")
                {
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Num", System.Data.SqlDbType.NVarChar, 58));
                    cmd.Parameters["@LotOrder_Num"].Value = strLotOrderNum;
                }
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BeginDate", System.Data.SqlDbType.Date));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EndDate", System.Data.SqlDbType.Date));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters["@BeginDate"].Value = dtBeginDate;
                cmd.Parameters["@EndDate"].Value = dtEndDate;
                System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        objList.Add(new CLotOrder()
                        {
                            ID = (System.Guid)rs["LotOrder_Guid"],
                            Ib_ID = System.Convert.ToInt32(rs["LotOrder_Id"]),
                            SrcIb_ID = ((rs["SrcLotOrder_Id"] == System.DBNull.Value) ? 0 : System.Convert.ToInt32(rs["SrcLotOrder_Id"])),
                            Number = System.Convert.ToString(rs["LotOrder_Num"]),
                            Description = ((rs["LotOrder_Description"] == System.DBNull.Value) ? "" : System.Convert.ToString(rs["LotOrder_Description"])),
                            Vendor = new ERP_Mercury.Common.CVendor() 
                            { 
                                ID = (System.Guid)rs["Vendor_Guid"], 
                                Name = System.Convert.ToString( rs["Vendor_Name"] ), 
                                TypeVendor = new ERP_Mercury.Common.CVendorType() { ID =  (System.Guid)rs["VendorType_Guid"], Name = System.Convert.ToString( rs["VendorType_Name"] ) } },
                            CurrentLotorderState = new ERP_Mercury.Common.CLotOrderState()
                            {
                                ID = (System.Guid)rs["LotOrderSate_Guid"],
                                Name = System.Convert.ToString(rs["LotOrderSate_Name"]),
                                Description = ((rs["LotOrderSate_Description"] == System.DBNull.Value) ? "" : System.Convert.ToString(rs["LotOrderSate_Description"])),
                                OrderNum = System.Convert.ToInt32(rs["LotOrderSate_OrderNum"]),
                                IsActive = System.Convert.ToBoolean(rs["LotOrderSate_IsActive"])
                            },
                            Date = System.Convert.ToDateTime(rs["LotOrder_Date"]),
                            DateStockPrognostic = ( ( rs["LotOrder_StockDate"] == System.DBNull.Value ) ? System.DateTime.MinValue : System.Convert.ToDateTime(rs["LotOrder_StockDate"]) ),
                            DateShip = ((rs["LotOrder_ShipDate"] == System.DBNull.Value) ? System.DateTime.MinValue : System.Convert.ToDateTime(rs["LotOrder_ShipDate"])),
                            Currency = new ERP_Mercury.Common.CCurrency() 
                            { 
                                ID = (System.Guid)rs["Currency_Guid"], 
                                CurrencyAbbr = System.Convert.ToString(rs["Currency_Abbr"]) 
                            },
                            AllPriceEXW = System.Convert.ToDouble(rs["LotOrderAllPriceEXW"]),
                            AllPriceInvoice = System.Convert.ToDouble(rs["LotOrderAllPriceInvoice"]),
                            AllPriceForCalcCostPrice = System.Convert.ToDouble(rs["LotOrderAllPriceForCalcCostPrice"]),
                            QuantityInDoc = System.Convert.ToDouble(rs["LotOrder_QuantityInDoc"])
                        });
                    }
                }
                rs.Dispose();
                if (cmdSQL == null)
                {
                    cmd.Dispose();
                    DBConnection.Close();
                }
            }
            catch (System.Exception f)
            {
                strErr = "Не удалось получить список заказов. Текст ошибки: " + f.Message;
            }
            return objList;
        }

        #endregion

        #region Приложение к заказу
        /// <summary>
        /// Возвращает приложение к заказу
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="uuidLotOrderId">уи заказа</param>
        /// <returns>список объектов класса CLotOrderItems</returns>
        public static List<CLotOrderItems> GetLotOrderItemsList( UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid uuidLotOrderId, ref System.Int32 iRes, ref System.String strErr)
        {
            List<CLotOrderItems> objList = new List<CLotOrderItems>();
            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            try
            {
                if (cmdSQL == null)
                {
                    DBConnection = objProfile.GetDBSource();
                    if (DBConnection == null)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                            "Не удалось получить соединение с базой данных.", "Внимание",
                            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return objList;
                    }
                    cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.Connection = DBConnection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    cmd = cmdSQL;
                    cmd.Parameters.Clear();
                }

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_GetLotOrderItems]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                if (uuidLotOrderId.CompareTo(System.Guid.Empty) != 0)
                {
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Guid", System.Data.SqlDbType.UniqueIdentifier));
                    cmd.Parameters["@LotOrder_Guid"].Value = uuidLotOrderId;
                }
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();
                iRes = System.Convert.ToInt32( cmd.Parameters["@ERROR_NUM"].Value );
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        objList.Add(new CLotOrderItems()
                        {
                            ID = (System.Guid)rs["LotOrderItems_Guid"],
                            Ib_Id = System.Convert.ToInt32(rs["LotOrderItems_Id"]),
                            Product = new ERP_Mercury.Common.CProduct() { ID = (System.Guid)rs["Parts_Guid"], Name = System.Convert.ToString(rs["Parts_Name"]), Article = System.Convert.ToString(rs["Parts_Article"]), VendorPrice = System.Convert.ToDecimal(rs["Parts_VendorPrice"]), PackQuantity = System.Convert.ToInt32(rs["Parts_PackQuantity"]), ID_Ib = System.Convert.ToInt32(rs["Parts_Id"]) },
                            Measure = new ERP_Mercury.Common.CMeasure() { ID = (System.Guid)rs["Measure_Guid"], Name = System.Convert.ToString(rs["Measure_Name"]), ShortName = System.Convert.ToString(rs["Measure_ShortName"]) },
                            QuantityOrder = System.Convert.ToDouble(rs["LotOrderItems_OrderQuantity"]),
                            QuantityConfirm = System.Convert.ToDouble(rs["LotOrderItems_ConfirmQuantity"]),
                            Quantity = System.Convert.ToDouble(rs["LotOrderItems_Quantity"]),
                            PriceVendorTarif = System.Convert.ToDouble(rs["LotOrderItems_VendorPrice"]),
                            DiscountPercent = System.Convert.ToDouble(rs["LotOrderItems_DiscountPercent"]),
                            PriceVendorTarifWithDiscount = System.Convert.ToDouble(rs["LotOrderItems_DiscountVendorPrice"]),
                            PriceForCalcCostPrice = System.Convert.ToDouble(rs["LotOrderItems_PriceForCalcCostPrice"]),
                            ProductWeightInDirectory = System.Convert.ToDouble(rs["Parts_Weight"]),
                            PriceVendorTarifInDirectory = System.Convert.ToDouble(rs["Parts_VendorPrice"]),
                            ExpirationDare = ((rs["LotOrderItems_ExpDate"] == System.DBNull.Value) ? System.DateTime.MinValue : System.Convert.ToDateTime(rs["LotOrderItems_ExpDate"])),
                            CustomTarifPercent = System.Convert.ToDouble(rs["LotOrderItems_CustomTarifPercent"]),
                            CountryProduction = new ERP_Mercury.Common.CCountry() { ID = (System.Guid)rs["CountryProduction_Guid"], Name = System.Convert.ToString(rs["Country_Name"]) }
                        });
                    }
                }
                rs.Dispose();
                if (cmdSQL == null)
                {
                    cmd.Dispose();
                    DBConnection.Close();
                }
            }
            catch (System.Exception f)
            {
                strErr = "Не удалось получить приложение к заказу. Текст ошибки: " + f.Message;
            }
            return objList;
        }
        #endregion

        #region Добавление в БД информации о заказе
        /// <summary>
        /// Проверяет заполнение свойств заказа перед сохранением в БД
        /// </summary>
        /// <param name="Order_BeginDate">дата заказа</param>
        /// <param name="Vendor_Guid">уи поставщика</param>
        /// <param name="Currency_Guid">уи валюты заказа</param>
        /// <param name="LotOrderState_Guid">уи состояния заказа</param>
        /// <param name="addedCategories">приложение к заказу</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - все обязательные поля заполнены; false - не все обязазательные поля заполнены</returns>
        public static System.Boolean CheckAllPropertiesForSave( System.DateTime Order_BeginDate, System.Guid Vendor_Guid,
            System.Guid Currency_Guid, System.Guid LotOrderState_Guid, System.Data.DataTable addedCategories, ref System.String strErr )
        {
            System.Boolean bRet = false;
            try
            {
                if (Order_BeginDate == System.DateTime.MinValue)
                {
                    strErr = "Укажите, пожалуйста, дату заказа.";
                    return bRet;
                }
                if (Vendor_Guid == System.Guid.Empty)
                {
                    strErr = "Укажите, пожалуйста, поставщика.";
                    return bRet;
                }
                if (Currency_Guid == System.Guid.Empty)
                {
                    strErr = "Укажите, пожалуйста, валюту заказа.";
                    return bRet;
                }
                if (LotOrderState_Guid == System.Guid.Empty)
                {
                    strErr = "Укажите, пожалуйста, состояние заказа.";
                    return bRet;
                }
                if ((addedCategories == null) || (addedCategories.Rows.Count == 0))
                {
                    strErr = "Приложение к заказу не содержит записей. Добавьте, пожалуйста, хотя бы одну позицию.";
                    return bRet;
                }

                bRet = true;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "CheckAllPropertiesForSave.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return bRet;
        }

        /// <summary>
        /// Добавляет в БД информацию о заказе
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="LotOrder_Num">номер заказа</param>
        /// <param name="LotOrder_Date">дата формирования заказа</param>
        /// <param name="LotOrder_StockDate">дата планируемого поступления на склад приёмки товара</param>
        /// <param name="Vendor_Guid">уи поставщика</param>
        /// <param name="Currency_Guid">уи валюты</param>
        /// <param name="LotOrder_Description">примечание</param>
        /// <param name="LotOrder_IsActive">признак "активен"</param>
        /// <param name="LotOrder_Guid">уи заказа</param>
        /// <param name="LotOrder_AllPriceEXW">сумма заказа по тарифу поставщика</param>
        /// <param name="LotOrder_AllPriceInvoice">сумма по инвойсу</param>
        /// <param name="LotOrder_AllPriceForCalcCostPrice">сумма по цене для расчёта себестоимости</param>
        /// <param name="addedItems">приложение к заказу</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        public static System.Boolean AddLotOrder(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL, 
            System.String LotOrder_Num, System.DateTime LotOrder_Date, System.DateTime LotOrder_ShipDate, System.DateTime LotOrder_StockDate, 
            System.Guid Vendor_Guid, System.Guid Currency_Guid, System.String LotOrder_Description, System.Boolean LotOrder_IsActive,
            System.Guid LotOrderState_Guid, System.Data.DataTable addedItems,
            ref System.Guid LotOrder_Guid, ref System.Int32 LotOrder_Id, ref System.Double LotOrder_AllPriceEXW, ref System.Double LotOrder_AllPriceInvoice,
            ref System.Double LotOrder_AllPriceForCalcCostPrice, ref System.String strErr)
        {
            System.Boolean bRet = false;
            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            try
            {
                if (cmdSQL == null)
                {
                    DBConnection = objProfile.GetDBSource();
                    if (DBConnection == null)
                    {
                        strErr = "Не удалось получить соединение с базой данных.";
                        return bRet;
                    }
                    cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.Connection = DBConnection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    cmd = cmdSQL;
                    cmd.Parameters.Clear();
                }
                cmd.Parameters.Clear();
                cmd.CommandTimeout = 600;
                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_AddLotOrder]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.AddWithValue("@tLotOrderItems", addedItems);
                cmd.Parameters["@tLotOrderItems"].SqlDbType = System.Data.SqlDbType.Structured;
                cmd.Parameters["@tLotOrderItems"].TypeName = "dbo.udt_LotOrderItems";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Num", System.Data.SqlDbType.NVarChar, 56));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Date", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_StockDate", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_ShipDate", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Vendor_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Currency_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrderState_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Description", System.Data.SqlDbType.NVarChar, 512));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_IsActive", System.Data.SqlDbType.Bit));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters["@LotOrder_Guid"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Id", System.Data.SqlDbType.Int));
                cmd.Parameters["@LotOrder_Id"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_AllPriceEXW", System.Data.SqlDbType.Money));
                cmd.Parameters["@LotOrder_AllPriceEXW"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_AllPriceInvoice", System.Data.SqlDbType.Money));
                cmd.Parameters["@LotOrder_AllPriceInvoice"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_AllPriceForCalcCostPrice", System.Data.SqlDbType.Money));
                cmd.Parameters["@LotOrder_AllPriceForCalcCostPrice"].Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters["@LotOrder_Num"].Value = LotOrder_Num;
                cmd.Parameters["@LotOrder_Date"].Value = LotOrder_Date;
                cmd.Parameters["@LotOrder_ShipDate"].Value = LotOrder_ShipDate;

                if (System.DateTime.Compare(LotOrder_StockDate, System.DateTime.MinValue) == 0)
                {
                    cmd.Parameters["@LotOrder_StockDate"].IsNullable = true;
                    cmd.Parameters["@LotOrder_StockDate"].Value = null;
                }
                else
                {
                    cmd.Parameters["@LotOrder_StockDate"].Value = LotOrder_StockDate;
                }
                cmd.Parameters["@Vendor_Guid"].Value = Vendor_Guid;
                cmd.Parameters["@Currency_Guid"].Value = Currency_Guid;
                cmd.Parameters["@LotOrderState_Guid"].Value = LotOrderState_Guid;
                cmd.Parameters["@LotOrder_Description"].Value = LotOrder_Description;
                cmd.Parameters["@LotOrder_IsActive"].Value = LotOrder_IsActive;

                cmd.ExecuteNonQuery();
                System.Int32 iRes = (System.Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                if (iRes == 0)
                {
                    LotOrder_Guid = (System.Guid)cmd.Parameters["@LotOrder_Guid"].Value;
                    LotOrder_Id = System.Convert.ToInt32(cmd.Parameters["@LotOrder_Id"].Value);
                    LotOrder_AllPriceEXW = System.Convert.ToDouble(cmd.Parameters["@LotOrder_AllPriceEXW"].Value);
                    LotOrder_AllPriceInvoice = System.Convert.ToDouble(cmd.Parameters["@LotOrder_AllPriceInvoice"].Value);
                    LotOrder_AllPriceForCalcCostPrice = System.Convert.ToDouble(cmd.Parameters["@LotOrder_AllPriceForCalcCostPrice"].Value);
                }
                else
                {
                    strErr = (System.String)cmd.Parameters["@ERROR_MES"].Value;
                }

                if (cmdSQL == null)
                {
                    DBConnection.Close();
                }
                bRet = (iRes == 0);
            }
            catch (System.Exception f)
            {
                strErr = f.Message;
            }
            finally
            {
                if (DBConnection != null)
                {
                    DBConnection.Close();
                }
            }
            return bRet;
        }

        #endregion

        #region Редактирование в БД информации о заказе
        /// <summary>
        /// Вносит изменения в БД о заказе
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="LotOrder_Num">номер заказа</param>
        /// <param name="LotOrder_Date">дата формирования заказа</param>
        /// <param name="LotOrder_StockDate">дата планируемого поступления на склад приёмки товара</param>
        /// <param name="Vendor_Guid">уи поставщика</param>
        /// <param name="Currency_Guid">уи валюты</param>
        /// <param name="LotOrder_Description">примечание</param>
        /// <param name="LotOrder_IsActive">признак "активен"</param>
        /// <param name="LotOrder_Guid">уи заказа</param>
        /// <param name="LotOrder_AllPriceEXW">сумма заказа по тарифу поставщика</param>
        /// <param name="LotOrder_AllPriceInvoice">сумма по инвойсу</param>
        /// <param name="LotOrder_AllPriceForCalcCostPrice">сумма по цене для расчёта себестоимости</param>
        /// <param name="addedItems">приложение к заказу</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        public static System.Boolean EditLotOrder(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.String LotOrder_Num, System.DateTime LotOrder_Date, System.DateTime LotOrder_ShipDate, System.DateTime LotOrder_StockDate,
            System.Guid Vendor_Guid, System.Guid Currency_Guid, System.String LotOrder_Description, System.Boolean LotOrder_IsActive,
            System.Guid LotOrderState_Guid, System.Data.DataTable addedItems,
            System.Guid LotOrder_Guid, ref System.Double LotOrder_AllPriceEXW, ref System.Double LotOrder_AllPriceInvoice,
            ref System.Double LotOrder_AllPriceForCalcCostPrice, ref System.String strErr)
        {
            System.Boolean bRet = false;
            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            try
            {
                if (cmdSQL == null)
                {
                    DBConnection = objProfile.GetDBSource();
                    if (DBConnection == null)
                    {
                        strErr = "Не удалось получить соединение с базой данных.";
                        return bRet;
                    }
                    cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.Connection = DBConnection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    cmd = cmdSQL;
                    cmd.Parameters.Clear();
                }
                cmd.Parameters.Clear();
                cmd.CommandTimeout = 600;
                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_EditLotOrder]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.AddWithValue("@tLotOrderItems", addedItems);
                cmd.Parameters["@tLotOrderItems"].SqlDbType = System.Data.SqlDbType.Structured;
                cmd.Parameters["@tLotOrderItems"].TypeName = "dbo.udt_LotOrderItems";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Guid", System.Data.SqlDbType.UniqueIdentifier)); 
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Num", System.Data.SqlDbType.NVarChar, 56));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Date", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_ShipDate", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_StockDate", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Vendor_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrderState_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Currency_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Description", System.Data.SqlDbType.NVarChar, 512));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_IsActive", System.Data.SqlDbType.Bit));

                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_AllPriceEXW", System.Data.SqlDbType.Money));
                cmd.Parameters["@LotOrder_AllPriceEXW"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_AllPriceInvoice", System.Data.SqlDbType.Money));
                cmd.Parameters["@LotOrder_AllPriceInvoice"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_AllPriceForCalcCostPrice", System.Data.SqlDbType.Money));
                cmd.Parameters["@LotOrder_AllPriceForCalcCostPrice"].Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters["@LotOrder_Num"].Value = LotOrder_Num;
                cmd.Parameters["@LotOrder_Date"].Value = LotOrder_Date;
                cmd.Parameters["@LotOrder_ShipDate"].Value = LotOrder_ShipDate;

                if (System.DateTime.Compare(LotOrder_StockDate, System.DateTime.MinValue) == 0)
                {
                    cmd.Parameters["@LotOrder_StockDate"].IsNullable = true;
                    cmd.Parameters["@LotOrder_StockDate"].Value = null;
                }
                else
                {
                    cmd.Parameters["@LotOrder_StockDate"].Value = LotOrder_StockDate;
                }
                cmd.Parameters["@LotOrder_Guid"].Value = LotOrder_Guid;
                cmd.Parameters["@Vendor_Guid"].Value = Vendor_Guid;
                cmd.Parameters["@Currency_Guid"].Value = Currency_Guid;
                cmd.Parameters["@LotOrderState_Guid"].Value = LotOrderState_Guid;
                cmd.Parameters["@LotOrder_Description"].Value = LotOrder_Description;
                cmd.Parameters["@LotOrder_IsActive"].Value = LotOrder_IsActive;

                cmd.ExecuteNonQuery();
                System.Int32 iRes = (System.Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                if (iRes == 0)
                {
                    LotOrder_AllPriceEXW = System.Convert.ToDouble(cmd.Parameters["@LotOrder_AllPriceEXW"].Value);
                    LotOrder_AllPriceInvoice = System.Convert.ToDouble(cmd.Parameters["@LotOrder_AllPriceInvoice"].Value);
                    LotOrder_AllPriceForCalcCostPrice = System.Convert.ToDouble(cmd.Parameters["@LotOrder_AllPriceForCalcCostPrice"].Value);
                }
                else
                {
                    strErr = (System.String)cmd.Parameters["@ERROR_MES"].Value;
                }

                if (cmdSQL == null)
                {
                    DBConnection.Close();
                }
                bRet = (iRes == 0);
            }
            catch (System.Exception f)
            {
                strErr = f.Message;
            }
            finally
            {
                if (DBConnection != null)
                {
                    DBConnection.Close();
                }
            }
            return bRet;
        }

        #endregion

        #region Удаление заказа из БД
        /// <summary>
        /// Удаляет из БД информацию о заказе
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="LotOrder_Guid">уи заказа</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        public static System.Boolean DeleteLotOrder(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid LotOrder_Guid,  ref System.String strErr)
        {
            System.Boolean bRet = false;
            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            try
            {
                if (cmdSQL == null)
                {
                    DBConnection = objProfile.GetDBSource();
                    if (DBConnection == null)
                    {
                        strErr = "Не удалось получить соединение с базой данных.";
                        return bRet;
                    }
                    cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.Connection = DBConnection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    cmd = cmdSQL;
                    cmd.Parameters.Clear();
                }
                cmd.Parameters.Clear();
                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_DeleteLotOrder]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters["@LotOrder_Guid"].Value = LotOrder_Guid;

                cmd.ExecuteNonQuery();
                System.Int32 iRes = (System.Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                if (iRes != 0)
                {
                    strErr = (System.String)cmd.Parameters["@ERROR_MES"].Value;
                }

                if (cmdSQL == null)
                {
                    DBConnection.Close();
                }
                bRet = (iRes == 0);
            }
            catch (System.Exception f)
            {
                strErr = f.Message;
            }
            finally
            {
                if (DBConnection != null)
                {
                    DBConnection.Close();
                }
            }
            return bRet;
        }
        #endregion

        #region Журнал состояний заказа
        /// <summary>
        /// Возвращает журнал состояний заказа
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="uuidLotOrderId">уи заказа</param>
        /// <param name="iRes">результат выполнения хранимой процедуры</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>объект класса CLotOrderHistory</returns>
        public static CLotOrderHistory GetLotOrderHistory(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid uuidLotOrderId, ref System.Int32 iRes, ref System.String strErr)
        {
            CLotOrderHistory objList = new CLotOrderHistory();
            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            try
            {
                if (cmdSQL == null)
                {
                    DBConnection = objProfile.GetDBSource();
                    if (DBConnection == null)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                            "Не удалось получить соединение с базой данных.", "Внимание",
                            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return objList;
                    }
                    cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.Connection = DBConnection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    cmd = cmdSQL;
                    cmd.Parameters.Clear();
                }

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_GetLotOrderSateHistory]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                if (uuidLotOrderId.CompareTo(System.Guid.Empty) != 0)
                {
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Guid", System.Data.SqlDbType.UniqueIdentifier));
                    cmd.Parameters["@LotOrder_Guid"].Value = uuidLotOrderId;
                }
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();
                iRes = System.Convert.ToInt32(cmd.Parameters["@ERROR_NUM"].Value);
                if (rs.HasRows)
                {
                    objList.LotOrderHistoryRecordList = new List<CLotOrderHistory.LotOrderHistoryRecord>();
                    while (rs.Read())
                    {
                        objList.AddLotOrderHistoryRecord(System.Convert.ToDateTime(rs["Record_Updated"]),
                            System.Convert.ToString(rs["Record_UserUdpated"]),
                            new ERP_Mercury.Common.CLotOrderState() { ID = (System.Guid)rs["LotOrderState_Guid"],
                                                                      Name = System.Convert.ToString(rs["LotOrderSate_Name"]),
                                                                      OrderNum = System.Convert.ToInt32(rs["LotOrderSate_OrderNum"])
                            });
                    }
                }
                rs.Dispose();
                if (cmdSQL == null)
                {
                    cmd.Dispose();
                    DBConnection.Close();
                }
            }
            catch (System.Exception f)
            {
                strErr = "Не удалось получить журнал состояний заказа. Текст ошибки: " + f.Message;
            }
            return objList;
        }

        #endregion

        #region Выпадающий список для заполнения приложения к КЛП
        /// <summary>
        /// Возвращает приложение к заказу, не включённое в КЛП
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="uuidLotOrderId">уи заказа</param>
        /// <returns>список объектов класса CLotOrderItems</returns>
        public static List<CLotOrderItems> GetSrcForKlpItems(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid uuidLotOrderId, ref System.Int32 iRes, ref System.String strErr)
        {
            List<CLotOrderItems> objList = new List<CLotOrderItems>();
            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            try
            {
                if (cmdSQL == null)
                {
                    DBConnection = objProfile.GetDBSource();
                    if (DBConnection == null)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                            "Не удалось получить соединение с базой данных.", "Внимание",
                            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return objList;
                    }
                    cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.Connection = DBConnection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    cmd = cmdSQL;
                    cmd.Parameters.Clear();
                }

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_GetSrcForKlpItems]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                if (uuidLotOrderId.CompareTo(System.Guid.Empty) != 0)
                {
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Guid", System.Data.SqlDbType.UniqueIdentifier));
                    cmd.Parameters["@LotOrder_Guid"].Value = uuidLotOrderId;
                }
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();
                iRes = System.Convert.ToInt32(cmd.Parameters["@ERROR_NUM"].Value);
                if (rs.HasRows)
                {
                    CLotOrderItems objItem = null;
                    while (rs.Read())
                    {
                        if( (System.Convert.ToDouble(rs["LotOrderItems_Quantity"]) - System.Convert.ToDouble(rs["LotOrderItemsQuantityInKLP"])) > 0 )
                        {
                            // количество, указанное в строке заказа превышает количество для этой же строки заказа в приложении к КЛП
                            objItem = new CLotOrderItems();
                            {
                                objItem.ID = (System.Guid)rs["LotOrderItems_Guid"];
                                objItem.Ib_Id = System.Convert.ToInt32(rs["LotOrderItems_Id"]);
                                objItem.Product = new ERP_Mercury.Common.CProduct()
                                {
                                    ID = (System.Guid)rs["Parts_Guid"],
                                    Name = System.Convert.ToString(rs["Parts_Name"]),
                                    Article = System.Convert.ToString(rs["Parts_Article"]),
                                    VendorPrice = System.Convert.ToDecimal(rs["Parts_VendorPrice"]),
                                    PackQuantity = System.Convert.ToInt32(rs["Parts_PackQuantity"]),
                                    ID_Ib = System.Convert.ToInt32(rs["Parts_Id"]),
                                    BarcodeList = new List<string>(),
                                    ProductTradeMark = new ERP_Mercury.Common.CProductTradeMark() { ID = (System.Guid)rs["PartsOwner_Guid"] },
                                    AlcoholicContentPercent = System.Convert.ToDecimal(rs["Parts_AlcoholicContentPercent"])
                                };
                                objItem.Measure = new ERP_Mercury.Common.CMeasure() { ID = (System.Guid)rs["Measure_Guid"], Name = System.Convert.ToString(rs["Measure_Name"]), ShortName = System.Convert.ToString(rs["Measure_ShortName"]) };
                                objItem.QuantityOrder = System.Convert.ToDouble(rs["LotOrderItems_OrderQuantity"]);
                                objItem.QuantityConfirm = System.Convert.ToDouble(rs["LotOrderItems_ConfirmQuantity"]);
                                objItem.Quantity = System.Convert.ToDouble(rs["LotOrderItems_Quantity"]);
                                objItem.PriceVendorTarif = System.Convert.ToDouble(rs["LotOrderItems_VendorPrice"]);
                                objItem.DiscountPercent = System.Convert.ToDouble(rs["LotOrderItems_DiscountPercent"]);
                                objItem.PriceVendorTarifWithDiscount = System.Convert.ToDouble(rs["LotOrderItems_DiscountVendorPrice"]);
                                objItem.PriceForCalcCostPrice = System.Convert.ToDouble(rs["LotOrderItems_PriceForCalcCostPrice"]);
                                objItem.ProductWeightInDirectory = System.Convert.ToDouble(rs["Parts_Weight"]);
                                objItem.PriceVendorTarifInDirectory = System.Convert.ToDouble(rs["Parts_VendorPrice"]);
                                objItem.QuantityInKLP = System.Convert.ToDouble(rs["LotOrderItemsQuantityInKLP"]);
                                objItem.CustomTarifPercent = System.Convert.ToDouble(rs["LotOrderItems_CustomTarifPercent"]);
                                objItem.CountryProduction = new ERP_Mercury.Common.CCountry() { ID = (System.Guid)rs["CountryProduction_Guid"], Name = System.Convert.ToString(rs["Country_Name"]) };
                            };

                            if (rs["PartsBarcode"] != System.DBNull.Value)
                            {
                                objItem.Product.BarcodeList.Add(System.Convert.ToString(rs["PartsBarcode"]));
                            }

                            objList.Add( objItem );
                        }
                    }
                }
                rs.Dispose();
                if (cmdSQL == null)
                {
                    cmd.Dispose();
                    DBConnection.Close();
                }
            }
            catch (System.Exception f)
            {
                strErr = "Не удалось получить список позиций для формирования КЛП. Текст ошибки: " + f.Message;
            }
            return objList;
        }

        #endregion

        #region Смена состояния заказа

        /// <summary>
        /// Вносит изменения в состояние заказа в БД
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="uuidLotOrderId">уи заказа</param>
        /// <param name="uuidLotOrderStateId">уи состояния заказа</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <param name="iLotOrder_Id">уи заказа в InterBase</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        public static System.Boolean ChangeLotOrderSate(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid LotOrder_Guid, System.Guid LotOrderState_Guid, ref System.String strErr, ref System.Int32 LotOrder_Id)
        {
            System.Boolean bRes = false;
            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            try
            {
                if (cmdSQL == null)
                {
                    DBConnection = objProfile.GetDBSource();
                    if (DBConnection == null)
                    {
                        strErr = "Не удалось получить соединение с базой данных.";
                        return bRes;
                    }
                    cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.Connection = DBConnection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    cmd = cmdSQL;
                    cmd.Parameters.Clear();
                }

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_ChangeLotOrderSate]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrderState_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Id", System.Data.SqlDbType.Int));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters["@LotOrder_Id"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters["@LotOrder_Guid"].Value = LotOrder_Guid;
                cmd.Parameters["@LotOrderState_Guid"].Value = LotOrderState_Guid;
                System.Int32 iRes = cmd.ExecuteNonQuery();
                
                iRes = System.Convert.ToInt32(cmd.Parameters["@ERROR_NUM"].Value);
                strErr = System.Convert.ToString(cmd.Parameters["@ERROR_MES"].Value);

                if (iRes == 0)
                {
                    LotOrder_Id = System.Convert.ToInt32(cmd.Parameters["@LotOrder_Id"].Value);
                }

                bRes = (iRes == 0);

                if (cmdSQL == null)
                {
                    cmd.Dispose();
                    DBConnection.Close();
                }
            }
            catch (System.Exception f)
            {
                strErr = "Не удалось внести изменения в состояние заказа. Текст ошибки: " + f.Message;
            }
            return bRes;
        }
        #endregion

    }
}
