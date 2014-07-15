using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPMercuryLotOrder
{
    public class CKLP
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
        /// Номер 
        /// </summary>
        public System.String Number { get; set; }
        /// <summary>
        /// Дата оформления КЛП
        /// </summary>
        public System.DateTime Date { get; set; }
        /// <summary>
        /// Дата и время начала приёмки
        /// </summary>
        public System.DateTime DateTimeStartAccepting { get; set; }
        /// <summary>
        /// Дата и время начала приёмки
        /// </summary>
        public System.DateTime DateTimeEndAccepting { get; set; }
        /// <summary>
        /// Склад приёмки товара
        /// </summary>
        public ERP_Mercury.Common.CStock StockAccepting { get; set; }
        /// <summary>
        /// Склад приёмки товара
        /// </summary>
        public System.String StockAcceptingName 
        {
            get
            {
                return (StockAccepting == null ? "" : StockAccepting.Name);
            }
        }
        /// <summary>
        /// Поставщик
        /// </summary>
        public ERP_Mercury.Common.CVendor Vendor { get; set; }
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
        public ERP_Mercury.Common.CCurrency Currency { get; set; }
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
        /// Текущее состояние КЛП
        /// </summary>
        public ERP_Mercury.Common.CKLPState CurrentKLPState { get; set; }
        /// <summary>
        /// Текущее состояние КЛП (наименование)
        /// </summary>
        public System.String CurrentKLPStateName
        {
            get
            {
                return (CurrentKLPState == null ? "" : CurrentKLPState.Name);
            }
        }
        /// <summary>
        /// Примечание
        /// </summary>
        public System.String Description { get; set; }
        /// <summary>
        /// Признак "КЛП активен"
        /// </summary>
        public System.Boolean IsActive { get; set; }
        /// <summary>
        /// Признак "Себестоимость рассчитана"
        /// </summary>
        public System.Boolean IsCostCalc { get; set; }
        /// <summary>
        /// Признак "Себестоимость рассчитана"
        /// </summary>
        public System.String strIsCostCalc
        {
            get
            {
                return( IsCostCalc == true ? "рассчитана" : "" );
            }
        }
        /// <summary>
        /// Сумма (фактическое количество * цена в ОВУ для расчёта С/С)
        /// </summary>
        public System.Double SumFactByPriceForCalcCostPrice { get; set; }
        /// <summary>
        /// Сумма (фактическое количество * цена в валюте расчёта с поставщиком для расчёта С/С)
        /// </summary>
        public System.Double SumFactByPriceForCalcCostPriceInVendorCurrency { get; set; }
        /// <summary>
        /// Сумма (количество* цена в ОВУ для расчёта С/С)
        /// </summary>
        public System.Double SumByPriceForCalcCostPrice { get; set; }
        /// <summary>
        /// Количество в инвойсе
        /// </summary>
        public System.Double QuantityInDoc { get; set; }
        /// <summary>
        /// Количество фактическое
        /// </summary>
        public System.Double QuantityFact { get; set; }
        /// <summary>
        /// Приложение к КЛП
        /// </summary>
        public List<CKLPItems> KLPItemsList { get; set; }

        #endregion

        #region  Конструктор
        public CKLP()
        {
            ID = System.Guid.Empty;
            Ib_ID = 0;
            Currency = null;
            Vendor = null;
            StockAccepting = null;
            Number = "";
            Date = System.DateTime.MinValue;
            DateTimeStartAccepting = System.DateTime.MinValue;
            DateTimeEndAccepting = System.DateTime.MinValue;
            CurrentKLPState = null;
            Description = "";
            IsActive = false;
            SumByPriceForCalcCostPrice = 0;
            SumFactByPriceForCalcCostPrice = 0;
            SumFactByPriceForCalcCostPriceInVendorCurrency = 0;
            QuantityInDoc = 0;
            QuantityFact = 0;
            KLPItemsList = null;
            IsCostCalc = false;
        }
        #endregion
    }

    public class CKLPItems
    {
        #region Свойства
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public System.Guid ID { get; set; }
        /// <summary>
        /// Уникальный идентификатор строки приложения к заказу
        /// </summary>
        public System.Guid ParentLotOrderItemsID { get; set; }
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
        /// количество подтверждённое складом
        /// </summary>
        public System.Double QuantityFact { get; set; }
        /// <summary>
        /// количество в документе от поставщика
        /// </summary>
        public System.Double Quantity { get; set; }
        /// <summary>
        /// Цена в ОВУ для расчёта себестоимости
        /// </summary>
        public System.Double PriceForCalcCostPrice { get; set; }
        /// <summary>
        /// Цена для расчёта себестоимости в валюте поставщика
        /// </summary>
        public System.Double PriceForCalcCostPriceInVendorCurrency { get; set; }
        /// <summary>
        /// (Цена для расчёта себестоимости в валюте поставщика х фактическое количество )
        /// </summary>
        public System.Double SumFactPriceForCalcCostPriceInVendorCurrency { get { return (PriceForCalcCostPriceInVendorCurrency * QuantityFact); } }
        /// <summary>
        /// (Цена в ОВУ для расчёта себестоимости х фактическое количество )
        /// </summary>
        public System.Double SumFactPriceForCalcCostPrice { get { return (PriceForCalcCostPrice * QuantityFact); } }
        /// <summary>
        /// (Цена в ОВУ для расчёта себестоимости х количество в документах от поставщика )
        /// </summary>
        public System.Double SumPriceForCalcCostPrice { get { return (PriceForCalcCostPrice * Quantity); } }
        /// <summary>
        /// Таможенный тариф
        /// </summary>
        public System.Double CustomTarifPercent { get; set; }
        /// <summary>
        /// Страна производства
        /// </summary>
        public ERP_Mercury.Common.CCountry CountryProduction { get; set; }
        /// <summary>
        /// Срок годности
        /// </summary>
        public System.DateTime ExpirationDate { get; set; }
        #endregion

        #region Конструктор
        public CKLPItems()
        {
            ID = System.Guid.Empty;
            ParentLotOrderItemsID = System.Guid.Empty;
            Ib_Id = 0;
            Product = null;
            Measure = null;
            Quantity = 0;
            QuantityFact = 0;
            PriceForCalcCostPrice = 0;
            PriceForCalcCostPriceInVendorCurrency = 0;
            CustomTarifPercent = 0;
            CountryProduction = null;
            ExpirationDate = System.DateTime.MinValue;
        }
        #endregion

        #region Преобразование приложения к КЛП в таблицу
        /// <summary>
        /// Преобразует приложение к КЛП в таблицу
        /// </summary>
        /// <param name="objKLPItemslist">приложение к КЛП</param>
        /// <param name="uuidKLPID">уи КЛП</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>таблица</returns>
        public static System.Data.DataTable ConvertListToTable(List<CKLPItems> objKLPItemslist, System.Guid uuidKLPID, ref System.String strErr)
        {
            if (objKLPItemslist == null) { return null; }
            System.Data.DataTable addedItems = new System.Data.DataTable();

            try
            {
                addedItems.Columns.Add(new System.Data.DataColumn("KLPItems_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("KLP_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("Parts_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("Measure_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("LotOrderItems_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("KLPItems_Quantity", typeof(System.Data.SqlTypes.SqlDouble)));
                addedItems.Columns.Add(new System.Data.DataColumn("KLPItems_FactQuantity", typeof(System.Data.SqlTypes.SqlDouble)));
                addedItems.Columns.Add(new System.Data.DataColumn("KLPItems_DiscountVendorPrice", typeof(System.Data.SqlTypes.SqlMoney)));
                addedItems.Columns.Add(new System.Data.DataColumn("KLPItems_CurrencyPrice", typeof(System.Data.SqlTypes.SqlMoney)));
                addedItems.Columns.Add(new System.Data.DataColumn("KLPItems_CustomTarifPercent", typeof(System.Data.SqlTypes.SqlDouble)));
                addedItems.Columns.Add(new System.Data.DataColumn("CountryProduction_Guid", typeof(System.Data.SqlTypes.SqlGuid)));

                System.Data.DataRow newRow = null;
                foreach (CKLPItems objItem in objKLPItemslist)
                {
                    newRow = addedItems.NewRow();
                    newRow["KLPItems_Guid"] = objItem.ID;
                    newRow["KLP_Guid"] = uuidKLPID;
                    newRow["Parts_Guid"] = objItem.Product.ID;
                    newRow["Measure_Guid"] = objItem.Measure.ID;
                    newRow["LotOrderItems_Guid"] = objItem.ParentLotOrderItemsID;
                    newRow["KLPItems_Quantity"] = objItem.Quantity;
                    newRow["KLPItems_FactQuantity"] = objItem.QuantityFact;
                    newRow["KLPItems_DiscountVendorPrice"] = (System.Data.SqlTypes.SqlMoney)objItem.PriceForCalcCostPriceInVendorCurrency;
                    newRow["KLPItems_CurrencyPrice"] = (System.Data.SqlTypes.SqlMoney)objItem.PriceForCalcCostPrice;
                    newRow["KLPItems_CustomTarifPercent"] = (System.Data.SqlTypes.SqlMoney)objItem.CustomTarifPercent;
                    newRow["CountryProduction_Guid"] = objItem.CountryProduction.ID;

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
    public class CKLPHistory
    {
        #region Свойства
        public struct KLPHistoryRecord
        {
            public System.DateTime RecordDateTimeUpdate;
            public System.String RecordUserUpdate;
            public ERP_Mercury.Common.CKLPState KLPState;

            public KLPHistoryRecord(System.DateTime dtRecordDateTimeUpdate, System.String strRecordUserUpdate,
                ERP_Mercury.Common.CKLPState objKLPState)
            {
                RecordDateTimeUpdate = dtRecordDateTimeUpdate;
                RecordUserUpdate = strRecordUserUpdate;
                KLPState = objKLPState;
            }
        }

        public List<KLPHistoryRecord> KLPHistoryRecordList { get; set; }

        #endregion

        #region Конструктор
        public CKLPHistory()
        {
            KLPHistoryRecordList = null;
        }
        #endregion

        #region Добавление записи в журнал
        /// <summary>
        /// Добавление записи в журнал состояний
        /// </summary>
        /// <param name="dtRecordDateTimeUpdate">дата-время собятия</param>
        /// <param name="strRecordUserUpdate">пользователь, изменивший состояние КЛП</param>
        /// <param name="objKLPState">состояние, в которое перешёл КЛП</param>
        public void AddKLPHistoryRecord(System.DateTime dtRecordDateTimeUpdate, System.String strRecordUserUpdate,
                ERP_Mercury.Common.CKLPState objKLPState)
        {
            System.Int32 iRecordCount = 0;
            try
            {
                if (KLPHistoryRecordList == null)
                {
                    KLPHistoryRecordList = new List<KLPHistoryRecord>();
                }

                iRecordCount = KLPHistoryRecordList.Count;
                KLPHistoryRecordList.Add(new KLPHistoryRecord(dtRecordDateTimeUpdate, strRecordUserUpdate, objKLPState));
            }
            catch
            {
                if ((KLPHistoryRecordList != null) && (KLPHistoryRecordList.Count != 0)
                    && (KLPHistoryRecordList.Count > iRecordCount))
                {
                    KLPHistoryRecordList.RemoveAt(KLPHistoryRecordList.Count - 1);
                }
            }
            return;
        }
        #endregion
    }

    public class CKLPRepository
    {
        #region Список КЛП
        /// <summary>
        /// Возвращает список КЛП к заказу
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="uuidLotOrderId">уи заказа</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>список КЛПу (объекты класса CKLP)</returns>
        public static List<CKLP> GetKLPList(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid uuidLotOrderId, ref System.String strErr)
        {
            List<CKLP> objList = new List<CKLP>();
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

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_GetKLPForLotOrder]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters["@LotOrder_Guid"].Value = uuidLotOrderId;
                System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        objList.Add(new CKLP()
                        {
                            ID = (System.Guid)rs["KLP_Guid"],
                            Ib_ID = System.Convert.ToInt32(rs["KLP_Id"]),
                            Number = System.Convert.ToString(rs["KLP_Num"]),
                            Description = ((rs["KLP_Description"] == System.DBNull.Value) ? "" : System.Convert.ToString(rs["KLP_Description"])),
                            Vendor = new ERP_Mercury.Common.CVendor()
                            {
                                ID = (System.Guid)rs["Vendor_Guid"],
                                Name = System.Convert.ToString(rs["Vendor_Name"]),
                                TypeVendor = new ERP_Mercury.Common.CVendorType() { ID = (System.Guid)rs["VendorType_Guid"], Name = System.Convert.ToString(rs["VendorType_Name"]) }
                            },
                            Currency = new ERP_Mercury.Common.CCurrency() { ID = (System.Guid)rs["Currency_Guid"], CurrencyAbbr = System.Convert.ToString(rs["Currency_Abbr"]) },
                            CurrentKLPState = new ERP_Mercury.Common.CKLPState()
                            {
                                ID = (System.Guid)rs["KLPState_Guid"],
                                Name = System.Convert.ToString(rs["KLPSate_Name"]),
                                Description = ((rs["KLPSate_Description"] == System.DBNull.Value) ? "" : System.Convert.ToString(rs["KLPSate_Description"])),
                                IsActive = System.Convert.ToBoolean(rs["KLPSate_IsActive"])
                            },
                            Date = System.Convert.ToDateTime(rs["KLP_Date"]),
                            DateTimeStartAccepting = ((rs["KLP_StartAccepting"] == System.DBNull.Value) ? System.DateTime.MinValue : System.Convert.ToDateTime(rs["KLP_StartAccepting"])),
                            DateTimeEndAccepting = ((rs["KLP_EndtAccepting"] == System.DBNull.Value) ? System.DateTime.MinValue : System.Convert.ToDateTime(rs["KLP_EndtAccepting"])),
                            IsActive = System.Convert.ToBoolean(rs["KLP_IsActive"]),
                            IsCostCalc = System.Convert.ToBoolean(rs["KLP_CostIsCalc"]),
                            StockAccepting = new ERP_Mercury.Common.CStock()
                            {
                                ID = (System.Guid)rs["Stock_Guid"],
                                IBId = System.Convert.ToInt32(rs["Stock_Id"]),
                                Name = System.Convert.ToString(rs["Stock_Name"]),
                                Company = new ERP_Mercury.Common.CCompany() { ID = (System.Guid)rs["Company_Guid"], Abbr = System.Convert.ToString(rs["Company_Acronym"]) },
                                WareHouse = new ERP_Mercury.Common.CWarehouse() { ID = (System.Guid)rs["Warehouse_Guid"], Name = System.Convert.ToString(rs["Warehouse_Name"]) }
                            },
                            QuantityInDoc = System.Convert.ToDouble(rs["Quantity"]),
                            QuantityFact = System.Convert.ToDouble(rs["FactQuantity"]),
                            SumFactByPriceForCalcCostPrice = System.Convert.ToDouble(rs["FactAllCurrencyPrice"]),
                            SumFactByPriceForCalcCostPriceInVendorCurrency = System.Convert.ToDouble(rs["FactAllDiscountVendorPrice"])
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
                strErr = "Не удалось получить список КЛП для выбранного заказа. Текст ошибки: " + f.Message;
            }
            return objList;
        }

        #endregion

        #region Список приложения к КЛП
        /// <summary>
        /// Возвращает приложение к КЛП
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="uuidKLPId">уи КЛП</param>
        /// <returns>список объектов класса CKLPItems</returns>
        public static List<CKLPItems> GetKLPItemsList(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid uuidKLPId, ref System.Int32 iRes, ref System.String strErr)
        {
            List<CKLPItems> objList = new List<CKLPItems>();
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

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_GetKLPItems]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters["@KLP_Guid"].Value = uuidKLPId;
                System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();
                iRes = System.Convert.ToInt32(cmd.Parameters["@ERROR_NUM"].Value);
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        objList.Add( new CKLPItems()
                        {
                            ID = (System.Guid)rs["KLPItems_Guid"],
                            Ib_Id = System.Convert.ToInt32(rs["KLPItems_Id"]),
                            Product = new ERP_Mercury.Common.CProduct((rs["PartsBarcode"] == System.DBNull.Value) ? "" : System.Convert.ToString(rs["PartsBarcode"])) 
                            { 
                                ID = (System.Guid)rs["Parts_Guid"], 
                                Name = System.Convert.ToString(rs["Parts_Name"]), 
                                Article = System.Convert.ToString(rs["Parts_Article"]), 
                                VendorPrice = System.Convert.ToDecimal(rs["Parts_VendorPrice"]), 
                                PackQuantity = System.Convert.ToInt32(rs["Parts_PackQuantity"]), 
                                ID_Ib = System.Convert.ToInt32(rs["Parts_Id"]), 
                                ProductTradeMark = new ERP_Mercury.Common.CProductTradeMark() { ID = (System.Guid)rs["PartsOwner_Guid"] },
                                AlcoholicContentPercent = System.Convert.ToDecimal(rs["Parts_AlcoholicContentPercent"])
                            },
                            Measure = new ERP_Mercury.Common.CMeasure() { ID = (System.Guid)rs["Measure_Guid"], Name = System.Convert.ToString(rs["Measure_Name"]), ShortName = System.Convert.ToString(rs["Measure_ShortName"]) },
                            Quantity = System.Convert.ToDouble(rs["KLPItems_Quantity"]),
                            QuantityFact = System.Convert.ToDouble(rs["KLPItems_FactQuantity"]),
                            PriceForCalcCostPrice = System.Convert.ToDouble(rs["KLPItems_CurrencyPrice"]),
                            PriceForCalcCostPriceInVendorCurrency = System.Convert.ToDouble(rs["KLPItems_DiscountVendorPrice"]),
                            ParentLotOrderItemsID = (System.Guid)rs["LotOrderItems_Guid"],
                            CustomTarifPercent = System.Convert.ToDouble(rs["KLPItems_CustomTarifPercent"]),
                            CountryProduction = new ERP_Mercury.Common.CCountry() { ID = (System.Guid)rs["CountryProduction_Guid"], Name = System.Convert.ToString(rs["Country_Name"]) },
                            ExpirationDate = ( ( rs["LotOrderItems_ExpDate"] == System.DBNull.Value ) ? System.DateTime.MinValue : System.Convert.ToDateTime( rs["LotOrderItems_ExpDate"] ) )
                        } );
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
                strErr = "Не удалось получить приложение к КЛП. Текст ошибки: " + f.Message;
            }
            return objList;
        }
        #endregion

        #region Добавление в БД информации о КЛП
        /// <summary>
        /// Проверяет заполнение свойств КЛП перед сохранением в БД
        /// </summary>
        /// <param name="Order_BeginDate">дата заказа</param>
        /// <param name="Vendor_Guid">уи поставщика</param>
        /// <param name="Currency_Guid">уи валюты заказа</param>
        /// <param name="LotOrderState_Guid">уи состояния заказа</param>
        /// <param name="addedCategories">приложение к заказу</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - все обязательные поля заполнены; false - не все обязазательные поля заполнены</returns>
        public static System.Boolean CheckAllPropertiesForSave(System.DateTime KLP_Date, System.Guid LotOrder_Guid,
            System.Guid Stock_Guid, System.Guid KLPState_Guid, System.Data.DataTable addedCategories, ref System.String strErr)
        {
            System.Boolean bRet = false;
            try
            {
                if (KLP_Date == System.DateTime.MinValue)
                {
                    strErr = "Укажите, пожалуйста, дату КЛП.";
                    return bRet;
                }
                if (LotOrder_Guid == System.Guid.Empty)
                {
                    strErr = "Укажите, пожалуйста, заказ.";
                    return bRet;
                }
                if (Stock_Guid == System.Guid.Empty)
                {
                    strErr = "Укажите, пожалуйста, склад прихода товара.";
                    return bRet;
                }
                if (KLPState_Guid == System.Guid.Empty)
                {
                    strErr = "Укажите, пожалуйста, состояние КЛП.";
                    return bRet;
                }
                if ((addedCategories == null) || (addedCategories.Rows.Count == 0))
                {
                    strErr = "Приложение к КЛП не содержит записей. Добавьте, пожалуйста, хотя бы одну позицию.";
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
        /// Добавляет в БД информацию о КЛП
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="KLP_Num">номер КЛП</param>
        /// <param name="KLP_Date">дата КЛП</param>
        /// <param name="KLP_StartAccepting">дата начала приёмки товара</param>
        /// <param name="KLP_EndtAccepting">дата окончания приёмки товара</param>
        /// <param name="KLPState_Guid">уи состояния КЛП</param>
        /// <param name="Stock_Guid">уи склада прихода товара</param>
        /// <param name="LotOrder_Guid">уи заказа</param>
        /// <param name="KLP_Description">примечание</param>
        /// <param name="KLP_CostIsCalc">признак "себестоимость рассчитана"</param>
        /// <param name="KLP_IsActive">признак "КЛП активен"</param>
        /// <param name="addedItems">приложение к КЛП</param>
        /// <param name="KLP_Guid">уи КЛП</param>
        /// <param name="KLP_Id">уи КЛП в InterBase</param>
        /// <param name="SumFactByCostPrice">сумма по себестоимости по фактическому количеству</param>
        /// <param name="SumByCostPrice">сумма по себестоимости по количеству в накладной</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        public static System.Boolean AddKLP(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.String KLP_Num, System.DateTime KLP_Date, System.DateTime KLP_StartAccepting, System.DateTime KLP_EndAccepting,
            System.Guid KLPState_Guid, System.Guid Stock_Guid, System.Guid LotOrder_Guid, System.String KLP_Description, 
            System.Boolean KLP_CostIsCalc, System.Boolean KLP_IsActive,  System.Data.DataTable addedItems,
            ref System.Guid KLP_Guid, ref System.Int32 KLP_Id, ref System.Double SumFactByPriceForCalcCostPrice,
            ref System.Double SumFactByPriceForCalcCostPriceInVendorCurrency,
            ref System.String strErr)
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
                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_AddKLP]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.AddWithValue("@tKLPItems", addedItems);
                cmd.Parameters["@tKLPItems"].SqlDbType = System.Data.SqlDbType.Structured;
                cmd.Parameters["@tKLPItems"].TypeName = "dbo.udt_KLPItems";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_Num", System.Data.SqlDbType.NVarChar, 56));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_Date", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLPState_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Stock_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_Description", System.Data.SqlDbType.NVarChar, 512));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_CostIsCalc", System.Data.SqlDbType.Bit));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_IsActive", System.Data.SqlDbType.Bit));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_StartAccepting", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_EndtAccepting", System.Data.SqlDbType.DateTime));

                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters["@KLP_Guid"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_Id", System.Data.SqlDbType.Int));
                cmd.Parameters["@KLP_Id"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SumFactByPriceForCalcCostPrice", System.Data.SqlDbType.Money));
                cmd.Parameters["@SumFactByPriceForCalcCostPrice"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SumFactByPriceForCalcCostPriceInVendorCurrency", System.Data.SqlDbType.Money));
                cmd.Parameters["@SumFactByPriceForCalcCostPriceInVendorCurrency"].Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters["@KLP_Num"].Value = KLP_Num;
                cmd.Parameters["@KLP_Date"].Value = KLP_Date;

                if (System.DateTime.Compare(KLP_StartAccepting, System.DateTime.MinValue) == 0)
                {
                    cmd.Parameters["@KLP_StartAccepting"].IsNullable = true;
                    cmd.Parameters["@KLP_StartAccepting"].Value = null;
                }
                else
                {
                    cmd.Parameters["@KLP_StartAccepting"].Value = KLP_StartAccepting;
                }

                if (System.DateTime.Compare(KLP_EndAccepting, System.DateTime.MinValue) == 0)
                {
                    cmd.Parameters["@KLP_EndtAccepting"].IsNullable = true;
                    cmd.Parameters["@KLP_EndtAccepting"].Value = null;
                }
                else
                {
                    cmd.Parameters["@KLP_EndtAccepting"].Value = KLP_EndAccepting;
                }

                cmd.Parameters["@KLPState_Guid"].Value = KLPState_Guid;
                cmd.Parameters["@Stock_Guid"].Value = Stock_Guid;
                cmd.Parameters["@LotOrder_Guid"].Value = LotOrder_Guid;
                cmd.Parameters["@KLP_Description"].Value = KLP_Description;
                cmd.Parameters["@KLP_IsActive"].Value = KLP_IsActive;
                cmd.Parameters["@KLP_CostIsCalc"].Value = KLP_CostIsCalc;

                cmd.ExecuteNonQuery();
                System.Int32 iRes = (System.Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                if (iRes == 0)
                {
                    KLP_Guid = (System.Guid)cmd.Parameters["@KLP_Guid"].Value;
                    KLP_Id = System.Convert.ToInt32(cmd.Parameters["@KLP_Id"].Value);
                    SumFactByPriceForCalcCostPrice = System.Convert.ToDouble(cmd.Parameters["@SumFactByPriceForCalcCostPrice"].Value);
                    SumFactByPriceForCalcCostPriceInVendorCurrency = System.Convert.ToDouble(cmd.Parameters["@SumFactByPriceForCalcCostPriceInVendorCurrency"].Value);
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

        #region Редактирование в БД информации о КЛП
        /// <summary>
        /// Редактирует в БД информацию о КЛП
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="KLP_Num">номер КЛП</param>
        /// <param name="KLP_Date">дата КЛП</param>
        /// <param name="KLP_StartAccepting">дата начала приёмки товара</param>
        /// <param name="KLP_EndtAccepting">дата окончания приёмки товара</param>
        /// <param name="KLPState_Guid">уи состояния КЛП</param>
        /// <param name="Stock_Guid">уи склада прихода товара</param>
        /// <param name="LotOrder_Guid">уи заказа</param>
        /// <param name="KLP_Description">примечание</param>
        /// <param name="KLP_CostIsCalc">признак "себестоимость рассчитана"</param>
        /// <param name="KLP_IsActive">признак "КЛП активен"</param>
        /// <param name="addedItems">приложение к КЛП</param>
        /// <param name="KLP_Guid">уи КЛП</param>
        /// <param name="KLP_Id">уи КЛП в InterBase</param>
        /// <param name="SumFactByCostPrice">сумма по себестоимости по фактическому количеству</param>
        /// <param name="SumByCostPrice">сумма по себестоимости по количеству в накладной</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        public static System.Boolean EditKLP(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.String KLP_Num, System.DateTime KLP_Date, System.DateTime KLP_StartAccepting, System.DateTime KLP_EndAccepting,
            System.Guid KLPState_Guid, System.Guid Stock_Guid, System.Guid LotOrder_Guid, System.String KLP_Description,
            System.Boolean KLP_CostIsCalc, System.Boolean KLP_IsActive, System.Data.DataTable addedItems,
            System.Guid KLP_Guid, ref System.Double SumFactByPriceForCalcCostPrice,
            ref System.Double SumFactByPriceForCalcCostPriceInVendorCurrency,
            ref System.String strErr)
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
                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_EditKLP]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.AddWithValue("@tKLPItems", addedItems);
                cmd.Parameters["@tKLPItems"].SqlDbType = System.Data.SqlDbType.Structured;
                cmd.Parameters["@tKLPItems"].TypeName = "dbo.udt_KLPItems";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_Num", System.Data.SqlDbType.NVarChar, 56));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_Date", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLPState_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Stock_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LotOrder_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_Description", System.Data.SqlDbType.NVarChar, 512));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_CostIsCalc", System.Data.SqlDbType.Bit));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_IsActive", System.Data.SqlDbType.Bit));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_StartAccepting", System.Data.SqlDbType.DateTime));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_EndtAccepting", System.Data.SqlDbType.DateTime));

                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SumFactByPriceForCalcCostPrice", System.Data.SqlDbType.Money));
                cmd.Parameters["@SumFactByPriceForCalcCostPrice"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SumFactByPriceForCalcCostPriceInVendorCurrency", System.Data.SqlDbType.Money));
                cmd.Parameters["@SumFactByPriceForCalcCostPriceInVendorCurrency"].Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters["@KLP_Guid"].Value = KLP_Guid;
                cmd.Parameters["@KLP_Num"].Value = KLP_Num;
                cmd.Parameters["@KLP_Date"].Value = KLP_Date;

                if (System.DateTime.Compare(KLP_StartAccepting, System.DateTime.MinValue) == 0)
                {
                    cmd.Parameters["@KLP_StartAccepting"].IsNullable = true;
                    cmd.Parameters["@KLP_StartAccepting"].Value = null;
                }
                else
                {
                    cmd.Parameters["@KLP_StartAccepting"].Value = KLP_StartAccepting;
                }

                if (System.DateTime.Compare(KLP_EndAccepting, System.DateTime.MinValue) == 0)
                {
                    cmd.Parameters["@KLP_EndtAccepting"].IsNullable = true;
                    cmd.Parameters["@KLP_EndtAccepting"].Value = null;
                }
                else
                {
                    cmd.Parameters["@KLP_EndtAccepting"].Value = KLP_EndAccepting;
                }

                cmd.Parameters["@KLPState_Guid"].Value = KLPState_Guid;
                cmd.Parameters["@Stock_Guid"].Value = Stock_Guid;
                cmd.Parameters["@LotOrder_Guid"].Value = LotOrder_Guid;
                cmd.Parameters["@KLP_Description"].Value = KLP_Description;
                cmd.Parameters["@KLP_IsActive"].Value = KLP_IsActive;
                cmd.Parameters["@KLP_CostIsCalc"].Value = KLP_CostIsCalc;

                cmd.ExecuteNonQuery();
                System.Int32 iRes = (System.Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                if (iRes == 0)
                {
                    SumFactByPriceForCalcCostPrice = System.Convert.ToDouble(cmd.Parameters["@SumFactByPriceForCalcCostPrice"].Value);
                    SumFactByPriceForCalcCostPriceInVendorCurrency = System.Convert.ToDouble(cmd.Parameters["@SumFactByPriceForCalcCostPriceInVendorCurrency"].Value);
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

        #region Удаление КЛП из БД
        /// <summary>
        /// Удаляет из БД информацию о КЛП
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="KLP_Guid">уи заказа</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        public static System.Boolean DeleteKLP(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid KLP_Guid, ref System.String strErr)
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
                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_DeleteKLP]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters["@KLP_Guid"].Value = KLP_Guid;

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
 
        #region Журнал состояний КЛП
        /// <summary>
        /// Возвращает журнал состояний КЛП
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="uuidKLPId">уи КЛП</param>
        /// <param name="iRes">результат выполнения хранимой процедуры</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>объект класса CKLPHistory</returns>
        public static CKLPHistory GetKLPHistory(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            System.Guid uuidKLPId, ref System.Int32 iRes, ref System.String strErr)
        {
            CKLPHistory objList = new CKLPHistory();
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

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_GetKLPStateHistory]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                if (uuidKLPId.CompareTo(System.Guid.Empty) != 0)
                {
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KLP_Guid", System.Data.SqlDbType.UniqueIdentifier));
                    cmd.Parameters["@KLP_Guid"].Value = uuidKLPId;
                }
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();
                iRes = System.Convert.ToInt32(cmd.Parameters["@ERROR_NUM"].Value);
                if (rs.HasRows)
                {
                    objList.KLPHistoryRecordList = new List<CKLPHistory.KLPHistoryRecord>();
                    while (rs.Read())
                    {
                        objList.AddKLPHistoryRecord(System.Convert.ToDateTime(rs["Record_Updated"]),
                            System.Convert.ToString(rs["Record_UserUdpated"]),
                            new ERP_Mercury.Common.CKLPState()
                            {
                                ID = (System.Guid)rs["KLPState_Guid"],
                                Name = System.Convert.ToString(rs["KLPSate_Name"])
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
                strErr = "Не удалось получить журнал состояний КЛП. Текст ошибки: " + f.Message;
            }
            return objList;
        }

        #endregion
    }
}
