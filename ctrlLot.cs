using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_Mercury.Common;
using System.Threading;
using OfficeOpenXml;

namespace ERPMercuryLotOrder
{
    public partial class ctrlLot : UserControl
    {
        #region Свойства
        private UniXP.Common.CProfile m_objProfile;
        private UniXP.Common.MENUITEM m_objMenuItem;
        private List<ERP_Mercury.Common.CProduct> m_objPartsList;
        private List<ERP_Mercury.Common.CVendor> m_objVendorList;
        public List<CStock> m_objStockList;

        private CLot m_objSelectedLot;
        private System.Guid m_uuidSelectedStockID;

        private System.Boolean m_bIsChanged;

        private System.Boolean m_bDisableEvents;
        private System.Boolean m_bNewObject;
        private System.Boolean m_bIsReadOnly;

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

        public delegate void SetProductListToFormDelegate(List<ERP_Mercury.Common.CProduct> objProductNewList, System.Int32 iRowCountInLis);
        public SetProductListToFormDelegate m_SetProductListToFormDelegate;

        private const System.Int32 iThreadSleepTime = 1000;
        private System.Boolean m_bThreadFinishJob;

        private const System.String m_strReportsDirectory = "templates";
        private const System.String m_strReportSuppl = "Lot.xlsx";
        private const System.String m_strModeReadOnly = "Режим просмотра";
        private const System.String m_strModeEdit = "Режим редактирования";
        private const string strSlash = "\\";

        #endregion

        #region События
        // Создаем закрытое поле, ссылающееся на заголовок списка делегатов
        private EventHandler<ChangeLotPropertieEventArgs> m_ChangeLotProperties;
        // Создаем в классе член-событие
        public event EventHandler<ChangeLotPropertieEventArgs> ChangeLotProperties
        {
            add
            {
                // берем закрытую блокировку и добавляем обработчик
                // (передаваемый по значению) в список делегатов
                m_ChangeLotProperties += value;
            }
            remove
            {
                // берем закрытую блокировку и удаляем обработчик
                // (передаваемый по значению) из списка делегатов
                m_ChangeLotProperties -= value;
            }
        }
        /// <summary>
        /// Инициирует событие и уведомляет о нем зарегистрированные объекты
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChangeLotProperties(ChangeLotPropertieEventArgs e)
        {
            // Сохраняем поле делегата во временном поле для обеспечение безопасности потока
            EventHandler<ChangeLotPropertieEventArgs> temp = m_ChangeLotProperties;
            // Если есть зарегистрированные объектв, уведомляем их
            if (temp != null) temp(this, e);
        }
        public void SimulateChangeLotProperties(CLot objLot, enumActionSaveCancel enActionType, System.Boolean bIsNewLot)
        {
            // Создаем объект, хранящий информацию, которую нужно передать
            // объектам, получающим уведомление о событии
            ChangeLotPropertieEventArgs e = new ChangeLotPropertieEventArgs(objLot, enActionType, bIsNewLot);

            // Вызываем виртуальный метод, уведомляющий наш объект о возникновении события
            // Если нет типа, переопределяющего этот метод, наш объект уведомит все объекты, 
            // подписавшиеся на уведомление о событии
            OnChangeLotProperties(e);
        }
        #endregion

        #region Конструктор
        public ctrlLot(UniXP.Common.CProfile objProfile, UniXP.Common.MENUITEM objMenuItem,
            List<CVendor> objVendorList, List<CStock> objStockList)
        {
            m_objProfile = objProfile;
            m_objMenuItem = objMenuItem;

            m_objStockList = objStockList;
            m_objVendorList = objVendorList;

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);

            InitializeComponent();

            m_bIsChanged = false;
            m_bDisableEvents = false;
            m_bNewObject = false;
            m_uuidSelectedStockID = System.Guid.Empty;

            m_objSelectedLot = null;
            m_objPartsList = null;
            lblEditMode.Text = "";

            dtLotDocDate.DateTime = System.DateTime.Today;

            //LoadComboBoxItems();

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
                    strFileFullName = String.Format("{0}\\{1}", strPath, strDllName);
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
        private void ctrlLot_Load(object sender, EventArgs e)
        {
            try
            {
                txtLotNum.SelectAll();
                txtLotNum.Focus();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("ctrlLot_Load. Текст ошибки: " + f.Message);
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
                cboxLotState.Properties.Appearance.BackColor = ((cboxLotState.SelectedItem == null) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                cboxStockLot.Properties.Appearance.BackColor = ((cboxStockLot.SelectedItem == null) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                txtLotNum.Properties.Appearance.BackColor = ((txtLotNum.Text == System.String.Empty) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                txtLotDocNum.Properties.Appearance.BackColor = ((txtLotDocNum.Text == System.String.Empty) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                calcLotCurrencyRate.Properties.Appearance.BackColor = ((calcLotCurrencyRate.Value <= 0) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                dtLotDocDate.Properties.Appearance.BackColor = ((dtLotDocDate.DateTime == System.DateTime.MinValue) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);

                if (cboxVendor.SelectedItem == null) { bRet = false; }
                if (cboxCurrency.SelectedItem == null) { bRet = false; }
                if (cboxLotState.SelectedItem == null) { bRet = false; }
                if (cboxStockLot.SelectedItem == null) { bRet = false; }
                if (txtLotDocNum.Text == System.String.Empty) { bRet = false; }
                if ((dtLotDocDate.DateTime.CompareTo(System.DateTime.MinValue) == 0) || (dtLotDocDate.DateTime.CompareTo(System.DateTime.MaxValue) == 0)) { bRet = false; }
                if (calcLotCurrencyRate.Value <= 0) { bRet = false; }

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
                    SimulateChangeLotProperties(m_objSelectedLot, ERP_Mercury.Common.enumActionSaveCancel.Unkown, m_bNewObject);
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
        private void LotItems_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                if (m_bDisableEvents == true) { return; }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("LotItems_RowChanged. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        private void cboxLotPropertie_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_bDisableEvents == true) { return; }


                if ((sender == cboxProductTradeMark) || (sender == cboxProductType))
                {
                    //SetFilterForPartsCombo();
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


        private void txtLotPropertie_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
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
                SendMessageToLog("Ошибка изменения свойств прихода. Текст ошибки: " + f.Message);
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
        private void SetPriceInRow(System.Int32 iRowHandle, System.Double dblCostPrice, System.Double dblCurrencyRate)
        {
            try
            {
                gridView.SetRowCellValue(iRowHandle, colPrice, (dblCostPrice == 0 ? 0 : (dblCostPrice * dblCurrencyRate)));
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
                        objItem = m_objPartsList.Cast<CProduct>().SingleOrDefault<CProduct>(x => x.ID.CompareTo((System.Guid)e.Value) == 0);

                        gridView.SetRowCellValue(e.RowHandle, colMeasureID, objItem.Measure.ID);
                        gridView.SetRowCellValue(e.RowHandle, colLotItems_MeasureName, objItem.Measure.ShortName);
                        gridView.SetRowCellValue(e.RowHandle, colPrice, 0);
                        gridView.SetRowCellValue(e.RowHandle, colCurrencyPrice, 0);
                        gridView.SetRowCellValue(e.RowHandle, colDiscountPercent, spinEditDiscount.Value);


                        gridView.SetRowCellValue(e.RowHandle, colKLPItemsQuantity, 0);
                        gridView.SetRowCellValue(e.RowHandle, colLotQuantity, 0);
                        gridView.SetRowCellValue(e.RowHandle, colQuantity, objItem.CustomerOrderPackQty);

                        gridView.SetRowCellValue(e.RowHandle, colLotItems_PartsArticle, objItem.Article);
                        gridView.SetRowCellValue(e.RowHandle, colLotItems_PartsName, objItem.Name);

                        // страна производства
                        if (cboxCountryProduction.SelectedItem != null)
                        {
                            gridView.SetRowCellValue(e.RowHandle, colCountryID, ((ERP_Mercury.Common.CCountry)cboxCountryProduction.SelectedItem).ID);
                            gridView.SetRowCellValue(e.RowHandle, colLotItems_CountryProductionName, ((ERP_Mercury.Common.CCountry)cboxCountryProduction.SelectedItem).Name);
                        }


                        //SetPriceInRow(e.RowHandle, System.Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colDiscountPercent)));

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
                //else if ((e.Column == colDiscountPercent) && (e.Value != null))
                //{
                //    SetPriceInRow(e.RowHandle, System.Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colDiscountPercent)));
                //}
                else if ((e.Column == colCurrencyPrice) && (e.Value != null))
                {
                    //SetPriceInRow(e.RowHandle, System.Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colDiscountPercent)));
                }
                //else if ((e.Column == colOrderedQuantity) && (e.Value != null) && (gridView.GetRowCellValue(e.RowHandle, colProductID) != null) &&
                //    (gridView.GetRowCellValue(e.RowHandle, colOrderPackQty) != System.DBNull.Value) &&
                //    (gridView.GetRowCellValue(e.RowHandle, colOrderedQuantity) != System.DBNull.Value))
                //{
                //    System.Decimal dclOrderedQty = System.Convert.ToDecimal(e.Value);
                //    System.Decimal dclmultiplicity = System.Convert.ToDecimal(gridView.GetRowCellValue(e.RowHandle, colOrderPackQty));
                //    System.Decimal dclInstockQty = System.Convert.ToDecimal(gridView.GetRowCellValue(e.RowHandle, colOrderedQuantity));

                //    if (checkMultiplicity.CheckState == CheckState.Checked)
                //    {
                //        if ((dclOrderedQty % dclmultiplicity) != 0)
                //        {
                //            dclOrderedQty = (((int)dclOrderedQty / (int)dclmultiplicity) * dclmultiplicity) + dclmultiplicity;
                //            if (dclOrderedQty > dclInstockQty)
                //            {
                //                dclOrderedQty = dclInstockQty;
                //            }
                //        }
                //    }

                //    if (System.Convert.ToDecimal(System.Convert.ToDecimal(e.Value)) != dclOrderedQty)
                //    {
                //        gridView.SetRowCellValue(e.RowHandle, colOrderedQuantity, System.Convert.ToDecimal(dclOrderedQty));
                //    }
                //    gridView.SetRowCellValue(e.RowHandle, colConfirmQuantity, System.Convert.ToDecimal(dclOrderedQty));
                //    gridView.SetRowCellValue(e.RowHandle, colQuantityInDoc, System.Convert.ToDecimal(dclOrderedQty));
                //    gridView.UpdateCurrentRow();

                //}
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
                if ((gridView.GetRowCellValue(e.RowHandle, colKLPItemsQuantity) != null) &&
                    (gridView.GetRowCellValue(e.RowHandle, colQuantity) != null))
                {
                    System.Double dblKLPItemsQuantity = System.Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colKLPItemsQuantity));
                    System.Double dblQuantity = System.Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colQuantity));
                    if (dblKLPItemsQuantity < dblQuantity)
                    {
                        if ((e.Column == colKLPItemsQuantity) || (e.Column == colQuantity))
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

                cboxStockLot.Properties.Items.Clear();
                cboxStockLot.Properties.Items.AddRange(m_objStockList);

                cboxProductTradeMark.Properties.Items.Clear();
                cboxProductType.Properties.Items.Clear();

                // Валюты
                cboxCurrency.Properties.Items.Clear();
                cboxCurrency.Properties.Items.AddRange(CCurrency.GetCurrencyList(m_objProfile, null));

                // Состояния заказа
                cboxLotState.Properties.Items.Clear();
                cboxLotState.Properties.Items.AddRange(CLotState.GetLotStateList(m_objProfile, null, System.Guid.Empty));

                // Товары
                dataSet.Tables["Product"].Clear();
                repositoryItemLookUpEditProduct.DataSource = dataSet.Tables["Product"];

                // страны производства
                cboxCountryProduction.Properties.Items.Clear();
                dataSet.Tables["CountryProduction"].Clear();
                List<CCountry> objCountryProductionList = CCountry.GetCountryList(m_objProfile, null);
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
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("В результате применения фильтра будут удалены товары в приходе,\nне соответствующие заданным условиям.\nУстановить фильтр?", "Внимание",
                        System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        cboxProductTradeMark.SelectedValueChanged -= new EventHandler(cboxLotPropertie_SelectedValueChanged);
                        cboxProductType.SelectedValueChanged -= new EventHandler(cboxLotPropertie_SelectedValueChanged);

                        cboxProductTradeMark.SelectedItem = null;
                        cboxProductType.SelectedItem = null;

                        cboxProductTradeMark.SelectedValueChanged += new EventHandler(cboxLotPropertie_SelectedValueChanged);
                        cboxProductType.SelectedValueChanged += new EventHandler(cboxLotPropertie_SelectedValueChanged);

                        return;
                    }
                }
                System.Guid TradeMarkId = ((cboxProductTradeMark.SelectedItem == null) ? System.Guid.Empty : ((ERP_Mercury.Common.CProductTradeMark)cboxProductTradeMark.SelectedItem).ID);
                System.Guid PartTypeId = ((cboxProductType.SelectedItem == null) ? System.Guid.Empty : ((ERP_Mercury.Common.CProductType)cboxProductType.SelectedItem).ID);

                tableLayoutPanelBackground.SuspendLayout();

                List<CProduct> FilteredProductList = m_objPartsList;

                if (TradeMarkId != System.Guid.Empty)
                {
                    FilteredProductList = FilteredProductList.Where<CProduct>(x => x.ProductTradeMark.ID == TradeMarkId).ToList<CProduct>();
                }

                if (PartTypeId != System.Guid.Empty)
                {
                    FilteredProductList = FilteredProductList.Where<CProduct>(x => x.ProductType.ID == PartTypeId).ToList<CProduct>();
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
        /// Запуск потока, в котором загружается приложение к приходу
        /// </summary>
        public void StartLoadProductListForComboBoxInThread()
        {
            try
            {
                // инициализируем события
                this.m_EventStopThread = new System.Threading.ManualResetEvent(false);
                this.m_EventThreadStopped = new System.Threading.ManualResetEvent(false);

                // инициализируем делегаты
                m_SetProductListToFormDelegate = new SetProductListToFormDelegate(SetProductListToForm);
                m_SendMessageToLogDelegate = new SendMessageToLogDelegate(SendMessageToLog);
                m_objPartsList.Clear();
                dataSet.Tables["Product"].Clear();

                // запуск потока
                // делаем событиям reset
                this.m_EventStopThread.Reset();
                this.m_EventThreadStopped.Reset();

                this.thrAddress = new System.Threading.Thread(LoadProductListForComboBox);
                this.thrAddress.Start();

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
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("StartThreadWithLoadData().\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// метод, выполняемый в потоке для загрузки в грид приложения к приходу и обновления выпадающего списка с товарами
        /// </summary>
        public void LoadProductListForComboBox()
        {
            try
            {
                // товары
                List<CProduct> objProductList = CProduct.GetProductList(m_objProfile, null, false, true);
                List<CProduct> objAddProductList = new List<CProduct>();

                if ((objProductList != null) && (objProductList.Count > 0))
                {
                    System.Int32 iRecCount = 0;
                    System.Int32 iRecAllCount = 0;
                    foreach (CProduct objProduct in objProductList)
                    {
                        objAddProductList.Add(objProduct);
                        iRecCount++;
                        iRecAllCount++;

                        if (iRecCount == 1000)
                        {
                            iRecCount = 0;
                            Thread.Sleep(1000);
                            this.Invoke(m_SetProductListToFormDelegate, new Object[] { objAddProductList, iRecAllCount });
                            objAddProductList.Clear();
                        }

                    }
                    if (iRecCount != 1000)
                    {
                        iRecCount = 0;
                        this.Invoke(m_SetProductListToFormDelegate, new Object[] { objAddProductList, iRecAllCount });
                        objAddProductList.Clear();
                    }

                }

                objProductList = null;
                objAddProductList = null;
                this.Invoke(m_SetProductListToFormDelegate, new Object[] { null, 0 });

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

        /// <summary>
        /// Загружает в набор данных список товаров для выпадающего списка
        /// </summary>
        /// <param name="objPartsList">списком товара</param>
        /// <param name="iRowCountInList">количество строк, которые требуется загрузить</param>
        private void SetProductListToForm(List<CProduct> objPartsList, System.Int32 iRowCountInList)
        {
            try
            {
                if ((objPartsList != null) && (objPartsList.Count > 0) && (dataSet.Tables["Product"].Rows.Count < iRowCountInList))
                {
                    m_objPartsList.AddRange(objPartsList);

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
                else
                {
                    this.m_bThreadFinishJob = true;
                }


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
                dtLotDocDate.Properties.ReadOnly = bSet;
                txtLotDescription.Properties.ReadOnly = bSet;
                txtLotNum.Properties.ReadOnly = bSet;
                txtLotDocNum.Properties.ReadOnly = bSet;

                cboxVendor.Properties.ReadOnly = bSet;
                cboxLotState.Properties.ReadOnly = bSet;
                cboxCurrency.Properties.ReadOnly = bSet;
                cboxCountryProduction.Properties.ReadOnly = bSet;
                cboxStockLot.Properties.ReadOnly = bSet;

                cboxProductTradeMark.Properties.ReadOnly = bSet;
                cboxProductType.Properties.ReadOnly = bSet;
                spinEditDiscount.Properties.ReadOnly = bSet;
                btnSetDiscount.Enabled = !bSet;
                checkMultiplicity.Properties.ReadOnly = bSet;
                checkLotActive.Properties.ReadOnly = bSet;

                gridView.OptionsBehavior.Editable = !bSet;

                mitemImport.Enabled = !bSet;
                mitemRefreshPrices.Enabled = !bSet;
                mitemClearPrice.Enabled = !bSet;

                m_bIsReadOnly = bSet;

                btnEdit.Enabled = bSet;

                lblEditMode.Text = ((bSet == true) ? m_strModeReadOnly : m_strModeEdit);
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

                StartLoadProductListForComboBoxInThread();
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

        #region Редактировать приход
        /// <summary>
        /// очистка содержимого элементов управления
        /// </summary>
        private void ClearControls()
        {
            try
            {
                dtLotDocDate.EditValue = null;
                txtLotDescription.Text = "";
                txtLotNum.Text = "";
                txtLotDocNum.Text = "";
                txtKLPNum.Text = "";

                cboxCurrency.SelectedItem = null;
                cboxVendor.SelectedItem = null;
                cboxLotState.SelectedItem = null;
                cboxCountryProduction.SelectedItem = null;
                checkLotActive.Checked = false;

                cboxProductTradeMark.SelectedItem = null;
                cboxProductType.SelectedItem = null;
                spinEditDiscount.Value = 0;

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

        private void LoadLotItemsListToDataSet()
        {
            try
            {
                dataSet.Tables["Product"].Clear();
                System.Data.DataRow newRowProduct = null;

                foreach (CLotItem objItem in m_objSelectedLot.LotItemList)
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

                foreach (CLotItem objItem in m_objSelectedLot.LotItemList)
                {
                    newRowOrderItems = dataSet.Tables["OrderItems"].NewRow();

                    newRowOrderItems["OrderItemsID"] = objItem.ID;
                    newRowOrderItems["ProductID"] = objItem.Product.ID;
                    newRowOrderItems["MeasureID"] = objItem.Measure.ID;
                    newRowOrderItems["LotItems_Quantity"] = objItem.Quantity;
                    newRowOrderItems["KLPItems_Quantity"] = objItem.QuantityInKLP;
                    newRowOrderItems["Lot_Quantity"] = 0;
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

                    newRowOrderItems["LotItems_MeasureName"] = objItem.Measure.ShortName;
                    newRowOrderItems["LotItems_PartsArticle"] = objItem.Product.Name;
                    newRowOrderItems["LotItems_PartsName"] = objItem.Product.Article;
                    newRowOrderItems["LotItems_CountryProductionName"] = objItem.CountryProduction.Name;
                    newRowOrderItems["DiscountPercent"] = 0;
                    newRowOrderItems["LotItems_CurrencyPrice"] = objItem.CostPrice;
                    newRowOrderItems["LotItems_Price"] = objItem.Price;

                    if (objItem.ExpirationDate != System.DateTime.MinValue)
                    {
                        newRowOrderItems["ExpirationDate"] = objItem.ExpirationDate;
                    }

                    dataSet.Tables["OrderItems"].Rows.Add(newRowOrderItems);
                }
                newRowOrderItems = null;
                objProduct = null;

                dataSet.Tables["OrderItems"].AcceptChanges();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("LoadLotItemsListToDataSet. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        private void LoadLotPropertiesToControls(CLot objLot)
        {
            try
            {
                txtLotDescription.Text = objLot.Description;
                txtLotNum.Text = objLot.Number;
                txtLotDocNum.Text = objLot.DocNumber;
                txtKLPNum.Text = "";
                dtLotDocDate.DateTime = objLot.DocDate;

                cboxVendor.SelectedItem = (objLot.Vendor == null) ? null : cboxVendor.Properties.Items.Cast<CVendor>().SingleOrDefault<CVendor>(x => x.ID.CompareTo(objLot.Vendor.ID) == 0);
                cboxCurrency.SelectedItem = (objLot.Currency == null) ? null : cboxCurrency.Properties.Items.Cast<CCurrency>().SingleOrDefault<CCurrency>(x => x.ID.CompareTo(objLot.Currency.ID) == 0);

                cboxLotState.Properties.Items.Clear();
                cboxLotState.Properties.Items.AddRange(CLotState.GetLotStateList(m_objProfile, null, objLot.ID));
                cboxLotState.SelectedItem = (objLot.CurrentLotState == null) ? null : cboxLotState.Properties.Items.Cast<CLotOrderState>().SingleOrDefault<CLotOrderState>(x => x.ID.CompareTo(objLot.CurrentLotState.ID) == 0);

                cboxProductTradeMark.Properties.Items.Add(new ERP_Mercury.Common.CProductTradeMark() { ID = System.Guid.Empty, Name = "" });
                cboxProductTradeMark.Properties.Items.AddRange(ERP_Mercury.Common.CProductTradeMark.GetProductTradeMarkList(m_objProfile, null));
                cboxProductType.Properties.Items.Add(new ERP_Mercury.Common.CProductType() { ID = System.Guid.Empty, Name = "" });
                cboxProductType.Properties.Items.AddRange(ERP_Mercury.Common.CProductType.GetProductTypeList(m_objProfile, null));
            }
            catch (System.Exception f)
            {
                SendMessageToLog("LoadLotPropertiesToControls. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        /// <summary>
        /// Загружает свойства прихода для редактирования
        /// </summary>
        /// <param name="objLot">приход</param>
        /// <param name="bNewObject">признак "новый приход"</param>
        public void EditLot(CLot objLot, System.Boolean bNewObject)
        {
            if (objLot == null) { return; }
            m_bDisableEvents = true;
            m_bNewObject = bNewObject;
            try
            {
                m_objSelectedLot = objLot;

                this.tableLayoutPanelBackground.SuspendLayout();

                ClearControls();

                LoadLotPropertiesToControls(m_objSelectedLot);

                LoadLotItemsListToDataSet();

                SetPropertiesModified(false);

                ValidateProperties();

                SetModeReadOnly(true);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка редактирования документа \"Приход на склад\". Текст ошибки: " + f.Message);
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

        #region Новый приход
        /// <summary>
        /// Новый приход
        /// </summary>
        public void NewLot(CVendor objVendor)
        {
            try
            {
                m_bNewObject = true;
                m_bDisableEvents = true;

                m_objSelectedLot = new CLot() { DocDate = System.DateTime.Today, Vendor = objVendor, LotItemList = new List<CLotItem>() };

                this.tableLayoutPanelBackground.SuspendLayout();

                ClearControls();

                LoadLotPropertiesToControls(m_objSelectedLot);

                cboxLotState.SelectedItem = (cboxLotState.Properties.Items.Count == 0) ? null : cboxLotState.Properties.Items[0];
                cboxCountryProduction.SelectedItem = ((cboxCountryProduction.Properties.Items.Count > 0) ? cboxCountryProduction.Properties.Items[0] : null);

                btnEdit.Enabled = false;
                btnCancel.Enabled = true;

                SetModeReadOnly(false);
                SetPropertiesModified(true);

                StartLoadProductListForComboBoxInThread();
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
                SimulateChangeLotProperties(m_objSelectedLot, ERP_Mercury.Common.enumActionSaveCancel.Cancel, m_bNewObject);
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
        private SaveChangesResult SaveChanges(ref System.String strErr)
        {
            System.Boolean bRet = false;
            try
            {
                if (m_objSelectedLot == null)
                {
                    strErr += ("\nПрограмме не удалось определить объект \"Приходный документ\".\nОбратитесь, пожалуйста, к разработчику.");
                    return SaveChangesResult.Failure;
                }

                System.Guid KLP_Guid = m_objSelectedLot.KLPID;
                System.String Lot_Num = txtLotNum.Text;
                System.String Lot_DocNum = txtLotDocNum.Text;
                System.DateTime Lot_Date = dtLotDocDate.DateTime;
                System.String Lot_Description = txtLotDocNum.Text;
                System.Boolean Lot_IsActive = checkLotActive.Checked;

                System.Guid Vendor_Guid = ((cboxVendor.SelectedItem == null) ? (System.Guid.Empty) : ((CVendor)cboxVendor.SelectedItem).ID);
                System.Guid Currency_Guid = ((cboxCurrency.SelectedItem == null) ? (System.Guid.Empty) : ((CCurrency)cboxCurrency.SelectedItem).ID);
                System.Guid Stock_Guid = ((cboxStockLot.SelectedItem == null) ? (System.Guid.Empty) : ((CStock)cboxStockLot.SelectedItem).ID);
                System.Guid LotState_Guid = ((cboxLotState.SelectedItem == null) ? (System.Guid.Empty) : ((CLotState)cboxLotState.SelectedItem).ID);
                System.Double Lot_CurrencyRate = System.Convert.ToDouble(calcLotCurrencyRate.Value);

                System.Guid Lot_Guid = ((m_bNewObject == true) ? System.Guid.Empty : m_objSelectedLot.ID);
                System.Int32 Lot_Id = ((m_bNewObject == true) ? 0 : m_objSelectedLot.Ib_ID);
                System.Double Lot_AllPrice = 0;
                System.Double Lot_CurrencyAllPrice = 0;
                System.Double Lot_RetCurrencyAllPrice = 0;

                List<CLotItem> objLotItemList = new List<CLotItem>();

                System.Guid uuidOrderItmsID = System.Guid.Empty;
                System.Guid uuidProductID = System.Guid.Empty;
                System.Guid uuidMeasureID = System.Guid.Empty;
                System.Guid uuidCountryProductionID = System.Guid.Empty;
                System.Double dblLotItems_Quantity = 0;
                //System.Double dblKLPItems_Quantity = 0;
                //System.Double dblLot_Quantity = 0;
                System.Double dblLotItems_Price = 0;
                System.Double dblLotItems_CurrencyPrice = 0;
                System.DateTime dtExpirationDate = System.DateTime.MinValue;

                dataSet.Tables["OrderItems"].AcceptChanges();

                for (System.Int32 i = 0; i < dataSet.Tables["OrderItems"].Rows.Count; i++)
                {
                    if ((dataSet.Tables["OrderItems"].Rows[i]["ProductID"] == System.DBNull.Value) ||
                        (dataSet.Tables["OrderItems"].Rows[i]["MeasureID"] == System.DBNull.Value) ||
                        (dataSet.Tables["OrderItems"].Rows[i]["CountryProductionID"] == System.DBNull.Value) ||
                        (dataSet.Tables["OrderItems"].Rows[i]["LotItems_Quantity"] == System.DBNull.Value))
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
                    dblLotItems_Quantity = System.Convert.ToDouble(dataSet.Tables["OrderItems"].Rows[i]["LotItems_Quantity"]);
                    dblLotItems_Price = System.Convert.ToDouble(dataSet.Tables["OrderItems"].Rows[i]["LotItems_Price"]);
                    dblLotItems_CurrencyPrice = System.Convert.ToDouble(dataSet.Tables["OrderItems"].Rows[i]["LotItems_CurrencyPrice"]);
                    dtExpirationDate = ((dataSet.Tables["OrderItems"].Rows[i]["ExpirationDate"] == System.DBNull.Value) ? System.DateTime.MinValue : System.Convert.ToDateTime((dataSet.Tables["OrderItems"].Rows[i]["ExpirationDate"])));

                    objLotItemList.Add(new CLotItem()
                    {
                        ID = uuidOrderItmsID,
                        Product = new CProduct() { ID = uuidProductID },
                        Measure = new CMeasure() { ID = uuidMeasureID },
                        CountryProduction = new CCountry() { ID = uuidCountryProductionID },
                        Quantity = dblLotItems_Quantity,
                        Price = dblLotItems_Price,
                        CostPrice = dblLotItems_CurrencyPrice,
                        ExpirationDate = dtExpirationDate
                    });
                }
                System.Data.DataTable addedItems = ((gridControl.DataSource == null) ? null : CLotItem.ConvertListToTable(objLotItemList, Lot_Guid, ref strErr));
                objLotItemList = null;

                // проверка значений
                if (CLotRepository.CheckAllPropertiesForSave(Lot_Date, Vendor_Guid, Currency_Guid, LotState_Guid, Stock_Guid,
                     addedItems, ref strErr) == true)
                {
                    if (m_bNewObject == true)
                    {
                        // новый приход
                        bRet = CLotRepository.AddLot(m_objProfile, null, KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date,
                            Vendor_Guid, Currency_Guid, Stock_Guid, Lot_Description, Lot_IsActive,
                            LotState_Guid, Lot_CurrencyRate, addedItems,
                            ref Lot_Guid, ref Lot_Id, ref Lot_AllPrice, ref Lot_CurrencyAllPrice,
                            ref Lot_RetCurrencyAllPrice, ref strErr);
                    }
                    else
                    {
                        bRet = CLotRepository.EditLot(m_objProfile, null, KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date,
                            Vendor_Guid, Currency_Guid, Stock_Guid, Lot_Description, Lot_IsActive,
                            LotState_Guid, Lot_CurrencyRate, addedItems,
                            Lot_Guid, ref Lot_AllPrice, ref Lot_CurrencyAllPrice,
                            ref Lot_RetCurrencyAllPrice, ref strErr);
                    }
                }

                if (bRet == true)
                {
                    if (m_bNewObject == true)
                    {
                        m_objSelectedLot.ID = Lot_Guid;
                        m_objSelectedLot.Ib_ID = Lot_Id;
                    }
                    m_objSelectedLot.Number = Lot_Num;
                    m_objSelectedLot.DocNumber = Lot_DocNum;
                    m_objSelectedLot.DocDate = Lot_Date;
                    m_objSelectedLot.Date = Lot_Date;
                    m_objSelectedLot.Vendor = ((cboxVendor.SelectedItem == null) ? null : (CVendor)cboxVendor.SelectedItem);
                    m_objSelectedLot.Currency = ((cboxCurrency.SelectedItem == null) ? null : (CCurrency)cboxCurrency.SelectedItem);
                    m_objSelectedLot.Stock = ((cboxStockLot.SelectedItem == null) ? null : (CStock)cboxStockLot.SelectedItem);
                    m_objSelectedLot.CurrentLotState = ((cboxLotState.SelectedItem == null) ? null : (CLotState)cboxLotState.SelectedItem);
                    m_objSelectedLot.Description = Lot_Description;
                    m_objSelectedLot.IsActive = Lot_IsActive;
                    m_objSelectedLot.AllPrice = Lot_AllPrice;
                    m_objSelectedLot.AllCostPrice = Lot_CurrencyAllPrice;
                    m_objSelectedLot.AllCostPriceReturn = Lot_RetCurrencyAllPrice;

                }

            }
            catch (System.Exception f)
            {
                strErr += ("\n" + f.Message);
            }
            finally
            {
            }
            return ((bRet == true) ? SaveChangesResult.Success : SaveChangesResult.Failure);
        }

        private System.Boolean ChangeLotOrderSate(ref System.String strErr)
        {
            System.Boolean bRes = false;
            try
            {

                if (m_bNewObject == false)
                {
                    System.Guid Lot_Guid = ((m_bNewObject == true) ? System.Guid.Empty : m_objSelectedLot.ID);
                    System.Guid LotState_Guid = ((cboxLotState.SelectedItem == null) ? (System.Guid.Empty) : ((CLotState)cboxLotState.SelectedItem).ID);
                    System.Int32 Lot_Id = m_objSelectedLot.Ib_ID;

                    // теперь вносим изменения в состояние прихода
                    if (CLotRepository.ChangeLotState(m_objProfile, null, Lot_Guid, LotState_Guid, ref strErr, ref Lot_Id))
                    {
                        m_objSelectedLot.CurrentLotState = ((cboxLotState.SelectedItem == null) ? null : (CLotState)cboxLotState.SelectedItem);
                        m_objSelectedLot.Ib_ID = Lot_Id;
                        bRes = true;
                    }
                }
                else
                {
                    bRes = true;
                }
            }
            catch (System.Exception f)
            {
                strErr = ("\n" + f.Message);
            }

            return bRes;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                System.String strErr = System.String.Empty;
                if (SaveChanges(ref strErr) == SaveChangesResult.Success)
                {
                    // теперь состояние заказа
                    strErr = System.String.Empty;
                    if (ChangeLotOrderSate(ref strErr) == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Изменения в приходе сохранены за исключением состояния заказа\n" + strErr, "Внимание",
                             System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    }

                    SimulateChangeLotProperties(m_objSelectedLot, ERP_Mercury.Common.enumActionSaveCancel.Save, m_bNewObject);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(strErr, "Внимание",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }

            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка сохранения изменений в \"Приходный документе\".\nОбратитесь, пожалуйста, к разработчику.\nТекст ошибки: " + f.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return;
        }

        #endregion

        #region Печать

        private void ExportToExcel(string strFileName)
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

                        worksheet.Cells[3, 1].Value = String.Format("Партия №{0}", txtLotNum.Text);
                        worksheet.Cells[4, 1].Value = String.Format("Приход №{0}", txtLotDocNum.Text);
                        worksheet.Cells[5, 1].Value = String.Format("Поставщик: \"{0}\"", cboxVendor.Text);
                        worksheet.Cells[6, 1].Value = String.Format("Склад: \"{0}\"", cboxStockLot.Text);
                        worksheet.Cells[7, 1].Value = String.Format("Дата: {0}", dtLotDocDate.DateTime.ToShortDateString());

                        System.Int32 iRecordNum = 0;
                        System.Double dclQuantity = 0;
                        System.Double dclPrice = 0;
                        System.Double dclCostPrice = 0;
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
                                dclQuantity = System.Convert.ToDouble(gridView.GetRowCellValue(i, colQuantity));
                            }
                            catch
                            {
                                dclQuantity = 0;
                            }
                            try
                            {
                                dclPrice = System.Convert.ToDouble(gridView.GetRowCellValue(i, colPrice));
                            }
                            catch
                            {
                                dclPrice = 0;
                            }
                            try
                            {
                                dclCostPrice = System.Convert.ToDouble(gridView.GetRowCellValue(i, colCurrencyPrice));
                            }
                            catch
                            {
                                dclCostPrice = 0;
                            }
                            try
                            {
                                strExpirationDate = ((gridView.GetRowCellValue(i, colExpirationDate) == null) ? ":" : System.Convert.ToDateTime(gridView.GetRowCellValue(i, colExpirationDate)).ToShortDateString());
                            }
                            catch
                            {
                                strExpirationDate = "";
                            }


                            strPartsName = System.Convert.ToString(gridView.GetRowCellValue(i, colLotItems_PartsName));
                            strArticleName = System.Convert.ToString(gridView.GetRowCellValue(i, colLotItems_PartsArticle));
                            strMeasureName = System.Convert.ToString(gridView.GetRowCellValue(i, colLotItems_MeasureName));
                            strCountryProductionName = System.Convert.ToString(gridView.GetRowCellValue(i, colLotItems_CountryProductionName));

                            worksheet.Cells[iCurrentRow, 1].Value = strPartsName;
                            worksheet.Cells[iCurrentRow, 2].Value = strArticleName;
                            worksheet.Cells[iCurrentRow, 3].Value = strMeasureName;

                            worksheet.Cells[iCurrentRow, 4].Value = dclQuantity;
                            worksheet.Cells[iCurrentRow, 5].Value = dclPrice;
                            worksheet.Cells[iCurrentRow, 6].Value = dclCostPrice;

                            worksheet.Cells[iCurrentRow, 7].Value = strExpirationDate;
                            worksheet.Cells[iCurrentRow, 8].Value = strCountryProductionName;

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
                System.String strFileName = "";
                System.String strDLLPath = Application.StartupPath;
                strDLLPath += (String.Format("{0}{1}{0}", strSlash, m_strReportsDirectory));

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


                ExportToExcel(strFileNameCopy);

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


    }

}
