using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraExport;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraEditors;
using System.Data.OleDb;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;

namespace ERPMercuryLotOrder
{
    public partial class ctrlLotOrder : UserControl
    {
        #region Свойства
        private UniXP.Common.CProfile m_objProfile;
        private UniXP.Common.MENUITEM m_objMenuItem;
        private List<ERP_Mercury.Common.CProduct> m_objPartsList;
        private List<ERP_Mercury.Common.CVendor> m_objVendorList;

        private CLotOrder m_objSelectedOrder;
        private System.Guid m_uuidSelectedStockID;

        private System.Boolean m_bIsChanged;

        private System.Boolean m_bDisableEvents;
        private System.Boolean m_bNewObject;
        private System.Boolean m_bIsReadOnly;
        private System.String m_strXLSImportFilePath;
        private System.Int32 m_iXLSSheetImport;
        private List<System.String> m_SheetList;

        // потоки
        private System.Threading.Thread thrAddress;
        public System.Threading.Thread ThreadAddress
        {
            get { return thrAddress; }
        }
        private System.Threading.ManualResetEvent m_EventStopThread;
        public System.Threading.ManualResetEvent EventStopThread
        {
            get { return m_EventStopThread; }
        }
        private System.Threading.ManualResetEvent m_EventThreadStopped;
        public System.Threading.ManualResetEvent EventThreadStopped
        {
            get { return m_EventThreadStopped; }
        }
        public delegate void LoadPartsListDelegate();
        public LoadPartsListDelegate m_LoadPartsListDelegate;

        public delegate void SendMessageToLogDelegate(System.String strMessage);
        public SendMessageToLogDelegate m_SendMessageToLogDelegate;

        public delegate void SetProductListToFormDelegate(List<ERP_Mercury.Common.CProduct> objProductNewList);
        public SetProductListToFormDelegate m_SetProductListToFormDelegate;

        private const System.Int32 iThreadSleepTime = 1000;
        private System.Boolean m_bThreadFinishJob;

        private const System.String m_strReportsDirectory = "templates";
        private const System.String m_strReportSuppl = "LotOrder.xlsx";
        private const System.String m_strModeReadOnly = "Режим просмотра";
        private const System.String m_strModeEdit = "Режим редактирования";

        #endregion

        #region События
        // Создаем закрытое поле, ссылающееся на заголовок списка делегатов
        private EventHandler<ChangeLotOrderPropertieEventArgs> m_ChangeLotOrderProperties;
        // Создаем в классе член-событие
        public event EventHandler<ChangeLotOrderPropertieEventArgs> ChangeLotOrderProperties
        {
            add
            {
                // берем закрытую блокировку и добавляем обработчик
                // (передаваемый по значению) в список делегатов
                m_ChangeLotOrderProperties += value;
            }
            remove
            {
                // берем закрытую блокировку и удаляем обработчик
                // (передаваемый по значению) из списка делегатов
                m_ChangeLotOrderProperties -= value;
            }
        }
        /// <summary>
        /// Инициирует событие и уведомляет о нем зарегистрированные объекты
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChangeLotOrderProperties(ChangeLotOrderPropertieEventArgs e)
        {
            // Сохраняем поле делегата во временном поле для обеспечение безопасности потока
            EventHandler<ChangeLotOrderPropertieEventArgs> temp = m_ChangeLotOrderProperties;
            // Если есть зарегистрированные объектв, уведомляем их
            if (temp != null) temp(this, e);
        }
        public void SimulateChangeOrderProperties(CLotOrder objOrder, ERP_Mercury.Common.enumActionSaveCancel enActionType, System.Boolean bIsNewOrder)
        {
            // Создаем объект, хранящий информацию, которую нужно передать
            // объектам, получающим уведомление о событии
            ChangeLotOrderPropertieEventArgs e = new ChangeLotOrderPropertieEventArgs(objOrder, enActionType, bIsNewOrder);

            // Вызываем виртуальный метод, уведомляющий наш объект о возникновении события
            // Если нет типа, переопределяющего этот метод, наш объект уведомит все объекты, 
            // подписавшиеся на уведомление о событии
            OnChangeLotOrderProperties(e);
        }
        #endregion

        #region Конструктор
        public ctrlLotOrder(UniXP.Common.CProfile objProfile, UniXP.Common.MENUITEM objMenuItem, List<ERP_Mercury.Common.CVendor> objVendorList)
        {
            m_objProfile = objProfile;
            m_objMenuItem = objMenuItem;
            m_objVendorList = objVendorList;

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);

            InitializeComponent();

            m_bIsChanged = false;
            m_bDisableEvents = false;
            m_bNewObject = false;
            m_uuidSelectedStockID = System.Guid.Empty;

            m_objSelectedOrder = null;
            m_objPartsList = null;
            m_strXLSImportFilePath = "";
            m_iXLSSheetImport = 0;
            lblEditMode.Text = "";

            BeginDate.DateTime = System.DateTime.Today;
            DeliveryDate.DateTime = System.DateTime.Today;

            LoadComboBoxItems();

            //StartThreadWithLoadData();
        }

        private System.Reflection.Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            System.Reflection.Assembly MyAssembly = null;
            System.Reflection.Assembly objExecutingAssemblies = System.Reflection.Assembly.GetExecutingAssembly();

            System.Reflection.AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();

            //Loop through the array of referenced assembly names.
            System.String strDllName = "";
            foreach (System.Reflection.AssemblyName strAssmbName in arrReferencedAssmbNames)
            {

                //Check for the assembly names that have raised the "AssemblyResolve" event.
                if (strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) == args.Name.Substring(0, args.Name.IndexOf(",")))
                {
                    strDllName = args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll";
                    break;
                }

            }
            if (strDllName != "")
            {
                System.String strFileFullName = "";
                System.Boolean bError = false;
                foreach (System.String strPath in this.m_objProfile.ResourcePathList)
                {
                    //Load the assembly from the specified path. 
                    strFileFullName = strPath + "\\" + strDllName;
                    if (System.IO.File.Exists(strFileFullName))
                    {
                        try
                        {
                            MyAssembly = System.Reflection.Assembly.LoadFrom(strFileFullName);
                            break;
                        }
                        catch (System.Exception f)
                        {
                            bError = true;
                            DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка загрузки библиотеки: " +
                                strFileFullName + "\n\nТекст ошибки: " + f.Message, "Ошибка",
                                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                    if (bError) { break; }
                }
            }

            //Return the loaded assembly.
            if (MyAssembly == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Не удалось найти библиотеку: " +
                                strDllName, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

            }
            return MyAssembly;
        }
        #endregion

        #region Загрузка формы
        private void ctrlLotOrder_Load(object sender, EventArgs e)
        {
            try
            {
                txtLotOrderNum.SelectAll();
                txtLotOrderNum.Focus();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("ctrlLotOrder_Load. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }
        #endregion

        #region Журнал сообщений
        private void SendMessageToLog(System.String strMessage)
        {
            try
            {
                m_objMenuItem.SimulateNewMessage(strMessage);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "SendMessageToLog.\n Текст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region Индикация изменений
        /// <summary>
        /// Проверяет содержимое элементов управления
        /// </summary>
        private System.Boolean ValidateProperties()
        {
            System.Boolean bRet = true;
            try
            {
                cboxVendor.Properties.Appearance.BackColor = ((cboxVendor.SelectedItem == null) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                cboxCurrency.Properties.Appearance.BackColor = ((cboxCurrency.SelectedItem == null) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                cboxLotOrderState.Properties.Appearance.BackColor = ((cboxLotOrderState.SelectedItem == null) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                txtLotOrderNum.Properties.Appearance.BackColor = ((txtLotOrderNum.Text == "") ? System.Drawing.Color.Tomato : System.Drawing.Color.White);

                BeginDate.Properties.Appearance.BackColor = ((BeginDate.DateTime == System.DateTime.MinValue) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                DeliveryDate.Properties.Appearance.BackColor = (((DeliveryDate.DateTime == System.DateTime.MinValue) || (DeliveryDate.DateTime.CompareTo(BeginDate.DateTime) < 0)) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);

                if (cboxVendor.SelectedItem == null) { bRet = false; }
                if (cboxCurrency.SelectedItem == null) { bRet = false; }
                if (cboxLotOrderState.SelectedItem == null) { bRet = false; }
                if (txtLotOrderNum.Text == "") { bRet = false; }
                if (BeginDate.DateTime == System.DateTime.MinValue) { bRet = false; }
                if ((DeliveryDate.DateTime == System.DateTime.MinValue) || (DeliveryDate.DateTime.CompareTo(BeginDate.DateTime) < 0)) { bRet = false; }
                if (dataSet.Tables["OrderItems"].Rows.Count == 0) { bRet = false; }

            }
            catch (System.Exception f)
            {
                SendMessageToLog("ValidateProperties. Текст ошибки: " + f.Message);
            }

            return bRet;
        }
        private void SetPropertiesModified(System.Boolean bModified)
        {
            try
            {
                m_bIsChanged = bModified;
                btnSave.Enabled = (m_bIsChanged && (ValidateProperties() == true));
                btnCancel.Enabled = m_bIsChanged;
                if (m_bIsChanged == true)
                {
                    SimulateChangeOrderProperties(m_objSelectedOrder, ERP_Mercury.Common.enumActionSaveCancel.Unkown, m_bNewObject);
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("SetPropertiesModified. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return;
        }
        private void OrderItems_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                if (m_bDisableEvents == true) { return; }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("OrderItems_RowChanged. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        private void cboxOrderPropertie_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_bDisableEvents == true) { return; }


                if ((sender == cboxProductTradeMark) || (sender == cboxProductType))
                {
                    SetFilterForPartsCombo();
                }


                SetPropertiesModified(true);
            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка изменения свойств " + ((DevExpress.XtraEditors.ComboBoxEdit)sender).ToolTip + ". Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return;
        }


        private void txtOrderPropertie_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (m_bDisableEvents == true) { return; }
                if (e.NewValue != null)
                {
                    SetPropertiesModified(true);
                    if ((sender.GetType().Name == "TextEdit") &&
                        (((DevExpress.XtraEditors.TextEdit)sender).Properties.ReadOnly == false))
                    {
                        System.String strValue = (System.String)e.NewValue;
                        ((DevExpress.XtraEditors.TextEdit)sender).Properties.Appearance.BackColor = (strValue == "") ? System.Drawing.Color.Tomato : System.Drawing.Color.White;
                    }
                }
            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка изменения свойств ПСЦ. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return;
        }
        private void gridViewProductList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (m_bDisableEvents == true) { return; }

                SetPropertiesModified(true);

            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("gridViewProductList_CellValueChanged. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return;
        }
        private void gridViewProductList_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (m_bDisableEvents == true) { return; }

                SetPropertiesModified(true);
            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("gridViewProductList_CellValueChanging. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return;
        }
        private void SetPriceInRow(System.Int32 iRowHandle, System.Double dblDiscountPercent)
        {
            try
            {
                System.Double VendorPrice = (gridView.GetRowCellValue(iRowHandle, colVendorPrice) == null ? 0 : System.Convert.ToDouble(gridView.GetRowCellValue(iRowHandle, colVendorPrice)));
                System.Double PriceWithDiscount = (VendorPrice == 0 ? 0 : (VendorPrice * (1 - (dblDiscountPercent/100 ))));

                gridView.SetRowCellValue(iRowHandle, colVendorPriceWithDiscount, PriceWithDiscount);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("SetPriceInRow. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (m_bDisableEvents == true) { return; }

                if ((e.Column == colProductID) && (m_objPartsList != null) && (e.Value != null))
                {

                    ERP_Mercury.Common.CProduct objItem = null;
                    try
                    {
                        objItem = m_objPartsList.Cast<ERP_Mercury.Common.CProduct>().Single<ERP_Mercury.Common.CProduct>(x => x.ID.CompareTo((System.Guid)e.Value) == 0);

                        gridView.SetRowCellValue(e.RowHandle, colMeasureID, objItem.Measure.ID);
                        gridView.SetRowCellValue(e.RowHandle, colOrderItems_MeasureName, objItem.Measure.ShortName);
                        gridView.SetRowCellValue(e.RowHandle, colProduct_Weight, objItem.Weight);
                        gridView.SetRowCellValue(e.RowHandle, colVendorPriceInDirectory, objItem.VendorPrice);
                        gridView.SetRowCellValue(e.RowHandle, colVendorPrice, objItem.VendorPrice);
                        gridView.SetRowCellValue(e.RowHandle, colPriceForCalcCostPrice, 0);
                        gridView.SetRowCellValue(e.RowHandle, colDiscountPercent, spinEditDiscount.Value);

                        gridView.SetRowCellValue(e.RowHandle, colOrderPackQty, objItem.CustomerOrderPackQty);
                        if (checkMultiplicity.Checked == true)
                        {
                            gridView.SetRowCellValue(e.RowHandle, colOrderedQuantity, objItem.CustomerOrderPackQty);
                            gridView.SetRowCellValue(e.RowHandle, colConfirmQuantity, objItem.CustomerOrderPackQty);
                            gridView.SetRowCellValue(e.RowHandle, colQuantityInDoc, objItem.CustomerOrderPackQty);
                        }
                        else
                        {
                            gridView.SetRowCellValue(e.RowHandle, colOrderedQuantity, 1);
                            gridView.SetRowCellValue(e.RowHandle, colConfirmQuantity, 1);
                            gridView.SetRowCellValue(e.RowHandle, colQuantityInDoc, 1);
                        }

                        gridView.SetRowCellValue(e.RowHandle, colOrderItems_PartsArticle, objItem.Article);
                        gridView.SetRowCellValue(e.RowHandle, colOrderItems_PartsName, objItem.Name);

                        // страна производства
                        if (cboxCountryProduction.SelectedItem != null)
                        {
                            gridView.SetRowCellValue(e.RowHandle, colCountryID, ( ( ERP_Mercury.Common.CCountry )cboxCountryProduction.SelectedItem ).ID);
                            gridView.SetRowCellValue(e.RowHandle, colOrderItems_CountryProductionName, ((ERP_Mercury.Common.CCountry)cboxCountryProduction.SelectedItem).Name);
                        }

                        // таможенный тариф
                        gridView.SetRowCellValue(e.RowHandle, colCustomTarifPercent, spinEditCustomTarif.Value);

                        SetPriceInRow(e.RowHandle, System.Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colDiscountPercent)));
                        gridView.UpdateCurrentRow();
                    }
                    catch
                    {
                    }
                    finally
                    {
                        objItem = null;
                    }
                }
                else if ((e.Column == colCountryID) && (e.Value != null))
                {
                    //
                }
                else if ((e.Column == colDiscountPercent) && (e.Value != null))
                {
                    SetPriceInRow(e.RowHandle, System.Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colDiscountPercent)));
                }
                else if ((e.Column == colVendorPrice) && (e.Value != null))
                {
                    SetPriceInRow(e.RowHandle, System.Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colDiscountPercent)));
                }
                else if ((e.Column == colOrderedQuantity) && (e.Value != null) && (gridView.GetRowCellValue(e.RowHandle, colProductID) != null) &&
                    (gridView.GetRowCellValue(e.RowHandle, colOrderPackQty) != System.DBNull.Value) &&
                    (gridView.GetRowCellValue(e.RowHandle, colOrderedQuantity) != System.DBNull.Value))
                {
                    System.Decimal dclOrderedQty = System.Convert.ToDecimal(e.Value);
                    System.Decimal dclmultiplicity = System.Convert.ToDecimal(gridView.GetRowCellValue(e.RowHandle, colOrderPackQty));
                    System.Decimal dclInstockQty = System.Convert.ToDecimal(gridView.GetRowCellValue(e.RowHandle, colOrderedQuantity));

                    if (checkMultiplicity.CheckState == CheckState.Checked)
                    {
                        if ((dclOrderedQty % dclmultiplicity) != 0)
                        {
                            dclOrderedQty = (((int)dclOrderedQty / (int)dclmultiplicity) * dclmultiplicity) + dclmultiplicity;
                            if (dclOrderedQty > dclInstockQty)
                            {
                                dclOrderedQty = dclInstockQty;
                            }
                        }
                    }

                    if (System.Convert.ToDecimal(System.Convert.ToDecimal(e.Value)) != dclOrderedQty)
                    {
                        gridView.SetRowCellValue(e.RowHandle, colOrderedQuantity, System.Convert.ToDecimal(dclOrderedQty));
                    }
                    gridView.SetRowCellValue(e.RowHandle, colConfirmQuantity, System.Convert.ToDecimal(dclOrderedQty));
                    gridView.SetRowCellValue(e.RowHandle, colQuantityInDoc, System.Convert.ToDecimal(dclOrderedQty));
                    gridView.UpdateCurrentRow();

                }
                SetPropertiesModified(true);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("gridView_CellValueChanged. Текст ошибки: " + f.Message);
            }
            finally
            {

            }
            return;
        }

        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                e.Info.DisplayText = ((e.RowHandle < 0) ? "" : ("№ " + System.String.Format("{0:### ### ##0}", (e.RowHandle + 1))));
            }
            catch (System.Exception f)
            {
                SendMessageToLog("gridView_CustomDrawRowIndicator. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        private void repositoryItemLookUpEditProduct_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                if (m_bDisableEvents == true) { return; }

                if (e.AcceptValue == true)
                {
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colProductID, (System.Guid)e.Value);
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("repositoryItemLookUpEditProduct_CloseUp. Текст ошибки: " + f.Message);
            }
            finally
            {
                ValidateProperties();
            }
            return;
        }


        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if ((gridView.GetRowCellValue(e.RowHandle, colConfirmQuantity) != null) &&
                    (gridView.GetRowCellValue(e.RowHandle, colOrderedQuantity) != null))
                {
                    System.Double dblQuantityReserved = System.Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colConfirmQuantity));
                    System.Double dblOrderedQuantity = System.Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colOrderedQuantity));
                    if (dblQuantityReserved != dblOrderedQuantity)
                    {
                        if ((e.Column == colOrderedQuantity) || (e.Column == colConfirmQuantity))
                        {
                            Rectangle r = e.Bounds;
                            e.Appearance.DrawString(e.Cache, e.DisplayText, r);

                            e.Handled = true;
                        }
                    }

                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("gridView_CustomDrawCell. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }
        /// <summary>
        /// Устанавливает указанный процент скидки на все позиции в заказе
        /// </summary>
        /// <param name="dblDiscountPercent">размер скидки в процентах</param>
        private void SenDiscountPercent(System.Double dblDiscountPercent)
        {
            try
            {
                tableLayoutPanelBackground.SuspendLayout();

                if (gridView.RowCount == 0) { return; }

                Cursor = Cursors.WaitCursor;

                for (System.Int32 i = 0; i < gridView.RowCount; i++)
                {
                    gridView.SetRowCellValue(i, colDiscountPercent, dblDiscountPercent);
                }

            }
            catch (System.Exception f)
            {
                SendMessageToLog("SenDiscountPercent. Текст ошибки: " + f.Message);
            }
            finally
            {
                tableLayoutPanelBackground.ResumeLayout(false);
                gridView.RefreshData();
                Cursor = Cursors.Default;
            }
            return;
        }
        private void btnSetDiscount_Click(object sender, EventArgs e)
        {
            try
            {
                SenDiscountPercent(System.Convert.ToDouble(spinEditDiscount.Value));
            }
            catch (System.Exception f)
            {
                SendMessageToLog("btnSetDiscount_Click. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.tableLayoutPanelBackground.ResumeLayout(false);
                gridView.RefreshData();
                Cursor = Cursors.Default;
            }
            return;
        }

        private void SetCustomTarifPercent(System.Double dblCustomTarifPercent)
        {
            try
            {
                tableLayoutPanelBackground.SuspendLayout();

                if (gridView.RowCount == 0) { return; }

                Cursor = Cursors.WaitCursor;

                for (System.Int32 i = 0; i < gridView.RowCount; i++)
                {
                    gridView.SetRowCellValue(i, colCustomTarifPercent, dblCustomTarifPercent);
                }

            }
            catch (System.Exception f)
            {
                SendMessageToLog("SetCustomTarifPercent. Текст ошибки: " + f.Message);
            }
            finally
            {
                tableLayoutPanelBackground.ResumeLayout(false);
                gridView.RefreshData();
                Cursor = Cursors.Default;
            }
            return;
        }

        private void btnSetCustomTarif_Click(object sender, EventArgs e)
        {
            try
            {
                SetCustomTarifPercent(System.Convert.ToDouble(spinEditCustomTarif.Value));
            }
            catch (System.Exception f)
            {
                SendMessageToLog("btnSetCustomTarif_Click. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.tableLayoutPanelBackground.ResumeLayout(false);
                gridView.RefreshData();
                Cursor = Cursors.Default;
            }
            return;
        }

        #endregion

        #region Выпадающие списки
        /// <summary>
        /// Обновление выпадающих списков
        /// </summary>
        /// <returns>true - все списки успешно обновлены; false - ошибка</returns>
        private System.Boolean LoadComboBoxItems()
        {
            System.Boolean bRet = false;
            try
            {
                cboxVendor.Properties.Items.Clear();
                cboxVendor.Properties.Items.AddRange(m_objVendorList);

                cboxProductTradeMark.Properties.Items.Clear();
                cboxProductType.Properties.Items.Clear();

                // Валюты
                cboxCurrency.Properties.Items.Clear();
                cboxCurrency.Properties.Items.AddRange( ERP_Mercury.Common.CCurrency.GetCurrencyList( m_objProfile, null));

                // Состояния заказа
                cboxLotOrderState.Properties.Items.Clear();
                cboxLotOrderState.Properties.Items.AddRange(ERP_Mercury.Common.CLotOrderState.GetLotOrderStateList(m_objProfile, null));

                // Товары
                dataSet.Tables["Product"].Clear();
                repositoryItemLookUpEditProduct.DataSource = dataSet.Tables["Product"];

                // страны производства
                cboxCountryProduction.Properties.Items.Clear();
                dataSet.Tables["CountryProduction"].Clear();
                List<ERP_Mercury.Common.CCountry> objCountryProductionList = ERP_Mercury.Common.CCountry.GetCountryList(m_objProfile, null);
                if ((objCountryProductionList != null) && (objCountryProductionList.Count > 0))
                {
                    cboxCountryProduction.Properties.Items.AddRange(objCountryProductionList);
                    System.Data.DataRow newRowCountryProduction = null;
                    foreach (ERP_Mercury.Common.CCountry objItem in objCountryProductionList)
                    {
                        newRowCountryProduction = dataSet.Tables["CountryProduction"].NewRow();

                        newRowCountryProduction["CountryProductionID"] = objItem.ID;
                        newRowCountryProduction["CountryProductionName"] = objItem.Name;

                        dataSet.Tables["CountryProduction"].Rows.Add(newRowCountryProduction);
                    }
                    newRowCountryProduction = null;
                    dataSet.Tables["CountryProduction"].AcceptChanges();


                }
                objCountryProductionList = null;

                repositoryItemLookUpEditCountryProduction.DataSource = dataSet.Tables["CountryProduction"];
                cboxCountryProduction.SelectedItem = ((cboxCountryProduction.Properties.Items.Count > 0) ? cboxCountryProduction.Properties.Items[0] : null);

                bRet = true;
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка обновления выпадающих списков. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return bRet;
        }
        /// <summary>
        /// Фильтрует выпадающий список с товарами
        /// </summary>
        private void SetFilterForPartsCombo()
        {
            try
            {
                if (gridView.RowCount > 0)
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("В результате применения фильтра будут удалены товары в заказе,\nне соответствующие заданным условиям.\nУстановить фильтр?", "Внимание",
                        System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        cboxProductTradeMark.SelectedValueChanged -= new EventHandler(cboxOrderPropertie_SelectedValueChanged);
                        cboxProductType.SelectedValueChanged -= new EventHandler(cboxOrderPropertie_SelectedValueChanged);

                        cboxProductTradeMark.SelectedItem = null;
                        cboxProductType.SelectedItem = null;

                        cboxProductTradeMark.SelectedValueChanged += new EventHandler(cboxOrderPropertie_SelectedValueChanged);
                        cboxProductType.SelectedValueChanged += new EventHandler(cboxOrderPropertie_SelectedValueChanged);

                        return;
                    }
                }
                System.Guid TradeMarkId = ((cboxProductTradeMark.SelectedItem == null) ? System.Guid.Empty : ((ERP_Mercury.Common.CProductTradeMark)cboxProductTradeMark.SelectedItem).ID);
                System.Guid PartTypeId = ((cboxProductType.SelectedItem == null) ? System.Guid.Empty : ((ERP_Mercury.Common.CProductType)cboxProductType.SelectedItem).ID);

                tableLayoutPanelBackground.SuspendLayout();

                List<ERP_Mercury.Common.CProduct> FilteredProductList = m_objPartsList;

                if (TradeMarkId != System.Guid.Empty)
                {
                    FilteredProductList = FilteredProductList.Where<ERP_Mercury.Common.CProduct>(x => x.ProductTradeMark.ID == TradeMarkId).ToList<ERP_Mercury.Common.CProduct>();
                }

                if (PartTypeId != System.Guid.Empty)
                {
                    FilteredProductList = FilteredProductList.Where<ERP_Mercury.Common.CProduct>(x => x.ProductType.ID == PartTypeId).ToList<ERP_Mercury.Common.CProduct>();
                }

                if (FilteredProductList.Count != m_objPartsList.Count)
                {
                    dataSet.Tables["Product"].Clear();

                    System.Data.DataRow newRowProduct = null;
                    dataSet.Tables["Product"].Clear();
                    foreach (ERP_Mercury.Common.CProduct objItem in FilteredProductList)
                    {
                        newRowProduct = dataSet.Tables["Product"].NewRow();

                        newRowProduct["ProductID"] = objItem.ID;
                        newRowProduct["Product_MeasureID"] = objItem.Measure.ID;
                        newRowProduct["Product_MeasureName"] = objItem.Measure.ShortName;
                        newRowProduct["ProductFullName"] = objItem.ProductFullName;
                        newRowProduct["ProductShortName"] = objItem.Name;
                        newRowProduct["ProductArticle"] = objItem.Article;
                        newRowProduct["CustomerOrderPackQty"] = objItem.CustomerOrderPackQty;

                        dataSet.Tables["Product"].Rows.Add(newRowProduct);
                    }
                    newRowProduct = null;
                    dataSet.Tables["Product"].AcceptChanges();
                }

                // теперь нужно проверить содержимое заказа на предмет товаров, не попадающих под условия фильтра
                if ((gridView.RowCount > 0) && ((TradeMarkId != System.Guid.Empty) || (PartTypeId != System.Guid.Empty)))
                {
                    System.Guid PartsGuid = System.Guid.Empty;
                    ERP_Mercury.Common.CProduct objProduct = null;
                    System.Boolean bOk = true;
                    for (System.Int32 i = (gridView.RowCount - 1); i >= 0; i--)
                    {
                        PartsGuid = (System.Guid)(gridView.GetDataRow(i)["ProductID"]);
                        bOk = true;
                        try
                        {
                            objProduct = m_objPartsList.Single<ERP_Mercury.Common.CProduct>(x => x.ID == PartsGuid);
                        }
                        catch
                        {
                            objProduct = null;
                        }
                        if (objProduct != null)
                        {
                            // проверяем на соответствие марке
                            if (TradeMarkId != System.Guid.Empty)
                            {
                                bOk = (objProduct.ProductTradeMark.ID == TradeMarkId);
                            }
                            if ((bOk == true) && (PartTypeId != System.Guid.Empty))
                            {
                                bOk = (objProduct.ProductTradeMark.ID == PartTypeId);
                            }
                        }
                        if (bOk == false)
                        {
                            gridView.DeleteRow(i);
                        }
                    }

                    objProduct = null;

                }

            }
            catch (System.Exception f)
            {
                SendMessageToLog("SetFilterForPartsCombo. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.tableLayoutPanelBackground.ResumeLayout(false);
            }
            return;
        }

        #endregion

        #region Потоки
        /// <summary>
        /// Создает форму со списком товара
        /// </summary>
        /// <param name="objPartsList">списком товара</param>
        private void SetProductListToForm(List<ERP_Mercury.Common.CProduct> objPartsList)
        {
            try
            {
                m_objPartsList = objPartsList;

                System.Data.DataRow newRowProduct = null;
                dataSet.Tables["Product"].Clear();
                foreach (ERP_Mercury.Common.CProduct objItem in m_objPartsList)
                {
                    newRowProduct = dataSet.Tables["Product"].NewRow();
                    newRowProduct["ProductID"] = objItem.ID;
                    newRowProduct["Product_MeasureID"] = objItem.Measure.ID;
                    newRowProduct["Product_MeasureName"] = objItem.Measure.ShortName;
                    newRowProduct["ProductFullName"] = objItem.ProductFullName;
                    newRowProduct["ProductShortName"] = objItem.Name;
                    newRowProduct["ProductArticle"] = objItem.Article;
                    newRowProduct["CustomerOrderPackQty"] = objItem.CustomerOrderPackQty;


                    dataSet.Tables["Product"].Rows.Add(newRowProduct);
                }
                newRowProduct = null;
                dataSet.Tables["Product"].AcceptChanges();

            }
            catch (System.Exception f)
            {
                SendMessageToLog("SetProductListToForm. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return;
        }

        /// <summary>
        /// загружает список товаров и список новых товаров
        /// </summary>
        private void LoadPartssList()
        {
            try
            {
                // товары
                m_objPartsList = ERP_Mercury.Common.CProduct.GetProductList( m_objProfile, null, false, true );
                if (m_objPartsList != null)
                {
                    this.Invoke(m_SetProductListToFormDelegate, new Object[] { m_objPartsList });
                }
            }
            catch (System.Exception f)
            {
                this.Invoke(m_SendMessageToLogDelegate, new Object[] { ("Ошибка обновления списка товаров. Текст ошибки: " + f.Message) });
            }
            finally
            {
                EventStopThread.Set();
            }

            return;
        }

        public void StartThreadWithLoadData()
        {
            try
            {
                // инициализируем события
                this.m_EventStopThread = new System.Threading.ManualResetEvent(false);
                this.m_EventThreadStopped = new System.Threading.ManualResetEvent(false);

                // инициализируем делегаты
                m_LoadPartsListDelegate = new LoadPartsListDelegate(LoadPartssList);
                m_SetProductListToFormDelegate = new SetProductListToFormDelegate(SetProductListToForm);
                m_SendMessageToLogDelegate = new SendMessageToLogDelegate(SendMessageToLog);

                // запуск потока
                StartThread();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("StartThreadWithLoadData().\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void StartThread()
        {
            try
            {
                // делаем событиям reset
                this.m_EventStopThread.Reset();
                this.m_EventThreadStopped.Reset();

                this.thrAddress = new System.Threading.Thread(WorkerThreadFunction);
                this.thrAddress.Start();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("StartThread().\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        public void WorkerThreadFunction()
        {
            try
            {
                Run();
            }
            catch (System.Exception e)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("WorkerThreadFunction\n" + e.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
            }
            return;
        }

        public void Run()
        {
            try
            {
                LoadPartssList();

                // пока заполняется список товаров будем проверять, не было ли сигнала прекратить все это
                while (this.m_bThreadFinishJob == false)
                {
                    // проверим, а не попросили ли нас закрыться
                    if (this.m_EventStopThread.WaitOne(iThreadSleepTime, true))
                    {
                        this.m_EventThreadStopped.Set();
                        break;
                    }
                }

            }
            catch (System.Exception e)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Run\n" + e.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
            }
            return;
        }
        /// <summary>
        /// Делает пометку о необходимости остановить поток
        /// </summary>
        public void TreadIsFree()
        {
            try
            {
                this.m_bThreadFinishJob = true;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("StopPleaseTread() " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
            }
            return;
        }

        private System.Boolean bIsThreadsActive()
        {
            System.Boolean bRet = false;
            try
            {
                bRet = (
                    ((ThreadAddress != null) && (ThreadAddress.IsAlive == true))
                    );
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("bIsThreadsActive.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bRet;
        }

        private void CloseThreadInAddressEditor()
        {
            try
            {
                if (bIsThreadsActive() == true)
                {
                    if ((ThreadAddress != null) && (ThreadAddress.IsAlive == true))
                    {
                        EventStopThread.Set();
                    }
                }
                while (bIsThreadsActive() == true)
                {
                    if (System.Threading.WaitHandle.WaitAll((new System.Threading.ManualResetEvent[] { EventThreadStopped }), 100, true))
                    {
                        break;
                    }
                    Application.DoEvents();
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("bIsThreadsActive.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        #endregion

        #region Режим просмотра/редактирования
        /// <summary>
        /// Устанавливает режим просмотра/редактирования
        /// </summary>
        /// <param name="bSet">true - режим просмотра; false - режим редактирования</param>
        private void SetModeReadOnly(System.Boolean bSet)
        {
            try
            {
                BeginDate.Properties.ReadOnly = bSet;
                DeliveryDate.Properties.ReadOnly = bSet;
                txtDescription.Properties.ReadOnly = bSet;
                txtLotOrderNum.Properties.ReadOnly = bSet;

                cboxVendor.Properties.ReadOnly = bSet;
                cboxLotOrderState.Properties.ReadOnly = bSet;
                cboxCurrency.Properties.ReadOnly = bSet;
                cboxCountryProduction.Properties.ReadOnly = bSet;

                cboxProductTradeMark.Properties.ReadOnly = bSet;
                cboxProductType.Properties.ReadOnly = bSet;
                spinEditDiscount.Properties.ReadOnly = bSet;
                spinEditCustomTarif.Properties.ReadOnly = bSet;
                btnSetDiscount.Enabled = !bSet;
                btnSetCustomTarif.Enabled = !bSet;
                checkMultiplicity.Properties.ReadOnly = bSet;
                checkLotOrderActive.Properties.ReadOnly = bSet;

                gridView.OptionsBehavior.Editable = !bSet;

                mitemImport.Enabled = !bSet;
                mitemRefreshPrices.Enabled = !bSet;
                mitemClearPrice.Enabled = !bSet;

                m_bIsReadOnly = bSet;

                btnEdit.Enabled = bSet;

                lblEditMode.Text = ((bSet == true) ? m_strModeReadOnly : m_strModeEdit );
            }
            catch (System.Exception f)
            {
                SendMessageToLog("SetModeReadOnly. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Refresh();

                SetModeReadOnly(false);
                btnEdit.Enabled = false;
                SetPropertiesModified(true);

                StartThreadWithLoadData();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("SetModeReadOnly. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }
        #endregion

        #region Редактировать заказ
        /// <summary>
        /// очистка содержимого элементов управления
        /// </summary>
        private void ClearControls()
        {
            try
            {
                txtDescription.Text = "";
                txtLotOrderNum.Text = "";
                cboxCurrency.SelectedItem = null;
                cboxVendor.SelectedItem = null;
                cboxLotOrderState.SelectedItem = null;
                cboxCountryProduction.SelectedItem = null;
                checkLotOrderActive.Checked = false;

                cboxProductTradeMark.SelectedItem = null;
                cboxProductType.SelectedItem = null;
                spinEditDiscount.Value = 0;
                spinEditCustomTarif.Value = 0;

                dataSet.Tables["OrderItems"].Clear();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("ClearControls. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        private void LoadOrderItemsListToDataSet()
        {
            try
            {
                dataSet.Tables["Product"].Clear();
                System.Data.DataRow newRowProduct = null;

                foreach (CLotOrderItems objItem in m_objSelectedOrder.LotOrderItemsList)
                {
                    newRowProduct = dataSet.Tables["Product"].NewRow();
                    newRowProduct["ProductID"] = objItem.Product.ID;
                    newRowProduct["Product_MeasureID"] = objItem.Measure.ID;
                    newRowProduct["Product_MeasureName"] = objItem.Measure.ShortName;
                    newRowProduct["ProductFullName"] = objItem.Product.ProductFullName;
                    newRowProduct["ProductShortName"] = objItem.Product.Name;
                    newRowProduct["ProductArticle"] = objItem.Product.Article;
                    newRowProduct["CustomerOrderPackQty"] = 1;

                    dataSet.Tables["Product"].Rows.Add(newRowProduct);

                }
                newRowProduct = null;
                dataSet.Tables["Product"].AcceptChanges();

                dataSet.Tables["OrderItems"].Clear();
                System.Data.DataRow newRowOrderItems = null;
                ERP_Mercury.Common.CProduct objProduct = null;

                foreach (CLotOrderItems objItem in m_objSelectedOrder.LotOrderItemsList)
                {
                    newRowOrderItems = dataSet.Tables["OrderItems"].NewRow();

                    newRowOrderItems["OrderItemsID"] = objItem.ID;
                    newRowOrderItems["ProductID"] = objItem.Product.ID;
                    newRowOrderItems["MeasureID"] = objItem.Measure.ID;
                    newRowOrderItems["OrderedQuantity"] = objItem.QuantityOrder;
                    newRowOrderItems["ConfirmQuantity"] = objItem.QuantityConfirm;
                    newRowOrderItems["QuantityInDoc"] = objItem.Quantity;
                    newRowOrderItems["CountryProductionID"] = objItem.CountryProduction.ID;

                    if (m_objPartsList != null)
                    {
                        try
                        {
                            objProduct = m_objPartsList.Single<ERP_Mercury.Common.CProduct>(x => x.ID.CompareTo(objItem.Product.ID) == 0);
                        }
                        catch
                        {
                            objProduct = null;
                        }
                        if (objProduct != null)
                        {
                            newRowOrderItems["OrderPackQty"] = objProduct.CustomerOrderPackQty;
                        }
                    }

                    newRowOrderItems["OrderItems_MeasureName"] = objItem.Measure.ShortName;
                    newRowOrderItems["OrderItems_PartsName"] = objItem.Product.Name;
                    newRowOrderItems["OrderItems_PartsArticle"] = objItem.Product.Article;
                    newRowOrderItems["OrderItems_CountryProductionName"] = objItem.CountryProduction.Name;
                    newRowOrderItems["VendorPrice"] = objItem.PriceVendorTarif;
                    newRowOrderItems["CustomTarifPercent"] = objItem.CustomTarifPercent;

                    newRowOrderItems["DiscountPercent"] = objItem.DiscountPercent;
//                    newRowOrderItems["DiscountPercent"] = (((m_bNewObject == true) && (m_objSelectedOrder.ID == System.Guid.Empty)) ? 0 : objItem.DiscountPercent);

                    newRowOrderItems["VendorPriceWithDiscount"] = objItem.PriceVendorTarifWithDiscount;
                    newRowOrderItems["PriceForCalcCostPrice"] = objItem.PriceForCalcCostPrice;
                    newRowOrderItems["Product_VendorPrice"] = objItem.PriceVendorTarifInDirectory;
                    newRowOrderItems["Product_Weight"] = objItem.ProductWeightInDirectory;

                    if (objItem.ExpirationDare != System.DateTime.MinValue )
                    {
                        newRowOrderItems["ExpirationDate"] = objItem.ExpirationDare;
                    }

                    dataSet.Tables["OrderItems"].Rows.Add(newRowOrderItems);
                }
                newRowOrderItems = null;
                objProduct = null;

                dataSet.Tables["OrderItems"].AcceptChanges();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("LoadOrderItemsListToDataSet. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        /// <summary>
        /// Загружает свойства заказа для редактирования
        /// </summary>
        /// <param name="objOrder">заказ</param>
        /// <param name="bNewObject">признак "новый заказ"</param>
        public void EditOrder(CLotOrder objOrder, System.Boolean bNewObject)
        {
            if (objOrder == null) { return; }
            m_bDisableEvents = true;
            m_bNewObject = bNewObject;
            try
            {
                m_objSelectedOrder = objOrder;

                this.tableLayoutPanelBackground.SuspendLayout();

                ClearControls();

                txtLotOrderNum.Text = m_objSelectedOrder.Number;
                BeginDate.DateTime = m_objSelectedOrder.Date;
                DeliveryDate.DateTime = m_objSelectedOrder.DateStockPrognostic;
                ShipDate.DateTime = m_objSelectedOrder.DateShip;
                txtDescription.Text = m_objSelectedOrder.Description;
                checkLotOrderActive.Checked = m_objSelectedOrder.IsActive;

                cboxVendor.SelectedItem = (m_objSelectedOrder.Vendor == null) ? null : cboxVendor.Properties.Items.Cast<ERP_Mercury.Common.CVendor>().Single<ERP_Mercury.Common.CVendor>(x => x.ID.CompareTo(m_objSelectedOrder.Vendor.ID) == 0);
                cboxCurrency.SelectedItem = (m_objSelectedOrder.Currency == null) ? null : cboxCurrency.Properties.Items.Cast<ERP_Mercury.Common.CCurrency>().Single<ERP_Mercury.Common.CCurrency>(x => x.ID.CompareTo(m_objSelectedOrder.Currency.ID) == 0);

                cboxLotOrderState.Properties.Items.Clear();
                cboxLotOrderState.Properties.Items.AddRange(ERP_Mercury.Common.CLotOrderState.GetLotOrderStateList(m_objProfile, null, m_objSelectedOrder.ID));
                cboxLotOrderState.SelectedItem = (m_objSelectedOrder.CurrentLotorderState == null) ? null : cboxLotOrderState.Properties.Items.Cast<ERP_Mercury.Common.CLotOrderState>().Single<ERP_Mercury.Common.CLotOrderState>(x => x.ID.CompareTo(m_objSelectedOrder.CurrentLotorderState.ID) == 0);

                cboxProductTradeMark.Properties.Items.Add(new ERP_Mercury.Common.CProductTradeMark() { ID = System.Guid.Empty, Name = "" });
                cboxProductTradeMark.Properties.Items.AddRange(ERP_Mercury.Common.CProductTradeMark.GetProductTradeMarkList(m_objProfile, null));
                cboxProductType.Properties.Items.Add(new ERP_Mercury.Common.CProductType() { ID = System.Guid.Empty, Name = "" });
                cboxProductType.Properties.Items.AddRange(ERP_Mercury.Common.CProductType.GetProductTypeList(m_objProfile, null));

                LoadOrderItemsListToDataSet();

                SetPropertiesModified(false);
                ValidateProperties();

                SetModeReadOnly(true);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка редактирования заказа поставщику. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.tableLayoutPanelBackground.ResumeLayout(false);
                m_bDisableEvents = false;
                btnCancel.Enabled = true;
            }
            return;
        }
        #endregion

        #region Копирование заказа
        /// <summary>
        /// Копирует свойства заказа в новый заказ и открывает его для редактирования
        /// </summary>
        /// <param name="objOrder">заказ</param>
        public void CopyOrder(CLotOrder objOrder)
        {
            if (objOrder == null) { return; }

            try
            {
                m_objSelectedOrder = new CLotOrder();
                m_objSelectedOrder.Date = System.DateTime.Today;
                m_objSelectedOrder.DateStockPrognostic = System.DateTime.Today;
                m_objSelectedOrder.Description = objOrder.Description;
                m_objSelectedOrder.Vendor = objOrder.Vendor;
                m_objSelectedOrder.Currency = objOrder.Currency;
                m_objSelectedOrder.IsActive = true;

                System.Int32 iRes = 0;
                System.String strErr = "";

                m_objSelectedOrder.LotOrderItemsList = CLotOrderRepository.GetLotOrderItemsList(m_objProfile, null, objOrder.ID, ref iRes, ref strErr);

                EditOrder(m_objSelectedOrder, true);

                SetModeReadOnly(false);
                gridControl.RefreshDataSource();
                gridView.RefreshData();

                StartThreadWithLoadData();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка копирования заказа поставщику. Текст ошибки: " + f.Message);
            }
            finally
            {
                m_bNewObject = true;
                m_objSelectedOrder.ID = System.Guid.Empty;
                btnSave.Enabled = (ValidateProperties() == true);
            }
            return;
        }

        #endregion

        #region Новый заказ
        /// <summary>
        /// Новый заказ
        /// </summary>
        public void NewOrder(ERP_Mercury.Common.CVendor objVendor)
        {
            try
            {
                m_bNewObject = true;
                m_bDisableEvents = true;

                m_objSelectedOrder = new CLotOrder();
                m_objSelectedOrder.LotOrderItemsList = new List<CLotOrderItems>();
                m_objSelectedOrder.Vendor = objVendor;
                m_objSelectedOrder.DateShip = System.DateTime.Today;

                this.tableLayoutPanelBackground.SuspendLayout();

                ClearControls();

                txtDescription.Text = m_objSelectedOrder.Description;
                checkLotOrderActive.Checked = true;
                cboxVendor.SelectedItem = (m_objSelectedOrder.Vendor == null) ? null : cboxVendor.Properties.Items.Cast<ERP_Mercury.Common.CVendor>().Single<ERP_Mercury.Common.CVendor>(x => x.ID.CompareTo(m_objSelectedOrder.Vendor.ID) == 0);
                cboxCurrency.SelectedItem = (m_objSelectedOrder.Currency == null) ? null : cboxCurrency.Properties.Items.Cast<ERP_Mercury.Common.CCurrency>().Single<ERP_Mercury.Common.CCurrency>(x => x.ID.CompareTo(m_objSelectedOrder.Currency.ID) == 0);

                cboxLotOrderState.Properties.Items.Clear();
                cboxLotOrderState.Properties.Items.AddRange(ERP_Mercury.Common.CLotOrderState.GetLotOrderStateList(m_objProfile, null, m_objSelectedOrder.ID));
                cboxLotOrderState.SelectedItem = (cboxLotOrderState.Properties.Items.Count == 0) ? null : cboxLotOrderState.Properties.Items[0];
                //cboxLotOrderState.SelectedItem = (m_objSelectedOrder.CurrentLotorderState == null) ? null : cboxLotOrderState.Properties.Items.Cast<ERP_Mercury.Common.CLotOrderState>().Single<ERP_Mercury.Common.CLotOrderState>(x => x.ID.CompareTo(m_objSelectedOrder.CurrentLotorderState.ID) == 0);

                cboxProductTradeMark.Properties.Items.Add(new ERP_Mercury.Common.CProductTradeMark() { ID = System.Guid.Empty, Name = "" });
                cboxProductTradeMark.Properties.Items.AddRange(ERP_Mercury.Common.CProductTradeMark.GetProductTradeMarkList(m_objProfile, null));
                cboxProductType.Properties.Items.Add(new ERP_Mercury.Common.CProductType() { ID = System.Guid.Empty, Name = "" });
                cboxProductType.Properties.Items.AddRange(ERP_Mercury.Common.CProductType.GetProductTypeList(m_objProfile, null));

                cboxCountryProduction.SelectedItem = ((cboxCountryProduction.Properties.Items.Count > 0) ? cboxCountryProduction.Properties.Items[0] : null);

                btnEdit.Enabled = false;
                btnCancel.Enabled = true;

                SetModeReadOnly(false);
                SetPropertiesModified(true);

                StartThreadWithLoadData();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка создания заказа поставщику. Текст ошибки: " + f.Message);
            }
            finally
            {
                tableLayoutPanelBackground.ResumeLayout(false);
                m_bDisableEvents = false;
            }
            return;
        }

        #endregion

        #region Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Cancel();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка отмены изменений. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return;
        }
        /// <summary>
        /// Отмена внесенных изменений
        /// </summary>
        private void Cancel()
        {
            try
            {
                SimulateChangeOrderProperties(m_objSelectedOrder, ERP_Mercury.Common.enumActionSaveCancel.Cancel, m_bNewObject);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка отмены изменений. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return;

        }
        #endregion

        #region Сохранить изменения
        /// <summary>
        /// Сохраняет изменения в базе данных
        /// </summary>
        /// <returns>true - удачное завершение операции;false - ошибка</returns>
        private System.Boolean bSaveChanges(ref System.String strErr)
        {
            System.Boolean bRet = false;
            System.Boolean bOkSave = false;
            Cursor = Cursors.WaitCursor;
            try
            {

                System.String LotOrder_Num = txtLotOrderNum.Text;
                System.DateTime LotOrder_Date = BeginDate.DateTime; 
                System.DateTime LotOrder_StockDate = DeliveryDate.DateTime;
                System.DateTime LotOrder_ShipDate = ShipDate.DateTime;
                System.Guid Vendor_Guid = (( cboxVendor.SelectedItem == null) ? (System.Guid.Empty) : ((ERP_Mercury.Common.CVendor)cboxVendor.SelectedItem).ID);
                System.Guid Currency_Guid = (( cboxCurrency.SelectedItem == null) ? (System.Guid.Empty) : ((ERP_Mercury.Common.CCurrency)cboxCurrency.SelectedItem).ID);
                System.Guid LotOrderState_Guid = ((cboxLotOrderState.SelectedItem == null) ? (System.Guid.Empty) : ((ERP_Mercury.Common.CLotOrderState)cboxLotOrderState.SelectedItem).ID);
                System.String LotOrder_Description = txtDescription.Text; 
                System.Boolean LotOrder_IsActive = checkLotOrderActive.Checked;


                System.Guid LotOrder_Guid = ( ( m_bNewObject == true ) ? System.Guid.Empty : m_objSelectedOrder.ID ); 
                System.Double LotOrder_AllPrice = 0; 
                System.Double LotOrder_AllDiscount = 0;
                System.Double LotOrder_TotalPrice = 0;   

                List<CLotOrderItems> objOrderItemList = new List<CLotOrderItems>();

                System.Guid uuidOrderItmsID = System.Guid.Empty;
                System.Guid uuidProductID = System.Guid.Empty;
                System.Guid uuidMeasureID = System.Guid.Empty;
                System.Guid uuidCountryProductionID = System.Guid.Empty;
                System.Double dblQuantityOrdered = 0;
                System.Double dblQuantityConfirm = 0;
                System.Double dblQuantity = 0;
                System.Double dblPriceVendorTarif = 0;
                System.Double dblDiscountPercent = 0;
                System.Double dblPriceVendorTarifWithDiscount = 0;
                System.Double dblPriceForCalcCostPrice = 0;
                System.DateTime dtExpirationDate = System.DateTime.MinValue;
                System.Double dblCustomTarifPercent = 0;

                dataSet.Tables["OrderItems"].AcceptChanges();

                for (System.Int32 i = 0; i < dataSet.Tables["OrderItems"].Rows.Count; i++)
                {
                    if ((dataSet.Tables["OrderItems"].Rows[i]["ProductID"] == System.DBNull.Value) ||
                        (dataSet.Tables["OrderItems"].Rows[i]["MeasureID"] == System.DBNull.Value) ||
                        (dataSet.Tables["OrderItems"].Rows[i]["CountryProductionID"] == System.DBNull.Value) ||
                        (dataSet.Tables["OrderItems"].Rows[i]["OrderedQuantity"] == System.DBNull.Value))
                    {
                        continue;
                    }
                    if (m_bNewObject == true)
                    {
                        uuidOrderItmsID = System.Guid.NewGuid();
                    }
                    else
                    {
                        uuidOrderItmsID = ((dataSet.Tables["OrderItems"].Rows[i]["OrderItemsID"] == System.DBNull.Value) ? System.Guid.NewGuid() : (System.Guid)(dataSet.Tables["OrderItems"].Rows[i]["OrderItemsID"]));
                    }
                    uuidProductID = (System.Guid)(dataSet.Tables["OrderItems"].Rows[i]["ProductID"]);
                    uuidMeasureID = (System.Guid)(dataSet.Tables["OrderItems"].Rows[i]["MeasureID"]);
                    uuidCountryProductionID = (System.Guid)(dataSet.Tables["OrderItems"].Rows[i]["CountryProductionID"]);
                    dblQuantityOrdered = System.Convert.ToDouble(dataSet.Tables["OrderItems"].Rows[i]["OrderedQuantity"]);
                    dblQuantityConfirm = System.Convert.ToDouble(dataSet.Tables["OrderItems"].Rows[i]["ConfirmQuantity"]);
                    dblQuantity = System.Convert.ToDouble(dataSet.Tables["OrderItems"].Rows[i]["QuantityInDoc"]);
                    dblPriceVendorTarif = System.Convert.ToDouble(dataSet.Tables["OrderItems"].Rows[i]["VendorPrice"]);
                    dblDiscountPercent = System.Convert.ToDouble(dataSet.Tables["OrderItems"].Rows[i]["DiscountPercent"]);
                    dblPriceVendorTarifWithDiscount = System.Convert.ToDouble(dataSet.Tables["OrderItems"].Rows[i]["VendorPriceWithDiscount"]);
                    dtExpirationDate = ((dataSet.Tables["OrderItems"].Rows[i]["ExpirationDate"] == System.DBNull.Value) ? System.DateTime.MinValue : System.Convert.ToDateTime((dataSet.Tables["OrderItems"].Rows[i]["ExpirationDate"])) );
                    dblCustomTarifPercent = System.Convert.ToDouble(dataSet.Tables["OrderItems"].Rows[i]["CustomTarifPercent"]);
                    dblPriceForCalcCostPrice = System.Convert.ToDouble(dataSet.Tables["OrderItems"].Rows[i]["PriceForCalcCostPrice"]);

                    objOrderItemList.Add(new CLotOrderItems()
                    {
                        ID = uuidOrderItmsID,
                        Product = new ERP_Mercury.Common.CProduct() { ID = uuidProductID },
                        Measure = new ERP_Mercury.Common.CMeasure() { ID = uuidMeasureID },
                        CountryProduction = new ERP_Mercury.Common.CCountry() { ID = uuidCountryProductionID },
                        QuantityOrder = dblQuantityOrdered,
                        QuantityConfirm = dblQuantityConfirm,
                        Quantity = dblQuantity,
                        PriceVendorTarif = dblPriceVendorTarif,
                        DiscountPercent = dblDiscountPercent,
                        PriceVendorTarifWithDiscount = dblPriceVendorTarifWithDiscount,
                        ExpirationDare = dtExpirationDate,
                        CustomTarifPercent = dblCustomTarifPercent,
                        PriceForCalcCostPrice = dblPriceForCalcCostPrice
                    });
                }
                System.Data.DataTable addedItems = ((gridControl.DataSource == null) ? null : CLotOrderItems.ConvertListToTable(objOrderItemList, LotOrder_Guid, ref strErr) );
                objOrderItemList = null;

                // проверка значений
                if( CLotOrderRepository.CheckAllPropertiesForSave(LotOrder_Date, Vendor_Guid, Currency_Guid, LotOrderState_Guid,
                     addedItems, ref strErr) == true)
                {
                    if (m_bNewObject == true)
                    {
                        // новый заказ
                        System.Guid uuidOrderId = System.Guid.Empty;
                        System.Int32 iSupplId = 0;
                        bOkSave = CLotOrderRepository.AddLotOrder(m_objProfile, null, LotOrder_Num, LotOrder_Date, LotOrder_ShipDate, LotOrder_StockDate,
                            Vendor_Guid, Currency_Guid, LotOrder_Description, LotOrder_IsActive, LotOrderState_Guid, addedItems, 
                            ref LotOrder_Guid, ref iSupplId, ref LotOrder_AllPrice, ref LotOrder_AllDiscount, 
                            ref LotOrder_TotalPrice, ref strErr);
                        if (bOkSave == true)
                        {
                            m_objSelectedOrder.ID = uuidOrderId;
                            m_objSelectedOrder.Ib_ID = iSupplId;
                        }
                    }
                    else
                    {
                        bOkSave = CLotOrderRepository.EditLotOrder(m_objProfile, null, LotOrder_Num, LotOrder_Date, LotOrder_ShipDate, LotOrder_StockDate,
                            Vendor_Guid, Currency_Guid, LotOrder_Description, LotOrder_IsActive, LotOrderState_Guid, addedItems, 
                            LotOrder_Guid, ref LotOrder_AllPrice, ref LotOrder_AllDiscount,
                            ref LotOrder_TotalPrice, ref strErr);
                    }
                }

                if (bOkSave == true)
                {
                    m_objSelectedOrder.Number = LotOrder_Num;
                    m_objSelectedOrder.Date = LotOrder_Date;
                    m_objSelectedOrder.DateShip = LotOrder_ShipDate;
                    m_objSelectedOrder.DateStockPrognostic = LotOrder_StockDate;
                    m_objSelectedOrder.Vendor = ((cboxVendor.SelectedItem == null) ? null : (ERP_Mercury.Common.CVendor)cboxVendor.SelectedItem);
                    m_objSelectedOrder.Currency = ((cboxCurrency.SelectedItem == null) ? null : (ERP_Mercury.Common.CCurrency)cboxCurrency.SelectedItem);
                    m_objSelectedOrder.Description = LotOrder_Description;
                }

                bRet = bOkSave;
            }
            catch (System.Exception f)
            {
                strErr = f.Message;
                SendMessageToLog("Ошибка сохранения изменений в заказе. Текст ошибки: " + f.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return bRet;
        }

        private System.Boolean ChangeLotOrderSate(ref System.String strErr)
        {
            System.Boolean bRes = false;
            try
            {

                if (m_bNewObject == false)
                {
                    System.Guid LotOrder_Guid = ((m_bNewObject == true) ? System.Guid.Empty : m_objSelectedOrder.ID);
                    System.Guid LotOrderState_Guid = ((cboxLotOrderState.SelectedItem == null) ? (System.Guid.Empty) : ((ERP_Mercury.Common.CLotOrderState)cboxLotOrderState.SelectedItem).ID);
                    System.Int32 LotOrder_Id = m_objSelectedOrder.Ib_ID;

                    // теперь вносим изменения в состояние заказа
                    bRes = CLotOrderRepository.ChangeLotOrderSate(m_objProfile, null, LotOrder_Guid, LotOrderState_Guid,
                        ref strErr, ref LotOrder_Id);
                    if (bRes == true)
                    {
                        m_objSelectedOrder.CurrentLotorderState = ((cboxLotOrderState.SelectedItem == null) ? null : (ERP_Mercury.Common.CLotOrderState)cboxLotOrderState.SelectedItem);
                        m_objSelectedOrder.Ib_ID = LotOrder_Id;
                    }

                }
                else
                {
                    bRes = true;
                }
            }
            catch (System.Exception f)
            {
                strErr = f.Message;
                SendMessageToLog("Ошибка сохранения изменения состояния заказа. Текст ошибки: " + f.Message);
            }

            return bRes;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                System.String strErr = "";
                if (bSaveChanges(ref strErr) == true)
                {
                    // теперь состояние заказа
                    strErr = "";
                    if (ChangeLotOrderSate(ref strErr) == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Изменения в заказе успешно сохранены за исключением состояния заказа\n" + strErr, "Внимание",
                             System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    }

                    SimulateChangeOrderProperties(m_objSelectedOrder, ERP_Mercury.Common.enumActionSaveCancel.Save, m_bNewObject);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(strErr, "Внимание",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }

            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка сохранения изменений в заказе поставщику. Текст ошибки: " + f.Message);
            }
            return;
        }

        #endregion

        #region запись в DBGrid

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if( (e.KeyCode == Keys.Down) && ( e.Alt == false ) )
                {
                    if (gridView.FocusedRowHandle >= 0)
                    {
                        if (IsValidDataInRow(gridView.FocusedRowHandle) == true)
                        {
                            if (gridView.FocusedRowHandle == (gridView.RowCount - 1))
                            {
                                gridView.AddNewRow();
                                gridView.FocusedColumn = colProductID;
                                e.Handled = true;
                            }
                        }
                    }
                    else
                    {
                        gridView.AddNewRow();
                        gridView.FocusedColumn = colProductID;
                        e.Handled = true;
                    }
                }
                else if (e.KeyCode == Keys.Up)
                {
                    if (gridView.GetDataRow(gridView.FocusedRowHandle)["ProductID"] == System.DBNull.Value)
                    {
                        gridView.CancelUpdateCurrentRow();
                        e.Handled = true;
                    }
                }
                else if (e.KeyCode == Keys.Delete && e.Control)
                {
                    gridView.DeleteSelectedRows();
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("gridView_KeyDown. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;

        }

        private void gridView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                DataRow row = gridView.GetDataRow(e.RowHandle);

                //row["OrderItemsID"] = System.Guid.NewGuid();
                row["OrderedQuantity"] = 1;
                row["ConfirmQuantity"] = 1;
                row["QuantityInDoc"] = 1;
                row["VendorPrice"] = 0;
                row["DiscountPercent"] = spinEditDiscount.Value;
                row["VendorPriceWithDiscount"] = 0;
                row["PriceForCalcCostPrice"] = 0;
                row["CustomTarifPercent"] = spinEditCustomTarif.Value;
            }
            catch (System.Exception f)
            {
                SendMessageToLog("gridView_InitNewRow. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        private void gridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            try
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            }
            catch (System.Exception f)
            {
                SendMessageToLog("gridView_InvalidRowException. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        private void gridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                System.Boolean bOK = true;
                if ((gridView.GetDataRow(e.RowHandle)["OrderedQuantity"] == System.DBNull.Value) ||
                    (System.Convert.ToDouble(gridView.GetDataRow(e.RowHandle)["OrderedQuantity"]) < 1))
                {
                    bOK = false;
                    gridView.SetColumnError(colOrderedQuantity, "недопустимое количество", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                }
                if (gridView.GetDataRow(e.RowHandle)["ProductID"] == System.DBNull.Value)
                {
                    bOK = false;
                    gridView.SetColumnError(colProductID, "укажите, пожалуйста, товар", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                }
                if (gridView.GetDataRow(e.RowHandle)["MeasureID"] == System.DBNull.Value)
                {
                    bOK = false;
                    gridView.SetColumnError(colOrderItems_MeasureName, "укажите, пожалуйста, единицу измерения", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                }
                if (gridView.GetDataRow(e.RowHandle)["CountryProductionID"] == System.DBNull.Value)
                {
                    bOK = false;
                    gridView.SetColumnError( colOrderItems_CountryProductionName, "укажите, пожалуйста, страну производства", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                }
                e.Valid = bOK;

            }
            catch (System.Exception f)
            {
                SendMessageToLog("gridView_ValidateRow. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        private System.Boolean IsValidDataInRow(System.Int32 iRowHandle)
        {
            System.Boolean bRet = true;
            try
            {
                if ((iRowHandle < 0) || (gridView.RowCount < iRowHandle)) { return bRet; }
                else
                {
                    if ((gridView.GetDataRow(iRowHandle)["OrderedQuantity"] == System.DBNull.Value) ||
                        (System.Convert.ToDouble(gridView.GetDataRow(iRowHandle)["OrderedQuantity"]) < 1))
                    {
                        bRet = false;
                    }
                    if (gridView.GetDataRow(iRowHandle)["ProductID"] == System.DBNull.Value)
                    {
                        bRet = false;
                    }
                    if (gridView.GetDataRow(iRowHandle)["MeasureID"] == System.DBNull.Value)
                    {
                        bRet = false;
                    }
                    if (gridView.GetDataRow(iRowHandle)["CountryProductionID"] == System.DBNull.Value)
                    {
                        bRet = false;
                    }
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("IsValidDataInRow. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return bRet;

        }

        private void gridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (m_bDisableEvents == true) { return; }
                SetPropertiesModified(true);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("gridView_CellValueChanging. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }
        #endregion

        #region Экспорт приложения к заказу
        //<sbExportToHTML>
        private void sbExportToHTML_Click(object sender, System.EventArgs e)
        {
            try
            {
                panelProgressBar.Visible = true;

                string fileName = ShowSaveFileDialog("HTML документ", "HTML Documents|*.html");
                if (fileName != "")
                {
                    ExportTo(new DevExpress.XtraExport.ExportHtmlProvider(fileName));
                    OpenFile(fileName);
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("sbExportToHTML_Click. Текст ошибки: " + f.Message);
            }
            finally
            {
                panelProgressBar.Visible = false;
            }
            return;

        }
        //</sbExportToHTML>

        //<sbExportToXML>
        private void sbExportToXML_Click(object sender, System.EventArgs e)
        {
            try
            {
                panelProgressBar.Visible = true;

                string fileName = ShowSaveFileDialog("XML документ", "XML Documents|*.xml");
                if (fileName != "")
                {
                    ExportTo(new ExportXmlProvider(fileName));
                    OpenFile(fileName);
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("sbExportToXML_Click. Текст ошибки: " + f.Message);
            }
            finally
            {
                panelProgressBar.Visible = false;
            }

            return;
        }
        //</sbExportToXML>

        //<sbExportToXLS>
        private void sbExportToXLS_Click(object sender, System.EventArgs e)
        {
            try
            {
                panelProgressBar.Visible = true;
                string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xlsx");
                if (fileName != "")
                {
                    ExportTo(new ExportXlsProvider(fileName));
                    OpenFile(fileName);
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("sbExportToXLS_Click. Текст ошибки: " + f.Message);
            }
            finally
            {
                panelProgressBar.Visible = false;
            }

            return;
        }
        //</sbExportToXLS>

        //<sbExportToTXT>
        private void sbExportToTXT_Click(object sender, System.EventArgs e)
        {
            try
            {
                panelProgressBar.Visible = true;
                string fileName = ShowSaveFileDialog("Text Document", "Text Files|*.txt");
                if (fileName != "")
                {
                    ExportTo(new ExportTxtProvider(fileName));
                    OpenFile(fileName);
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("sbExportToTXT_Click. Текст ошибки: " + f.Message);
            }
            finally
            {
                panelProgressBar.Visible = false;
            }

            return;
        }
        //</sbExportToTXT>

        //<sbExportToTXT>
        private void sbExportToDBF_Click(object sender, System.EventArgs e)
        {
            try
            {
                panelProgressBar.Visible = true;
                string fileName = ShowSaveFileDialog("документ DBF", "DBF Files|*.dbf");
                if (fileName != "")
                {
                    if (EхportDBF(fileName, false) == true)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Экспорт данных успешно завершён.", "Внимание",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    }
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("sbExportToTXT_Click. Текст ошибки: " + f.Message);
            }
            finally
            {
                panelProgressBar.Visible = false;
            }

            return;
        }

        private void sbExportToDBFCurrency_Click(object sender, System.EventArgs e)
        {
            try
            {
                panelProgressBar.Visible = true;
                string fileName = ShowSaveFileDialog("документ DBF", "DBF Files|*.dbf");
                if (fileName != "")
                {
                    if (EхportDBF(fileName, true) == true)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Экспорт данных успешно завершён.", "Внимание",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    }
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("sbExportToTXT_Click. Текст ошибки: " + f.Message);
            }
            finally
            {
                panelProgressBar.Visible = false;
            }

            return;
        }

        private bool EхportDBF(string fileName, System.Boolean bCurrencyPrice)
        {
            string tableName = string.Empty;
            bool returnStatus = false;
            try
            {
                List<ERP_Mercury.Common.CCountry> objCountryList = new List<ERP_Mercury.Common.CCountry>();
                for( System.Int32 i = 0; i < cboxCountryProduction.Properties.Items.Count; i++ )
                {
                    objCountryList.Add( ( ERP_Mercury.Common.CCountry )cboxCountryProduction.Properties.Items[ i ] );
                }

                System.IO.File.Delete(fileName);

                string jetOleDbConString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Extended Properties=dBASE IV";
                OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
                conn.ConnectionString = String.Format(jetOleDbConString, System.IO.Path.GetDirectoryName(fileName));

                System.Data.OleDb.OleDbCommand oleDbCommandCreateTable = new System.Data.OleDb.OleDbCommand();
                System.Data.OleDb.OleDbCommand oleDbJetInsertCommand = new System.Data.OleDb.OleDbCommand();
                oleDbCommandCreateTable.Connection = conn;
                oleDbJetInsertCommand.Connection = conn;

                System.String strTableName = System.IO.Path.GetFileNameWithoutExtension(fileName);
                oleDbCommandCreateTable.CommandText = "CREATE TABLE " + strTableName + "(ARTICLE CHAR (20), NAME2 CHAR (52), QUANTITY Integer, PRICE Double, MARKUP Double, COUNTRY Integer, TARIFF Double )";

                conn.Open();

                oleDbCommandCreateTable.ExecuteNonQuery();

                oleDbJetInsertCommand.CommandText = "INSERT INTO " + strTableName + " (ARTICLE, NAME2, QUANTITY, PRICE, MARKUP, COUNTRY, TARIFF) VALUES (?, ?, ?, ?, ?, ?, ?)";
                oleDbJetInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ARTICLE", System.Data.OleDb.OleDbType.VarWChar, 20, "ARTICLE"));
                oleDbJetInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("NAME2", System.Data.OleDb.OleDbType.VarWChar, 52, "NAME2"));
                oleDbJetInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("QUANTITY", System.Data.OleDb.OleDbType.Integer, 0, "QUANTITY"));
                oleDbJetInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("PRICE", System.Data.OleDb.OleDbType.Double, 0, "PRICE"));
                oleDbJetInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("MARKUP", System.Data.OleDb.OleDbType.Double, 0, "MARKUP"));
                oleDbJetInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("COUNTRY", System.Data.OleDb.OleDbType.Integer, 0, "COUNTRY"));
                oleDbJetInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("TARIFF", System.Data.OleDb.OleDbType.Double, 0, "TARIFF"));

                for (System.Int32 i = 0; i < gridView.RowCount; i++)
                {
                    oleDbJetInsertCommand.Parameters["ARTICLE"].Value = System.Convert.ToString(gridView.GetRowCellValue(i, colOrderItems_PartsArticle));
                    oleDbJetInsertCommand.Parameters["NAME2"].Value = System.Convert.ToString(gridView.GetRowCellValue(i, colOrderItems_PartsName));
                    oleDbJetInsertCommand.Parameters["QUANTITY"].Value = System.Convert.ToInt32(gridView.GetRowCellValue(i, colConfirmQuantity));
                    oleDbJetInsertCommand.Parameters["PRICE"].Value = System.Convert.ToDouble(gridView.GetRowCellValue(i, colVendorPriceWithDiscount));
                    oleDbJetInsertCommand.Parameters["MARKUP"].Value = 0;
                    oleDbJetInsertCommand.Parameters["COUNTRY"].Value = ( objCountryList.Single<ERP_Mercury.Common.CCountry>(x=>x.ID.Equals( ( System.Guid )gridView.GetRowCellValue(i, colCountryID) ) == true ) ).ID_Ib;
                    oleDbJetInsertCommand.Parameters["TARIFF"].Value = System.Convert.ToDouble(gridView.GetRowCellValue(i, colCustomTarifPercent));

                    oleDbJetInsertCommand.ExecuteNonQuery();
                }

                conn.Close();
                returnStatus = true;

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Не удалось произвести экспорт заказа в файл dbf.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return returnStatus;
        } // close function

        //</sbExportToTXT>

        private void OpenFile(string fileName)
        {
            if (XtraMessageBox.Show("Хотите открыть этот файл?", "Экспорт в...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(this, 
                        "Не удалось найти приложение, с помощью которого можно было бы открыть файл.", "Открыть файл", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            progressBarControl1.Position = 0;
        }

        //<sbExportToHTML>
        private void ExportTo(IExportProvider provider)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            this.FindForm().Refresh();
            BaseExportLink link = gridView.CreateExportLink(provider);
            (link as GridViewExportLink).ExpandAll = false;
            link.Progress += new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);
            link.ExportTo(true);
            provider.Dispose();
            link.Progress -= new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);

            Cursor.Current = currentCursor;
        }
        //</sbExportToHTML>

        private string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = txtLotOrderNum.Text; // Application.ProductName;
            //int n = name.LastIndexOf(".") + 1;
            //if (n > 0) name = name.Substring(n, name.Length - n);
            dlg.Title = "Экспорт данных в " + title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }

        //<sbExportToHTML>
        private void Export_Progress(object sender, DevExpress.XtraGrid.Export.ProgressEventArgs e)
        {
            if (e.Phase == DevExpress.XtraGrid.Export.ExportPhase.Link)
            {
                progressBarControl1.Position = e.Position;
                this.Update();
            }
        }
        //</sbExportToHTML>

        #endregion

        #region Импорт приложения к заказу
        private void mitmsImportFromExcelByPartsFullName_Click(object sender, EventArgs e)
        {
            try
            {
                ImportFromExcel( enumImportMode.ByPartsFullName );
            }
            catch (System.Exception f)
            {
                SendMessageToLog("mitmsImportFromExcelByPartsFullName_Click. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        private void mitmsImportFromExcelByPartsId_Click(object sender, EventArgs e)
        {
            try
            {
                ImportFromExcel(enumImportMode.ByPartsId);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("mitmsImportFromExcelByPartsId_Click. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }
        public void ImportFromExcel(enumImportMode enImportMode)
        {
            try
            {
                frmImportXLSData objFrmImportXLSData = new frmImportXLSData(m_objProfile, m_objMenuItem);

                objFrmImportXLSData.OpenForImportPartsInLotOrder(enImportMode, enumImportTarget.ImportContents, System.Convert.ToDouble(spinEditDiscount.Value), 
                    dataSet.Tables["OrderItems"], m_strXLSImportFilePath,
                    m_iXLSSheetImport, m_SheetList, checkMultiplicity.Checked, m_objPartsList);

                DialogResult dlgRes = objFrmImportXLSData.DialogResult;

                m_strXLSImportFilePath = objFrmImportXLSData.FileFullName;
                m_iXLSSheetImport = objFrmImportXLSData.SelectedSheetId;
                m_SheetList = objFrmImportXLSData.SheetList;


                objFrmImportXLSData.Dispose();
                objFrmImportXLSData = null;
            }
            catch (System.Exception f)
            {
                SendMessageToLog("ImportFromExcel. Текст ошибки: " + f.Message);
            }
            finally
            {
                btnSave.Enabled = (ValidateProperties() == true);
            }
            return;
        }
        private void mitmsRefreshPricesByPartsId_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshPricesFromExcel(enumImportMode.ByPartsId);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("mitmsRefreshPricesByPartsId_Click. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return;
        }

        private void mitmsRefreshPricesByPartsFullName_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshPricesFromExcel(enumImportMode.ByPartsFullName);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("mitmsRefreshPricesByPartsFullName_Click. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return;
        }

        public void RefreshPricesFromExcel(enumImportMode enImportMode)
        {
            try
            {
                frmImportXLSData objFrmImportXLSData = new frmImportXLSData(m_objProfile, m_objMenuItem);

                objFrmImportXLSData.OpenForImportPartsInLotOrder(enImportMode, enumImportTarget.RefreshPrices, System.Convert.ToDouble(spinEditDiscount.Value),
                    dataSet.Tables["OrderItems"], m_strXLSImportFilePath,
                    m_iXLSSheetImport, m_SheetList, checkMultiplicity.Checked, m_objPartsList);

                DialogResult dlgRes = objFrmImportXLSData.DialogResult;

                m_strXLSImportFilePath = objFrmImportXLSData.FileFullName;
                m_iXLSSheetImport = objFrmImportXLSData.SelectedSheetId;
                m_SheetList = objFrmImportXLSData.SheetList;


                objFrmImportXLSData.Dispose();
                objFrmImportXLSData = null;
            }
            catch (System.Exception f)
            {
                SendMessageToLog("RefreshPricesFromExcel. Текст ошибки: " + f.Message);
            }
            finally
            {
                btnSave.Enabled = (ValidateProperties() == true);
            }
            return;
        }

        #endregion

        #region Печать
        /// <summary>
        /// Передача данных в MS Excel
        /// </summary>
        private void ExportPSCToExcel()
        {
            Excel.Application oXL = null;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            System.Int32 iStartRow = 10;
            System.Int32 iCurrentRow = iStartRow;
            object m = Type.Missing;
            //Excel.Range oRng;

            try
            {
                // курс ценообразования
               // System.String strErr = "";

                System.String strFileName = "";
                System.String strDLLPath = Application.StartupPath;
                strDLLPath += ("\\" + m_strReportsDirectory + "\\");

                strFileName = strDLLPath + m_strReportSuppl;

                if (System.IO.File.Exists(strFileName) == false)
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.Refresh();
                        if ((openFileDialog.FileName != "") && (System.IO.File.Exists(openFileDialog.FileName) == true))
                        {
                            strFileName = openFileDialog.FileName;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                SendMessageToLog("Идёт экспорт данных в MS Excel... ");
                this.Cursor = Cursors.WaitCursor;
                oXL = new Excel.Application();
                oWB = (Excel._Workbook)(oXL.Workbooks.Open(strFileName, 0, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                oSheet = (Excel._Worksheet)oWB.Worksheets[1];


                // форма оплаты №1
                //CCustomer objSelectedCustomer = ((Customer.SelectedItem == null) ? null : (CCustomer)Customer.SelectedItem);

                oSheet.Cells[3, 1] = "Заказ №" + txtLotOrderNum.Text;
                oSheet.Cells[5, 1] = "Поставщик: " + "\"" + cboxVendor.Text + "\"";
                oSheet.Cells[7, 1] = "Дата: " + BeginDate.DateTime.ToShortDateString();

                System.Int32 iRecordNum = 0;
                System.Double dclOrderedQuantity = 0;
                System.Double dclConfirmQuantity = 0;
                System.Double dclQuantityInDoc = 0;

                System.Double dclVendorPrice = 0;
                System.Double dclDiscountPercent = 0;
                System.Double dclVendorPriceWithDiscont = 0;
                System.Double dclSumOrdered = 0;
                System.Double dclSumOrderedWithDiscount = 0;
                System.Double dclSumConfirmed = 0;
                System.Double dclSumConfirmedWithDiscount = 0;
                System.Double dclSumInDoc = 0;
                System.Double dclSumInDocWithDiscount = 0;
                System.String strExpirationDate = "";

                System.String strPartsName = "";
                System.String strArticleName = "";
                System.String strMeasureName = "";

                for (System.Int32 i = 0; i < gridView.RowCount; i++)
                {
                    iRecordNum++;
                    try
                    {
                        dclOrderedQuantity = System.Convert.ToDouble(gridView.GetRowCellValue(i, colOrderedQuantity));
                    }
                    catch
                    {
                        dclOrderedQuantity = 0;
                    }
                    try
                    {
                        dclConfirmQuantity = System.Convert.ToDouble(gridView.GetRowCellValue(i, colConfirmQuantity));
                    }
                    catch
                    {
                        dclConfirmQuantity = 0;
                    }
                    try
                    {
                        dclQuantityInDoc = System.Convert.ToDouble(gridView.GetRowCellValue(i, colQuantityInDoc));
                    }
                    catch
                    {
                        dclQuantityInDoc = 0;
                    }
                    try
                    {
                        dclVendorPrice = System.Convert.ToDouble(gridView.GetRowCellValue(i, colVendorPrice));
                    }
                    catch
                    {
                        dclVendorPrice = 0;
                    }
                    try
                    {
                        dclDiscountPercent = System.Convert.ToDouble(gridView.GetRowCellValue(i, colDiscountPercent));
                    }
                    catch
                    {
                        dclDiscountPercent = 0;
                    }
                    try
                    {
                        dclVendorPriceWithDiscont = System.Convert.ToDouble(gridView.GetRowCellValue(i, colVendorPriceWithDiscount));
                    }
                    catch
                    {
                        dclVendorPriceWithDiscont = 0;
                    }
                    try
                    {
                        dclSumOrdered = System.Convert.ToDouble(gridView.GetRowCellValue(i, colSumOrdered));
                    }
                    catch
                    {
                        dclSumOrdered = 0;
                    }
                    try
                    {
                        dclSumOrderedWithDiscount = System.Convert.ToDouble(gridView.GetRowCellValue(i, colSumOrderedWithDiscount));
                    }
                    catch
                    {
                        dclSumOrderedWithDiscount = 0;
                    }
                    try
                    {
                        dclSumConfirmed = System.Convert.ToDouble(gridView.GetRowCellValue(i, colSumConfirmed));
                    }
                    catch
                    {
                        dclSumConfirmed = 0;
                    }
                    try
                    {
                        dclSumConfirmedWithDiscount = System.Convert.ToDouble(gridView.GetRowCellValue(i, colSumConfirmedWithDiscount));
                    }
                    catch
                    {
                        dclSumConfirmedWithDiscount = 0;
                    }
                    try
                    {
                        dclSumInDoc = System.Convert.ToDouble(gridView.GetRowCellValue(i, colSumInDoc));
                    }
                    catch
                    {
                        dclSumInDoc = 0;
                    }
                    try
                    {
                        dclSumInDocWithDiscount = System.Convert.ToDouble(gridView.GetRowCellValue(i, colSumPriceForCalcCostPrice));
                    }
                    catch
                    {
                        dclSumInDocWithDiscount = 0;
                    }
                    try
                    {
                        strExpirationDate = ( ( gridView.GetRowCellValue(i, colExpirationDate) == null ) ? ":" : System.Convert.ToDateTime( gridView.GetRowCellValue(i, colExpirationDate)  ).ToShortDateString() );
                    }
                    catch
                    {
                        strExpirationDate = "";
                    }
                    strPartsName = System.Convert.ToString(gridView.GetRowCellValue(i, colOrderItems_PartsName));
                    strArticleName = System.Convert.ToString(gridView.GetRowCellValue(i, colOrderItems_PartsArticle));
                    strMeasureName = System.Convert.ToString(gridView.GetRowCellValue(i, colOrderItems_MeasureName));

                    oSheet.Cells[iCurrentRow, 1] = strPartsName;
                    oSheet.Cells[iCurrentRow, 2] = strArticleName;
                    oSheet.Cells[iCurrentRow, 3] = strMeasureName;

                    oSheet.Cells[iCurrentRow, 4] = dclOrderedQuantity;
                    oSheet.Cells[iCurrentRow, 5] = dclConfirmQuantity;
                    oSheet.Cells[iCurrentRow, 6] = dclQuantityInDoc;

                    oSheet.Cells[iCurrentRow, 7] = dclVendorPrice;
                    oSheet.Cells[iCurrentRow, 8] = dclDiscountPercent;
                    oSheet.Cells[iCurrentRow, 9] = dclVendorPriceWithDiscont;

                    oSheet.Cells[iCurrentRow, 10] = dclSumOrdered;
                    oSheet.Cells[iCurrentRow, 11] = dclSumConfirmed;
                    oSheet.Cells[iCurrentRow, 12] = dclSumInDoc;

                    oSheet.Cells[iCurrentRow, 13] = dclSumOrderedWithDiscount;
                    oSheet.Cells[iCurrentRow, 14] = dclSumConfirmedWithDiscount;
                    oSheet.Cells[iCurrentRow, 15] = dclSumInDocWithDiscount;
                    oSheet.Cells[iCurrentRow, 16] = strExpirationDate;

                    if (i < (gridView.RowCount - 1))
                    {
                        oSheet.get_Range(oSheet.Cells[iCurrentRow, 1], oSheet.Cells[iCurrentRow, 100]).Copy(Missing.Value);
                        oSheet.get_Range(oSheet.Cells[iCurrentRow, 1], oSheet.Cells[iCurrentRow, 1]).Insert(Excel.XlInsertShiftDirection.xlShiftDown, Missing.Value);
                        iCurrentRow++;
                    }

                }
                oSheet.Cells[iCurrentRow + 1, 1] = "Итого:";
                oSheet.get_Range(oSheet.Cells[iCurrentRow + 1, 4], oSheet.Cells[iCurrentRow + 1, 4]).Formula = "=СУММ(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                oSheet.get_Range(oSheet.Cells[iCurrentRow + 1, 5], oSheet.Cells[iCurrentRow + 1, 5]).Formula = "=СУММ(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                oSheet.get_Range(oSheet.Cells[iCurrentRow + 1, 6], oSheet.Cells[iCurrentRow + 1, 6]).Formula = "=СУММ(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                oSheet.get_Range(oSheet.Cells[iCurrentRow + 1, 7], oSheet.Cells[iCurrentRow + 1, 7]).Formula = "=СУММ(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                oSheet.get_Range(oSheet.Cells[iCurrentRow + 1, 8], oSheet.Cells[iCurrentRow + 1, 8]).Formula = "=СУММ(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                oSheet.get_Range(oSheet.Cells[iCurrentRow + 1, 9], oSheet.Cells[iCurrentRow + 1, 9]).Formula = "=СУММ(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                oSheet.get_Range(oSheet.Cells[iCurrentRow + 1, 10], oSheet.Cells[iCurrentRow + 1, 10]).Formula = "=СУММ(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                oSheet.get_Range(oSheet.Cells[iCurrentRow + 1, 11], oSheet.Cells[iCurrentRow + 1, 11]).Formula = "=СУММ(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                oSheet.get_Range(oSheet.Cells[iCurrentRow + 1, 12], oSheet.Cells[iCurrentRow + 1, 12]).Formula = "=СУММ(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                oSheet.get_Range(oSheet.Cells[iCurrentRow + 1, 13], oSheet.Cells[iCurrentRow + 1, 13]).Formula = "=СУММ(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                oSheet.get_Range(oSheet.Cells[iCurrentRow + 1, 14], oSheet.Cells[iCurrentRow + 1, 14]).Formula = "=СУММ(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                oSheet.get_Range(oSheet.Cells[iCurrentRow + 1, 15], oSheet.Cells[iCurrentRow + 1, 15]).Formula = "=СУММ(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                oSheet.get_Range(oSheet.Cells[iCurrentRow + 1, 1], oSheet.Cells[iCurrentRow + 1, 16]).Font.Bold = true;
                oSheet.get_Range("A1", "A1").EntireColumn.AutoFit();


                ((Excel._Worksheet)oWB.Worksheets[1]).Activate();

                oXL.Visible = true;
                oXL.UserControl = true;

            }
            catch (System.Exception f)
            {
                oXL = null;
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка экспорта в MS Excel.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oSheet = null;
                oWB = null;
                oXL = null;
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void ExportToExcel2(string strFileName)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                System.IO.FileInfo newFile = new System.IO.FileInfo(strFileName);
                if (newFile.Exists == false)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Ошибка экспорта в MS Excel.\n\nНе найден файл: " + strFileName, "Ошибка",
                       System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }

                System.Int32 iStartRow = 10;
                System.Int32 iCurrentRow = iStartRow;

                using (ExcelPackage package = new ExcelPackage(newFile))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    if (worksheet != null)
                    {

                        worksheet.Cells[3, 1].Value = "Заказ №" + txtLotOrderNum.Text;
                        worksheet.Cells[5, 1].Value = "Поставщик: " + "\"" + cboxVendor.Text + "\"";
                        worksheet.Cells[7, 1].Value = "Дата: " + BeginDate.DateTime.ToShortDateString();

                        System.Int32 iRecordNum = 0;
                        System.Double dclOrderedQuantity = 0;
                        System.Double dclConfirmQuantity = 0;
                        System.Double dclQuantityInDoc = 0;

                        System.Double dclVendorPrice = 0;
                        System.Double dclDiscountPercent = 0;
                        System.Double dclVendorPriceWithDiscont = 0;
                        System.Double dclPriceForCalcCostPrice = 0;

                        System.Double dclSumOrdered = 0;
                        System.Double dclSumConfirmed = 0;
                        System.Double dclSumConfirmedWithDiscount = 0;
                        System.Double dclSumPriceForCalcCostPrice = 0;

                        System.Double dclCustomTarifPercent = 0;
                        System.String strExpirationDate = "";

                        System.String strPartsName = "";
                        System.String strArticleName = "";
                        System.String strMeasureName = "";
                        System.String strCountryProductionName = "";

                        for (System.Int32 i = 0; i < gridView.RowCount; i++)
                        {
                            iRecordNum++;
                            try
                            {
                                dclCustomTarifPercent = System.Convert.ToDouble(gridView.GetRowCellValue(i, colCustomTarifPercent));
                            }
                            catch
                            {
                                dclCustomTarifPercent = 0;
                            }
                            try
                            {
                                dclOrderedQuantity = System.Convert.ToDouble(gridView.GetRowCellValue(i, colOrderedQuantity));
                            }
                            catch
                            {
                                dclOrderedQuantity = 0;
                            }
                            try
                            {
                                dclConfirmQuantity = System.Convert.ToDouble(gridView.GetRowCellValue(i, colConfirmQuantity));
                            }
                            catch
                            {
                                dclConfirmQuantity = 0;
                            }
                            try
                            {
                                dclQuantityInDoc = System.Convert.ToDouble(gridView.GetRowCellValue(i, colQuantityInDoc));
                            }
                            catch
                            {
                                dclQuantityInDoc = 0;
                            }
                            try
                            {
                                dclVendorPrice = System.Convert.ToDouble(gridView.GetRowCellValue(i, colVendorPrice));
                            }
                            catch
                            {
                                dclVendorPrice = 0;
                            }
                            try
                            {
                                dclDiscountPercent = System.Convert.ToDouble(gridView.GetRowCellValue(i, colDiscountPercent));
                            }
                            catch
                            {
                                dclDiscountPercent = 0;
                            }
                            try
                            {
                                dclVendorPriceWithDiscont = System.Convert.ToDouble(gridView.GetRowCellValue(i, colVendorPriceWithDiscount));
                            }
                            catch
                            {
                                dclVendorPriceWithDiscont = 0;
                            }
                            try
                            {
                                dclPriceForCalcCostPrice = System.Convert.ToDouble(gridView.GetRowCellValue(i, colPriceForCalcCostPrice));
                            }
                            catch
                            {
                                dclPriceForCalcCostPrice = 0;
                            }

                            try
                            {
                                dclSumOrdered = System.Convert.ToDouble(gridView.GetRowCellValue(i, colSumOrdered));
                            }
                            catch
                            {
                                dclSumOrdered = 0;
                            }
                            try
                            {
                                dclSumConfirmed = System.Convert.ToDouble(gridView.GetRowCellValue(i, colSumConfirmed));
                            }
                            catch
                            {
                                dclSumConfirmed = 0;
                            }
                            try
                            {
                                dclSumConfirmedWithDiscount = System.Convert.ToDouble(gridView.GetRowCellValue(i, colSumConfirmedWithDiscount));
                            }
                            catch
                            {
                                dclSumConfirmedWithDiscount = 0;
                            }
                            try
                            {
                                dclSumPriceForCalcCostPrice = System.Convert.ToDouble(gridView.GetRowCellValue(i, colSumPriceForCalcCostPrice));
                            }
                            catch
                            {
                                dclSumPriceForCalcCostPrice = 0;
                            }

                            try
                            {
                                strExpirationDate = ((gridView.GetRowCellValue(i, colExpirationDate) == null) ? ":" : System.Convert.ToDateTime(gridView.GetRowCellValue(i, colExpirationDate)).ToShortDateString());
                            }
                            catch
                            {
                                strExpirationDate = "";
                            }


                            strPartsName = System.Convert.ToString(gridView.GetRowCellValue(i, colOrderItems_PartsName));
                            strArticleName = System.Convert.ToString(gridView.GetRowCellValue(i, colOrderItems_PartsArticle));
                            strMeasureName = System.Convert.ToString(gridView.GetRowCellValue(i, colOrderItems_MeasureName));
                            strCountryProductionName = System.Convert.ToString(gridView.GetRowCellValue(i, colOrderItems_CountryProductionName));

                            worksheet.Cells[iCurrentRow, 1].Value = strPartsName;
                            worksheet.Cells[iCurrentRow, 2].Value = strArticleName;
                            worksheet.Cells[iCurrentRow, 3].Value = strMeasureName;

                            worksheet.Cells[iCurrentRow, 4].Value = dclOrderedQuantity;
                            worksheet.Cells[iCurrentRow, 5].Value = dclConfirmQuantity;
                            worksheet.Cells[iCurrentRow, 6].Value = dclQuantityInDoc;

                            worksheet.Cells[iCurrentRow, 7].Value = dclVendorPrice;
                            worksheet.Cells[iCurrentRow, 8].Value = dclDiscountPercent;
                            worksheet.Cells[iCurrentRow, 9].Value = dclVendorPriceWithDiscont;
                            worksheet.Cells[iCurrentRow, 10].Value = dclPriceForCalcCostPrice;

                            worksheet.Cells[iCurrentRow, 11].Value = dclSumOrdered;
                            worksheet.Cells[iCurrentRow, 12].Value = dclSumConfirmed;
                            worksheet.Cells[iCurrentRow, 13].Value = dclSumConfirmedWithDiscount;
                            worksheet.Cells[iCurrentRow, 14].Value = dclSumPriceForCalcCostPrice;

                            worksheet.Cells[iCurrentRow, 15].Value = strExpirationDate;
                            worksheet.Cells[iCurrentRow, 16].Value = dclCustomTarifPercent;
                            worksheet.Cells[iCurrentRow, 17].Value = strCountryProductionName;

                            if (i < (gridView.RowCount - 1))
                            {
                                using (var range = worksheet.Cells[iCurrentRow, 1, iCurrentRow, 100])
                                {
                                    range.Copy(worksheet.Cells[iCurrentRow, 1, iCurrentRow, 1]);
                                }
                                iCurrentRow++;
                            }

                        }
                        worksheet.Cells[iCurrentRow + 1, 1].Value = "Итого:";
                        worksheet.Cells[iCurrentRow + 1, 4, iCurrentRow + 1, 4].FormulaR1C1 = "=SUM(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                        worksheet.Cells[iCurrentRow + 1, 5, iCurrentRow + 1, 5].FormulaR1C1 = "=SUM(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                        worksheet.Cells[iCurrentRow + 1, 6, iCurrentRow + 1, 6].FormulaR1C1 = "=SUM(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                        worksheet.Cells[iCurrentRow + 1, 11, iCurrentRow + 1, 11].FormulaR1C1 = "=SUM(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                        worksheet.Cells[iCurrentRow + 1, 12, iCurrentRow + 1, 12].FormulaR1C1 = "=SUM(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                        worksheet.Cells[iCurrentRow + 1, 13, iCurrentRow + 1, 13].FormulaR1C1 = "=SUM(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                        worksheet.Cells[iCurrentRow + 1, 14, iCurrentRow + 1, 14].FormulaR1C1 = "=SUM(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                        worksheet.Cells[iCurrentRow + 1, 1, iCurrentRow + 1, 14].Style.Font.Bold = true;

                        worksheet.Cells["A1:A1000"].AutoFitColumns();


                        worksheet = null;

                        package.Save();

                        try
                        {
                            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
                            {
                                process.StartInfo.FileName = strFileName;
                                process.StartInfo.Verb = "Open";
                                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                                process.Start();
                            }
                        }
                        catch
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(this, "Cannot find an application on your system suitable for openning the file with exported data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }


                }


            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка экспорта в MS Excel.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //ExportPSCToExcel();

                System.String strFileName = "";
                System.String strDLLPath = Application.StartupPath;
                strDLLPath += ("\\" + m_strReportsDirectory + "\\");

                strFileName = strDLLPath + m_strReportSuppl;

                if (System.IO.File.Exists(strFileName) == false)
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.Refresh();
                        if ((openFileDialog.FileName != "") && (System.IO.File.Exists(openFileDialog.FileName) == true))
                        {
                            strFileName = openFileDialog.FileName;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                System.String strTmpPath = System.IO.Path.GetTempPath();
                System.String strFileNameCopy = (strTmpPath + "Заказ поставщику.xlsx");

                System.IO.File.Copy(strFileName, strFileNameCopy, true);


                ExportToExcel2( strFileNameCopy );

            }
            catch (System.Exception f)
            {
                SendMessageToLog("btnPrint_Click. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return;
        }
        #endregion

        #region Обнуление цен в столбцах с ценами
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (gridView.RowCount == 0)
                {
                    mitemClearPrice.Visible = false;
                    return;
                }

                if ((gridView.FocusedColumn == colPriceForCalcCostPrice) || (gridView.FocusedColumn == colVendorPrice) || (gridView.FocusedColumn == colVendorPriceWithDiscount))
                {
                    mitemClearPrice.Text = "Обнулить " + gridView.FocusedColumn.Caption;
                    mitemClearPrice.Visible = true;
                }
                else
                {
                    mitemClearPrice.Visible = false;
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("contextMenuStrip_Opening. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        private void ClearValuesInGridColumn( DevExpress.XtraGrid.Columns.GridColumn objColumn )
        {
            if (gridView.RowCount == 0) { return; }
            if (objColumn == null) { return; }

            try
            {
                tableLayoutPanelBackground.SuspendLayout();

                if (gridView.RowCount == 0) { return; }

                Cursor = Cursors.WaitCursor;

                for (System.Int32 i = 0; i < gridView.RowCount; i++)
                {
                    gridView.SetRowCellValue(i, objColumn, 0);
                }

            }
            catch (System.Exception f)
            {
                SendMessageToLog("ClearValuesInGridColumn. Текст ошибки: " + f.Message);
            }
            finally
            {
                tableLayoutPanelBackground.ResumeLayout(false);
                gridView.RefreshData();
                Cursor = Cursors.Default;
            }

            return;
        }

        private void mitemClearPrice_Click(object sender, EventArgs e)
        {
            if (gridView.FocusedColumn == null) { return; }
            ClearValuesInGridColumn(gridView.FocusedColumn);
        }
        #endregion

    }

    /// <summary>
    /// Тип, хранящий информацию, которая передается получателям уведомления о событии
    /// </summary>
    public class ChangeLotOrderPropertieEventArgs : EventArgs
    {
        private readonly CLotOrder m_objOrder;
        public CLotOrder Order
        { get { return m_objOrder; } }

        private readonly ERP_Mercury.Common.enumActionSaveCancel m_enActionType;
        public ERP_Mercury.Common.enumActionSaveCancel ActionType
        { get { return m_enActionType; } }

        private readonly System.Boolean m_bIsNewOrder;
        public System.Boolean IsNewOrder
        { get { return m_bIsNewOrder; } }

        public ChangeLotOrderPropertieEventArgs(CLotOrder objOrder, ERP_Mercury.Common.enumActionSaveCancel enActionType, System.Boolean bIsNewOrder)
        {
            m_objOrder = objOrder;
            m_enActionType = enActionType;
            m_bIsNewOrder = bIsNewOrder;
        }
    }

}
