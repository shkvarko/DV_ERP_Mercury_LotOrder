using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace ERPMercuryLotOrder
{
    public partial class ctrlKLP : UserControl
    {
        #region Свойства
        private UniXP.Common.CProfile m_objProfile;
        private UniXP.Common.MENUITEM m_objMenuItem;
        private System.Boolean m_bOnlyView;
        private System.Boolean m_bDisableEvents;
        private System.Boolean m_bIsChanged;
        private System.Boolean m_bNewObject;
        private System.Boolean m_bIsReadOnly;
        private ctrlLotList m_frmLotList;
        private List<CKLP> m_objKLPList;
        private CKLP m_objSelectedKLP;
        private CLotOrder m_objLotOrder;
        private List<ERP_Mercury.Common.CStock> m_objStockList;
        private List<CLotOrderItems> m_objSrcForKlp;
        private DevExpress.XtraGrid.Views.Base.ColumnView ColumnView
        {
            get { return gridControlKLPList.MainView as DevExpress.XtraGrid.Views.Base.ColumnView; }
        }
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

        public delegate void SetProductListToFormDelegate(List<CLotOrderItems>  objProductNewList);
        public SetProductListToFormDelegate m_SetProductListToFormDelegate;

        private const System.Int32 iThreadSleepTime = 1000;
        private System.Boolean m_bThreadFinishJob;
        private const System.String m_strLblLotOrderInfoText = "Журнал КЛП к заказу №";
        private const System.String m_strReportsDirectory = "templates";
        private const System.String m_strReportSuppl = "KLP.xlsx";

        #endregion

        #region События
        // Создаем закрытое поле, ссылающееся на заголовок списка делегатов
        private EventHandler<CloseKLPListEventArgs> m_CloseKLPList;
        // Создаем в классе член-событие
        public event EventHandler<CloseKLPListEventArgs> CloseKLPList
        {
            add
            {
                // берем закрытую блокировку и добавляем обработчик
                // (передаваемый по значению) в список делегатов
                m_CloseKLPList += value;
            }
            remove
            {
                // берем закрытую блокировку и удаляем обработчик
                // (передаваемый по значению) из списка делегатов
                m_CloseKLPList -= value;
            }
        }
        /// <summary>
        /// Инициирует событие и уведомляет о нем зарегистрированные объекты
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCloseKLPList(CloseKLPListEventArgs e)
        {
            // Сохраняем поле делегата во временном поле для обеспечение безопасности потока
            EventHandler<CloseKLPListEventArgs> temp = m_CloseKLPList;
            // Если есть зарегистрированные объектв, уведомляем их
            if (temp != null) temp(this, e);
        }
        public void SimulateCloseKLPList(CLotOrder objOrder)
        {
            // Создаем объект, хранящий информацию, которую нужно передать
            // объектам, получающим уведомление о событии
            CloseKLPListEventArgs e = new CloseKLPListEventArgs(objOrder);

            // Вызываем виртуальный метод, уведомляющий наш объект о возникновении события
            // Если нет типа, переопределяющего этот метод, наш объект уведомит все объекты, 
            // подписавшиеся на уведомление о событии
            OnCloseKLPList(e);
        }

        private void OnCloseLotList(Object sender, CloseLotListEventArgs e)
        {
            try
            {
                tabControl.SelectedTabPage = tabPageKLPList;
                this.Refresh();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("OnCloseLotList. Текст ошибки: " + f.Message);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }

        private void OnCloseLotEditor(Object sender, CloseLotEditorEventArgs e)
        {
            try
            {
                switch (e.enOpenLotEditorMode)
                {
                    case OpenLotEditorMode.FromLotLis:
                        if (m_frmLotList != null)
                        {
                            m_frmLotList.ShowPageLotList();
                            if (tabControl.SelectedTabPage != tabPageLotList)
                            {
                                tabControl.SelectedTabPage = tabPageLotList;
                                this.Refresh();
                            }
                        }
                        break;
                    case OpenLotEditorMode.FromKLPEditor:
                        tabControl.SelectedTabPage = tabPageKLPEditor;
                        break;
                    default:
                        break;
                }

                this.Refresh();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("OnCloseLotList. Текст ошибки: " + f.Message);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }
        #endregion

        #region Конструктор
        public ctrlKLP(UniXP.Common.MENUITEM objMenuItem)
        {
            InitializeComponent();

            m_objMenuItem = objMenuItem;
            m_objProfile = objMenuItem.objProfile;
            m_objKLPList = null;
            m_objSelectedKLP = null;
            m_objLotOrder = null;
            m_objStockList = null;
            m_objSrcForKlp = null;
            m_bDisableEvents = false;
            m_bIsChanged = false;
            m_bIsReadOnly = false;
            m_frmLotList = null;

            AddGridColumns();

            tabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            m_bOnlyView = false;
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
                    "SendMessageToLog.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region Список КЛП

        private void AddGridColumns()
        {
            ColumnView.Columns.Clear();
            AddGridColumn(ColumnView, "ID", "Идентификатор");
            AddGridColumn(ColumnView, "CurrentKLPStateName", "Состояние");
            AddGridColumn(ColumnView, "Number", "Номер");
            AddGridColumn(ColumnView, "Date", "Дата заказа");
            AddGridColumn(ColumnView, "VendorName", "Поставщик");
            AddGridColumn(ColumnView, "StockAcceptingName", "Склад приёмки");
            AddGridColumn(ColumnView, "QuantityInDoc", "Кол-во по док-ту");
            AddGridColumn(ColumnView, "QuantityFact", "Кол-во факт.");
            AddGridColumn(ColumnView, "IsActive", "Активен");
            AddGridColumn(ColumnView, "IsCostCalc", "Расчёт с/с");
            AddGridColumn(ColumnView, "SumFactByPriceForCalcCostPriceInVendorCurrency", "Сумма");
            AddGridColumn(ColumnView, "SumFactByPriceForCalcCostPrice", "Сумма вал.");

            foreach (DevExpress.XtraGrid.Columns.GridColumn objColumn in ColumnView.Columns)
            {
                objColumn.OptionsColumn.AllowEdit = false;
                objColumn.OptionsColumn.AllowFocus = false;
                objColumn.OptionsColumn.ReadOnly = true;
                if (objColumn.FieldName == "VendorName")
                {
                    objColumn.BestFit();
                    //objColumn.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                }
                if (objColumn.FieldName == "ID") 
                {
                    objColumn.Visible = false;
                }
                if ((objColumn.FieldName == "QuantityInDoc") || (objColumn.FieldName == "QuantityFact"))
                {
                    objColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    objColumn.DisplayFormat.FormatString = "### ### ##0";
                    objColumn.SummaryItem.FieldName = objColumn.FieldName;
                    objColumn.SummaryItem.DisplayFormat = ((objColumn.FieldName == "QuantityInDoc") ? "Кол-во: {0:### ### ##0}" : "Кол-во факт.: {0:### ### ##0}");
                    objColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                }
                if (objColumn.FieldName == "SumFactPriceForCalcCostPriceInVendorCurrency")
                {
                    objColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    objColumn.DisplayFormat.FormatString = "### ### ##0.00";
                    objColumn.SummaryItem.FieldName = objColumn.FieldName;
                    objColumn.SummaryItem.DisplayFormat = "Сумма: {0:### ### ##0.00}";
                    objColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                }
                if (objColumn.FieldName == "SumFactPriceForCalcCostPrice")
                {
                    objColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    objColumn.DisplayFormat.FormatString = "### ### ##0.00";
                    objColumn.SummaryItem.FieldName = objColumn.FieldName;
                    objColumn.SummaryItem.DisplayFormat = "Сумма вал.: {0:### ### ##0.00}";
                    objColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                }
                if (objColumn.FieldName == "IsCostCalc")
                {
                    objColumn.ColumnEdit = repItemCheckEdit;
                }
            }
        }
        private void AddGridColumn(DevExpress.XtraGrid.Views.Base.ColumnView view, string fieldName, string caption) { AddGridColumn(view, fieldName, caption, null); }
        private void AddGridColumn(DevExpress.XtraGrid.Views.Base.ColumnView view, string fieldName, string caption, DevExpress.XtraEditors.Repository.RepositoryItem item) { AddGridColumn(view, fieldName, caption, item, "", DevExpress.Utils.FormatType.None); }
        private void AddGridColumn(DevExpress.XtraGrid.Views.Base.ColumnView view, string fieldName, string caption, DevExpress.XtraEditors.Repository.RepositoryItem item, string format, DevExpress.Utils.FormatType type)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = view.Columns.AddField(fieldName);
            column.Caption = caption;
            column.ColumnEdit = item;
            column.DisplayFormat.FormatType = type;
            column.DisplayFormat.FormatString = format;
            column.VisibleIndex = view.VisibleColumns.Count;
        }
        /// <summary>
        /// Загружает список КЛП
        /// </summary>
        /// <param name="objLotOrder">Заказ</param>
        public void LoadKLPList( CLotOrder objLotOrder )
        {
            m_objLotOrder = objLotOrder;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                gridControlKLPList.DataSource = null;
                System.String strErr = "";
                
                m_objKLPList = CKLPRepository.GetKLPList( m_objProfile, null, m_objLotOrder.ID, ref strErr );
                if( m_objKLPList == null )
                {
                    SendMessageToLog(strErr);
                    return;
                }

                gridControlKLPList.DataSource = m_objKLPList;
                lblOrderInfo.Text = m_strLblLotOrderInfoText + m_objLotOrder.Number + " от " + m_objLotOrder.Date.ToShortDateString();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Запрос списка КЛП. Текст ошибки: " + f.Message);
                //
            }
            finally
            {
                this.Cursor = Cursors.Default;
                tabControl.SelectedTabPage = tabPageKLPList;
                this.Refresh();
            }

            return ;
        }
        #endregion

        #region Свойства КЛП
        /// <summary>
        /// Возвращает ссылку на выбранный в списке КЛП
        /// </summary>
        /// <returns>ссылка на КЛП</returns>
        private CKLP GetSelectedKLP()
        {
            CKLP objRet = null;
            try
            {
                if ((((DevExpress.XtraGrid.Views.Grid.GridView)gridControlKLPList.MainView).RowCount > 0) &&
                    (((DevExpress.XtraGrid.Views.Grid.GridView)gridControlKLPList.MainView).FocusedRowHandle >= 0))
                {
                    System.Guid uuidID = (System.Guid)(((DevExpress.XtraGrid.Views.Grid.GridView)gridControlKLPList.MainView)).GetFocusedRowCellValue("ID");

                    objRet = m_objKLPList.Single<CKLP>(x => x.ID.CompareTo(uuidID) == 0);
                }
            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка поиска выбранного КЛП. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return objRet;
        }

        private void gridViewKLPList_RowCountChanged(object sender, EventArgs e)
        {
            try
            {
                ShowKLPProperties(GetSelectedKLP());

                barBtnAddKLP.Enabled = !m_bOnlyView;
                barBtnDeleteKLP.Enabled = ((!m_bOnlyView) && (gridViewKLPList.FocusedRowHandle >= 0));
                barBtnToLotList.Enabled = ((!m_bOnlyView) && (gridViewKLPList.FocusedRowHandle >= 0));
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Отображение свойств КЛП. Текст ошибки: " + f.Message);
            }
            return;
        }
        private void gridViewKLPList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                ShowKLPProperties(GetSelectedKLP());

                barBtnAddKLP.Enabled = !m_bOnlyView;
                barBtnDeleteKLP.Enabled = ((!m_bOnlyView) && (e.FocusedRowHandle >= 0));
                barBtnToLotList.Enabled = ((!m_bOnlyView) && (e.FocusedRowHandle >= 0));
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Отображение свойств КЛП. Текст ошибки: " + f.Message);
            }
            return;
        }

        /// <summary>
        /// Отображает свойства КЛП
        /// </summary>
        /// <param name="objKLP">КЛП</param>
        private void ShowKLPProperties(CKLP objKLP)
        {
            try
            {
                this.tableLayoutPanelAgreementShortInfo.SuspendLayout();

                txtLotOrderName.Text = "";
                txtVendorName.Text = "";
                txtStockStockAccepting.Text = "";
                txtLotOrderDate.Text = "";
                txtLotOrderState.Text = "";
                calcQuantity.Value = 0;
                calcQuantityFact.Value = 0;
                txtCostIsCalc.Text = "";
                calcSumFactPriceForCalcCostPriceInVendorCurrency.Value = 0;
                calcSumFactPriceForCalcCostPrice.Value = 0;

                if (objKLP != null)
                {
                    txtLotOrderName.Text = objKLP.Number;
                    txtVendorName.Text = objKLP.VendorName;
                    txtStockStockAccepting.Text = objKLP.StockAcceptingName;
                    txtLotOrderDate.Text = objKLP.Date.ToShortDateString();
                    txtLotOrderState.Text = objKLP.CurrentKLPStateName;
                    calcQuantity.Value = System.Convert.ToDecimal(objKLP.QuantityInDoc);
                    calcQuantityFact.Value = System.Convert.ToDecimal(objKLP.QuantityFact);
                    txtCostIsCalc.Text = objKLP.strIsCostCalc;
                    calcSumFactPriceForCalcCostPriceInVendorCurrency.Value = System.Convert.ToDecimal(objKLP.SumFactByPriceForCalcCostPriceInVendorCurrency);
                    calcSumFactPriceForCalcCostPrice.Value = System.Convert.ToDecimal(objKLP.SumFactByPriceForCalcCostPrice);
                }

                this.tableLayoutPanelAgreementShortInfo.ResumeLayout(false);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Отображение свойств КЛП. Текст ошибки: " + f.Message);
            }
            return;
        }
        #endregion

        #region Выход
        private void barBtnExit_Click(object sender, EventArgs e)
        {
            try
            {
                SimulateCloseKLPList(m_objLotOrder);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Текст ошибки: " + f.Message);
            }
            finally
            {
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
                cboxStock.Properties.Appearance.BackColor = ((cboxStock.SelectedItem == null) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                cboxKLPState.Properties.Appearance.BackColor = ((cboxKLPState.SelectedItem == null) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                txtKLPNum.Properties.Appearance.BackColor = ((txtKLPNum.Text == "") ? System.Drawing.Color.Tomato : System.Drawing.Color.White);

                KLPDate.Properties.Appearance.BackColor = ((KLPDate.DateTime == System.DateTime.MinValue) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);

                if (cboxStock.SelectedItem == null) { bRet = false; }
                if (cboxKLPState.SelectedItem == null) { bRet = false; }
                if (dataSet.Tables["KLPItems"].Rows.Count == 0) { bRet = false; }

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

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (m_bDisableEvents == true) { return; }

                if ((e.Column == colProductID) && (m_objSrcForKlp != null) && (e.Value != null))
                {

                    CLotOrderItems objItem = null;
                    try
                    {
                        objItem = m_objSrcForKlp.Cast<CLotOrderItems>().Single<CLotOrderItems>(x => x.Product.ID.CompareTo((System.Guid)e.Value) == 0);

                        gridView.SetRowCellValue(e.RowHandle, colMeasureID, objItem.Measure.ID);
                        gridView.SetRowCellValue(e.RowHandle, colOrderItems_MeasureName, objItem.Measure.ShortName);
                        gridView.SetRowCellValue(e.RowHandle, colLotOrderItems_Guid, objItem.ID);
                        gridView.SetRowCellValue(e.RowHandle, colQuantity, objItem.Quantity);
                        // 2013.02.11
                        // фактическое количество при создании КЛП должно быть равно нулю
                        // gridView.SetRowCellValue(e.RowHandle, colFactQuantity, objItem.Quantity);
                        gridView.SetRowCellValue(e.RowHandle, colFactQuantity, 0 );
                        gridView.SetRowCellValue(e.RowHandle, colDiscountVendorPrice, objItem.PriceVendorTarifWithDiscount);
                        gridView.SetRowCellValue(e.RowHandle, colCurrencyPrice, 0);
                        gridView.SetRowCellValue(e.RowHandle, colLotOrderItems_QuantityInDoc, objItem.Quantity);
                        gridView.SetRowCellValue(e.RowHandle, colLotOrderItems_QuantityInKLP, objItem.QuantityInKLP);
                        gridView.SetRowCellValue(e.RowHandle, colKLPItems_PartsName, objItem.Product.Article);
                        gridView.SetRowCellValue(e.RowHandle, colKLPItems_PartsArticle, objItem.Product.Name);
                        // страна производства
                        gridView.SetRowCellValue(e.RowHandle, colKLPItems_CountryProductionName, objItem.CountryProduction.Name);
                        gridView.SetRowCellValue(e.RowHandle, colCountryProductionID, objItem.CountryProduction.ID);
                        // таможенный тариф
                        gridView.SetRowCellValue(e.RowHandle, colCustomTarifPercent, objItem.CustomTarifPercent);

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

        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if ((gridView.GetRowCellValue(e.RowHandle, colQuantity) != null) &&
                    (gridView.GetRowCellValue(e.RowHandle, colFactQuantity) != null))
                {
                    System.Double dblQuantity = System.Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colQuantity));
                    System.Double dblFactQuantity = System.Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colFactQuantity));
                    if (dblQuantity != dblFactQuantity)
                    {
                        if ((e.Column == colQuantity) || (e.Column == colFactQuantity))
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

        #endregion

        #region Выпадающие списки
        /// <summary>
        /// Обновление выпадающих списков
        /// </summary>
        /// <returns>true - все списки успешно обновлены; false - ошибка</returns>
        private void LoadComboBoxItems()
        {
            try
            {
                cboxProductTradeMark.Properties.Items.Clear();
                cboxProductType.Properties.Items.Clear();

                // Склад
                cboxStock.Properties.Items.Clear();
                m_objStockList = ERP_Mercury.Common.CStock.GetStockList(m_objProfile, null);
                if (m_objStockList != null)
                {
                    foreach (ERP_Mercury.Common.CStock objStock in m_objStockList)
                    {
                        cboxStock.Properties.Items.Add(objStock.CompanyAbbr + " " + objStock.WareHouseName);
                    }
                }
                // Состояния КЛП
                cboxKLPState.Properties.Items.Clear();
                cboxKLPState.Properties.Items.AddRange(ERP_Mercury.Common.CKLPState.GetKLPStateList(m_objProfile, null));

                // Товары
                dataSet.Tables["SrcForKlpItems"].Clear();
                repositoryItemLookUpEditProduct.DataSource = dataSet.Tables["SrcForKlpItems"];

                // страны производства
                dataSet.Tables["CountryProduction"].Clear();
                List<ERP_Mercury.Common.CCountry> objCountryProductionList = ERP_Mercury.Common.CCountry.GetCountryList(m_objProfile, null);
                if ((objCountryProductionList != null) && (objCountryProductionList.Count > 0))
                {
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

            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка обновления выпадающих списков. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return ;
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
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("В результате применения фильтра будут удалены товары в КЛП,\nне соответствующие заданным условиям.\nУстановить фильтр?", "Внимание",
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

                List<CLotOrderItems> FilteredProductList = m_objSrcForKlp;

                if (TradeMarkId != System.Guid.Empty)
                {
                    FilteredProductList = m_objSrcForKlp.Where<CLotOrderItems>(x => x.Product.ProductTradeMark.ID == TradeMarkId).ToList<CLotOrderItems>();
                }

                if (PartTypeId != System.Guid.Empty)
                {
                    FilteredProductList = FilteredProductList.Where<CLotOrderItems>(x => x.Product.ProductType.ID == PartTypeId).ToList<CLotOrderItems>();
                }

                if (FilteredProductList.Count != m_objSrcForKlp.Count)
                {
                    dataSet.Tables["SrcForKlpItems"].Clear();

                    System.Data.DataRow newRowProduct = null;
                    dataSet.Tables["SrcForKlpItems"].Clear();
                    foreach (CLotOrderItems objItem in FilteredProductList)
                    {
                        newRowProduct = dataSet.Tables["SrcForKlpItems"].NewRow();
                        newRowProduct["ProductID"] = objItem.Product.ID;
                        newRowProduct["Product_MeasureID"] = objItem.Measure.ID;
                        newRowProduct["Product_MeasureName"] = objItem.Measure.ShortName;
                        newRowProduct["ProductFullName"] = objItem.Product.ProductFullName;
                        newRowProduct["ProductShortName"] = objItem.Product.Name;
                        newRowProduct["ProductArticle"] = objItem.Product.Article;
                        newRowProduct["OrderItems_OrderQuantity"] = objItem.QuantityOrder;
                        newRowProduct["OrderItems_ConfirmQuantity"] = objItem.QuantityConfirm;
                        newRowProduct["OrderItems_Quantity"] = objItem.Quantity;
                        newRowProduct["OrderItems_QuantityInKLP"] = objItem.QuantityInKLP;
                        newRowProduct["OrderItems_ID"] = objItem.ID;

                        newRowProduct["OrderItems_CountryProductionID"] = objItem.CountryProduction.ID;
                        newRowProduct["OrderItems_CountryProductionName"] = objItem.CountryProduction.Name;
                        newRowProduct["OrderItems_Customtarifpercent"] = objItem.CustomTarifPercent;

                        dataSet.Tables["SrcForKlpItems"].Rows.Add(newRowProduct);
                    }
                    newRowProduct = null;
                    dataSet.Tables["SrcForKlpItems"].AcceptChanges();
                }

                // теперь нужно проверить содержимое заказа на предмет товаров, не попадающих под условия фильтра
                if ((gridView.RowCount > 0) && ((TradeMarkId != System.Guid.Empty) || (PartTypeId != System.Guid.Empty)))
                {
                    System.Guid PartsGuid = System.Guid.Empty;
                    ERP_Mercury.Common.CProduct objProduct = null;
                    System.Boolean bOk = true;
                    System.Data.DataRow newRowOrderItems = null;
                    List<System.Data.DataRow> FilteredRowList = new List<DataRow>();

                    for (System.Int32 i = 0; i <= (gridView.RowCount - 1); i++)
                    {
                        
                        PartsGuid = (System.Guid)(gridView.GetDataRow(i)["ProductID"]);
                        bOk = false;
                        objProduct = null;
                        try
                        {
                            objProduct = m_objSrcForKlp.SingleOrDefault<CLotOrderItems>(x => x.Product.ID == PartsGuid).Product;
                        }
                        catch
                        {
                            objProduct = null;
                        }
                        if( (objProduct != null) && (objProduct.ID.CompareTo(System.Guid.Empty) != 0 ) )
                        {
                            // проверяем на соответствие марке
                            if (TradeMarkId != System.Guid.Empty)
                            {
                                bOk = (objProduct.ProductTradeMark.ID == TradeMarkId);
                            }
                            if ((bOk == true) && (PartTypeId != System.Guid.Empty))
                            {
                                bOk = (objProduct.ProductType.ID == PartTypeId);
                            }
                        }
                        if (bOk == true)
                        {
                            newRowOrderItems = dataSet.Tables["KLPItems"].NewRow();

                            newRowOrderItems["ProductID"] = (System.Guid)(gridView.GetDataRow(i)["ProductID"]);
                            newRowOrderItems["MeasureID"] = (System.Guid)(gridView.GetDataRow(i)["MeasureID"]);
                            newRowOrderItems["Quantity"] = gridView.GetDataRow(i)["Quantity"];
                            newRowOrderItems["FactQuantity"] = gridView.GetDataRow(i)["FactQuantity"];
                            newRowOrderItems["CurrencyPrice"] = gridView.GetDataRow(i)["CurrencyPrice"];
                            newRowOrderItems["DiscountVendorPrice"] = gridView.GetDataRow(i)["DiscountVendorPrice"];
                            newRowOrderItems["KLPItems_MeasureName"] = gridView.GetDataRow(i)["KLPItems_MeasureName"];
                            newRowOrderItems["KLPItems_PartsArticle"] = gridView.GetDataRow(i)["KLPItems_PartsArticle"];
                            newRowOrderItems["KLPItems_PartsName"] = gridView.GetDataRow(i)["KLPItems_PartsName"];
                            newRowOrderItems["LotOrderItems_Guid"] = gridView.GetDataRow(i)["LotOrderItems_Guid"];
                            newRowOrderItems["KLPItems_Id"] = gridView.GetDataRow(i)["KLPItems_Id"];
                            newRowOrderItems["LotOrderItems_QuantityInDoc"] = gridView.GetDataRow(i)["LotOrderItems_QuantityInDoc"];
                            newRowOrderItems["LotOrderItems_QuantityInKLP"] = gridView.GetDataRow(i)["LotOrderItems_QuantityInKLP"];

                            newRowOrderItems["CountryProductionID"] = gridView.GetDataRow(i)["CountryProductionID"];
                            newRowOrderItems["KLPItems_CountryProductionName"] = gridView.GetDataRow(i)["KLPItems_CountryProductionName"];
                            newRowOrderItems["CustomTarifPercent"] = gridView.GetDataRow(i)["CustomTarifPercent"];

                            FilteredRowList.Add(newRowOrderItems);

                        }
                    }

                    objProduct = null;
                    newRowOrderItems = null;
                    dataSet.Tables["KLPItems"].Rows.Clear();

                    if (FilteredRowList.Count > 0)
                    {
                        foreach (System.Data.DataRow RowKLPItems in FilteredRowList)
                        {
                            dataSet.Tables["KLPItems"].Rows.Add(RowKLPItems);
                        }
                    }
                    dataSet.Tables["KLPItems"].AcceptChanges();

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

        #region запись в DBGrid

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == Keys.Down) && (e.Alt == false))
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
                row["CurrencyPrice"] = 0;
                row["FactQuantity"] = 0;
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
                if ((gridView.GetDataRow(e.RowHandle)["Quantity"] == System.DBNull.Value) ||
                    (System.Convert.ToDouble(gridView.GetDataRow(e.RowHandle)["Quantity"]) < 0))
                {
                    bOK = false;
                    gridView.SetColumnError(colQuantity, "недопустимое количество", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                }
                if ((gridView.GetDataRow(e.RowHandle)["FactQuantity"] == System.DBNull.Value) ||
                    (System.Convert.ToDouble(gridView.GetDataRow(e.RowHandle)["FactQuantity"]) < 0))
                {
                    bOK = false;
                    gridView.SetColumnError(colFactQuantity, "недопустимое фактическое количество", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
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
                    gridView.SetColumnError(colOrderItems_MeasureName, "укажите, пожалуйста, страну производства", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
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

        #region Потоки
        /// <summary>
        /// Создает форму со списком товара
        /// </summary>
        /// <param name="objPartsList">списком товара</param>
        private void SetProductListToForm(List<CLotOrderItems> objSrcForKlp)
        {
            try
            {
                m_objSrcForKlp = objSrcForKlp;

                System.Data.DataRow newRowProduct = null;
                dataSet.Tables["SrcForKlpItems"].Clear();
                foreach (CLotOrderItems objItem in m_objSrcForKlp)
                {
                    newRowProduct = dataSet.Tables["SrcForKlpItems"].NewRow();
                    newRowProduct["ProductID"] = objItem.Product.ID;
                    newRowProduct["Product_MeasureID"] = objItem.Measure.ID;
                    newRowProduct["Product_MeasureName"] = objItem.Measure.ShortName;
                    newRowProduct["ProductFullName"] = objItem.Product.ProductFullName;
                    newRowProduct["ProductShortName"] = objItem.Product.Name;
                    newRowProduct["ProductArticle"] = objItem.Product.Article;
                    newRowProduct["OrderItems_OrderQuantity"] = objItem.QuantityOrder;
                    newRowProduct["OrderItems_ConfirmQuantity"] = objItem.QuantityConfirm;
                    newRowProduct["OrderItems_Quantity"] = objItem.Quantity;
                    newRowProduct["OrderItems_QuantityInKLP"] = objItem.QuantityInKLP;
                    newRowProduct["OrderItems_ID"] = objItem.ID;

                    newRowProduct["OrderItems_CountryProductionID"] = objItem.CountryProduction.ID;
                    newRowProduct["OrderItems_CountryProductionName"] = objItem.CountryProduction.Name;
                    newRowProduct["OrderItems_CustomTarifPercent"] = objItem.CustomTarifPercent;

                    dataSet.Tables["SrcForKlpItems"].Rows.Add(newRowProduct);
                }
                newRowProduct = null;
                dataSet.Tables["SrcForKlpItems"].AcceptChanges();

                if (m_bNewObject == true)
                {
                    // для нового КЛП мы сразу же загружаем список тех позиий, которые не включены ни в одно КЛП
                    dataSet.Tables["KLPItems"].Clear();
                    System.Data.DataRow newRowOrderItems = null;

                    foreach (CLotOrderItems objItem in m_objSrcForKlp)
                    {
                        newRowOrderItems = dataSet.Tables["KLPItems"].NewRow();

                        newRowOrderItems["ProductID"] = objItem.Product.ID;
                        newRowOrderItems["MeasureID"] = objItem.Measure.ID;
                        newRowOrderItems["Quantity"] = ( objItem.Quantity - objItem.QuantityInKLP );
                        newRowOrderItems["FactQuantity"] = (objItem.Quantity - objItem.QuantityInKLP);
                        newRowOrderItems["CurrencyPrice"] = objItem.PriceForCalcCostPrice;
                        newRowOrderItems["DiscountVendorPrice"] = objItem.PriceForCalcCostPrice;
                        newRowOrderItems["KLPItems_MeasureName"] = objItem.Measure.ShortName;
                        newRowOrderItems["KLPItems_PartsArticle"] = objItem.Product.Article;
                        newRowOrderItems["KLPItems_PartsName"] = objItem.Product.Name;
                        newRowOrderItems["LotOrderItems_Guid"] = objItem.ID;
                        newRowOrderItems["KLPItems_Id"] = objItem.Ib_Id;
                        newRowOrderItems["LotOrderItems_QuantityInDoc"] = objItem.Quantity;
                        newRowOrderItems["LotOrderItems_QuantityInKLP"] = objItem.QuantityInKLP;

                        newRowOrderItems["CountryProductionID"] = objItem.CountryProduction.ID;
                        newRowOrderItems["KLPItems_CountryProductionName"] = objItem.CountryProduction.Name;
                        newRowOrderItems["CustomTarifPercent"] = objItem.CustomTarifPercent;

                        dataSet.Tables["KLPItems"].Rows.Add(newRowOrderItems);
                    }
                    newRowOrderItems = null;

                    dataSet.Tables["KLPItems"].AcceptChanges();
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
        /// загружает список товаров и список новых товаров
        /// </summary>
        private void LoadPartssList()
        {
            try
            {
                // товары
                System.Int32 iRes = 0;
                System.String strErr = "";
                m_objSrcForKlp = CLotOrderRepository.GetSrcForKlpItems( m_objProfile, null, m_objLotOrder.ID, ref iRes, ref strErr);
                if (m_objSrcForKlp != null)
                {
                    this.Invoke(m_SetProductListToFormDelegate, new Object[] { m_objSrcForKlp });
                }
            }
            catch (System.Exception f)
            {
                this.Invoke(m_SendMessageToLogDelegate, new Object[] { ("Ошибка обновления списка товаров. Текст ошибки: " + f.Message) });
            }
            finally
            {
                EventStopThread.Set();
                this.m_bThreadFinishJob = true;
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
                KLPDate.Properties.ReadOnly = bSet;
                KLPStartAccepting.Properties.ReadOnly = bSet;
                KLPEndAccepting.Properties.ReadOnly = bSet;
                txtDescription.Properties.ReadOnly = bSet;
                txtKLPNum.Properties.ReadOnly = bSet;

                cboxStock.Properties.ReadOnly = bSet;
                cboxKLPState.Properties.ReadOnly = bSet;

                cboxProductTradeMark.Properties.ReadOnly = bSet;
                cboxProductType.Properties.ReadOnly = bSet;

                gridView.OptionsBehavior.Editable = !bSet;
                checkKLPIsActive.Properties.ReadOnly = bSet;
                checkKLPCostIsCalc.Properties.ReadOnly = true;

                m_bIsReadOnly = bSet;

                btnEdit.Enabled = bSet;
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

                //StartThreadWithLoadData();
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

        #region Редактировать КЛП
        /// <summary>
        /// очистка содержимого элементов управления
        /// </summary>
        private void ClearControls()
        {
            try
            {
                txtDescription.Text = "";
                txtKLPNum.Text = "";
                cboxStock.SelectedItem = null;
                cboxKLPState.SelectedItem = null;
                checkKLPIsActive.Checked = false;
                checkKLPCostIsCalc.Checked = false;

                cboxProductTradeMark.SelectedItem = null;
                cboxProductType.SelectedItem = null;

                KLPStartAccepting.EditValue = null;
                KLPEndAccepting.EditValue = null;
                KLPDate.DateTime = System.DateTime.MinValue;


                dataSet.Tables["KLPItems"].Clear();
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

        private void LoadKLPItemsListToDataSet()
        {
            try
            {
                System.Data.DataRow newRowProduct = null;
                dataSet.Tables["SrcForKlpItems"].Clear();
                foreach (CLotOrderItems objItem in m_objSrcForKlp)
                {
                    newRowProduct = dataSet.Tables["SrcForKlpItems"].NewRow();
                    newRowProduct["ProductID"] = objItem.Product.ID;
                    newRowProduct["Product_MeasureID"] = objItem.Measure.ID;
                    newRowProduct["Product_MeasureName"] = objItem.Measure.ShortName;
                    newRowProduct["ProductFullName"] = objItem.Product.ProductFullName;
                    newRowProduct["ProductShortName"] = objItem.Product.Name;
                    newRowProduct["ProductArticle"] = objItem.Product.Article;
                    newRowProduct["OrderItems_OrderQuantity"] = objItem.QuantityOrder;
                    newRowProduct["OrderItems_ConfirmQuantity"] = objItem.QuantityConfirm;
                    newRowProduct["OrderItems_Quantity"] = objItem.Quantity;
                    newRowProduct["OrderItems_QuantityInKLP"] = objItem.QuantityInKLP;
                    newRowProduct["OrderItems_ID"] = objItem.ID;

                    newRowProduct["OrderItems_CountryProductionID"] = objItem.CountryProduction.ID;
                    newRowProduct["OrderItems_CountryProductionName"] = objItem.CountryProduction.Name;
                    newRowProduct["OrderItems_CustomTarifPercent"] = objItem.CustomTarifPercent;

                    dataSet.Tables["SrcForKlpItems"].Rows.Add(newRowProduct);
                }
                newRowProduct = null;
                dataSet.Tables["SrcForKlpItems"].AcceptChanges();

                dataSet.Tables["KLPItems"].Clear();
                System.Data.DataRow newRowOrderItems = null;

                foreach ( CKLPItems objItem in m_objSelectedKLP.KLPItemsList )
                {
                    newRowOrderItems = dataSet.Tables["KLPItems"].NewRow();

                    newRowOrderItems["KLPItemsID"] = objItem.ID;
                    newRowOrderItems["ProductID"] = objItem.Product.ID;
                    newRowOrderItems["MeasureID"] = objItem.Measure.ID;
                    newRowOrderItems["Quantity"] = objItem.Quantity;
                    newRowOrderItems["FactQuantity"] = objItem.QuantityFact;
                    newRowOrderItems["CurrencyPrice"] = objItem.PriceForCalcCostPrice;
                    newRowOrderItems["DiscountVendorPrice"] = objItem.PriceForCalcCostPriceInVendorCurrency;
                    newRowOrderItems["KLPItems_MeasureName"] = objItem.Measure.ShortName;
                    newRowOrderItems["KLPItems_PartsArticle"] = objItem.Product.Article;
                    newRowOrderItems["KLPItems_PartsName"] = objItem.Product.Name;
                    newRowOrderItems["LotOrderItems_Guid"] = objItem.ParentLotOrderItemsID;
                    newRowOrderItems["KLPItems_Id"] = objItem.Ib_Id;
                    newRowOrderItems["LotOrderItems_QuantityInDoc"] = objItem.Quantity;
                    newRowOrderItems["LotOrderItems_QuantityInKLP"] = objItem.QuantityFact;

                    newRowOrderItems["CountryProductionID"] = objItem.CountryProduction.ID;
                    newRowOrderItems["KLPItems_CountryProductionName"] = objItem.CountryProduction.Name;
                    newRowOrderItems["CustomTarifPercent"] = objItem.CustomTarifPercent;

                    dataSet.Tables["KLPItems"].Rows.Add(newRowOrderItems);
                }
                newRowOrderItems = null;

                dataSet.Tables["KLPItems"].AcceptChanges();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("LoadKLPItemsListToDataSet. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        /// <summary>
        /// Загружает свойства КЛП для редактирования
        /// </summary>
        /// <param name="objKLP">КЛП</param>
        /// <param name="bNewObject">признак "новый заказ"</param>
        public void EditKLP(CKLP objKLP, System.Boolean bNewObject)
        {
            if (objKLP == null) { return; }
            m_bDisableEvents = true;
            m_bNewObject = bNewObject;
            try
            {
                m_objSelectedKLP = objKLP;

                LoadComboBoxItems();

                System.Int32 iRes = 0;
                System.String strErr = "";

                // запрашиваем приложение к КЛП
                m_objSelectedKLP.KLPItemsList = CKLPRepository.GetKLPItemsList( m_objProfile, null, m_objSelectedKLP.ID, ref iRes, ref strErr );
                // теперь необходимо получить список позиций, доступных для включения в КЛП
                m_objSrcForKlp = CLotOrderRepository.GetSrcForKlpItems(m_objProfile, null, m_objLotOrder.ID, ref iRes, ref strErr);
                if (m_objSrcForKlp == null) { m_objSrcForKlp = new List<CLotOrderItems>(); }
                // у нас есть список позиций из заказа, которые не включены ни в одно КЛП
                // добавим в него записи из приложения к КЛП
                if (m_objSelectedKLP.KLPItemsList != null)
                {
                    foreach (CKLPItems objKLPItems in m_objSelectedKLP.KLPItemsList)
                    {
                        m_objSrcForKlp.Add(new CLotOrderItems()
                        {
                            ID = objKLPItems.ParentLotOrderItemsID,
                            Ib_Id = 0,
                            Product = objKLPItems.Product,
                            Measure = objKLPItems.Measure,
                            QuantityOrder = objKLPItems.Quantity,
                            QuantityConfirm = objKLPItems.Quantity,
                            Quantity = objKLPItems.Quantity,
                            PriceForCalcCostPrice = objKLPItems.PriceForCalcCostPrice,
                            DiscountPercent = 0,
                            ProductWeightInDirectory = 0,
                            QuantityInKLP = objKLPItems.QuantityFact,
                            CountryProduction = objKLPItems.CountryProduction,
                            CustomTarifPercent = objKLPItems.CustomTarifPercent
                        });
                    }
                }

                this.tableLayoutPanelBackground.SuspendLayout();

                ClearControls();

                txtKLPNum.Text = m_objSelectedKLP.Number;
                KLPDate.DateTime = m_objSelectedKLP.Date;
                if (m_objSelectedKLP.DateTimeStartAccepting == System.DateTime.MinValue)
                {
                    KLPStartAccepting.EditValue = null;
                }
                else
                {
                    KLPStartAccepting.DateTime = m_objSelectedKLP.DateTimeStartAccepting;
                }
                if (m_objSelectedKLP.DateTimeEndAccepting == System.DateTime.MinValue)
                {
                    KLPEndAccepting.EditValue = null;
                }
                else
                {
                    KLPEndAccepting.DateTime = m_objSelectedKLP.DateTimeEndAccepting;
                }

                txtDescription.Text = m_objSelectedKLP.Description;
                checkKLPIsActive.Checked = m_objSelectedKLP.IsActive;
                checkKLPCostIsCalc.Checked = m_objSelectedKLP.IsCostCalc;

                cboxStock.SelectedItem = null;
                if (m_objSelectedKLP.StockAccepting != null)
                {
                    for( System.Int32 i=0; i< cboxStock.Properties.Items.Count; i++ )
                    {
                        if( cboxStock.Properties.Items[i].ToString() == ( m_objSelectedKLP.StockAccepting.CompanyAbbr + " " + m_objSelectedKLP.StockAccepting.WareHouseName ) )
                        {
                            cboxStock.SelectedIndex = i;
                            break;
                        }
                    }
                }
                cboxKLPState.SelectedItem = (m_objSelectedKLP.CurrentKLPState == null) ? null : cboxKLPState.Properties.Items.Cast<ERP_Mercury.Common.CKLPState>().Single<ERP_Mercury.Common.CKLPState>(x => x.ID.CompareTo(m_objSelectedKLP.CurrentKLPState.ID) == 0);

                cboxProductTradeMark.Properties.Items.Add(new ERP_Mercury.Common.CProductTradeMark() { ID = System.Guid.Empty, Name = "" });
                cboxProductTradeMark.Properties.Items.AddRange(ERP_Mercury.Common.CProductTradeMark.GetProductTradeMarkList(m_objProfile, null));
                cboxProductType.Properties.Items.Add(new ERP_Mercury.Common.CProductType() { ID = System.Guid.Empty, Name = "" });
                cboxProductType.Properties.Items.AddRange(ERP_Mercury.Common.CProductType.GetProductTypeList(m_objProfile, null));

                LoadKLPItemsListToDataSet();

                SetPropertiesModified(false);
                ValidateProperties();

                SetModeReadOnly(true);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка редактирования КЛП. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.tableLayoutPanelBackground.ResumeLayout(false);
                m_bDisableEvents = false;
                btnCancel.Enabled = true;
                tabControl.SelectedTabPage = tabPageKLPEditor;
            }
            return;
        }

        private void gridControlKLPList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                EditKLP(GetSelectedKLP(), false);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка редактирования КЛП. Текст ошибки: " + f.Message);
            }
            finally
            {
                txtKLPNum.Focus();
            }
            return;
        }


        #endregion

        #region Новый КЛП
        /// <summary>
        /// Новый КЛП
        /// </summary>
        public void NewKLP(CLotOrder objLotOrder)
        {
            try
            {
                m_bNewObject = true;
                m_bDisableEvents = true;
                m_objLotOrder = objLotOrder;


                m_objSelectedKLP = new CKLP();
                m_objSelectedKLP.KLPItemsList = new List<CKLPItems>();

                LoadComboBoxItems();

                this.tableLayoutPanelBackground.SuspendLayout();

                ClearControls();

                KLPDate.DateTime = System.DateTime.Today;
                txtDescription.Text = m_objSelectedKLP.Description;
                checkKLPIsActive.Checked = true;
                checkKLPCostIsCalc.Checked = false;
                cboxStock.SelectedItem = null;
                if (m_objSelectedKLP.StockAccepting != null)
                {
                    for (System.Int32 i = 0; i < cboxStock.Properties.Items.Count; i++)
                    {
                        if (cboxStock.Properties.Items[i].ToString() == (m_objSelectedKLP.StockAccepting.CompanyAbbr + " " + m_objSelectedKLP.StockAccepting.WareHouseName))
                        {
                            cboxStock.SelectedIndex = i;
                            break;
                        }
                    }
                }

                cboxKLPState.SelectedItem = (cboxKLPState.Properties.Items.Count == 0) ? null : cboxKLPState.Properties.Items[0];

                cboxProductTradeMark.Properties.Items.Add(new ERP_Mercury.Common.CProductTradeMark() { ID = System.Guid.Empty, Name = "" });
                cboxProductTradeMark.Properties.Items.AddRange(ERP_Mercury.Common.CProductTradeMark.GetProductTradeMarkList(m_objProfile, null));
                cboxProductType.Properties.Items.Add(new ERP_Mercury.Common.CProductType() { ID = System.Guid.Empty, Name = "" });
                cboxProductType.Properties.Items.AddRange(ERP_Mercury.Common.CProductType.GetProductTypeList(m_objProfile, null));

                btnEdit.Enabled = false;
                btnCancel.Enabled = true;

                SetModeReadOnly(false);
                SetPropertiesModified(true);

                StartThreadWithLoadData();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка создания КЛП. Текст ошибки: " + f.Message);
            }
            finally
            {
                tableLayoutPanelBackground.ResumeLayout(false);
                m_bDisableEvents = false;
                tabControl.SelectedTabPage = tabPageKLPEditor;
                txtKLPNum.Focus();
            }
            return;
        }

        private void barBtnAddKLP_Click(object sender, EventArgs e)
        {
            try
            {
                NewKLP(m_objLotOrder);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка создания КЛП. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }


        #endregion

        #region Удалить КЛП
        /// <summary>
        /// Удаляет КЛП
        /// </summary>
        /// <param name="objKLP">КЛП</param>
        private void DeleteKLP(CKLP objKLP)
        {
            if (objKLP == null) { return; }
            try
            {
                System.Int32 iFocusedRowHandle = gridView.FocusedRowHandle;
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Подтвердите, пожалуйста, удаление КЛП.\n\n№" + objKLP.Number +
                    "\nДата: " + objKLP.Date.ToShortDateString() + "\nПоставщик: " + objKLP.Vendor.Name, "Подтверждение",
                    System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == DialogResult.No) { return; }

                System.String strErr = "";
                if ( CKLPRepository.DeleteKLP(m_objProfile, null, objKLP.ID, ref strErr) == true)
                {
                    LoadKLPList( m_objLotOrder );
                }
                else
                {
                    SendMessageToLog("Удаление КЛП. Текст ошибки: " + strErr);
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Удаление КЛП. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }
        private void barBtnDeleteKLP_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteKLP( GetSelectedKLP());
            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("Удаление КЛП. Текст ошибки: " + f.Message);
            }
            finally
            {
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
                tabControl.SelectedTabPage = tabPageKLPList;
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
        /// Проверка на предмет того, есть ли в КЛП дублирующиеся позиции
        /// </summary>
        /// <returns>true- дубликаты присутствуют; false - дубликатов нет</returns>
        private System.Boolean bIsExistsDublicatePositionInKLP( ref System.String strErr )
        {
            System.Boolean bRet = false;
            try
            {
                System.Guid LotOrderItemsGuid = System.Guid.Empty;
                System.String strPartsName = "";
                System.Int32 iRowCount = 0;
                for (System.Int32 i = 0; i < dataSet.Tables["KLPItems"].Rows.Count; i++)
                {
                    LotOrderItemsGuid = (System.Guid)dataSet.Tables["KLPItems"].Rows[i]["LotOrderItems_Guid"];
                    strPartsName = ((System.String)dataSet.Tables["KLPItems"].Rows[i]["KLPItems_PartsArticle"] + " " + (System.String)dataSet.Tables["KLPItems"].Rows[i]["KLPItems_PartsName"]);
                    iRowCount = 0;

                    for (System.Int32 i2 = 0; i2 < dataSet.Tables["KLPItems"].Rows.Count; i2++)
                    {
                        if (((System.Guid)dataSet.Tables["KLPItems"].Rows[i2]["LotOrderItems_Guid"]).CompareTo(LotOrderItemsGuid) == 0)
                        {
                            iRowCount++;
                        }
                    }

                    if (iRowCount > 1) 
                    {
                        strErr = "В приложении к КЛП присутствует более одной позиции с указанным товаром:\n" + strPartsName;
                        break; 
                    }
                }

                bRet = (iRowCount > 1);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка проверки дубликатов значений в КЛП. Текст ошибки: " + f.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return bRet;
        }

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
                dataSet.Tables["KLPItems"].AcceptChanges();
                System.String KLP_Num = txtKLPNum.Text; 
                System.DateTime KLP_Date = KLPDate.DateTime;
                System.DateTime KLP_StartAccepting = ( (KLPStartAccepting.EditValue == null) ? System.DateTime.MinValue : KLPStartAccepting.DateTime );
                System.DateTime KLP_EndAccepting = ((KLPEndAccepting.EditValue == null) ? System.DateTime.MinValue : KLPEndAccepting.DateTime);
                System.Guid KLPState_Guid = (( cboxKLPState.SelectedItem == null) ? (System.Guid.Empty) : ((ERP_Mercury.Common.CKLPState)cboxKLPState.SelectedItem).ID);
                System.Guid Stock_Guid = System.Guid.Empty;
                if( cboxStock.SelectedItem != null )
                {
                    foreach( ERP_Mercury.Common.CStock objStock in m_objStockList )
                    {
                        if( ( objStock.CompanyAbbr + " " + objStock.WareHouseName ) == cboxStock.Text )
                        {
                            Stock_Guid = objStock.ID;
                            break;
                        }
                    }
                }
                System.Guid LotOrder_Guid = m_objLotOrder.ID; 
                System.String KLP_Description = txtDescription.Text;
                System.Boolean KLP_IsActive = checkKLPIsActive.Checked;

                System.Guid KLP_Guid = ((m_bNewObject == true) ? System.Guid.Empty : m_objSelectedKLP.ID);

                System.Int32 KLP_Id = ((m_bNewObject == true) ? 0 : m_objSelectedKLP.Ib_ID);
                System.Double SumFactByPriceForCalcCostPrice = 0;
                System.Double SumFactByPriceForCalcCostPriceInVendorCurrency = 0;

                List<CKLPItems> objKLPItemList = new List<CKLPItems>();

                System.Guid uuidKLPItemsID = System.Guid.Empty;
                System.Guid uuidLotOrderItemsID = System.Guid.Empty;
                System.Guid uuidProductID = System.Guid.Empty;
                System.Guid uuidMeasureID = System.Guid.Empty;
                System.Guid uuidCountryProductionID = System.Guid.Empty;
                System.Double dblQuantity = 0;
                System.Double dblQuantityFact = 0;
                System.Double dblPriceForCalcCostPrice = 0;
                System.Double dblPriceForCalcCostPriceInVendorCurrency = 0;
                System.Double dblCustomTarifPercent = 0;

                for (System.Int32 i = 0; i < dataSet.Tables["KLPItems"].Rows.Count; i++)
                {
                    if (
                        (dataSet.Tables["KLPItems"].Rows[i]["LotOrderItems_Guid"] == System.DBNull.Value) ||
                        (dataSet.Tables["KLPItems"].Rows[i]["ProductID"] == System.DBNull.Value) ||
                        (dataSet.Tables["KLPItems"].Rows[i]["MeasureID"] == System.DBNull.Value) ||
                        (dataSet.Tables["KLPItems"].Rows[i]["CountryProductionID"] == System.DBNull.Value) ||
                        (dataSet.Tables["KLPItems"].Rows[i]["FactQuantity"] == System.DBNull.Value))
                    {
                        continue;
                    }
                    if (m_bNewObject == true)
                    {
                        uuidKLPItemsID = System.Guid.NewGuid();
                    }
                    else
                    {
                        uuidKLPItemsID = ((dataSet.Tables["KLPItems"].Rows[i]["KLPItemsID"] == System.DBNull.Value) ? System.Guid.NewGuid() : (System.Guid)(dataSet.Tables["KLPItems"].Rows[i]["KLPItemsID"]));
                    }
                    uuidProductID = (System.Guid)(dataSet.Tables["KLPItems"].Rows[i]["ProductID"]);
                    uuidMeasureID = (System.Guid)(dataSet.Tables["KLPItems"].Rows[i]["MeasureID"]);
                    uuidCountryProductionID = (System.Guid)(dataSet.Tables["KLPItems"].Rows[i]["CountryProductionID"]);
                    uuidLotOrderItemsID = (System.Guid)dataSet.Tables["KLPItems"].Rows[i]["LotOrderItems_Guid"];
                    dblQuantity = System.Convert.ToDouble(dataSet.Tables["KLPItems"].Rows[i]["Quantity"]);
                    dblQuantityFact = System.Convert.ToDouble(dataSet.Tables["KLPItems"].Rows[i]["FactQuantity"]);
                    dblPriceForCalcCostPrice = System.Convert.ToDouble(dataSet.Tables["KLPItems"].Rows[i]["CurrencyPrice"]);
                    dblPriceForCalcCostPriceInVendorCurrency = System.Convert.ToDouble(dataSet.Tables["KLPItems"].Rows[i]["DiscountVendorPrice"]);
                    dblCustomTarifPercent = System.Convert.ToDouble(dataSet.Tables["KLPItems"].Rows[i]["CustomTarifPercent"]);

                    objKLPItemList.Add(new CKLPItems()
                    {
                        ID = uuidKLPItemsID,
                        Product = new ERP_Mercury.Common.CProduct() { ID = uuidProductID },
                        Measure = new ERP_Mercury.Common.CMeasure() { ID = uuidMeasureID },
                        QuantityFact = dblQuantityFact,
                        Quantity = dblQuantity,
                        ParentLotOrderItemsID = uuidLotOrderItemsID,
                        PriceForCalcCostPrice = dblPriceForCalcCostPrice,
                        PriceForCalcCostPriceInVendorCurrency = dblPriceForCalcCostPriceInVendorCurrency,
                        CountryProduction = new ERP_Mercury.Common.CCountry() { ID = uuidCountryProductionID },
                        CustomTarifPercent = dblCustomTarifPercent
                    });
                }
                System.Data.DataTable addedItems = ((gridControl.DataSource == null) ? null : CKLPItems.ConvertListToTable(objKLPItemList, KLP_Guid, ref strErr));
                objKLPItemList = null;

                // проверка значений
                if (CKLPRepository.CheckAllPropertiesForSave(KLP_Date, LotOrder_Guid,   Stock_Guid, KLPState_Guid,
                     addedItems, ref strErr) == true)
                {
                    if (m_bNewObject == true)
                    {
                        // новый КЛП

                        bOkSave = CKLPRepository.AddKLP(m_objProfile, null, KLP_Num, KLP_Date, KLP_StartAccepting, KLP_EndAccepting,
                            KLPState_Guid, Stock_Guid, LotOrder_Guid, KLP_Description, false, KLP_IsActive, addedItems,
                            ref KLP_Guid, ref KLP_Id, ref SumFactByPriceForCalcCostPrice, 
                            ref SumFactByPriceForCalcCostPriceInVendorCurrency, ref strErr);
                        if (bOkSave == true)
                        {
                            m_objSelectedKLP.ID = KLP_Guid;
                            m_objSelectedKLP.Ib_ID = KLP_Id;
                        }
                    }
                    else
                    {
                        bOkSave = CKLPRepository.EditKLP(m_objProfile, null, KLP_Num, KLP_Date, KLP_StartAccepting, KLP_EndAccepting,
                            KLPState_Guid, Stock_Guid, LotOrder_Guid, KLP_Description,
                            false, KLP_IsActive, addedItems, KLP_Guid, ref SumFactByPriceForCalcCostPrice, 
                            ref SumFactByPriceForCalcCostPriceInVendorCurrency, ref strErr);
                    }
                }

                if (bOkSave == true)
                {
                    m_objSelectedKLP.SumFactByPriceForCalcCostPrice = SumFactByPriceForCalcCostPrice;
                    m_objSelectedKLP.SumFactByPriceForCalcCostPriceInVendorCurrency = SumFactByPriceForCalcCostPriceInVendorCurrency;
                    m_objSelectedKLP.Number = KLP_Num;
                    m_objSelectedKLP.IsActive = KLP_IsActive;
                    m_objSelectedKLP.Date = KLP_Date;
                    m_objSelectedKLP.DateTimeStartAccepting = KLP_StartAccepting;
                    m_objSelectedKLP.DateTimeEndAccepting = KLP_EndAccepting;
                    m_objSelectedKLP.Vendor = m_objLotOrder.Vendor;
                    m_objSelectedKLP.Currency = m_objLotOrder.Currency;
                    m_objSelectedKLP.CurrentKLPState = ((cboxKLPState.SelectedItem == null) ? null : (ERP_Mercury.Common.CKLPState)cboxKLPState.SelectedItem);
                    m_objSelectedKLP.Description = KLP_Description;
                }

                bRet = bOkSave;
            }
            catch (System.Exception f)
            {
                strErr = f.Message;
                SendMessageToLog("Ошибка сохранения изменений в КЛП. Текст ошибки: " + f.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return bRet;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                System.String strErr = "";
                
                dataSet.Tables["KLPItems"].AcceptChanges();
                if (bIsExistsDublicatePositionInKLP(ref strErr) == true)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(strErr, "Внимание",
                         System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return;
                }

                if (bSaveChanges(ref strErr) == true)
                {
                    // обновляем список КЛП для заказа
                    LoadKLPList(m_objLotOrder);
                    tabControl.SelectedTabPage = tabPageKLPList; 
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(strErr, "Внимание",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка сохранения изменений в КЛП. Текст ошибки: " + f.Message);
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
            System.Int32 iStartRow = 12;
            System.Int32 iCurrentRow = iStartRow;
            object m = Type.Missing;
            
            System.Int32 iColumnPartsId = 1;
            System.Int32 iRowKLPNum = 3;
            System.Int32 iRowKLPId = 4;
//            System.Int32 iRowLotDeliveryDate = 6;
            System.Int32 iColumnPartsArticle = 2;
            System.Int32 iColumnPartsName = 3;
            System.Int32 iColumnQuantityInDoc = 4;
            System.Int32 iColumnBarCode = 8;
            System.Int32 iColumnCountry = 9;
            System.Int32 iColumnAlcoholicContentPercent = 11;
            System.String strStockMan = "Кладовщик: _________________/___________________";
            System.String strStockManager = "заведующий складом: _________________/___________________";

            //Excel.Range oRng;

            try
            {
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

                oSheet.Cells[iRowKLPNum, iColumnPartsId] = System.Convert.ToString(oSheet.get_Range(oSheet.Cells[iRowKLPNum, iColumnPartsId], oSheet.Cells[iRowKLPNum, iColumnPartsId]).Value2) + " " + txtKLPNum.Text + " от " + KLPDate.DateTime.ToShortDateString();

                System.String strKLPId = "3000000";
                oSheet.Cells[iRowKLPId, iColumnPartsId] = "№" + strKLPId.Substring(0, (strKLPId.Length - m_objSelectedKLP.Ib_ID.ToString().Length) ) + m_objSelectedKLP.Ib_ID.ToString(); // m_objSelectedKLP.Ib_ID.ToString();

                System.Int32 iRecordNum = 0;
                System.Int32 iPartsId = 0;
                System.Guid uuidPartsID = System.Guid.Empty;
                System.String strPartsArticle = "";
                System.String strPartsName = "";
                System.Double dclQuantityInDoc = 0;
                System.String strBarCode = "";
                System.String strCountryProduction = "";
                System.Decimal dclAlcoholicContentPercent = 0;

                ERP_Mercury.Common.CProduct objProduct = null;
                System.String strErr = System.String.Empty;

                for (System.Int32 i = 0; i < gridView.RowCount; i++)
                {
                    iRecordNum++;
                    uuidPartsID = (System.Guid)(gridView.GetRowCellValue(i, colProductID ));
                    objProduct = null;

                    strPartsArticle = "";
                    strPartsName = "";
                    dclQuantityInDoc = 0;
                    strBarCode = "";
                    strCountryProduction = "";
                   
                    objProduct =  m_objSrcForKlp.Where<CLotOrderItems>(x => x.Product.ID == uuidPartsID).ToList<CLotOrderItems>().First<CLotOrderItems>().Product;

                    if( objProduct != null )
                    {
                        iPartsId = objProduct.ID_Ib;
                        strPartsArticle = objProduct.Article;
                        strPartsName = objProduct.Name;
                        strBarCode = ((objProduct.BarcodeFirst == "") ? "" : ("\"" + objProduct.BarcodeFirst + "\""));

                        if (objProduct.LoadBarCodeList(m_objProfile, null, ref strErr) == true)
                        {
                            strBarCode = objProduct.BarcodeListString2;
                        }

                        dclAlcoholicContentPercent = objProduct.AlcoholicContentPercent;

                        strCountryProduction = System.Convert.ToString(gridView.GetRowCellValue(i, colKLPItems_CountryProductionName));
                        //strCountryProduction = objProduct.CountryImportName;
                    }

                    try
                    {
                        dclQuantityInDoc = System.Convert.ToDouble(gridView.GetRowCellValue(i, colQuantity));
                    }
                    catch
                    {
                        dclQuantityInDoc = 0;
                    }

                    oSheet.Cells[iCurrentRow, iColumnPartsId] = iPartsId;
                    oSheet.Cells[iCurrentRow, iColumnPartsArticle] = strPartsArticle;
                    oSheet.Cells[iCurrentRow, iColumnPartsName] = strPartsName;

                    oSheet.Cells[iCurrentRow, iColumnQuantityInDoc] = dclQuantityInDoc;
                    oSheet.Cells[iCurrentRow, iColumnBarCode] = strBarCode;
                    oSheet.Cells[iCurrentRow, iColumnCountry] = strCountryProduction;
                    oSheet.Cells[iCurrentRow, iColumnAlcoholicContentPercent] = dclAlcoholicContentPercent;

                    if (i < (gridView.RowCount - 1))
                    {
                        oSheet.get_Range(oSheet.Cells[iCurrentRow, 1], oSheet.Cells[iCurrentRow, 100]).Copy(Missing.Value);
                        oSheet.get_Range(oSheet.Cells[iCurrentRow, 1], oSheet.Cells[iCurrentRow, 1]).Insert(Excel.XlInsertShiftDirection.xlShiftDown, Missing.Value);
                        iCurrentRow++;
                    }

                }
                iCurrentRow++;
                oSheet.Cells[iCurrentRow, 1] = "Итого:";
                oSheet.get_Range(oSheet.Cells[iCurrentRow, iColumnQuantityInDoc], oSheet.Cells[iCurrentRow, iColumnQuantityInDoc]).Formula = "=СУММ(R[-" + iRecordNum.ToString() + "]C:R[-1]C)";
                oSheet.get_Range(oSheet.Cells[iCurrentRow, 1], oSheet.Cells[iCurrentRow, 11]).Font.Bold = true;
                oSheet.get_Range("C1", "C1").EntireColumn.AutoFit();

                iCurrentRow++;
                oSheet.Cells[iCurrentRow, iColumnPartsName] = strStockMan;
                iCurrentRow++;
                oSheet.Cells[iCurrentRow, iColumnPartsName] = strStockManager;


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
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ExportPSCToExcel();
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

        #region Журнал приходов
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                menuLotList.Enabled = ((gridView.RowCount == 0) || (gridView.FocusedRowHandle < 0));
            }
            catch (System.Exception f)
            {
                SendMessageToLog("contextMenuStrip_Opening. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return;
        }

        private void LoadLotList(CKLP objKLP)
        {
            try
            {
                if (m_frmLotList == null)
                {
                    m_frmLotList = new ctrlLotList(m_objMenuItem);
                    tableLayoutPanelLotList.Controls.Add(m_frmLotList, 0, 0);

                    this.m_frmLotList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));

                    //m_frmLotList.Dock = DockStyle.Fill;
                    m_frmLotList.CloseLotList += OnCloseLotList;
                    m_frmLotList.CloseLotEditor += OnCloseLotEditor;

                    // при создании объекта класса ctrlLotList загружаются выпадающие списки для панели поиска в журнале приходов
                    // и в редакторе прихода
                    m_frmLotList.LoadDataInComboBox(true, true);
                    this.Refresh();
                }

                if (m_frmLotList != null)
                {
                    tabControl.SelectedTabPage = tabPageLotList;
                    tabControl.SelectedTabPage.Refresh();

                    m_frmLotList.LoadLotListFromKLP(objKLP);
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("LoadLotList. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Refresh();
                this.Cursor = Cursors.Default;
            }
            return;
        }

        private void menuLotList_Click(object sender, EventArgs e)
        {
            LoadLotList(GetSelectedKLP());
        }
        private void barBtnToLotList_Click(object sender, EventArgs e)
        {
            LoadLotList(GetSelectedKLP());
        }
        #endregion

        #region Новый приход на склад
        private void contextMenuStripEditor_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                menuItemNewLotFromKLP.Enabled = (( m_bNewObject == false ) || (m_bIsChanged == true));
            }
            catch (System.Exception f)
            {
                SendMessageToLog("contextMenuStripEditor_Opening. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return;
        }

        private void NewLotFromKLPEditor()
        {
            try
            {
                List<CKLPItems> objKLPItemList = new List<CKLPItems>();
                int[] arr = gridView.GetSelectedRows();
                if (arr.Length > 0)
                {
                    for (System.Int32 i = 0; i < arr.Length; i++)
                    {
                        objKLPItemList.Add( m_objSelectedKLP.KLPItemsList[gridView.GetDataSourceRowIndex(arr[i])] );
                    }
                }
                else
                {
                    objKLPItemList = m_objSelectedKLP.KLPItemsList;
                }

                if ((objKLPItemList != null) && (objKLPItemList.Count > 0))
                {
                    if (m_frmLotList == null)
                    {
                        m_frmLotList = new ctrlLotList(m_objMenuItem);
                        tableLayoutPanelLotList.Controls.Add(m_frmLotList, 0, 0);
                        m_frmLotList.Dock = DockStyle.Fill;
                        m_frmLotList.CloseLotList += OnCloseLotList;
                        m_frmLotList.CloseLotEditor += OnCloseLotEditor;
                        // при создании объекта класса ctrlLotList загружаются выпадающие списки для панели поиска в журнале приходов
                        // и в редакторе прихода
                        m_frmLotList.LoadDataInComboBox(true, true);

                    }

                    if (m_frmLotList != null)
                    {
                        m_frmLotList.NewLotFromKLPEditor(m_objSelectedKLP, objKLPItemList);
                        tabControl.SelectedTabPage = tabPageLotList;
                    }

                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("NewLotFromKLPEditor. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        private void menuItemNewLotFromKLP_Click(object sender, EventArgs e)
        {
            try
            {
                NewLotFromKLPEditor();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("menuItemNewLotFromKLP_Click. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }
        #endregion

        private void ctrlKLP_Resize(object sender, EventArgs e)
        {
            tableLayoutPanelLotList.Size = new System.Drawing.Size(tableLayoutPanelLotList.Size.Width + 1, tableLayoutPanelLotList.Size.Height);
        }

    }

    /// <summary>
    /// Тип, хранящий информацию, которая передается получателям уведомления о событии
    /// </summary>
    public class CloseKLPListEventArgs : EventArgs
    {
        private readonly CLotOrder m_objOrder;
        public CLotOrder Order
        { get { return m_objOrder; } }

        public CloseKLPListEventArgs(CLotOrder objOrder)
        {
            m_objOrder = objOrder;
        }
    }


}
