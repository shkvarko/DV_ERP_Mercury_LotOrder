namespace ERPMercuryLotOrder
{
    partial class frmCharges
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControlTMGList = new DevExpress.XtraGrid.GridControl();
            this.gridViewTMGList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.dtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeleteCertificate = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddCertificate = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboxChargesType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboxCurrency = new DevExpress.XtraEditors.ComboBoxEdit();
            this.calcCharges_Value = new DevExpress.XtraEditors.CalcEdit();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.calcCharges_CurrencyRate = new DevExpress.XtraEditors.CalcEdit();
            this.calcCharges_Expense = new DevExpress.XtraEditors.CalcEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.calcCharges_Rest = new DevExpress.XtraEditors.CalcEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.dtChargesDate = new DevExpress.XtraEditors.DateEdit();
            this.lblInfo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.dtBeginDate = new DevExpress.XtraEditors.DateEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTMGList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTMGList)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxChargesType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcCharges_Value.Properties)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calcCharges_CurrencyRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcCharges_Expense.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcCharges_Rest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtChargesDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtChargesDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBeginDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBeginDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 273F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(892, 597);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel1, null);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.gridControlTMGList, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(610, 589);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel2, null);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // gridControlTMGList
            // 
            this.gridControlTMGList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTMGList.EmbeddedNavigator.Name = "";
            this.gridControlTMGList.Location = new System.Drawing.Point(3, 28);
            this.gridControlTMGList.MainView = this.gridViewTMGList;
            this.gridControlTMGList.Name = "gridControlTMGList";
            this.gridControlTMGList.Size = new System.Drawing.Size(604, 558);
            this.gridControlTMGList.TabIndex = 1;
            this.gridControlTMGList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTMGList});
            // 
            // gridViewTMGList
            // 
            this.gridViewTMGList.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gridViewTMGList.Appearance.Row.Options.UseBackColor = true;
            this.gridViewTMGList.GridControl = this.gridControlTMGList;
            this.gridViewTMGList.Name = "gridViewTMGList";
            this.gridViewTMGList.OptionsBehavior.Editable = false;
            this.gridViewTMGList.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewTMGList.OptionsDetail.ShowDetailTabs = false;
            this.gridViewTMGList.OptionsDetail.SmartDetailExpand = false;
            this.gridViewTMGList.OptionsView.ShowGroupPanel = false;
            this.gridViewTMGList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewTMGList_FocusedRowChanged);
            this.gridViewTMGList.RowCountChanged += new System.EventHandler(this.gridViewTMGList_RowCountChanged);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.dtEndDate, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.labelControl8, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.dtBeginDate, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnRefresh, 3, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(610, 25);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel6, null);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // dtEndDate
            // 
            this.dtEndDate.EditValue = null;
            this.dtEndDate.Location = new System.Drawing.Point(202, 3);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEndDate.Size = new System.Drawing.Size(99, 20);
            this.dtEndDate.TabIndex = 6;
            this.dtEndDate.ToolTip = "Укажите окончание периода для поиска";
            this.dtEndDate.ToolTipController = this.toolTipController;
            this.dtEndDate.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel11, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl25, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.labelControl1, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelControl2, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.labelControl3, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.labelControl4, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.cboxChargesType, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.cboxCurrency, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.calcCharges_Value, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 8);
            this.tableLayoutPanel3.Controls.Add(this.calcCharges_CurrencyRate, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.calcCharges_Expense, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.labelControl5, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.calcCharges_Rest, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.labelControl6, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.dtChargesDate, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblInfo, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(621, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 9;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(267, 589);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel3, null);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 3;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.btnDeleteCertificate, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.btnAddCertificate, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.btnPrint, 2, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(94, 25);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel11, null);
            this.tableLayoutPanel11.TabIndex = 7;
            // 
            // btnDeleteCertificate
            // 
            this.btnDeleteCertificate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDeleteCertificate.Image = global::ERPMercuryLotOrder.Properties.Resources.delete2;
            this.btnDeleteCertificate.Location = new System.Drawing.Point(26, 1);
            this.btnDeleteCertificate.Margin = new System.Windows.Forms.Padding(1);
            this.btnDeleteCertificate.Name = "btnDeleteCertificate";
            this.btnDeleteCertificate.Size = new System.Drawing.Size(23, 23);
            this.btnDeleteCertificate.TabIndex = 1;
            this.btnDeleteCertificate.ToolTip = "Удалить расход";
            this.btnDeleteCertificate.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnDeleteCertificate.Click += new System.EventHandler(this.btnDeleteCertificate_Click);
            // 
            // btnAddCertificate
            // 
            this.btnAddCertificate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddCertificate.Image = global::ERPMercuryLotOrder.Properties.Resources.add2;
            this.btnAddCertificate.Location = new System.Drawing.Point(1, 1);
            this.btnAddCertificate.Margin = new System.Windows.Forms.Padding(1);
            this.btnAddCertificate.Name = "btnAddCertificate";
            this.btnAddCertificate.Size = new System.Drawing.Size(23, 23);
            this.btnAddCertificate.TabIndex = 0;
            this.btnAddCertificate.ToolTip = "Добавить новый расход";
            this.btnAddCertificate.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnAddCertificate.Click += new System.EventHandler(this.btnAddCertificate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPrint.Image = global::ERPMercuryLotOrder.Properties.Resources.printer2;
            this.btnPrint.Location = new System.Drawing.Point(51, 1);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(1);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(23, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.ToolTip = "Печать списка расходов";
            this.btnPrint.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnPrint.Click += new System.EventHandler(this.sbExportToXLS_Click);
            // 
            // labelControl25
            // 
            this.labelControl25.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl25.Location = new System.Drawing.Point(3, 56);
            this.labelControl25.Name = "labelControl25";
            this.labelControl25.Size = new System.Drawing.Size(67, 13);
            this.labelControl25.TabIndex = 8;
            this.labelControl25.Text = "Тип расхода:";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Location = new System.Drawing.Point(3, 81);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Валюта:";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl2.Location = new System.Drawing.Point(3, 106);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Курс:";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl3.Location = new System.Drawing.Point(3, 131);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Сумма:";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl4.Location = new System.Drawing.Point(3, 156);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "Расход:";
            // 
            // cboxChargesType
            // 
            this.cboxChargesType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxChargesType.Location = new System.Drawing.Point(97, 53);
            this.cboxChargesType.Name = "cboxChargesType";
            this.cboxChargesType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxChargesType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxChargesType.Size = new System.Drawing.Size(167, 20);
            this.cboxChargesType.TabIndex = 1;
            this.cboxChargesType.ToolTip = "Тип дополнительного расхода";
            this.cboxChargesType.ToolTipController = this.toolTipController;
            this.cboxChargesType.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cboxChargesType.EditValueChanged += new System.EventHandler(this.TradeMarkChargesProperties_SelectedValueChanged);
            this.cboxChargesType.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.TradeMarkChargesProperties_EditValueChanging);
            // 
            // cboxCurrency
            // 
            this.cboxCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxCurrency.Location = new System.Drawing.Point(97, 78);
            this.cboxCurrency.Name = "cboxCurrency";
            this.cboxCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxCurrency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxCurrency.Size = new System.Drawing.Size(167, 20);
            this.cboxCurrency.TabIndex = 2;
            this.cboxCurrency.ToolTip = "Валюта платежа";
            this.cboxCurrency.ToolTipController = this.toolTipController;
            this.cboxCurrency.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cboxCurrency.EditValueChanged += new System.EventHandler(this.TradeMarkChargesProperties_SelectedValueChanged);
            this.cboxCurrency.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.TradeMarkChargesProperties_EditValueChanging);
            // 
            // calcCharges_Value
            // 
            this.calcCharges_Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.calcCharges_Value.Location = new System.Drawing.Point(97, 128);
            this.calcCharges_Value.Name = "calcCharges_Value";
            this.calcCharges_Value.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcCharges_Value.Size = new System.Drawing.Size(167, 20);
            this.calcCharges_Value.TabIndex = 4;
            this.calcCharges_Value.ToolTip = "Сумма дополнительного расхода в валюте оплаты";
            this.calcCharges_Value.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.calcCharges_Value.EditValueChanged += new System.EventHandler(this.TradeMarkChargesProperties_SelectedValueChanged);
            this.calcCharges_Value.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.TradeMarkChargesProperties_EditValueChanging);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(94, 559);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(173, 30);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel4, null);
            this.tableLayoutPanel4.TabIndex = 20;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::ERPMercuryLotOrder.Properties.Resources.cancel_16;
            this.btnCancel.Location = new System.Drawing.Point(95, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.ToolTip = "Отменить изменения";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::ERPMercuryLotOrder.Properties.Resources.disk_blue_ok;
            this.btnSave.Location = new System.Drawing.Point(13, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "ОК";
            this.btnSave.ToolTip = "Сохранить изменения";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // calcCharges_CurrencyRate
            // 
            this.calcCharges_CurrencyRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.calcCharges_CurrencyRate.Location = new System.Drawing.Point(97, 103);
            this.calcCharges_CurrencyRate.Name = "calcCharges_CurrencyRate";
            this.calcCharges_CurrencyRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcCharges_CurrencyRate.Size = new System.Drawing.Size(167, 20);
            this.calcCharges_CurrencyRate.TabIndex = 3;
            this.calcCharges_CurrencyRate.ToolTip = "Курс валюты расхода к основной валюте учёта";
            this.calcCharges_CurrencyRate.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.calcCharges_CurrencyRate.EditValueChanged += new System.EventHandler(this.TradeMarkChargesProperties_SelectedValueChanged);
            this.calcCharges_CurrencyRate.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.TradeMarkChargesProperties_EditValueChanging);
            // 
            // calcCharges_Expense
            // 
            this.calcCharges_Expense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.calcCharges_Expense.Location = new System.Drawing.Point(97, 153);
            this.calcCharges_Expense.Name = "calcCharges_Expense";
            this.calcCharges_Expense.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcCharges_Expense.Size = new System.Drawing.Size(167, 20);
            this.calcCharges_Expense.TabIndex = 5;
            this.calcCharges_Expense.ToolTip = "Сумма разнесённая по КЛП";
            this.calcCharges_Expense.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl5.Location = new System.Drawing.Point(3, 181);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(47, 13);
            this.labelControl5.TabIndex = 27;
            this.labelControl5.Text = "Остаток:";
            // 
            // calcCharges_Rest
            // 
            this.calcCharges_Rest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.calcCharges_Rest.Location = new System.Drawing.Point(97, 178);
            this.calcCharges_Rest.Name = "calcCharges_Rest";
            this.calcCharges_Rest.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcCharges_Rest.Size = new System.Drawing.Size(167, 20);
            this.calcCharges_Rest.TabIndex = 6;
            this.calcCharges_Rest.ToolTip = "Сумма остатка";
            this.calcCharges_Rest.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl6.Location = new System.Drawing.Point(3, 31);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(77, 13);
            this.labelControl6.TabIndex = 29;
            this.labelControl6.Text = "Дата платежа:";
            // 
            // dtChargesDate
            // 
            this.dtChargesDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtChargesDate.EditValue = null;
            this.dtChargesDate.Location = new System.Drawing.Point(97, 28);
            this.dtChargesDate.Name = "dtChargesDate";
            this.dtChargesDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtChargesDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtChargesDate.Size = new System.Drawing.Size(167, 20);
            this.dtChargesDate.TabIndex = 0;
            this.dtChargesDate.ToolTip = "Дата платежа";
            this.dtChargesDate.ToolTipController = this.toolTipController;
            this.dtChargesDate.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.dtChargesDate.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.TradeMarkChargesProperties_EditValueChanging);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblInfo.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Appearance.Options.UseFont = true;
            this.lblInfo.Appearance.Options.UseForeColor = true;
            this.lblInfo.Location = new System.Drawing.Point(97, 6);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(36, 13);
            this.lblInfo.TabIndex = 30;
            this.lblInfo.Text = "lblInfo";
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl8.Location = new System.Drawing.Point(3, 6);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(80, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Период поиска:";
            // 
            // dtBeginDate
            // 
            this.dtBeginDate.EditValue = null;
            this.dtBeginDate.Location = new System.Drawing.Point(97, 3);
            this.dtBeginDate.Name = "dtBeginDate";
            this.dtBeginDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtBeginDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtBeginDate.Size = new System.Drawing.Size(99, 20);
            this.dtBeginDate.TabIndex = 5;
            this.dtBeginDate.ToolTip = "Укажите начало периода для поиска";
            this.dtBeginDate.ToolTipController = this.toolTipController;
            this.dtBeginDate.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRefresh.Image = global::ERPMercuryLotOrder.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(305, 1);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 23);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.ToolTip = "Обновить список расходов";
            this.btnRefresh.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmCharges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 597);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmCharges";
            this.toolTipController.SetSuperTip(this, null);
            this.Text = "frmTradeMarkCharges";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTMGList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTMGList)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboxChargesType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcCharges_Value.Properties)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calcCharges_CurrencyRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcCharges_Expense.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcCharges_Rest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtChargesDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtChargesDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBeginDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBeginDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraGrid.GridControl gridControlTMGList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTMGList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private DevExpress.XtraEditors.SimpleButton btnDeleteCertificate;
        private DevExpress.XtraEditors.SimpleButton btnAddCertificate;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cboxChargesType;
        private DevExpress.XtraEditors.ComboBoxEdit cboxCurrency;
        private DevExpress.XtraEditors.CalcEdit calcCharges_Value;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.Utils.ToolTipController toolTipController;
        private DevExpress.XtraEditors.CalcEdit calcCharges_CurrencyRate;
        private DevExpress.XtraEditors.DateEdit dtEndDate;
        private DevExpress.XtraEditors.DateEdit dtBeginDate;
        private DevExpress.XtraEditors.CalcEdit calcCharges_Expense;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.CalcEdit calcCharges_Rest;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.DateEdit dtChargesDate;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.LabelControl lblInfo;
    }
}