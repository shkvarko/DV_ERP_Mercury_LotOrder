namespace ERPMercuryLotOrder
{
    partial class ctrlLotOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlLotOrder));
            this.colOrderedQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEditOrderedQuantity = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colConfirmQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVendorPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVendorPriceWithDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.tableLayoutPanelBackground = new System.Windows.Forms.TableLayoutPanel();
            this.panelProgressBar = new DevExpress.XtraEditors.PanelControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
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
            this.dataSet = new System.Data.DataSet();
            this.OrderItems = new System.Data.DataTable();
            this.OrderItemsID = new System.Data.DataColumn();
            this.ProductID = new System.Data.DataColumn();
            this.MeasureID = new System.Data.DataColumn();
            this.OrderedQuantity = new System.Data.DataColumn();
            this.ConfirmQuantity = new System.Data.DataColumn();
            this.QuantityInDoc = new System.Data.DataColumn();
            this.VendorPrice = new System.Data.DataColumn();
            this.DiscountPercent = new System.Data.DataColumn();
            this.VendorPriceWithDiscount = new System.Data.DataColumn();
            this.SumOrdered = new System.Data.DataColumn();
            this.SumOrderedWithDiscount = new System.Data.DataColumn();
            this.SumConfirmed = new System.Data.DataColumn();
            this.SumConfirmedWithDiscount = new System.Data.DataColumn();
            this.SumInDoc = new System.Data.DataColumn();
            this.SumInDocWithDiscount = new System.Data.DataColumn();
            this.OrderItems_MeasureName = new System.Data.DataColumn();
            this.OrderItems_PartsArticle = new System.Data.DataColumn();
            this.OrderItems_PartsName = new System.Data.DataColumn();
            this.OrderPackQty = new System.Data.DataColumn();
            this.Product_VendorPrice = new System.Data.DataColumn();
            this.Product_Weight = new System.Data.DataColumn();
            this.SumWeightForQuantityInDoc = new System.Data.DataColumn();
            this.ExpirationDate = new System.Data.DataColumn();
            this.CountryProductionID = new System.Data.DataColumn();
            this.OrderItems_CountryProductionName = new System.Data.DataColumn();
            this.CustomTarifPercent = new System.Data.DataColumn();
            this.PriceForCalcCostPrice = new System.Data.DataColumn();
            this.SumPriceForCalcCostPrice = new System.Data.DataColumn();
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
            this.colOrderItems_MeasureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduct_Weight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVendorPriceInDirectory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantityInDoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEditDiscount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colSumOrdered = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumOrderedWithDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumConfirmed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumConfirmedWithDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumInDoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumPriceForCalcCostPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderPackQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderItems_PartsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderItems_PartsArticle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpirationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colCountryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditCountryProduction = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCustomTarifPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderItems_CountryProductionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceForCalcCostPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditDiscount = new DevExpress.XtraEditors.SpinEdit();
            this.btnSetDiscount = new DevExpress.XtraEditors.SimpleButton();
            this.checkMultiplicity = new DevExpress.XtraEditors.CheckEdit();
            this.controlNavigator = new DevExpress.XtraEditors.ControlNavigator();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditCustomTarif = new DevExpress.XtraEditors.SpinEdit();
            this.btnSetCustomTarif = new DevExpress.XtraEditors.SimpleButton();
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
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.BeginDate = new DevExpress.XtraEditors.DateEdit();
            this.txtLotOrderNum = new DevExpress.XtraEditors.TextEdit();
            this.DeliveryDate = new DevExpress.XtraEditors.DateEdit();
            this.checkLotOrderActive = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.ShipDate = new DevExpress.XtraEditors.DateEdit();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cboxCurrency = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cboxLotOrderState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboxVendor = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblEditMode = new DevExpress.XtraEditors.LabelControl();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEditOrderedQuantity)).BeginInit();
            this.tableLayoutPanelBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelProgressBar)).BeginInit();
            this.panelProgressBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCustomTarif.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxCountryProduction.Properties)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxProductType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxProductTradeMark.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BeginDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeginDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotOrderNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLotOrderActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipDate.Properties)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxLotOrderState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxVendor.Properties)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colOrderedQuantity
            // 
            this.colOrderedQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colOrderedQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colOrderedQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colOrderedQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOrderedQuantity.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colOrderedQuantity.Caption = "Кол-во (заказанное)";
            this.colOrderedQuantity.ColumnEdit = this.repositoryItemCalcEditOrderedQuantity;
            this.colOrderedQuantity.FieldName = "OrderedQuantity";
            this.colOrderedQuantity.MinWidth = 100;
            this.colOrderedQuantity.Name = "colOrderedQuantity";
            this.colOrderedQuantity.SummaryItem.DisplayFormat = "Заказано: {0:### ### ##0}";
            this.colOrderedQuantity.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colOrderedQuantity.Visible = true;
            this.colOrderedQuantity.VisibleIndex = 4;
            this.colOrderedQuantity.Width = 105;
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
            // colConfirmQuantity
            // 
            this.colConfirmQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colConfirmQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colConfirmQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colConfirmQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colConfirmQuantity.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colConfirmQuantity.Caption = "Кол-во (подтверждено поставщиком)";
            this.colConfirmQuantity.ColumnEdit = this.repositoryItemCalcEditOrderedQuantity;
            this.colConfirmQuantity.FieldName = "ConfirmQuantity";
            this.colConfirmQuantity.MinWidth = 100;
            this.colConfirmQuantity.Name = "colConfirmQuantity";
            this.colConfirmQuantity.SummaryItem.DisplayFormat = "Подтв-но: {0:### ### ##0}";
            this.colConfirmQuantity.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colConfirmQuantity.Visible = true;
            this.colConfirmQuantity.VisibleIndex = 5;
            this.colConfirmQuantity.Width = 100;
            // 
            // colVendorPrice
            // 
            this.colVendorPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colVendorPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colVendorPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colVendorPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVendorPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colVendorPrice.Caption = "Цена exw";
            this.colVendorPrice.DisplayFormat.FormatString = "# ### ### ##0.000";
            this.colVendorPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVendorPrice.FieldName = "VendorPrice";
            this.colVendorPrice.MinWidth = 55;
            this.colVendorPrice.Name = "colVendorPrice";
            this.colVendorPrice.Visible = true;
            this.colVendorPrice.VisibleIndex = 7;
            this.colVendorPrice.Width = 55;
            // 
            // colVendorPriceWithDiscount
            // 
            this.colVendorPriceWithDiscount.AppearanceCell.Options.UseTextOptions = true;
            this.colVendorPriceWithDiscount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colVendorPriceWithDiscount.AppearanceHeader.Options.UseTextOptions = true;
            this.colVendorPriceWithDiscount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVendorPriceWithDiscount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colVendorPriceWithDiscount.Caption = "Цена по инвойсу";
            this.colVendorPriceWithDiscount.DisplayFormat.FormatString = "# ### ### ##0.000";
            this.colVendorPriceWithDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVendorPriceWithDiscount.FieldName = "VendorPriceWithDiscount";
            this.colVendorPriceWithDiscount.MinWidth = 70;
            this.colVendorPriceWithDiscount.Name = "colVendorPriceWithDiscount";
            this.colVendorPriceWithDiscount.Visible = true;
            this.colVendorPriceWithDiscount.VisibleIndex = 9;
            this.colVendorPriceWithDiscount.Width = 70;
            // 
            // tableLayoutPanelBackground
            // 
            this.tableLayoutPanelBackground.ColumnCount = 1;
            this.tableLayoutPanelBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBackground.Controls.Add(this.panelProgressBar, 0, 4);
            this.tableLayoutPanelBackground.Controls.Add(this.gridControl, 0, 7);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel6, 0, 6);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel8, 0, 5);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel1, 0, 8);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanelBackground.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanelBackground.Controls.Add(this.lblEditMode, 0, 0);
            this.tableLayoutPanelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBackground.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelBackground.Name = "tableLayoutPanelBackground";
            this.tableLayoutPanelBackground.RowCount = 9;
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelBackground.Size = new System.Drawing.Size(1203, 624);
            this.toolTipController.SetSuperTip(this.tableLayoutPanelBackground, null);
            this.tableLayoutPanelBackground.TabIndex = 0;
            // 
            // panelProgressBar
            // 
            this.panelProgressBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelProgressBar.Controls.Add(this.progressBarControl1);
            this.panelProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProgressBar.Location = new System.Drawing.Point(3, 160);
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
            this.gridControl.Location = new System.Drawing.Point(3, 243);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditProduct,
            this.repositoryItemCalcEditOrderedQuantity,
            this.repositoryItemSpinEditDiscount,
            this.repositoryItemDateEdit,
            this.repositoryItemLookUpEditCountryProduction});
            this.gridControl.Size = new System.Drawing.Size(1197, 347);
            this.gridControl.TabIndex = 26;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
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
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
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
            this.mitmsExportToHTML.Click += new System.EventHandler(this.sbExportToHTML_Click);
            // 
            // mitmsExportToXML
            // 
            this.mitmsExportToXML.Name = "mitmsExportToXML";
            this.mitmsExportToXML.Size = new System.Drawing.Size(233, 22);
            this.mitmsExportToXML.Text = "в XML...";
            this.mitmsExportToXML.Click += new System.EventHandler(this.sbExportToXML_Click);
            // 
            // mitmsExportToXLS
            // 
            this.mitmsExportToXLS.Name = "mitmsExportToXLS";
            this.mitmsExportToXLS.Size = new System.Drawing.Size(233, 22);
            this.mitmsExportToXLS.Text = "в MS Excel...";
            this.mitmsExportToXLS.Click += new System.EventHandler(this.sbExportToXLS_Click);
            // 
            // mitmsExportToTXT
            // 
            this.mitmsExportToTXT.Name = "mitmsExportToTXT";
            this.mitmsExportToTXT.Size = new System.Drawing.Size(233, 22);
            this.mitmsExportToTXT.Text = "в TXT...";
            this.mitmsExportToTXT.Click += new System.EventHandler(this.sbExportToTXT_Click);
            // 
            // mitmsExportToDBF
            // 
            this.mitmsExportToDBF.Name = "mitmsExportToDBF";
            this.mitmsExportToDBF.Size = new System.Drawing.Size(233, 22);
            this.mitmsExportToDBF.Text = "в DBF...";
            this.mitmsExportToDBF.Click += new System.EventHandler(this.sbExportToDBF_Click);
            // 
            // mitmsExportToDBFCurrency
            // 
            this.mitmsExportToDBFCurrency.Name = "mitmsExportToDBFCurrency";
            this.mitmsExportToDBFCurrency.Size = new System.Drawing.Size(233, 22);
            this.mitmsExportToDBFCurrency.Text = "в DBF (цена в валюте учета)...";
            this.mitmsExportToDBFCurrency.Visible = false;
            this.mitmsExportToDBFCurrency.Click += new System.EventHandler(this.sbExportToDBFCurrency_Click);
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
            this.mitmsImportFromExcelByPartsId.Click += new System.EventHandler(this.mitmsImportFromExcelByPartsId_Click);
            // 
            // изMSExcelспецимпортToolStripMenuItem
            // 
            this.изMSExcelспецимпортToolStripMenuItem.Name = "изMSExcelспецимпортToolStripMenuItem";
            this.изMSExcelспецимпортToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.изMSExcelспецимпортToolStripMenuItem.Text = "из MS Excel (специмпорт FULLNAME) ";
            this.изMSExcelспецимпортToolStripMenuItem.Click += new System.EventHandler(this.mitmsImportFromExcelByPartsFullName_Click);
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
            this.mitmsRefreshPricesByPartsId.Click += new System.EventHandler(this.mitmsRefreshPricesByPartsId_Click);
            // 
            // mitmsRefreshPricesByPartsFullName
            // 
            this.mitmsRefreshPricesByPartsFullName.Name = "mitmsRefreshPricesByPartsFullName";
            this.mitmsRefreshPricesByPartsFullName.Size = new System.Drawing.Size(254, 22);
            this.mitmsRefreshPricesByPartsFullName.Text = "из MS Excel (специмпорт FULLNAME)";
            this.mitmsRefreshPricesByPartsFullName.Click += new System.EventHandler(this.mitmsRefreshPricesByPartsFullName_Click);
            // 
            // mitemClearPrice
            // 
            this.mitemClearPrice.Name = "mitemClearPrice";
            this.mitemClearPrice.Size = new System.Drawing.Size(301, 22);
            this.mitemClearPrice.Text = "Обнулить цену";
            this.mitemClearPrice.Click += new System.EventHandler(this.mitemClearPrice_Click);
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
            this.OrderedQuantity,
            this.ConfirmQuantity,
            this.QuantityInDoc,
            this.VendorPrice,
            this.DiscountPercent,
            this.VendorPriceWithDiscount,
            this.SumOrdered,
            this.SumOrderedWithDiscount,
            this.SumConfirmed,
            this.SumConfirmedWithDiscount,
            this.SumInDoc,
            this.SumInDocWithDiscount,
            this.OrderItems_MeasureName,
            this.OrderItems_PartsArticle,
            this.OrderItems_PartsName,
            this.OrderPackQty,
            this.Product_VendorPrice,
            this.Product_Weight,
            this.SumWeightForQuantityInDoc,
            this.ExpirationDate,
            this.CountryProductionID,
            this.OrderItems_CountryProductionName,
            this.CustomTarifPercent,
            this.PriceForCalcCostPrice,
            this.SumPriceForCalcCostPrice});
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
            // OrderedQuantity
            // 
            this.OrderedQuantity.Caption = "Кол-во (заказанное)";
            this.OrderedQuantity.ColumnName = "OrderedQuantity";
            this.OrderedQuantity.DataType = typeof(decimal);
            // 
            // ConfirmQuantity
            // 
            this.ConfirmQuantity.Caption = "Количество подтверждённое";
            this.ConfirmQuantity.ColumnName = "ConfirmQuantity";
            this.ConfirmQuantity.DataType = typeof(decimal);
            // 
            // QuantityInDoc
            // 
            this.QuantityInDoc.Caption = "Кол-во (в документе)";
            this.QuantityInDoc.ColumnName = "QuantityInDoc";
            this.QuantityInDoc.DataType = typeof(decimal);
            // 
            // VendorPrice
            // 
            this.VendorPrice.Caption = "Цена exw";
            this.VendorPrice.ColumnName = "VendorPrice";
            this.VendorPrice.DataType = typeof(double);
            // 
            // DiscountPercent
            // 
            this.DiscountPercent.Caption = "Размер скидки, %";
            this.DiscountPercent.ColumnName = "DiscountPercent";
            this.DiscountPercent.DataType = typeof(double);
            // 
            // VendorPriceWithDiscount
            // 
            this.VendorPriceWithDiscount.Caption = "Цена по инвойсу";
            this.VendorPriceWithDiscount.ColumnName = "VendorPriceWithDiscount";
            this.VendorPriceWithDiscount.DataType = typeof(double);
            // 
            // SumOrdered
            // 
            this.SumOrdered.Caption = "Сумма заказа";
            this.SumOrdered.ColumnName = "SumOrdered";
            this.SumOrdered.DataType = typeof(double);
            this.SumOrdered.Expression = "VendorPrice * OrderedQuantity";
            this.SumOrdered.ReadOnly = true;
            // 
            // SumOrderedWithDiscount
            // 
            this.SumOrderedWithDiscount.Caption = "Сумма заказа с учетом скидки";
            this.SumOrderedWithDiscount.ColumnName = "SumOrderedWithDiscount";
            this.SumOrderedWithDiscount.DataType = typeof(double);
            this.SumOrderedWithDiscount.Expression = "VendorPriceWithDiscount * OrderedQuantity";
            this.SumOrderedWithDiscount.ReadOnly = true;
            // 
            // SumConfirmed
            // 
            this.SumConfirmed.Caption = "Сумма подтверждённая";
            this.SumConfirmed.ColumnName = "SumConfirmed";
            this.SumConfirmed.DataType = typeof(double);
            this.SumConfirmed.Expression = "VendorPrice * ConfirmQuantity";
            this.SumConfirmed.ReadOnly = true;
            // 
            // SumConfirmedWithDiscount
            // 
            this.SumConfirmedWithDiscount.Caption = "Сумма подтверждённая с учётом скидки";
            this.SumConfirmedWithDiscount.ColumnName = "SumConfirmedWithDiscount";
            this.SumConfirmedWithDiscount.DataType = typeof(double);
            this.SumConfirmedWithDiscount.Expression = "VendorPriceWithDiscount * ConfirmQuantity";
            this.SumConfirmedWithDiscount.ReadOnly = true;
            // 
            // SumInDoc
            // 
            this.SumInDoc.Caption = "Сумма (в документе)";
            this.SumInDoc.ColumnName = "SumInDoc";
            this.SumInDoc.DataType = typeof(double);
            this.SumInDoc.Expression = "VendorPrice * QuantityInDoc";
            this.SumInDoc.ReadOnly = true;
            // 
            // SumInDocWithDiscount
            // 
            this.SumInDocWithDiscount.Caption = "Сумма (в документе) с учетом скидки";
            this.SumInDocWithDiscount.ColumnName = "SumInDocWithDiscount";
            this.SumInDocWithDiscount.DataType = typeof(double);
            this.SumInDocWithDiscount.Expression = "VendorPriceWithDiscount * QuantityInDoc";
            this.SumInDocWithDiscount.ReadOnly = true;
            // 
            // OrderItems_MeasureName
            // 
            this.OrderItems_MeasureName.Caption = "Ед. изм.";
            this.OrderItems_MeasureName.ColumnName = "OrderItems_MeasureName";
            // 
            // OrderItems_PartsArticle
            // 
            this.OrderItems_PartsArticle.ColumnName = "OrderItems_PartsArticle";
            // 
            // OrderItems_PartsName
            // 
            this.OrderItems_PartsName.ColumnName = "OrderItems_PartsName";
            // 
            // OrderPackQty
            // 
            this.OrderPackQty.ColumnName = "OrderPackQty";
            // 
            // Product_VendorPrice
            // 
            this.Product_VendorPrice.Caption = "Текущий тариф в справочнике";
            this.Product_VendorPrice.ColumnName = "Product_VendorPrice";
            this.Product_VendorPrice.DataType = typeof(double);
            // 
            // Product_Weight
            // 
            this.Product_Weight.Caption = "Вес, кг.";
            this.Product_Weight.ColumnName = "Product_Weight";
            this.Product_Weight.DataType = typeof(double);
            // 
            // SumWeightForQuantityInDoc
            // 
            this.SumWeightForQuantityInDoc.Caption = "Вес (итого), кг.";
            this.SumWeightForQuantityInDoc.ColumnName = "SumWeightForQuantityInDoc";
            this.SumWeightForQuantityInDoc.DataType = typeof(double);
            this.SumWeightForQuantityInDoc.Expression = "Product_Weight * QuantityInDoc";
            this.SumWeightForQuantityInDoc.ReadOnly = true;
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
            // OrderItems_CountryProductionName
            // 
            this.OrderItems_CountryProductionName.Caption = "Страна пр-ва";
            this.OrderItems_CountryProductionName.ColumnName = "OrderItems_CountryProductionName";
            // 
            // CustomTarifPercent
            // 
            this.CustomTarifPercent.Caption = "Тамож. тариф, %";
            this.CustomTarifPercent.ColumnName = "CustomTarifPercent";
            this.CustomTarifPercent.DataType = typeof(double);
            // 
            // PriceForCalcCostPrice
            // 
            this.PriceForCalcCostPrice.Caption = "Цена вал. для расчёта С/С";
            this.PriceForCalcCostPrice.ColumnName = "PriceForCalcCostPrice";
            this.PriceForCalcCostPrice.DataType = typeof(double);
            // 
            // SumPriceForCalcCostPrice
            // 
            this.SumPriceForCalcCostPrice.Caption = "Сумма вал. для расчёта С/С";
            this.SumPriceForCalcCostPrice.ColumnName = "SumPriceForCalcCostPrice";
            this.SumPriceForCalcCostPrice.DataType = typeof(double);
            this.SumPriceForCalcCostPrice.Expression = "PriceForCalcCostPrice * ConfirmQuantity";
            this.SumPriceForCalcCostPrice.ReadOnly = true;
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
            this.colOrderItems_MeasureName,
            this.colProduct_Weight,
            this.colVendorPriceInDirectory,
            this.colOrderedQuantity,
            this.colConfirmQuantity,
            this.colQuantityInDoc,
            this.colVendorPrice,
            this.colDiscountPercent,
            this.colVendorPriceWithDiscount,
            this.colSumOrdered,
            this.colSumOrderedWithDiscount,
            this.colSumConfirmed,
            this.colSumConfirmedWithDiscount,
            this.colSumInDoc,
            this.colSumPriceForCalcCostPrice,
            this.colSumWeight,
            this.colOrderPackQty,
            this.colOrderItems_PartsName,
            this.colOrderItems_PartsArticle,
            this.colExpirationDate,
            this.colCountryID,
            this.colCustomTarifPercent,
            this.colOrderItems_CountryProductionName,
            this.colPriceForCalcCostPrice});
            this.gridView.CustomizationFormBounds = new System.Drawing.Rectangle(1062, 711, 208, 189);
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.Column = this.colOrderedQuantity;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition1.Value1 = 0D;
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition2.Value1 = "0";
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.Column = this.colConfirmQuantity;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition3.Value1 = "0";
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.Column = this.colVendorPrice;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition4.Value1 = "0";
            styleFormatCondition5.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition5.Appearance.Options.UseBackColor = true;
            styleFormatCondition5.Column = this.colVendorPriceWithDiscount;
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
            this.gridView.IndicatorWidth = 60;
            this.gridView.Name = "gridView";
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView_CustomDrawRowIndicator);
            this.gridView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView_CustomDrawCell);
            this.gridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView_InitNewRow);
            this.gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_CellValueChanged);
            this.gridView.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_CellValueChanging);
            this.gridView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_InvalidRowException);
            this.gridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_ValidateRow);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
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
            // colOrderItems_MeasureName
            // 
            this.colOrderItems_MeasureName.AppearanceHeader.Options.UseTextOptions = true;
            this.colOrderItems_MeasureName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOrderItems_MeasureName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colOrderItems_MeasureName.Caption = "Ед изм.";
            this.colOrderItems_MeasureName.FieldName = "OrderItems_MeasureName";
            this.colOrderItems_MeasureName.MinWidth = 55;
            this.colOrderItems_MeasureName.Name = "colOrderItems_MeasureName";
            this.colOrderItems_MeasureName.OptionsColumn.AllowEdit = false;
            this.colOrderItems_MeasureName.OptionsColumn.ReadOnly = true;
            this.colOrderItems_MeasureName.Visible = true;
            this.colOrderItems_MeasureName.VisibleIndex = 1;
            this.colOrderItems_MeasureName.Width = 55;
            // 
            // colProduct_Weight
            // 
            this.colProduct_Weight.AppearanceHeader.Options.UseTextOptions = true;
            this.colProduct_Weight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProduct_Weight.Caption = "Вес, кг.";
            this.colProduct_Weight.DisplayFormat.FormatString = "### ##0.000";
            this.colProduct_Weight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colProduct_Weight.FieldName = "Product_Weight";
            this.colProduct_Weight.MinWidth = 60;
            this.colProduct_Weight.Name = "colProduct_Weight";
            this.colProduct_Weight.OptionsColumn.AllowEdit = false;
            this.colProduct_Weight.OptionsColumn.ReadOnly = true;
            this.colProduct_Weight.Visible = true;
            this.colProduct_Weight.VisibleIndex = 2;
            this.colProduct_Weight.Width = 61;
            // 
            // colVendorPriceInDirectory
            // 
            this.colVendorPriceInDirectory.AppearanceHeader.Options.UseTextOptions = true;
            this.colVendorPriceInDirectory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVendorPriceInDirectory.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colVendorPriceInDirectory.Caption = "Тариф в справочнике";
            this.colVendorPriceInDirectory.DisplayFormat.FormatString = "### ##0.000";
            this.colVendorPriceInDirectory.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVendorPriceInDirectory.FieldName = "Product_VendorPrice";
            this.colVendorPriceInDirectory.MinWidth = 70;
            this.colVendorPriceInDirectory.Name = "colVendorPriceInDirectory";
            this.colVendorPriceInDirectory.OptionsColumn.AllowEdit = false;
            this.colVendorPriceInDirectory.OptionsColumn.ReadOnly = true;
            this.colVendorPriceInDirectory.Visible = true;
            this.colVendorPriceInDirectory.VisibleIndex = 3;
            this.colVendorPriceInDirectory.Width = 70;
            // 
            // colQuantityInDoc
            // 
            this.colQuantityInDoc.AppearanceHeader.Options.UseTextOptions = true;
            this.colQuantityInDoc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQuantityInDoc.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colQuantityInDoc.Caption = "Кол-во (в документе)";
            this.colQuantityInDoc.ColumnEdit = this.repositoryItemCalcEditOrderedQuantity;
            this.colQuantityInDoc.FieldName = "QuantityInDoc";
            this.colQuantityInDoc.MinWidth = 100;
            this.colQuantityInDoc.Name = "colQuantityInDoc";
            this.colQuantityInDoc.SummaryItem.DisplayFormat = "По док-ту: {0:### ### ##0}";
            this.colQuantityInDoc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colQuantityInDoc.Visible = true;
            this.colQuantityInDoc.VisibleIndex = 6;
            this.colQuantityInDoc.Width = 100;
            // 
            // colDiscountPercent
            // 
            this.colDiscountPercent.AppearanceHeader.Options.UseTextOptions = true;
            this.colDiscountPercent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiscountPercent.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDiscountPercent.Caption = "Скидка, %";
            this.colDiscountPercent.ColumnEdit = this.repositoryItemSpinEditDiscount;
            this.colDiscountPercent.DisplayFormat.FormatString = "##0";
            this.colDiscountPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiscountPercent.FieldName = "DiscountPercent";
            this.colDiscountPercent.MinWidth = 50;
            this.colDiscountPercent.Name = "colDiscountPercent";
            this.colDiscountPercent.Visible = true;
            this.colDiscountPercent.VisibleIndex = 8;
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
            // colSumOrdered
            // 
            this.colSumOrdered.AppearanceHeader.Options.UseTextOptions = true;
            this.colSumOrdered.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSumOrdered.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSumOrdered.Caption = "Сумма, exw (заказано)";
            this.colSumOrdered.DisplayFormat.FormatString = "# ### ### ##0.00";
            this.colSumOrdered.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumOrdered.FieldName = "SumOrdered";
            this.colSumOrdered.MinWidth = 150;
            this.colSumOrdered.Name = "colSumOrdered";
            this.colSumOrdered.OptionsColumn.AllowEdit = false;
            this.colSumOrdered.OptionsColumn.ReadOnly = true;
            this.colSumOrdered.SummaryItem.DisplayFormat = "Сумма, exw: {0:### ### ##0.00}";
            this.colSumOrdered.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colSumOrdered.Visible = true;
            this.colSumOrdered.VisibleIndex = 13;
            this.colSumOrdered.Width = 150;
            // 
            // colSumOrderedWithDiscount
            // 
            this.colSumOrderedWithDiscount.AppearanceHeader.Options.UseTextOptions = true;
            this.colSumOrderedWithDiscount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSumOrderedWithDiscount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSumOrderedWithDiscount.Caption = "Сумма (заказано) со скидкой";
            this.colSumOrderedWithDiscount.DisplayFormat.FormatString = "# ### ### ##0.00";
            this.colSumOrderedWithDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumOrderedWithDiscount.FieldName = "SumOrderedWithDiscount";
            this.colSumOrderedWithDiscount.MinWidth = 150;
            this.colSumOrderedWithDiscount.Name = "colSumOrderedWithDiscount";
            this.colSumOrderedWithDiscount.OptionsColumn.AllowEdit = false;
            this.colSumOrderedWithDiscount.OptionsColumn.ReadOnly = true;
            this.colSumOrderedWithDiscount.SummaryItem.DisplayFormat = "(со скидкой): {0:### ### ##0.00}";
            this.colSumOrderedWithDiscount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colSumOrderedWithDiscount.Width = 150;
            // 
            // colSumConfirmed
            // 
            this.colSumConfirmed.AppearanceHeader.Options.UseTextOptions = true;
            this.colSumConfirmed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSumConfirmed.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSumConfirmed.Caption = "Сумма, exw (подтверждено поставщиком)";
            this.colSumConfirmed.DisplayFormat.FormatString = "### ### ##0.00";
            this.colSumConfirmed.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumConfirmed.FieldName = "SumConfirmed";
            this.colSumConfirmed.MinWidth = 150;
            this.colSumConfirmed.Name = "colSumConfirmed";
            this.colSumConfirmed.OptionsColumn.ReadOnly = true;
            this.colSumConfirmed.SummaryItem.DisplayFormat = "Сумма, exw: {0:### ### ##0.00}";
            this.colSumConfirmed.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colSumConfirmed.Visible = true;
            this.colSumConfirmed.VisibleIndex = 14;
            this.colSumConfirmed.Width = 150;
            // 
            // colSumConfirmedWithDiscount
            // 
            this.colSumConfirmedWithDiscount.AppearanceHeader.Options.UseTextOptions = true;
            this.colSumConfirmedWithDiscount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSumConfirmedWithDiscount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSumConfirmedWithDiscount.Caption = "Сумма по инвойсу (подтверждено поставщиком)";
            this.colSumConfirmedWithDiscount.DisplayFormat.FormatString = "### ### ##0.00";
            this.colSumConfirmedWithDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumConfirmedWithDiscount.FieldName = "SumConfirmedWithDiscount";
            this.colSumConfirmedWithDiscount.MinWidth = 150;
            this.colSumConfirmedWithDiscount.Name = "colSumConfirmedWithDiscount";
            this.colSumConfirmedWithDiscount.OptionsColumn.ReadOnly = true;
            this.colSumConfirmedWithDiscount.SummaryItem.DisplayFormat = "По инвойсу: {0:### ### ##0.00}";
            this.colSumConfirmedWithDiscount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colSumConfirmedWithDiscount.Visible = true;
            this.colSumConfirmedWithDiscount.VisibleIndex = 15;
            this.colSumConfirmedWithDiscount.Width = 150;
            // 
            // colSumInDoc
            // 
            this.colSumInDoc.AppearanceCell.Options.UseTextOptions = true;
            this.colSumInDoc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSumInDoc.AppearanceHeader.Options.UseTextOptions = true;
            this.colSumInDoc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSumInDoc.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSumInDoc.Caption = "Сумма (по док-ту)";
            this.colSumInDoc.CustomizationCaption = "Сумма, руб.";
            this.colSumInDoc.DisplayFormat.FormatString = "# ### ### ##0.00";
            this.colSumInDoc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumInDoc.FieldName = "SumInDoc";
            this.colSumInDoc.MinWidth = 150;
            this.colSumInDoc.Name = "colSumInDoc";
            this.colSumInDoc.OptionsColumn.AllowEdit = false;
            this.colSumInDoc.OptionsColumn.ReadOnly = true;
            this.colSumInDoc.SummaryItem.DisplayFormat = "По док-ту: {0:### ### ##0.00}";
            this.colSumInDoc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colSumInDoc.Width = 150;
            // 
            // colSumPriceForCalcCostPrice
            // 
            this.colSumPriceForCalcCostPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colSumPriceForCalcCostPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSumPriceForCalcCostPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colSumPriceForCalcCostPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSumPriceForCalcCostPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSumPriceForCalcCostPrice.Caption = "Сумма вал. для расчёта С/С (подтверждено поставщиком)";
            this.colSumPriceForCalcCostPrice.CustomizationCaption = "Сумма вал. для расчёта С/С";
            this.colSumPriceForCalcCostPrice.DisplayFormat.FormatString = "# ### ### ##0.00";
            this.colSumPriceForCalcCostPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumPriceForCalcCostPrice.FieldName = "SumPriceForCalcCostPrice";
            this.colSumPriceForCalcCostPrice.MinWidth = 150;
            this.colSumPriceForCalcCostPrice.Name = "colSumPriceForCalcCostPrice";
            this.colSumPriceForCalcCostPrice.OptionsColumn.AllowEdit = false;
            this.colSumPriceForCalcCostPrice.OptionsColumn.ReadOnly = true;
            this.colSumPriceForCalcCostPrice.SummaryItem.DisplayFormat = "Сумма, вал.: {0:### ### ##0.00}";
            this.colSumPriceForCalcCostPrice.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colSumPriceForCalcCostPrice.Visible = true;
            this.colSumPriceForCalcCostPrice.VisibleIndex = 16;
            this.colSumPriceForCalcCostPrice.Width = 150;
            // 
            // colSumWeight
            // 
            this.colSumWeight.Caption = "Вес (итого), кг.";
            this.colSumWeight.DisplayFormat.FormatString = "# ### ### ##0.000";
            this.colSumWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumWeight.FieldName = "SumWeightForQuantityInDoc";
            this.colSumWeight.MinWidth = 100;
            this.colSumWeight.Name = "colSumWeight";
            this.colSumWeight.OptionsColumn.AllowEdit = false;
            this.colSumWeight.OptionsColumn.ReadOnly = true;
            this.colSumWeight.SummaryItem.DisplayFormat = "Вес, кг.: {0:### ### ##0.000}";
            this.colSumWeight.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colSumWeight.Visible = true;
            this.colSumWeight.VisibleIndex = 17;
            this.colSumWeight.Width = 100;
            // 
            // colOrderPackQty
            // 
            this.colOrderPackQty.Caption = "OrderPackQty";
            this.colOrderPackQty.FieldName = "OrderPackQty";
            this.colOrderPackQty.Name = "colOrderPackQty";
            // 
            // colOrderItems_PartsName
            // 
            this.colOrderItems_PartsName.Caption = "colOrderItems_PartsName";
            this.colOrderItems_PartsName.FieldName = "OrderItems_PartsName";
            this.colOrderItems_PartsName.Name = "colOrderItems_PartsName";
            // 
            // colOrderItems_PartsArticle
            // 
            this.colOrderItems_PartsArticle.Caption = "colOrderItems_PartsArticle";
            this.colOrderItems_PartsArticle.FieldName = "OrderItems_PartsArticle";
            this.colOrderItems_PartsArticle.Name = "colOrderItems_PartsArticle";
            // 
            // colExpirationDate
            // 
            this.colExpirationDate.Caption = "Срок годности";
            this.colExpirationDate.ColumnEdit = this.repositoryItemDateEdit;
            this.colExpirationDate.FieldName = "ExpirationDate";
            this.colExpirationDate.Name = "colExpirationDate";
            this.colExpirationDate.Visible = true;
            this.colExpirationDate.VisibleIndex = 18;
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
            this.colCountryID.VisibleIndex = 12;
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
            // colCustomTarifPercent
            // 
            this.colCustomTarifPercent.Caption = "Тамож. тариф, %";
            this.colCustomTarifPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCustomTarifPercent.FieldName = "CustomTarifPercent";
            this.colCustomTarifPercent.MinWidth = 30;
            this.colCustomTarifPercent.Name = "colCustomTarifPercent";
            this.colCustomTarifPercent.Visible = true;
            this.colCustomTarifPercent.VisibleIndex = 11;
            // 
            // colOrderItems_CountryProductionName
            // 
            this.colOrderItems_CountryProductionName.Caption = "colOrderItems_CountryProductionName";
            this.colOrderItems_CountryProductionName.FieldName = "OrderItems_CountryProductionName";
            this.colOrderItems_CountryProductionName.Name = "colOrderItems_CountryProductionName";
            // 
            // colPriceForCalcCostPrice
            // 
            this.colPriceForCalcCostPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colPriceForCalcCostPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPriceForCalcCostPrice.Caption = "Цена вал. для расчёта С/С";
            this.colPriceForCalcCostPrice.DisplayFormat.FormatString = "# ### ### ##0.000";
            this.colPriceForCalcCostPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPriceForCalcCostPrice.FieldName = "PriceForCalcCostPrice";
            this.colPriceForCalcCostPrice.Name = "colPriceForCalcCostPrice";
            this.colPriceForCalcCostPrice.Visible = true;
            this.colPriceForCalcCostPrice.VisibleIndex = 10;
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
            this.tableLayoutPanel6.Controls.Add(this.labelControl6, 5, 0);
            this.tableLayoutPanel6.Controls.Add(this.spinEditCustomTarif, 6, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnSetCustomTarif, 7, 0);
            this.tableLayoutPanel6.Controls.Add(this.labelControl8, 8, 0);
            this.tableLayoutPanel6.Controls.Add(this.cboxCountryProduction, 9, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 215);
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
            this.btnSetDiscount.Click += new System.EventHandler(this.btnSetDiscount_Click);
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
            // labelControl6
            // 
            this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl6.Location = new System.Drawing.Point(576, 6);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(93, 13);
            this.labelControl6.TabIndex = 29;
            this.labelControl6.Text = "Тамож. тариф, %:";
            // 
            // spinEditCustomTarif
            // 
            this.spinEditCustomTarif.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditCustomTarif.Location = new System.Drawing.Point(674, 3);
            this.spinEditCustomTarif.Name = "spinEditCustomTarif";
            this.spinEditCustomTarif.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditCustomTarif.Size = new System.Drawing.Size(51, 20);
            this.spinEditCustomTarif.TabIndex = 30;
            // 
            // btnSetCustomTarif
            // 
            this.btnSetCustomTarif.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSetCustomTarif.Image = global::ERPMercuryLotOrder.Properties.Resources.sign_percentage_16;
            this.btnSetCustomTarif.Location = new System.Drawing.Point(728, 1);
            this.btnSetCustomTarif.Margin = new System.Windows.Forms.Padding(0);
            this.btnSetCustomTarif.Name = "btnSetCustomTarif";
            this.btnSetCustomTarif.Size = new System.Drawing.Size(23, 22);
            this.btnSetCustomTarif.TabIndex = 31;
            this.btnSetCustomTarif.ToolTip = "Установить тариф на все позиции";
            this.btnSetCustomTarif.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnSetCustomTarif.Click += new System.EventHandler(this.btnSetCustomTarif_Click);
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
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 188);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(1203, 27);
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
            this.cboxProductType.Location = new System.Drawing.Point(797, 3);
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
            this.cboxProductType.SelectedValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
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
            this.cboxProductTradeMark.Size = new System.Drawing.Size(380, 20);
            this.cboxProductTradeMark.TabIndex = 29;
            this.cboxProductTradeMark.ToolTip = "Товарная марка";
            this.cboxProductTradeMark.ToolTipController = this.toolTipController;
            this.cboxProductTradeMark.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cboxProductTradeMark.SelectedValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
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
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.btnPrint.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 9;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl10, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl7, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.BeginDate, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtLotOrderNum, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.DeliveryDate, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkLotOrderActive, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl9, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.ShipDate, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 20);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1203, 27);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel2, null);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Location = new System.Drawing.Point(3, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 13);
            this.labelControl1.TabIndex = 27;
            this.labelControl1.Text = "Заказ №:";
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl10.Location = new System.Drawing.Point(203, 7);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(67, 13);
            this.labelControl10.TabIndex = 20;
            this.labelControl10.Text = "Дата заказа:";
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl7.Location = new System.Drawing.Point(597, 7);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(145, 13);
            this.labelControl7.TabIndex = 26;
            this.labelControl7.Text = "Дата прихода (прогнозная):";
            // 
            // BeginDate
            // 
            this.BeginDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BeginDate.EditValue = null;
            this.BeginDate.Location = new System.Drawing.Point(275, 3);
            this.BeginDate.Name = "BeginDate";
            this.BeginDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BeginDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BeginDate.Size = new System.Drawing.Size(114, 20);
            this.BeginDate.TabIndex = 1;
            this.BeginDate.ToolTip = "Дата оформления заказа";
            this.BeginDate.ToolTipController = this.toolTipController;
            this.BeginDate.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.BeginDate.EditValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
            this.BeginDate.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtOrderPropertie_EditValueChanging);
            // 
            // txtLotOrderNum
            // 
            this.txtLotOrderNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLotOrderNum.Location = new System.Drawing.Point(72, 3);
            this.txtLotOrderNum.Name = "txtLotOrderNum";
            this.txtLotOrderNum.Size = new System.Drawing.Size(125, 20);
            this.txtLotOrderNum.TabIndex = 0;
            this.txtLotOrderNum.ToolTip = "Номер заказа";
            this.txtLotOrderNum.ToolTipController = this.toolTipController;
            this.txtLotOrderNum.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtLotOrderNum.EditValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
            this.txtLotOrderNum.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtOrderPropertie_EditValueChanging);
            // 
            // DeliveryDate
            // 
            this.DeliveryDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DeliveryDate.EditValue = null;
            this.DeliveryDate.Location = new System.Drawing.Point(750, 3);
            this.DeliveryDate.Name = "DeliveryDate";
            this.DeliveryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DeliveryDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DeliveryDate.Size = new System.Drawing.Size(114, 20);
            this.DeliveryDate.TabIndex = 3;
            this.DeliveryDate.ToolTip = "Планируемая дата доставки заказа";
            this.DeliveryDate.ToolTipController = this.toolTipController;
            this.DeliveryDate.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.DeliveryDate.EditValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
            this.DeliveryDate.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtOrderPropertie_EditValueChanging);
            // 
            // checkLotOrderActive
            // 
            this.checkLotOrderActive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkLotOrderActive.Location = new System.Drawing.Point(870, 4);
            this.checkLotOrderActive.Name = "checkLotOrderActive";
            this.checkLotOrderActive.Properties.Caption = "Активен";
            this.checkLotOrderActive.Size = new System.Drawing.Size(75, 19);
            this.checkLotOrderActive.TabIndex = 4;
            this.checkLotOrderActive.ToolTip = "Признак \"Поставка активна\"";
            this.checkLotOrderActive.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.checkLotOrderActive.EditValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
            this.checkLotOrderActive.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtOrderPropertie_EditValueChanging);
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl9.Location = new System.Drawing.Point(395, 7);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(79, 13);
            this.labelControl9.TabIndex = 28;
            this.labelControl9.Text = "Дата отгрузки:";
            // 
            // ShipDate
            // 
            this.ShipDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ShipDate.EditValue = null;
            this.ShipDate.Location = new System.Drawing.Point(477, 3);
            this.ShipDate.Name = "ShipDate";
            this.ShipDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ShipDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ShipDate.Size = new System.Drawing.Size(114, 20);
            this.ShipDate.TabIndex = 2;
            this.ShipDate.ToolTip = "Дата оформления заказа";
            this.ShipDate.ToolTipController = this.toolTipController;
            this.ShipDate.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.cboxCurrency, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl5, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.cboxLotOrderState, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.cboxVendor, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl2, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 47);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1203, 27);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel3, null);
            this.tableLayoutPanel3.TabIndex = 20;
            // 
            // cboxCurrency
            // 
            this.cboxCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxCurrency.Location = new System.Drawing.Point(895, 3);
            this.cboxCurrency.Name = "cboxCurrency";
            this.cboxCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxCurrency.Properties.PopupSizeable = true;
            this.cboxCurrency.Properties.Sorted = true;
            this.cboxCurrency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxCurrency.Size = new System.Drawing.Size(68, 20);
            this.cboxCurrency.TabIndex = 1;
            this.cboxCurrency.ToolTip = "Валюта расчёта с поставщиком";
            this.cboxCurrency.ToolTipController = this.toolTipController;
            this.cboxCurrency.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cboxCurrency.SelectedValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl5.Location = new System.Drawing.Point(969, 7);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(58, 13);
            this.labelControl5.TabIndex = 32;
            this.labelControl5.Text = "Состояние:";
            // 
            // cboxLotOrderState
            // 
            this.cboxLotOrderState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxLotOrderState.Location = new System.Drawing.Point(1033, 3);
            this.cboxLotOrderState.Name = "cboxLotOrderState";
            this.cboxLotOrderState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxLotOrderState.Properties.PopupSizeable = true;
            this.cboxLotOrderState.Properties.Sorted = true;
            this.cboxLotOrderState.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxLotOrderState.Size = new System.Drawing.Size(167, 20);
            this.cboxLotOrderState.TabIndex = 2;
            this.cboxLotOrderState.ToolTip = "Текущее состояние заказа";
            this.cboxLotOrderState.ToolTipController = this.toolTipController;
            this.cboxLotOrderState.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cboxLotOrderState.SelectedValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl3.Location = new System.Drawing.Point(844, 7);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(43, 13);
            this.labelControl3.TabIndex = 30;
            this.labelControl3.Text = "Валюта:";
            // 
            // cboxVendor
            // 
            this.cboxVendor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxVendor.Location = new System.Drawing.Point(72, 3);
            this.cboxVendor.Name = "cboxVendor";
            this.cboxVendor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxVendor.Properties.PopupSizeable = true;
            this.cboxVendor.Properties.Sorted = true;
            this.cboxVendor.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxVendor.Size = new System.Drawing.Size(766, 20);
            this.cboxVendor.TabIndex = 0;
            this.cboxVendor.ToolTip = "Поставщик";
            this.cboxVendor.ToolTipController = this.toolTipController;
            this.cboxVendor.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cboxVendor.SelectedValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
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
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.txtDescription, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelControl4, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 74);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1203, 83);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel4, null);
            this.tableLayoutPanel4.TabIndex = 21;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(72, 3);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(1128, 77);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.ToolTip = "Примечание";
            this.txtDescription.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtDescription.EditValueChanged += new System.EventHandler(this.cboxOrderPropertie_SelectedValueChanged);
            this.txtDescription.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtOrderPropertie_EditValueChanging);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl4.Location = new System.Drawing.Point(3, 35);
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
            // openFileDialog
            // 
            this.openFileDialog.Filter = "MS Excel 2010 files (*.xlsx)|*.xlsx|MS Excel 2003 files (*.xls)|*.xls|All files (" +
    "*.*)|*.*";
            // 
            // ctrlLotOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelBackground);
            this.Name = "ctrlLotOrder";
            this.Size = new System.Drawing.Size(1203, 624);
            this.toolTipController.SetSuperTip(this, null);
            this.Load += new System.EventHandler(this.ctrlLotOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEditOrderedQuantity)).EndInit();
            this.tableLayoutPanelBackground.ResumeLayout(false);
            this.tableLayoutPanelBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelProgressBar)).EndInit();
            this.panelProgressBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCustomTarif.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxCountryProduction.Properties)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxProductType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxProductTradeMark.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BeginDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeginDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotOrderNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLotOrderActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipDate.Properties)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxLotOrderState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxVendor.Properties)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController toolTipController;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBackground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.DateEdit DeliveryDate;
        private DevExpress.XtraEditors.DateEdit BeginDate;
        private DevExpress.XtraEditors.TextEdit txtLotOrderNum;
        private DevExpress.XtraEditors.CheckEdit checkLotOrderActive;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cboxVendor;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboxCurrency;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator;
        private DevExpress.XtraEditors.SpinEdit spinEditDiscount;
        private DevExpress.XtraEditors.SimpleButton btnSetDiscount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.ComboBoxEdit cboxProductTradeMark;
        private DevExpress.XtraEditors.PictureEdit pictureFilter;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.ComboBoxEdit cboxProductType;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderItemsID;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colMeasureID;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderItems_MeasureName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderedQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEditOrderedQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colConfirmQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colVendorPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountPercent;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colVendorPriceWithDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colSumOrdered;
        private DevExpress.XtraGrid.Columns.GridColumn colSumOrderedWithDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colSumConfirmed;
        private DevExpress.XtraGrid.Columns.GridColumn colSumConfirmedWithDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colSumInDoc;
        private DevExpress.XtraGrid.Columns.GridColumn colSumPriceForCalcCostPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderPackQty;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderItems_PartsName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderItems_PartsArticle;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit cboxLotOrderState;
        private System.Data.DataSet dataSet;
        private System.Data.DataTable OrderItems;
        private System.Data.DataColumn OrderItemsID;
        private System.Data.DataColumn ProductID;
        private System.Data.DataColumn MeasureID;
        private System.Data.DataColumn OrderedQuantity;
        private System.Data.DataColumn VendorPrice;
        private System.Data.DataColumn DiscountPercent;
        private System.Data.DataColumn VendorPriceWithDiscount;
        private System.Data.DataColumn QuantityInDoc;
        private System.Data.DataColumn SumOrdered;
        private System.Data.DataColumn SumOrderedWithDiscount;
        private System.Data.DataColumn SumInDoc;
        private System.Data.DataColumn SumInDocWithDiscount;
        private System.Data.DataColumn OrderItems_MeasureName;
        private System.Data.DataColumn ConfirmQuantity;
        private System.Data.DataColumn OrderItems_PartsArticle;
        private System.Data.DataColumn OrderItems_PartsName;
        private System.Data.DataTable Product;
        private System.Data.DataColumn ProductGuid;
        private System.Data.DataColumn ProductShortName;
        private System.Data.DataColumn CustomerOrderPackQty;
        private System.Data.DataColumn Product_MeasureID;
        private System.Data.DataColumn Product_MeasureName;
        private System.Data.DataColumn SumConfirmed;
        private System.Data.DataColumn SumConfirmedWithDiscount;
        private DevExpress.XtraEditors.CheckEdit checkMultiplicity;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
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
        private DevExpress.XtraEditors.PanelControl panelProgressBar;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantityInDoc;
        private System.Data.DataColumn OrderPackQty;
        private System.Data.DataColumn ProductArticle;
        private System.Data.DataColumn ProductFullName;
        private System.Windows.Forms.ToolStripMenuItem изMSExcelспецимпортToolStripMenuItem;
        private System.Data.DataColumn Product_VendorPrice;
        private System.Data.DataColumn Product_Weight;
        private System.Data.DataColumn SumWeightForQuantityInDoc;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct_Weight;
        private DevExpress.XtraGrid.Columns.GridColumn colVendorPriceInDirectory;
        private DevExpress.XtraGrid.Columns.GridColumn colSumWeight;
        private DevExpress.XtraEditors.LabelControl lblEditMode;
        private System.Data.DataColumn ExpirationDate;
        private DevExpress.XtraGrid.Columns.GridColumn colExpirationDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;
        private System.Data.DataColumn CountryProductionID;
        private System.Data.DataColumn OrderItems_CountryProductionName;
        private System.Data.DataColumn CustomTarifPercent;
        private System.Data.DataTable CountryProduction;
        private System.Data.DataColumn CountryProductionGuid;
        private System.Data.DataColumn CountryProductionName;
        private DevExpress.XtraGrid.Columns.GridColumn colCountryID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditCountryProduction;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomTarifPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderItems_CountryProductionName;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SpinEdit spinEditCustomTarif;
        private DevExpress.XtraEditors.SimpleButton btnSetCustomTarif;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit cboxCountryProduction;
        private System.Data.DataColumn PriceForCalcCostPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceForCalcCostPrice;
        private System.Data.DataColumn SumPriceForCalcCostPrice;
        private System.Windows.Forms.ToolStripMenuItem mitemClearPrice;
        private System.Windows.Forms.ToolStripMenuItem mitemRefreshPrices;
        private System.Windows.Forms.ToolStripMenuItem mitmsRefreshPricesByPartsId;
        private System.Windows.Forms.ToolStripMenuItem mitmsRefreshPricesByPartsFullName;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.DateEdit ShipDate;
    }
}
