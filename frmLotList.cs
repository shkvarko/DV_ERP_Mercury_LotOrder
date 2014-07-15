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
using ERP_Mercury.Common;

namespace ERPMercuryLotOrder
{
    public partial class frmLotList : DevExpress.XtraEditors.XtraForm
    {
        #region Свойства
        private UniXP.Common.CProfile m_objProfile;
        private UniXP.Common.MENUITEM m_objMenuItem;
        private ctrlLotList m_frmLotList;
        #endregion

        #region Конструктор
        public frmLotList(UniXP.Common.MENUITEM objMenuItem)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);

            InitializeComponent();

            m_objMenuItem = objMenuItem;
            m_objProfile = objMenuItem.objProfile;
            m_frmLotList = null;
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

        #region Журнал приходов
        private void OnCloseLotList(Object sender, CloseLotListEventArgs e)
        {
            try
            {
                m_frmLotList.ShowPageLotList();
                this.Refresh();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "OnCloseLotList.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                m_frmLotList.ShowPageLotList();
                this.Refresh();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "OnCloseLotEditor.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }

        /// <summary>
        /// Загрузка журнала приходов
        /// </summary>
        private void RefreshLotList()
        {
            try
            {
                if (m_frmLotList == null)
                {
                    m_frmLotList = new ctrlLotList(m_objMenuItem);
                    
                    tableLayoutPanelBackground.Controls.Add(m_frmLotList, 0, 0);
                    
                    m_frmLotList.Dock = DockStyle.Fill;
                    m_frmLotList.CloseLotList += OnCloseLotList;
                    m_frmLotList.CloseLotEditor += OnCloseLotEditor;
                }

                if (m_frmLotList != null)
                {
                    tableLayoutPanelBackground.Refresh();
                    m_frmLotList.LoadDataInComboBox(true, true);
                    m_frmLotList.LoadLotListFromUniXP();
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "LoadLotList.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return;
        }

        private void frmLotList_Load(object sender, EventArgs e)
        {
            RefreshLotList();
        }

        #endregion

        private void frmLotList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if ((m_frmLotList != null) && (m_frmLotList.ThreadAddress != null) && (m_frmLotList.ThreadAddress.IsAlive == true))
                {
                    // в редакторе прихода загружается справочник товаров в выпадающий список
                    m_frmLotList.CloseThreadInLotEditor();

                    while ((m_frmLotList.ThreadAddress != null) && (m_frmLotList.ThreadAddress.IsAlive == true))
                    {
                        if (System.Threading.WaitHandle.WaitAll(
                            (new System.Threading.ManualResetEvent[] { m_frmLotList.EventThreadStopped }),
                            100, true))
                        {
                            break;
                        }
                        Application.DoEvents();
                    }

                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "frmLotList_FormClosing.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;

        }


    }

    public class LotListEditor : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmLotList obj = new frmLotList(objMenuItem);
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }

    }


}
