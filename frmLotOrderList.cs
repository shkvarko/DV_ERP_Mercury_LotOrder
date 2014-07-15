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
using Excel = Microsoft.Office.Interop.Excel;


namespace ERPMercuryLotOrder
{
    public partial class frmLotOrderList : DevExpress.XtraEditors.XtraForm
    {
        #region Свойства
        private UniXP.Common.CProfile m_objProfile;
        private UniXP.Common.MENUITEM m_objMenuItem;
        private System.Boolean m_bOnlyView;
        private List<ERP_Mercury.Common.CVendor> m_objVendorList;
        private List<CLotOrder> m_objOrderList;
        private CLotOrder m_objSelectedOrder;
        private ctrlLotOrder frmOrderEditor;
        private ctrlKLP frmKLPEditor;
        private DevExpress.XtraGrid.Views.Base.ColumnView ColumnView
        {
            get { return gridControlLotOrderList.MainView as DevExpress.XtraGrid.Views.Base.ColumnView; }
        }
        // потоки
        private System.Threading.Thread thrStockOrderTypeParts;
        public System.Threading.Thread ThreadStockOrderTypeParts
        {
            get { return thrStockOrderTypeParts; }
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
        public delegate void LoadVendorListDelegate(List<ERP_Mercury.Common.CVendor> objVendorList, System.Int32 iRowCountInLis);
        public LoadVendorListDelegate m_LoadVendorListDelegate;
        private const System.Int32 iThreadSleepTime = 1000;
        private const System.String strWaitVendor = "ждите... идет заполнение списка";
        private System.Boolean m_bThreadFinishJob;
        #endregion

        #region Конструктор
        public frmLotOrderList(UniXP.Common.MENUITEM objMenuItem)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);

            InitializeComponent();

            m_objMenuItem = objMenuItem;
            m_objProfile = objMenuItem.objProfile;
            m_objOrderList = null;
            m_objSelectedOrder = null;
            frmKLPEditor = null;
            m_bThreadFinishJob = false;
            m_objVendorList = new List<ERP_Mercury.Common.CVendor>();

            AddGridColumns();

            dtBeginDate.DateTime = new DateTime(System.DateTime.Today.Year, System.DateTime.Today.Month, 1);
            dtEndDate.DateTime = System.DateTime.Today; //new DateTime(System.DateTime.Today.Year, 12, 31);

            RestoreLayoutFromRegistry();

            LoadComboBox();

            LoadOrderList();

            tabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            m_bOnlyView = false;

            StartThreadWithLoadData();
        }

        private void OnChangeOrderPropertie(Object sender, ChangeLotOrderPropertieEventArgs e)
        {
            try
            {
                switch (e.ActionType)
                {
                    case ERP_Mercury.Common.enumActionSaveCancel.Cancel:
                        {
                            CancelChangesInOrder();
                            break;
                        }
                    case ERP_Mercury.Common.enumActionSaveCancel.Save:
                        {
                            if (e.IsNewOrder == true)
                            {
                                m_objSelectedOrder = null;
                                LoadOrderList();
                            }
                            else
                            {
                                SaveChangesInOrder();
                            }
                            break;
                        }
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("OnChangeOrderPropertie. Текст ошибки: " + f.Message);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }

        private void OnCloseKLPList(Object sender, CloseKLPListEventArgs e)
        {
            try
            {
                tabControl.SelectedTabPage = tabPageViewer;
                this.Refresh();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("OnCloseKLPList. Текст ошибки: " + f.Message);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
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

        #region Потоки
        public void StartThreadWithLoadData()
        {
            try
            {
                // инициализируем события
                this.m_EventStopThread = new System.Threading.ManualResetEvent(false);
                this.m_EventThreadStopped = new System.Threading.ManualResetEvent(false);

                // инициализируем делегаты
                m_LoadVendorListDelegate = new LoadVendorListDelegate(LoadVendorList);

                m_objVendorList.Clear();

                barBtnAdd.Enabled = false;
                barBtnEdit.Enabled = false;
                barBtnDelete.Enabled = false;
                barBtnCopy.Enabled = false;
                barbtnImportProduct.Enabled = false;

                gridControlLotOrderList.MouseDoubleClick -= new MouseEventHandler(gridControlAgreementGrid_MouseDoubleClick);

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

                this.thrStockOrderTypeParts = new System.Threading.Thread(WorkerThreadFunction);
                this.thrStockOrderTypeParts.Start();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("StartThreadWithLoadData().\n\nТекст ошибки: " + f.Message, "Ошибка",
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
                LoadVendorListInThread();

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

                //cboxCustomer.SelectedText = "";
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

        public void LoadVendorListInThread()
        {
            try
            {
                List<ERP_Mercury.Common.CVendor> objVendorList = ERP_Mercury.Common.CVendor.GetVendorList(m_objProfile, null);


                List<ERP_Mercury.Common.CVendor> objAddVendorList = new List<ERP_Mercury.Common.CVendor>();
                if ((objVendorList != null) && (objVendorList.Count > 0))
                {
                    System.Int32 iRecCount = 0;
                    System.Int32 iRecAllCount = 0;
                    foreach (ERP_Mercury.Common.CVendor objVendor in objVendorList)
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
                this.m_bThreadFinishJob = true;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("LoadCustomerListInThread.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        private void LoadVendorList(List<ERP_Mercury.Common.CVendor> objVendorList, System.Int32 iRowCountInList)
        {
            try
            {
                cboxVendor.Text = strWaitVendor;
                if ((objVendorList != null) && (objVendorList.Count > 0) && (cboxVendor.Properties.Items.Count < iRowCountInList))
                {
                    cboxVendor.Properties.Items.AddRange(objVendorList);
                    m_objVendorList.AddRange(objVendorList);
                }
                else
                {
                    cboxVendor.Text = "";
                    barBtnAdd.Enabled = !m_bOnlyView;
                    barBtnEdit.Enabled = (gridViewLotOrderList.FocusedRowHandle >= 0);
                    barBtnCopy.Enabled = (gridViewLotOrderList.FocusedRowHandle >= 0);
                    barBtnDelete.Enabled = ((!m_bOnlyView) && (gridViewLotOrderList.FocusedRowHandle >= 0));
                    //barbtnImportProduct.Enabled = true;
                    gridControlLotOrderList.MouseDoubleClick += new MouseEventHandler(gridControlAgreementGrid_MouseDoubleClick);
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("LoadCustomerList.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        private System.Boolean bIsThreadsActive()
        {
            System.Boolean bRet = false;
            try
            {
                if (frmOrderEditor == null) { return bRet; }
                bRet = ((frmOrderEditor.ThreadAddress != null) && (frmOrderEditor.ThreadAddress.IsAlive == true));
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
                System.Boolean bNeedDoEvents = false;
                while (bIsThreadsActive() == true)
                {
                    bNeedDoEvents = false;

                    if (System.Threading.WaitHandle.WaitAll((new System.Threading.ManualResetEvent[] { frmOrderEditor.EventThreadStopped }), 100, true))
                    {
                        bNeedDoEvents = true;
                        break;
                    }

                    if (bNeedDoEvents == true)
                    {
                        Application.DoEvents();
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("CloseThreadInAddressEditor.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void frmOrderList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (bIsThreadsActive() == true)
                {
                    // присутствуют рабочие потоки
                    CloseThreadInAddressEditor();
                    e.Cancel = false;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка закрытия формы.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                    "SendMessageToLog.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region Отмена изменений в редакторе заказа
        private void CancelChangesInOrder()
        {
            try
            {
                ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
                this.SuspendLayout();

                tabControl.SelectedTabPage = tabPageViewer;
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Отмена изменений. Текст ошибки: " + f.Message);
            }
            finally // очищаем занимаемые ресурсы
            {
                ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
                this.ResumeLayout(false);
            }

            return;
        }
        #endregion

        #region Изменения в редакторе заказа подтверждены
        private void SaveChangesInOrder()
        {
            try
            {
                ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
                this.SuspendLayout();

                tabControl.SelectedTabPage = tabPageViewer;
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Подтверждение изменений. Текст ошибки: " + f.Message);
            }
            finally // очищаем занимаемые ресурсы
            {
                ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
                this.ResumeLayout(false);
            }

            return;
        }
        #endregion

        #region Журнал КЛП
        /// <summary>
        /// Загружает список КЛП выбранного заказа
        /// </summary>
        /// <param name="objOrder">заказ</param>
        private void LoadKLPList(CLotOrder objOrder)
        {
            if (objOrder == null) { return; }
            try
            {
                ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
                this.SuspendLayout();

                if (frmKLPEditor == null)
                {
                    frmKLPEditor = new ctrlKLP( m_objMenuItem );
                    tableLayoutPanelKLP.Controls.Add(frmKLPEditor, 0, 0);
                    frmKLPEditor.Dock = DockStyle.Fill;
                    frmKLPEditor.CloseKLPList += OnCloseKLPList;
                }

                frmKLPEditor.LoadKLPList(objOrder);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка загрузки журнала КДП. Текст ошибки: " + f.Message);
            }
            finally
            {
                ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
                this.ResumeLayout(false);
                tabControl.SelectedTabPage = tabPageKLP;
            }
            return;
        }
        #endregion

        #region Редактировать заказ
        /// <summary>
        /// Загружает свойства заказа для редактирования
        /// </summary>
        /// <param name="objOrder">заказ</param>
        private void EditOrder(CLotOrder objOrder)
        {
            if (objOrder == null) { return; }
            try
            {
                m_objSelectedOrder = objOrder;

                System.Int32 iRes = 0;
                System.String strErr = "";
                
                m_objSelectedOrder.LotOrderItemsList = CLotOrderRepository.GetLotOrderItemsList(m_objProfile, null, m_objSelectedOrder.ID, 
                    ref iRes, ref strErr);

                if (iRes != 0)
                {
                    SendMessageToLog("Ошибка редактирования заказа. Текст ошибки: " + strErr);
                }
                else
                {
                    try
                    {
                        ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
                        this.SuspendLayout();

                        if (frmOrderEditor == null)
                        {
                            frmOrderEditor = new ctrlLotOrder(m_objProfile, m_objMenuItem, m_objVendorList);
                            tableLayoutPanelAgreementEditor.Controls.Add(frmOrderEditor, 0, 0);
                            frmOrderEditor.Dock = DockStyle.Fill;
                            frmOrderEditor.ChangeLotOrderProperties += OnChangeOrderPropertie;
                        }

                        frmOrderEditor.EditOrder(objOrder, false);
                    }
                    catch (System.Exception f)
                    {
                        SendMessageToLog("Ошибка редактирования заказа. Текст ошибки: " + f.Message);
                    }
                    finally
                    {
                        ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
                        this.ResumeLayout(false);
                        tabControl.SelectedTabPage = tabPageEditor;
                    }

                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка редактирования заказа. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }
        private void barBtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                EditOrder(GetSelectedOrder());

            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка редактирования заказа. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return;
        }

        private void gridControlAgreementGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                EditOrder(GetSelectedOrder());

            }//try
            catch (System.Exception f)
            {
                SendMessageToLog(f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return;
        }
        /// <summary>
        /// Возвращает ссылку на выбранный в списке заказ
        /// </summary>
        /// <returns>ссылка на заказ</returns>
        private CLotOrder GetSelectedOrder()
        {
            CLotOrder objRet = null;
            try
            {
                if ((((DevExpress.XtraGrid.Views.Grid.GridView)gridControlLotOrderList.MainView).RowCount > 0) &&
                    (((DevExpress.XtraGrid.Views.Grid.GridView)gridControlLotOrderList.MainView).FocusedRowHandle >= 0))
                {
                    System.Guid uuidID = (System.Guid)(((DevExpress.XtraGrid.Views.Grid.GridView)gridControlLotOrderList.MainView)).GetFocusedRowCellValue("ID");

                    objRet = m_objOrderList.Single<CLotOrder>(x => x.ID.CompareTo(uuidID) == 0);
                }
            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка поиска выбранного заказа. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return objRet;
        }

        #endregion

        #region Копировать заказ
        /// <summary>
        /// Копирует свойства заказа в новый и открывает его для редактирования
        /// </summary>
        /// <param name="objOrder">заказ</param>
        private void CopyOrder(CLotOrder objOrder)
        {
            if (objOrder == null) { return; }
            try
            {
                m_objSelectedOrder = objOrder;

                ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
                this.SuspendLayout();

                if (frmOrderEditor == null)
                {
                    frmOrderEditor = new ctrlLotOrder( m_objProfile, m_objMenuItem, m_objVendorList );
                    tableLayoutPanelAgreementEditor.Controls.Add(frmOrderEditor, 0, 0);
                    frmOrderEditor.Dock = DockStyle.Fill;
                    frmOrderEditor.ChangeLotOrderProperties += OnChangeOrderPropertie;
                }

                frmOrderEditor.CopyOrder(objOrder);

                tabControl.SelectedTabPage = tabPageEditor;

            }
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка копирования заказа. Текст ошибки: " + f.Message);
            }
            finally
            {
                ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
                this.ResumeLayout(false);
                tabControl.SelectedTabPage = tabPageEditor;
            }
            return;
        }

        private void barBtnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CopyOrder(GetSelectedOrder());

            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("Ошибка копирования заказа. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return;
        }

        #endregion

        #region Удалить заказ
        /// <summary>
        /// Удаляет заказ
        /// </summary>
        /// <param name="objOrder">заказ</param>
        private void DeleteOrder(CLotOrder objOrder)
        {
            if (objOrder == null) { return; }
            System.String strErr = "";

            try
            {
                System.Int32 iFocusedRowHandle = gridViewLotOrderList.FocusedRowHandle;
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Подтвердите, пожалуйста, удаление заказа.\n\n№" + objOrder.Number.ToString() +
                    "\nДата: " + objOrder.Date.ToShortDateString() + "\nПоставщик: " + objOrder.Vendor.Name, "Подтверждение",
                    System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == DialogResult.No) { return; }

                if (CLotOrderRepository.DeleteLotOrder(m_objProfile, null, objOrder.ID, ref strErr) == true)
                {
                    LoadOrderList();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(strErr, "Предупреждение",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

                    SendMessageToLog("Удаление заказа. Текст ошибки: " + strErr);
                }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Удаление заказа. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }
        private void barBtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteOrder(GetSelectedOrder());
            }//try
            catch (System.Exception f)
            {
                SendMessageToLog("Удаление заказа. Текст ошибки: " + f.Message);
            }
            finally
            {
            }

            return;
        }
        #endregion

        #region Новый заказ
        /// <summary>
        /// Открывает редактор заказа в режиме "Новый заказ"
        /// </summary>
        private void NewOrder()
        {
            try
            {
                ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
                this.SuspendLayout();

                if (frmOrderEditor == null)
                {
                    frmOrderEditor = new ctrlLotOrder( m_objProfile, m_objMenuItem, m_objVendorList);
                    tableLayoutPanelAgreementEditor.Controls.Add(frmOrderEditor, 0, 0);
                    frmOrderEditor.Dock = DockStyle.Fill;
                    frmOrderEditor.ChangeLotOrderProperties += OnChangeOrderPropertie;
                }

                ERP_Mercury.Common.CVendor objSelectedVendor = (((cboxVendor.SelectedItem == null) || (System.Convert.ToString(cboxVendor.SelectedItem) == "")) ? null : ((ERP_Mercury.Common.CVendor)cboxVendor.SelectedItem));

                frmOrderEditor.NewOrder(objSelectedVendor);

                tabControl.SelectedTabPage = tabPageEditor;

            }
            catch (System.Exception f)
            {
                SendMessageToLog("Создание заказа. Текст ошибки: " + f.Message);
            }
            finally
            {
                ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
                this.ResumeLayout(false);
                tabControl.SelectedTabPage = tabPageEditor;
            }
            return;
        }
        private void barBtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                NewOrder();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Создание заказа. Текст ошибки: " + f.Message);
            }
            finally
            {
            }
            return;
        }

        #endregion

        #region Импорт заказа
        private void btnImportProduct_Click(object sender, EventArgs e)
        {
            try
            {
                ImportDataFromExcel();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("btnImportProduct_Click. Текст ошибки: " + f.Message);
            }
            return;
        }
        /// <summary>
        /// Импорт данных из файла MS Excel
        /// </summary>
        private void ImportDataFromExcel()
        {
            try
            {
                NewOrder();
                //if (frmOrderEditor != null)
                //{ frmOrderEditor.ImportFromExcel(); }
            }
            catch (System.Exception f)
            {
                SendMessageToLog("ImportDataFromExcel. Текст ошибки: " + f.Message);
            }
            return;
        }

        #endregion

        #region Список заказов

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                menuHistoryLog.Enabled = (gridViewLotOrderList.FocusedRowHandle >= 0);
                CLotOrder objSelectedOrder = GetSelectedOrder();
                menuKLPList.Enabled = ((objSelectedOrder != null) && (objSelectedOrder.SrcIb_ID != 0));
                objSelectedOrder = null;
            }
            catch (System.Exception f)
            {
                SendMessageToLog(f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return;
        }

        private void LoadComboBox()
        {
            try
            {
                cboxVendor.Properties.Items.Clear();
                cboxVendor.Properties.Items.Add(new ERP_Mercury.Common.CCustomer());
            }
            catch (System.Exception f)
            {
                SendMessageToLog("LoadComboBox. Текст ошибки: " + f.Message);
            }
            return;
        }

        private void AddGridColumns()
        {
            ColumnView.Columns.Clear();
            AddGridColumn(ColumnView, "ID", "Идентификатор");
            AddGridColumn(ColumnView, "CurrentLotorderStateName", "Состояние");
            AddGridColumn(ColumnView, "Number", "Номер");
            AddGridColumn(ColumnView, "Date", "Дата заказа");
            AddGridColumn(ColumnView, "VendorName", "Поставщик");
            AddGridColumn(ColumnView, "QuantityInDoc", "Кол-во");            
            AddGridColumn(ColumnView, "CurrencyCode", "Валюта");
            AddGridColumn(ColumnView, "AllPriceEXW", "Сумма EXW");
            AddGridColumn(ColumnView, "AllPriceInvoice", "Сумма по инвойсу");
            AddGridColumn(ColumnView, "AllPriceForCalcCostPrice", "Сумма по цене для расчёта С/С");
            AddGridColumn(ColumnView, "LotOrderStateOrderNum", "№ состояния по порядку");

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
                if ((objColumn.FieldName == "ID") || (objColumn.FieldName == "LotOrderStateOrderNum"))
                {
                    objColumn.Visible = false;
                }
                if (objColumn.FieldName == "QuantityInDoc")
                {
                    objColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    objColumn.DisplayFormat.FormatString = "### ### ##0";
                    objColumn.SummaryItem.FieldName = objColumn.FieldName;
                    objColumn.SummaryItem.DisplayFormat = "Кол-во: {0:### ### ##0}";
                    objColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                }
                if ((objColumn.FieldName == "AllPriceEXW") || (objColumn.FieldName == "AllPriceInvoice") || (objColumn.FieldName == "AllPriceForCalcCostPrice"))
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
        /// Загружает список заказов
        /// </summary>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        public System.Boolean LoadOrderList()
        {
            System.Boolean bRet = false;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                //this.tableLayoutPanel2.SuspendLayout();
                //((System.ComponentModel.ISupportInitialize)(this.gridControlAgreementList)).BeginInit();
                System.Int32 iRowHandle = gridViewLotOrderList.FocusedRowHandle;

                gridControlLotOrderList.DataSource = null;
                System.Guid uuidVendorId = (((cboxVendor.SelectedItem == null) || (System.Convert.ToString(cboxVendor.SelectedItem) == "") || (cboxVendor.Text == strWaitVendor)) ? System.Guid.Empty : ((ERP_Mercury.Common.CVendor)cboxVendor.SelectedItem).ID);
                System.String strErr = "";
                m_objOrderList = CLotOrderRepository.GetLotOrderList( m_objProfile, null, dtBeginDate.DateTime, dtEndDate.DateTime, 
                    uuidVendorId, txtLotOrderNum.Text.Trim(), ref strErr );

                if (m_objOrderList != null)
                {
                    gridControlLotOrderList.DataSource = m_objOrderList;
                }

                if ((gridViewLotOrderList.RowCount > 0) && (iRowHandle >= 0) && (gridViewLotOrderList.RowCount > iRowHandle))
                {
                    gridViewLotOrderList.FocusedRowHandle = iRowHandle;
                }

                //this.tableLayoutPanel2.ResumeLayout(false);
                //((System.ComponentModel.ISupportInitialize)(this.gridControlAgreementList)).EndInit();

                bRet = true;
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Запрос списка заказов. Текст ошибки: " + f.Message);
                //
            }
            finally
            {
                this.Cursor = Cursors.Default;
                tabControl.SelectedTabPage = tabPageViewer;
                this.Refresh();
            }

            return bRet;
        }
        private void barBtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadOrderList();
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
        private void dtBeginDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) { LoadOrderList(); }
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

        #endregion

        #region Свойства заказа
        private void gridViewAgreementList_RowCountChanged(object sender, EventArgs e)
        {
            try
            {
                ShowOrderProperties(GetSelectedOrder());

                barBtnAdd.Enabled = !m_bOnlyView;
                barBtnEdit.Enabled = (gridViewLotOrderList.FocusedRowHandle >= 0);
                barBtnCopy.Enabled = (gridViewLotOrderList.FocusedRowHandle >= 0);
                barBtnDelete.Enabled = ((!m_bOnlyView) && (gridViewLotOrderList.FocusedRowHandle >= 0));
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Отображение свойств заказа. Текст ошибки: " + f.Message);
            }
            return;
        }
        private void gridViewAgreementList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                ShowOrderProperties(GetSelectedOrder());

                barBtnAdd.Enabled = !m_bOnlyView;
                barBtnEdit.Enabled = (e.FocusedRowHandle >= 0);
                barBtnCopy.Enabled = (e.FocusedRowHandle >= 0);
                barBtnDelete.Enabled = ((!m_bOnlyView) && (e.FocusedRowHandle >= 0));
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Отображение свойств заказа. Текст ошибки: " + f.Message);
            }
            return;
        }

        /// <summary>
        /// Отображает свойства заказа
        /// </summary>
        /// <param name="objOrder">заказ</param>
        private void ShowOrderProperties(CLotOrder objOrder)
        {
            try
            {
                this.tableLayoutPanelAgreementShortInfo.SuspendLayout();

                txtLotOrderName.Text = "";
                txtVendorName.Text = "";
                txtLotOrderDate.Text = "";
                txtLotOrderState.Text = "";
                calcQuantity.Value = 0;
                calcSumEXW.Value = 0;
                calcSumInvoice.Value = 0;
                calcSumPriceForCalcCostPrice.Value = 0;

                if (objOrder != null)
                {
                    txtLotOrderName.Text = objOrder.Number;
                    txtVendorName.Text = objOrder.VendorName;
                    txtLotOrderDate.Text = objOrder.Date.ToShortDateString();
                    txtLotOrderState.Text = objOrder.CurrentLotorderStateName;
                    calcQuantity.Value = System.Convert.ToDecimal(objOrder.QuantityInDoc);
                    calcSumEXW.Value = System.Convert.ToDecimal(objOrder.AllPriceEXW);
                    calcSumInvoice.Value = System.Convert.ToDecimal(objOrder.AllPriceInvoice);
                    calcSumPriceForCalcCostPrice.Value = System.Convert.ToDecimal(objOrder.AllPriceForCalcCostPrice);
                }

                this.tableLayoutPanelAgreementShortInfo.ResumeLayout(false);
            }
            catch (System.Exception f)
            {
                SendMessageToLog("Отображение свойств заказа. Текст ошибки: " + f.Message);
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
                gridViewLotOrderList.RestoreLayoutFromRegistry(strReestrPath + gridViewLotOrderList.Name);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка загрузки настроек списка заказов.\n\nТекст ошибки : " + f.Message, "Внимание",
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
                gridViewLotOrderList.SaveLayoutToRegistry(strReestrPath + gridViewLotOrderList.Name);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка записи настроек списка заказов.\n\nТекст ошибки : " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }
        #endregion

        #region Журнал событий
        /// <summary>
        /// Загружает журнал событий
        /// </summary>
        private void ShowEventLog()
        {
            try
            {
                if ((gridViewLotOrderList.RowCount == 0) || (gridViewLotOrderList.FocusedRowHandle < 0)) { return; }
                CLotOrder objOrder = GetSelectedOrder();

                if (objOrder != null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    UniXP.Common.frmEventLog objfrmEventLog = new UniXP.Common.frmEventLog(m_objProfile, objOrder.ID);
                    if (objfrmEventLog != null)
                    {
                        objfrmEventLog.ShowDialog();
                    }
                    objfrmEventLog.Dispose();
                    objfrmEventLog = null;
                }

            }
            catch (System.Exception f)
            {
                SendMessageToLog("ShowEventLog. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return;
        }

        private void menuEventLog_Click(object sender, EventArgs e)
        {
            try
            {
                ShowEventLog();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("ShowEventLog. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return;
        }

        #endregion

        #region Отрисовка ячеек
        private void gridViewAgreementList_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                System.Drawing.Image img = null;
                if (e.Column.FieldName == "OrderStateName")
                {
                    ERP_Mercury.Common.enPDASupplState SupplState = (ERP_Mercury.Common.enPDASupplState)gridViewLotOrderList.GetRowCellValue(e.RowHandle, gridViewLotOrderList.Columns["LotOrderStateOrderNum"]);
                    System.Int32 iImgIndx = -1;
                    switch (SupplState)
                    {
                        case ERP_Mercury.Common.enPDASupplState.CalcPricesOk:
                            {
                                iImgIndx = 0;

                                break;
                            }
                        case ERP_Mercury.Common.enPDASupplState.AutoCalcPricesOk:
                            {
                                iImgIndx = 0;
                                break;
                            }
                        case ERP_Mercury.Common.enPDASupplState.Print:
                            {
                                iImgIndx = 3;
                                break;
                            }
                        case ERP_Mercury.Common.enPDASupplState.Confirm:
                            {
                                iImgIndx = 4;
                                break;
                            }
                        case ERP_Mercury.Common.enPDASupplState.TTN:
                            {
                                iImgIndx = 5;
                                break;
                            }
                        case ERP_Mercury.Common.enPDASupplState.Shipped:
                            {
                                iImgIndx = 6;
                                break;
                            }
                        case ERP_Mercury.Common.enPDASupplState.CalcPricesFalse:
                            {
                                iImgIndx = 1;
                                break;
                            }
                        case ERP_Mercury.Common.enPDASupplState.CreateSupplInIBFalse:
                            {
                                iImgIndx = 1;
                                break;
                            }
                        case ERP_Mercury.Common.enPDASupplState.OutPartsOfStock:
                            {
                                iImgIndx = 1;
                                break;
                            }
                        case ERP_Mercury.Common.enPDASupplState.MakedForRecalcPrices:
                            {
                                iImgIndx = 7;
                                break;
                            }
                        case ERP_Mercury.Common.enPDASupplState.Deleted:
                            {
                                iImgIndx = 8;
                                break;
                            }
                        case ERP_Mercury.Common.enPDASupplState.CreditControl:
                            {
                                iImgIndx = 1;
                                break;
                            }
                        case ERP_Mercury.Common.enPDASupplState.FindStock:
                            {
                                iImgIndx = 2;
                                break;
                            }
                        case ERP_Mercury.Common.enPDASupplState.Created:
                            {
                                iImgIndx = 2;
                                break;
                            }
                        default:
                            {
                                iImgIndx = -1;
                                break;
                            }
                    }
                    img = imageCollection.Images[iImgIndx];
                }

                // собственно отрисовка
                if (img != null)
                {
                    Rectangle rImg = new Rectangle(e.Bounds.X + 3, e.Bounds.Y + (e.Bounds.Height - img.Size.Height) / 2, img.Width, img.Height);
                    e.Graphics.DrawImage(img, rImg);
                    Rectangle r = e.Bounds;

                    //r.Inflate(-1, -1);
                    //e.Graphics.FillRectangle(e.Appearance.brush, r);

                    r.Inflate(-( rImg.Width + 5 ), 0);
                    e.Appearance.DrawString(e.Cache, e.DisplayText, r);

                    e.Handled = true;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("gridViewUserList_CustomDrawCell\n" + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
#endregion

        #region Закрытие формы
        private void frmLotOrderList_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                SaveLayoutToRegistry();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("frmLotOrderList_FormClosed. Текст ошибки: " + f.Message);
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
            BaseExportLink link = gridViewLotOrderList.CreateExportLink(provider);
            (link as GridViewExportLink).ExpandAll = false;
            link.ExportTo(true);
            provider.Dispose();

            Cursor.Current = currentCursor;
        }
        //</sbExportToHTML>

        private string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = "список заказов поставщику"; // Application.ProductName;
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

        #region Журнал состояний
        /// <summary>
        /// Загружает журнал состояний
        /// </summary>
        private void ShowHistoryLog()
        {
            try
            {
                if ((gridViewLotOrderList.RowCount == 0) || (gridViewLotOrderList.FocusedRowHandle < 0)) { return; }
                CLotOrder objOrder = GetSelectedOrder();

                if (objOrder != null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    frmDocStateHistory objfrmDocStateHistory = new frmDocStateHistory();
                    if (objfrmDocStateHistory != null)
                    {
                        objfrmDocStateHistory.LoadLotOrderHistory(m_objProfile, objOrder.ID, "№ " + objOrder.Number + " от " + objOrder.Date.ToShortDateString(), 
                            objOrder.VendorName);
                    }
                    objfrmDocStateHistory.Dispose();
                    objfrmDocStateHistory = null;
                }

            }
            catch (System.Exception f)
            {
                SendMessageToLog("ShowHistoryLog. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return;
        }

        private void menuHistoryLog_Click(object sender, EventArgs e)
        {
            try
            {
                ShowHistoryLog();
            }
            catch (System.Exception f)
            {
                SendMessageToLog("ShowHistoryLog. Текст ошибки: " + f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return;
        }

        #endregion

        #region Журнал КЛП
        private void menuKLPList_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                LoadKLPList(GetSelectedOrder());

            }//try
            catch (System.Exception f)
            {
                SendMessageToLog(f.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return;
        }
        #endregion

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

    }

    public class LotOrderListEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmLotOrderList obj = new frmLotOrderList(objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }

    }
}
