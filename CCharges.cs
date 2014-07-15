using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPMercuryLotOrder
{
    /// <summary>
    /// Класс "Дополнительный расход"
    /// </summary>
    public class CCharges
    {
        #region Свойства
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public System.Guid ID { get; set; }
        /// <summary>
        /// Тип дополнительных расходов
        /// </summary>
        public ERP_Mercury.Common.CSurcharges ChargesType { get; set; }
        /// <summary>
        /// Наименовнание типа дополнительных расходов
        /// </summary>
        public System.String ChargesTypeName
        {
            get { return ((ChargesType == null) ? "" : ChargesType.Name); }
        }
        /// <summary>
        /// Валюта расхода
        /// </summary>
        public ERP_Mercury.Common.CCurrency Currency { get; set; }
        /// <summary>
        /// Валюта расхода
        /// </summary>
        public System.String CurrencyCode
        {
            get { return ((Currency == null) ? "" : Currency.CurrencyAbbr); }
        }
        /// <summary>
        /// Дата платежа
        /// </summary>
        public System.DateTime ChargesDate { get; set; }
        /// <summary>
        /// Сумма платежа
        /// </summary>
        public System.Double ChargesValue { get; set; }
        /// <summary>
        /// Сумма расхода
        /// </summary>
        public System.Double ChargesExpense { get; set; }
        /// <summary>
        /// Сумма остатка платежа
        /// </summary>
        public System.Double ChargesRest { get; set; }
        /// <summary>
        /// Курс валюты платежа к валюте учёта
        /// </summary>
        public System.Double ChargesCurrencyRate { get; set; }
        /// <summary>
        /// Признак "Были изменены свойства"
        /// </summary>
        public System.Boolean IsChanged { get; set; }

        #endregion

        #region Конструктор
        public CCharges()
        {
            ID = System.Guid.Empty;
            ChargesType = null;
            Currency = null;
            ChargesValue = 0;
            ChargesExpense = 0;
            ChargesRest = 0;
            ChargesCurrencyRate = 0;
            IsChanged = false;
        }
        #endregion
    }

    public class CChargesRepository
    {
        #region Список объектов
        /// <summary>
        /// Возвращает список расходов
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="dtBeginDate">начало периода</param>
        /// <param name="dtEndDate">конец периода</param>
        /// <returns>список расходов</returns>
        public static List<CCharges> GetChargesList(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL, 
            System.DateTime dtBeginDate, System.DateTime dtEndDate)
        {
            List<CCharges> objList = new List<CCharges>();
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

                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_GetCharges]", objProfile.GetOptionsDllDBName());
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
                        objList.Add(new CCharges()
                        {
                            ID = (System.Guid)rs["Charges_Guid"],
                            ChargesType = new ERP_Mercury.Common.CSurcharges()
                            {
                                ID = (System.Guid)rs["Surcharges_Guid"],
                                Name = System.Convert.ToString(rs["Surcharges_Name"]),
                                Description = ((rs["Surcharges_Description"] == System.DBNull.Value) ? "" : System.Convert.ToString(rs["Surcharges_Description"])),
                                OrderNum = System.Convert.ToInt32(rs["Surcharges_NumberOrder"]),
                                IsActive = System.Convert.ToBoolean(rs["Surcharges_IsActive"])
                            },
                            ChargesDate = System.Convert.ToDateTime( rs["Charges_Date"] ),
                            Currency = new ERP_Mercury.Common.CCurrency() { ID = (System.Guid)rs["Currency_Guid"], CurrencyAbbr = System.Convert.ToString( rs["Currency_Abbr"] ) },
                            ChargesCurrencyRate = System.Convert.ToDouble( rs["Charges_CurrencyRate"] ),
                            ChargesValue = System.Convert.ToDouble(rs["Charges_Value"]),
                            ChargesExpense = System.Convert.ToDouble(rs["Charges_Expense"]),
                            ChargesRest = System.Convert.ToDouble(rs["Charges_Rest"])
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
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Не удалось получить список дополнительных расходов.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return objList;
        }
        #endregion

        #region Удаление доп. расхода из БД
        /// <summary>
        /// Удалить запись из БД
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="uuidID">уникальный идентификатор объекта</param>
        /// <returns>true - удачное завершение; false - ошибка</returns>
        public static System.Boolean Remove(UniXP.Common.CProfile objProfile, System.Guid uuidID)
        {
            System.Boolean bRet = false;
            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlTransaction DBTransaction = null;
            try
            {
                DBConnection = objProfile.GetDBSource();
                if (DBConnection == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Не удалось получить соединение с базой данных.", "Внимание",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return bRet;
                }
                DBTransaction = DBConnection.BeginTransaction();
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.Connection = DBConnection;
                cmd.Transaction = DBTransaction;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_DeleteCharges]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Charges_Guid", System.Data.SqlDbType.UniqueIdentifier));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters["@Charges_Guid"].Value = uuidID;

                cmd.ExecuteNonQuery();
                System.Int32 iRes = (System.Int32)cmd.Parameters["@RETURN_VALUE"].Value;

                if (iRes != 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка удаления информации о дополнительном расходе.\n\nТекст ошибки: " +
                        (System.String)cmd.Parameters["@ERROR_MES"].Value, "Ошибка",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }

                bRet = (iRes == 0);

                if (bRet == true)
                {
                    // подтверждаем транзакцию  
                    DBTransaction.Commit();
                }
                else
                {
                    // откатываем транзакцию
                    DBTransaction.Rollback();
                }
                cmd.Dispose();
            }
            catch (System.Exception f)
            {
                DBTransaction.Rollback();
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка удаления информации о дополнительном расходе.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                DBConnection.Close();
            }
            return bRet;
        }


        #endregion

        #region Сохранение дополнительного расхода в БД

        #region IsAllParametersValid
        /// <summary>
        /// Проверка свойств перед сохранением
        /// </summary>
        /// <returns>true - ошибок нет; false - ошибка</returns>
        public static System.Boolean IsAllParametersValid( CCharges objCharges )
        {
            System.Boolean bRet = false;
            try
            {
                if (objCharges.Currency == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Укажите, пожалуйста, валюту.", "Внимание",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return bRet;
                }
                if (objCharges.ChargesType == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Укажите, пожалуйста, тип расхода!", "Внимание",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return bRet;
                }
                if (objCharges.ChargesValue == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Укажите, пожалуйста, величину расхода!", "Внимание",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return bRet;
                }
                if (objCharges.ChargesCurrencyRate == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Укажите, пожалуйста, курс пересчёта валюты расхода в валюту учёта!", "Внимание",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return bRet;
                }

                bRet = true;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка проверки свойств.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bRet;
        }
        #endregion

        /// <summary>
        /// Сохранение списка расходов в БД
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <param name="cmdSQL">SQL-команда</param>
        /// <param name="objChargesList">список расходов</param>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        public static System.Boolean SaveChargesList(UniXP.Common.CProfile objProfile, System.Data.SqlClient.SqlCommand cmdSQL,
            List<CCharges> objChargesList, ref System.String strErr)
        {
            System.Boolean bRet = false;
            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlTransaction DBTransaction = null;
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
                    DBTransaction = DBConnection.BeginTransaction();
                    cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.Connection = DBConnection;
                    cmd.Transaction = DBTransaction;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    cmd = cmdSQL;
                    cmd.Parameters.Clear();
                }
                System.Data.DataTable addedItems = new System.Data.DataTable();

                addedItems.Columns.Add(new System.Data.DataColumn("Charges_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("Surcharges_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("Charges_Date", typeof(System.Data.SqlTypes.SqlDateTime)));
                addedItems.Columns.Add(new System.Data.DataColumn("Currency_Guid", typeof(System.Data.SqlTypes.SqlGuid)));
                addedItems.Columns.Add(new System.Data.DataColumn("Charges_Value", typeof(System.Data.SqlTypes.SqlDouble)));
                addedItems.Columns.Add(new System.Data.DataColumn("Charges_Expense", typeof(System.Data.SqlTypes.SqlDouble)));
                addedItems.Columns.Add(new System.Data.DataColumn("Charges_CurrencyRate", typeof(System.Data.SqlTypes.SqlDouble)));
                addedItems.Columns.Add(new System.Data.DataColumn("Charges_Rest", typeof(System.Data.SqlTypes.SqlDouble)));

                System.Data.DataRow newRow = null;
                foreach (CCharges objItem in objChargesList)
                {
                    newRow = addedItems.NewRow();
                    newRow["Charges_Guid"] = objItem.ID;
                    newRow["Surcharges_Guid"] = objItem.ChargesType.ID;
                    newRow["Charges_Date"] = objItem.ChargesDate;
                    newRow["Currency_Guid"] = objItem.Currency.ID;
                    newRow["Charges_Value"] = objItem.ChargesValue;
                    newRow["Charges_Expense"] = objItem.ChargesExpense;
                    newRow["Charges_CurrencyRate"] = objItem.ChargesCurrencyRate;
                    newRow["Charges_Rest"] = objItem.ChargesRest;
                    addedItems.Rows.Add(newRow);
                }
                addedItems.AcceptChanges();

                cmd.Parameters.Clear();
                cmd.CommandText = System.String.Format("[{0}].[dbo].[usp_AddCharges]", objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.AddWithValue("@tCharges", addedItems);
                cmd.Parameters["@tCharges"].SqlDbType = System.Data.SqlDbType.Structured;
                cmd.Parameters["@tCharges"].TypeName = "dbo.udt_Charges";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                System.Int32 iRes = (System.Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                if (iRes != 0)
                {
                    strErr = (System.String)cmd.Parameters["@ERROR_MES"].Value;
                }

                if (cmdSQL == null)
                {
                    if (iRes == 0)
                    {
                        // подтверждаем транзакцию
                        if (DBTransaction != null)
                        {
                            DBTransaction.Commit();
                        }
                    }
                    else
                    {
                        // откатываем транзакцию
                        if (DBTransaction != null)
                        {
                            DBTransaction.Rollback();
                        }
                    }
                    DBConnection.Close();
                }
                bRet = (iRes == 0);
            }
            catch (System.Exception f)
            {
                if ((cmdSQL == null) && (DBTransaction != null))
                {
                    DBTransaction.Rollback();
                }
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

    }

}
