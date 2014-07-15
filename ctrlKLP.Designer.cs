namespace ERPMercuryLotOrder
{
    partial class ctrlKLP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlKLP));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition9 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition10 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition11 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition12 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition13 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition14 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition15 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition16 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEditOrderedQuantity = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colFactQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountVendorPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanelKLPList = new System.Windows.Forms.TableLayoutPanel();
            this.lblOrderInfo = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControlKLPList = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuLotList = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewKLPList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tableLayoutPanelAgreementShortInfo = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtLotOrderName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtVendorName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtLotOrderDate = new DevExpress.XtraEditors.TextEdit();
            this.calcQuantity = new DevExpress.XtraEditors.CalcEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.txtLotOrderState = new DevExpress.XtraEditors.TextEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.calcQuantityFact = new DevExpress.XtraEditors.CalcEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency = new DevExpress.XtraEditors.CalcEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtStockStockAccepting = new DevExpress.XtraEditors.TextEdit();
            this.txtCostIsCalc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.calcSumFactPriceForCalcCostPrice = new DevExpress.XtraEditors.CalcEdit();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.barBtnAddKLP = new DevExpress.XtraEditors.SimpleButton();
            this.barBtnDeleteKLP = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintKLPList = new DevExpress.XtraEditors.SimpleButton();
            this.barBtnExit = new DevExpress.XtraEditors.SimpleButton();
            this.barBtnToLotList = new DevExpress.XtraEditors.SimpleButton();
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageKLPList = new DevExpress.XtraTab.XtraTabPage();
            this.tabPageKLPEditor = new DevExpress.XtraTab.XtraTabPage();
            this.tableLayoutPanelBackground = new System.Windows.Forms.TableLayoutPanel();
            this.panelProgressBar = new DevExpress.XtraEditors.PanelControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStripEditor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemNewLotFromKLP = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSet = new System.Data.DataSet();
            this.KLPItems = new System.Data.DataTable();
            this.KLPItemsID = new System.Data.DataColumn();
            this.ProductID = new System.Data.DataColumn();
            this.MeasureID = new System.Data.DataColumn();
            this.Quantity = new System.Data.DataColumn();
            this.FactQuantity = new System.Data.DataColumn();
            this.CurrencyPrice = new System.Data.DataColumn();
            this.DiscountVendorPrice = new System.Data.DataColumn();
            this.AllDiscountVendorPrice = new System.Data.DataColumn();
            this.FactAllDiscountVendorPrice = new System.Data.DataColumn();
            this.AllCurrencyPrice = new System.Data.DataColumn();
            this.FactAllCurrencyPrice = new System.Data.DataColumn();
            this.KLPItems_MeasureName = new System.Data.DataColumn();
            this.KLPItems_PartsArticle = new System.Data.DataColumn();
            this.KLPItems_PartsName = new System.Data.DataColumn();
            this.LotOrderItems_Guid = new System.Data.DataColumn();
            this.KLPItems_Id = new System.Data.DataColumn();
            this.LotOrderItems_QuantityInDoc = new System.Data.DataColumn();
            this.LotOrderItems_QuantityInKLP = new System.Data.DataColumn();
            this.CountryProductionID = new System.Data.DataColumn();
            this.KLPItems_CountryProductionName = new System.Data.DataColumn();
            this.CustomTarifPercent = new System.Data.DataColumn();
            this.SrcForKlpItems = new System.Data.DataTable();
            this.ProductGuid = new System.Data.DataColumn();
            this.ProductShortName = new System.Data.DataColumn();
            this.OrderItems_OrderQuantity = new System.Data.DataColumn();
            this.Product_MeasureID = new System.Data.DataColumn();
            this.Product_MeasureName = new System.Data.DataColumn();
            this.ProductArticle = new System.Data.DataColumn();
            this.ProductFullName = new System.Data.DataColumn();
            this.OrderItems_ConfirmQuantity = new System.Data.DataColumn();
            this.OrderItems_Quantity = new System.Data.DataColumn();
            this.OrderItems_QuantityInKLP = new System.Data.DataColumn();
            this.OrderItems_ID = new System.Data.DataColumn();
            this.OrderItems_CountryProductionID = new System.Data.DataColumn();
            this.OrderItems_CountryProductionName = new System.Data.DataColumn();
            this.OrderItems_CustomTarifPercent = new System.Data.DataColumn();
            this.CountryProduction = new System.Data.DataTable();
            this.CountryProductionGuid = new System.Data.DataColumn();
            this.CountryProductionName = new System.Data.DataColumn();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKLPItemsID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKLPItems_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditProduct = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMeasureID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderItems_MeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomTarifPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllDiscountVendorPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactAllDiscountVendorPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllCurrencyPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactAllCurrencyPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKLPItems_PartsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKLPItems_PartsArticle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotOrderItems_QuantityInDoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotOrderItems_QuantityInKLP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotOrderItems_Guid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCountryProductionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditCountryProduction = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colKLPItems_CountryProductionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEditDiscount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.controlNavigator = new DevExpress.XtraEditors.ControlNavigator();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cboxProductTradeMark = new DevExpress.XtraEditors.ComboBoxEdit();
            this.pictureFilter = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.cboxProductType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.cboxKLPState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.KLPDate = new DevExpress.XtraEditors.DateEdit();
            this.txtKLPNum = new DevExpress.XtraEditors.TextEdit();
            this.checkKLPCostIsCalc = new DevExpress.XtraEditors.CheckEdit();
            this.checkKLPIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.KLPStartAccepting = new DevExpress.XtraEditors.DateEdit();
            this.KLPEndAccepting = new DevExpress.XtraEditors.DateEdit();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.cboxStock = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.barBtnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.barBtnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.barBtnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanelLotList = new System.Windows.Forms.TableLayoutPanel();
            this.tabPageLotList = new DevExpress.XtraTab.XtraTabPage();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEditOrderedQuantity)).BeginInit();
            this.tableLayoutPanelKLPList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrderInfo.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlKLPList)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKLPList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCheckEdit)).BeginInit();
            this.tableLayoutPanelAgreementShortInfo.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotOrderName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendorName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotOrderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotOrderState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcQuantityFact.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockStockAccepting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCostIsCalc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSumFactPriceForCalcCostPrice.Properties)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageKLPList.SuspendLayout();
            this.tabPageKLPEditor.SuspendLayout();
            this.tableLayoutPanelBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelProgressBar)).BeginInit();
            this.panelProgressBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.contextMenuStripEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KLPItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SrcForKlpItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountryProduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditCountryProduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditDiscount)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxProductTradeMark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxProductType.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxKLPState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KLPDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KLPDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKLPNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkKLPCostIsCalc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkKLPIsActive.Properties)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KLPStartAccepting.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KLPStartAccepting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KLPEndAccepting.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KLPEndAccepting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxStock.Properties)).BeginInit();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            this.tableLayoutPanel13.SuspendLayout();
            this.tabPageLotList.SuspendLayout();
            this.SuspendLayout();
            // 
            // colQuantity
            // 
            this.colQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQuantity.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colQuantity.Caption = "Кол-во";
            this.colQuantity.ColumnEdit = this.repositoryItemCalcEditOrderedQuantity;
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MinWidth = 100;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.SummaryItem.DisplayFormat = "по док-ту: {0:### ### ##0}";
            this.colQuantity.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 2;
            this.colQuantity.Width = 105;
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
            // colFactQuantity
            // 
            this.colFactQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colFactQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colFactQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colFactQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFactQuantity.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colFactQuantity.Caption = "Кол-во (факт)";
            this.colFactQuantity.ColumnEdit = this.repositoryItemCalcEditOrderedQuantity;
            this.colFactQuantity.FieldName = "FactQuantity";
            this.colFactQuantity.MinWidth = 100;
            this.colFactQuantity.Name = "colFactQuantity";
            this.colFactQuantity.SummaryItem.DisplayFormat = "факт: {0:### ### ##0}";
            this.colFactQuantity.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colFactQuantity.Visible = true;
            this.colFactQuantity.VisibleIndex = 3;
            this.colFactQuantity.Width = 100;
            // 
            // colDiscountVendorPrice
            // 
            this.colDiscountVendorPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colDiscountVendorPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDiscountVendorPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colDiscountVendorPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiscountVendorPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDiscountVendorPrice.Caption = "Цена";
            this.colDiscountVendorPrice.DisplayFormat.FormatString = "# ### ### ##0.000";
            this.colDiscountVendorPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiscountVendorPrice.FieldName = "DiscountVendorPrice";
            this.colDiscountVendorPrice.MinWidth = 55;
            this.colDiscountVendorPrice.Name = "colDiscountVendorPrice";
            this.colDiscountVendorPrice.Visible = true;
            this.colDiscountVendorPrice.VisibleIndex = 4;
            this.colDiscountVendorPrice.Width = 99;
            // 
            // colCurrencyPrice
            // 
            this.colCurrencyPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colCurrencyPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCurrencyPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrencyPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrencyPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCurrencyPrice.Caption = "Цена вал. для расчёта С/С";
            this.colCurrencyPrice.DisplayFormat.FormatString = "# ### ### ##0.000";
            this.colCurrencyPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCurrencyPrice.FieldName = "CurrencyPrice";
            this.colCurrencyPrice.MinWidth = 70;
            this.colCurrencyPrice.Name = "colCurrencyPrice";
            this.colCurrencyPrice.Visible = true;
            this.colCurrencyPrice.VisibleIndex = 5;
            this.colCurrencyPrice.Width = 98;
            // 
            // tableLayoutPanelKLPList
            // 
            this.tableLayoutPanelKLPList.ColumnCount = 1;
            this.tableLayoutPanelKLPList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelKLPList.Controls.Add(this.lblOrderInfo, 0, 0);
            this.tableLayoutPanelKLPList.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanelKLPList.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanelKLPList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelKLPList.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelKLPList.Name = "tableLayoutPanelKLPList";
            this.tableLayoutPanelKLPList.RowCount = 3;
            this.tableLayoutPanelKLPList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelKLPList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelKLPList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelKLPList.Size = new System.Drawing.Size(961, 591);
            this.toolTipController.SetSuperTip(this.tableLayoutPanelKLPList, null);
            this.tableLayoutPanelKLPList.TabIndex = 3;
            // 
            // lblOrderInfo
            // 
            this.lblOrderInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrderInfo.Location = new System.Drawing.Point(3, 3);
            this.lblOrderInfo.Name = "lblOrderInfo";
            this.lblOrderInfo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblOrderInfo.Properties.Appearance.Options.UseFont = true;
            this.lblOrderInfo.Properties.ReadOnly = true;
            this.lblOrderInfo.Size = new System.Drawing.Size(955, 20);
            this.lblOrderInfo.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 286F));
            this.tableLayoutPanel2.Controls.Add(this.gridControlKLPList, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanelAgreementShortInfo, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 53);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 537F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(959, 537);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel2, null);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // gridControlKLPList
            // 
            this.gridControlKLPList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlKLPList.ContextMenuStrip = this.contextMenuStrip;
            this.gridControlKLPList.EmbeddedNavigator.Name = "";
            this.gridControlKLPList.Location = new System.Drawing.Point(3, 3);
            this.gridControlKLPList.MainView = this.gridViewKLPList;
            this.gridControlKLPList.Name = "gridControlKLPList";
            this.gridControlKLPList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemCheckEdit});
            this.gridControlKLPList.Size = new System.Drawing.Size(667, 531);
            this.gridControlKLPList.TabIndex = 1;
            this.gridControlKLPList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewKLPList});
            this.gridControlKLPList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControlKLPList_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLotList});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(168, 26);
            this.toolTipController.SetSuperTip(this.contextMenuStrip, null);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // menuLotList
            // 
            this.menuLotList.Name = "menuLotList";
            this.menuLotList.Size = new System.Drawing.Size(167, 22);
            this.menuLotList.Text = "Журнал Приходов";
            this.menuLotList.Click += new System.EventHandler(this.menuLotList_Click);
            // 
            // gridViewKLPList
            // 
            this.gridViewKLPList.GridControl = this.gridControlKLPList;
            this.gridViewKLPList.Name = "gridViewKLPList";
            this.gridViewKLPList.OptionsBehavior.Editable = false;
            this.gridViewKLPList.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewKLPList.OptionsDetail.ShowDetailTabs = false;
            this.gridViewKLPList.OptionsDetail.SmartDetailExpand = false;
            this.gridViewKLPList.OptionsView.ShowFooter = true;
            this.gridViewKLPList.OptionsView.ShowGroupPanel = false;
            this.gridViewKLPList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewKLPList_FocusedRowChanged);
            this.gridViewKLPList.RowCountChanged += new System.EventHandler(this.gridViewKLPList_RowCountChanged);
            // 
            // repItemCheckEdit
            // 
            this.repItemCheckEdit.AutoHeight = false;
            this.repItemCheckEdit.Name = "repItemCheckEdit";
            // 
            // tableLayoutPanelAgreementShortInfo
            // 
            this.tableLayoutPanelAgreementShortInfo.ColumnCount = 1;
            this.tableLayoutPanelAgreementShortInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAgreementShortInfo.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanelAgreementShortInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAgreementShortInfo.Location = new System.Drawing.Point(676, 3);
            this.tableLayoutPanelAgreementShortInfo.Name = "tableLayoutPanelAgreementShortInfo";
            this.tableLayoutPanelAgreementShortInfo.RowCount = 2;
            this.tableLayoutPanelAgreementShortInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 453F));
            this.tableLayoutPanelAgreementShortInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAgreementShortInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelAgreementShortInfo.Size = new System.Drawing.Size(280, 531);
            this.toolTipController.SetSuperTip(this.tableLayoutPanelAgreementShortInfo, null);
            this.tableLayoutPanelAgreementShortInfo.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.txtLotOrderName, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtVendorName, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelControl4, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.txtLotOrderDate, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.calcQuantity, 0, 11);
            this.tableLayoutPanel3.Controls.Add(this.labelControl3, 0, 10);
            this.tableLayoutPanel3.Controls.Add(this.labelControl13, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.txtLotOrderState, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.labelControl15, 0, 12);
            this.tableLayoutPanel3.Controls.Add(this.calcQuantityFact, 0, 13);
            this.tableLayoutPanel3.Controls.Add(this.labelControl6, 0, 16);
            this.tableLayoutPanel3.Controls.Add(this.labelControl7, 0, 14);
            this.tableLayoutPanel3.Controls.Add(this.calcSumFactPriceForCalcCostPriceInVendorCurrency, 0, 17);
            this.tableLayoutPanel3.Controls.Add(this.labelControl5, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.txtStockStockAccepting, 0, 9);
            this.tableLayoutPanel3.Controls.Add(this.txtCostIsCalc, 0, 15);
            this.tableLayoutPanel3.Controls.Add(this.labelControl16, 0, 18);
            this.tableLayoutPanel3.Controls.Add(this.calcSumFactPriceForCalcCostPrice, 0, 19);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 21;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(280, 453);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel3, null);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // txtLotOrderName
            // 
            this.txtLotOrderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLotOrderName.Location = new System.Drawing.Point(3, 65);
            this.txtLotOrderName.Name = "txtLotOrderName";
            this.txtLotOrderName.Properties.ReadOnly = true;
            this.txtLotOrderName.Size = new System.Drawing.Size(274, 20);
            this.txtLotOrderName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 5);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Поставщик";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(3, 48);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "№ КЛП";
            // 
            // txtVendorName
            // 
            this.txtVendorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVendorName.Location = new System.Drawing.Point(3, 22);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Properties.ReadOnly = true;
            this.txtVendorName.Size = new System.Drawing.Size(274, 20);
            this.txtVendorName.TabIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(3, 94);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(57, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Дата КЛП";
            // 
            // txtLotOrderDate
            // 
            this.txtLotOrderDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLotOrderDate.Location = new System.Drawing.Point(3, 111);
            this.txtLotOrderDate.Name = "txtLotOrderDate";
            this.txtLotOrderDate.Properties.ReadOnly = true;
            this.txtLotOrderDate.Size = new System.Drawing.Size(274, 20);
            this.txtLotOrderDate.TabIndex = 2;
            // 
            // calcQuantity
            // 
            this.calcQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.calcQuantity.Location = new System.Drawing.Point(3, 240);
            this.calcQuantity.Name = "calcQuantity";
            this.calcQuantity.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.calcQuantity.Properties.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.calcQuantity.Properties.Appearance.Options.UseFont = true;
            this.calcQuantity.Properties.Appearance.Options.UseForeColor = true;
            this.calcQuantity.Properties.Appearance.Options.UseTextOptions = true;
            this.calcQuantity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.calcQuantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcQuantity.Properties.DisplayFormat.FormatString = "### ### ##0";
            this.calcQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcQuantity.Properties.EditFormat.FormatString = "### ### ##0";
            this.calcQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcQuantity.Properties.ReadOnly = true;
            this.calcQuantity.Size = new System.Drawing.Size(274, 20);
            this.calcQuantity.TabIndex = 4;
            this.calcQuantity.ToolTip = "Количество в инвойсе";
            this.calcQuantity.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(3, 223);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Количество";
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(3, 137);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(61, 13);
            this.labelControl13.TabIndex = 3;
            this.labelControl13.Text = "Состояние";
            // 
            // txtLotOrderState
            // 
            this.txtLotOrderState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLotOrderState.Location = new System.Drawing.Point(3, 154);
            this.txtLotOrderState.Name = "txtLotOrderState";
            this.txtLotOrderState.Properties.ReadOnly = true;
            this.txtLotOrderState.Size = new System.Drawing.Size(274, 20);
            this.txtLotOrderState.TabIndex = 3;
            // 
            // labelControl15
            // 
            this.labelControl15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(3, 266);
            this.labelControl15.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(148, 13);
            this.labelControl15.TabIndex = 20;
            this.labelControl15.Text = "Количество фактическое";
            // 
            // calcQuantityFact
            // 
            this.calcQuantityFact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.calcQuantityFact.Location = new System.Drawing.Point(3, 283);
            this.calcQuantityFact.Name = "calcQuantityFact";
            this.calcQuantityFact.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.calcQuantityFact.Properties.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.calcQuantityFact.Properties.Appearance.Options.UseFont = true;
            this.calcQuantityFact.Properties.Appearance.Options.UseForeColor = true;
            this.calcQuantityFact.Properties.Appearance.Options.UseTextOptions = true;
            this.calcQuantityFact.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.calcQuantityFact.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcQuantityFact.Properties.DisplayFormat.FormatString = "### ### ##0";
            this.calcQuantityFact.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcQuantityFact.Properties.ReadOnly = true;
            this.calcQuantityFact.Size = new System.Drawing.Size(274, 20);
            this.calcQuantityFact.TabIndex = 5;
            this.calcQuantityFact.ToolTip = "Сумма";
            this.calcQuantityFact.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(3, 352);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(37, 13);
            this.labelControl6.TabIndex = 7;
            this.labelControl6.Text = "Сумма";
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(3, 309);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(89, 13);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "Себестоимость";
            // 
            // calcSumFactPriceForCalcCostPriceInVendorCurrency
            // 
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Location = new System.Drawing.Point(3, 369);
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Name = "calcSumFactPriceForCalcCostPriceInVendorCurrency";
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Properties.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Properties.Appearance.Options.UseFont = true;
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Properties.Appearance.Options.UseForeColor = true;
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Properties.Appearance.Options.UseTextOptions = true;
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Properties.DisplayFormat.FormatString = "### ### ##0.00";
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Properties.EditFormat.FormatString = "### ### ##0.00";
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Properties.ReadOnly = true;
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Size = new System.Drawing.Size(274, 20);
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.TabIndex = 7;
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.ToolTip = "Сумма со скидкой (по инвойсу)";
            this.calcSumFactPriceForCalcCostPriceInVendorCurrency.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(3, 180);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(88, 13);
            this.labelControl5.TabIndex = 21;
            this.labelControl5.Text = "Склад приёмки";
            // 
            // txtStockStockAccepting
            // 
            this.txtStockStockAccepting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStockStockAccepting.Location = new System.Drawing.Point(3, 197);
            this.txtStockStockAccepting.Name = "txtStockStockAccepting";
            this.txtStockStockAccepting.Properties.ReadOnly = true;
            this.txtStockStockAccepting.Size = new System.Drawing.Size(274, 20);
            this.txtStockStockAccepting.TabIndex = 22;
            // 
            // txtCostIsCalc
            // 
            this.txtCostIsCalc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCostIsCalc.Location = new System.Drawing.Point(3, 326);
            this.txtCostIsCalc.Name = "txtCostIsCalc";
            this.txtCostIsCalc.Properties.ReadOnly = true;
            this.txtCostIsCalc.Size = new System.Drawing.Size(274, 20);
            this.txtCostIsCalc.TabIndex = 23;
            // 
            // labelControl16
            // 
            this.labelControl16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl16.Appearance.Options.UseFont = true;
            this.labelControl16.Location = new System.Drawing.Point(3, 395);
            this.labelControl16.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(64, 13);
            this.labelControl16.TabIndex = 24;
            this.labelControl16.Text = "Сумма вал.";
            // 
            // calcSumFactPriceForCalcCostPrice
            // 
            this.calcSumFactPriceForCalcCostPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.calcSumFactPriceForCalcCostPrice.Location = new System.Drawing.Point(3, 412);
            this.calcSumFactPriceForCalcCostPrice.Name = "calcSumFactPriceForCalcCostPrice";
            this.calcSumFactPriceForCalcCostPrice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.calcSumFactPriceForCalcCostPrice.Properties.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.calcSumFactPriceForCalcCostPrice.Properties.Appearance.Options.UseFont = true;
            this.calcSumFactPriceForCalcCostPrice.Properties.Appearance.Options.UseForeColor = true;
            this.calcSumFactPriceForCalcCostPrice.Properties.Appearance.Options.UseTextOptions = true;
            this.calcSumFactPriceForCalcCostPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.calcSumFactPriceForCalcCostPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcSumFactPriceForCalcCostPrice.Properties.DisplayFormat.FormatString = "### ### ##0.00";
            this.calcSumFactPriceForCalcCostPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcSumFactPriceForCalcCostPrice.Properties.EditFormat.FormatString = "### ### ##0.00";
            this.calcSumFactPriceForCalcCostPrice.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcSumFactPriceForCalcCostPrice.Properties.ReadOnly = true;
            this.calcSumFactPriceForCalcCostPrice.Size = new System.Drawing.Size(274, 20);
            this.calcSumFactPriceForCalcCostPrice.TabIndex = 25;
            this.calcSumFactPriceForCalcCostPrice.ToolTip = "Сумма со скидкой (по инвойсу)";
            this.calcSumFactPriceForCalcCostPrice.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 5;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.barBtnAddKLP, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.barBtnDeleteKLP, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnPrintKLPList, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.barBtnExit, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.barBtnToLotList, 4, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(961, 27);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel5, null);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // barBtnAddKLP
            // 
            this.barBtnAddKLP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.barBtnAddKLP.Image = ((System.Drawing.Image)(resources.GetObject("barBtnAddKLP.Image")));
            this.barBtnAddKLP.ImageAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.barBtnAddKLP.Location = new System.Drawing.Point(1, 1);
            this.barBtnAddKLP.Margin = new System.Windows.Forms.Padding(1);
            this.barBtnAddKLP.Name = "barBtnAddKLP";
            this.barBtnAddKLP.Size = new System.Drawing.Size(25, 25);
            this.barBtnAddKLP.TabIndex = 0;
            this.barBtnAddKLP.ToolTip = "Создать новый КЛП для заказа";
            this.barBtnAddKLP.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.barBtnAddKLP.Click += new System.EventHandler(this.barBtnAddKLP_Click);
            // 
            // barBtnDeleteKLP
            // 
            this.barBtnDeleteKLP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.barBtnDeleteKLP.Image = ((System.Drawing.Image)(resources.GetObject("barBtnDeleteKLP.Image")));
            this.barBtnDeleteKLP.ImageAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.barBtnDeleteKLP.Location = new System.Drawing.Point(28, 1);
            this.barBtnDeleteKLP.Margin = new System.Windows.Forms.Padding(1);
            this.barBtnDeleteKLP.Name = "barBtnDeleteKLP";
            this.barBtnDeleteKLP.Size = new System.Drawing.Size(25, 25);
            this.barBtnDeleteKLP.TabIndex = 1;
            this.barBtnDeleteKLP.ToolTip = "Удалить КЛП";
            this.barBtnDeleteKLP.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.barBtnDeleteKLP.Click += new System.EventHandler(this.barBtnDeleteKLP_Click);
            // 
            // btnPrintKLPList
            // 
            this.btnPrintKLPList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPrintKLPList.Image = global::ERPMercuryLotOrder.Properties.Resources.printer2;
            this.btnPrintKLPList.ImageAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnPrintKLPList.Location = new System.Drawing.Point(55, 1);
            this.btnPrintKLPList.Margin = new System.Windows.Forms.Padding(1);
            this.btnPrintKLPList.Name = "btnPrintKLPList";
            this.btnPrintKLPList.Size = new System.Drawing.Size(25, 25);
            this.btnPrintKLPList.TabIndex = 2;
            this.btnPrintKLPList.ToolTip = "Печать списка КЛП";
            this.btnPrintKLPList.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // barBtnExit
            // 
            this.barBtnExit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.barBtnExit.Image = global::ERPMercuryLotOrder.Properties.Resources.navigate_left;
            this.barBtnExit.Location = new System.Drawing.Point(82, 1);
            this.barBtnExit.Margin = new System.Windows.Forms.Padding(1);
            this.barBtnExit.Name = "barBtnExit";
            this.barBtnExit.Size = new System.Drawing.Size(140, 25);
            this.barBtnExit.TabIndex = 3;
            this.barBtnExit.Text = "К журналу заказов";
            this.barBtnExit.ToolTip = "Выход из журнала КЛП";
            this.barBtnExit.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.barBtnExit.Click += new System.EventHandler(this.barBtnExit_Click);
            // 
            // barBtnToLotList
            // 
            this.barBtnToLotList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.barBtnToLotList.Image = global::ERPMercuryLotOrder.Properties.Resources.navigate_right;
            this.barBtnToLotList.ImageAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.barBtnToLotList.Location = new System.Drawing.Point(226, 1);
            this.barBtnToLotList.Margin = new System.Windows.Forms.Padding(1);
            this.barBtnToLotList.Name = "barBtnToLotList";
            this.barBtnToLotList.Size = new System.Drawing.Size(140, 25);
            this.barBtnToLotList.TabIndex = 4;
            this.barBtnToLotList.Text = "К журналу приходов";
            this.barBtnToLotList.ToolTip = "загрузить журнал приходов на склад для выбранного КЛП";
            this.barBtnToLotList.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.barBtnToLotList.Click += new System.EventHandler(this.barBtnToLotList_Click);
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabPage = this.tabPageKLPList;
            this.tabControl.Size = new System.Drawing.Size(970, 622);
            this.tabControl.TabIndex = 4;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageKLPList,
            this.tabPageKLPEditor,
            this.tabPageLotList});
            this.tabControl.Text = "xtraTabControl1";
            // 
            // tabPageKLPList
            // 
            this.tabPageKLPList.Controls.Add(this.tableLayoutPanelKLPList);
            this.tabPageKLPList.Name = "tabPageKLPList";
            this.tabPageKLPList.Size = new System.Drawing.Size(961, 591);
            this.tabPageKLPList.Text = "xtraTabPage1";
            // 
            // tabPageKLPEditor
            // 
            this.tabPageKLPEditor.Controls.Add(this.tableLayoutPanelBackground);
            this.tabPageKLPEditor.Name = "tabPageKLPEditor";
            this.tabPageKLPEditor.Size = new System.Drawing.Size(961, 591);
            this.tabPageKLPEditor.Text = "xtraTabPage2";
            // 
            // tableLayoutPanelBackground
            // 
            this.tableLayoutPanelBackground.ColumnCount = 1;
            this.tableLayoutPanelBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBackground.Controls.Add(this.panelProgressBar, 0, 3);
            this.tableLayoutPanelBackground.Controls.Add(this.gridControl, 0, 6);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel6, 0, 5);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel8, 0, 4);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel1, 0, 7);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel9, 0, 2);
            this.tableLayoutPanelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBackground.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelBackground.Name = "tableLayoutPanelBackground";
            this.tableLayoutPanelBackground.RowCount = 8;
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelBackground.Size = new System.Drawing.Size(961, 591);
            this.toolTipController.SetSuperTip(this.tableLayoutPanelBackground, null);
            this.tableLayoutPanelBackground.TabIndex = 1;
            // 
            // panelProgressBar
            // 
            this.panelProgressBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelProgressBar.Controls.Add(this.progressBarControl1);
            this.panelProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProgressBar.Location = new System.Drawing.Point(3, 140);
            this.panelProgressBar.Name = "panelProgressBar";
            this.panelProgressBar.Size = new System.Drawing.Size(955, 25);
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
            this.progressBarControl1.Size = new System.Drawing.Size(947, 16);
            this.progressBarControl1.TabIndex = 0;
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.contextMenuStripEditor;
            this.gridControl.DataMember = "KLPItems";
            this.gridControl.DataSource = this.dataSet;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(3, 223);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditProduct,
            this.repositoryItemCalcEditOrderedQuantity,
            this.repositoryItemSpinEditDiscount,
            this.repositoryItemLookUpEditCountryProduction});
            this.gridControl.Size = new System.Drawing.Size(955, 334);
            this.gridControl.TabIndex = 26;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // contextMenuStripEditor
            // 
            this.contextMenuStripEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewLotFromKLP});
            this.contextMenuStripEditor.Name = "contextMenuStrip";
            this.contextMenuStripEditor.Size = new System.Drawing.Size(148, 26);
            this.toolTipController.SetSuperTip(this.contextMenuStripEditor, null);
            this.contextMenuStripEditor.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripEditor_Opening);
            // 
            // menuItemNewLotFromKLP
            // 
            this.menuItemNewLotFromKLP.Name = "menuItemNewLotFromKLP";
            this.menuItemNewLotFromKLP.Size = new System.Drawing.Size(147, 22);
            this.menuItemNewLotFromKLP.Text = "Новый приход";
            this.menuItemNewLotFromKLP.Click += new System.EventHandler(this.menuItemNewLotFromKLP_Click);
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "dataSet";
            this.dataSet.Relations.AddRange(new System.Data.DataRelation[] {
            new System.Data.DataRelation("rlOrderItmsProduct", "SrcForKlpItems", "KLPItems", new string[] {
                        "ProductID"}, new string[] {
                        "ProductID"}, false)});
            this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.KLPItems,
            this.SrcForKlpItems,
            this.CountryProduction});
            // 
            // KLPItems
            // 
            this.KLPItems.Columns.AddRange(new System.Data.DataColumn[] {
            this.KLPItemsID,
            this.ProductID,
            this.MeasureID,
            this.Quantity,
            this.FactQuantity,
            this.CurrencyPrice,
            this.DiscountVendorPrice,
            this.AllDiscountVendorPrice,
            this.FactAllDiscountVendorPrice,
            this.AllCurrencyPrice,
            this.FactAllCurrencyPrice,
            this.KLPItems_MeasureName,
            this.KLPItems_PartsArticle,
            this.KLPItems_PartsName,
            this.LotOrderItems_Guid,
            this.KLPItems_Id,
            this.LotOrderItems_QuantityInDoc,
            this.LotOrderItems_QuantityInKLP,
            this.CountryProductionID,
            this.KLPItems_CountryProductionName,
            this.CustomTarifPercent});
            this.KLPItems.TableName = "KLPItems";
            // 
            // KLPItemsID
            // 
            this.KLPItemsID.Caption = "ID";
            this.KLPItemsID.ColumnName = "KLPItemsID";
            this.KLPItemsID.DataType = typeof(System.Guid);
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
            // Quantity
            // 
            this.Quantity.Caption = "Кол-во";
            this.Quantity.ColumnName = "Quantity";
            this.Quantity.DataType = typeof(decimal);
            // 
            // FactQuantity
            // 
            this.FactQuantity.Caption = "Количество факт.";
            this.FactQuantity.ColumnName = "FactQuantity";
            this.FactQuantity.DataType = typeof(decimal);
            // 
            // CurrencyPrice
            // 
            this.CurrencyPrice.Caption = "Себестоимость";
            this.CurrencyPrice.ColumnName = "CurrencyPrice";
            this.CurrencyPrice.DataType = typeof(double);
            // 
            // DiscountVendorPrice
            // 
            this.DiscountVendorPrice.Caption = "Тариф поставщика с учетом скидки";
            this.DiscountVendorPrice.ColumnName = "DiscountVendorPrice";
            this.DiscountVendorPrice.DataType = typeof(double);
            // 
            // AllDiscountVendorPrice
            // 
            this.AllDiscountVendorPrice.Caption = "Сумма";
            this.AllDiscountVendorPrice.ColumnName = "AllDiscountVendorPrice";
            this.AllDiscountVendorPrice.DataType = typeof(double);
            this.AllDiscountVendorPrice.Expression = "DiscountVendorPrice * Quantity";
            this.AllDiscountVendorPrice.ReadOnly = true;
            // 
            // FactAllDiscountVendorPrice
            // 
            this.FactAllDiscountVendorPrice.Caption = "Сумма (факт.)";
            this.FactAllDiscountVendorPrice.ColumnName = "FactAllDiscountVendorPrice";
            this.FactAllDiscountVendorPrice.DataType = typeof(double);
            this.FactAllDiscountVendorPrice.Expression = "DiscountVendorPrice * FactQuantity";
            this.FactAllDiscountVendorPrice.ReadOnly = true;
            // 
            // AllCurrencyPrice
            // 
            this.AllCurrencyPrice.Caption = "Сумма по с/с";
            this.AllCurrencyPrice.ColumnName = "AllCurrencyPrice";
            this.AllCurrencyPrice.DataType = typeof(double);
            this.AllCurrencyPrice.Expression = "CurrencyPrice * Quantity";
            this.AllCurrencyPrice.ReadOnly = true;
            // 
            // FactAllCurrencyPrice
            // 
            this.FactAllCurrencyPrice.Caption = "Сумма по с/с (факт.)";
            this.FactAllCurrencyPrice.ColumnName = "FactAllCurrencyPrice";
            this.FactAllCurrencyPrice.DataType = typeof(double);
            this.FactAllCurrencyPrice.Expression = "CurrencyPrice * FactQuantity";
            this.FactAllCurrencyPrice.ReadOnly = true;
            // 
            // KLPItems_MeasureName
            // 
            this.KLPItems_MeasureName.Caption = "Ед. изм.";
            this.KLPItems_MeasureName.ColumnName = "KLPItems_MeasureName";
            // 
            // KLPItems_PartsArticle
            // 
            this.KLPItems_PartsArticle.ColumnName = "KLPItems_PartsArticle";
            // 
            // KLPItems_PartsName
            // 
            this.KLPItems_PartsName.ColumnName = "KLPItems_PartsName";
            // 
            // LotOrderItems_Guid
            // 
            this.LotOrderItems_Guid.Caption = "ID позиции в заказе";
            this.LotOrderItems_Guid.ColumnName = "LotOrderItems_Guid";
            this.LotOrderItems_Guid.DataType = typeof(System.Guid);
            // 
            // KLPItems_Id
            // 
            this.KLPItems_Id.ColumnName = "KLPItems_Id";
            this.KLPItems_Id.DataType = typeof(int);
            // 
            // LotOrderItems_QuantityInDoc
            // 
            this.LotOrderItems_QuantityInDoc.Caption = "LotOrderItems_QuantityInDoc";
            this.LotOrderItems_QuantityInDoc.ColumnName = "LotOrderItems_QuantityInDoc";
            this.LotOrderItems_QuantityInDoc.DataType = typeof(decimal);
            // 
            // LotOrderItems_QuantityInKLP
            // 
            this.LotOrderItems_QuantityInKLP.ColumnName = "LotOrderItems_QuantityInKLP";
            this.LotOrderItems_QuantityInKLP.DataType = typeof(decimal);
            // 
            // CountryProductionID
            // 
            this.CountryProductionID.ColumnName = "CountryProductionID";
            this.CountryProductionID.DataType = typeof(System.Guid);
            // 
            // KLPItems_CountryProductionName
            // 
            this.KLPItems_CountryProductionName.ColumnName = "KLPItems_CountryProductionName";
            // 
            // CustomTarifPercent
            // 
            this.CustomTarifPercent.ColumnName = "CustomTarifPercent";
            this.CustomTarifPercent.DataType = typeof(double);
            // 
            // SrcForKlpItems
            // 
            this.SrcForKlpItems.Columns.AddRange(new System.Data.DataColumn[] {
            this.ProductGuid,
            this.ProductShortName,
            this.OrderItems_OrderQuantity,
            this.Product_MeasureID,
            this.Product_MeasureName,
            this.ProductArticle,
            this.ProductFullName,
            this.OrderItems_ConfirmQuantity,
            this.OrderItems_Quantity,
            this.OrderItems_QuantityInKLP,
            this.OrderItems_ID,
            this.OrderItems_CountryProductionID,
            this.OrderItems_CountryProductionName,
            this.OrderItems_CustomTarifPercent});
            this.SrcForKlpItems.TableName = "SrcForKlpItems";
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
            // OrderItems_OrderQuantity
            // 
            this.OrderItems_OrderQuantity.Caption = "Кол-во";
            this.OrderItems_OrderQuantity.ColumnName = "OrderItems_OrderQuantity";
            this.OrderItems_OrderQuantity.DataType = typeof(decimal);
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
            // OrderItems_ConfirmQuantity
            // 
            this.OrderItems_ConfirmQuantity.Caption = "Кол-во (подтв.)";
            this.OrderItems_ConfirmQuantity.ColumnName = "OrderItems_ConfirmQuantity";
            this.OrderItems_ConfirmQuantity.DataType = typeof(decimal);
            // 
            // OrderItems_Quantity
            // 
            this.OrderItems_Quantity.Caption = "Кол-во";
            this.OrderItems_Quantity.ColumnName = "OrderItems_Quantity";
            this.OrderItems_Quantity.DataType = typeof(decimal);
            // 
            // OrderItems_QuantityInKLP
            // 
            this.OrderItems_QuantityInKLP.Caption = "Кол-во в КЛП";
            this.OrderItems_QuantityInKLP.ColumnName = "OrderItems_QuantityInKLP";
            this.OrderItems_QuantityInKLP.DataType = typeof(decimal);
            // 
            // OrderItems_ID
            // 
            this.OrderItems_ID.ColumnName = "OrderItems_ID";
            this.OrderItems_ID.DataType = typeof(System.Guid);
            // 
            // OrderItems_CountryProductionID
            // 
            this.OrderItems_CountryProductionID.ColumnName = "OrderItems_CountryProductionID";
            this.OrderItems_CountryProductionID.DataType = typeof(System.Guid);
            // 
            // OrderItems_CountryProductionName
            // 
            this.OrderItems_CountryProductionName.ColumnName = "OrderItems_CountryProductionName";
            // 
            // OrderItems_CustomTarifPercent
            // 
            this.OrderItems_CustomTarifPercent.ColumnName = "OrderItems_CustomTarifPercent";
            this.OrderItems_CustomTarifPercent.DataType = typeof(double);
            // 
            // CountryProduction
            // 
            this.CountryProduction.Columns.AddRange(new System.Data.DataColumn[] {
            this.CountryProductionGuid,
            this.CountryProductionName});
            this.CountryProduction.TableName = "CountryProduction";
            // 
            // CountryProductionGuid
            // 
            this.CountryProductionGuid.ColumnName = "CountryProductionID";
            this.CountryProductionGuid.DataType = typeof(System.Guid);
            // 
            // CountryProductionName
            // 
            this.CountryProductionName.ColumnName = "CountryProductionName";
            // 
            // gridView
            // 
            this.gridView.ColumnPanelRowHeight = 60;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKLPItemsID,
            this.colKLPItems_Id,
            this.colProductID,
            this.colMeasureID,
            this.colOrderItems_MeasureName,
            this.colQuantity,
            this.colFactQuantity,
            this.colDiscountVendorPrice,
            this.colCustomTarifPercent,
            this.colCurrencyPrice,
            this.colAllDiscountVendorPrice,
            this.colFactAllDiscountVendorPrice,
            this.colAllCurrencyPrice,
            this.colFactAllCurrencyPrice,
            this.colKLPItems_PartsName,
            this.colKLPItems_PartsArticle,
            this.colLotOrderItems_QuantityInDoc,
            this.colLotOrderItems_QuantityInKLP,
            this.colLotOrderItems_Guid,
            this.colCountryProductionID,
            this.colKLPItems_CountryProductionName});
            this.gridView.CustomizationFormBounds = new System.Drawing.Rectangle(1062, 711, 208, 189);
            styleFormatCondition9.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition9.Appearance.Options.UseBackColor = true;
            styleFormatCondition9.Column = this.colQuantity;
            styleFormatCondition9.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition9.Value1 = 0D;
            styleFormatCondition10.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition10.Appearance.Options.UseBackColor = true;
            styleFormatCondition10.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition10.Value1 = "0";
            styleFormatCondition11.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition11.Appearance.Options.UseBackColor = true;
            styleFormatCondition11.Column = this.colFactQuantity;
            styleFormatCondition11.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition11.Value1 = "0";
            styleFormatCondition12.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition12.Appearance.Options.UseBackColor = true;
            styleFormatCondition12.Column = this.colDiscountVendorPrice;
            styleFormatCondition12.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition12.Value1 = "0";
            styleFormatCondition13.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition13.Appearance.Options.UseBackColor = true;
            styleFormatCondition13.Column = this.colCurrencyPrice;
            styleFormatCondition13.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition13.Value1 = "0";
            styleFormatCondition14.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition14.Appearance.Options.UseBackColor = true;
            styleFormatCondition14.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition14.Value1 = "0";
            styleFormatCondition15.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition15.Appearance.Options.UseBackColor = true;
            styleFormatCondition15.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition15.Value1 = "0";
            styleFormatCondition16.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition16.Appearance.Options.UseBackColor = true;
            styleFormatCondition16.Condition = DevExpress.XtraGrid.FormatConditionEnum.Less;
            styleFormatCondition16.Value1 = "0";
            this.gridView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition9,
            styleFormatCondition10,
            styleFormatCondition11,
            styleFormatCondition12,
            styleFormatCondition13,
            styleFormatCondition14,
            styleFormatCondition15,
            styleFormatCondition16});
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "OrderID", null, "")});
            this.gridView.IndicatorWidth = 50;
            this.gridView.Name = "gridView";
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView_CustomDrawRowIndicator);
            this.gridView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView_CustomDrawCell);
            this.gridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView_InitNewRow);
            this.gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_CellValueChanged);
            this.gridView.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewProductList_CellValueChanging);
            this.gridView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_InvalidRowException);
            this.gridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_ValidateRow);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            // 
            // colKLPItemsID
            // 
            this.colKLPItemsID.AppearanceHeader.Options.UseTextOptions = true;
            this.colKLPItemsID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colKLPItemsID.Caption = "KLPItemsID";
            this.colKLPItemsID.FieldName = "KLPItemsID";
            this.colKLPItemsID.Name = "colKLPItemsID";
            // 
            // colKLPItems_Id
            // 
            this.colKLPItems_Id.Caption = "KLPItems_Id";
            this.colKLPItems_Id.FieldName = "KLPItems_Id";
            this.colKLPItems_Id.Name = "colKLPItems_Id";
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
            // colOrderItems_MeasureName
            // 
            this.colOrderItems_MeasureName.AppearanceHeader.Options.UseTextOptions = true;
            this.colOrderItems_MeasureName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOrderItems_MeasureName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colOrderItems_MeasureName.Caption = "Ед изм.";
            this.colOrderItems_MeasureName.FieldName = "KLPItems_MeasureName";
            this.colOrderItems_MeasureName.MinWidth = 55;
            this.colOrderItems_MeasureName.Name = "colOrderItems_MeasureName";
            this.colOrderItems_MeasureName.OptionsColumn.AllowEdit = false;
            this.colOrderItems_MeasureName.OptionsColumn.ReadOnly = true;
            this.colOrderItems_MeasureName.Visible = true;
            this.colOrderItems_MeasureName.VisibleIndex = 1;
            this.colOrderItems_MeasureName.Width = 55;
            // 
            // colCustomTarifPercent
            // 
            this.colCustomTarifPercent.Caption = "Тамож. тариф, %";
            this.colCustomTarifPercent.ColumnEdit = this.repositoryItemCalcEditOrderedQuantity;
            this.colCustomTarifPercent.DisplayFormat.FormatString = "# ### ### ##0.00";
            this.colCustomTarifPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCustomTarifPercent.FieldName = "CustomTarifPercent";
            this.colCustomTarifPercent.Name = "colCustomTarifPercent";
            this.colCustomTarifPercent.Visible = true;
            this.colCustomTarifPercent.VisibleIndex = 8;
            // 
            // colAllDiscountVendorPrice
            // 
            this.colAllDiscountVendorPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colAllDiscountVendorPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAllDiscountVendorPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colAllDiscountVendorPrice.Caption = "Сумма";
            this.colAllDiscountVendorPrice.DisplayFormat.FormatString = "# ### ### ##0.00";
            this.colAllDiscountVendorPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAllDiscountVendorPrice.FieldName = "AllDiscountVendorPrice";
            this.colAllDiscountVendorPrice.MinWidth = 150;
            this.colAllDiscountVendorPrice.Name = "colAllDiscountVendorPrice";
            this.colAllDiscountVendorPrice.OptionsColumn.AllowEdit = false;
            this.colAllDiscountVendorPrice.OptionsColumn.ReadOnly = true;
            this.colAllDiscountVendorPrice.SummaryItem.DisplayFormat = "Тариф: {0:### ### ##0.00}";
            this.colAllDiscountVendorPrice.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colAllDiscountVendorPrice.Width = 150;
            // 
            // colFactAllDiscountVendorPrice
            // 
            this.colFactAllDiscountVendorPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colFactAllDiscountVendorPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFactAllDiscountVendorPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colFactAllDiscountVendorPrice.Caption = "Сумма (факт.)";
            this.colFactAllDiscountVendorPrice.DisplayFormat.FormatString = "# ### ### ##0.00";
            this.colFactAllDiscountVendorPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFactAllDiscountVendorPrice.FieldName = "FactAllDiscountVendorPrice";
            this.colFactAllDiscountVendorPrice.MinWidth = 150;
            this.colFactAllDiscountVendorPrice.Name = "colFactAllDiscountVendorPrice";
            this.colFactAllDiscountVendorPrice.OptionsColumn.AllowEdit = false;
            this.colFactAllDiscountVendorPrice.OptionsColumn.ReadOnly = true;
            this.colFactAllDiscountVendorPrice.SummaryItem.DisplayFormat = "Сумма: {0:### ### ##0.00}";
            this.colFactAllDiscountVendorPrice.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colFactAllDiscountVendorPrice.Width = 150;
            // 
            // colAllCurrencyPrice
            // 
            this.colAllCurrencyPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colAllCurrencyPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAllCurrencyPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colAllCurrencyPrice.Caption = "Сумма (для расчёта с/с)";
            this.colAllCurrencyPrice.DisplayFormat.FormatString = "### ### ##0.00";
            this.colAllCurrencyPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAllCurrencyPrice.FieldName = "AllCurrencyPrice";
            this.colAllCurrencyPrice.MinWidth = 150;
            this.colAllCurrencyPrice.Name = "colAllCurrencyPrice";
            this.colAllCurrencyPrice.OptionsColumn.ReadOnly = true;
            this.colAllCurrencyPrice.SummaryItem.DisplayFormat = "Подтв-но: {0:### ### ##0.00}";
            this.colAllCurrencyPrice.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colAllCurrencyPrice.Visible = true;
            this.colAllCurrencyPrice.VisibleIndex = 9;
            this.colAllCurrencyPrice.Width = 150;
            // 
            // colFactAllCurrencyPrice
            // 
            this.colFactAllCurrencyPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colFactAllCurrencyPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFactAllCurrencyPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colFactAllCurrencyPrice.Caption = "Сумма (для расчёта с/с) факт.";
            this.colFactAllCurrencyPrice.DisplayFormat.FormatString = "### ### ##0.00";
            this.colFactAllCurrencyPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFactAllCurrencyPrice.FieldName = "FactAllCurrencyPrice";
            this.colFactAllCurrencyPrice.MinWidth = 150;
            this.colFactAllCurrencyPrice.Name = "colFactAllCurrencyPrice";
            this.colFactAllCurrencyPrice.OptionsColumn.ReadOnly = true;
            this.colFactAllCurrencyPrice.SummaryItem.DisplayFormat = "Сумма по с/с: {0:### ### ##0.00}";
            this.colFactAllCurrencyPrice.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colFactAllCurrencyPrice.Visible = true;
            this.colFactAllCurrencyPrice.VisibleIndex = 6;
            this.colFactAllCurrencyPrice.Width = 150;
            // 
            // colKLPItems_PartsName
            // 
            this.colKLPItems_PartsName.Caption = "colOrderItems_PartsName";
            this.colKLPItems_PartsName.FieldName = "KLPItems_PartsName";
            this.colKLPItems_PartsName.Name = "colKLPItems_PartsName";
            // 
            // colKLPItems_PartsArticle
            // 
            this.colKLPItems_PartsArticle.Caption = "colOrderItems_PartsArticle";
            this.colKLPItems_PartsArticle.FieldName = "KLPItems_PartsArticle";
            this.colKLPItems_PartsArticle.Name = "colKLPItems_PartsArticle";
            // 
            // colLotOrderItems_QuantityInDoc
            // 
            this.colLotOrderItems_QuantityInDoc.Caption = "LotOrderItems_QuantityInDoc";
            this.colLotOrderItems_QuantityInDoc.FieldName = "LotOrderItems_QuantityInDoc";
            this.colLotOrderItems_QuantityInDoc.Name = "colLotOrderItems_QuantityInDoc";
            // 
            // colLotOrderItems_QuantityInKLP
            // 
            this.colLotOrderItems_QuantityInKLP.Caption = "colLotOrderItems_QuantityInKLP";
            this.colLotOrderItems_QuantityInKLP.FieldName = "LotOrderItems_QuantityInKLP";
            this.colLotOrderItems_QuantityInKLP.Name = "colLotOrderItems_QuantityInKLP";
            // 
            // colLotOrderItems_Guid
            // 
            this.colLotOrderItems_Guid.Caption = "colLotOrderItems_Guid";
            this.colLotOrderItems_Guid.FieldName = "LotOrderItems_Guid";
            this.colLotOrderItems_Guid.Name = "colLotOrderItems_Guid";
            // 
            // colCountryProductionID
            // 
            this.colCountryProductionID.Caption = "Страна пр-ва";
            this.colCountryProductionID.ColumnEdit = this.repositoryItemLookUpEditCountryProduction;
            this.colCountryProductionID.FieldName = "CountryProductionID";
            this.colCountryProductionID.Name = "colCountryProductionID";
            this.colCountryProductionID.Visible = true;
            this.colCountryProductionID.VisibleIndex = 7;
            // 
            // repositoryItemLookUpEditCountryProduction
            // 
            this.repositoryItemLookUpEditCountryProduction.Appearance.Options.UseBackColor = true;
            this.repositoryItemLookUpEditCountryProduction.AutoHeight = false;
            this.repositoryItemLookUpEditCountryProduction.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditCountryProduction.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CountryProductionName", "Страна пр-ва", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.repositoryItemLookUpEditCountryProduction.DisplayMember = "CountryProductionName";
            this.repositoryItemLookUpEditCountryProduction.Name = "repositoryItemLookUpEditCountryProduction";
            this.repositoryItemLookUpEditCountryProduction.NullText = "";
            this.repositoryItemLookUpEditCountryProduction.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.repositoryItemLookUpEditCountryProduction.ValidateOnEnterKey = true;
            this.repositoryItemLookUpEditCountryProduction.ValueMember = "CountryProductionID";
            // 
            // colKLPItems_CountryProductionName
            // 
            this.colKLPItems_CountryProductionName.Caption = "Страна пр-ва";
            this.colKLPItems_CountryProductionName.FieldName = "KLPItems_CountryProductionName";
            this.colKLPItems_CountryProductionName.Name = "colKLPItems_CountryProductionName";
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
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 7;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 288F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.controlNavigator, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 195);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(961, 25);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel6, null);
            this.tableLayoutPanel6.TabIndex = 25;
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
            this.tableLayoutPanel8.Controls.Add(this.labelControl8, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.cboxProductTradeMark, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.pictureFilter, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.labelControl14, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.labelControl9, 4, 0);
            this.tableLayoutPanel8.Controls.Add(this.cboxProductType, 5, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 168);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(961, 27);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel8, null);
            this.tableLayoutPanel8.TabIndex = 22;
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl8.Location = new System.Drawing.Point(31, 7);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(148, 13);
            this.labelControl8.TabIndex = 28;
            this.labelControl8.Text = "Фильтрация списка товаров:";
            // 
            // cboxProductTradeMark
            // 
            this.cboxProductTradeMark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxProductTradeMark.Location = new System.Drawing.Point(311, 3);
            this.cboxProductTradeMark.Name = "cboxProductTradeMark";
            this.cboxProductTradeMark.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxProductTradeMark.Properties.PopupSizeable = true;
            this.cboxProductTradeMark.Properties.Sorted = true;
            this.cboxProductTradeMark.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxProductTradeMark.Size = new System.Drawing.Size(259, 20);
            this.cboxProductTradeMark.TabIndex = 29;
            this.cboxProductTradeMark.ToolTip = "Товарная марка";
            this.cboxProductTradeMark.ToolTipController = this.toolTipController;
            this.cboxProductTradeMark.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cboxProductTradeMark.SelectedValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
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
            // labelControl14
            // 
            this.labelControl14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl14.Location = new System.Drawing.Point(211, 7);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(85, 13);
            this.labelControl14.TabIndex = 27;
            this.labelControl14.Text = "Товарная марка:";
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl9.Location = new System.Drawing.Point(576, 7);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(90, 13);
            this.labelControl9.TabIndex = 28;
            this.labelControl9.Text = "Товарная группа:";
            // 
            // cboxProductType
            // 
            this.cboxProductType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxProductType.Location = new System.Drawing.Point(676, 3);
            this.cboxProductType.Name = "cboxProductType";
            this.cboxProductType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxProductType.Properties.PopupSizeable = true;
            this.cboxProductType.Properties.Sorted = true;
            this.cboxProductType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxProductType.Size = new System.Drawing.Size(259, 20);
            this.cboxProductType.TabIndex = 30;
            this.cboxProductType.ToolTip = "Товарная группа";
            this.cboxProductType.ToolTipController = this.toolTipController;
            this.cboxProductType.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cboxProductType.SelectedValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 560);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(961, 31);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel1, null);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(883, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.ToolTip = "Отменить изменения";
            this.btnCancel.ToolTipController = this.toolTipController;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(801, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "ОК";
            this.btnSave.ToolTip = "Сохранить изменения";
            this.btnSave.ToolTipController = this.toolTipController;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            this.btnPrint.ToolTip = "Печать КЛП";
            this.btnPrint.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 9;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.labelControl10, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelControl11, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.cboxKLPState, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelControl19, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.KLPDate, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtKLPNum, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.checkKLPCostIsCalc, 7, 0);
            this.tableLayoutPanel4.Controls.Add(this.checkKLPIsActive, 6, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(961, 27);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel4, null);
            this.tableLayoutPanel4.TabIndex = 19;
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl10.Location = new System.Drawing.Point(3, 7);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(41, 13);
            this.labelControl10.TabIndex = 27;
            this.labelControl10.Text = "КЛП №:";
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl11.Location = new System.Drawing.Point(192, 7);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(30, 13);
            this.labelControl11.TabIndex = 20;
            this.labelControl11.Text = "Дата:";
            // 
            // cboxKLPState
            // 
            this.cboxKLPState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxKLPState.Location = new System.Drawing.Point(450, 3);
            this.cboxKLPState.Name = "cboxKLPState";
            this.cboxKLPState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxKLPState.Properties.PopupSizeable = true;
            this.cboxKLPState.Properties.Sorted = true;
            this.cboxKLPState.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxKLPState.Size = new System.Drawing.Size(139, 20);
            this.cboxKLPState.TabIndex = 2;
            this.cboxKLPState.ToolTip = "Текущее состояние КЛП";
            this.cboxKLPState.ToolTipController = this.toolTipController;
            this.cboxKLPState.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cboxKLPState.SelectedValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
            // 
            // labelControl19
            // 
            this.labelControl19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl19.Location = new System.Drawing.Point(381, 7);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(58, 13);
            this.labelControl19.TabIndex = 32;
            this.labelControl19.Text = "Состояние:";
            // 
            // KLPDate
            // 
            this.KLPDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.KLPDate.EditValue = null;
            this.KLPDate.Location = new System.Drawing.Point(261, 3);
            this.KLPDate.Name = "KLPDate";
            this.KLPDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.KLPDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.KLPDate.Size = new System.Drawing.Size(114, 20);
            this.KLPDate.TabIndex = 1;
            this.KLPDate.ToolTip = "Дата оформления КЛП";
            this.KLPDate.ToolTipController = this.toolTipController;
            this.KLPDate.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.KLPDate.EditValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
            this.KLPDate.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtOrderPropertie_EditValueChanging);
            // 
            // txtKLPNum
            // 
            this.txtKLPNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKLPNum.Location = new System.Drawing.Point(72, 3);
            this.txtKLPNum.Name = "txtKLPNum";
            this.txtKLPNum.Size = new System.Drawing.Size(114, 20);
            this.txtKLPNum.TabIndex = 0;
            this.txtKLPNum.ToolTip = "Номер КЛП";
            this.txtKLPNum.ToolTipController = this.toolTipController;
            this.txtKLPNum.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtKLPNum.EditValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
            this.txtKLPNum.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtOrderPropertie_EditValueChanging);
            // 
            // checkKLPCostIsCalc
            // 
            this.checkKLPCostIsCalc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkKLPCostIsCalc.Location = new System.Drawing.Point(667, 4);
            this.checkKLPCostIsCalc.Name = "checkKLPCostIsCalc";
            this.checkKLPCostIsCalc.Properties.Caption = "С/С рассчитана";
            this.checkKLPCostIsCalc.Size = new System.Drawing.Size(121, 19);
            this.checkKLPCostIsCalc.TabIndex = 28;
            this.checkKLPCostIsCalc.ToolTip = "Признак \"Себестоимость рассчитана\"";
            this.checkKLPCostIsCalc.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // checkKLPIsActive
            // 
            this.checkKLPIsActive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkKLPIsActive.Location = new System.Drawing.Point(595, 4);
            this.checkKLPIsActive.Name = "checkKLPIsActive";
            this.checkKLPIsActive.Properties.Caption = "Активен";
            this.checkKLPIsActive.Size = new System.Drawing.Size(66, 19);
            this.checkKLPIsActive.TabIndex = 3;
            this.checkKLPIsActive.ToolTip = "Признак \"КЛП активен\"";
            this.checkKLPIsActive.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.checkKLPIsActive.EditValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
            this.checkKLPIsActive.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtOrderPropertie_EditValueChanging);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 7;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 309F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.labelControl18, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.labelControl12, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.KLPStartAccepting, 3, 0);
            this.tableLayoutPanel7.Controls.Add(this.KLPEndAccepting, 5, 0);
            this.tableLayoutPanel7.Controls.Add(this.labelControl21, 4, 0);
            this.tableLayoutPanel7.Controls.Add(this.cboxStock, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(961, 27);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel7, null);
            this.tableLayoutPanel7.TabIndex = 20;
            // 
            // labelControl18
            // 
            this.labelControl18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl18.Location = new System.Drawing.Point(3, 7);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(36, 13);
            this.labelControl18.TabIndex = 28;
            this.labelControl18.Text = "Склад:";
            // 
            // labelControl12
            // 
            this.labelControl12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl12.Location = new System.Drawing.Point(381, 7);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(86, 13);
            this.labelControl12.TabIndex = 26;
            this.labelControl12.Text = "Начало приёмки:";
            // 
            // KLPStartAccepting
            // 
            this.KLPStartAccepting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.KLPStartAccepting.EditValue = null;
            this.KLPStartAccepting.Location = new System.Drawing.Point(475, 3);
            this.KLPStartAccepting.Name = "KLPStartAccepting";
            this.KLPStartAccepting.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.KLPStartAccepting.Properties.DisplayFormat.FormatString = "dd.mm.yyyy hh:mm:ss";
            this.KLPStartAccepting.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.KLPStartAccepting.Properties.EditFormat.FormatString = "dd.mm.yyyy hh:mm:ss";
            this.KLPStartAccepting.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.KLPStartAccepting.Properties.Mask.EditMask = "dd.mm.yyyy hh:mm:ss";
            this.KLPStartAccepting.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.KLPStartAccepting.Size = new System.Drawing.Size(154, 20);
            this.KLPStartAccepting.TabIndex = 2;
            this.KLPStartAccepting.ToolTip = "дата и время начала приёмки товара";
            this.KLPStartAccepting.ToolTipController = this.toolTipController;
            this.KLPStartAccepting.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.KLPStartAccepting.EditValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
            this.KLPStartAccepting.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtOrderPropertie_EditValueChanging);
            // 
            // KLPEndAccepting
            // 
            this.KLPEndAccepting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.KLPEndAccepting.EditValue = null;
            this.KLPEndAccepting.Location = new System.Drawing.Point(746, 3);
            this.KLPEndAccepting.Name = "KLPEndAccepting";
            this.KLPEndAccepting.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.KLPEndAccepting.Properties.DisplayFormat.FormatString = "dd.mm.yyyy hh:mm:ss";
            this.KLPEndAccepting.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.KLPEndAccepting.Properties.EditFormat.FormatString = "dd.mm.yyyy hh:mm:ss";
            this.KLPEndAccepting.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.KLPEndAccepting.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.KLPEndAccepting.Size = new System.Drawing.Size(164, 20);
            this.KLPEndAccepting.TabIndex = 29;
            this.KLPEndAccepting.ToolTip = "дата и время окончания приёмки товара";
            this.KLPEndAccepting.ToolTipController = this.toolTipController;
            this.KLPEndAccepting.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.KLPEndAccepting.EditValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
            this.KLPEndAccepting.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtOrderPropertie_EditValueChanging);
            // 
            // labelControl21
            // 
            this.labelControl21.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl21.Location = new System.Drawing.Point(635, 7);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(105, 13);
            this.labelControl21.TabIndex = 28;
            this.labelControl21.Text = "Окончание приёмки:";
            // 
            // cboxStock
            // 
            this.cboxStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxStock.Location = new System.Drawing.Point(72, 3);
            this.cboxStock.Name = "cboxStock";
            this.cboxStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxStock.Properties.PopupSizeable = true;
            this.cboxStock.Properties.Sorted = true;
            this.cboxStock.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxStock.Size = new System.Drawing.Size(303, 20);
            this.cboxStock.TabIndex = 0;
            this.cboxStock.ToolTip = "Склад приёмки товара";
            this.cboxStock.ToolTipController = this.toolTipController;
            this.cboxStock.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cboxStock.SelectedValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.txtDescription, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.labelControl20, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 54);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(961, 83);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel9, null);
            this.tableLayoutPanel9.TabIndex = 21;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(72, 3);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(886, 77);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.ToolTip = "Примечание";
            this.txtDescription.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtDescription.EditValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
            this.txtDescription.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtOrderPropertie_EditValueChanging);
            // 
            // labelControl20
            // 
            this.labelControl20.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl20.Location = new System.Drawing.Point(3, 35);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(65, 13);
            this.labelControl20.TabIndex = 29;
            this.labelControl20.Text = "Примечание:";
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 6;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Controls.Add(this.barBtnEdit, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.barBtnAdd, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.barBtnDelete, 2, 0);
            this.tableLayoutPanel13.Controls.Add(this.simpleButton1, 3, 0);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(952, 31);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel13, null);
            this.tableLayoutPanel13.TabIndex = 2;
            // 
            // barBtnEdit
            // 
            this.barBtnEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.barBtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("barBtnEdit.Image")));
            this.barBtnEdit.ImageAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.barBtnEdit.Location = new System.Drawing.Point(28, 4);
            this.barBtnEdit.Margin = new System.Windows.Forms.Padding(1);
            this.barBtnEdit.Name = "barBtnEdit";
            this.barBtnEdit.Size = new System.Drawing.Size(23, 23);
            this.barBtnEdit.TabIndex = 10;
            this.barBtnEdit.ToolTip = "Редактировать заказ";
            this.barBtnEdit.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // barBtnAdd
            // 
            this.barBtnAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.barBtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("barBtnAdd.Image")));
            this.barBtnAdd.ImageAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.barBtnAdd.Location = new System.Drawing.Point(1, 4);
            this.barBtnAdd.Margin = new System.Windows.Forms.Padding(1);
            this.barBtnAdd.Name = "barBtnAdd";
            this.barBtnAdd.Size = new System.Drawing.Size(23, 23);
            this.barBtnAdd.TabIndex = 9;
            this.barBtnAdd.ToolTip = "Создать новый заказ";
            this.barBtnAdd.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // barBtnDelete
            // 
            this.barBtnDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.barBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("barBtnDelete.Image")));
            this.barBtnDelete.ImageAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.barBtnDelete.Location = new System.Drawing.Point(55, 4);
            this.barBtnDelete.Margin = new System.Windows.Forms.Padding(1);
            this.barBtnDelete.Name = "barBtnDelete";
            this.barBtnDelete.Size = new System.Drawing.Size(23, 23);
            this.barBtnDelete.TabIndex = 11;
            this.barBtnDelete.ToolTip = "Удалить заказ";
            this.barBtnDelete.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.simpleButton1.Image = global::ERPMercuryLotOrder.Properties.Resources.printer2;
            this.simpleButton1.ImageAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleButton1.Location = new System.Drawing.Point(82, 4);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(1);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(23, 23);
            this.simpleButton1.TabIndex = 14;
            this.simpleButton1.ToolTip = "Печать списка заказов";
            this.simpleButton1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // tableLayoutPanelLotList
            // 
            this.tableLayoutPanelLotList.ColumnCount = 1;
            this.tableLayoutPanelLotList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLotList.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLotList.Name = "tableLayoutPanelLotList";
            this.tableLayoutPanelLotList.RowCount = 1;
            this.tableLayoutPanelLotList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLotList.Size = new System.Drawing.Size(961, 591);
            this.toolTipController.SetSuperTip(this.tableLayoutPanelLotList, null);
            this.tableLayoutPanelLotList.TabIndex = 0;
            // 
            // tabPageLotList
            // 
            this.tabPageLotList.Controls.Add(this.tableLayoutPanelLotList);
            this.tabPageLotList.Name = "tabPageLotList";
            this.tabPageLotList.Size = new System.Drawing.Size(961, 591);
            this.tabPageLotList.Text = "tabPageLotList";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "MS Excel 2010 files (*.xlsx)|*.xlsx|MS Excel 2003 files (*.xls)|*.xls|All files (" +
    "*.*)|*.*";
            // 
            // ctrlKLP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "ctrlKLP";
            this.Size = new System.Drawing.Size(970, 622);
            this.toolTipController.SetSuperTip(this, null);
            this.Resize += new System.EventHandler(this.ctrlKLP_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEditOrderedQuantity)).EndInit();
            this.tableLayoutPanelKLPList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblOrderInfo.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlKLPList)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKLPList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCheckEdit)).EndInit();
            this.tableLayoutPanelAgreementShortInfo.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotOrderName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendorName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotOrderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotOrderState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcQuantityFact.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSumFactPriceForCalcCostPriceInVendorCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockStockAccepting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCostIsCalc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSumFactPriceForCalcCostPrice.Properties)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageKLPList.ResumeLayout(false);
            this.tabPageKLPEditor.ResumeLayout(false);
            this.tableLayoutPanelBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelProgressBar)).EndInit();
            this.panelProgressBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.contextMenuStripEditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KLPItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SrcForKlpItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountryProduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditCountryProduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditDiscount)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxProductTradeMark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxProductType.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxKLPState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KLPDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KLPDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKLPNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkKLPCostIsCalc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkKLPIsActive.Properties)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KLPStartAccepting.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KLPStartAccepting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KLPEndAccepting.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KLPEndAccepting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxStock.Properties)).EndInit();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tabPageLotList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelKLPList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraGrid.GridControl gridControlKLPList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewKLPList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAgreementShortInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.TextEdit txtLotOrderName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtVendorName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtLotOrderDate;
        private DevExpress.XtraEditors.CalcEdit calcQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TextEdit txtLotOrderState;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.CalcEdit calcQuantityFact;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.CalcEdit calcSumFactPriceForCalcCostPriceInVendorCurrency;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private DevExpress.XtraEditors.SimpleButton barBtnAddKLP;
        private DevExpress.XtraEditors.SimpleButton barBtnDeleteKLP;
        private DevExpress.XtraEditors.SimpleButton btnPrintKLPList;
        private DevExpress.XtraEditors.SimpleButton barBtnExit;
        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage tabPageKLPList;
        private DevExpress.XtraTab.XtraTabPage tabPageKLPEditor;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtStockStockAccepting;
        private DevExpress.XtraEditors.TextEdit txtCostIsCalc;
        private DevExpress.Utils.ToolTipController toolTipController;
        private System.Data.DataSet dataSet;
        private System.Data.DataTable KLPItems;
        private System.Data.DataColumn KLPItemsID;
        private System.Data.DataColumn ProductID;
        private System.Data.DataColumn MeasureID;
        private System.Data.DataColumn Quantity;
        private System.Data.DataColumn FactQuantity;
        private System.Data.DataColumn CurrencyPrice;
        private System.Data.DataColumn DiscountVendorPrice;
        private System.Data.DataColumn AllDiscountVendorPrice;
        private System.Data.DataColumn FactAllDiscountVendorPrice;
        private System.Data.DataColumn AllCurrencyPrice;
        private System.Data.DataColumn FactAllCurrencyPrice;
        private System.Data.DataColumn KLPItems_MeasureName;
        private System.Data.DataColumn KLPItems_PartsArticle;
        private System.Data.DataColumn KLPItems_PartsName;
        private System.Data.DataTable SrcForKlpItems;
        private System.Data.DataColumn ProductGuid;
        private System.Data.DataColumn ProductShortName;
        private System.Data.DataColumn OrderItems_OrderQuantity;
        private System.Data.DataColumn Product_MeasureID;
        private System.Data.DataColumn Product_MeasureName;
        private System.Data.DataColumn ProductArticle;
        private System.Data.DataColumn ProductFullName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBackground;
        private DevExpress.XtraEditors.PanelControl panelProgressBar;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colKLPItemsID;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colMeasureID;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderItems_MeasureName;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEditOrderedQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colFactQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountVendorPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colAllDiscountVendorPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colFactAllDiscountVendorPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colAllCurrencyPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colFactAllCurrencyPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colKLPItems_PartsName;
        private DevExpress.XtraGrid.Columns.GridColumn colKLPItems_PartsArticle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit cboxProductTradeMark;
        private DevExpress.XtraEditors.PictureEdit pictureFilter;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.ComboBoxEdit cboxProductType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.DateEdit KLPDate;
        private DevExpress.XtraEditors.TextEdit txtKLPNum;
        private DevExpress.XtraEditors.DateEdit KLPStartAccepting;
        private DevExpress.XtraEditors.CheckEdit checkKLPIsActive;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private DevExpress.XtraEditors.ComboBoxEdit cboxStock;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.ComboBoxEdit cboxKLPState;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.DateEdit KLPEndAccepting;
        private DevExpress.XtraEditors.CheckEdit checkKLPCostIsCalc;
        private System.Data.DataColumn LotOrderItems_Guid;
        private System.Data.DataColumn OrderItems_ConfirmQuantity;
        private System.Data.DataColumn OrderItems_Quantity;
        private System.Data.DataColumn OrderItems_QuantityInKLP;
        private System.Data.DataColumn KLPItems_Id;
        private DevExpress.XtraGrid.Columns.GridColumn colKLPItems_Id;
        private System.Data.DataColumn LotOrderItems_QuantityInDoc;
        private System.Data.DataColumn LotOrderItems_QuantityInKLP;
        private DevExpress.XtraGrid.Columns.GridColumn colLotOrderItems_QuantityInDoc;
        private DevExpress.XtraGrid.Columns.GridColumn colLotOrderItems_QuantityInKLP;
        private System.Data.DataColumn OrderItems_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colLotOrderItems_Guid;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repItemCheckEdit;
        private DevExpress.XtraEditors.TextEdit lblOrderInfo;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Data.DataColumn CountryProductionID;
        private System.Data.DataColumn KLPItems_CountryProductionName;
        private System.Data.DataColumn CustomTarifPercent;
        private System.Data.DataTable CountryProduction;
        private System.Data.DataColumn CountryProductionGuid;
        private System.Data.DataColumn CountryProductionName;
        private System.Data.DataColumn OrderItems_CountryProductionID;
        private System.Data.DataColumn OrderItems_CountryProductionName;
        private System.Data.DataColumn OrderItems_CustomTarifPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomTarifPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colCountryProductionID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditCountryProduction;
        private DevExpress.XtraGrid.Columns.GridColumn colKLPItems_CountryProductionName;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.CalcEdit calcSumFactPriceForCalcCostPrice;
        private DevExpress.XtraTab.XtraTabPage tabPageLotList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private DevExpress.XtraEditors.SimpleButton barBtnEdit;
        private DevExpress.XtraEditors.SimpleButton barBtnAdd;
        private DevExpress.XtraEditors.SimpleButton barBtnDelete;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuLotList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLotList;
        private DevExpress.XtraEditors.SimpleButton barBtnToLotList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEditor;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewLotFromKLP;

    }
}
