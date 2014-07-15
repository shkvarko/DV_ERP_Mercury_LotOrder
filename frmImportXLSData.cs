using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_Mercury.Common;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;

namespace ERPMercuryLotOrder
{
    public partial class frmImportXLSData : DevExpress.XtraEditors.XtraForm
    {
        #region Свойства
        private UniXP.Common.CProfile m_objProfile;
        private UniXP.Common.MENUITEM m_objMenuItem;
        private enumImportMode m_enImportMode;
        private enumImportTarget m_enImportTarget;
        System.Double m_dblRateCurrencyToCurrencyMain;
        /// <summary>
        /// Список настроек
        /// </summary>
        private CSettingForImportData m_objSettingForImportData;
        private System.String m_strFileFullName;
        /// <summary>
        /// Имя файла
        /// </summary>
        public System.String FileFullName
        {
            get { return m_strFileFullName; }
        }
        public System.Int32 SelectedSheetId { get; set; }
        public List<System.String> SheetList;
        private List<CProduct> m_objPartsList;
        private System.Data.DataTable m_objdtOrderItems;
        private System.Double m_dblDiscountPercent;
        private System.Boolean m_bcheckMultiplicity;
        private List<CKLPItems> m_objKLPItemList;

        private const System.String strNodeSettingname = "ColumnItem";
        private const string strCaptionTextForImportInLotOrder = "Импорт данных в приложение к заказу";
        private const string strCaptionTextForImportInLot = "Импорт данных в приложение к приходу";
        #endregion

        #region Конструктор
        public frmImportXLSData(UniXP.Common.CProfile objProfile, UniXP.Common.MENUITEM objMenuItem ) 
        {
            InitializeComponent();

            m_objProfile = objProfile;
            m_objMenuItem = objMenuItem;
            m_strFileFullName = "";
            m_objSettingForImportData = null;
            btnLoadDataFromFile.Enabled = false;
            m_objdtOrderItems = null;
            m_dblDiscountPercent = 0;
            SelectedSheetId = 0;
            m_bcheckMultiplicity = false;
            SheetList = null;
            m_enImportMode = enumImportMode.Unkown;
            m_enImportTarget = enumImportTarget.Unkown;
            m_objPartsList = null;
            lblImportValuesList.Text = "";
            pictureBoxImportValueList.Image = null;
            m_objKLPItemList = null;
            lstboxImportValuesList.Items.Clear();
            tabControlTreeList.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            m_dblRateCurrencyToCurrencyMain = 0;
        }
        #endregion

        #region Открыть форму с настройками для импорта приложения в заказ
        /// <summary>
        /// Открывает форму в режиме импорта данных в приложение к заказу
        /// </summary>
        public void OpenForImportPartsInLotOrder( enumImportMode enImportMode, enumImportTarget enImportTarget,
            System.Double dblDiscountPercent, System.Data.DataTable objdtOrderItems, System.String strFileName,
            System.Int32 iSelectedSheetId, List<System.String> SheetList, System.Boolean bcheckMultiplicity, 
            List<CProduct> objPartsList
            )
        {
            try
            {
                m_dblDiscountPercent = dblDiscountPercent;
                m_objdtOrderItems = objdtOrderItems;
                m_bcheckMultiplicity = bcheckMultiplicity;
                m_enImportMode = enImportMode;
                m_enImportTarget = enImportTarget;
                m_objPartsList = objPartsList;

                SetInitialParams();

                txtID_Ib.Text = strFileName;
                cboxSheet.Properties.Items.Clear();
                if (SheetList != null)
                {
                    cboxSheet.Properties.Items.AddRange(SheetList);
                    cboxSheet.SelectedIndex = iSelectedSheetId;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "OpenForImportPartsInSuppl.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                ShowDialog();
            }

            return;

        }
        /// <summary>
        /// Открывает форму в режиме импорта данных в приложение к приходу
        /// </summary>
        public void OpenForImportPartsInLot( enumImportMode enImportMode, List<CKLPItems> objKLPItemList, List<CProduct> objProductList,
            System.Data.DataTable objdtLotItems, System.Double dblCurrencyRate, System.String strFileName,
            System.Int32 iSelectedSheetId, List<System.String> SheetList )
        {
            try
            {
                m_objdtOrderItems = objdtLotItems;
                m_enImportMode = enImportMode;
                m_enImportTarget = enumImportTarget.ImportDataToLot;
                m_objPartsList = objProductList;
                m_dblRateCurrencyToCurrencyMain = dblCurrencyRate;

                m_objKLPItemList = objKLPItemList;
                m_objPartsList = objProductList;

                SetInitialParams();

                txtID_Ib.Text = strFileName;
                cboxSheet.Properties.Items.Clear();
                if (SheetList != null)
                {
                    cboxSheet.Properties.Items.AddRange(SheetList);
                    cboxSheet.SelectedIndex = iSelectedSheetId;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "OpenForImportPartsInLot.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                ShowDialog();
            }

            return;

        }
        #endregion

        #region Первоначальные установки
        private void SetInitialParams()
        {
            try
            {
                txtID_Ib.Text = "";
                cboxSheet.Properties.Items.Clear();
                treeListSettings.Nodes.Clear();

                switch (m_enImportMode)
                {
                    case enumImportMode.ByPartsId:
                        m_objSettingForImportData = CSettingForImportData.GetSettingForImportDataInLotOrderByPartsId(m_objProfile, null);
                        tabControlTreeList.SelectedTabPage = tabPageImportOrder;
                        lstboxImportValuesList.Enabled = true;
                        Text = strCaptionTextForImportInLotOrder;
                        break;
                    case enumImportMode.ByPartsFullName:
                        m_objSettingForImportData = CSettingForImportData.GetSettingForImportDataInLotOrderByPartsFullName(m_objProfile, null);
                        lstboxImportValuesList.Enabled = true;
                        tabControlTreeList.SelectedTabPage = tabPageImportOrder;
                        Text = strCaptionTextForImportInLotOrder;
                        break;
                    case enumImportMode.ByPartsIdForLot:
                        m_objSettingForImportData = CSettingForImportData.GetSettingForImportDataInLotByPartsId(m_objProfile, null);
                        lstboxImportValuesList.Enabled = false;
                        tabControlTreeList.SelectedTabPage = tabPageImportLot;
                        Text = strCaptionTextForImportInLot;
                        break;
                    default:
                        m_objSettingForImportData = null;
                        break;
                }

                foreach (CSettingItemForImportData objSetting in m_objSettingForImportData.SettingsList)
                {
                    treeListSettings.AppendNode(new object[] { true, objSetting.TOOLS_USERNAME, System.String.Format("{0:### ### ##0}", objSetting.TOOLS_VALUE), objSetting.TOOLS_DESCRIPTION }, null).Tag = objSetting;
                }

                CheckSelectedAttrForUpdate();

            }//try
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "SetInitialParams.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return;
        }

        #endregion

        #region Выбор файла
        private void btnFileOpenDialog_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.Refresh();
                    if ((openFileDialog.FileName != "") && (System.IO.File.Exists(openFileDialog.FileName) == true))
                    {
                        txtID_Ib.Text = openFileDialog.FileName;
                        ReadSheetListFromXLSFile(txtID_Ib.Text);
                    }
                }
            }//try
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "btnFileOpenDialog_Click.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return;
        }
        /// <summary>
        /// Считывает коллекцию листов в файле MS Excel
        /// </summary>
        /// <param name="strFileName">имя файла MS Excel</param>
        private void ReadSheetListFromXLSFile( System.String strFileName )
        {
            if (strFileName == "") { return; }
            if (System.IO.File.Exists(strFileName) == false)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                     "файл \"" + strFileName + "\" не найден.", "Ошибка",
                     System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            Excel.Application oXL = null;
            Excel._Workbook oWB;

            System.Int32 iStartRow = 8;
            System.Int32 iCurrentRow = iStartRow;
            object m = Type.Missing;

            try
            {
                cboxSheet.Properties.Items.Clear();
                this.Cursor = Cursors.WaitCursor;
                oXL = new Excel.Application();
                oWB = (Excel._Workbook)(oXL.Workbooks.Open(strFileName, 0, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));

                foreach (Excel._Worksheet objSheet in oWB.Worksheets)
                {
                    cboxSheet.Properties.Items.Add(objSheet.Name);
                }

                oWB.Close(Missing.Value, Missing.Value, Missing.Value);
                oXL.Quit();

            }
            catch (System.Exception f)
            {
                oXL = null;
                oWB = null;
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка экспорта в MS Excel.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oWB = null;
                oXL = null;
                cboxSheet.SelectedItem = ((cboxSheet.Properties.Items.Count > 0) ? cboxSheet.Properties.Items[0] : null);
                btnLoadDataFromFile.Enabled = (cboxSheet.SelectedItem != null);

                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            return;
        }
        /// <summary>
        /// Возвращает значение параметра настройки по его наименованию
        /// </summary>
        /// <param name="strSettingName">имя параметра</param>
        /// <param name="bIsCheck">признак того, включена ли настройка</param>
        /// <returns>значение параметра настройки</returns>
        private System.Int32 GetSettingValueByName(System.String strSettingName, ref System.Boolean bIsCheck)
        {
            System.Int32 iRet = 0;
            try
            {
                CSettingItemForImportData objSetting = null;
                foreach( DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treeListSettings.Nodes )
                {
                    if (objNode.Tag == null) { continue; }
                    objSetting = (CSettingItemForImportData)objNode.Tag;
                    foreach (CSettingItemForImportData objItem in m_objSettingForImportData.SettingsList)
                    {
                        if (objSetting.TOOLS_NAME == strSettingName)
                        {
                            iRet = System.Convert.ToInt32(objNode.GetValue(colSettingsColumnNum));
                            bIsCheck = System.Convert.ToBoolean(objNode.GetValue(colCheck));
                            break;
                        }
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "GetSettingValueByName.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return iRet;
        }

        /// <summary>
        /// Считывает информацию из фала MS Excel
        /// </summary>
        /// <param name="strFileName">имя файла MS Excel</param>
        private void ReadDataFromXLSFile(System.String strFileName)
        {
            if (strFileName == "") { return; }
            if (System.IO.File.Exists(strFileName) == false)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                     "файл \"" + strFileName + "\" не найден.", "Ошибка",
                     System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            Excel.Application oXL = null;
            Excel._Workbook oWB;
            object m = Type.Missing;
            listEditLog.Items.Clear();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                treeListImportOrder.Nodes.Clear();

                System.Boolean bCheckPRICE_EXW = false;
                System.Boolean bCheckPRICE_INVOICE = false;
                System.Boolean bCheckPRICE_FORCALCCOSTPRICE = false;
                System.Boolean bCheckQUANTITY = false;
                System.Boolean bCheckQUANTITY_CONFIRM = false;
                System.Boolean bCheckQUANTITY_INDOC = false;

                System.Int32 iColumnPRICE_EXW = GetSettingValueByName(CSettingForImportData.strFieldNamePRICE_EXW, ref bCheckPRICE_EXW);
                System.Int32 iColumnPRICE_INVOICE = GetSettingValueByName(CSettingForImportData.strFieldNamePRICE_INVOICE, ref bCheckPRICE_INVOICE);
                System.Int32 iColumnPRICE_FORCALCCOSTPRICE = GetSettingValueByName(CSettingForImportData.strFieldNamePRICE_FORCALCCOSTPRICE, ref bCheckPRICE_FORCALCCOSTPRICE);

                System.Int32 iColumnQUANTITY = GetSettingValueByName(CSettingForImportData.strFieldNameQUANTITY, ref bCheckQUANTITY);
                System.Int32 iColumnQUANTITY_CONFIRM = GetSettingValueByName(CSettingForImportData.strFieldNameQUANTITY_COFIRM, ref bCheckQUANTITY_CONFIRM);
                System.Int32 iColumnQUANTITY_INDOC = GetSettingValueByName(CSettingForImportData.strFieldNameQUANTITY_INDOC, ref bCheckQUANTITY_INDOC);

                if ((bCheckPRICE_EXW == false) && (bCheckPRICE_INVOICE == false)
                    && (bCheckPRICE_FORCALCCOSTPRICE == false) && (bCheckQUANTITY == false) &&
                    (bCheckQUANTITY_CONFIRM == false) && (bCheckQUANTITY_INDOC == false ))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                         "Необходимо выбрать в настройках хотя бы один параметр для обновления.", "Внимание!",
                         System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return;
                }

                System.Boolean bCheck = false;
                System.Int32 iStartRow = GetSettingValueByName(CSettingForImportData.strFieldNameSTARTROW, ref bCheck);
                System.Int32 iColumnPartsFullName = GetSettingValueByName(CSettingForImportData.strFieldNameFULLNAME, ref bCheck);
                System.Int32 iColumnPartsId = GetSettingValueByName(CSettingForImportData.strFieldNamePARTS_ID, ref bCheck);
                System.Int32 iColumnARTICLE = GetSettingValueByName(CSettingForImportData.strFieldNameARTICLE, ref bCheck);
                System.Int32 iColumnNAME2 = GetSettingValueByName(CSettingForImportData.strFieldNameNAME2, ref bCheck);
                //System.Int32 iColumnQUANTITY = GetSettingValueByName(CSettingForImportData.strFieldNameQUANTITY, ref bCheck);
                System.Int32 iColumnMARKUP = GetSettingValueByName(CSettingForImportData.strFieldNameMARKUP, ref bCheck);
                System.Int32 iColumnCOUNTRY = GetSettingValueByName(CSettingForImportData.strFieldNameCOUNTRY, ref bCheck);
                System.Int32 iColumnTARIFF = GetSettingValueByName(CSettingForImportData.strFieldNameTARIFF, ref bCheck); 

                System.String strFULLNAME = "";
                System.String strPARTS_ID = "";
                System.String strQUANTITY = "";
                System.String strQUANTITY_CONFIRM = "";
                System.String strQUANTITY_INDOC = "";
                System.String strPRICE_EXW = "";
                System.String strPRICE_INVOICE = "";
                System.String strPRICE_FORCALCCOSTPRICE = "";
                System.String strMARKUP = "";
                System.String strFrstColumn = "";
                System.String strCOUNTRY = "";
                System.String strTARIFF = "";

                System.Int32 iCurrentRow = iStartRow;

                oXL = new Excel.Application();
                oWB = (Excel._Workbook)(oXL.Workbooks.Open(strFileName, 0, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                Excel._Worksheet objSheet = (Excel._Worksheet)oWB.Worksheets[(cboxSheet.SelectedIndex + 1)];

                System.Boolean bStopRead = false;


                    iCurrentRow = iStartRow;
                    bStopRead = false;
                    System.Boolean bErrExists = false;
                    System.Int32 i = 1;
                    System.Decimal iQuantity = 0;
                    System.Decimal iQuantityConfirm = 0;
                    System.Decimal iQuantityInDoc = 0;
                    System.Double dblPRICE_EXW = 0;
                    System.Double dblPRICE_INVOICE = 0;
                    System.Double dblPRICE_FORCALCCOSTPRICE = 0;
                    System.Double dblMARKUP = 0;
                    System.Double dblTARIFF = 0;
                    System.Int32 iCOUNTRY = 0;

                    //System.Decimal dclmultiplicity = 0;
                    CProduct objProduct = null;

                    while (bStopRead == false)
                    {
                        bErrExists = false;

                        // пробежим по строкам и считаем информацию
                        strFrstColumn = System.Convert.ToString(objSheet.get_Range(objSheet.Cells[iCurrentRow, 1], objSheet.Cells[iCurrentRow, 1]).Value2);
                        if (strFrstColumn == "")
                        {
                            bStopRead = true;
                        }
                        else
                        {
                            switch (m_enImportMode)
                            {
                                case enumImportMode.ByPartsId:
                                    strPARTS_ID = System.Convert.ToString(objSheet.get_Range(objSheet.Cells[iCurrentRow, iColumnPartsId], objSheet.Cells[iCurrentRow, iColumnPartsId]).Value2);
                                    break;
                                case enumImportMode.ByPartsFullName:
                                    strFULLNAME = System.Convert.ToString(objSheet.get_Range(objSheet.Cells[iCurrentRow, iColumnPartsFullName], objSheet.Cells[iCurrentRow, iColumnPartsFullName]).Value2);
                                    break;
                                default:
                                    break;
                            }
                            
                            //strQUANTITY = System.Convert.ToString(objSheet.get_Range(objSheet.Cells[iCurrentRow, iColumnQUANTITY], objSheet.Cells[iCurrentRow, iColumnQUANTITY]).Value2);
                            if (bCheckQUANTITY == true)
                            {
                                strQUANTITY = System.Convert.ToString(objSheet.get_Range(objSheet.Cells[iCurrentRow, iColumnQUANTITY], objSheet.Cells[iCurrentRow, iColumnQUANTITY]).Value2);
                            }
                            else { strQUANTITY = "0"; }

                            if (bCheckQUANTITY_CONFIRM == true)
                            {
                                strQUANTITY_CONFIRM = System.Convert.ToString(objSheet.get_Range(objSheet.Cells[iCurrentRow, iColumnQUANTITY_CONFIRM], objSheet.Cells[iCurrentRow, iColumnQUANTITY_CONFIRM]).Value2);
                            }
                            else { strQUANTITY_CONFIRM = "0"; }

                            if (bCheckQUANTITY_INDOC == true)
                            {
                                strQUANTITY_INDOC = System.Convert.ToString(objSheet.get_Range(objSheet.Cells[iCurrentRow, iColumnQUANTITY_INDOC], objSheet.Cells[iCurrentRow, iColumnQUANTITY_INDOC]).Value2);
                            }
                            else { strQUANTITY_INDOC = "0"; }

                            if (bCheckPRICE_EXW == true)
                            {
                                strPRICE_EXW = System.Convert.ToString(objSheet.get_Range(objSheet.Cells[iCurrentRow, iColumnPRICE_EXW], objSheet.Cells[iCurrentRow, iColumnPRICE_EXW]).Value2);
                            }
                            else { strPRICE_EXW = "0"; }
                            if (bCheckPRICE_INVOICE == true)
                            {
                                strPRICE_INVOICE = System.Convert.ToString(objSheet.get_Range(objSheet.Cells[iCurrentRow, iColumnPRICE_INVOICE], objSheet.Cells[iCurrentRow, iColumnPRICE_INVOICE]).Value2);
                            }
                            else { strPRICE_INVOICE = "0"; }
                            if (bCheckPRICE_FORCALCCOSTPRICE == true)
                            {
                                strPRICE_FORCALCCOSTPRICE = System.Convert.ToString(objSheet.get_Range(objSheet.Cells[iCurrentRow, iColumnPRICE_FORCALCCOSTPRICE], objSheet.Cells[iCurrentRow, iColumnPRICE_FORCALCCOSTPRICE]).Value2);
                            }
                            else { strPRICE_FORCALCCOSTPRICE = "0"; }
                            strMARKUP = "";
  //                          strMARKUP = System.Convert.ToString(objSheet.get_Range(objSheet.Cells[iCurrentRow, iColumnMARKUP], objSheet.Cells[iCurrentRow, iColumnMARKUP]).Value2);
                            strCOUNTRY = System.Convert.ToString(objSheet.get_Range(objSheet.Cells[iCurrentRow, iColumnCOUNTRY], objSheet.Cells[iCurrentRow, iColumnCOUNTRY]).Value2);
                            strTARIFF = System.Convert.ToString(objSheet.get_Range(objSheet.Cells[iCurrentRow, iColumnTARIFF], objSheet.Cells[iCurrentRow, iColumnTARIFF]).Value2);

                            iQuantity = 0;
                            iQuantityConfirm = 0;
                            iQuantityInDoc = 0;
                            dblPRICE_EXW = 0;
                            dblPRICE_INVOICE = 0;
                            dblPRICE_FORCALCCOSTPRICE = 0;
                            dblMARKUP = 0;
                            objProduct = null;
                            
                            // преобразуем строки в числа
                            //if( strQUANTITY == "" ) 
                            //{
                            //    listEditLog.Items.Add(String.Format("{0} не указано количество.", i));
                            //}
                            //else
                            //{
                                // количество
                                try
                                {
                                    iQuantity = System.Convert.ToDecimal(strQUANTITY);
                                }
                                catch
                                {
                                    bErrExists = true;
                                    listEditLog.Items.Add(String.Format("{0} ошибка преобразования количества товара в числовой формат.", i));
                                }
                            //}
                            // количество подтверждённое
                            try
                            {
                                iQuantityConfirm = System.Convert.ToDecimal(strQUANTITY_CONFIRM);
                            }
                            catch
                            {
                                bErrExists = true;
                                listEditLog.Items.Add(String.Format("{0} ошибка преобразования подтверждённого количества в числовой формат.", i));
                            }
                            // количество в документе
                            try
                            {
                                iQuantityInDoc = System.Convert.ToDecimal(strQUANTITY_INDOC);
                            }
                            catch
                            {
                                bErrExists = true;
                                listEditLog.Items.Add(String.Format("{0} ошибка преобразования количества в док-те в числовой формат.", i));
                            }
                            // цена exw
                            try
                            {
                                dblPRICE_EXW = System.Convert.ToDouble(strPRICE_EXW);
                            }
                            catch
                            {
                                bErrExists = true;
                                listEditLog.Items.Add(String.Format("{0} ошибка преобразования цены exw  в числовой формат.", i));
                            }
                            // цена по инвойсу
                            try
                            {
                                dblPRICE_INVOICE = System.Convert.ToDouble(strPRICE_INVOICE);
                            }
                            catch
                            {
                                bErrExists = true;
                                listEditLog.Items.Add(String.Format("{0} ошибка преобразования цены по инвойсу  в числовой формат.", i));
                            }
                            // цена для расчёта с/с
                            try
                            {
                                dblPRICE_FORCALCCOSTPRICE = System.Convert.ToDouble(strPRICE_FORCALCCOSTPRICE);
                            }
                            catch
                            {
                                bErrExists = true;
                                listEditLog.Items.Add(String.Format("{0} ошибка преобразования цены для расчёта с/с  в числовой формат.", i));
                            }
                            // скидка
                            try
                            {
                                if( strMARKUP == "" ) { dblMARKUP = 0;}
                                else {dblMARKUP = System.Convert.ToDouble( strMARKUP );}
                            }
                            catch
                            {
                                bErrExists = true;
                                listEditLog.Items.Add(String.Format("{0} ошибка преобразования скидки в числовой формат.", i));
                            }
                            // таможенный тариф
                            try
                            {
                                if (strTARIFF == "") { dblTARIFF = 0; }
                                else { dblTARIFF = System.Convert.ToDouble(strTARIFF); }
                            }
                            catch
                            {
                                bErrExists = true;
                                listEditLog.Items.Add(String.Format("{0} ошибка преобразования таможенного тарифа в числовой формат.", i));
                            }
                            // страна производства
                            try
                            {
                                if (strCOUNTRY == "") { iCOUNTRY = 0; }
                                else { iCOUNTRY = System.Convert.ToInt32(strCOUNTRY); }
                            }
                            catch
                            {
                                bErrExists = true;
                                listEditLog.Items.Add(String.Format("{0} ошибка преобразования кода страны в числовой формат.", i));
                            }

                        }

                        if ((bErrExists == false) && (bStopRead == false))
                        {
                            if (m_objPartsList != null)
                            {
                                try
                                {
                                    switch (m_enImportMode)
                                    {
                                        case enumImportMode.ByPartsId:
                                            objProduct = m_objPartsList.Single<ERP_Mercury.Common.CProduct>(x => x.ID_Ib == System.Convert.ToInt32(strPARTS_ID));
                                            break;
                                        case enumImportMode.ByPartsFullName:
                                            objProduct = m_objPartsList.Single<ERP_Mercury.Common.CProduct>(x => x.ProductFullName == strFULLNAME);
                                            break;
                                        default:
                                            break;
                                    }
                                    
                                }
                                catch
                                {
                                    objProduct = null;
                                }
                            }
                            //objProduct = COrderRepository.GetPartsInstock(m_objProfile, null, strNAME2, strARTICLE, m_objSelectedStock.ID);

                            if (objProduct == null)
                            {
                                bErrExists = true;
                                switch (m_enImportMode)
                                {
                                    case enumImportMode.ByPartsId:
                                        listEditLog.Items.Add( String.Format("{0} товар с указанным кодом не найден, код товара: {1}", System.Convert.ToString( i ), strPARTS_ID ) );
                                        break;
                                    case enumImportMode.ByPartsFullName:
                                        listEditLog.Items.Add( String.Format("{0} товар с указанным артикулом и наименованием не найден. товар: {1}", System.Convert.ToString(i), strFULLNAME ) );
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                treeListImportOrder.AppendNode(new object[] { objProduct.ID, objProduct.ID_Ib, objProduct.Article, objProduct.Name, 
                                    iQuantity, iQuantityConfirm, iQuantityInDoc, dblPRICE_EXW, dblPRICE_INVOICE, dblPRICE_FORCALCCOSTPRICE, dblTARIFF, iCOUNTRY  }, null).Tag = objProduct;

                                listEditLog.Items.Add(String.Format("{0} OK ", i));
                            }
                        }

                        iCurrentRow++;
                        i++;
                        strFrstColumn = System.Convert.ToString(objSheet.get_Range(objSheet.Cells[iCurrentRow, 1], objSheet.Cells[iCurrentRow, 1]).Value2);
                        listEditLog.Refresh();

                    } //while (bStopRead == false)

                objSheet = null;
                oWB.Close(false, Missing.Value, Missing.Value);
                oXL.Quit();
            }
            catch (System.Exception f)
            {
                oWB = null;
                oXL = null;
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка экспорта в MS Excel.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                oWB = null;
                oXL = null;
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            return;
        }


        /// <summary>
        /// Считывает информацию из фала MS Excel
        /// </summary>
        /// <param name="strFileName">имя файла MS Excel</param>
        private void ReadDataFromXLSFileForImportInLot(System.String strFileName)
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

                listEditLog.Items.Clear();
                treeListImportLot.Nodes.Clear();

                System.Boolean bCheck = false;

                System.Int32 iStartRow = GetSettingValueByName(CSettingForImportData.strFieldNameSTARTROW, ref bCheck);
                //System.Int32 iColumnPRICE = GetSettingValueByName(CSettingForImportData.strFieldNamePRICE, ref bCheck);
                System.Int32 iColumnQUANTITY = GetSettingValueByName(CSettingForImportData.strFieldNameQUANTITY, ref bCheck);
                System.Int32 iColumnPartsId = GetSettingValueByName(CSettingForImportData.strFieldNamePARTS_ID, ref bCheck);
                System.Int32 iColumnEXPDATE = GetSettingValueByName(CSettingForImportData.strFieldNameEXPDATE, ref bCheck);

                System.String strPARTS_ID = "";
                System.String strQUANTITY = "";
                //System.String strCURRENCYPRICE = "";
                System.String strEXPDATE = "";

                System.Int32 iPARTS_ID = 0;
                System.Decimal dblQUANTITY = 0;
                //System.Double dblCURRENCYPRICE = 0;
                System.DateTime dtEXPDATE = System.DateTime.MinValue;

                System.Int32 iCurrentRow = iStartRow;
                System.Int32 i = 1;

                using (ExcelPackage package = new ExcelPackage(newFile))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[cboxSheet.SelectedIndex + 1];
                    if (worksheet != null)
                    {

                        System.Boolean bStopRead = false;
                        System.Boolean bErrExists = false;
                        System.String strFrstColumn = "";
                        CKLPItems objKLPItem = null;

                        while (bStopRead == false)
                        {
                            bErrExists = false;

                            // пробежим по строкам и считаем информацию
                            strFrstColumn = System.Convert.ToString(worksheet.Cells[iCurrentRow, 1].Value);
                            if (strFrstColumn == "")
                            {
                                bStopRead = true;
                            }
                            else
                            {
                                strPARTS_ID = System.Convert.ToString(worksheet.Cells[iCurrentRow, iColumnPartsId].Value);
                                strQUANTITY = System.Convert.ToString(worksheet.Cells[iCurrentRow, iColumnQUANTITY].Value);
                                //strCURRENCYPRICE = System.Convert.ToString(worksheet.Cells[iCurrentRow, iColumnPRICE].Value);
                                strEXPDATE = System.Convert.ToString(worksheet.Cells[iCurrentRow, iColumnEXPDATE].Value);

                                iPARTS_ID = 0;
                                dblQUANTITY = 0;
                                //dblCURRENCYPRICE = 0;
                                dtEXPDATE = System.DateTime.MinValue;

                                // код товара
                                try
                                {
                                    iPARTS_ID = System.Convert.ToInt32(strPARTS_ID);
                                }
                                catch
                                {
                                    bErrExists = true;
                                    listEditLog.Items.Add(String.Format("{0} ошибка преобразования кода товара в числовой формат.", i));
                                }
                                // количество
                                try
                                {
                                    dblQUANTITY = System.Convert.ToDecimal(strQUANTITY);
                                }
                                catch
                                {
                                    bErrExists = true;
                                    listEditLog.Items.Add(String.Format("{0} ошибка преобразования количества товара в числовой формат.", i));
                                }
                                //// цена
                                //try
                                //{
                                //    if (strCURRENCYPRICE != "")
                                //    {
                                //        dblCURRENCYPRICE = System.Convert.ToDouble(strCURRENCYPRICE);
                                //    }
                                //}
                                //catch
                                //{
                                //    bErrExists = true;
                                //    listEditLog.Items.Add(String.Format("{0} ошибка преобразования цены в числовой формат.", i));
                                //}
                                // срок годности
                                try
                                {
                                    if (strEXPDATE != "")
                                    {
                                        dtEXPDATE = System.Convert.ToDateTime(strEXPDATE);
                                    }
                                }
                                catch
                                {
                                    bErrExists = true;
                                    listEditLog.Items.Add(String.Format("{0} ошибка преобразования срока годности в формат даты.", i));
                                }
                            }

                            if ((bErrExists == false) && (bStopRead == false))
                            {
                                try
                                {
                                    if (m_objKLPItemList != null)
                                    {
                                        objKLPItem = m_objKLPItemList.FirstOrDefault<CKLPItems>(x => x.Product.ID_Ib == iPARTS_ID);
                                        if (dtEXPDATE.CompareTo(System.DateTime.MinValue) != 0)
                                        {
                                            objKLPItem.ExpirationDate = dtEXPDATE;
                                        }
                                    }
                                    if ((objKLPItem == null) && (m_objPartsList != null))
                                    {
                                        objKLPItem = new CKLPItems()
                                        {
                                            Product = m_objPartsList.SingleOrDefault<ERP_Mercury.Common.CProduct>(x => x.ID_Ib == iPARTS_ID),
                                            ExpirationDate = dtEXPDATE
                                        };
                                        objKLPItem.Measure = objKLPItem.Product.Measure;
                                    }
                                }
                                catch
                                {
                                    objKLPItem = null;
                                }

                                if ((objKLPItem == null) || (objKLPItem.Product == null))
                                {
                                    bErrExists = true;
                                    listEditLog.Items.Add(String.Format("{0} товар с указанным кодом не найден, код товара: {1}", System.Convert.ToString(i), strPARTS_ID));
                                }
                                else
                                {
                                    treeListImportLot.AppendNode(new object[] { objKLPItem.ID, objKLPItem.Product.ID, objKLPItem.Product.ID_Ib, 
                                        objKLPItem.Product.Article, objKLPItem.Product.Name, 
                                    dblQUANTITY, objKLPItem.PriceForCalcCostPrice, ( objKLPItem.PriceForCalcCostPrice * m_dblRateCurrencyToCurrencyMain ),
                                    ((objKLPItem.ExpirationDate.CompareTo(System.DateTime.MinValue) != 0) ? objKLPItem.ExpirationDate : System.DateTime.MinValue ), 
                                    ((objKLPItem.CountryProduction == null ) ? "" : objKLPItem.CountryProduction.Name )  }, null).Tag = objKLPItem;

                                    listEditLog.Items.Add(String.Format("{0} OK ", i));
                                }
                            }

                            iCurrentRow++;
                            i++;
                            strFrstColumn = System.Convert.ToString(worksheet.Cells[iCurrentRow, 1].Value);
                            listEditLog.Refresh();

                        } //while (bStopRead == false)
                    }
                    worksheet = null;
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

        private void btnLoadDataFromFile_Click(object sender, EventArgs e)
        {
            try
            {
                switch (m_enImportMode)
                {
                    case enumImportMode.ByPartsFullName:
                        ReadDataFromXLSFile(txtID_Ib.Text);
                        break;
                    case enumImportMode.ByPartsId:
                        ReadDataFromXLSFile(txtID_Ib.Text);
                        break;
                    case enumImportMode.ByPartsIdForLot:
                        ReadDataFromXLSFileForImportInLot(txtID_Ib.Text);
                        break;
                    default:
                        break;
 
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "btnLoadDataFromFile_Click.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }

        private void cboxSheet_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnLoadDataFromFile.Enabled = (cboxSheet.SelectedItem != null);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "cboxSheet_SelectedValueChanged.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }

        #endregion

        #region Подтвердить выбор
        private void treeListSettings_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            try
            {
                if ((e.Node == null) || (e.Node.Tag == null)) { return; }

                if (e.Column == colCheck)
                {
                    System.String strSettingName = ((CSettingItemForImportData)e.Node.Tag).TOOLS_NAME;

                    if (((strSettingName == CSettingForImportData.strFieldNamePARTS_ID) ||
                        (strSettingName == CSettingForImportData.strFieldNameARTICLE) ||
                        (strSettingName == CSettingForImportData.strFieldNameNAME2) || (strSettingName == CSettingForImportData.strFieldNameSTARTROW) ||
                        (strSettingName == CSettingForImportData.strFieldNameFULLNAME)) && (System.Convert.ToBoolean(e.Value) == false))
                    {
                        e.Node.SetValue(colCheck, true);
                    }
                    else
                    {
                        CheckSelectedAttrForUpdate();
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "treeListSettings_CellValueChanged.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return;
        }
        private void treeListSettings_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
        }

        /// <summary>
        /// Проверка, какие параметры выбраны для обновления в заказе
        /// </summary>
        private void CheckSelectedAttrForUpdate()
        {
            try
            {
                tableLayoutPanelImportValueList.SuspendLayout();
                
                lblImportValuesList.Text = "";
                pictureBoxImportValueList.Image = null;
                lstboxImportValuesList.Items.Clear();

                // необходимо пройти по дереву выбранных для импорта параметров и обновить информацию о том, что именно будет обновляться

                System.String strSettingName = System.String.Empty;
                System.String strSettingUserName = System.String.Empty;
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treeListSettings.Nodes)
                {
                    if (objNode.Tag == null) { continue; }
                    CSettingItemForImportData objSetting = (CSettingItemForImportData)objNode.Tag;

                    strSettingName = objSetting.TOOLS_NAME;
                    strSettingUserName = objSetting.TOOLS_USERNAME;

                    if( ( strSettingName ==  CSettingForImportData.strFieldNamePARTS_ID ) || 
                        ( strSettingName ==  CSettingForImportData.strFieldNameARTICLE ) || 
                        ( strSettingName ==  CSettingForImportData.strFieldNameNAME2 ) || 
                        ( strSettingName ==  CSettingForImportData.strFieldNameFULLNAME ) ||
                        (strSettingName == CSettingForImportData.strFieldNameSTARTROW)
                        )
                    { continue; }

                    if (System.Convert.ToBoolean(objNode.GetValue(colCheck)) == false) { continue; }
                    else
                    {
                        lstboxImportValuesList.Items.Add(strSettingUserName);
                    }

                }

                if (lstboxImportValuesList.Items.Count == 0)
                {
                    lblImportValuesList.Text = "Не выбраны данные для импорта!";
                    pictureBoxImportValueList.Image = ERPMercuryLotOrder.Properties.Resources.warning_24;
                }
                else
                {
                    lblImportValuesList.Text = "Данные для импорта:";
                    pictureBoxImportValueList.Image = ERPMercuryLotOrder.Properties.Resources.Information;
                }


            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "CheckSelectedAttrForUpdate.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                tableLayoutPanelImportValueList.ResumeLayout( false );
            }
            return;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID_Ib.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Укажите файл шаблона MS Excel.", "Предупреждение",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return;
                }

                switch (this.m_enImportTarget)
                {
                    case enumImportTarget.ImportContents:
                        ImportdataToOrderItems();
                        break;
                    case  enumImportTarget.RefreshPrices:
                        RefreshPricesInOrderItems();
                        break;
                    case enumImportTarget.ImportDataToLot:
                        ImportDataInLot();
                        break;
                    default:
                        break;
                }
 
                if (treeListImportOrder.Nodes.Count == 0)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }

            }//try
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "btnOk_Click.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();

            }//try
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "btnCancel_Click.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return;
        }
        #endregion

        #region Сохранить настройки в БД

        private void SaveSettings()
        {
            try
            {
                if ((m_objSettingForImportData != null) && (m_objSettingForImportData.SettingsList != null))
                {
                    CSettingItemForImportData objSetting = null;
                    foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treeListSettings.Nodes)
                    {
                        if (objNode.Tag == null) { continue; }
                        objSetting = (CSettingItemForImportData)objNode.Tag;
                        foreach (CSettingItemForImportData objItem in m_objSettingForImportData.SettingsList)
                        {
                            if (objSetting.TOOLS_ID == objItem.TOOLS_ID)
                            {
                                objItem.TOOLS_VALUE = objSetting.TOOLS_VALUE;
                                objItem.TOOLS_DESCRIPTION = objSetting.TOOLS_DESCRIPTION;
                                break;
                            }
                        }
                    }
                }

                System.String strErr = "";
                if (SaveXMLSettings(ref strErr) == false)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Ошибка сохранения настроек в базе данных.\nТекст ошибки: " + strErr, "Ошибка",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "SaveSettings.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return ;
        }

        private System.Boolean SaveXMLSettings(ref System.String strErr)
        {
            System.Boolean bRet = false;
            try
            {
                System.Xml.XmlNodeList nodeList = m_objSettingForImportData.XMLSettings.GetElementsByTagName(strNodeSettingname);
                if (nodeList != null)
                {
                    CSettingItemForImportData objSetting = null;
                    foreach (System.Xml.XmlNode xmlNode in nodeList)
                    {
                        foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treeListSettings.Nodes)
                        {
                            if (objNode.Tag == null) { continue; }
                            objSetting = (CSettingItemForImportData)objNode.Tag;

                            if ( objSetting.TOOLS_ID.ToString() == xmlNode.Attributes[0].Value)
                            {
                                xmlNode.Attributes[3].InnerText = System.Convert.ToString(objNode.GetValue(colSettingsDescription));
                                xmlNode.Attributes[4].InnerText = System.Convert.ToString(objNode.GetValue(colSettingsColumnNum));
                            }
                        }
                    }
                    // теперь и в Базе данных
                    bRet = m_objSettingForImportData.SaveExportSetting( m_objProfile, null, ref strErr );
                }
            }//try
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "SaveXMLSettingsForSheet.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return bRet;

        }

        private void btnSaveSetings_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка сохранения настроек.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return ;

        }
        #endregion

        #region Импорт содержимого файла в приложение к заказу
        /// <summary>
        /// Импорт данных в приложение к заказу
        /// </summary>
        private void ImportdataToOrderItems()
        {
            if (treeListImportOrder == null) { return; }
            
            List<ERP_Mercury.Common.CCountry> objCountryList = ERP_Mercury.Common.CCountry.GetCountryList(m_objProfile, null);
            if ((objCountryList == null) || (objCountryList.Count == 0))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Импорт данных в заказ отменён.\nНе удалось получить список стран производства.", "Ошибка",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return;
            }
            System.Boolean bCheckPRICE_EXW = false;
            System.Boolean bCheckPRICE_INVOICE = false;
            System.Boolean bCheckPRICE_FORCALCCOSTPRICE = false;
            System.Boolean bCheckQUANTITY_CONFIRM = false;
            System.Boolean bCheckQUANTITY_INDOC = false;
            System.Boolean bCheckTARIFF = false;
            System.Boolean bCheckCOUNTRY = false;

            System.Int32 iColumnPRICE_EXW = GetSettingValueByName(CSettingForImportData.strFieldNamePRICE_EXW, ref bCheckPRICE_EXW);
            System.Int32 iColumnPRICE_INVOICE = GetSettingValueByName(CSettingForImportData.strFieldNamePRICE_INVOICE, ref bCheckPRICE_INVOICE);
            System.Int32 iColumnPRICE_FORCALCCOSTPRICE = GetSettingValueByName(CSettingForImportData.strFieldNamePRICE_FORCALCCOSTPRICE, ref bCheckPRICE_FORCALCCOSTPRICE);

            System.Int32 iColumnQUANTITY_CONFIRM = GetSettingValueByName( CSettingForImportData.strFieldNameQUANTITY_COFIRM, ref bCheckQUANTITY_CONFIRM );
            System.Int32 iColumnQUANTITY_INDOC = GetSettingValueByName( CSettingForImportData.strFieldNameQUANTITY_INDOC, ref bCheckQUANTITY_INDOC );
            System.Int32 iColumnbCheckTARIFF = GetSettingValueByName(CSettingForImportData.strFieldNameTARIFF, ref bCheckTARIFF);
            System.Int32 iColumnbCheckCOUNTRY = GetSettingValueByName(CSettingForImportData.strFieldNameCOUNTRY, ref bCheckCOUNTRY);

            if ((bCheckPRICE_EXW == false) && (bCheckPRICE_INVOICE == false) && (bCheckPRICE_FORCALCCOSTPRICE == false) &&
                (bCheckQUANTITY_CONFIRM == false) && (bCheckQUANTITY_INDOC == false) && (bCheckTARIFF == false) && (bCheckCOUNTRY == false) )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                     "Необходимо выбрать в настройках хотя бы один параметр для импорта.", "Внимание!",
                     System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;


                this.tableLayoutPanel1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.treeListImportOrder)).BeginInit();


                //m_objdtOrderItems.Clear();
                System.Data.DataRow newRowOrderItems = null;
                CProduct objProduct = null;
                CCountry objCountryProduction = null;
                System.Int32 i = 0;
                List<DevExpress.XtraTreeList.Nodes.TreeListNode> objNodeForDeleteList = new List<DevExpress.XtraTreeList.Nodes.TreeListNode>();
                System.Boolean bErrExists = false;
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treeListImportOrder.Nodes)
                {
                    i++;
                    bErrExists = false;
                    if (objNode.Tag == null) { continue; }
                    objProduct = (CProduct)objNode.Tag;

                     // количество
                     if( System.Convert.ToDouble( objNode.GetValue( colQuantity ) ) <= 0 ) 
                     {
                       bErrExists = true;
                       listEditLog.Items.Add(String.Format("{0}Количество должно быть больше нуля. Количество в заказе: {1}", i, System.Convert.ToString(objNode.GetValue(colQuantity))));
                     }

                     if( System.Convert.ToDouble( objNode.GetValue( colPriceExw ) ) <= 0 ) 
                     {
                       bErrExists = true;
                       listEditLog.Items.Add(String.Format("{0}Тариф товара должен быть больше нуля. Тариф: {1}", i, System.Convert.ToString(objNode.GetValue(colPriceExw))));
                     }


                     if (bErrExists == false)
                     {
                         newRowOrderItems = m_objdtOrderItems.NewRow();

                         //newRowOrderItems["OrderItemsID"] = System.Guid.NewGuid();
                         newRowOrderItems["ProductID"] = objProduct.ID;
                         newRowOrderItems["MeasureID"] = objProduct.Measure.ID;

                         newRowOrderItems["OrderedQuantity"] = System.Convert.ToDouble(objNode.GetValue(colQuantity));
                         newRowOrderItems["ConfirmQuantity"] = ((bCheckQUANTITY_CONFIRM == true) ? System.Convert.ToDouble(objNode.GetValue(colQuantityConfirm)) : 0);
                         newRowOrderItems["QuantityInDoc"] = ((bCheckQUANTITY_INDOC == true) ? System.Convert.ToDouble(objNode.GetValue(colQuantityInDoc)) : 0); 

                         newRowOrderItems["VendorPrice"] = ( (bCheckPRICE_EXW == true) ? System.Convert.ToDouble(objNode.GetValue(colPriceExw)) : 0 );

                         newRowOrderItems["DiscountPercent"] = m_dblDiscountPercent;
                         newRowOrderItems["VendorPriceWithDiscount"] = ( ( bCheckPRICE_INVOICE == true ) ? System.Convert.ToDouble(objNode.GetValue(colPriceInvoice)) : 0 ); //!!!
                         newRowOrderItems["PriceForCalcCostPrice"] = ((bCheckPRICE_FORCALCCOSTPRICE == true) ? System.Convert.ToDouble(objNode.GetValue(colPriceForCalcCostPrice)) : 0); //!!!

                         newRowOrderItems["OrderPackQty"] = objProduct.CustomerOrderPackQty;
                         newRowOrderItems["OrderItems_MeasureName"] = objProduct.Measure.ShortName;
                         newRowOrderItems["OrderItems_PartsName"] = objProduct.Name;
                         newRowOrderItems["OrderItems_PartsArticle"] = objProduct.Article;

                         newRowOrderItems["Product_VendorPrice"] = objProduct.VendorPrice;
                         newRowOrderItems["Product_Weight"] = objProduct.Weight;

                         if (bCheckCOUNTRY == true)
                         {
                             objCountryProduction = objCountryList.SingleOrDefault<ERP_Mercury.Common.CCountry>(x => x.ID_Ib.Equals(System.Convert.ToInt32(objNode.GetValue(colCountryProduction))) == true);

                             if (objCountryProduction != null)
                             {
                                 newRowOrderItems["CountryProductionID"] = objCountryProduction.ID;
                                 newRowOrderItems["OrderItems_CountryProductionName"] = objCountryProduction.Name;
                             }
                         }
                         newRowOrderItems["CustomTarifPercent"] = ((bCheckTARIFF == true) ? System.Convert.ToDouble(objNode.GetValue(colCustomTarifPercent)) : 0); //!!!

                         objNodeForDeleteList.Add(objNode);
                         listEditLog.Items.Add(String.Format("{0} OK", i));

                         m_objdtOrderItems.Rows.Add(newRowOrderItems);
                     }
                }

                newRowOrderItems = null;
                m_objdtOrderItems.AcceptChanges();
                objCountryProduction = null;
                objProduct = null;

                if (objNodeForDeleteList != null)
                {
                    foreach( DevExpress.XtraTreeList.Nodes.TreeListNode objNode in objNodeForDeleteList )
                    {
                        treeListImportOrder.Nodes.Remove(objNode);
                    }
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка импорта данных в приложение к заказу.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.tableLayoutPanel1.ResumeLayout(false);
                this.tableLayoutPanel1.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.treeListImportOrder)).EndInit();

                if (objCountryList != null) { objCountryList = null; }

                Cursor = Cursors.Default;
            }

            return;

        }
        /// <summary>
        /// импорт данных из treeListImportLot в приложение к приходу
        /// </summary>
        private void ImportDataInLot()
        {
            if (treeListImportLot.Nodes.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Список импортируемых записей пуст.", "Сообщение",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                this.tableLayoutPanel1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.treeListImportLot)).BeginInit();

                System.Data.DataRow newRowLotItems = null;
                System.Int32 i = 0;
                List<DevExpress.XtraTreeList.Nodes.TreeListNode> objNodeForDeleteList = new List<DevExpress.XtraTreeList.Nodes.TreeListNode>();
                System.Boolean bErrExists = false;
                CKLPItems objKLPItem = null;

                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treeListImportLot.Nodes)
                {
                    i++;
                    bErrExists = false;
                    if (objNode.Tag == null) { continue; }

                    objKLPItem = ( CKLPItems )objNode.Tag;

                    // количество
                    if (System.Convert.ToDouble(objNode.GetValue(colImportLotQuantity)) <= 0)
                    {
                        bErrExists = true;
                        listEditLog.Items.Add(String.Format("{0}Количество должно быть больше нуля. Количество в приходе: {1}", i, System.Convert.ToString(objNode.GetValue(colQuantity))));
                    }


                    if (bErrExists == false)
                    {
                        newRowLotItems = m_objdtOrderItems.NewRow();

                        newRowLotItems["OrderItemsID"] = System.Guid.Empty;
                        newRowLotItems["KLPItemsID"] = objKLPItem.ID;
                        newRowLotItems["ProductID"] = objKLPItem.Product.ID;
                        newRowLotItems["MeasureID"] = objKLPItem.Measure.ID;
                        newRowLotItems["LotItems_Quantity"] = System.Convert.ToDouble(objNode.GetValue(colImportLotQuantity));
                        newRowLotItems["KLPItems_Quantity"] = objKLPItem.QuantityFact;
                        newRowLotItems["Lot_Quantity"] = 0;
                        newRowLotItems["CountryProductionID"] = objKLPItem.CountryProduction.ID;

                        newRowLotItems["LotItems_MeasureName"] = objKLPItem.Measure.ShortName;
                        newRowLotItems["LotItems_PartsArticle"] = objKLPItem.Product.Name;
                        newRowLotItems["LotItems_PartsName"] = objKLPItem.Product.Article;
                        newRowLotItems["LotItems_CountryProductionName"] = objKLPItem.CountryProduction.Name;
                        newRowLotItems["DiscountPercent"] = 0;
                        newRowLotItems["LotItems_CurrencyPrice"] = objKLPItem.PriceForCalcCostPrice;
                        newRowLotItems["LotItems_Price"] = ( objKLPItem.PriceForCalcCostPrice * m_dblRateCurrencyToCurrencyMain );

                        if (objKLPItem.ExpirationDate != System.DateTime.MinValue)
                        {
                            newRowLotItems["ExpirationDate"] = objKLPItem.ExpirationDate;
                        }

                        objNodeForDeleteList.Add(objNode);
                        listEditLog.Items.Add(String.Format("{0} OK", i));

                        m_objdtOrderItems.Rows.Add(newRowLotItems);
                    }
                }

                newRowLotItems = null;
                m_objdtOrderItems.AcceptChanges();

                if (objNodeForDeleteList != null)
                {
                    foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in objNodeForDeleteList)
                    {
                        treeListImportLot.Nodes.Remove(objNode);
                    }
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка импорта данных в приложение к приходу.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.tableLayoutPanel1.ResumeLayout(false);
                this.tableLayoutPanel1.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.treeListImportLot)).EndInit();

                Cursor = Cursors.Default;
            }

            return;

        }
        
        #endregion

        #region Обновление цен в заказе
        /// <summary>
        /// Обновление цен в приложение к заказу
        /// </summary>
        private void RefreshPricesInOrderItems()
        {
            if (treeListImportOrder == null) { return; }

            System.Boolean bCheckPRICE_EXW = false;
            System.Boolean bCheckPRICE_INVOICE = false;
            System.Boolean bCheckPRICE_FORCALCCOSTPRICE = false;
            System.Boolean bCheckQUANTITY = false;
            System.Boolean bCheckQUANTITY_CONFIRM = false;
            System.Boolean bCheckQUANTITY_INDOC = false;
            System.Boolean bCheckTARIFF = false;
            System.Boolean bCheckCOUNTRY = false;

            System.Int32 iColumnPRICE_EXW = GetSettingValueByName(CSettingForImportData.strFieldNamePRICE_EXW, ref bCheckPRICE_EXW);
            System.Int32 iColumnPRICE_INVOICE = GetSettingValueByName(CSettingForImportData.strFieldNamePRICE_INVOICE, ref bCheckPRICE_INVOICE);
            System.Int32 iColumnPRICE_FORCALCCOSTPRICE = GetSettingValueByName(CSettingForImportData.strFieldNamePRICE_FORCALCCOSTPRICE, ref bCheckPRICE_FORCALCCOSTPRICE);
            System.Int32 iColumnQUANTITY = GetSettingValueByName(CSettingForImportData.strFieldNameQUANTITY, ref bCheckQUANTITY);
            System.Int32 iColumnQUANTITY_CONFIRM = GetSettingValueByName(CSettingForImportData.strFieldNameQUANTITY_COFIRM, ref bCheckQUANTITY_CONFIRM);
            System.Int32 iColumnQUANTITY_INDOC = GetSettingValueByName(CSettingForImportData.strFieldNameQUANTITY_INDOC, ref bCheckQUANTITY_INDOC);

            System.Int32 iColumnbCheckTARIFF = GetSettingValueByName(CSettingForImportData.strFieldNameTARIFF, ref bCheckTARIFF);
            System.Int32 iColumnbCheckCOUNTRY = GetSettingValueByName(CSettingForImportData.strFieldNameCOUNTRY, ref bCheckCOUNTRY);

            if ((bCheckPRICE_EXW == false) && (bCheckPRICE_INVOICE == false) &&
                (bCheckPRICE_FORCALCCOSTPRICE == false) && (bCheckQUANTITY_CONFIRM == false) &&
                (bCheckQUANTITY_INDOC == false) && (bCheckQUANTITY == false) && (bCheckTARIFF == false) && (bCheckCOUNTRY == false))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                     "Необходимо выбрать в настройках хотя бы один параметр для импорта.", "Внимание!",
                     System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;


                this.tableLayoutPanel1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.treeListImportOrder)).BeginInit();


                CProduct objProduct = null;
                System.Guid uuidProductID;

                List<ERP_Mercury.Common.CCountry> objCountryList = ERP_Mercury.Common.CCountry.GetCountryList(m_objProfile, null);
                CCountry objCountryProduction = null;

                System.Int32 i = 0;
                List<DevExpress.XtraTreeList.Nodes.TreeListNode> objNodeForDeleteList = new List<DevExpress.XtraTreeList.Nodes.TreeListNode>();
                System.Boolean bErrExists = false;
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treeListImportOrder.Nodes)
                {
                    i++;
                    bErrExists = false;
                    if (objNode.Tag == null) { continue; }
                    objProduct = (CProduct)objNode.Tag;

                    //// количество
                    //if (System.Convert.ToDouble(objNode.GetValue(colQuantity)) <= 0)
                    //{
                    //    bErrExists = true;
                    //    listEditLog.Items.Add(String.Format("{0}Количество должно быть больше нуля. Количество в заказе: {1}", i, System.Convert.ToString(objNode.GetValue(colQuantity))));
                    //}

                    if (bCheckPRICE_EXW == true)
                    {
                        if (System.Convert.ToDouble(objNode.GetValue(colPriceExw)) <= 0)
                        {
                            bErrExists = true;
                            listEditLog.Items.Add(String.Format("{0}Цена exw товара должна быть больше нуля. Тариф: {1}", i, System.Convert.ToString(objNode.GetValue(colPriceExw))));
                        }
                    }

                    if (bCheckPRICE_INVOICE == true)
                    {
                        if (System.Convert.ToDouble(objNode.GetValue(colPriceInvoice)) <= 0)
                        {
                            bErrExists = true;
                            listEditLog.Items.Add(String.Format("{0}Цена по инвойсу должна быть больше нуля. Цена по инвойсу: {1}", i, System.Convert.ToString(objNode.GetValue(colPriceInvoice))));
                        }
                    }

                    if (bCheckPRICE_FORCALCCOSTPRICE == true)
                    {
                        if (System.Convert.ToDouble(objNode.GetValue(colPriceForCalcCostPrice)) <= 0)
                        {
                            bErrExists = true;
                            listEditLog.Items.Add(String.Format("{0}Цена для расчёта С/С товара должна быть больше нуля. Цена для расчёта С/С: {1}", i, System.Convert.ToString(objNode.GetValue(colPriceForCalcCostPrice))));
                        }
                    }

                    if (bCheckTARIFF == true)
                    {
                        if (System.Convert.ToDouble(objNode.GetValue(colCustomTarifPercent)) < 0)
                        {
                            bErrExists = true;
                            listEditLog.Items.Add(String.Format("{0}Таможенный тариф должен быть больше либо равен нулю. Таможенный тариф: {1}", i, System.Convert.ToString(objNode.GetValue(colCustomTarifPercent))));
                        }
                    }

                    if (bCheckCOUNTRY == true)
                    {
                        if (System.Convert.ToDouble(objNode.GetValue(colCountryProduction)) < 0)
                        {
                            bErrExists = true;
                            listEditLog.Items.Add(String.Format("{0}Код страны быть больше нуля. Код страны: {1}", i, System.Convert.ToString(objNode.GetValue(colCountryProduction))));
                        }

                    }

                    if (bErrExists == false)
                    {
                        // необходимо найти строчку с товаром и внести правки в цены
                        for (System.Int32 i2 = 0; i2 < m_objdtOrderItems.Rows.Count; i2++)
                        {
                            if (m_objdtOrderItems.Rows[i2]["ProductID"] == System.DBNull.Value)
                            {
                                continue;
                            }

                            uuidProductID = (System.Guid)(m_objdtOrderItems.Rows[i2]["ProductID"]);
                            if (uuidProductID.CompareTo(objProduct.ID) == 0)
                            {
                                if (bCheckPRICE_EXW == true)
                                {
                                    m_objdtOrderItems.Rows[i2]["VendorPrice"] = System.Convert.ToDouble(objNode.GetValue(colPriceExw));
                                }
                                if (bCheckPRICE_INVOICE == true)
                                {
                                    m_objdtOrderItems.Rows[i2]["VendorPriceWithDiscount"] = System.Convert.ToDouble(objNode.GetValue(colPriceInvoice));
                                }
                                if (bCheckPRICE_FORCALCCOSTPRICE == true)
                                {
                                    m_objdtOrderItems.Rows[i2]["PriceForCalcCostPrice"] = System.Convert.ToDouble(objNode.GetValue(colPriceForCalcCostPrice));
                                }
                                if (bCheckQUANTITY == true)
                                {
                                    m_objdtOrderItems.Rows[i2]["OrderedQuantity"] = System.Convert.ToDouble(objNode.GetValue(colQuantity));
                                }
                                if (bCheckQUANTITY_CONFIRM == true)
                                {
                                    m_objdtOrderItems.Rows[i2]["ConfirmQuantity"] = System.Convert.ToDouble(objNode.GetValue(colQuantityConfirm));
                                }
                                if (bCheckQUANTITY_INDOC == true)
                                {
                                    m_objdtOrderItems.Rows[i2]["QuantityInDoc"] = System.Convert.ToDouble(objNode.GetValue(colQuantityInDoc));
                                }
                                if (bCheckTARIFF == true)
                                {
                                    m_objdtOrderItems.Rows[i2]["CustomTarifPercent"] = System.Convert.ToDouble(objNode.GetValue(colCustomTarifPercent));
                                }
                                if (bCheckCOUNTRY == true)
                                {
                                    objCountryProduction = objCountryList.SingleOrDefault<ERP_Mercury.Common.CCountry>(x => x.ID_Ib.Equals(System.Convert.ToInt32(objNode.GetValue(colCountryProduction))) == true);

                                    if (objCountryProduction != null)
                                    {
                                        m_objdtOrderItems.Rows[i2]["CountryProductionID"] = objCountryProduction.ID;
                                        m_objdtOrderItems.Rows[i2]["OrderItems_CountryProductionName"] = objCountryProduction.Name;
                                    }
                                }

                            }

                        
                        }
                        objNodeForDeleteList.Add(objNode);
                        listEditLog.Items.Add(String.Format("{0} OK", i));
                    }
                }

                m_objdtOrderItems.AcceptChanges();
                objProduct = null;

                if (objNodeForDeleteList != null)
                {
                    foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in objNodeForDeleteList)
                    {
                        treeListImportOrder.Nodes.Remove(objNode);
                    }
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка обновления цен в приложение к заказу.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.tableLayoutPanel1.ResumeLayout(false);
                this.tableLayoutPanel1.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.treeListImportOrder)).EndInit();

                Cursor = Cursors.Default;
            }

            return;

        }
        #endregion

        #region Закрытие формы
        private void frmImportXLSData_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                m_strFileFullName = txtID_Ib.Text;
                SelectedSheetId = cboxSheet.SelectedIndex;
                SheetList = new List<string>();
                foreach (object objItem in cboxSheet.Properties.Items)
                {
                    SheetList.Add(System.Convert.ToString(objItem));
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "frmImportXLSData_FormClosed.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        #endregion

        #region Отрисовка ячеек дерева
        private void treeListImportOrder_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            try
            {
                System.Double dblStockQty = System.Convert.ToDouble(e.Node.GetValue(colPriceExw));
                System.Double dblOrderQty = System.Convert.ToDouble(e.Node.GetValue(colQuantity));
                
                if (dblStockQty == 0)
                {
                    if (e.Column == colPriceExw)
                    {
                        e.Appearance.DrawString(e.Cache, e.CellText,
                                    new Rectangle(e.Bounds.Location.X, e.Bounds.Location.Y,
                                    e.Bounds.Size.Width - 3, e.Bounds.Size.Height), new System.Drawing.SolidBrush(Color.Red));
                        e.Handled = true;
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "treeListImportOrder_CustomDrawNodeCell.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }

        private void treeListImportLot_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            try
            {
                System.Double dblQuantity = System.Convert.ToDouble(e.Node.GetValue(colImportLotQuantity));

                if (dblQuantity == 0)
                {
                    if (e.Column == colImportLotCurrencyPrice)
                    {
                        e.Appearance.DrawString(e.Cache, e.CellText,
                                    new Rectangle(e.Bounds.Location.X, e.Bounds.Location.Y,
                                    e.Bounds.Size.Width - 3, e.Bounds.Size.Height), new System.Drawing.SolidBrush(Color.Red));
                        e.Handled = true;
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "treeListImportLot_CustomDrawNodeCell.\nТекст ошибки: " + f.Message, "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;

        }

        #endregion

    }
}
