using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPMercuryLotOrder
{
    /// <summary>
    /// Класс "Приход на склад"
    /// </summary>
    public class CLot
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
        /// КЛП, из которого сформирован приход
        /// </summary>
        public CKLP ParentKLP { get; set; }
        /// <summary>
        /// Номер партии
        /// </summary>
        public System.String Number {get; set;}
        /// <summary>
        /// Номер накладной
        /// </summary>
        public System.String DocNumber { get; set; }
        /// <summary>
        /// Дата оформления 
        /// </summary>
        public System.DateTime Date {get; set;}
        /// <summary>
        /// Дата накладной
        /// </summary>
        public System.DateTime DocDate { get; set; }
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
                return (Vendor == null ? System.String.Empty : Vendor.Name);
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
                return (Currency == null ? System.String.Empty : Currency.CurrencyAbbr);
            }
        }
        /// <summary>
        /// Склад прихода
        /// </summary>
        public ERP_Mercury.Common.CStock Stock { get; set; }
        /// <summary>
        /// Склад прихода (наименование)
        /// </summary>
        public System.String StockName
        {
            get
            {
                return (Stock == null ? System.String.Empty : Stock.Name);
            }
        }
        /// <summary>
        /// Текущее состояние прихода
        /// </summary>
        public ERP_Mercury.Common.CLotState CurrentLotState {get; set;}
        /// <summary>
        /// Текущее состояние прихода (наименование)
        /// </summary>
        public System.String CurrentLotStateName
        { 
            get {
                    return ( CurrentLotState == null ? System.String.Empty : CurrentLotState.Name); 
                }
        }
        /// <summary>
        /// № состояния по порядку
        /// </summary>
        public System.Int32 LotStateOrderNum
        {
            get
            {
                return (CurrentLotState == null ? 0 : CurrentLotState.OrderNum);
            }
        }
        /// <summary>
        /// Примечание
        /// </summary>
        public System.String Description {get; set;}
        /// <summary>
        /// Признак "приход активен"
        /// </summary>
        public System.Boolean IsActive {get; set;}
        /// <summary>
        /// Себестоимость в валюте прихода
        /// </summary>
        public System.Double AllPrice {get; set;}
        /// <summary>
        /// Себестоимость в ОВУ
        /// </summary>
        public System.Double AllCostPrice {get; set;}
        /// <summary>
        /// Возврат по себестоимости в ОВУ
        /// </summary>
        public System.Double AllCostPriceReturn { get; set; }
        /// <summary>
        /// Приложение к заказу
        /// </summary>
        public List<CLotItem> LotItemList { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public System.Double Quantity { get; set; }
        /// <summary>
        /// Количество возврата по документу
        /// </summary>
        public System.Double QuantityReturn { get; set; }
        /// <summary>
        /// Количество с учётом возврата
        /// </summary>
        public System.Double QuantityWithoutReturn { get { return (Quantity - QuantityReturn); } }
        /// <summary>
        /// Себестоимость в ОВУ с учётом возврата
        /// </summary>
        public System.Double AllCostPriceWithoutReturn { get { return (AllCostPrice - AllCostPriceReturn); } }
        /// <summary>
        /// Курс пересчёта валюты прихода в ОВУ
        /// </summary>
        public System.Double RateCurrencyToCurrencyMain { get; set; }
        /// <summary>
        /// Дата накладной на ответхранение
        /// </summary>
        public System.DateTime StoreWaybillDate { get; set; }
        /// <summary>
        /// Номер накладной на ответхранение
        /// </summary>
        public System.String StoreWaybillDocNumber { get; set; }
        #endregion

        #region Конструктор
        public CLot()
        {
            ID = System.Guid.Empty;
            Ib_ID = 0;
            ParentKLP = null;
            Number = System.String.Empty;
            DocNumber = System.String.Empty;
            Date = System.DateTime.MinValue;
            DocDate = System.DateTime.MinValue;
            Currency = null;
            Vendor = null;
            Stock = null;
            CurrentLotState = null;
            Description = "";
            IsActive = false;
            AllPrice = 0;
            AllCostPrice = 0;
            AllCostPriceReturn = 0;
            Quantity = 0;
            QuantityReturn = 0;
            RateCurrencyToCurrencyMain = 0;
            LotItemList = null;
            StoreWaybillDocNumber = "";
            StoreWaybillDate = System.DateTime.MinValue;
        }
        #endregion

      }

    /// <summary>
    /// Класс "Строка в приложении к приходу"
    /// </summary>
    public class CLotItem
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
        /// Уникальный идентификатор в приложении к КЛП
        /// </summary>
        public System.Guid KLPItems_ID { get; set; }
        /// <summary>
        /// Товар
        /// </summary>
        public ERP_Mercury.Common.CProduct Product { get; set; }
        /// <summary>
        /// Единица измерения
        /// </summary>
        public ERP_Mercury.Common.CMeasure Measure { get; set; }
        /// <summary>
        /// количество
        /// </summary>
        public System.Double Quantity { get; set; }
        /// <summary>
        /// количество, включенное в КЛП
        /// </summary>
        public System.Double QuantityInKLP { get; set; }
        /// <summary>
        /// количество возврата
        /// </summary>
        public System.Double QuantityReturn { get; set; }
        /// <summary>
        /// количество с учётом возврата
        /// </summary>
        public System.Double QuantityWithoutReturn { get { return ( Quantity - QuantityReturn ); } }
        /// <summary>
        /// Себестоимость единицы товара в валюте прихода
        /// </summary>
        public System.Double Price { get; set; }
        /// <summary>
        /// Себестоимость единицы товара в ОВУ
        /// </summary>
        public System.Double CostPrice { get; set; }
        /// <summary>
        /// Себестоимость товара в валюте прихода
        /// </summary>
        public System.Double SumPrice { get { return (Price * Quantity); } }
        /// <summary>
        /// (тариф поставщика х количество подтверждённое поставщиком )
        /// </summary>
        public System.Double SumCostPrice { get { return (CostPrice * Quantity); } }
        /// <summary>
        /// Срок годности
        /// </summary>
        public System.DateTime ExpirationDate { get; set; }
        /// <summary>
        /// Страна производства
        /// </summary>
        public ERP_Mercury.Common.CCountry CountryProduction { get; set; }

        #endregion

        #region Конструктор
        public CLotItem()
        {
            ID = System.Guid.Empty;
            Ib_Id = 0;
            KLPItems_ID = System.Guid.Empty;
            Product = null;
            Measure = null;
            Quantity = 0;
            QuantityInKLP = 0;
            QuantityReturn = 0;
            Price = 0;
            CostPrice = 0;
            ExpirationDate = System.DateTime.MinValue;
            CountryProduction = null;
        }
        #endregion

        #region Преобразование приложения к приходу в таблицу
        /// <summary>
        /// Преобразует приложение к приходу в таблицу
        /// </summary>
        /// <param name="objLotItemList">приложение к заказу</param>
        /// <param name="uuidLotID">уи заказа</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>таблица</returns>
        public static System.Data.DataTable ConvertListToTable(List<CLotItem> objLotItemList, System.Guid uuidLotID, ref System.String strErr)
        {
            if (objLotItemList == null) { return null; }
            System.Data.DataTable addedItems = new System.Data.DataTable();

            try
            {
                addedItems.Columns.Add(new System.Data.DataColumn("LotItems_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotItems_Id", typeof(System.Data.SqlTypes.SqlInt32)));
                addedItems.Columns.Add(new System.Data.DataColumn("Lot_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("KLPItems_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("Parts_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("Measure_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotItems_Quantity", typeof(System.Data.SqlTypes.SqlDouble)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotItems_RetQuantity", typeof(System.Data.SqlTypes.SqlDouble)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotItems_Price", typeof(System.Data.SqlTypes.SqlMoney)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotItems_CurrencyPrice", typeof(System.Data.SqlTypes.SqlMoney)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotItems_ExpDate", typeof(System.Data.SqlTypes.SqlDateTime)));
                addedItems.Columns.Add(new System.Data.DataColumn("CountryProduction_Guid", typeof(System.Data.SqlTypes.SqlGuid)));

                System.Data.DataRow newRow = null;
                foreach (CLotItem objItem in objLotItemList)
                {
                    newRow = addedItems.NewRow();
                    newRow["LotItems_Guid"] = objItem.ID;
                    newRow["LotItems_Id"] = objItem.Ib_Id;
                    newRow["Lot_Guid"] = uuidLotID;
                    if (objItem.KLPItems_ID.CompareTo(System.Guid.Empty) != 0)
                    {
                        newRow["KLPItems_Guid"] = objItem.KLPItems_ID;
                    }
                    newRow["Parts_Guid"] = objItem.Product.ID;
                    newRow["Measure_Guid"] = objItem.Measure.ID;
                    newRow["LotItems_Quantity"] = objItem.Quantity;
                    newRow["LotItems_RetQuantity"] = objItem.QuantityReturn;
                    newRow["LotItems_Price"] = (System.Data.SqlTypes.SqlMoney)objItem.Price;
                    newRow["LotItems_CurrencyPrice"] = (System.Data.SqlTypes.SqlMoney)objItem.CostPrice;
                    newRow["CountryProduction_Guid"] = objItem.CountryProduction.ID;
                    if (objItem.ExpirationDate != System.DateTime.MinValue)
                    {
                        try
                        {
                            newRow["LotItems_ExpDate"] = (System.Data.SqlTypes.SqlDateTime)objItem.ExpirationDate;
                        }
                        catch
                        {
                            newRow["LotItems_ExpDate"] = System.DBNull.Value;
                        }

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
    public class CLotHistory
    {
        #region Свойства
        public struct LotHistoryRecord
        {
            public System.DateTime RecordDateTimeUpdate;
            public System.String RecordUserUpdate;
            public ERP_Mercury.Common.CLotState LotState;

            public LotHistoryRecord(System.DateTime dtRecordDateTimeUpdate, System.String strRecordUserUpdate,
                ERP_Mercury.Common.CLotState objLotState)
            {
                RecordDateTimeUpdate = dtRecordDateTimeUpdate;
                RecordUserUpdate = strRecordUserUpdate;
                LotState = objLotState;
            }
        }

        public List<LotHistoryRecord> LotHistoryRecordList { get; set; }

        #endregion

        #region Конструктор
        public CLotHistory()
        {
            LotHistoryRecordList = null;
        }
        #endregion

        #region Добавление записи в журнал
        public void AddLotHistoryRecord(System.DateTime dtRecordDateTimeUpdate, System.String strRecordUserUpdate,
                ERP_Mercury.Common.CLotState objLotState)
        {
            System.Int32 iRecordCount = 0;
            try
            {
                if (LotHistoryRecordList == null)
                {
                    LotHistoryRecordList = new List<LotHistoryRecord>();
                }

                iRecordCount = LotHistoryRecordList.Count;
                LotHistoryRecordList.Add(new LotHistoryRecord(dtRecordDateTimeUpdate, strRecordUserUpdate, objLotState));
            }
            catch
            {
                if ((LotHistoryRecordList != null) && (LotHistoryRecordList.Count != 0)
                    && (LotHistoryRecordList.Count > iRecordCount))
                {
                    LotHistoryRecordList.RemoveAt(LotHistoryRecordList.Count - 1);
                }
            }
            return;
        }
        #endregion
    }

    public class CLotRepository
    {
        #region Список приходов
        /// <summary>
        /// Возвращает список приходов
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="dtBeginDate">начало периода для поиска</param>
        /// <param name="dtEndDate">окончание периода для поиска</param>
        /// <returns>список приходов (объекты класса CLot)</returns>
        public static List<CLot> GetLotList(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.DateTime dtBeginDate, System.DateTime dtEndDate, ref System.String strErr)
        {
            List<CLot> objList = new List<CLot>();
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

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_GetLot]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
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
                        objList.Add(new CLot()
                        {
                            ID = (System.Guid)rs["Lot_Guid"],
                            Ib_ID = System.Convert.ToInt32(rs["Lot_Id"]),
                            ParentKLP = ( (rs["KLP_Guid"] == System.DBNull.Value) ? null : new CKLP() { ID = (System.Guid)rs["KLP_Guid"], Number = System.Convert.ToString(rs["KLP_Num"]), Date = System.Convert.ToDateTime(rs["KLP_Date"])} ),
                            Number = System.Convert.ToString(rs["Lot_Num"]),
                            DocNumber = System.Convert.ToString(rs["Lot_DocNum"]),
                            Description = ((rs["Lot_Description"] == System.DBNull.Value) ? "" : System.Convert.ToString(rs["Lot_Description"])),
                            Vendor = new ERP_Mercury.Common.CVendor()
                            {
                                ID = (System.Guid)rs["Vendor_Guid"],
                                Name = System.Convert.ToString(rs["Vendor_Name"]),
                                TypeVendor = new ERP_Mercury.Common.CVendorType() { ID = (System.Guid)rs["VendorType_Guid"], Name = System.Convert.ToString(rs["VendorType_Name"]) }
                            },
                            CurrentLotState = new ERP_Mercury.Common.CLotState()
                            {
                                ID = (System.Guid)rs["LotState_Guid"],
                                Name = System.Convert.ToString(rs["LotState_Name"]),
                                Description = ((rs["LotState_Description"] == System.DBNull.Value) ? System.String.Empty : System.Convert.ToString(rs["LotState_Description"])),
                                OrderNum = System.Convert.ToInt32(rs["LotState_OrderNum"]),
                                IsActive = System.Convert.ToBoolean(rs["LotState_IsActive"]),
                                IsRequire = System.Convert.ToBoolean(rs["LotState_IsRequire"]),
                                IsCanEditDocument = System.Convert.ToBoolean(rs["LotState_IsCanEditDocument"]) 
                            },
                            Date = System.Convert.ToDateTime(rs["Lot_Date"]),
                            DocDate = System.Convert.ToDateTime(rs["Lot_DocDate"]),
                            Currency = new ERP_Mercury.Common.CCurrency()
                            {
                                ID = (System.Guid)rs["Currency_Guid"],
                                CurrencyAbbr = System.Convert.ToString(rs["Currency_Abbr"])
                            },
                            Stock = new ERP_Mercury.Common.CStock()
                            {
                                ID = (System.Guid)rs["Stock_Guid"], IBId = System.Convert.ToInt32(rs["Stock_Id"]), Name = System.Convert.ToString(rs["Stock_Name"]), 
                                WareHouse = new ERP_Mercury.Common.CWarehouse() { ID = (System.Guid)rs["Warehouse_Guid"],  WarehouseType = new ERP_Mercury.Common.CWareHouseType() {  ID = (System.Guid)rs["WarehouseType_Guid"], Name = System.Convert.ToString(rs["WareHouseType_Name"]) }}, 
                                Company = new ERP_Mercury.Common.CCompany() { ID = (System.Guid)rs["Company_Guid"], Name = System.Convert.ToString(rs["Company_Name"]), Abbr = System.Convert.ToString(rs["Company_Acronym"])}
                            },
                            RateCurrencyToCurrencyMain = System.Convert.ToDouble(rs["Lot_CurrencyRate"]), 
                            AllCostPrice  = System.Convert.ToDouble(rs["Lot_CurrencyAllPrice"]), 
                            AllPrice  = System.Convert.ToDouble(rs["Lot_AllPrice"]), 
                            AllCostPriceReturn  = System.Convert.ToDouble(rs["Lot_RetCurrencyAllPrice"]),  
                            IsActive = System.Convert.ToBoolean(rs["Lot_IsActive"]), 
                            Quantity = System.Convert.ToDouble(rs["Quantity"]), 
                            QuantityReturn = System.Convert.ToDouble(rs["RetQuantity"])
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
                strErr = "Не удалось получить список приходов. Текст ошибки: " + f.Message;
            }
            return objList;
        }
        /// <summary>
        /// Возвращает список приходов для КЛП
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="KLP_Guid">УИ КЛП</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>список приходов</returns>
        public static List<CLot> GetLotList(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid KLP_Guid, ref System.String strErr)
        {
            List<CLot> objList = new List<CLot>();
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

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_GetLot]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters["@KLP_Guid"].Value = KLP_Guid;
                System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        objList.Add(new CLot()
                        {
                            ID = (System.Guid)rs["Lot_Guid"],
                            Ib_ID = System.Convert.ToInt32(rs["Lot_Id"]),
                            ParentKLP = ((rs["KLP_Guid"] == System.DBNull.Value) ? null : new CKLP() { ID = (System.Guid)rs["KLP_Guid"], Number = System.Convert.ToString(rs["KLP_Num"]), Date = System.Convert.ToDateTime(rs["KLP_Date"]) }),
                            Number = System.Convert.ToString(rs["Lot_Num"]),
                            DocNumber = System.Convert.ToString(rs["Lot_DocNum"]),
                            Description = ((rs["Lot_Description"] == System.DBNull.Value) ? "" : System.Convert.ToString(rs["Lot_Description"])),
                            Vendor = new ERP_Mercury.Common.CVendor()
                            {
                                ID = (System.Guid)rs["Vendor_Guid"],
                                Name = System.Convert.ToString(rs["Vendor_Name"]),
                                TypeVendor = new ERP_Mercury.Common.CVendorType() { ID = (System.Guid)rs["VendorType_Guid"], Name = System.Convert.ToString(rs["VendorType_Name"]) }
                            },
                            CurrentLotState = new ERP_Mercury.Common.CLotState()
                            {
                                ID = (System.Guid)rs["LotState_Guid"],
                                Name = System.Convert.ToString(rs["LotState_Name"]),
                                Description = ((rs["LotState_Description"] == System.DBNull.Value) ? System.String.Empty : System.Convert.ToString(rs["LotState_Description"])),
                                OrderNum = System.Convert.ToInt32(rs["LotState_OrderNum"]),
                                IsActive = System.Convert.ToBoolean(rs["LotState_IsActive"]),
                                IsRequire = System.Convert.ToBoolean(rs["LotState_IsRequire"]),
                                IsCanEditDocument = System.Convert.ToBoolean(rs["LotState_IsCanEditDocument"])
                            },
                            Date = System.Convert.ToDateTime(rs["Lot_Date"]),
                            DocDate = System.Convert.ToDateTime(rs["Lot_DocDate"]),
                            Currency = new ERP_Mercury.Common.CCurrency()
                            {
                                ID = (System.Guid)rs["Currency_Guid"],
                                CurrencyAbbr = System.Convert.ToString(rs["Currency_Abbr"])
                            },
                            Stock = new ERP_Mercury.Common.CStock()
                            {
                                ID = (System.Guid)rs["Stock_Guid"],
                                IBId = System.Convert.ToInt32(rs["Stock_Id"]),
                                Name = System.Convert.ToString(rs["Stock_Name"]),
                                WareHouse = new ERP_Mercury.Common.CWarehouse() { ID = (System.Guid)rs["Warehouse_Guid"], WarehouseType = new ERP_Mercury.Common.CWareHouseType() { ID = (System.Guid)rs["WarehouseType_Guid"], Name = System.Convert.ToString(rs["WareHouseType_Name"]) } },
                                Company = new ERP_Mercury.Common.CCompany() { ID = (System.Guid)rs["Company_Guid"], Name = System.Convert.ToString(rs["Company_Name"]), Abbr = System.Convert.ToString(rs["Company_Acronym"]) }
                            },
                            RateCurrencyToCurrencyMain = System.Convert.ToDouble(rs["Lot_CurrencyRate"]),
                            AllCostPrice = System.Convert.ToDouble(rs["Lot_CurrencyAllPrice"]),
                            AllPrice = System.Convert.ToDouble(rs["Lot_AllPrice"]),
                            AllCostPriceReturn = System.Convert.ToDouble(rs["Lot_RetCurrencyAllPrice"]),
                            IsActive = System.Convert.ToBoolean(rs["Lot_IsActive"]),
                            Quantity = System.Convert.ToDouble(rs["Quantity"]),
                            QuantityReturn = System.Convert.ToDouble(rs["RetQuantity"]),
                            StoreWaybillDocNumber = ((rs["StoreWaybill_DocNum"] == System.DBNull.Value) ? "" : System.Convert.ToString(rs["StoreWaybill_DocNum"])),
                            StoreWaybillDate = ((rs["StoreWaybill_DocDate"] == System.DBNull.Value) ? System.DateTime.MinValue : System.Convert.ToDateTime(rs["StoreWaybill_DocDate"]))
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
                strErr = "Не удалось получить список приходов. Текст ошибки: " + f.Message;
            }
            return objList;
        }
        #endregion

        #region Приложение к приходу
        /// <summary>
        /// Возвращает приложение к приходу
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="uuidLotOrderId">уи прихода</param>
        /// <returns>список объектов класса CLotItem</returns>
        public static List<CLotItem> GetLotItemList(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid uuidLotId, ref System.Int32 iRes, ref System.String strErr)
        {
            List<CLotItem> objList = new List<CLotItem>();
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

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_GetLotItems]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                if (uuidLotId.CompareTo(System.Guid.Empty) != 0)
                {
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_Guid", System.Data.SqlDbType.UniqueIdentifier));
                    cmd.Parameters["@Lot_Guid"].Value = uuidLotId;
                }
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();
                iRes = System.Convert.ToInt32(cmd.Parameters["@ERROR_NUM"].Value);
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        objList.Add(new CLotItem()
                        {
                            ID = (System.Guid)rs["LotItems_Guid"],
                            Ib_Id = System.Convert.ToInt32(rs["LotItems_Id"]),
                            KLPItems_ID = ((rs["KLPItems_Guid"] == System.DBNull.Value) ? System.Guid.Empty : (System.Guid)(rs["KLPItems_Guid"])),
                            Product = new ERP_Mercury.Common.CProduct() { ID = (System.Guid)rs["Parts_Guid"], Name = System.Convert.ToString(rs["Parts_Name"]), Article = System.Convert.ToString(rs["Parts_Article"]), ID_Ib = System.Convert.ToInt32(rs["Parts_Id"]) },
                            Measure = new ERP_Mercury.Common.CMeasure() { ID = (System.Guid)rs["Measure_Guid"], Name = System.Convert.ToString(rs["Measure_Name"]), ShortName = System.Convert.ToString(rs["Measure_ShortName"]) },
                            Quantity = System.Convert.ToDouble(rs["LotItems_Quantity"]),
                            QuantityReturn = System.Convert.ToDouble(rs["LotItems_RetQuantity"]),
                            Price = System.Convert.ToDouble(rs["LotItems_Price"]),
                            CostPrice = System.Convert.ToDouble(rs["LotItems_CurrencyPrice"]), 
                            ExpirationDate = ((rs["LotItems_ExpDate"] == System.DBNull.Value) ? System.DateTime.MinValue : System.Convert.ToDateTime(rs["LotItems_ExpDate"])),
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
                strErr = "Не удалось получить приложение к приходу. Текст ошибки: " + f.Message;
            }
            return objList;
        }
        #endregion

        #region Добавление в БД информации о приходе
        /// <summary>
        /// Проверяет заполнение свойств прихода перед сохранением в БД
        /// </summary>
        /// <param name="Lot_Date">дата прихода</param>
        /// <param name="Vendor_Guid">уи поставщика</param>
        /// <param name="Currency_Guid">уи валюты прихода</param>
        /// <param name="LotState_Guid">уи состояния прихода</param>
        /// <param name="Stock_Guid">уи состояния прихода</param>
        /// <param name="addedCategories">приложение к приходу</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - все обязательные поля заполнены; false - не все обязазательные поля заполнены</returns>
        public static System.Boolean CheckAllPropertiesForSave(System.DateTime Lot_Date, System.Guid Vendor_Guid,
            System.Guid Currency_Guid, System.Guid LotState_Guid, System.Guid Stock_Guid, System.Data.DataTable addedCategories, 
            ref System.String strErr)
        {
            System.Boolean bRet = false;
            try
            {
                if( (Lot_Date.Equals( System.DateTime.MinValue ) == true) ||
                    (Lot_Date.Equals( System.DateTime.MaxValue ) == true) )
                {
                    strErr = "Укажите, пожалуйста, дату прихода.";
                    return bRet;
                }
                if (Vendor_Guid == System.Guid.Empty)
                {
                    strErr = "Укажите, пожалуйста, поставщика.";
                    return bRet;
                }
                if (Currency_Guid == System.Guid.Empty)
                {
                    strErr = "Укажите, пожалуйста, валюту прихода.";
                    return bRet;
                }
                if (LotState_Guid == System.Guid.Empty)
                {
                    strErr = "Укажите, пожалуйста, состояние прихода.";
                    return bRet;
                }
                if (Stock_Guid == System.Guid.Empty)
                {
                    strErr = "Укажите, пожалуйста, склад прихода.";
                    return bRet;
                }
                if ((addedCategories == null) || (addedCategories.Rows.Count == 0))
                {
                    strErr = "Приложение к приходу не содержит записей. Добавьте, пожалуйста, хотя бы одну позицию.";
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
        /// Добавляет в БД информацию о приходе
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="KLP_Guid">уи КЛП</param>
        /// <param name="Lot_Num">номер прихода</param>
        /// <param name="Lot_DocNum">номер приходной накладной</param>
        /// <param name="Lot_Date">дата прихода</param>
        /// <param name="Vendor_Guid">уи поставщика</param>
        /// <param name="Currency_Guid">уи валюты</param>
        /// <param name="Stock_Guid">уи склада прихода</param>
        /// <param name="Lot_Description">примечание</param>
        /// <param name="Lot_IsActive">признак "активен"</param>
        /// <param name="LotState_Guid">уи состояния прихода</param>
        /// <param name="Lot_CurrencyRate">курс пересчёта валюты прихода в ОВУ</param>
        /// <param name="StoreWaybill_DocDate">дата накладной на ответхранение</param>
        /// <param name="StoreWaybill_DocNum">номер накладной на ответхранение</param>
        /// <param name="addedItems">приложение к приходу</param>
        /// <param name="Lot_Guid">уи прихода</param>
        /// <param name="Lot_Id">уи прихода (Interbase)</param>
        /// <param name="Lot_AllPrice">себестоимость в валюте прихода</param>
        /// <param name="Lot_CurrencyAllPrice">себестоимость в ОВУ</param>
        /// <param name="Lot_RetCurrencyAllPrice">сумма возврата по себестоимости в ОВУ</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        public static System.Boolean AddLot(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid KLP_Guid, System.String Lot_Num, System.String Lot_DocNum, System.DateTime Lot_Date,
            System.Guid Vendor_Guid, System.Guid Currency_Guid, System.Guid Stock_Guid, 
            System.String Lot_Description, System.Boolean Lot_IsActive,
            System.Guid LotState_Guid, System.Double Lot_CurrencyRate, System.Data.DataTable addedItems,
            System.DateTime StoreWaybill_DocDate, System.String StoreWaybill_DocNum,
            ref System.Guid Lot_Guid, ref System.Int32 Lot_Id, ref System.Double Lot_AllPrice, ref System.Double Lot_CurrencyAllPrice,
            ref System.Double Lot_RetCurrencyAllPrice, ref System.String strErr)
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
                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_AddLot]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.AddWithValue("@tLotItems", addedItems);
                cmd.Parameters["@tLotItems"].SqlDbType = System.Data.SqlDbType.Structured;
                cmd.Parameters["@tLotItems"].TypeName = "dbo.udt_LotItems";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_Num", System.Data.SqlDbType.NVarChar, 56));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_DocNum", System.Data.SqlDbType.NVarChar, 56));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_Date", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_DocDate", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Vendor_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Stock_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Currency_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotState_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_Description", System.Data.SqlDbType.NVarChar, 512));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_IsActive", System.Data.SqlDbType.Bit));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_CurrencyRate", System.Data.SqlDbType.Money));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StoreWaybill_DocNum", System.Data.SqlDbType.NVarChar, 56));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StoreWaybill_DocDate", System.Data.SqlDbType.DateTime));

                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters["@Lot_Guid"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_Id", System.Data.SqlDbType.Int));
                cmd.Parameters["@Lot_Id"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_AllPrice", System.Data.SqlDbType.Money));
                cmd.Parameters["@Lot_AllPrice"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_CurrencyAllPrice", System.Data.SqlDbType.Money));
                cmd.Parameters["@Lot_CurrencyAllPrice"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_RetCurrencyAllPrice", System.Data.SqlDbType.Money));
                cmd.Parameters["@Lot_RetCurrencyAllPrice"].Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters["@Lot_Num"].Value = Lot_Num;
                cmd.Parameters["@Lot_DocNum"].Value = Lot_DocNum;
                cmd.Parameters["@Lot_Date"].Value = Lot_Date;
                cmd.Parameters["@Lot_DocDate"].Value = Lot_Date;

                if (KLP_Guid.CompareTo( System.Guid.Empty ) == 0)
                {
                    cmd.Parameters["@KLP_Guid"].IsNullable = true;
                    cmd.Parameters["@KLP_Guid"].Value = null;
                }
                else
                {
                    cmd.Parameters["@KLP_Guid"].Value = KLP_Guid;
                }
                if (StoreWaybill_DocDate.CompareTo(System.DateTime.MinValue) == 0)
                {
                    cmd.Parameters["@StoreWaybill_DocDate"].IsNullable = true;
                    cmd.Parameters["@StoreWaybill_DocDate"].Value = null;
                }
                else
                {
                    cmd.Parameters["@StoreWaybill_DocDate"].Value = StoreWaybill_DocDate;
                }
                if (StoreWaybill_DocNum.Trim() == "")
                {
                    cmd.Parameters["@StoreWaybill_DocNum"].IsNullable = true;
                    cmd.Parameters["@StoreWaybill_DocNum"].Value = null;
                }
                else
                {
                    cmd.Parameters["@StoreWaybill_DocNum"].Value = StoreWaybill_DocNum;
                }
                cmd.Parameters["@Vendor_Guid"].Value = Vendor_Guid;
                cmd.Parameters["@Currency_Guid"].Value = Currency_Guid;
                cmd.Parameters["@Stock_Guid"].Value = Stock_Guid;
                cmd.Parameters["@LotState_Guid"].Value = LotState_Guid;
                if (Lot_Description.Equals(System.String.Empty) == true)
                {
                    cmd.Parameters["@Lot_Description"].IsNullable = true;
                    cmd.Parameters["@Lot_Description"].Value = null;
                }
                else
                {
                    cmd.Parameters["@Lot_Description"].Value = Lot_Description;
                }
                cmd.Parameters["@Lot_IsActive"].Value = Lot_IsActive;
                cmd.Parameters["@Lot_CurrencyRate"].Value = Lot_CurrencyRate;

                cmd.ExecuteNonQuery();
                System.Int32 iRes = (System.Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                if (iRes == 0)
                {
                    Lot_Guid = (System.Guid)cmd.Parameters["@Lot_Guid"].Value;
                    Lot_Id = System.Convert.ToInt32(cmd.Parameters["@Lot_Id"].Value);
                    Lot_AllPrice = System.Convert.ToDouble(cmd.Parameters["@Lot_AllPrice"].Value);
                    Lot_CurrencyAllPrice = System.Convert.ToDouble(cmd.Parameters["@Lot_CurrencyAllPrice"].Value);
                    Lot_RetCurrencyAllPrice = System.Convert.ToDouble(cmd.Parameters["@Lot_RetCurrencyAllPrice"].Value);
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

        #region Редактирование в БД информации о приходе
        /// <summary>
        /// Вносит изменения в БД о приходе
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="KLP_Guid">уи КЛП</param>
        /// <param name="Lot_Num">номер прихода</param>
        /// <param name="Lot_DocNum">номер приходной накладной</param>
        /// <param name="Lot_Date">дата прихода</param>
        /// <param name="Vendor_Guid">уи поставщика</param>
        /// <param name="Currency_Guid">уи валюты</param>
        /// <param name="Stock_Guid">уи склада прихода</param>
        /// <param name="Lot_Description">примечание</param>
        /// <param name="Lot_IsActive">признак "активен"</param>
        /// <param name="LotState_Guid">уи состояния прихода</param>
        /// <param name="Lot_CurrencyRate">курс пересчёта валюты прихода в ОВУ</param>
        /// <param name="StoreWaybill_DocDate">дата накладной на ответхранение</param>
        /// <param name="StoreWaybill_DocNum">номер накладной на ответхранение</param>
        /// <param name="addedItems">приложение к приходу</param>
        /// <param name="Lot_Guid">уи прихода</param>
        /// <param name="Lot_AllPrice">себестоимость в валюте прихода</param>
        /// <param name="Lot_CurrencyAllPrice">себестоимость в ОВУ</param>
        /// <param name="Lot_RetCurrencyAllPrice">сумма возврата по себестоимости в ОВУ</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        public static System.Boolean EditLot(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid KLP_Guid, System.String Lot_Num, System.String Lot_DocNum, System.DateTime Lot_Date,
            System.Guid Vendor_Guid, System.Guid Currency_Guid, System.Guid Stock_Guid,
            System.String Lot_Description, System.Boolean Lot_IsActive,
            System.Guid LotState_Guid, System.Double Lot_CurrencyRate, System.Data.DataTable addedItems,
            System.DateTime StoreWaybill_DocDate, System.String StoreWaybill_DocNum,
            System.Guid Lot_Guid, ref System.Double Lot_AllPrice, ref System.Double Lot_CurrencyAllPrice,
            ref System.Double Lot_RetCurrencyAllPrice, ref System.String strErr)
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
                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_EditLot]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.AddWithValue("@tLotItems", addedItems);
                cmd.Parameters["@tLotItems"].SqlDbType = System.Data.SqlDbType.Structured;
                cmd.Parameters["@tLotItems"].TypeName = "dbo.udt_LotItems";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_Num", System.Data.SqlDbType.NVarChar, 56));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_DocNum", System.Data.SqlDbType.NVarChar, 56));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_Date", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_DocDate", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StoreWaybill_DocNum", System.Data.SqlDbType.NVarChar, 56));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StoreWaybill_DocDate", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Vendor_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Stock_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Currency_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotState_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_Description", System.Data.SqlDbType.NVarChar, 512));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_IsActive", System.Data.SqlDbType.Bit));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_CurrencyRate", System.Data.SqlDbType.Money));

                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_AllPrice", System.Data.SqlDbType.Money));
                cmd.Parameters["@Lot_AllPrice"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_CurrencyAllPrice", System.Data.SqlDbType.Money));
                cmd.Parameters["@Lot_CurrencyAllPrice"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_RetCurrencyAllPrice", System.Data.SqlDbType.Money));
                cmd.Parameters["@Lot_RetCurrencyAllPrice"].Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters["@Lot_Guid"].Value = Lot_Guid;
                cmd.Parameters["@Lot_Num"].Value = Lot_Num;
                cmd.Parameters["@Lot_DocNum"].Value = Lot_DocNum;
                cmd.Parameters["@Lot_Date"].Value = Lot_Date;
                cmd.Parameters["@Lot_DocDate"].Value = Lot_Date;

                if (KLP_Guid.CompareTo(System.Guid.Empty) == 0)
                {
                    cmd.Parameters["@KLP_Guid"].IsNullable = true;
                    cmd.Parameters["@KLP_Guid"].Value = null;
                }
                else
                {
                    cmd.Parameters["@KLP_Guid"].Value = KLP_Guid;
                }
                if (StoreWaybill_DocDate.CompareTo(System.DateTime.MinValue) == 0)
                {
                    cmd.Parameters["@StoreWaybill_DocDate"].IsNullable = true;
                    cmd.Parameters["@StoreWaybill_DocDate"].Value = null;
                }
                else
                {
                    cmd.Parameters["@StoreWaybill_DocDate"].Value = StoreWaybill_DocDate;
                }
                if (StoreWaybill_DocNum.Trim() == "")
                {
                    cmd.Parameters["@StoreWaybill_DocNum"].IsNullable = true;
                    cmd.Parameters["@StoreWaybill_DocNum"].Value = null;
                }
                else
                {
                    cmd.Parameters["@StoreWaybill_DocNum"].Value = StoreWaybill_DocNum;
                }
                cmd.Parameters["@Vendor_Guid"].Value = Vendor_Guid;
                cmd.Parameters["@Currency_Guid"].Value = Currency_Guid;
                cmd.Parameters["@Stock_Guid"].Value = Stock_Guid;
                cmd.Parameters["@LotState_Guid"].Value = LotState_Guid;
                if (Lot_Description.Equals(System.String.Empty) == true)
                {
                    cmd.Parameters["@Lot_Description"].IsNullable = true;
                    cmd.Parameters["@Lot_Description"].Value = null;
                }
                else
                {
                    cmd.Parameters["@Lot_Description"].Value = Lot_Description;
                }
                cmd.Parameters["@Lot_IsActive"].Value = Lot_IsActive;
                cmd.Parameters["@Lot_CurrencyRate"].Value = Lot_CurrencyRate;

                cmd.ExecuteNonQuery();
                System.Int32 iRes = (System.Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                if (iRes == 0)
                {
                    Lot_AllPrice = System.Convert.ToDouble(cmd.Parameters["@Lot_AllPrice"].Value);
                    Lot_CurrencyAllPrice = System.Convert.ToDouble(cmd.Parameters["@Lot_CurrencyAllPrice"].Value);
                    Lot_RetCurrencyAllPrice = System.Convert.ToDouble(cmd.Parameters["@Lot_RetCurrencyAllPrice"].Value);
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

        #region Удаление прихода из БД
        /// <summary>
        /// Удаляет из БД информацию о приходе
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="Lot_Guid">уи прихода</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        public static System.Boolean DeleteLot(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid Lot_Guid, ref System.String strErr)
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
                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_DeleteLot]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters["@Lot_Guid"].Value = Lot_Guid;

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

        #region Журнал состояний прихода
        /// <summary>
        /// Возвращает журнал состояний прихода
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="uuidLotId">уи прихода</param>
        /// <param name="iRes">результат выполнения хранимой процедуры</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>объект класса CLotOrderHistory</returns>
        public static CLotHistory GetLotHistory(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid uuidLotId, ref System.Int32 iRes, ref System.String strErr)
        {
            CLotHistory objList = new CLotHistory();
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

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_GetLotStateHistory]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                if (uuidLotId.CompareTo(System.Guid.Empty) != 0)
                {
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_Guid", System.Data.SqlDbType.UniqueIdentifier));
                    cmd.Parameters["@Lot_Guid"].Value = uuidLotId;
                }
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();
                iRes = System.Convert.ToInt32(cmd.Parameters["@ERROR_NUM"].Value);
                if (rs.HasRows)
                {
                    objList.LotHistoryRecordList = new List<CLotHistory.LotHistoryRecord>();
                    while (rs.Read())
                    {
                        objList.AddLotHistoryRecord(System.Convert.ToDateTime(rs["Record_Updated"]),
                            System.Convert.ToString(rs["Record_UserUdpated"]),
                            new ERP_Mercury.Common.CLotState()
                            {
                                ID = (System.Guid)rs["LotState_Guid"],
                                Name = System.Convert.ToString(rs["LotState_Name"]),
                                OrderNum = System.Convert.ToInt32(rs["LotState_OrderNum"])
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
                strErr = "Не удалось получить журнал состояний прихода. Текст ошибки: " + f.Message;
            }
            return objList;
        }

        #endregion

        #region Выпадающий список для заполнения приложения к приходу на основании КЛП
        /// <summary>
        /// Возвращает приложение к КЛП, не включённое в приходный документ
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="uuidKLPId">уи КЛП</param>
        /// <returns>список объектов класса CLotItem</returns>
        public static List<CLotItem> GetSrcForKlpItems(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid uuidKLPId, ref System.Int32 iRes, ref System.String strErr)
        {
            List<CLotItem> objList = new List<CLotItem>();
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

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_GetSrcForLotItems]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters["@KLP_Guid"].Value = uuidKLPId;
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();
                iRes = System.Convert.ToInt32(cmd.Parameters["@ERROR_NUM"].Value);
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        if ((System.Convert.ToDouble(rs["LotOrderItems_Quantity"]) - System.Convert.ToDouble(rs["LotOrderItemsQuantityInKLP"])) > 0)
                        {

                            objList.Add(new CLotItem()
                            {
                                ID = (System.Guid)rs["LotItems_Guid"],
                                Ib_Id = System.Convert.ToInt32(rs["LotItems_Id"]),
                                KLPItems_ID = ((rs["KLPItems_Guid"] == System.DBNull.Value) ? System.Guid.Empty : (System.Guid)(rs["KLPItems_Guid"])),
                                Product = new ERP_Mercury.Common.CProduct() { ID = (System.Guid)rs["Parts_Guid"], Name = System.Convert.ToString(rs["Parts_Name"]), Article = System.Convert.ToString(rs["Parts_Article"]), ID_Ib = System.Convert.ToInt32(rs["Parts_Id"]) },
                                Measure = new ERP_Mercury.Common.CMeasure() { ID = (System.Guid)rs["Measure_Guid"], Name = System.Convert.ToString(rs["Measure_Name"]), ShortName = System.Convert.ToString(rs["Measure_ShortName"]) },
                                Quantity = System.Convert.ToDouble(rs["KLPItems_FactQuantity"]),
                                QuantityReturn = 0,
                                Price = System.Convert.ToDouble(rs["KLPItems_CurrencyPrice"]),
                                CostPrice = System.Convert.ToDouble(rs["KLPItems_CurrencyPrice"]),
                                CountryProduction = new ERP_Mercury.Common.CCountry() { ID = (System.Guid)rs["CountryProduction_Guid"], Name = System.Convert.ToString(rs["Country_Name"]) }
                            });
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
                strErr = "Не удалось получить список позиций для формирования прихода. Текст ошибки: " + f.Message;
            }
            return objList;
        }

        #endregion

        #region Смена состояния прихода

        /// <summary>
        /// Вносит изменения в состояние прихода в БД
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="uuidLotId">уи прихода</param>
        /// <param name="uuidLotStateId">уи состояния прихода</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <param name="iLot_Id">уи прихода в InterBase</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        public static System.Boolean ChangeLotState(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid Lot_Guid, System.Guid LotState_Guid, ref System.String strErr, ref System.Int32 Lot_Id)
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

                cmd.CommandTimeout = 600;
                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_ChangeLotState]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotState_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Lot_Id", System.Data.SqlDbType.Int));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters["@Lot_Id"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters["@Lot_Guid"].Value = Lot_Guid;
                cmd.Parameters["@LotState_Guid"].Value = LotState_Guid;
                System.Int32 iRes = cmd.ExecuteNonQuery();

                iRes = System.Convert.ToInt32(cmd.Parameters["@ERROR_NUM"].Value);
                strErr = System.Convert.ToString(cmd.Parameters["@ERROR_MES"].Value);

                if (iRes == 0)
                {
                    Lot_Id = System.Convert.ToInt32(cmd.Parameters["@Lot_Id"].Value);
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
                strErr = "Не удалось внести изменения в состояние прихода. Текст ошибки: " + f.Message;
            }
            return bRes;
        }
        #endregion

    }

}
