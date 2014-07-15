using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraExport;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraEditors;


namespace ERPMercuryLotOrder
{

    public partial class frmCharges : DevExpress.XtraEditors.XtraForm
    {
        #region Свойства
        private UniXP.Common.CProfile m_objProfile;
        private UniXP.Common.MENUITEM m_objMenuItem;
        private List<CCharges> m_objTMCList;
        private CCharges m_objSelectedTMC;
        private DevExpress.XtraGrid.Views.Base.ColumnView ColumnView
        {
            get { return gridControlTMGList.MainView as DevExpress.XtraGrid.Views.Base.ColumnView; }
        }
        private System.Boolean m_bDisableEvents;
        private System.Boolean m_bIsChanged;
        public System.Boolean IsChanged
        {
            get { return m_bIsChanged; }
        }
        private System.Boolean m_bIsNew;
        private const System.String m_strEditMode = "Запись редактируется...";
        #endregion

        #region Конструктор
        public frmCharges(UniXP.Common.CProfile objProfile, UniXP.Common.MENUITEM objMenuItem)
        {
            InitializeComponent();

            m_objProfile = objProfile;
            m_objMenuItem = objMenuItem;
            m_objSelectedTMC = null;
            m_bDisableEvents = false;
            m_bIsChanged = false;
            m_bIsNew = false;

            AddGridColumns();
            LoadComboBoxItems();

            lblInfo.Text = "";
            dtBeginDate.DateTime = new DateTime(System.DateTime.Today.Year, System.DateTime.Today.Month, 1);
            dtEndDate.DateTime = System.DateTime.Today;
            
            LoadTradeMarkChargesList();

        }
        #endregion

        #region Настройки грида
        private void AddGridColumns()
        {
            ColumnView.Columns.Clear();
            AddGridColumn(ColumnView, "ID", "УИ записи");
            AddGridColumn(ColumnView, "ChargesDate", "Дата");
            AddGridColumn(ColumnView, "ChargesTypeName", "Тип расхода");
            AddGridColumn(ColumnView, "CurrencyCode", "Валюта");
            AddGridColumn(ColumnView, "ChargesCurrencyRate", "Курс к валюте учёта");
            AddGridColumn(ColumnView, "ChargesValue", "Сумма");
            AddGridColumn(ColumnView, "ChargesExpense", "Расход");
            AddGridColumn(ColumnView, "ChargesRest", "Остаток");

            foreach (DevExpress.XtraGrid.Columns.GridColumn objColumn in ColumnView.Columns)
            {
                objColumn.OptionsColumn.AllowEdit = false;
                objColumn.OptionsColumn.AllowFocus = false;
                objColumn.OptionsColumn.ReadOnly = true;
                objColumn.Visible = (objColumn.FieldName != "ID");
                objColumn.Width = objColumn.GetBestWidth();

                if ((objColumn.FieldName == "ChargesValue") || (objColumn.FieldName == "ChargesExpense") || (objColumn.FieldName == "ChargesRest"))
                {
                    objColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    objColumn.DisplayFormat.FormatString = "### ### ##0.00";
                }
                if( objColumn.FieldName == "ChargesCurrencyRate" )
                {
                    objColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    objColumn.DisplayFormat.FormatString = "### ### ##0.00000";
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
        #endregion

        #region Выпадающие списки
        /// <summary>
        /// загружает информацию в выпадающие списки
        /// </summary>
        private void LoadComboBoxItems()
        {
            m_bDisableEvents = true;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.tableLayoutPanel1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.cboxCurrency.Properties)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.cboxChargesType.Properties)).BeginInit();

                cboxCurrency.Properties.Items.Clear();
                cboxChargesType.Properties.Items.Clear();

                cboxCurrency.Properties.Items.AddRange( ERP_Mercury.Common.CCurrency.GetCurrencyList( m_objProfile, null ) );
                cboxChargesType.Properties.Items.AddRange(ERP_Mercury.Common.CSurcharges.GetSurchargesList(m_objProfile, null));

                this.tableLayoutPanel1.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.cboxCurrency.Properties)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.cboxChargesType.Properties)).EndInit();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка обновления выпадающих списков. Текст ошибки: " + f.Message);
            }
            finally
            {
                m_bDisableEvents = false;
                this.Cursor = Cursors.Default;
            }

            return;
        }
        #endregion
        
        #region Список записей
        public System.Boolean LoadTradeMarkChargesList()
        {
            System.Boolean bRet = false;
            m_bDisableEvents = true;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.tableLayoutPanel1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.gridControlTMGList)).BeginInit();

                gridControlTMGList.DataSource = null;

                m_objTMCList = CChargesRepository.GetChargesList(m_objProfile, null, dtBeginDate.DateTime, dtEndDate.DateTime);

                if (m_objTMCList != null)
                {
                    gridControlTMGList.DataSource = m_objTMCList;
                    if (m_objTMCList.Count > 0)
                    {
                        gridViewTMGList.FocusedRowHandle = 0;
                    }
                    else
                    {
                        SetReadOnlyPropertiesControls(true);
                    }

                }

                btnSave.Enabled = false;
                btnCancel.Enabled = false;

                this.tableLayoutPanel1.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.gridControlTMGList)).EndInit();
                bRet = true;
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка обновления списка. Текст ошибки: " + f.Message);
            }
            finally
            {
                m_bDisableEvents = false;


                this.Cursor = Cursors.Default;
            }

            return bRet;
        }
        private void gridViewTMGList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                LoadTradeMarkChargesPropertiesInEditor( GetSelectedCharges());
            }
            catch (System.Exception f)
            {
                SendMessageToLog("FocusedRowChanged. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }
        private void gridViewTMGList_RowCountChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTradeMarkChargesPropertiesInEditor(GetSelectedCharges());
            }
            catch (System.Exception f)
            {
                SendMessageToLog("RowCountChanged. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadTradeMarkChargesList();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("btnRefresh_Click. Текст ошибки: " + f.Message);
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
                    "SendMessageToLog. Текст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        #endregion

        #region Индикация изменений
        private void SetPropertiesModified(System.Boolean bModified)
        {
            ValidateProperties();
            m_bIsChanged = bModified;
            if (m_bIsChanged == true)
            {
                btnSave.Enabled = IsAllParamFill();
                btnCancel.Enabled = true;
            }
            else
            {
                btnSave.Enabled = m_bIsChanged;
                btnCancel.Enabled = bModified;
            }

            btnRefresh.Enabled = !(m_bIsChanged);
            btnAddCertificate.Enabled = !(m_bIsChanged);
            btnDeleteCertificate.Enabled = !(m_bIsChanged);
            btnPrint.Enabled = !(m_bIsChanged);
            
            gridControlTMGList.Enabled = !(m_bIsChanged);
            gridViewTMGList.Appearance.Row.BackColor = (m_bIsChanged == true ? SystemColors.ButtonFace : SystemColors.Window);
            lblInfo.Text = ((m_bIsChanged == true) ? m_strEditMode : "");
            
        }
        /// <summary>
        /// Включает/отключает элементы управления для отображения свойств адреса
        /// </summary>
        /// <param name="bEnable">признак "включить/выключить"</param>
        private void SetReadOnlyPropertiesControls(System.Boolean bEnable)
        {
            try
            {
                cboxCurrency.Properties.ReadOnly = bEnable;
                cboxChargesType.Properties.ReadOnly = bEnable;
                calcCharges_Value.Properties.ReadOnly = bEnable;
                calcCharges_CurrencyRate.Properties.ReadOnly = bEnable;
                dtChargesDate.Properties.ReadOnly = bEnable;

                calcCharges_Expense.Properties.ReadOnly = true;
                calcCharges_Rest.Properties.ReadOnly = true;

                if (bEnable == true)
                {
                    // включен режим "только просмотр"
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                }
                else
                {
                    // включен режим "редактирование"
                    btnSave.Enabled = m_bIsChanged;
                    btnCancel.Enabled = true;
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("SetReadOnlyPropertiesControls. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        private void TradeMarkChargesProperties_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (m_bDisableEvents == true) { return; }
            try
            {
                if (e.NewValue != null)
                {
                    if ((sender == calcCharges_Value) || (sender == calcCharges_CurrencyRate))
                    {
                        e.Cancel = (System.Convert.ToDecimal(e.NewValue) < 0);
                    }

                    SetPropertiesModified(true);
                }
            }//try
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка изменения свойств записи.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return;
        }

        private void TradeMarkChargesProperties_SelectedValueChanged(object sender, EventArgs e)
        {
            if (m_bDisableEvents == true) { return; }
            try
            {
                SetPropertiesModified(true);
            }//try
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка изменения свойств записи.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return;
        }

        #endregion

        #region Редактирование свойств записи
        /// <summary>
        /// Возвращает ссылку на выбранный в списке элемент
        /// </summary>
        /// <returns>ссылка на объект</returns>
        private CCharges GetSelectedCharges()
        {
            CCharges objRet = null;
            try
            {
                if ((((DevExpress.XtraGrid.Views.Grid.GridView)gridControlTMGList.MainView).RowCount > 0) &&
                    (((DevExpress.XtraGrid.Views.Grid.GridView)gridControlTMGList.MainView).FocusedRowHandle >= 0))
                {
                    System.Int32 iDataSourceRowIndex = gridViewTMGList.GetDataSourceRowIndex(gridViewTMGList.FocusedRowHandle);
                    objRet = m_objTMCList[iDataSourceRowIndex];
                }
            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка поиска выбранного элемента. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return objRet;
        }

        private void LoadTradeMarkChargesPropertiesInEditor(CCharges objCharges)
        {
            try
            {
                m_bDisableEvents = true;

                SetReadOnlyPropertiesControls(false);

                ClearPropertiesEditors();

                if (objCharges == null) { return; }

                m_objSelectedTMC = objCharges;


                this.tableLayoutPanel1.SuspendLayout();

                dtChargesDate.DateTime = m_objSelectedTMC.ChargesDate;
                cboxChargesType.SelectedItem = (m_objSelectedTMC.ChargesType == null) ? null : cboxChargesType.Properties.Items.Cast<ERP_Mercury.Common.CSurcharges>().Single<ERP_Mercury.Common.CSurcharges>(x => x.ID.CompareTo(m_objSelectedTMC.ChargesType.ID) == 0);
                cboxCurrency.SelectedItem = (m_objSelectedTMC.Currency == null) ? null : cboxCurrency.Properties.Items.Cast<ERP_Mercury.Common.CCurrency>().Single<ERP_Mercury.Common.CCurrency>(x => x.ID.CompareTo(m_objSelectedTMC.Currency.ID) == 0);
                calcCharges_CurrencyRate.Value = System.Convert.ToDecimal( m_objSelectedTMC.ChargesCurrencyRate );
                calcCharges_Value.Value = System.Convert.ToDecimal(m_objSelectedTMC.ChargesValue);
                calcCharges_Expense.Value = System.Convert.ToDecimal(m_objSelectedTMC.ChargesExpense);
                calcCharges_Rest.Value = System.Convert.ToDecimal(m_objSelectedTMC.ChargesRest);
                
                this.tableLayoutPanel1.ResumeLayout(false);

                SetReadOnlyPropertiesControls(false);
                SetPropertiesModified(false);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка редактирования записи. Текст ошибки: " + f.Message);
            }
            finally
            {
                m_bDisableEvents = false;
            }
            return;
        }

        /// <summary>
        /// Проверяет все ли обязательные поля заполнены
        /// </summary>
        /// <returns>true - все обязательные поля заполнены; false - не все полязаполнены</returns>
        private System.Boolean IsAllParamFill()
        {
            System.Boolean bRet = false;
            try
            {
                bRet = ((cboxCurrency.SelectedItem != null) && (cboxChargesType.SelectedItem != null) &&
                    (calcCharges_Value.Value >= 0) && ( calcCharges_CurrencyRate.Value >= 0 ) );
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка проверки заполнения обязательных свойств записи. Текст ошибки: " + f.Message);
            }
            return bRet;
        }

        /// <summary>
        /// Проверяет содержимое элементов управления
        /// </summary>
        private void ValidateProperties()
        {
            try
            {
                cboxCurrency.Properties.Appearance.BackColor = ((cboxCurrency.SelectedItem == null) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                cboxChargesType.Properties.Appearance.BackColor = ((cboxChargesType.SelectedItem == null) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                calcCharges_Value.Properties.Appearance.BackColor = ((calcCharges_Value.Value <= 0) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                calcCharges_CurrencyRate.Properties.Appearance.BackColor = ((calcCharges_CurrencyRate.Value <= 0) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
            }
            catch
            {
            }
            return;
        }

        private void AddradeMarkCharges()
        {
            try
            {
                m_bIsNew = true;
                
                ClearPropertiesEditors();

                m_objSelectedTMC = new CCharges() { ID = System.Guid.NewGuid(), ChargesDate = System.DateTime.Today, ChargesCurrencyRate = 1 };


                SetReadOnlyPropertiesControls(false);
                SetPropertiesModified(true);

                dtChargesDate.DateTime = m_objSelectedTMC.ChargesDate;
                calcCharges_CurrencyRate.Value = System.Convert.ToDecimal(m_objSelectedTMC.ChargesCurrencyRate);

            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка добавления записи. Текст ошибки: " + f.Message);
            }
            return ;
        }

        private void btnAddCertificate_Click(object sender, EventArgs e)
        {
            try
            {
                AddradeMarkCharges();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка добавления записи. Текст ошибки: " + f.Message);
            }
            return;
        }

        private void DeleteMarkCharges()
        {
            try
            {
                if( (m_objSelectedTMC != null) && ( m_bIsNew == false ) )
                {
                    if ( CChargesRepository.Remove( m_objProfile,  m_objSelectedTMC.ID ) == true)
                    {
                        m_objTMCList.Remove(m_objSelectedTMC);
                        gridControlTMGList.RefreshDataSource();
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                       "Ошибка удаления записи.", "Внимание",
                       System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    }
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка удаления записи. Текст ошибки: " + f.Message);
            }
            return;
        }
        private void btnDeleteCertificate_Click(object sender, EventArgs e)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show( "Подтвердите, пожалуйста, удаление записи.", "Внимание",
                    System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DeleteMarkCharges();
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка удаления записи. Текст ошибки: " + f.Message);
            }
            return;
        }

        #endregion

        #region Сохранить изменения
        /// <summary>
        /// Сохранение изменений в базе данных
        /// </summary>
        private void SaveChanges()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (m_objSelectedTMC != null)
                {
                    if (IsAllParamFill() == true)
                    {
                        CCharges objTMCForSave = new CCharges();

                        objTMCForSave.ID = m_objSelectedTMC.ID;
                        objTMCForSave.ChargesDate = dtChargesDate.DateTime;
                        objTMCForSave.ChargesType = (ERP_Mercury.Common.CSurcharges)cboxChargesType.SelectedItem;
                        objTMCForSave.Currency = (ERP_Mercury.Common.CCurrency)cboxCurrency.SelectedItem;
                        objTMCForSave.ChargesCurrencyRate = System.Convert.ToDouble( calcCharges_CurrencyRate.Value );
                        objTMCForSave.ChargesValue = System.Convert.ToDouble( calcCharges_Value.Value);

                        List<CCharges> objChargesList = new List<CCharges>();
                        objChargesList.Add(objTMCForSave);

                        System.String strErr = "";

                        if (CChargesRepository.SaveChargesList(m_objProfile, null, objChargesList, ref strErr) == true)
                        {
                            m_objSelectedTMC.Currency = objTMCForSave.Currency;
                            m_objSelectedTMC.ChargesDate = objTMCForSave.ChargesDate;
                            m_objSelectedTMC.ChargesType = objTMCForSave.ChargesType;
                            m_objSelectedTMC.ChargesCurrencyRate = objTMCForSave.ChargesCurrencyRate;
                            m_objSelectedTMC.ChargesValue = objTMCForSave.ChargesValue;

                            if (m_bIsNew == true)
                            {
                                m_objTMCList.Add(m_objSelectedTMC);
                                m_bIsNew = false;
                            }

                            gridControlTMGList.RefreshDataSource();
                            SetPropertiesModified(false);
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(
                            ("Ошибка сохранения изменений.\n" + strErr ), "Внимание",
                            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                        }

                        objTMCForSave = null;
                    }

                }

            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка сохранения изменений в базе данных. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveChanges();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка сохранения изменений в базе данных. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return;
        }


        
        #endregion

        #region Отменить изменения
        private void ClearPropertiesEditors()
        {
            try
            {
                cboxCurrency.SelectedItem = null;
                cboxChargesType.SelectedItem = null;
                calcCharges_Value.Value = 0;
                calcCharges_CurrencyRate.Value = 0;
                calcCharges_Expense.Value = 0;
                calcCharges_Rest.Value = 0;
                dtChargesDate.DateTime = System.DateTime.Today;

            }
            catch (System.Exception f)
            {
                SendMessageToLog("ClearPropertiesEditors. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        private void CancelChanges()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (m_objSelectedTMC != null)
                {
                    if (m_bIsNew == true)
                    {
                        ClearPropertiesEditors();
                    }
                    else
                    {
                        LoadTradeMarkChargesPropertiesInEditor(GetSelectedCharges());
                    }

                    SetPropertiesModified(false);
                }

            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка отмены изменений. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                CancelChanges();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка отмены изменений. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return;
        }

        #endregion

        #region Настройки внешнего вида журналов
        /// <summary>
        /// Считывает настройки журналов из реестра
        /// </summary>
        public void RestoreLayoutFromRegistry()
        {
            System.String strReestrPath = this.m_objProfile.GetRegKeyBase();
            strReestrPath += ("\\Tools\\");
            try
            {
                gridViewTMGList.RestoreLayoutFromRegistry(strReestrPath + gridViewTMGList.Name);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка загрузки настроек списка записей.\n\nТекст ошибки : " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }
        /// <summary>
        /// Записывает настройки журналов в реестр
        /// </summary>
        public void SaveLayoutToRegistry()
        {
            System.String strReestrPath = this.m_objProfile.GetRegKeyBase();
            strReestrPath += ("\\Tools\\");
            try
            {
                gridViewTMGList.SaveLayoutToRegistry(strReestrPath + gridViewTMGList.Name);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка записи настроек списка записей.\n\nТекст ошибки : " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }
        #endregion

        #region Экспорт в MS Excel
        private string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            //string name = Application.ProductName;
            string name = "Журнал дополнительных расходов";
            int n = name.LastIndexOf(".") + 1;
            if (n > 0) name = name.Substring(n, name.Length - n);
            dlg.Title = "Экспорт списка записей " + title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }
        private void OpenFile(string fileName)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Вы хотите открыть этот файл?", "Экспорт в MS Excel...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка метода OpenFile.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        //<sbExportToHTML>
        private void ExportTo(DevExpress.XtraExport.IExportProvider provider,
            DevExpress.XtraGrid.Views.Grid.GridView objGridView)
        {
            try
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                this.FindForm().Refresh();

                BaseExportLink link = objGridView.CreateExportLink(provider);
                (link as GridViewExportLink).ExpandAll = false;
                //link.Progress += new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);
                link.ExportTo(true);
                provider.Dispose();
                //link.Progress -= new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);

                Cursor.Current = currentCursor;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка метода OpenFile.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        private void sbExportToXLS_Click(object sender, System.EventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView objGridView = gridViewTMGList;

                if ((objGridView == null) || (objGridView.RowCount == 0))
                {
                    return;
                }
                string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xls");
                if (fileName != "")
                {
                    ExportTo(new ExportXlsProvider(fileName), objGridView);
                    OpenFile(fileName);
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка метода sbExportToXLS_Click.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion


    }

    public class ChargeseEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmCharges obj = new frmCharges( objMenuItem.objProfile, objMenuItem );
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }

}
