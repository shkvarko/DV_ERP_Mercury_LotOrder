namespace ERPMercuryLotOrder
{
    partial class ctrlLot
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition5 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition6 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition7 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition8 = new DevExpress.XtraGrid.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlLot));
            this.colKLPItemsQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEditOrderedQuantity = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colLotQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mitemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmsExportToHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmsExportToXML = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmsExportToXLS = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmsExportToTXT = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmsExportToDBF = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmsExportToDBFCurrency = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmsImportFromExcelByPartsId = new System.Windows.Forms.ToolStripMenuItem();
            this.изMSExcelспецимпортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemRefreshPrices = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmsRefreshPricesByPartsId = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmsRefreshPricesByPartsFullName = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemClearPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelBackground = new System.Windows.Forms.TableLayoutPanel();
            this.panelProgressBar = new DevExpress.XtraEditors.PanelControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.dataSet = new System.Data.DataSet();
            this.OrderItems = new System.Data.DataTable();
            this.OrderItemsID = new System.Data.DataColumn();
            this.ProductID = new System.Data.DataColumn();
            this.MeasureID = new System.Data.DataColumn();
            this.LotItems_Quantity = new System.Data.DataColumn();
            this.KLPItems_Quantity = new System.Data.DataColumn();
            this.Lot_Quantity = new System.Data.DataColumn();
            this.LotItems_Price = new System.Data.DataColumn();
            this.LotItems_CurrencyPrice = new System.Data.DataColumn();
            this.LotItems_AllPrice = new System.Data.DataColumn();
            this.LotItems_CurrencyAllPrice = new System.Data.DataColumn();
            this.LotItems_MeasureName = new System.Data.DataColumn();
            this.LotItems_PartsArticle = new System.Data.DataColumn();
            this.LotItems_PartsName = new System.Data.DataColumn();
            this.ExpirationDate = new System.Data.DataColumn();
            this.CountryProductionID = new System.Data.DataColumn();
            this.LotItems_CountryProductionName = new System.Data.DataColumn();
            this.DiscountPercent = new System.Data.DataColumn();
            this.Product = new System.Data.DataTable();
            this.ProductGuid = new System.Data.DataColumn();
            this.ProductShortName = new System.Data.DataColumn();
            this.CustomerOrderPackQty = new System.Data.DataColumn();
            this.Product_MeasureID = new System.Data.DataColumn();
            this.Product_MeasureName = new System.Data.DataColumn();
            this.ProductArticle = new System.Data.DataColumn();
            this.ProductFullName = new System.Data.DataColumn();
            this.CountryProduction = new System.Data.DataTable();
            this.CountryProductionGuid = new System.Data.DataColumn();
            this.CountryProductionName = new System.Data.DataColumn();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOrderItemsID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditProduct = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMeasureID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotItems_MeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEditDiscount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colSumPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumCurrencyPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotItems_PartsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotItems_PartsArticle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpirationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colCountryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditCountryProduction = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLotItems_CountryProductionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditDiscount = new DevExpress.XtraEditors.SpinEdit();
            this.btnSetDiscount = new DevExpress.XtraEditors.SimpleButton();
            this.checkMultiplicity = new DevExpress.XtraEditors.CheckEdit();
            this.controlNavigator = new DevExpress.XtraEditors.ControlNavigator();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cboxCountryProduction = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.pictureFilter = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.cboxProductType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboxProductTradeMark = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtLotNum = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtLotDocNum = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.dtLotDocDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtKLPNum = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cboxVendor = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.cboxStockLot = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtLotDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblEditMode = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.checkLotActive = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboxCurrency = new DevExpress.XtraEditors.ComboBoxEdit();
            this.calcLotCurrencyRate = new DevExpress.XtraEditors.CalcEdit();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cboxLotState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEditOrderedQuantity)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.tableLayoutPanelBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelProgressBar)).BeginInit();
            this.panelProgressBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Product)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountryProduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditCountryProduction)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDiscount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkMultiplicity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxCountryProduction.Properties)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxProductType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxProductTradeMark.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotDocNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLotDocDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLotDocDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKLPNum.Properties)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxVendor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxStockLot.Properties)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotDescription.Properties)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkLotActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcLotCurrencyRate.Properties)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxLotState.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colKLPItemsQuantity
            // 
            this.colKLPItemsQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colKLPItemsQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colKLPItemsQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colKLPItemsQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKLPItemsQuantity.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colKLPItemsQuantity.Caption = "Кол-во в КЛП";
            this.colKLPItemsQuantity.ColumnEdit = this.repositoryItemCalcEditOrderedQuantity;
            this.colKLPItemsQuantity.FieldName = "KLPItems_Quantity";
            this.colKLPItemsQuantity.MinWidth = 80;
            this.colKLPItemsQuantity.Name = "colKLPItemsQuantity";
            this.colKLPItemsQuantity.SummaryItem.DisplayFormat = "Кол-во в КЛП: {0:### ### ##0}";
            this.colKLPItemsQuantity.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colKLPItemsQuantity.Visible = true;
            this.colKLPItemsQuantity.VisibleIndex = 2;
            this.colKLPItemsQuantity.Width = 80;
            // 
            // repositoryItemCalcEditOrderedQuantity
            // 
            this.repositoryItemCalcEditOrderedQuantity.AutoHeight = false;
            this.repositoryItemCalcEditOrderedQuantity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEditOrderedQuantity.DisplayFormat.FormatString = "### ##0";
            this.repositoryItemCalcEditOrderedQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemCalcEditOrderedQuantity.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemCalcEditOrderedQuantity.Name = "repositoryItemCalcEditOrderedQuantity";
            // 
            // colLotQuantity
            // 
            this.colLotQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colLotQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colLotQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colLotQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLotQuantity.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colLotQuantity.Caption = "Кол-во (поставлено на приход)";
            this.colLotQuantity.ColumnEdit = this.repositoryItemCalcEditOrderedQuantity;
            this.colLotQuantity.FieldName = "Lot_Quantity";
            this.colLotQuantity.MinWidth = 80;
            this.colLotQuantity.Name = "colLotQuantity";
            this.colLotQuantity.SummaryItem.DisplayFormat = "Оприходовано: {0:### ### ##0}";
            this.colLotQuantity.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colLotQuantity.Visible = true;
            this.colLotQuantity.VisibleIndex = 3;
            this.colLotQuantity.Width = 80;
            // 
            // colPrice
            // 
            this.colPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPrice.Caption = "Цена (валюта прихода)";
            this.colPrice.DisplayFormat.FormatString = "# ### ### ##0.000";
            this.colPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrice.FieldName = "LotItems_Price";
            this.colPrice.MinWidth = 100;
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 5;
            this.colPrice.Width = 100;
            // 
            // colCurrencyPrice
            // 
            this.colCurrencyPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colCurrencyPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCurrencyPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrencyPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrencyPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCurrencyPrice.Caption = "Себестоимость";
            this.colCurrencyPrice.DisplayFormat.FormatString = "# ### ### ##0.000";
            this.colCurrencyPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCurrencyPrice.FieldName = "LotItems_CurrencyPrice";
            this.colCurrencyPrice.MinWidth = 100;
            this.colCurrencyPrice.Name = "colCurrencyPrice";
            this.colCurrencyPrice.Visible = true;
            this.colCurrencyPrice.VisibleIndex = 7;
            this.colCurrencyPrice.Width = 100;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitemExport,
            this.mitemImport,
            this.mitemRefreshPrices,
            this.mitemClearPrice});
            this.contextMenuStrip.Name = "contextMenuStripLicence";
            this.contextMenuStrip.Size = new System.Drawing.Size(302, 92);
            this.toolTipController.SetSuperTip(this.contextMenuStrip, null);
            // 
            // mitemExport
            // 
            this.mitemExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmsExportToHTML,
            this.mitmsExportToXML,
            this.mitmsExportToXLS,
            this.mitmsExportToTXT,
            this.mitmsExportToDBF,
            this.mitmsExportToDBFCurrency});
            this.mitemExport.Name = "mitemExport";
            this.mitemExport.Size = new System.Drawing.Size(301, 22);
            this.mitemExport.Text = "Экспорт";
            // 
            // mitmsExportToHTML
            // 
            this.mitmsExportToHTML.Name = "mitmsExportToHTML";
            this.mitmsExportToHTML.Size = new System.Drawing.Size(233, 22);
            this.mitmsExportToHTML.Text = "в HTML...";
            // 
            // mitmsExportToXML
            // 
            this.mitmsExportToXML.Name = "mitmsExportToXML";
            this.mitmsExportToXML.Size = new System.Drawing.Size(233, 22);
            this.mitmsExportToXML.Text = "в XML...";
            // 
            // mitmsExportToXLS
            // 
            this.mitmsExportToXLS.Name = "mitmsExportToXLS";
            this.mitmsExportToXLS.Size = new System.Drawing.Size(233, 22);
            this.mitmsExportToXLS.Text = "в MS Excel...";
            // 
            // mitmsExportToTXT
            // 
            this.mitmsExportToTXT.Name = "mitmsExportToTXT";
            this.mitmsExportToTXT.Size = new System.Drawing.Size(233, 22);
            this.mitmsExportToTXT.Text = "в TXT...";
            // 
            // mitmsExportToDBF
            // 
            this.mitmsExportToDBF.Name = "mitmsExportToDBF";
            this.mitmsExportToDBF.Size = new System.Drawing.Size(233, 22);
            this.mitmsExportToDBF.Text = "в DBF...";
            // 
            // mitmsExportToDBFCurrency
            // 
            this.mitmsExportToDBFCurrency.Name = "mitmsExportToDBFCurrency";
            this.mitmsExportToDBFCurrency.Size = new System.Drawing.Size(233, 22);
            this.mitmsExportToDBFCurrency.Text = "в DBF (цена в валюте учета)...";
            this.mitmsExportToDBFCurrency.Visible = false;
            // 
            // mitemImport
            // 
            this.mitemImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmsImportFromExcelByPartsId,
            this.изMSExcelспецимпортToolStripMenuItem});
            this.mitemImport.Name = "mitemImport";
            this.mitemImport.Size = new System.Drawing.Size(301, 22);
            this.mitemImport.Text = "Импорт приложения к заказу";
            // 
            // mitmsImportFromExcelByPartsId
            // 
            this.mitmsImportFromExcelByPartsId.Name = "mitmsImportFromExcelByPartsId";
            this.mitmsImportFromExcelByPartsId.Size = new System.Drawing.Size(257, 22);
            this.mitmsImportFromExcelByPartsId.Text = "из MS Excel (специмпорт ID)";
            // 
            // изMSExcelспецимпортToolStripMenuItem
            // 
            this.изMSExcelспецимпортToolStripMenuItem.Name = "изMSExcelспецимпортToolStripMenuItem";
            this.изMSExcelспецимпортToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.изMSExcelспецимпортToolStripMenuItem.Text = "из MS Excel (специмпорт FULLNAME) ";
            // 
            // mitemRefreshPrices
            // 
            this.mitemRefreshPrices.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmsRefreshPricesByPartsId,
            this.mitmsRefreshPricesByPartsFullName});
            this.mitemRefreshPrices.Name = "mitemRefreshPrices";
            this.mitemRefreshPrices.Size = new System.Drawing.Size(301, 22);
            this.mitemRefreshPrices.Text = "Обновить цены  и количество в приложении";
            // 
            // mitmsRefreshPricesByPartsId
            // 
            this.mitmsRefreshPricesByPartsId.Name = "mitmsRefreshPricesByPartsId";
            this.mitmsRefreshPricesByPartsId.Size = new System.Drawing.Size(254, 22);
            this.mitmsRefreshPricesByPartsId.Text = "из MS Excel (специмпорт ID)";
            // 
            // mitmsRefreshPricesByPartsFullName
            // 
            this.mitmsRefreshPricesByPartsFullName.Name = "mitmsRefreshPricesByPartsFullName";
            this.mitmsRefreshPricesByPartsFullName.Size = new System.Drawing.Size(254, 22);
            this.mitmsRefreshPricesByPartsFullName.Text = "из MS Excel (специмпорт FULLNAME)";
            // 
            // mitemClearPrice
            // 
            this.mitemClearPrice.Name = "mitemClearPrice";
            this.mitemClearPrice.Size = new System.Drawing.Size(301, 22);
            this.mitemClearPrice.Text = "Обнулить цену";
            // 
            // tableLayoutPanelBackground
            // 
            this.tableLayoutPanelBackground.ColumnCount = 1;
            this.tableLayoutPanelBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBackground.Controls.Add(this.panelProgressBar, 0, 6);
            this.tableLayoutPanelBackground.Controls.Add(this.gridControl, 0, 9);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel6, 0, 8);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel8, 0, 7);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel1, 0, 10);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel4, 0, 5);
            this.tableLayoutPanelBackground.Controls.Add(this.lblEditMode, 0, 0);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel5, 0, 4);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBackground.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelBackground.Name = "tableLayoutPanelBackground";
            this.tableLayoutPanelBackground.RowCount = 11;
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelBackground.Size = new System.Drawing.Size(1203, 624);
            this.toolTipController.SetSuperTip(this.tableLayoutPanelBackground, null);
            this.tableLayoutPanelBackground.TabIndex = 1;
            // 
            // panelProgressBar
            // 
            this.panelProgressBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelProgressBar.Controls.Add(this.progressBarControl1);
            this.panelProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProgressBar.Location = new System.Drawing.Point(3, 185);
            this.panelProgressBar.Name = "panelProgressBar";
            this.panelProgressBar.Size = new System.Drawing.Size(1197, 25);
            this.toolTipController.SetSuperTip(this.panelProgressBar, null);
            this.panelProgressBar.TabIndex = 27;
            this.panelProgressBar.Visible = false;
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarControl1.Location = new System.Drawing.Point(4, 5);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Size = new System.Drawing.Size(1189, 16);
            this.progressBarControl1.TabIndex = 0;
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.contextMenuStrip;
            this.gridControl.DataMember = "OrderItems";
            this.gridControl.DataSource = this.dataSet;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(3, 269);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditProduct,
            this.repositoryItemCalcEditOrderedQuantity,
            this.repositoryItemSpinEditDiscount,
            this.repositoryItemDateEdit,
            this.repositoryItemLookUpEditCountryProduction});
            this.gridControl.Size = new System.Drawing.Size(1197, 321);
            this.gridControl.TabIndex = 26;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "dataSet";
            this.dataSet.Relations.AddRange(new System.Data.DataRelation[] {
            new System.Data.DataRelation("rlOrderItmsProduct", "Product", "OrderItems", new string[] {
                        "ProductID"}, new string[] {
                        "ProductID"}, false),
            new System.Data.DataRelation("rlOrderitmsCountryProduction", "CountryProduction", "OrderItems", new string[] {
                        "CountryProductionID"}, new string[] {
                        "CountryProductionID"}, false)});
            this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.OrderItems,
            this.Product,
            this.CountryProduction});
            // 
            // OrderItems
            // 
            this.OrderItems.Columns.AddRange(new System.Data.DataColumn[] {
            this.OrderItemsID,
            this.ProductID,
            this.MeasureID,
            this.LotItems_Quantity,
            this.KLPItems_Quantity,
            this.Lot_Quantity,
            this.LotItems_Price,
            this.LotItems_CurrencyPrice,
            this.LotItems_AllPrice,
            this.LotItems_CurrencyAllPrice,
            this.LotItems_MeasureName,
            this.LotItems_PartsArticle,
            this.LotItems_PartsName,
            this.ExpirationDate,
            this.CountryProductionID,
            this.LotItems_CountryProductionName,
            this.DiscountPercent});
            this.OrderItems.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.ForeignKeyConstraint("rlOrderitmsCountryProduction", "CountryProduction", new string[] {
                        "CountryProductionID"}, new string[] {
                        "CountryProductionID"}, System.Data.AcceptRejectRule.None, System.Data.Rule.None, System.Data.Rule.None)});
            this.OrderItems.TableName = "OrderItems";
            // 
            // OrderItemsID
            // 
            this.OrderItemsID.Caption = "ID";
            this.OrderItemsID.ColumnName = "OrderItemsID";
            this.OrderItemsID.DataType = typeof(System.Guid);
            // 
            // ProductID
            // 
            this.ProductID.Caption = "Товар";
            this.ProductID.ColumnName = "ProductID";
            this.ProductID.DataType = typeof(System.Guid);
            // 
            // MeasureID
            // 
            this.MeasureID.Caption = "MeasureID";
            this.MeasureID.ColumnName = "MeasureID";
            this.MeasureID.DataType = typeof(System.Guid);
            // 
            // LotItems_Quantity
            // 
            this.LotItems_Quantity.Caption = "Количество";
            this.LotItems_Quantity.ColumnName = "LotItems_Quantity";
            this.LotItems_Quantity.DataType = typeof(decimal);
            // 
            // KLPItems_Quantity
            // 
            this.KLPItems_Quantity.Caption = "Кол-во в КЛП";
            this.KLPItems_Quantity.ColumnName = "KLPItems_Quantity";
            this.KLPItems_Quantity.DataType = typeof(decimal);
            // 
            // Lot_Quantity
            // 
            this.Lot_Quantity.Caption = "Кол-во (оприходовано)";
            this.Lot_Quantity.ColumnName = "Lot_Quantity";
            this.Lot_Quantity.DataType = typeof(decimal);
            // 
            // LotItems_Price
            // 
            this.LotItems_Price.Caption = "Цена (валюта прихода)";
            this.LotItems_Price.ColumnName = "LotItems_Price";
            this.LotItems_Price.DataType = typeof(double);
            // 
            // LotItems_CurrencyPrice
            // 
            this.LotItems_CurrencyPrice.Caption = "С/С (ОВУ)";
            this.LotItems_CurrencyPrice.ColumnName = "LotItems_CurrencyPrice";
            this.LotItems_CurrencyPrice.DataType = typeof(double);
            // 
            // LotItems_AllPrice
            // 
            this.LotItems_AllPrice.Caption = "Сумма (валюта прихода)";
            this.LotItems_AllPrice.ColumnName = "LotItems_AllPrice";
            this.LotItems_AllPrice.DataType = typeof(double);
            this.LotItems_AllPrice.Expression = "LotItems_Price * LotItems_Quantity";
            this.LotItems_AllPrice.ReadOnly = true;
            // 
            // LotItems_CurrencyAllPrice
            // 
            this.LotItems_CurrencyAllPrice.Caption = "Сумма (С/С)";
            this.LotItems_CurrencyAllPrice.ColumnName = "LotItems_CurrencyAllPrice";
            this.LotItems_CurrencyAllPrice.DataType = typeof(double);
            this.LotItems_CurrencyAllPrice.Expression = "LotItems_CurrencyPrice * LotItems_Quantity";
            this.LotItems_CurrencyAllPrice.ReadOnly = true;
            // 
            // LotItems_MeasureName
            // 
            this.LotItems_MeasureName.Caption = "Ед. изм.";
            this.LotItems_MeasureName.ColumnName = "LotItems_MeasureName";
            // 
            // LotItems_PartsArticle
            // 
            this.LotItems_PartsArticle.ColumnName = "LotItems_PartsArticle";
            // 
            // LotItems_PartsName
            // 
            this.LotItems_PartsName.ColumnName = "LotItems_PartsName";
            // 
            // ExpirationDate
            // 
            this.ExpirationDate.Caption = "Срок годности";
            this.ExpirationDate.ColumnName = "ExpirationDate";
            this.ExpirationDate.DataType = typeof(System.DateTime);
            // 
            // CountryProductionID
            // 
            this.CountryProductionID.Caption = "Страна пр-ва";
            this.CountryProductionID.ColumnName = "CountryProductionID";
            this.CountryProductionID.DataType = typeof(System.Guid);
            // 
            // LotItems_CountryProductionName
            // 
            this.LotItems_CountryProductionName.Caption = "Страна пр-ва";
            this.LotItems_CountryProductionName.ColumnName = "LotItems_CountryProductionName";
            // 
            // DiscountPercent
            // 
            this.DiscountPercent.Caption = "надбавка,%";
            this.DiscountPercent.ColumnName = "DiscountPercent";
            // 
            // Product
            // 
            this.Product.Columns.AddRange(new System.Data.DataColumn[] {
            this.ProductGuid,
            this.ProductShortName,
            this.CustomerOrderPackQty,
            this.Product_MeasureID,
            this.Product_MeasureName,
            this.ProductArticle,
            this.ProductFullName});
            this.Product.TableName = "Product";
            // 
            // ProductGuid
            // 
            this.ProductGuid.Caption = "Товар";
            this.ProductGuid.ColumnName = "ProductID";
            this.ProductGuid.DataType = typeof(System.Guid);
            // 
            // ProductShortName
            // 
            this.ProductShortName.Caption = "Наименование товара";
            this.ProductShortName.ColumnName = "ProductShortName";
            // 
            // CustomerOrderPackQty
            // 
            this.CustomerOrderPackQty.Caption = "Количество в упаковке";
            this.CustomerOrderPackQty.ColumnName = "CustomerOrderPackQty";
            this.CustomerOrderPackQty.DataType = typeof(decimal);
            // 
            // Product_MeasureID
            // 
            this.Product_MeasureID.Caption = "MeasureID";
            this.Product_MeasureID.ColumnName = "Product_MeasureID";
            this.Product_MeasureID.DataType = typeof(System.Guid);
            // 
            // Product_MeasureName
            // 
            this.Product_MeasureName.Caption = "Ед. изм.";
            this.Product_MeasureName.ColumnName = "Product_MeasureName";
            // 
            // ProductArticle
            // 
            this.ProductArticle.Caption = "Артикул";
            this.ProductArticle.ColumnName = "ProductArticle";
            // 
            // ProductFullName
            // 
            this.ProductFullName.Caption = "Товар";
            this.ProductFullName.ColumnName = "ProductFullName";
            // 
            // CountryProduction
            // 
            this.CountryProduction.Columns.AddRange(new System.Data.DataColumn[] {
            this.CountryProductionGuid,
            this.CountryProductionName});
            this.CountryProduction.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "CountryProductionID"}, false)});
            this.CountryProduction.TableName = "CountryProduction";
            // 
            // CountryProductionGuid
            // 
            this.CountryProductionGuid.Caption = "Страна пр-ва (код)";
            this.CountryProductionGuid.ColumnName = "CountryProductionID";
            this.CountryProductionGuid.DataType = typeof(System.Guid);
            // 
            // CountryProductionName
            // 
            this.CountryProductionName.Caption = "Страна пр-ва";
            this.CountryProductionName.ColumnName = "CountryProductionName";
            // 
            // gridView
            // 
            this.gridView.ColumnPanelRowHeight = 60;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOrderItemsID,
            this.colProductID,
            this.colMeasureID,
            this.colLotItems_MeasureName,
            this.colKLPItemsQuantity,
            this.colLotQuantity,
            this.colQuantity,
            this.colPrice,
            this.colDiscountPercent,
            this.colCurrencyPrice,
            this.colSumPrice,
            this.colSumCurrencyPrice,
            this.colLotItems_PartsName,
            this.colLotItems_PartsArticle,
            this.colExpirationDate,
            this.colCountryID,
            this.colLotItems_CountryProductionName});
            this.gridView.CustomizationFormBounds = new System.Drawing.Rectangle(1062, 711, 208, 189);
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.Column = this.colKLPItemsQuantity;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition1.Value1 = 0D;
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition2.Value1 = "0";
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.Column = this.colLotQuantity;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition3.Value1 = "0";
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.Column = this.colPrice;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition4.Value1 = "0";
            styleFormatCondition5.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition5.Appearance.Options.UseBackColor = true;
            styleFormatCondition5.Column = this.colCurrencyPrice;
            styleFormatCondition5.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition5.Value1 = "0";
            styleFormatCondition6.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition6.Appearance.Options.UseBackColor = true;
            styleFormatCondition6.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition6.Value1 = "0";
            styleFormatCondition7.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition7.Appearance.Options.UseBackColor = true;
            styleFormatCondition7.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition7.Value1 = "0";
            styleFormatCondition8.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition8.Appearance.Options.UseBackColor = true;
            styleFormatCondition8.Condition = DevExpress.XtraGrid.FormatConditionEnum.Less;
            styleFormatCondition8.Value1 = "0";
            this.gridView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3,
            styleFormatCondition4,
            styleFormatCondition5,
            styleFormatCondition6,
            styleFormatCondition7,
            styleFormatCondition8});
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "OrderID", null, "")});
            this.gridView.IndicatorWidth = 50;
            this.gridView.Name = "gridView";
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // colOrderItemsID
            // 
            this.colOrderItemsID.AppearanceHeader.Options.UseTextOptions = true;
            this.colOrderItemsID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colOrderItemsID.Caption = "OrderItemsID";
            this.colOrderItemsID.FieldName = "OrderItemsID";
            this.colOrderItemsID.Name = "colOrderItemsID";
            // 
            // colProductID
            // 
            this.colProductID.AppearanceHeader.Options.UseTextOptions = true;
            this.colProductID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProductID.Caption = "Наименование товара";
            this.colProductID.ColumnEdit = this.repositoryItemLookUpEditProduct;
            this.colProductID.FieldName = "ProductID";
            this.colProductID.MinWidth = 200;
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 0;
            this.colProductID.Width = 356;
            // 
            // repositoryItemLookUpEditProduct
            // 
            this.repositoryItemLookUpEditProduct.Appearance.Options.UseBackColor = true;
            this.repositoryItemLookUpEditProduct.AutoHeight = false;
            this.repositoryItemLookUpEditProduct.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditProduct.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductShortName", "Наименование товара", 125),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductArticle", "Артикул", 40)});
            this.repositoryItemLookUpEditProduct.DisplayMember = "ProductFullName";
            this.repositoryItemLookUpEditProduct.DropDownRows = 10;
            this.repositoryItemLookUpEditProduct.Name = "repositoryItemLookUpEditProduct";
            this.repositoryItemLookUpEditProduct.NullText = "";
            this.repositoryItemLookUpEditProduct.PopupFormMinSize = new System.Drawing.Size(500, 0);
            this.repositoryItemLookUpEditProduct.PopupWidth = 500;
            this.repositoryItemLookUpEditProduct.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.repositoryItemLookUpEditProduct.ValidateOnEnterKey = true;
            this.repositoryItemLookUpEditProduct.ValueMember = "ProductID";
            // 
            // colMeasureID
            // 
            this.colMeasureID.Caption = "MeasureID";
            this.colMeasureID.FieldName = "MeasureID";
            this.colMeasureID.Name = "colMeasureID";
            // 
            // colLotItems_MeasureName
            // 
            this.colLotItems_MeasureName.AppearanceHeader.Options.UseTextOptions = true;
            this.colLotItems_MeasureName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLotItems_MeasureName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colLotItems_MeasureName.Caption = "Ед изм.";
            this.colLotItems_MeasureName.FieldName = "LotItems_MeasureName";
            this.colLotItems_MeasureName.MinWidth = 55;
            this.colLotItems_MeasureName.Name = "colLotItems_MeasureName";
            this.colLotItems_MeasureName.OptionsColumn.AllowEdit = false;
            this.colLotItems_MeasureName.OptionsColumn.ReadOnly = true;
            this.colLotItems_MeasureName.Visible = true;
            this.colLotItems_MeasureName.VisibleIndex = 1;
            this.colLotItems_MeasureName.Width = 55;
            // 
            // colQuantity
            // 
            this.colQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQuantity.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colQuantity.Caption = "Кол-во";
            this.colQuantity.ColumnEdit = this.repositoryItemCalcEditOrderedQuantity;
            this.colQuantity.FieldName = "LotItems_Quantity";
            this.colQuantity.MinWidth = 80;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.SummaryItem.DisplayFormat = "Кол-во: {0:### ### ##0}";
            this.colQuantity.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 4;
            this.colQuantity.Width = 80;
            // 
            // colDiscountPercent
            // 
            this.colDiscountPercent.AppearanceHeader.Options.UseTextOptions = true;
            this.colDiscountPercent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiscountPercent.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDiscountPercent.Caption = "надбавка, %";
            this.colDiscountPercent.ColumnEdit = this.repositoryItemSpinEditDiscount;
            this.colDiscountPercent.DisplayFormat.FormatString = "##0";
            this.colDiscountPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiscountPercent.FieldName = "DiscountPercent";
            this.colDiscountPercent.MinWidth = 50;
            this.colDiscountPercent.Name = "colDiscountPercent";
            this.colDiscountPercent.Visible = true;
            this.colDiscountPercent.VisibleIndex = 6;
            this.colDiscountPercent.Width = 50;
            // 
            // repositoryItemSpinEditDiscount
            // 
            this.repositoryItemSpinEditDiscount.AutoHeight = false;
            this.repositoryItemSpinEditDiscount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEditDiscount.DisplayFormat.FormatString = "# ### ### ##0";
            this.repositoryItemSpinEditDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEditDiscount.EditFormat.FormatString = "# ### ### ##0";
            this.repositoryItemSpinEditDiscount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEditDiscount.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.repositoryItemSpinEditDiscount.Name = "repositoryItemSpinEditDiscount";
            // 
            // colSumPrice
            // 
            this.colSumPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colSumPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSumPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSumPrice.Caption = "Сумма (вал. прихода)";
            this.colSumPrice.DisplayFormat.FormatString = "# ### ### ##0.00";
            this.colSumPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumPrice.FieldName = "LotItems_AllPrice";
            this.colSumPrice.MinWidth = 150;
            this.colSumPrice.Name = "colSumPrice";
            this.colSumPrice.OptionsColumn.AllowEdit = false;
            this.colSumPrice.OptionsColumn.ReadOnly = true;
            this.colSumPrice.SummaryItem.DisplayFormat = "Сумма, exw: {0:### ### ##0.00}";
            this.colSumPrice.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colSumPrice.Visible = true;
            this.colSumPrice.VisibleIndex = 8;
            this.colSumPrice.Width = 150;
            // 
            // colSumCurrencyPrice
            // 
            this.colSumCurrencyPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colSumCurrencyPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSumCurrencyPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSumCurrencyPrice.Caption = "Сумма (с/с)";
            this.colSumCurrencyPrice.DisplayFormat.FormatString = "# ### ### ##0.00";
            this.colSumCurrencyPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumCurrencyPrice.FieldName = "LotItems_CurrencyAllPrice";
            this.colSumCurrencyPrice.MinWidth = 150;
            this.colSumCurrencyPrice.Name = "colSumCurrencyPrice";
            this.colSumCurrencyPrice.OptionsColumn.AllowEdit = false;
            this.colSumCurrencyPrice.OptionsColumn.ReadOnly = true;
            this.colSumCurrencyPrice.SummaryItem.DisplayFormat = "С/С: {0:### ### ##0.00}";
            this.colSumCurrencyPrice.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colSumCurrencyPrice.Visible = true;
            this.colSumCurrencyPrice.VisibleIndex = 9;
            this.colSumCurrencyPrice.Width = 150;
            // 
            // colLotItems_PartsName
            // 
            this.colLotItems_PartsName.Caption = "colOrderItems_PartsName";
            this.colLotItems_PartsName.FieldName = "LotItems_PartsName";
            this.colLotItems_PartsName.Name = "colLotItems_PartsName";
            // 
            // colLotItems_PartsArticle
            // 
            this.colLotItems_PartsArticle.Caption = "colOrderItems_PartsArticle";
            this.colLotItems_PartsArticle.FieldName = "LotItems_PartsArticle";
            this.colLotItems_PartsArticle.Name = "colLotItems_PartsArticle";
            // 
            // colExpirationDate
            // 
            this.colExpirationDate.Caption = "Срок годности";
            this.colExpirationDate.ColumnEdit = this.repositoryItemDateEdit;
            this.colExpirationDate.FieldName = "ExpirationDate";
            this.colExpirationDate.Name = "colExpirationDate";
            this.colExpirationDate.Visible = true;
            this.colExpirationDate.VisibleIndex = 10;
            // 
            // repositoryItemDateEdit
            // 
            this.repositoryItemDateEdit.AutoHeight = false;
            this.repositoryItemDateEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit.Name = "repositoryItemDateEdit";
            this.repositoryItemDateEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colCountryID
            // 
            this.colCountryID.Caption = "Страна пр-ва";
            this.colCountryID.ColumnEdit = this.repositoryItemLookUpEditCountryProduction;
            this.colCountryID.FieldName = "CountryProductionID";
            this.colCountryID.Name = "colCountryID";
            this.colCountryID.Visible = true;
            this.colCountryID.VisibleIndex = 11;
            // 
            // repositoryItemLookUpEditCountryProduction
            // 
            this.repositoryItemLookUpEditCountryProduction.Appearance.Options.UseBackColor = true;
            this.repositoryItemLookUpEditCountryProduction.AutoHeight = false;
            this.repositoryItemLookUpEditCountryProduction.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditCountryProduction.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CountryProductionName", "Страна пр-ва", 50)});
            this.repositoryItemLookUpEditCountryProduction.DisplayMember = "CountryProductionName";
            this.repositoryItemLookUpEditCountryProduction.DropDownRows = 10;
            this.repositoryItemLookUpEditCountryProduction.Name = "repositoryItemLookUpEditCountryProduction";
            this.repositoryItemLookUpEditCountryProduction.NullText = "";
            this.repositoryItemLookUpEditCountryProduction.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.repositoryItemLookUpEditCountryProduction.ValidateOnEnterKey = true;
            this.repositoryItemLookUpEditCountryProduction.ValueMember = "CountryProductionID";
            // 
            // colLotItems_CountryProductionName
            // 
            this.colLotItems_CountryProductionName.Caption = "colOrderItems_CountryProductionName";
            this.colLotItems_CountryProductionName.FieldName = "LotItems_CountryProductionName";
            this.colLotItems_CountryProductionName.Name = "colLotItems_CountryProductionName";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 11;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 288F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.labelControl16, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.spinEditDiscount, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnSetDiscount, 4, 0);
            this.tableLayoutPanel6.Controls.Add(this.checkMultiplicity, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.controlNavigator, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.labelControl8, 8, 0);
            this.tableLayoutPanel6.Controls.Add(this.cboxCountryProduction, 9, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 241);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1203, 25);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel6, null);
            this.tableLayoutPanel6.TabIndex = 25;
            // 
            // labelControl16
            // 
            this.labelControl16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl16.Location = new System.Drawing.Point(420, 6);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(60, 13);
            this.labelControl16.TabIndex = 28;
            this.labelControl16.Text = "Скидка, %:";
            // 
            // spinEditDiscount
            // 
            this.spinEditDiscount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditDiscount.Location = new System.Drawing.Point(486, 3);
            this.spinEditDiscount.Name = "spinEditDiscount";
            this.spinEditDiscount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditDiscount.Size = new System.Drawing.Size(57, 20);
            this.spinEditDiscount.TabIndex = 2;
            // 
            // btnSetDiscount
            // 
            this.btnSetDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSetDiscount.Image = global::ERPMercuryLotOrder.Properties.Resources.sign_percentage_16;
            this.btnSetDiscount.Location = new System.Drawing.Point(547, 1);
            this.btnSetDiscount.Margin = new System.Windows.Forms.Padding(0);
            this.btnSetDiscount.Name = "btnSetDiscount";
            this.btnSetDiscount.Size = new System.Drawing.Size(23, 22);
            this.btnSetDiscount.TabIndex = 3;
            this.btnSetDiscount.ToolTip = "Установить скидку на все позиции";
            this.btnSetDiscount.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // checkMultiplicity
            // 
            this.checkMultiplicity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkMultiplicity.Location = new System.Drawing.Point(291, 3);
            this.checkMultiplicity.Name = "checkMultiplicity";
            this.checkMultiplicity.Properties.Caption = "Кратность кол-ва";
            this.checkMultiplicity.Size = new System.Drawing.Size(115, 19);
            this.checkMultiplicity.TabIndex = 1;
            this.checkMultiplicity.ToolTip = "Количество в заказе должно быть кратно количеству в упаковке";
            this.checkMultiplicity.ToolTipController = this.toolTipController;
            this.checkMultiplicity.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // controlNavigator
            // 
            this.controlNavigator.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.controlNavigator.Location = new System.Drawing.Point(3, 3);
            this.controlNavigator.Name = "controlNavigator";
            this.controlNavigator.NavigatableControl = this.gridControl;
            this.controlNavigator.ShowToolTips = true;
            this.controlNavigator.Size = new System.Drawing.Size(281, 19);
            this.controlNavigator.TabIndex = 0;
            this.controlNavigator.Text = "controlNavigator";
            this.controlNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.controlNavigator.TextStringFormat = "Запись {0} of {1}";
            this.controlNavigator.ToolTipController = this.toolTipController;
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl8.Location = new System.Drawing.Point(758, 6);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(72, 13);
            this.labelControl8.TabIndex = 32;
            this.labelControl8.Text = "Страна пр-ва:";
            // 
            // cboxCountryProduction
            // 
            this.cboxCountryProduction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxCountryProduction.Location = new System.Drawing.Point(835, 3);
            this.cboxCountryProduction.Name = "cboxCountryProduction";
            this.cboxCountryProduction.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxCountryProduction.Properties.PopupSizeable = true;
            this.cboxCountryProduction.Properties.Sorted = true;
            this.cboxCountryProduction.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxCountryProduction.Size = new System.Drawing.Size(99, 20);
            this.cboxCountryProduction.TabIndex = 33;
            this.cboxCountryProduction.ToolTip = "Страна производства";
            this.cboxCountryProduction.ToolTipController = this.toolTipController;
            this.cboxCountryProduction.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 7;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel8.Controls.Add(this.labelControl13, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.pictureFilter, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.labelControl15, 4, 0);
            this.tableLayoutPanel8.Controls.Add(this.cboxProductType, 5, 0);
            this.tableLayoutPanel8.Controls.Add(this.cboxProductTradeMark, 3, 0);
            this.tableLayoutPanel8.Controls.Add(this.labelControl14, 2, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 213);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(1203, 28);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel8, null);
            this.tableLayoutPanel8.TabIndex = 22;
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl13.Location = new System.Drawing.Point(31, 7);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(148, 13);
            this.labelControl13.TabIndex = 28;
            this.labelControl13.Text = "Фильтрация списка товаров:";
            // 
            // pictureFilter
            // 
            this.pictureFilter.EditValue = global::ERPMercuryLotOrder.Properties.Resources.filter_data_16;
            this.pictureFilter.Location = new System.Drawing.Point(3, 3);
            this.pictureFilter.Name = "pictureFilter";
            this.pictureFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureFilter.Size = new System.Drawing.Size(22, 20);
            this.pictureFilter.TabIndex = 12;
            // 
            // labelControl15
            // 
            this.labelControl15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl15.Location = new System.Drawing.Point(697, 7);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(90, 13);
            this.labelControl15.TabIndex = 28;
            this.labelControl15.Text = "Товарная группа:";
            // 
            // cboxProductType
            // 
            this.cboxProductType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxProductType.Location = new System.Drawing.Point(797, 4);
            this.cboxProductType.Name = "cboxProductType";
            this.cboxProductType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxProductType.Properties.PopupSizeable = true;
            this.cboxProductType.Properties.Sorted = true;
            this.cboxProductType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxProductType.Size = new System.Drawing.Size(380, 20);
            this.cboxProductType.TabIndex = 30;
            this.cboxProductType.ToolTip = "Товарная группа";
            this.cboxProductType.ToolTipController = this.toolTipController;
            this.cboxProductType.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // cboxProductTradeMark
            // 
            this.cboxProductTradeMark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxProductTradeMark.Location = new System.Drawing.Point(311, 4);
            this.cboxProductTradeMark.Name = "cboxProductTradeMark";
            this.cboxProductTradeMark.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxProductTradeMark.Properties.PopupSizeable = true;
            this.cboxProductTradeMark.Properties.Sorted = true;
            this.cboxProductTradeMark.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxProductTradeMark.Size = new System.Drawing.Size(380, 20);
            this.cboxProductTradeMark.TabIndex = 29;
            this.cboxProductTradeMark.ToolTip = "Товарная марка";
            this.cboxProductTradeMark.ToolTipController = this.toolTipController;
            this.cboxProductTradeMark.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // labelControl14
            // 
            this.labelControl14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl14.Location = new System.Drawing.Point(211, 7);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(85, 13);
            this.labelControl14.TabIndex = 27;
            this.labelControl14.Text = "Товарная марка:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPrint, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 593);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1203, 31);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel1, null);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(1125, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.ToolTip = "Отменить изменения";
            this.btnCancel.ToolTipController = this.toolTipController;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(1043, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "ОК";
            this.btnSave.ToolTip = "Сохранить изменения";
            this.btnSave.ToolTipController = this.toolTipController;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Image = global::ERPMercuryLotOrder.Properties.Resources.document_edit;
            this.btnEdit.Location = new System.Drawing.Point(85, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(112, 25);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.ToolTipController = this.toolTipController;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(3, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Печать";
            this.btnPrint.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 11;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 232F));
            this.tableLayoutPanel2.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtLotNum, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl7, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtLotDocNum, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl10, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtLotDocDate, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl11, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtKLPNum, 7, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 47);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1203, 27);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel2, null);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Location = new System.Drawing.Point(3, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 13);
            this.labelControl1.TabIndex = 27;
            this.labelControl1.Text = "Партия №:";
            // 
            // txtLotNum
            // 
            this.txtLotNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLotNum.Location = new System.Drawing.Point(73, 3);
            this.txtLotNum.Name = "txtLotNum";
            this.txtLotNum.Size = new System.Drawing.Size(114, 20);
            this.txtLotNum.TabIndex = 0;
            this.txtLotNum.ToolTip = "Номер партии";
            this.txtLotNum.ToolTipController = this.toolTipController;
            this.txtLotNum.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl7.Location = new System.Drawing.Point(193, 7);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(66, 13);
            this.labelControl7.TabIndex = 28;
            this.labelControl7.Text = "Документ №";
            // 
            // txtLotDocNum
            // 
            this.txtLotDocNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLotDocNum.Location = new System.Drawing.Point(265, 3);
            this.txtLotDocNum.Name = "txtLotDocNum";
            this.txtLotDocNum.Size = new System.Drawing.Size(114, 20);
            this.txtLotDocNum.TabIndex = 1;
            this.txtLotDocNum.ToolTip = "Номер приходного документа";
            this.txtLotDocNum.ToolTipController = this.toolTipController;
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl10.Location = new System.Drawing.Point(385, 7);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(68, 13);
            this.labelControl10.TabIndex = 20;
            this.labelControl10.Text = "Дата док-та:";
            // 
            // dtLotDocDate
            // 
            this.dtLotDocDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtLotDocDate.EditValue = null;
            this.dtLotDocDate.Location = new System.Drawing.Point(459, 3);
            this.dtLotDocDate.Name = "dtLotDocDate";
            this.dtLotDocDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtLotDocDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtLotDocDate.Size = new System.Drawing.Size(114, 20);
            this.dtLotDocDate.TabIndex = 2;
            this.dtLotDocDate.ToolTip = "Дата оформления заказа";
            this.dtLotDocDate.ToolTipController = this.toolTipController;
            this.dtLotDocDate.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl11.Location = new System.Drawing.Point(579, 7);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(41, 13);
            this.labelControl11.TabIndex = 33;
            this.labelControl11.Text = "КЛП №:";
            // 
            // txtKLPNum
            // 
            this.txtKLPNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKLPNum.Location = new System.Drawing.Point(626, 3);
            this.txtKLPNum.Name = "txtKLPNum";
            this.txtKLPNum.Properties.ReadOnly = true;
            this.txtKLPNum.Size = new System.Drawing.Size(113, 20);
            this.txtKLPNum.TabIndex = 3;
            this.txtKLPNum.ToolTip = "КЛП, на основании которого сформирован приход";
            this.txtKLPNum.ToolTipController = this.toolTipController;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 312F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 274F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.cboxVendor, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl9, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.cboxStockLot, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 74);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1203, 27);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel3, null);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // cboxVendor
            // 
            this.cboxVendor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxVendor.Location = new System.Drawing.Point(73, 3);
            this.cboxVendor.Name = "cboxVendor";
            this.cboxVendor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxVendor.Properties.PopupSizeable = true;
            this.cboxVendor.Properties.Sorted = true;
            this.cboxVendor.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxVendor.Size = new System.Drawing.Size(306, 20);
            this.cboxVendor.TabIndex = 0;
            this.cboxVendor.ToolTip = "Поставщик";
            this.cboxVendor.ToolTipController = this.toolTipController;
            this.cboxVendor.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl2.Location = new System.Drawing.Point(3, 7);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 13);
            this.labelControl2.TabIndex = 28;
            this.labelControl2.Text = "Поставщик:";
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl9.Location = new System.Drawing.Point(385, 7);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(82, 13);
            this.labelControl9.TabIndex = 30;
            this.labelControl9.Text = "Склад прихода:";
            this.labelControl9.ToolTip = "Склад прихода товара";
            this.labelControl9.ToolTipController = this.toolTipController;
            // 
            // cboxStockLot
            // 
            this.cboxStockLot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxStockLot.Location = new System.Drawing.Point(471, 3);
            this.cboxStockLot.Name = "cboxStockLot";
            this.cboxStockLot.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxStockLot.Properties.PopupSizeable = true;
            this.cboxStockLot.Properties.Sorted = true;
            this.cboxStockLot.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxStockLot.Size = new System.Drawing.Size(268, 20);
            this.cboxStockLot.TabIndex = 1;
            this.cboxStockLot.ToolTip = "Поставщик";
            this.cboxStockLot.ToolTipController = this.toolTipController;
            this.cboxStockLot.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.txtLotDescription, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelControl4, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 128);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1203, 54);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel4, null);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // txtLotDescription
            // 
            this.txtLotDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLotDescription.Location = new System.Drawing.Point(72, 3);
            this.txtLotDescription.Name = "txtLotDescription";
            this.txtLotDescription.Size = new System.Drawing.Size(1128, 48);
            this.txtLotDescription.TabIndex = 0;
            this.txtLotDescription.ToolTip = "Примечание";
            this.txtLotDescription.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl4.Location = new System.Drawing.Point(3, 20);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(65, 13);
            this.labelControl4.TabIndex = 29;
            this.labelControl4.Text = "Примечание:";
            // 
            // lblEditMode
            // 
            this.lblEditMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEditMode.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEditMode.Appearance.Options.UseFont = true;
            this.lblEditMode.Location = new System.Drawing.Point(3, 3);
            this.lblEditMode.Name = "lblEditMode";
            this.lblEditMode.Size = new System.Drawing.Size(140, 13);
            this.lblEditMode.TabIndex = 28;
            this.lblEditMode.Text = "режим редактирования";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 5;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.checkLotActive, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.labelControl12, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.labelControl3, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.cboxCurrency, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.calcLotCurrencyRate, 3, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 101);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1203, 27);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel5, null);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // checkLotActive
            // 
            this.checkLotActive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkLotActive.Location = new System.Drawing.Point(385, 4);
            this.checkLotActive.Name = "checkLotActive";
            this.checkLotActive.Properties.Caption = "Активен";
            this.checkLotActive.Size = new System.Drawing.Size(80, 19);
            this.checkLotActive.TabIndex = 2;
            this.checkLotActive.ToolTip = "Признак \"Приход активен\"";
            this.checkLotActive.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // labelControl12
            // 
            this.labelControl12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl12.Location = new System.Drawing.Point(195, 7);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(61, 13);
            this.labelControl12.TabIndex = 32;
            this.labelControl12.Text = "Курс к ОВУ:";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl3.Location = new System.Drawing.Point(3, 7);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(43, 13);
            this.labelControl3.TabIndex = 30;
            this.labelControl3.Text = "Валюта:";
            // 
            // cboxCurrency
            // 
            this.cboxCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxCurrency.Location = new System.Drawing.Point(72, 3);
            this.cboxCurrency.Name = "cboxCurrency";
            this.cboxCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxCurrency.Properties.PopupSizeable = true;
            this.cboxCurrency.Properties.Sorted = true;
            this.cboxCurrency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxCurrency.Size = new System.Drawing.Size(117, 20);
            this.cboxCurrency.TabIndex = 0;
            this.cboxCurrency.ToolTip = "Валюта расчёта с поставщиком";
            this.cboxCurrency.ToolTipController = this.toolTipController;
            this.cboxCurrency.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // calcLotCurrencyRate
            // 
            this.calcLotCurrencyRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.calcLotCurrencyRate.Location = new System.Drawing.Point(265, 3);
            this.calcLotCurrencyRate.Name = "calcLotCurrencyRate";
            this.calcLotCurrencyRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcLotCurrencyRate.Properties.ReadOnly = true;
            this.calcLotCurrencyRate.Size = new System.Drawing.Size(114, 20);
            this.calcLotCurrencyRate.TabIndex = 1;
            this.calcLotCurrencyRate.ToolTip = "Курс валюты прихода к валюте учёта";
            this.calcLotCurrencyRate.ToolTipController = this.toolTipController;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 312F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.labelControl5, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.cboxLotState, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 20);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(1203, 27);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel7, null);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl5.Location = new System.Drawing.Point(3, 7);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(58, 13);
            this.labelControl5.TabIndex = 32;
            this.labelControl5.Text = "Состояние:";
            // 
            // cboxLotState
            // 
            this.cboxLotState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxLotState.Location = new System.Drawing.Point(73, 3);
            this.cboxLotState.Name = "cboxLotState";
            this.cboxLotState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxLotState.Properties.PopupSizeable = true;
            this.cboxLotState.Properties.Sorted = true;
            this.cboxLotState.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxLotState.Size = new System.Drawing.Size(306, 20);
            this.cboxLotState.TabIndex = 2;
            this.cboxLotState.ToolTip = "Текущее состояние прихода";
            this.cboxLotState.ToolTipController = this.toolTipController;
            this.cboxLotState.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "MS Excel 2010 files (*.xlsx)|*.xlsx|MS Excel 2003 files (*.xls)|*.xls|All files (" +
    "*.*)|*.*";
            // 
            // ctrlLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelBackground);
            this.Name = "ctrlLot";
            this.Size = new System.Drawing.Size(1203, 624);
            this.toolTipController.SetSuperTip(this, null);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEditOrderedQuantity)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanelBackground.ResumeLayout(false);
            this.tableLayoutPanelBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelProgressBar)).EndInit();
            this.panelProgressBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Product)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountryProduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditCountryProduction)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDiscount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkMultiplicity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxCountryProduction.Properties)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxProductType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxProductTradeMark.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotDocNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLotDocDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLotDocDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKLPNum.Properties)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxVendor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxStockLot.Properties)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotDescription.Properties)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkLotActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcLotCurrencyRate.Properties)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxLotState.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController toolTipController;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mitemExport;
        private System.Windows.Forms.ToolStripMenuItem mitmsExportToHTML;
        private System.Windows.Forms.ToolStripMenuItem mitmsExportToXML;
        private System.Windows.Forms.ToolStripMenuItem mitmsExportToXLS;
        private System.Windows.Forms.ToolStripMenuItem mitmsExportToTXT;
        private System.Windows.Forms.ToolStripMenuItem mitmsExportToDBF;
        private System.Windows.Forms.ToolStripMenuItem mitmsExportToDBFCurrency;
        private System.Windows.Forms.ToolStripMenuItem mitemImport;
        private System.Windows.Forms.ToolStripMenuItem mitmsImportFromExcelByPartsId;
        private System.Windows.Forms.ToolStripMenuItem изMSExcelспецимпортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mitemRefreshPrices;
        private System.Windows.Forms.ToolStripMenuItem mitmsRefreshPricesByPartsId;
        private System.Windows.Forms.ToolStripMenuItem mitmsRefreshPricesByPartsFullName;
        private System.Windows.Forms.ToolStripMenuItem mitemClearPrice;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Data.DataSet dataSet;
        private System.Data.DataTable OrderItems;
        private System.Data.DataColumn OrderItemsID;
        private System.Data.DataColumn ProductID;
        private System.Data.DataColumn MeasureID;
        private System.Data.DataColumn LotItems_Quantity;
        private System.Data.DataColumn KLPItems_Quantity;
        private System.Data.DataColumn Lot_Quantity;
        private System.Data.DataColumn LotItems_Price;
        private System.Data.DataColumn LotItems_CurrencyPrice;
        private System.Data.DataColumn LotItems_AllPrice;
        private System.Data.DataColumn LotItems_CurrencyAllPrice;
        private System.Data.DataColumn LotItems_MeasureName;
        private System.Data.DataColumn LotItems_PartsArticle;
        private System.Data.DataColumn LotItems_PartsName;
        private System.Data.DataColumn ExpirationDate;
        private System.Data.DataColumn CountryProductionID;
        private System.Data.DataColumn LotItems_CountryProductionName;
        private System.Data.DataTable Product;
        private System.Data.DataColumn ProductGuid;
        private System.Data.DataColumn ProductShortName;
        private System.Data.DataColumn CustomerOrderPackQty;
        private System.Data.DataColumn Product_MeasureID;
        private System.Data.DataColumn Product_MeasureName;
        private System.Data.DataColumn ProductArticle;
        private System.Data.DataColumn ProductFullName;
        private System.Data.DataTable CountryProduction;
        private System.Data.DataColumn CountryProductionGuid;
        private System.Data.DataColumn CountryProductionName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBackground;
        private DevExpress.XtraEditors.PanelControl panelProgressBar;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderItemsID;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colMeasureID;
        private DevExpress.XtraGrid.Columns.GridColumn colLotItems_MeasureName;
        private DevExpress.XtraGrid.Columns.GridColumn colKLPItemsQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEditOrderedQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colLotQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountPercent;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colSumPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colSumCurrencyPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colLotItems_PartsName;
        private DevExpress.XtraGrid.Columns.GridColumn colLotItems_PartsArticle;
        private DevExpress.XtraGrid.Columns.GridColumn colExpirationDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colCountryID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditCountryProduction;
        private DevExpress.XtraGrid.Columns.GridColumn colLotItems_CountryProductionName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.SpinEdit spinEditDiscount;
        private DevExpress.XtraEditors.SimpleButton btnSetDiscount;
        private DevExpress.XtraEditors.CheckEdit checkMultiplicity;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit cboxCountryProduction;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.PictureEdit pictureFilter;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.ComboBoxEdit cboxProductType;
        private DevExpress.XtraEditors.ComboBoxEdit cboxProductTradeMark;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.DateEdit dtLotDocDate;
        private DevExpress.XtraEditors.TextEdit txtLotNum;
        private DevExpress.XtraEditors.CheckEdit checkLotActive;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.ComboBoxEdit cboxCurrency;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit cboxLotState;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cboxVendor;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevExpress.XtraEditors.MemoEdit txtLotDescription;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lblEditMode;
        private DevExpress.XtraEditors.ComboBoxEdit cboxStockLot;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtLotDocNum;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtKLPNum;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.CalcEdit calcLotCurrencyRate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Data.DataColumn DiscountPercent;
    }
}
