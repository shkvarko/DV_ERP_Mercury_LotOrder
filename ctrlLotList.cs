using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DevExpress.XtraExport;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraEditors;
using System.Data.OleDb;
using System.Reflection;
using ERP_Mercury.Common;
using OfficeOpenXml;

namespace ERPMercuryLotOrder
{
    public partial class ctrlLotList : UserControl
    {
        #region Свойства
        private LotListMode m_enLotListMode;
        private UniXP.Common.CProfile m_objProfile;
        private UniXP.Common.MENUITEM m_objMenuItem;
        private System.Boolean m_bOnlyView;
        private List<CVendor> m_objVendorList;
        private List<CStock> m_objStockList;
        private List<CLot> m_objLotList;
        private CKLP m_objParentKLP;
        private CLot m_objCurrentLot;
        private OpenLotEditorMode m_enOpenLotEditorMode;
        public CLot SelectedLot
        {
            get { return GetSelectedLot(); }
        }
        
        private CLot GetSelectedLot()
        {
            CLot objRet = null;
            try
            {
                if ((((DevExpress.XtraGrid.Views.Grid.GridView)gridControlLotList.MainView).RowCount > 0) &&
                    (((DevExpress.XtraGrid.Views.Grid.GridView)gridControlLotList.MainView).FocusedRowHandle >= 0))
                {
                    System.Guid uuidID = (System.Guid)(((DevExpress.XtraGrid.Views.Grid.GridView)gridControlLotList.MainView)).GetFocusedRowCellValue("ID");

                    objRet = m_objLotList.SingleOrDefault<CLot>(x => x.ID.CompareTo(uuidID) == 0);
                }
            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка поиска выбранного прихода. Текст ошибки: " + f.Message);
            }
            return objRet;
        }


        private DevExpress.XtraGrid.Views.Base.ColumnView ColumnView
        {
            get { return gridControlLotList.MainView as DevExpress.XtraGrid.Views.Base.ColumnView; }
        }

        #region Потоки
        // потоки
        public System.Threading.Thread ThreadLoadVendorList { get; set; }
        public System.Threading.Thread ThreadLoadStockList { get; set; }
        public System.Threading.Thread ThreadLoadLotList { get; set; }

        public System.Threading.ManualResetEvent EventStopThread { get; set; }
        public System.Threading.ManualResetEvent EventThreadStopped { get; set; }
        private System.Boolean m_bThreadFinishJob;


        public delegate void LoadVendorListDelegate(List<CVendor> objVendorList, System.Int32 iRowCountInLis);
        public LoadVendorListDelegate m_LoadVendorListDelegate;

        public delegate void LoadStockListDelegate(List<CStock> objStockList, System.Int32 iRowCountInLis);
        public LoadStockListDelegate m_LoadStockListDelegate;

        public delegate void LoadLotListDelegate(List<CLot> objLotList, System.Int32 iRowCountInList);
        public LoadLotListDelegate m_LoadLotListDelegate;

        private const System.Int32 iThreadSleepTime = 1000;
        private const System.String strWaitLoadList = "ждите... идет заполнение списка";
        #endregion

        private const int iSearchPanelRowStyleIndx = 2;
        private const string strLblInfoForLotListCaption = "Журнал приходов на склад";
        private const string strWaitLoadLotList = "идёт загрузка спсика приходов на склад...";
        private System.Guid m_uuidCurrenyAccounting;
        private System.Boolean m_bComboBoxWithProductListIsFull;
        private System.String m_strXLSImportFilePath;
        private System.Int32 m_iXLSSheetImport;
        private List<System.String> m_SheetList;
        #endregion

        #region Конструктор
        public ctrlLotList(UniXP.Common.MENUITEM objMenuItem)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);

            InitializeComponent();

            m_objMenuItem = objMenuItem;
            m_objProfile = objMenuItem.objProfile;
            m_enLotListMode = LotListMode.Unkown;
            m_objParentKLP = null;
            m_objLotList = new List<CLot>();
            m_objCurrentLot = null;
            m_bThreadFinishJob = false;
            m_uuidCurrenyAccounting = System.Guid.Empty;
            m_objVendorList = new List<ERP_Mercury.Common.CVendor>();
            m_objStockList = new List<CStock>();
            dtBeginDate.DateTime = new DateTime(System.DateTime.Today.Year, System.DateTime.Today.Month, 1);
            dtEndDate.DateTime = System.DateTime.Today;

            m_bIsChanged = false;
            m_bDisableEvents = true;
            m_bNewObject = false;
            m_uuidSelectedStockID = System.Guid.Empty;
            m_enOpenLotEditorMode = OpenLotEditorMode.Unkown;

            m_objPartsList = null;
            lblEditMode.Text = "";
            m_strXLSImportFilePath = "";
            m_iXLSSheetImport = 0;
            m_SheetList = null;

            dtLotDocDate.DateTime = System.DateTime.Today;

            AddGridColumns();

            tabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            m_bOnlyView = false;
            m_bComboBoxWithProductListIsFull = false;
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

        #region Открытие формы
        /// <summary>
        /// Вызывает методы по загрузке данных в выпадающие списки
        /// </summary>
        /// <param name="bloadInSearchPanel">признак "обновить выпадающие списки на панели поиска"</param>
        /// <param name="bloadInEditor">признак "обновить выпадающие списки в редакторе"</param>
        public void LoadDataInComboBox(System.Boolean bloadInSearchPanel, System.Boolean bloadInEditor)
        {
            try
            {
                if (bloadInSearchPanel == true)
                {
                    // загрузка в потоках значения в выпадающие списки: "Поставщики", "Склады"
                    LoadComboBoxForSearchPanel();
                }
                if (bloadInEditor == true)
                {
                    // обновление выпадающих списков в редакторе прихода на склад
                    LoadComboBoxItems();
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("LoadDataInComboBox().\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }


        /// <summary>
        /// загрузка списка приходов из КЛП
        /// </summary>
        /// <param name="objKLP">объект "КЛП"</param>
        public void LoadLotListFromKLP(CKLP objKLP)
        {
            try
            {
                // ссылка на КЛП, из которого сформированы приходы на склад
                m_objParentKLP = objKLP;
                // вариант отображения журнала приходов
                m_enLotListMode = LotListMode.FromKLP;
                // сокрытие панели поиска
                tableLayoutPanelLotList.RowStyles[iSearchPanelRowStyleIndx].Height = 0;

                LoadctrlLotList();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("LoadLotListFromKLP().\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        /// <summary>
        /// загрузка списка приходов непосредственно из UniXP
        /// </summary>
        public void LoadLotListFromUniXP()
        {
            try
            {
                // обнуление ссылки на КЛП
                m_objParentKLP = null;
                // вариант отображения журнала приходов
                m_enLotListMode = LotListMode.FromUniXP;
                // сокрытие кнопки возврата в модуль КЛП
                barBtnreturnToKLP.Visible = false;

                LoadctrlLotList();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("LoadLotListFromKLP().\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        /// <summary>
        /// Загрузка содержимого выпадающих списков для поиска и редактирования прихода
        /// Настройка внешнего вида журнала приходов
        /// </summary>
        private void LoadctrlLotList()
        {
            try
            {
                // текущая закладка "Журнал приходов"
                tabControl.SelectedTabPage = tabPageViewer;
                tabControl.Refresh();
                // загрузка из реестра настроек отображения журнала
                RestoreLayoutFromRegistry();
                // загрузка журнала приходов
                StartThreadLoadLotList();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("frmLotList_Shown().\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        #endregion

        #region Загрузка выпадающих списков
        /// <summary>
        /// Загружает в потоках значения в выпадающие списки: "Поставщики", "Склады"
        /// </summary>
        public void LoadComboBoxForSearchPanel()
        {
            try
            {
                // выпадающий список "Поставщики"
                StartThreadLoadVendorList();
                // выпадающий список "Склады"
                StartThreadLoadStockList();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("LoadComboBox. Текст ошибки: " + f.Message);
            }
            return;
        }
        /// <summary>
        /// Стартует поток, в котором загружается список поставщиков
        /// </summary>
        public void StartThreadLoadVendorList()
        {
            try
            {
                // инициализируем делегаты
                m_LoadVendorListDelegate = new LoadVendorListDelegate(LoadVendorList);
                m_objVendorList.Clear();
                cboxVendorListForSearch.Properties.Items.Clear();
                cboxVendor.Properties.Items.Clear();

                // запуск потока
                this.ThreadLoadVendorList = new System.Threading.Thread(LoadVendorListInThread);
                this.ThreadLoadVendorList.Start();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("StartThreadLoadVendorList().\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// Загружает список поставщиков (метод, выполняемый в потоке)
        /// </summary>
        public void LoadVendorListInThread()
        {
            try
            {
                List<CVendor> objVendorList = CVendor.GetVendorList(m_objProfile, null);

                List<CVendor> objAddVendorList = new List<CVendor>();
                if ((objVendorList != null) && (objVendorList.Count > 0))
                {
                    System.Int32 iRecCount = 0;
                    System.Int32 iRecAllCount = 0;
                    foreach (CVendor objVendor in objVendorList)
                    {
                        objAddVendorList.Add(objVendor);
                        iRecCount++;
                        iRecAllCount++;

                        if (iRecCount == 1000)
                        {
                            iRecCount = 0;
                            Thread.Sleep(1000);
                            this.Invoke(m_LoadVendorListDelegate, new Object[] { objAddVendorList, iRecAllCount });
                            objAddVendorList.Clear();
                        }

                    }
                    if (iRecCount != 1000)
                    {
                        iRecCount = 0;
                        this.Invoke(m_LoadVendorListDelegate, new Object[] { objAddVendorList, iRecAllCount });
                        objAddVendorList.Clear();
                    }

                }

                objVendorList = null;
                objAddVendorList = null;
                this.Invoke(m_LoadVendorListDelegate, new Object[] { null, 0 });
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("LoadVendorListInThread.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        /// <summary>
        /// загружает в combobox список поставщиков
        /// </summary>
        /// <param name="objVendorList">список поставщиков</param>
        /// <param name="iRowCountInList">количество строк, которые требуется загрузить в combobox</param>
        private void LoadVendorList(List<CVendor> objVendorList, System.Int32 iRowCountInList)
        {
            try
            {
                cboxVendorListForSearch.Text = strWaitLoadList;
                cboxVendor.Text = strWaitLoadList;
                if ((objVendorList != null) && (objVendorList.Count > 0) && (cboxVendorListForSearch.Properties.Items.Count < iRowCountInList))
                {
                    cboxVendorListForSearch.Properties.Items.AddRange(objVendorList);
                    cboxVendor.Properties.Items.AddRange(objVendorList);
                    m_objVendorList.AddRange(objVendorList);
                }
                else
                {
                    cboxVendorListForSearch.Text = "";
                    cboxVendor.Text = "";
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("LoadVendorList.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }

        /// <summary>
        /// Стартует поток, в котором загружается список складов
        /// </summary>
        public void StartThreadLoadStockList()
        {
            try
            {
                // инициализируем делегаты
                m_LoadStockListDelegate = new LoadStockListDelegate(LoadStockList);
                m_objStockList.Clear();
                cboxStock.Properties.Items.Clear();
                cboxStockLot.Properties.Items.Clear();

                // запуск потока
                this.ThreadLoadStockList = new System.Threading.Thread(LoadStockListInThread);
                this.ThreadLoadStockList.Start();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("StartThreadLoadStockList().\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// Загружает список складов (метод, выполняемый в потоке)
        /// </summary>
        public void LoadStockListInThread()
        {
            try
            {
                List<CStock> objStockList = CStock.GetStockList(m_objProfile, null);
                List<CStock> objAddStockList = new List<CStock>();

                if ((objStockList != null) && (objStockList.Count > 0))
                {
                    System.Int32 iRecCount = 0;
                    System.Int32 iRecAllCount = 0;
                    foreach (CStock objStock in objStockList)
                    {
                        objAddStockList.Add(objStock);
                        iRecCount++;
                        iRecAllCount++;

                        if (iRecCount == 1000)
                        {
                            iRecCount = 0;
                            Thread.Sleep(1000);
                            this.Invoke(m_LoadStockListDelegate, new Object[] { objAddStockList, iRecAllCount });
                            objAddStockList.Clear();
                        }

                    }
                    if (iRecCount != 1000)
                    {
                        iRecCount = 0;
                        this.Invoke(m_LoadStockListDelegate, new Object[] { objAddStockList, iRecAllCount });
                        objAddStockList.Clear();
                    }

                }

                objStockList = null;
                objAddStockList = null;
                this.Invoke(m_LoadStockListDelegate, new Object[] { null, 0 });
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("LoadStockListInThread.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        /// <summary>
        /// загружает в combobox список складов
        /// </summary>
        /// <param name="objVendorList">список складов</param>
        /// <param name="iRowCountInList">количество строк, которые требуется загрузить в combobox</param>
        private void LoadStockList(List<CStock> objStockList, System.Int32 iRowCountInList)
        {
            try
            {
                cboxStock.Text = strWaitLoadList;
                cboxStockLot.Text = strWaitLoadList;

                if ((objStockList != null) && (objStockList.Count > 0) && (cboxStock.Properties.Items.Count < iRowCountInList))
                {
                    cboxStock.Properties.Items.AddRange(objStockList);
                    cboxStockLot.Properties.Items.AddRange(objStockList);
                    m_objStockList.AddRange(objStockList);
                }
                else
                {
                    cboxStock.Text = "";
                    cboxStockLot.Text = "";
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("LoadStockList.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        /// <summary>
        /// Обновление выпадающих списков в редакторе прихода на склад
        /// </summary>
        /// <returns>true - все списки успешно обновлены; false - ошибка</returns>
        private System.Boolean LoadComboBoxItems()
        {
            System.Boolean bRet = false;
            try
            {
                cboxProductTradeMark.Properties.Items.Clear();
                cboxProductType.Properties.Items.Clear();

                // Валюты
                cboxCurrency.Properties.Items.Clear();
                List<CCurrency> objCurrencylist = CCurrency.GetCurrencyList(m_objProfile, null);
                if ((objCurrencylist != null) && (objCurrencylist.Count > 0))
                {
                    CCurrency objCurrenyAccounting = objCurrencylist.SingleOrDefault<CCurrency>(x => x.IsMain);
                    m_uuidCurrenyAccounting = ((objCurrenyAccounting != null) ? objCurrenyAccounting.ID : System.Guid.Empty);

                    if ((m_objParentKLP != null) && (m_enLotListMode == LotListMode.FromKLP) && (m_objParentKLP.Currency != null))
                    {
                        cboxCurrency.Properties.Items.Add(m_objParentKLP.Currency);
                    }
                    else
                    {
                        cboxCurrency.Properties.Items.AddRange(objCurrencylist);
                    }
                }

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

                // в том случае, если приход формируется из КЛП, в выпадающем списке поставщиков и валют должно быть только одно значение
                // если привязка к КЛП отсутствует, то отображается весь список значений
                if ((m_objParentKLP != null) && (m_objCurrentLot != null) && (m_objCurrentLot.Vendor != null))
                {
                    cboxVendor.Properties.Items.Clear();
                    cboxVendor.Properties.Items.Add(m_objCurrentLot.Vendor);
                }

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
                                bOk = (objProduct.ProductType.ID == PartTypeId);
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

        #region Журнал приходов
        private void dtBeginDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // при нажатии "Enter" стартует поток, в котором загружается журнал приходов на склад
                if ((e.KeyCode == Keys.Enter) && (barBtnRefresh.Visible == true))
                {
                    StartThreadLoadLotList();
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка обновления списка. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }
        private void dtBeginDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // при нажатии "Enter" стартует поток, в котором загружается журнал приходов на склад
                if ((e.KeyChar == (char)Keys.Enter) && (barBtnRefresh.Visible == true))
                {
                    StartThreadLoadLotList();
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("dtBeginDate_KeyPress.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;

        }
        /// <summary>
        /// Обработчик нажатия клавиши "barBtnRefresh"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // старт потока на обновления журнала приходов
                StartThreadLoadLotList();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("barBtnRefresh_Click.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;

        }

        /// <summary>
        /// Настройка элементов управления перед запускам потока на обновление журнала приходов
        /// </summary>
        private void SetPropertieEnabledForBarBtnsBeforeStartThread()
        {
            try
            {
                barBtnAdd.Enabled = false;
                barBtnEdit.Enabled = false;
                barBtnDelete.Enabled = false;
                barBtnRefresh.Enabled = false;

                dtBeginDate.Enabled = false;
                dtEndDate.Enabled = false;
                txtDocNum.Enabled = false;

                cboxVendorListForSearch.Properties.ReadOnly = true;
                cboxStock.Properties.ReadOnly = true;

                gridControlLotList.MouseDoubleClick -= new MouseEventHandler(gridControlLotList_MouseDoubleClick);
            }
            catch (System.Exception f)
            {
                SendMessageToLog((String.Format("SetPropertieEnabledForBarBtnsBeforeStartThread.  Ошибка: {0}", f.Message)));
            }
            finally
            {
            }
            return;
        }
        /// <summary>
        /// Настройка элементов управления после того, как поток на обновление журнала приходов закончил свою работу
        /// </summary>
        private void SetPropertieEnabledForBarBtnsAfterFinishThread()
        {
            try
            {
                barBtnAdd.Enabled = !m_bOnlyView;
                barBtnEdit.Enabled = (gridViewLotList.FocusedRowHandle >= 0);
                barBtnDelete.Enabled = ((!m_bOnlyView) && (gridViewLotList.FocusedRowHandle >= 0));
                barBtnRefresh.Enabled = true;

                dtBeginDate.Enabled = true;
                dtEndDate.Enabled = true;
                txtDocNum.Enabled = true;

                cboxVendorListForSearch.Properties.ReadOnly = false;
                cboxStock.Properties.ReadOnly = false;

                gridControlLotList.MouseDoubleClick += new MouseEventHandler(gridControlLotList_MouseDoubleClick);
            }
            catch (System.Exception f)
            {
                SendMessageToLog((String.Format("SetPropertieEnabledForBarBtnsAfterFinishThread.  Ошибка: {0}", f.Message)));
            }
            finally
            {
            }
            return;
        }

        /// <summary>
        /// Стартует поток, в котором загружается список приходов
        /// </summary>
        public void StartThreadLoadLotList()
        {
            try
            {
                // пометка о том, что выполняется запрос списка приходов
                lblOrderInfo.Text = strWaitLoadLotList;
                lblOrderInfo.ForeColor = Color.Red;
                lblOrderInfo.Refresh();

                // инициализируем делегаты
                m_LoadLotListDelegate = new LoadLotListDelegate(LoadLotList);
                m_objLotList.Clear();

                // блокировка кнопок на панели управления
                SetPropertieEnabledForBarBtnsBeforeStartThread();

                // запуск потока
                Cursor = Cursors.WaitCursor;
                this.ThreadLoadLotList = new System.Threading.Thread(LoadLotListInThread);
                this.ThreadLoadLotList.Start();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("StartThreadLoadLotList().\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// Запрашивает список приходов из БД и порционно передаёт в журнал приходов (выполняется в потоке)
        /// </summary>
        public void LoadLotListInThread()
        {
            try
            {
                List<CLot> objLotList = null;
                System.String strErr = System.String.Empty;

                if( (m_enLotListMode == LotListMode.FromKLP) && (m_objParentKLP != null) )
                {
                    // запрос только тех приходов, которые сформированы для m_objParentKLP
                    objLotList = CLotRepository.GetLotList(m_objProfile, null, m_objParentKLP.ID, ref strErr);
                }
                else if (m_enLotListMode == LotListMode.FromUniXP)
                {
                    System.DateTime dtBegin = dtBeginDate.DateTime;
                    System.DateTime dtEnd = dtEndDate.DateTime;
                    System.String strDocNum = txtDocNum.Text;
                    CVendor objVendor = ( ((cboxVendorListForSearch.SelectedItem != null) && (cboxVendorListForSearch.SelectedItem != "") ) ? (CVendor)cboxVendorListForSearch.SelectedItem : null);
                    CStock objStock = (((cboxStock.SelectedItem != null) && (cboxStock.SelectedItem != "")) ? (CStock)cboxStock.SelectedItem : null);

                    // запрос приходов за указанный период дат
                    objLotList = CLotRepository.GetLotList(m_objProfile, null, dtBegin, dtEnd, ref strErr);

                    // фильтрация по дополнительным параметрам
                    if( (objLotList != null ) && ( objLotList.Count > 0 ) && (strDocNum != "") )
                    {
                        // номер прихода
                        objLotList = objLotList.Where<CLot>(x => x.DocNumber == strDocNum).ToList<CLot>();
                    }
                    if ((objLotList != null) && (objLotList.Count > 0) && (objVendor != null))
                    {
                        // поставщик
                        objLotList = objLotList.Where<CLot>(x => x.Vendor.ID.CompareTo(objVendor.ID) == 0).ToList<CLot>();
                    }
                    if ((objLotList != null) && (objLotList.Count > 0) && (objStock != null))
                    {
                        // склад прихода
                        objLotList = objLotList.Where<CLot>(x => x.Stock.ID.CompareTo(objStock.ID) == 0).ToList<CLot>();
                    }
                }

                // список, в который будут порциями загружаться объекты "Приход", а затем передаваться в грид
                List<CLot> objAddLotList = new List<CLot>();

                if ((objLotList != null) && (objLotList.Count > 0))
                {
                    System.Int32 iRecCount = 0;
                    System.Int32 iRecAllCount = 0;
                    foreach (CLot objLot in objLotList)
                    {
                        objAddLotList.Add(objLot);
                        iRecCount++;
                        iRecAllCount++;

                        if (iRecCount == 1000)
                        {
                            iRecCount = 0;
                            Thread.Sleep(1000);
                            // передача пакета данных в грид
                            this.Invoke(m_LoadLotListDelegate, new Object[] { objAddLotList, iRecAllCount });
                            objAddLotList.Clear();
                        }

                    }
                    if (iRecCount != 1000)
                    {
                        // передача пакета данных в грид
                        iRecCount = 0;
                        this.Invoke(m_LoadLotListDelegate, new Object[] { objAddLotList, iRecAllCount });
                        objAddLotList.Clear();
                    }

                }

                // все данные переданы в грид
                // уведомление о том, что процесс закончен
                objLotList = null;
                objAddLotList = null;
                this.Invoke(m_LoadLotListDelegate, new Object[] { null, 0 });
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("LoadLotListInThread.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        /// <summary>
        /// загружает в журнал список складов
        /// </summary>
        /// <param name="objVendorList">список складов</param>
        /// <param name="iRowCountInList">количество строк, которые требуется загрузить в combobox</param>
        private void LoadLotList(List<CLot> objLotList, System.Int32 iRowCountInList)
        {
            try
            {
                if ((objLotList != null) && (objLotList.Count > 0) && (gridViewLotList.RowCount < iRowCountInList))
                {
                    m_objLotList.AddRange(objLotList);
                    if (gridControlLotList.DataSource == null)
                    {
                        gridControlLotList.DataSource = m_objLotList;
                    }
                    gridControlLotList.RefreshDataSource();
                }
                else
                {
                    // процесс загрузки данных завершён
                    Thread.Sleep(1000);

                    gridControlLotList.RefreshDataSource();
                    // активация кнопок на ToolBar
                    SetPropertieEnabledForBarBtnsAfterFinishThread();
                    // информация о КЛП (если запуск из журнала КЛП)
                    lblOrderInfo.Text = (((m_enLotListMode == LotListMode.FromKLP) && (m_objParentKLP != null)) ? (String.Format("{0} для КЛП №{1} от {2}", strLblInfoForLotListCaption, m_objParentKLP.Number, m_objParentKLP.Date.ToShortDateString())) : (strLblInfoForLotListCaption));
                    lblOrderInfo.ForeColor = Color.Black;
                    lblOrderInfo.Refresh();

                    if (gridViewLotList.RowCount > 0)
                    {
                        gridViewLotList.FocusedRowHandle = 0;
                        ShowLotProperties(SelectedLot);
                        tableLayoutPanelViewLotProperties.Refresh();
                    }
                     
                    Cursor = Cursors.Default;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("LoadStockList.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                    String.Format("SendMessageToLog.\n\nТекст ошибки: {0}", f.Message), "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region Настройки внешнего вида журналов
        /// <summary>
        /// Формирует коллекцию столбцов для грида с журналом приходов на склад
        /// </summary>
        private void AddGridColumns()
        {
            ColumnView.Columns.Clear();
            AddGridColumn(ColumnView, "ID", "Идентификатор");
            AddGridColumn(ColumnView, "CurrentLotStateName", "Состояние");
            AddGridColumn(ColumnView, "Number", "Номер партии");
            AddGridColumn(ColumnView, "DocNumber", "Номер док-та");
            AddGridColumn(ColumnView, "DocDate", "Дата док-та");
            AddGridColumn(ColumnView, "VendorName", "Поставщик");
            AddGridColumn(ColumnView, "Quantity", "Кол-во");
            AddGridColumn(ColumnView, "CurrencyCode", "Валюта");
            AddGridColumn(ColumnView, "AllPrice", "С/С в валюте прихода");
            AddGridColumn(ColumnView, "AllCostPrice", "С/С в ОВУ");
            AddGridColumn(ColumnView, "LotStateOrderNum", "№ состояния по порядку");
            AddGridColumn(ColumnView, "StockName", "Склад прихода");

            
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
                if ((objColumn.FieldName == "ID") || (objColumn.FieldName == "LotStateOrderNum"))
                {
                    objColumn.Visible = false;
                }
                if (objColumn.FieldName == "Quantity")
                {
                    objColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    objColumn.DisplayFormat.FormatString = "### ### ##0";
                    objColumn.SummaryItem.FieldName = objColumn.FieldName;
                    objColumn.SummaryItem.DisplayFormat = "Кол-во: {0:### ### ##0}";
                    objColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                }
                if ((objColumn.FieldName == "AllPrice") || (objColumn.FieldName == "AllCostPrice"))
                {
                    objColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    objColumn.DisplayFormat.FormatString = "### ### ##0.00";
                    objColumn.SummaryItem.FieldName = objColumn.FieldName;
                    objColumn.SummaryItem.DisplayFormat = "Итого: {0:### ### ##0.00}";
                    objColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
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
        /// Считывает настройки журналов из реестра
        /// </summary>
        public void RestoreLayoutFromRegistry()
        {
            try
            {
                gridViewLotList.RestoreLayoutFromRegistry(String.Format("{0}{1}", 
                    (this.m_objProfile.GetRegKeyBase() + ("\\Tools\\")), gridViewLotList.Name));
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка загрузки настроек списка приходов.\n\nТекст ошибки : " + f.Message, "Внимание",
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
            try
            {
                gridViewLotList.SaveLayoutToRegistry(String.Format("{0}{1}", 
                    (this.m_objProfile.GetRegKeyBase() + ("\\Tools\\")), gridViewLotList.Name));
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                String.Format("Ошибка записи настроек списка приходов.\n\nТекст ошибки : {0}", f.Message), "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }
        #endregion

        #region Свойства приходного документа
        /// <summary>
        /// Обработчик события "Изменение количества записей в гриде"
        /// </summary>
        private void gridViewLotListFocusedRowChanged()
        {
            try
            {
                // загрузка информации по выделенному в списке приходу на панель свойств
                ShowLotProperties(SelectedLot);
                // включение/выключение кнопок на ToolBar
                barBtnAdd.Enabled = !m_bOnlyView;
                barBtnEdit.Enabled = (gridViewLotList.FocusedRowHandle >= 0);
                barBtnDelete.Enabled = ((!m_bOnlyView) && (gridViewLotList.FocusedRowHandle >= 0));
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Отображение свойств прихода. Текст ошибки: " + f.Message);
            }
            return;
        }

        private void gridViewLotList_RowCountChanged(object sender, EventArgs e)
        {
            gridViewLotListFocusedRowChanged();
        }
        private void gridViewLotList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewLotListFocusedRowChanged();
        }

        /// <summary>
        /// Отображает свойства объекта "Приход"
        /// </summary>
        /// <param name="objLot">объект "Приход"</param>
        private void ShowLotProperties(CLot objLot)
        {
            try
            {
                // очистка элементов управление, в которых отображаются свойства прихода
                txtDocNum.Text = "";
                txtVendorName.Text = "";
                txtLotNumber.Text = "";
                txtLotDocNumber.Text = "";
                txtLotOrderDate.Text = "";
                txtStockLot.Text = "";
                txtLotOrderState.Text = "";
                txtLotCurrency.Text = "";
                calcLotAllPrice.Value = 0;
                calcLotCurrencyPrice.Value = 0;
                calcLotQuantity.Value = 0;

                if (objLot != null)
                {
                    // информация по приходу загружается в элементы управления
                    txtLotNumber.Text = objLot.Number;
                    txtVendorName.Text = objLot.VendorName;
                    txtLotDocNumber.Text = objLot.DocNumber;
                    txtLotOrderDate.Text = objLot.DocDate.ToShortDateString();
                    txtStockLot.Text = objLot.StockName;
                    txtLotOrderState.Text = objLot.CurrentLotStateName;
                    txtLotCurrency.Text = objLot.CurrencyCode;

                    calcLotAllPrice.Value = System.Convert.ToDecimal(objLot.AllPrice);
                    calcLotCurrencyPrice.Value = System.Convert.ToDecimal(objLot.AllCostPrice);
                    calcLotQuantity.Value = System.Convert.ToDecimal(objLot.Quantity);
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Отображение свойств прихода. Текст ошибки: " + f.Message);
            }
            return;
        }
        #endregion

        #region Редактирование приходного документа
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
                if ((m_objParentKLP != null) && (m_enLotListMode == LotListMode.FromKLP))
                {
                    cboxCurrency.Properties.ReadOnly = true;
                }
                else
                {
                    cboxCurrency.Properties.ReadOnly = bSet;
                }
                cboxCountryProduction.Properties.ReadOnly = bSet;
                cboxStockLot.Properties.ReadOnly = bSet;

                txtStoreWaybillNum.Properties.ReadOnly = bSet;
                dtStoreWaybillDocDate.Properties.ReadOnly = bSet;

                cboxProductTradeMark.Properties.ReadOnly = bSet;
                cboxProductType.Properties.ReadOnly = bSet;
                spinEditDiscount.Properties.ReadOnly = bSet;
                btnSetDiscount.Enabled = !bSet;
                checkMultiplicity.Properties.ReadOnly = bSet;
                checkLotActive.Properties.ReadOnly = bSet;

                gridView.OptionsBehavior.Editable = !bSet;

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

                if (m_objParentKLP == null)
                {
                    // у прихода нет ссылки на КЛП
                    // загрузка всего справочника товаров в выпадающий список для заполнения приложения к приходу
                    StartLoadProductListForComboBoxInThread(true);
                }
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
        /// <summary>
        /// очистка содержимого элементов управления редакторе
        /// </summary>
        private void ClearControlsInEditor()
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

                txtStoreWaybillNum.Text = "";
                dtStoreWaybillDocDate.EditValue = null;

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
        /// <summary>
        /// Загрузка приложения к приходу в грид и формирование выпадающего списка значений для заполнения грида
        /// в выпадающий список загружаются только те позиции, которые присутствуют в приложении к приходу
        /// </summary>
        private void LoadLotItemsListToDataSet()
        {
            try
            {
                dataSet.Tables["Product"].Clear();
                System.Data.DataRow newRowProduct = null;

                dataSet.Tables["OrderItems"].Clear();
                System.Data.DataRow newRowOrderItems = null;

                foreach (CLotItem objItem in m_objCurrentLot.LotItemList)
                {
                    // выпадающий список с товарами
                    newRowProduct = dataSet.Tables["Product"].NewRow();
                    newRowProduct["ProductID"] = objItem.Product.ID;
                    newRowProduct["Product_MeasureID"] = objItem.Measure.ID;
                    newRowProduct["Product_MeasureName"] = objItem.Measure.ShortName;
                    newRowProduct["ProductFullName"] = objItem.Product.ProductFullName;
                    newRowProduct["ProductShortName"] = objItem.Product.Name;
                    newRowProduct["ProductArticle"] = objItem.Product.Article;
                    newRowProduct["CustomerOrderPackQty"] = 1;
                    newRowProduct["KLPItemGuid"] = objItem.KLPItems_ID;

                    dataSet.Tables["Product"].Rows.Add(newRowProduct);

                    // приложение к приходу
                    newRowOrderItems = dataSet.Tables["OrderItems"].NewRow();
                    newRowOrderItems["OrderItemsID"] = objItem.ID;
                    newRowOrderItems["KLPItemsID"] = objItem.KLPItems_ID;
                    newRowOrderItems["ProductID"] = objItem.Product.ID;
                    newRowOrderItems["MeasureID"] = objItem.Measure.ID;
                    newRowOrderItems["LotItems_Quantity"] = objItem.Quantity;
                    newRowOrderItems["KLPItems_Quantity"] = objItem.QuantityInKLP;
                    newRowOrderItems["Lot_Quantity"] = 0;
                    newRowOrderItems["CountryProductionID"] = objItem.CountryProduction.ID;
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
                newRowProduct = null;
                dataSet.Tables["Product"].AcceptChanges();

                newRowOrderItems = null;
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
        /// <summary>
        /// загрузка свойств прихода в элементы управления
        /// </summary>
        /// <param name="objLot">объект "Приход на склад"</param>
        private void LoadLotPropertiesToControls(CLot objLot)
        {
            try
            {
                txtLotDescription.Text = objLot.Description;
                txtLotNum.Text = objLot.Number;
                txtLotDocNum.Text = objLot.DocNumber;
                txtKLPNum.Text = ((m_objParentKLP != null) ? (String.Format("№{0} от {1}", m_objParentKLP.Number, m_objParentKLP.Date.ToShortDateString())) : "");
                dtLotDocDate.DateTime = objLot.DocDate;

                cboxVendor.SelectedItem = (objLot.Vendor == null) ? null : cboxVendor.Properties.Items.Cast<CVendor>().SingleOrDefault<CVendor>(x => x.ID.CompareTo(objLot.Vendor.ID) == 0);
                cboxCurrency.SelectedItem = (objLot.Currency == null) ? null : cboxCurrency.Properties.Items.Cast<CCurrency>().SingleOrDefault<CCurrency>(x => x.ID.CompareTo(objLot.Currency.ID) == 0);
                cboxStockLot.SelectedItem = (objLot.Stock == null) ? null : cboxStockLot.Properties.Items.Cast<CStock>().SingleOrDefault<CStock>(x => x.ID.CompareTo(objLot.Stock.ID) == 0);

                checkLotActive.Checked = objLot.IsActive;
                calcLotCurrencyRate.Value = System.Convert.ToDecimal(m_objCurrentLot.RateCurrencyToCurrencyMain);

                cboxLotState.Properties.Items.Clear();
                cboxLotState.Properties.Items.AddRange(CLotState.GetLotStateList(m_objProfile, null, objLot.ID));
                cboxLotState.SelectedItem = (objLot.CurrentLotState == null) ? null : cboxLotState.Properties.Items.Cast<CLotState>().SingleOrDefault<CLotState>(x => x.ID.CompareTo(objLot.CurrentLotState.ID) == 0);

                txtStoreWaybillNum.Text = objLot.StoreWaybillDocNumber;
                dtStoreWaybillDocDate.DateTime = objLot.StoreWaybillDate;

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
        /// Загружает свойства прихода в редактор
        /// </summary>
        /// <param name="objLot">объект "приход на склад"</param>
        private void EditLot(CLot objLot)
        {
            this.Cursor = Cursors.WaitCursor;

            if (objLot == null) { return; }
            try
            {
                // m_objCurrentLot используется для идентификации текущего объекта
                m_objCurrentLot = objLot;
                m_objParentKLP = m_objCurrentLot.ParentKLP;

                System.Int32 iRes = 0;
                System.String strErr = "";
                
                // запрос приложения к приходу
                m_objCurrentLot.LotItemList = CLotRepository.GetLotItemList(m_objProfile, null, m_objCurrentLot.ID,  ref iRes, ref strErr);

                if (iRes != 0)
                {
                    SendMessageToLog("Ошибка редактирования прихода. Текст ошибки: " + strErr);
                }
                else
                {
                    try
                    {
                        //((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
                        //this.SuspendLayout();
                        // пометка для обработчика изменений в элементах управления, что не нужно реагировать
                        // метод обработчика вызывается, но сразу передаёт управление в вызывающий его метод
                        m_bDisableEvents = true;
                        // текущий объект не является новым
                        m_bNewObject = false;
                        try
                        {
                            // очистка содержимого элементов управления
                            ClearControlsInEditor();
                            // загрузка свойств прихода в элементы управления
                            LoadLotPropertiesToControls(m_objCurrentLot);
                            // загрузка приложения к приходу в грид
                            LoadLotItemsListToDataSet();
                            // после загрузки всех свойств установка пометки, что изменения в редакторе отсутствуют
                            SetPropertiesModified(false);
                            // проверка элементов управления на предмет заполнения всех обязательных полей
                            ValidateProperties();
                            // включение режима "Только просмотр"
                            SetModeReadOnly(true);
                        }
                        catch (System.Exception f)
                        {
                            SendMessageToLog("Ошибка редактирования документа \"Приход на склад\". Текст ошибки: " + f.Message);
                        }
                        finally
                        {
                            // включается обработчик изменений в элементах управления
                            m_bDisableEvents = false;
                            btnCancel.Enabled = true;
                        }
                    }
                    catch (System.Exception f)
                    {
                        SendMessageToLog("Ошибка редактирования прихода. Текст ошибки: " + f.Message);
                    }
                    finally
                    {
                        //((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
                        //this.ResumeLayout(false);
                        // текущей закладкой становится "Редактор"
                        tabControl.SelectedTabPage = tabPageEditor;
                        if (m_objCurrentLot.CurrentLotState != null)
                        {
                            // проверка, можно ли редактировать документ в текущем состоянии
                            btnEdit.Visible = m_objCurrentLot.CurrentLotState.IsCanEditDocument;
                        }
                    }

                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка редактирования прихода. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return;
        }
        private void barBtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // выбранный в списке объект загружается в редактор
                m_enOpenLotEditorMode = OpenLotEditorMode.FromLotLis;
                // выбранный в списке объект загружается в редактор
                EditLot(SelectedLot);
                //// сразу включается режим "Просмотр и Редактирование"
                //SetModeReadOnly( false );
            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка редактирования прихода. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        private void gridControlLotList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                // выбранный в списке объект загружается в редактор
                m_enOpenLotEditorMode = OpenLotEditorMode.FromLotLis;
                EditLot(SelectedLot);
            }//try
            catch (System.Exception f)
            {
                SendMessageToLog(f.Message);
            }
            finally
            {
            }
            return;
        }
        #endregion

        #region Изменения в редакторе прихода подтверждены
        private void SaveChangesInLot()
        {
            try
            {
                //((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
                //this.SuspendLayout();

                tabControl.SelectedTabPage = tabPageViewer;
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Подтверждение изменений. Текст ошибки: " + f.Message);
            }
            finally // очищаем занимаемые ресурсы
            {
                //((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
                //this.ResumeLayout(false);
            }

            return;
        }
        #endregion

        #region Удалить документ "приход на склад"
        /// <summary>
        /// Удаляет приходный документ из БД
        /// </summary>
        /// <param name="objLot">приходный документ</param>
        private void DeleteLot(CLot objLot)
        {
            if (objLot == null) { return; }
            try
            {
                if (objLot.CurrentLotState.IsCanEditDocument == false)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Состояние документа \"" + objLot.CurrentLotStateName + "\".\nУдаление запрещено!", "Предупреждение",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return;
                }

                System.Int32 iFocusedRowHandle = gridViewLotList.FocusedRowHandle;
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Подтвердите, пожалуйста, удаление документа \"Приход на склад\".\n\n№" + objLot.DocNumber +
                    "\nДата: " + objLot.DocDate.ToShortDateString() + "\nПоставщик: " + objLot.VendorName, "Подтверждение",
                    System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == DialogResult.No) { return; }

                System.String strErr = "";
                if (CLotRepository.DeleteLot(m_objProfile, null, objLot.ID, ref strErr) == true)
                {
                    m_objLotList.Remove(objLot);
                    gridControlLotList.RefreshDataSource();

                    if (iFocusedRowHandle < m_objLotList.Count)
                    {
                        gridViewLotList.FocusedRowHandle = iFocusedRowHandle;
                    }
                    else if (m_objLotList.Count > 0)
                    {
                        gridViewLotList.FocusedRowHandle = (m_objLotList.Count - 1);
                    }
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(strErr, "Ошибка",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Удаление приходного документа. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }
        private void barBtnDeleteLot_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteLot(SelectedLot);
            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("Удаление приходного документа. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return;
        }
        #endregion

        #region Печать
        private void sbExportToXLS_Click(object sender, System.EventArgs e)
        {
            try
            {
                string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xls");
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
            }

            return;
        }

        //<sbExportToHTML>
        private void ExportTo(IExportProvider provider)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            this.FindForm().Refresh();
            BaseExportLink link = gridViewLotList.CreateExportLink(provider);
            (link as GridViewExportLink).ExpandAll = false;
            link.ExportTo(true);
            provider.Dispose();

            Cursor.Current = currentCursor;
        }
        //</sbExportToHTML>

        private string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = "список приходов на склад"; // Application.ProductName;
            //int n = name.LastIndexOf(".") + 1;
            //if (n > 0) name = name.Substring(n, name.Length - n);
            dlg.Title = "Экспорт данных в " + title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }

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
                    DevExpress.XtraEditors.XtraMessageBox.Show(this, "Не удалось найти приложение, с помощью которого можно было бы открыть файл.", "Открыть файл", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion


        // Редактор

        #region Свойства
        private List<ERP_Mercury.Common.CProduct> m_objPartsList;

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
        public delegate void LoadPartsListDelegate();
        public LoadPartsListDelegate m_LoadPartsListDelegate;

        public delegate void SendMessageToLogDelegate(System.String strMessage);
        public SendMessageToLogDelegate m_SendMessageToLogDelegate;

        public delegate void SetProductListToFormDelegate(List<ERP_Mercury.Common.CProduct> objProductNewList, System.Int32 iRowCountInLis);
        public SetProductListToFormDelegate m_SetProductListToFormDelegate;

        private const System.String m_strReportsDirectory = "templates";
        private const System.String m_strReportLot = "Lot.xlsx";
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

        // Создаем закрытое поле, ссылающееся на заголовок списка делегатов
        private EventHandler<CloseLotListEventArgs> m_CloseLotList;
        // Создаем в классе член-событие
        public event EventHandler<CloseLotListEventArgs> CloseLotList
        {
            add
            {
                // берем закрытую блокировку и добавляем обработчик
                // (передаваемый по значению) в список делегатов
                m_CloseLotList += value;
            }
            remove
            {
                // берем закрытую блокировку и удаляем обработчик
                // (передаваемый по значению) из списка делегатов
                m_CloseLotList -= value;
            }
        }
        /// <summary>
        /// Инициирует событие и уведомляет о нем зарегистрированные объекты
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCloseLotList(CloseLotListEventArgs e)
        {
            // Сохраняем поле делегата во временном поле для обеспечение безопасности потока
            EventHandler<CloseLotListEventArgs> temp = m_CloseLotList;
            // Если есть зарегистрированные объектв, уведомляем их
            if (temp != null) temp(this, e);
        }
        public void SimulateCloseLotList(LotListMode enumeratorLotListMode)
        {
            // Создаем объект, хранящий информацию, которую нужно передать
            // объектам, получающим уведомление о событии
            CloseLotListEventArgs e = new CloseLotListEventArgs(enumeratorLotListMode);

            // Вызываем виртуальный метод, уведомляющий наш объект о возникновении события
            // Если нет типа, переопределяющего этот метод, наш объект уведомит все объекты, 
            // подписавшиеся на уведомление о событии
            OnCloseLotList(e);
        }

        // Создаем закрытое поле, ссылающееся на заголовок списка делегатов
        private EventHandler<CloseLotEditorEventArgs> m_CloseLotEditor;
        // Создаем в классе член-событие
        public event EventHandler<CloseLotEditorEventArgs> CloseLotEditor
        {
            add
            {
                // берем закрытую блокировку и добавляем обработчик
                // (передаваемый по значению) в список делегатов
                m_CloseLotEditor += value;
            }
            remove
            {
                // берем закрытую блокировку и удаляем обработчик
                // (передаваемый по значению) из списка делегатов
                m_CloseLotEditor -= value;
            }
        }
        /// <summary>
        /// Инициирует событие и уведомляет о нем зарегистрированные объекты
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCloseLotEditor(CloseLotEditorEventArgs e)
        {
            // Сохраняем поле делегата во временном поле для обеспечение безопасности потока
            EventHandler<CloseLotEditorEventArgs> temp = m_CloseLotEditor;
            // Если есть зарегистрированные объектв, уведомляем их
            if (temp != null) temp(this, e);
        }
        public void SimulateCloseLotEditor(OpenLotEditorMode enumeratorOpenLotEditorMode, CLot objLot, System.Boolean bNewObject)
        {
            // Создаем объект, хранящий информацию, которую нужно передать
            // объектам, получающим уведомление о событии
            CloseLotEditorEventArgs e = new CloseLotEditorEventArgs(enumeratorOpenLotEditorMode, objLot, bNewObject);

            // Вызываем виртуальный метод, уведомляющий наш объект о возникновении события
            // Если нет типа, переопределяющего этот метод, наш объект уведомит все объекты, 
            // подписавшиеся на уведомление о событии
            OnCloseLotEditor(e);
        }
        #endregion

        #region Загрузка формы
        private void ctrlLotList_Load(object sender, EventArgs e)
        {
            try
            {
                gridControlLotList.Focus();
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

        #region Индикация изменений
        /// <summary>
        /// Проверяет содержимое элементов управления
        /// </summary>
        private System.Boolean ValidateProperties()
        {
            System.Boolean bRet = true;
            try
            {
                cboxVendor.Properties.Appearance.BackColor =( ((cboxVendor.SelectedItem == null) || ( cboxVendor.Text == System.String.Empty ) ) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                cboxCurrency.Properties.Appearance.BackColor =( ((cboxCurrency.SelectedItem == null) || ( cboxCurrency.Text == System.String.Empty ) ) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                cboxLotState.Properties.Appearance.BackColor =( ((cboxLotState.SelectedItem == null) || ( cboxLotState.Text == System.String.Empty ) ) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                cboxStockLot.Properties.Appearance.BackColor = (((cboxStockLot.SelectedItem == null) || ( cboxStockLot.Text == System.String.Empty ) ) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                txtLotNum.Properties.Appearance.BackColor = ((txtLotNum.Text == System.String.Empty) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                txtLotDocNum.Properties.Appearance.BackColor = ((txtLotDocNum.Text == System.String.Empty) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                calcLotCurrencyRate.Properties.Appearance.BackColor = ((calcLotCurrencyRate.Value <= 0) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                dtLotDocDate.Properties.Appearance.BackColor = ((dtLotDocDate.DateTime == System.DateTime.MinValue) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);

                if ((cboxVendor.SelectedItem == null) || (cboxVendor.Text == System.String.Empty)) { bRet = false; }
                if ((cboxCurrency.SelectedItem == null) || (cboxCurrency.Text == System.String.Empty)) { bRet = false; }
                if ((cboxLotState.SelectedItem == null) || (cboxLotState.Text == System.String.Empty)) { bRet = false; }
                if ((cboxStockLot.SelectedItem == null) || (cboxStockLot.Text == System.String.Empty)) { bRet = false; }
                if (txtLotNum.Text == System.String.Empty) { bRet = false; }
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
                    SimulateChangeLotProperties(SelectedLot, ERP_Mercury.Common.enumActionSaveCancel.Unkown, m_bNewObject);
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
                if ((sender == cboxCurrency) && (cboxCurrency.SelectedItem != null))
                {
                    // пересчёт курса
                    System.String strErr = "";
                    m_objCurrentLot.RateCurrencyToCurrencyMain = System.Convert.ToDouble(CCurrencyRate.GetCurrencyRate(m_objProfile, null,
                     ((CCurrency)cboxCurrency.SelectedItem).ID, m_uuidCurrenyAccounting, m_objCurrentLot.DocDate, ref strErr));
                    calcLotCurrencyRate.Value = System.Convert.ToDecimal(m_objCurrentLot.RateCurrencyToCurrencyMain);
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


        #endregion

        #region Загрузка всего справочника товаров в список допустимых значений для приложения к приходу
        /// <summary>
        /// Запуск потока, в котором загружается выпадающий список значений из справочника товаров
        /// </summary>
        /// <param name="bForcedReload">Признак, нужно ли принудительно обновить список, если он уже заполнен</param>
        public void StartLoadProductListForComboBoxInThread(System.Boolean bForcedReload = false)
        {
            if (bForcedReload == false)
            {
                if ((m_objPartsList != null) && (m_objPartsList.Count > 0) && (m_bComboBoxWithProductListIsFull == true)) { return; }
            }
            try
            {
                // инициализируем события
                this.EventStopThread = new System.Threading.ManualResetEvent(false);
                this.EventThreadStopped = new System.Threading.ManualResetEvent(false);
                m_bThreadFinishJob = false;

                // инициализируем делегаты
                m_SetProductListToFormDelegate = new SetProductListToFormDelegate(SetProductListToForm);
                m_SendMessageToLogDelegate = new SendMessageToLogDelegate(SendMessageToLog);
                if (m_objPartsList == null) { m_objPartsList = new List<CProduct>(); }

                m_objPartsList.Clear();
                panelProgressBar.Visible = true;
                progressBarControl.Position = 5;

                mitemImport.Visible = false;

                this.Update();

                // запуск потока
                // делаем событиям reset
                this.EventStopThread.Reset();
                this.EventThreadStopped.Reset();

                this.thrAddress = new System.Threading.Thread(LoadProductListForComboBox);
                this.thrAddress.Start();

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
                System.Boolean bNeedCloseThread = false;
                // запрос списка товаров из справочника
                List<CProduct> objProductList = CProduct.GetProductList(m_objProfile, null, false, true);
                List<CProduct> objAddProductList = new List<CProduct>();
                // порциями по 2000 записей заполняется выпадающий список значений
                if ((objProductList != null) && (objProductList.Count > 0))
                {
                    System.Int32 iRecCount = 0;
                    System.Int32 iRecAllCount = objProductList.Count;
                    foreach (CProduct objProduct in objProductList)
                    {
                        objAddProductList.Add(objProduct);
                        iRecCount++;

                        if (iRecCount == 2000)
                        {
                            iRecCount = 0;
                            Thread.Sleep(1000);
                            this.Invoke(m_SetProductListToFormDelegate, new Object[] { objAddProductList, iRecAllCount });
                            objAddProductList.Clear();
                        }

                        if (m_bThreadFinishJob == true)
                        {
                            break;
                        }
                    }
                    if ((iRecCount != 2000) && (m_bThreadFinishJob == false))
                    {
                        iRecCount = 0;
                        this.Invoke(m_SetProductListToFormDelegate, new Object[] { objAddProductList, iRecAllCount });
                        objAddProductList.Clear();
                    }

                }

                m_bComboBoxWithProductListIsFull = true;
                objProductList = null;
                objAddProductList = null;
                this.Invoke(m_SetProductListToFormDelegate, new Object[] { null, 0 });

                if (m_bThreadFinishJob == false)
                { this.m_bThreadFinishJob = true; }
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
                    foreach (ERP_Mercury.Common.CProduct objItem in objPartsList)
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

                    System.Double iPart = dataSet.Tables["Product"].Rows.Count;
                    System.Double iAll = iRowCountInList;
                    System.Double iPosition = (iPart / iAll) * 100;

                    progressBarControl.Position = System.Convert.ToInt32( iPosition );
                    this.Update();

                }
                else
                {
                    progressBarControl.Position = 100;
                    this.Update();
                    this.m_bThreadFinishJob = true;
                    SendMessageToLog("SetProductListToForm. Загрузка списка товаров завершена: " + System.DateTime.Now.ToLongTimeString());
                    panelProgressBar.Visible = false;
                    mitemImport.Visible = true;
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
        /// <summary>
        /// Останавливает поток, в котором загружается справочник товаров в выпадающий список
        /// </summary>
        public void CloseThreadInLotEditor()
        {
            try
            {
                if (bIsThreadsActive() == true)
                {
                    if ((ThreadAddress != null) && (ThreadAddress.IsAlive == true))
                    {
                        m_bThreadFinishJob = true;
                    }
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

        #region Новый приход
        public void NewLotFromKLPEditor(CKLP objKLP, List<CKLPItems> objKLPItemList)
        {
            try
            {
                m_objParentKLP = objKLP;
                m_enLotListMode = LotListMode.FromKLP;
                m_enOpenLotEditorMode = OpenLotEditorMode.FromKLPEditor;

                tableLayoutPanelLotList.RowStyles[iSearchPanelRowStyleIndx].Height = 0;
                lblOrderInfo.Text = (((m_enLotListMode == LotListMode.FromKLP) && (m_objParentKLP != null)) ? (String.Format("{0} для КЛП №{1} от {2}", strLblInfoForLotListCaption, m_objParentKLP.Number, m_objParentKLP.Date.ToShortDateString())) : (strLblInfoForLotListCaption));

                cboxVendor.Properties.Items.Clear();
                cboxVendor.Properties.Items.Add(objKLP.Vendor);

                //StartThreadLoadStockList();

                RestoreLayoutFromRegistry();

                NewLotFromKLP(objKLP, objKLPItemList);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("NewLotFromKLPEditor.\n\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void barBtnAdd_Click(object sender, EventArgs e)
        {
            CreateNewLot();
        }

        /// <summary>
        /// Определяет вариант создания нового прихода (из КЛП, либо без привязки к КЛП)и вызывает соответствующие методы 
        /// </summary>
        private void CreateNewLot()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (m_enLotListMode != LotListMode.FromKLP) 
                {
                    // m_objParentKLP ссылается на "родительский" КЛП того прихода, который открывался в редакторе последним
                    // если же журнал был открыт НЕ из модуля КЛП, то ссылка на КЛП при создании нового прихода обнуляется
                    m_objParentKLP = null;
                }
                if ((m_objParentKLP != null) && (m_enLotListMode == LotListMode.FromKLP))
                {
                    // приход формируется на основании КЛП

                    if (m_objParentKLP.IsCostCalc == false)
                    {
                        if (DevExpress.XtraEditors.XtraMessageBox.Show(
                           "Для выбранного КЛП нет пометки, что себестоимость рассчитана.\nПрдолжить операцию по созданию нового прихода?", "Подтверждение",
                           System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) != DialogResult.Yes)
                        {
                            return;
                        }

                    }

                    // запрашивается приложение к КЛП
                    System.Int32 iRes = 0;
                    System.String strErr = System.String.Empty;
                    List<CKLPItems> objKLPItemList = CKLPRepository.GetKLPItemsList(m_objProfile, null, m_objParentKLP.ID, ref iRes, ref strErr);
                    if ((objKLPItemList != null) && (iRes == 0))
                    {
                        // открывается закладка с редактором
                        NewLotFromKLP(m_objParentKLP, objKLPItemList);
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                            String.Format("Не удалось получить список позиций из КЛП для приходного документаg.\n\nТекст ошибки: {0}", strErr), "Ошибка",
                           System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    NewLotWithoutKLP();
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("CreateNewLot. Текст ошибки: " + f.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            return;
        }

        /// <summary>
        /// Новый приход
        /// </summary>
        public void NewLotWithoutKLP()
        {
            try
            {
                // пометка "редактируется новый объект, которого ещё нет в БД"
                m_bNewObject = true;

                // редактор открывается из журнала приходов
                m_enOpenLotEditorMode = OpenLotEditorMode.FromLotLis;
                
                // отключаются обработчики изменений в элементах управления
                m_bDisableEvents = true;

                // создание объекта "текущий приходный документ"
                m_objCurrentLot = new CLot() { DocDate = System.DateTime.Today, LotItemList = new List<CLotItem>() };

                //// отключается визуализация изменений в контейнере
                //this.tableLayoutPanelBackground.SuspendLayout();

                // очистка значений в элементах управления
                ClearControlsInEditor();

                // загрузка свойств объекта приход в элементы управления
                LoadLotPropertiesToControls(m_objCurrentLot);
                
                // загрузка приложения к приходу в dataset
                LoadLotItemsListToDataSet();

                // установка значений текущего состояния прихода и страны производства для значения по умолчанию в приложении к приходу
                cboxLotState.SelectedItem = (cboxLotState.Properties.Items.Count == 0) ? null : cboxLotState.Properties.Items[0];
                cboxCountryProduction.SelectedItem = ((cboxCountryProduction.Properties.Items.Count > 0) ? cboxCountryProduction.Properties.Items[0] : null);

                // кнопка "Редактировать" отключается, а "Отмена" включается
                btnEdit.Enabled = false;
                btnCancel.Enabled = true;

                // установка режима "Редактирование"
                SetModeReadOnly(false);
                
                // пометка о том, что были произведены изменения в свойствах приходного документа
                SetPropertiesModified(true);

                // включаются обработчики изменений в элементах управления
                m_bDisableEvents = false;
                // открывается закладка с релдактором прихода
                tabControl.SelectedTabPage = tabPageEditor;
                tabPageEditor.Refresh();

                // в потоке запускается процесс по формированию выпадающего списка с товарами
                StartLoadProductListForComboBoxInThread( true );
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка создания документа \"Приход товара\". Текст ошибки: " + f.Message);
            }
            finally
            {
                //// включается визуализация изменений в контейнере
                //tableLayoutPanelBackground.ResumeLayout(false);
            }
            return;
        }
        /// <summary>
        /// Создаёт новый объект "Приходный документ" с привязкой к конкретному КЛП
        /// </summary>
        /// <param name="uuidKLPId"></param>
        /// <param name="strKLPNum"></param>
        /// <param name="objVendor"></param>
        /// <param name="objKLPItemList"></param>
        public void NewLotFromKLP( CKLP objKLP, List<CKLPItems> objKLPItemList )
        {
            try
            {
                gridView.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView_CellValueChanged);

                // пометка "редактируется новый объект, которого ещё нет в БД"
                m_bNewObject = true;

                // редактор открывается из журнала приходов
                m_enOpenLotEditorMode = OpenLotEditorMode.FromLotLis;

                // отключаются обработчики изменений в элементах управления
                m_bDisableEvents = true;

                // создание объекта "текущий приходный документ"
                m_objCurrentLot = new CLot() { DocDate = System.DateTime.Today, Vendor = objKLP.Vendor, LotItemList = new List<CLotItem>(), 
                    Currency = objKLP.Currency, IsActive = true };

                List<CCurrency> objCurrencylist = CCurrency.GetCurrencyList(m_objProfile, null);
                if ((objCurrencylist != null) && (objCurrencylist.Count > 0))
                {
                    // идентификатор валюты учёта
                    CCurrency objCurrenyAccounting = objCurrencylist.SingleOrDefault<CCurrency>(x => x.IsMain);
                    m_uuidCurrenyAccounting = ((objCurrenyAccounting != null) ? objCurrenyAccounting.ID : System.Guid.Empty);
                    if (m_objCurrentLot.Currency == null) { m_objCurrentLot.Currency = objCurrenyAccounting; }
                }
                objCurrencylist = null;

                System.String strErr = System.String.Empty;
                m_objCurrentLot.RateCurrencyToCurrencyMain = System.Convert.ToDouble( CCurrencyRate.GetCurrencyRate(m_objProfile, null, 
                    m_objCurrentLot.Currency.ID, m_uuidCurrenyAccounting, m_objCurrentLot.DocDate, ref strErr) );

                // загрузка приложения к приходу из приложения к КЛП
                foreach (CKLPItems objKLPItem in objKLPItemList)
                {
                    m_objCurrentLot.LotItemList.Add(new CLotItem()
                    {
                        KLPItems_ID = objKLPItem.ID,
                        Product = objKLPItem.Product,
                        Measure = objKLPItem.Measure,
                        CountryProduction = objKLPItem.CountryProduction,
                        Quantity = objKLPItem.QuantityFact,
                        CostPrice = objKLPItem.PriceForCalcCostPrice,
                        ExpirationDate = objKLPItem.ExpirationDate,
                        Price = objKLPItem.PriceForCalcCostPriceInVendorCurrency //  (objKLPItem.PriceForCalcCostPrice * m_objCurrentLot.RateCurrencyToCurrencyMain)
                    });
                }

                //// отключается визуализация изменений в контейнере
                //this.tableLayoutPanelBackground.SuspendLayout();

                // очистка значений в элементах управления
                ClearControlsInEditor();

                // загрузка свойств объекта приход в элементы управления
                LoadLotPropertiesToControls(m_objCurrentLot);

                // загрузка приложения к приходу в dataset
                LoadLotItemsListToDataSet();

                // установка значений текущего состояния прихода и страны производства для значения по умолчанию в приложении к приходу
                cboxLotState.SelectedItem = (cboxLotState.Properties.Items.Count == 0) ? null : cboxLotState.Properties.Items[0];
                cboxCountryProduction.SelectedItem = ((cboxCountryProduction.Properties.Items.Count > 0) ? cboxCountryProduction.Properties.Items[0] : null);
                txtKLPNum.Text = objKLP.Number;
                txtLotNum.Text = objKLP.Number;
                txtStoreWaybillNum.Text = objKLP.VendorName;

                System.String strKLPId = "3000000";
                txtLotDocNum.Text = "№" + strKLPId.Substring(0, (strKLPId.Length - objKLP.Ib_ID.ToString().Length)) + objKLP.Ib_ID.ToString(); 

                // кнопка "Редактировать" отключается, а "Отмена" включается
                btnEdit.Enabled = false;
                btnCancel.Enabled = true;

                // установка режима "Редактирование"
                SetModeReadOnly(false);

                // пометка о том, что были произведены изменения в свойствах приходного документа
                SetPropertiesModified(true);

                m_bDisableEvents = false;
                // открывается закладка с релдактором прихода
                tabControl.SelectedTabPage = tabPageEditor;
                tabPageEditor.Refresh();

                txtLotNum.Focus();
                txtLotNum.SelectAll();

                // в потоке запускается процесс по формированию выпадающего списка с товарами
                // 2013.06.24
                // отключаю загрузку всего справочника товаров
                //StartLoadProductListForComboBoxInThread();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка создания документа \"Приход товара\". Текст ошибки: " + f.Message);
            }
            finally
            {
                gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView_CellValueChanged);
                //// включается визуализация изменений в контейнере
                //tableLayoutPanelBackground.ResumeLayout(false);
                // включаются обработчики изменений в элементах управления
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
                // закрываем поток, в котором загружается справочник товаров для выпадающего списка
                CloseThreadInLotEditor();

                // сообщает всем, кто подписался на событие "CloseLotEditorEventArgs", что оно наступило
                SimulateCloseLotEditor(m_enOpenLotEditorMode, m_objCurrentLot, m_bNewObject);
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
                if ( m_objCurrentLot == null)
                {
                    strErr += ("\nПрограмме не удалось определить объект \"Приходный документ\".\nОбратитесь, пожалуйста, к разработчику.");
                    return SaveChangesResult.Failure;
                }

                System.Guid KLP_Guid = System.Guid.Empty;

                if (m_bNewObject == true)
                {
                    KLP_Guid = ((m_objParentKLP == null) ? System.Guid.Empty : m_objParentKLP.ID);
                }
                else
                {
                    KLP_Guid = ( ( m_objCurrentLot.ParentKLP != null ) ?  m_objCurrentLot.ParentKLP.ID : System.Guid.Empty);
                }
                
                System.String Lot_Num = txtLotNum.Text;
                System.String Lot_DocNum = txtLotDocNum.Text;
                System.DateTime Lot_Date = dtLotDocDate.DateTime;
                System.String Lot_Description = txtLotDescription.Text;
                System.Boolean Lot_IsActive = checkLotActive.Checked;

                System.Guid Vendor_Guid = ((cboxVendor.SelectedItem == null) ? (System.Guid.Empty) : ((CVendor)cboxVendor.SelectedItem).ID);
                System.Guid Currency_Guid = ((cboxCurrency.SelectedItem == null) ? (System.Guid.Empty) : ((CCurrency)cboxCurrency.SelectedItem).ID);
                System.Guid Stock_Guid = ((cboxStockLot.SelectedItem == null) ? (System.Guid.Empty) : ((CStock)cboxStockLot.SelectedItem).ID);
                System.Guid LotState_Guid = ((cboxLotState.SelectedItem == null) ? (System.Guid.Empty) : ((CLotState)cboxLotState.SelectedItem).ID);
                System.Double Lot_CurrencyRate = System.Convert.ToDouble(calcLotCurrencyRate.Value);

                System.Guid Lot_Guid = ((m_bNewObject == true) ? System.Guid.Empty : m_objCurrentLot.ID);
                System.Int32 Lot_Id = ((m_bNewObject == true) ? 0 : m_objCurrentLot.Ib_ID);
                System.Double Lot_AllPrice = 0;
                System.Double Lot_CurrencyAllPrice = 0;
                System.Double Lot_RetCurrencyAllPrice = 0;

                List<CLotItem> objLotItemList = new List<CLotItem>(); 
                
                System.String StoreWaybill_DocNum = txtStoreWaybillNum.Text;
                System.DateTime StoreWaybill_DocDate = dtStoreWaybillDocDate.DateTime;

                System.Guid uuidOrderItmsID = System.Guid.Empty;
                System.Guid uuidKLPItemID = System.Guid.Empty;
                System.Guid uuidProductID = System.Guid.Empty;
                System.Guid uuidMeasureID = System.Guid.Empty;
                System.Guid uuidCountryProductionID = System.Guid.Empty;
                System.Double dblLotItems_Quantity = 0;
                System.Double dblKLPItems_Quantity = 0;
                System.Double dblLot_Quantity = 0;
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
                    uuidKLPItemID = ((dataSet.Tables["OrderItems"].Rows[i]["KLPItemsID"] == System.DBNull.Value) ? System.Guid.Empty : (System.Guid)(dataSet.Tables["OrderItems"].Rows[i]["KLPItemsID"]));

                    dblKLPItems_Quantity = System.Convert.ToDouble(dataSet.Tables["OrderItems"].Rows[i]["KLPItems_Quantity"]);
                    dblLot_Quantity = System.Convert.ToDouble(dataSet.Tables["OrderItems"].Rows[i]["Lot_Quantity"]);

                    objLotItemList.Add(new CLotItem()
                    {
                        ID = uuidOrderItmsID, 
                        KLPItems_ID = uuidKLPItemID,
                        Product = new CProduct() { ID = uuidProductID },
                        Measure = new CMeasure() { ID = uuidMeasureID },
                        CountryProduction = new CCountry() { ID = uuidCountryProductionID },
                        Quantity = dblLotItems_Quantity, 
                        QuantityInKLP = dblKLPItems_Quantity, QuantityReturn = 0, Ib_Id = 0,
                        Price = dblLotItems_Price,
                        CostPrice = dblLotItems_CurrencyPrice,
                        ExpirationDate = dtExpirationDate
                    });

                }
                System.Data.DataTable addedItems = ((gridControl.DataSource == null) ? null : CLotItem.ConvertListToTable(objLotItemList, Lot_Guid, ref strErr));
                System.Double dblSumQuantity = objLotItemList.Sum<CLotItem>(x => x.Quantity);
                System.Double dblSumCostPrice = objLotItemList.Sum<CLotItem>(x => x.SumCostPrice);
                System.Double dblSumPrice = objLotItemList.Sum<CLotItem>(x => x.SumPrice);

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
                            LotState_Guid, Lot_CurrencyRate,  addedItems, StoreWaybill_DocDate, StoreWaybill_DocNum,
                            ref Lot_Guid, ref Lot_Id, ref Lot_AllPrice, ref Lot_CurrencyAllPrice,
                            ref Lot_RetCurrencyAllPrice, ref strErr);
                    }
                    else
                    {
                        bRet = CLotRepository.EditLot(m_objProfile, null, KLP_Guid, Lot_Num, Lot_DocNum, Lot_Date,
                            Vendor_Guid, Currency_Guid, Stock_Guid, Lot_Description, Lot_IsActive,
                            LotState_Guid, Lot_CurrencyRate, addedItems, StoreWaybill_DocDate, StoreWaybill_DocNum,
                            Lot_Guid, ref Lot_AllPrice, ref Lot_CurrencyAllPrice,
                            ref Lot_RetCurrencyAllPrice, ref strErr);
                    }
                }

                if (bRet == true)
                {
                    if (m_bNewObject == true)
                    {
                        m_objCurrentLot.ID = Lot_Guid;
                        m_objCurrentLot.Ib_ID = Lot_Id;
                    }
                    m_objCurrentLot.Number = Lot_Num;
                    m_objCurrentLot.DocNumber = Lot_DocNum;
                    m_objCurrentLot.DocDate = Lot_Date;
                    m_objCurrentLot.Date = Lot_Date;
                    m_objCurrentLot.Vendor = ((cboxVendor.SelectedItem == null) ? null : (CVendor)cboxVendor.SelectedItem);
                    m_objCurrentLot.Currency = ((cboxCurrency.SelectedItem == null) ? null : (CCurrency)cboxCurrency.SelectedItem);
                    m_objCurrentLot.Stock = ((cboxStockLot.SelectedItem == null) ? null : (CStock)cboxStockLot.SelectedItem);
                    m_objCurrentLot.CurrentLotState = ((cboxLotState.SelectedItem == null) ? null : (CLotState)cboxLotState.SelectedItem);
                    m_objCurrentLot.Description = Lot_Description;
                    m_objCurrentLot.IsActive = Lot_IsActive;
                    m_objCurrentLot.AllPrice = Lot_AllPrice;
                    m_objCurrentLot.AllCostPrice = Lot_CurrencyAllPrice;
                    m_objCurrentLot.AllCostPriceReturn = Lot_RetCurrencyAllPrice;
                    m_objCurrentLot.StoreWaybillDate = StoreWaybill_DocDate;
                    m_objCurrentLot.StoreWaybillDocNumber = StoreWaybill_DocNum;
                    m_objCurrentLot.ParentKLP = m_objParentKLP;
                    m_objCurrentLot.Quantity = dblSumQuantity;
                    m_objCurrentLot.AllCostPrice = dblSumCostPrice;
                    m_objCurrentLot.AllPrice = dblSumPrice;
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
                    System.Guid Lot_Guid = ((m_bNewObject == true) ? System.Guid.Empty : SelectedLot.ID);
                    System.Guid LotState_Guid = ((cboxLotState.SelectedItem == null) ? (System.Guid.Empty) : ((CLotState)cboxLotState.SelectedItem).ID);
                    System.Int32 Lot_Id = SelectedLot.Ib_ID;

                    // теперь вносим изменения в состояние прихода
                    if (CLotRepository.ChangeLotState(m_objProfile, null, Lot_Guid, LotState_Guid, ref strErr, ref Lot_Id))
                    {
                        SelectedLot.CurrentLotState = ((cboxLotState.SelectedItem == null) ? null : (CLotState)cboxLotState.SelectedItem);
                        SelectedLot.Ib_ID = Lot_Id;
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
                        DevExpress.XtraEditors.XtraMessageBox.Show("Изменения в приходе сохранены за исключением состояния заказа.\n" + strErr, "Внимание",
                             System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    }

                    if (m_bNewObject == true)
                    {
                        if (m_objCurrentLot != null)
                        {
                            m_objLotList.Add(m_objCurrentLot);
                        }
                    }

                    if (m_enOpenLotEditorMode == OpenLotEditorMode.FromLotLis)
                    {
                        if (gridControlLotList.DataSource == null)
                        {
                            gridControlLotList.DataSource = m_objLotList;
                        }
                        gridControlLotList.RefreshDataSource();
                    }

                    SimulateCloseLotEditor(m_enOpenLotEditorMode, m_objCurrentLot, m_bNewObject); 
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
        public void ShowPageLotList()
        {
            tabControl.SelectedTabPage = tabPageViewer;
            this.Refresh();

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

                if (newFile.Exists)
                {
                    newFile.Delete();  // ensures we create a new workbook
                    newFile = new System.IO.FileInfo(strFileName);
                }
                
                System.Int32 iStartRow = 10;
                System.Int32 iCurrentRow = iStartRow;

                using (ExcelPackage package = new ExcelPackage(newFile))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Приход");
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
                
                Random rnd = new Random(DateTime.Now.Millisecond);

                strFileName = String.Format("{0}{1}", strDLLPath, m_strReportLot);

                System.String strTmpPath = System.IO.Path.GetTempPath();
                System.String strFileNameCopy = (String.Format("{0}{1}_Приход на склад.xlsx", strTmpPath, rnd.Next(100)));

                //System.IO.File.Copy(strFileName, strFileNameCopy, true);

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

        #region Выход из журнала приходов
        private void barBtnreturnToKLP_Click(object sender, EventArgs e)
        {
            // сообщает всем, кто подписался на событие "CloseLotListEventArgs", что оно наступило
            SimulateCloseLotList(m_enLotListMode);
        }
        #endregion

        #region Обработка событий грида с приложением к приходу
        private void gridView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                DataRow row = gridView.GetDataRow(e.RowHandle);

                //row["OrderItemsID"] = System.Guid.NewGuid();
                row["LotItems_Quantity"] = 1;
                row["KLPItems_Quantity"] = 0;
                row["Lot_Quantity"] = 0;
                row["LotItems_CurrencyPrice"] = 0;
                row["LotItems_Price"] = 0;
                row["DiscountPercent"] = spinEditDiscount.Value;
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
        private void gridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (m_bDisableEvents == true) { return; }

                SetPropertiesModified(true);
            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("gridView_CellValueChanging. Текст ошибки: " + f.Message);
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

                if ((e.Column == colProductID) && (e.Value != null))
                {

                    try
                    {
                        if (m_objParentKLP == null)
                        {
                            // приход на склад формируется без привязки к КЛП
                            if (m_objPartsList != null)
                            {
                                ERP_Mercury.Common.CProduct objItem = m_objPartsList.Cast<CProduct>().SingleOrDefault<CProduct>(x => x.ID.CompareTo((System.Guid)e.Value) == 0);

                                if (objItem != null)
                                {
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
                                }
                            }
                        }
                        else
                        {
                            // у прихода есть ссылка на КЛП
                            if ((m_objCurrentLot != null) && (m_objCurrentLot.LotItemList != null))
                            {
                                CLotItem objItem = m_objCurrentLot.LotItemList.Cast<CLotItem>().SingleOrDefault<CLotItem>(x => x.Product.ID.CompareTo((System.Guid)e.Value) == 0);

                                if (objItem != null)
                                {
                                    gridView.SetRowCellValue(e.RowHandle, colOrderItemsID, objItem.ID);
                                    gridView.SetRowCellValue(e.RowHandle, colMeasureID, objItem.Product.Measure.ID);
                                    gridView.SetRowCellValue(e.RowHandle, colLotItems_MeasureName, objItem.Product.Measure.ShortName);
                                    gridView.SetRowCellValue(e.RowHandle, colCurrencyPrice, objItem.CostPrice);
                                    gridView.SetRowCellValue(e.RowHandle, colPrice, objItem.CostPrice * m_objCurrentLot.RateCurrencyToCurrencyMain);
                                    gridView.SetRowCellValue(e.RowHandle, colDiscountPercent, spinEditDiscount.Value);


                                    gridView.SetRowCellValue(e.RowHandle, colKLPItemsQuantity, 0);
                                    gridView.SetRowCellValue(e.RowHandle, colLotQuantity, 0);
                                    gridView.SetRowCellValue(e.RowHandle, colQuantity, objItem.Quantity);

                                    gridView.SetRowCellValue(e.RowHandle, colLotItems_PartsArticle, objItem.Product.Article);
                                    gridView.SetRowCellValue(e.RowHandle, colLotItems_PartsName, objItem.Product.Name);

                                    // страна производства
                                    if (objItem.CountryProduction != null)
                                    {
                                        gridView.SetRowCellValue(e.RowHandle, colCountryID, objItem.CountryProduction.ID);
                                        gridView.SetRowCellValue(e.RowHandle, colLotItems_CountryProductionName, objItem.CountryProduction.Name);
                                    }
                                }
                            
                            }

                        }


                        //SetPriceInRow(e.RowHandle, System.Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colDiscountPercent)));

                        gridView.UpdateCurrentRow();
                    }
                    catch
                    {
                    }
                    finally
                    {
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
                    SetPriceInRow(e.RowHandle, System.Convert.ToDouble(e.Value), m_objCurrentLot.RateCurrencyToCurrencyMain);
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
                    if (dblKLPItemsQuantity > dblQuantity)
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
                if ((gridView.GetDataRow(e.RowHandle)["LotItems_Quantity"] == System.DBNull.Value) ||
                    (System.Convert.ToDouble(gridView.GetDataRow(e.RowHandle)["LotItems_Quantity"]) < 1))
                {
                    bOK = false;
                    gridView.SetColumnError(colQuantity, "недопустимое количество", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                }
                if (gridView.GetDataRow(e.RowHandle)["ProductID"] == System.DBNull.Value)
                {
                    bOK = false;
                    gridView.SetColumnError(colProductID, "укажите, пожалуйста, товар", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                }
                if (gridView.GetDataRow(e.RowHandle)["MeasureID"] == System.DBNull.Value)
                {
                    bOK = false;
                    gridView.SetColumnError( colLotItems_MeasureName, "укажите, пожалуйста, единицу измерения", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                }
                if (gridView.GetDataRow(e.RowHandle)["CountryProductionID"] == System.DBNull.Value)
                {
                    bOK = false;
                    gridView.SetColumnError( colLotItems_CountryProductionName, "укажите, пожалуйста, страну производства", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
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
                    if ((gridView.GetDataRow(iRowHandle)["LotItems_Quantity"] == System.DBNull.Value) ||
                        (System.Convert.ToDouble(gridView.GetDataRow(iRowHandle)["LotItems_Quantity"]) < 1))
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

        #endregion

        #region Импорт данных в приложение к приходу
        private void contextMenuStripEditor_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                mitemDeleteAllrecords.Enabled = ((m_bIsReadOnly == false) && (gridView.RowCount > 0));
                mitemImport.Enabled = (m_bIsReadOnly == false);
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
        /// <summary>
        /// импорт данных в приложение к приходу из файла MS Excel
        /// </summary>
        public void ImportFromExcel()
        {
            try
            {
                frmImportXLSData objFrmImportXLSData = new frmImportXLSData(m_objProfile, m_objMenuItem);

                // два варианта импорта:
                // 1. приход привязан к конкретному КЛП
                // 2. приход сформирован НЕ из КЛП
                
                // в первом случае необходимо сформировать набор данных, в котором будет производиться поиск импортируемых товаров
                // во втором случае в модуль импорта передаётся список всех товаров

                List<CKLPItems> objKLPItemList = null;
                List<CProduct> objProductList = null;

                if( m_objParentKLP != null )
                {
                    // 1. приход привязан к конкретному КЛП
                    // список возможных записей находится в m_objCurrentLot.LotItemList
                    // необходимо сформировать список объектов класса CKLPItems
                    
                    objKLPItemList = new List<CKLPItems>();
                    if( m_objCurrentLot.LotItemList != null )
                    {
                        foreach( CLotItem objLotItem in m_objCurrentLot.LotItemList )
                        {
                            objKLPItemList.Add( new CKLPItems() 
                            { 
                                ID = objLotItem.KLPItems_ID, 
                                QuantityFact = objLotItem.Quantity, 
                                PriceForCalcCostPrice = objLotItem.CostPrice, 
                                Product = objLotItem.Product, 
                                CountryProduction = objLotItem.CountryProduction,
                                Measure = objLotItem.Measure
                            } );
                        }
                    }
                }
                else
                {
                    // 2. приход сформирован НЕ из КЛП
                    objProductList = m_objPartsList;
                }

                objFrmImportXLSData.OpenForImportPartsInLot(enumImportMode.ByPartsIdForLot, objKLPItemList, 
                    objProductList, dataSet.Tables["OrderItems"], m_objCurrentLot.RateCurrencyToCurrencyMain,  m_strXLSImportFilePath,
                    m_iXLSSheetImport, m_SheetList );

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

        private void mitemImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_bIsReadOnly == true) { return; }

                ImportFromExcel();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("mitemImport_Click. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }
        /// <summary>
        /// Удаление всех записей в приложении к приходу
        /// </summary>
        private void DeleteAllrecords()
        {
            try
            {
                dataSet.Tables["OrderItems"].Clear();
                gridControl.RefreshDataSource();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("DeleteAllrecords. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }
        private void mitemDeleteAllrecords_Click(object sender, EventArgs e)
        {
            try
            {
                if( m_bIsReadOnly == true) { return; }

                DeleteAllrecords();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("mitemDeleteAllrecords_Click. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        #endregion

    }

    /// <summary>
    /// Тип, хранящий информацию, которая передается получателям уведомления о событии
    /// </summary>
    public class ChangeLotPropertieEventArgs : EventArgs
    {
        private readonly CLot m_objLot;
        public CLot Lot
        { get { return m_objLot; } }

        private readonly ERP_Mercury.Common.enumActionSaveCancel m_enActionType;
        public ERP_Mercury.Common.enumActionSaveCancel ActionType
        { get { return m_enActionType; } }

        private readonly System.Boolean m_bIsNewLot;
        public System.Boolean IsNewLot
        { get { return m_bIsNewLot; } }

        public ChangeLotPropertieEventArgs(CLot objLot, ERP_Mercury.Common.enumActionSaveCancel enActionType, System.Boolean bIsNewLot)
        {
            m_objLot = objLot;
            m_enActionType = enActionType;
            m_bIsNewLot = bIsNewLot;
        }
    }

    /// <summary>
    /// Тип, хранящий информацию, которая передается получателям уведомления о событии
    /// </summary>
    public class CloseLotListEventArgs : EventArgs
    {
        private readonly LotListMode m_enLotListMode;
        public LotListMode enLotListMode
        { get { return m_enLotListMode; } }

        public CloseLotListEventArgs(LotListMode enumeratorLotListMode)
        {
            m_enLotListMode = enumeratorLotListMode;
        }
    }

    /// <summary>
    /// Тип, хранящий информацию, которая передается получателям уведомления о событии
    /// </summary>
    public class CloseLotEditorEventArgs : EventArgs
    {
        private readonly OpenLotEditorMode m_enOpenLotEditorMode;
        public OpenLotEditorMode enOpenLotEditorMode
        { get { return m_enOpenLotEditorMode; } }

        private readonly CLot m_objLot;
        public CLot Lot
        { get { return m_objLot; } }

        private readonly System.Boolean m_bNewObject;
        public System.Boolean NewObject
        { get { return m_bNewObject; } }

        public CloseLotEditorEventArgs(OpenLotEditorMode enumeratorOpenLotEditorMode, CLot objLot, System.Boolean bNewObject)
        {
            m_enOpenLotEditorMode = enumeratorOpenLotEditorMode;
            m_objLot = objLot;
            m_bNewObject = bNewObject;
        }
    }
}